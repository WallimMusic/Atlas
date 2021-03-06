﻿using System;
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
using Sys;
namespace Sys
{
    public partial class FrmUnits : AtlasForm
    {
        public FrmUnits()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);
            AtlasCompanent.TemelBar(barMenu);
            AtlasCompanent.TemelGrid(grdGrid);
        }

        #region Methods

        AccessManager db = new AccessManager();
        Helper helper = new Helper();
        DialogResult result;

        bool active;
        int REf, RowCount, fraction;
        string  name, type, nat, symbol;



        void FillData()
        {
            bindCountry.DataSource = db.GetDataTable("select * from sysUnit order by Ref ASC");
            RowCount = grdGrid.RowCount;
        }

        #endregion

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

                grdGrid.FocusedRowHandle = -1;

                for (int i = 0; i < grdGrid.RowCount - 1; i++)
                {

                    if (string.IsNullOrEmpty(grdGrid.GetRowCellValue(i, "Ref").ToString()))
                        REf = 0;
                    else
                        REf = int.Parse(grdGrid.GetRowCellValue(i, "Ref").ToString());

                    if (string.IsNullOrEmpty(grdGrid.GetRowCellValue(i, "active").ToString()))
                        active = false;
                    else
                        active = bool.Parse(grdGrid.GetRowCellValue(i, "active").ToString());

                    nat = (grdGrid.GetRowCellValue(i, "nationalCode").ToString());
                    name = grdGrid.GetRowCellValue(i, "unitName").ToString();
                    type = grdGrid.GetRowCellValue(i, "unitType").ToString();
                    symbol = grdGrid.GetRowCellValue(i, "symbol").ToString();
                    fraction = int.Parse(grdGrid.GetRowCellValue(i, "fraction").ToString());

                    db.AddParameterValue("@ref", REf);
                    db.AddParameterValue("@active", active);
                    db.AddParameterValue("@name", name);
                    db.AddParameterValue("@symbol", symbol);
                    db.AddParameterValue("@type", type);
                    db.AddParameterValue("@natCode", nat);
                    db.AddParameterValue("@frac", fraction);
                    db.RunCommand("sp_sysUnit_AddOrUp", CommandType.StoredProcedure);

                }
                XtraMessageBox.Show("İşlem başarıyla tamamlandı.", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillData();
                RowCount = grdGrid.RowCount;
                this.Close();
            
 
               
       
        }

        private void grdGrid_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            pmMenu.ShowPopup(Cursor.Position);
        }

        private void btnDeleteLine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                System.Data.DataRow row = grdGrid.GetDataRow(grdGrid.FocusedRowHandle);

                if (!string.IsNullOrEmpty(row[0].ToString()) && row[0].ToString() != "0")
                {
                    result = XtraMessageBox.Show("Seçili kaydı silmek istediğinize emin misiniz?\n\rKaydet işlemi yapılmadan son düzenlemeler geçerli olmayacaktır.", "Soru?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        REf = int.Parse(row[0].ToString());
                        grdGrid.DeleteRow(grdGrid.FocusedRowHandle);
                        db.AddParameterValue("@Ref", REf);
                        db.RunCommand("delete from sysUnit where Ref=@Ref");

                        XtraMessageBox.Show("İşlem başarıyla tamamlandı.", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    if (row[0].ToString() != "0")
                    grdGrid.DeleteRow(grdGrid.FocusedRowHandle);
            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
            }
        }

        private void btnEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void FrmUnits_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (grdGrid.RowCount != RowCount)
            {
                DialogResult answer;
                answer = XtraMessageBox.Show("Yaptığınız değişikler kaydedilmeyecek.\n\rVazgeçmek istediğinize emin misiniz?", "Soru?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer == DialogResult.No)
                    e.Cancel = true;
                else
                    e.Cancel = false;
            }
        }

        private void FrmUnits_Load(object sender, EventArgs e)
        {
            FillData();
            RowCount = grdGrid.RowCount;
        }
    }
}