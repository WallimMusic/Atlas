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
    public partial class AtlasDateEdit : UserControl
    {
        public AtlasDateEdit()
        {
            InitializeComponent();
        }

        public void SetDate(DateTime Date)
        {
            flashDate.DateTime = Date;
        }

        public DateTime GetDate()
        {
            return DateTime.Parse(flashDate.DateTime.ToShortDateString());
        }

        private void flaDate_EditValueChanged(object sender, EventArgs e)
        {
            this.Tag = "1";
        }

        public void ClearData()
        {
            flashDate.Text = "";
        }

        private void flashDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                flashDate.Text = "";
        }

        private void flashDate_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void flashDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)
            //{
            //    string dateValue = flashDate.Text;
            //    DateTime value = DateTime.ParseExact(dateValue, "ddMMyyyy", null);
            //    flashDate.Text = value.ToShortDateString();
            //}
        }
    }
}
