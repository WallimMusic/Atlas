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
    public partial class FrmSize : AtlasForm
    {
        public FrmSize()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelRibbon(ribbonControl1);
            AtlasCompanent.TemelGrid(grdGrid);
            grdGrid.OptionsView.ColumnAutoWidth = true;
            txtCode.flaButtonEdit.ButtonClick += GetCode;
        }

        #region Methods


        ErpManager db = new ErpManager();
        Helper helper = new Helper();
        StringBuilder stb = new StringBuilder();
        DataTable dtControl = new DataTable();
        AtlasChangeState c = new AtlasChangeState();

        int REf, RowCount;
        string code, name, codeCount;
        int MaxRef;


        DialogResult result;


        void FillData()
        {

            db.AddParameterValue("@ref", this._Ref);
            bindData.DataSource = db.GetDataTable("select * from StStockCardSizeDetails where SizeRef=@ref order by Ref ASC");
            RowCount = grdGrid.RowCount;
            db.parameterDelete();

            if (this._FormMod == Enums.enmFormMod.Guncelle)
            {
                db.AddParameterValue("@ref", this._Ref);
                DataTable dt = db.GetDataTable("select * from StStockCardSize where Ref=@ref");
                txtCode.SetString(dt.Rows[0][1].ToString());
                txtName.SetString(dt.Rows[0][2].ToString());
            }

        }

        bool Control()
        {
            stb.Clear();

            if (!string.IsNullOrEmpty(txtCode.GetString()))
            {
                dtControl.Clear();
                db.AddParameterValue("@code", txtCode.GetString());
                dtControl = db.GetDataTable("select code from StStockCardSize where code=@code");
                if (dtControl.Rows.Count > 0)
                    codeCount = (dtControl.Rows[0][0].ToString());
            }

            if (_FormMod == Enums.enmFormMod.Yeni && dtControl.Rows.Count > 0)
                stb.AppendLine("Böyle bir beden kodu sistemde mevcut.");

            if (string.IsNullOrEmpty(txtCode.GetString()))
                stb.AppendLine("Beden kodu boş geçilemez.");
            else
                code = txtCode.GetString();

            if (string.IsNullOrEmpty(txtName.GetString()))
                stb.AppendLine("Beden adı boş geçilemez.");
            else
                name = txtName.GetString();

            if (grdGrid.RowCount <= 0)
                stb.AppendLine("Beden tanımı yapmadan kayıt yapamazsınız.");

            if (stb.ToString().Length <= 0)
                return true;
            else return false;
        }

        #endregion


        private void grdGrid_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            pmMenu.ShowPopup(Cursor.Position);
        }

        private void FrmSize_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
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
                        db.RunCommand("delete from StStockCardSize where Ref=@Ref");

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
                if (Control())
                {

                    db.AddParameterValue("@ref", this._Ref);
                    db.AddParameterValue("@code", code);
                    db.AddParameterValue("@name", name);
                    db.RunCommand("sp_StockCardSize", CommandType.StoredProcedure);
                    db.parameterDelete();

                    if (this._FormMod == Enums.enmFormMod.Yeni)
                        MaxRef += int.Parse(db.GetScalarValue("select Max(Ref) from StStockCardSize").ToString());
                    else
                        MaxRef = this._Ref;

                    for (int i = 0; i < grdGrid.RowCount - 1; i++)
                    {
                        if (string.IsNullOrEmpty(grdGrid.GetRowCellValue(i, "Ref").ToString()))
                            REf = 0;
                        else
                            REf = int.Parse(grdGrid.GetRowCellValue(i, "Ref").ToString());


                        name = grdGrid.GetRowCellValue(i, "propName").ToString();


                        db.AddParameterValue("@ref", REf);
                        db.AddParameterValue("@sizeRef", MaxRef);
                        db.AddParameterValue("@propName", name);
                        db.RunCommand("sp_StockCardSizeDetails", CommandType.StoredProcedure);

                    }
                    XtraMessageBox.Show("İşlem başarıyla tamamlandı.", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillData();
                    RowCount = grdGrid.RowCount;
                    this.DialogResult = DialogResult.OK;
                    c.StateStabil(this);
                    this.Close();

                }
            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
                db.parameterDelete();

            }

        }

        private void FrmSize_Load(object sender, EventArgs e)
        {
            chkActive.SetBoolValue(true);
            chkActive.SetString("Aktif");
            FillData();
            c.StateStabil(this);
        }

        void GetCode(object sender, EventArgs e)
        {
            helper.GetCode("StStockCardSize", "code", this, txtCode, 100);
        }
    }
}