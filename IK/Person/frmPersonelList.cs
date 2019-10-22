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
using Microsoft.VisualBasic;

namespace IK
{
    public partial class frmPersonelList : AtlasForm
    {
        public frmPersonelList()
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
        public string sql;
        #region Methods
        void FillData()
        {

            sql = @"		SELECT        
tbPerson.Ref, 
tbPerson.name + ' ' + surname AS[Ad Soyad], 
tc AS TC, 
birthDate as [Doğum Tarihi], 
birthPlace as [Doğum Yeri],
mName as [Anne Adı],
dName as [Baba Adı],
bGroup as [Kan Grubu],
mStatus as [Medeni Hal],
register as [Sicil Numarası],

firm as [Firma],
campus as [Yerleşke],
mission as [Görev], 
tbUnit.name as [Birim],
sDate as [İşe Giriş], 
gsm as [GSM], 
mail as [Mail], 
[address] as [Adres], 
cName as [Yakın Adı], 
cSurname as [Yakın Soyadı], 
cRank as [Yakın Derecesi], 
cGsm as [Yakın GSM], 
dLicence as [Ehliyet],
solider as [Askerlik Durumu],
education as [Öğrenim],
children as [Çocuk Sayısı],
IBAN
FROM tbPerson  with(nolock)
LEFT OUTER JOIN  tbUnit 
ON tbPerson.unit = tbUnit.Ref
WHERE ExitDate is null OR exitDate = '01.01.1900'
ORDER BY  [Ad Soyad] asc

";

            this._Sql = sql;
            dt = db.GetDataTable(this._Sql);
            if (dt != null)
            {
                dgwList.DataSource = dt;
                grdList.Columns[0].Visible = false;
                grdList.Columns[4].Visible = false;
                grdList.Columns[5].Visible = false;
                grdList.Columns[6].Visible = false;
                grdList.Columns[7].Visible = false;
                grdList.Columns[8].Visible = false;
                grdList.Columns[9].Visible = false;
                grdList.Columns[16].Visible = false;
                grdList.Columns[17].Visible = false;
                grdList.Columns[18].Visible = false;
                grdList.Columns[19].Visible = false;
                grdList.Columns[20].Visible = false;
                grdList.Columns[21].Visible = false;
                grdList.Columns[22].Visible = false;
                grdList.Columns[23].Visible = false;
                grdList.Columns[24].Visible = false;
                grdList.Columns[25].Visible = false;
                grdList.Columns[26].Visible = false;
            }
            grdList.BestFitColumns();
        }

        void Add()
        {
            Person.FrmAddPerson newForm = new Person.FrmAddPerson();
            newForm._Ref = 0;
            newForm._FormMod = Enums.enmFormMod.Yeni;
            //yeniForm.MdiParent = frmAnaMenu.ActiveForm;
            newForm.MdiParent = FrmIKMain.ActiveForm;
            newForm.Show();

            if (newForm.DialogResult == DialogResult.OK)
                FillData();
        }

        void Show()
        {
            if (grdList.RowCount > 0)
            {
                if (grdList.FocusedRowHandle != -1)
                {
                    Person.FrmAddPerson newForm = new Person.FrmAddPerson();
                    newForm._Ref = int.Parse(grdList.GetFocusedRowCellValue("Ref").ToString());
                    newForm._MenuNo = this._MenuNo;
                    newForm._FormMod = Enums.enmFormMod.Goruntule;
                    newForm.MdiParent = FrmIKMain.ActiveForm;
                    newForm.Show();
                }
            }
        }

        void Update()
        {
            if (grdList.RowCount > 0)
                if (grdList.FocusedRowHandle != -1)
                {
                    Person.FrmAddPerson newForm = new Person.FrmAddPerson();
                    newForm._Ref = int.Parse(grdList.GetFocusedRowCellValue("Ref").ToString());
                    newForm._MenuNo = this._MenuNo;
                    newForm._FormMod = Enums.enmFormMod.Guncelle;
                    newForm.MdiParent = FrmIKMain.ActiveForm;
                    newForm.Show();
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

            DataTable dtFill = db.GetDataTable(sql);
            gridControl1.DataSource = dtFill;
            sfd.Filter = "Excel Dosyası (*.xls)|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
                gridView1.ExportToXls(sfd.FileName);

            sfd.Reset();
            FillData();
        }

        private void bbixlsx_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dtFill = db.GetDataTable(sql);
            gridControl1.DataSource = dtFill;
            sfd.Filter = "Excel Dosyası (*.xlsx)|*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
                gridView1.ExportToXlsx(sfd.FileName);

            sfd.Reset();
            FillData();
        }

        private void bbipdf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dtFill = db.GetDataTable(sql);
            gridControl1.DataSource = dtFill;
            sfd.Filter = "Pdf Dosyası (*.pdf)|*.pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
                gridView1.ExportToPdf(sfd.FileName);

            sfd.Reset();
            FillData();
        }

        private void bbidoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            DataTable dtFill = db.GetDataTable(sql);
            gridControl1.DataSource = dtFill;
            sfd.Filter = "Word Dosyası (*.rtf)|*.rtf";
            if (sfd.ShowDialog() == DialogResult.OK)
                gridView1.ExportToRtf(sfd.FileName);

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

        private void btnSil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdList.RowCount > 0)
            {
                if (!string.IsNullOrEmpty(grdList.GetFocusedRowCellValue("Ref").ToString()))
                {

                    Person.FrmExitWork work = new Person.FrmExitWork();
                    work._Ref = int.Parse(grdList.GetFocusedRowCellValue("Ref").ToString());

                    if (work.ShowDialog() == DialogResult.OK)
                        FillData();
                }
            }
        }

        private void bbiEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void grdList_DoubleClick(object sender, EventArgs e)
        {
            Update();
        }

        private void grdList_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            popupMenu1.ShowPopup(Cursor.Position);
        }
    }
}