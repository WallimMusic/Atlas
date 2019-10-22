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
using Obje.Companents;
using Sys;

namespace Sys
{
    public partial class FrmLogin : AtlasForm
    {
        public FrmLogin()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            txtUsername.flaText.KeyDown += getKey;
            txtUsername.flaText.KeyUp += getKey;
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
            txtUsername.Text = "";
            txtUsername.Text = "";
        }

        AccessManager db = new AccessManager();
        Helper helper = new Helper();


        #endregion

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            db.Screen = ("SYS");
            tmrSaat.Start();
            txtPassword.flaText.Properties.PasswordChar = '●';
        }

        private void tmrSaat_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToShortTimeString().ToString();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.GetString() == "admin" && txtPassword.GetString() == "1299")
            {
                FrmSysMain ana = (FrmSysMain)Application.OpenForms["FrmSysMain"];
                ana.username = txtUsername.GetString();
                ana.database = "2018";
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void getKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                FrmServerConnections conn = new FrmServerConnections();
                conn.ShowDialog();

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}