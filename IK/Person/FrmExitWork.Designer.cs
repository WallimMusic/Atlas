namespace IK.Person
{
    partial class FrmExitWork
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExitWork));
            this.label1 = new System.Windows.Forms.Label();
            this.atlasTextBox1 = new Obje.Companents.AtlasTextBox();
            this.groupControl7 = new DevExpress.XtraEditors.GroupControl();
            this.dgwFolder = new DevExpress.XtraGrid.GridControl();
            this.grdFolder = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnEscape = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.btnDeleteLine = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeleteBarcode = new DevExpress.XtraBars.BarButtonItem();
            this.btnFolderAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnFolderDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnFolderOpen = new DevExpress.XtraBars.BarButtonItem();
            this.atlasDateEdit1 = new Obje.Companents.AtlasDateEdit();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Çıkış Tarihi:";
            // 
            // atlasTextBox1
            // 
            this.atlasTextBox1.Location = new System.Drawing.Point(85, 64);
            this.atlasTextBox1.Name = "atlasTextBox1";
            this.atlasTextBox1.Size = new System.Drawing.Size(171, 20);
            this.atlasTextBox1.TabIndex = 1;
            // 
            // groupControl7
            // 
            this.groupControl7.Location = new System.Drawing.Point(0, 0);
            this.groupControl7.Name = "groupControl7";
            this.groupControl7.Size = new System.Drawing.Size(200, 100);
            this.groupControl7.TabIndex = 0;
            // 
            // dgwFolder
            // 
            this.dgwFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwFolder.Location = new System.Drawing.Point(2, 21);
            this.dgwFolder.MainView = this.grdFolder;
            this.dgwFolder.Name = "dgwFolder";
            this.dgwFolder.Size = new System.Drawing.Size(1049, 204);
            this.dgwFolder.TabIndex = 68;
            this.dgwFolder.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdFolder});
            // 
            // grdFolder
            // 
            this.grdFolder.GridControl = this.dgwFolder;
            this.grdFolder.Name = "grdFolder";
            this.grdFolder.OptionsView.ShowGroupPanel = false;
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Kaydet [F2]";
            this.btnSave.Id = 0;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.LargeImage")));
            this.btnSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.btnSave.Name = "btnSave";
            // 
            // btnEscape
            // 
            this.btnEscape.Caption = "Vazgeç [ESC]";
            this.btnEscape.Id = 1;
            this.btnEscape.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEscape.ImageOptions.Image")));
            this.btnEscape.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEscape.ImageOptions.LargeImage")));
            this.btnEscape.Name = "btnEscape";
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(269, 26);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 70);
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.HideWhenMerging = DevExpress.Utils.DefaultBoolean.False;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEscape, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar1
            // 
            this.bar1.BarName = "Main menu";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.HideWhenMerging = DevExpress.Utils.DefaultBoolean.False;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem2, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Main menu";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Kaydet [F2]";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Vazgeç [ESC]";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControl1);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.btnDeleteLine,
            this.btnDeleteBarcode,
            this.btnFolderAdd,
            this.btnFolderDelete,
            this.btnFolderOpen});
            this.barManager1.MainMenu = this.bar1;
            this.barManager1.MaxItemId = 7;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(269, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 96);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(269, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 70);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl1.Location = new System.Drawing.Point(269, 26);
            this.barDockControl1.Manager = this.barManager1;
            this.barDockControl1.Size = new System.Drawing.Size(0, 70);
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
            // atlasDateEdit1
            // 
            this.atlasDateEdit1.Location = new System.Drawing.Point(85, 35);
            this.atlasDateEdit1.Name = "atlasDateEdit1";
            this.atlasDateEdit1.Size = new System.Drawing.Size(170, 20);
            this.atlasDateEdit1.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "İzin Hakkı:";
            // 
            // FrmExitWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 96);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.atlasDateEdit1);
            this.Controls.Add(this.atlasTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControl1);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmExitWork";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İşten Çıkış ";
            this.Load += new System.EventHandler(this.FrmExitWork_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Obje.Companents.AtlasTextBox atlasTextBox1;
        private DevExpress.XtraEditors.GroupControl groupControl7;
        private DevExpress.XtraGrid.GridControl dgwFolder;
        private DevExpress.XtraGrid.Views.Grid.GridView grdFolder;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnEscape;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private System.Windows.Forms.Label label2;
        private Obje.Companents.AtlasDateEdit atlasDateEdit1;
        private DevExpress.XtraBars.BarButtonItem btnDeleteLine;
        private DevExpress.XtraBars.BarButtonItem btnDeleteBarcode;
        private DevExpress.XtraBars.BarButtonItem btnFolderAdd;
        private DevExpress.XtraBars.BarButtonItem btnFolderDelete;
        private DevExpress.XtraBars.BarButtonItem btnFolderOpen;
    }
}