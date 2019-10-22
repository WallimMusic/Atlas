namespace Erp.Sell
{
    partial class FrmCustomerAcc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomerAcc));
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnEscape = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeleteLine = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeleteBarcode = new DevExpress.XtraBars.BarButtonItem();
            this.btnFolderAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnFolderDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnFolderOpen = new DevExpress.XtraBars.BarButtonItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flashCheckEdit1 = new Obje.Companents.AtlasCheckEdit();
            this.chkActive = new Obje.Companents.AtlasCheckEdit();
            this.label20 = new System.Windows.Forms.Label();
            this.ledType = new Obje.Companents.AtlasLookUp();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtName = new Obje.Companents.AtlasTextBox();
            this.txtCode = new Obje.Companents.AtlasButtonEdit();
            this.navBar = new DevExpress.XtraNavBar.NavBarControl();
            this.navInfo = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.txtAdress = new Obje.Companents.AtlasMemoEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMail = new Obje.Companents.AtlasTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTel = new Obje.Companents.FlashTextBoxGsm();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGsm = new Obje.Companents.FlashTextBoxGsm();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCountry = new Obje.Companents.AtlasTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDistirct = new Obje.Companents.AtlasTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCity = new Obje.Companents.AtlasTextBox();
            this.navBarGroupControlContainer2 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.label17 = new System.Windows.Forms.Label();
            this.txtVNo = new Obje.Companents.AtlasTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtVD = new Obje.Companents.AtlasTextBox();
            this.chkPerson = new Obje.Companents.AtlasCheckEdit();
            this.txtFAdress = new Obje.Companents.AtlasMemoEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFMail = new Obje.Companents.AtlasTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFTel = new Obje.Companents.FlashTextBoxGsm();
            this.label12 = new System.Windows.Forms.Label();
            this.txtFGsm = new Obje.Companents.FlashTextBoxGsm();
            this.label13 = new System.Windows.Forms.Label();
            this.txtFCountry = new Obje.Companents.AtlasTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtFDistirct = new Obje.Companents.AtlasTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtFCity = new Obje.Companents.AtlasTextBox();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).BeginInit();
            this.navBar.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            this.navBarGroupControlContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flashCheckEdit1);
            this.groupBox1.Controls.Add(this.chkActive);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.ledType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblUsername);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Location = new System.Drawing.Point(4, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 139);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kart Üst Bilgileri";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // flashCheckEdit1
            // 
            this.flashCheckEdit1.Location = new System.Drawing.Point(70, 39);
            this.flashCheckEdit1.Name = "flashCheckEdit1";
            this.flashCheckEdit1.Size = new System.Drawing.Size(170, 20);
            this.flashCheckEdit1.TabIndex = 32;
            // 
            // chkActive
            // 
            this.chkActive.Location = new System.Drawing.Point(70, 17);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(170, 20);
            this.chkActive.TabIndex = 31;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label20.Location = new System.Drawing.Point(12, 115);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(54, 15);
            this.label20.TabIndex = 28;
            this.label20.Text = "Cari Tipi:";
            // 
            // ledType
            // 
            this.ledType.Location = new System.Drawing.Point(70, 113);
            this.ledType.Name = "ledType";
            this.ledType.Size = new System.Drawing.Size(237, 20);
            this.ledType.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(14, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 26;
            this.label1.Text = "Cari Adı:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUsername.Location = new System.Drawing.Point(4, 63);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(62, 15);
            this.lblUsername.TabIndex = 25;
            this.lblUsername.Text = "Cari Kodu:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(70, 88);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(237, 20);
            this.txtName.TabIndex = 3;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(70, 62);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(193, 20);
            this.txtCode.TabIndex = 2;
            // 
            // navBar
            // 
            this.navBar.ActiveGroup = this.navInfo;
            this.navBar.Controls.Add(this.navBarGroupControlContainer1);
            this.navBar.Controls.Add(this.navBarGroupControlContainer2);
            this.navBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navBar.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navInfo,
            this.navBarGroup1});
            this.navBar.Location = new System.Drawing.Point(0, 175);
            this.navBar.Name = "navBar";
            this.navBar.OptionsNavPane.ExpandedWidth = 417;
            this.navBar.Size = new System.Drawing.Size(417, 457);
            this.navBar.TabIndex = 11;
            this.navBar.Text = "navBarControl1";
            // 
            // navInfo
            // 
            this.navInfo.Caption = "Genel Cari Bilgileri";
            this.navInfo.ControlContainer = this.navBarGroupControlContainer1;
            this.navInfo.Expanded = true;
            this.navInfo.GroupClientHeight = 171;
            this.navInfo.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navInfo.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navInfo.ImageOptions.SmallImage")));
            this.navInfo.Name = "navInfo";
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navBarGroupControlContainer1.Appearance.Options.UseBackColor = true;
            this.navBarGroupControlContainer1.Controls.Add(this.txtAdress);
            this.navBarGroupControlContainer1.Controls.Add(this.label8);
            this.navBarGroupControlContainer1.Controls.Add(this.txtMail);
            this.navBarGroupControlContainer1.Controls.Add(this.label7);
            this.navBarGroupControlContainer1.Controls.Add(this.label6);
            this.navBarGroupControlContainer1.Controls.Add(this.txtTel);
            this.navBarGroupControlContainer1.Controls.Add(this.label5);
            this.navBarGroupControlContainer1.Controls.Add(this.txtGsm);
            this.navBarGroupControlContainer1.Controls.Add(this.label4);
            this.navBarGroupControlContainer1.Controls.Add(this.txtCountry);
            this.navBarGroupControlContainer1.Controls.Add(this.label3);
            this.navBarGroupControlContainer1.Controls.Add(this.txtDistirct);
            this.navBarGroupControlContainer1.Controls.Add(this.label2);
            this.navBarGroupControlContainer1.Controls.Add(this.txtCity);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(409, 164);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // txtAdress
            // 
            this.txtAdress.Location = new System.Drawing.Point(44, 84);
            this.txtAdress.Name = "txtAdress";
            this.txtAdress.Size = new System.Drawing.Size(357, 71);
            this.txtAdress.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(3, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 15);
            this.label8.TabIndex = 40;
            this.label8.Text = "Adres:";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(238, 55);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(163, 20);
            this.txtMail.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(199, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 15);
            this.label7.TabIndex = 38;
            this.label7.Text = "Mail:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(207, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 15);
            this.label6.TabIndex = 36;
            this.label6.Text = "Tel:";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(238, 29);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(163, 20);
            this.txtTel.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(197, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 15);
            this.label5.TabIndex = 34;
            this.label5.Text = "GSM:";
            // 
            // txtGsm
            // 
            this.txtGsm.Location = new System.Drawing.Point(238, 3);
            this.txtGsm.Name = "txtGsm";
            this.txtGsm.Size = new System.Drawing.Size(163, 20);
            this.txtGsm.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(7, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 15);
            this.label4.TabIndex = 32;
            this.label4.Text = "Ülke:";
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(44, 3);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(145, 20);
            this.txtCountry.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 30;
            this.label3.Text = "Semt:";
            // 
            // txtDistirct
            // 
            this.txtDistirct.Location = new System.Drawing.Point(44, 55);
            this.txtDistirct.Name = "txtDistirct";
            this.txtDistirct.Size = new System.Drawing.Size(145, 20);
            this.txtDistirct.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(4, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 28;
            this.label2.Text = "Şehir:";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(44, 29);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(145, 20);
            this.txtCity.TabIndex = 6;
            // 
            // navBarGroupControlContainer2
            // 
            this.navBarGroupControlContainer2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navBarGroupControlContainer2.Appearance.Options.UseBackColor = true;
            this.navBarGroupControlContainer2.Controls.Add(this.label17);
            this.navBarGroupControlContainer2.Controls.Add(this.txtVNo);
            this.navBarGroupControlContainer2.Controls.Add(this.label16);
            this.navBarGroupControlContainer2.Controls.Add(this.txtVD);
            this.navBarGroupControlContainer2.Controls.Add(this.chkPerson);
            this.navBarGroupControlContainer2.Controls.Add(this.txtFAdress);
            this.navBarGroupControlContainer2.Controls.Add(this.label9);
            this.navBarGroupControlContainer2.Controls.Add(this.txtFMail);
            this.navBarGroupControlContainer2.Controls.Add(this.label10);
            this.navBarGroupControlContainer2.Controls.Add(this.label11);
            this.navBarGroupControlContainer2.Controls.Add(this.txtFTel);
            this.navBarGroupControlContainer2.Controls.Add(this.label12);
            this.navBarGroupControlContainer2.Controls.Add(this.txtFGsm);
            this.navBarGroupControlContainer2.Controls.Add(this.label13);
            this.navBarGroupControlContainer2.Controls.Add(this.txtFCountry);
            this.navBarGroupControlContainer2.Controls.Add(this.label14);
            this.navBarGroupControlContainer2.Controls.Add(this.txtFDistirct);
            this.navBarGroupControlContainer2.Controls.Add(this.label15);
            this.navBarGroupControlContainer2.Controls.Add(this.txtFCity);
            this.navBarGroupControlContainer2.Name = "navBarGroupControlContainer2";
            this.navBarGroupControlContainer2.Size = new System.Drawing.Size(409, 207);
            this.navBarGroupControlContainer2.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label17.Location = new System.Drawing.Point(198, 28);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(36, 15);
            this.label17.TabIndex = 59;
            this.label17.Text = "V.No:";
            // 
            // txtVNo
            // 
            this.txtVNo.Location = new System.Drawing.Point(240, 23);
            this.txtVNo.Name = "txtVNo";
            this.txtVNo.Size = new System.Drawing.Size(163, 20);
            this.txtVNo.TabIndex = 17;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label16.Location = new System.Drawing.Point(9, 28);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(25, 15);
            this.label16.TabIndex = 57;
            this.label16.Text = "V.D";
            // 
            // txtVD
            // 
            this.txtVD.Location = new System.Drawing.Point(46, 23);
            this.txtVD.Name = "txtVD";
            this.txtVD.Size = new System.Drawing.Size(145, 20);
            this.txtVD.TabIndex = 13;
            // 
            // chkPerson
            // 
            this.chkPerson.Location = new System.Drawing.Point(44, 2);
            this.chkPerson.Name = "chkPerson";
            this.chkPerson.Size = new System.Drawing.Size(170, 20);
            this.chkPerson.TabIndex = 12;
            // 
            // txtFAdress
            // 
            this.txtFAdress.Location = new System.Drawing.Point(46, 129);
            this.txtFAdress.Name = "txtFAdress";
            this.txtFAdress.Size = new System.Drawing.Size(357, 71);
            this.txtFAdress.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(5, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 15);
            this.label9.TabIndex = 54;
            this.label9.Text = "Adres:";
            // 
            // txtFMail
            // 
            this.txtFMail.Location = new System.Drawing.Point(240, 100);
            this.txtFMail.Name = "txtFMail";
            this.txtFMail.Size = new System.Drawing.Size(163, 20);
            this.txtFMail.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(201, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 15);
            this.label10.TabIndex = 53;
            this.label10.Text = "Mail:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(209, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 15);
            this.label11.TabIndex = 52;
            this.label11.Text = "Tel:";
            // 
            // txtFTel
            // 
            this.txtFTel.Location = new System.Drawing.Point(240, 74);
            this.txtFTel.Name = "txtFTel";
            this.txtFTel.Size = new System.Drawing.Size(163, 20);
            this.txtFTel.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(199, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 15);
            this.label12.TabIndex = 51;
            this.label12.Text = "GSM:";
            // 
            // txtFGsm
            // 
            this.txtFGsm.Location = new System.Drawing.Point(240, 48);
            this.txtFGsm.Name = "txtFGsm";
            this.txtFGsm.Size = new System.Drawing.Size(163, 20);
            this.txtFGsm.TabIndex = 18;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(9, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 15);
            this.label13.TabIndex = 50;
            this.label13.Text = "Ülke:";
            // 
            // txtFCountry
            // 
            this.txtFCountry.Location = new System.Drawing.Point(46, 48);
            this.txtFCountry.Name = "txtFCountry";
            this.txtFCountry.Size = new System.Drawing.Size(145, 20);
            this.txtFCountry.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.Location = new System.Drawing.Point(5, 103);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 15);
            this.label14.TabIndex = 49;
            this.label14.Text = "Semt:";
            // 
            // txtFDistirct
            // 
            this.txtFDistirct.Location = new System.Drawing.Point(46, 100);
            this.txtFDistirct.Name = "txtFDistirct";
            this.txtFDistirct.Size = new System.Drawing.Size(145, 20);
            this.txtFDistirct.TabIndex = 16;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label15.Location = new System.Drawing.Point(6, 76);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 15);
            this.label15.TabIndex = 48;
            this.label15.Text = "Şehir:";
            // 
            // txtFCity
            // 
            this.txtFCity.Location = new System.Drawing.Point(46, 74);
            this.txtFCity.Name = "txtFCity";
            this.txtFCity.Size = new System.Drawing.Size(145, 20);
            this.txtFCity.TabIndex = 15;
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Firma Bilgileri";
            this.navBarGroup1.ControlContainer = this.navBarGroupControlContainer2;
            this.navBarGroup1.GroupClientHeight = 211;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup1.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup1.ImageOptions.SmallImage")));
            this.navBarGroup1.Name = "navBarGroup1";
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
            this.ribbonControl1.Size = new System.Drawing.Size(417, 140);
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
            // FrmCustomerAcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 632);
            this.Controls.Add(this.navBar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "FrmCustomerAcc";
            this.Text = "Cari Hesapları";
            this.Load += new System.EventHandler(this.FrmCustomerAcc_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).EndInit();
            this.navBar.ResumeLayout(false);
            this.navBarGroupControlContainer1.ResumeLayout(false);
            this.navBarGroupControlContainer1.PerformLayout();
            this.navBarGroupControlContainer2.ResumeLayout(false);
            this.navBarGroupControlContainer2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnEscape;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUsername;
        private Obje.Companents.AtlasTextBox txtName;
        private Obje.Companents.AtlasButtonEdit txtCode;
        private DevExpress.XtraBars.BarButtonItem btnDeleteLine;
        private DevExpress.XtraBars.BarButtonItem btnDeleteBarcode;
        private DevExpress.XtraBars.BarButtonItem btnFolderAdd;
        private DevExpress.XtraBars.BarButtonItem btnFolderDelete;
        private DevExpress.XtraBars.BarButtonItem btnFolderOpen;
        private DevExpress.XtraNavBar.NavBarControl navBar;
        private DevExpress.XtraNavBar.NavBarGroup navInfo;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer1;
        private System.Windows.Forms.Label label20;
        private Obje.Companents.AtlasLookUp ledType;
        private System.Windows.Forms.Label label4;
        private Obje.Companents.AtlasTextBox txtCountry;
        private System.Windows.Forms.Label label3;
        private Obje.Companents.AtlasTextBox txtDistirct;
        private System.Windows.Forms.Label label2;
        private Obje.Companents.AtlasTextBox txtCity;
        private Obje.Companents.AtlasMemoEdit txtAdress;
        private System.Windows.Forms.Label label8;
        private Obje.Companents.AtlasTextBox txtMail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Obje.Companents.FlashTextBoxGsm txtTel;
        private System.Windows.Forms.Label label5;
        private Obje.Companents.FlashTextBoxGsm txtGsm;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer2;
        private System.Windows.Forms.Label label17;
        private Obje.Companents.AtlasTextBox txtVNo;
        private System.Windows.Forms.Label label16;
        private Obje.Companents.AtlasTextBox txtVD;
        private Obje.Companents.AtlasCheckEdit chkPerson;
        private Obje.Companents.AtlasMemoEdit txtFAdress;
        private System.Windows.Forms.Label label9;
        private Obje.Companents.AtlasTextBox txtFMail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private Obje.Companents.FlashTextBoxGsm txtFTel;
        private System.Windows.Forms.Label label12;
        private Obje.Companents.FlashTextBoxGsm txtFGsm;
        private System.Windows.Forms.Label label13;
        private Obje.Companents.AtlasTextBox txtFCountry;
        private System.Windows.Forms.Label label14;
        private Obje.Companents.AtlasTextBox txtFDistirct;
        private System.Windows.Forms.Label label15;
        private Obje.Companents.AtlasTextBox txtFCity;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private Obje.Companents.AtlasCheckEdit flashCheckEdit1;
        private Obje.Companents.AtlasCheckEdit chkActive;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
    }
}