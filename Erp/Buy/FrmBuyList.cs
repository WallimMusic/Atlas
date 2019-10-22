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
using DevExpress.XtraEditors.Repository;
using System.Globalization;
using DevExpress.XtraEditors.Controls;

namespace Erp.Buy
{
    public partial class FrmBuyList : AtlasForm
    {
        public FrmBuyList()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelRibbon(ribbonControl1);
            AtlasCompanent.TemelGrid(grdGrid);
            AtlasCompanent.TemelGrid(grdBranch);
            AtlasCompanent.Navbar(navBar);

            txtCode.flaButtonEdit.ButtonClick += getListCode;
        }

        #region Methods
        CultureInfo ciTL = new CultureInfo("tr-TR");
        ErpManager db = new ErpManager();
        AccessManager sysDb = new AccessManager();
        Helper helper = new Helper();
        Obje.Classes.AtlasChangeState c = new AtlasChangeState();
        StringBuilder stb = new StringBuilder();
        public DataTable dtBox = new DataTable();
        DataTable dtDetail = new DataTable();
        DataTable dtControl = new DataTable();
        int REf, codeCount;
        string code;
        DialogResult result;

        void SetForm()
        {
            chkActive.SetString("Aktif");
            chkActive.SetBoolValue(true);

            dtBox.Columns.Clear();
            dtBox.Columns.Add("Ref", typeof(int));
            dtBox.Columns.Add("Liste Ref");
            dtBox.Columns.Add("Kart Ref");
            dtBox.Columns.Add("Kart Kodu", typeof(string));
            dtBox.Columns.Add("Kart Adı", typeof(string));
            dtBox.Columns.Add("Renk");
            dtBox.Columns.Add("Beden");
            dtBox.Columns.Add("Barkod", typeof(string));
            dtBox.Columns.Add("Birim Ref");
            dtBox.Columns.Add("Birim Kodu");
            dtBox.Columns.Add("Fiyat", typeof(decimal));
            dtBox.Rows.Clear();
            dgwGrid.DataSource = dtBox;

            RepositoryItemButtonEdit riBtnStockCode;
            riBtnStockCode = new RepositoryItemButtonEdit();
            dgwGrid.RepositoryItems.Add(riBtnStockCode);
            riBtnStockCode.ButtonClick += riBtnStockCode_Click;

            dgwGrid.DataSource = dtBox;
            grdGrid.Columns[0].Visible = false;
            grdGrid.Columns[1].Visible = false;
            grdGrid.Columns[2].Visible = false;
            grdGrid.Columns[3].ColumnEdit = riBtnStockCode;

            //grdGrid.Columns[8].ColumnEdit = riLedUnit;
            grdGrid.Columns[8].Visible = false;
            grdGrid.Columns[3].OptionsColumn.ReadOnly = false;
            grdGrid.Columns[4].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[5].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[6].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[2].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[9].OptionsColumn.AllowEdit = false;

            grdGrid.BestFitColumns();
            grdGrid.RefreshData();

        }

