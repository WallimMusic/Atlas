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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;

namespace Sys
{
    public partial class FrmAuthorityDetails : AtlasForm
    {
        public FrmAuthorityDetails()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelBar(barMenu);
            AtlasCompanent.TemelGrid(grdGrid);

            grdGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
        }

        #region Methods


        AccessManager db = new AccessManager();
        Helper helper = new Helper();
        AtlasChangeState c = new AtlasChangeState();

        int REf, RowCount;
        DialogResult result;

        void FillData()
        {
            DataTable dtGrid = new DataTable();

            dtGrid.Columns.Add("Ref");
            dtGrid.Columns.Add("authRef");
            dtGrid.Columns.Add("Modül");
            dtGrid.Columns.Add("menuRef");
            dtGrid.Columns.Add("authSee", typeof(bool));
            dtGrid.Columns.Add("authAdd", typeof(bool));
            dtGrid.Columns.Add("authUpdate", typeof(bool));
            dtGrid.Columns.Add("authShow", typeof(bool));

            db.AddParameterValue("@ref", this._Ref);



            dgwGrid.DataSource = dtGrid;
            grdGrid.Columns[0].Visible = false;
            grdGrid.Columns[1].Visible = false;
            grdGrid.Columns[2].Caption = "Modül";
            grdGrid.Columns[3].Caption = "Form";
            grdGrid.Columns[4].Caption = "Görüntüleme Yetkisi";
            grdGrid.Columns[5].Caption = "Ekleme Yetkisi";
            grdGrid.Columns[6].Caption = "Güncelleme Yetkisi";
            grdGrid.Columns[7].Caption = "İnceleme Yetkisi";
            grdGrid.Columns[0].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[1].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[2].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[3].OptionsColumn.AllowEdit = false;

            db.AddParameterValue("@active", true);
            db.AddParameterValue("@type", "Form");
            DataTable dt2 = db.GetDataTable("select * from sysMenu where Active=@active and type=@type");

            RepositoryItemLookUpEdit riledType;
            riledType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            riledType.BeginInit();
            riledType.Columns.Add(new LookUpColumnInfo() { FieldName = "Ref", Caption = "Ref", Visible = false });
            riledType.Columns.Add(new LookUpColumnInfo() { FieldName = "description", Caption = "Ad" });
            riledType.NullText = "Seçim Yapınız";
            riledType.DisplayMember = "description";
            riledType.ValueMember = "Ref";
            riledType.DataSource = dt2;
            dgwGrid.RepositoryItems.Add(riledType);

            grdGrid.Columns[3].ColumnEdit = riledType;


            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                DataRow row = dtGrid.NewRow();
                row["menuRef"] = int.Parse(dt2.Rows[i]["Ref"].ToString());

                db.AddParameterValue("@ref", dt2.Rows[i]["Ref"].ToString());
                string code = db.GetScalarValue("select code from sysMenu where Ref=@ref").ToString();
                db.AddParameterValue("@code", code);
                row["Modül"] = db.GetScalarValue("select [description] from sysMenu where code=@code and type='AnaMenu'").ToString();
                row["authSee"] = true;
                row["authAdd"] = true;
                row["authUpdate"] = true;
                row["authShow"] = true;
                dtGrid.Rows.Add(row);
            }
            grdGrid.BestFitColumns();
            grdGrid.RefreshData();


            RowCount = grdGrid.RowCount;
            grdGrid.BestFitColumns();

            if (this._FormMod == Enums.enmFormMod.Guncelle)
            {
                db.AddParameterValue("@ref", this._Ref);
                DataTable dt = db.GetDataTable("select * from SysAuths where Ref=@ref");

                txtCode.SetString(dt.Rows[0]["code"].ToString());
                txtName.SetString(dt.Rows[0]["name"].ToString());

                db.AddParameterValue("@ref", this._Ref);
                DataTable dtData = db.GetDataTable(@"SELECT SysAuthDetails.Ref AS Ref,sysAuthDetails.authRef as authRef,sysAuthDetails.MenuRef,sysAuthDetails.authSee,sysAuthDetails.authAdd,sysAuthDetails.authUpdate,sysAuthDetails.authShow 
                                   FROM SysAuths JOIN sysAuthDetails ON SysAuths.Ref = sysAuthDetails.authRef  where sysAuthDetails.authRef=@ref");

                dtGrid.Rows.Clear();
                for (int i = 0; i < dtData.Rows.Count; i++)
                {

                    DataRow row = dtGrid.NewRow();
                    int Ref = int.Parse(dtData.Rows[i]["menuRef"].ToString());
                    row["Ref"] = dtData.Rows[i]["Ref"].ToString();
                    row["authRef"] = this._Ref;
                    row["menuRef"] = Ref;

                    db.AddParameterValue("@ref", Ref);
                    string code = db.GetScalarValue("select code from sysMenu where Ref=@ref").ToString();

                    db.AddParameterValue("@code", code);
                    row["Modül"] = db.GetScalarValue("select [description] from sysMenu where code=@code and type='AnaMenu'").ToString();


                    row["authSee"] = bool.Parse(dtData.Rows[i]["authSee"].ToString());
                    row["authAdd"] = bool.Parse(dtData.Rows[i]["authAdd"].ToString());
                    row["authUpdate"] = bool.Parse(dtData.Rows[i]["authUpdate"].ToString());
                    row["authShow"] = bool.Parse(dtData.Rows[i]["authShow"].ToString());
                    dtGrid.Rows.Add(row);
                }
                grdGrid.BestFitColumns();
                grdGrid.RefreshData();

            }
        }
        #endregion

        private void FrmAuthorityPackage_Load(object sender, EventArgs e)
        {
            helper.ClearForm(this);
            chkActive.SetString("Aktif");
            chkActive.SetBoolValue(true);
            FillData();

            c.StateStabil(this);
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {



            db.AddParameterValue("@ref", this._Ref);
            db.AddParameterValue("@code", txtCode.GetString());
            db.AddParameterValue("@name", txtName.GetString());
            db.AddParameterValue("@active", chkActive.GetBoolValue());
            db.RunCommand("sp_sysAuth_AddOrUp", CommandType.StoredProcedure);

            if (this._FormMod == Enums.enmFormMod.Yeni)
                this._Ref = int.Parse(db.GetScalarValue("select Max(ref) from SysAuths").ToString());


            for (int i = 0; i < grdGrid.RowCount; i++)
            {

                if (string.IsNullOrEmpty(grdGrid.GetRowCellValue(i, "Ref").ToString()))
                    REf = 0;
                else
                    REf = int.Parse(grdGrid.GetRowCellValue(i, "Ref").ToString());

                db.AddParameterValue("@ref", REf);
                db.AddParameterValue("@authRef", this._Ref);
                db.AddParameterValue("@menuRef", int.Parse(grdGrid.GetRowCellValue(i, "menuRef").ToString()));
                db.AddParameterValue("@see", grdGrid.GetRowCellValue(i, "authSee").ToString());
                db.AddParameterValue("@add", grdGrid.GetRowCellValue(i, "authAdd").ToString());
                db.AddParameterValue("@update", grdGrid.GetRowCellValue(i, "authUpdate").ToString());
                db.AddParameterValue("@show", grdGrid.GetRowCellValue(i, "authShow").ToString());

                db.RunCommand("sp_sysAuthDetails_AddOrUp", CommandType.StoredProcedure);

            }
            XtraMessageBox.Show("İşlem başarıyla tamamlandı.", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RowCount = grdGrid.RowCount;
            this.DialogResult = DialogResult.OK;
            c.StateStabil(this);
            this.Close();



        }

        private void btnEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}