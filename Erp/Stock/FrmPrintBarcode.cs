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
using DevExpress.XtraReports.UI;

namespace Erp.Stock
{
    public partial class FrmPrintBarcode : AtlasForm
    {
        public FrmPrintBarcode()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelGrid(grdGrid);
            AtlasCompanent.TemelRibbon(ribbonControl1);
            ledCard.flaLookUp.EditValueChanged += fillGrid;
        }

        ErpManager db = new ErpManager();
        DataTable dtList = new DataTable();

        private void FrmPrintBarcode_Load(object sender, EventArgs e)
        {

            ledCard.flaLookUp.Properties.ValueMember = "Ref";
            ledCard.flaLookUp.Properties.DisplayMember = "code";
            ledCard.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ref", Caption = "dbNo", Visible = false });
            ledCard.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "code", Caption = "Kodu" });
            ledCard.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "name", Caption = "Adı" });
            ledCard.flaLookUp.Properties.DataSource = db.GetDataTable("select * from StStockCard");

            dtList.Columns.Add("Seçim", typeof(bool));
            dtList.Columns.Add("Beden");
            dtList.Columns.Add("Renk");
            dtList.Columns.Add("Barkod");


            dgwGrid.DataSource = dtList;
            grdGrid.Columns[1].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[2].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[3].OptionsColumn.AllowEdit = false;
            grdGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            grdGrid.OptionsView.ShowAutoFilterRow = false;
        }

        private void btnEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void fillGrid(object sender, EventArgs e)
        {
            if (ledCard.GetValue() != 0)
            {
                dtList.Rows.Clear();
                db.AddParameterValue("@ref", ledCard.GetValue());
                DataTable dt = db.GetDataTable("select * from StStockCardBarcodes where cardRef=@ref");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dtList.NewRow();
                    row["Beden"] = dt.Rows[i]["size"].ToString();
                    row["Renk"] = dt.Rows[i]["color"].ToString();
                    row["Barkod"] = dt.Rows[i]["barcode"].ToString();
                    dtList.Rows.Add(row);
                    db.AddParameterValue("@ref", ledCard.GetValue());
                    flashTextBox1.SetString(db.GetScalarValue("select name from StStockCard where Ref=@ref").ToString());
                }
                grdGrid.RefreshData();
                grdGrid.BestFitColumns();

            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Print.Barcode barcode = new Print.Barcode();            
            ReportPrintTool printTool = new ReportPrintTool(barcode);
            printTool.ShowRibbonPreviewDialog();
        }
    }
}