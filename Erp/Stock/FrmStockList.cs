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
using System.Data.SqlClient;

namespace Erp.Stock
{
    public partial class FrmStockList : AtlasForm
    {
        public FrmStockList()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelRibbon(ribbonControl1);
            AtlasCompanent.TemelGrid(grdStock);
            AtlasCompanent.TemelGrid(grdWhouse);
            AtlasCompanent.TemelGrid(grdMove);

            grdStock.OptionsBehavior.Editable = false;
            grdStock.OptionsView.ShowAutoFilterRow = true;
            grdStock.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            grdWhouse.OptionsBehavior.Editable = false;
            grdWhouse.OptionsView.ShowAutoFilterRow = true;
            grdWhouse.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            grdMove.OptionsBehavior.Editable = false;
            grdMove.OptionsView.ShowAutoFilterRow = true;
            grdMove.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            this.MaximizeBox = true;
        }

        ErpManager db = new ErpManager();
        DataTable dt = new DataTable();
        SaveFileDialog sfd = new SaveFileDialog();

        FrmErpMain f = (FrmErpMain)Application.OpenForms["FrmErpMain"];
        #region Methods
        void FillData()
        {


            dt = db.GetDataTable("select * from Stock_Cards");
            if (dt != null)
            {
                dgwStock.DataSource = dt;
                grdStock.Columns["Ref"].Visible = false;
                grdStock.BestFitColumns();
            }

        }

        void Add()
        {
            FrmStokCard newForm = new FrmStokCard();
            newForm._Ref = 0;
            newForm._FormMod = Enums.enmFormMod.Yeni;
            newForm.Text = "Yeni Stok Kartı";

            newForm.MdiParent = FrmErpMain.ActiveForm;
            newForm.Show();

            if (newForm.DialogResult == DialogResult.OK)
                FillData();
        }

        void Show()
        {
            try
            {
                if (grdStock.RowCount > 0)
                {
                    if (grdStock.FocusedRowHandle != -1 && !string.IsNullOrEmpty(grdStock.GetFocusedRowCellValue("Ref").ToString()))
                    {
                        FrmStokCard newForm = new FrmStokCard();
                        newForm._Ref = int.Parse(grdStock.GetFocusedRowCellValue("Ref").ToString());
                        newForm._MenuNo = this._MenuNo;
                        newForm._FormMod = Enums.enmFormMod.Goruntule;
                        newForm.ShowDialog();
                    }
                }
            }
            catch (Exception)
            {

            }

        }

        void Update()
        {

            //tr1y
            //{
            if (grdStock.RowCount > 0)
                if (grdStock.FocusedRowHandle != -1 && !string.IsNullOrEmpty(grdStock.GetFocusedRowCellValue("Ref").ToString()))
                {

                    FrmStokCard newForm = new FrmStokCard();
                    newForm._Ref = int.Parse(grdStock.GetFocusedRowCellValue("Ref").ToString());
                    newForm._MenuNo = this._MenuNo;
                    newForm._FormMod = Enums.enmFormMod.Guncelle;
                    newForm.Text = grdStock.GetFocusedRowCellValue("Stok Kodu").ToString() + " adlı Stok Kartı";
                    f.Viewchild(newForm);
                    if (newForm.DialogResult == DialogResult.OK)
                        FillData();
                }


            //}
            //catch (Exception)
            //{
            //}

        }

        #endregion

        #region Export

        private void bbixls_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sfd.Filter = "Excel Dosyası (*.xls)|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
                grdStock.ExportToXls(sfd.FileName);

