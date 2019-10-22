namespace SYS
{
    partial class FrmFirm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFirm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ledVeritabani = new Obje.Companents.AtlasLookUp();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFirmName = new Obje.Companents.AtlasTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFirmCode = new Obje.Companents.AtlasButtonEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.chkActive = new Obje.Companents.AtlasCheckEdit();
            this.txtFirmNo = new Obje.Companents.AtlasTextBox();
            this.lblSecurityType = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTaxName = new Obje.Companents.AtlasTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTax = new Obje.Companents.AtlasTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTel3 = new Obje.Companents.FlashTextBoxGsm();
            this.txtTel2 = new Obje.Companents.FlashTextBoxGsm();
            this.txtTel1 = new Obje.Companents.FlashTextBoxGsm();
            this.txtWeb = new Obje.Companents.AtlasTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMail = new Obje.Companents.AtlasTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAddress = new Obje.Companents.AtlasMemoEdit();
            this.ledSehir = new Obje.Companents.AtlasLookUp();
            this.ledUlke = new Obje.Companents.AtlasLookUp();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.barMenu = new DevExpress.XtraBars.Bar();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnEscape = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ledVeritabani);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFirmName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtFirmCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkActive);
            this.groupBox1.Controls.Add(this.txtFirmNo);
            this.groupBox1.Controls.Add(this.lblSecurityType);
            this.groupBox1.Location = new System.Drawing.Point(10, 39);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(363, 197);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Firma Bilgileri";
            // 
            // ledVeritabani
            // 
            this.ledVeritabani.Location = new System.Drawing.Point(94, 155);
            this.ledVeritabani.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ledVeritabani.Name = "ledVeritabani";
            this.ledVeritabani.Size = new System.Drawing.Size(198, 25);
            this.ledVeritabani.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(20, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 44;
            this.label3.Text = "Veritabanı:";
            // 
            // txtFirmName
            // 
            this.txtFirmName.Location = new System.Drawing.Point(94, 123);
            this.txtFirmName.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtFirmName.Name = "txtFirmName";
            this.txtFirmName.Size = new System.Drawing.Size(261, 25);
            this.txtFirmName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(21, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 42;
            this.label2.Text = "Firma Adı:";
            // 
            // txtFirmCode
            // 
            this.txtFirmCode.Location = new System.Drawing.Point(94, 91);
            this.txtFirmCode.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtFirmCode.Name = "txtFirmCode";
            this.txtFirmCode.Size = new System.Drawing.Size(198, 25);
            this.txtFirmCode.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(9, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 40;
            this.label1.Text = "Firma Kodu:";
            // 
            // chkActive
            // 
            this.chkActive.Location = new System.Drawing.Point(94, 27);
            this.chkActive.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(198, 25);
            this.chkActive.TabIndex = 1;
            // 
            // txtFirmNo
            // 
            this.txtFirmNo.Location = new System.Drawing.Point(94, 59);
            this.txtFirmNo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtFirmNo.Name = "txtFirmNo";
            this.txtFirmNo.Size = new System.Drawing.Size(138, 25);
            this.txtFirmNo.TabIndex = 2;
            // 
            // lblSecurityType
            // 
            this.lblSecurityType.AutoSize = true;
            this.lblSecurityType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSecurityType.Location = new System.Drawing.Point(23, 63);
            this.lblSecurityType.Name = "lblSecurityType";
            this.lblSecurityType.Size = new System.Drawing.Size(73, 20);
            this.lblSecurityType.TabIndex = 24;
            this.lblSecurityType.Text = "Firma No:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTaxName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtTax);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(10, 244);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(363, 98);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Vergi Dairesi";
            // 
            // txtTaxName
            // 
            this.txtTaxName.Location = new System.Drawing.Point(94, 57);
            this.txtTaxName.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtTaxName.Name = "txtTaxName";
            this.txtTaxName.Size = new System.Drawing.Size(261, 25);
            this.txtTaxName.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(30, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 42;
            this.label5.Text = "V.D Adı:";
            // 
            // txtTax
            // 
            this.txtTax.Location = new System.Drawing.Point(94, 25);
            this.txtTax.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtTax.Name = "txtTax";
            this.txtTax.Size = new System.Drawing.Size(138, 25);
            this.txtTax.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(33, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 24;
            this.label7.Text = "V.D No:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTel3);
            this.groupBox3.Controls.Add(this.txtTel2);
            this.groupBox3.Controls.Add(this.txtTel1);
            this.groupBox3.Controls.Add(this.txtWeb);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtMail);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtAddress);
            this.groupBox3.Controls.Add(this.ledSehir);
            this.groupBox3.Controls.Add(this.ledUlke);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(10, 350);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(720, 177);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "İletişim Bilgileri";
            // 
            // txtTel3
            // 
            this.txtTel3.Location = new System.Drawing.Point(455, 80);
            this.txtTel3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtTel3.Name = "txtTel3";
            this.txtTel3.Size = new System.Drawing.Size(175, 25);
            this.txtTel3.TabIndex = 13;
            // 
            // txtTel2
            // 
            this.txtTel2.Location = new System.Drawing.Point(455, 50);
            this.txtTel2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtTel2.Name = "txtTel2";
            this.txtTel2.Size = new System.Drawing.Size(175, 25);
            this.txtTel2.TabIndex = 12;
            // 
            // txtTel1
            // 
            this.txtTel1.Location = new System.Drawing.Point(455, 21);
            this.txtTel1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtTel1.Name = "txtTel1";
            this.txtTel1.Size = new System.Drawing.Size(175, 25);
            this.txtTel1.TabIndex = 11;
            // 
            // txtWeb
            // 
            this.txtWeb.Location = new System.Drawing.Point(455, 143);
            this.txtWeb.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtWeb.Name = "txtWeb";
            this.txtWeb.Size = new System.Drawing.Size(254, 25);
            this.txtWeb.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(406, 148);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 20);
            this.label13.TabIndex = 57;
            this.label13.Text = "Web:";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(455, 111);
            this.txtMail.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(254, 25);
            this.txtMail.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(394, 116);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 20);
            this.label12.TabIndex = 55;
            this.label12.Text = "E-Mail:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(414, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 20);
            this.label11.TabIndex = 53;
            this.label11.Text = "Fax:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(388, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 20);
            this.label10.TabIndex = 51;
            this.label10.Text = "Telefon:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(388, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 20);
            this.label9.TabIndex = 49;
            this.label9.Text = "Telefon:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(96, 85);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(267, 82);
            this.txtAddress.TabIndex = 10;
            // 
            // ledSehir
            // 
            this.ledSehir.Location = new System.Drawing.Point(94, 49);
            this.ledSehir.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ledSehir.Name = "ledSehir";
            this.ledSehir.Size = new System.Drawing.Size(198, 25);
            this.ledSehir.TabIndex = 9;
            // 
            // ledUlke
            // 
            this.ledUlke.Location = new System.Drawing.Point(94, 17);
            this.ledUlke.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ledUlke.Name = "ledUlke";
            this.ledUlke.Size = new System.Drawing.Size(198, 25);
            this.ledUlke.TabIndex = 8;
            this.ledUlke.Validated += new System.EventHandler(this.ledUlke_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(41, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 20);
            this.label8.TabIndex = 45;
            this.label8.Text = "Adres:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(49, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 20);
            this.label6.TabIndex = 44;
            this.label6.Text = "Ülke:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(45, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 43;
            this.label4.Text = "Şehir:";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.Location = new System.Drawing.Point(380, 49);
            this.pictureEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.NullText = "sağ click yapınız..";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Size = new System.Drawing.Size(349, 293);
            this.pictureEdit1.TabIndex = 51;
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
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(735, 32);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 532);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(735, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 32);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 500);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(735, 32);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 500);
            // 
            // FrmFirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 532);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmFirm";
            this.Text = "Firma";
            this.Load += new System.EventHandler(this.FrmFirm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSecurityType;
        private Obje.Companents.AtlasCheckEdit chkActive;
        private Obje.Companents.AtlasTextBox txtFirmNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private Obje.Companents.AtlasTextBox txtTaxName;
        private System.Windows.Forms.Label label5;
        private Obje.Companents.AtlasTextBox txtTax;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private Obje.Companents.AtlasTextBox txtFirmName;
        private System.Windows.Forms.Label label2;
        private Obje.Companents.AtlasButtonEdit txtFirmCode;
        private Obje.Companents.AtlasMemoEdit txtAddress;
        private Obje.Companents.AtlasLookUp ledSehir;
        private Obje.Companents.AtlasLookUp ledUlke;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private Obje.Companents.AtlasTextBox txtWeb;
        private System.Windows.Forms.Label label13;
        private Obje.Companents.AtlasTextBox txtMail;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private Obje.Companents.FlashTextBoxGsm txtTel3;
        private Obje.Companents.FlashTextBoxGsm txtTel2;
        private Obje.Companents.FlashTextBoxGsm txtTel1;
        private Obje.Companents.AtlasLookUp ledVeritabani;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraBars.Bar barMenu;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnEscape;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.ComponentModel.IContainer components;
    }
}