namespace ISOHostSample
{
    partial class ISOHostSample
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ISOHostSample));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelBank = new System.Windows.Forms.Label();
            this.comboBoxBank = new System.Windows.Forms.ComboBox();
            this.comboBoxMod = new System.Windows.Forms.ComboBox();
            this.numericUpDownDBS = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDBN = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAdr = new System.Windows.Forms.NumericUpDown();
            this.buttonClearB = new System.Windows.Forms.Button();
            this.buttonWrite = new System.Windows.Forms.Button();
            this.buttonRead = new System.Windows.Forms.Button();
            this.labelMod = new System.Windows.Forms.Label();
            this.labelDBSize = new System.Windows.Forms.Label();
            this.labelDBN = new System.Windows.Forms.Label();
            this.labelAdr = new System.Windows.Forms.Label();
            this.HexEdit = new HexEditor();
            this.groupBoxProt = new System.Windows.Forms.GroupBox();
            this.checkBoxEnable = new System.Windows.Forms.CheckBox();
            this.buttonProtClear = new System.Windows.Forms.Button();
            this.textBoxProtocol = new System.Windows.Forms.TextBox();
            this.groupBoxTagList = new System.Windows.Forms.GroupBox();
            this.button_Authent_myd = new System.Windows.Forms.Button();
            this.button_AuthentMifare = new System.Windows.Forms.Button();
            this.buttonClearList = new System.Windows.Forms.Button();
            this.buttonRun = new System.Windows.Forms.Button();
            this.listBoxTags = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDBN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAdr)).BeginInit();
            this.groupBoxProt.SuspendLayout();
            this.groupBoxTagList.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelBank);
            this.groupBox1.Controls.Add(this.comboBoxBank);
            this.groupBox1.Controls.Add(this.comboBoxMod);
            this.groupBox1.Controls.Add(this.numericUpDownDBS);
            this.groupBox1.Controls.Add(this.numericUpDownDBN);
            this.groupBox1.Controls.Add(this.numericUpDownAdr);
            this.groupBox1.Controls.Add(this.buttonClearB);
            this.groupBox1.Controls.Add(this.buttonWrite);
            this.groupBox1.Controls.Add(this.buttonRead);
            this.groupBox1.Controls.Add(this.labelMod);
            this.groupBox1.Controls.Add(this.labelDBSize);
            this.groupBox1.Controls.Add(this.labelDBN);
            this.groupBox1.Controls.Add(this.labelAdr);
            this.groupBox1.Controls.Add(this.HexEdit);
            this.groupBox1.Location = new System.Drawing.Point(6, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(721, 335);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Read/Write Multiple Blocks";
            // 
            // labelBank
            // 
            this.labelBank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBank.AutoSize = true;
            this.labelBank.Location = new System.Drawing.Point(537, 306);
            this.labelBank.Name = "labelBank";
            this.labelBank.Size = new System.Drawing.Size(32, 13);
            this.labelBank.TabIndex = 13;
            this.labelBank.Text = "Bank";
            // 
            // comboBoxBank
            // 
            this.comboBoxBank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxBank.FormattingEnabled = true;
            this.comboBoxBank.Items.AddRange(new object[] {
            "reserved",
            "EPC memory bank",
            "TID memory bank",
            "User memory bank"});
            this.comboBoxBank.Location = new System.Drawing.Point(585, 301);
            this.comboBoxBank.Name = "comboBoxBank";
            this.comboBoxBank.Size = new System.Drawing.Size(122, 21);
            this.comboBoxBank.TabIndex = 12;
            this.comboBoxBank.SelectedIndexChanged += new System.EventHandler(this.comboBoxBank_SelectedIndexChanged);
            // 
            // comboBoxMod
            // 
            this.comboBoxMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMod.FormattingEnabled = true;
            this.comboBoxMod.Items.AddRange(new object[] {
            "non addressed",
            "addressed",
            "selected"});
            this.comboBoxMod.Location = new System.Drawing.Point(613, 274);
            this.comboBoxMod.Name = "comboBoxMod";
            this.comboBoxMod.Size = new System.Drawing.Size(94, 21);
            this.comboBoxMod.TabIndex = 11;
            // 
            // numericUpDownDBS
            // 
            this.numericUpDownDBS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownDBS.Location = new System.Drawing.Point(668, 249);
            this.numericUpDownDBS.Name = "numericUpDownDBS";
            this.numericUpDownDBS.Size = new System.Drawing.Size(39, 20);
            this.numericUpDownDBS.TabIndex = 10;
            this.numericUpDownDBS.ValueChanged += new System.EventHandler(this.numericUpDownDBS_ValueChanged);
            // 
            // numericUpDownDBN
            // 
            this.numericUpDownDBN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownDBN.Location = new System.Drawing.Point(668, 223);
            this.numericUpDownDBN.Name = "numericUpDownDBN";
            this.numericUpDownDBN.Size = new System.Drawing.Size(39, 20);
            this.numericUpDownDBN.TabIndex = 9;
            // 
            // numericUpDownAdr
            // 
            this.numericUpDownAdr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownAdr.Location = new System.Drawing.Point(668, 198);
            this.numericUpDownAdr.Name = "numericUpDownAdr";
            this.numericUpDownAdr.Size = new System.Drawing.Size(39, 20);
            this.numericUpDownAdr.TabIndex = 8;
            // 
            // buttonClearB
            // 
            this.buttonClearB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearB.Location = new System.Drawing.Point(632, 79);
            this.buttonClearB.Name = "buttonClearB";
            this.buttonClearB.Size = new System.Drawing.Size(75, 23);
            this.buttonClearB.TabIndex = 7;
            this.buttonClearB.Text = "&Clear";
            this.buttonClearB.UseVisualStyleBackColor = true;
            this.buttonClearB.Click += new System.EventHandler(this.buttonClearB_Click);
            // 
            // buttonWrite
            // 
            this.buttonWrite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWrite.Location = new System.Drawing.Point(632, 50);
            this.buttonWrite.Name = "buttonWrite";
            this.buttonWrite.Size = new System.Drawing.Size(75, 23);
            this.buttonWrite.TabIndex = 6;
            this.buttonWrite.Text = "&Write";
            this.buttonWrite.UseVisualStyleBackColor = true;
            this.buttonWrite.Click += new System.EventHandler(this.buttonWrite_Click);
            // 
            // buttonRead
            // 
            this.buttonRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRead.Location = new System.Drawing.Point(632, 21);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(75, 23);
            this.buttonRead.TabIndex = 5;
            this.buttonRead.Text = "&Read";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // labelMod
            // 
            this.labelMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMod.AutoSize = true;
            this.labelMod.Location = new System.Drawing.Point(537, 279);
            this.labelMod.Name = "labelMod";
            this.labelMod.Size = new System.Drawing.Size(34, 13);
            this.labelMod.TabIndex = 4;
            this.labelMod.Text = "Mode";
            // 
            // labelDBSize
            // 
            this.labelDBSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDBSize.AutoSize = true;
            this.labelDBSize.Location = new System.Drawing.Point(537, 253);
            this.labelDBSize.Name = "labelDBSize";
            this.labelDBSize.Size = new System.Drawing.Size(45, 13);
            this.labelDBSize.TabIndex = 3;
            this.labelDBSize.Text = "DB-Size";
            this.labelDBSize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelDBN
            // 
            this.labelDBN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDBN.AutoSize = true;
            this.labelDBN.Location = new System.Drawing.Point(537, 227);
            this.labelDBN.Name = "labelDBN";
            this.labelDBN.Size = new System.Drawing.Size(30, 13);
            this.labelDBN.TabIndex = 2;
            this.labelDBN.Text = "DBN";
            // 
            // labelAdr
            // 
            this.labelAdr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAdr.AutoSize = true;
            this.labelAdr.Location = new System.Drawing.Point(537, 202);
            this.labelAdr.Name = "labelAdr";
            this.labelAdr.Size = new System.Drawing.Size(30, 13);
            this.labelAdr.TabIndex = 1;
            this.labelAdr.Text = "ADR";
            // 
            // HexEdit
            // 
            this.HexEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HexEdit.AutoScroll = true;
            this.HexEdit.ColumnCount = 4;
            this.HexEdit.Location = new System.Drawing.Point(6, 14);
            this.HexEdit.Margin = new System.Windows.Forms.Padding(4);
            this.HexEdit.Name = "HexEdit";
            this.HexEdit.Size = new System.Drawing.Size(529, 308);
            this.HexEdit.TabIndex = 0;
            this.HexEdit.Load += new System.EventHandler(this.HexEdit_Load);
            // 
            // groupBoxProt
            // 
            this.groupBoxProt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxProt.Controls.Add(this.checkBoxEnable);
            this.groupBoxProt.Controls.Add(this.buttonProtClear);
            this.groupBoxProt.Controls.Add(this.textBoxProtocol);
            this.groupBoxProt.Location = new System.Drawing.Point(6, 353);
            this.groupBoxProt.Name = "groupBoxProt";
            this.groupBoxProt.Size = new System.Drawing.Size(1051, 179);
            this.groupBoxProt.TabIndex = 1;
            this.groupBoxProt.TabStop = false;
            this.groupBoxProt.Text = "ProtocolWindow";
            // 
            // checkBoxEnable
            // 
            this.checkBoxEnable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxEnable.AutoSize = true;
            this.checkBoxEnable.Location = new System.Drawing.Point(972, 60);
            this.checkBoxEnable.Name = "checkBoxEnable";
            this.checkBoxEnable.Size = new System.Drawing.Size(59, 17);
            this.checkBoxEnable.TabIndex = 2;
            this.checkBoxEnable.Text = "Enable";
            this.checkBoxEnable.UseVisualStyleBackColor = true;
            this.checkBoxEnable.CheckedChanged += new System.EventHandler(this.checkBoxEnable_CheckedChanged);
            // 
            // buttonProtClear
            // 
            this.buttonProtClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonProtClear.Location = new System.Drawing.Point(956, 19);
            this.buttonProtClear.Name = "buttonProtClear";
            this.buttonProtClear.Size = new System.Drawing.Size(75, 23);
            this.buttonProtClear.TabIndex = 1;
            this.buttonProtClear.Text = "Cl&ear";
            this.buttonProtClear.UseVisualStyleBackColor = true;
            this.buttonProtClear.Click += new System.EventHandler(this.buttonProtClear_Click);
            // 
            // textBoxProtocol
            // 
            this.textBoxProtocol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProtocol.Location = new System.Drawing.Point(6, 19);
            this.textBoxProtocol.Multiline = true;
            this.textBoxProtocol.Name = "textBoxProtocol";
            this.textBoxProtocol.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxProtocol.Size = new System.Drawing.Size(935, 153);
            this.textBoxProtocol.TabIndex = 0;
            this.textBoxProtocol.WordWrap = false;
            this.textBoxProtocol.TextChanged += new System.EventHandler(this.textBoxProtocol_TextChanged);
            // 
            // groupBoxTagList
            // 
            this.groupBoxTagList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTagList.Controls.Add(this.button_Authent_myd);
            this.groupBoxTagList.Controls.Add(this.button_AuthentMifare);
            this.groupBoxTagList.Controls.Add(this.buttonClearList);
            this.groupBoxTagList.Controls.Add(this.buttonRun);
            this.groupBoxTagList.Controls.Add(this.listBoxTags);
            this.groupBoxTagList.Location = new System.Drawing.Point(733, 12);
            this.groupBoxTagList.Name = "groupBoxTagList";
            this.groupBoxTagList.Size = new System.Drawing.Size(324, 335);
            this.groupBoxTagList.TabIndex = 3;
            this.groupBoxTagList.TabStop = false;
            this.groupBoxTagList.Text = "TagList";
            // 
            // button_Authent_myd
            // 
            this.button_Authent_myd.Location = new System.Drawing.Point(226, 301);
            this.button_Authent_myd.Name = "button_Authent_myd";
            this.button_Authent_myd.Size = new System.Drawing.Size(84, 23);
            this.button_Authent_myd.TabIndex = 4;
            this.button_Authent_myd.Text = "Authent my-d";
            this.button_Authent_myd.UseVisualStyleBackColor = true;
            this.button_Authent_myd.Click += new System.EventHandler(this.button_Authent_myd_Click);
            // 
            // button_AuthentMifare
            // 
            this.button_AuthentMifare.Location = new System.Drawing.Point(226, 274);
            this.button_AuthentMifare.Name = "button_AuthentMifare";
            this.button_AuthentMifare.Size = new System.Drawing.Size(84, 23);
            this.button_AuthentMifare.TabIndex = 3;
            this.button_AuthentMifare.Text = "Authent Mifare";
            this.button_AuthentMifare.UseVisualStyleBackColor = true;
            this.button_AuthentMifare.Click += new System.EventHandler(this.button_AuthentMifare_Click);
            // 
            // buttonClearList
            // 
            this.buttonClearList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearList.Location = new System.Drawing.Point(229, 50);
            this.buttonClearList.Name = "buttonClearList";
            this.buttonClearList.Size = new System.Drawing.Size(75, 23);
            this.buttonClearList.TabIndex = 2;
            this.buttonClearList.Text = "Cl&ear";
            this.buttonClearList.UseVisualStyleBackColor = true;
            this.buttonClearList.Click += new System.EventHandler(this.buttonClearList_Click);
            // 
            // buttonRun
            // 
            this.buttonRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRun.Location = new System.Drawing.Point(229, 21);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 1;
            this.buttonRun.Text = "R&un";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // listBoxTags
            // 
            this.listBoxTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxTags.FormattingEnabled = true;
            this.listBoxTags.HorizontalScrollbar = true;
            this.listBoxTags.Location = new System.Drawing.Point(6, 21);
            this.listBoxTags.Name = "listBoxTags";
            this.listBoxTags.Size = new System.Drawing.Size(208, 290);
            this.listBoxTags.TabIndex = 0;
            this.listBoxTags.SelectedIndexChanged += new System.EventHandler(this.listBoxTags_SelectedIndexChanged);
            // 
            // ISOHostSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 537);
            this.Controls.Add(this.groupBoxTagList);
            this.Controls.Add(this.groupBoxProt);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ISOHostSample";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ISOHostModeSample  -  FEIG ELECTRONIC  -  advanced reader technology";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ISOSample_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDBN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAdr)).EndInit();
            this.groupBoxProt.ResumeLayout(false);
            this.groupBoxProt.PerformLayout();
            this.groupBoxTagList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxProt;
        private System.Windows.Forms.GroupBox groupBoxTagList;
        private System.Windows.Forms.Button buttonClearList;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.ListBox listBoxTags;
        private System.Windows.Forms.CheckBox checkBoxEnable;
        private System.Windows.Forms.Button buttonProtClear;
        private System.Windows.Forms.TextBox textBoxProtocol;
        private System.Windows.Forms.Button buttonClearB;
        private System.Windows.Forms.Button buttonWrite;
        private System.Windows.Forms.Label labelMod;
        private System.Windows.Forms.Label labelDBSize;
        private System.Windows.Forms.Label labelDBN;
        private System.Windows.Forms.Label labelAdr;
        private System.Windows.Forms.NumericUpDown numericUpDownDBS;
        private System.Windows.Forms.NumericUpDown numericUpDownDBN;
        private System.Windows.Forms.NumericUpDown numericUpDownAdr;
        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.ComboBox comboBoxMod;
        private HexEditor HexEdit;
        private System.Windows.Forms.Label labelBank;
        private System.Windows.Forms.ComboBox comboBoxBank;
        private System.Windows.Forms.Button button_Authent_myd;
        private System.Windows.Forms.Button button_AuthentMifare;  
    }
}

