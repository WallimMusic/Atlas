﻿namespace Sys
{
    partial class FrmCountry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCountry));
            this.barMenu = new DevExpress.XtraBars.Bar();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnEscape = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnDeleteLine = new DevExpress.XtraBars.BarButtonItem();
            this.dgwGrid = new DevExpress.XtraGrid.GridControl();
            this.bindCountry = new System.Windows.Forms.BindingSource();
            this.grdGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPlateCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNatName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhoneCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pmMenu = new DevExpress.XtraBars.PopupMenu();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // barMenu
            // 
            this.barMenu.BarName = "Main menu";
            this.barMenu.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.barMenu.DockCol = 0;
            this.barMenu.DockRow = 0;
            this.barMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMenu.HideWhenMerging = DevExpress.Utils.DefaultBoolean.False;
            this.barMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEscape, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barMenu.OptionsBar.AllowQuickCustomization = false;
            this.barMenu.OptionsBar.UseWholeRow = true;
            this.barMenu.Text = "Main menu";
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
            this.barMenu});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSave,
            this.btnEscape,
            this.btnDeleteLine});
            this.barManager1.MainMenu = this.barMenu;
            this.barManager1.MaxItemId = 4;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(513, 32);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 340);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(513, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 32);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 308);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(513, 32);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 308);
            // 
            // btnDeleteLine
            // 
            this.btnDeleteLine.Caption = "Satırı Sil";
            this.btnDeleteLine.Id = 3;
            this.btnDeleteLine.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteLine.ImageOptions.Image")));
            this.btnDeleteLine.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDeleteLine.ImageOptions.LargeImage")));
            this.btnDeleteLine.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Delete);
            this.btnDeleteLine.Name = "btnDeleteLine";
            this.btnDeleteLine.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDeleteLine_ItemClick);
            // 
            // dgwGrid
            // 
            this.dgwGrid.DataSource = this.bindCountry;
            this.dgwGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwGrid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgwGrid.Location = new System.Drawing.Point(0, 32);
            this.dgwGrid.MainView = this.grdGrid;
            this.dgwGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgwGrid.MenuManager = this.barManager1;
            this.dgwGrid.Name = "dgwGrid";
            this.dgwGrid.Size = new System.Drawing.Size(513, 308);
            this.dgwGrid.TabIndex = 4;
            this.dgwGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdGrid});
            // 
            // grdGrid
            // 
            this.grdGrid.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPlateCode,
            this.colName,
            this.colNatName,
            this.colPhoneCode,
            this.colRef});
            this.grdGrid.GridControl = this.dgwGrid;
            this.grdGrid.Name = "grdGrid";
            this.grdGrid.OptionsView.ShowGroupPanel = false;
            this.grdGrid.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.grdGrid_PopupMenuShowing);
            // 
            // colPlateCode
            // 
            this.colPlateCode.Caption = "Ülke Kodu";
            this.colPlateCode.FieldName = "plateNo";
            this.colPlateCode.Name = "colPlateCode";
            this.colPlateCode.Visible = true;
            this.colPlateCode.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.Caption = "Adı";
            this.colName.FieldName = "name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colNatName
            // 
            this.colNatName.Caption = "Yabancı Adı";
            this.colNatName.FieldName = "nationalName";
            this.colNatName.Name = "colNatName";
            this.colNatName.Visible = true;
            this.colNatName.VisibleIndex = 2;
            // 
            // colPhoneCode
            // 
            this.colPhoneCode.Caption = "Telefon Kodu";
            this.colPhoneCode.FieldName = "countryPhoneCode";
            this.colPhoneCode.Name = "colPhoneCode";
            this.colPhoneCode.Visible = true;
            this.colPhoneCode.VisibleIndex = 3;
            // 
            // colRef
            // 
            this.colRef.Caption = "Referans No";
            this.colRef.FieldName = "Ref";
            this.colRef.Name = "colRef";
            // 
            // pmMenu
            // 
            this.pmMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDeleteLine)});
            this.pmMenu.Manager = this.barManager1;
            this.pmMenu.Name = "pmMenu";
            // 
            // FrmCountry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 340);
            this.Controls.Add(this.dgwGrid);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmCountry";
            this.Text = "Ülkeler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCountry_FormClosing);
            this.Load += new System.EventHandler(this.FrmCountry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Bar barMenu;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnEscape;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl dgwGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView grdGrid;
        private System.Windows.Forms.BindingSource bindCountry;
        private DevExpress.XtraGrid.Columns.GridColumn colPlateCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNatName;
        private DevExpress.XtraGrid.Columns.GridColumn colPhoneCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRef;
        private DevExpress.XtraBars.PopupMenu pmMenu;
        private DevExpress.XtraBars.BarButtonItem btnDeleteLine;
    }
}