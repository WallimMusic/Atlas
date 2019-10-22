namespace Sys
{
    partial class FrmDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDatabase));
            this.barMenu = new DevExpress.XtraBars.Bar();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnEscape = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new Obje.Companents.AtlasTextBox();
            this.txtTimeOut = new Obje.Companents.AtlasTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSecurityType = new System.Windows.Forms.Label();
            this.txtDbNo = new Obje.Companents.AtlasTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLoadDb = new System.Windows.Forms.Button();
            this.cmbDb = new Obje.Companents.AtlasComboBox();
            this.lblDb = new System.Windows.Forms.Label();
            this.btnTestDb = new System.Windows.Forms.Button();
            this.cmbServer = new Obje.Companents.AtlasComboBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.txtPassword = new Obje.Companents.AtlasTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsername = new Obje.Companents.AtlasTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbGuvenlikType = new Obje.Companents.AtlasComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.barDockControlTop.Size = new System.Drawing.Size(326, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 339);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(326, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 313);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(326, 26);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 313);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtTimeOut);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblSecurityType);
            this.groupBox1.Controls.Add(this.txtDbNo);
            this.groupBox1.Location = new System.Drawing.Point(0, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 97);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Veritabanı Bilgileri";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(67, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 15);
            this.label1.TabIndex = 54;
            this.label1.Text = "Ad:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(101, 42);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(118, 20);
            this.txtName.TabIndex = 2;
            // 
            // txtTimeOut
            // 
            this.txtTimeOut.Location = new System.Drawing.Point(101, 67);
            this.txtTimeOut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTimeOut.Name = "txtTimeOut";
            this.txtTimeOut.Size = new System.Drawing.Size(54, 20);
            this.txtTimeOut.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(12, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 15);
            this.label5.TabIndex = 48;
            this.label5.Text = "Zaman Aşımı:";
            // 
            // lblSecurityType
            // 
            this.lblSecurityType.AutoSize = true;
            this.lblSecurityType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSecurityType.Location = new System.Drawing.Point(11, 20);
            this.lblSecurityType.Name = "lblSecurityType";
            this.lblSecurityType.Size = new System.Drawing.Size(81, 15);
            this.lblSecurityType.TabIndex = 43;
            this.lblSecurityType.Text = "Veritabanı No:";
            // 
            // txtDbNo
            // 
            this.txtDbNo.Location = new System.Drawing.Point(101, 18);
            this.txtDbNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDbNo.Name = "txtDbNo";
            this.txtDbNo.Size = new System.Drawing.Size(118, 20);
            this.txtDbNo.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLoadDb);
            this.groupBox2.Controls.Add(this.cmbDb);
            this.groupBox2.Controls.Add(this.lblDb);
            this.groupBox2.Controls.Add(this.btnTestDb);
            this.groupBox2.Controls.Add(this.cmbServer);
            this.groupBox2.Controls.Add(this.lblServer);
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtUsername);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbGuvenlikType);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(0, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(326, 208);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bağlantı Bilgileri";
            // 
            // btnLoadDb
            // 
            this.btnLoadDb.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnLoadDb.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLoadDb.Location = new System.Drawing.Point(101, 122);
            this.btnLoadDb.Name = "btnLoadDb";
            this.btnLoadDb.Size = new System.Drawing.Size(216, 23);
            this.btnLoadDb.TabIndex = 8;
            this.btnLoadDb.Text = "Veritabanlarını Yükle";
            this.btnLoadDb.UseVisualStyleBackColor = false;
            this.btnLoadDb.Click += new System.EventHandler(this.btnLoadDb_Click);
            // 
            // cmbDb
            // 
            this.cmbDb.Location = new System.Drawing.Point(101, 149);
            this.cmbDb.Name = "cmbDb";
            this.cmbDb.Size = new System.Drawing.Size(215, 20);
            this.cmbDb.TabIndex = 9;
            // 
            // lblDb
            // 
            this.lblDb.AutoSize = true;
            this.lblDb.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDb.Location = new System.Drawing.Point(30, 152);
            this.lblDb.Name = "lblDb";
            this.lblDb.Size = new System.Drawing.Size(62, 15);
            this.lblDb.TabIndex = 65;
            this.lblDb.Text = "Veritabanı:";
            // 
            // btnTestDb
            // 
            this.btnTestDb.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnTestDb.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTestDb.Location = new System.Drawing.Point(102, 175);
            this.btnTestDb.Name = "btnTestDb";
            this.btnTestDb.Size = new System.Drawing.Size(215, 23);
            this.btnTestDb.TabIndex = 10;
            this.btnTestDb.Text = "BAĞLANTIYI TEST ET";
            this.btnTestDb.UseVisualStyleBackColor = false;
            this.btnTestDb.Click += new System.EventHandler(this.btnTestDb_Click);
            // 
            // cmbServer
            // 
            this.cmbServer.Location = new System.Drawing.Point(101, 20);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(216, 20);
            this.cmbServer.TabIndex = 4;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblServer.Location = new System.Drawing.Point(43, 22);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(50, 15);
            this.lblServer.TabIndex = 62;
            this.lblServer.Text = "Sunucu:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(102, 98);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(215, 20);
            this.txtPassword.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(60, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 15);
            this.label4.TabIndex = 60;
            this.label4.Text = "Şifre:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(102, 72);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(215, 20);
            this.txtUsername.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(17, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 59;
            this.label3.Text = "Kullanıcı Adı:";
            // 
            // cmbGuvenlikType
            // 
            this.cmbGuvenlikType.Location = new System.Drawing.Point(102, 46);
            this.cmbGuvenlikType.Name = "cmbGuvenlikType";
            this.cmbGuvenlikType.Size = new System.Drawing.Size(174, 20);
            this.cmbGuvenlikType.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 58;
            this.label2.Text = "Güvenlik Türü:";
            // 
            // FrmDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 339);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmDatabase";
            this.Text = "Veritabanı";
            this.Load += new System.EventHandler(this.FrmDatabase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private Obje.Companents.AtlasTextBox txtTimeOut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSecurityType;
        private Obje.Companents.AtlasTextBox txtDbNo;
        private System.Windows.Forms.Label label1;
        private Obje.Companents.AtlasTextBox txtName;
        private System.Windows.Forms.GroupBox groupBox2;
        private Obje.Companents.AtlasComboBox cmbServer;
        private System.Windows.Forms.Label lblServer;
        private Obje.Companents.AtlasTextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private Obje.Companents.AtlasTextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private Obje.Companents.AtlasComboBox cmbGuvenlikType;
        private System.Windows.Forms.Label label2;
        private Obje.Companents.AtlasComboBox cmbDb;
        private System.Windows.Forms.Label lblDb;
        private System.Windows.Forms.Button btnTestDb;
        private System.Windows.Forms.Button btnLoadDb;
        private System.ComponentModel.IContainer components;
    }
}