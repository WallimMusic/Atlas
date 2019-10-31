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
using DevExpress.XtraGrid.Columns;

namespace Erp.Stock
{
    public partial class FrmBarcodeList : AtlasForm
    {
        public FrmBarcodeList()
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
        public string gelen = "";
        public int branchRef = 0;
        Helper helper = new Erp.Helper();

        #endregion

        private void FrmBarcodeList_Load(object sender, EventArgs e)
        {
            #region Create Table // tablonun columnları oluşturuldu.

            dtList.Columns.Add("Ref");
            dtList.Columns.Add("Seçim", typeof(bool));
            dtList.Columns.Add("Kart Kodu");
            dtList.Columns.Add("Kart Adı");
            dtList.Columns.Add("Beden");
            dtList.Columns.Add("Renk");
            dtList.Columns.Add("Barkod");
            dtList.Columns.Add("Birim Ref");
            dtList.Columns.Add("Birim Kodu");


            #endregion

            #region FillDataToTable // aktif kartlar çekilip dinamik olan tabloya dolduruldu.

            DataTable dtData = db.GetDataTable(@"SELECT  * FROM Stock_GetStockWithoutBarcode()");

            for (int i = 0; i < dtData.Rows.Count; i++)
            {
                DataRow row = dtList.NewRow();
                row["Ref"] = int.Parse(dtData.Rows[i][0].ToString());
                row["Seçim"] = false;
                row["Kart Kodu"] = dtData.Rows[i][1].ToString();
                row["Kart Adı"] = dtData.Rows[i][2].ToString();
                row["Beden"] = dtData.Rows[i][3].ToString();
                row["Renk"] = dtData.Rows[i][4].ToString();
                row["Barkod"] = dtData.Rows[i][5].ToString();
                row["Birim Ref"] = dtData.Rows[i][6].ToString();
                row["Birim Kodu"] = dtData.Rows[i][7].ToString();
                dtList.Rows.Add(row);
            }
            gridControl1.DataSource = dtList;
            #endregion

            #region Set Grid View  // grid view ayarları
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[7].Visible = false;

            gridView1.Columns[2].OptionsColumn.AllowEdit = false;
            gridView1.Columns[3].OptionsColumn.AllowEdit = false;
            gridView1.Columns[4].OptionsColumn.AllowEdit = false;
            gridView1.Columns[5].OptionsColumn.AllowEdit = false;
            gridView1.Columns[2].Group();
            gridView1.BestFitColumns();

            #endregion

        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Space)
                {
                    if (gridView1.GetFocusedRowCellValue("Seçim").ToString() == "True")
                        gridView1.SetFocusedRowCellValue("Seçim", false);
                    else
                        gridView1.SetFocusedRowCellValue("Seçim", true);
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    string barcode = "";
                    string oldBarcode, state = "";
                    int miktar;
                    int LastListRef;
                    DataRow row;
                    gridView1.Columns[2].UnGroup();

                    #region Plug
                    if (gelen == "Plug")
                    {
                        FrmOperation form = (FrmOperation)Application.OpenForms["FrmOperation"];
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            if (gridView1.GetRowCellValue(i, "Seçim").ToString() == "True")
                            {
                                if (form.grdGrid.RowCount - 1 > 0)
                                {
                                    for (int a = 0; a < form.grdGrid.RowCount - 1; a++)
                                    {
                                        barcode = gridView1.GetRowCellValue(i, "Barkod").ToString();
                                        oldBarcode = form.grdGrid.GetRowCellValue(a, "Barkod").ToString();
                                        if (barcode == oldBarcode)
                                        {
                                            miktar = int.Parse(form.grdGrid.GetRowCellValue(a, "Miktar").ToString());
                                            miktar++;
                                            form.grdGrid.SetRowCellValue(a, "Miktar", miktar);
                                            state = "true";
                                            break;
                                        }
                                        else
                                        {
                                            state = "false";
                                        }

                                    }
                                    if (state == "false")
                                    {
                                        row = form.dtBox.NewRow();
                                        row["Kart Ref"] = int.Parse(gridView1.GetRowCellValue(i, "Ref").ToString());
                                        row["Kart Kodu"] = gridView1.GetRowCellValue(i, "Kart Kodu").ToString();
                                        row["Kart Adı"] = gridView1.GetRowCellValue(i, "Kart Adı").ToString();
                                        row["Renk"] = gridView1.GetRowCellValue(i, "Renk").ToString();
                                        row["Beden"] = gridView1.GetRowCellValue(i, "Beden").ToString();
                                        row["Barkod"] = gridView1.GetRowCellValue(i, "Barkod").ToString();
                                        row["Birim Ref"] = gridView1.GetRowCellValue(i, "Birim Ref").ToString();
                                        row["Birim Kodu"] = gridView1.GetRowCellValue(i, "Birim Kodu").ToString();
                                        row["Miktar"] = 1;
                                        form.dtBox.Rows.Add(row);

                                    }
                                }
                                else
                                {
                                    row = form.dtBox.NewRow();
                                    row["Kart Ref"] = int.Parse(gridView1.GetRowCellValue(i, "Ref").ToString());
                                    row["Kart Kodu"] = gridView1.GetRowCellValue(i, "Kart Kodu").ToString();
                                    row["Kart Adı"] = gridView1.GetRowCellValue(i, "Kart Adı").ToString();
                                    row["Renk"] = gridView1.GetRowCellValue(i, "Renk").ToString();
                                    row["Beden"] = gridView1.GetRowCellValue(i, "Beden").ToString();
                                    row["Barkod"] = gridView1.GetRowCellValue(i, "Barkod").ToString();
                                    row["Birim Ref"] = gridView1.GetRowCellValue(i, "Birim Ref").ToString();
                                    row["Birim Kodu"] = gridView1.GetRowCellValue(i, "Birim Kodu").ToString();
                                    row["Miktar"] = 1;
                                    form.dtBox.Rows.Add(row);
                                }
                            }
                        }
                    }
                    #endregion

