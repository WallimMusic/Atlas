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
using DevExpress.XtraEditors.Controls;
using System.Globalization;
using DevExpress.XtraEditors.Repository;
using Obje.List;

namespace Erp.Sell
{
    public partial class FrmDiscount : AtlasForm
    {
        public FrmDiscount()
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
            dtBox.Columns.Add("İndirim Tipi", typeof(int));
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
            dtBox.Columns.Add("Eski Fiyat", typeof(decimal));
            dtBox.Columns.Add("Oran", typeof(decimal));
            dtBox.Columns.Add("Yeni Fiyat", typeof(decimal));
            dtBox.Rows.Clear();
            dgwGrid.DataSource = dtBox;

            RepositoryItemButtonEdit riBtnStockCode;
            riBtnStockCode = new RepositoryItemButtonEdit();
            dgwGrid.RepositoryItems.Add(riBtnStockCode);
            riBtnStockCode.ButtonClick += riBtnStockCode_Click;

            RepositoryItemLookUpEdit riledType;
            riledType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            riledType.BeginInit();
            riledType.Columns.Add(new LookUpColumnInfo() { FieldName = "Key", Caption = "Ref", Visible = false });
            riledType.Columns.Add(new LookUpColumnInfo() { FieldName = "Value", Caption = "Ad" });
            riledType.NullText = "Seçim Yapınız";
            riledType.DisplayMember = "Value";
            riledType.ValueMember = "Key";
            riledType.DataSource = FlashDictionary.discountType.ToList();
            dgwGrid.RepositoryItems.Add(riledType);

            dgwGrid.DataSource = dtBox;

            grdGrid.Columns[1].Visible = false;
            grdGrid.Columns[2].Visible = false;
            grdGrid.Columns[3].Visible = false;
            grdGrid.Columns[4].ColumnEdit = riBtnStockCode;
            grdGrid.Columns[0].ColumnEdit = riledType;
            //grdGrid.Columns[8].ColumnEdit = riLedUnit;
            grdGrid.Columns[9].Visible = false;
            grdGrid.Columns[4].OptionsColumn.ReadOnly = false;
            grdGrid.Columns[5].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[6].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[7].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[3].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[10].OptionsColumn.AllowEdit = false;

            grdGrid.BestFitColumns();
            grdGrid.RefreshData();

        }

        void FillLookUp()
        {
            FrmErpMain main = (FrmErpMain)Application.OpenForms["FrmErpMain"];
            riLedBranch.DataSource = main.lstBranch.ToList();

            db.AddParameterValue("@ref", this._Ref);
            dgwBranch.DataSource = db.GetDataTable("select * from StSellDiscountBranch where [discountRef]=@ref ");
        }

