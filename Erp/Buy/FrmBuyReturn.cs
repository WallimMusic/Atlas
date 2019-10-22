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
using DevExpress.XtraEditors.Repository;

namespace Erp.Buy
{
    public partial class FrmBuyReturn : AtlasForm
    {
        public FrmBuyReturn()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelRibbon(ribbonControl1);
            AtlasCompanent.TemelGrid(grdGrid);
            //ledBranch.flaLookUp.EditValueChanged += getWhouse;
        }

        #region Methods
        #endregion

        #region Defi
        ErpManager db = new ErpManager();
        AccessManager sysDb = new AccessManager();
        Helper helper = new Helper();
        Obje.Classes.AtlasChangeState c = new AtlasChangeState();
        StringBuilder stb = new StringBuilder();


        int RowCount;
        public DataTable dtBox = new DataTable();
        DataTable dtReturn = new DataTable();
        public string Type;
        DataTable dtDetail = new DataTable();
        FrmErpMain main = (FrmErpMain)Application.OpenForms["FrmErpMain"];
        bool ok = false;

        DialogResult result;
        #endregion

        private void FrmBuyReturn_Load(object sender, EventArgs e)
        {

        }
    }
}