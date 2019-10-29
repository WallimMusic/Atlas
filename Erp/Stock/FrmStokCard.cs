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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using System.Drawing.Imaging;

namespace Erp.Stock
{
    public partial class FrmStokCard : AtlasForm
    {
        public FrmStokCard()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelRibbon(ribbonControl1);
            AtlasCompanent.Navbar(navBar);
            AtlasCompanent.TemelGrid(grdBarcode);
            AtlasCompanent.TemelGrid(grdColorSize);
            AtlasCompanent.TemelGrid(grdUnit);
            AtlasCompanent.TemelGrid(grdFolder);



            grdColorSize.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            grdBarcode.OptionsBehavior.Editable = false;
            grdBarcode.OptionsView.NewItemRowPosition = NewItemRowPosition.None;

            grdFolder.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            grdFolder.OptionsBehavior.Editable = false;

            // get stock code when txtCode's button clicked

            txtCode.flaButtonEdit.ButtonClick += GetStockCode;
            dtpStart.flashDate.EditValueChanged += SetNextDate;
            ledBrand.flaLookUp.EditValueChanged += LoadModelsWithBrand;

            #region Button Edit

            btnClass1.flaButtonEdit.Tag = "1";
            btnClass2.flaButtonEdit.Tag = "2";
            btnClass3.flaButtonEdit.Tag = "3";
            btnClass4.flaButtonEdit.Tag = "4";
            btnClass5.flaButtonEdit.Tag = "5";
            btnClass6.flaButtonEdit.Tag = "6";
            btnClass7.flaButtonEdit.Tag = "7";
            btnClass8.flaButtonEdit.Tag = "8";
            btnClass9.flaButtonEdit.Tag = "9";
            btnClass10.flaButtonEdit.Tag = "10";

            btnClass1.flaButtonEdit.ButtonClick += GetClassCode;
            btnClass2.flaButtonEdit.ButtonClick += GetClassCode;
            btnClass3.flaButtonEdit.ButtonClick += GetClassCode;
            btnClass4.flaButtonEdit.ButtonClick += GetClassCode;
            btnClass5.flaButtonEdit.ButtonClick += GetClassCode;
            btnClass6.flaButtonEdit.ButtonClick += GetClassCode;
            btnClass7.flaButtonEdit.ButtonClick += GetClassCode;
            btnClass8.flaButtonEdit.ButtonClick += GetClassCode;
            btnClass9.flaButtonEdit.ButtonClick += GetClassCode;
            btnClass10.flaButtonEdit.ButtonClick += GetClassCode;

            #endregion

        }

        #region Definetions

        FrmErpMain main = (FrmErpMain)Application.OpenForms["FrmErpMain"];
        ErpManager db = new ErpManager();
        Erp.Helper helper = new Erp.Helper();
        AtlasChangeState c = new AtlasChangeState();
        AccessManager sysDb = new AccessManager();
        StringBuilder stb = new StringBuilder();
        StringBuilder stMatrice = new StringBuilder();
        DialogResult result;

        Ean13Barcode2005.Ean13 eanBarcode = new Ean13Barcode2005.Ean13();

        int REf;
        int SizeCartelaCount = 0, ColorCartelaCount = 0, SizeCartelaRef = 0, ColorCartelaRef = 0;
        int codeCount, oldCodeCount, erpCodeCount;

        int color = 0, size = 0, brand = 0, model = 0, producer = 0, season = 0, group = 0, unitRef = 0;

        string code;

        public string codeClass = "", nameClass = "";
        public int classCodeRef = 0, classDetailRef = 0;

        DataTable dtClasses = new DataTable();
        DataTable dtColor = new DataTable();
        DataTable dtSize = new DataTable();
        DataTable dtCavala = new DataTable();
        DataTable dtBarcode = new DataTable();
        DataTable dtFOlder = new DataTable();
        DataTable dtControl = new DataTable();
        DataTable dtFillFolder = new DataTable();
        #endregion

        #region Methods

