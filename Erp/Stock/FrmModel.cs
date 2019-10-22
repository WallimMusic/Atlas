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

namespace Erp.Stock
{
    public partial class FrmModel : AtlasForm
    {
        public FrmModel()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelRibbon(ribbonControl1);
            AtlasCompanent.TemelGrid(grdGrid);
        }


        #region Methods


        ErpManager db = new ErpManager();
        Helper helper = new Helper();

        int REf, RowCount, brandRef;
        string code, name;



        DialogResult result;


        void FillData()
        {
            bindData.DataSource = db.GetDataTable("select * from StStockCardModel order by Ref ASC");
            RowCount = grdGrid.RowCount;

            riLedBrand.DataSource = db.GetDataTable("select * from StStockCardBrand order by Ref asc");
        }

        #endregion

        private void FrmModel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (grdGrid.RowCount != RowCount)
            {
                DialogResult answer;
                answer = XtraMessageBox.Show("Yaptığınız değişikler kaydedilmeyecek.\n\rVazgeçmek istediğinize emin misiniz?", "Soru?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer == DialogResult.No)
                    e.Cancel = true;
                else
                    e.Cancel = false;
            }
        }

        private void grdGrid_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            pmMenu.ShowPopup(Cursor.Position);
        }

        private void btnDeleteLine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                System.Data.DataRow row = grdGrid.GetDataRow(grdGrid.FocusedRowHandle);

                if (!string.IsNullOrEmpty(row[0].ToString()) && row[0].ToString() != "0")
                {
                    result = XtraMessageBox.Show("Seçili kaydı silmek istediğinize emin misiniz?\n\rKaydet işlemi yapılmadan son düzenlemeler geçerli olmayacaktır.", "Soru?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        REf = int.Parse(row[0].ToString());
                        grdGrid.DeleteRow(grdGrid.FocusedRowHandle);
                        db.AddParameterValue("@Ref", REf);
                        db.RunCommand("delete from StStockCardModel where Ref=@Ref");

                        XtraMessageBox.Show("İşlem başarıyla tamamlandı.", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    if (row[0].ToString() != "0")
                    grdGrid.DeleteRow(grdGrid.FocusedRowHandle);
            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdGrid.RowCount - 1; i++)
                {
                    if (string.IsNullOrEmpty(grdGrid.GetRowCellValue(i, "Ref").ToString()))
                        REf = 0;
                    else
                        REf = int.Parse(grdGrid.GetRowCellValue(i, "Ref").ToString());

                    code = grdGrid.GetRowCellValue(i, "code").ToString();
                    name = grdGrid.GetRowCellValue(i, "name").ToString();
                    brandRef = int.Parse(grdGrid.GetRowCellValue(i, "brandRef").ToString());

                    db.AddParameterValue("@ref", REf);
                    db.AddParameterValue("@code", code);
                    db.AddParameterValue("@name", name);
                    db.AddParameterValue("@brandRef", brandRef);
                    db.RunCommand("sp_StockCardModel", CommandType.StoredProcedure);

                }
                XtraMessageBox.Show("İşlem başarıyla tamamlandı.", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillData();
                RowCount = grdGrid.RowCount;
                this.Close();
            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
                db.parameterDelete();
            }
        }

        private void FrmModel_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void btnEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}