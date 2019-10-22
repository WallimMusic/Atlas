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
using Obje.List;
using DevExpress.XtraEditors.Controls;

namespace Erp.Sell
{
    public partial class FrmCustomerAcc : AtlasForm
    {
        public FrmCustomerAcc()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelRibbon(ribbonControl1);
            AtlasCompanent.Navbar(navBar);

            flashCheckEdit1.flaCheck.EditValueChanged += GetCheckClicked;
            txtCode.flaButtonEdit.ButtonClick += GetCustomerCode;

        }

        #region Methods

        ErpManager db = new ErpManager();
        Erp.Helper helper = new Erp.Helper();
        AtlasChangeState c = new AtlasChangeState();
        AccessManager sysDb = new AccessManager();
        StringBuilder stb = new StringBuilder();
        DataTable dtControl = new DataTable();
        string code;
        int codeCount;

        void SetForm()
        {
            chkActive.SetBoolValue(true);
            chkActive.SetString("Aktif");

            flashCheckEdit1.SetBoolValue(false);
            flashCheckEdit1.SetString("Yabancı");

            chkPerson.SetBoolValue(false);
            chkPerson.SetString("Şahıs");


            ledType.SetValue(200);

        }

        void LookUpFill()
        {
            ledType.flaLookUp.Properties.Columns.Clear();
            ledType.flaLookUp.Properties.ValueMember = "Key";
            ledType.flaLookUp.Properties.DisplayMember = "Value";
            ledType.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Key", Caption = "dbNo", Visible = false });
            ledType.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Value", Caption = "Tip" });
            ledType.flaLookUp.Properties.DataSource = FlashDictionary.cusTypes.ToList();
        }

        bool Control()
        {

            stb.Clear();

            #region Code Control
            if (!string.IsNullOrEmpty(txtCode.GetString()))
            {
                dtControl.Clear();
                db.AddParameterValue("@code", txtCode.GetString());
                dtControl = db.GetDataTable("select code from StCustomerAccount where code=@code");
                if (dtControl.Rows.Count > 0)
                    codeCount = int.Parse(dtControl.Rows[0][0].ToString());
            }

            if (codeCount > 0 && this._FormMod == Enums.enmFormMod.Yeni)
                stb.AppendLine("Böyle bir cari kodu sistemde mevcut.");


            if (string.IsNullOrEmpty(txtCode.GetString()))
                stb.AppendLine("Cari kodu boş geçilemez.");
            else
                code = txtCode.GetString();


            #endregion

            if (ledType.GetValue() != 200)
            {
                if (string.IsNullOrEmpty(txtVD.GetString()))
                    stb.AppendLine("Vergi dairesi boş geçilemez.");
                if (string.IsNullOrEmpty(txtVNo.GetString()))
                    stb.AppendLine("Vergi numarası boş geçilemez.");
            }

            if (stb.ToString().Length <= 0)
                return true;
            else
                return false;
        }

        void FillData()
        {
            db.AddParameterValue("@Ref", this._Ref);
            DataTable dt = db.GetDataTable("select * from StCustomerAccount where Ref=@ref");
            chkActive.SetBoolValue(bool.Parse(dt.Rows[0][1].ToString()));
            flashCheckEdit1.SetBoolValue(bool.Parse(dt.Rows[0][2].ToString()));
            chkPerson.SetBoolValue(bool.Parse(dt.Rows[0][3].ToString()));
            ledType.SetValue(int.Parse(dt.Rows[0][4].ToString()));
            txtCode.SetString(dt.Rows[0][5].ToString());
            txtName.SetString(dt.Rows[0][6].ToString());
            txtCountry.SetString(dt.Rows[0][7].ToString());
            txtCity.SetString(dt.Rows[0][8].ToString());
            txtDistirct.SetString(dt.Rows[0][9].ToString());
            txtGsm.SetString(dt.Rows[0][10].ToString());
            txtTel.SetString(dt.Rows[0][11].ToString());
            txtMail.SetString(dt.Rows[0][12].ToString());
            txtAdress.SetString(dt.Rows[0][13].ToString());
            txtVD.SetString(dt.Rows[0][14].ToString());
            txtVNo.SetString(dt.Rows[0][15].ToString());
            txtFCountry.SetString(dt.Rows[0][16].ToString());
            txtFCity.SetString(dt.Rows[0][17].ToString());
            txtFDistirct.SetString(dt.Rows[0][18].ToString());
            txtFGsm.SetString(dt.Rows[0][19].ToString());
            txtFTel.SetString(dt.Rows[0][20].ToString());
            txtFMail.SetString(dt.Rows[0][21].ToString());
            txtFAdress.SetString(dt.Rows[0][22].ToString());

            txtCode.Enabled = false;


        }


