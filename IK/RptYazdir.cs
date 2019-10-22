using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace IK
{
    public partial class RptYazdir : DevExpress.XtraReports.UI.XtraReport
    {
        public RptYazdir()
        {
            InitializeComponent();
        }


        public int Ref = 0;
        public int pRef = 0;
        public int oncekiRef = 0;
        void Yazdir(int pRef, int Ref)
        {

            if (oncekiRef != 0)
            {
                db.AddParameterValue("@oRef", oncekiRef);
                DataTable dtOnceki = db.GetDataTable("select * from tbPermission where Ref=@oRef");

                lblOizinTuru.Text = " " + dtOnceki.Rows[0]["pType"].ToString();
                lblOKullanilan.Text = " " + dtOnceki.Rows[0]["pRequest"].ToString();
                lblOizineGidis.Text = " " + dtOnceki.Rows[0]["pSDate"].ToString().Substring(0, 10);
                lblODonus.Text = " " + dtOnceki.Rows[0]["pWSDate"].ToString().Substring(0, 10);
            }

            db.AddParameterValue("@pRef", pRef);
            DataTable dtPersonel = db.GetDataTable("select * from tbPerson where Ref=@pRef");

            string vekilSql = @"SELECT         tbPerson_1.name  + ' ' + tbPerson_1.surname AS Expr1
FROM            tbPerson INNER JOIN
                         tbUnit ON tbPerson.unit = tbUnit.Ref INNER JOIN
                         tbPerson AS tbPerson_1 ON tbUnit.aRef = tbPerson_1.Ref
WHERE        (tbPerson.Ref = @pRef)";

            if (dtPersonel.Rows[0]["unit"].ToString() != "0")
            {
                db.AddParameterValue("@pRef", pRef);
                string yetkili = db.GetScalarValue(vekilSql).ToString();
                lblVekili.Text = " " + yetkili;
            }

            db.AddParameterValue("@IRef", Ref);
            DataTable dtIzin = db.GetDataTable("select * from tbPermission where Ref=@IRef");


            lblAd.Text = " " + dtPersonel.Rows[0]["name"].ToString();
            lblSoyad.Text = " " + dtPersonel.Rows[0]["surname"].ToString();
            lblSicil.Text = " " + dtPersonel.Rows[0]["register"].ToString();
            lblIseGiris.Text = " " + dtPersonel.Rows[0]["sDate"].ToString().Substring(0, 10);
            lblGorev.Text = " " + dtPersonel.Rows[0]["mission"].ToString();
            lblGorevYeri.Text = " " + dtPersonel.Rows[0]["campus"].ToString();


            lblizinAdres.Text = " " + dtPersonel.Rows[0]["address"].ToString();
            lblIzinTuru.Text = " " + dtIzin.Rows[0]["pType"].ToString();
            lblTalepEdilen.Text = " " + dtIzin.Rows[0]["pRequest"].ToString();

            lblBaslangic.Text = " " + dtIzin.Rows[0]["pSDate"].ToString().Substring(0, 10);
            lblBitis.Text = " " + dtIzin.Rows[0]["pFDate"].ToString().Substring(0, 10);
            lblIsbasi.Text = " " + dtIzin.Rows[0]["pWSDate"].ToString().Substring(0, 10);

            lblNedeni.Text = " " + dtIzin.Rows[0]["why"].ToString();
            lblAciklama.Text = " " + dtIzin.Rows[0]["desc"].ToString();

            int unit = int.Parse(dtPersonel.Rows[0]["unit"].ToString());
            if (unit != 0)
            {
                db.AddParameterValue("@ref", unit);
                lblBirim.Text = " " + db.GetScalarValue("select name from tbUnit where Ref=@ref").ToString();
            }

            if (!string.IsNullOrEmpty(dtIzin.Rows[0]["vekil"].ToString()) && dtIzin.Rows[0]["vekil"].ToString() != "0")
            {
                int vekil = int.Parse(dtIzin.Rows[0]["vekil"].ToString());

                db.AddParameterValue("@ref", vekil);
                lblVekili.Text = " " + db.GetScalarValue("select name + ' ' + surname from tbPerson where ref=@ref").ToString();
            }



            int hakedis = int.Parse(dtPersonel.Rows[0]["gain"].ToString());

            db.AddParameterValue("@Aref", pRef);
            int kullanilan = int.Parse(db.GetScalarValue("select SUM(pRequest) from tbPermission where pRef=@Aref").ToString());

            int kalan = hakedis - kullanilan;
            lblKalan.Text = " " + kalan.ToString();

            xrTableCell15.Text = " Yukarıda belirttiğim tarihler arasında izin kullanacağımı ve kalan yıllık ücretli izin gün sayımın " + kalan.ToString() + " gün olduğu konusunda işveren kayıtları ile mutabık olduğumu kabul ve beyan ederim.";

        }
        AccessManager db = new AccessManager();

        private void RptYazdir_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            Yazdir(pRef, Ref);
        }

        private void TopMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
