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
using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using System.IO;
using TheArtOfDev.HtmlRenderer.WinForms;
using System.Drawing.Imaging;

namespace IK
{
    public partial class FrmIKMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmIKMain()
        {
            InitializeComponent();
        }

        public int pRef = 0, pUnit = 0;

        public void Viewchild(AtlasForm _form)
        {
            //Check Before Open
            if (!IsFormActive(_form))
            {
                _form.MdiParent = this;
                _form.Show();
            }
        }
        //Check If a Form Is Opened Already
        private bool IsFormActive(AtlasForm form)
        {
            bool IsOpened = false;
            //If There Is More Than One Form Opened
            if (MdiChildren.Count() > 0)
            {
                foreach (var item in MdiChildren)
                {
                    if (form.Name == item.Name)
                    {
                        // Active This Form
                        xtraTabbedMdiManager1.Pages[item].MdiChild.Activate();
                        IsOpened = true;
                    }
                }
            }
            return IsOpened;
        }

        //void FormFill(string sql, string listname, AtlasForm Form)
        //{

        //    frmPersonelList List = new frmPersonelList();
        //    List._ConnStr = "";
        //    List._Sql = sql;
        //    List.Text = listname + " Kayıt Listesi";
        //    List.newForm = new AtlasForm();
        //    List.newForm = Form;


        //    //List._add = bool.Parse(dtAuth.Rows[0]["authAdd"].ToString());
        //    //List._update = bool.Parse(dtAuth.Rows[0]["authUpdate"].ToString());
        //    //List._show = bool.Parse(dtAuth.Rows[0]["authShow"].ToString());

        //    List.MdiParent = this;
        //    List.Show();


        //}