        #endregion

        private void FrmCustomerAcc_Load(object sender, EventArgs e)
        {
            LookUpFill();
            SetForm();
            if (this._FormMod == Enums.enmFormMod.Guncelle)
                FillData();
            c.StateStabil(this);
        }

        #region Other Events

        private void getCussCode(object sender, ButtonPressedEventArgs e)
        {
            helper.GetCode("StCustomerAccount", "code", this, txtCode, 20000);
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

                    db.AddParameterValue("@ref", this._Ref);
                    db.AddParameterValue("@active", chkActive.GetBoolValue());
                    db.AddParameterValue("@nationality", flashCheckEdit1.GetBoolValue());
                    db.AddParameterValue("@person", chkPerson.GetBoolValue());
                    db.AddParameterValue("@type", ledType.GetValue());
                    db.AddParameterValue("@code", txtCode.GetString());
                    db.AddParameterValue("@name", txtName.GetString());
                    db.AddParameterValue("@country", txtCountry.GetString());
                    db.AddParameterValue("@city", txtCity.GetString());
                    db.AddParameterValue("@district", txtDistirct.GetString());
                    db.AddParameterValue("@gsm", txtGsm.GetString());
                    db.AddParameterValue("@tel", txtTel.GetString());
                    db.AddParameterValue("@mail", txtMail.GetString(), SqlDbType.NVarChar);
                    db.AddParameterValue("@address", txtAdress.GetString(), SqlDbType.NVarChar);
                    db.AddParameterValue("@Ftax", txtVD.GetString());
                    db.AddParameterValue("@ftaxNo", txtVNo.GetString());
                    db.AddParameterValue("@Fcountry", txtFCountry.GetString());
                    db.AddParameterValue("@Fcity", txtFCity.GetString());
                    db.AddParameterValue("@Fdistrict", txtFDistirct.GetString());
                    db.AddParameterValue("@Fgsm", txtFGsm.GetString());
                    db.AddParameterValue("@Ftel", txtFTel.GetString());
                    db.AddParameterValue("@Fmail", txtFMail.GetString(), SqlDbType.NVarChar);
                    db.AddParameterValue("@Faddress", txtFAdress.GetString(), SqlDbType.NVarChar);
                    db.RunCommand("sp_Customer", CommandType.StoredProcedure);
                    XtraMessageBox.Show("İşlem başarıyla tamamlandı.", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    helper.ClearForm(this);
                    c.StateStabil(this);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    FrmErrorForm form = new FrmErrorForm();
                    form.flashMemoEdit1.SetString(stb.ToString());
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        #region Other events

        private void GetCheckClicked(object sender, EventArgs e)
        {
            if (flashCheckEdit1.GetBoolValue() == false)
            {
                txtCity.SetString("İstanbul");
                txtCountry.SetString("Türkiye");

                txtFCity.SetString("İstanbul");
                txtFCountry.SetString("Türkiye");
            }
            else
            {
                txtCity.SetString("");
                txtCountry.SetString("");
                txtFCity.SetString("");
                txtFCountry.SetString("");
            }
        }

        private void GetCustomerCode(object sender, ButtonPressedEventArgs e)
        {
            helper.GetCode("StCustomerAccount", "code", this, txtCode, 20000);
        }

        #endregion
    }
}