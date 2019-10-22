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
using System.IO;
using Obje.Classes;
using Obje.Companents;
using Sys;

namespace Sys
{
    public partial class FrmUser : AtlasForm
    {
        public FrmUser()
        {
            InitializeComponent();
      AtlasCompanent.AForm(this);
        AtlasCompanent.TemelBar(barMenu);
        }

        #region Methods

        AccessManager db = new AccessManager();
        Helper helper = new Helper();
        DataTable dtList = new DataTable();
        StringBuilder stb = new StringBuilder();
        DataTable dtControl = new DataTable();
       AtlasChangeState c = new AtlasChangeState();

        int  dbRef = 0, groupRef = 0, roleRef = 0;
        string code, name,  codeCount;
        string newName = "", HashedPass, NormalPass;


        void LookUpDoldur()
        {
            ledDb.flaLookUp.Properties.Columns.Clear();
            ledGroup.flaLookUp.Properties.Columns.Clear();
            ledRole.flaLookUp.Properties.Columns.Clear();

            ledDb.flaLookUp.Properties.ValueMember = "Ref";
            ledDb.flaLookUp.Properties.DisplayMember = "name";
            ledDb.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ref", Caption = "dbNo", Visible = false });
            ledDb.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "name", Caption = "Adı" });
            ledDb.flaLookUp.Properties.DataSource = db.GetDataTable("select * from sysDatabase");

            ledGroup.flaLookUp.Properties.ValueMember = "Ref";
            ledGroup.flaLookUp.Properties.DisplayMember = "name";
            ledGroup.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ref", Caption = "dbNo", Visible = false });
            ledGroup.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "name", Caption = "Adı" });
            ledGroup.flaLookUp.Properties.DataSource = db.GetDataTable("select * from sysUserGroup");

            ledRole.flaLookUp.Properties.ValueMember = "Ref";
            ledRole.flaLookUp.Properties.DisplayMember = "name";
            ledRole.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ref", Caption = "dbNo", Visible = false });
            ledRole.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "name", Caption = "Adı" });
            ledRole.flaLookUp.Properties.DataSource = db.GetDataTable("select * from sysRole");
        }

        void FillData()
        {
            db.AddParameterValue("@Ref", this._Ref);
            dtList = db.GetDataTable("select * from sysUser where Ref=@Ref");
            this._Ref = int.Parse(dtList.Rows[0][0].ToString());
            chkActive.SetBoolValue(bool.Parse(dtList.Rows[0][1].ToString()));
            txtCode.SetString(dtList.Rows[0][2].ToString());
            txtName.SetString(dtList.Rows[0][3].ToString());
            txtUsername.SetString(dtList.Rows[0][4].ToString());
            if (dtList.Rows[0][5].ToString().Length > 0)
            {
                NormalPass = helper.TextSifreCoz(dtList.Rows[0][5].ToString());
                txtPassword.SetString(NormalPass);
            }
            ledGroup.SetValue(int.Parse(dtList.Rows[0][6].ToString()));
            ledRole.SetValue(int.Parse(dtList.Rows[0][7].ToString()));
            txtMail.SetString(dtList.Rows[0][8].ToString());
            txtTel1.SetString(dtList.Rows[0][9].ToString());
            txtTel2.SetString(dtList.Rows[0][10].ToString());
            ledDb.SetValue(int.Parse(dtList.Rows[0][11].ToString()));
            if (!string.IsNullOrEmpty(dtList.Rows[0][12].ToString()))
                pictureEdit1.Image = Image.FromFile(Application.StartupPath + "\\Images\\User\\" + dtList.Rows[0][12].ToString());
        }

        bool Control()
        {
            stb.Clear();

            if (!string.IsNullOrEmpty(txtCode.GetString()))
            {
                dtControl.Clear();
                db.AddParameterValue("@code", txtCode.GetString());
                dtControl = db.GetDataTable("select code from sysUser where code=@code");
                if (dtControl.Rows.Count > 0)
                    codeCount = (dtControl.Rows[0][2].ToString());
            }

            if (_FormMod ==Enums.enmFormMod.Yeni && dtControl.Rows.Count > 0)
                stb.AppendLine("Böyle bir kullanıcı kodu sistemde mevcut.");

            if (string.IsNullOrEmpty(txtCode.GetString()))
                stb.AppendLine("kullanıcı kodu boş geçilemez.");
            else
                code = txtCode.GetString();

            if (string.IsNullOrEmpty(txtName.GetString()))
                stb.AppendLine("kullanıcı adı boş geçilemez.");
            else
                name = txtName.GetString();

            if (string.IsNullOrEmpty(ledDb.GetValue().ToString()))
                stb.AppendLine("varsayılan veritabanı boş geçilemez.");
            else
                dbRef = ledDb.GetValue();

            if (!string.IsNullOrEmpty(ledGroup.GetValue().ToString()))
                groupRef = ledGroup.GetValue();

            if (!string.IsNullOrEmpty(ledRole.GetValue().ToString()))
                roleRef = ledRole.GetValue();



            if (stb.ToString().Length <= 0)
                return true;
            else
                return false;
        }

        #endregion

        private void btnEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (Control())
                {


                    if (!string.IsNullOrEmpty(pictureEdit1.GetLoadedImageLocation().ToString()))
                    {
                        string MainPath = pictureEdit1.GetLoadedImageLocation().ToString();
                        string GuidKey = Guid.NewGuid().ToString();
                        string[] words = MainPath.Split('.');
                        string goal = Application.StartupPath + @"\\Images\\User\\";
                        newName = GuidKey + "." + words[1].ToString();
                        File.Copy(pictureEdit1.GetLoadedImageLocation().ToString(), goal + newName);

                    }
                    NormalPass = txtPassword.GetString();
                    if (NormalPass.Length > 0)
                        HashedPass = helper.TextSifrele(NormalPass);


                    db.AddParameterValue("@ref", this._Ref);
                    db.AddParameterValue("@active", chkActive.GetBoolValue());
                    db.AddParameterValue("@code", txtCode.GetString());
                    db.AddParameterValue("@name", txtName.GetString());
                    db.AddParameterValue("@username", txtUsername.GetString());
                    db.AddParameterValue("@password", HashedPass);
                    db.AddParameterValue("@roleRef", roleRef);
                    db.AddParameterValue("@groupRef", groupRef);
                    db.AddParameterValue("@phoneNo1", txtTel1.GetString());
                    db.AddParameterValue("@phoneNo2", txtTel2.GetString());
                    db.AddParameterValue("@eMail", txtMail.GetString());
                    db.AddParameterValue("@defualtDB", dbRef);
                    db.AddParameterValue("@path", newName);


                    db.RunCommand("sp_sysUser_AddOrUp", CommandType.StoredProcedure);
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
                    db.parameterDelete();
                }
            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
                db.parameterDelete();
            }
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            helper.ClearForm(this);
            chkActive.SetString("Aktif");
            chkActive.SetBoolValue(true);
            LookUpDoldur();
            if (this._FormMod == Enums.enmFormMod.Guncelle)
            {
                FillData();
            }
            c.StateStabil(this);
        }
    }
}