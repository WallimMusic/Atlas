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

namespace Erp.Stock
{
    public partial class FrmImportStock : AtlasForm
    {
        public FrmImportStock()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelRibbon(ribbonControl1);
            AtlasCompanent.TemelGrid(grdGrid);



            grdGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            grdGrid.OptionsView.ShowAutoFilterRow = false;

        }

        ErpManager db = new ErpManager();
        Helper helper = new Erp.Helper();
        DataTable dt = new DataTable();
        AtlasChangeState c = new AtlasChangeState();
        bool state = false;
        void SetForm()
        {


            dt.Columns.Add("Seçim", typeof(bool));
            dt.Columns.Add("Ref", typeof(int));
            dt.Columns.Add("Code");
            dt.Columns.Add("Name");
            dt.Columns.Add("[Desc]");
            dt.Columns.Add("oldCardCode");
            dt.Columns.Add("erpCode");
            dt.Columns.Add("startDate", typeof(DateTime));
            dt.Columns.Add("finishDate", typeof(DateTime));
            dt.Columns.Add("Yerli Üretim", typeof(bool));
            dgwGrid.DataSource = dt;
            grdGrid.Columns[1].Visible = false;
            grdGrid.Columns[2].Caption = "Kod";
            grdGrid.Columns[3].Caption = "Ad";
            grdGrid.Columns[4].Caption = "Açıklama";
            grdGrid.Columns[5].Caption = "Eski Kart Kodu";
            grdGrid.Columns[6].Caption = "Erp Kodu";
            grdGrid.Columns[7].Caption = "Başlangıç Tarihi";
            grdGrid.Columns[8].Caption = "Bitiş Tarihi";
            grdGrid.OptionsBehavior.Editable = true;
            grdGrid.Columns[0].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[2].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[3].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[4].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[5].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[6].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[7].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[8].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[9].OptionsColumn.AllowEdit = true;
        }

        private void FrmImportStock_Load(object sender, EventArgs e)
        {
            SetForm();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Dosyası (*.xlsx)|*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                grdGrid.Columns[0].Visible = false;
                grdGrid.Columns[2].Visible = false;
                grdGrid.ExportToXlsx(sfd.FileName);
            }
            grdGrid.Columns[0].Visible = true;
            grdGrid.Columns[2].Visible = true;

