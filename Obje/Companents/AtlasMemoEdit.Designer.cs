namespace Obje.Companents
{
    partial class AtlasMemoEdit
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
            this.flashMemo = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.flashMemo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // flashMemo
            // 
            this.flashMemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flashMemo.Location = new System.Drawing.Point(0, 0);
            this.flashMemo.Name = "flashMemo";
            this.flashMemo.Properties.Appearance.BackColor = System.Drawing.Color.LightBlue;
            this.flashMemo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.flashMemo.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.flashMemo.Properties.Appearance.Options.UseBackColor = true;
            this.flashMemo.Properties.Appearance.Options.UseFont = true;
            this.flashMemo.Properties.Appearance.Options.UseForeColor = true;
            this.flashMemo.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Orange;
            this.flashMemo.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.flashMemo.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black;
            this.flashMemo.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.flashMemo.Properties.AppearanceFocused.Options.UseFont = true;
            this.flashMemo.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.flashMemo.Size = new System.Drawing.Size(150, 150);
            this.flashMemo.TabIndex = 0;
            this.flashMemo.EditValueChanged += new System.EventHandler(this.flaMemo_EditValueChanged);
            // 
            // AtlasMemoEdit
            // 
            this.Controls.Add(this.flashMemo);
            this.Name = "AtlasMemoEdit";
            ((System.ComponentModel.ISupportInitialize)(this.flashMemo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.MemoEdit flaMemo;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.MemoEdit memoEdit2;
        public DevExpress.XtraEditors.MemoEdit flashMemo;
    }
}
