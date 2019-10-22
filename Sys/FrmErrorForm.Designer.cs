namespace Sys
{
    partial class FrmErrorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer Companents = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (Companents != null))
            {
                Companents.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flashMemoEdit1 = new Obje.Companents.AtlasMemoEdit();
            this.SuspendLayout();
            // 
            // flashMemoEdit1
            // 
            this.flashMemoEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flashMemoEdit1.Location = new System.Drawing.Point(0, 0);
            this.flashMemoEdit1.Name = "flashMemoEdit1";
            this.flashMemoEdit1.Size = new System.Drawing.Size(320, 291);
            this.flashMemoEdit1.TabIndex = 0;
            // 
            // FrmErrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 291);
            this.Controls.Add(this.flashMemoEdit1);
            this.Name = "FrmErrorForm";
            this.Text = "FrmErrorForm";
            this.Load += new System.EventHandler(this.FrmErrorForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public Obje.Companents.AtlasMemoEdit flashMemoEdit1;
    }
}