namespace Erp.Sell
{
    partial class FrmCampaings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCampaings));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnEscape = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeleteLine = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPriceUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBranchDelete = new DevExpress.XtraBars.BarButtonItem();
            this.navBar = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.dgwGrid = new DevExpress.XtraGrid.GridControl();
            this.grdGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.riLedDirection = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.riBtnStockCode = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.riLedUnit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.navBarGroupControlContainer2 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.dgwBranch = new DevExpress.XtraGrid.GridControl();
            this.grdBranch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBranchRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBranch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riLedBranch = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colListRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPropx = new Obje.Companents.AtlasTextBox();
            this.txtPropy = new Obje.Companents.AtlasTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ledType = new Obje.Companents.AtlasLookUp();
            this.chkActive = new Obje.Companents.AtlasCheckEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFinish = new Obje.Companents.AtlasDateEdit();
            this.dtpStart = new Obje.Companents.AtlasDateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new Obje.Companents.AtlasTextBox();
            this.txtCode = new Obje.Companents.AtlasButtonEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.pmBranch = new DevExpress.XtraBars.PopupMenu(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bindData = new System.Windows.Forms.BindingSource(this.components);
            this.pmMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).BeginInit();
            this.navBar.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLedDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riBtnStockCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLedUnit)).BeginInit();
            this.navBarGroupControlContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwBranch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBranch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLedBranch)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pmBranch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmMenu)).BeginInit();
            this.SuspendLayout();
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
            // bbiPriceUpdate
            // 
            this.bbiPriceUpdate.Caption = "Fiyatları Uygula";
            this.bbiPriceUpdate.Id = 3;
            this.bbiPriceUpdate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiPriceUpdate.ImageOptions.Image")));
            this.bbiPriceUpdate.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiPriceUpdate.ImageOptions.LargeImage")));
            this.bbiPriceUpdate.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F4);
            this.bbiPriceUpdate.Name = "bbiPriceUpdate";
            // 
            // bbiBranchDelete
            // 
            this.bbiBranchDelete.Caption = "Satırı Sil";
            this.bbiBranchDelete.Id = 4;
            this.bbiBranchDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiBranchDelete.ImageOptions.Image")));
            this.bbiBranchDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiBranchDelete.ImageOptions.LargeImage")));
            this.bbiBranchDelete.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Delete);
            this.bbiBranchDelete.Name = "bbiBranchDelete";
            this.bbiBranchDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiBranchDelete_ItemClick);
            // 
            // navBar
            // 
            this.navBar.ActiveGroup = this.navBarGroup1;
            this.navBar.Controls.Add(this.navBarGroupControlContainer1);
            this.navBar.Controls.Add(this.navBarGroupControlContainer2);
            this.navBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navBar.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2});
            this.navBar.Location = new System.Drawing.Point(0, 168);
            this.navBar.Name = "navBar";
            this.navBar.OptionsNavPane.ExpandedWidth = 622;
            this.navBar.Size = new System.Drawing.Size(622, 502);
            this.navBar.TabIndex = 27;
            this.navBar.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Satırlar";
            this.navBarGroup1.ControlContainer = this.navBarGroupControlContainer1;
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupClientHeight = 319;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup1.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup1.ImageOptions.SmallImage")));
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navBarGroupControlContainer1.Appearance.Options.UseBackColor = true;
            this.navBarGroupControlContainer1.Controls.Add(this.dgwGrid);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(614, 312);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // dgwGrid
            // 
            this.dgwGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwGrid.Location = new System.Drawing.Point(0, 0);
            this.dgwGrid.MainView = this.grdGrid;
            this.dgwGrid.Name = "dgwGrid";
            this.dgwGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riLedDirection,
            this.riBtnStockCode,
            this.riLedUnit});
            this.dgwGrid.Size = new System.Drawing.Size(614, 312);
            this.dgwGrid.TabIndex = 18;
            this.dgwGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdGrid});
            // 
            // grdGrid
            // 
            this.grdGrid.GridControl = this.dgwGrid;
            this.grdGrid.Name = "grdGrid";
            this.grdGrid.OptionsView.ShowGroupPanel = false;
            this.grdGrid.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.grdGrid_PopupMenuShowing);
            this.grdGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdGrid_KeyDown);
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, editorButtonImageOptions3, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F6), serializableAppearanceObject9, serializableAppearanceObject10, serializableAppearanceObject11, serializableAppearanceObject12, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
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
            // navBarGroupControlContainer2
            // 
            this.navBarGroupControlContainer2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navBarGroupControlContainer2.Appearance.Options.UseBackColor = true;
            this.navBarGroupControlContainer2.Controls.Add(this.dgwBranch);
            this.navBarGroupControlContainer2.Name = "navBarGroupControlContainer2";
            this.navBarGroupControlContainer2.Size = new System.Drawing.Size(614, 221);
            this.navBarGroupControlContainer2.TabIndex = 1;
            // 
            // dgwBranch
            // 
            this.dgwBranch.Location = new System.Drawing.Point(-4, 0);
            this.dgwBranch.MainView = this.grdBranch;
            this.dgwBranch.Name = "dgwBranch";
            this.dgwBranch.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riLedBranch});
            this.dgwBranch.Size = new System.Drawing.Size(272, 218);
            this.dgwBranch.TabIndex = 0;
            this.dgwBranch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdBranch});
            // 
            // grdBranch
            // 
            this.grdBranch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBranchRef,
            this.colBranch,
            this.colListRef});
            this.grdBranch.GridControl = this.dgwBranch;
            this.grdBranch.Name = "grdBranch";
            this.grdBranch.OptionsView.ShowGroupPanel = false;
            this.grdBranch.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.grdBranch_PopupMenuShowing);
            // 
            // colBranchRef
            // 
            this.colBranchRef.Caption = "Ref";
            this.colBranchRef.FieldName = "Ref";
            this.colBranchRef.Name = "colBranchRef";
            // 
            // colBranch
            // 
            this.colBranch.Caption = "Şubeler";
            this.colBranch.ColumnEdit = this.riLedBranch;
            this.colBranch.FieldName = "branchRef";
            this.colBranch.Name = "colBranch";
            this.colBranch.Visible = true;
            this.colBranch.VisibleIndex = 0;
            // 
            // riLedBranch
            // 
            this.riLedBranch.AutoHeight = false;
            this.riLedBranch.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riLedBranch.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Key", "Ref", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Şube")});
            this.riLedBranch.DisplayMember = "Value";
            this.riLedBranch.Name = "riLedBranch";
            this.riLedBranch.NullText = "Seçim Yapınız";
            this.riLedBranch.ShowFooter = false;
            this.riLedBranch.ValueMember = "Key";
            // 
            // colListRef
            // 
            this.colListRef.Caption = "List Ref";
            this.colListRef.FieldName = "campaingRef";
            this.colListRef.Name = "colListRef";
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "Kullanılacak Yerler";
            this.navBarGroup2.ControlContainer = this.navBarGroupControlContainer2;
            this.navBarGroup2.GroupClientHeight = 228;
            this.navBarGroup2.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup2.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup2.ImageOptions.SmallImage")));
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPropx);
            this.groupBox1.Controls.Add(this.txtPropy);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ledType);
            this.groupBox1.Controls.Add(this.chkActive);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpFinish);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(0, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(622, 130);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Genel Bilgiler";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(510, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 15);
            this.label7.TabIndex = 58;
            this.label7.Text = "Y:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(397, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 15);
            this.label6.TabIndex = 57;
            this.label6.Text = "X:";
            // 
            // txtPropx
            // 
            this.txtPropx.Location = new System.Drawing.Point(423, 102);
            this.txtPropx.Name = "txtPropx";
            this.txtPropx.Size = new System.Drawing.Size(70, 20);
            this.txtPropx.TabIndex = 7;
            // 
            // txtPropy
            // 
            this.txtPropy.Location = new System.Drawing.Point(533, 102);
            this.txtPropy.Name = "txtPropy";
            this.txtPropy.Size = new System.Drawing.Size(70, 20);
            this.txtPropy.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(325, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 54;
            this.label1.Text = "Kampanya Tipi:";
            // 
            // ledType
            // 
            this.ledType.Location = new System.Drawing.Point(423, 22);
            this.ledType.Name = "ledType";
            this.ledType.Size = new System.Drawing.Size(180, 20);
            this.ledType.TabIndex = 4;
            // 
            // chkActive
            // 
            this.chkActive.Location = new System.Drawing.Point(128, 23);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(170, 20);
            this.chkActive.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(353, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 52;
            this.label5.Text = "Bitiş Tarihi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(325, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 15);
            this.label4.TabIndex = 51;
            this.label4.Text = "Başlangıç Tarihi:";
            // 
            // dtpFinish
            // 
            this.dtpFinish.Location = new System.Drawing.Point(423, 75);
            this.dtpFinish.Name = "dtpFinish";
            this.dtpFinish.Size = new System.Drawing.Size(180, 20);
            this.dtpFinish.TabIndex = 6;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(423, 49);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(180, 20);
            this.dtpStart.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(35, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 48;
            this.label2.Text = "Kampanya Adı:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(128, 76);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(178, 20);
            this.txtName.TabIndex = 3;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(128, 49);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(178, 20);
            this.txtCode.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(25, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 30;
            this.label3.Text = "Kampanya Kodu:";
            // 
            // pmBranch
            // 
            this.pmBranch.ItemLinks.Add(this.bbiBranchDelete);
            this.pmBranch.Name = "pmBranch";
            this.pmBranch.Ribbon = this.ribbonControl1;
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
            this.bbiPriceUpdate,
            this.bbiBranchDelete});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 1;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(622, 140);
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
            // pmMenu
            // 
            this.pmMenu.ItemLinks.Add(this.btnDeleteLine);
            this.pmMenu.Name = "pmMenu";
            this.pmMenu.Ribbon = this.ribbonControl1;
            // 
            // FrmCampaings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 670);
            this.Controls.Add(this.navBar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "FrmCampaings";
            this.Text = "Kampanyalar";
            this.Load += new System.EventHandler(this.FrmCampaings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).EndInit();
            this.navBar.ResumeLayout(false);
            this.navBarGroupControlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLedDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riBtnStockCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLedUnit)).EndInit();
            this.navBarGroupControlContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwBranch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBranch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLedBranch)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pmBranch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnEscape;
        private DevExpress.XtraNavBar.NavBarControl navBar;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer1;
        public DevExpress.XtraGrid.GridControl dgwGrid;
        public DevExpress.XtraGrid.Views.Grid.GridView grdGrid;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riLedDirection;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit riBtnStockCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riLedUnit;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer2;
        private DevExpress.XtraGrid.GridControl dgwBranch;
        private DevExpress.XtraGrid.Views.Grid.GridView grdBranch;
        private DevExpress.XtraGrid.Columns.GridColumn colBranchRef;
        private DevExpress.XtraGrid.Columns.GridColumn colBranch;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riLedBranch;
        private DevExpress.XtraGrid.Columns.GridColumn colListRef;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private System.Windows.Forms.GroupBox groupBox1;
        private Obje.Companents.AtlasCheckEdit chkActive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Obje.Companents.AtlasDateEdit dtpFinish;
        private Obje.Companents.AtlasDateEdit dtpStart;
        private System.Windows.Forms.Label label2;
        private Obje.Companents.AtlasTextBox txtName;
        private Obje.Companents.AtlasButtonEdit txtCode;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraBars.BarButtonItem btnDeleteLine;
        private DevExpress.XtraBars.BarButtonItem bbiPriceUpdate;
        private DevExpress.XtraBars.BarButtonItem bbiBranchDelete;
        private DevExpress.XtraBars.PopupMenu pmBranch;
        private System.Windows.Forms.BindingSource bindData;
        private DevExpress.XtraBars.PopupMenu pmMenu;
        private System.Windows.Forms.Label label1;
        private Obje.Companents.AtlasLookUp ledType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Obje.Companents.AtlasTextBox txtPropx;
        private Obje.Companents.AtlasTextBox txtPropy;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
    }
}