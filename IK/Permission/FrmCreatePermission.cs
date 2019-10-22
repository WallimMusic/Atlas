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
using Obje.Classes;
using DevExpress.XtraReports.UI;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;

namespace IK.Permission
{
    public partial class FrmCreatePermission : AtlasForm
    {
        public FrmCreatePermission()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelBar(bar1);
            ledPersonel.flaLookUp.EditValueChanged += LoadPersonInfo;
            dtpIzinBitisTarihi.flashDate.EditValueChanged += Calculate;
            txtToplamTatil.flaText.TextChanged += totalText;
            dtpIzinBaslangic.flashDate.EditValueChanged += setMinDate;
        }

        void fillLed()
        {
            this.MaximizeBox = true;

            #region person
            DataTable dtPerson = new DataTable();
            DataTable dtVekil = new DataTable();
            string sql = "";
            FrmIKMain main = (FrmIKMain)Application.OpenForms["FrmIKMain"];
            _Ref = main.pRef;
            if (_Ref != 0)
            {
                db.parameterDelete();
                db.AddParameterValue("@ref", _Ref);
                if (int.Parse(db.GetScalarValue("Select count(*) from tbUnit where aRef=@ref").ToString()) > 0)
                {
                    db.parameterDelete();
                    db.AddParameterValue("@aRef", _Ref);
                    int unitRef = int.Parse(db.GetScalarValue("select ref from tbUnit where aRef=@aRef").ToString());

                    db.parameterDelete();
                    db.AddParameterValue("@unit", unitRef);
                    dtPerson = db.GetDataTable(@"Select Ref, name +' ' + surname as [Ad Soyad],mission from tbPerson with(nolock) WHERE unit=@unit
                    AND(ExitDate is null OR exitDate = '01.01.1900')");
                }
                else
                {
                    db.AddParameterValue("@ref", _Ref);
                    dtPerson = db.GetDataTable("Select Ref, name +' ' + surname as [Ad Soyad],mission from tbPerson with(nolock) WHERE  ref=@ref");
                }

                db.AddParameterValue("@Ref", _Ref);
                int newUnit = int.Parse(db.GetScalarValue("select unit from tbPerson where Ref=@Ref").ToString());
                db.AddParameterValue("@unit", newUnit);
                dtVekil = db.GetDataTable(@"Select Ref, name +' ' + surname as [Ad Soyad],mission from tbPerson with(nolock) WHERE unit=@unit
                    AND(ExitDate is null OR exitDate = '01.01.1900')");
            }
            else
            {
                dtPerson = db.GetDataTable("Select Ref, name +' ' + surname as [Ad Soyad],mission from tbPerson with(nolock) WHERE ExitDate is null OR exitDate = '01.01.1900' ORDER BY  [Ad Soyad] asc");
                dtVekil = db.GetDataTable("Select Ref, name +' ' + surname as [Ad Soyad],mission from tbPerson with(nolock) WHERE ExitDate is null OR exitDate = '01.01.1900' ORDER BY  [Ad Soyad] asc");
            }

            ledPersonel.flaLookUp.Properties.ValueMember = "Ref";
            ledPersonel.flaLookUp.Properties.DisplayMember = "Ad Soyad";
            ledPersonel.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ref", Caption = "dbNo", Visible = false });
            ledPersonel.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ad Soyad", Caption = "Ad Soyad" });
            ledPersonel.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "mission", Caption = "Görev" });
            ledPersonel.flaLookUp.Properties.DataSource = dtPerson;
            #endregion

            #region vekil




            ledVekil.flaLookUp.Properties.ValueMember = "Ref";
            ledVekil.flaLookUp.Properties.DisplayMember = "Ad Soyad";
            ledVekil.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ref", Caption = "dbNo", Visible = false });
            ledVekil.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ad Soyad", Caption = "Ad Soyad" });
            ledVekil.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "mission", Caption = "Görev" });
            ledVekil.flaLookUp.Properties.DataSource = dtVekil;


            #endregion


            cmbIzinTuru.flashCombo.Properties.Items.Add("Askerlik");
            cmbIzinTuru.flashCombo.Properties.Items.Add("Babalık");
            cmbIzinTuru.flashCombo.Properties.Items.Add("Denkleştirme");
            cmbIzinTuru.flashCombo.Properties.Items.Add("Doğum");
            cmbIzinTuru.flashCombo.Properties.Items.Add("Evlilik");
            cmbIzinTuru.flashCombo.Properties.Items.Add("İstirahat");
            cmbIzinTuru.flashCombo.Properties.Items.Add("Mazeret");
            cmbIzinTuru.flashCombo.Properties.Items.Add("Taşınma");
            cmbIzinTuru.flashCombo.Properties.Items.Add("Ücretsiz");
            cmbIzinTuru.flashCombo.Properties.Items.Add("Vefat");
            cmbIzinTuru.flashCombo.Properties.Items.Add("Yıllık");


        }

        void save()
        {
            int OncekiRef = 0;
            db.AddParameterValue("@pRef", ledPersonel.GetValue());
            if (int.Parse(db.GetScalarValue("Select Count(*) from tbPermission where pRef=@pRef").ToString()) > 0)
            {
                db.AddParameterValue("@pRef", ledPersonel.GetValue());
                OncekiRef = int.Parse(db.GetScalarValue("select max(Ref) from tbPermission where pRef=@pRef").ToString());
            }

            db.AddParameterValue("@Ref", _Ref);
            db.AddParameterValue("@pRef", ledPersonel.GetValue());
            db.AddParameterValue("@pType", cmbIzinTuru.GetString());
            db.AddParameterValue("@psDate", dtpIzinBaslangic.GetDate(), SqlDbType.Date);
            db.AddParameterValue("@pfDate", dtpIzinBitisTarihi.GetDate(), SqlDbType.Date);
            db.AddParameterValue("@pwsDate", dtpIseBaslamaTarihi.GetDate(), SqlDbType.Date);
            db.AddParameterValue("@pRequest", txtVerilen.GetString());
            db.AddParameterValue("@weekend", txtHaftaSonu.GetString());
            db.AddParameterValue("@national", txtMilli.GetString());
            db.AddParameterValue("@religion", txtDiniBayram.GetString());
            db.AddParameterValue("@why", txtWhy.GetString());
            db.AddParameterValue("@desc", txtDesc.GetString());
            db.AddParameterValue("@vekil", ledVekil.GetValue());
            if (int.Parse(txtKalanIzin.GetString()) < 0)
            {
                DialogResult soru;
                soru = XtraMessageBox.Show("Bu izin formunun oluşturulması halinde personelin izin hakkı eksiye düşecektir..\n\rOnaylıyor musunuz?", "Soru?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (soru == DialogResult.Yes)
                {
                    db.RunCommand("sp_Permission", CommandType.StoredProcedure);
                }
            }
            else
                db.RunCommand("sp_Permission", CommandType.StoredProcedure);


            DialogResult cevap;
            cevap = XtraMessageBox.Show("İşlem başarıyla tamamlandı.\n\rİzin belgesini yazdırmak ister misiniz?", "Başarılı İşlem!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (cevap == DialogResult.Yes)
            {
                _Ref = int.Parse(db.GetScalarValue("select max(Ref) from tbPermission").ToString());
                RptYazdir Rp = new RptYazdir();
                Rp.pRef = ledPersonel.GetValue();
                Rp.Ref = _Ref;
                Rp.oncekiRef = OncekiRef;
                Rp.CreateDocument();
                ReportPrintTool printTool = new ReportPrintTool(Rp);
                printTool.ShowRibbonPreviewDialog();
            }

            if (dtpIzinBitisTarihi.GetDate() > DateTime.Now)
            {
                db.AddParameterValue("@ref", ledPersonel.GetValue());
                int unitRef = int.Parse(db.GetScalarValue("select unit from tbPerson where Ref=@ref").ToString());
                if (unitRef != 0 && !string.IsNullOrEmpty(unitRef.ToString()))
                {
                    db.AddParameterValue("@uRef", unitRef);
                    string mailAddress = db.GetScalarValue(@"SELECT        tbPerson.mail
FROM  tbUnit INNER JOIN tbPerson ON tbUnit.aRef = tbPerson.Ref WHERE (tbUnit.Ref = @uRef)").ToString();

                    if (!string.IsNullOrEmpty(mailAddress))
                    {
                        string pAd = "", pSoyad = "";
                        db.AddParameterValue("@ref", ledPersonel.GetValue());
                        pAd = db.GetScalarValue("select name from tbPerson where Ref=@ref").ToString();
                        db.AddParameterValue("@ref", ledPersonel.GetValue());
                        pSoyad = db.GetScalarValue("select surname from tbPerson where Ref=@ref").ToString();
                        sendMail(mailAddress, pAd, pSoyad, cmbIzinTuru.GetString(), dtpIzinBaslangic.GetDate().ToShortDateString().ToString(), dtpIzinBitisTarihi.GetDate().ToShortDateString().ToString(), dtpIseBaslamaTarihi.GetDate().ToShortDateString().ToString());
                    }
                    else
                    {
                        XtraMessageBox.Show("Departman yöneticisinin mail adresi bulunamadı.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                    XtraMessageBox.Show("Personele ait mail adresi bulunamadı.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            helper.ClearForm(this);
            c.StateStabil(this);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        void sendMail(string gonderilecekAdres, string pAd, string pSoyad, string iType, string date1, string date2, string date3)
        {
            #region Mail Ayarları

            string imagePath = Application.StartupPath + "\\logo.jpg";
            string adSoyad = pAd + " " + pSoyad + " İZİN BİLGİLERİ";
            string mailBody = string.Format(@"        
<table border=2>
            <tr style=border: 0>
                <td colspan=2 width=400 height=100 style=text-align: center;color: brown;font-size: 15px;>   <h3> Bu mail otomatik olarak oluşturulmuştur..<br>Cevap gönderilmemelidir.</h3> </td>
            </tr>
            <tr>
            <tr>
                <td colspan=2 width=400  height=100 style=text-align: center><img src=cid:myImageID></td>
            </tr>
       
<tr>
    <td width=150>Adı:</td>
    <td>{0}</td>
</tr>
<tr>
    <td width=150>Soyadı:</td>
    <td>{1}</td>
</tr>
<tr>
    <td width=150>İzin Nedeni:</td>
    <td>{2}</td>
</tr>
<tr>
    <td width=150>İzin Başlangıç Tarihi:</td>
    <td>{3}</td>
</tr>
<tr>
    <td width=150>İzin Bitiş Tarihi:</td>
    <td>{4}</td>
</tr>
<tr>
    <td width=150>İşe Dönüş Tarihi:</td>
    <td>{5}</td>
</tr>
            </table>", pAd, pSoyad, iType, date1, date2, date3);


            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            NetworkCredential basicCredential = new NetworkCredential("insankaynaklari@badbear.com.tr", "BadBear2015");
            MailAddress fromAddress = new MailAddress("insankaynaklari@badbear.com.tr");
            LinkedResource theEmailImage = new LinkedResource(imagePath, MediaTypeNames.Image.Jpeg);


            theEmailImage.ContentId = "myImageID";
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailBody, null, MediaTypeNames.Text.Html);
            htmlView.LinkedResources.Add(theEmailImage);
            message.AlternateViews.Add(htmlView);

            #endregion

            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Host = "smtp.yandex.com.tr";
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = basicCredential;
            message.From = fromAddress;
            message.Subject = ledPersonel.GetString() + " İZİN BİLGİLERİ";
            message.IsBodyHtml = true;
            message.Body = mailBody;
            message.To.Add(gonderilecekAdres);
            message.CC.Add("muratselcuk@badbear.com.tr");
            message.CC.Add("seyhanselcuk@badbear.com.tr");
            smtpClient.Send(message);
        }

        bool Control()
        {
            int errorCount = 0;

            if (string.IsNullOrEmpty(ledPersonel.GetString()))
            {
                XtraMessageBox.Show("Personel alanını boş geçemezsiniz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorCount++;
            }
            else
            {
                if (this._FormMod != Enums.enmFormMod.Guncelle)
                {
                    db.AddParameterValue("@pRef", ledPersonel.GetValue());
                    db.AddParameterValue("@date", dtpIzinBaslangic.GetDate(), SqlDbType.Date);
                    DataTable dt = db.GetDataTable(@"select * from tbPermission  with(nolock) where pRef=@pRef
                    AND @date BETWEEN pSDate and pFDate");
                    if (dt.Rows.Count > 0)
                    {
                        XtraMessageBox.Show(ledPersonel.GetString() + " adlı personelin\n\rSeçilen izin başlangıcında bir izni zaten var.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        errorCount++;

                    }
                }
            }

            if (string.IsNullOrEmpty(dtpIzinBaslangic.GetDate().ToString()) || string.IsNullOrEmpty(dtpIzinBitisTarihi.GetDate().ToString()))
            {
                XtraMessageBox.Show("Başlangıç veya bitiş tarihi değeri boş geçilemez..", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                errorCount++;
            }

            if (errorCount > 0)
                return false;
            else
                return true;
        }

        AccessManager db = new AccessManager();
        Helper helper = new IK.Helper();
        AtlasChangeState c = new AtlasChangeState();

        int Gain = 0, request = 0;
        public int pRef = 0, kRef = 0;

        private void FrmCreatePermission_Load(object sender, EventArgs e)
        {
            groupControl3.Enabled = false;
            fillLed();
            if (_FormMod == Enums.enmFormMod.Guncelle)
            {
                this._Ref = kRef;


                db.AddParameterValue("@ref", kRef);
                DataTable dt = db.GetDataTable("select * from tbPermission  with(nolock)  where Ref=@ref");
                ledPersonel.SetValue(int.Parse(dt.Rows[0]["pRef"].ToString()));
                cmbIzinTuru.SetString(dt.Rows[0]["pType"].ToString());
                dtpIzinBaslangic.SetDate(DateTime.Parse((dt.Rows[0]["pSDate"].ToString())));
                dtpIzinBitisTarihi.SetDate(DateTime.Parse((dt.Rows[0]["pFDate"].ToString())));
                dtpIseBaslamaTarihi.SetDate(DateTime.Parse((dt.Rows[0]["pWSDate"].ToString())));
                txtWhy.SetString(dt.Rows[0]["why"].ToString());
                txtDesc.SetString(dt.Rows[0]["desc"].ToString());
                ledVekil.SetValue(int.Parse(dt.Rows[0]["vekil"].ToString()));

            }
        }
        DialogResult cevap2;
        private void LoadPersonInfo(object sender, EventArgs e)
        {
            try
            {
                groupControl3.Enabled = true;
                db.AddParameterValue("@ref", ledPersonel.GetValue());
                DataTable dt = db.GetDataTable("SELECT * FROM tbPerson where Ref=@ref");

                dtpIseGiris.SetDate(DateTime.Parse(dt.Rows[0]["sDate"].ToString()));
                txtAdres.SetString(dt.Rows[0]["address"].ToString());
                txtToplamIzin.SetString(dt.Rows[0]["gain"].ToString());
                txtAdres.SetString(dt.Rows[0]["address"].ToString());

                db.AddParameterValue("@pRef", ledPersonel.GetValue());
                request = int.Parse(db.GetScalarValue("select  dbo.IK_GetUsedDays(@pRef)").ToString());

                txtKullanilanIzin.SetString(request.ToString());


                txtKullanilabilir.SetString((int.Parse(txtToplamIzin.GetString()) - request).ToString());
                txtOKullanilan.SetString(txtKullanilabilir.GetString());
            }
            catch (Exception)
            {
            }


        }

        private void Calculate(object sender, EventArgs e)
        {
            int haftaSonu = 0, resmiTatil = 0, diniTatil = 0;
            DateTime tarih1 = dtpIzinBaslangic.GetDate();
            DateTime tarih2 = dtpIzinBitisTarihi.GetDate();

            for (DateTime date = tarih1; date <= tarih2; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Sunday)
                    haftaSonu++;

                if (date.DayOfYear == 1 || date.DayOfYear == 113 || date.DayOfYear == 121 || date.DayOfYear == 139 || date.DayOfYear == 196 || date.DayOfYear == 242 || date.DayOfYear == 301)
                    resmiTatil++;
            }

            DataTable dtDini = db.GetDataSet("SELECT * FROM tbReligion").Tables[0];
            for (int a = 0; a < dtDini.Rows.Count; a++)
            {
                for (DateTime date = tarih1; date < tarih2; date = date.AddDays(1))
                {
                    if (date >= DateTime.Parse(dtDini.Rows[a][2].ToString()) && date <= DateTime.Parse(dtDini.Rows[a][3].ToString()))
                        if (date.DayOfWeek != DayOfWeek.Sunday)
                            if (date.DayOfYear != 1 && date.DayOfYear != 113 && date.DayOfYear != 121 && date.DayOfYear != 139 && date.DayOfYear != 196 && date.DayOfYear != 242 && date.DayOfYear != 301)
                                diniTatil++;

                }

            }
            DateTime tarih3 = dtpIseBaslamaTarihi.GetDate();
            TimeSpan Sonuc = tarih2 - tarih1;




            txtTalepEdilen.SetString((Sonuc.TotalDays + 1).ToString());
            txtIstenilen.SetString((Sonuc.TotalDays + 1).ToString());

            txtHaftaSonu.SetString(haftaSonu.ToString());
            txtDiniBayram.SetString(diniTatil.ToString());
            txtMilli.SetString(resmiTatil.ToString());
            txtTotal.SetString((resmiTatil + diniTatil + haftaSonu).ToString());
            txtToplamTatil.SetString(txtTotal.GetString());
            dtpIseBaslamaTarihi.flashDate.Properties.MinValue = dtpIzinBitisTarihi.GetDate().AddDays(1);
            dtpIseBaslamaTarihi.SetDate(dtpIzinBitisTarihi.GetDate().AddDays(1));

        }

        private void btnEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtToplamTatil.flaText.TextChanged -= totalText;
            this.Close();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                if (Control() == true)
                {
                    save();
                }
            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
                db.parameterDelete();
            }
        }

        private void groupControl3_Click(object sender, EventArgs e)
        {

        }

        private void cmbIzinTuru_MouseClick(object sender, MouseEventArgs e)
        {


        }

        private void totalText(object sender, EventArgs e)
        {
            try
            {
                int kullanilabilir = 0, istenilen = 0, tatil = 0, kalan = 0, verilen = 0;
                kullanilabilir = int.Parse(txtKullanilabilir.GetString());
                istenilen = int.Parse(txtIstenilen.GetString());
                tatil = int.Parse(txtToplamTatil.GetString());
                verilen = (istenilen - tatil);
                kalan = kullanilabilir - verilen;

                txtVerilen.SetString(verilen.ToString());
                txtKalanIzin.SetString(kalan.ToString());


            }
            catch (Exception)
            {

            }





        }

        private void setMinDate(object sender, EventArgs e)
        {
            dtpIzinBitisTarihi.flashDate.Properties.MinValue = dtpIzinBaslangic.GetDate();
            dtpIzinBitisTarihi.ClearData();
        }

    }
}