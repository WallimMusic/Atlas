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
using DevExpress.XtraEditors.Controls;
using Obje.Classes;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using Obje.List;
namespace Erp.Stock
{
    public partial class FrmOperation : AtlasForm
    {
        public FrmOperation()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelRibbon(ribbonControl1);
            AtlasCompanent.TemelGrid(grdGrid);

            ledBranch.flaLookUp.EditValueChanged += getWhouse;
            txtPlugSeri.flaText.EditValueChanged += getPlugNo;

            grdGrid.OptionsNavigation.EnterMoveNextColumn = false;
        }

        #region Methods


        ErpManager db = new ErpManager();
        AccessManager sysDb = new AccessManager();
        Helper helper = new Helper();
        Obje.Classes.AtlasChangeState c = new AtlasChangeState();
        StringBuilder stb = new StringBuilder();

        int REf, RowCount;
        int wHouse = 0, branch = 0, direc = 0;
        public DataTable dtBox = new DataTable();
        public string Type;
        DataTable dtDetail = new DataTable();
        FrmErpMain main = (FrmErpMain)Application.OpenForms["FrmErpMain"];


        DialogResult result;

        void FillData()
        {
            db.AddParameterValue("@ref", this._Ref);
            DataTable dtPlug = db.GetDataTable("select * from StPlug where Ref=@ref");
            txtPlugSeri.SetString(dtPlug.Rows[0][1].ToString());
            txtPlugNo.SetString(dtPlug.Rows[0][2].ToString());
            ledPlugType.SetValue(int.Parse(dtPlug.Rows[0][3].ToString()));
            dtpPlugDate.SetDate(DateTime.Parse(dtPlug.Rows[0][4].ToString()));
            ledBranch.SetValue(int.Parse(dtPlug.Rows[0][5].ToString()));
            ledWhouse.SetValue(int.Parse(dtPlug.Rows[0][6].ToString()));
            txtDesc.SetString(dtPlug.Rows[0][7].ToString());

            db.AddParameterValue("@ref", this._Ref);
            DataTable dtPlugDetails = db.GetDataTable("select * from StPlugDetails where plugRef=@ref");
            for (int i = 0; i < dtPlugDetails.Rows.Count; i++)
            {
                DataRow row = dtBox.NewRow();
                row["Ref"] = dtPlugDetails.Rows[i]["Ref"];
                row["Fiş Ref"] = dtPlugDetails.Rows[i]["plugRef"];
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
                row["Satır Açıklaması"] = dtPlugDetails.Rows[i]["lineDescription"];
                dtBox.Rows.Add(row);

            }

            grdGrid.RefreshData();

            RowCount = grdGrid.RowCount;

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

            ledPlugType.flaLookUp.Properties.ValueMember = "Key";
            ledPlugType.flaLookUp.Properties.DisplayMember = "Value";
            ledPlugType.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Key", Caption = "dbNo", Visible = false });
            ledPlugType.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Value", Caption = "Adı" });
            ledPlugType.flaLookUp.Properties.DataSource = FlashDictionary.plugTypes.ToList();

            ledBranch.flaLookUp.Properties.ValueMember = "Key";
            ledBranch.flaLookUp.Properties.DisplayMember = "Value";
            ledBranch.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Key", Caption = "dbNo", Visible = false });
            ledBranch.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Value", Caption = "Adı" });

            ledBranch.flaLookUp.Properties.DataSource = main.lstBranch.ToList();

            RepositoryItemButtonEdit riBtnStockCode;
            riBtnStockCode = new RepositoryItemButtonEdit();
            dgwGrid.RepositoryItems.Add(riBtnStockCode);
            riBtnStockCode.ButtonClick += riBtnStockCode_Click;

            txtPlugSeri.SetString("A");
            txtPlugSeri.Enabled = false;

            if (this._FormNo == "10.02.101")
            {
                ledPlugType.SetValue(100);
                direc = 1;
            }
            else if (this._FormNo == "10.02.102")
            {
                ledPlugType.SetValue(101);
                direc = 1;
            }

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
            grdGrid.BestFitColumns();
            grdGrid.RefreshData();
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
            if (grdGrid.RowCount - 1 <= 0)
                stb.AppendLine("Satır hareketi olmadan kayıt yapılamaz.");

            if (stb.ToString().Length <= 0)
                return true;
            else return false;
        }
        #endregion

        private void btnEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void FrmOperation_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void riBtnStockCode_Click(object sender, EventArgs e)
        {
            Stock.FrmBarcodeList list = new FrmBarcodeList();
            list.gelen = "Plug";
            list.ShowDialog();
        }

        private void FrmOperation_Load(object sender, EventArgs e)
        {
            SetForm();
            if (this._FormMod == Enums.enmFormMod.Guncelle)
                FillData();

            FillGrid();
            c.StateStabil(this);
        }

