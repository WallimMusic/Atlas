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

namespace Erp.Sell
{
    public partial class FrmSellOrder : AtlasForm
    {
        public FrmSellOrder()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelRibbon(ribbonControl1);
            AtlasCompanent.TemelGrid(grdGrid);

            txtCode.flaButtonEdit.ButtonClick += getCode;
            ledBranch.flaLookUp.EditValueChanged += getWhouse;
            riBtnStockCode.ButtonClick += riBtnStockCode_Click;
        }
        #region Methods


        ErpManager db = new ErpManager();
        AccessManager sysDb = new AccessManager();
        Helper helper = new Helper();
        Obje.Classes.AtlasChangeState c = new AtlasChangeState();
        StringBuilder stb = new StringBuilder();

        int REf, RowCount;
        int wHouse = 0, branch = 0, direc = 1;
        public DataTable dtBox = new DataTable();
        public string Type;
        DataTable dtDetail = new DataTable();
        FrmErpMain main = (FrmErpMain)Application.OpenForms["FrmErpMain"];
        bool ok = false;
        decimal allTotal = 0;
        decimal lineCount = 0;
        decimal allQuantity = 0;
        DialogResult result;



        void FillData()
        {
            db.AddParameterValue("@ref", this._Ref);
            DataTable dtPlug = db.GetDataTable("select * from StSellOrder where Ref=@ref");
            txtCode.SetString(dtPlug.Rows[0][1].ToString());
            txtName.SetString(dtPlug.Rows[0][2].ToString());
            dtpPlugDate.SetDate(DateTime.Parse(dtPlug.Rows[0][3].ToString()));
            ledBranch.SetValue(int.Parse(dtPlug.Rows[0][4].ToString()));
            ledWhouse.SetValue(int.Parse(dtPlug.Rows[0][5].ToString()));
            txtDesc.SetString(dtPlug.Rows[0][6].ToString());
            ledCustomer.SetValue(int.Parse(dtPlug.Rows[0]["customerRef"].ToString()));

            db.AddParameterValue("@ref", this._Ref);
            DataTable dtPlugDetails = db.GetDataTable("select * from StSellOrderDetails where orderRef=@ref");
            for (int i = 0; i < dtPlugDetails.Rows.Count; i++)
            {
                DataRow row = dtBox.NewRow();
                row["Ref"] = dtPlugDetails.Rows[i]["Ref"];
                row["Fiş Ref"] = dtPlugDetails.Rows[i]["orderRef"];
                row["Kart Ref"] = dtPlugDetails.Rows[i]["cardRef"];
                row["Kart Kodu"] = dtPlugDetails.Rows[i]["cardCode"];
                db.parameterDelete();

                db.AddParameterValue("@ref", dtPlugDetails.Rows[i]["cardRef"], SqlDbType.Int);
                row["Kart Adı"] = db.GetScalarValue("select name from StStockCard where ref=@ref").ToString();
                db.parameterDelete();
                row["Barkod"] = dtPlugDetails.Rows[i]["barcode"];

                db.AddParameterValue("@barcode", dtPlugDetails.Rows[i]["barcode"]);
                row["Renk"] = db.GetScalarValue("select color from StStockCardBarcodes where barcode=@barcode");
                db.AddParameterValue("@barcode", dtPlugDetails.Rows[i]["barcode"]);
                row["Beden"] = db.GetScalarValue("select size from StStockCardBarcodes where barcode=@barcode");
                db.parameterDelete();

                row["Birim Ref"] = dtPlugDetails.Rows[i]["unitRef"];
                sysDb.AddParameterValue("@ref", dtPlugDetails.Rows[i]["unitRef"], SqlDbType.Int);
                row["Birim Kodu"] = sysDb.GetScalarValue("select symbol from sysUnit where Ref=@ref").ToString();
                sysDb.parameterDelete();
                row["Miktar"] = dtPlugDetails.Rows[i]["quantity"];
                row["Birim Fiyat"] = dtPlugDetails.Rows[i]["unitPrice"];
                row["Toplam Tutar"] = dtPlugDetails.Rows[i]["linePrice"];
                row["Satır Açıklaması"] = dtPlugDetails.Rows[i]["lineDescription"];

                dtBox.Rows.Add(row);

            }

            grdGrid.RefreshData();

            RowCount = grdGrid.RowCount;
            Calculate();
            grdGrid.BestFitColumns();


        }

