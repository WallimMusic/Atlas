namespace IK
{
    partial class frmPersonelList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPersonelList));
            this.barList = new DevExpress.XtraBars.Bar();
            this.bbiAdd = new DevExpress.XtraBars.BarButtonItem();
            this.bbiChange = new DevExpress.XtraBars.BarButtonItem();
            this.btnSil = new DevExpress.XtraBars.BarButtonItem();
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
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.dgwList = new DevExpress.XtraGrid.GridControl();
            this.grdList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
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
            this.btnSil.Caption = "Çıkış [Delete]";
            this.btnSil.Id = 15;
            this.btnSil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSil.ImageOptions.Image")));
            this.btnSil.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSil.ImageOptions.LargeImage")));
            this.btnSil.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Delete);
            this.btnSil.Name = "btnSil";
            this.btnSil.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSil_ItemClick);
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
            this.barCheckItem1,
            this.btnSil,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3});
            this.barManager1.MainMenu = this.barList;
            this.barManager1.MaxItemId = 19;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(770, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 358);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(770, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 332);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(770, 26);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 332);
            // 
            // barCheckItem1
            // 
            this.barCheckItem1.Caption = "barCheckItem1";
            this.barCheckItem1.Id = 14;
            this.barCheckItem1.Name = "barCheckItem1";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Ekle...";
            this.barButtonItem1.Id = 16;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAdd_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Değiştir...";
            this.barButtonItem2.Id = 17;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiChange_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Çıkış...";
            this.barButtonItem3.Id = 18;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSil_ItemClick);
            // 
            // dgwList
            // 
            this.dgwList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwList.Location = new System.Drawing.Point(0, 26);
            this.dgwList.MainView = this.grdList;
            this.dgwList.MenuManager = this.barManager1;
            this.dgwList.Name = "dgwList";
            this.dgwList.Size = new System.Drawing.Size(770, 332);
            this.dgwList.TabIndex = 6;
            this.dgwList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdList});
            // 
            // grdList
            // 
            this.grdList.GridControl = this.dgwList;
            this.grdList.Name = "grdList";
            this.grdList.OptionsBehavior.Editable = false;
            this.grdList.OptionsView.ShowAutoFilterRow = true;
            this.grdList.OptionsView.ShowGroupPanel = false;
            this.grdList.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.grdList_PopupMenuShowing);
            this.grdList.DoubleClick += new System.EventHandler(this.grdList_DoubleClick);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(657, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(98, 24);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Visible = false;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // frmPersonelList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 358);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.dgwList);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmPersonelList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kayıt Listesi";
            this.Load += new System.EventHandler(this.frmList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private DevExpress.XtraGrid.GridControl dgwList;
        private DevExpress.XtraGrid.Views.Grid.GridView grdList;
        private DevExpress.XtraBars.BarButtonItem btnSil;
        private DevExpress.XtraBars.BarCheckItem barCheckItem1;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}