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
    public partial class FrmPersonReturn : AtlasForm
    {
        public FrmPersonReturn()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
        }
        AccessManager db = new AccessManager();
        Helper helper = new IK.Helper();
        AtlasChangeState c = new AtlasChangeState();
        private void FrmPersonReturn_Load(object sender, EventArgs e)
        {
            atlasDateEdit1.SetDate(DateTime.Now);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DialogResult cevap;
                cevap = XtraMessageBox.Show("Personelin dönüşü gerçekleşecek.\n\rOnaylıyor musunuz?", "SORU?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    db.AddParameterValue("@date", atlasDateEdit1.GetDate(), SqlDbType.Date);
                    db.AddParameterValue("@date2", "");
                    db.AddParameterValue("@ref", _Ref);
                    db.RunCommand("update tbPerson set SDate=@date, ExitDate=@date2 where Ref=@ref");
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