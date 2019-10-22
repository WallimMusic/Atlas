namespace Obje.Companents
{
    partial class AtlasDateEdit
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>


        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flashDate = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.flashDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flashDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // flashDate
            // 
            this.flashDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flashDate.EditValue = null;
            this.flashDate.EnterMoveNextControl = true;
            this.flashDate.Location = new System.Drawing.Point(0, 0);
            this.flashDate.Name = "flashDate";
            this.flashDate.Properties.Appearance.BackColor = System.Drawing.Color.Bisque;
            this.flashDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.flashDate.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.flashDate.Properties.Appearance.Options.UseBackColor = true;
            this.flashDate.Properties.Appearance.Options.UseFont = true;
            this.flashDate.Properties.Appearance.Options.UseForeColor = true;
            this.flashDate.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.Bisque;
            this.flashDate.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.flashDate.Properties.AppearanceDropDown.ForeColor = System.Drawing.Color.Black;
            this.flashDate.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.flashDate.Properties.AppearanceDropDown.Options.UseFont = true;
            this.flashDate.Properties.AppearanceDropDown.Options.UseForeColor = true;
            this.flashDate.Properties.AppearanceFocused.BackColor = System.Drawing.Color.PaleGreen;
            this.flashDate.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.flashDate.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.flashDate.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.flashDate.Properties.AppearanceFocused.Options.UseFont = true;
            this.flashDate.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.flashDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.flashDate.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.False;
            this.flashDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.flashDate.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.flashDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.flashDate.Properties.MaxValue = new System.DateTime(9999, 12, 31, 0, 0, 0, 0);
            this.flashDate.Size = new System.Drawing.Size(170, 20);
            this.flashDate.TabIndex = 0;
            this.flashDate.EditValueChanged += new System.EventHandler(this.flashDate_EditValueChanged);
            this.flashDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.flashDate_KeyPress);
            this.flashDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.flashDate_KeyUp);
            // 
            // AtlasDateEdit
            // 
            this.Controls.Add(this.flashDate);
            this.Name = "AtlasDateEdit";
            this.Size = new System.Drawing.Size(170, 20);
            ((System.ComponentModel.ISupportInitialize)(this.flashDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flashDate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        public DevExpress.XtraEditors.DateEdit flashDate;
    }
}
