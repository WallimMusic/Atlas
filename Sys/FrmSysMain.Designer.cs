namespace Sys
{
    partial class FrmSysMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSysMain));
            this.bbiBankWhouse = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReport = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDocument = new DevExpress.XtraBars.BarButtonItem();
            this.bsiUsername = new DevExpress.XtraBars.BarStaticItem();
            this.lblUsername = new DevExpress.XtraBars.BarStaticItem();
            this.bsiDatabase = new DevExpress.XtraBars.BarStaticItem();
            this.lblDatabase = new DevExpress.XtraBars.BarStaticItem();
            this.bsiTarih = new DevExpress.XtraBars.BarStaticItem();
            this.lblDate = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.lblClock = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bbiServerConnections = new DevExpress.XtraBars.BarButtonItem();
            this.bbieMailDefinations = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSmsDefinations = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bbiDatabaseDefinations = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCompanyDefinations = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBranchDefinations = new DevExpress.XtraBars.BarButtonItem();
            this.bbiwHouseDefinations = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bbiUserAccounts = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUserGroups = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUserRoles = new DevExpress.XtraBars.BarButtonItem();
            this.bbiMenus = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAuths = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bbiCurrency = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTaxs = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUnits = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCustom = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAdress = new DevExpress.XtraBars.BarSubItem();
            this.biCountry = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCity = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBank = new DevExpress.XtraBars.BarSubItem();
            this.bbiBanks = new DevExpress.XtraBars.BarButtonItem();
            this.btnAuthorityPackage = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SuspendLayout();
            // 
            // bbiBankWhouse
            // 
            this.bbiBankWhouse.Caption = "Şubeler";
            this.bbiBankWhouse.Id = 26;
            this.bbiBankWhouse.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiBankWhouse.ImageOptions.Image")));
            this.bbiBankWhouse.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiBankWhouse.ImageOptions.LargeImage")));
            this.bbiBankWhouse.Name = "bbiBankWhouse";
            this.bbiBankWhouse.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiBankWhouse_ItemClick);
            // 
            // bbiReport
            // 
            this.bbiReport.Caption = "Rapor Tanımları";
            this.bbiReport.Id = 21;
            this.bbiReport.Name = "bbiReport";
            this.bbiReport.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing;
            // 
            // bbiDocument
            // 
            this.bbiDocument.Caption = "Döküman Tanımları";
            this.bbiDocument.Id = 22;
            this.bbiDocument.Name = "bbiDocument";
            this.bbiDocument.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing;
            // 
            // bsiUsername
            // 
            this.bsiUsername.Caption = "Kullanıcı Adı:";
            this.bsiUsername.Id = 29;
            this.bsiUsername.Name = "bsiUsername";
            // 
            // lblUsername
            // 
            this.lblUsername.Caption = "...";
            this.lblUsername.Id = 30;
            this.lblUsername.Name = "lblUsername";
            // 
            // bsiDatabase
            // 
            this.bsiDatabase.Caption = "Veritabanı:";
            this.bsiDatabase.Id = 31;
            this.bsiDatabase.Name = "bsiDatabase";
            // 
            // lblDatabase
            // 
            this.lblDatabase.Caption = "...";
            this.lblDatabase.Id = 32;
            this.lblDatabase.Name = "lblDatabase";
            // 
            // bsiTarih
            // 
            this.bsiTarih.Caption = "Tarih:";
            this.bsiTarih.Id = 33;
            this.bsiTarih.Name = "bsiTarih";
            // 
            // lblDate
            // 
            this.lblDate.Caption = "...";
            this.lblDate.Id = 34;
            this.lblDate.Name = "lblDate";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "Saat:";
            this.barStaticItem1.Id = 35;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // lblClock
            // 
            this.lblClock.Caption = "...";
            this.lblClock.Id = 36;
            this.lblClock.Name = "lblClock";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Tanımlamalar";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiServerConnections);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbieMailDefinations);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiSmsDefinations);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Sunucu ve Bağlantı Ayarları";
            // 
            // bbiServerConnections
            // 
            this.bbiServerConnections.Caption = "Sunucu Bağlantıları";
            this.bbiServerConnections.Id = 2;
            this.bbiServerConnections.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiServerConnections.ImageOptions.Image")));
            this.bbiServerConnections.Name = "bbiServerConnections";
            this.bbiServerConnections.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            this.bbiServerConnections.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiServerConnections_ItemClick);
            // 
            // bbieMailDefinations
            // 
            this.bbieMailDefinations.Caption = "e-Posta Sunucu Tanımları";
            this.bbieMailDefinations.Id = 3;
            this.bbieMailDefinations.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbieMailDefinations.ImageOptions.Image")));
            this.bbieMailDefinations.Name = "bbieMailDefinations";
            this.bbieMailDefinations.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.bbieMailDefinations.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing;
            // 
            // bbiSmsDefinations
            // 
            this.bbiSmsDefinations.Caption = "Sms Sunucu Bağlantıları";
            this.bbiSmsDefinations.Id = 4;
            this.bbiSmsDefinations.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiSmsDefinations.ImageOptions.Image")));
            this.bbiSmsDefinations.Name = "bbiSmsDefinations";
            this.bbiSmsDefinations.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.bbiSmsDefinations.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiDatabaseDefinations);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiCompanyDefinations);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiBranchDefinations);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiwHouseDefinations);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "Firma Tanımları";
            // 
            // bbiDatabaseDefinations
            // 
            this.bbiDatabaseDefinations.Caption = "Veritabanı Tanımları";
            this.bbiDatabaseDefinations.Id = 8;
            this.bbiDatabaseDefinations.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiDatabaseDefinations.ImageOptions.Image")));
            this.bbiDatabaseDefinations.Name = "bbiDatabaseDefinations";
            this.bbiDatabaseDefinations.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiDatabaseDefinations.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDatabaseDefinations_ItemClick);
            // 
            // bbiCompanyDefinations
            // 
            this.bbiCompanyDefinations.Caption = "Firma Tanımları";
            this.bbiCompanyDefinations.Id = 5;
            this.bbiCompanyDefinations.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiCompanyDefinations.ImageOptions.Image")));
            this.bbiCompanyDefinations.Name = "bbiCompanyDefinations";
            this.bbiCompanyDefinations.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiCompanyDefinations.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCompanyDefinations_ItemClick);
            // 
            // bbiBranchDefinations
            // 
            this.bbiBranchDefinations.Caption = "Şube Tanımları";
            this.bbiBranchDefinations.Id = 6;
            this.bbiBranchDefinations.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiBranchDefinations.ImageOptions.Image")));
            this.bbiBranchDefinations.Name = "bbiBranchDefinations";
            this.bbiBranchDefinations.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiBranchDefinations.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiBranchDefinations_ItemClick);
            // 
            // bbiwHouseDefinations
            // 
            this.bbiwHouseDefinations.Caption = "Depo Tanımları";
            this.bbiwHouseDefinations.Id = 7;
            this.bbiwHouseDefinations.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiwHouseDefinations.ImageOptions.Image")));
            this.bbiwHouseDefinations.Name = "bbiwHouseDefinations";
            this.bbiwHouseDefinations.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiwHouseDefinations.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiwHouseDefinations_ItemClick);
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiUserAccounts);
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiUserGroups);
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiUserRoles);
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiMenus);
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiAuths);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Text = "Kullanıcı Tanımları";
            // 
            // bbiUserAccounts
            // 
            this.bbiUserAccounts.Caption = "Kullanıcı Hesapları";
            this.bbiUserAccounts.Id = 9;
            this.bbiUserAccounts.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiUserAccounts.ImageOptions.Image")));
            this.bbiUserAccounts.Name = "bbiUserAccounts";
            this.bbiUserAccounts.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiUserAccounts.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiUserAccounts_ItemClick);
            // 
            // bbiUserGroups
            // 
            this.bbiUserGroups.Caption = "Kullanıcı Grupları";
            this.bbiUserGroups.Id = 10;
            this.bbiUserGroups.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiUserGroups.ImageOptions.Image")));
            this.bbiUserGroups.Name = "bbiUserGroups";
            this.bbiUserGroups.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiUserGroups.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiUserGroups_ItemClick);
            // 
            // bbiUserRoles
            // 
            this.bbiUserRoles.Caption = "Rol Tanımları";
            this.bbiUserRoles.Id = 11;
            this.bbiUserRoles.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiUserRoles.ImageOptions.Image")));
            this.bbiUserRoles.Name = "bbiUserRoles";
            this.bbiUserRoles.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiUserRoles.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiUserRoles_ItemClick);
            // 
            // bbiMenus
            // 
            this.bbiMenus.Caption = "Menü Tanımları";
            this.bbiMenus.Id = 12;
            this.bbiMenus.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiMenus.ImageOptions.Image")));
            this.bbiMenus.Name = "bbiMenus";
            this.bbiMenus.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing;
            // 
            // bbiAuths
            // 
            this.bbiAuths.Caption = "Yetki Tanımları";
            this.bbiAuths.Id = 13;
            this.bbiAuths.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiAuths.ImageOptions.Image")));
            this.bbiAuths.Name = "bbiAuths";
            this.bbiAuths.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAuths_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Yetki Paketleri";
            this.barButtonItem1.Id = 38;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.AllowTextClipping = false;
            this.ribbonPageGroup4.ItemLinks.Add(this.bbiCurrency);
            this.ribbonPageGroup4.ItemLinks.Add(this.bbiTaxs);
            this.ribbonPageGroup4.ItemLinks.Add(this.bbiUnits);
            this.ribbonPageGroup4.ItemLinks.Add(this.bbiCustom);
            this.ribbonPageGroup4.ItemLinks.Add(this.bbiAdress);
            this.ribbonPageGroup4.ItemLinks.Add(this.bbiBank);
            this.ribbonPageGroup4.ItemLinks.Add(this.bbiReport);
            this.ribbonPageGroup4.ItemLinks.Add(this.bbiDocument);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            this.ribbonPageGroup4.Text = "Sabit Tanımlar";
            // 
            // bbiCurrency
            // 
            this.bbiCurrency.Caption = "Döviz Bilgileri";
            this.bbiCurrency.Id = 14;
            this.bbiCurrency.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiCurrency.ImageOptions.Image")));
            this.bbiCurrency.Name = "bbiCurrency";
            this.bbiCurrency.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCurrency_ItemClick);
            // 
            // bbiTaxs
            // 
            this.bbiTaxs.Caption = "Vergi Daireleri";
            this.bbiTaxs.Id = 15;
            this.bbiTaxs.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiTaxs.ImageOptions.Image")));
            this.bbiTaxs.Name = "bbiTaxs";
            this.bbiTaxs.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiTaxs_ItemClick);
            // 
            // bbiUnits
            // 
            this.bbiUnits.Caption = "Birimler";
            this.bbiUnits.Id = 16;
            this.bbiUnits.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiUnits.ImageOptions.Image")));
            this.bbiUnits.Name = "bbiUnits";
            this.bbiUnits.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiUnits_ItemClick);
            // 
            // bbiCustom
            // 
            this.bbiCustom.Caption = "Özellik Tanımları";
            this.bbiCustom.Id = 18;
            this.bbiCustom.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiCustom.ImageOptions.Image")));
            this.bbiCustom.Name = "bbiCustom";
            this.bbiCustom.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing;
            // 
            // bbiAdress
            // 
            this.bbiAdress.Caption = "Adres Tanımları";
            this.bbiAdress.Id = 19;
            this.bbiAdress.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiAdress.ImageOptions.Image")));
            this.bbiAdress.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biCountry),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiCity)});
            this.bbiAdress.Name = "bbiAdress";
            // 
            // biCountry
            // 
            this.biCountry.Caption = "Ülkeler";
            this.biCountry.Id = 23;
            this.biCountry.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("biCountry.ImageOptions.Image")));
            this.biCountry.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("biCountry.ImageOptions.LargeImage")));
            this.biCountry.Name = "biCountry";
            this.biCountry.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biCountry_ItemClick);
            // 
            // bbiCity
            // 
            this.bbiCity.Caption = "Şehirler";
            this.bbiCity.Id = 24;
            this.bbiCity.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiCity.ImageOptions.Image")));
            this.bbiCity.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiCity.ImageOptions.LargeImage")));
            this.bbiCity.Name = "bbiCity";
            this.bbiCity.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCity_ItemClick);
            // 
            // bbiBank
            // 
            this.bbiBank.Caption = "Banka Tanımları";
            this.bbiBank.Id = 20;
            this.bbiBank.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiBank.ImageOptions.Image")));
            this.bbiBank.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiBanks),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiBankWhouse)});
            this.bbiBank.Name = "bbiBank";
            // 
            // bbiBanks
            // 
            this.bbiBanks.Caption = "Bankalar";
            this.bbiBanks.Id = 25;
            this.bbiBanks.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiBanks.ImageOptions.Image")));
            this.bbiBanks.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiBanks.ImageOptions.LargeImage")));
            this.bbiBanks.Name = "bbiBanks";
            this.bbiBanks.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiBanks_ItemClick);
            // 
            // btnAuthorityPackage
            // 
            this.btnAuthorityPackage.Caption = "Yetki Paketleri";
            this.btnAuthorityPackage.Id = 37;
            this.btnAuthorityPackage.Name = "btnAuthorityPackage";
            this.btnAuthorityPackage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAuthorityPackage_ItemClick);
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiUsername);
            this.ribbonStatusBar.ItemLinks.Add(this.lblUsername);
            this.ribbonStatusBar.ItemLinks.Add(this.bsiDatabase);
            this.ribbonStatusBar.ItemLinks.Add(this.lblDatabase);
            this.ribbonStatusBar.ItemLinks.Add(this.bsiTarih);
            this.ribbonStatusBar.ItemLinks.Add(this.lblDate);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItem1);
            this.ribbonStatusBar.ItemLinks.Add(this.lblClock);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 618);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1186, 21);
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bbiServerConnections,
            this.bbieMailDefinations,
            this.bbiSmsDefinations,
            this.bbiCompanyDefinations,
            this.bbiBranchDefinations,
            this.bbiwHouseDefinations,
            this.bbiDatabaseDefinations,
            this.bbiUserAccounts,
            this.bbiUserGroups,
            this.bbiUserRoles,
            this.bbiMenus,
            this.bbiAuths,
            this.bbiCurrency,
            this.bbiTaxs,
            this.bbiUnits,
            this.bbiCustom,
            this.bbiAdress,
            this.bbiBank,
            this.bbiReport,
            this.bbiDocument,
            this.biCountry,
            this.bbiCity,
            this.bbiBanks,
            this.bbiBankWhouse,
            this.bsiUsername,
            this.lblUsername,
            this.bsiDatabase,
            this.lblDatabase,
            this.bsiTarih,
            this.lblDate,
            this.barStaticItem1,
            this.lblClock,
            this.btnAuthorityPackage,
            this.barButtonItem1});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 39;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2007;
            this.ribbon.Size = new System.Drawing.Size(1186, 146);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Above;
            // 
            // tmrClock
            // 
            this.tmrClock.Enabled = true;
            this.tmrClock.Interval = 1000;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2016 Colorful";
            // 
            // FrmSysMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 639);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "FrmSysMain";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Flash SYS";
            this.Load += new System.EventHandler(this.FrmSysMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.BarButtonItem bbiBankWhouse;
        private DevExpress.XtraBars.BarButtonItem bbiReport;
        private DevExpress.XtraBars.BarButtonItem bbiDocument;
        private DevExpress.XtraBars.BarStaticItem bsiUsername;
        private DevExpress.XtraBars.BarStaticItem lblUsername;
        private DevExpress.XtraBars.BarStaticItem bsiDatabase;
        private DevExpress.XtraBars.BarStaticItem lblDatabase;
        private DevExpress.XtraBars.BarStaticItem bsiTarih;
        private DevExpress.XtraBars.BarStaticItem lblDate;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem lblClock;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bbiServerConnections;
        private DevExpress.XtraBars.BarButtonItem bbieMailDefinations;
        private DevExpress.XtraBars.BarButtonItem bbiSmsDefinations;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem bbiDatabaseDefinations;
        private DevExpress.XtraBars.BarButtonItem bbiCompanyDefinations;
        private DevExpress.XtraBars.BarButtonItem bbiBranchDefinations;
        private DevExpress.XtraBars.BarButtonItem bbiwHouseDefinations;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem bbiUserAccounts;
        private DevExpress.XtraBars.BarButtonItem bbiUserGroups;
        private DevExpress.XtraBars.BarButtonItem bbiUserRoles;
        private DevExpress.XtraBars.BarButtonItem bbiMenus;
        private DevExpress.XtraBars.BarButtonItem bbiAuths;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem bbiCurrency;
        private DevExpress.XtraBars.BarButtonItem bbiTaxs;
        private DevExpress.XtraBars.BarButtonItem bbiUnits;
        private DevExpress.XtraBars.BarButtonItem bbiCustom;
        private DevExpress.XtraBars.BarSubItem bbiAdress;
        private DevExpress.XtraBars.BarButtonItem biCountry;
        private DevExpress.XtraBars.BarButtonItem bbiCity;
        private DevExpress.XtraBars.BarSubItem bbiBank;
        private DevExpress.XtraBars.BarButtonItem bbiBanks;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private System.Windows.Forms.Timer tmrClock;
        private System.ComponentModel.IContainer components;
        private DevExpress.XtraBars.BarButtonItem btnAuthorityPackage;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
    }
}