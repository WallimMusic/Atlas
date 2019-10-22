namespace Erp.Stock
{
    partial class FrmPrintBarcode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrintBarcode));
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ledCard = new Obje.Companents.AtlasLookUp();
            this.flashTextBox1 = new Obje.Companents.AtlasTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnEscape = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeleteLine = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeleteBarcode = new DevExpress.XtraBars.BarButtonItem();
            this.btnFolderAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnFolderDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnFolderOpen = new DevExpress.XtraBars.BarButtonItem();
            this.dgwGrid = new DevExpress.XtraGrid.GridControl();
            this.grdGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.barCodeControl1 = new DevExpress.XtraEditors.BarCodeControl();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ledCard);
            this.groupBox1.Controls.Add(this.flashTextBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblUsername);
            this.groupBox1.Location = new System.Drawing.Point(8, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 69);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bilgiler";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // ledCard
            // 
            this.ledCard.Location = new System.Drawing.Point(74, 17);
            this.ledCard.Name = "ledCard";
            this.ledCard.Size = new System.Drawing.Size(250, 20);
            this.ledCard.TabIndex = 1;
            // 
            // flashTextBox1
            // 
            this.flashTextBox1.Location = new System.Drawing.Point(73, 42);
            this.flashTextBox1.Name = "flashTextBox1";
            this.flashTextBox1.Size = new System.Drawing.Size(251, 20);
            this.flashTextBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(15, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 28;
            this.label1.Text = "Kart Adı:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUsername.Location = new System.Drawing.Point(5, 18);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(62, 15);
            this.lblUsername.TabIndex = 26;
            this.lblUsername.Text = "Kart Kodu:";
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Yazdır [Ctrl + P]";
            this.btnSave.Id = 0;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.LargeImage")));
            this.btnSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
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
            // dgwGrid
            // 
            this.dgwGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwGrid.Location = new System.Drawing.Point(8, 106);
            this.dgwGrid.MainView = this.grdGrid;
            this.dgwGrid.Name = "dgwGrid";
            this.dgwGrid.Size = new System.Drawing.Size(330, 255);
            this.dgwGrid.TabIndex = 4;
            this.dgwGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdGrid});
            // 
            // grdGrid
            // 
            this.grdGrid.GridControl = this.dgwGrid;
            this.grdGrid.Name = "grdGrid";
            this.grdGrid.OptionsView.ShowGroupPanel = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.barCodeControl1);
            this.groupBox2.Location = new System.Drawing.Point(8, 367);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(330, 69);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Örnek Barkod";
            // 
            // barCodeControl1
            // 
            this.barCodeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barCodeControl1.Location = new System.Drawing.Point(3, 17);
            this.barCodeControl1.Module = 1.5D;
            this.barCodeControl1.Name = "barCodeControl1";
            this.barCodeControl1.Padding = new System.Windows.Forms.Padding(10, 2, 10, 0);
            this.barCodeControl1.Size = new System.Drawing.Size(324, 49);
            this.barCodeControl1.Symbology = code128Generator1;
            this.barCodeControl1.TabIndex = 10;
            this.barCodeControl1.Text = "8691234100021";
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
            this.ribbonControl1.Size = new System.Drawing.Size(348, 57);
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
            // FrmPrintBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 445);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgwGrid);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "FrmPrintBarcode";
            this.Text = "Barkod Yazdır";
            this.Load += new System.EventHandler(this.FrmPrintBarcode_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnEscape;
        private DevExpress.XtraBars.BarButtonItem btnDeleteLine;
        private DevExpress.XtraBars.BarButtonItem btnDeleteBarcode;
        private DevExpress.XtraBars.BarButtonItem btnFolderAdd;
        private DevExpress.XtraBars.BarButtonItem btnFolderDelete;
        private DevExpress.XtraBars.BarButtonItem btnFolderOpen;
        private DevExpress.XtraGrid.GridControl dgwGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView grdGrid;
        private System.Windows.Forms.Label lblUsername;
        private Obje.Companents.AtlasTextBox flashTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.BarCodeControl barCodeControl1;
        private Obje.Companents.AtlasLookUp ledCard;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
    }
}