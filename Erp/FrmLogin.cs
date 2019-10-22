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
using System.Threading;
using static Obje.Classes.Enums;
using Obje.Classes;
using Obje.Companents;
using Erp;

namespace Erp
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        public FrmLogin()
        {
            InitializeComponent();

            ledFirm.flaLookUp.EditValueChanged += GetConnStr;
        }

        #region Tanımlar

        Random r = new Random();

        void Titret()
        {
            int c = 0;
            Point l = this.Location;
            while (c < 50)
            {
                int x = r.Next(1, 10);
                int y = r.Next(1, 10);
                this.Location = new Point(l.X + x, l.Y + y);
                Thread.Sleep(20); // bu çalışan kod parçacığının belirtilen bir süre duraklatılmasını sağlar.
                c++;
            }
            this.Location = l;
            txtUsername.ClearData();
            txtPassword.ClearData();
        }

        AccessManager db = new AccessManager();
        ErpManager erpMan = new ErpManager();
        Helper helper = new Helper();


        #endregion

        private void FrmLogin_Load(object sender, EventArgs e)
        {

            txtPassword.flaText.Properties.PasswordChar = '●';
            flashComboBox1.flashCombo.Properties.Items.Add("Türkçe");
            flashComboBox1.flashCombo.Text = "Türkçe";


            ledFirm.flaLookUp.Properties.ValueMember = "Ref";
            ledFirm.flaLookUp.Properties.DisplayMember = "name";
            ledFirm.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ref", Caption = "dbNo", Visible = false });
            ledFirm.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "name", Caption = "Adı" });
            db.AddParameterValue("@act", true, SqlDbType.Bit);
            ledFirm.flaLookUp.Properties.DataSource = db.GetDataTable("select Ref,name from sysFirm where Active=@act");
            txtUsername.SetString("onrcn");
            txtPassword.SetString("010203");
            ledFirm.SetValue(4);
            btnLogin.PerformClick();
        }

        private void tmrSaat_Tick(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ledFirm.GetValue().ToString()))
            {
                if (string.IsNullOrEmpty(txtUsername.GetString()))
                    XtraMessageBox.Show("Kullanıcı adı boş geçilemez.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (string.IsNullOrEmpty(txtPassword.GetString()))
                    XtraMessageBox.Show("Şifre boş geçilemez.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    string hashedPass = helper.TextSifrele(txtPassword.GetString());
                    db.AddParameterValue("@param1", txtUsername.GetString());
                    db.AddParameterValue("@param2", hashedPass);
                    if (db.GetDataSet("select * from sysUser where userName=@param1 and password=@param2").Tables[0].Rows.Count > 0)
                    {
                        FrmErpMain main = (FrmErpMain)Application.OpenForms["FrmErpMain"];
                        db.AddParameterValue("@param1", txtUsername.GetString());
                        db.AddParameterValue("@param2", hashedPass);
                        main.userRef = int.Parse(db.GetScalarValue("select Ref from sysUser where userName=@param1 and password=@param2").ToString());
                        main.firmRef = ledFirm.GetValue();

                        this.DialogResult = DialogResult.OK;

                    }
                    else
                        Titret();
                }

            }
            else
            {
                XtraMessageBox.Show("Firma seçmeden giriş yapamazsınız.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GetConnStr(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(ledFirm.GetValue().ToString()))
            {
                db.AddParameterValue("@ref", ledFirm.GetValue());
                int dbRef = int.Parse(db.GetScalarValue("select dbRef from sysFirm where Ref=@Ref").ToString());

                db.AddParameterValue("@ref", dbRef);
                string conn = db.GetScalarValue("select path from sysDatabase where Ref=@ref").ToString();
                if (!string.IsNullOrEmpty(conn))
                {
                    string normalConn = helper.TextSifreCoz(conn);
                    Properties.Settings.Default.connStr = normalConn;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    XtraMessageBox.Show("seçtiğiniz firmaya ait bir veritabanı bağlantısı bulunmuyor.\n\rLütfen veritabanı bağlantısını yapınız.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }

            }
        }
    }
}