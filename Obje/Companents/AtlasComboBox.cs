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
    public partial class AtlasComboBox : UserControl
    {
        public AtlasComboBox()
        {
            InitializeComponent();
        }

        public string GetString()
        {
            return flashCombo.Text;
        }

        public void SetString(string value)
        {
            flashCombo.Text = value;
        }

        public void SetData(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                flashCombo.Properties.Items.Add(row["Moduller"]);
            }
        }

        public void ClearData()
        {
            flashCombo.Text = "";
        }

        private void flaCombo_EditValueChanged(object sender, EventArgs e)
        {
            this.Tag = "1";
        }
    }
}
