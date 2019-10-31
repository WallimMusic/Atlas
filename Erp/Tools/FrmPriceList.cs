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

namespace Erp.Tools
{
    public partial class FrmPriceList : AtlasForm
    {
        public FrmPriceList()
        {

            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelGrid(grdGrid);
        }

        public string barcode, type, branchRef, cardCode;
        ErpManager db = new ErpManager();
        DataTable dt;

        private void grdGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (type == "Buy Order")
                {
                    Buy.FrmBuyOrder form = (Buy.FrmBuyOrder)Application.OpenForms["FrmBuyOrder"];
                    form.grdGrid.CellValueChanged -= form.grdGrid_CellValueChanged;
                    decimal price = decimal.Parse(grdGrid.GetFocusedRowCellValue("Fiyatı").ToString());
                    for (int i = 0; i < form.grdGrid.RowCount - 1; i++)
                    {
                        if (form.grdGrid.GetRowCellValue(i, "Kart Kodu").ToString() == cardCode)
                            form.grdGrid.SetRowCellValue(i, "Birim Fiyat", price);

                    }
                    form.Calculate();
                    form.grdGrid.CellValueChanged += form.grdGrid_CellValueChanged;
                    this.Close();
                }

                else if (type == "Sell Order")
                {
                    Sell.FrmSellOrder form = (Sell.FrmSellOrder)Application.OpenForms["FrmSellOrder"];
                    form.grdGrid.CellValueChanged -= form.grdGrid_CellValueChanged;
                    decimal price = decimal.Parse(grdGrid.GetFocusedRowCellValue("Fiyatı").ToString());
                    for (int i = 0; i < form.grdGrid.RowCount - 1; i++)
                    {
                        if (form.grdGrid.GetRowCellValue(i, "Kart Kodu").ToString() == cardCode)
                            form.grdGrid.SetRowCellValue(i, "Birim Fiyat", price);

                    }
                    form.Calculate();
                    form.grdGrid.CellValueChanged += form.grdGrid_CellValueChanged;
                    this.Close();
                }
            }

        }

        private void FrmPriceList_Load(object sender, EventArgs e)
        {
            if (type == "Buy Order")
            {
                db.AddParameterValue("@barcode", barcode);
                db.AddParameterValue("@branchRef", branchRef);
                dt = db.GetDataTable(@"SELECT * FROM Tools_GetBuyPriceList(@branchRef,@barcode)");
            }
            else if (type == "Sell Order")
            {
                db.AddParameterValue("@barcode", barcode);
                db.AddParameterValue("@branchRef", branchRef);
                dt = db.GetDataTable(@"SELECT * FROM Tools_GetSellPriceList(@branchRef,@barcode)");
            }
            dgwGrid.DataSource = dt;
            grdGrid.OptionsBehavior.Editable = false;
            grdGrid.BestFitColumns();


        }
    }
}