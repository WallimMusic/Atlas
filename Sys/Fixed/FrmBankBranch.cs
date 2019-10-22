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
using Obje.Companents;
using Sys;
namespace Sys
{
    public partial class FrmBankBranch : AtlasForm
    {
        public FrmBankBranch()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelBar(barMenu);
            AtlasCompanent.TemelGrid(grdGrid);
        }


        #region Methods


        AccessManager db = new AccessManager();
        Helper helper = new Helper();

        int REf, RowCount, bankRef, cityRef;
        string code, name;



        DialogResult result;



        void FillData()
        {
            bindCountry.DataSource = db.GetDataTable("select * from sysBankBranch order by Ref ASC");
            RowCount = grdGrid.RowCount;

            riledbank.DataSource = db.GetDataTable("select * from sysBank");
            riLedCity.DataSource = db.GetDataTable("select * from sysCity");
        }

        #endregion

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
                        db.RunCommand("delete from sysBankBranch where Ref=@Ref");

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
                grdGrid.FocusedRowHandle = -1;
                for (int i = 0; i < grdGrid.RowCount - 1; i++)
                {

                    if (string.IsNullOrEmpty(grdGrid.GetRowCellValue(i, "Ref").ToString()))
                        REf = 0;
                    else
                        REf = int.Parse(grdGrid.GetRowCellValue(i, "Ref").ToString());

                    cityRef = int.Parse(grdGrid.GetRowCellValue(i, "cityRef").ToString());
                    code = grdGrid.GetRowCellValue(i, "code").ToString();
                    name = grdGrid.GetRowCellValue(i, "name").ToString();
                    bankRef = int.Parse(grdGrid.GetRowCellValue(i, "bankRef").ToString());

                    db.AddParameterValue("@ref", REf);
                    db.AddParameterValue("@bankRef", bankRef);
                    db.AddParameterValue("@code", code);
                    db.AddParameterValue("@name", name);
                    db.AddParameterValue("@cityRef", cityRef);

                    db.RunCommand("sp_SysBankBranch_AddOrUp", CommandType.StoredProcedure);

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

        private void btnEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void FrmBankBranch_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FrmBankBranch_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}