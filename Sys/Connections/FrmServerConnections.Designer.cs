namespace Sys
{
    partial class FrmServerConnections
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer Companents = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (Companents != null))
            {
                Companents.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmServerConnections));
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barMenu = new DevExpress.XtraBars.Bar();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnEscape = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.grpServerInfo = new System.Windows.Forms.GroupBox();
            this.cmbSecType = new Obje.Companents.AtlasComboBox();
            this.btnLoadDb = new System.Windows.Forms.Button();
            this.txtPassword = new Obje.Companents.AtlasTextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new Obje.Companents.AtlasTextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.cmbServer = new Obje.Companents.AtlasComboBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblSecurityType = new System.Windows.Forms.Label();
            this.grpDatabase = new System.Windows.Forms.GroupBox();
            this.cmbDb = new Obje.Companents.AtlasComboBox();
            this.lblDb = new System.Windows.Forms.Label();
            this.btnTestDb = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.grpServerInfo.SuspendLayout();
            this.grpDatabase.SuspendLayout();
            this.SuspendLayout();
            // 
            // bar4
            // 
            this.bar4.BarName = "Main menu";
            this.bar4.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 0;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar4.HideWhenMerging = DevExpress.Utils.DefaultBoolean.False;
            this.bar4.OptionsBar.AllowQuickCustomization = false;
            this.bar4.OptionsBar.UseWholeRow = true;
            this.bar4.Text = "Main menu";
            // 
            // bar1
            // 
            this.bar1.BarName = "Main menu";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.HideWhenMerging = DevExpress.Utils.DefaultBoolean.False;
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Main menu";
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
            this.btnEscape});
            this.barManager1.MainMenu = this.barMenu;
            this.barManager1.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(325, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 273);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(325, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 247);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(325, 26);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 247);
            // 
            // grpServerInfo
            // 
            this.grpServerInfo.Controls.Add(this.cmbSecType);
            this.grpServerInfo.Controls.Add(this.btnLoadDb);
            this.grpServerInfo.Controls.Add(this.txtPassword);
            this.grpServerInfo.Controls.Add(this.lblPassword);
            this.grpServerInfo.Controls.Add(this.txtUsername);
            this.grpServerInfo.Controls.Add(this.lblUsername);
            this.grpServerInfo.Controls.Add(this.cmbServer);
            this.grpServerInfo.Controls.Add(this.lblServer);
            this.grpServerInfo.Controls.Add(this.lblSecurityType);
            this.grpServerInfo.Location = new System.Drawing.Point(0, 32);
            this.grpServerInfo.Name = "grpServerInfo";
            this.grpServerInfo.Size = new System.Drawing.Size(325, 164);
            this.grpServerInfo.TabIndex = 6;
            this.grpServerInfo.TabStop = false;
            this.grpServerInfo.Text = "Sunucu Bilgileri";
            // 
            // cmbSecType
            // 
            this.cmbSecType.Location = new System.Drawing.Point(103, 15);
            this.cmbSecType.Name = "cmbSecType";
            this.cmbSecType.Size = new System.Drawing.Size(209, 20);
            this.cmbSecType.TabIndex = 30;
            // 
            // btnLoadDb
            // 
            this.btnLoadDb.BackColor = System.Drawing.Color.Bisque;
            this.btnLoadDb.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLoadDb.Location = new System.Drawing.Point(103, 124);
            this.btnLoadDb.Name = "btnLoadDb";
            this.btnLoadDb.Size = new System.Drawing.Size(209, 23);
            this.btnLoadDb.TabIndex = 27;
            this.btnLoadDb.Text = "Veritabanlarını Yükle";
            this.btnLoadDb.UseVisualStyleBackColor = false;
            this.btnLoadDb.Click += new System.EventHandler(this.btnLoadDb_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(103, 97);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(209, 20);
            this.txtPassword.TabIndex = 25;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPassword.Location = new System.Drawing.Point(64, 99);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(33, 15);
            this.lblPassword.TabIndex = 29;
            this.lblPassword.Text = "Şifre:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(103, 71);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(209, 20);
            this.txtUsername.TabIndex = 24;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUsername.Location = new System.Drawing.Point(21, 73);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(76, 15);
            this.lblUsername.TabIndex = 28;
            this.lblUsername.Text = "Kullanıcı Adı:";
            // 
            // cmbServer
            // 
            this.cmbServer.Location = new System.Drawing.Point(103, 43);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(209, 20);
            this.cmbServer.TabIndex = 22;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblServer.Location = new System.Drawing.Point(47, 45);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(50, 15);
            this.lblServer.TabIndex = 26;
            this.lblServer.Text = "Sunucu:";
            // 
            // lblSecurityType
            // 
            this.lblSecurityType.AutoSize = true;
            this.lblSecurityType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSecurityType.Location = new System.Drawing.Point(13, 19);
            this.lblSecurityType.Name = "lblSecurityType";
            this.lblSecurityType.Size = new System.Drawing.Size(84, 15);
            this.lblSecurityType.TabIndex = 23;
            this.lblSecurityType.Text = "Güvenlik Türü:";
            // 
            // grpDatabase
            // 
            this.grpDatabase.Controls.Add(this.cmbDb);
            this.grpDatabase.Controls.Add(this.lblDb);
            this.grpDatabase.Location = new System.Drawing.Point(0, 202);
            this.grpDatabase.Name = "grpDatabase";
            this.grpDatabase.Size = new System.Drawing.Size(325, 40);
            this.grpDatabase.TabIndex = 7;
            this.grpDatabase.TabStop = false;
            this.grpDatabase.Text = "Veritabanı";
            // 
            // cmbDb
            // 
            this.cmbDb.Location = new System.Drawing.Point(104, 14);
            this.cmbDb.Name = "cmbDb";
            this.cmbDb.Size = new System.Drawing.Size(209, 20);
            this.cmbDb.TabIndex = 6;
            // 
            // lblDb
            // 
            this.lblDb.AutoSize = true;
            this.lblDb.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDb.Location = new System.Drawing.Point(36, 17);
            this.lblDb.Name = "lblDb";
            this.lblDb.Size = new System.Drawing.Size(62, 15);
            this.lblDb.TabIndex = 8;
            this.lblDb.Text = "Veritabanı:";
            // 
            // btnTestDb
            // 
            this.btnTestDb.BackColor = System.Drawing.Color.Bisque;
            this.btnTestDb.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTestDb.Location = new System.Drawing.Point(0, 248);
            this.btnTestDb.Name = "btnTestDb";
            this.btnTestDb.Size = new System.Drawing.Size(325, 23);
            this.btnTestDb.TabIndex = 7;
            this.btnTestDb.Text = "BAĞLANTIYI TEST ET";
            this.btnTestDb.UseVisualStyleBackColor = false;
            this.btnTestDb.Click += new System.EventHandler(this.btnTestDb_Click);
            // 
            // FrmServerConnections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 273);
            this.Controls.Add(this.btnTestDb);
            this.Controls.Add(this.grpDatabase);
            this.Controls.Add(this.grpServerInfo);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmServerConnections";
            this.Text = "Sunucu Bağlantıları";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmServerConnections_FormClosing);
            this.Load += new System.EventHandler(this.FrmServerConnections_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.grpServerInfo.ResumeLayout(false);
            this.grpServerInfo.PerformLayout();
            this.grpDatabase.ResumeLayout(false);
            this.grpDatabase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar barMenu;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnEscape;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.GroupBox grpServerInfo;
        private System.Windows.Forms.GroupBox grpDatabase;
        private Obje.Companents.AtlasComboBox cmbDb;
        private System.Windows.Forms.Label lblDb;
        private System.Windows.Forms.Button btnTestDb;
        private System.Windows.Forms.Button btnLoadDb;
        private Obje.Companents.AtlasTextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private Obje.Companents.AtlasTextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private Obje.Companents.AtlasComboBox cmbServer;
        private System.Windows.Forms.Label lblServer;
        private Obje.Companents.AtlasComboBox cmbSecurityType;
        private System.Windows.Forms.Label lblSecurityType;
        private Obje.Companents.AtlasComboBox cmbSecType;
        private System.ComponentModel.IContainer components;
    }
}