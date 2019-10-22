using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Obje;
namespace Obje.Companents
{
    public partial class AtlasLookUp : UserControl
    {
        public AtlasLookUp()
        {
            InitializeComponent();
        }

        public int GetValue()
        {
            int ID = 0;

            if (flaLookUp.EditValue != null)
                ID = int.Parse(flaLookUp.EditValue.ToString());

            return ID;

        }

        public void ClearData()
        {
            flaLookUp.EditValue = null;
        }

        public string GetStringValue()
        {
            string ID = "0";

            if (flaLookUp.EditValue != null)
                ID = flaLookUp.EditValue.ToString();

            return ID;
        }

        public void SetString(string text)
        {
            flaLookUp.Text = text;
        }

        public void SetData(DataTable Dt)
        {
            flaLookUp.Properties.DataSource = Dt;
        }

        public void SetData(List<object> Listim)
        {
            flaLookUp.Properties.DataSource = Listim;
        }

        //public void SetData(BindingList<IEntity> Listim)
        //{
        //    flaLookUp.Properties.DataSource = Listim;
        //}

        public void SetValue(int ID)
        {
            flaLookUp.EditValue = ID;
        }

        public void SetStringValue(string value)
        {
            flaLookUp.EditValue = value;
        }

        public string GetString()
        {
            return flaLookUp.Text;
        }

        private void flaLookUp_EditValueChanged(object sender, EventArgs e)
        {
            this.Tag = "1";
        }
    }
}
