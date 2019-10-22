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
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using Obje.Classes;
using Obje.Companents;
using Sys;
namespace Sys
{
    public partial class FrmServerConnections : AtlasForm
    {
        public FrmServerConnections()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelBar(barMenu);

            cmbSecType.flashCombo.SelectedValueChanged += CmbSelectedChange;
        }

        #region Methods

        string str;
        AccessManager db = new AccessManager();
        Helper helper = new Helper();
        AtlasChangeState c = new AtlasChangeState();

        void GetInstancesNames()
        {
            DataTable dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            foreach (DataRow serverRow in dt.Rows)
            {
                if (serverRow[dt.Columns["InstanceName"]].ToString() == "")
                {
                    cmbServer.flashCombo.Properties.Items.Add(serverRow[dt.Columns["ServerName"]].ToString());
                }
                else
                {
                    cmbServer.flashCombo.Properties.Items.Add(serverRow[dt.Columns["ServerName"]].ToString() + "\\" +
                                        (serverRow[dt.Columns["InstanceName"]].ToString()));
                }
            }
        }
        void SqlConnectionTest()
        {

            SqlConnection m_Connection = null;
            m_Connection = new SqlConnection();
            if (cmbSecType.GetString() == "SQL")
                str = "Data Source=" + cmbServer.GetString() + "; Database = " + cmbDb.GetString() + "; User ID=" + txtUsername.GetString() + ";Password=" + txtPassword.GetString();
            else
                str = "Data Source = " + cmbServer.GetString() + "; Database =" + cmbDb.GetString() + "; Integrated Security=true;";

            m_Connection.ConnectionString = str;

            if (m_Connection.State != ConnectionState.Open)
            {
                try
                {
                    m_Connection.Open();
                    XtraMessageBox.Show("Bağlantı bilgileri doğrulandı.\n\rAyarları kaydedebilirsiniz.", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSave.Enabled = true;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Bağlantı bilgileri doğrulanamadı.", "Hatalı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = false;
                    helper.WriteLog(ex);
                }
            }
        }
        #endregion

        #region Load events
        private void FrmServerConnections_Load(object sender, EventArgs e)
        {
            helper.ClearForm(this);
            cmbSecType.flashCombo.Properties.Items.Add("WİNDOWS");
            cmbSecType.flashCombo.Properties.Items.Add("SQL");
            txtPassword.flaText.Properties.PasswordChar = '●';
            GetInstancesNames();
            c.StateStabil(this);
        }
        #endregion

        #region Others events
        private void CmbSelectedChange(object sender, EventArgs e)
        {
            if (cmbSecType.GetString() == "WİNDOWS")
            {
                txtPassword.Enabled = false;
                txtUsername.Enabled = false;
                txtPassword.ClearData();
                txtUsername.ClearData();
                lblUsername.Enabled = false;
                lblPassword.Enabled = false;
            }
            else
            {
                lblUsername.Enabled = true;
                lblPassword.Enabled = true;
                txtUsername.Enabled = true;
                txtPassword.Enabled = true;
            }
        }
        #endregion

        private void btnTestDb_Click(object sender, EventArgs e)
        {
            SqlConnectionTest();
        }

        private void btnLoadDb_Click(object sender, EventArgs e)
        {
            DataTable dtDb = db.GetDataTable("SELECT name DbName FROM master.dbo.sysdatabases");
            for (int i = 0; i < dtDb.Rows.Count; i++)
            {
                cmbDb.flashCombo.Properties.Items.Add(dtDb.Rows[i][0].ToString());
            }

        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string path = Application.StartupPath + @"\\connStr.txt";
            string connStr = str;
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(connStr);
            sw.Flush();
            sw.Close();
            fs.Close();
            XtraMessageBox.Show("Kayıt başarıyla gerçekleşti.", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            c.StateStabil(this);
            this.Close();
        }

        private void btnEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void FrmServerConnections_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}