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
    public partial class FrmServiceList : AtlasForm
    {
        public FrmServiceList()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelGrid(gridView1);
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            gridView1.OptionsView.ShowAutoFilterRow = true;
        }

        #region Definitions

        ErpManager db = new ErpManager();
        DataTable dtList = new DataTable();
        public string come = "";
        Helper helper = new Erp.Helper();

        #endregion



        private void FrmServiceList_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.GetDataTable("select * from StBuyServices");
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[0].Caption = "Ref";
            gridView1.Columns[1].Caption = "Hizmet Kodu";
            gridView1.Columns[2].Caption = "Hizmet Adı";
            gridView1.BestFitColumns();
            gridView1.OptionsBehavior.Editable = false;
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{

            if (e.KeyCode == Keys.Enter)
            {

                #region Service Order
                if (come == "Service Order")
                {

                    if (!string.IsNullOrEmpty(gridView1.GetFocusedRowCellValue("ref").ToString()))
                    {

                        Buy.FrmServiceOrder form = (Buy.FrmServiceOrder)Application.OpenForms["FrmServiceOrder"];

                        DataRow row = form.dtBox.NewRow();

                        row["Hizmet Kodu"] = gridView1.GetFocusedRowCellValue("code").ToString();
                        row["Hizmet Adı"] = gridView1.GetFocusedRowCellValue("name").ToString();
                        row["Hizmet Ref"] = int.Parse(gridView1.GetFocusedRowCellValue("ref").ToString());
                        row["Birim Fiyat"] = "1.00";
                        row["Miktar"] = 1;
                        form.dtBox.Rows.Add(row);


                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }

                }
            }
            #endregion


            //}
            //catch (Exception)
            //{

            //}
        }
    }
}