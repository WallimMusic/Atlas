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

namespace IK.Person
{
    public partial class FrmExitPersonList : AtlasForm
    {
        public FrmExitPersonList()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelBar(barList);
            AtlasCompanent.TemelGrid(grdList);
            this.MaximizeBox = true;

            grdList.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
        }

        ErpManager db = new ErpManager();
        DataTable dt = new DataTable();
        SaveFileDialog sfd = new SaveFileDialog();
        OpenFileDialog ofd = new OpenFileDialog();

        void FillData()
        {

            string sql = @"		SELECT        
tbPerson.Ref, 
tbPerson.name + ' ' + surname AS[Ad Soyad], 
tc AS TC, 
birthDate as [Doğum Tarihi], 
mission as [Görev], 
tbUnit.name as [Birim],
sDate as [İşe Giriş], 
gsm as [GSM], 
mail as [Mail], 
bGroup as [Kan Grubu], 
dLicence as [Ehliyet]
FROM tbPerson   with(nolock)
LEFT OUTER JOIN  tbUnit 
ON tbPerson.unit = tbUnit.Ref
WHERE exitDate != '01.01.1900' 
ORDER BY  [Ad Soyad] asc";

            this._Sql = sql;
            dt = db.GetDataTable(this._Sql);
            if (dt != null)
            {
                dgwList.DataSource = dt;
                grdList.Columns["Ref"].Visible = false;
            }
            grdList.BestFitColumns();
        }

        private void bbiEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
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
            grdList.OptionsFilter.Reset();
        }

        private void FrmExitPersonList_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void btnReturn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdList.RowCount > 0)
            {
                if (!string.IsNullOrEmpty(grdList.GetFocusedRowCellValue("Ref").ToString()))
                {

                    Person.FrmPersonReturn work = new Person.FrmPersonReturn();
                    work._Ref = int.Parse(grdList.GetFocusedRowCellValue("Ref").ToString());

                    if (work.ShowDialog() == DialogResult.OK)
                        FillData();
                }
            }
        }
    }
}