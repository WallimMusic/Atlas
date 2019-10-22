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
    public partial class AtlasTextBox : UserControl
    {
        public AtlasTextBox()
        {
            InitializeComponent();
        }

        public string GetString()
        {
            return flaText.Text;
        }

        public void SetString(string value)
        {
            flaText.Text = value;
        }

        public void ClearData()
        {
            flaText.Text = "";
        }

        public void SetPasswordChar()
        {
            flaText.Properties.PasswordChar = '●';
        }

        private void flaText_EditValueChanged(object sender, EventArgs e)
        {
            this.Tag = "1";
        }

        private void flaText_KeyUp(object sender, KeyEventArgs e)
        {
         
        }
    }
}
