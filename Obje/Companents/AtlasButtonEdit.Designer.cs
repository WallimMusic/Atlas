namespace Obje.Companents
{
    partial class AtlasButtonEdit
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            this.flaButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.flaButtonEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // flaButtonEdit
            // 
            this.flaButtonEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flaButtonEdit.EnterMoveNextControl = true;
            this.flaButtonEdit.Location = new System.Drawing.Point(0, 0);
            this.flaButtonEdit.Name = "flaButtonEdit";
            this.flaButtonEdit.Properties.Appearance.BackColor = System.Drawing.Color.Bisque;
            this.flaButtonEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.flaButtonEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.flaButtonEdit.Properties.Appearance.Options.UseBackColor = true;
            this.flaButtonEdit.Properties.Appearance.Options.UseFont = true;
            this.flaButtonEdit.Properties.Appearance.Options.UseForeColor = true;
            this.flaButtonEdit.Properties.AppearanceFocused.BackColor = System.Drawing.Color.PaleGreen;
            this.flaButtonEdit.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.flaButtonEdit.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.flaButtonEdit.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.flaButtonEdit.Properties.AppearanceFocused.Options.UseFont = true;
            this.flaButtonEdit.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.flaButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F6))});
            this.flaButtonEdit.Size = new System.Drawing.Size(170, 20);
            this.flaButtonEdit.TabIndex = 0;
            this.flaButtonEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.flaButtonEdit_KeyDown);
            this.flaButtonEdit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.flaButtonEdit_KeyUp);
            // 
            // AtlasButtonEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flaButtonEdit);
            this.Name = "AtlasButtonEdit";
            this.Size = new System.Drawing.Size(170, 20);
            ((System.ComponentModel.ISupportInitialize)(this.flaButtonEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.ButtonEdit flaButtonEdit;
    }
}
