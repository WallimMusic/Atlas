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
    public partial class FrmSettings : AtlasForm
    {
        public FrmSettings()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelBar(bar1);
            AtlasCompanent.TemelGrid(gridView1);

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            ledPersonel.flaLookUp.Properties.EditValueChanged += fillPdata;
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
            ledPersonel.flaLookUp.Properties.DataSource = db.GetDataTable("Select Ref,name + ' ' + surname as [Ad Soyad],mission from tbPerson with(nolock) WHERE ExitDate is null OR exitDate = '01.01.1900' ORDER BY  [Ad Soyad] asc");
        }

        private void btnEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        void fillData()
        {
          
            DataTable dt = db.GetDataTable(@"Select tbUsers.Ref,tbUsers.aRef,tbPerson.name + ' ' + tbPerson.surname [Personel], tbUsers.name as [Kullanıcı Adı], password as [Şifre] from tbUsers
            LEFT OUTER JOIN tbPerson
            ON tbPerson.Ref = tbUsers.aRef");
            gridControl1.DataSource = dt;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Visible = false;
            gridView1.BestFitColumns();
            gridView1.MoveFirst();



        }

        void clear()
        {
            txtPass.ClearData();

            _Ref = 0;
            ledPersonel.SetString("");
        }

        string tc = "";
        DataTable dtAuth;
        private void FrmSettings_Load(object sender, EventArgs e)
        {
            FillPerson();
            fillData();
            clear();
            c.StateStabil(this);
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
                        db.RunCommand("delete from tbUsers where Ref=@ref");
                    }

                    XtraMessageBox.Show("İşlem Başarıyla Gerçekleştirildi..", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
                db.parameterDelete();
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                db.AddParameterValue("@Ref", _Ref);
                db.AddParameterValue("@aRef", ledPersonel.GetValue());
                db.AddParameterValue("@user", tc);
                db.AddParameterValue("@pass", txtPass.GetString());

                db.RunCommand("sp_Users", CommandType.StoredProcedure);

                //if (gridView2.RowCount > 0)
                //{
                //    for (int i = 0; i < gridView2.RowCount; i++)
                //    {
                //        db.parameterDelete();
                //        db.AddParameterValue("@Ref", gridView2.GetRowCellValue(i, "Ref").ToString());
                //        db.AddParameterValue("@pRef", gridView2.GetRowCellValue(i, "menuRef").ToString());
                //        db.AddParameterValue("@menuRef", gridView2.GetRowCellValue(i, "Modül").ToString());
                //        db.AddParameterValue("@add", gridView2.GetRowCellValue(i, "Ekleme").ToString());
                //        db.AddParameterValue("@see", gridView2.GetRowCellValue(i, "Görme").ToString());
                //        db.AddParameterValue("@update", gridView2.GetRowCellValue(i, "Güncelleme").ToString());
                //        db.AddParameterValue("@del", gridView2.GetRowCellValue(i, "Silme").ToString());

                //        db.RunCommand("sp_Auth", CommandType.StoredProcedure);
                //    }
                //}




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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(gridView1.GetFocusedRowCellValue("Ref").ToString()))
                {
                    _Ref = int.Parse(gridView1.GetFocusedRowCellValue("Ref").ToString());
                    db.AddParameterValue("@Ref", _Ref);
                    DataTable dt = db.GetDataTable("Select * from tbUsers where Ref=@ref");
                    txtPass.SetString(dt.Rows[0]["password"].ToString());

                    ledPersonel.SetValue(int.Parse(dt.Rows[0]["aRef"].ToString()));
                    ledPersonel.SetString(dt.Rows[0]["Personel"].ToString());
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void fillPdata(object sender, EventArgs e)
        {
//            gridControl2.DataSource = db.GetDataTable(@"SELECT        tbAuths.Ref, tbAuths.menuRef, tbMenus.Modul AS Modül, tbMenus.ScreenName AS Ekran, tbAuths.authSee AS Görme, tbAuths.authAdd AS Ekleme, tbAuths.authUpdate AS Güncelleme, tbAuths.authDelete AS Silme
//FROM            tbAuths RIGHT OUTER JOIN
//                         tbMenus ON tbAuths.menuRef = tbMenus.Ref ");
//            gridView2.Columns[0].Visible = false;
//            gridView2.Columns[1].Visible = false;
//            gridView2.BestFitColumns();

            if (ledPersonel.GetValue() != 0 && !string.IsNullOrEmpty(ledPersonel.GetValue().ToString()))
            {
                db.AddParameterValue("@ref", ledPersonel.GetValue());
                tc = db.GetScalarValue("select tc from tbPerson where Ref=@ref").ToString();
            }
        }

    }

}