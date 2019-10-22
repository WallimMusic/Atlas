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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;

namespace IK.Permission
{
    public partial class FrmPermissionList : AtlasForm
    {
        public FrmPermissionList()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelBar(barList);
            this.MaximizeBox = true;

            AtlasCompanent.TemelGrid(grdAll);
            AtlasCompanent.TemelGrid(grdNext);
            AtlasCompanent.TemelGrid(grdNow);
            AtlasCompanent.TemelGrid(grdPast);

            grdAll.CustomDrawCell -= AtlasCompanent.View_CustomDrawCell;
            grdAll.CustomDrawCell += grdAll_CustomDrawCell;

            grdAll.RowCellStyle -= AtlasCompanent.View_RowCellStyle;


            grdAll.OptionsBehavior.Editable = false;
            grdNext.OptionsBehavior.Editable = false;
            grdNow.OptionsBehavior.Editable = false;
            grdPast.OptionsBehavior.Editable = false;

            grdAll.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            grdNext.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            grdNow.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            grdPast.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            grdAll.OptionsView.ShowAutoFilterRow = true;
            grdNext.OptionsView.ShowAutoFilterRow = true;
            grdNow.OptionsView.ShowAutoFilterRow = true;
            grdPast.OptionsView.ShowAutoFilterRow = true;

            this.MaximizeBox = true;

            grdNext.PopupMenuShowing += grdAll_PopupMenuShowing;
            grdNow.PopupMenuShowing += grdAll_PopupMenuShowing;
            grdPast.PopupMenuShowing += grdAll_PopupMenuShowing;
        }

        public AtlasForm newForm;

        AccessManager db = new AccessManager();
        Helper helper = new IK.Helper();
        AtlasChangeState c = new AtlasChangeState();

        SaveFileDialog sfd = new SaveFileDialog();
        OpenFileDialog ofd = new OpenFileDialog();

