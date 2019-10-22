using System;
using System.Windows.Forms;
using Obje;
namespace Obje.Companents
{
    public partial class AtlasCheckEdit : UserControl
    {
        public AtlasCheckEdit()
        {
            InitializeComponent();
        }
        public bool GetBoolValue()
        {
            bool state = false;

            if (flaCheck.Checked)
                state = true;

            return state;
        }

        public void SetBoolValue(bool Value)
        {
            if (Value)
                flaCheck.Checked = true;
            else
                flaCheck.Checked = false;
        }

        public Int16 GetIntValue()
        {
            Int16 state = 0;

            if (flaCheck.Checked)
                state = 1;

            return state;
        }

        public void SetIntValue(Int16 Value)
        {
            if (Value == 0)
                flaCheck.Checked = false;
            else
                flaCheck.Checked = true;
        }

        public void SetValueAktif(bool Value)
        {
            if (Value == true)
            {
                flaCheck.Checked = true;
                flaCheck.Text = "Aktif";
            }
            else
            {
                flaCheck.Checked = false;
                flaCheck.Text = "Pasif";
            }
        }

        public void SetString(string value)
        {
            flaCheck.Text = value;
        }

        public string GetString()
        {
            return flaCheck.Text;
        }

        private void flaCheck_CheckedChanged(object sender, EventArgs e)
        {
            this.Tag = "1";
        }

    }
}
