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
using Sys;

namespace Sys
{
    public partial class FrmUserGroup :AtlasForm
    {
        public FrmUserGroup()
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

        int REf;
        string code, name, codeCount;



        void FillData()
        {
            db.AddParameterValue("@Ref", this._Ref);
            dtList = db.GetDataTable("select * from sysUserGroup where Ref=@Ref");
            REf = int.Parse(dtList.Rows[0][0].ToString());
            txtCode.SetString(dtList.Rows[0][1].ToString());
            txtName.SetString(dtList.Rows[0][2].ToString());
            txtDesc.SetString(dtList.Rows[0][3].ToString());
        }

        bool Control()
        {
            stb.Clear();

            if (!string.IsNullOrEmpty(txtCode.GetString()))
            {
                dtControl.Clear();
                db.AddParameterValue("@code", txtCode.GetString());
                dtControl = db.GetDataTable("select code from sysUserGroup where code=@code");
                if (dtControl.Rows.Count > 0)
                    codeCount = (dtControl.Rows[0][0].ToString());
            }

            if (_FormMod ==Enums.enmFormMod.Yeni && dtControl.Rows.Count > 0)
                stb.AppendLine("Böyle bir grup kodu sistemde mevcut.");

            if (string.IsNullOrEmpty(txtCode.GetString()))
                stb.AppendLine("grup kodu boş geçilemez.");
            else
                code = txtCode.GetString();

            if (string.IsNullOrEmpty(txtName.GetString()))
                stb.AppendLine("grup adı boş geçilemez.");
            else
                name = txtName.GetString();

            if (stb.ToString().Length <= 0)
                return true;
            else
                return false;
        }

        #endregion

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (Control())
                {
                    db.AddParameterValue("@ref", this._Ref);
                    db.AddParameterValue("@code", code);
                    db.AddParameterValue("@name", name);
                    db.AddParameterValue("@desc", txtDesc.GetString());


                    db.RunCommand("sp_sysUserGroup_AddOrUp", CommandType.StoredProcedure);
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
            }
        }

        private void FrmUserGroup_Load(object sender, EventArgs e)
        {
            helper.ClearForm(this);
            if (this._FormMod ==Enums.enmFormMod.Guncelle)
            {
                FillData();
            }
            c.StateStabil(this);
        }

        private void btnEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

    }
}