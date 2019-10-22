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

namespace IK.Settings
{
    public partial class FrmUnit : AtlasForm
    {
        public FrmUnit()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelBar(bar1);
            AtlasCompanent.TemelGrid(gridView1);

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
        }


        Helper helper = new IK.Helper();
        AtlasChangeState c = new AtlasChangeState();
        AccessManager db = new AccessManager();

        void FillPerson()
        {
            this.MaximizeBox = true;

            ledPersonel.flaLookUp.Properties.ValueMember = "Ref";
            ledPersonel.flaLookUp.Properties.DisplayMember = "Ad Soyad";
            ledPersonel.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ref", Caption = "dbNo", Visible = false });
            ledPersonel.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ad Soyad", Caption = "Ad Soyad" });
            ledPersonel.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "mission", Caption = "Görev" });
            ledPersonel.flaLookUp.Properties.DataSource = db.GetDataTable("Select Ref,name + ' ' + surname as [Ad Soyad],mission from tbPerson  WHERE tbPerson.ExitDate is null OR tbPerson.exitDate = '01.01.1900' ORDER BY  [Ad Soyad] asc");
        }
        void fillData()
        {
            DataTable dt = db.GetDataTable(@"SELECT tbUnit.Ref,tbUnit.aRef,tbPerson.name + ' ' + tbPerson.surname [Yetkili],tbUnit.Name as [Departman] from tbUnit
LEFT OUTER JOIN tbPerson with(nolock)
ON tbPerson.Ref = tbUnit.aRef
 WHERE tbPerson.ExitDate is null OR tbPerson.exitDate = '01.01.1900'");
            gridControl1.DataSource = dt;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Visible = false;
            gridView1.BestFitColumns();
        }
        void clear()
        {
            txtUser.ClearData();
            _Ref = 0;
            ledPersonel.SetString("");
        }

        private void FrmUnit_Load(object sender, EventArgs e)
        {
            FillPerson();
            fillData();
            clear();
            c.StateStabil(this);
        }

        private void btnEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(gridView1.GetFocusedRowCellValue("Ref").ToString()))
                {
                    _Ref = int.Parse(gridView1.GetFocusedRowCellValue("Ref").ToString());
                    DialogResult cevap;
                    cevap = XtraMessageBox.Show("Seçili kaydı silmek istediğinize emin misiniz?", "Soru?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (cevap == DialogResult.Yes)
                    {
                        db.AddParameterValue("@ref", _Ref);
                        db.RunCommand("delete from tbUnit where Ref=@ref");
                    }

                    XtraMessageBox.Show("İşlem Başarıyla Gerçekleştirildi..", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillData();
                }

            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
                db.parameterDelete();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(gridView1.GetFocusedRowCellValue("Ref").ToString()))
                {
                    _Ref = int.Parse(gridView1.GetFocusedRowCellValue("Ref").ToString());
                    db.AddParameterValue("@Ref", _Ref);
                    DataTable dt = db.GetDataTable("Select * from tbUnit where Ref=@ref");
                    txtUser.SetString(dt.Rows[0]["name"].ToString());
                    ledPersonel.SetValue(int.Parse(dt.Rows[0]["aRef"].ToString()));
                    ledPersonel.SetString(dt.Rows[0]["Yetkili"].ToString());
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                db.AddParameterValue("@Ref", _Ref);
                db.AddParameterValue("@aRef", ledPersonel.GetValue());
                db.AddParameterValue("@user", txtUser.GetString());

                db.RunCommand("sp_Unit", CommandType.StoredProcedure);

                XtraMessageBox.Show("İşlem Başarıyla Gerçekleştirildi..", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                helper.ClearForm(this);
                c.StateStabil(this);
                this.DialogResult = DialogResult.OK;
                this.Close();


            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
                db.parameterDelete();
            }
        }
    }
}