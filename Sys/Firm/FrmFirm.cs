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

namespace SYS
{
    public partial class FrmFirm : AtlasForm
    {
        public FrmFirm()
        {
            InitializeComponent();
            Obje.Classes.AtlasCompanent.AForm(this);
            Obje.Classes.AtlasCompanent.TemelBar(barMenu);


        }

        #region Methods

        AtlasChangeState c = new AtlasChangeState();
        AccessManager db = new AccessManager();
        Helper helper = new Helper();
        StringBuilder stb = new StringBuilder();

        int dbRef = 0, no = 0;
        string code = "", name = "";
        string newName;
        int codeCount;
        int noCount;
        DataTable dtControl = new DataTable();
        bool Control()
        {
            stb.Clear();
            if (!string.IsNullOrEmpty(txtFirmNo.GetString()))
            {
                dtControl.Clear();
                db.AddParameterValue("@no", txtFirmNo.GetString());
                dtControl = db.GetDataTable("select no from sysFirm where no=@no");
                if (dtControl.Rows.Count > 0)
                    noCount = int.Parse(dtControl.Rows[0][0].ToString());
            }
            if (!string.IsNullOrEmpty(txtFirmCode.GetString()))
            {
                dtControl.Clear();
                db.AddParameterValue("@code", txtFirmCode.GetString());
                dtControl = db.GetDataTable("select code from sysFirm where code=@code");
                if (dtControl.Rows.Count > 0)
                    codeCount = int.Parse(dtControl.Rows[0][0].ToString());
            }


            if (_FormMod == Enums.enmFormMod.Yeni && noCount > 0)
                stb.AppendLine("Böyle bir firma numarası sistemde mevcut.");

            if (string.IsNullOrEmpty(txtFirmNo.GetString()))
                stb.AppendLine("Firma numarası boş geçilemez.");
            else
                no = int.Parse(txtFirmNo.GetString());

            if (_FormMod == Enums.enmFormMod.Yeni && codeCount > 0)
                stb.AppendLine("Böyle bir firma kodu sistemde mevcut.");

            if (string.IsNullOrEmpty(txtFirmCode.GetString()))
                stb.AppendLine("Firma kodu boş geçilemez.");
            else
                code = txtFirmCode.GetString();

            if (string.IsNullOrEmpty(txtFirmName.GetString()))
                stb.AppendLine("Firma adı boş geçilemez.");
            else
                name = txtFirmName.GetString();

            if (string.IsNullOrEmpty(ledVeritabani.GetString()))
                stb.AppendLine("Firma veritabanı boş geçilemez.");
            else
                dbRef = ledVeritabani.GetValue();

            if (stb.ToString().Length <= 0)
                return true;
            else
                return false;
        }


        void FillLookUp()
        {
            ledVeritabani.flaLookUp.Properties.Columns.Clear();
            ledUlke.flaLookUp.Properties.Columns.Clear();

            ledVeritabani.flaLookUp.Properties.ValueMember = "Ref";
            ledVeritabani.flaLookUp.Properties.DisplayMember = "name";
            ledVeritabani.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ref", Caption = "dbNo", Visible = false });
            ledVeritabani.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "name", Caption = "Adı" });
            ledVeritabani.flaLookUp.Properties.DataSource = db.GetDataTable("select * from sysDatabase");


