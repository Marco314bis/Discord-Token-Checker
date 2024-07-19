namespace TokensChecker
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.tokensListView = new System.Windows.Forms.ListView();
            this.show_username = new System.Windows.Forms.CheckBox();
            this.show_global_name = new System.Windows.Forms.CheckBox();
            this.show_id = new System.Windows.Forms.CheckBox();
            this.show_nitro_type = new System.Windows.Forms.CheckBox();
            this.show_creation_date = new System.Windows.Forms.CheckBox();
            this.show_type = new System.Windows.Forms.CheckBox();
            this.show_email = new System.Windows.Forms.CheckBox();
            this.show_phone_number = new System.Windows.Forms.CheckBox();
            this.show_flags = new System.Windows.Forms.CheckBox();
            this.show_locale = new System.Windows.Forms.CheckBox();
            this.show_bio = new System.Windows.Forms.CheckBox();
            this.show_guild_count = new System.Windows.Forms.CheckBox();
            this.show_friend_count = new System.Windows.Forms.CheckBox();
            this.show_dms_count = new System.Windows.Forms.CheckBox();
            this.show_payment_method = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToken = new System.Windows.Forms.ToolStripMenuItem();
            this.copyLoginScript = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAsJson = new System.Windows.Forms.ToolStripMenuItem();
            this.show_token = new System.Windows.Forms.CheckBox();
            this.show_validity = new System.Windows.Forms.CheckBox();
            this.show_lock_status = new System.Windows.Forms.CheckBox();
            this.show_check_status = new System.Windows.Forms.CheckBox();
            this.show_nitro_start = new System.Windows.Forms.CheckBox();
            this.show_nitro_end = new System.Windows.Forms.CheckBox();
            this.show_nitro_remaining = new System.Windows.Forms.CheckBox();
            this.show_available_boosts = new System.Windows.Forms.CheckBox();
            this.show_boosts_cooldowns = new System.Windows.Forms.CheckBox();
            this.btnExport = new TokensChecker.CustomButton();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tokensListView
            // 
            this.tokensListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tokensListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tokensListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tokensListView.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.tokensListView.FullRowSelect = true;
            this.tokensListView.HideSelection = false;
            this.tokensListView.Location = new System.Drawing.Point(1, 0);
            this.tokensListView.Name = "tokensListView";
            this.tokensListView.Size = new System.Drawing.Size(1270, 530);
            this.tokensListView.TabIndex = 0;
            this.tokensListView.UseCompatibleStateImageBehavior = false;
            this.tokensListView.View = System.Windows.Forms.View.Details;
            this.tokensListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.TokensListView_ColumnClick);
            this.tokensListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TokensListView_MouseClick);
            // 
            // show_username
            // 
            this.show_username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.show_username.AutoSize = true;
            this.show_username.Checked = true;
            this.show_username.CheckState = System.Windows.Forms.CheckState.Checked;
            this.show_username.Location = new System.Drawing.Point(117, 593);
            this.show_username.Name = "show_username";
            this.show_username.Size = new System.Drawing.Size(86, 21);
            this.show_username.TabIndex = 1;
            this.show_username.Text = "Username";
            this.show_username.UseVisualStyleBackColor = true;
            // 
            // show_global_name
            // 
            this.show_global_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.show_global_name.AutoSize = true;
            this.show_global_name.Location = new System.Drawing.Point(234, 539);
            this.show_global_name.Name = "show_global_name";
            this.show_global_name.Size = new System.Drawing.Size(104, 21);
            this.show_global_name.TabIndex = 2;
            this.show_global_name.Text = "Global Name";
            this.show_global_name.UseVisualStyleBackColor = true;
            // 
            // show_id
            // 
            this.show_id.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.show_id.AutoSize = true;
            this.show_id.Location = new System.Drawing.Point(117, 566);
            this.show_id.Name = "show_id";
            this.show_id.Size = new System.Drawing.Size(39, 21);
            this.show_id.TabIndex = 3;
            this.show_id.Text = "ID";
            this.show_id.UseVisualStyleBackColor = true;
            // 
            // show_nitro_type
            // 
            this.show_nitro_type.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.show_nitro_type.AutoSize = true;
            this.show_nitro_type.Checked = true;
            this.show_nitro_type.CheckState = System.Windows.Forms.CheckState.Checked;
            this.show_nitro_type.Location = new System.Drawing.Point(966, 539);
            this.show_nitro_type.Name = "show_nitro_type";
            this.show_nitro_type.Size = new System.Drawing.Size(88, 21);
            this.show_nitro_type.TabIndex = 4;
            this.show_nitro_type.Text = "Nitro Type";
            this.show_nitro_type.UseVisualStyleBackColor = true;
            // 
            // show_creation_date
            // 
            this.show_creation_date.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.show_creation_date.AutoSize = true;
            this.show_creation_date.Checked = true;
            this.show_creation_date.CheckState = System.Windows.Forms.CheckState.Checked;
            this.show_creation_date.Location = new System.Drawing.Point(234, 566);
            this.show_creation_date.Name = "show_creation_date";
            this.show_creation_date.Size = new System.Drawing.Size(107, 21);
            this.show_creation_date.TabIndex = 5;
            this.show_creation_date.Text = "Creation Date";
            this.show_creation_date.UseVisualStyleBackColor = true;
            // 
            // show_type
            // 
            this.show_type.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.show_type.AutoSize = true;
            this.show_type.Checked = true;
            this.show_type.CheckState = System.Windows.Forms.CheckState.Checked;
            this.show_type.Location = new System.Drawing.Point(361, 539);
            this.show_type.Name = "show_type";
            this.show_type.Size = new System.Drawing.Size(92, 21);
            this.show_type.TabIndex = 6;
            this.show_type.Text = "Token Type";
            this.show_type.UseVisualStyleBackColor = true;
            // 
            // show_email
            // 
            this.show_email.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.show_email.AutoSize = true;
            this.show_email.Location = new System.Drawing.Point(361, 566);
            this.show_email.Name = "show_email";
            this.show_email.Size = new System.Drawing.Size(110, 21);
            this.show_email.TabIndex = 7;
            this.show_email.Text = "Email Address";
            this.show_email.UseVisualStyleBackColor = true;
            // 
            // show_phone_number
            // 
            this.show_phone_number.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.show_phone_number.AutoSize = true;
            this.show_phone_number.Checked = true;
            this.show_phone_number.CheckState = System.Windows.Forms.CheckState.Checked;
            this.show_phone_number.Location = new System.Drawing.Point(361, 593);
            this.show_phone_number.Name = "show_phone_number";
            this.show_phone_number.Size = new System.Drawing.Size(115, 21);
            this.show_phone_number.TabIndex = 8;
            this.show_phone_number.Text = "Phone Number";
            this.show_phone_number.UseVisualStyleBackColor = true;
            // 
            // show_flags
            // 
            this.show_flags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.show_flags.AutoSize = true;
            this.show_flags.Checked = true;
            this.show_flags.CheckState = System.Windows.Forms.CheckState.Checked;
            this.show_flags.Location = new System.Drawing.Point(234, 593);
            this.show_flags.Name = "show_flags";
            this.show_flags.Size = new System.Drawing.Size(112, 21);
            this.show_flags.TabIndex = 9;
            this.show_flags.Text = "Flags (Badges)";
            this.show_flags.UseVisualStyleBackColor = true;
            // 
            // show_locale
            // 
            this.show_locale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.show_locale.AutoSize = true;
            this.show_locale.Checked = true;
            this.show_locale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.show_locale.Location = new System.Drawing.Point(495, 539);
            this.show_locale.Name = "show_locale";
            this.show_locale.Size = new System.Drawing.Size(64, 21);
            this.show_locale.TabIndex = 11;
            this.show_locale.Text = "Locale";
            this.show_locale.UseVisualStyleBackColor = true;
            // 
            // show_bio
            // 
            this.show_bio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.show_bio.AutoSize = true;
            this.show_bio.Location = new System.Drawing.Point(495, 566);
            this.show_bio.Name = "show_bio";
            this.show_bio.Size = new System.Drawing.Size(45, 21);
            this.show_bio.TabIndex = 12;
            this.show_bio.Text = "Bio";
            this.show_bio.UseVisualStyleBackColor = true;
            // 
            // show_guild_count
            // 
            this.show_guild_count.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.show_guild_count.AutoSize = true;
            this.show_guild_count.Checked = true;
            this.show_guild_count.CheckState = System.Windows.Forms.CheckState.Checked;
            this.show_guild_count.Location = new System.Drawing.Point(632, 539);
            this.show_guild_count.Name = "show_guild_count";
            this.show_guild_count.Size = new System.Drawing.Size(95, 21);
            this.show_guild_count.TabIndex = 13;
            this.show_guild_count.Text = "Guild Count";
            this.show_guild_count.UseVisualStyleBackColor = true;
            this.show_guild_count.Visible = false;
            // 
            // show_friend_count
            // 
            this.show_friend_count.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.show_friend_count.AutoSize = true;
            this.show_friend_count.Checked = true;
            this.show_friend_count.CheckState = System.Windows.Forms.CheckState.Checked;
            this.show_friend_count.Location = new System.Drawing.Point(495, 593);
            this.show_friend_count.Name = "show_friend_count";
            this.show_friend_count.Size = new System.Drawing.Size(101, 21);
            this.show_friend_count.TabIndex = 14;
            this.show_friend_count.Text = "Friend Count";
            this.show_friend_count.UseVisualStyleBackColor = true;
            this.show_friend_count.Visible = false;
            // 
            // show_dms_count
            // 
            this.show_dms_count.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.show_dms_count.AutoSize = true;
            this.show_dms_count.Checked = true;
            this.show_dms_count.CheckState = System.Windows.Forms.CheckState.Checked;
            this.show_dms_count.Location = new System.Drawing.Point(632, 566);
            this.show_dms_count.Name = "show_dms_count";
            this.show_dms_count.Size = new System.Drawing.Size(92, 21);
            this.show_dms_count.TabIndex = 15;
            this.show_dms_count.Text = "DMs Count";
            this.show_dms_count.UseVisualStyleBackColor = true;
            this.show_dms_count.Visible = false;
            // 
            // show_payment_method
            // 
            this.show_payment_method.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.show_payment_method.AutoSize = true;
            this.show_payment_method.Checked = true;
            this.show_payment_method.CheckState = System.Windows.Forms.CheckState.Checked;
            this.show_payment_method.Location = new System.Drawing.Point(632, 593);
            this.show_payment_method.Name = "show_payment_method";
            this.show_payment_method.Size = new System.Drawing.Size(132, 21);
            this.show_payment_method.TabIndex = 16;
            this.show_payment_method.Text = "Payment Methods";
            this.show_payment_method.UseVisualStyleBackColor = true;
            this.show_payment_method.Visible = false;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToken,
            this.copyLoginScript,
            this.copyAsJson});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(165, 70);
            this.contextMenuStrip.Text = "Options";
            // 
            // copyToken
            // 
            this.copyToken.Name = "copyToken";
            this.copyToken.Size = new System.Drawing.Size(164, 22);
            this.copyToken.Text = "Copy token";
            this.copyToken.Click += new System.EventHandler(this.CopyToken_Click);
            // 
            // copyLoginScript
            // 
            this.copyLoginScript.Name = "copyLoginScript";
            this.copyLoginScript.Size = new System.Drawing.Size(164, 22);
            this.copyLoginScript.Text = "Copy login script";
            this.copyLoginScript.Click += new System.EventHandler(this.CopyLoginScript_Click);
            // 
            // copyAsJson
            // 
            this.copyAsJson.Name = "copyAsJson";
            this.copyAsJson.Size = new System.Drawing.Size(164, 22);
            this.copyAsJson.Text = "Copy as json";
            this.copyAsJson.Click += new System.EventHandler(this.CopyAsJson_Click);
            // 
            // show_token
            // 
            this.show_token.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.show_token.AutoSize = true;
            this.show_token.Checked = true;
            this.show_token.CheckState = System.Windows.Forms.CheckState.Checked;
            this.show_token.Location = new System.Drawing.Point(12, 539);
            this.show_token.Name = "show_token";
            this.show_token.Size = new System.Drawing.Size(61, 21);
            this.show_token.TabIndex = 18;
            this.show_token.Text = "Token";
            this.show_token.UseVisualStyleBackColor = true;
            // 
            // show_validity
            // 
            this.show_validity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.show_validity.AutoSize = true;
            this.show_validity.Checked = true;
            this.show_validity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.show_validity.Location = new System.Drawing.Point(12, 566);
            this.show_validity.Name = "show_validity";
            this.show_validity.Size = new System.Drawing.Size(68, 21);
            this.show_validity.TabIndex = 19;
            this.show_validity.Text = "Validity";
            this.show_validity.UseVisualStyleBackColor = true;
            // 
            // show_lock_status
            // 
            this.show_lock_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.show_lock_status.AutoSize = true;
            this.show_lock_status.Checked = true;
            this.show_lock_status.CheckState = System.Windows.Forms.CheckState.Checked;
            this.show_lock_status.Location = new System.Drawing.Point(12, 593);
            this.show_lock_status.Name = "show_lock_status";
            this.show_lock_status.Size = new System.Drawing.Size(92, 21);
            this.show_lock_status.TabIndex = 20;
            this.show_lock_status.Text = "Lock Status";
            this.show_lock_status.UseVisualStyleBackColor = true;
            // 
            // show_check_status
            // 
            this.show_check_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.show_check_status.AutoSize = true;
            this.show_check_status.Location = new System.Drawing.Point(117, 539);
            this.show_check_status.Name = "show_check_status";
            this.show_check_status.Size = new System.Drawing.Size(100, 21);
            this.show_check_status.TabIndex = 21;
            this.show_check_status.Text = "Check Status";
            this.show_check_status.UseVisualStyleBackColor = true;
            // 
            // show_nitro_start
            // 
            this.show_nitro_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.show_nitro_start.AutoSize = true;
            this.show_nitro_start.Checked = true;
            this.show_nitro_start.CheckState = System.Windows.Forms.CheckState.Checked;
            this.show_nitro_start.Location = new System.Drawing.Point(794, 539);
            this.show_nitro_start.Name = "show_nitro_start";
            this.show_nitro_start.Size = new System.Drawing.Size(119, 21);
            this.show_nitro_start.TabIndex = 22;
            this.show_nitro_start.Text = "Nitro Start Date";
            this.show_nitro_start.UseVisualStyleBackColor = true;
            this.show_nitro_start.Visible = false;
            // 
            // show_nitro_end
            // 
            this.show_nitro_end.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.show_nitro_end.AutoSize = true;
            this.show_nitro_end.Checked = true;
            this.show_nitro_end.CheckState = System.Windows.Forms.CheckState.Checked;
            this.show_nitro_end.Location = new System.Drawing.Point(794, 566);
            this.show_nitro_end.Name = "show_nitro_end";
            this.show_nitro_end.Size = new System.Drawing.Size(114, 21);
            this.show_nitro_end.TabIndex = 23;
            this.show_nitro_end.Text = "Nitro End Date";
            this.show_nitro_end.UseVisualStyleBackColor = true;
            this.show_nitro_end.Visible = false;
            // 
            // show_nitro_remaining
            // 
            this.show_nitro_remaining.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.show_nitro_remaining.AutoSize = true;
            this.show_nitro_remaining.Checked = true;
            this.show_nitro_remaining.CheckState = System.Windows.Forms.CheckState.Checked;
            this.show_nitro_remaining.Location = new System.Drawing.Point(794, 593);
            this.show_nitro_remaining.Name = "show_nitro_remaining";
            this.show_nitro_remaining.Size = new System.Drawing.Size(154, 21);
            this.show_nitro_remaining.TabIndex = 24;
            this.show_nitro_remaining.Text = "Nitro Remaining Days";
            this.show_nitro_remaining.UseVisualStyleBackColor = true;
            this.show_nitro_remaining.Visible = false;
            // 
            // show_available_boosts
            // 
            this.show_available_boosts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.show_available_boosts.AutoSize = true;
            this.show_available_boosts.Checked = true;
            this.show_available_boosts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.show_available_boosts.Location = new System.Drawing.Point(966, 566);
            this.show_available_boosts.Name = "show_available_boosts";
            this.show_available_boosts.Size = new System.Drawing.Size(122, 21);
            this.show_available_boosts.TabIndex = 25;
            this.show_available_boosts.Text = "Available Boosts";
            this.show_available_boosts.UseVisualStyleBackColor = true;
            this.show_available_boosts.Visible = false;
            // 
            // show_boosts_cooldowns
            // 
            this.show_boosts_cooldowns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.show_boosts_cooldowns.AutoSize = true;
            this.show_boosts_cooldowns.Checked = true;
            this.show_boosts_cooldowns.CheckState = System.Windows.Forms.CheckState.Checked;
            this.show_boosts_cooldowns.Location = new System.Drawing.Point(966, 593);
            this.show_boosts_cooldowns.Name = "show_boosts_cooldowns";
            this.show_boosts_cooldowns.Size = new System.Drawing.Size(135, 21);
            this.show_boosts_cooldowns.TabIndex = 26;
            this.show_boosts_cooldowns.Text = "Boosts Cooldowns";
            this.show_boosts_cooldowns.UseVisualStyleBackColor = true;
            this.show_boosts_cooldowns.Visible = false;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnExport.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.btnExport.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnExport.BorderRadius = 18;
            this.btnExport.BorderSize = 0;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(1131, 539);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(129, 69);
            this.btnExport.TabIndex = 17;
            this.btnExport.Text = "Export datas";
            this.btnExport.TextColor = System.Drawing.Color.White;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1272, 620);
            this.Controls.Add(this.show_boosts_cooldowns);
            this.Controls.Add(this.show_available_boosts);
            this.Controls.Add(this.show_nitro_remaining);
            this.Controls.Add(this.show_nitro_end);
            this.Controls.Add(this.show_nitro_start);
            this.Controls.Add(this.show_check_status);
            this.Controls.Add(this.show_lock_status);
            this.Controls.Add(this.show_validity);
            this.Controls.Add(this.show_token);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.show_payment_method);
            this.Controls.Add(this.show_dms_count);
            this.Controls.Add(this.show_friend_count);
            this.Controls.Add(this.show_guild_count);
            this.Controls.Add(this.show_bio);
            this.Controls.Add(this.show_locale);
            this.Controls.Add(this.show_flags);
            this.Controls.Add(this.show_phone_number);
            this.Controls.Add(this.show_email);
            this.Controls.Add(this.show_type);
            this.Controls.Add(this.show_creation_date);
            this.Controls.Add(this.show_nitro_type);
            this.Controls.Add(this.show_id);
            this.Controls.Add(this.show_global_name);
            this.Controls.Add(this.show_username);
            this.Controls.Add(this.tokensListView);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1110, 265);
            this.Name = "Form2";
            this.Text = "Discord Token Checker | Results";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView tokensListView;
        private System.Windows.Forms.CheckBox show_username;
        private System.Windows.Forms.CheckBox show_global_name;
        private System.Windows.Forms.CheckBox show_id;
        private System.Windows.Forms.CheckBox show_nitro_type;
        private System.Windows.Forms.CheckBox show_creation_date;
        private System.Windows.Forms.CheckBox show_type;
        private System.Windows.Forms.CheckBox show_email;
        private System.Windows.Forms.CheckBox show_phone_number;
        private System.Windows.Forms.CheckBox show_flags;
        private System.Windows.Forms.CheckBox show_locale;
        private System.Windows.Forms.CheckBox show_bio;
        private System.Windows.Forms.CheckBox show_guild_count;
        private System.Windows.Forms.CheckBox show_friend_count;
        private System.Windows.Forms.CheckBox show_dms_count;
        private System.Windows.Forms.CheckBox show_payment_method;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyAsJson;
        private System.Windows.Forms.ToolStripMenuItem copyLoginScript;
        private CustomButton btnExport;
        private System.Windows.Forms.ToolStripMenuItem copyToken;
        private System.Windows.Forms.CheckBox show_token;
        private System.Windows.Forms.CheckBox show_validity;
        private System.Windows.Forms.CheckBox show_lock_status;
        private System.Windows.Forms.CheckBox show_check_status;
        private System.Windows.Forms.CheckBox show_nitro_start;
        private System.Windows.Forms.CheckBox show_nitro_end;
        private System.Windows.Forms.CheckBox show_nitro_remaining;
        private System.Windows.Forms.CheckBox show_available_boosts;
        private System.Windows.Forms.CheckBox show_boosts_cooldowns;
    }
}