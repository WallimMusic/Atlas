using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Obje.Classes;
using Obje.Companents;
using Sys;
using SYS;
namespace Sys
{
    public partial class FrmSysMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmSysMain()
        {
            InitializeComponent();
        }

        #region Tanımlar ve metodlar

        public string username, database;



        void FormFill(string sql, string listname/*string FormNo*/, AtlasForm Form)
        {
            this.IsMdiContainer = true;
            frmList List = new frmList();
            List._ConnStr = "";
            List._Sql = sql;
            List._FormText = listname + " Kayıt Listesi";
            List.newForm = new AtlasForm();
            List.newForm = Form;
            List.MdiParent = FrmSysMain.ActiveForm;
            List.Show();
        }
        #endregion

        private void FrmSysMain_Load(object sender, EventArgs e)
        {
            //FrmLogin Log = new FrmLogin();
            //this.Opacity = 0;
            //Log.ShowDialog();
            //if (Log.DialogResult == System.Windows.Forms.DialogResult.OK)
            //{
            //    this.Opacity = 100;
            //    lblUsername.Caption = username;
            //    lblDatabase.Caption = database;
            //}
        }

        private void bbiDatabaseDefinations_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmDatabase db = new FrmDatabase();
            FormFill("select Ref,dbNo as [Veritabanı Numarası],name as [Veritabanı Adı] from sysDatabase", "Veritabanları", db);
        }

        private void bbiCompanyDefinations_ItemClick(object sender, ItemClickEventArgs e)
        {

            FrmFirm db = new FrmFirm();
            FormFill("SELECT        Ref, no AS [Firma No], code AS [Firma Kodu], name AS [Firma Adı] FROM            sysFirm	WHERE        (active = 1)", "Firma", db);
        }

        private void bbiBranchDefinations_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmBranch db = new FrmBranch();
            FormFill(@"SELECT        sysBranch.Ref, sysFirm.name AS [Firma Adı], sysBranch.no AS [Şube No], sysBranch.code AS [Şube Kodu], sysBranch.name AS [Şube Adı], sysCountry.name AS Ülke, sysCity.name AS Şehir
            FROM            sysBranch INNER JOIN
                         sysFirm ON sysBranch.firmRef = sysFirm.Ref INNER JOIN
                         sysCity ON sysBranch.cityRef = sysCity.Ref INNER JOIN
                         sysCountry ON sysCity.countryRef = sysCountry.Ref
            WHERE        (sysBranch.active = 1) AND (sysFirm.active = 1)", "Şube", db);
        }

        private void bbiwHouseDefinations_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmWhouse db = new FrmWhouse();
            FormFill(@"select WH.Ref, WH.no as [Depo No], WH.code as [Depo Kodu], WH.name as [Depo Adı], FM.name as [Firma Adı], WH.name as [Şube Adı] from sysWhouse WH
            INNER JOIN sysFirm FM ON Fm.Ref = WH.firmRef
            INNER JOIN sysBranch BR ON BR.Ref = WH.branchRef",
            "Depo", db);
        }

        private void bbiCurrency_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCurrency cou = new FrmCurrency();
            this.IsMdiContainer = true;
            cou.MdiParent = this;
            cou.Show();
        }

        private void bbiCity_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCitys cou = new FrmCitys();
            this.IsMdiContainer = true;
            cou.MdiParent = this;
            cou.Show();
        }

        private void bbiTaxs_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmTax cou = new FrmTax();
            this.IsMdiContainer = true;
            cou.MdiParent = this;
            cou.Show();
        }

        private void bbiUnits_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmUnits cou = new FrmUnits();
            this.IsMdiContainer = true;
            cou.MdiParent = this;
            cou.Show();
        }

        private void bbiBanks_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmBank cou = new FrmBank();
            this.IsMdiContainer = true;
            cou.MdiParent = this;
            cou.Show();
        }

        private void bbiBankWhouse_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmBankBranch cou = new FrmBankBranch();
            this.IsMdiContainer = true;
            cou.MdiParent = this;
            cou.Show();
        }

        private void bbiUserAccounts_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmUser db = new FrmUser();
            FormFill(@"select US.Ref,Us.code as [Kullanıcı Kodu],US.nameSurname as[Kullanıcı Adı-Soyadı],RL.name as [Kullanıcı Rolü], GR.name as [Kullanıcı Grubu] from sysUser US with(nolock)
            INNER JOIN sysRole RL ON Rl.Ref = US.RoleID
            INNER JOIN sysUserGroup GR ON GR.Ref = US.GroupID
            where US.active = 1", "Kullanıcı Grupları", db);
        }

        private void bbiUserRoles_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmUserRole db = new FrmUserRole();
            FormFill(" select Ref, code as [Rol Kodu], name as [Rol Adı],description as [Açıklama]  from sysRole", "Kullanıcı Rolleri", db);
        }

        private void bbiUserGroups_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmUserGroup db = new FrmUserGroup();
            FormFill(" select Ref, code as [Grup Kodu], name as [Grup Adı],description as [Açıklama]  from sysUserGroup", "Kullanıcı Grupları", db);
        }

        private void biCountry_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCountry country = new FrmCountry();
            this.IsMdiContainer = true;
            country.MdiParent = this;
            country.Show();
        }

        private void btnAuthorityPackage_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmAuthorityDetails authorityPackage = new FrmAuthorityDetails();
            FormFill(@"SELECT        Ref, code AS Kod, name AS Ad
FROM            SysAuths
WHERE(active = 1)", "Paketler", authorityPackage);
        }

        private void bbiAuths_ItemClick(object sender, ItemClickEventArgs e)
        {
            User.FrmAuth auth = new User.FrmAuth();
            auth.ShowDialog();
        }

        private void bbiServerConnections_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmServerConnections serverConn = new FrmServerConnections();
            serverConn.ShowDialog();
        }
    }
}