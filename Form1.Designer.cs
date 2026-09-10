namespace ProfileFillingTool
{
    partial class ProfileFillingTool
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnFillProfiles = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbComPorts = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbEncryptMode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDevicePassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbEncryptKey = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbAuthKey = new System.Windows.Forms.TextBox();
            this.cbUse1107 = new System.Windows.Forms.CheckBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.capturePeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.periodUnit = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.profileEntries = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.cbAssociation = new System.Windows.Forms.ComboBox();
            this.labelProgress = new System.Windows.Forms.Label();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.cbFillTillNow = new System.Windows.Forms.CheckBox();
            this.cb_ResetProfiles = new System.Windows.Forms.CheckBox();
            this.tbServerIp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbUseNetwork = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFillProfiles
            // 
            this.btnFillProfiles.Location = new System.Drawing.Point(268, 291);
            this.btnFillProfiles.Margin = new System.Windows.Forms.Padding(2);
            this.btnFillProfiles.Name = "btnFillProfiles";
            this.btnFillProfiles.Size = new System.Drawing.Size(116, 41);
            this.btnFillProfiles.TabIndex = 0;
            this.btnFillProfiles.Text = "Fill Profiles";
            this.btnFillProfiles.UseVisualStyleBackColor = true;
            this.btnFillProfiles.Click += new System.EventHandler(this.btnFillProfiles_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ComPort";
            // 
            // cbComPorts
            // 
            this.cbComPorts.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ProfileFillingTool.Properties.Settings.Default, "initialComPortValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbComPorts.FormattingEnabled = true;
            this.cbComPorts.Location = new System.Drawing.Point(116, 15);
            this.cbComPorts.Margin = new System.Windows.Forms.Padding(2);
            this.cbComPorts.Name = "cbComPorts";
            this.cbComPorts.Size = new System.Drawing.Size(131, 21);
            this.cbComPorts.TabIndex = 2;
            this.cbComPorts.Text = global::ProfileFillingTool.Properties.Settings.Default.initialComPortValue;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "BaudRate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 94);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Encryption Mode";
            // 
            // cbEncryptMode
            // 
            this.cbEncryptMode.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ProfileFillingTool.Properties.Settings.Default, "initialEncryptionModeValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbEncryptMode.FormattingEnabled = true;
            this.cbEncryptMode.Items.AddRange(new object[] {
            "Password",
            "GMAC"});
            this.cbEncryptMode.Location = new System.Drawing.Point(116, 91);
            this.cbEncryptMode.Margin = new System.Windows.Forms.Padding(2);
            this.cbEncryptMode.Name = "cbEncryptMode";
            this.cbEncryptMode.Size = new System.Drawing.Size(131, 21);
            this.cbEncryptMode.TabIndex = 8;
            this.cbEncryptMode.Text = global::ProfileFillingTool.Properties.Settings.Default.initialEncryptionModeValue;
            this.cbEncryptMode.SelectedIndexChanged += new System.EventHandler(this.cbEncryptMode_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 132);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Device Password";
            // 
            // tbDevicePassword
            // 
            this.tbDevicePassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ProfileFillingTool.Properties.Settings.Default, "initialPasswordValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbDevicePassword.Location = new System.Drawing.Point(116, 129);
            this.tbDevicePassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbDevicePassword.Name = "tbDevicePassword";
            this.tbDevicePassword.Size = new System.Drawing.Size(131, 20);
            this.tbDevicePassword.TabIndex = 10;
            this.tbDevicePassword.Text = global::ProfileFillingTool.Properties.Settings.Default.initialPasswordValue;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 169);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Encryption Key";
            // 
            // tbEncryptKey
            // 
            this.tbEncryptKey.Location = new System.Drawing.Point(116, 166);
            this.tbEncryptKey.Margin = new System.Windows.Forms.Padding(2);
            this.tbEncryptKey.Name = "tbEncryptKey";
            this.tbEncryptKey.Size = new System.Drawing.Size(131, 20);
            this.tbEncryptKey.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 206);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Authenticat. Key";
            // 
            // tbAuthKey
            // 
            this.tbAuthKey.Location = new System.Drawing.Point(116, 203);
            this.tbAuthKey.Margin = new System.Windows.Forms.Padding(2);
            this.tbAuthKey.Name = "tbAuthKey";
            this.tbAuthKey.Size = new System.Drawing.Size(131, 20);
            this.tbAuthKey.TabIndex = 14;
            // 
            // cbUse1107
            // 
            this.cbUse1107.AutoSize = true;
            this.cbUse1107.Location = new System.Drawing.Point(16, 325);
            this.cbUse1107.Name = "cbUse1107";
            this.cbUse1107.Size = new System.Drawing.Size(72, 17);
            this.cbUse1107.TabIndex = 15;
            this.cbUse1107.Text = "Use 1107";
            this.cbUse1107.UseVisualStyleBackColor = true;
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.capturePeriod,
            this.periodUnit,
            this.profileEntries});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Location = new System.Drawing.Point(268, 15);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 62;
            this.dgv.Size = new System.Drawing.Size(328, 248);
            this.dgv.TabIndex = 16;
            // 
            // capturePeriod
            // 
            this.capturePeriod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.capturePeriod.HeaderText = "Capture Period";
            this.capturePeriod.MinimumWidth = 8;
            this.capturePeriod.Name = "capturePeriod";
            this.capturePeriod.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // periodUnit
            // 
            this.periodUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.periodUnit.HeaderText = "Period Unit";
            this.periodUnit.Items.AddRange(new object[] {
            "Second",
            "Minute",
            "Hour",
            "Day",
            "Month",
            "Year"});
            this.periodUnit.MinimumWidth = 8;
            this.periodUnit.Name = "periodUnit";
            // 
            // profileEntries
            // 
            this.profileEntries.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.profileEntries.HeaderText = "Profile Entries";
            this.profileEntries.MinimumWidth = 8;
            this.profileEntries.Name = "profileEntries";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 243);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Use Association";
            // 
            // cbAssociation
            // 
            this.cbAssociation.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ProfileFillingTool.Properties.Settings.Default, "initialUseAssociationValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbAssociation.FormattingEnabled = true;
            this.cbAssociation.Location = new System.Drawing.Point(116, 240);
            this.cbAssociation.Name = "cbAssociation";
            this.cbAssociation.Size = new System.Drawing.Size(131, 21);
            this.cbAssociation.TabIndex = 18;
            this.cbAssociation.Text = global::ProfileFillingTool.Properties.Settings.Default.initialUseAssociationValue;
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.labelProgress.Location = new System.Drawing.Point(389, 313);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(80, 13);
            this.labelProgress.TabIndex = 23;
            this.labelProgress.Text = "Progress: None";
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.AllowDrop = true;
            this.cbBaudRate.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ProfileFillingTool.Properties.Settings.Default, "initialBaudRateValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Items.AddRange(new object[] {
            "300",
            "9600",
            "38400",
            "57600",
            "115200"});
            this.cbBaudRate.Location = new System.Drawing.Point(116, 53);
            this.cbBaudRate.Margin = new System.Windows.Forms.Padding(2);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(131, 21);
            this.cbBaudRate.TabIndex = 4;
            this.cbBaudRate.Text = global::ProfileFillingTool.Properties.Settings.Default.initialBaudRateValue;
            // 
            // cbFillTillNow
            // 
            this.cbFillTillNow.AutoSize = true;
            this.cbFillTillNow.Location = new System.Drawing.Point(16, 371);
            this.cbFillTillNow.Name = "cbFillTillNow";
            this.cbFillTillNow.Size = new System.Drawing.Size(79, 17);
            this.cbFillTillNow.TabIndex = 24;
            this.cbFillTillNow.Text = "Fill Till Now";
            this.cbFillTillNow.UseVisualStyleBackColor = true;
            this.cbFillTillNow.CheckedChanged += new System.EventHandler(this.cbFillTillNow_CheckedChanged);
            // 
            // cb_ResetProfiles
            // 
            this.cb_ResetProfiles.AutoSize = true;
            this.cb_ResetProfiles.Location = new System.Drawing.Point(16, 394);
            this.cb_ResetProfiles.Name = "cb_ResetProfiles";
            this.cb_ResetProfiles.Size = new System.Drawing.Size(140, 17);
            this.cb_ResetProfiles.TabIndex = 25;
            this.cb_ResetProfiles.Text = "Reset Profiles Before Fill";
            this.cb_ResetProfiles.UseVisualStyleBackColor = true;
            // 
            // tbServerIp
            // 
            this.tbServerIp.Location = new System.Drawing.Point(116, 280);
            this.tbServerIp.Name = "tbServerIp";
            this.tbServerIp.Size = new System.Drawing.Size(131, 20);
            this.tbServerIp.TabIndex = 26;
            this.tbServerIp.TextChanged += new System.EventHandler(this.tbServerIp_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Server IP";
            // 
            // cbUseNetwork
            // 
            this.cbUseNetwork.AutoSize = true;
            this.cbUseNetwork.Location = new System.Drawing.Point(16, 348);
            this.cbUseNetwork.Name = "cbUseNetwork";
            this.cbUseNetwork.Size = new System.Drawing.Size(88, 17);
            this.cbUseNetwork.TabIndex = 28;
            this.cbUseNetwork.Text = "Use Network";
            this.cbUseNetwork.UseVisualStyleBackColor = true;
            this.cbUseNetwork.CheckedChanged += new System.EventHandler(this.cbUseNetwork_CheckedChanged);
            // 
            // ProfileFillingTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 423);
            this.Controls.Add(this.cbUseNetwork);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbServerIp);
            this.Controls.Add(this.cb_ResetProfiles);
            this.Controls.Add(this.cbFillTillNow);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.cbAssociation);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.cbUse1107);
            this.Controls.Add(this.tbAuthKey);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbEncryptKey);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbDevicePassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbEncryptMode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbBaudRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbComPorts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFillProfiles);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProfileFillingTool";
            this.Text = "Profile Filling Tool v1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProfileFillingTool_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFillProfiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbComPorts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbEncryptMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDevicePassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbEncryptKey;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbAuthKey;
        private System.Windows.Forms.CheckBox cbUse1107;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbAssociation;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn capturePeriod;
        private System.Windows.Forms.DataGridViewComboBoxColumn periodUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn profileEntries;
        private System.Windows.Forms.CheckBox cbFillTillNow;
        private System.Windows.Forms.CheckBox cb_ResetProfiles;
        private System.Windows.Forms.TextBox tbServerIp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbUseNetwork;
    }
}

