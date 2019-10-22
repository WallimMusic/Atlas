namespace Obje.Companents
{
    partial class AtlasLookUp
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
            this.flaLookUp = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.flaLookUp.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // flaLookUp
            // 
            this.flaLookUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flaLookUp.EnterMoveNextControl = true;
            this.flaLookUp.Location = new System.Drawing.Point(0, 0);
            this.flaLookUp.Name = "flaLookUp";
            this.flaLookUp.Properties.Appearance.BackColor = System.Drawing.Color.Bisque;
            this.flaLookUp.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.flaLookUp.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.flaLookUp.Properties.Appearance.Options.UseBackColor = true;
            this.flaLookUp.Properties.Appearance.Options.UseFont = true;
            this.flaLookUp.Properties.Appearance.Options.UseForeColor = true;
            this.flaLookUp.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.Bisque;
            this.flaLookUp.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.flaLookUp.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.flaLookUp.Properties.AppearanceDropDown.Options.UseFont = true;
            this.flaLookUp.Properties.AppearanceFocused.BackColor = System.Drawing.Color.PaleGreen;
            this.flaLookUp.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.flaLookUp.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.flaLookUp.Properties.AppearanceFocused.Options.UseFont = true;
            this.flaLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.flaLookUp.Properties.NullText = "";
            this.flaLookUp.Properties.ShowFooter = false;
            this.flaLookUp.Size = new System.Drawing.Size(170, 20);
            this.flaLookUp.TabIndex = 0;
            this.flaLookUp.EditValueChanged += new System.EventHandler(this.flaLookUp_EditValueChanged);
            // 
            // AtlasLookUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flaLookUp);
            this.Name = "AtlasLookUp";
            this.Size = new System.Drawing.Size(170, 20);
            ((System.ComponentModel.ISupportInitialize)(this.flaLookUp.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.LookUpEdit flaLookUp;
    }
}