        bool Control()
        {

            stb.Clear();

            #region Code Control
            if (!string.IsNullOrEmpty(txtCode.GetString()))
            {
                dtControl.Clear();
                db.AddParameterValue("@code", txtCode.GetString());
                dtControl = db.GetDataTable("select code from StSellDiscount where code=@code");
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

        #region PM EVENTS

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
                        db.RunCommand("delete from StSellDiscountDetail where Ref=@Ref");

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

        private void bbiPriceUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool state = false;
            int type = 0;
            decimal oran = 0;
            if (grdGrid.RowCount - 1 > 0)
            {
                if (!string.IsNullOrEmpty(grdGrid.GetFocusedRowCellValue("Oran").ToString()))
                {
                    oran = decimal.Parse(grdGrid.GetFocusedRowCellValue("Oran").ToString());
                    state = true;
                }

                type = int.Parse(grdGrid.GetFocusedRowCellValue("İndirim Tipi").ToString());
                if (state == true)
                {
                    for (int i = 0; i < grdGrid.RowCount - 1; i++)
                    {
                        grdGrid.SetRowCellValue(i, "İndirim Tipi", type);
                        grdGrid.SetRowCellValue(i, "Oran", oran);
                    }
                }
                else
                    XtraMessageBox.Show("Oran alanı boş geçilemez.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void grdGrid_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            pmMenu.ShowPopup(Cursor.Position);
        }

        private void bbiApplyCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool state = false;
            int type = 0;
            decimal oran = 0;
            string cardCode = "";
            decimal price = 0;
            if (grdGrid.RowCount - 1 > 0)
            {


                if (!string.IsNullOrEmpty(grdGrid.GetFocusedRowCellValue("Oran").ToString()))
                {
                    oran = decimal.Parse(grdGrid.GetFocusedRowCellValue("Oran").ToString());
                    state = true;
                }
                price = decimal.Parse(grdGrid.GetFocusedRowCellValue("Eski Fiyat").ToString());
                type = int.Parse(grdGrid.GetFocusedRowCellValue("İndirim Tipi").ToString());
                cardCode = grdGrid.GetFocusedRowCellValue("Kart Kodu").ToString();
                if (state == true)
                {

                    for (int i = 0; i < grdGrid.RowCount - 1; i++)
                    {
                        if (cardCode == grdGrid.GetRowCellValue(i, "Kart Kodu").ToString())
                        {
                            grdGrid.SetRowCellValue(i, "Eski Fiyat", price);
                            grdGrid.SetRowCellValue(i, "İndirim Tipi", type);
                            grdGrid.SetRowCellValue(i, "Oran", oran);
                        }
                    }
                }
                else
                    XtraMessageBox.Show("Oran alanı boş geçilemez.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        #endregion

        private void FrmDiscount_Load(object sender, EventArgs e)
        {
            helper.ClearForm(this);
            SetForm();
            FillLookUp();
            if (this._FormMod == Enums.enmFormMod.Guncelle)
            {
                db.AddParameterValue("@ref", this._Ref);
                DataTable dt = db.GetDataTable("select * from StSellDiscount where Ref=@ref");
                chkActive.SetBoolValue(bool.Parse(dt.Rows[0][1].ToString()));
                txtCode.SetString(dt.Rows[0][2].ToString());
                txtName.SetString(dt.Rows[0][3].ToString());
                dtpStart.SetDate(DateTime.Parse(dt.Rows[0][4].ToString()));
                dtpFinish.SetDate(DateTime.Parse(dt.Rows[0][5].ToString()));
                db.parameterDelete();

                db.AddParameterValue("@ref", this._Ref);
                dtDetail = db.GetDataTable("select * from StSellDiscountDetail where discountRef=@ref");
                for (int i = 0; i < dtDetail.Rows.Count; i++)
                {
                    DataRow row = dtBox.NewRow();
                    row["İndirim Tipi"] = dtDetail.Rows[i]["lineType"].ToString();
                    row["Ref"] = dtDetail.Rows[i]["Ref"].ToString();
                    row["Liste Ref"] = dtDetail.Rows[i]["discountRef"].ToString();

                    row["Kart Ref"] = dtDetail.Rows[i]["cardRef"].ToString();

                    db.AddParameterValue("@ref", dtDetail.Rows[i]["cardRef"].ToString());
                    DataTable dtStock = db.GetDataTable("select code,name from StStockCard where Ref=@ref");
                    row["Kart Kodu"] = (dtStock.Rows[0][0].ToString());
                    row["Kart Adı"] = (dtStock.Rows[0][1].ToString());


                    row["Barkod"] = dtDetail.Rows[i]["barcode"].ToString();
                    db.AddParameterValue("@barcode", dtDetail.Rows[i]["barcode"].ToString());
                    DataTable dtBarcode = db.GetDataTable("select color,size from StStockCardBarcodes where barcode=@barcode");
                    row["Renk"] = (dtBarcode.Rows[0][0].ToString());
                    row["Beden"] = (dtBarcode.Rows[0][1].ToString());

                    row["Birim Ref"] = int.Parse(dtDetail.Rows[i]["unitRef"].ToString());
                    sysDb.AddParameterValue("@ref", dtDetail.Rows[i]["unitRef"].ToString());
                    row["Birim Kodu"] = sysDb.GetScalarValue("select symbol from SysUnit where ref=@ref").ToString();


                    row["Oran"] = dtDetail.Rows[i]["rate"].ToString();
                    row["Eski Fiyat"] = dtDetail.Rows[i]["oldPrice"].ToString();
                    row["Yeni Fiyat"] = dtDetail.Rows[i]["newPrice"].ToString();
                    dtBox.Rows.Add(row);
                }
                dgwGrid.DataSource = dtBox;
                grdGrid.RefreshData();
            }
            c.StateStabil(this);
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Control())
            {
                db.AddParameterValue("@ref", this._Ref);
                db.AddParameterValue("@active", chkActive.GetBoolValue());
                db.AddParameterValue("@code", txtCode.GetString());
                db.AddParameterValue("@name", txtName.GetString());
                db.AddParameterValue("@start", dtpStart.GetDate().ToShortDateString(), SqlDbType.Date);
                db.AddParameterValue("@finish", dtpFinish.GetDate().ToShortDateString(), SqlDbType.Date);
                db.RunCommand("sp_SellDiscount", CommandType.StoredProcedure);
                db.parameterDelete();

                if (this._FormMod == Enums.enmFormMod.Yeni)
                    this._Ref = int.Parse(db.GetScalarValue("Select MAX(ref) from StSellDiscount").ToString());

                if (grdGrid.RowCount - 1 > 0)
                {


                    for (int i = 0; i < grdGrid.RowCount - 1; i++)
                    {
                        if (string.IsNullOrEmpty(grdGrid.GetRowCellValue(i, "Ref").ToString()))
                            REf = 0;
                        else
                            REf = int.Parse(grdGrid.GetRowCellValue(i, "Ref").ToString());

                        db.AddParameterValue("@ref", REf);
                        db.AddParameterValue("@discountRef", this._Ref);
                        db.AddParameterValue("@cardRef", grdGrid.GetRowCellValue(i, "Kart Ref"));
                        db.AddParameterValue("@unitRef", grdGrid.GetRowCellValue(i, "Birim Ref"));
                        db.AddParameterValue("@lineType", grdGrid.GetRowCellValue(i, "İndirim Tipi"));
                        db.AddParameterValue("@barcode", grdGrid.GetRowCellValue(i, "Barkod"));
                        db.AddParameterValue("@oldPrice", grdGrid.GetRowCellValue(i, "Eski Fiyat"), SqlDbType.Decimal);
                        db.AddParameterValue("@newPrice", grdGrid.GetRowCellValue(i, "Yeni Fiyat"), SqlDbType.Decimal);
                        db.AddParameterValue("@rate", grdGrid.GetRowCellValue(i, "Oran"), SqlDbType.Decimal);
                        db.RunCommand("sp_SellDiscountDetail", CommandType.StoredProcedure);
                        db.parameterDelete();
                    }

                    if (grdBranch.RowCount - 1 > 0)
                    {
                        for (int a = 0; a < grdBranch.RowCount - 1; a++)
                        {
                            if (string.IsNullOrEmpty(grdBranch.GetRowCellValue(a, "Ref").ToString()))
                                REf = 0;
                            else
                                REf = int.Parse(grdBranch.GetRowCellValue(a, "Ref").ToString());

                            db.AddParameterValue("@ref", REf);
                            db.AddParameterValue("@discountRef", this._Ref);
                            db.AddParameterValue("@branchRef", grdBranch.GetRowCellValue(a, "branchRef"));
                            db.RunCommand("sp_SellDiscountBranch", CommandType.StoredProcedure);
                            db.parameterDelete();
                        }
                    }
                    XtraMessageBox.Show("İşlem başarıyla tamamlandı.", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    helper.ClearForm(this);
                    c.StateStabil(this);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }






            }
            else
            {
                FrmErrorForm form = new FrmErrorForm();
                form.flashMemoEdit1.SetString(stb.ToString());
                form.ShowDialog();
            }
        }

        private void grdGrid_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.ToString() == "Barkod")
            {
                int LastListRef;
                string barcode = e.Value.ToString();
                string oldBarcode, state = "";

                db.AddParameterValue("@barcode", barcode);
                DataTable dtSearch = db.GetDataTable(@"SELECT        stStockCard.Ref, stStockCard.code AS [Kart Kodu], stStockCard.name AS [Kart Adı], StStockCardBarcodes.size AS Beden, StStockCardBarcodes.color AS Renk, StStockCardBarcodes.barcode AS Barcode, StStockCardUnits.unitRef as [Birim Ref],  StStockCardUnits.unitCode as [Birim Kodu] FROM            stStockCard 
INNER JOIN StStockCardBarcodes ON stStockCard.Ref = StStockCardBarcodes.cardRef 
INNER JOIN StStockCardUnits ON stStockCard.Ref = StStockCardUnits.Ref
WHERE        (stStockCard.active = 1) 
and barcode = @barcode");

                if (dtSearch.Rows.Count > 0)
                {
                    if (grdGrid.RowCount - 1 > 0)
                    {
                        for (int i = 0; i < grdGrid.RowCount - 1; i++)
                        {
                            oldBarcode = grdGrid.GetRowCellValue(i, "Barkod").ToString();
                            if (barcode == oldBarcode)
                            {
                                state = "true";
                                grdGrid.DeleteRow(grdGrid.FocusedRowHandle);
                                break;

                            }
                            else
                                state = "false";
                        }
                        if (state == "false")
                        {
                            grdGrid.DeleteRow(grdGrid.FocusedRowHandle);
                            DataRow row = dtBox.NewRow();
                            row["İndirim Tipi"] = 400;
                            row["Kart Ref"] = int.Parse(dtSearch.Rows[0]["Ref"].ToString());
                            row["Kart Kodu"] = dtSearch.Rows[0]["Kart Kodu"].ToString();
                            row["Kart Adı"] = dtSearch.Rows[0]["Kart Adı"].ToString();
                            row["Renk"] = dtSearch.Rows[0]["Renk"].ToString();
                            row["Beden"] = dtSearch.Rows[0]["Beden"].ToString();
                            row["Barkod"] = barcode;
                            row["Birim Ref"] = dtSearch.Rows[0]["Birim Ref"].ToString();
                            row["Birim Kodu"] = dtSearch.Rows[0]["Birim Kodu"].ToString();

                            LastListRef = int.Parse(db.GetScalarValue("select MAX(ref) from StSellPriceList where active = 1 and GETDATE() between startDate and finishDate").ToString());

                            db.AddParameterValue("@ref", LastListRef);
                            db.AddParameterValue("@barcode", barcode);
                            DataTable dtSellList = db.GetDataTable(" SELECT        price FROM            StSellPriceListDetails WHERE (barcode = @barcode) AND (listRef = @ref)");
                            if (string.IsNullOrEmpty(dtSellList.Rows[0][0].ToString()) || dtSellList.Rows[0][0].ToString() == "0")
                                row["Eski Fiyat"] = 0;
                            else
                                row["Eski Fiyat"] = decimal.Parse(dtSellList.Rows[0][0].ToString());
                            grdGrid.DeleteRow(grdGrid.FocusedRowHandle);
                            dtBox.Rows.Add(row);
                            grdGrid.RefreshData();


                        }
                    }
                    else
                    {
                        grdGrid.DeleteRow(grdGrid.FocusedRowHandle);
                        DataRow row = dtBox.NewRow();
                        row["İndirim Tipi"] = 400;
                        row["Kart Ref"] = int.Parse(dtSearch.Rows[0]["Ref"].ToString());
                        row["Kart Kodu"] = dtSearch.Rows[0]["Kart Kodu"].ToString();
                        row["Kart Adı"] = dtSearch.Rows[0]["Kart Adı"].ToString();
                        row["Renk"] = dtSearch.Rows[0]["Renk"].ToString();
                        row["Beden"] = dtSearch.Rows[0]["Beden"].ToString();
                        row["Barkod"] = barcode;
                        row["Birim Ref"] = dtSearch.Rows[0]["Birim Ref"].ToString();
                        row["Birim Kodu"] = dtSearch.Rows[0]["Birim Kodu"].ToString();
                        LastListRef = int.Parse(db.GetScalarValue("select MAX(ref) from StSellPriceList where active = 1 and GETDATE() between startDate and finishDate").ToString());

                        db.AddParameterValue("@ref", LastListRef);
                        db.AddParameterValue("@barcode", barcode);
                        DataTable dtSellList = db.GetDataTable(" SELECT        price FROM            StSellPriceListDetails WHERE (barcode = @barcode) AND (listRef = @ref)");
                        if (string.IsNullOrEmpty(dtSellList.Rows[0][0].ToString()) || dtSellList.Rows[0][0].ToString() == "0")
                            row["Eski Fiyat"] = 0;
                        else
                            row["Eski Fiyat"] = decimal.Parse(dtSellList.Rows[0][0].ToString());
                        dtBox.Rows.Add(row);
                        grdGrid.RefreshData();
                    }

                }
                else
                {
                    grdGrid.DeleteRow(grdGrid.FocusedRowHandle);
                }
            }
            else if (e.Column.ToString() == "İndirim Tipi" || e.Column.ToString() == "Oran")
            {

                int type;
                decimal oran = 0, oldPrice, newPrice, pay;

                for (int i = 0; i < grdGrid.RowCount - 1; i++)
                {
                    type = int.Parse(grdGrid.GetRowCellValue(i, "İndirim Tipi").ToString());
                    if (!string.IsNullOrEmpty(grdGrid.GetRowCellValue(i, "Oran").ToString()))
                        oran = decimal.Parse(grdGrid.GetRowCellValue(i, "Oran").ToString());

                    oldPrice = decimal.Parse(grdGrid.GetRowCellValue(i, "Eski Fiyat").ToString());
                    if (type == 400)
                    {
                        // yüzde
                        pay = (oldPrice / 100) * oran;
                        newPrice = oldPrice - pay;
                        grdGrid.SetRowCellValue(i, "Yeni Fiyat", newPrice);
                        pay = 0; oran = 0; oldPrice = 0; newPrice = 0;
                    }
                    else if (type == 401)
                    {
                        // yüzde
                        pay = oran;
                        newPrice = oldPrice - pay;
                        grdGrid.SetRowCellValue(i, "Yeni Fiyat", newPrice);
                        pay = 0; oran = 0; oldPrice = 0; newPrice = 0;
                    }
                }
            }
        }

        private void btnEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void grdGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6 && grdGrid.FocusedColumn.ToString() == "Kart Kodu")
            {
                Stock.FrmBarcodeList list = new Stock.FrmBarcodeList();
                list.gelen = "Discount";
                list.ShowDialog();
            }
        }

        #region OTHER EVENTS

        private void getListCode(object sender, ButtonPressedEventArgs e)
        {
            helper.GetCode("StSellDiscount", "code", this, txtCode, 5000);
        }

        private void riBtnStockCode_Click(object sender, EventArgs e)
        {
            Stock.FrmBarcodeList list = new Stock.FrmBarcodeList();
            list.gelen = "Discount";
            list.ShowDialog();


        }

        #endregion
    }
}