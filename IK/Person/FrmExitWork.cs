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

namespace IK.Person
{
    public partial class FrmExitWork : AtlasForm
    {
        public FrmExitWork()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
        }
        AccessManager db = new AccessManager();
        Helper helper = new IK.Helper();
        AtlasChangeState c = new AtlasChangeState();
        int kullanilan = 0;
        int kazanilan = 0;
        private void FrmExitWork_Load(object sender, EventArgs e)
        {
            DateTime dateNow = DateTime.Now;
            db.AddParameterValue("@ref", _Ref);
            kazanilan = int.Parse(db.GetScalarValue("Select gain from tbPerson where Ref=@ref").ToString());

            db.AddParameterValue("@pRef", _Ref);
            if (!string.IsNullOrEmpty(db.GetScalarValue("Select SUM(pRequest) from tbPermission where pRef=@pRef").ToString()))
            {
                db.AddParameterValue("@pRef", _Ref);
                kullanilan = int.Parse(db.GetScalarValue("Select SUM(pRequest) from tbPermission where pRef=@pRef").ToString());
            }


            atlasTextBox1.SetString((kazanilan - kullanilan).ToString());
            atlasTextBox1.Enabled = false;

            atlasDateEdit1.SetDate(dateNow);


        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        void Calculate()
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DialogResult cevap;
                cevap = XtraMessageBox.Show("Personelin çıkışı gerçekleşecek.\n\rOnaylıyor musunuz?", "SORU?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    db.AddParameterValue("@date", atlasDateEdit1.GetDate(), SqlDbType.Date);
                    db.AddParameterValue("@ref", _Ref);
                    db.RunCommand("update tbPerson set ExitDate=@date where Ref=@ref");
                }
                XtraMessageBox.Show("İşlem başarıyla tamamlandı.", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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