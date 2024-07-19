using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TokensChecker
{
    public partial class Form2 : Form
    {
        private readonly List<TokenInfo> tokens;
        private readonly TokenCheckerOptions options;
        private readonly ImageList imageList;
        private readonly ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
        private readonly Dictionary<CheckBox, ColumnInfo> columnInfos = new Dictionary<CheckBox, ColumnInfo>();
        private Dictionary<CheckBox, ColumnHeader> checkboxs_list;

        public Form2(List<TokenInfo> tokenResults, TokenCheckerOptions tokenOptions, ImageList images)
        {
            InitializeComponent();
            tokens = tokenResults;
            options = tokenOptions;
            imageList = images;
            tokensListView.ListViewItemSorter = lvwColumnSorter;
        }

        private void Form2_Load(object sender, System.EventArgs e)
        {
            InitializeCheckboxList();
            InitializeCheckboxState();
            InitializeListView();
        }

        private void InitializeCheckboxList()
        {
            checkboxs_list = new Dictionary<CheckBox, ColumnHeader> {
                {show_token, new ColumnHeader { Text = "Token", Width = 240 }},
                {show_validity, new ColumnHeader { Text = "Valid", Width = 60 }},
                {show_lock_status, new ColumnHeader { Text = "Locked", Width = 90 }},
                {show_check_status, new ColumnHeader { Text = "Check Status", Width = 150 }},
                {show_id, new ColumnHeader { Text = "ID", Width = 120 }},
                {show_username, new ColumnHeader { Text = "Username", Width = 150 }},
                {show_global_name, new ColumnHeader { Text = "Global Name", Width = 150 }},
                {show_creation_date, new ColumnHeader { Text = "Creation Date", Width = 150 }},
                {show_flags, new ColumnHeader { Text = "Flags", Width = 150 }},
                {show_type, new ColumnHeader { Text = "Token Type", Width = 100 }},
                {show_email, new ColumnHeader { Text = "Email Address", Width = 150 }},
                {show_phone_number, new ColumnHeader { Text = "Phone Number", Width = 100 }},
                {show_locale, new ColumnHeader { Text = "Locale", Width = 80 }},
                {show_bio, new ColumnHeader { Text = "Bio", Width = 150 }},
                {show_friend_count, new ColumnHeader { Text = "Friend Count", Width = 90 }},
                {show_guild_count, new ColumnHeader { Text = "Guild count", Width = 80 }},
                {show_dms_count, new ColumnHeader { Text = "Dm history count", Width = 120 }},
                {show_payment_method, new ColumnHeader { Text = "Payment Methods", Width = 120 }},
                {show_nitro_type, new ColumnHeader { Text = "Nitro", Width = 90 }},
                {show_nitro_start, new ColumnHeader { Text = "Nitro Start Date", Width = 120 }},
                {show_nitro_end, new ColumnHeader { Text = "Nitro End Date", Width = 120 }},
                {show_nitro_remaining, new ColumnHeader { Text = "Nitro Days Remaining", Width = 140 }},
                {show_available_boosts, new ColumnHeader { Text = "Available Boosts", Width = 120 }},
                {show_boosts_cooldowns, new ColumnHeader { Text = "Boosts Cooldowns", Width = 120 }},
            };
            foreach (var clh in checkboxs_list.Values)
            {
                clh.TextAlign = HorizontalAlignment.Center;
            }
        }

        private void InitializeCheckboxState()
        {
            foreach (var kvp in checkboxs_list)
            {
                if (!kvp.Key.Visible)
                {
                    if (ShouldShowColumn(kvp.Key))
                    {
                        kvp.Key.Visible = true;
                    }
                }
            }
        }

        private void InitializeListView()
        {
            if (imageList != null && imageList.Images.Count > 0)
            {
                tokensListView.SmallImageList = imageList;
            }

            int index = 0;
            foreach (var kvp in checkboxs_list)
            {
                columnInfos[kvp.Key] = new ColumnInfo
                {
                    Header = kvp.Value,
                    OriginalIndex = index++,
                    Width = kvp.Value.Width
                };

                if (ShouldShowColumn(kvp.Key))
                {
                    tokensListView.Columns.Add(kvp.Value);
                }
            }

            foreach (var token in tokens)
            {
                var item = new ListViewItem(GetTokenValue(token, checkboxs_list.First().Key));
                foreach (var kvp in checkboxs_list.Skip(1))
                {
                    if (ShouldShowColumn(kvp.Key))
                    {
                        item.SubItems.Add(GetTokenValue(token, kvp.Key));
                    }
                }
                if (imageList != null && imageList.Images.ContainsKey(token.Token))
                {
                    item.ImageKey = token.Token;
                }
                tokensListView.Items.Add(item);
            }

            foreach (var checkbox in checkboxs_list.Keys)
            {
                checkbox.CheckedChanged += Checkbox_CheckedChanged;
            }
        }

        private string GetTokenValue(TokenInfo token, CheckBox checkbox)
        {
            if (checkbox == show_token) return token.Token ?? "None";
            if (checkbox == show_validity) return token.Valid.ToString();
            if (checkbox == show_lock_status) return token.Locked.ToString();
            if (checkbox == show_check_status) return token.Status ?? "None";
            if (checkbox == show_id) return token.Id != 0 ? token.Id.ToString() : string.Empty;
            if (checkbox == show_username) return token.Username ?? string.Empty;
            if (checkbox == show_global_name) return token.GlobalName ?? "None";
            if (checkbox == show_creation_date) return token.CreationDate ?? string.Empty;
            if (checkbox == show_flags) return (token.Flags == null || !token.Flags.Any()) ? "None" : string.Join(", ", token.Flags);
            if (checkbox == show_type) return token.Type ?? "None";
            if (checkbox == show_email) return token.Email ?? "None";
            if (checkbox == show_phone_number) return token.Phone ?? "None";
            if (checkbox == show_locale) return token.Locale ?? "None";
            if (checkbox == show_bio) return token.Bio ?? "None";
            if (checkbox == show_friend_count) return token.FriendsCount != 0 ? token.FriendsCount.ToString() : string.Empty;
            if (checkbox == show_guild_count) return token.GuildCount != 0 ? token.GuildCount.ToString() : string.Empty;
            if (checkbox == show_dms_count) return token.DmHistoryCount != 0 ? token.DmHistoryCount.ToString() : string.Empty;
            if (checkbox == show_payment_method) return (token.PaymentMethods == null || !token.PaymentMethods.Any()) ? "None" : string.Join(", ", token.PaymentMethods);
            if (checkbox == show_nitro_type) return token.Nitro ?? "None";
            if (checkbox == show_nitro_start) return token.NitroStartedAt ?? string.Empty;
            if (checkbox == show_nitro_end) return token.NitroEndsAt ?? string.Empty;
            if (checkbox == show_nitro_remaining) return token.NitroRemainingDays.ToString();
            if (checkbox == show_available_boosts) return token.NitroAvailableBoosts.ToString();
            if (checkbox == show_boosts_cooldowns) return (token.BoostCooldowns == null || !token.BoostCooldowns.Any()) ? "None" : string.Join(", ", token.BoostCooldowns);

            return string.Empty;
        }

        private void Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;
            if (columnInfos.TryGetValue(checkbox, out ColumnInfo columnInfo))
            {
                if (checkbox.Checked)
                {
                    if (!tokensListView.Columns.Contains(columnInfo.Header))
                    {
                        int insertIndex = tokensListView.Columns.Count;
                        for (int i = 0; i < tokensListView.Columns.Count; i++)
                        {
                            var currentCheckbox = checkboxs_list.FirstOrDefault(x => x.Value == tokensListView.Columns[i]).Key;
                            if (columnInfos[currentCheckbox].OriginalIndex > columnInfo.OriginalIndex)
                            {
                                insertIndex = i;
                                break;
                            }
                        }
                        tokensListView.Columns.Insert(insertIndex, columnInfo.Header);

                        columnInfo.Header.Width = columnInfo.Width;

                        foreach (ListViewItem item in tokensListView.Items)
                        {
                            item.SubItems.Insert(insertIndex, new ListViewItem.ListViewSubItem(item, GetTokenValue(tokens[item.Index], checkbox)));
                        }
                    }
                }
                else
                {
                    if (tokensListView.Columns.Contains(columnInfo.Header))
                    {
                        columnInfo.Width = columnInfo.Header.Width;

                        int columnIndex = tokensListView.Columns.IndexOf(columnInfo.Header);
                        tokensListView.Columns.Remove(columnInfo.Header);
                        foreach (ListViewItem item in tokensListView.Items)
                        {
                            item.SubItems.RemoveAt(columnIndex);
                        }
                    }
                }
            }
        }

        private bool ShouldShowColumn(CheckBox checkbox)
        {
            if (checkbox == show_friend_count) return options.FriendsCount;
            if (checkbox == show_guild_count) return options.GuildCount;
            if (checkbox == show_dms_count) return options.DmHistoryCount;
            if (checkbox == show_payment_method) return options.PaymentMethod;
            if (checkbox == show_nitro_start ||
                checkbox == show_nitro_end || checkbox == show_nitro_remaining ||
                checkbox == show_available_boosts || checkbox == show_boosts_cooldowns)
                return options.NitroInfo;

            return checkbox.Checked;
        }

        private void TokensListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var focusedItem = tokensListView.FocusedItem;
                if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    contextMenuStrip.Show(Cursor.Position);
                }
            }
        }

        private void TokensListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }
            tokensListView.Sort();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(tokens, options);
            form3.ShowDialog();
        }

        private void CopyToken_Click(object sender, EventArgs e)
        {
            var selectedTokens = tokensListView.SelectedItems.Cast<ListViewItem>()
                                               .Select(item => item.Text)
                                               .ToList();
            if (selectedTokens.Any())
            {
                string textToCopy = string.Join(Environment.NewLine, selectedTokens);
                Clipboard.SetText(textToCopy);
            }
        }

        private void CopyLoginScript_Click(object sender, EventArgs e)
        {
            string token = tokensListView.SelectedItems[0].Text;
            string code = $@"setInterval(() => {{document.body.appendChild(document.createElement `iframe`).contentWindow.localStorage.token = `""{token}""`}}, 50);setTimeout(() => {{location.reload();}}, 2500);";
            Clipboard.SetText(code);
        }

        private void CopyAsJson_Click(object sender, EventArgs e)
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            if (tokensListView.SelectedItems.Count == 1)
            {
                TokenInfo token = tokens.FirstOrDefault(t => t.Token == tokensListView.SelectedItems[0].Text);
                string jsonString = JsonConvert.SerializeObject(token, settings);
                Clipboard.SetText(jsonString);
            }
            else
            {
                List<TokenInfo> accs = new List<TokenInfo>();
                foreach (ListViewItem item in tokensListView.SelectedItems)
                {
                    accs.Add(tokens.FirstOrDefault(t => t.Token == item.Text));
                }
                string json = JsonConvert.SerializeObject(accs, settings);
                Clipboard.SetText(json);
            }
        }

        private class ColumnInfo
        {
            public ColumnHeader Header { get; set; }
            public int OriginalIndex { get; set; }
            public int Width { get; set; }
        }
    }
}