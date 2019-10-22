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
using System.Globalization;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using Obje.List;

namespace Erp.Sell
{
    public partial class FrmCampaings : AtlasForm
    {
        public FrmCampaings()
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

            RepositoryItemButtonEdit riBtnStockCode;
            riBtnStockCode = new RepositoryItemButtonEdit();
            dgwGrid.RepositoryItems.Add(riBtnStockCode);
            riBtnStockCode.ButtonClick += riBtnStockCode_Click;

            dtBox.Columns.Clear();
            dtBox.Columns.Add("Ref", typeof(int));
            dtBox.Columns.Add("Kampanya Ref");
            dtBox.Columns.Add("Kart Ref");
            dtBox.Columns.Add("Kart Kodu", typeof(string));
            dtBox.Columns.Add("Kart Adı", typeof(string));
            dtBox.Columns.Add("Renk");
            dtBox.Columns.Add("Beden");
            dtBox.Columns.Add("Barkod", typeof(string));

            dtBox.Rows.Clear();
            dgwGrid.DataSource = dtBox;

            dgwGrid.DataSource = dtBox;
            grdGrid.Columns[0].Visible = false;
            grdGrid.Columns[1].Visible = false;
            grdGrid.Columns[2].Visible = false;

            grdGrid.Columns[3].ColumnEdit = riBtnStockCode;
            grdGrid.Columns[4].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[5].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[6].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[7].OptionsColumn.AllowEdit = false;

            grdGrid.BestFitColumns();
            grdGrid.RefreshData();

        }



        void FillLookUp()
        {
            ledType.flaLookUp.Properties.Columns.Clear();
            ledType.flaLookUp.Properties.ValueMember = "Key";
            ledType.flaLookUp.Properties.DisplayMember = "Value";
            ledType.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Key", Caption = "dbNo", Visible = false });
            ledType.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Value", Caption = "Adı" });
            ledType.flaLookUp.Properties.DataSource = FlashDictionary.campaingTypes.ToList();

            FrmErpMain main = (FrmErpMain)Application.OpenForms["FrmErpMain"];
            riLedBranch.DataSource = main.lstBranch.ToList();

            db.AddParameterValue("@ref", this._Ref);
            dgwBranch.DataSource = db.GetDataTable("select * from StSellCampaingBranch where campaingRef=@ref ");
        }

        bool Control()
        {

            stb.Clear();

            #region Code Control
            if (!string.IsNullOrEmpty(txtCode.GetString()))
            {
                dtControl.Clear();
                db.AddParameterValue("@code", txtCode.GetString());
                dtControl = db.GetDataTable("select code from StSellCampaing where code=@code");
                if (dtControl.Rows.Count > 0)
                    codeCount = int.Parse(dtControl.Rows[0][0].ToString());
            }

            if (codeCount > 0 && this._FormMod == Enums.enmFormMod.Yeni)
                stb.AppendLine("Böyle bir kampanya kodu sistemde mevcut.");

            #endregion


            if (string.IsNullOrEmpty(txtCode.GetString()))
                stb.AppendLine("Kampanya kodu boş geçilemez.");
            else
                code = txtCode.GetString();



            if (stb.ToString().Length <= 0)
                return true;
            else return false;




        }
        #endregion