                    #region Sell List
                    else if (gelen == "List")
                    {
                        Sell.FrmSellPrices form = (Sell.FrmSellPrices)Application.OpenForms["FrmSellPrices"];
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            if (gridView1.GetRowCellValue(i, "Seçim").ToString() == "True")
                            {
                                if (form.grdGrid.RowCount - 1 > 0)
                                {
                                    for (int a = 0; a < form.grdGrid.RowCount - 1; a++)
                                    {
                                        barcode = gridView1.GetRowCellValue(i, "Barkod").ToString();
                                        oldBarcode = form.grdGrid.GetRowCellValue(a, "Barkod").ToString();
                                        if (barcode == oldBarcode)
                                        {
                                            state = "true";
                                            break;
                                        }
                                        else
                                            state = "false";

                                    }
                                    if (state == "false")
                                    {
                                        row = form.dtBox.NewRow();
                                        row["Kart Ref"] = int.Parse(gridView1.GetRowCellValue(i, "Ref").ToString());
                                        row["Kart Kodu"] = gridView1.GetRowCellValue(i, "Kart Kodu").ToString();
                                        row["Kart Adı"] = gridView1.GetRowCellValue(i, "Kart Adı").ToString();
                                        row["Renk"] = gridView1.GetRowCellValue(i, "Renk").ToString();
                                        row["Beden"] = gridView1.GetRowCellValue(i, "Beden").ToString();
                                        row["Barkod"] = gridView1.GetRowCellValue(i, "Barkod").ToString();
                                        row["Birim Ref"] = gridView1.GetRowCellValue(i, "Birim Ref").ToString();
                                        row["Birim Kodu"] = gridView1.GetRowCellValue(i, "Birim Kodu").ToString();
                                        row["Fiyat"] = 1;
                                        form.dtBox.Rows.Add(row);
                                    }
                                }
                                else
                                {
                                    row = form.dtBox.NewRow();
                                    row["Kart Ref"] = int.Parse(gridView1.GetRowCellValue(i, "Ref").ToString());
                                    row["Kart Kodu"] = gridView1.GetRowCellValue(i, "Kart Kodu").ToString();
                                    row["Kart Adı"] = gridView1.GetRowCellValue(i, "Kart Adı").ToString();
                                    row["Renk"] = gridView1.GetRowCellValue(i, "Renk").ToString();
                                    row["Beden"] = gridView1.GetRowCellValue(i, "Beden").ToString();
                                    row["Barkod"] = gridView1.GetRowCellValue(i, "Barkod").ToString();
                                    row["Birim Ref"] = gridView1.GetRowCellValue(i, "Birim Ref").ToString();
                                    row["Birim Kodu"] = gridView1.GetRowCellValue(i, "Birim Kodu").ToString();
                                    row["Fiyat"] = 1;
                                    form.dtBox.Rows.Add(row);
                                }
                            }
                        }
                    }
                    #endregion

                    #region Kampanya

