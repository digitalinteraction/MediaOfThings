namespace APDUSample
{
    partial class APDU_Sample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APDU_Sample));
            this.button_inventory = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_rfreset = new System.Windows.Forms.Button();
            this.label_status = new System.Windows.Forms.Label();
            this.textBox_status_out = new System.Windows.Forms.TextBox();
            this.groupBox_APDUEditor = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_APDU = new System.Windows.Forms.MaskedTextBox();
            this.button_sendAPDU = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox_TagList = new System.Windows.Forms.ListBox();
            this.groupBox_Reader = new System.Windows.Forms.GroupBox();
            this.button_exit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox_APDUEditor.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox_Reader.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_inventory
            // 
            this.button_inventory.Location = new System.Drawing.Point(6, 19);
            this.button_inventory.Name = "button_inventory";
            this.button_inventory.Size = new System.Drawing.Size(130, 23);
            this.button_inventory.TabIndex = 0;
            this.button_inventory.Text = "[0xB0][0x01]  &Inventory";
            this.button_inventory.UseVisualStyleBackColor = true;
            this.button_inventory.Click += new System.EventHandler(this.OnButtonClick_Inventory);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_rfreset);
            this.groupBox1.Controls.Add(this.button_inventory);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(142, 150);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Commands";
            // 
            // button_rfreset
            // 
            this.button_rfreset.Location = new System.Drawing.Point(8, 121);
            this.button_rfreset.Name = "button_rfreset";
            this.button_rfreset.Size = new System.Drawing.Size(129, 23);
            this.button_rfreset.TabIndex = 2;
            this.button_rfreset.Text = "[0x69]  &RF-Reset";
            this.button_rfreset.UseVisualStyleBackColor = true;
            this.button_rfreset.Click += new System.EventHandler(this.button_rfreset_Click);
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(17, 189);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(40, 13);
            this.label_status.TabIndex = 3;
            this.label_status.Text = "Status:";
            // 
            // textBox_status_out
            // 
            this.textBox_status_out.Location = new System.Drawing.Point(63, 186);
            this.textBox_status_out.Name = "textBox_status_out";
            this.textBox_status_out.ReadOnly = true;
            this.textBox_status_out.Size = new System.Drawing.Size(549, 20);
            this.textBox_status_out.TabIndex = 4;
            // 
            // groupBox_APDUEditor
            // 
            this.groupBox_APDUEditor.Controls.Add(this.maskedTextBox_APDU);
            this.groupBox_APDUEditor.Controls.Add(this.button_sendAPDU);
            this.groupBox_APDUEditor.Location = new System.Drawing.Point(160, 111);
            this.groupBox_APDUEditor.Name = "groupBox_APDUEditor";
            this.groupBox_APDUEditor.Size = new System.Drawing.Size(452, 51);
            this.groupBox_APDUEditor.TabIndex = 5;
            this.groupBox_APDUEditor.TabStop = false;
            this.groupBox_APDUEditor.Text = "APDU-Editor";
            // 
            // maskedTextBox_APDU
            // 
            this.maskedTextBox_APDU.Location = new System.Drawing.Point(8, 20);
            this.maskedTextBox_APDU.Name = "maskedTextBox_APDU";
            this.maskedTextBox_APDU.Size = new System.Drawing.Size(350, 20);
            this.maskedTextBox_APDU.TabIndex = 2;
            this.maskedTextBox_APDU.Tag = "60";
            this.maskedTextBox_APDU.TextChanged += new System.EventHandler(this.maskedTextBox_APDU_TextChanged);
            // 
            // button_sendAPDU
            // 
            this.button_sendAPDU.Location = new System.Drawing.Point(369, 18);
            this.button_sendAPDU.Name = "button_sendAPDU";
            this.button_sendAPDU.Size = new System.Drawing.Size(75, 23);
            this.button_sendAPDU.TabIndex = 1;
            this.button_sendAPDU.Text = "Send &APDU";
            this.button_sendAPDU.UseVisualStyleBackColor = true;
            this.button_sendAPDU.Click += new System.EventHandler(this.OnButtonClick_SendAPDU);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox_TagList);
            this.groupBox2.Location = new System.Drawing.Point(161, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(235, 93);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tag List";
            // 
            // listBox_TagList
            // 
            this.listBox_TagList.FormattingEnabled = true;
            this.listBox_TagList.Location = new System.Drawing.Point(7, 19);
            this.listBox_TagList.Name = "listBox_TagList";
            this.listBox_TagList.Size = new System.Drawing.Size(216, 69);
            this.listBox_TagList.TabIndex = 0;
            this.listBox_TagList.SelectedIndexChanged += new System.EventHandler(this.listBox_TagList_SelectedIndexChanged);
            // 
            // groupBox_Reader
            // 
            this.groupBox_Reader.Controls.Add(this.button_exit);
            this.groupBox_Reader.Location = new System.Drawing.Point(488, 12);
            this.groupBox_Reader.Name = "groupBox_Reader";
            this.groupBox_Reader.Size = new System.Drawing.Size(124, 93);
            this.groupBox_Reader.TabIndex = 8;
            this.groupBox_Reader.TabStop = false;
            this.groupBox_Reader.Text = "Reader";
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(7, 19);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(111, 23);
            this.button_exit.TabIndex = 1;
            this.button_exit.Text = "E&XIT";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.OnButtonClick_Exit);
            // 
            // APDU_Sample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 219);
            this.Controls.Add(this.groupBox_Reader);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox_APDUEditor);
            this.Controls.Add(this.textBox_status_out);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "APDU_Sample";
            this.Text = "APDUSample";
            this.groupBox1.ResumeLayout(false);
            this.groupBox_APDUEditor.ResumeLayout(false);
            this.groupBox_APDUEditor.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox_Reader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_inventory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_rfreset;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.TextBox textBox_status_out;
        private System.Windows.Forms.GroupBox groupBox_APDUEditor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox_Reader;
        private System.Windows.Forms.Button button_sendAPDU;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.ListBox listBox_TagList;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_APDU;
    }
}

