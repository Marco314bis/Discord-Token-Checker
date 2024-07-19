using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TokensChecker
{
    public partial class Form3 : Form
    {
        private readonly List<TokenInfo> tokens;
        public Form3(List<TokenInfo> tokenList, TokenCheckerOptions tokenOptions)
        {

            InitializeComponent();
            tokens = tokenList;
            if (!tokenOptions.PaymentMethod)
            {
                chkPaymentMethods.Visible = false;
                panel6.Visible = false;
                textBoxPaymentMethods.Visible = false;
                btnPaymentMethods.Visible = false;
            }
            if (!tokenOptions.NitroInfo)
                groupBoxNitro.Visible = false;
        }

        private void HandleSaveButtonClick(TextBox targetTextBox, string dialogTitle)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Normal text file (*.txt)|*.txt";
                saveFileDialog.Title = dialogTitle.Replace("Location", "");
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.FileName = dialogTitle;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    targetTextBox.Text = saveFileDialog.FileName;
                }
            }
        }

        private void BtnEmailVerified_Click(object sender, EventArgs e)
        {
            HandleSaveButtonClick(textBoxEmailVerified, "Email Verified Tokens Location");
        }
        private void BtnFullyVerified_Click(object sender, EventArgs e)
        {
            HandleSaveButtonClick(textBoxFullyVerified, "Fully Verified Tokens Location");
        }

        private void BtnUnclaimed_Click(object sender, EventArgs e)
        {
            HandleSaveButtonClick(textBoxUnclaimed, "Unclaimed Tokens Location");
        }

        private void BtnLocked_Click(object sender, EventArgs e)
        {
            HandleSaveButtonClick(textBoxLocked, "Phone Locked Tokens Location");
        }

        private void BtnInvalid_Click(object sender, EventArgs e)
        {
            HandleSaveButtonClick(textBoxInvalid, "Invalid Tokens Location");
        }

        private void BtnPaymentMethods_Click(object sender, EventArgs e)
        {
            HandleSaveButtonClick(textBoxPaymentMethods, "Payment Methods Tokens Location");
        }

        private void BtnNitro_Click(object sender, EventArgs e)
        {
            HandleSaveButtonClick(textBoxNitro, "Nitro Tokens Location");
        }

        private void StatusExportBtn_Click(object sender, EventArgs e)
        {
            var exportConfigs = new List<(CheckBox Checkbox, TextBox TextBox, Func<TokenInfo, bool> Predicate)>
            {
                (chkEmailVerified, textBoxEmailVerified, t => t.Type == "Email Verified"),
                (chkFullyVerified, textBoxFullyVerified, t => t.Type == "Fully Verified"),
                (chkUnclaimed, textBoxUnclaimed, t => t.Type == "Unclaimed"),
                (chkLocked, textBoxLocked, t => t.Locked),
                (chkInvalid, textBoxInvalid, t => !t.Valid),
                (chkPaymentMethods, textBoxPaymentMethods, t => t.PaymentMethods?.Count > 0),
                (chkHasNitro, textBoxNitro, t => t.Nitro != "None")
            };

            foreach (var (checkbox, textBox, predicate) in exportConfigs)
            {
                if (checkbox.Checked)
                {
                    try
                    {
                        var filteredTokens = tokens.Where(predicate).Select(t => t.Token);
                        File.AppendAllLines(textBox.Text, filteredTokens);
                    }
                    catch{}
                }
            }
            MessageBox.Show("Tokens successfully exported!", "Export success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DateExportBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                ShowNewFolderButton = true,
                Description = "Select the folder in which to export tokens"
            };
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                return;
            List<string> checkedItems = checkedListBoxDates.CheckedItems.Cast<string>().ToList();
            foreach (TokenInfo token in tokens)
            {
                if (token.CreationDate != null)
                {
                    string year = DateTime.ParseExact(token.CreationDate, "MMM dd yyyy - HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture).Year.ToString();
                    if (checkedItems.Contains(year))
                    {
                        File.AppendAllText(Path.Combine(folderBrowserDialog.SelectedPath, $"{year}.txt"), token.Token + Environment.NewLine);
                    }
                }
            }
            MessageBox.Show($"Tokens successfully exported by creation date in {folderBrowserDialog.SelectedPath}!", "Export success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void NitroExportBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                ShowNewFolderButton = true,
                Description = "Select the folder in which to export tokens"
            };
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                return;
            var nitroTokens = tokens.Where(t => t.Nitro != "None").Select(t => t);
            foreach (TokenInfo token in nitroTokens)
            {
                if (chkBoostCount.Checked)
                {   
                    File.AppendAllText(Path.Combine(folderBrowserDialog.SelectedPath, $"{token.NitroAvailableBoosts} Boosts.txt"), token.Token + Environment.NewLine);
                }
                if (chkNitroExpiration.Checked)
                {
                    File.AppendAllText(Path.Combine(folderBrowserDialog.SelectedPath, $"{token.NitroRemainingDays} Remaining Days.txt"), token.Token + Environment.NewLine);
                }
            }
            MessageBox.Show($"Nitro tokens successfully exported in {folderBrowserDialog.SelectedPath}!", "Export success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void JsonExportBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                Title = "Export datas as JSON",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                string jsonContent = JsonConvert.SerializeObject(tokens, settings);
                File.WriteAllText(filePath, jsonContent);
                MessageBox.Show($"Tokens successfully exported in {filePath}!", "Export success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
