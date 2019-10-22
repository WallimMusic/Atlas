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

namespace Erp.Sell
{
    public partial class FrmCurrentList : AtlasForm
    {
        public FrmCurrentList()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelRibbon(ribbonControl1);
            AtlasCompanent.TemelGrid(grdStock);
            grdStock.OptionsBehavior.Editable = false;
            grdStock.OptionsView.ShowAutoFilterRow = true;
            this.MaximizeBox = true;
        }


        #region Definitions
        ErpManager db = new ErpManager();
        DataTable dt = new DataTable();
        SaveFileDialog sfd = new SaveFileDialog();
        #endregion

        #region Methods
        void FillData()
        {
            dt = db.GetDataTable(@"SELECT        Ref, type as [Tip], code as [Kod], name as [Ad], country as [Ülke], city as [Şehir], gsm as [GSM],mail as [Mail]
            FROM            StCustomerAccount where active = 1");
            if (dt != null)
            {
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    dt.Rows[i][1].
                //    if (dt.Rows[i][1].ToString() == "200")
                //        dt.Rows[i][1] = "Alıcı";
                //    if (dt.Rows[i][1].ToString() == "201")
                //        dt.Rows[i][1] = "Satıcı";
                //    if (dt.Rows[i][1].ToString() == "202")
                //        dt.Rows[i][1] = "Alıcı + Satıcı";
                //}
                dgwStock.DataSource = dt;
                grdStock.Columns["Ref"].Visible = false;
                grdStock.Columns["Tip"].Visible = false;
            }
            grdStock.BestFitColumns();
        }

        void Add()
        {
            Sell.FrmCustomerAcc newForm = new FrmCustomerAcc();
            newForm._Ref = 0;
            newForm._FormMod = Enums.enmFormMod.Yeni;
            //yeniForm.MdiParent = frmAnaMenu.ActiveForm;
            newForm.ShowDialog();

            if (newForm.DialogResult == DialogResult.OK)
                FillData();
        }

        void Show()
        {
            if (grdStock.RowCount > 0)
            {
                if (grdStock.FocusedRowHandle != -1)
                {
                    Sell.FrmCustomerAcc newForm = new FrmCustomerAcc();
                    newForm._Ref = int.Parse(grdStock.GetFocusedRowCellValue("Ref").ToString());
                    newForm._MenuNo = this._MenuNo;
                    newForm._FormMod = Enums.enmFormMod.Goruntule;
                    newForm.ShowDialog();
                }
            }
        }

        void Update()
        {
            if (grdStock.RowCount > 0)
                if (grdStock.FocusedRowHandle != -1)
                {
                    Sell.FrmCustomerAcc newForm = new FrmCustomerAcc();
                    newForm._Ref = int.Parse(grdStock.GetFocusedRowCellValue("Ref").ToString());
                    newForm._MenuNo = this._MenuNo;
                    newForm._FormMod = Enums.enmFormMod.Guncelle;
                    //yeniForm.MdiParent = frmAnaMenu.ActiveForm;
                    newForm.ShowDialog();
                }

            FillData();
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

        private void bbiEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}