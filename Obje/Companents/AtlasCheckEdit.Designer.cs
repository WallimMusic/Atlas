namespace Obje.Companents
{
    partial class AtlasCheckEdit
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
            this.flaCheck = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.flaCheck.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // flaCheck
            // 
            this.flaCheck.EnterMoveNextControl = true;
            this.flaCheck.Location = new System.Drawing.Point(4, -2);
            this.flaCheck.Name = "flaCheck";
            this.flaCheck.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.flaCheck.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.flaCheck.Properties.Appearance.Options.UseBackColor = true;
            this.flaCheck.Properties.Appearance.Options.UseFont = true;
            this.flaCheck.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.flaCheck.Properties.AppearanceFocused.Options.UseFont = true;
            this.flaCheck.Properties.Caption = "checkEdit1";
            this.flaCheck.Size = new System.Drawing.Size(166, 19);
            this.flaCheck.TabIndex = 0;
            this.flaCheck.CheckedChanged += new System.EventHandler(this.flaCheck_CheckedChanged);
            // 
            // FlashCheckEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flaCheck);
            this.Name = "FlashCheckEdit";
            this.Size = new System.Drawing.Size(170, 20);
            ((System.ComponentModel.ISupportInitialize)(this.flaCheck.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.CheckEdit flaCheck;
    }
}
