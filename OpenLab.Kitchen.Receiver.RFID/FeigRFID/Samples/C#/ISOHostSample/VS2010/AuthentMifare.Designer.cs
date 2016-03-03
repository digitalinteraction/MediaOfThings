namespace ISOHostSample
{
    partial class AuthentMifare
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
            this.comboBoxKeyLoc = new System.Windows.Forms.ComboBox();
            this.label_KeyLoc = new System.Windows.Forms.Label();
            this.label_KeyType = new System.Windows.Forms.Label();
            this.comboBoxKeyType = new System.Windows.Forms.ComboBox();
            this.labelDBAdr = new System.Windows.Forms.Label();
            this.labelKeyAdr = new System.Windows.Forms.Label();
            this.numericUpDown_DBAdr = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_KeyAdr = new System.Windows.Forms.NumericUpDown();
            this.labelKey = new System.Windows.Forms.Label();
            this.textBox_Key1 = new System.Windows.Forms.TextBox();
            this.textBox_Key2 = new System.Windows.Forms.TextBox();
            this.textBox_Key3 = new System.Windows.Forms.TextBox();
            this.textBox_Key4 = new System.Windows.Forms.TextBox();
            this.button_Authent = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.textBox_Key5 = new System.Windows.Forms.TextBox();
            this.textBox_Key6 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DBAdr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_KeyAdr)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxKeyLoc
            // 
            this.comboBoxKeyLoc.FormattingEnabled = true;
            this.comboBoxKeyLoc.Items.AddRange(new object[] {
            "Key from Protocol",
            "Key from Reader"});
            this.comboBoxKeyLoc.Location = new System.Drawing.Point(121, 25);
            this.comboBoxKeyLoc.Name = "comboBoxKeyLoc";
            this.comboBoxKeyLoc.Size = new System.Drawing.Size(118, 21);
            this.comboBoxKeyLoc.TabIndex = 0;
            this.comboBoxKeyLoc.SelectedIndexChanged += new System.EventHandler(this.comboBoxKeyLoc_SelectedIndexChanged);
            // 
            // label_KeyLoc
            // 
            this.label_KeyLoc.AutoSize = true;
            this.label_KeyLoc.Location = new System.Drawing.Point(25, 28);
            this.label_KeyLoc.Name = "label_KeyLoc";
            this.label_KeyLoc.Size = new System.Drawing.Size(69, 13);
            this.label_KeyLoc.TabIndex = 1;
            this.label_KeyLoc.Text = "Key Location";
            // 
            // label_KeyType
            // 
            this.label_KeyType.AutoSize = true;
            this.label_KeyType.Location = new System.Drawing.Point(25, 62);
            this.label_KeyType.Name = "label_KeyType";
            this.label_KeyType.Size = new System.Drawing.Size(52, 13);
            this.label_KeyType.TabIndex = 2;
            this.label_KeyType.Text = "Key-Type";
            // 
            // comboBoxKeyType
            // 
            this.comboBoxKeyType.FormattingEnabled = true;
            this.comboBoxKeyType.Items.AddRange(new object[] {
            "Key A",
            "Key B"});
            this.comboBoxKeyType.Location = new System.Drawing.Point(121, 59);
            this.comboBoxKeyType.Name = "comboBoxKeyType";
            this.comboBoxKeyType.Size = new System.Drawing.Size(118, 21);
            this.comboBoxKeyType.TabIndex = 3;
            // 
            // labelDBAdr
            // 
            this.labelDBAdr.AutoSize = true;
            this.labelDBAdr.Location = new System.Drawing.Point(25, 100);
            this.labelDBAdr.Name = "labelDBAdr";
            this.labelDBAdr.Size = new System.Drawing.Size(71, 13);
            this.labelDBAdr.TabIndex = 4;
            this.labelDBAdr.Text = "DB-Adr. (dec)";
            // 
            // labelKeyAdr
            // 
            this.labelKeyAdr.AutoSize = true;
            this.labelKeyAdr.Location = new System.Drawing.Point(25, 133);
            this.labelKeyAdr.Name = "labelKeyAdr";
            this.labelKeyAdr.Size = new System.Drawing.Size(74, 13);
            this.labelKeyAdr.TabIndex = 5;
            this.labelKeyAdr.Text = "Key-Adr. (dec)";
            // 
            // numericUpDown_DBAdr
            // 
            this.numericUpDown_DBAdr.Location = new System.Drawing.Point(121, 98);
            this.numericUpDown_DBAdr.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_DBAdr.Name = "numericUpDown_DBAdr";
            this.numericUpDown_DBAdr.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown_DBAdr.TabIndex = 6;
            this.numericUpDown_DBAdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown_KeyAdr
            // 
            this.numericUpDown_KeyAdr.Location = new System.Drawing.Point(121, 131);
            this.numericUpDown_KeyAdr.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown_KeyAdr.Name = "numericUpDown_KeyAdr";
            this.numericUpDown_KeyAdr.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown_KeyAdr.TabIndex = 7;
            this.numericUpDown_KeyAdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Location = new System.Drawing.Point(25, 172);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(73, 13);
            this.labelKey.TabIndex = 8;
            this.labelKey.Text = "Key ( 00 .. FF)";
            // 
            // textBox_Key1
            // 
            this.textBox_Key1.Location = new System.Drawing.Point(121, 169);
            this.textBox_Key1.MaxLength = 2;
            this.textBox_Key1.Name = "textBox_Key1";
            this.textBox_Key1.Size = new System.Drawing.Size(25, 20);
            this.textBox_Key1.TabIndex = 9;
            this.textBox_Key1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Key1.Leave += new System.EventHandler(this.textBox_Key1_Leave);
            // 
            // textBox_Key2
            // 
            this.textBox_Key2.Location = new System.Drawing.Point(148, 169);
            this.textBox_Key2.MaxLength = 2;
            this.textBox_Key2.Name = "textBox_Key2";
            this.textBox_Key2.Size = new System.Drawing.Size(25, 20);
            this.textBox_Key2.TabIndex = 10;
            this.textBox_Key2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Key2.Leave += new System.EventHandler(this.textBox_Key2_Leave);
            // 
            // textBox_Key3
            // 
            this.textBox_Key3.Location = new System.Drawing.Point(175, 169);
            this.textBox_Key3.MaxLength = 2;
            this.textBox_Key3.Name = "textBox_Key3";
            this.textBox_Key3.Size = new System.Drawing.Size(25, 20);
            this.textBox_Key3.TabIndex = 11;
            this.textBox_Key3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Key3.Leave += new System.EventHandler(this.textBox_Key3_Leave);
            // 
            // textBox_Key4
            // 
            this.textBox_Key4.Location = new System.Drawing.Point(202, 169);
            this.textBox_Key4.MaxLength = 2;
            this.textBox_Key4.Name = "textBox_Key4";
            this.textBox_Key4.Size = new System.Drawing.Size(25, 20);
            this.textBox_Key4.TabIndex = 12;
            this.textBox_Key4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Key4.Leave += new System.EventHandler(this.textBox_Key4_Leave);
            // 
            // button_Authent
            // 
            this.button_Authent.Location = new System.Drawing.Point(269, 23);
            this.button_Authent.Name = "button_Authent";
            this.button_Authent.Size = new System.Drawing.Size(75, 23);
            this.button_Authent.TabIndex = 13;
            this.button_Authent.Text = "Authent";
            this.button_Authent.UseVisualStyleBackColor = true;
            this.button_Authent.Click += new System.EventHandler(this.button_Authent_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(269, 57);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 14;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // textBox_Key5
            // 
            this.textBox_Key5.Location = new System.Drawing.Point(229, 169);
            this.textBox_Key5.MaxLength = 2;
            this.textBox_Key5.Name = "textBox_Key5";
            this.textBox_Key5.Size = new System.Drawing.Size(25, 20);
            this.textBox_Key5.TabIndex = 15;
            this.textBox_Key5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Key5.Leave += new System.EventHandler(this.textBox_Key5_Leave);
            // 
            // textBox_Key6
            // 
            this.textBox_Key6.Location = new System.Drawing.Point(256, 169);
            this.textBox_Key6.MaxLength = 2;
            this.textBox_Key6.Name = "textBox_Key6";
            this.textBox_Key6.Size = new System.Drawing.Size(25, 20);
            this.textBox_Key6.TabIndex = 16;
            this.textBox_Key6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Key6.Leave += new System.EventHandler(this.textBox_Key6_Leave);
            // 
            // AuthentMifare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 208);
            this.Controls.Add(this.textBox_Key6);
            this.Controls.Add(this.textBox_Key5);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Authent);
            this.Controls.Add(this.textBox_Key4);
            this.Controls.Add(this.textBox_Key3);
            this.Controls.Add(this.textBox_Key2);
            this.Controls.Add(this.textBox_Key1);
            this.Controls.Add(this.labelKey);
            this.Controls.Add(this.numericUpDown_KeyAdr);
            this.Controls.Add(this.numericUpDown_DBAdr);
            this.Controls.Add(this.labelKeyAdr);
            this.Controls.Add(this.labelDBAdr);
            this.Controls.Add(this.comboBoxKeyType);
            this.Controls.Add(this.label_KeyType);
            this.Controls.Add(this.label_KeyLoc);
            this.Controls.Add(this.comboBoxKeyLoc);
            this.Name = "AuthentMifare";
            this.Text = "AuthentMifare";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DBAdr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_KeyAdr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxKeyLoc;
        private System.Windows.Forms.Label label_KeyLoc;
        private System.Windows.Forms.Label label_KeyType;
        private System.Windows.Forms.ComboBox comboBoxKeyType;
        private System.Windows.Forms.Label labelDBAdr;
        private System.Windows.Forms.Label labelKeyAdr;
        private System.Windows.Forms.NumericUpDown numericUpDown_DBAdr;
        private System.Windows.Forms.NumericUpDown numericUpDown_KeyAdr;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.TextBox textBox_Key1;
        private System.Windows.Forms.TextBox textBox_Key2;
        private System.Windows.Forms.TextBox textBox_Key3;
        private System.Windows.Forms.TextBox textBox_Key4;
        private System.Windows.Forms.Button button_Authent;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.TextBox textBox_Key5;
        private System.Windows.Forms.TextBox textBox_Key6;
    }
}