            ledUlke.flaLookUp.Properties.ValueMember = "Ref";
            ledUlke.flaLookUp.Properties.DisplayMember = "name";
            ledUlke.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ref", Caption = "plateNo", Visible = false });
            ledUlke.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "name", Caption = "Adı" });
            ledUlke.flaLookUp.Properties.DataSource = db.GetDataTable("select * from sysCountry");
        }


        #endregion

        private void btnEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void FrmFirm_Load(object sender, EventArgs e)
        {
            helper.ClearForm(this);
            chkActive.SetBoolValue(true);
            chkActive.SetString("Aktif");
            FillLookUp();

            if (_FormMod == Enums.enmFormMod.Guncelle)
            {
                db.AddParameterValue("@Ref", this._Ref);
                DataTable dtFirm = db.GetDataTable("select * from sysFirm where Ref=@ref");

                ledVeritabani.SetValue(int.Parse(dtFirm.Rows[0][1].ToString()));
                txtFirmNo.SetString(dtFirm.Rows[0][2].ToString());
                chkActive.SetBoolValue(bool.Parse(dtFirm.Rows[0][3].ToString()));
                txtFirmCode.SetString(dtFirm.Rows[0][4].ToString());
                txtFirmName.SetString(dtFirm.Rows[0][5].ToString());
                txtAddress.SetString(dtFirm.Rows[0][6].ToString());
                ledSehir.SetValue(int.Parse(dtFirm.Rows[0][7].ToString()));
                ledUlke.SetValue(int.Parse(dtFirm.Rows[0][8].ToString()));
                txtTaxName.SetString(dtFirm.Rows[0][9].ToString());
                txtTax.SetString(dtFirm.Rows[0][10].ToString());
                txtTel1.SetString(dtFirm.Rows[0][11].ToString());
                txtTel2.SetString(dtFirm.Rows[0][12].ToString());
                txtTel3.SetString(dtFirm.Rows[0][13].ToString());
                txtMail.SetString(dtFirm.Rows[0][14].ToString());
                txtWeb.SetString(dtFirm.Rows[0][15].ToString());

                if (!string.IsNullOrEmpty(dtFirm.Rows[0][16].ToString()))
                    pictureEdit1.Image = Image.FromFile(Application.StartupPath + "\\Images\\Firm\\" + dtFirm.Rows[0][16].ToString());

            }

            c.StateStabil(this);


        }

        private void ledUlke_Validated(object sender, EventArgs e)
        {

            ledSehir.flaLookUp.Properties.Columns.Clear();
            ledSehir.flaLookUp.Properties.ValueMember = "Ref";
            ledSehir.flaLookUp.Properties.DisplayMember = "name";
            ledSehir.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ref", Caption = "No", Visible = false });
            ledSehir.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "name", Caption = "Adı" });
            db.AddParameterValue("@ref", ledUlke.GetValue());
            ledSehir.flaLookUp.Properties.DataSource = db.GetDataTable("select * from sysCity where countryRef=@ref");
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
                        string goal = Application.StartupPath + @"\\Images\\Firm\\";
                        newName = GuidKey + "." + words[1].ToString();
                        File.Copy(pictureEdit1.GetLoadedImageLocation().ToString(), goal + newName);

                    }

                    db.AddParameterValue("@ref", this._Ref);
                    db.AddParameterValue("@dbRef", dbRef);
                    db.AddParameterValue("@no", no);
                    db.AddParameterValue("@active", chkActive.GetBoolValue());
                    db.AddParameterValue("@code", code);
                    db.AddParameterValue("@name", name);
                    db.AddParameterValue("@address", txtAddress.GetString());
                    db.AddParameterValue("@cityRef", ledSehir.GetValue());
                    db.AddParameterValue("@countrRef", ledUlke.GetValue());
                    db.AddParameterValue("@taxOffice", txtTaxName.GetString());
                    db.AddParameterValue("@taxNo", txtTax.GetString());
                    db.AddParameterValue("@phoneNo1", txtTel1.GetString());
                    db.AddParameterValue("@phoneNo2", txtTel2.GetString());
                    db.AddParameterValue("@faxNo", txtTel3.GetString());
                    db.AddParameterValue("@eMail", txtMail.GetString());
                    db.AddParameterValue("@web", txtWeb.GetString());
                    db.AddParameterValue("@path", newName);
                    db.RunCommand("sp_sysFirm_AddOrUp", CommandType.StoredProcedure);
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
    }
}