namespace Sys.User
{
    partial class FrmAuth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAuth));
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnEscape = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnDeleteLine = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBranchAddList = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAddBranchList = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ledPackage = new Obje.Companents.AtlasLookUp();
            this.ledUser = new Obje.Companents.AtlasLookUp();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgwBranch = new DevExpress.XtraGrid.GridControl();
            this.grdBranch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dgwAuth = new DevExpress.XtraGrid.GridControl();
            this.grdAuth = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dgwDb = new DevExpress.XtraGrid.GridControl();
            this.grdDb = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ledFirm = new Obje.Companents.AtlasLookUp();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwBranch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBranch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAuth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAuth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwDb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDb)).BeginInit();
            this.SuspendLayout();
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEscape, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Main menu";
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Kaydet [F2]";
            this.btnSave.Id = 0;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.LargeImage")));
            this.btnSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShortcutKeyDisplayString = "F2";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnEscape
            // 
            this.btnEscape.Caption = "Vazgeç [ESC]";
            this.btnEscape.Id = 1;
            this.btnEscape.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEscape.ImageOptions.Image")));
            this.btnEscape.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEscape.ImageOptions.LargeImage")));
            this.btnEscape.Name = "btnEscape";
            this.btnEscape.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.False;
            this.btnEscape.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEscape_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSave,
            this.btnEscape,
            this.btnDeleteLine,
            this.bbiBranchAddList,
            this.bbiAddBranchList,
            this.barButtonItem1});
            this.barManager1.MainMenu = this.bar1;
            this.barManager1.MaxItemId = 7;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(731, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 684);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(731, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 658);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(731, 26);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 658);
            // 
            // btnDeleteLine
            // 
            this.btnDeleteLine.Caption = "Satırı Sil";
            this.btnDeleteLine.Id = 3;
            this.btnDeleteLine.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteLine.ImageOptions.Image")));
            this.btnDeleteLine.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDeleteLine.ImageOptions.LargeImage")));
            this.btnDeleteLine.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Delete);
            this.btnDeleteLine.Name = "btnDeleteLine";
            // 
            // bbiBranchAddList
            // 
            this.bbiBranchAddList.Caption = "Listeye Ekle";
            this.bbiBranchAddList.Id = 4;
            this.bbiBranchAddList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiBranchAddList.ImageOptions.Image")));
            this.bbiBranchAddList.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiBranchAddList.ImageOptions.LargeImage")));
            this.bbiBranchAddList.Name = "bbiBranchAddList";
            // 
            // bbiAddBranchList
            // 
            this.bbiAddBranchList.Caption = "Listeye Ekle";
            this.bbiAddBranchList.Id = 5;
            this.bbiAddBranchList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiAddBranchList.ImageOptions.Image")));
            this.bbiAddBranchList.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiAddBranchList.ImageOptions.LargeImage")));
            this.bbiAddBranchList.Name = "bbiAddBranchList";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Listeden Kaldır";
            this.barButtonItem1.Id = 6;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ledFirm);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ledPackage);
            this.groupBox1.Controls.Add(this.ledUser);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(653, 76);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Genel Bilgiler";
            // 
            // ledPackage
            // 
            this.ledPackage.Location = new System.Drawing.Point(423, 17);
            this.ledPackage.Name = "ledPackage";
            this.ledPackage.Size = new System.Drawing.Size(221, 20);
            this.ledPackage.TabIndex = 74;
            // 
            // ledUser
            // 
            this.ledUser.Location = new System.Drawing.Point(114, 43);
            this.ledUser.Name = "ledUser";
            this.ledUser.Size = new System.Drawing.Size(221, 20);
            this.ledUser.TabIndex = 72;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(341, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 71;
            this.label3.Text = "Yetki Paketi:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(47, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 69;
            this.label1.Text = "Kullanıcı:";
            // 
            // dgwBranch
            // 
            this.dgwBranch.Location = new System.Drawing.Point(5, 113);
            this.dgwBranch.MainView = this.grdBranch;
            this.dgwBranch.MenuManager = this.barManager1;
            this.dgwBranch.Name = "dgwBranch";
            this.dgwBranch.Size = new System.Drawing.Size(335, 279);
            this.dgwBranch.TabIndex = 5;
            this.dgwBranch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdBranch});
            // 
            // grdBranch
            // 
            this.grdBranch.GridControl = this.dgwBranch;
            this.grdBranch.Name = "grdBranch";
            this.grdBranch.OptionsView.ShowGroupPanel = false;
            // 
            // dgwAuth
            // 
            this.dgwAuth.Location = new System.Drawing.Point(346, 113);
            this.dgwAuth.MainView = this.grdAuth;
            this.dgwAuth.MenuManager = this.barManager1;
            this.dgwAuth.Name = "dgwAuth";
            this.dgwAuth.Size = new System.Drawing.Size(377, 568);
            this.dgwAuth.TabIndex = 6;
            this.dgwAuth.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdAuth});
            // 
            // grdAuth
            // 
            this.grdAuth.GridControl = this.dgwAuth;
            this.grdAuth.Name = "grdAuth";
            this.grdAuth.OptionsView.ShowGroupPanel = false;
            // 
            // dgwDb
            // 
            this.dgwDb.Location = new System.Drawing.Point(5, 398);
            this.dgwDb.MainView = this.grdDb;
            this.dgwDb.MenuManager = this.barManager1;
            this.dgwDb.Name = "dgwDb";
            this.dgwDb.Size = new System.Drawing.Size(335, 283);
            this.dgwDb.TabIndex = 7;
            this.dgwDb.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdDb});
            // 
            // grdDb
            // 
            this.grdDb.GridControl = this.dgwDb;
            this.grdDb.Name = "grdDb";
            this.grdDb.OptionsView.ShowGroupPanel = false;
            // 
            // ledFirm
            // 
            this.ledFirm.Location = new System.Drawing.Point(114, 17);
            this.ledFirm.Name = "ledFirm";
            this.ledFirm.Size = new System.Drawing.Size(221, 20);
            this.ledFirm.TabIndex = 75;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(62, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 74;
            this.label2.Text = "Firma:";
            // 
            // FrmAuth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 684);
            this.Controls.Add(this.dgwDb);
            this.Controls.Add(this.dgwAuth);
            this.Controls.Add(this.dgwBranch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmAuth";
            this.Text = "FrmAuth";
            this.Load += new System.EventHandler(this.FrmAuth_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwBranch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBranch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAuth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAuth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwDb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnEscape;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnDeleteLine;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.GridControl dgwDb;
        private DevExpress.XtraGrid.Views.Grid.GridView grdDb;
        private DevExpress.XtraGrid.GridControl dgwAuth;
        private DevExpress.XtraGrid.Views.Grid.GridView grdAuth;
        private DevExpress.XtraGrid.GridControl dgwBranch;
        private DevExpress.XtraGrid.Views.Grid.GridView grdBranch;
        private Obje.Companents.AtlasLookUp ledPackage;
        private Obje.Companents.AtlasLookUp ledUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraBars.BarButtonItem bbiBranchAddList;
        private DevExpress.XtraBars.BarButtonItem bbiAddBranchList;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private Obje.Companents.AtlasLookUp ledFirm;
        private System.Windows.Forms.Label label2;
    }
}