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
    public partial class AtlasMemoEdit : UserControl
    {
        public AtlasMemoEdit()
        {
            InitializeComponent();
        }

        public string GetString()
        {
            return flashMemo.Text;
        }

        public void SetString(string value)
        {
            flashMemo.Text = value;
        }

        public void ClearData()
        {
            flashMemo.Text = "";
        }

        private void flaMemo_EditValueChanged(object sender, EventArgs e)
        {
            this.Tag = "1";
        }

    }
}
