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
    public partial class FrmCountry : AtlasForm
    {
        public FrmCountry()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelBar(barMenu);
            AtlasCompanent.TemelGrid(grdGrid);
        }

        #region Methods


        AccessManager db = new AccessManager();
        Helper helper = new Helper();
        StringBuilder stb = new StringBuilder();
        List<int> Deleted = new List<int>();

        int REf, RowCount;
        string plateCode, name, nationalName, phoneCode;
        DialogResult result;



        void FillData()
        {
            bindCountry.DataSource = db.GetDataTable("select * from sysCountry order by Ref ASC");
        }

        #endregion



        private void btnEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void grdGrid_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            pmMenu.ShowPopup(Cursor.Position);
        }

        private void FrmCountry_FormClosing(object sender, FormClosingEventArgs e)
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
                        db.RunCommand("delete from sysCountry where Ref=@Ref");

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

        private void FrmCountry_Load(object sender, EventArgs e)
        {
            FillData();
            RowCount = grdGrid.RowCount;
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

                    plateCode = grdGrid.GetRowCellValue(i, "plateNo").ToString();
                    name = grdGrid.GetRowCellValue(i, "name").ToString();
                    nationalName = grdGrid.GetRowCellValue(i, "nationalName").ToString();
                    phoneCode = grdGrid.GetRowCellValue(i, "countryPhoneCode").ToString();

                    db.AddParameterValue("@ref", REf);
                    db.AddParameterValue("@no", plateCode);
                    db.AddParameterValue("@name", name);
                    db.AddParameterValue("@natName", nationalName);
                    db.AddParameterValue("@phone", phoneCode);
                    db.RunCommand("sp_sysCountry_AddOrUp", CommandType.StoredProcedure);

                }
                XtraMessageBox.Show("İşlem başarıyla tamamlandı.", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillData();
                RowCount = grdGrid.RowCount;
                this.Close();
            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
            }

        }
    }
}