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
    public partial class FrmBranch : AtlasForm
    {
        public FrmBranch()
        {
            InitializeComponent();
          Obje.Classes.AtlasCompanent.AForm(this);
            Obje.Classes.AtlasCompanent.TemelBar(barMenu);
        }

        #region methods

      AtlasChangeState c = new AtlasChangeState();
        AccessManager db = new AccessManager();
        Helper helper = new Helper();
        StringBuilder stb = new StringBuilder();

        int codeCount;
        int noCount;
        DataTable dtControl = new DataTable();

        int firmRef = 0, no = 0;
        string code = "", name = "";
        bool Control()
        {
            stb.Clear();
            if (!string.IsNullOrEmpty(txtNo.GetString()))
            {
                dtControl.Clear();
                db.AddParameterValue("@no", txtNo.GetString());
                dtControl = db.GetDataTable("select no from sysBranch where no=@no");
                if (dtControl.Rows.Count > 0)
                    noCount = int.Parse(dtControl.Rows[0][0].ToString());
            }
            if (!string.IsNullOrEmpty(txtCode.GetString()))
            {
                dtControl.Clear();
                db.AddParameterValue("@code", txtCode.GetString());
                dtControl = db.GetDataTable("select code from sysBranch where code=@code");
                if (dtControl.Rows.Count > 0)
                    codeCount = int.Parse(dtControl.Rows[0][0].ToString());
            }


            if (_FormMod == enmFormMod.Yeni && noCount > 0)
                stb.AppendLine("Böyle bir şube numarası sistemde mevcut.");

            if (string.IsNullOrEmpty(txtNo.GetString()))
                stb.AppendLine("Şube numarası boş geçilemez.");
            else
                no = int.Parse(txtNo.GetString());

            if (_FormMod == Enums.enmFormMod.Yeni && codeCount > 0)
                stb.AppendLine("Böyle bir şube kodu sistemde mevcut.");

            if (string.IsNullOrEmpty(txtCode.GetString()))
                stb.AppendLine("Şube kodu boş geçilemez.");
            else
                code = txtCode.GetString();

            if (string.IsNullOrEmpty(txtName.GetString()))
                stb.AppendLine("Şube adı boş geçilemez.");
            else
                name = txtName.GetString();

            if (string.IsNullOrEmpty(ledFirm.GetString()))
                stb.AppendLine("Şube firması boş geçilemez.");
            else
                firmRef = ledFirm.GetValue();

            if (stb.ToString().Length <= 0)
                return true;
            else
                return false;
        }

        void FiilLookUp()
        {


            ledFirm.flaLookUp.Properties.ValueMember = "Ref";
            ledFirm.flaLookUp.Properties.DisplayMember = "name";
            ledFirm.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ref", Caption = "dbNo", Visible = false });
            ledFirm.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "name", Caption = "Adı" });
            db.AddParameterValue("@act", 1);
            ledFirm.flaLookUp.Properties.DataSource = db.GetDataTable("select Ref,name from sysFirm where Active=@act");
        }

        #endregion

        private void FrmBranch_Load(object sender, EventArgs e)
        {
            helper.ClearForm(this);
            chkActive.SetBoolValue(true);
            chkActive.SetString("Aktif");
            FiilLookUp();
            if (_FormMod == Enums.enmFormMod.Guncelle)
            {
                db.AddParameterValue("@Ref", this._Ref);
                DataTable dtFirm = db.GetDataTable("select * from sysBranch where Ref=@ref");

                ledFirm.SetValue(int.Parse(dtFirm.Rows[0][1].ToString()));
                ledFirm.Validate();
                txtNo.SetString(dtFirm.Rows[0][2].ToString());
                chkActive.SetBoolValue(bool.Parse(dtFirm.Rows[0][3].ToString()));
                txtCode.SetString(dtFirm.Rows[0][4].ToString());
                txtName.SetString(dtFirm.Rows[0][5].ToString());
                txtAddress.SetString(dtFirm.Rows[0][6].ToString());
                ledCity.SetValue(int.Parse(dtFirm.Rows[0][7].ToString()));
                txtTel1.SetString(dtFirm.Rows[0][8].ToString());
                txtTel2.SetString(dtFirm.Rows[0][9].ToString());
                txtTel3.SetString(dtFirm.Rows[0][10].ToString());
                txtMail.SetString(dtFirm.Rows[0][11].ToString());
            }

            c.StateStabil(this);
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (Control())
                {
                    db.AddParameterValue("@ref", this._Ref);
                    db.AddParameterValue("@firmRef", firmRef);
                    db.AddParameterValue("@no", no);
                    db.AddParameterValue("@active", chkActive.GetBoolValue());
                    db.AddParameterValue("@code", code);
                    db.AddParameterValue("@name", name);
                    db.AddParameterValue("@address", txtAddress.GetString());
                    db.AddParameterValue("@cityRef", ledCity.GetValue());
                    db.AddParameterValue("@phoneNo1", txtTel1.GetString());
                    db.AddParameterValue("@phoneNo2", txtTel2.GetString());
                    db.AddParameterValue("@faxNo", txtTel3.GetString());
                    db.AddParameterValue("@eMail", txtMail.GetString());

                    db.RunCommand("sp_sysBranch_AddOrUp", CommandType.StoredProcedure);
                    XtraMessageBox.Show("İşlem başarıyla tamamlandı.", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            catch (Exception ex)
            {
                helper.WriteLog(ex);
            }
        }

        private void btnEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void ledFirm_Validated(object sender, EventArgs e)
        {
            ledCity.flaLookUp.Properties.Columns.Clear();
            ledCity.flaLookUp.Properties.ValueMember = "Ref";
            ledCity.flaLookUp.Properties.DisplayMember = "name";
            ledCity.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ref", Caption = "No", Visible = false });
            ledCity.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "name", Caption = "Adı" });
            db.AddParameterValue("@ref1", ledFirm.GetValue());
            int id = int.Parse(db.GetScalarValue("select countryRef from sysFirm where Ref=@ref1").ToString());

            db.AddParameterValue("@ref", id);
            ledCity.flaLookUp.Properties.DataSource = db.GetDataTable("select * from sysCity where countryRef=@ref");
        }
    }
}