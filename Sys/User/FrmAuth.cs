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

namespace Sys.User
{
    public partial class FrmAuth : AtlasForm
    {
        public FrmAuth()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelBar(bar1);
            AtlasCompanent.TemelGrid(grdAuth);
            AtlasCompanent.TemelGrid(grdBranch);
            AtlasCompanent.TemelGrid(grdDb);

            grdAuth.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            grdBranch.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            grdDb.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            grdAuth.OptionsBehavior.Editable = false;

            ledFirm.flaLookUp.EditValueChanged += GetBrandsWithFirm;
            ledUser.flaLookUp.EditValueChanged += UserFill;
            ledPackage.flaLookUp.EditValueChanged += GetPackageWithAuth;

            grdBranch.FocusedRowChanged += getWhouseWithBranch;

        }

        #region Methods


        AccessManager db = new AccessManager();
        Helper helper = new Helper();
        AtlasChangeState c = new AtlasChangeState();
        DataTable dtWhouse = new DataTable();
        DataTable dtBranch = new DataTable();
        StringBuilder stb = new StringBuilder();
        int REf, RowCount;
        DialogResult result;

        void FillLookUp()
        {
            ledFirm.flaLookUp.Properties.Columns.Clear();
            ledPackage.flaLookUp.Properties.Columns.Clear();
            ledUser.flaLookUp.Properties.Columns.Clear();


            ledUser.flaLookUp.Properties.ValueMember = "Ref";
            ledUser.flaLookUp.Properties.DisplayMember = "nameSurname";
            ledUser.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ref", Caption = "dbNo", Visible = false });
            ledUser.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "nameSurname", Caption = "Adı Soyadı" });
            ledUser.flaLookUp.Properties.DataSource = db.GetDataTable("select * from sysUser where active=1");

            ledFirm.flaLookUp.Properties.ValueMember = "Ref";
            ledFirm.flaLookUp.Properties.DisplayMember = "name";
            ledFirm.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ref", Caption = "dbNo", Visible = false });
            ledFirm.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "name", Caption = "Adı" });
            ledFirm.flaLookUp.Properties.DataSource = db.GetDataTable("select * from sysFirm where active=1");

            ledPackage.flaLookUp.Properties.ValueMember = "Ref";
            ledPackage.flaLookUp.Properties.DisplayMember = "name";
            ledPackage.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ref", Caption = "dbNo", Visible = false });
            ledPackage.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "name", Caption = "Adı" });
            ledPackage.flaLookUp.Properties.DataSource = db.GetDataTable("select * from sysAuths where active=1");
        }

        void SetForm()
        {
           
            dtBranch.Columns.Add("Ref");
            dtBranch.Columns.Add("no");
            dtBranch.Columns.Add("code");
            dtBranch.Columns.Add("name");
            dtBranch.Columns.Add("Seçim", typeof(bool));
            dgwBranch.DataSource = dtBranch;


            grdBranch.Columns[0].Visible = false;
            grdBranch.Columns[1].Caption = "Şube No";
            grdBranch.Columns[2].Caption = "Şube Kodu";
            grdBranch.Columns[3].Caption = "Şube Adı";
            grdBranch.Columns[1].OptionsColumn.AllowEdit = false;
            grdBranch.Columns[2].OptionsColumn.AllowEdit = false;
            grdBranch.Columns[3].OptionsColumn.AllowEdit = false;

            dtWhouse.Columns.Add("Ref");
            dtWhouse.Columns.Add("no");
            dtWhouse.Columns.Add("code");
            dtWhouse.Columns.Add("name");
            dtWhouse.Columns.Add("Seçim", typeof(bool));
            dgwDb.DataSource = dtWhouse;

            grdDb.Columns[0].Visible = false;
            grdDb.Columns[1].Caption = "Depo No";
            grdDb.Columns[2].Caption = "Depo Kodu";
            grdDb.Columns[3].Caption = "Depo Adı";
            grdDb.Columns[1].OptionsColumn.AllowEdit = false;
            grdDb.Columns[2].OptionsColumn.AllowEdit = false;
            grdDb.Columns[3].OptionsColumn.AllowEdit = false;


        }

        void FillData()
        {


            if (!string.IsNullOrEmpty(ledFirm.GetValue().ToString()) && !string.IsNullOrEmpty(ledUser.GetValue().ToString()))
            {

                if (int.Parse(db.GetScalarValue("select count(*) from sysAuthUser").ToString()) > 0)
                {
                    db.AddParameterValue("@uRef", ledUser.GetValue());
                    db.AddParameterValue("@firmRef", ledFirm.GetValue());
                    if (int.Parse(db.GetScalarValue("select count(*) from sysAuthUser where userRef=@uRef and firmRef=@firmRef").ToString()) > 0)
                    {
                        db.AddParameterValue("@uRef", ledUser.GetValue());
                        db.AddParameterValue("@firmRef", ledFirm.GetValue());
                        int authRefID = int.Parse(db.GetScalarValue("select authRef from sysAuthUser where userRef=@uRef and firmRef=@firmRef").ToString());
                        ledPackage.SetValue(authRefID);
                        db.AddParameterValue("@uRef", ledUser.GetValue());
                        db.AddParameterValue("@firmRef", ledFirm.GetValue());
                        this._Ref = int.Parse(db.GetScalarValue("select Ref from sysAuthUser where userRef=@uRef and firmRef=@firmRef").ToString());
                    }

                }
                db.AddParameterValue("@ref", ledUser.GetValue());
                DataTable dtDataBranch = db.GetDataTable("select * from sysAuthUserBranch where userRef=@ref");
                if (dtDataBranch.Rows.Count > 0)
                {
                    for (int i = 0; i < dtDataBranch.Rows.Count; i++)
                    {
                        for (int a = 0; a < dtBranch.Rows.Count; a++)
                        {
                            if (dtDataBranch.Rows[i]["branchRef"].ToString() == dtBranch.Rows[a]["Ref"].ToString())
                                grdBranch.SetRowCellValue(a, "Seçim", true);
                        }
                    }
                }



                db.AddParameterValue("@ref", ledUser.GetValue());
                DataTable dtDataWhouse = db.GetDataTable("select * from sysAuthUserWhouse where userRef=@ref");
                if (dtDataWhouse.Rows.Count > 0)
                {
                    for (int i = 0; i < dtDataWhouse.Rows.Count; i++)
                    {
                        for (int a = 0; a < dtWhouse.Rows.Count; a++)
                        {
                            if (dtDataWhouse.Rows[i]["whouseRef"].ToString() == dtWhouse.Rows[a]["Ref"].ToString())
                                grdDb.SetRowCellValue(a, "Seçim", true);
                        }
                    }
                }





            }

        }

        bool Control()
        {
            if (string.IsNullOrEmpty(ledUser.GetValue().ToString()))
                stb.AppendLine("Kullanıcı boş geçilemez.");
            if (string.IsNullOrEmpty(ledFirm.GetValue().ToString()))
                stb.AppendLine("Firma boş geçilemez.");
            if (string.IsNullOrEmpty(ledPackage.GetValue().ToString()))
                stb.AppendLine("Yetki paketi boş geçilemez.");

            if (stb.ToString().Length <= 0)
                return true;
            else
                return false;
        }


        #endregion

        private void FrmAuth_Load(object sender, EventArgs e)
        {
            SetForm();
            FillLookUp();
        }

        private void btnEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            REf = 0;
            if (Control())
            {


                db.AddParameterValue("@ref", this._Ref);
                db.AddParameterValue("@firmRef", ledFirm.GetValue());
                db.AddParameterValue("@userRef", ledUser.GetValue());
                db.AddParameterValue("@authRef", ledPackage.GetValue());
                db.RunCommand("sp_sysUserAuth_AddOrUp", CommandType.StoredProcedure);

                if (this._FormMod == Enums.enmFormMod.Yeni)
                    this._Ref = int.Parse(db.GetScalarValue("select MAX(ref) from SysAuthUser").ToString());


                for (int i = 0; i < grdBranch.RowCount; i++)
                {
                    db.AddParameterValue("@ref1", ledUser.GetValue());
                    db.AddParameterValue("@ref2", grdBranch.GetRowCellValue(i, "Ref"));
                    if (int.Parse(db.GetScalarValue("select count(*) from sysAuthUserBranch where userRef=@ref1 and branchRef=@ref2").ToString()) > 0)
                    {
                        db.AddParameterValue("@ref1", ledUser.GetValue());
                        db.AddParameterValue("@ref2", grdBranch.GetRowCellValue(i, "Ref"));
                        REf = int.Parse(db.GetScalarValue("select Ref from sysAuthUserBranch where userRef=@ref1 and branchRef=@ref2").ToString());
                    }
                    if (grdBranch.GetRowCellValue(i, "Seçim").ToString() == "True")
                    {
                        db.AddParameterValue("@ref", REf);
                        db.AddParameterValue("@userRef", ledUser.GetValue());
                        db.AddParameterValue("@branchRef", grdBranch.GetRowCellValue(i, "Ref"));
                        db.RunCommand("sp_sysAuthUserBranch_AddOrUp", CommandType.StoredProcedure);
                    }
                    else if (grdBranch.GetRowCellValue(i, "Seçim").ToString() == "False")
                    {
                        db.AddParameterValue("@ref", REf);
                        db.RunCommand("delete from sysAutUserBranch where Ref=@ref ");
                    }
                }


                for (int a = 0; a < grdDb.RowCount; a++)
                {

                    REf = 0;
                    db.AddParameterValue("@ref1", ledUser.GetValue());
                    db.AddParameterValue("@ref2", grdDb.GetRowCellValue(a, "Ref"));
                    if (int.Parse(db.GetScalarValue("select count(*) from sysAuthUserWhouse where userRef=@ref1 and whouseRef=@ref2").ToString()) > 0)
                    {
                        db.AddParameterValue("@ref1", ledUser.GetValue());
                        db.AddParameterValue("@ref2", grdDb.GetRowCellValue(a, "Ref"));
                        REf = int.Parse(db.GetScalarValue("select Ref from sysAuthUserWhouse where userRef=@ref1 and whouseRef=@ref2").ToString());
                    }

                    if (grdDb.GetRowCellValue(a, "Seçim").ToString() == "True")
                    {
                        db.AddParameterValue("@ref", REf);
                        db.AddParameterValue("@userRef", ledUser.GetValue());
                        db.AddParameterValue("@whouseRef", grdDb.GetRowCellValue(a, "Ref"));
                        db.RunCommand("sp_sysAuthUserWhouse_AddOrUp", CommandType.StoredProcedure);
                    }
                    else if (grdDb.GetRowCellValue(a, "Seçim").ToString() == "False")
                    {
                        db.AddParameterValue("@ref", REf);
                        db.RunCommand("delete from sysAuthUserWhouse where Ref=@ref ");
                    }
                }

                XtraMessageBox.Show("İşlem başarıyla tamamlandı.", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                helper.ClearForm(this);
                c.StateStabil(this);
                this.DialogResult = DialogResult.OK;
                this.Close();


            }
            else
            {
                FrmErrorForm error = new FrmErrorForm();
                error.flashMemoEdit1.SetString(stb.ToString());
                error.ShowDialog();
            }
        }

        void GetBrandsWithFirm(object sender, EventArgs e)
        {

            DataTable dtData;
            db.AddParameterValue("@active", true);
            db.AddParameterValue("@firmRef", ledFirm.GetValue());
            dtData = db.GetDataTable(@" SELECT        Ref, no, code, name
            FROM    sysBranch where active=@active and firmRef=@firmRef");

            for (int i = 0; i < dtData.Rows.Count; i++)
            {
                DataRow row = dtBranch.NewRow();
                row["Ref"] = dtData.Rows[i][0];
                row["no"] = dtData.Rows[i][1];
                row["code"] = dtData.Rows[i][2];
                row["name"] = dtData.Rows[i][3];
                dtBranch.Rows.Add(row);
            }
            grdBranch.RefreshData();
            grdBranch.BestFitColumns();

        }

        void GetPackageWithAuth(object sender, EventArgs e)
        {

            db.AddParameterValue("@ref", ledPackage.GetValue());
            dgwAuth.DataSource = db.GetDataTable(@"SELECT        sysMenu.description AS Form, sysAuthDetails.authSee AS Görme, sysAuthDetails.authAdd AS Ekleme, sysAuthDetails.authUpdate AS Güncelleme, sysAuthDetails.authShow AS İnceleme
                    FROM            sysAuthDetails INNER JOIN
                         sysMenu ON sysAuthDetails.menuRef = sysMenu.Ref where authRef=@ref");
            grdAuth.BestFitColumns();
        }

        void getWhouseWithBranch(object sender, EventArgs e)
        {
            DataTable dtData;


            db.AddParameterValue("@ref", ledFirm.GetValue());
            dtData = db.GetDataTable(@"SELECT        sysWhouse.Ref, sysWhouse.no as no, sysWhouse.code AS code, sysWhouse.name AS name
            FROM sysWhouse INNER JOIN
            sysBranch ON sysWhouse.branchRef = sysBranch.Ref where sysWhouse.firmRef=@ref");

            for (int i = 0; i < dtData.Rows.Count; i++)
            {
                DataRow row = dtWhouse.NewRow();
                row["Ref"] = dtData.Rows[i]["Ref"];
                row["no"] = dtData.Rows[i]["no"];
                row["code"] = dtData.Rows[i]["code"];
                row["name"] = dtData.Rows[i]["name"];
                dtWhouse.Rows.Add(row);
            }
            grdDb.RefreshData();
            grdDb.BestFitColumns();
        }

        void UserFill(object sender, EventArgs e)
        {
            FillData();
        }


    }
}