        void sendMail(string gonderilecekAdres, string pAd, string pSoyad)
        {
            #region Mail Ayarları

            string imagePath = Application.StartupPath + "\\Gif.gif";
            string mailBody = string.Format(@"<table border=2>         
                <tr>
                <img src=cid:myImageID width=500 height=500>
                </tr>
                </table>", pAd);


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
            message.Subject = "MUTLU YILAR " + pAd + " " + pSoyad + " !";
            message.IsBodyHtml = true;
            message.Body = mailBody;
            message.To.Add(gonderilecekAdres);
            message.Bcc.Add("seldakaban@badbear.com.tr");
            //message.CC.Add("muratselcuk@badbear.com.tr");
            //message.CC.Add("seyhanselcuk@badbear.com.tr");
            smtpClient.Send(message);
        }

        public int _Ref = 0;
        public string who = "";
        private void FrmIKMain_Load(object sender, EventArgs e)
        {
            this.Text = "Atlas | İnsan Kaynakları Modülü";
            FrmLogin Log = new FrmLogin();
            this.Opacity = 0;
            Log.ShowDialog();
            if (Log.DialogResult == System.Windows.Forms.DialogResult.OK)
                this.Opacity = 100;

            if (Properties.Settings.Default.rememberMe == true)
            {
                who = Properties.Settings.Default.who;
                _Ref = int.Parse(Properties.Settings.Default.pRef.ToString());
            }



            if (who == "YSK" || who == "MURAT")
            {
                ribbonPageAyarlar.Visible = true;
                barButtonItem1.Visibility = BarItemVisibility.Always;
                barButtonItem7.Visibility = BarItemVisibility.Always;
                barButtonItem2.Visibility = BarItemVisibility.Always;
            }

            else
            {

                db.AddParameterValue("@ref", pRef);
                pUnit = int.Parse(db.GetScalarValue("select unit from tbPerson where Ref=@ref").ToString());

                //db.AddParameterValue("@Ref", _Ref);
                //DataTable dt = db.GetDataTable("select * from tbUsers where Ref=@ref");


                //if (bool.Parse(dt.Rows[0]["cPermission"].ToString()) == false)
                //    btnIzinOlustur.Visibility = BarItemVisibility.Never;

                //if (bool.Parse(dt.Rows[0]["sReport"].ToString()) == false)
                //    btnTümIzinlerRaporu.Visibility = BarItemVisibility.Never;


                //if (bool.Parse(dt.Rows[0]["sPReport"].ToString()) == false)
                //    btnPersonelRaporu.Visibility = BarItemVisibility.Never;

                //if (bool.Parse(dt.Rows[0]["sReport"].ToString()) == false && bool.Parse(dt.Rows[0]["sPReport"].ToString()) == false)
                //    pageRapor.Visible = false;
            }
            //barButtonItem5.PerformClick();
            //barButtonItem10.PerformClick();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Person.FrmAddPerson addPerson = new Person.FrmAddPerson();
            Viewchild(addPerson);
        }
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {

            frmPersonelList list = new frmPersonelList();
            Viewchild(list);
        }
        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            Permission.FrmCreatePermission create = new Permission.FrmCreatePermission();
            Viewchild(create);
        }
        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmReligion religion = new frmReligion();
            Viewchild(religion);
        }
        AccessManager db = new AccessManager();
        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            Person.FrmAddPerson addPerson = new Person.FrmAddPerson();
            DataTable dt = db.GetDataTable(@"SELECT * from tbPerson");
            int totalHak = 0;
            try
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i]["sDate"].ToString()))
                        {
                            DateTime sonTarih = DateTime.Now;
                            DateTime ilkTarih = DateTime.Parse(dt.Rows[i]["sDate"].ToString());

                            int[] sonuc = addPerson.ikiTarihFarki(sonTarih, ilkTarih);
                            int yil = int.Parse(sonuc[0].ToString());
                            int hak = 0;

                            if (yil < 1)
                                hak = 0;
                            if (yil <= 5 && yil > 1)
                                hak = 14;
                            else if (yil < 15 && yil > 5)
                                hak = 20;
                            else if (yil > 15)
                                hak = 26;

                            int onbes = 0;
                            int on = 0;
                            int bes = 0;
                            int kalan = 0;


                            if (yil < 1)
                                totalHak += 0;
                            if (yil - 5 >= 0)
                            {
                                bes = 1;
                                totalHak += 5 * 14;
                                kalan = yil - 5;
                            }
                            else if (yil - 5 < 0)
                                totalHak = yil * 14;

                            if (kalan - 10 >= 0)
                            {
                                on = 1;
                                totalHak += 10 * 20;
                                kalan = kalan - 10;
                            }

                            else if (kalan - 10 < 0)
                            {
                                totalHak += kalan * 20;
                                kalan = 0;
                            }

                            if (kalan > 0)
                            {
                                onbes = 1;
                                totalHak += kalan * 26;
                            }

                            int Ref = int.Parse(dt.Rows[i]["Ref"].ToString());

                            db.AddParameterValue("@ref", Ref);
                            db.AddParameterValue("@gain", totalHak);
                            db.RunCommand("update tbPerson set gain=@gain where Ref=@ref");

                        }
                    }

                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            Permission.FrmPermissionList list = new Permission.FrmPermissionList();
            Viewchild(list);
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            Person.FrmPersonalReport report = new Person.FrmPersonalReport();
            Viewchild(report);
        }

        private void btnAyarlar_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmSettings set = new FrmSettings();
            Viewchild(set);
        }

        private void barButtonItem3_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            try
            {
                Properties.Settings.Default.pRef = 0;
                Properties.Settings.Default.who = "";
                Properties.Settings.Default.rememberMe = false;
                Properties.Settings.Default.Save();
                Application.Exit();
            }
            catch (Exception)
            {

            }


        }

        private void barButtonItem6_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            FrmImport import = new FrmImport();
            Viewchild(import);
        }

        private void barButtonItem7_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Person.FrmExitPersonList list = new Person.FrmExitPersonList();
            Viewchild(list);
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {


        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void BarButtonItem10_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            //DataTable dt = db.GetDataTable("select name,surname,mail,birthDate from tbPerson where DAY(birthDate)=DAY(GETDATE()) and MONTH(birthDate)=MONTH(GETDATE())");
            //if (dt.Rows.Count > 0)
            //{

            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        if (!string.IsNullOrEmpty(dt.Rows[i][2].ToString()))
            //            sendMail(dt.Rows[i][2].ToString(), dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
            //        else
            //        {
            //            SmtpClient smtpClient = new SmtpClient();
            //            MailMessage message = new MailMessage();
            //            NetworkCredential basicCredential = new NetworkCredential("insankaynaklari@badbear.com.tr", "BadBear2015");
            //            MailAddress fromAddress = new MailAddress("insankaynaklari@badbear.com.tr");


            //            smtpClient.Port = 587;
            //            smtpClient.EnableSsl = true;
            //            smtpClient.Host = "smtp.yandex.com.tr";
            //            smtpClient.UseDefaultCredentials = false;
            //            smtpClient.Credentials = basicCredential;
            //            message.From = fromAddress;
            //            message.Subject = "Bad Bear IK Doğum Günü Hatırlatıcısı";
            //            message.IsBodyHtml = true;
            //            message.Body = "Bugün " + dt.Rows[i][0].ToString() + " " + dt.Rows[i][1].ToString() + " adlı kişinin doğum günü";
            //            message.To.Add("seldakaban@badbear.com.tr");
            //            smtpClient.Send(message);
            //        }
            //    }
            //}

           
    



            string htmlBody = @"
            <body style= width: 100%; height: 100%>
                <table align=center style= width: 850px; height: 768px;  border-style: solid; border-color:white; background-image:url(cid:myImageOne);>
                    <tr align=center>
                        <td>
                            <img src=cid:myImageTwo width=414 height=116> </img>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h3 style=text-align: center; color: white; font-size: 72px;font-family: Bottle Party DEMO, Times, serif> Doğum günün kutlu olsun!<br>Bad Bear ailesi olarak<br>Yeni yaşını kutlarız..<br></h3>
                          </td>
                    </tr>

                    <tr align=center>
                        <td>
                            <img src=cid:myImageThree> </img>
                        </td>
                    </tr>
                </table>
            </body>";
            //WebBrowser wb = new WebBrowser();


            //Bitmap m_Bitmap = new Bitmap(850, 768);

            //HtmlRender.Render(Graphics.FromImage(m_Bitmap), htmlBody, 0, 0, 500);
            //m_Bitmap.Save(Application.StartupPath + "\\ad.png",ImageFormat.Png);

            string pathOne = "";
            string pathTwo = "";
            string pathThree = "";

            pathOne = Application.StartupPath + "\\background.jpg";
            pathTwo = Application.StartupPath + "\\logo.png";
            pathThree = Application.StartupPath + "\\ayi.png";

            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
            message.AlternateViews.Add(htmlView);



            LinkedResource imageOne = new LinkedResource(pathOne, MediaTypeNames.Image.Jpeg);
            LinkedResource imageTwo = new LinkedResource(pathTwo, MediaTypeNames.Image.Jpeg);
            LinkedResource imageThree = new LinkedResource(pathThree, MediaTypeNames.Image.Jpeg);


            imageOne.ContentId = "myImageOne";
            imageTwo.ContentId = "myImageTwo";
            imageThree.ContentId = "myImageThree";

            htmlView.LinkedResources.Add(imageOne);
            htmlView.LinkedResources.Add(imageTwo);
            htmlView.LinkedResources.Add(imageThree);


            NetworkCredential basicCredential = new NetworkCredential("insankaynaklari@badbear.com.tr", "BadBear2015");
            MailAddress fromAddress = new MailAddress("insankaynaklari@badbear.com.tr");
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Host = "smtp.yandex.com.tr";
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = basicCredential;
            message.From = fromAddress;
            message.Subject = "MUTLU YILAR ONUR BOZKURT";
            message.IsBodyHtml = true;
            message.Body = htmlBody;

            message.To.Add("onur@onurbozkurt.com.tr");
            //message.Bcc.Add("seldakaban@badbear.com.tr");
            message.CC.Add("onrcn@msn.com");
            //message.CC.Add("seyhanselcuk@badbear.com.tr");
            smtpClient.Send(message);


        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            Settings.FrmUnit list = new Settings.FrmUnit();
            Viewchild(list);
        }
    }
}