                    else if (gelen == "Campaing")
                    {
                        Sell.FrmCampaings form = (Sell.FrmCampaings)Application.OpenForms["FrmCampaings"];
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            if (gridView1.GetRowCellValue(i, "Seçim").ToString() == "True")
                            {
                                if (form.grdGrid.RowCount - 1 > 0)
                                {
                                    for (int a = 0; a < form.grdGrid.RowCount - 1; a++)
                                    {
                                        barcode = gridView1.GetRowCellValue(i, "Barkod").ToString();
                                        oldBarcode = form.grdGrid.GetRowCellValue(a, "Barkod").ToString();
                                        if (barcode == oldBarcode)
                                        {
                                            state = "true";
                                            break;
                                        }
                                        else
                                            state = "false";

                                    }
                                    if (state == "false")
                                    {
                                        row = form.dtBox.NewRow();
                                        row["Kart Ref"] = int.Parse(gridView1.GetRowCellValue(i, "Ref").ToString());
                                        row["Kart Kodu"] = gridView1.GetRowCellValue(i, "Kart Kodu").ToString();
                                        row["Kart Adı"] = gridView1.GetRowCellValue(i, "Kart Adı").ToString();
                                        row["Renk"] = gridView1.GetRowCellValue(i, "Renk").ToString();
                                        row["Beden"] = gridView1.GetRowCellValue(i, "Beden").ToString();
                                        row["Barkod"] = gridView1.GetRowCellValue(i, "Barkod").ToString();
                                        form.dtBox.Rows.Add(row);
                                    }
                                }
                                else
                                {
                                    row = form.dtBox.NewRow();
                                    row["Kart Ref"] = int.Parse(gridView1.GetRowCellValue(i, "Ref").ToString());
                                    row["Kart Kodu"] = gridView1.GetRowCellValue(i, "Kart Kodu").ToString();
                                    row["Kart Adı"] = gridView1.GetRowCellValue(i, "Kart Adı").ToString();
                                    row["Renk"] = gridView1.GetRowCellValue(i, "Renk").ToString();
                                    row["Beden"] = gridView1.GetRowCellValue(i, "Beden").ToString();
                                    row["Barkod"] = gridView1.GetRowCellValue(i, "Barkod").ToString();
                                    form.dtBox.Rows.Add(row);
                                }
                            }
                        }
                    }

                    #endregion

                    #region İndirim

                    else if (gelen == "Discount")
                    {
                        Sell.FrmDiscount form = (Sell.FrmDiscount)Application.OpenForms["FrmDiscount"];
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            if (gridView1.GetRowCellValue(i, "Seçim").ToString() == "True")
                            {
                                if (form.grdGrid.RowCount - 1 > 0)
                                {
                                    for (int a = 0; a < form.grdGrid.RowCount - 1; a++)
                                    {
                                        barcode = gridView1.GetRowCellValue(i, "Barkod").ToString();
                                        oldBarcode = form.grdGrid.GetRowCellValue(a, "Barkod").ToString();
                                        if (barcode == oldBarcode)
                                        {
                                            state = "true";
                                            break;
                                        }
                                        else
                                            state = "false";

                                    }
                                    if (state == "false")
                                    {
                                        row = form.dtBox.NewRow();
                                        row["İndirim Tipi"] = 400;
                                        row["Kart Ref"] = int.Parse(gridView1.GetRowCellValue(i, "Ref").ToString());
                                        row["Kart Kodu"] = gridView1.GetRowCellValue(i, "Kart Kodu").ToString();
                                        row["Kart Adı"] = gridView1.GetRowCellValue(i, "Kart Adı").ToString();
                                        row["Renk"] = gridView1.GetRowCellValue(i, "Renk").ToString();
                                        row["Beden"] = gridView1.GetRowCellValue(i, "Beden").ToString();
                                        row["Barkod"] = gridView1.GetRowCellValue(i, "Barkod").ToString();
                                        row["Birim Ref"] = gridView1.GetRowCellValue(i, "Birim Ref").ToString();
                                        row["Birim Kodu"] = gridView1.GetRowCellValue(i, "Birim Kodu").ToString();


                                        string paramBarcode = gridView1.GetRowCellValue(i, "Barkod").ToString();
                                        db.AddParameterValue("@branchRef", branchRef);
                                        db.AddParameterValue("@barcode", paramBarcode);
                                        row["Eski Fiyat"] = decimal.Parse(db.GetScalarValue("select  dbo.Tools_GetLastActiveSellPrice(@barcode,@branchRef)").ToString());



                                        form.dtBox.Rows.Add(row);
                                    }
                                }
                                else
                                {
                                    row = form.dtBox.NewRow();
                                    row["İndirim Tipi"] = 400;
                                    row["Kart Ref"] = int.Parse(gridView1.GetRowCellValue(i, "Ref").ToString());
                                    row["Kart Kodu"] = gridView1.GetRowCellValue(i, "Kart Kodu").ToString();
                                    row["Kart Adı"] = gridView1.GetRowCellValue(i, "Kart Adı").ToString();
                                    row["Renk"] = gridView1.GetRowCellValue(i, "Renk").ToString();
                                    row["Beden"] = gridView1.GetRowCellValue(i, "Beden").ToString();
                                    row["Barkod"] = gridView1.GetRowCellValue(i, "Barkod").ToString();
                                    row["Birim Ref"] = gridView1.GetRowCellValue(i, "Birim Ref").ToString();
                                    row["Birim Kodu"] = gridView1.GetRowCellValue(i, "Birim Kodu").ToString();



                                    string paramBarcode = gridView1.GetRowCellValue(i, "Barkod").ToString();
                                    db.AddParameterValue("@branchRef", branchRef);
                                    db.AddParameterValue("@barcode", paramBarcode);
                                    row["Eski Fiyat"] = decimal.Parse(db.GetScalarValue("select  dbo.Tools_GetLastActiveSellPrice(@barcode,@branchRef)").ToString());



                                    form.dtBox.Rows.Add(row);
                                }
                            }
                        }
                    }

                    #endregion

                    #region Buy List 
                    else if (gelen == "Buy")
                    {
                        Buy.FrmBuyList form = (Buy.FrmBuyList)Application.OpenForms["FrmBuyList"];
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            if (gridView1.GetRowCellValue(i, "Seçim").ToString() == "True")
                            {
                                if (form.grdGrid.RowCount - 1 > 0)
                                {
                                    for (int a = 0; a < form.grdGrid.RowCount - 1; a++)
                                    {
                                        barcode = gridView1.GetRowCellValue(i, "Barkod").ToString();
                                        oldBarcode = form.grdGrid.GetRowCellValue(a, "Barkod").ToString();
                                        if (barcode == oldBarcode)
                                        {
                                            state = "true";
                                            break;
                                        }
                                        else
                                            state = "false";

                                    }
                                    if (state == "false")
                                    {
                                        row = form.dtBox.NewRow();
                                        row["Kart Ref"] = int.Parse(gridView1.GetRowCellValue(i, "Ref").ToString());
                                        row["Kart Kodu"] = gridView1.GetRowCellValue(i, "Kart Kodu").ToString();
                                        row["Kart Adı"] = gridView1.GetRowCellValue(i, "Kart Adı").ToString();
                                        row["Renk"] = gridView1.GetRowCellValue(i, "Renk").ToString();
                                        row["Beden"] = gridView1.GetRowCellValue(i, "Beden").ToString();
                                        row["Barkod"] = gridView1.GetRowCellValue(i, "Barkod").ToString();
                                        row["Birim Ref"] = gridView1.GetRowCellValue(i, "Birim Ref").ToString();
                                        row["Birim Kodu"] = gridView1.GetRowCellValue(i, "Birim Kodu").ToString();
                                        row["Fiyat"] = 1;
                                        form.dtBox.Rows.Add(row);
                                    }
                                }
                                else
                                {
                                    row = form.dtBox.NewRow();
                                    row["Kart Ref"] = int.Parse(gridView1.GetRowCellValue(i, "Ref").ToString());
                                    row["Kart Kodu"] = gridView1.GetRowCellValue(i, "Kart Kodu").ToString();
                                    row["Kart Adı"] = gridView1.GetRowCellValue(i, "Kart Adı").ToString();
                                    row["Renk"] = gridView1.GetRowCellValue(i, "Renk").ToString();
                                    row["Beden"] = gridView1.GetRowCellValue(i, "Beden").ToString();
                                    row["Barkod"] = gridView1.GetRowCellValue(i, "Barkod").ToString();
                                    row["Birim Ref"] = gridView1.GetRowCellValue(i, "Birim Ref").ToString();
                                    row["Birim Kodu"] = gridView1.GetRowCellValue(i, "Birim Kodu").ToString();
                                    row["Fiyat"] = 1;
                                    form.dtBox.Rows.Add(row);
                                }
                            }
                        }
                    }
                    #endregion

                    #region Buy Order
                    if (gelen == "Buy Order")
                    {
                        Buy.FrmBuyOrder form = (Buy.FrmBuyOrder)Application.OpenForms["FrmBuyOrder"];
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            if (gridView1.GetRowCellValue(i, "Seçim").ToString() == "True")
                            {
                                if (form.grdGrid.RowCount - 1 > 0)
                                {
                                    for (int a = 0; a < form.grdGrid.RowCount - 1; a++)
                                    {
                                        barcode = gridView1.GetRowCellValue(i, "Barkod").ToString();
                                        oldBarcode = form.grdGrid.GetRowCellValue(a, "Barkod").ToString();
                                        if (barcode == oldBarcode)
                                        {
                                            miktar = int.Parse(form.grdGrid.GetRowCellValue(a, "Miktar").ToString());
                                            miktar++;
                                            form.grdGrid.SetRowCellValue(a, "Miktar", miktar);
                                            state = "true";
                                            break;
                                        }
                                        else
                                        {
                                            state = "false";
                                        }

                                    }
                                    if (state == "false")
                                    {
                                        row = form.dtBox.NewRow();
                                        row["Kart Ref"] = int.Parse(gridView1.GetRowCellValue(i, "Ref").ToString());
                                        row["Kart Kodu"] = gridView1.GetRowCellValue(i, "Kart Kodu").ToString();
                                        row["Kart Adı"] = gridView1.GetRowCellValue(i, "Kart Adı").ToString();
                                        row["Renk"] = gridView1.GetRowCellValue(i, "Renk").ToString();
                                        row["Beden"] = gridView1.GetRowCellValue(i, "Beden").ToString();
                                        row["Barkod"] = gridView1.GetRowCellValue(i, "Barkod").ToString();
                                        row["Birim Ref"] = gridView1.GetRowCellValue(i, "Birim Ref").ToString();
                                        row["Birim Kodu"] = gridView1.GetRowCellValue(i, "Birim Kodu").ToString();
                                        row["Miktar"] = 1;

                                        db.AddParameterValue("@barcode", gridView1.GetRowCellValue(i, "Barkod").ToString());
                                        db.AddParameterValue("@branchRef", form.ledBranch.GetValue());
                                        string price = db.GetScalarValue("select  dbo.Tools_GetLastActiveBuyPrice(@barcode,@branchRef)").ToString();
                                        row["Birim Fiyat"] = price;
                                        decimal total = 1 * decimal.Parse(price);
                                        row["Toplam Tutar"] = total;

                                        form.dtBox.Rows.Add(row);

                                    }
                                }
                                else
                                {
                                    row = form.dtBox.NewRow();
                                    row["Kart Ref"] = int.Parse(gridView1.GetRowCellValue(i, "Ref").ToString());
                                    row["Kart Kodu"] = gridView1.GetRowCellValue(i, "Kart Kodu").ToString();
                                    row["Kart Adı"] = gridView1.GetRowCellValue(i, "Kart Adı").ToString();
                                    row["Renk"] = gridView1.GetRowCellValue(i, "Renk").ToString();
                                    row["Beden"] = gridView1.GetRowCellValue(i, "Beden").ToString();
                                    row["Barkod"] = gridView1.GetRowCellValue(i, "Barkod").ToString();
                                    row["Birim Ref"] = gridView1.GetRowCellValue(i, "Birim Ref").ToString();
                                    row["Birim Kodu"] = gridView1.GetRowCellValue(i, "Birim Kodu").ToString();
                                    row["Miktar"] = 1;
                                    db.AddParameterValue("@barcode", gridView1.GetRowCellValue(i, "Barkod").ToString());
                                    db.AddParameterValue("@branchRef", form.ledBranch.GetValue());
                                    string price = db.GetScalarValue("select  dbo.Tools_GetLastActiveBuyPrice(@barcode,@branchRef)").ToString();
                                    row["Birim Fiyat"] = price;
                                    decimal total = 1 * decimal.Parse(price);
                                    row["Toplam Tutar"] = total;
                                    form.dtBox.Rows.Add(row);
                                }
                            }
                        }
                        form.Calculate();
                    }
                    #endregion

                    #region Sell Order
                    if (gelen == "Sell Order")
                    {
                        Sell.FrmSellOrder form = (Sell.FrmSellOrder)Application.OpenForms["FrmSellOrder"];
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            if (gridView1.GetRowCellValue(i, "Seçim").ToString() == "True")
                            {
                                if (form.grdGrid.RowCount - 1 > 0)
                                {
                                    for (int a = 0; a < form.grdGrid.RowCount - 1; a++)
                                    {
                                        barcode = gridView1.GetRowCellValue(i, "Barkod").ToString();
                                        oldBarcode = form.grdGrid.GetRowCellValue(a, "Barkod").ToString();
                                        if (barcode == oldBarcode)
                                        {
                                            miktar = int.Parse(form.grdGrid.GetRowCellValue(a, "Miktar").ToString());
                                            miktar++;
                                            form.grdGrid.SetRowCellValue(a, "Miktar", miktar);
                                            state = "true";
                                            break;
                                        }
                                        else
                                        {
                                            state = "false";
                                        }

                                    }
                                    if (state == "false")
                                    {
                                        row = form.dtBox.NewRow();
                                        row["Kart Ref"] = int.Parse(gridView1.GetRowCellValue(i, "Ref").ToString());
                                        row["Kart Kodu"] = gridView1.GetRowCellValue(i, "Kart Kodu").ToString();
                                        row["Kart Adı"] = gridView1.GetRowCellValue(i, "Kart Adı").ToString();
                                        row["Renk"] = gridView1.GetRowCellValue(i, "Renk").ToString();
                                        row["Beden"] = gridView1.GetRowCellValue(i, "Beden").ToString();
                                        row["Barkod"] = gridView1.GetRowCellValue(i, "Barkod").ToString();
                                        row["Birim Ref"] = gridView1.GetRowCellValue(i, "Birim Ref").ToString();
                                        row["Birim Kodu"] = gridView1.GetRowCellValue(i, "Birim Kodu").ToString();
                                        row["Miktar"] = 1;

                                        db.AddParameterValue("@barcode", gridView1.GetRowCellValue(i, "Barkod").ToString());
                                        db.AddParameterValue("@branchRef", form.ledBranch.GetValue());
                                        string price = db.GetScalarValue("select  dbo.Tools_GetLastActiveSellPrice(@barcode,@branchRef)").ToString();
                                        row["Birim Fiyat"] = price;
                                        decimal total = 1 * decimal.Parse(price);
                                        row["Toplam Tutar"] = total;

                                        form.dtBox.Rows.Add(row);

                                    }
                                }
                                else
                                {
                                    row = form.dtBox.NewRow();
                                    row["Kart Ref"] = int.Parse(gridView1.GetRowCellValue(i, "Ref").ToString());
                                    row["Kart Kodu"] = gridView1.GetRowCellValue(i, "Kart Kodu").ToString();
                                    row["Kart Adı"] = gridView1.GetRowCellValue(i, "Kart Adı").ToString();
                                    row["Renk"] = gridView1.GetRowCellValue(i, "Renk").ToString();
                                    row["Beden"] = gridView1.GetRowCellValue(i, "Beden").ToString();
                                    row["Barkod"] = gridView1.GetRowCellValue(i, "Barkod").ToString();
                                    row["Birim Ref"] = gridView1.GetRowCellValue(i, "Birim Ref").ToString();
                                    row["Birim Kodu"] = gridView1.GetRowCellValue(i, "Birim Kodu").ToString();
                                    row["Miktar"] = 1;
                                    db.AddParameterValue("@barcode", gridView1.GetRowCellValue(i, "Barkod").ToString());
                                    db.AddParameterValue("@branchRef", form.ledBranch.GetValue());
                                    string price = db.GetScalarValue("select  dbo.Tools_GetLastActiveSellPrice(@barcode,@branchRef)").ToString();
                                    row["Birim Fiyat"] = price;
                                    decimal total = 1 * decimal.Parse(price);
                                    row["Toplam Tutar"] = total;
                                    form.dtBox.Rows.Add(row);
                                }
                            }
                        }
                        form.Calculate();
                    }
                    #endregion

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
            }
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            popupMenu1.ShowPopup(Cursor.Position);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            #region Select All Card Item // Karta ait tüm kaytıtların seçilmesi için
            if (!string.IsNullOrEmpty(gridView1.GetFocusedRowCellValue("Kart Kodu").ToString()))
            {
                string cardCode = gridView1.GetFocusedRowCellValue("Kart Kodu").ToString();
                gridView1.Columns[2].UnGroup();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, "Kart Kodu").ToString() == cardCode)
                        gridView1.SetRowCellValue(i, "Seçim", true);
                }
            }
            gridView1.Columns[2].Group();
            #endregion
        }
    }
}