            sfd.Reset();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                    row["Name"] = data.Rows[i][0].ToString();
                    row["[Desc]"] = data.Rows[i][1].ToString();
                    row["oldCardCode"] = data.Rows[i][2].ToString();
                    row["erpCode"] = data.Rows[i][3].ToString();
                    row["startDate"] = data.Rows[i][4].ToString();
                    row["finishDate"] = data.Rows[i][5].ToString();
                    dt.Rows.Add(row);
                }
                grdGrid.RefreshData();
                grdGrid.BestFitColumns();

            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int maxCode = int.Parse(db.GetScalarValue("select MAX(code) from StStockCard").ToString());
            for (int i = 0; i < grdGrid.RowCount; i++)
            {
                if (i == 0)
                {
                    grdGrid.SetRowCellValue(i, "Seçim", true);
                    grdGrid.SetRowCellValue(i, "Code", maxCode + 1);
                    if (string.IsNullOrEmpty(grdGrid.GetRowCellValue(i, "Name").ToString()))
                        grdGrid.SetRowCellValue(i, "Name", "BOŞ");

                }
                else
                {
                    grdGrid.SetRowCellValue(i, "Seçim", true);
                    grdGrid.SetRowCellValue(i, "Code", int.Parse(grdGrid.GetRowCellValue(i - 1, "Code").ToString()) + 1);
                    if (string.IsNullOrEmpty(grdGrid.GetRowCellValue(i, "Name").ToString()))
                        grdGrid.SetRowCellValue(i, "Name", "BOŞ");
                }
            }

            for (int a = 0; a < grdGrid.RowCount; a++)
            {
                if ((grdGrid.GetRowCellValue(a, "Name").ToString()) == "BOŞ")
                {
                    state = false;
                    break;
                }
                else
                { state = true; }
            }

            if (state == false)
            {
                XtraMessageBox.Show("Kart adı boş geçilen satırların Ad kısmı BOŞ olarak değiştirilmiştir.\n\rBu kayıtlar düzeltilmeden aktarım yapılmayacaktır.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdGrid.Columns[3].OptionsColumn.AllowEdit = true;
            }

            grdGrid.RefreshData();
            grdGrid.BestFitColumns();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //try
            //{
            if (state)
            {
                for (int i = 0; i < grdGrid.RowCount; i++)
                {
                    this._Ref = 0;
                    db.AddParameterValue("@ref", this._Ref);
                    db.AddParameterValue("@code", grdGrid.GetFocusedRowCellValue("Code").ToString());
                    db.AddParameterValue("@active", true);
                    db.AddParameterValue("@name", grdGrid.GetFocusedRowCellValue("Name").ToString());
                    db.AddParameterValue("@desc", grdGrid.GetFocusedRowCellValue("[Desc]").ToString());
                    db.AddParameterValue("@oldCode", grdGrid.GetFocusedRowCellValue("oldCardCode").ToString());
                    db.AddParameterValue("@erpCode", grdGrid.GetFocusedRowCellValue("erpCode").ToString());
                    db.AddParameterValue("@start", grdGrid.GetFocusedRowCellValue("startDate"), SqlDbType.Date);
                    db.AddParameterValue("@finish", grdGrid.GetFocusedRowCellValue("finishDate"), SqlDbType.Date);
                    db.AddParameterValue("@colorLot", 0);
                    db.AddParameterValue("@sizeLot", 0);
                    db.AddParameterValue("@brandRef", 0);
                    db.AddParameterValue("@modelRef", 0);
                    db.AddParameterValue("@producerRef", 0);
                    db.AddParameterValue("@seasonRef", 0);
                    db.AddParameterValue("@groupRef", 0);
                    db.AddParameterValue("@specialCode", /*txtSpecialCode.GetString()*/"");
                    db.AddParameterValue("@auth1", /*txtAuth1.GetString()*/"");
                    db.AddParameterValue("@auth2", /*txtAuth2.GetString()*/"");
                    db.AddParameterValue("@auth3",/* txtAuth3.GetString()*/"");
                    db.AddParameterValue("@auth4", /*txtAuth4.GetString()*/"");
                    db.AddParameterValue("@local", grdGrid.GetRowCellValue(i, "Yerli Üretim"));
                    db.RunCommand("sp_StockCard", CommandType.StoredProcedure);

                    string code = "";
                    int cardRef = 0;
                    int unitRef = 0, REf = 0, lenght = 0, weight = 0, width = 0, desi = 0;
                    unitRef = 1;
                    lenght = 0;
                    weight = 0;
                    width = 0;
                    desi = 0;
                    code = "Adet";
                    db.AddParameterValue("@code", grdGrid.GetFocusedRowCellValue("Code").ToString());
                    cardRef = int.Parse(db.GetScalarValue("select ref from StStockCard where code=@code").ToString());


                    db.AddParameterValue("@ref", REf);
                    db.AddParameterValue("@cardRef", cardRef);
                    db.AddParameterValue("@unitRef", unitRef);
                    db.AddParameterValue("@code", code);
                    db.AddParameterValue("@lenght", lenght);
                    db.AddParameterValue("@weight", weight);
                    db.AddParameterValue("@width", width);
                    db.AddParameterValue("@desi", desi);
                    db.RunCommand("sp_StockCardUnit", CommandType.StoredProcedure);
                    db.parameterDelete();

                }
                XtraMessageBox.Show("İşlem başarıyla tamamlandı.", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                helper.ClearForm(this);
                c.StateStabil(this);
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            else
            {
                XtraMessageBox.Show("Kart adı boş geçilen satırların Ad kısmı BOŞ olarak değiştirilmiştir.\n\rBu kayıtlar düzeltilmeden aktarım yapılmayacaktır.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdGrid.Columns[3].OptionsColumn.AllowEdit = true;
            }
            //}
            //catch (Exception ex)
            //{
            //    helper.WriteLog(ex);
            //    db.parameterDelete();
            //}
        }
    }
}