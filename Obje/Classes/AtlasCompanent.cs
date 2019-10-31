using DevExpress.Images;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraNavBar;
using System;
using System.Drawing;
using System.Windows.Forms;
using Obje;
using Obje.Classes;
using DevExpress.XtraGrid;
using DevExpress.XtraBars.Ribbon;

namespace Obje.Classes
{
    public class AtlasCompanent
    {
        #region Grid
        public static void TemelGrid(DevExpress.XtraGrid.Views.Grid.GridView view)
        {

            view.GridControl.Resize += dgw_Resize;

            // best fit column
            view.BestFitColumns();

            // gridlerin altındaki navigatörü gösteriyor.
            view.GridControl.UseEmbeddedNavigator = true;

            // son satıra focusluyor.
            view.RowLoaded += View_RowLoaded;


            // filtre verildiğinde alttaki filtrenin gözükmemesini sağlıyor.
            view.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;

            //gruplama alanın kapatılması
            view.OptionsView.ShowGroupPanel = false;

            //satır renklendiriyor.
            view.CustomDrawCell += View_CustomDrawCell;

            //focuslanan satır özellikleri
            view.RowCellStyle += View_RowCellStyle;



            //filtre satırı
            view.OptionsView.ShowAutoFilterRow = false;

            //yeni satır
            view.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            //Son kolonun otomatik geniletilmesi
            view.OptionsView.ColumnAutoWidth = false;



            view.OptionsDetail.EnableMasterViewMode = false;
            view.OptionsNavigation.EnterMoveNextColumn = false;
            view.OptionsNavigation.AutoFocusNewRow = true;
            view.OptionsNavigation.EnterMoveNextColumn = false;
            view.Appearance.FocusedRow.BackColor = Color.Transparent;
            view.Appearance.FocusedCell.BackColor = Color.Transparent;


        }

        private static void View_RowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
            bool needMoveLastRow = true;
            ColumnView view = sender as ColumnView;
            if (needMoveLastRow)
            {
                needMoveLastRow = false;
                view.MoveLast();
            }
        }

        public static void View_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;

            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.FontStyleDelta = FontStyle.Bold;
                e.Appearance.ForeColor = Color.Black;
             
            }
        }

        public static void View_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle % 2 == 0)
                e.Appearance.BackColor = Color.LightBlue;
        }

        public static void dgw_Resize(object sender, EventArgs e)
        {
            GridControl control = sender as GridControl;
            GridView view = control.MainView as GridView;
            view.BestFitColumns();

        }


        #endregion

        #region Bar
        public static void TemelBar(Bar bar)
        {
            bar.OptionsBar.AllowQuickCustomization = false;
            bar.CanDockStyle = bar.CanDockStyle;
            bar.DockStyle = BarDockStyle.Top;
            bar.HideWhenMerging = DevExpress.Utils.DefaultBoolean.False;
            bar.Text = "Menü";
        }
        #endregion

        #region Ribbon
        public static void TemelRibbon(RibbonControl rib)
        {
            rib.RibbonStyle = RibbonControlStyle.OfficeUniversal;
            rib.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            rib.ShowPageHeadersMode = ShowPageHeadersMode.Hide;
            rib.ShowToolbarCustomizeItem = false;
        }
        #endregion

        #region NavBar

        public static void Navbar(NavBarControl nav)
        {
            nav.GroupExpanding += Nav_GroupExpanding;
            nav.MouseUp += Nav_MouseUp;
        }

        private static void Nav_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            NavBarHitInfo hInfo = ((NavBarControl)sender).CalcHitInfo(e.Location);
            if (hInfo.InGroupCaption && !hInfo.InGroupButton)
            {
                for (int i = 0; i < ((NavBarControl)sender).Groups.Count; i++)
                    ((NavBarControl)sender).Groups[i].Expanded = false;
                hInfo.Group.Expanded = !hInfo.Group.Expanded;
            }
        }

        private static void Nav_GroupExpanding(object sender, NavBarGroupCancelEventArgs e)
        {
            for (int i = 0; i < ((NavBarControl)sender).Groups.Count; i++)
                ((NavBarControl)sender).Groups[i].Expanded = false;
        }

        #endregion

        #region Bar Sub İtem

        public static void BarIcon(Bar bar)
        {
            foreach (var item in bar.Manager.Items)
            {
                if (item is BarSubItem)
                {
                    BarSubItem bsi = (BarSubItem)item;
                    bsi.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
                    if (bsi.Caption == "Tanımlar")
                        bsi.ImageOptions.Image = ImageResourceCache.Default.GetImage("images/actions/download_16x16.png");
                    else if (bsi.Caption == "İşlemler")
                        bsi.ImageOptions.Image = ImageResourceCache.Default.GetImage("images/chart/line_16x16.png");
                    else if (bsi.Caption == "Servisler")
                        bsi.ImageOptions.Image = ImageResourceCache.Default.GetImage("images/setup/properties_16x16.png");
                    else if (bsi.Caption == "Raporlar")
                        bsi.ImageOptions.Image = ImageResourceCache.Default.GetImage("images/reports/report_16x16.png");
                }
                if (item is BarButtonItem)
                {
                    BarButtonItem bbi = (BarButtonItem)item;
                    bbi.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
                }
            }
        }
        #endregion

        #region Atlas Form

        public static void AForm(AtlasForm form)
        {
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            form.KeyPreview = true;
            form.FormClosing += Form_FormClosing;
            form.KeyUp += Form_KeyUp;
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            form.MaximizeBox = false;
            form.Icon = new System.Drawing.Icon(Application.StartupPath + "//Images//atlas.ico");



        }

        private static void Form_Load(object sender, EventArgs e)
        {

        }

        private static void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Classes.AtlasChangeState c = new Classes.AtlasChangeState();
            if (c.ReturnState((AtlasForm)sender))
            {
                DialogResult answer;
                answer = XtraMessageBox.Show("Yaptığınız değişikler kaydedilmeyecek.\n\rVazgeçmek istediğinize emin misiniz?", "Soru?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer == DialogResult.No)
                    e.Cancel = true;
                else
                {
                    Helper helper = new Helper();
                    helper.ClearForm((AtlasForm)sender);
                    e.Cancel = false;
                }

            }
        }

        private static void Form_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
                ((AtlasForm)sender).Close();
        }


        #endregion
    }
}
