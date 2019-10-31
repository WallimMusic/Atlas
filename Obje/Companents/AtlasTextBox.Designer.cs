namespace Obje.Companents
{
    partial class AtlasTextBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flaText = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.flaText.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // flaText
            // 
            this.flaText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flaText.EnterMoveNextControl = true;
            this.flaText.Location = new System.Drawing.Point(0, 0);
            this.flaText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flaText.Name = "flaText";
            this.flaText.Properties.Appearance.BackColor = System.Drawing.Color.LightBlue;
            this.flaText.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.flaText.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.flaText.Properties.Appearance.Options.UseBackColor = true;
            this.flaText.Properties.Appearance.Options.UseFont = true;
            this.flaText.Properties.Appearance.Options.UseForeColor = true;
            this.flaText.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Orange;
            this.flaText.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.flaText.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.flaText.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.flaText.Properties.AppearanceFocused.Options.UseFont = true;
            this.flaText.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.flaText.Size = new System.Drawing.Size(228, 24);
            this.flaText.TabIndex = 2;
            this.flaText.EditValueChanged += new System.EventHandler(this.flaText_EditValueChanged);
            this.flaText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.flaText_KeyUp);
            // 
            // AtlasTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flaText);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AtlasTextBox";
            this.Size = new System.Drawing.Size(228, 25);
            ((System.ComponentModel.ISupportInitialize)(this.flaText.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.TextEdit flaText;
    }
}