        void fillData()
        {
            #region All
            FrmIKMain main = (FrmIKMain)Application.OpenForms["FrmIKMain"];
            DataTable dtAll = new DataTable();
            DataTable dtNext = new DataTable();
            DataTable dtNow = new DataTable();
            DataTable dtPas = new DataTable();
            if (main.who != "YSK")
            {

                db.AddParameterValue("@unit", main.pUnit);
                dtAll = db.GetDataTable(@"SELECT        tbPermission.Ref, 
			  tbPermission.pRef, 
			  tbPerson.name + ' ' + tbPerson.surname AS [Ad Soyad],
			  tbPermission.pType AS [İzin Tipi],
			  tbPermission.pSDate AS [Başlangıç Tarihi], 
			  tbPermission.pFDate AS [Bitiş Tarihi], 
			  tbPermission.pWSDate AS [İşe Başlama Tarihi], 
              tbPermission.pRequest AS [Kullanılan İzin], 
			  (tbPermission.Weekend + tbPermission.pNational + tbPermission.religion) as [Resmi Tatil], 
			  (tbPermission.Weekend + tbPermission.pNational + tbPermission.religion + tbPermission.pRequest) as [Toplam]			
              FROM tbPermission  with(nolock) LEFT OUTER JOIN
              tbPerson ON tbPermission.pRef = tbPerson.Ref
              where tbperson.unit=@unit
              ");

                db.AddParameterValue("@nDate", DateTime.Now.ToShortDateString().ToString(), SqlDbType.Date);
                db.AddParameterValue("@unit", main.pUnit);
                dtNext = db.GetDataTable(@"SELECT        tbPermission.Ref, 
			  tbPermission.pRef, 
			  tbPerson.name + ' ' + tbPerson.surname AS [Ad Soyad],
			  tbPermission.pType AS [İzin Tipi],
			  tbPermission.pSDate AS [Başlangıç Tarihi], 
			  tbPermission.pFDate AS [Bitiş Tarihi], 
			  tbPermission.pWSDate AS [İşe Başlama Tarihi], 
              tbPermission.pRequest AS [Kullanılan İzin], 
			  (tbPermission.Weekend + tbPermission.pNational + tbPermission.religion) as [Resmi Tatil], 
			  (tbPermission.Weekend + tbPermission.pNational + tbPermission.religion + tbPermission.pRequest) as [Toplam]
			  FROM            tbPermission  with(nolock) LEFT OUTER JOIN
              tbPerson ON tbPermission.pRef = tbPerson.Ref
			  WHERE
			  @nDate <  tbPermission.pSDate AND tbperson.unit=@unit");

                db.AddParameterValue("@dNow", DateTime.Now.ToShortDateString().ToString(), SqlDbType.Date);
                db.AddParameterValue("@unit", main.pUnit);
                dtNow = db.GetDataTable(@"SELECT        tbPermission.Ref, 
			  tbPermission.pRef, 
			  tbPerson.name + ' ' + tbPerson.surname AS [Ad Soyad],
			  tbPermission.pType AS [İzin Tipi],
			  tbPermission.pSDate AS [Başlangıç Tarihi], 
			  tbPermission.pFDate AS [Bitiş Tarihi], 
			  tbPermission.pWSDate AS [İşe Başlama Tarihi], 
              tbPermission.pRequest AS [Kullanılan İzin], 
			  (tbPermission.Weekend + tbPermission.pNational + tbPermission.religion) as [Resmi Tatil], 
			  (tbPermission.Weekend + tbPermission.pNational + tbPermission.religion + tbPermission.pRequest) as [Toplam]
			  FROM            tbPermission  with(nolock) LEFT OUTER JOIN
              tbPerson ON tbPermission.pRef = tbPerson.Ref
			  WHERE
			  @dNow BETWEEN tbPermission.pSDate AND tbPermission.pFDate AND tbperson.unit=@unit");


                db.AddParameterValue("@dPast", DateTime.Now.ToShortDateString().ToString(), SqlDbType.Date);
                db.AddParameterValue("@unit", main.pUnit);
                dtPas = db.GetDataTable(@"SELECT        tbPermission.Ref, 
			  tbPermission.pRef, 
			  tbPerson.name + ' ' + tbPerson.surname AS [Ad Soyad],
			  tbPermission.pType AS [İzin Tipi],
			  tbPermission.pSDate AS [Başlangıç Tarihi], 
			  tbPermission.pFDate AS [Bitiş Tarihi], 
			  tbPermission.pWSDate AS [İşe Başlama Tarihi], 
              tbPermission.pRequest AS [Kullanılan İzin], 
			  (tbPermission.Weekend + tbPermission.pNational + tbPermission.religion) as [Resmi Tatil], 
			  (tbPermission.Weekend + tbPermission.pNational + tbPermission.religion + tbPermission.pRequest) as [Toplam]
			  FROM            tbPermission  with(nolock)
            LEFT OUTER JOIN
              tbPerson ON tbPermission.pRef = tbPerson.Ref
			  WHERE
			  @dPast >= tbPermission.pWSDate AND tbperson.unit=@unit");
            }
            else
            {
                dtAll = db.GetDataTable(@"SELECT        tbPermission.Ref, 
			  tbPermission.pRef, 
			  tbPerson.name + ' ' + tbPerson.surname AS [Ad Soyad],
			  tbPermission.pType AS [İzin Tipi],
			  tbPermission.pSDate AS [Başlangıç Tarihi], 
			  tbPermission.pFDate AS [Bitiş Tarihi], 
			  tbPermission.pWSDate AS [İşe Başlama Tarihi], 
              tbPermission.pRequest AS [Kullanılan İzin], 
			  (tbPermission.Weekend + tbPermission.pNational + tbPermission.religion) as [Resmi Tatil], 
			  (tbPermission.Weekend + tbPermission.pNational + tbPermission.religion + tbPermission.pRequest) as [Toplam]			
              FROM tbPermission  with(nolock) LEFT OUTER JOIN
              tbPerson ON tbPermission.pRef = tbPerson.Ref
              ");

                db.AddParameterValue("@nDate", DateTime.Now.ToShortDateString().ToString(), SqlDbType.Date);
                dtNext = db.GetDataTable(@"SELECT        tbPermission.Ref, 
			  tbPermission.pRef, 
			  tbPerson.name + ' ' + tbPerson.surname AS [Ad Soyad],
			  tbPermission.pType AS [İzin Tipi],
			  tbPermission.pSDate AS [Başlangıç Tarihi], 
			  tbPermission.pFDate AS [Bitiş Tarihi], 
			  tbPermission.pWSDate AS [İşe Başlama Tarihi], 
              tbPermission.pRequest AS [Kullanılan İzin], 
			  (tbPermission.Weekend + tbPermission.pNational + tbPermission.religion) as [Resmi Tatil], 
			  (tbPermission.Weekend + tbPermission.pNational + tbPermission.religion + tbPermission.pRequest) as [Toplam]
			  FROM            tbPermission  with(nolock) LEFT OUTER JOIN
              tbPerson ON tbPermission.pRef = tbPerson.Ref
			  WHERE
			  @nDate <  tbPermission.pSDate");

                db.AddParameterValue("@dNow", DateTime.Now.ToShortDateString().ToString(), SqlDbType.Date);
                dtNow = db.GetDataTable(@"SELECT        tbPermission.Ref, 
			  tbPermission.pRef, 
			  tbPerson.name + ' ' + tbPerson.surname AS [Ad Soyad],
			  tbPermission.pType AS [İzin Tipi],
			  tbPermission.pSDate AS [Başlangıç Tarihi], 
			  tbPermission.pFDate AS [Bitiş Tarihi], 
			  tbPermission.pWSDate AS [İşe Başlama Tarihi], 
              tbPermission.pRequest AS [Kullanılan İzin], 
			  (tbPermission.Weekend + tbPermission.pNational + tbPermission.religion) as [Resmi Tatil], 
			  (tbPermission.Weekend + tbPermission.pNational + tbPermission.religion + tbPermission.pRequest) as [Toplam]
			  FROM            tbPermission  with(nolock) LEFT OUTER JOIN
              tbPerson ON tbPermission.pRef = tbPerson.Ref
			  WHERE
			  @dNow BETWEEN tbPermission.pSDate AND tbPermission.pFDate");

                db.AddParameterValue("@dPast", DateTime.Now.ToShortDateString().ToString(), SqlDbType.Date);
                dtPas = db.GetDataTable(@"SELECT        tbPermission.Ref, 
			  tbPermission.pRef, 
			  tbPerson.name + ' ' + tbPerson.surname AS [Ad Soyad],
			  tbPermission.pType AS [İzin Tipi],
			  tbPermission.pSDate AS [Başlangıç Tarihi], 
			  tbPermission.pFDate AS [Bitiş Tarihi], 
			  tbPermission.pWSDate AS [İşe Başlama Tarihi], 
              tbPermission.pRequest AS [Kullanılan İzin], 
			  (tbPermission.Weekend + tbPermission.pNational + tbPermission.religion) as [Resmi Tatil], 
			  (tbPermission.Weekend + tbPermission.pNational + tbPermission.religion + tbPermission.pRequest) as [Toplam]
			  FROM            tbPermission  with(nolock)
            LEFT OUTER JOIN
              tbPerson ON tbPermission.pRef = tbPerson.Ref
			  WHERE
			  @dPast >= tbPermission.pWSDate");
            }

            dgwAll.DataSource = dtAll;
            grdAll.Columns[0].Visible = false;
            grdAll.Columns[1].Visible = false;
            grdAll.BestFitColumns();
            #endregion

            dgwNext.DataSource = dtNext;
            grdNext.Columns[0].Visible = false;
            grdNext.Columns[1].Visible = false;
            grdNext.BestFitColumns();


            dgwNow.DataSource = dtNow;
            grdNow.Columns[0].Visible = false;
            grdNow.Columns[1].Visible = false;
            grdNow.BestFitColumns();


            dgwPast.DataSource = dtPas;
            grdPast.Columns[0].Visible = false;
            grdPast.Columns[1].Visible = false;
            grdPast.BestFitColumns();
        }

        private void FrmPermissionList_Load(object sender, EventArgs e)
        {
            fillData();
        }

        private void grdAll_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

        }

        private void grdAll_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    DateTime bugun = DateTime.Parse(DateTime.Now.ToShortDateString().ToString());
                    DateTime baslangic = DateTime.Parse(View.GetRowCellDisplayText(e.RowHandle, "Başlangıç Tarihi").ToString());
                    DateTime bitis = DateTime.Parse(grdAll.GetRowCellValue(e.RowHandle, "Bitiş Tarihi").ToString());
                    if (bugun > baslangic)
                    {
                        e.Appearance.BackColor = Color.DarkRed;
                        e.Appearance.ForeColor = Color.White;
                    }
                    else if (bugun < baslangic)
                    {
                        e.Appearance.BackColor = Color.DarkGreen;
                        e.Appearance.ForeColor = Color.White;
                    }
                    if (bugun >= baslangic && bugun <= bitis)
                    {
                        e.Appearance.BackColor = Color.Orange;
                        e.Appearance.ForeColor = Color.Black;
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }


        }

        private void grdAll_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;

            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.FontStyleDelta = FontStyle.Bold;
            }
        }

        #region Export

        private void bbixls_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Tüm İzinler")
            {
                sfd.Filter = "Excel Dosyası (*.xls)|*.xls";
                if (sfd.ShowDialog() == DialogResult.OK)
                    grdAll.ExportToXls(sfd.FileName);
            }
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Gelecek İzinler")
            {
                sfd.Filter = "Excel Dosyası (*.xls)|*.xls";
                if (sfd.ShowDialog() == DialogResult.OK)
                    grdNext.ExportToXls(sfd.FileName);
            }
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Aktif İzinler")
            {
                sfd.Filter = "Excel Dosyası (*.xls)|*.xls";
                if (sfd.ShowDialog() == DialogResult.OK)
                    grdNow.ExportToXls(sfd.FileName);
            }
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Geçmiş İzinler")
            {
                sfd.Filter = "Excel Dosyası (*.xls)|*.xls";
                if (sfd.ShowDialog() == DialogResult.OK)
                    grdPast.ExportToXls(sfd.FileName);
            }

            sfd.Reset();

        }

        private void bbixlsx_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Tüm İzinler")
            {
                sfd.Filter = "Excel Dosyası (*.xlsx)|*.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                    grdAll.ExportToXlsx(sfd.FileName);
            }
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Gelecek İzinler")
            {
                sfd.Filter = "Excel Dosyası (*.xlsx)|*.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                    grdNext.ExportToXlsx(sfd.FileName);
            }
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Aktif İzinler")
            {
                sfd.Filter = "Excel Dosyası (*.xlsx)|*.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                    grdNow.ExportToXlsx(sfd.FileName);
            }
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Geçmiş İzinler")
            {
                sfd.Filter = "Excel Dosyası (*.xlsx)|*.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                    grdPast.ExportToXlsx(sfd.FileName);
            }

            sfd.Reset();
        }

        private void bbipdf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Tüm İzinler")
            {
                sfd.Filter = "Pdf Dosyası (*.pdf)|*.pdf";
                if (sfd.ShowDialog() == DialogResult.OK)
                    grdAll.ExportToPdf(sfd.FileName);
            }
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Gelecek İzinler")
            {
                sfd.Filter = "Pdf Dosyası (*.pdf)|*.pdf";
                if (sfd.ShowDialog() == DialogResult.OK)
                    grdNext.ExportToPdf(sfd.FileName);
            }
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Aktif İzinler")
            {
                sfd.Filter = "Pdf Dosyası (*.pdf)|*.pdf";
                if (sfd.ShowDialog() == DialogResult.OK)
                    grdNow.ExportToPdf(sfd.FileName);
            }
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Geçmiş İzinler")
            {
                sfd.Filter = "Pdf Dosyası (*.pdf)|*.pdf";
                if (sfd.ShowDialog() == DialogResult.OK)
                    grdPast.ExportToPdf(sfd.FileName);
            }



            sfd.Reset();
        }

        private void bbidoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Tüm İzinler")
            {
                sfd.Filter = "Word Dosyası (*.rtf)|*.rtf";
                if (sfd.ShowDialog() == DialogResult.OK)
                    grdAll.ExportToRtf(sfd.FileName);
            }
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Gelecek İzinler")
            {
                sfd.Filter = "Word Dosyası (*.rtf)|*.rtf";
                if (sfd.ShowDialog() == DialogResult.OK)
                    grdNext.ExportToRtf(sfd.FileName);
            }
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Aktif İzinler")
            {
                sfd.Filter = "Word Dosyası (*.rtf)|*.rtf";
                if (sfd.ShowDialog() == DialogResult.OK)
                    grdNow.ExportToRtf(sfd.FileName);
            }
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Geçmiş İzinler")
            {
                sfd.Filter = "Word Dosyası (*.rtf)|*.rtf";
                if (sfd.ShowDialog() == DialogResult.OK)
                    grdPast.ExportToRtf(sfd.FileName);
            }


            sfd.Reset();
        }