        private void getWhouse(object sender, EventArgs e)
        {
            ledWhouse.flaLookUp.Properties.ValueMember = "Key";
            ledWhouse.flaLookUp.Properties.DisplayMember = "Value";
            ledWhouse.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Key", Caption = "dbNo", Visible = false });
            ledWhouse.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Value", Caption = "Adı" });
            ledWhouse.flaLookUp.Properties.DataSource = main.lstWhouse.ToList();
        }

        private void grdGrid_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.ToString() == "Barkod")
            {
                string barcode = e.Value.ToString();
                string oldBarcode, state = "";
                int miktar = 0;
                db.AddParameterValue("@barcode", barcode);
                DataTable dtSearch = db.GetDataTable(@"select * from Stock_GetStockWithBarcode(@barcode)");

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

        }

        private void grdGrid_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
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
                        db.RunCommand("delete from StPlugDetails where Ref=@Ref");

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

        private void bbiApplyAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool state = false;
            decimal price = 0;
            if (grdGrid.RowCount - 1 > 0)
            {
                if (!string.IsNullOrEmpty(grdGrid.GetFocusedRowCellValue("Miktar").ToString()))
                {
                    price = decimal.Parse(grdGrid.GetFocusedRowCellValue("Miktar").ToString());
                    state = true;
                }
                if (state == true)
                {
                    for (int i = 0; i < grdGrid.RowCount - 1; i++)
                    {
                        grdGrid.SetRowCellValue(i, "Miktar", price);
                    }
                }
                else
                    XtraMessageBox.Show("Oran alanı boş geçilemez.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bbiApplyCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(grdGrid.GetFocusedRowCellValue("Miktar").ToString()))
            {
                grdGrid.Columns[3].UnGroup();
                string cardCode = (grdGrid.GetFocusedRowCellValue("Kart Kodu").ToString());
                decimal Price = decimal.Parse(grdGrid.GetFocusedRowCellValue("Miktar").ToString());

                grdGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                for (int i = 0; i < grdGrid.RowCount; i++)
                {
                    if (grdGrid.GetRowCellValue(i, "Kart Kodu").ToString() == cardCode)
                        grdGrid.SetRowCellValue(i, "Miktar", Price);
                }
            }

            grdGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
        }

        private void grdGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6 && grdGrid.FocusedColumn.ToString() == "Kart Kodu")
            {
                Stock.FrmBarcodeList list = new FrmBarcodeList();
                list.gelen = "Plug";
                list.ShowDialog();
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (Control())
                {
                    db.AddParameterValue("@ref", this._Ref);
                    db.AddParameterValue("@serial", txtPlugSeri.GetString());
                    db.AddParameterValue("@plugNo", txtPlugNo.GetString());
                    db.AddParameterValue("@type", ledPlugType.GetValue());
                    db.AddParameterValue("@date", dtpPlugDate.GetDate().ToShortDateString(), SqlDbType.Date);
                    db.AddParameterValue("@branch", branch);
                    db.AddParameterValue("@whouse", wHouse);
                    db.AddParameterValue("@desc", txtDesc.GetString());
                    db.RunCommand("sp_Plug", CommandType.StoredProcedure);
                    db.parameterDelete();




                    if (this._FormMod == Enums.enmFormMod.Yeni)
                        this._Ref = int.Parse(db.GetScalarValue("select MAX(Ref) from StPlug").ToString());


                    grdGrid.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
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

                        db.AddParameterValue("@ref", REf);
                        db.AddParameterValue("@plugRef", this._Ref);
                        db.AddParameterValue("@cardRef", cardRef);
                        db.AddParameterValue("@cardCode", cardCode);
                        db.AddParameterValue("@barcode", barcode);
                        db.AddParameterValue("@unitRef", unitRef);
                        db.AddParameterValue("@quantity", quantity);
                        db.AddParameterValue("@direc", direc);
                        db.AddParameterValue("@desc", lineDesc);
                        db.RunCommand("sp_PlugDetails", CommandType.StoredProcedure);

                    }
                    XtraMessageBox.Show("İşlem başarılı bir şekilde kaydedildi.", "Başarılı işlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    helper.ClearForm(this);
                    c.StateStabil(this);
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

        private void getPlugNo(object sender, EventArgs e)
        {
            int plugNo;
            db.AddParameterValue("@serial", txtPlugSeri.GetString());
            DataTable dt = (db.GetDataTable("select MAX(plugNo) from StPlug where plugSerial=@serial"));
            if (string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                plugNo = 999;
            else
                plugNo = int.Parse(dt.Rows[0][0].ToString());

            plugNo++;
            txtPlugNo.SetString(plugNo.ToString());
        }
    }
}