﻿namespace Erp.Buy
{
    partial class FrmServiceOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmServiceOrder));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnEscape = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeleteLine = new DevExpress.XtraBars.BarButtonItem();
            this.bbiApplyAll = new DevExpress.XtraBars.BarButtonItem();
            this.bbiApplyCard = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOrderAccept = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ledCustomer = new Obje.Companents.AtlasLookUp();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesc = new Obje.Companents.AtlasTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new Obje.Companents.AtlasTextBox();
            this.txtCode = new Obje.Companents.AtlasButtonEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpPlugDate = new Obje.Companents.AtlasDateEdit();
            this.ledBranch = new Obje.Companents.AtlasLookUp();
            this.label4 = new System.Windows.Forms.Label();
            this.pmMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblquan = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgwGrid = new DevExpress.XtraGrid.GridControl();
            this.grdGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.riLedDirection = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.riBtnStockCode = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.riLedUnit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pmMenu)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLedDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riBtnStockCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLedUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Purple;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnSave,
            this.btnEscape,
            this.btnDeleteLine,
            this.bbiApplyAll,
            this.bbiApplyCard,
            this.bbiOrderAccept});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonControl1.MaxItemId = 1;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1338, 156);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Kaydet [F2]";
            this.btnSave.Id = 0;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.LargeImage")));
            this.btnSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnEscape
            // 
            this.btnEscape.Caption = "Vazgeç [ESC]";
            this.btnEscape.Id = 1;
            this.btnEscape.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEscape.ImageOptions.Image")));
            this.btnEscape.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEscape.ImageOptions.LargeImage")));
            this.btnEscape.Name = "btnEscape";
            this.btnEscape.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEscape_ItemClick);
            // 
            // btnDeleteLine
            // 
            this.btnDeleteLine.Caption = "Satırı Sil";
            this.btnDeleteLine.Id = 2;
            this.btnDeleteLine.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteLine.ImageOptions.Image")));
            this.btnDeleteLine.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDeleteLine.ImageOptions.LargeImage")));
            this.btnDeleteLine.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Delete);
            this.btnDeleteLine.Name = "btnDeleteLine";
            this.btnDeleteLine.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDeleteLine_ItemClick);
            // 
            // bbiApplyAll
            // 
            this.bbiApplyAll.Caption = "Hepsine Uygula";
            this.bbiApplyAll.Id = 3;
            this.bbiApplyAll.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiApplyAll.ImageOptions.Image")));
            this.bbiApplyAll.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiApplyAll.ImageOptions.LargeImage")));
            this.bbiApplyAll.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A));
            this.bbiApplyAll.Name = "bbiApplyAll";
            // 
            // bbiApplyCard
            // 
            this.bbiApplyCard.Caption = "Karta Uygula";
            this.bbiApplyCard.Id = 4;
            this.bbiApplyCard.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiApplyCard.ImageOptions.Image")));
            this.bbiApplyCard.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiApplyCard.ImageOptions.LargeImage")));
            this.bbiApplyCard.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F4);
            this.bbiApplyCard.Name = "bbiApplyCard";
            // 
            // bbiOrderAccept
            // 
            this.bbiOrderAccept.Caption = "Siparişi Onayla [F5]";
            this.bbiOrderAccept.Id = 5;
            this.bbiOrderAccept.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiOrderAccept.ImageOptions.Image")));
            this.bbiOrderAccept.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiOrderAccept.ImageOptions.LargeImage")));
            this.bbiOrderAccept.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.bbiOrderAccept.Name = "bbiOrderAccept";
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
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiOrderAccept);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEscape);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "MainMenu";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ledCustomer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpPlugDate);
            this.groupBox1.Controls.Add(this.ledBranch);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(5, 52);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(559, 159);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Genel Bilgiler";
            // 
            // ledCustomer
            // 
            this.ledCustomer.Location = new System.Drawing.Point(101, 85);
            this.ledCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ledCustomer.Name = "ledCustomer";
            this.ledCustomer.Size = new System.Drawing.Size(160, 25);
            this.ledCustomer.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(56, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 60;
            this.label1.Text = "Cari:";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(101, 117);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(5);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(423, 25);
            this.txtDesc.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(21, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 58;
            this.label7.Text = "Açıklama:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(7, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 52;
            this.label2.Text = "Hizmet Adı:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(101, 55);
            this.txtName.Margin = new System.Windows.Forms.Padding(5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(160, 25);
            this.txtName.TabIndex = 2;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(101, 26);
            this.txtCode.Margin = new System.Windows.Forms.Padding(5);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(160, 25);
            this.txtCode.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(-5, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 51;
            this.label3.Text = "Hİzmet Kodu:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(264, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 41;
            this.label6.Text = "Hizmet Tarihi:";
            // 
            // dtpPlugDate
            // 
            this.dtpPlugDate.Location = new System.Drawing.Point(364, 55);
            this.dtpPlugDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpPlugDate.Name = "dtpPlugDate";
            this.dtpPlugDate.Size = new System.Drawing.Size(160, 25);
            this.dtpPlugDate.TabIndex = 3;
            // 
            // ledBranch
            // 
            this.ledBranch.Location = new System.Drawing.Point(364, 21);
            this.ledBranch.Margin = new System.Windows.Forms.Padding(5);
            this.ledBranch.Name = "ledBranch";
            this.ledBranch.Size = new System.Drawing.Size(160, 25);
            this.ledBranch.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(313, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 36;
            this.label4.Text = "Şube:";
            // 
            // pmMenu
            // 
            this.pmMenu.ItemLinks.Add(this.btnDeleteLine);
            this.pmMenu.Name = "pmMenu";
            this.pmMenu.Ribbon = this.ribbonControl1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblTotal);
            this.groupBox3.Controls.Add(this.lblquan);
            this.groupBox3.Controls.Add(this.lblCount);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(570, 52);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(382, 159);
            this.groupBox3.TabIndex = 45;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sipariş Özeti";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTotal.Location = new System.Drawing.Point(105, 95);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(21, 20);
            this.lblTotal.TabIndex = 42;
            this.lblTotal.Text = "...";
            // 
            // lblquan
            // 
            this.lblquan.AutoSize = true;
            this.lblquan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblquan.Location = new System.Drawing.Point(105, 64);
            this.lblquan.Name = "lblquan";
            this.lblquan.Size = new System.Drawing.Size(21, 20);
            this.lblquan.TabIndex = 41;
            this.lblquan.Text = "...";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCount.Location = new System.Drawing.Point(105, 32);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(21, 20);
            this.lblCount.TabIndex = 40;
            this.lblCount.Text = "...";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(7, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 20);
            this.label10.TabIndex = 39;
            this.label10.Text = "Toplam Adet:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(3, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 20);
            this.label9.TabIndex = 38;
            this.label9.Text = "Toplam Tutar:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(10, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 20);
            this.label8.TabIndex = 37;
            this.label8.Text = "Kalem Sayısı:";
            // 
            // dgwGrid
            // 
            this.dgwGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwGrid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgwGrid.Location = new System.Drawing.Point(3, 20);
            this.dgwGrid.MainView = this.grdGrid;
            this.dgwGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgwGrid.Name = "dgwGrid";
            this.dgwGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riLedDirection,
            this.riBtnStockCode,
            this.riLedUnit});
            this.dgwGrid.Size = new System.Drawing.Size(1318, 509);
            this.dgwGrid.TabIndex = 7;
            this.dgwGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdGrid,
            this.gridView2,
            this.gridView1});
            // 
            // grdGrid
            // 
            this.grdGrid.DetailHeight = 431;
            this.grdGrid.GridControl = this.dgwGrid;
            this.grdGrid.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Toplam Tutar", null, "", "")});
            this.grdGrid.Name = "grdGrid";
            this.grdGrid.OptionsView.ShowGroupPanel = false;
            this.grdGrid.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.grdGrid_PopupMenuShowing);
            this.grdGrid.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdGrid_FocusedRowChanged);
            this.grdGrid.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdGrid_CellValueChanged);
            // 
            // riLedDirection
            // 
            this.riLedDirection.AutoHeight = false;
            this.riLedDirection.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riLedDirection.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Key", "Ref", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Yön")});
            this.riLedDirection.DisplayMember = "Value";
            this.riLedDirection.Name = "riLedDirection";
            this.riLedDirection.NullText = "Seçim Yapınız..";
            this.riLedDirection.ShowFooter = false;
            this.riLedDirection.ValueMember = "Key";
            // 
            // riBtnStockCode
            // 
            this.riBtnStockCode.AutoHeight = false;
            this.riBtnStockCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F6), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.riBtnStockCode.Name = "riBtnStockCode";
            // 
            // riLedUnit
            // 
            this.riLedUnit.AutoHeight = false;
            this.riLedUnit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riLedUnit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ref", "Ref", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("unitName", "Birim")});
            this.riLedUnit.DisplayMember = "unitName";
            this.riLedUnit.Name = "riLedUnit";
            this.riLedUnit.NullText = "Seçim Yapınız..";
            this.riLedUnit.ShowFooter = false;
            this.riLedUnit.ValueMember = "Ref";
            // 
            // gridView2
            // 
            this.gridView2.DetailHeight = 431;
            this.gridView2.GridControl = this.dgwGrid;
            this.gridView2.Name = "gridView2";
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 431;
            this.gridView1.GridControl = this.dgwGrid;
            this.gridView1.Name = "gridView1";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgwGrid);
            this.groupBox2.Location = new System.Drawing.Point(5, 219);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(1324, 533);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Satırlar";
            // 
            // FrmServiceOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 765);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "FrmServiceOrder";
            this.Text = "Hizmet Satınalma Talebi";
            this.Load += new System.EventHandler(this.FrmServiceOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pmMenu)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLedDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riBtnStockCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLedUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnEscape;
        private DevExpress.XtraBars.BarButtonItem btnDeleteLine;
        private DevExpress.XtraBars.BarButtonItem bbiApplyAll;
        private DevExpress.XtraBars.BarButtonItem bbiApplyCard;
        private DevExpress.XtraBars.BarButtonItem bbiOrderAccept;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Obje.Companents.AtlasTextBox txtDesc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private Obje.Companents.AtlasTextBox txtName;
        private Obje.Companents.AtlasButtonEdit txtCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private Obje.Companents.AtlasDateEdit dtpPlugDate;
        public Obje.Companents.AtlasLookUp ledBranch;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraBars.PopupMenu pmMenu;
        public Obje.Companents.AtlasLookUp ledCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblquan;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        public DevExpress.XtraGrid.GridControl dgwGrid;
        public DevExpress.XtraGrid.Views.Grid.GridView grdGrid;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riLedDirection;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit riBtnStockCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riLedUnit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}