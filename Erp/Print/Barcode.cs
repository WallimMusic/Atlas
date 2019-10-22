using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Erp.Print
{
    public partial class Barcode : DevExpress.XtraReports.UI.XtraReport
    {
        public Barcode()
        {
            InitializeComponent();
        }
        public string barcode = "", name = "", size = "", price = "";
        bool local = true;
        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblBarcode.Text = barcode;
            lblBarcode2.Text = barcode;

            lblPrice.Text = price + "₺";
            lblPrice2.Text = price + "₺";

            lblProductName.Text = name;
            lblProductName2.Text = name;

            lblSize.Text = size;
            lblSize2.Text = size;

            xRbarcode.Text = barcode;
            xRBarcode2.Text = barcode;

            if(local)
            {
                xrPictureBox1.Visible = true;
                xrPictureBox2.Visible = true;
            }


        }
    }
}