        #endregion

        private void bbiGruplama_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Tüm İzinler")
            {

                if (grdAll.OptionsView.ShowGroupPanel == true)
                    grdAll.OptionsView.ShowGroupPanel = false;
                else
                    grdAll.OptionsView.ShowGroupPanel = true;
            }
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Gelecek İzinler")
            {
                if (grdNext.OptionsView.ShowGroupPanel == true)
                    grdNext.OptionsView.ShowGroupPanel = false;
                else
                    grdNext.OptionsView.ShowGroupPanel = true;
            }
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Aktif İzinler")
            {
                if (grdNow.OptionsView.ShowGroupPanel == true)
                    grdNow.OptionsView.ShowGroupPanel = false;
                else
                    grdNow.OptionsView.ShowGroupPanel = true;
            }
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Geçmiş İzinler")
            {
                if (grdPast.OptionsView.ShowGroupPanel == true)
                    grdPast.OptionsView.ShowGroupPanel = false;
                else
                    grdPast.OptionsView.ShowGroupPanel = true;
            }

        }

        private void bbiFiltreleme_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Tüm İzinler")
            {

                if (grdAll.OptionsView.ShowAutoFilterRow == true)
                    grdAll.OptionsView.ShowAutoFilterRow = false;
                else
                    grdAll.OptionsView.ShowAutoFilterRow = true;
            }
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Gelecek İzinler")
            {

                if (grdNext.OptionsView.ShowAutoFilterRow == true)
                    grdNext.OptionsView.ShowAutoFilterRow = false;
                else
                    grdNext.OptionsView.ShowAutoFilterRow = true;

            }
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Aktif İzinler")
            {
                if (grdNow.OptionsView.ShowAutoFilterRow == true)
                    grdNow.OptionsView.ShowAutoFilterRow = false;
                else
                    grdNow.OptionsView.ShowAutoFilterRow = true;
            }
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Geçmiş İzinler")
            {
                if (grdPast.OptionsView.ShowAutoFilterRow == true)
                    grdPast.OptionsView.ShowAutoFilterRow = false;
                else
                    grdPast.OptionsView.ShowAutoFilterRow = true;
            }

        }

        private void bbiFiltreTemizle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Tüm İzinler")
            {
                grdAll.OptionsFilter.Reset();
            }
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Gelecek İzinler")
            {
                grdNext.OptionsFilter.Reset();

            }
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Aktif İzinler")
            {
                grdNow.OptionsFilter.Reset();
            }
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Geçmiş İzinler")
            {
                grdPast.OptionsFilter.Reset();
            }

        }

        private void bbiEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bbiAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Permission.FrmCreatePermission create = new FrmCreatePermission();
            create.MdiParent = FrmIKMain.ActiveForm;
            create.Show();
        }

        private void bbiChange_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmCreatePermission permission = new FrmCreatePermission();

            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Tüm İzinler")
            {
                if (!string.IsNullOrEmpty(grdAll.GetFocusedRowCellValue("Ref").ToString()))
                {
                    permission.pRef = int.Parse(grdAll.GetFocusedRowCellValue("pRef").ToString());
                    permission.kRef = int.Parse(grdAll.GetFocusedRowCellValue("Ref").ToString());
                }

            }
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Gelecek İzinler")
            {
                if (!string.IsNullOrEmpty(grdNext.GetFocusedRowCellValue("Ref").ToString()))
                {
                    permission.pRef = int.Parse(grdAll.GetFocusedRowCellValue("pRef").ToString());
                    permission.kRef = int.Parse(grdAll.GetFocusedRowCellValue("Ref").ToString());
                }

            }
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Aktif İzinler")
            {
                if (!string.IsNullOrEmpty(grdNow.GetFocusedRowCellValue("Ref").ToString()))
                {
                    permission.pRef = int.Parse(grdAll.GetFocusedRowCellValue("pRef").ToString());
                    permission.kRef = int.Parse(grdAll.GetFocusedRowCellValue("Ref").ToString());
                }
            }
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Geçmiş İzinler")
            {
                if (!string.IsNullOrEmpty(grdPast.GetFocusedRowCellValue("Ref").ToString()))
                {
                    permission.pRef = int.Parse(grdAll.GetFocusedRowCellValue("pRef").ToString());
                    permission.kRef = int.Parse(grdAll.GetFocusedRowCellValue("Ref").ToString());
                }
            }

            permission.MdiParent = FrmIKMain.ActiveForm;
            permission._FormMod = Enums.enmFormMod.Guncelle;
            permission.Show();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RptYazdir Rp = new RptYazdir();
            int pRef = 0, Ref = 0;
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Tüm İzinler")
            {
                if (!string.IsNullOrEmpty(grdAll.GetFocusedRowCellValue("Ref").ToString()))
                {
                    Rp.Ref = int.Parse(grdAll.GetFocusedRowCellValue("Ref").ToString());
                    Rp.pRef = int.Parse(grdAll.GetFocusedRowCellValue("pRef").ToString());
                    db.AddParameterValue("@pRef", Rp.pRef);
                    if (int.Parse(db.GetScalarValue("Select Count(*) from tbPermission where pRef=@pRef").ToString()) > 0)
                    {
                        db.AddParameterValue("@pRef", Rp.pRef);
                        Rp.oncekiRef = int.Parse(db.GetScalarValue("select max(Ref) from tbPermission where pRef=@pRef").ToString());
                    }
                }

            }
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Gelecek İzinler")
            {
                if (!string.IsNullOrEmpty(grdNext.GetFocusedRowCellValue("Ref").ToString()))
                {
                    Rp.Ref = int.Parse(grdNext.GetFocusedRowCellValue("Ref").ToString());
                    Rp.pRef = int.Parse(grdNext.GetFocusedRowCellValue("pRef").ToString());
                    db.AddParameterValue("@pRef", Rp.pRef);
                    if (int.Parse(db.GetScalarValue("Select Count(*) from tbPermission where pRef=@pRef").ToString()) > 0)
                    {
                        db.AddParameterValue("@pRef", Rp.pRef);
                        Rp.oncekiRef = int.Parse(db.GetScalarValue("select max(Ref) from tbPermission where pRef=@pRef").ToString());
                    }
                }


            }
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Aktif İzinler")
            {
                if (!string.IsNullOrEmpty(grdNow.GetFocusedRowCellValue("Ref").ToString()))
                {
                    Rp.Ref = int.Parse(grdNow.GetFocusedRowCellValue("Ref").ToString());
                    Rp.pRef = int.Parse(grdNow.GetFocusedRowCellValue("pRef").ToString());
                    db.AddParameterValue("@pRef", Rp.pRef);
                    if (int.Parse(db.GetScalarValue("Select Count(*) from tbPermission where pRef=@pRef").ToString()) > 0)
                    {
                        db.AddParameterValue("@pRef", Rp.pRef);
                        Rp.oncekiRef = int.Parse(db.GetScalarValue("select max(Ref) from tbPermission where pRef=@pRef").ToString());
                    }
                }


            }
            if (xtraTabControl1.SelectedTabPage.Text.ToString() == "Geçmiş İzinler")
            {
                if (!string.IsNullOrEmpty(grdPast.GetFocusedRowCellValue("Ref").ToString()))
                {
                    Rp.Ref = int.Parse(grdPast.GetFocusedRowCellValue("Ref").ToString());
                    Rp.pRef = int.Parse(grdPast.GetFocusedRowCellValue("pRef").ToString());
                    db.AddParameterValue("@pRef", Rp.pRef);
                    if (int.Parse(db.GetScalarValue("Select Count(*) from tbPermission where pRef=@pRef").ToString()) > 0)
                    {
                        db.AddParameterValue("@pRef", Rp.pRef);
                        Rp.oncekiRef = int.Parse(db.GetScalarValue("select max(Ref) from tbPermission where pRef=@pRef").ToString());
                    }
                }
            }
            Rp.CreateDocument();
            ReportPrintTool printTool = new ReportPrintTool(Rp);
            printTool.ShowRibbonPreviewDialog();
        }

        private void btnSil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdAll.RowCount > 0)
            {
                if (grdAll.FocusedRowHandle != -1)
                {
                    DialogResult cevap;
                    cevap = XtraMessageBox.Show("izni silmek istediğinize emin misiniz?", "Soru?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (cevap == DialogResult.Yes)
                    {
                        _Ref = int.Parse(grdAll.GetFocusedRowCellValue("Ref").ToString());
                        db.AddParameterValue("@Ref", _Ref);
                        db.RunCommand("delete from tbPermission where Ref=@ref");
                        XtraMessageBox.Show("İşlem başarıyla gerçekleşti.", "Başarılı İşlem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fillData();
                    }

                }
            }
        }

        private void grdAll_DoubleClick(object sender, EventArgs e)
        {
            bbiChange.PerformClick();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bbiAdd.PerformClick();
        }

        private void grdAll_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            popupMenu1.ShowPopup(Cursor.Position);
        }
    }
}