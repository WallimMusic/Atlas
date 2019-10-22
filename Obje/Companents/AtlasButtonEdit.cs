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
    public partial class AtlasButtonEdit : UserControl
    {
        public AtlasButtonEdit()
        {
            InitializeComponent();
        }
        public string GetString()
        {
            return flaButtonEdit.Text;
        }

        public void SetString(string value)
        {
            flaButtonEdit.Text = value;
        }

        public void ClearData()
        {
            flaButtonEdit.Text = "";
        }

        public void SetPasswordChar()
        {
            flaButtonEdit.Properties.PasswordChar = '●';
        }

        private void flaText_EditValueChanged(object sender, EventArgs e)
        {
            this.Tag = "1";
        }


        private void flaButtonEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                flaButtonEdit.Text = "";
        }

        private void flaButtonEdit_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                flaButtonEdit.Text = "";
        }


    }
}