        void LookUpFill()
        {
            ledColorCartela.flaLookUp.Properties.Columns.Clear();
            ledSizeCartela.flaLookUp.Properties.Columns.Clear();
            ledBrand.flaLookUp.Properties.Columns.Clear();
            ledSeason.flaLookUp.Properties.Columns.Clear();
            ledProducer.flaLookUp.Properties.Columns.Clear();
            ledModel.flaLookUp.Properties.Columns.Clear();
            ledGroup.flaLookUp.Properties.Columns.Clear();

            #region Color

            ledColorCartela.flaLookUp.Properties.ValueMember = "Ref";
            ledColorCartela.flaLookUp.Properties.DisplayMember = "name";
            ledColorCartela.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ref", Caption = "dbNo", Visible = false });
            ledColorCartela.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "code", Caption = "Kodu" });
            ledColorCartela.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "name", Caption = "Adı" });
            ledColorCartela.flaLookUp.Properties.DataSource = db.GetDataTable("select * from StStockCardColor");

            #endregion

            #region Size

            ledSizeCartela.flaLookUp.Properties.ValueMember = "Ref";
            ledSizeCartela.flaLookUp.Properties.DisplayMember = "name";
            ledSizeCartela.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ref", Caption = "dbNo", Visible = false });
            ledSizeCartela.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "code", Caption = "Kodu" });
            ledSizeCartela.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "name", Caption = "Adı" });
            ledSizeCartela.flaLookUp.Properties.DataSource = db.GetDataTable("select * from StStockCardSize");

            #endregion

            #region Brand

            ledBrand.flaLookUp.Properties.ValueMember = "Ref";
            ledBrand.flaLookUp.Properties.DisplayMember = "name";
            ledBrand.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ref", Caption = "dbNo", Visible = false });
            ledBrand.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "code", Caption = "Kodu" });
            ledBrand.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "name", Caption = "Adı" });
            ledBrand.flaLookUp.Properties.DataSource = db.GetDataTable("select * from StStockCardBrand");

            #endregion

            #region Season

            ledSeason.flaLookUp.Properties.ValueMember = "Ref";
            ledSeason.flaLookUp.Properties.DisplayMember = "name";
            ledSeason.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ref", Caption = "dbNo", Visible = false });
            ledSeason.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "code", Caption = "Kodu" });
            ledSeason.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "name", Caption = "Adı" });
            ledSeason.flaLookUp.Properties.DataSource = db.GetDataTable("select * from StStockCardSeason");

            #endregion

            #region Producer

            ledProducer.flaLookUp.Properties.ValueMember = "Ref";
            ledProducer.flaLookUp.Properties.DisplayMember = "name";
            ledProducer.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ref", Caption = "dbNo", Visible = false });
            ledProducer.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "code", Caption = "Kodu" });
            ledProducer.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "name", Caption = "Adı" });
            ledProducer.flaLookUp.Properties.DataSource = db.GetDataTable("select * from StStockCardProducer");

            #endregion

            #region Group

            ledGroup.flaLookUp.Properties.ValueMember = "Ref";
            ledGroup.flaLookUp.Properties.DisplayMember = "name";
            ledGroup.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ref", Caption = "dbNo", Visible = false });
            ledGroup.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "code", Caption = "Kodu" });
            ledGroup.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "name", Caption = "Adı" });
            ledGroup.flaLookUp.Properties.DataSource = db.GetDataTable("select * from StStockCardGroup");

            #endregion

            sysDb.AddParameterValue("@act", true);
            riLedUnit.DataSource = sysDb.GetDataTable("select * from sysUnit where active=@act");
        }

        void SetForm()
        {
            chkActive.SetBoolValue(true);
            chkActive.SetString("Aktif");
            flashCheckEdit1.SetString("Yerli Üretim");

            for (int i = 0; i < listUseModul.Items.Count; i++)
                listUseModul.SetItemCheckState(i, CheckState.Checked);

            db.AddParameterValue("@ref", this._Ref);
            bindUnit.DataSource = db.GetDataTable("select * from StStockCardUnits where cardRef=@ref");

            #region Card File
            dtFOlder.Columns.Add("Ref");
            dtFOlder.Columns.Add("cardRef");
            dtFOlder.Columns.Add("folderName");
            dtFOlder.Columns.Add("systemFolderName");
            dtFOlder.Columns.Add("folderPath");
            dtFOlder.Columns.Add("folderType");

            dtFOlder.Columns["Ref"].ColumnName = "Ref";
            dtFOlder.Columns["cardRef"].ColumnName = "cardRef";
            dtFOlder.Columns["folderName"].ColumnName = "Dosya Adı";
            dtFOlder.Columns["systemFolderName"].ColumnName = "Sistem Dosya Adı";
            dtFOlder.Columns["folderPath"].ColumnName = "Dosya Yolu";
            dtFOlder.Columns["folderType"].ColumnName = "Dosya Tipi";


            dtClasses.Columns.Add("Ref");
            dtClasses.Columns.Add("cardRef");
            dtClasses.Columns.Add("classRef");
            dtClasses.Columns.Add("tagNumber");
            dtClasses.Columns.Add("detailRef");




            //db.AddParameterValue("@ref", this._Ref);


            db.AddParameterValue("@ref", this._Ref);
            dtFillFolder = db.GetDataTable("select * from StStockCardFiles where cardRef=@ref");

            for (int t = 0; t < dtFillFolder.Rows.Count; t++)
            {
                DataRow row = dtFOlder.NewRow();
                row["Ref"] = dtFillFolder.Rows[t][0].ToString();
                row["cardRef"] = dtFillFolder.Rows[t][1].ToString();
                row["Dosya Adı"] = dtFillFolder.Rows[t][2].ToString();
                row["Sistem Dosya Adı"] = dtFillFolder.Rows[t][3].ToString();
                row["Dosya Yolu"] = dtFillFolder.Rows[t][4].ToString() + "/" + dtFillFolder.Rows[t][3].ToString();
                row["Dosya Tipi"] = dtFillFolder.Rows[t][5].ToString();
                dtFOlder.Rows.Add(row);
                grdFolder.RefreshData();
            }

            dgwFolder.DataSource = dtFOlder;
            grdFolder.Columns[0].Visible = false;
            grdFolder.Columns[1].Visible = false;


            #endregion


            #region Barcode

            dtBarcode.Columns.Clear();
            dtBarcode.Rows.Clear();
            grdBarcode.Columns.Clear();
            dgwBarcode.DataSource = null;
            dtBarcode.Columns.Add("Ref");
            dtBarcode.Columns.Add("cardRef");
            dtBarcode.Columns.Add("state", typeof(bool));
            dtBarcode.Columns.Add("CardCode");
            dtBarcode.Columns.Add("propSize");
            dtBarcode.Columns.Add("propColor");
            dtBarcode.Columns.Add("Barcode");

            dtBarcode.Columns["Ref"].ColumnName = "Ref";
            dtBarcode.Columns["cardRef"].ColumnName = "cardRef";
            dtBarcode.Columns["state"].ColumnName = "Onay";
            dtBarcode.Columns["CardCode"].ColumnName = "Kart Kodu";
            dtBarcode.Columns["propSize"].ColumnName = "Beden";
            dtBarcode.Columns["propColor"].ColumnName = "Renk";
            dtBarcode.Columns["Barcode"].ColumnName = "Barkod";

            #endregion

        }

        void CreateMatrice()
        {
            dtCavala.Columns.Clear();
            dtCavala.Rows.Clear();
            dgwColorSize.DataSource = null;
            bindCavala.DataSource = null;
            grdColorSize.Columns.Clear();

            #region Size Control
            if (string.IsNullOrEmpty(ledSizeCartela.GetValue().ToString()))
                stMatrice.AppendLine("Beden kartelası seçilmeden matris oluşturulamaz.");
            else
            {
                SizeCartelaRef = ledSizeCartela.GetValue();
                db.AddParameterValue("@ref", SizeCartelaRef);
                SizeCartelaCount = int.Parse(db.GetScalarValue("select count(*) from StStockCardSizeDetails where sizeRef=@ref").ToString());
            }


            if (SizeCartelaCount <= 0)
                stMatrice.AppendLine("Seçtiğiniz beden kartelasına ait kayıt bulunmuyor.");
            else
            {
                db.AddParameterValue("@ref", SizeCartelaRef);
                dtSize = db.GetDataTable("select propName from StStockCardSizeDetails where sizeRef = @ref");
            }
            #endregion SizeControl

            #region Color Control
            if (string.IsNullOrEmpty(ledColorCartela.GetValue().ToString()))
                stMatrice.AppendLine("Renk kartelası seçilmeden matris oluşturulamaz.");
            else
            {
                ColorCartelaRef = ledColorCartela.GetValue();
                db.AddParameterValue("@ref", ColorCartelaRef);
                ColorCartelaCount = int.Parse(db.GetScalarValue("select count(*) from StStockCardColorDetails where colorRef=@ref").ToString());
            }
            if (ColorCartelaCount <= 0)
                stMatrice.AppendLine("Seçtiğiniz renk kartelasına ait kayıt bulunmuyor.");
            else
            {
                db.AddParameterValue("@ref", ColorCartelaRef);
                dtColor = db.GetDataTable("select propColor from StStockCardColorDetails where colorRef = @ref");
            }
            #endregion

            #region Control and Create Matrice

            if (stMatrice.ToString().Length > 0)
            {
                FrmErrorForm form = new FrmErrorForm();
                form.flashMemoEdit1.SetString(stMatrice.ToString());
                form.ShowDialog();
            }
            else
            {
                dtCavala.Columns.Add("Renkler", typeof(string));


                for (int i = 0; i < dtSize.Rows.Count; i++)
                {
                    dtCavala.Columns.Add(dtSize.Rows[i][0].ToString(), typeof(bool));
                }

                for (int i = 0; i < dtColor.Rows.Count; i++)
                {
                    DataRow row = dtCavala.NewRow();
                    row["Renkler"] = dtColor.Rows[i][0].ToString();
                    dtCavala.Rows.Add(row);
                }

                bindCavala.DataSource = dtCavala;
                dgwColorSize.DataSource = dtCavala;
                grdColorSize.Columns[0].OptionsColumn.AllowEdit = false;
            }
            #endregion

        }

        void CreateBarcode()
        {
            string barcode = "";

            DataTable dt = new DataTable();
            dtBarcode.Rows.Clear();
            foreach (GridColumn column in grdColorSize.VisibleColumns)
            {
                dt.Columns.Add(column.FieldName, column.ColumnType);
            }
            for (int i = 0; i < grdColorSize.DataRowCount; i++)
            {
                DataRow row = dt.NewRow();
                foreach (GridColumn column in grdColorSize.VisibleColumns)
                {
                    row[column.FieldName] = grdColorSize.GetRowCellValue(i, column);
                }
                dt.Rows.Add(row);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Rows[i][j].ToString() == "True")
                    {

                        //int pCode = 0;
                        //eanBarcode.CountryCode = "90";

                        //sysDb.AddParameterValue("@ref", main.firmRef);
                        //string fCode = sysDb.GetScalarValue("select code from sysFirm where Ref=@ref").ToString();


                        //pCode = int.Parse(txtCode.GetString().ToString()) + int.Parse((j + 1).ToString()) + int.Parse((i + 1).ToString());
                        //eanBarcode.ProductCode = pCode.ToString();

                        //eanBarcode.ChecksumDigit = "5";
                        //barcode = eanBarcode.CountryCode + fCode + pCode + eanBarcode.ChecksumDigit;
                        barcode = "869" + "123" + (j + 1).ToString() + txtCode.GetString() + (i + 1).ToString();
                        //for (int k = 0; k < grdBarcode.RowCount; k++)
                        //{
                        //    string gridBarcode = grdBarcode.GetRowCellValue(k, "Barkod").ToString();
                        //    if (!string.IsNullOrEmpty(gridBarcode) && gridBarcode != barcode)
                        //    {
                        DataRow row = dtBarcode.NewRow();

                        row["Ref"] = null;
                        row["cardRef"] = null;
                        row["Onay"] = true;
                        row["Kart Kodu"] = txtCode.GetString();
                        row["Beden"] = dt.Columns[j].Caption.ToString();
                        row["Renk"] = dt.Rows[i][0].ToString();
                        row["Barkod"] = barcode.ToString();
                        dtBarcode.Rows.Add(row);
                        //    }
                        //}

                    }
                }
            }

            dgwBarcode.DataSource = dtBarcode;
            grdBarcode.BestFitColumns();
            grdBarcode.Columns[0].Visible = false;
            grdBarcode.Columns[1].Visible = false;
        }

        void DeleteLine(GridView grd, string sql)
        {
            try
            {
                if (grd.RowCount > 0 && grd.FocusedRowHandle != -1)
                {
                    System.Data.DataRow row = grd.GetDataRow(grd.FocusedRowHandle);


                    if (!string.IsNullOrEmpty(row[0].ToString()) && row[0].ToString() != "0")
                    {
                        result = XtraMessageBox.Show("Seçili kaydı silmek istediğinize emin misiniz?\n\rKaydet işlemi yapılmadan son düzenlemeler geçerli olmayacaktır.", "Soru?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            REf = int.Parse(row[0].ToString());
                            db.AddParameterValue("@Ref", REf);
                            db.RunCommand(sql + " where Ref=@Ref");
                            string path = row[4].ToString() + row[3].ToString();
                            File.Delete(path);
                            grd.DeleteRow(grd.FocusedRowHandle);


                        }
                    }
                    else
                        if (row[0].ToString() != "0")
                        grd.DeleteRow(grd.FocusedRowHandle);
                }
            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
            }
        }

        bool Control()
        {

            stb.Clear();

            #region Code Control
            if (!string.IsNullOrEmpty(txtCode.GetString()))
            {
                dtControl.Clear();
                db.AddParameterValue("@code", txtCode.GetString());
                dtControl = db.GetDataTable("select code from StStockCard where code=@code");
                if (dtControl.Rows.Count > 0)
                    codeCount = int.Parse(dtControl.Rows[0][0].ToString());
            }

            if (codeCount > 0 && _FormMod == Enums.enmFormMod.Yeni)
                stb.AppendLine("Böyle bir stok kodu sistemde mevcut.");

            if (!string.IsNullOrEmpty(txtOldCode.GetString()))
            {
                dtControl.Clear();
                db.AddParameterValue("@code", txtCode.GetString());
                dtControl = db.GetDataTable("select oldCardCode from StStockCard where oldCardCode=@code");
                if (dtControl.Rows.Count > 0)
                    oldCodeCount = int.Parse(dtControl.Rows[0][0].ToString());
            }

            if (oldCodeCount > 0 && this._FormMod == Enums.enmFormMod.Yeni)
                stb.AppendLine("Böyle bir eski stok kodu sistemde mevcut.");

            if (!string.IsNullOrEmpty(txtLogoCode.GetString()))
            {
                dtControl.Clear();
                db.AddParameterValue("@code", txtCode.GetString());
                dtControl = db.GetDataTable("select erpCode from StStockCard where erpCode=@code");
                if (dtControl.Rows.Count > 0)
                    erpCodeCount = int.Parse(dtControl.Rows[0][0].ToString());
            }

            if (oldCodeCount > 0 && this._FormMod == Enums.enmFormMod.Yeni)
                stb.AppendLine("Böyle bir erp stok kodu sistemde mevcut.");
            #endregion


            if (string.IsNullOrEmpty(txtCode.GetString()))
                stb.AppendLine("Stok kodu boş geçilemez.");
            else
                code = txtCode.GetString();

            #region Look Up Control

            if (ledBrand.GetValue() > 0 && !string.IsNullOrEmpty(ledBrand.GetValue().ToString()))
                brand = ledBrand.GetValue();

            if (ledColorCartela.GetValue() > 0 && !string.IsNullOrEmpty(ledColorCartela.GetValue().ToString()))
                color = ledColorCartela.GetValue();

            if (ledGroup.GetValue() > 0 && !string.IsNullOrEmpty(ledGroup.GetValue().ToString()))
                group = ledGroup.GetValue();

            if (ledModel.GetValue() > 0 && !string.IsNullOrEmpty(ledModel.GetValue().ToString()))
                model = ledModel.GetValue();

            if (ledProducer.GetValue() > 0 && !string.IsNullOrEmpty(ledProducer.GetValue().ToString()))
                producer = ledProducer.GetValue();

            if (ledSeason.GetValue() > 0 && !string.IsNullOrEmpty(ledSeason.GetValue().ToString()))
                season = ledSeason.GetValue();

            if (ledSizeCartela.GetValue() > 0 && !string.IsNullOrEmpty(ledSizeCartela.GetValue().ToString()))
                size = ledSizeCartela.GetValue();

            #endregion

            if (stb.ToString().Length <= 0)
                return true;
            else return false;




        }

        #endregion

        #region Popup menu events

        private void grdUnit_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            try
            {
                pmUnit.ShowPopup(Cursor.Position);
            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
            }

        }

        private void btnDeleteUnitLine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DeleteLine(grdUnit, "delete from StStockCardUnits");
            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
            }
        }

        private void btnDeleteBarcode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DeleteLine(grdUnit, "delete from StStockCardUnits");
            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
            }
        }

        private void grdBarcode_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                pmBarcode.ShowPopup(MousePosition);
            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
            }
        }

        private void grdFolder_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            pmFolder.ShowPopup(Cursor.Position);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < dtClasses.Rows.Count; i++)
            {
                for (int a = 0; a < dtClasses.Columns.Count; a++)
                {
                    MessageBox.Show(dtClasses.Rows[i][a].ToString());
                }
            }
        }

        private void btnEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {



            //try
            //{
            if (Control() && this._FormMod != Enums.enmFormMod.Goruntule)
            {

                #region Card
                db.AddParameterValue("@ref", this._Ref);
                db.AddParameterValue("@code", code);
                db.AddParameterValue("@active", chkActive.GetBoolValue());
                db.AddParameterValue("@name", txtName.GetString());
                db.AddParameterValue("@desc", txtDesc.GetString());
                db.AddParameterValue("@oldCode", txtOldCode.GetString());
                db.AddParameterValue("@erpCode", txtLogoCode.GetString());
                db.AddParameterValue("@start", dtpStart.GetDate().ToShortDateString(), SqlDbType.Date);
                db.AddParameterValue("@finish", dtpFinish.GetDate().ToShortDateString(), SqlDbType.Date);
                db.AddParameterValue("@colorLot", color);
                db.AddParameterValue("@sizeLot", size);
                db.AddParameterValue("@brandRef", brand);
                db.AddParameterValue("@modelRef", model);
                db.AddParameterValue("@producerRef", producer);
                db.AddParameterValue("@seasonRef", season);
                db.AddParameterValue("@groupRef", group);
                db.AddParameterValue("@local", flashCheckEdit1.GetBoolValue());
                db.RunCommand("sp_StockCard", CommandType.StoredProcedure);
                db.parameterDelete();


                #endregion

                if (_FormMod == Enums.enmFormMod.Yeni)
                    this._Ref = int.Parse(db.GetScalarValue("select MAX(ref) from StStockCard").ToString());

                #region Modul

                string selectedModul = "";
                for (int a = 0; a < listUseModul.CheckedItems.Count; a++)
                {
                    int modulRef = 0;
                    selectedModul = listUseModul.Items[a].ToString();

                    db.AddParameterValue("@smodul", selectedModul);
                    DataTable dt = db.GetDataTable("select * from StStockCardModul where Modul=@Smodul");
                    if (dt.Rows.Count > 0)
                        modulRef = int.Parse(dt.Rows[0][0].ToString());

                    db.AddParameterValue("@ref", modulRef);
                    db.AddParameterValue("@cardRef", this._Ref);
                    db.AddParameterValue("@modul", selectedModul);
                    db.AddParameterValue("@state", true);

                    db.RunCommand("sp_StockCardModul", CommandType.StoredProcedure);
                }

                #endregion

                #region Unit

                int lenght = 0, weight = 0, width = 0, desi = 0;

                //for (int i = 0; i < grdUnit.RowCount - 1; i++)
                //{
                //    if (string.IsNullOrEmpty(grdUnit.GetRowCellValue(i, "Ref").ToString()))
                //        REf = 0;
                //else
                //    REf = int.Parse(grdUnit.GetRowCellValue(i, "Ref").ToString());


                //unitRef = int.Parse(grdUnit.GetRowCellValue(i, "unitRef").ToString());
                //lenght = int.Parse(grdUnit.GetRowCellValue(i, "lenght").ToString());
                //weight = int.Parse(grdUnit.GetRowCellValue(i, "weight").ToString());
                //width = int.Parse(grdUnit.GetRowCellValue(i, "width").ToString());
                //desi = int.Parse(grdUnit.GetRowCellValue(i, "desi").ToString());

                unitRef = 1;
                lenght = 0;
                weight = 0;
                width = 0;
                desi = 0;
                code = "Adet";

                db.AddParameterValue("@ref", REf);
                db.AddParameterValue("@cardRef", this._Ref);
                db.AddParameterValue("@unitRef", unitRef);
                db.AddParameterValue("@code", code);
                db.AddParameterValue("@lenght", lenght);
                db.AddParameterValue("@weight", weight);
                db.AddParameterValue("@width", width);
                db.AddParameterValue("@desi", desi);
                db.RunCommand("sp_StockCardUnit", CommandType.StoredProcedure);
                db.parameterDelete();
                sysDb.parameterDelete();

                //}

                #endregion

                #region Barcode and Color

                string cardCode = "", BarcodeSize = "", BarcodeColor = "", barcode = "";
                for (int j = 0; j < grdBarcode.RowCount; j++)
                {
                    if (string.IsNullOrEmpty(grdBarcode.GetRowCellValue(j, "Ref").ToString()))
                        REf = 0;
                    else
                        REf = int.Parse(grdBarcode.GetRowCellValue(j, "Ref").ToString());



                    BarcodeSize = grdBarcode.GetRowCellValue(j, "Beden").ToString();
                    BarcodeColor = grdBarcode.GetRowCellValue(j, "Renk").ToString();
                    barcode = grdBarcode.GetRowCellValue(j, "Barkod").ToString();

                    cardCode = txtCode.GetString();
                    db.AddParameterValue("@ref", REf);
                    db.AddParameterValue("@cardRef", this._Ref);
                    db.AddParameterValue("@cardCode", cardCode);
                    db.AddParameterValue("@size", BarcodeSize);
                    db.AddParameterValue("@color", BarcodeColor);
                    db.AddParameterValue("@barcode", barcode);
                    db.RunCommand("sp_StockCardBarcode", CommandType.StoredProcedure);
                    db.parameterDelete();


                }




                #endregion

                #region File

                string foldername = "", sysName = "", path = "", type = "";
                for (int k = 0; k < grdFolder.RowCount; k++)
                {
                    if (string.IsNullOrEmpty(grdFolder.GetRowCellValue(k, "Ref").ToString()))
                        REf = 0;
                    else
                        REf = int.Parse(grdFolder.GetRowCellValue(k, "Ref").ToString());

                    foldername = grdFolder.GetRowCellValue(k, "Dosya Adı").ToString();
                    sysName = grdFolder.GetRowCellValue(k, "Sistem Dosya Adı").ToString();
                    path = grdFolder.GetRowCellValue(k, "Dosya Yolu").ToString();

                    type = grdFolder.GetRowCellValue(k, "Dosya Tipi").ToString();

                    db.AddParameterValue("@ref", REf);
                    db.AddParameterValue("@cardRef", this._Ref);
                    db.AddParameterValue("@name", foldername);
                    db.AddParameterValue("@sysName", sysName);
                    db.AddParameterValue("@path", path, SqlDbType.NVarChar, -1);
                    db.AddParameterValue("@type", type);
                    db.RunCommand("sp_StockCardFile", CommandType.StoredProcedure);

                    if (!string.IsNullOrEmpty(path))
                    {
                        string location = @"\Images\Stock\" + txtCode.GetString() + "\\";
                        string goal = Application.StartupPath + location;
                        if (!File.Exists(goal))
                            Directory.CreateDirectory(goal);

                        if (!File.Exists(goal + sysName))
                        {
                            File.Copy(path, goal + sysName);

                            db.AddParameterValue("@ref", this._Ref);
                            db.AddParameterValue("@path", goal, SqlDbType.NVarChar, -1);
                            db.RunCommand("update StStockCardFiles set folderPath=@path where cardRef=@ref");
                        }

                    }



                    db.parameterDelete();
                }


                #endregion

                #region Class

                if (dtClasses.Rows.Count > 0)
                {
                    for (int i = 0; i < dtClasses.Rows.Count; i++)

                    {
                        db.AddParameterValue("@Ref", dtClasses.Rows[i]["Ref"].ToString());
                        db.AddParameterValue("@cardRef", REf);
                        db.AddParameterValue("@classRef", dtClasses.Rows[i]["classRef"].ToString());
                        db.AddParameterValue("@detailRef", dtClasses.Rows[i]["detailRef"].ToString());
                        db.AddParameterValue("@tagNumber", dtClasses.Rows[i]["tagNumber"].ToString());
                        db.RunCommand("sp_StockCardClassRowDetail", CommandType.StoredProcedure);
                    }
                }


                #endregion

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



            //}
            //catch (Exception ex)
            //{
            //    helper.WriteLog(ex);
            //    db.parameterDelete();
            //}
        }

        private void btnEscape_ItemDoubleClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnFolderAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Jpg Dosyası |*.jpg| Png Dosyası|*.png";
                ofd.Title = "Resim Dosyası Seçiniz..";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = ofd.FileName;
                    string folderName = ofd.SafeFileName;
                    string[] words = folderPath.Split('.');
                    string fileType = words[1].ToString();
                    string guid = Guid.NewGuid().ToString();
                    string systemName = guid + "." + fileType;


                    DataRow row = dtFOlder.NewRow();
                    row["Ref"] = null;
                    row["cardRef"] = null;
                    row["Dosya Adı"] = folderName;
                    row["Sistem Dosya Adı"] = systemName;
                    row["Dosya Yolu"] = folderPath;
                    row["Dosya Tipi"] = fileType;
                    dtFOlder.Rows.Add(row);
                    grdFolder.RefreshData();
                    grdFolder.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
            }


        }

        private void btnFolderDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DeleteLine(grdFolder, "delete from StStockCardFiles");
            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
            }

        }

        private void btnFolderOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //try
            //{
            System.Data.DataRow row = grdFolder.GetDataRow(grdFolder.FocusedRowHandle);
            if (!string.IsNullOrEmpty(row[4].ToString()))
            {
                if (row[5].ToString() != "pdf")
                {
                    FrmShowImage image = new FrmShowImage();
                    string path = row[4].ToString() + row[3].ToString();
                    image.pictureEdit1.Image = Image.FromFile(path);
                    image.ShowDialog();
                }
                if (row[5].ToString() == "pdf")
                {
                    FrmPdfViewer viewer = new FrmPdfViewer();
                    viewer.pdfViewer1.LoadDocument(row[4].ToString() + row[3].ToString());
                    viewer.ShowDialog();
                }
            }
            else
            {
                XtraMessageBox.Show("Seçili bir dosya yok veya seçili dosyanın yolu belirtilmemiş.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //}
            //catch (Exception ex)
            //{
            //    helper.WriteLog(ex);
            //}

        }

        #endregion

        #region Others Event

        private void GetClassCode(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit btn = (ButtonEdit)sender;

            int no = int.Parse(btn.Tag.ToString());

            db.AddParameterValue("@no", no);
            int classRef = int.Parse(db.GetScalarValue("select Ref from StStockCardClass where no=@no").ToString());

            db.AddParameterValue("@ref", classRef);
            db.AddParameterValue("@status", true);
            int count = int.Parse(db.GetScalarValue("SELECT Count(*) FROM StStockCardClassDetail where classRef=@ref and status=@status").ToString());
            Tools.FrmClassDetailList list = new Tools.FrmClassDetailList();
            if (count > 0)
            {

                list._Ref = classRef;
                list.ShowDialog();
            }
            else
                XtraMessageBox.Show("Bu sınıfa ait bir alt özellik mevcut değil.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            DataRow drClassRef;
            DataRow drDetailRef;
            if (list.DialogResult == DialogResult.OK)
            {
                foreach (Control item in tableLayoutPanel1.Controls)
                {
                    if (item is Label)
                    {
                        if (item.Tag != null)
                            if (item.Tag.ToString() == btn.Tag.ToString())
                            {
                                item.Text = nameClass;
                                //drClassRef
                            }


                    }
                    else if (item is AtlasButtonEdit)
                    {
                        AtlasButtonEdit b = item as AtlasButtonEdit;
                        if (item.Tag != null)
                            if (item.Tag.ToString() == btn.Tag.ToString())
                                b.SetString(codeClass);

                        int selectedRef = 0;
                        if (item.Tag != null && !string.IsNullOrEmpty(b.GetString()) && item.Tag.ToString() == btn.Tag.ToString())
                        {

                            int tagNo = int.Parse(item.Tag.ToString());

                            db.AddParameterValue("@tagNo", tagNo);
                            classCodeRef = int.Parse(db.GetScalarValue("select Ref from StStockCardClass where no=@tagNo").ToString());

                            for (int i = 0; i < dtClasses.Rows.Count; i++)
                            {
                                if (!string.IsNullOrEmpty(dtClasses.Rows[i]["tagNumber"].ToString()))
                                    selectedRef = int.Parse(dtClasses.Rows[i]["Ref"].ToString());
                            }

                            DataRow classRow = dtClasses.NewRow();
                            classRow["Ref"] = selectedRef;
                            classRow["cardRef"] = REf;
                            classRow["classRef"] = classCodeRef;
                            classRow["tagNumber"] = tagNo;
                            classRow["detailRef"] = classDetailRef;
                            dtClasses.Rows.Add(classRow);
                        }
                    }
                }

            }

        }

        private void GetStockCode(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                helper.GetCode("stStockCard", "code", this, txtCode, 10000);
            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
            }

        }

        private void SetNextDate(object sender, EventArgs e)
        {
            try
            {
                DateTime date = dtpStart.GetDate().AddYears(5);
                dtpFinish.SetDate(date);

            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
            }

        }

        private void LoadModelsWithBrand(object sender, EventArgs e)
        {
            #region Producer

            try
            {
                ledModel.flaLookUp.Properties.ValueMember = "Ref";
                ledModel.flaLookUp.Properties.DisplayMember = "name";
                ledModel.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ref", Caption = "dbNo", Visible = false });
                ledModel.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "code", Caption = "Kodu" });
                ledModel.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "name", Caption = "Adı" });
                db.AddParameterValue("@ref", ledBrand.GetValue());
                ledModel.flaLookUp.Properties.DataSource = db.GetDataTable("select * from StStockCardModel where brandRef=@ref");


            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
            }



            #endregion
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CreateBarcode();
            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
            }

        }

        private void FrmStokCard_Load(object sender, EventArgs e)
        {
            try
            {
                c.DoActive(this);
                SetForm();
                LookUpFill();
                if (this._FormMod == Enums.enmFormMod.Guncelle || this._FormMod == Enums.enmFormMod.Goruntule)
                {
                    db.AddParameterValue("@ref", this._Ref);
                    DataTable dtFillStock = db.GetDataTable("select * from StStockCard where Ref=@ref");
                    chkActive.SetBoolValue(bool.Parse(dtFillStock.Rows[0][1].ToString()));
                    txtCode.SetString(dtFillStock.Rows[0][2].ToString());
                    txtCode.Enabled = false;
                    txtName.SetString(dtFillStock.Rows[0][3].ToString());
                    txtDesc.SetString(dtFillStock.Rows[0][4].ToString());
                    txtOldCode.SetString(dtFillStock.Rows[0][5].ToString());
                    txtLogoCode.SetString(dtFillStock.Rows[0][6].ToString());
                    dtpStart.SetDate(DateTime.Parse(dtFillStock.Rows[0][7].ToString()));
                    dtpFinish.SetDate(DateTime.Parse(dtFillStock.Rows[0][8].ToString()));


                    if (dtFillStock.Rows[0][9].ToString() != "0" && dtFillStock.Rows[0][10].ToString() != "0")
                    {
                        ledColorCartela.Enabled = false;
                        ledColorCartela.SetValue(int.Parse(dtFillStock.Rows[0][9].ToString()));

                        ledSizeCartela.Enabled = false;
                        ledSizeCartela.SetValue(int.Parse(dtFillStock.Rows[0][10].ToString()));

                        CreateMatrice();

                        db.AddParameterValue("@ref", this._Ref);
                        DataTable dtDoCheck = db.GetDataTable("select * from StStockCardBarcodes where cardRef=@ref");

                        for (int m = 0; m < dtDoCheck.Rows.Count; m++)
                        {
                            for (int q = 0; q < dtCavala.Columns.Count; q++)
                            {
                                if (dtDoCheck.Rows[m][3].ToString() == dtCavala.Columns[q].Caption.ToString())
                                {
                                    for (int y = 0; y < dtCavala.Rows.Count; y++)
                                    {
                                        if (dtDoCheck.Rows[m][4].ToString() == dtCavala.Rows[y][0].ToString())
                                        {
                                            grdColorSize.SetRowCellValue(y, grdColorSize.Columns[q], true);
                                        }
                                    }

                                }
                            }
                        }
                        CreateBarcode();
                    }

                    if (dtFillStock.Rows[0][11].ToString() != "0")
                        ledBrand.SetValue(int.Parse(dtFillStock.Rows[0][11].ToString()));
                    if (dtFillStock.Rows[0][12].ToString() != "0")
                        ledModel.SetValue(int.Parse(dtFillStock.Rows[0][12].ToString()));
                    if (dtFillStock.Rows[0][13].ToString() != "0")
                        ledProducer.SetValue(int.Parse(dtFillStock.Rows[0][13].ToString()));
                    if (dtFillStock.Rows[0][14].ToString() != "0")
                        ledSeason.SetValue(int.Parse(dtFillStock.Rows[0][14].ToString()));
                    if (dtFillStock.Rows[0][15].ToString() != "0")
                        ledGroup.SetValue(int.Parse(dtFillStock.Rows[0][15].ToString()));

                    flashCheckEdit1.SetBoolValue(bool.Parse(dtFillStock.Rows[0][16].ToString()));


                    if (this._FormMod == Enums.enmFormMod.Goruntule)
                        c.DoDisable(this);
                }

                DataTable dtClass = db.GetDataTable("select * from StStockCardClass");
                for (int i = 0; i < dtClass.Rows.Count; i++)
                {
                    foreach (Control item in tableLayoutPanel1.Controls)
                    {
                        if (item.Tag != null)
                        {
                            if (item.Tag.ToString() == "0" + dtClass.Rows[i]["no"].ToString())
                            {
                                item.Text = dtClass.Rows[i]["name"].ToString() + ":";
                            }
                        }
                    }
                }

                db.AddParameterValue("@cardRef", this._Ref);
                dtClasses = db.GetDataTable("select * from StStockCardClassRowDetail where cardRef=@cardRef");

                for (int x = 0; x < dtClasses.Rows.Count; x++)
                {
                    foreach (Control item in tableLayoutPanel1.Controls)
                    {
                        if (item is Label)
                        {
                            if (item.Tag != null)
                                if (item.Tag.ToString() == dtClasses.Rows[x]["tagNumber"].ToString())
                                {
                                    string text = "";
                                    db.AddParameterValue("@cRef", dtClasses.Rows[x]["classRef"].ToString());
                                    db.AddParameterValue("@dRef", dtClasses.Rows[x]["detailRef"].ToString());
                                    text = db.GetScalarValue("select name from StStockCardClassDetail where classRef=@cRef and Ref=@dRef").ToString();
                                    item.Text = text;
                                }

                        }
                        else if (item is AtlasButtonEdit)
                        {
                            AtlasButtonEdit b = item as AtlasButtonEdit;
                            if (item.Tag != null)
                                if (item.Tag.ToString() == dtClasses.Rows[x]["tagNumber"].ToString())
                                {
                                    string text = "";
                                    db.AddParameterValue("@cRef", dtClasses.Rows[x]["classRef"].ToString());
                                    db.AddParameterValue("@dRef", dtClasses.Rows[x]["detailRef"].ToString());
                                    text = db.GetScalarValue("select code from StStockCardClassDetail where classRef=@cRef and Ref=@dRef").ToString();
                                    b.SetString(text);
                                }
                        }
                    }
                }


                c.StateStabil(this);
            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
            }

        }

        private void btnCreateMatrice_Click(object sender, EventArgs e)
        {
            try
            {
                CreateMatrice();
            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
            }

        }

    }
}