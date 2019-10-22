namespace IK.Permission
{
    partial class FrmPermissionList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPermissionList));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabAll = new DevExpress.XtraTab.XtraTabPage();
            this.dgwAll = new DevExpress.XtraGrid.GridControl();
            this.grdAll = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.barList = new DevExpress.XtraBars.Bar();
            this.bbiAdd = new DevExpress.XtraBars.BarButtonItem();
            this.bbiChange = new DevExpress.XtraBars.BarButtonItem();
            this.btnSil = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
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
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.tabNext = new DevExpress.XtraTab.XtraTabPage();
            this.dgwNext = new DevExpress.XtraGrid.GridControl();
            this.grdNext = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabNow = new DevExpress.XtraTab.XtraTabPage();
            this.dgwNow = new DevExpress.XtraGrid.GridControl();
            this.grdNow = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabLast = new DevExpress.XtraTab.XtraTabPage();
            this.dgwPast = new DevExpress.XtraGrid.GridControl();
            this.grdPast = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.tabNext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNext)).BeginInit();
            this.tabNow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwNow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNow)).BeginInit();
            this.tabLast.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 30);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabAll;
            this.xtraTabControl1.Size = new System.Drawing.Size(1071, 469);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabAll,
            this.tabNext,
            this.tabNow,
            this.tabLast});
            // 
            // tabAll
            // 
            this.tabAll.Controls.Add(this.dgwAll);
            this.tabAll.Name = "tabAll";
            this.tabAll.Size = new System.Drawing.Size(1069, 444);
            this.tabAll.Text = "Tüm İzinler";
            // 
            // dgwAll
            // 
            this.dgwAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwAll.Location = new System.Drawing.Point(0, 0);
            this.dgwAll.MainView = this.grdAll;
            this.dgwAll.MenuManager = this.barManager1;
            this.dgwAll.Name = "dgwAll";
            this.dgwAll.Size = new System.Drawing.Size(1069, 444);
            this.dgwAll.TabIndex = 0;
            this.dgwAll.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdAll});
            // 
            // grdAll
            // 
            this.grdAll.GridControl = this.dgwAll;
            this.grdAll.Name = "grdAll";
            this.grdAll.OptionsView.ShowGroupPanel = false;
            this.grdAll.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grdAll_CustomDrawCell);
            this.grdAll.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grdAll_RowCellStyle);
            this.grdAll.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grdAll_RowStyle);
            this.grdAll.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.grdAll_PopupMenuShowing);
            this.grdAll.DoubleClick += new System.EventHandler(this.grdAll_DoubleClick);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barList});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiAdd,
            this.bbiChange,
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
            this.barButtonItem1,
            this.btnSil,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5});
            this.barManager1.MainMenu = this.barList;
            this.barManager1.MaxItemId = 20;
            // 
            // barList
            // 
            this.barList.BarName = "bar menüsü";
            this.barList.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.barList.DockCol = 0;
            this.barList.DockRow = 0;
            this.barList.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barList.FloatLocation = new System.Drawing.Point(92, 142);
            this.barList.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiChange, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSil, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiEscape, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiExport, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiShow, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barList.OptionsBar.AllowQuickCustomization = false;
            this.barList.OptionsBar.MultiLine = true;
            this.barList.OptionsBar.RotateWhenVertical = false;
            this.barList.OptionsBar.UseWholeRow = true;
            this.barList.Text = "Main menu";
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
            // btnSil
            // 
            this.btnSil.Caption = "Sil [Delete]";
            this.btnSil.Id = 15;
            this.btnSil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSil.ImageOptions.Image")));
            this.btnSil.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSil.ImageOptions.LargeImage")));
            this.btnSil.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Delete);
            this.btnSil.Name = "btnSil";
            this.btnSil.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSil_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Yazdır [Ctrl + P]";
            this.barButtonItem1.Id = 14;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // bbiEscape
            // 
            this.bbiEscape.Caption = "Vazgeç [ESC]";
            this.bbiEscape.Id = 3;
            this.bbiEscape.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiEscape.ImageOptions.Image")));
            this.bbiEscape.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiEscape.ImageOptions.LargeImage")));
            this.bbiEscape.Name = "bbiEscape";
            this.bbiEscape.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEscape_ItemClick);
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
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1071, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 502);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1071, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 476);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1071, 26);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 476);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Ekle...";
            this.barButtonItem2.Id = 16;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Değiştir...";
            this.barButtonItem3.Id = 17;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiChange_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Sil...";
            this.barButtonItem4.Id = 18;
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSil_ItemClick);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Yazdır...";
            this.barButtonItem5.Id = 19;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // tabNext
            // 
            this.tabNext.Controls.Add(this.dgwNext);
            this.tabNext.Name = "tabNext";
            this.tabNext.Size = new System.Drawing.Size(1069, 444);
            this.tabNext.Text = "Gelecek İzinler";
            // 
            // dgwNext
            // 
            this.dgwNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwNext.Location = new System.Drawing.Point(0, 0);
            this.dgwNext.MainView = this.grdNext;
            this.dgwNext.MenuManager = this.barManager1;
            this.dgwNext.Name = "dgwNext";
            this.dgwNext.Size = new System.Drawing.Size(1069, 444);
            this.dgwNext.TabIndex = 1;
            this.dgwNext.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdNext});
            // 
            // grdNext
            // 
            this.grdNext.GridControl = this.dgwNext;
            this.grdNext.Name = "grdNext";
            this.grdNext.OptionsView.ShowGroupPanel = false;
            this.grdNext.DoubleClick += new System.EventHandler(this.grdAll_DoubleClick);
            // 
            // tabNow
            // 
            this.tabNow.Controls.Add(this.dgwNow);
            this.tabNow.Name = "tabNow";
            this.tabNow.Size = new System.Drawing.Size(1069, 444);
            this.tabNow.Text = "Aktif İzinler";
            // 
            // dgwNow
            // 
            this.dgwNow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwNow.Location = new System.Drawing.Point(0, 0);
            this.dgwNow.MainView = this.grdNow;
            this.dgwNow.MenuManager = this.barManager1;
            this.dgwNow.Name = "dgwNow";
            this.dgwNow.Size = new System.Drawing.Size(1069, 444);
            this.dgwNow.TabIndex = 1;
            this.dgwNow.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdNow});
            // 
            // grdNow
            // 
            this.grdNow.GridControl = this.dgwNow;
            this.grdNow.Name = "grdNow";
            this.grdNow.OptionsView.ShowGroupPanel = false;
            this.grdNow.DoubleClick += new System.EventHandler(this.grdAll_DoubleClick);
            // 
            // tabLast
            // 
            this.tabLast.Controls.Add(this.dgwPast);
            this.tabLast.Name = "tabLast";
            this.tabLast.Size = new System.Drawing.Size(1069, 444);
            this.tabLast.Text = "Geçmiş İzinler";
            // 
            // dgwPast
            // 
            this.dgwPast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwPast.Location = new System.Drawing.Point(0, 0);
            this.dgwPast.MainView = this.grdPast;
            this.dgwPast.MenuManager = this.barManager1;
            this.dgwPast.Name = "dgwPast";
            this.dgwPast.Size = new System.Drawing.Size(1069, 444);
            this.dgwPast.TabIndex = 1;
            this.dgwPast.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdPast});
            // 
            // grdPast
            // 
            this.grdPast.GridControl = this.dgwPast;
            this.grdPast.Name = "grdPast";
            this.grdPast.OptionsView.ShowGroupPanel = false;
            this.grdPast.DoubleClick += new System.EventHandler(this.grdAll_DoubleClick);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem5)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // FrmPermissionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 502);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmPermissionList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İzin Listesi";
            this.Load += new System.EventHandler(this.FrmPermissionList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabAll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.tabNext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNext)).EndInit();
            this.tabNow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwNow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNow)).EndInit();
            this.tabLast.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwPast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tabAll;
        private DevExpress.XtraTab.XtraTabPage tabNext;
        private DevExpress.XtraBars.Bar barList;
        private DevExpress.XtraBars.BarButtonItem bbiAdd;
        private DevExpress.XtraBars.BarButtonItem bbiChange;
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
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraTab.XtraTabPage tabNow;
        private DevExpress.XtraTab.XtraTabPage tabLast;
        private DevExpress.XtraGrid.GridControl dgwAll;
        private DevExpress.XtraGrid.Views.Grid.GridView grdAll;
        private DevExpress.XtraGrid.GridControl dgwNext;
        private DevExpress.XtraGrid.Views.Grid.GridView grdNext;
        private DevExpress.XtraGrid.GridControl dgwNow;
        private DevExpress.XtraGrid.Views.Grid.GridView grdNow;
        private DevExpress.XtraGrid.GridControl dgwPast;
        private DevExpress.XtraGrid.Views.Grid.GridView grdPast;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnSil;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
    }
}