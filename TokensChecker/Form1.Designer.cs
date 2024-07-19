using System.Drawing;

namespace TokensChecker
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.title_label = new System.Windows.Forms.Label();
            this.tokens_textbox = new System.Windows.Forms.TextBox();
            this.tokens_label = new System.Windows.Forms.Label();
            this.guild_count = new System.Windows.Forms.CheckBox();
            this.dm_history_count = new System.Windows.Forms.CheckBox();
            this.friends_count = new System.Windows.Forms.CheckBox();
            this.avatar_preview = new System.Windows.Forms.CheckBox();
            this.payment_methods = new System.Windows.Forms.CheckBox();
            this.link_label = new System.Windows.Forms.Label();
            this.nitro_infos = new System.Windows.Forms.CheckBox();
            this.threads_label = new System.Windows.Forms.Label();
            this.threads_amount = new System.Windows.Forms.NumericUpDown();
            this.uses_proxies = new System.Windows.Forms.CheckBox();
            this.checkBtn = new TokensChecker.CustomButton();
            this.chkStatistics = new System.Windows.Forms.CheckBox();
            this.linkLabelGuns = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.threads_amount)).BeginInit();
            this.SuspendLayout();
            // 
            // title_label
            // 
            this.title_label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_label.Location = new System.Drawing.Point(277, 9);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(304, 40);
            this.title_label.TabIndex = 0;
            this.title_label.Text = "Discord Token Checker";
            // 
            // tokens_textbox
            // 
            this.tokens_textbox.AcceptsReturn = true;
            this.tokens_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tokens_textbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.tokens_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tokens_textbox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.tokens_textbox.Location = new System.Drawing.Point(12, 92);
            this.tokens_textbox.MaxLength = 2147483647;
            this.tokens_textbox.Multiline = true;
            this.tokens_textbox.Name = "tokens_textbox";
            this.tokens_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tokens_textbox.Size = new System.Drawing.Size(844, 344);
            this.tokens_textbox.TabIndex = 1;
            // 
            // tokens_label
            // 
            this.tokens_label.AutoSize = true;
            this.tokens_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tokens_label.Location = new System.Drawing.Point(9, 63);
            this.tokens_label.Name = "tokens_label";
            this.tokens_label.Size = new System.Drawing.Size(345, 17);
            this.tokens_label.TabIndex = 3;
            this.tokens_label.Text = "Input tokens: (or import tokens from files by clicking here)";
            this.tokens_label.Click += new System.EventHandler(this.TokensLabel_Click);
            // 
            // guild_count
            // 
            this.guild_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.guild_count.AutoSize = true;
            this.guild_count.Location = new System.Drawing.Point(12, 442);
            this.guild_count.Name = "guild_count";
            this.guild_count.Size = new System.Drawing.Size(93, 21);
            this.guild_count.TabIndex = 4;
            this.guild_count.Text = "Guild count";
            this.guild_count.UseVisualStyleBackColor = true;
            // 
            // dm_history_count
            // 
            this.dm_history_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dm_history_count.AutoSize = true;
            this.dm_history_count.Location = new System.Drawing.Point(128, 442);
            this.dm_history_count.Name = "dm_history_count";
            this.dm_history_count.Size = new System.Drawing.Size(126, 21);
            this.dm_history_count.TabIndex = 5;
            this.dm_history_count.Text = "Dm history count";
            this.dm_history_count.UseVisualStyleBackColor = true;
            // 
            // friends_count
            // 
            this.friends_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.friends_count.AutoSize = true;
            this.friends_count.Location = new System.Drawing.Point(12, 471);
            this.friends_count.Name = "friends_count";
            this.friends_count.Size = new System.Drawing.Size(105, 21);
            this.friends_count.TabIndex = 6;
            this.friends_count.Text = "Friends count";
            this.friends_count.UseVisualStyleBackColor = true;
            // 
            // avatar_preview
            // 
            this.avatar_preview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.avatar_preview.AutoSize = true;
            this.avatar_preview.Location = new System.Drawing.Point(128, 471);
            this.avatar_preview.Name = "avatar_preview";
            this.avatar_preview.Size = new System.Drawing.Size(111, 21);
            this.avatar_preview.TabIndex = 7;
            this.avatar_preview.Text = "Preview avatar";
            this.avatar_preview.UseVisualStyleBackColor = true;
            // 
            // payment_methods
            // 
            this.payment_methods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.payment_methods.AutoSize = true;
            this.payment_methods.Location = new System.Drawing.Point(260, 442);
            this.payment_methods.Name = "payment_methods";
            this.payment_methods.Size = new System.Drawing.Size(131, 21);
            this.payment_methods.TabIndex = 9;
            this.payment_methods.Text = "Payment methods";
            this.payment_methods.UseVisualStyleBackColor = true;
            // 
            // link_label
            // 
            this.link_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.link_label.AutoSize = true;
            this.link_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.link_label.Location = new System.Drawing.Point(559, 64);
            this.link_label.Name = "link_label";
            this.link_label.Size = new System.Drawing.Size(173, 17);
            this.link_label.TabIndex = 10;
            this.link_label.Text = "Made by bio.link/digitalcord";
            this.link_label.Click += new System.EventHandler(this.LinkLabel_Click);
            // 
            // nitro_infos
            // 
            this.nitro_infos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nitro_infos.AutoSize = true;
            this.nitro_infos.Location = new System.Drawing.Point(260, 471);
            this.nitro_infos.Name = "nitro_infos";
            this.nitro_infos.Size = new System.Drawing.Size(89, 21);
            this.nitro_infos.TabIndex = 12;
            this.nitro_infos.Text = "Nitro infos";
            this.nitro_infos.UseVisualStyleBackColor = true;
            // 
            // threads_label
            // 
            this.threads_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.threads_label.AutoSize = true;
            this.threads_label.Location = new System.Drawing.Point(588, 444);
            this.threads_label.Name = "threads_label";
            this.threads_label.Size = new System.Drawing.Size(58, 17);
            this.threads_label.TabIndex = 13;
            this.threads_label.Text = "Threads:";
            // 
            // threads_amount
            // 
            this.threads_amount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.threads_amount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.threads_amount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.threads_amount.ForeColor = System.Drawing.SystemColors.Window;
            this.threads_amount.Location = new System.Drawing.Point(652, 443);
            this.threads_amount.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.threads_amount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.threads_amount.Name = "threads_amount";
            this.threads_amount.Size = new System.Drawing.Size(65, 21);
            this.threads_amount.TabIndex = 14;
            this.threads_amount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // uses_proxies
            // 
            this.uses_proxies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uses_proxies.AutoSize = true;
            this.uses_proxies.Location = new System.Drawing.Point(463, 442);
            this.uses_proxies.Name = "uses_proxies";
            this.uses_proxies.Size = new System.Drawing.Size(102, 21);
            this.uses_proxies.TabIndex = 15;
            this.uses_proxies.Text = "Uses proxies";
            this.uses_proxies.UseVisualStyleBackColor = true;
            this.uses_proxies.CheckedChanged += new System.EventHandler(this.UsesProxies_CheckedChanged);
            // 
            // checkBtn
            // 
            this.checkBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(94)))), ((int)(((byte)(202)))));
            this.checkBtn.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(94)))), ((int)(((byte)(202)))));
            this.checkBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.checkBtn.BorderRadius = 8;
            this.checkBtn.BorderSize = 0;
            this.checkBtn.FlatAppearance.BorderSize = 0;
            this.checkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBtn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBtn.ForeColor = System.Drawing.Color.White;
            this.checkBtn.Location = new System.Drawing.Point(723, 442);
            this.checkBtn.Name = "checkBtn";
            this.checkBtn.Size = new System.Drawing.Size(133, 50);
            this.checkBtn.TabIndex = 2;
            this.checkBtn.Text = "Check tokens";
            this.checkBtn.TextColor = System.Drawing.Color.White;
            this.checkBtn.UseVisualStyleBackColor = false;
            this.checkBtn.Click += new System.EventHandler(this.CheckBtn_Click);
            // 
            // chkStatistics
            // 
            this.chkStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkStatistics.AutoSize = true;
            this.chkStatistics.Checked = true;
            this.chkStatistics.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStatistics.Location = new System.Drawing.Point(463, 469);
            this.chkStatistics.Name = "chkStatistics";
            this.chkStatistics.Size = new System.Drawing.Size(219, 21);
            this.chkStatistics.TabIndex = 16;
            this.chkStatistics.Text = "Send anonymous usage statistics";
            this.chkStatistics.UseVisualStyleBackColor = true;
            // 
            // linkLabelGuns
            // 
            this.linkLabelGuns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelGuns.AutoSize = true;
            this.linkLabelGuns.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabelGuns.Location = new System.Drawing.Point(728, 63);
            this.linkLabelGuns.Name = "linkLabelGuns";
            this.linkLabelGuns.Size = new System.Drawing.Size(128, 17);
            this.linkLabelGuns.TabIndex = 17;
            this.linkLabelGuns.Text = "| guns.lol/digitalcord";
            this.linkLabelGuns.Click += new System.EventHandler(this.LinkLabelGuns_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(868, 495);
            this.Controls.Add(this.linkLabelGuns);
            this.Controls.Add(this.chkStatistics);
            this.Controls.Add(this.uses_proxies);
            this.Controls.Add(this.threads_amount);
            this.Controls.Add(this.threads_label);
            this.Controls.Add(this.nitro_infos);
            this.Controls.Add(this.link_label);
            this.Controls.Add(this.payment_methods);
            this.Controls.Add(this.avatar_preview);
            this.Controls.Add(this.friends_count);
            this.Controls.Add(this.dm_history_count);
            this.Controls.Add(this.guild_count);
            this.Controls.Add(this.tokens_label);
            this.Controls.Add(this.checkBtn);
            this.Controls.Add(this.tokens_textbox);
            this.Controls.Add(this.title_label);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(855, 252);
            this.Name = "Form1";
            this.Text = "Discord Token Checker";
            ((System.ComponentModel.ISupportInitialize)(this.threads_amount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.TextBox tokens_textbox;
        private CustomButton checkBtn;
        private System.Windows.Forms.Label tokens_label;
        private System.Windows.Forms.CheckBox guild_count;
        private System.Windows.Forms.CheckBox dm_history_count;
        private System.Windows.Forms.CheckBox friends_count;
        private System.Windows.Forms.CheckBox avatar_preview;
        private System.Windows.Forms.CheckBox payment_methods;
        private System.Windows.Forms.Label link_label;
        private System.Windows.Forms.CheckBox nitro_infos;
        private System.Windows.Forms.Label threads_label;
        private System.Windows.Forms.NumericUpDown threads_amount;
        private System.Windows.Forms.CheckBox uses_proxies;
        private System.Windows.Forms.CheckBox chkStatistics;
        private System.Windows.Forms.Label linkLabelGuns;
    }
}