        private void FrmCampaings_Load(object sender, EventArgs e)
        {
            helper.ClearForm(this);
            SetForm();
            FillLookUp();
            if (this._FormMod == Enums.enmFormMod.Guncelle)
            {
                db.AddParameterValue("@ref", this._Ref);
                DataTable dt = db.GetDataTable("select * from StSellCampaing where Ref=@ref");
                ledType.SetValue(int.Parse(dt.Rows[0][1].ToString()));
                chkActive.SetBoolValue(bool.Parse(dt.Rows[0][2].ToString()));
                txtCode.SetString(dt.Rows[0][3].ToString());
                txtName.SetString(dt.Rows[0][4].ToString());
                dtpStart.SetDate(DateTime.Parse(dt.Rows[0][5].ToString()));
                dtpFinish.SetDate(DateTime.Parse(dt.Rows[0][6].ToString()));
                txtPropx.SetString(dt.Rows[0][7].ToString());
                txtPropy.SetString(dt.Rows[0][8].ToString());
                db.parameterDelete();

                db.AddParameterValue("@ref", this._Ref);
                DataTable dtDetail = db.GetDataTable("Select * from StSellCampaingDetail where campaingRef=@ref");
                for (int i = 0; i < dtDetail.Rows.Count; i++)
                {

                    DataRow row = dtBox.NewRow();

                    row["Ref"] = int.Parse(dtDetail.Rows[i][0].ToString());
                    row["Kampanya Ref"] = int.Parse(dtDetail.Rows[i][1].ToString());
                    row["Kart Ref"] = int.Parse(dtDetail.Rows[i][2].ToString());

                    db.AddParameterValue("@ref", dtDetail.Rows[i][2].ToString());
                    DataTable dtStock = db.GetDataTable("select code,name from StStockCard where Ref=@ref");
                    row["Kart Kodu"] = (dtStock.Rows[0][0].ToString());
                    row["Kart Adı"] = (dtStock.Rows[0][1].ToString());

                    db.AddParameterValue("@barcode", dtDetail.Rows[i][3].ToString());
                    DataTable dtBarcode = db.GetDataTable("select color,size from StStockCardBarcodes where barcode=@barcode");
                    row["Renk"] = (dtBarcode.Rows[0][0].ToString());
                    row["Beden"] = (dtBarcode.Rows[0][1].ToString());

                    row["Barkod"] = (dtDetail.Rows[i][3].ToString());
                    dtBox.Rows.Add(row);
                }
                dgwGrid.DataSource = dtBox;
                grdGrid.RefreshData();

            }
            c.StateStabil(this);
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (Control())
                {
                    db.AddParameterValue("@ref", this._Ref);
                    db.AddParameterValue("@type", ledType.GetValue());
                    db.AddParameterValue("@active", chkActive.GetBoolValue());
                    db.AddParameterValue("@code", txtCode.GetString());
                    db.AddParameterValue("@name", txtName.GetString());
                    db.AddParameterValue("@start", dtpStart.GetDate(), SqlDbType.Date);
                    db.AddParameterValue("@finish", dtpFinish.GetDate(), SqlDbType.Date);
                    db.AddParameterValue("@x", decimal.Parse(txtPropx.GetString()), SqlDbType.Decimal);
                    db.AddParameterValue("@y", decimal.Parse(txtPropy.GetString()), SqlDbType.Decimal);
                    db.RunCommand("sp_SellCampaing", CommandType.StoredProcedure);
                    db.parameterDelete();

                    if (this._FormMod == Enums.enmFormMod.Yeni)
                        this._Ref = int.Parse(db.GetScalarValue("select MAX(ref) from StSellCampaing").ToString());


                    for (int a = 0; a < grdGrid.RowCount - 1; a++)
                    {
                        if (string.IsNullOrEmpty(grdGrid.GetRowCellValue(a, "Ref").ToString()))
                            REf = 0;
                        else
                            REf = int.Parse(grdGrid.GetRowCellValue(a, "Ref").ToString());

                        db.AddParameterValue("@ref", REf);
                        db.AddParameterValue("@campaingRef", this._Ref);
                        db.AddParameterValue("@cardRef", grdGrid.GetRowCellValue(a, "Kart Ref"));
                        db.AddParameterValue("@barcode", grdGrid.GetRowCellValue(a, "Barkod"));
                        db.RunCommand("sp_CampaingDetails", CommandType.StoredProcedure);
                        db.parameterDelete();
                    }

                    for (int i = 0; i < grdBranch.RowCount - 1; i++)
                    {
                        if (string.IsNullOrEmpty(grdBranch.GetRowCellValue(i, "Ref").ToString()))
                            REf = 0;
                        else
                            REf = int.Parse(grdBranch.GetRowCellValue(i, "Ref").ToString());

                        db.AddParameterValue("@ref", REf);
                        db.AddParameterValue("@campaingRef", this._Ref);
                        db.AddParameterValue("@branchRef", grdBranch.GetRowCellValue(i, "branchRef"));
                        db.RunCommand("sp_SellCampaingBranch", CommandType.StoredProcedure);
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

        private void btnEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void getListCode(object sender, ButtonPressedEventArgs e)
        {
            helper.GetCode("StSellCampaing", "code", this, txtCode, 2000);
        }

        private void riBtnStockCode_Click(object sender, EventArgs e)
        {
            Stock.FrmBarcodeList list = new Stock.FrmBarcodeList();
            list.gelen = "Campaing";
            list.ShowDialog();
        }

        private void grdBranch_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            pmBranch.ShowPopup(Cursor.Position);
        }

        private void bbiBranchDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
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
                            db.RunCommand("delete from StSellCampaingBranch where Ref=@Ref");
                        }
                        XtraMessageBox.Show("İşlem başarıyla tamamlandı.", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    if (row[0].ToString() != "0")
                    grdBranch.DeleteRow(grdBranch.FocusedRowHandle);
            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
            }
        }

        private void grdGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6 && grdGrid.FocusedColumn.ToString() == "Kart Kodu")
            {
                Stock.FrmBarcodeList list = new Stock.FrmBarcodeList();
                list.gelen = "Campaing";
                list.ShowDialog();
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
                        db.RunCommand("delete from StSellCampaingDetail where Ref=@Ref");

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
    }
}