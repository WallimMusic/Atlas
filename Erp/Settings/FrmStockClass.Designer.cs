namespace Erp.Settings
{
    partial class FrmStockClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStockClass));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnEscape = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeleteLine = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeleteBarcode = new DevExpress.XtraBars.BarButtonItem();
            this.btnFolderAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnFolderDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnFolderOpen = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgwClass = new DevExpress.XtraGrid.GridControl();
            this.grdClassValue = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgwValue = new DevExpress.XtraGrid.GridControl();
            this.grdValue = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdClassValue)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdValue)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Purple;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnSave,
            this.btnEscape,
            this.btnDeleteLine,
            this.btnDeleteBarcode,
            this.btnFolderAdd,
            this.btnFolderDelete,
            this.btnFolderOpen});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 1;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbonControl1.Size = new System.Drawing.Size(912, 57);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Kaydet [F2]";
            this.btnSave.Id = 0;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.LargeImage")));
            this.btnSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnSave_ItemClick);
            // 
            // btnEscape
            // 
            this.btnEscape.Caption = "Vazgeç [ESC]";
            this.btnEscape.Id = 1;
            this.btnEscape.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEscape.ImageOptions.Image")));
            this.btnEscape.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEscape.ImageOptions.LargeImage")));
            this.btnEscape.Name = "btnEscape";
            this.btnEscape.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnEscape_ItemClick);
            // 
            // btnDeleteLine
            // 
            this.btnDeleteLine.Caption = "Satırı Sil";
            this.btnDeleteLine.Id = 2;
            this.btnDeleteLine.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteLine.ImageOptions.Image")));
            this.btnDeleteLine.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDeleteLine.ImageOptions.LargeImage")));
            this.btnDeleteLine.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Delete);
            this.btnDeleteLine.Name = "btnDeleteLine";
            // 
            // btnDeleteBarcode
            // 
            this.btnDeleteBarcode.Caption = "Satırı Sil";
            this.btnDeleteBarcode.Id = 3;
            this.btnDeleteBarcode.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteBarcode.ImageOptions.Image")));
            this.btnDeleteBarcode.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDeleteBarcode.ImageOptions.LargeImage")));
            this.btnDeleteBarcode.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Delete);
            this.btnDeleteBarcode.Name = "btnDeleteBarcode";
            // 
            // btnFolderAdd
            // 
            this.btnFolderAdd.Caption = "Ekle ";
            this.btnFolderAdd.Id = 4;
            this.btnFolderAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFolderAdd.ImageOptions.Image")));
            this.btnFolderAdd.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnFolderAdd.ImageOptions.LargeImage")));
            this.btnFolderAdd.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1);
            this.btnFolderAdd.Name = "btnFolderAdd";
            // 
            // btnFolderDelete
            // 
            this.btnFolderDelete.Caption = "Sil";
            this.btnFolderDelete.Id = 5;
            this.btnFolderDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFolderDelete.ImageOptions.Image")));
            this.btnFolderDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnFolderDelete.ImageOptions.LargeImage")));
            this.btnFolderDelete.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Delete);
            this.btnFolderDelete.Name = "btnFolderDelete";
            // 
            // btnFolderOpen
            // 
            this.btnFolderOpen.Caption = "Dosyayı Aç";
            this.btnFolderOpen.Id = 6;
            this.btnFolderOpen.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFolderOpen.ImageOptions.Image")));
            this.btnFolderOpen.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnFolderOpen.ImageOptions.LargeImage")));
            this.btnFolderOpen.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O));
            this.btnFolderOpen.Name = "btnFolderOpen";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "MainMenu";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSave);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEscape);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "MainMenu";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgwClass);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 530);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sınıflar";
            // 
            // dgwClass
            // 
            this.dgwClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwClass.Location = new System.Drawing.Point(3, 17);
            this.dgwClass.MainView = this.grdClassValue;
            this.dgwClass.MenuManager = this.ribbonControl1;
            this.dgwClass.Name = "dgwClass";
            this.dgwClass.Size = new System.Drawing.Size(417, 510);
            this.dgwClass.TabIndex = 3;
            this.dgwClass.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdClassValue});
            // 
            // grdClassValue
            // 
            this.grdClassValue.GridControl = this.dgwClass;
            this.grdClassValue.Name = "grdClassValue";
            this.grdClassValue.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.grdClassValue.OptionsView.ShowGroupPanel = false;
            this.grdClassValue.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.GrdClassValue_RowClick);
            this.grdClassValue.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.GrdClassValue_RowCellClick);
            this.grdClassValue.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.GrdClassValue_CellValueChanged);
            this.grdClassValue.RowCountChanged += new System.EventHandler(this.GrdClassValue_RowCountChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgwValue);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(423, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(489, 530);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sınıf İçerikleri";
            // 
            // dgwValue
            // 
            this.dgwValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwValue.Location = new System.Drawing.Point(3, 17);
            this.dgwValue.MainView = this.grdValue;
            this.dgwValue.MenuManager = this.ribbonControl1;
            this.dgwValue.Name = "dgwValue";
            this.dgwValue.Size = new System.Drawing.Size(483, 510);
            this.dgwValue.TabIndex = 3;
            this.dgwValue.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdValue});
            // 
            // grdValue
            // 
            this.grdValue.GridControl = this.dgwValue;
            this.grdValue.Name = "grdValue";
            this.grdValue.OptionsView.ShowGroupPanel = false;
            // 
            // FrmStockClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 587);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "FrmStockClass";
            this.Text = "Stok Sınıfları";
            this.Load += new System.EventHandler(this.FrmStockClass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdClassValue)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnEscape;
        private DevExpress.XtraBars.BarButtonItem btnDeleteLine;
        private DevExpress.XtraBars.BarButtonItem btnDeleteBarcode;
        private DevExpress.XtraBars.BarButtonItem btnFolderAdd;
        private DevExpress.XtraBars.BarButtonItem btnFolderDelete;
        private DevExpress.XtraBars.BarButtonItem btnFolderOpen;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraGrid.GridControl dgwValue;
        private DevExpress.XtraGrid.Views.Grid.GridView grdValue;
        private DevExpress.XtraGrid.GridControl dgwClass;
        private DevExpress.XtraGrid.Views.Grid.GridView grdClassValue;
    }
}