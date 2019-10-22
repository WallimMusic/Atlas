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
using Obje.Companents;
namespace Erp
{
    public partial class FrmErrorForm : AtlasForm
    {
        public FrmErrorForm()
        {

            InitializeComponent();
            Obje.Classes.AtlasCompanent.AForm(this);
        }

        AtlasChangeState c = new AtlasChangeState();

        private void FrmErrorForm_Load(object sender, EventArgs e)
        {
            c.StateStabil(this);
        }
    }
}