        void SetForm()
        {


            dtBox.Columns.Clear();
            dtBox.Columns.Add("Ref", typeof(int));
            dtBox.Columns.Add("Fiş Ref");
            dtBox.Columns.Add("Kart Ref");
            dtBox.Columns.Add("Kart Kodu", typeof(string));
            dtBox.Columns.Add("Kart Adı", typeof(string));
            dtBox.Columns.Add("Renk");
            dtBox.Columns.Add("Beden");
            dtBox.Columns.Add("Barkod", typeof(string));
            dtBox.Columns.Add("Birim Ref");
            dtBox.Columns.Add("Birim Kodu");
            dtBox.Columns.Add("Miktar");
            dtBox.Columns.Add("Birim Fiyat");
            dtBox.Columns.Add("Toplam Tutar");
            dtBox.Columns.Add("Satır Açıklaması");
            dtBox.Rows.Clear();
            dgwGrid.DataSource = null;
            //RepositoryItemLookUpEdit riLedDirection;
            //riLedDirection = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            //riLedDirection.BeginInit();
            //riLedDirection.Columns.Add(new LookUpColumnInfo() { FieldName = "Key", Caption = "Ref", Visible = false });
            //riLedDirection.Columns.Add(new LookUpColumnInfo() { FieldName = "Value", Caption = "Yön" });
            //riLedDirection.DisplayMember = "Value";
            //riLedDirection.ValueMember = "Key";
            //riLedDirection.DataSource = FlashDictionary.Direction.ToList();
            //dgwGrid.RepositoryItems.Add(riLedDirection);


            //RepositoryItemLookUpEdit riLedUnit;
            //riLedUnit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            //riLedUnit.BeginInit();
            //riLedUnit.Columns.Add(new LookUpColumnInfo() { FieldName = "Ref", Caption = "Ref", Visible = false });
            //riLedUnit.Columns.Add(new LookUpColumnInfo() { FieldName = "unitName", Caption = "Ad" });
            //riLedUnit.DisplayMember = "unitName";
            //riLedUnit.ValueMember = "Ref";
            //sysDb.AddParameterValue("@act", true);
            //riLedUnit.DataSource = sysDb.GetDataTable("select * from sysUnit where active=@act");
            //dgwGrid.RepositoryItems.Add(riLedUnit);

            ledBranch.flaLookUp.Properties.ValueMember = "Key";
            ledBranch.flaLookUp.Properties.DisplayMember = "Value";
            ledBranch.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Key", Caption = "dbNo", Visible = false });
            ledBranch.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Value", Caption = "Adı" });

            ledBranch.flaLookUp.Properties.DataSource = main.lstBranch.ToList();


            ledCustomer.flaLookUp.Properties.ValueMember = "Ref";
            ledCustomer.flaLookUp.Properties.DisplayMember = "name";
            ledCustomer.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ref", Caption = "dbNo", Visible = false });
            ledCustomer.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "name", Caption = "Adı" });
            ledCustomer.flaLookUp.Properties.DataSource = db.GetDataTable("select * from StCustomerAccount where active=1 and type = 201 or type = 202");

            RepositoryItemButtonEdit riBtnStockCode;
            riBtnStockCode = new RepositoryItemButtonEdit();
            dgwGrid.RepositoryItems.Add(riBtnStockCode);
            riBtnStockCode.ButtonClick += riBtnStockCode_Click;
        }

        void FillGrid()
        {
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
            grdGrid.Columns[11].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[12].OptionsColumn.AllowEdit = false;
            grdGrid.BestFitColumns();
            grdGrid.RefreshData();

            if (this._FormMod == Enums.enmFormMod.Diger)
            {
                grdGrid.OptionsBehavior.Editable = false;
                grdGrid.Columns[3].OptionsColumn.AllowEdit = false;
                grdGrid.Columns[10].OptionsColumn.AllowEdit = false;
                grdGrid.Columns[11].OptionsColumn.AllowEdit = false;
                grdGrid.PopupMenuShowing -= null;
                bbiApplyAll.Enabled = false;
                bbiApplyCard.Enabled = false;
                btnDeleteLine.Enabled = false;
                grdGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;


                foreach (Control item in this.Controls)
                {
                    item.Enabled = false;
                    if (item == dgwGrid || item == groupBox2)
                        item.Enabled = true;
                }
            }
        }

        bool Control()
        {
            stb.Clear();

            if (string.IsNullOrEmpty(ledBranch.GetValue().ToString()))
                stb.AppendLine("Şube boş geçilemez.");
            else
                branch = ledBranch.GetValue();
            if (string.IsNullOrEmpty(ledWhouse.GetValue().ToString()))
                stb.AppendLine("Depo boş geçilemez.");
            else
                wHouse = ledWhouse.GetValue();


            if (stb.ToString().Length <= 0)
                return true;
            else return false;
        }

        void Save()
        {
            if (Control())
            {
                db.AddParameterValue("@ref", this._Ref);
                db.AddParameterValue("@code", txtCode.GetString());
                db.AddParameterValue("@name", txtName.GetString());
                db.AddParameterValue("@date", dtpPlugDate.GetDate().ToShortDateString(), SqlDbType.Date);
                db.AddParameterValue("@branch", branch);
                db.AddParameterValue("@whouse", wHouse);
                db.AddParameterValue("@desc", txtDesc.GetString());

                db.AddParameterValue("@totalPrice", allTotal, SqlDbType.Decimal);
                db.AddParameterValue("@state",true);
                db.AddParameterValue("@customerRef", ledCustomer.GetValue());
                db.RunCommand("sp_SellOrder", CommandType.StoredProcedure);
                db.parameterDelete();




                if (this._FormMod == Enums.enmFormMod.Yeni)
                    this._Ref = int.Parse(db.GetScalarValue("select MAX(Ref) from StSellOrder").ToString());


                grdGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                grdGrid.OptionsView.ShowAutoFilterRow = false;

                for (int i = 0; i < grdGrid.RowCount; i++)
                {

                    if (string.IsNullOrEmpty(grdGrid.GetRowCellValue(i, "Ref").ToString()))
                        REf = 0;
                    else
                        REf = int.Parse(grdGrid.GetRowCellValue(i, "Ref").ToString());


                    int cardRef = int.Parse(grdGrid.GetRowCellValue(i, "Kart Ref").ToString());
                    string cardCode = grdGrid.GetRowCellValue(i, "Kart Kodu").ToString();
                    string barcode = grdGrid.GetRowCellValue(i, "Barkod").ToString();
                    int unitRef = int.Parse(grdGrid.GetRowCellValue(i, "Birim Ref").ToString());
                    int quantity = int.Parse(grdGrid.GetRowCellValue(i, "Miktar").ToString());
                    string lineDesc = grdGrid.GetRowCellValue(i, "Satır Açıklaması").ToString();
                    decimal unitPrice = decimal.Parse(grdGrid.GetRowCellValue(i, "Birim Fiyat").ToString());
                    decimal linePrice = decimal.Parse(grdGrid.GetRowCellValue(i, "Toplam Tutar").ToString());

                    db.AddParameterValue("@ref", REf);
                    db.AddParameterValue("@orderRef", this._Ref);
                    db.AddParameterValue("@cardRef", cardRef);
                    db.AddParameterValue("@cardCode", cardCode);
                    db.AddParameterValue("@barcode", barcode);
                    db.AddParameterValue("@unitRef", unitRef);
                    db.AddParameterValue("@quantity", quantity);
                    db.AddParameterValue("@unitPrice", unitPrice, SqlDbType.Decimal);
                    db.AddParameterValue("@linePrice", linePrice, SqlDbType.Decimal);
                    db.AddParameterValue("@direc", direc);
                    db.AddParameterValue("@desc", lineDesc);
                    db.RunCommand("sp_SellOrderDetails", CommandType.StoredProcedure);

                }
                XtraMessageBox.Show("İşlem başarılı bir şekilde kaydedildi.", "Başarılı işlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ok = true;

            }
            else
            {
                FrmErrorForm form = new FrmErrorForm();
                form.flashMemoEdit1.SetString(stb.ToString());
                form.ShowDialog();
            }
        }

        public void Calculate()
        {
            allTotal = 0; lineCount = 0; allQuantity = 0;

            for (int i = 0; i < grdGrid.RowCount - 1; i++)
            {
                if (!string.IsNullOrEmpty(grdGrid.GetRowCellValue(i, "Miktar").ToString()))
                {
                    decimal total = decimal.Parse(grdGrid.GetRowCellValue(i, "Miktar").ToString()) * decimal.Parse(grdGrid.GetRowCellValue(i, "Birim Fiyat").ToString());
                    grdGrid.SetRowCellValue(i, "Toplam Tutar", total);


                    allTotal += decimal.Parse(grdGrid.GetRowCellValue(i, "Toplam Tutar").ToString());
                    lineCount = grdGrid.RowCount - 1;
                    allQuantity += decimal.Parse(grdGrid.GetRowCellValue(i, "Miktar").ToString());

                    lblCount.Text = lineCount.ToString();
                    lblquan.Text = allQuantity.ToString();
                    lblTotal.Text = string.Format("{0:c}", double.Parse(allTotal.ToString()));
                }
                grdGrid.BestFitColumns();

            }
        }

        #endregion

        public void grdGrid_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            #region Barcode
            if (e.Column.ToString() == "Barkod")
            {
                string barcode = e.Value.ToString();
                string oldBarcode, state = "";
                int miktar = 0;
                db.AddParameterValue("@barcode", barcode);
                DataTable dtSearch = db.GetDataTable(@"SELECT        stStockCard.Ref, stStockCard.code AS [Kart Kodu], stStockCard.name AS [Kart Adı], StStockCardBarcodes.size AS Beden, StStockCardBarcodes.color AS Renk, StStockCardBarcodes.barcode AS Barcode, StStockCardUnits.unitRef as [Birim Ref],  StStockCardUnits.unitCode as [Birim Kodu] FROM            stStockCard 
 LEFT JOIN StStockCardBarcodes ON stStockCard.Ref = StStockCardBarcodes.cardRef 
 LEFT JOIN StStockCardUnits ON stStockCard.Ref = StStockCardUnits.Ref
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
                                grdGrid.DeleteRow(grdGrid.FocusedRowHandle);
                                miktar = int.Parse(grdGrid.GetRowCellValue(i, "Miktar").ToString());
                                miktar++;
                                grdGrid.SetRowCellValue(i, "Miktar", miktar);
                                state = "true";
                                break;

                            }
                            else
                                state = "false";
                        }
                        if (state == "false")
                        {

                            DataRow row = dtBox.NewRow();
                            row["Kart Ref"] = int.Parse(dtSearch.Rows[0]["Ref"].ToString());
                            row["Kart Kodu"] = dtSearch.Rows[0]["Kart Kodu"].ToString();
                            row["Kart Adı"] = dtSearch.Rows[0]["Kart Adı"].ToString();
                            row["Renk"] = dtSearch.Rows[0]["Renk"].ToString();
                            row["Beden"] = dtSearch.Rows[0]["Beden"].ToString();
                            row["Barkod"] = barcode;
                            row["Birim Ref"] = dtSearch.Rows[0]["Birim Ref"].ToString();
                            row["Birim Kodu"] = dtSearch.Rows[0]["Birim Kodu"].ToString();
                            row["Miktar"] = 1;
                            grdGrid.DeleteRow(grdGrid.FocusedRowHandle);
                            dtBox.Rows.Add(row);
                            grdGrid.RefreshData();


                        }
                    }
                    else
                    {
                        grdGrid.DeleteRow(grdGrid.FocusedRowHandle);
                        DataRow row = dtBox.NewRow();
                        row["Kart Ref"] = int.Parse(dtSearch.Rows[0]["Ref"].ToString());
                        row["Kart Kodu"] = dtSearch.Rows[0]["Kart Kodu"].ToString();
                        row["Kart Adı"] = dtSearch.Rows[0]["Kart Adı"].ToString();
                        row["Renk"] = dtSearch.Rows[0]["Renk"].ToString();
                        row["Beden"] = dtSearch.Rows[0]["Beden"].ToString();
                        row["Barkod"] = barcode;
                        row["Birim Ref"] = dtSearch.Rows[0]["Birim Ref"].ToString();
                        row["Birim Kodu"] = dtSearch.Rows[0]["Birim Kodu"].ToString();
                        row["Miktar"] = 1;
                        dtBox.Rows.Add(row);
                        grdGrid.RefreshData();
                    }
                }
                else
                {
                    grdGrid.DeleteRow(grdGrid.FocusedRowHandle);
                }
            }
            #endregion

            if (e.Column.ToString() == "Miktar" || e.Column.ToString() == "Birim Fiyat")
            {
                Calculate();
            }
        }

        private void FrmSellOrder_Load(object sender, EventArgs e)
        {
            SetForm();
            if (this._FormMod == Enums.enmFormMod.Guncelle || this._FormMod == Enums.enmFormMod.Diger)
                FillData();

            FillGrid();

            c.StateStabil(this);
        }

        private void grdGrid_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            pmMenu.ShowPopup(Cursor.Position);
        }

        private void bbiApplyCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdGrid.CellValueChanged -= grdGrid_CellValueChanged;
            if (!string.IsNullOrEmpty(grdGrid.GetFocusedRowCellValue("Miktar").ToString()))
            {
                grdGrid.Columns[3].UnGroup();
                string cardCode = (grdGrid.GetFocusedRowCellValue("Kart Kodu").ToString());
                decimal quantity = decimal.Parse(grdGrid.GetFocusedRowCellValue("Miktar").ToString());

                int gridCount = grdGrid.RowCount - 1;

                for (int i = 0; i < gridCount; i++)
                {
                    if (grdGrid.GetRowCellValue(i, "Kart Kodu").ToString() == cardCode)
                        grdGrid.SetRowCellValue(i, "Miktar", quantity);
                    else
                        break;
                }
            }
            Calculate();
            grdGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            grdGrid.CellValueChanged -= grdGrid_CellValueChanged;
        }

        private void bbiApplyAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

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
                        db.RunCommand("delete from StSellOrderDetails where Ref=@Ref");

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

        private void grdGrid_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6 && grdGrid.FocusedColumn.ToString() == "Kart Kodu")
            {
                Stock.FrmBarcodeList list = new Stock.FrmBarcodeList();
                list.gelen = "Sell Order";
                list.ShowDialog();
            }
            if (e.KeyCode == Keys.Space && grdGrid.FocusedColumn.ToString() == "Birim Fiyat")
            {

                Tools.FrmPriceList priceList = new Tools.FrmPriceList();
                priceList.type = "Sell Order";
                priceList.barcode = grdGrid.GetFocusedRowCellValue("Barkod").ToString();
                priceList.cardCode = grdGrid.GetFocusedRowCellValue("Kart Kodu").ToString();
                priceList.branchRef = ledBranch.GetValue().ToString();
                priceList.ShowDialog();
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //try
            //{
                Save();
                if (ok == true)
                {
                    this.DialogResult = DialogResult.OK;
                    helper.ClearForm(this);
                    c.StateStabil(this);
                    this.Close();
                }
            //}
            //catch (Exception ex)
            //{
            //    helper.WriteLog(ex);
            //}
        }

        private void btnEscape_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void dgwGrid_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Save();
                if (ok == true)
                {
                    db.AddParameterValue("@state", false);
                    db.AddParameterValue("@ref", this._Ref);
                    db.AddParameterValue("@date", DateTime.Now.ToShortDateString(), SqlDbType.Date);
                    db.RunCommand("update StSellOrder set state=@state,okDate=@date where Ref=@ref");

                    this.DialogResult = DialogResult.OK;
                    helper.ClearForm(this);
                    c.StateStabil(this);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
            }
        }

        private void riBtnStockCode_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ledBranch.GetValue().ToString()) || ledBranch.GetValue() == 0)
                XtraMessageBox.Show("Şube seçilmeden satırlar listelenemez.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(ledWhouse.GetValue().ToString()) || ledWhouse.GetValue() == 0)
                XtraMessageBox.Show("Depo seçilmeden satırlar listelenemez.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                Stock.FrmBarcodeList list = new Stock.FrmBarcodeList();
                list.gelen = "Sell Order";

                list.ShowDialog();
            }
        }

        private void getWhouse(object sender, EventArgs e)
        {
            ledWhouse.flaLookUp.Properties.ValueMember = "Key";
            ledWhouse.flaLookUp.Properties.DisplayMember = "Value";
            ledWhouse.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Key", Caption = "dbNo", Visible = false });
            ledWhouse.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Value", Caption = "Adı" });
            ledWhouse.flaLookUp.Properties.DataSource = main.lstWhouse.ToList();
        }

        private void getCode(object sender, EventArgs e)
        {
            helper.GetCode("StSellOrder", "code", this, txtCode, 6000);
        }
    }
}