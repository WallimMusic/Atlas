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

namespace Erp.Buy
{
    public partial class FrmOrderList : AtlasForm
    {
        public FrmOrderList()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelRibbon(ribbonControl1);
            AtlasCompanent.TemelGrid(grdGrid);
            AtlasCompanent.TemelGrid(gridView1);
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;


            grdGrid.OptionsView.ShowAutoFilterRow = true;
            grdGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

        }

        #region Methods

        Helper helper = new Erp.Helper();
        ErpManager db = new ErpManager();
        DataTable dtBidik = new DataTable();

        string Selected = "";

        void FillData()
        {
            DataTable dt = db.GetDataTable(@"SELECT        BO.Ref as Ref, BO.code AS [Kodu], BO.name AS [Adı], BO.Date AS [Veriliş Tarihi], BR.name as [Şube], WH.name as [Depo], BO.OkDate as [Onaylanma Tarihi]
            FROM            StBuyOrder BO with(nolock) 
            INNER JOIN AtlasSys.dbo.sysBranch BR ON BR.Ref = BO.branchRef
            INNER JOIN AtlasSys.dbo.sysWhouse WH ON WH.Ref = BO.whouseRef
            WHERE        (BO.state = 0)");
            gridControl1.DataSource = dt;
            gridView1.Columns[0].Visible = false;
            gridView1.BestFitColumns();


            DataTable dtOpen = db.GetDataTable(@"SELECT        BO.Ref as Ref, BO.code AS [Kodu], BO.name AS [Adı], BO.Date AS [Veriliş Tarihi], BR.name as [Şube], WH.name as [Depo]
            FROM            StBuyOrder BO with(nolock) 
            INNER JOIN AtlasSys.dbo.sysBranch BR ON BR.Ref = BO.branchRef
            INNER JOIN AtlasSys.dbo.sysWhouse WH ON WH.Ref = BO.whouseRef
            WHERE        (BO.state = 1)");


            dtBidik.Columns.Clear();
            dtBidik.Columns.Add("Seçim", typeof(bool));
            for (int i = 0; i < dtOpen.Columns.Count; i++)
                dtBidik.Columns.Add(dtOpen.Columns[i].ToString());


            for (int a = 0; a < dtOpen.Rows.Count; a++)
            {
                DataRow row = dtBidik.NewRow();
                row[0] = false;
                row[1] = dtOpen.Rows[a]["Ref"];
                row[2] = dtOpen.Rows[a]["Kodu"];
                row[3] = dtOpen.Rows[a]["Adı"];
                row[4] = DateTime.Parse(dtOpen.Rows[a]["Veriliş Tarihi"].ToString()).ToShortDateString();
                row[5] = dtOpen.Rows[a]["Şube"];
                row[6] = dtOpen.Rows[a]["Depo"];
                dtBidik.Rows.Add(row);
            }
            bindData.DataSource = dtBidik;
            grdGrid.Columns[1].Visible = false;
            grdGrid.BestFitColumns();

            grdGrid.Columns[0].OptionsColumn.AllowEdit = true;
            grdGrid.Columns[1].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[2].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[3].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[4].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[5].OptionsColumn.AllowEdit = false;
            grdGrid.Columns[6].OptionsColumn.AllowEdit = false;
        }

        #endregion

        private void FrmOrderList_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void bbiShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int Ref = 0;
            if (Selected == "grid1")
                Ref = int.Parse(grdGrid.GetFocusedRowCellValue("Ref").ToString());
            else if (Selected == "grid2")
                Ref = int.Parse(gridView1.GetFocusedRowCellValue("Ref").ToString());


            FrmBuyOrder order = new FrmBuyOrder();
            order._FormMod = Enums.enmFormMod.Diger;
            order._Ref = Ref;
            order.ShowDialog();


        }

        private void bbiOrderAccept_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                grdGrid.FocusedRowHandle = -1;
                if (grdGrid.RowCount > 0)
                {
                    for (int i = 0; i < grdGrid.RowCount; i++)
                    {
                        if (grdGrid.GetRowCellValue(i, "Seçim").ToString() == "True")
                        {
                            int REf = int.Parse(grdGrid.GetRowCellValue(i, "Ref").ToString());
                            db.AddParameterValue("@state", false);
                            db.AddParameterValue("@ref", REf);
                            db.AddParameterValue("@date", DateTime.Now.ToShortDateString(), SqlDbType.Date);
                            db.RunCommand("update StBuyOrder set state=@state,okDate=@date where Ref=@ref");
                        }
                    }
                    XtraMessageBox.Show("İşlem başarıyla kaydedildi.", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillData();
                }


            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Selected = "grid2";
        }

        private void grdGrid_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Selected = "grid1";
        }
    }
}