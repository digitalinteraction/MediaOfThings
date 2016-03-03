namespace ISOHostSample
{
    partial class AuthentMYD
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
            this.labelKeyAdr_Tag = new System.Windows.Forms.Label();
            this.labelKeyAdr_SAM = new System.Windows.Forms.Label();
            this.labelAuthCounterAdr = new System.Windows.Forms.Label();
            this.labelAuthSequence = new System.Windows.Forms.Label();
            this.numericUpDown_KeyAdrTAG = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_KeyAdrSAM = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_AuthCntAdr = new System.Windows.Forms.NumericUpDown();
            this.comboBox_AuthSequence = new System.Windows.Forms.ComboBox();
            this.button_AuthMYD = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_KeyAdrTAG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_KeyAdrSAM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AuthCntAdr)).BeginInit();
            this.SuspendLayout();
            // 
            // labelKeyAdr_Tag
            // 
            this.labelKeyAdr_Tag.AutoSize = true;
            this.labelKeyAdr_Tag.Location = new System.Drawing.Point(29, 24);
            this.labelKeyAdr_Tag.Name = "labelKeyAdr_Tag";
            this.labelKeyAdr_Tag.Size = new System.Drawing.Size(99, 13);
            this.labelKeyAdr_Tag.TabIndex = 0;
            this.labelKeyAdr_Tag.Text = "Key-Adr. TAG (dec)";
            // 
            // labelKeyAdr_SAM
            // 
            this.labelKeyAdr_SAM.AutoSize = true;
            this.labelKeyAdr_SAM.Location = new System.Drawing.Point(28, 57);
            this.labelKeyAdr_SAM.Name = "labelKeyAdr_SAM";
            this.labelKeyAdr_SAM.Size = new System.Drawing.Size(100, 13);
            this.labelKeyAdr_SAM.TabIndex = 1;
            this.labelKeyAdr_SAM.Text = "Key-Adr. SAM (dec)";
            // 
            // labelAuthCounterAdr
            // 
            this.labelAuthCounterAdr.AutoSize = true;
            this.labelAuthCounterAdr.Location = new System.Drawing.Point(28, 91);
            this.labelAuthCounterAdr.Name = "labelAuthCounterAdr";
            this.labelAuthCounterAdr.Size = new System.Drawing.Size(121, 13);
            this.labelAuthCounterAdr.TabIndex = 2;
            this.labelAuthCounterAdr.Text = "Auth. Counter Adr. (dec)";
            // 
            // labelAuthSequence
            // 
            this.labelAuthSequence.AutoSize = true;
            this.labelAuthSequence.Location = new System.Drawing.Point(29, 124);
            this.labelAuthSequence.Name = "labelAuthSequence";
            this.labelAuthSequence.Size = new System.Drawing.Size(96, 13);
            this.labelAuthSequence.TabIndex = 3;
            this.labelAuthSequence.Text = "Authent Sequence";
            // 
            // numericUpDown_KeyAdrTAG
            // 
            this.numericUpDown_KeyAdrTAG.Location = new System.Drawing.Point(187, 22);
            this.numericUpDown_KeyAdrTAG.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.numericUpDown_KeyAdrTAG.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown_KeyAdrTAG.Name = "numericUpDown_KeyAdrTAG";
            this.numericUpDown_KeyAdrTAG.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown_KeyAdrTAG.TabIndex = 4;
            this.numericUpDown_KeyAdrTAG.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // numericUpDown_KeyAdrSAM
            // 
            this.numericUpDown_KeyAdrSAM.Location = new System.Drawing.Point(187, 55);
            this.numericUpDown_KeyAdrSAM.Maximum = new decimal(new int[] {
            28,
            0,
            0,
            0});
            this.numericUpDown_KeyAdrSAM.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_KeyAdrSAM.Name = "numericUpDown_KeyAdrSAM";
            this.numericUpDown_KeyAdrSAM.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown_KeyAdrSAM.TabIndex = 5;
            this.numericUpDown_KeyAdrSAM.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_AuthCntAdr
            // 
            this.numericUpDown_AuthCntAdr.Location = new System.Drawing.Point(187, 89);
            this.numericUpDown_AuthCntAdr.Name = "numericUpDown_AuthCntAdr";
            this.numericUpDown_AuthCntAdr.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown_AuthCntAdr.TabIndex = 6;
            // 
            // comboBox_AuthSequence
            // 
            this.comboBox_AuthSequence.FormattingEnabled = true;
            this.comboBox_AuthSequence.Items.AddRange(new object[] {
            "Accelerated card authentification",
            "Entire card authentification"});
            this.comboBox_AuthSequence.Location = new System.Drawing.Point(187, 124);
            this.comboBox_AuthSequence.Name = "comboBox_AuthSequence";
            this.comboBox_AuthSequence.Size = new System.Drawing.Size(206, 21);
            this.comboBox_AuthSequence.TabIndex = 7;
            // 
            // button_AuthMYD
            // 
            this.button_AuthMYD.Location = new System.Drawing.Point(318, 19);
            this.button_AuthMYD.Name = "button_AuthMYD";
            this.button_AuthMYD.Size = new System.Drawing.Size(75, 23);
            this.button_AuthMYD.TabIndex = 8;
            this.button_AuthMYD.Text = "Authent";
            this.button_AuthMYD.UseVisualStyleBackColor = true;
            this.button_AuthMYD.Click += new System.EventHandler(this.button_AuthMYD_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(318, 52);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 9;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // AuthentMYD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 161);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_AuthMYD);
            this.Controls.Add(this.comboBox_AuthSequence);
            this.Controls.Add(this.numericUpDown_AuthCntAdr);
            this.Controls.Add(this.numericUpDown_KeyAdrSAM);
            this.Controls.Add(this.numericUpDown_KeyAdrTAG);
            this.Controls.Add(this.labelAuthSequence);
            this.Controls.Add(this.labelAuthCounterAdr);
            this.Controls.Add(this.labelKeyAdr_SAM);
            this.Controls.Add(this.labelKeyAdr_Tag);
            this.Name = "AuthentMYD";
            this.Text = "Authent my-d";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_KeyAdrTAG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_KeyAdrSAM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AuthCntAdr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelKeyAdr_Tag;
        private System.Windows.Forms.Label labelKeyAdr_SAM;
        private System.Windows.Forms.Label labelAuthCounterAdr;
        private System.Windows.Forms.Label labelAuthSequence;
        private System.Windows.Forms.NumericUpDown numericUpDown_KeyAdrTAG;
        private System.Windows.Forms.NumericUpDown numericUpDown_KeyAdrSAM;
        private System.Windows.Forms.NumericUpDown numericUpDown_AuthCntAdr;
        private System.Windows.Forms.ComboBox comboBox_AuthSequence;
        private System.Windows.Forms.Button button_AuthMYD;
        private System.Windows.Forms.Button button_Cancel;
    }
}