            sfd.Reset();
        }

        private void bbixlsx_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sfd.Filter = "Excel Dosyası (*.xlsx)|*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
                grdStock.ExportToXlsx(sfd.FileName);

            sfd.Reset();
        }

        private void bbipdf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sfd.Filter = "Pdf Dosyası (*.pdf)|*.pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
                grdStock.ExportToPdf(sfd.FileName);

            sfd.Reset();
        }

        private void bbidoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sfd.Filter = "Word Dosyası (*.rtf)|*.rtf";
            if (sfd.ShowDialog() == DialogResult.OK)
                grdStock.ExportToRtf(sfd.FileName);

            sfd.Reset();
        }

        #endregion

        private void FrmStockList_Load(object sender, EventArgs e)
        {
            bbiAdd.Enabled = true;
            bbiChange.Enabled = true;
            bbiInfo.Enabled = true;
            bbiDelete.Enabled = true;


            if (this._add == false)
                bbiAdd.Enabled = false;
            if (!this._update)
                bbiChange.Enabled = false;
            if (!this._show)
                bbiInfo.Enabled = false;
            if (!this._delete)
                bbiInfo.Enabled = false;

            FillData();
        }

        private void bbiAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Add();
        }

        private void bbiGruplama_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdStock.OptionsView.ShowGroupPanel == true)
                grdStock.OptionsView.ShowGroupPanel = false;
            else
                grdStock.OptionsView.ShowGroupPanel = true;
        }

        private void bbiFiltreleme_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdStock.OptionsView.ShowAutoFilterRow == true)
                grdStock.OptionsView.ShowAutoFilterRow = false;
            else
                grdStock.OptionsView.ShowAutoFilterRow = true;
        }

        private void bbiFiltreTemizle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdStock.OptionsFilter.Reset();
        }

        private void bbiChange_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Update();
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdStock.RowCount > 0)
                if (grdStock.FocusedRowHandle != -1 && !string.IsNullOrEmpty(grdStock.GetFocusedRowCellValue("Ref").ToString()))
                {

                    int Ref = int.Parse(grdStock.GetFocusedRowCellValue("Ref").ToString());
                    string stockName = grdStock.GetFocusedRowCellValue("Stok Adı").ToString();
                    DialogResult answer;
                    answer = XtraMessageBox.Show(stockName + " adlı ürünü pasife çekmek istediğinize emin misiniz?\n\rPasife çekilen stoklara ait tüm veriler pasif duruma geçecektir.\n\rPasife geçen stokları daha sonra tekrar aktif edebilirsiniz.", "Soru?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (answer == DialogResult.Yes)
                    {
                        db.AddParameterValue("@ref", Ref);
                        db.AddParameterValue("@act", false, SqlDbType.Bit);
                        db.RunCommand("update StStockCard set active=@act where Ref=@ref");
                        XtraMessageBox.Show("İşlem başarıyla gerçekleştirildi.", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillData();

                    }
                }
        }

        private void bbiInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Show();
        }

        private void grdStock_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            pmAnaMenu.ShowPopup(Cursor.Position);
        }

        private void bbiEscape_ItemDoubleClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void bbiEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void grdStock_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            int sRef = 0;
            sRef = int.Parse(grdStock.GetFocusedRowCellValue("Ref").ToString());
            if (sRef != 0)
            {
                string quantitySql = "", movSql = "";
                quantitySql = @"SELECT DISTINCT 
                        s.ref, 
                        s.sRef, 
                        s.sBarcode AS Barkod, 
                        b.size AS Beden, 
                        b.color AS Renk, 
                        sysB.name AS Şube, 
                        SysW.name AS Depo, 
                        dbo.Tools_CalcStockQuantity(s.sBarcode, s.brRef, s.whRef) AS Quantity
                    FROM   StStockIO AS s 
                    INNER JOIN AtlasSys.dbo.sysWhouse AS SysW ON SysW.Ref = s.whRef 
                    INNER JOIN AtlasSys.dbo.sysBranch AS sysB ON sysB.Ref = s.brRef 
                    INNER JOIN StStockCardBarcodes AS b ON b.barcode = s.sBarcode
                    WHERE 
                        s.lineDirection = '1'
                        AND s.sRef = @sRef";

                movSql = @"SELECT TOP 30
s.ref,
s.sRef, 
s.sBarcode AS Barkod, 
b.size AS Beden, 
b.color AS Renk, 
sysB.name AS Şube, 
SysW.name AS Depo, 
s.quantity as Adet,
REPLACE(REPLACE(s.lineDirection,0,'Çıkış'),1,'Giriş') AS Yön,
s.movementType as Tip
FROM StStockIO AS s
INNER JOIN AtlasSys.dbo.sysWhouse AS SysW ON SysW.Ref = s.whRef
INNER JOIN AtlasSys.dbo.sysBranch AS sysB ON sysB.Ref = s.brRef
INNER JOIN StStockCardBarcodes AS b ON b.barcode = s.sBarcode
WHERE S.sRef = @sRef
ORDER BY ref DESC";


                db.AddParameterValue("@sRef", sRef);
                DataTable dt = db.GetDataTable(quantitySql);
                if (dt.Rows.Count > 0)
                {
                    dgwWhouse.DataSource = dt;
                    grdWhouse.Columns[0].Visible = false;
                    grdWhouse.Columns[1].Visible = false;
                }
                else
                {
                    dt.Rows.Clear();
                    dgwWhouse.DataSource = dt;
                    grdWhouse.RefreshData();
                }


                db.AddParameterValue("@sRef", sRef);
                DataTable dtMov = db.GetDataTable(movSql);
                if (dtMov.Rows.Count > 0)
                {
                    dgwMove.DataSource = dtMov;
                    grdMove.Columns[0].Visible = false;
                    grdMove.Columns[1].Visible = false;
                }
                else
                {
                    dtMov.Rows.Clear();
                    dgwMove.DataSource = dtMov;
                    grdMove.RefreshData();
                }

                grdMove.BestFitColumns();
                grdWhouse.BestFitColumns();
            }
        }
    }
}