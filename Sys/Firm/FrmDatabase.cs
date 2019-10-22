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
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;
using Obje.Classes;
using Obje.Companents;
using Sys;

namespace Sys
{
    public partial class FrmDatabase : AtlasForm
    {
        public FrmDatabase()
        {
            InitializeComponent();


            Obje.Classes.AtlasCompanent.AForm(this);
            Obje.Classes.AtlasCompanent.TemelBar(barMenu);

        }

        #region Methods 

        AtlasChangeState c = new AtlasChangeState();
        AccessManager db = new AccessManager();
        Helper helper = new Helper();
        string Path = "", Pass = "", Username = "", dbName = "", dbType = "", dbNo = "", str = "";

        StringBuilder stb = new StringBuilder();

        bool Control()
        {
            if (string.IsNullOrEmpty(txtDbNo.GetString()))
                stb.AppendLine("Veritabanı numarası boş geçilemez.");
            else
                dbNo = (txtDbNo.GetString());

            if (string.IsNullOrEmpty(txtName.GetString()))
                stb.AppendLine("Veritabanı adı boş geçilemez.");
            else
                dbName = txtName.GetString();

            if (string.IsNullOrEmpty(cmbGuvenlikType.GetString()))
                stb.AppendLine("Güvenlik tipi boş geçilemez.");
            else
                dbType = cmbGuvenlikType.GetString();


            if (!string.IsNullOrEmpty(txtPassword.GetString()))
                Pass = helper.TextSifrele(txtPassword.GetString());
            else
                Pass = "";

            if (string.IsNullOrEmpty(txtUsername.GetString()))
                Username = "";
            else
                Username = txtUsername.GetString();

            if (stb.ToString().Length <= 0)
                return true;
            else
                return false;
        }

        void Clear()
        {
            txtDbNo.ClearData();
            txtName.ClearData();
            txtPassword.ClearData();
            txtTimeOut.ClearData();
            txtUsername.ClearData();
            cmbGuvenlikType.ClearData();
        }

        void GetInstancesNames()
        {
            cmbServer.flashCombo.Properties.Items.Clear();

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

            if (cmbServer.flashCombo.Properties.Items.Count <= 0)
                cmbServer.flashCombo.Properties.Items.Add(".");
        }

        void SqlConnectionTest()
        {

            SqlConnection m_Connection = null;
            m_Connection = new SqlConnection();
            if (cmbGuvenlikType.GetString() == "SQL")
                str = "Data Source=" + cmbServer.GetString() + "; Database = " + cmbDb.GetString() + "; User ID=" + txtUsername.GetString() + ";Password=" + txtPassword.GetString() + "; Integrated Security=true;";
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

        private void btnLoadDb_Click(object sender, EventArgs e)
        {
            DataTable dtDb = db.GetDataTable("SELECT name DbName FROM master.dbo.sysdatabases");
            for (int i = 0; i < dtDb.Rows.Count; i++)
            {
                cmbDb.flashCombo.Properties.Items.Add(dtDb.Rows[i][0].ToString());
            }
        }

        private void btnTestDb_Click(object sender, EventArgs e)
        {
            SqlConnectionTest();
        }

        private void btnEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void FrmDatabase_Load(object sender, EventArgs e)
        {
            helper.ClearForm(this);
            GetInstancesNames();
            cmbGuvenlikType.flashCombo.Properties.Items.Add("WİNDOWS");
            cmbGuvenlikType.flashCombo.Properties.Items.Add("SQL");

            txtPassword.flaText.Properties.PasswordChar = '●';
            if (_FormMod == Enums.enmFormMod.Guncelle)
            {
                db.AddParameterValue("@ref", this._Ref);
                DataTable dtDb = db.GetDataTable("select * from sysDatabase where Ref=@ref");
                txtDbNo.SetString(dtDb.Rows[0]["dbNo"].ToString());
                txtName.SetString(dtDb.Rows[0]["name"].ToString());
                cmbGuvenlikType.SetString(dtDb.Rows[0]["securityType"].ToString());
                txtUsername.SetString(dtDb.Rows[0]["sqlUsername"].ToString());
                txtPassword.SetString(helper.TextSifreCoz(dtDb.Rows[0]["sqlPassword"].ToString()));
                txtTimeOut.SetString(dtDb.Rows[0]["timeout"].ToString());
            }
            c.StateStabil(this);
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (Control())
                {
                    Path = helper.TextSifrele(str);
                    db.AddParameterValue("@ref", this._Ref);
                    db.AddParameterValue("@dbno", dbNo);
                    db.AddParameterValue("@name", dbName);
                    db.AddParameterValue("@path", Path, SqlDbType.NVarChar, 1000);
                    db.AddParameterValue("@type", dbType);
                    db.AddParameterValue("@username", Username);
                    db.AddParameterValue("@password", Pass);
                    db.AddParameterValue("@timeout", int.Parse(txtTimeOut.GetString()));

                    db.RunCommand("sp_sysDatabase_AddOrUp", CommandType.StoredProcedure);

                    XtraMessageBox.Show("Kayıt başarıyla tamamlandı.", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    c.StateStabil(this);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    FrmErrorForm eForm = new FrmErrorForm();
                    eForm.flashMemoEdit1.SetString(stb.ToString());
                    eForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
            }
        }
    }
}