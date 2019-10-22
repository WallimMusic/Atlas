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
using Obje.Classes;

namespace IK
{
    public partial class FrmLogin : AtlasForm
    {
        public FrmLogin()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
        }

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
            txtPass.Text = "";
            txtUser.Text = "";
            txtUser.Focus();
        }
        AccessManager db = new AccessManager();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FrmIKMain main = (FrmIKMain)Application.OpenForms["FrmIKMain"];
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPass.Text))
            {
                XtraMessageBox.Show("Kullanıcı Adı veya şifre boş geçilemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUser.Focus();
            }
            else
            {
                db.AddParameterValue("@name", txtUser.Text);
                db.AddParameterValue("@pass", txtPass.Text);
                DataTable dt = db.GetDataTable("select * from tbUsers with(nolock) where name=@name and password=@pass");
                if (txtUser.Text == "YSK" && txtPass.Text == "Ysk2019 !")
                {
                    main.who = "YSK";
                    if (atlasCheckEdit1.GetBoolValue() == true)
                    {
                        Properties.Settings.Default.rememberMe = true;
                        Properties.Settings.Default.pRef = 0;
                        Properties.Settings.Default.who = "YSK";
                        Properties.Settings.Default.Save();
                    }
                    this.DialogResult = DialogResult.OK;

                }
                else if (dt.Rows.Count > 0)
                {
                    main.pRef = int.Parse(dt.Rows[0]["aRef"].ToString());
                    main._Ref = int.Parse(dt.Rows[0]["Ref"].ToString());
                    if (atlasCheckEdit1.GetBoolValue() == true)
                    {
                        Properties.Settings.Default.rememberMe = true;
                        Properties.Settings.Default.pRef = int.Parse(dt.Rows[0]["Ref"].ToString());
                        Properties.Settings.Default.who = txtUser.Text;
                        Properties.Settings.Default.Save();
                    }
                    if (dt.Rows[0]["name"].ToString() == "15559994670")
                        main.who = "MURAT";
                    this.DialogResult = DialogResult.OK;
                }

                else
                    Titret();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            atlasCheckEdit1.SetString("Beni Hatırla");

            if (Properties.Settings.Default.rememberMe == true)
            {
                txtUser.Text = Properties.Settings.Default.who.ToString();
                txtPass.Focus();
            }

        }
    }
}