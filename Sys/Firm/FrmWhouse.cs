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

namespace SYS
{
    public partial class FrmWhouse : AtlasForm
    {
        public FrmWhouse()
        {
            InitializeComponent();
            Obje.Classes.AtlasCompanent.AForm(this);
            Obje.Classes.AtlasCompanent.TemelBar(barMenu);

            ledFirm.flaLookUp.EditValueChanged += ChangeFirmEditValue;
        }

        #region methods

        AtlasChangeState c = new AtlasChangeState();
        AccessManager db = new AccessManager();
        Helper helper = new Helper();
        StringBuilder stb = new StringBuilder();


        string codeCount;
        int noCount;
        DataTable dtControl = new DataTable();

        int firmRef = 0, no = 0, branchRef = 0;
        string code = "", name = "";

        bool Control()
        {
            stb.Clear();
            if (!string.IsNullOrEmpty(txtNo.GetString()))
            {
                dtControl.Clear();
                db.AddParameterValue("@no", txtNo.GetString());
                dtControl = db.GetDataTable("select no from sysWhouse where no=@no");
                if (dtControl.Rows.Count > 0)
                    noCount = int.Parse(dtControl.Rows[0][0].ToString());
            }
            if (!string.IsNullOrEmpty(txtCode.GetString()))
            {
                dtControl.Clear();
                db.AddParameterValue("@code", txtCode.GetString());
                dtControl = db.GetDataTable("select code from sysWhouse where code=@code");
                if (dtControl.Rows.Count > 0)
                    codeCount = (dtControl.Rows[0][0].ToString());
            }


            if (_FormMod == Enums.enmFormMod.Yeni && noCount > 0)
                stb.AppendLine("Böyle bir Depo numarası sistemde mevcut.");

            if (string.IsNullOrEmpty(txtNo.GetString()))
                stb.AppendLine("Depo numarası boş geçilemez.");
            else
                no = int.Parse(txtNo.GetString());

            if (_FormMod == Enums.enmFormMod.Yeni && dtControl.Rows.Count > 0)
                stb.AppendLine("Böyle bir Depo kodu sistemde mevcut.");

            if (string.IsNullOrEmpty(txtCode.GetString()))
                stb.AppendLine("Depo kodu boş geçilemez.");
            else
                code = txtCode.GetString();

            if (string.IsNullOrEmpty(txtName.GetString()))
                stb.AppendLine("Depo adı boş geçilemez.");
            else
                name = txtName.GetString();

            if (string.IsNullOrEmpty(ledFirm.GetString()))
                stb.AppendLine("Depo firması boş geçilemez.");
            else
                firmRef = ledFirm.GetValue();

            if (string.IsNullOrEmpty(ledBranch.GetString()))
                stb.AppendLine("Depo şubesi boş geçilemez.");
            else
                branchRef = ledBranch.GetValue();

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

        private void FrmWhouse_Load(object sender, EventArgs e)
        {
            helper.ClearForm(this);
            FiilLookUp();
            if (_FormMod == Enums.enmFormMod.Guncelle)
            {
                db.AddParameterValue("@Ref", this._Ref);
                DataTable dtWhouse = db.GetDataTable("select * from sysWhouse where Ref=@ref");

                ledFirm.SetValue(int.Parse(dtWhouse.Rows[0][1].ToString()));
                ledBranch.SetValue(int.Parse(dtWhouse.Rows[0][2].ToString()));
                txtNo.SetString(dtWhouse.Rows[0][3].ToString());
                txtCode.SetString(dtWhouse.Rows[0][4].ToString());
                txtName.SetString(dtWhouse.Rows[0][5].ToString());
                txtDesc.SetString(dtWhouse.Rows[0][6].ToString());
                txtArea.SetString(dtWhouse.Rows[0][7].ToString());
            }

            c.StateStabil(this);
        }

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
                    db.AddParameterValue("@ref", this._Ref);
                    db.AddParameterValue("@firmRef", firmRef);
                    db.AddParameterValue("@branchRef", branchRef);
                    db.AddParameterValue("@no", no);
                    db.AddParameterValue("@code", code);
                    db.AddParameterValue("@name", name);
                    db.AddParameterValue("@desc", txtDesc.GetString());
                    db.AddParameterValue("@area", txtArea.GetString());

                    db.RunCommand("sp_sysWhouse_AddOrUp", CommandType.StoredProcedure);
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

        #region Other events

        private void ChangeFirmEditValue(object sender, EventArgs e)
        {
            ledBranch.flaLookUp.Properties.Columns.Clear();
            ledBranch.flaLookUp.Properties.ValueMember = "Ref";
            ledBranch.flaLookUp.Properties.DisplayMember = "name";
            ledBranch.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ref", Caption = "No", Visible = false });
            ledBranch.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "name", Caption = "Adı" });
            db.AddParameterValue("@ref", ledFirm.GetValue());
            ledBranch.flaLookUp.Properties.DataSource = db.GetDataTable("select * from sysBranch where firmRef=@ref");
        }

        #endregion


    }
}