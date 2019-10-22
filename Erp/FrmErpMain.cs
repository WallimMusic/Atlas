using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using Obje.Classes;
using Obje.Companents;
using DevExpress.Office.Utils;
using DevExpress.XtraTreeList.Nodes;


namespace Erp
{
    public partial class FrmErpMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmErpMain()
        {
            InitializeComponent();
        }

        #region Methods

        ErpManager db = new ErpManager();
        AccessManager sysDb = new AccessManager();
        public int userRef, firmRef, authRef;

        public void Viewchild(AtlasForm _form)
        {
            //Check Before Open
            if (!IsFormActive(_form))
            {
                _form.MdiParent = FrmErpMain.ActiveForm;
                _form.Show();
            }
        }
        private bool IsFormActive(AtlasForm form)
        {
            bool IsOpened = false;
            //If There Is More Than One Form Opened
            if (MdiChildren.Count() > 0)
            {
                foreach (var item in MdiChildren)
                {
                    if (form.Text == item.Text)
                    {
                        item.Close();
                        IsOpened = false;
                    }
                }
            }
            return IsOpened;
        }

        void FormFill(string sql, string listname, AtlasForm Form)
        {

            frmList List = new frmList();
            List._ConnStr = Properties.Settings.Default.connStr;
            List._Sql = sql;
            List._FormText = listname;
            List.Text = listname + " Kayıt Listesi";
            List.newForm = new AtlasForm();
            List.newForm = Form;

            Viewchild(List);
        }
        void AuthControl(string desc, AtlasForm form)
        {
            sysDb.parameterDelete();
            sysDb.AddParameterValue("@desc", desc);
            sysDb.AddParameterValue("@authRef", authRef);
            DataTable dtAuth = sysDb.GetDataSet(@"SELECT         SysAuths.Ref AS authRef,sysMenu.code, sysMenu.description, sysAuthDetails.authSee, sysAuthDetails.authAdd, sysAuthDetails.authUpdate, sysAuthDetails.authShow FROM            SysAuths 
INNER JOIN sysAuthDetails ON SysAuths.Ref = sysAuthDetails.authRef 
INNER JOIN sysMenu ON sysAuthDetails.menuRef = sysMenu.Ref 
where description=@desc 
and authRef=@authRef").Tables[0];
            form._add = bool.Parse(dtAuth.Rows[0]["authAdd"].ToString());
            form._update = bool.Parse(dtAuth.Rows[0]["authUpdate"].ToString());
            form._show = bool.Parse(dtAuth.Rows[0]["authShow"].ToString());

        }

        public Dictionary<int, string> lstWhouse = new Dictionary<int, string>();
        public Dictionary<int, string> lstBranch = new Dictionary<int, string>();


        public DataTable dtBranch = new DataTable();
        public DataTable dtWhouse = new DataTable();
        public DataTable dtAuth = new DataTable();

        #endregion

        #region Stock Tree List
        private void treeList1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeListHitInfo hi = treeStock.CalcHitInfo(e.Location);
            if (hi.HitInfoType == DevExpress.XtraTreeList.HitInfoType.Cell)
            {

                // TreeList'ten marka seçildiğnide yapılacak işlemler.
                if (hi.Node[cololaylar].ToString() == "Marka")
                {
                    Stock.FrmBrand cou = new Stock.FrmBrand();
                    AuthControl("Marka", cou);
                    Viewchild(cou);
                }
                else if (hi.Node[cololaylar].ToString() == "Stok Kartı")
                {
                    Stock.FrmStockList list = new Stock.FrmStockList();
                    AuthControl("Stok Kartı", list);
                    Viewchild(list);
                }
                else if (hi.Node[cololaylar].ToString() == "Model")
                {
                    Stock.FrmModel cou = new Stock.FrmModel();
                    AuthControl("Model", cou);
                    Viewchild(cou);
                }
                else if (hi.Node[cololaylar].ToString() == "Sezon")
                {
                    Stock.FrmSeason cou = new Stock.FrmSeason();
                    AuthControl("Sezon", cou);
                    Viewchild(cou);
                }
                else if (hi.Node[cololaylar].ToString() == "Üretici Firma")
                {
                    Stock.FrmProducer cou = new Stock.FrmProducer();
                    AuthControl("Üretici Firma", cou);
                    Viewchild(cou);
                }
                else if (hi.Node[cololaylar].ToString() == "Ürün Grubu")
                {
                    Stock.FrmGroup cou = new Stock.FrmGroup();
                    AuthControl("Ürün Grubu", cou);
                    Viewchild(cou);
                }
                else if (hi.Node[cololaylar].ToString() == "Beden Kartelası")
                {
                    Stock.FrmSize db = new Stock.FrmSize();
                    FormFill(@"Select Ref,code as [Kod],name as [Adı] from StStockCardSize", "Beden Kartelası", db);
                }
                else if (hi.Node[cololaylar].ToString() == "Renk Kartelası")
                {
                    Stock.FrmColor db = new Stock.FrmColor();
                    FormFill(@"Select Ref,code as [Kod],name as [Adı] from StStockCardColor", "Renk Kartelası", db);
                }
                else if (hi.Node[cololaylar].ToString() == "Açılış Fişi")
                {
                    Stock.FrmOperation db = new Stock.FrmOperation();
                    db._FormNo = "10.02.101";
                    FormFill(@"SELECT        StPlug.Ref, plugSerial as [Fiş Seri], plugNo as [Fiş No],  plugDate as [Fiş Tarihi], sysBranch.name as [Şube], sysWhouse.name as [Depo],plugDesc as [Açıklama]
FROM            StPlug 
LEFT OUTER JOIN AtlasSys.dbo.sysBranch ON StPlug.branchRef = sysBranch.Ref
LEFT OUTER JOIN AtlasSys.dbo.sysWhouse ON StPlug.WhouseRef = sysWhouse.Ref
where plugType = 100", "Açılış Fişi", db);
                }
                else if (hi.Node[cololaylar].ToString() == "Sayım Fişi")
                {

                    Stock.FrmOperation db = new Stock.FrmOperation();
                    db._FormNo = "10.02.102";
                    FormFill(@"SELECT        StPlug.Ref, plugSerial as [Fiş Seri], plugNo as [Fiş No],  plugDate as [Fiş Tarihi], sysBranch.name as [Şube], sysWhouse.name as [Depo],plugDesc as [Açıklama]
FROM            StPlug 
LEFT OUTER JOIN AtlasSys.dbo.sysBranch ON StPlug.branchRef = sysBranch.Ref
LEFT OUTER JOIN AtlasSys.dbo.sysWhouse ON StPlug.WhouseRef = sysWhouse.Ref
where plugType = 101", "Sayım Fişi", db);
                }
                else if (hi.Node[cololaylar].ToString() == "Barkod Yazdırma")
                {

                    Stock.FrmPrintBarcode barcode = new Stock.FrmPrintBarcode();
                    AuthControl("Barkod Yazdır", barcode);
                    Viewchild(barcode);
                }
                else if (hi.Node[cololaylar].ToString() == "Toplu Stok Aktarma")
                {
                    Stock.FrmImportStock stock = new Stock.FrmImportStock();
                    AuthControl("Toplu Stok Aktarma", stock);
                    Viewchild(stock);
                }

            }


        }
        #endregion

        #region Sell Tree List
        private void treeSell_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeListHitInfo hi = treeSell.CalcHitInfo(e.Location);
            if (hi.HitInfoType == DevExpress.XtraTreeList.HitInfoType.Cell)
            {
                // TreeList'ten marka seçildiğnide yapılacak işlemler.
                if (hi.Node[cololaylar].ToString() == "Müşteri Cari Hesapları")
                {
                    Sell.FrmCurrentList list = new Sell.FrmCurrentList();
                    list.MdiParent = this;
                    list.Show();

                }
                else if (hi.Node[cololaylar].ToString() == "Satış Fiyat Listeleri")
                {

                    Sell.FrmSellPrices list = new Sell.FrmSellPrices();
                    FormFill(@"SELECT        PL.Ref as Ref, PL.code AS [Liste Kodu], PL.name AS [Liste Adı]
                    FROM            StSellPriceList PL with(nolock)
                    WHERE PL.active = 1 /*AND  @date between PL.startDate and PL.finishDate*/
                    ", "Satış Fiyatları", list);

                }
                else if (hi.Node[cololaylar].ToString() == "Satış Kampanyaları")
                {

                    Sell.FrmCampaings list = new Sell.FrmCampaings();
                    FormFill(@"SELECT        PL.Ref as Ref, PL.code AS [Liste Kodu], PL.name AS [Liste Adı]
                    FROM            StSellCampaing PL with(nolock)         
                    WHERE PL.active = 1/* AND  {0} between PL.startDate and PL.finishDate*/
                    ", "Satış Kampanyaları", list);

                }

                else if (hi.Node[cololaylar].ToString() == "İndirimler")
                {

                    Sell.FrmDiscount list = new Sell.FrmDiscount();
                    db.AddParameterValue("@date", DateTime.Now.ToShortDateString(), SqlDbType.Date);
                    FormFill(@"SELECT        PL.Ref as Ref, PL.code AS [Liste Kodu], PL.name AS [Liste Adı]
                    FROM            StSellDiscount PL with(nolock)         
                    WHERE PL.active = 1 /*AND  GETDATE() between PL.startDate and PL.finishDate*/
                    ", "İndirimler", list);

                }
                else if (hi.Node[cololaylar].ToString() == "Satış Siparişleri")
                {
                    Sell.FrmSellOrder list = new Sell.FrmSellOrder();
                    db.AddParameterValue("@date", DateTime.Now.ToShortDateString(), SqlDbType.Date);
                    FormFill(@"					SELECT SO.Ref,SO.Code as Kod,SO.name as [Adı],SO.date as [Tarih],SW.name as Şube,SB.name as Depo,
                    CA.name as Müşteri, SO.totalPrice as [Toplam Tutar]
                    FROM StSellOrder as SO
                    INNER JOIN StCustomerAccount as CA ON SO.customerRef = CA.Ref
                    INNER JOIN AtlasSys.dbo.sysWhouse as SW on SO.WhouseRef = SW.Ref
                    INNER JOIN AtlasSys.dbo.sysBranch as SB ON SO.BranchRef = SB.Ref ", "Satış Siparişleri", list);
                }

            }
        }
        #endregion

        #region Settings Tree List
        private void TreeSettings_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeListHitInfo hi = treeSettings.CalcHitInfo(e.Location);
            if (hi.HitInfoType == DevExpress.XtraTreeList.HitInfoType.Cell)
            {
                // TreeList'ten marka seçildiğnide yapılacak işlemler.
                if (hi.Node[colSettings].ToString() == "Stok Sınfları")
                {
                    Settings.FrmStockClass code = new Settings.FrmStockClass();
                    Viewchild(code);
                }
            }
        }

        private void bbiStockCardOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Stock.FrmStokCard card = new Stock.FrmStokCard();
            card.ShowDialog();
        }
        #endregion

        #region Buy Tree List


        private void treeBuy_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeListHitInfo hi = treeBuy.CalcHitInfo(e.Location);
            if (hi.HitInfoType == DevExpress.XtraTreeList.HitInfoType.Cell)
            {
                if (hi.Node[cololaylar].ToString() == "Tedarikçi Cari Hesapları")
                {
                    Sell.FrmCurrentList list = new Sell.FrmCurrentList();
                    list.MdiParent = this;
                    list.Show();
                }

                else if (hi.Node[cololaylar].ToString() == "Satınalma Fiyat Listeleri")
                {
                    Buy.FrmBuyList list = new Buy.FrmBuyList();
                    db.AddParameterValue("@date", DateTime.Now.ToShortDateString(), SqlDbType.Date);
                    FormFill(@"SELECT        PL.Ref as Ref, PL.code AS [Liste Kodu], PL.name AS [Liste Adı]
                    FROM            StBuyPriceList PL with(nolock)
                    WHERE PL.active = 1 /*AND  @date between PL.startDate and PL.finishDate*/
                    ", "Alış Fiyatları", list);
                }

                else if (hi.Node[cololaylar].ToString() == "Satınalma Siparişi")
                {
                    Buy.FrmBuyOrder order = new Buy.FrmBuyOrder();
                    FormFill(@"SELECT        BO.Ref as Ref, BO.code AS [Sipariş Kodu], BO.name AS [Sipariş Adı], BO.Date AS [Sipariş Tarihi], BR.name as [Şube], WH.name as [Depo]
FROM            StBuyOrder BO with(nolock) 
INNER JOIN AtlasSys.dbo.sysBranch BR ON BR.Ref = BO.branchRef
INNER JOIN AtlasSys.dbo.sysWhouse WH ON WH.Ref = BO.whouseRef
WHERE        (BO.state = 1) ", "Satınalma Siparişleri", order);
                }
                else if (hi.Node[cololaylar].ToString() == "Toplu Alım Siparişi Kapatma")
                {
                    Buy.FrmOrderList orderList = new Buy.FrmOrderList();
                    orderList.MdiParent = this;
                    orderList.Show();
                }
                else if (hi.Node[cololaylar].ToString() == "Alım İade Faturası")
                {
                    Buy.FrmBuyReturn Ret = new Buy.FrmBuyReturn();
                    FormFill(@"", "Alım İade Faturası", Ret);
                }


            }
        }

        #endregion

        #region Load
        private void FrmErpMain_Load(object sender, EventArgs e)
        {
            FrmLogin Log = new FrmLogin();
            this.Opacity = 0;
            Log.ShowDialog();
            if (Log.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                this.Opacity = 100;

                //yetki işlemleri
                #region Auth operations 


                // şubeleri doldurma.
                sysDb.AddParameterValue("@ref", userRef);
                dtBranch = sysDb.GetDataSet("select branchRef from sysAuthUserBranch where userRef=@ref").Tables[0];
                for (int i = 0; i < dtBranch.Rows.Count; i++)
                {
                    int branchRef = int.Parse(dtBranch.Rows[i][0].ToString());
                    sysDb.AddParameterValue("@ref", branchRef);
                    sysDb.AddParameterValue("@firmRef", firmRef);
                    string branchName = sysDb.GetScalarValue("select name from sysBranch where ref=@ref and firmRef=@firmRef").ToString();
                    lstBranch.Add(branchRef, branchName);
                }


                // depoaları doldurma.
                sysDb.AddParameterValue("@ref", userRef);
                dtWhouse = sysDb.GetDataSet("select whouseRef from sysAuthUserWhouse where userRef=@ref").Tables[0];
                for (int i = 0; i < dtWhouse.Rows.Count; i++)
                {
                    int whouseRef = int.Parse(dtWhouse.Rows[i][0].ToString());
                    sysDb.AddParameterValue("@ref", whouseRef);
                    sysDb.AddParameterValue("@branchRef", firmRef);
                    string whouseName = sysDb.GetScalarValue("select name from sysWhouse where ref=@ref").ToString();
                    lstWhouse.Add(whouseRef, whouseName);
                }



                #region Auths
                //// yetkiler
                sysDb.AddParameterValue("@firmRef", firmRef);
                sysDb.AddParameterValue("@userRef", userRef);
                authRef = int.Parse(sysDb.GetScalarValue("select authRef from sysAuthUser where firmRef=@firmRef and userRef=@userRef").ToString());

                sysDb.AddParameterValue("@ref", authRef);
                dtAuth = sysDb.GetDataSet(@"SELECT         SysAuths.Ref AS authRef,sysMenu.code, sysMenu.description, sysAuthDetails.authSee, sysAuthDetails.authAdd, sysAuthDetails.authUpdate, sysAuthDetails.authShow
                        FROM            SysAuths INNER JOIN
                         sysAuthDetails ON SysAuths.Ref = sysAuthDetails.authRef INNER JOIN
                         sysMenu ON sysAuthDetails.menuRef = sysMenu.Ref where SysAuths.Ref = @ref").Tables[0];

                for (int g = 0; g < dtAuth.Rows.Count; g++)
                {
                    if (dtAuth.Rows[g]["code"].ToString() == "10")
                    {
                        for (int i = 0; i < treeStock.Nodes.Count; i++)
                        {
                            for (int a = 0; a < treeStock.Nodes[i].Nodes.Count; a++)
                            {
                                string focusedNode = treeStock.Nodes[i].Nodes[a].GetDisplayText(cololaylar).ToString();
                                string listNde = dtAuth.Rows[g]["description"].ToString();

                                if (focusedNode == listNde)
                                {
                                    treeStock.Nodes[i].Nodes[a].Visible = bool.Parse(dtAuth.Rows[g]["authSee"].ToString());
                                }
                            }
                        }
                    }
                }
                #endregion

                #endregion
            }

        }
        #endregion





    }
}