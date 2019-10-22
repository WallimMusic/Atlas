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
using static Obje.Classes.Enums;

namespace Sys
{
    public partial class frmList : AtlasForm
    {
        public frmList()
        {

            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelBar(barList);
            AtlasCompanent.TemelGrid(grdList);
        }
        public AtlasForm newForm;

        AccessManager db = new AccessManager();
        DataTable dt = new DataTable();
        OpenFileDialog ofd = new OpenFileDialog();
        SaveFileDialog sfd = new SaveFileDialog();

        #region Methods
        void FillData()
        {
            dt = db.GetDataTable(this._Sql);
            if (dt != null)
            {
                dgwList.DataSource = dt;
                grdList.Columns["Ref"].Visible = false;
            }
            grdList.BestFitColumns();
        }

        void Add()
        {
            newForm._Ref = 0;
            newForm._FormMod = enmFormMod.Yeni;
            //yeniForm.MdiParent = frmAnaMenu.ActiveForm;
            newForm.ShowDialog();

            if (newForm.DialogResult == DialogResult.OK)
                FillData();
        }

        void Show()
        {
            if (grdList.RowCount > 0)
            {
                if (grdList.FocusedRowHandle != -1)
                {
                    newForm._Ref = int.Parse(grdList.GetFocusedRowCellValue("ref").ToString());
                    newForm._MenuNo = this._MenuNo;
                    newForm._FormMod = enmFormMod.Goruntule;
                    newForm.ShowDialog();
                }
            }
        }

        void Update()
        {
            if (grdList.RowCount > 0)
                if (grdList.FocusedRowHandle != -1)
                {
                    newForm._Ref = int.Parse(grdList.GetFocusedRowCellValue("Ref").ToString());
                    newForm._MenuNo = this._MenuNo;
                    newForm._FormMod = enmFormMod.Guncelle;
                    //yeniForm.MdiParent = frmAnaMenu.ActiveForm;
                    newForm.ShowDialog();
                }

            FillData();
        }
        #endregion

        private void frmList_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void bbiAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Add();
        }

        private void bbiChange_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Update();
        }

        #region Export

        private void bbixls_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sfd.Filter = "Excel Dosyası (*.xls)|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
                grdList.ExportToXls(sfd.FileName);

            sfd.Reset();
        }

        private void bbixlsx_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sfd.Filter = "Excel Dosyası (*.xlsx)|*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
                grdList.ExportToXlsx(sfd.FileName);

            sfd.Reset();
        }

        private void bbipdf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sfd.Filter = "Pdf Dosyası (*.pdf)|*.pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
                grdList.ExportToPdf(sfd.FileName);

            sfd.Reset();
        }

        private void bbidoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sfd.Filter = "Word Dosyası (*.rtf)|*.rtf";
            if (sfd.ShowDialog() == DialogResult.OK)
                grdList.ExportToRtf(sfd.FileName);

            sfd.Reset();
        }

        #endregion

        private void bbiGruplama_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdList.OptionsView.ShowGroupPanel == true)
                grdList.OptionsView.ShowGroupPanel = false;
            else
                grdList.OptionsView.ShowGroupPanel = true;
        }

        private void bbiFiltreleme_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdList.OptionsView.ShowAutoFilterRow == true)
                grdList.OptionsView.ShowAutoFilterRow = false;
            else
                grdList.OptionsView.ShowAutoFilterRow = true;
        }

        private void bbiFiltreTemizle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdList.ActiveFilter.Clear();

        }
    }
}