        void FillLookUp()
        {
            FrmErpMain main = (FrmErpMain)Application.OpenForms["FrmErpMain"];
            ledCurr.flaLookUp.Properties.Columns.Clear();
            ledCurr.flaLookUp.Properties.ValueMember = "Ref";
            ledCurr.flaLookUp.Properties.DisplayMember = "name";
            ledCurr.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ref", Caption = "dbNo", Visible = false });
            ledCurr.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "code", Caption = "Kodu" });
            ledCurr.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "name", Caption = "Adı" });
            ledCurr.flaLookUp.Properties.DataSource = sysDb.GetDataTable("select * from sysCurrency");

            sysDb.AddParameterValue("@act", true);
            sysDb.AddParameterValue("@ref", Properties.Settings.Default.firmRef);
            riLedBranch.DataSource = main.lstBranch.ToList();

            db.AddParameterValue("@ref", this._Ref);
            dgwBranch.DataSource = db.GetDataTable("select * from StBuyPriceListBranch where listRef=@ref ");
        }

        bool Control()
        {

            stb.Clear();

            #region Code Control
            if (!string.IsNullOrEmpty(txtCode.GetString()))
            {
                dtControl.Clear();
                db.AddParameterValue("@code", txtCode.GetString());
                dtControl = db.GetDataTable("select code from StBuyPriceList where code=@code");
                if (dtControl.Rows.Count > 0)
                    codeCount = int.Parse(dtControl.Rows[0][0].ToString());
            }

            if (codeCount > 0 && this._FormMod == Enums.enmFormMod.Yeni)
                stb.AppendLine("Böyle bir liste kodu sistemde mevcut.");

            #endregion


            if (string.IsNullOrEmpty(txtCode.GetString()))
                stb.AppendLine("liste kodu boş geçilemez.");
            else
                code = txtCode.GetString();



            if (stb.ToString().Length <= 0)
                return true;
            else return false;




        }
        #endregion


        private bool Kubra(bool value)
        {
            if (value)
                return true;
            else
                return false;
        } // this metod writed for Kübra Çifçi 02.12.2018 Sunday 00:41

        private void FrmBuyList_Load(object sender, EventArgs e)
        {
            helper.ClearForm(this);
            SetForm();
            FillLookUp();
            if (this._FormMod == Enums.enmFormMod.Guncelle)
            {
                db.AddParameterValue("@ref", this._Ref);
                DataTable dt = db.GetDataTable("select * from StBuyPriceList where Ref=@ref");

                chkActive.SetBoolValue(bool.Parse(dt.Rows[0][1].ToString()));
                txtCode.SetString(dt.Rows[0][2].ToString());
                txtName.SetString(dt.Rows[0][3].ToString());
                ledCurr.SetValue(int.Parse(dt.Rows[0][4].ToString()));
                dtpStart.SetDate(DateTime.Parse(dt.Rows[0][5].ToString()));
                dtpFinish.SetDate(DateTime.Parse(dt.Rows[0][6].ToString()));
                db.parameterDelete();


                db.AddParameterValue("@ref", this._Ref);
                DataTable dtDetail = db.GetDataTable("Select * from StBuyPriceListDetails where listRef=@ref");
                for (int i = 0; i < dtDetail.Rows.Count; i++)
                {

                    DataRow row = dtBox.NewRow();
                    row["Ref"] = int.Parse(dtDetail.Rows[i][0].ToString());
                    row["Liste Ref"] = int.Parse(dtDetail.Rows[i][1].ToString());
                    row["Kart Ref"] = int.Parse(dtDetail.Rows[i][2].ToString());

                    db.AddParameterValue("@ref", dtDetail.Rows[i][2].ToString());
                    DataTable dtStock = db.GetDataTable("select code,name from StStockCard where Ref=@ref");
                    row["Kart Kodu"] = (dtStock.Rows[0][0].ToString());
                    row["Kart Adı"] = (dtStock.Rows[0][1].ToString());

                    db.AddParameterValue("@barcode", dtDetail.Rows[i][4].ToString());
                    DataTable dtBarcode = db.GetDataTable("select color,size from StStockCardBarcodes where barcode=@barcode");
                    row["Renk"] = (dtBarcode.Rows[0][0].ToString());
                    row["Beden"] = (dtBarcode.Rows[0][1].ToString());

                    row["Birim Ref"] = int.Parse(dtDetail.Rows[i][3].ToString());
                    sysDb.AddParameterValue("@unitRef", dtDetail.Rows[i][3].ToString());
                    row["Birim Kodu"] = sysDb.GetScalarValue("select symbol from SysUnit where ref=@unitRef").ToString();

                    row["Barkod"] = (dtDetail.Rows[i][4].ToString());
                    row["Fiyat"] = decimal.Parse(dtDetail.Rows[i][5].ToString());
                    dtBox.Rows.Add(row);
                }
                dgwGrid.DataSource = dtBox;
                grdGrid.RefreshData();
            }
            c.StateStabil(this);
        }

        private void getListCode(object sender, ButtonPressedEventArgs e)
        {
            helper.GetCode("StBuyPriceList", "code", this, txtCode, 1000);
        }

        private void bbiPriceUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(grdGrid.GetFocusedRowCellValue("Fiyat").ToString()))
            {
                grdGrid.Columns[3].UnGroup();
                string cardCode = (grdGrid.GetFocusedRowCellValue("Kart Kodu").ToString());
                decimal Price = decimal.Parse(grdGrid.GetFocusedRowCellValue("Fiyat").ToString());

                grdGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                for (int i = 0; i < grdGrid.RowCount; i++)
                {
                    if (grdGrid.GetRowCellValue(i, "Kart Kodu").ToString() == cardCode)
                        grdGrid.SetRowCellValue(i, "Fiyat", Price);
                }
            }

            grdGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;


        }

        private void bbiBranchDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //try
            //{
            System.Data.DataRow row = grdBranch.GetDataRow(grdBranch.FocusedRowHandle);

            if (!string.IsNullOrEmpty(row[0].ToString()) && row[0].ToString() != "0")
            {
                result = XtraMessageBox.Show("Seçili kaydı silmek istediğinize emin misiniz?\n\rKaydet işlemi yapılmadan son düzenlemeler geçerli olmayacaktır.", "Soru?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    REf = int.Parse(row[0].ToString());
                    grdBranch.DeleteRow(grdBranch.FocusedRowHandle);
                    if (REf != 0)
                    {
                        db.AddParameterValue("@Ref", REf);
                        db.RunCommand("delete from StBuyPriceListBranch where Ref=@Ref");
                    }
                    XtraMessageBox.Show("İşlem başarıyla tamamlandı.", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                if (row[0].ToString() != "0")
                grdBranch.DeleteRow(grdBranch.FocusedRowHandle);
            //}
            //catch (Exception ex)
            //{
            //    helper.WriteLog(ex);
            //}
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
                        db.RunCommand("delete from StBuyPriceListDetails where Ref=@Ref");

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

        private void grdGrid_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            //ColumnView view = sender as ColumnView;
            //if (e.Column.Caption == "Fiyat" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            //{
            //    decimal price = Convert.ToDecimal(e.Value);
            //    e.DisplayText = string.Format(ciTL, "{0:c}", price);
            //}
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (Control())
                {
                    db.AddParameterValue("@ref", this._Ref);
                    db.AddParameterValue("@active", chkActive.GetBoolValue());
                    db.AddParameterValue("@code", txtCode.GetString());
                    db.AddParameterValue("@name", txtName.GetString());
                    db.AddParameterValue("@currencyRef", ledCurr.GetValue());
                    db.AddParameterValue("@start", dtpStart.GetDate(), SqlDbType.Date);
                    db.AddParameterValue("@finish", dtpFinish.GetDate(), SqlDbType.Date);
                    db.RunCommand("sp_BuyPriceList", CommandType.StoredProcedure);
                    db.parameterDelete();

                    if (this._FormMod == Enums.enmFormMod.Yeni)
                        this._Ref = int.Parse(db.GetScalarValue("select MAX(ref) from StBuyPriceList").ToString());


                    for (int a = 0; a < grdGrid.RowCount - 1; a++)
                    {
                        if (string.IsNullOrEmpty(grdGrid.GetRowCellValue(a, "Ref").ToString()))
                            REf = 0;
                        else
                            REf = int.Parse(grdGrid.GetRowCellValue(a, "Ref").ToString());


                        decimal price = decimal.Parse(grdGrid.GetRowCellValue(a, "Fiyat").ToString());
                        db.AddParameterValue("@ref", REf);
                        db.AddParameterValue("@listRef", this._Ref);
                        db.AddParameterValue("@cardRef", grdGrid.GetRowCellValue(a, "Kart Ref"));
                        db.AddParameterValue("@unitRef", grdGrid.GetRowCellValue(a, "Birim Ref"));
                        db.AddParameterValue("@barcode", grdGrid.GetRowCellValue(a, "Barkod"));
                        db.AddParameterValue("@price", price, SqlDbType.Decimal);
                        db.RunCommand("sp_BuyPriceListDetails", CommandType.StoredProcedure);
                        db.parameterDelete();
                    }

                    for (int i = 0; i < grdBranch.RowCount - 1; i++)
                    {
                        if (string.IsNullOrEmpty(grdBranch.GetRowCellValue(i, "Ref").ToString()))
                            REf = 0;
                        else
                            REf = int.Parse(grdBranch.GetRowCellValue(i, "Ref").ToString());

                        db.AddParameterValue("@ref", REf);
                        db.AddParameterValue("@listRef", this._Ref);
                        db.AddParameterValue("@branchRef", grdBranch.GetRowCellValue(i, "branchRef"));
                        db.RunCommand("sp_BuyPriceListBranch", CommandType.StoredProcedure);
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


                    FrmErrorForm form = new FrmErrorForm();
                    form.flashMemoEdit1.SetString(stb.ToString());
                    form.ShowDialog();

                }

            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
            }
        }

        private void grdBranch_PopupMenuShowing_1(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            pmBranch.ShowPopup(Cursor.Position);
        }

        private void grdGrid_PopupMenuShowing_1(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            pmBranch.ShowPopup(Cursor.Position);
        }

        private void bbiApplyAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool state = false;
            decimal price = 0;
            if (grdGrid.RowCount - 1 > 0)
            {
                if (!string.IsNullOrEmpty(grdGrid.GetFocusedRowCellValue("Fiyat").ToString()))
                {
                    price = decimal.Parse(grdGrid.GetFocusedRowCellValue("Fiyat").ToString());
                    state = true;
                }
                if (state == true)
                {
                    for (int i = 0; i < grdGrid.RowCount - 1; i++)
                    {
                        grdGrid.SetRowCellValue(i, "Fiyat", price);
                    }
                }
                else
                    XtraMessageBox.Show("Oran alanı boş geçilemez.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void grdGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6 && grdGrid.FocusedColumn.ToString() == "Kart Kodu")
            {
                Stock.FrmBarcodeList list = new Stock.FrmBarcodeList();
                list.gelen = "Buy";
                list.ShowDialog();
            }
        }

        private void riBtnStockCode_Click(object sender, EventArgs e)
        {
            Stock.FrmBarcodeList list = new Stock.FrmBarcodeList();
            list.gelen = "Buy";
            list.ShowDialog();


        }

        private void btnEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}