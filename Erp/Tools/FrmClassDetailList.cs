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
using DevExpress.XtraGrid.Views.Grid;

namespace Erp.Tools
{
    public partial class FrmClassDetailList : AtlasForm
    {
        public FrmClassDetailList()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelGrid(grdGrid);
            grdGrid.OptionsBehavior.Editable = false;
            grdGrid.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
        }
        ErpManager db = new ErpManager();
        private void FrmClassDetailList_Load(object sender, EventArgs e)
        {
            db.AddParameterValue("@ref", this._Ref);
            db.AddParameterValue("@status", true);
            DataTable dtDetail = db.GetDataTable("SELECT Ref, code as [Özellik Kodu],name as [Özellik Adı],status as [Özellik Durumu] FROM StStockCardClassDetail where classRef=@ref and status=@status");

            dgwGrid.DataSource = dtDetail;
            grdGrid.Columns[0].Visible = false;
        }

        private void GrdGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(grdGrid.GetFocusedRowCellValue("Ref").ToString()))
                {
                    Stock.FrmStokCard form = (Stock.FrmStokCard)Application.OpenForms["FrmStokCard"];
                    form.codeClass = grdGrid.GetFocusedRowCellValue("Özellik Kodu").ToString();
                    form.nameClass = grdGrid.GetFocusedRowCellValue("Özellik Adı").ToString();
                    form.classDetailRef = int.Parse(grdGrid.GetFocusedRowCellValue("Ref").ToString());
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}