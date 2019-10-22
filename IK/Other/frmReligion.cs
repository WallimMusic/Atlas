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

namespace IK
{
    public partial class frmReligion : AtlasForm
    {

        public frmReligion()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelBar(bar1);
            AtlasCompanent.TemelGrid(gridView1);
            this.MaximizeBox = true;



            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
        }


        void fillData()
        {
            DataTable dt = db.GetDataTable("Select Ref,name as [Bayram Adı],sDate as [Başlangıç],fDate as [Bitiş] from tbReligion  with(nolock)");
            gridControl1.DataSource = dt;
            gridView1.Columns[0].Visible = false;
            gridView1.BestFitColumns();

            cmbBayram.flashCombo.Properties.Items.Add("Ramazan Bayramı");
            cmbBayram.flashCombo.Properties.Items.Add("Kurban Bayramı");
        }
        AccessManager db = new AccessManager();
        Helper helper = new IK.Helper();
        AtlasChangeState c = new AtlasChangeState();


        bool Control()
        {
            int errorCount = 0;
            db.AddParameterValue("@name", cmbBayram.GetString());
            DataTable dt = db.GetDataTable("select * from tbReligion  with(nolock) where name=@name");
            if (dt.Rows.Count > 0)
            {
                DateTime yil = DateTime.Parse(dt.Rows[0]["sDate"].ToString());

                if (string.IsNullOrEmpty(cmbBayram.GetString()))
                {
                    XtraMessageBox.Show("Bayram adını boş geçemezsiniz.", "Hatalı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorCount++;
                }

                if (yil.Year == dtpBaslangic.GetDate().Year)
                {
                    XtraMessageBox.Show(cmbBayram.GetString() + " adlı bayramı aynı yıl içinde 2.kez sisteme ekleyemezsiniz.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    errorCount++;
                }
            }
            if (string.IsNullOrEmpty(dtpBaslangic.GetDate().ToString()) || string.IsNullOrEmpty(dtpBitis.GetDate().ToString()))
            {
                XtraMessageBox.Show("Başlangıç veya bitiş tarihi değeri boş geçilemez..", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                errorCount++;
            }
            if (errorCount > 0)
                return false;
            else
                return true;

        }

        void clear()
        {
            _Ref = 0;
            cmbBayram.ClearData();
            dtpBaslangic.ClearData();
            dtpBitis.ClearData();
        }

        private void frmReligion_Load(object sender, EventArgs e)
        {
            fillData();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //try
            //{
            if (Control() == true)
            {
                db.AddParameterValue("@ref", _Ref);
                db.AddParameterValue("@name", cmbBayram.GetString());
                db.AddParameterValue("@sDate", dtpBaslangic.GetDate(), SqlDbType.Date);
                db.AddParameterValue("@fDate", dtpBitis.GetDate(), SqlDbType.Date);
                db.RunCommand("sp_Religion", CommandType.StoredProcedure);

                XtraMessageBox.Show("İşlem başarıyla tamamlandı.", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                helper.ClearForm(this);
                c.StateStabil(this);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            //}
            //catch (Exception ex)
            //{
            //    helper.WriteLog(ex);
            //    db.parameterDelete();
            //}


        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(gridView1.GetFocusedRowCellValue("Ref").ToString()))
            {
                _Ref = int.Parse(gridView1.GetFocusedRowCellValue("Ref").ToString());
                cmbBayram.SetString(gridView1.GetFocusedRowCellValue("Bayram Adı").ToString());
                dtpBaslangic.SetDate(DateTime.Parse(gridView1.GetFocusedRowCellValue("Başlangıç").ToString()));
                dtpBitis.SetDate(DateTime.Parse(gridView1.GetFocusedRowCellValue("Bitiş").ToString()));
            }
        }

        private void btnSil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(gridView1.GetFocusedRowCellValue("Ref").ToString()))
                {
                    DialogResult cevap;
                    cevap = XtraMessageBox.Show("Kaydı silmek istediğinize emin misiniZ?", "Soru?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (cevap == DialogResult.Yes)
                    {
                        _Ref = int.Parse(gridView1.GetFocusedRowCellValue("Ref").ToString());
                        db.AddParameterValue("@ref", _Ref);
                        db.RunCommand("delete from tbReligion where Ref=@ref");
                        XtraMessageBox.Show("İşlem başarıyla tamamlandı.", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        fillData();
                    }
                }

            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
                db.parameterDelete();
            }
        }

        private void btnEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            popupMenu1.ShowPopup(Cursor.Position);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(gridView1.GetFocusedRowCellValue("Ref").ToString()))
                {
                    DialogResult cevap;
                    cevap = XtraMessageBox.Show("Kaydı silmek istediğinize emin misiniZ?", "Soru?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (cevap == DialogResult.Yes)
                    {
                        _Ref = int.Parse(gridView1.GetFocusedRowCellValue("Ref").ToString());
                        db.AddParameterValue("@ref", _Ref);
                        db.RunCommand("delete from tbReligion where Ref=@ref");
                        XtraMessageBox.Show("İşlem başarıyla tamamlandı.", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fillData();

                    }
                }

            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
                db.parameterDelete();
            }
        }
    }
}