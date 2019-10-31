namespace Erp.Tools
{
    partial class FrmPriceList
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgwGrid = new DevExpress.XtraGrid.GridControl();
            this.grdGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgwGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwGrid
            // 
            this.dgwGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwGrid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgwGrid.Location = new System.Drawing.Point(0, 0);
            this.dgwGrid.MainView = this.grdGrid;
            this.dgwGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgwGrid.Name = "dgwGrid";
            this.dgwGrid.Size = new System.Drawing.Size(764, 345);
            this.dgwGrid.TabIndex = 0;
            this.dgwGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdGrid});
            // 
            // grdGrid
            // 
            this.grdGrid.DetailHeight = 431;
            this.grdGrid.GridControl = this.dgwGrid;
            this.grdGrid.Name = "grdGrid";
            this.grdGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdGrid_KeyDown);
            this.grdGrid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdGrid_KeyDown);
            // 
            // FrmPriceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 345);
            this.Controls.Add(this.dgwGrid);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmPriceList";
            this.Text = "Fiyat Listesi";
            this.Load += new System.EventHandler(this.FrmPriceList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgwGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView grdGrid;
    }
}