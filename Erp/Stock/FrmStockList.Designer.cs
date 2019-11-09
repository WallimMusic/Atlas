namespace Erp.Stock
{
    partial class FrmStockList
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStockList));
            this.pmAnaMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.grpCount = new System.Windows.Forms.GroupBox();
            this.dgwMove = new DevExpress.XtraGrid.GridControl();
            this.grdMove = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grpWhouse = new System.Windows.Forms.GroupBox();
            this.dgwWhouse = new DevExpress.XtraGrid.GridControl();
            this.grdWhouse = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grpStock = new System.Windows.Forms.GroupBox();
            this.dgwStock = new DevExpress.XtraGrid.GridControl();
            this.grdStock = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiAdd = new DevExpress.XtraBars.BarButtonItem();
            this.bbiChange = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEscape = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExport = new DevExpress.XtraBars.BarSubItem();
            this.bbixls = new DevExpress.XtraBars.BarButtonItem();
            this.bbixlsx = new DevExpress.XtraBars.BarButtonItem();
            this.bbipdf = new DevExpress.XtraBars.BarButtonItem();
            this.bbidoc = new DevExpress.XtraBars.BarButtonItem();
            this.bbiShow = new DevExpress.XtraBars.BarSubItem();
            this.bbiGruplama = new DevExpress.XtraBars.BarButtonItem();
            this.bbiFiltreleme = new DevExpress.XtraBars.BarButtonItem();
            this.bbiFiltreTemizle = new DevExpress.XtraBars.BarButtonItem();
            this.bbiInfo = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.pmAnaMenu)).BeginInit();
            this.grpCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMove)).BeginInit();
            this.grpWhouse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwWhouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWhouse)).BeginInit();
            this.grpStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // pmAnaMenu
            // 
            this.pmAnaMenu.Name = "pmAnaMenu";
            // 
            // grpCount
            // 
            this.grpCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCount.Controls.Add(this.dgwMove);
            this.grpCount.Location = new System.Drawing.Point(993, 37);
            this.grpCount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpCount.Name = "grpCount";
            this.grpCount.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpCount.Size = new System.Drawing.Size(480, 720);
            this.grpCount.TabIndex = 16;
            this.grpCount.TabStop = false;
            this.grpCount.Text = "Son Hareketleri";
            // 
            // dgwMove
            // 
            this.dgwMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwMove.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgwMove.Location = new System.Drawing.Point(3, 20);
            this.dgwMove.MainView = this.grdMove;
            this.dgwMove.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgwMove.Name = "dgwMove";
            this.dgwMove.Size = new System.Drawing.Size(474, 696);
            this.dgwMove.TabIndex = 1;
            this.dgwMove.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdMove});
            // 
            // grdMove
            // 
            this.grdMove.DetailHeight = 431;
            this.grdMove.GridControl = this.dgwMove;
            this.grdMove.Name = "grdMove";
            this.grdMove.OptionsView.ShowGroupPanel = false;
            // 
            // grpWhouse
            // 
            this.grpWhouse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpWhouse.Controls.Add(this.dgwWhouse);
            this.grpWhouse.Location = new System.Drawing.Point(657, 37);
            this.grpWhouse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpWhouse.Name = "grpWhouse";
            this.grpWhouse.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpWhouse.Size = new System.Drawing.Size(333, 720);
            this.grpWhouse.TabIndex = 15;
            this.grpWhouse.TabStop = false;
            this.grpWhouse.Text = "Depo Miktarları";
            // 
            // dgwWhouse
            // 
            this.dgwWhouse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwWhouse.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgwWhouse.Location = new System.Drawing.Point(3, 20);
            this.dgwWhouse.MainView = this.grdWhouse;
            this.dgwWhouse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgwWhouse.Name = "dgwWhouse";
            this.dgwWhouse.Size = new System.Drawing.Size(327, 696);
            this.dgwWhouse.TabIndex = 0;
            this.dgwWhouse.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdWhouse});
            // 
            // grdWhouse
            // 
            this.grdWhouse.DetailHeight = 431;
            this.grdWhouse.GridControl = this.dgwWhouse;
            this.grdWhouse.Name = "grdWhouse";
            this.grdWhouse.OptionsView.ShowGroupPanel = false;
            // 
            // grpStock
            // 
            this.grpStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpStock.Controls.Add(this.dgwStock);
            this.grpStock.Location = new System.Drawing.Point(5, 45);
            this.grpStock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpStock.Name = "grpStock";
            this.grpStock.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpStock.Size = new System.Drawing.Size(649, 720);
            this.grpStock.TabIndex = 14;
            this.grpStock.TabStop = false;
            this.grpStock.Text = "Stoklar";
            // 
            // dgwStock
            // 
            this.dgwStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwStock.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgwStock.Location = new System.Drawing.Point(3, 20);
            this.dgwStock.MainView = this.grdStock;
            this.dgwStock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgwStock.Name = "dgwStock";
            this.dgwStock.Size = new System.Drawing.Size(643, 696);
            this.dgwStock.TabIndex = 6;
            this.dgwStock.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdStock});
            // 
            // grdStock
            // 
            this.grdStock.DetailHeight = 431;
            this.grdStock.GridControl = this.dgwStock;
            this.grdStock.Name = "grdStock";
            this.grdStock.OptionsView.ShowGroupPanel = false;
            this.grdStock.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdStock_FocusedRowChanged);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Purple;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.bbiAdd,
            this.bbiChange,
            this.bbiDelete,
            this.bbiEscape,
            this.bbiExport,
            this.bbiShow,
            this.bbixls,
            this.bbixlsx,
            this.bbipdf,
            this.bbidoc,
            this.bbiGruplama,
            this.bbiFiltreleme,
            this.bbiFiltreTemizle,
            this.bbiInfo,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonControl1.MaxItemId = 1;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbonControl1.Size = new System.Drawing.Size(1485, 53);
            // 
            // bbiAdd
            // 
            this.bbiAdd.Caption = "Ekle [F1]\r\n";
            this.bbiAdd.Id = 0;
            this.bbiAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiAdd.ImageOptions.Image")));
            this.bbiAdd.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiAdd.ImageOptions.LargeImage")));
            this.bbiAdd.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1);
            this.bbiAdd.Name = "bbiAdd";
            this.bbiAdd.Tag = "Kaydet";
            this.bbiAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAdd_ItemClick);
            // 
            // bbiChange
            // 
            this.bbiChange.Caption = "Değiştir [F2]";
            this.bbiChange.Id = 1;
            this.bbiChange.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiChange.ImageOptions.Image")));
            this.bbiChange.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiChange.ImageOptions.LargeImage")));
            this.bbiChange.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.bbiChange.Name = "bbiChange";
            this.bbiChange.Tag = "Degistir";
            this.bbiChange.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiChange_ItemClick);
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Pasife Çek [Del]";
            this.bbiDelete.Id = 2;
            this.bbiDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiDelete.ImageOptions.Image")));
            this.bbiDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiDelete.ImageOptions.LargeImage")));
            this.bbiDelete.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Delete);
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.Tag = "Sil";
            this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDelete_ItemClick);
            // 
            // bbiEscape
            // 
            this.bbiEscape.Caption = "Vazgeç [ESC]";
            this.bbiEscape.Id = 3;
            this.bbiEscape.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiEscape.ImageOptions.Image")));
            this.bbiEscape.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiEscape.ImageOptions.LargeImage")));
            this.bbiEscape.Name = "bbiEscape";
            this.bbiEscape.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEscape_ItemClick);
            this.bbiEscape.ItemDoubleClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEscape_ItemDoubleClick);
            // 
            // bbiExport
            // 
            this.bbiExport.Caption = "Aktarım";
            this.bbiExport.Id = 4;
            this.bbiExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiExport.ImageOptions.Image")));
            this.bbiExport.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiExport.ImageOptions.LargeImage")));
            this.bbiExport.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbixls),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbixlsx),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbipdf),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbidoc)});
            this.bbiExport.Name = "bbiExport";
            // 
            // bbixls
            // 
            this.bbixls.Caption = "Excel (xls)";
            this.bbixls.Id = 6;
            this.bbixls.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbixls.ImageOptions.Image")));
            this.bbixls.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbixls.ImageOptions.LargeImage")));
            this.bbixls.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1));
            this.bbixls.Name = "bbixls";
            this.bbixls.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbixls_ItemClick);
            // 
            // bbixlsx
            // 
            this.bbixlsx.Caption = "Excel (xlsx)";
            this.bbixlsx.Id = 7;
            this.bbixlsx.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbixlsx.ImageOptions.Image")));
            this.bbixlsx.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbixlsx.ImageOptions.LargeImage")));
            this.bbixlsx.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2));
            this.bbixlsx.Name = "bbixlsx";
            this.bbixlsx.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbixlsx_ItemClick);
            // 
            // bbipdf
            // 
            this.bbipdf.Caption = "Pdf";
            this.bbipdf.Id = 8;
            this.bbipdf.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbipdf.ImageOptions.Image")));
            this.bbipdf.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbipdf.ImageOptions.LargeImage")));
            this.bbipdf.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3));
            this.bbipdf.Name = "bbipdf";
            this.bbipdf.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbipdf_ItemClick);
            // 
            // bbidoc
            // 
            this.bbidoc.Caption = "Word";
            this.bbidoc.Id = 9;
            this.bbidoc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbidoc.ImageOptions.Image")));
            this.bbidoc.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbidoc.ImageOptions.LargeImage")));
            this.bbidoc.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4));
            this.bbidoc.Name = "bbidoc";
            this.bbidoc.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.True;
            this.bbidoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbidoc_ItemClick);
            // 
            // bbiShow
            // 
            this.bbiShow.Caption = "Görünüm";
            this.bbiShow.Id = 5;
            this.bbiShow.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiShow.ImageOptions.Image")));
            this.bbiShow.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiShow.ImageOptions.LargeImage")));
            this.bbiShow.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiGruplama),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiFiltreleme),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiFiltreTemizle)});
            this.bbiShow.Name = "bbiShow";
            // 
            // bbiGruplama
            // 
            this.bbiGruplama.Caption = "Gruplama Alanı";
            this.bbiGruplama.Id = 10;
            this.bbiGruplama.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiGruplama.ImageOptions.Image")));
            this.bbiGruplama.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiGruplama.ImageOptions.LargeImage")));
            this.bbiGruplama.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D1));
            this.bbiGruplama.Name = "bbiGruplama";
            this.bbiGruplama.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiGruplama_ItemClick);
            // 
            // bbiFiltreleme
            // 
            this.bbiFiltreleme.Caption = "Filtreleme Alanı";
            this.bbiFiltreleme.Id = 11;
            this.bbiFiltreleme.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiFiltreleme.ImageOptions.Image")));
            this.bbiFiltreleme.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiFiltreleme.ImageOptions.LargeImage")));
            this.bbiFiltreleme.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D2));
            this.bbiFiltreleme.Name = "bbiFiltreleme";
            this.bbiFiltreleme.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiFiltreleme_ItemClick);
            // 
            // bbiFiltreTemizle
            // 
            this.bbiFiltreTemizle.Caption = "Filtre Temizle";
            this.bbiFiltreTemizle.Id = 12;
            this.bbiFiltreTemizle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiFiltreTemizle.ImageOptions.Image")));
            this.bbiFiltreTemizle.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiFiltreTemizle.ImageOptions.LargeImage")));
            this.bbiFiltreTemizle.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D3));
            this.bbiFiltreTemizle.Name = "bbiFiltreTemizle";
            this.bbiFiltreTemizle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiFiltreTemizle_ItemClick);
            // 
            // bbiInfo
            // 
            this.bbiInfo.Caption = "İncele [F4]";
            this.bbiInfo.Id = 13;
            this.bbiInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiInfo.ImageOptions.Image")));
            this.bbiInfo.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiInfo.ImageOptions.LargeImage")));
            this.bbiInfo.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F4);
            this.bbiInfo.Name = "bbiInfo";
            this.bbiInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiInfo_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Ekle...";
            this.barButtonItem1.Id = 14;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Değiştir...";
            this.barButtonItem2.Id = 15;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "İncele...";
            this.barButtonItem3.Id = 16;
            this.barButtonItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.Image")));
            this.barButtonItem3.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.LargeImage")));
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Pasife Çek...";
            this.barButtonItem4.Id = 17;
            this.barButtonItem4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.ImageOptions.Image")));
            this.barButtonItem4.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.ImageOptions.LargeImage")));
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "MainMenu";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiAdd);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiChange);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiEscape);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiInfo);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiDelete);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "MainMenu";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bbixls);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbixlsx);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbipdf);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbidoc);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Aktarım";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiGruplama);
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiFiltreleme);
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiFiltreTemizle);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Görünüm";
            // 
            // FrmStockList
            // 
            this._add = true;
            this._delete = true;
            this._show = true;
            this._update = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 783);
            this.Controls.Add(this.grpCount);
            this.Controls.Add(this.grpWhouse);
            this.Controls.Add(this.grpStock);
            this.Controls.Add(this.ribbonControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmStockList";
            this.Text = "Stok Listesi";
            this.Load += new System.EventHandler(this.FrmStockList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pmAnaMenu)).EndInit();
            this.grpCount.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMove)).EndInit();
            this.grpWhouse.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwWhouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWhouse)).EndInit();
            this.grpStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.PopupMenu pmAnaMenu;
        private System.Windows.Forms.GroupBox grpCount;
        private DevExpress.XtraGrid.GridControl dgwMove;
        private DevExpress.XtraGrid.Views.Grid.GridView grdMove;
        private System.Windows.Forms.GroupBox grpWhouse;
        private DevExpress.XtraGrid.GridControl dgwWhouse;
        private DevExpress.XtraGrid.Views.Grid.GridView grdWhouse;
        private System.Windows.Forms.GroupBox grpStock;
        private DevExpress.XtraGrid.GridControl dgwStock;
        private DevExpress.XtraGrid.Views.Grid.GridView grdStock;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem bbiAdd;
        private DevExpress.XtraBars.BarButtonItem bbiChange;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiEscape;
        private DevExpress.XtraBars.BarSubItem bbiExport;
        private DevExpress.XtraBars.BarButtonItem bbixls;
        private DevExpress.XtraBars.BarButtonItem bbixlsx;
        private DevExpress.XtraBars.BarButtonItem bbipdf;
        private DevExpress.XtraBars.BarButtonItem bbidoc;
        private DevExpress.XtraBars.BarSubItem bbiShow;
        private DevExpress.XtraBars.BarButtonItem bbiGruplama;
        private DevExpress.XtraBars.BarButtonItem bbiFiltreleme;
        private DevExpress.XtraBars.BarButtonItem bbiFiltreTemizle;
        private DevExpress.XtraBars.BarButtonItem bbiInfo;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
    }
}