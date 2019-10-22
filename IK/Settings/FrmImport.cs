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
using System.Data.OleDb;

namespace IK
{
    public partial class FrmImport : AtlasForm
    {
        public FrmImport()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelBar(bar1);
            AtlasCompanent.TemelGrid(gridView1);
            this.MaximizeBox = true;

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            gridView1.OptionsView.ShowAutoFilterRow = false;

        }

        AccessManager db = new AccessManager();
        Helper helper = new IK.Helper();
        AtlasChangeState c = new AtlasChangeState();
        DataTable dt = new DataTable();
        void setForm()
        {
            dt.Columns.Add("Ad");
            dt.Columns.Add("Soyad");
            dt.Columns.Add("Görevi");
            dt.Columns.Add("GSM");
            dt.Columns.Add("Doğum Tarihi", typeof(DateTime));
            dt.Columns.Add("İşe Giriş Tarihi", typeof(DateTime));
            dt.Columns.Add("TC");
            dt.Columns.Add("Sicil");
            gridControl1.DataSource = dt;
        }

        private void FrmImport_Load(object sender, EventArgs e)
        {
            setForm();
        }

        private void btnEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                OleDbConnection conn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = '" + ofd.FileName + "'; Extended Properties = Excel 12.0");
                var adapter = new OleDbDataAdapter("select * from [Sayfa$]", conn);
                var ds = new DataSet();
                string tableName = "excelData";
                adapter.Fill(ds, tableName);
                System.Data.DataTable data = ds.Tables[tableName];

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    DataRow row = dt.NewRow();
                    row["Ad"] = data.Rows[i][0].ToString();
                    row["Soyad"] = data.Rows[i][1].ToString();
                    row["Görevi"] = data.Rows[i][2].ToString();
                    row["GSM"] = data.Rows[i][3].ToString();
                    if (!string.IsNullOrEmpty(data.Rows[i][4].ToString()))
                        row["Doğum Tarihi"] = data.Rows[i][4].ToString();
                    if (!string.IsNullOrEmpty(data.Rows[i][5].ToString()))
                        row["İşe Giriş Tarihi"] = data.Rows[i][5].ToString();
                    row["TC"] = data.Rows[i][6].ToString();
                    row["Sicil"] = data.Rows[i][7].ToString();
                    dt.Rows.Add(row);
                }


                gridControl1.DataSource = dt;
                gridView1.RefreshData();
                gridView1.BestFitColumns();

            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //try
            //{

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                db.AddParameterValue("@tc", dt.Rows[i]["TC"].ToString());
                if (int.Parse(db.GetScalarValue("select count(*) from tbPerson where TC=@tc").ToString()) > 0)
                {
                    db.AddParameterValue("@tc", dt.Rows[i]["TC"].ToString());
                    _Ref = int.Parse(db.GetScalarValue("select Ref from tbPerson where TC = @tc").ToString());
                }
                else
                    _Ref = 0;

                db.AddParameterValue("@ref", _Ref);
                db.AddParameterValue("@name", dt.Rows[i]["Ad"].ToString());
                db.AddParameterValue("@surname", dt.Rows[i]["Soyad"].ToString());
                db.AddParameterValue("@tc", dt.Rows[i]["TC"].ToString());

                db.AddParameterValue("@bdate", DateTime.Parse(dt.Rows[i]["Doğum Tarihi"].ToString()), SqlDbType.Date);
                db.AddParameterValue("@bPlace", "");
                db.AddParameterValue("@mName", "");
                db.AddParameterValue("@dName", "");
                db.AddParameterValue("@sex", "");
                db.AddParameterValue("@bgroup", "");
                db.AddParameterValue("@mStatus", "");
                db.AddParameterValue("@register", dt.Rows[i]["Sicil"].ToString());
                db.AddParameterValue("@mission", dt.Rows[i]["Görevi"].ToString());
                db.AddParameterValue("@unit", "");
                db.AddParameterValue("@sDate", DateTime.Parse(dt.Rows[i]["İşe Giriş Tarihi"].ToString()), SqlDbType.Date);
                db.AddParameterValue("@gsm", dt.Rows[i]["GSM"].ToString());
                db.AddParameterValue("@mail", "");
                db.AddParameterValue("@address", "", SqlDbType.NVarChar);
                db.AddParameterValue("@cname", "");
                db.AddParameterValue("@cSurname", "");
                db.AddParameterValue("@cRank", "");
                db.AddParameterValue("@cGsm", "");
                db.AddParameterValue("@dLicence", "");
                db.AddParameterValue("@solider", "");
                db.AddParameterValue("@education", "");
                db.AddParameterValue("@children", "");
                db.AddParameterValue("@imagePath", "");
                db.AddParameterValue("@gain", "");
                db.AddParameterValue("@firm", "");
                db.AddParameterValue("@insurance", "");
                db.AddParameterValue("@IBAN", "");
                db.RunCommand("sp_Person", CommandType.StoredProcedure);


            }
            XtraMessageBox.Show("İşlem başarıyla tamamlandı.", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            helper.ClearForm(this);
            c.StateStabil(this);
            this.DialogResult = DialogResult.OK;
            this.Close();
            //}
            //catch (Exception ex)
            //{
            //    helper.WriteLog(ex);
            //    db.parameterDelete();
            //}
        }
    }
}