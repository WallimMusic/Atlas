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

namespace Erp.Settings
{
    public partial class FrmStockClass : AtlasForm
    {
        public FrmStockClass()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelRibbon(ribbonControl1);
            AtlasCompanent.TemelGrid(grdClassValue);
            AtlasCompanent.TemelGrid(grdValue);
        }
        Obje.Classes.AtlasChangeState c = new AtlasChangeState();
        ErpManager db = new ErpManager();
        Helper helper = new Helper();
        int REf = 0;
        int selectedClassRef = 0;
        void FillData()
        {
            dgwClass.DataSource = db.GetDataTable("SELECT Ref,no as [Sıra No],name as [Sınıf Adı] FROM StStockCardClass");
            grdClassValue.Columns[0].Visible = false;
            grdClassValue.Columns[1].Width = 100;
            grdClassValue.Columns[1].MaxWidth = 100;
            grdClassValue.Columns[1].MinWidth = 100;
            grdClassValue.Columns[1].OptionsColumn.AllowEdit = false;
            grdClassValue.Columns[2].Width = 295;
            grdClassValue.Columns[2].MaxWidth = 295;
            grdClassValue.Columns[2].MinWidth = 295;
        }
        private void FrmStockClass_Load(object sender, EventArgs e)
        {

            FillData();
        }

        private void GrdClassValue_RowCountChanged(object sender, EventArgs e)
        {
            if (grdClassValue.RowCount > 11)
            {
                XtraMessageBox.Show("Maksimum eklenebilecek sınıf sayısı 10'dur. Daha fazla ekleme yapamazsınız..", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                grdClassValue.DeleteRow(10);
            }

        }

        private void GrdClassValue_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.ToString() == "Sınıf Adı")
                {


                    int siraNo = grdClassValue.GetFocusedDataSourceRowIndex();
                    siraNo++;
                    grdClassValue.SetFocusedRowCellValue("Sıra No", siraNo);

                }


            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
            }
        }

        private void BtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int maxSiraNo = 0, count = 0;
            try
            {



                for (int i = 0; i < grdClassValue.RowCount - 1; i++)
                {

                    if (string.IsNullOrEmpty(grdClassValue.GetRowCellValue(i, "Ref").ToString()))
                        REf = 0;
                    else
                        REf = int.Parse(grdClassValue.GetRowCellValue(i, "Ref").ToString());


                    db.AddParameterValue("@ref", REf);
                    db.AddParameterValue("@no", int.Parse(grdClassValue.GetRowCellValue(i, "Sıra No").ToString()));
                    db.AddParameterValue("@name", grdClassValue.GetRowCellValue(i, "Sınıf Adı").ToString().ToUpper());
                    db.RunCommand("sp_StockCardClass", CommandType.StoredProcedure);
                }

                int eksikKalan = 11 - grdClassValue.RowCount;

                for (int i = 0; i < eksikKalan; i++)
                {
                    count = int.Parse(db.GetScalarValue("Select COUNT(*) from StStockCardClass").ToString());
                    if (count > 0)
                        maxSiraNo = int.Parse(db.GetScalarValue("select MAX(no) from StStockCardClass").ToString());

                    maxSiraNo++;

                    db.AddParameterValue("@ref", 0);
                    db.AddParameterValue("@no", maxSiraNo);
                    db.AddParameterValue("@name", "BOŞ");
                    db.RunCommand("sp_StockCardClass", CommandType.StoredProcedure);
                }


                for (int i = 0; i < grdValue.RowCount - 1; i++)
                {
                    if (string.IsNullOrEmpty(grdValue.GetRowCellValue(i, "Ref").ToString()))
                        REf = 0;
                    else
                        REf = int.Parse(grdValue.GetRowCellValue(i, "Ref").ToString());


                    db.AddParameterValue("@ref", REf);
                    db.AddParameterValue("@classRef", selectedClassRef);
                    db.AddParameterValue("@code", grdValue.GetRowCellValue(i, "Özellik Kodu").ToString());
                    db.AddParameterValue("@name", grdValue.GetRowCellValue(i, "Özellik Adı").ToString().ToUpper());
                    db.AddParameterValue("@status", bool.Parse(grdValue.GetRowCellValue(i, "Özellik Durumu").ToString()), SqlDbType.Bit);
                    db.RunCommand("sp_StockCardClassDetail", CommandType.StoredProcedure);
                }
                XtraMessageBox.Show("İşlem başarılı bir şekilde kaydedildi.", "Başarılı işlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                helper.ClearForm(this);
                c.StateStabil(this);
                FillData();
            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);

            }

        }

        private void BtnEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void GrdClassValue_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            int Ref = 0;
            if (!string.IsNullOrEmpty(grdClassValue.GetFocusedRowCellValue("Ref").ToString()) || grdClassValue.GetFocusedRowCellValue("Ref").ToString() != "0")
                Ref = int.Parse(grdClassValue.GetFocusedRowCellValue("Ref").ToString());


            if (Ref != 0 || !string.IsNullOrEmpty(Ref.ToString()))
            {
                db.AddParameterValue("@Ref", Ref);
                DataTable dtDetail = db.GetDataTable("SELECT Ref, code as [Özellik Kodu],name as [Özellik Adı],status as [Özellik Durumu] FROM StStockCardClassDetail where classRef=@ref");
                dgwValue.DataSource = dtDetail;
                grdValue.Columns[0].Visible = false;
                selectedClassRef = Ref;
            }
        }

        private void GrdClassValue_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

            int Ref = 0;
            if (!string.IsNullOrEmpty(grdClassValue.GetFocusedRowCellValue("Ref").ToString()))
                Ref = int.Parse(grdClassValue.GetFocusedRowCellValue("Ref").ToString());


            if (Ref != 0 || !string.IsNullOrEmpty(Ref.ToString()))
            {
                db.AddParameterValue("@Ref", Ref);
                DataTable dtDetail = db.GetDataTable("SELECT Ref, code as [Özellik Kodu],name as [Özellik Adı],status as [Özellik Durumu] FROM StStockCardClassDetail where classRef=@ref");
                dgwValue.DataSource = dtDetail;
                grdValue.Columns[0].Visible = false;
                selectedClassRef = Ref;
            }
        }
    }
}