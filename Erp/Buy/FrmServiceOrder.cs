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

namespace Erp.Buy
{
    public partial class FrmServiceOrder : AtlasForm
    {
        public FrmServiceOrder()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelRibbon(ribbonControl1);
            AtlasCompanent.TemelGrid(grdGrid);

            txtCode.flaButtonEdit.ButtonClick += getCode;
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
        public string Type, sCode, sName;
        public int sRef = 0;
        DataTable dtDetail = new DataTable();
        FrmErpMain main = (FrmErpMain)Application.OpenForms["FrmErpMain"];
        bool ok = false;
        decimal allTotal = 0;
        decimal lineCount = 0;
        decimal allQuantity = 0;
        DialogResult result;


        public void Calculate()
        {
            grdGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            allTotal = 0; lineCount = 0; allQuantity = 0;

            for (int i = 0; i < grdGrid.RowCount - 1; i++)
            {
                if (!string.IsNullOrEmpty(grdGrid.GetRowCellValue(i, "Miktar").ToString()) && !string.IsNullOrEmpty(grdGrid.GetRowCellValue(i, "Birim Fiyat").ToString()))
                {

                    decimal unitPrice = decimal.Parse(grdGrid.GetRowCellValue(i, "Birim Fiyat").ToString());
                    unitPrice = decimal.Parse(unitPrice.ToString().Replace(",", "."));
                    unitPrice = Math.Round(unitPrice, 2);
                    grdGrid.SetRowCellValue(i, "Birim Fiyat", unitPrice.ToString());

                    decimal total = decimal.Parse(grdGrid.GetRowCellValue(i, "Miktar").ToString()) * unitPrice;
                    total = Math.Round(total, 2);
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

            grdGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
        }
        void FillData()
        {

            db.AddParameterValue("@ref", this._Ref);
            DataTable dtPlug = db.GetDataTable("select * from StBuyOrder where Ref=@ref");
            if (!string.IsNullOrEmpty(dtPlug.Rows[0][1].ToString()))
            {


                txtCode.SetString(dtPlug.Rows[0][1].ToString());
                txtName.SetString(dtPlug.Rows[0][2].ToString());
                dtpPlugDate.SetDate(DateTime.Parse(dtPlug.Rows[0][3].ToString()));
                ledBranch.SetValue(int.Parse(dtPlug.Rows[0][4].ToString()));
                txtDesc.SetString(dtPlug.Rows[0][6].ToString());

                db.AddParameterValue("@ref", this._Ref);
                DataTable dtPlugDetails = db.GetDataTable("select * from StBuyOrderDetails where orderRef=@ref");
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
                grdGrid.BestFitColumns();

            }
        }

        void SetForm()
        {


            dtBox.Columns.Clear();
            dtBox.Columns.Add("Ref", typeof(int));
            dtBox.Columns.Add("Fiş Ref");
            dtBox.Columns.Add("Hizmet Ref");
            dtBox.Columns.Add("Hizmet Kodu", typeof(string));
            dtBox.Columns.Add("Hizmet Adı", typeof(string));
            dtBox.Columns.Add("Miktar");
            dtBox.Columns.Add("Birim Fiyat");
            dtBox.Columns.Add("Toplam Tutar");
            dtBox.Columns.Add("Satır Açıklaması");
            dtBox.Rows.Clear();
            dgwGrid.DataSource = null;


            ledBranch.flaLookUp.Properties.ValueMember = "Key";
            ledBranch.flaLookUp.Properties.DisplayMember = "Value";
            ledBranch.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Key", Caption = "dbNo", Visible = false });
            ledBranch.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Value", Caption = "Adı" });

            ledBranch.flaLookUp.Properties.DataSource = main.lstBranch.ToList();


            RepositoryItemButtonEdit riServiceCode;
            riServiceCode = new RepositoryItemButtonEdit();
            dgwGrid.RepositoryItems.Add(riBtnStockCode);
            riServiceCode.ButtonClick += riBtnStockCode_Click;
        }

        void FillGrid()
        {
            dgwGrid.DataSource = dtBox;



            grdGrid.Columns[0].Visible = false;
            grdGrid.Columns[1].Visible = false;
            grdGrid.Columns[2].Visible = false;

            grdGrid.Columns[3].ColumnEdit = riBtnStockCode;

            //grdGrid.Columns[8].ColumnEdit = riLedUnit;

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

        private void grdGrid_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.ToString() == "Miktar" || e.Column.ToString() == "Birim Fiyat")
            {

                Calculate();

            }

            if (e.Column.ToString() == "Hizmet Kodu")
            {
                string text = grdGrid.GetFocusedRowCellValue("Hizmet Kodu").ToString();
                db.AddParameterValue("@code", text);
                DataTable dtSearch = db.GetDataTable("select * from StBuyServices where code=@code");
                if (dtSearch.Rows.Count > 0)
                {
                    grdGrid.SetFocusedRowCellValue("Hizmet Ref", dtSearch.Rows[0]["Ref"].ToString());
                    grdGrid.SetFocusedRowCellValue("Hizmet Adı", dtSearch.Rows[0]["name"].ToString());
                    grdGrid.SetFocusedRowCellValue("Miktar", 1);
                    grdGrid.SetFocusedRowCellValue("Birim Fiyat", "1.00");
                    grdGrid.SetFocusedRowCellValue("Toplam Tutar", "1.00");


                }
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
                        db.RunCommand("delete from StBuyServiceDetails where Ref=@Ref");

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

        private void grdGrid_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            pmMenu.ShowPopup(Cursor.Position);
        }

        private void grdGrid_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Calculate();
        }

        bool Control()
        {
            stb.Clear();

            if (string.IsNullOrEmpty(ledBranch.GetValue().ToString()))
                stb.AppendLine("Şube boş geçilemez.");
            else
                branch = ledBranch.GetValue();


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
                db.AddParameterValue("@state", true);
                db.AddParameterValue("@totalPrice", allTotal, SqlDbType.Decimal);
                db.RunCommand("sp_BuyOrder", CommandType.StoredProcedure);
                db.parameterDelete();




                if (this._FormMod == Enums.enmFormMod.Yeni)
                    this._Ref = int.Parse(db.GetScalarValue("select MAX(Ref) from StBuyOrder").ToString());


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
                    db.RunCommand("sp_BuyOrderDetails", CommandType.StoredProcedure);

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

        #endregion

        private void FrmServiceOrder_Load(object sender, EventArgs e)
        {
            SetForm();
            if (this._FormMod == Enums.enmFormMod.Guncelle || this._FormMod == Enums.enmFormMod.Diger)
                FillData();

            FillGrid();

            c.StateStabil(this);
        }



        private void riBtnStockCode_Click(object sender, EventArgs e)
        {
            Tools.FrmServiceList list = new Tools.FrmServiceList();
            list.come = "Service Order";
            list.ShowDialog();

            if (list.DialogResult == DialogResult.OK)
                Calculate();


        }

        private void getCode(object sender, EventArgs e)
        {
            helper.GetCode("StBuyServiceOrder", "code", this, txtCode, 3000);
        }
    }
}