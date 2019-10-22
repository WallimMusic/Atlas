namespace Erp.Stock
{
    partial class FrmModel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModel));
            this.pmMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnDeleteLine = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnEscape = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gridColCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbrand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riLedBrand = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.dgwGrid = new DevExpress.XtraGrid.GridControl();
            this.bindData = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pmMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLedBrand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindData)).BeginInit();
            this.SuspendLayout();
            // 
            // pmMenu
            // 
            this.pmMenu.ItemLinks.Add(this.btnDeleteLine);
            this.pmMenu.Name = "pmMenu";
            this.pmMenu.Ribbon = this.ribbonControl1;
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
            // ribbonControl1
            // 
            this.ribbonControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Purple;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnSave,
            this.btnEscape,
            this.btnDeleteLine,
            this.ribbonControl1.SearchEditItem});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 1;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(398, 128);
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
            // gridColCode
            // 
            this.gridColCode.Caption = "Model Kodu";
            this.gridColCode.FieldName = "code";
            this.gridColCode.Name = "gridColCode";
            this.gridColCode.Visible = true;
            this.gridColCode.VisibleIndex = 1;
            this.gridColCode.Width = 95;
            // 
            // colRef
            // 
            this.colRef.Caption = "Referans No";
            this.colRef.FieldName = "Ref";
            this.colRef.Name = "colRef";
            // 
            // grdGrid
            // 
            this.grdGrid.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRef,
            this.gridColCode,
            this.gridColName,
            this.colbrand});
            this.grdGrid.GridControl = this.dgwGrid;
            this.grdGrid.Name = "grdGrid";
            this.grdGrid.OptionsView.ShowGroupPanel = false;
            this.grdGrid.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.grdGrid_PopupMenuShowing);
            // 
            // gridColName
            // 
            this.gridColName.Caption = "Model Adı";
            this.gridColName.FieldName = "name";
            this.gridColName.Name = "gridColName";
            this.gridColName.Visible = true;
            this.gridColName.VisibleIndex = 2;
            this.gridColName.Width = 230;
            // 
            // colbrand
            // 
            this.colbrand.Caption = "Marka";
            this.colbrand.ColumnEdit = this.riLedBrand;
            this.colbrand.FieldName = "brandRef";
            this.colbrand.Name = "colbrand";
            this.colbrand.Visible = true;
            this.colbrand.VisibleIndex = 0;
            this.colbrand.Width = 82;
            // 
            // riLedBrand
            // 
            this.riLedBrand.AutoHeight = false;
            this.riLedBrand.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riLedBrand.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ref", "Ref", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "Adı")});
            this.riLedBrand.DisplayMember = "name";
            this.riLedBrand.Name = "riLedBrand";
            this.riLedBrand.NullText = "Seçim Yapınız..";
            this.riLedBrand.ShowFooter = false;
            this.riLedBrand.ValueMember = "Ref";
            // 
            // dgwGrid
            // 
            this.dgwGrid.DataSource = this.bindData;
            this.dgwGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwGrid.Location = new System.Drawing.Point(0, 128);
            this.dgwGrid.MainView = this.grdGrid;
            this.dgwGrid.Name = "dgwGrid";
            this.dgwGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riLedBrand});
            this.dgwGrid.Size = new System.Drawing.Size(398, 150);
            this.dgwGrid.TabIndex = 16;
            this.dgwGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdGrid});
            // 
            // FrmModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 278);
            this.Controls.Add(this.dgwGrid);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "FrmModel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Model";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmModel_FormClosing);
            this.Load += new System.EventHandler(this.FrmModel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pmMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLedBrand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.PopupMenu pmMenu;
        private DevExpress.XtraBars.BarButtonItem btnDeleteLine;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnEscape;
        private DevExpress.XtraGrid.GridControl dgwGrid;
        private System.Windows.Forms.BindingSource bindData;
        private DevExpress.XtraGrid.Views.Grid.GridView grdGrid;
        private DevExpress.XtraGrid.Columns.GridColumn colRef;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColName;
        private DevExpress.XtraGrid.Columns.GridColumn colbrand;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riLedBrand;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
    }
}