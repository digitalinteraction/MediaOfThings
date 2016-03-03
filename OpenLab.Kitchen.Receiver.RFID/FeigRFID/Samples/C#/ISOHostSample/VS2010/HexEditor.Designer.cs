namespace ISOHostSample
{
    partial class HexEditor
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.Hexer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Hexer
            // 
            this.Hexer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Hexer.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hexer.Location = new System.Drawing.Point(0, 0);
            this.Hexer.Multiline = true;
            this.Hexer.Name = "Hexer";
            this.Hexer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Hexer.Size = new System.Drawing.Size(289, 244);
            this.Hexer.TabIndex = 0;
            this.Hexer.WordWrap = false;
            this.Hexer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Hexer_KeyPress_1);
            this.Hexer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Hexer_MouseUp);
            // 
            // HexEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Hexer);
            this.Name = "HexEditor";
            this.Size = new System.Drawing.Size(289, 244);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox Hexer;

    }
}
