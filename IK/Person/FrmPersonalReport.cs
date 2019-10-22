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

namespace IK.Person
{
    public partial class FrmPersonalReport : AtlasForm
    {
        public FrmPersonalReport()
        {
            InitializeComponent();
            AtlasCompanent.TemelBar(bar1);
            AtlasCompanent.TemelGrid(grdPerson);
            AtlasCompanent.TemelGrid(gridView2);
            AtlasCompanent.AForm(this);

            grdPerson.OptionsBehavior.Editable = false;
            grdPerson.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            grdPerson.OptionsView.ShowAutoFilterRow = true;

            gridView2.OptionsBehavior.Editable = false;
            gridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            gridView2.OptionsView.ShowAutoFilterRow = false;
        }
        AccessManager db = new AccessManager();
        Helper helper = new IK.Helper();
        int Ref = 0;

        void fillData()
        {
            FrmIKMain main = (FrmIKMain)Application.OpenForms["FrmIKMain"];
            DataTable dt = new DataTable();
            if (main.who != "YSK")
            {

                db.AddParameterValue("@unit", main.pUnit);
                dt = db.GetDataTable(@"		SELECT        
tbPerson.Ref, 
tbPerson.name + ' ' + surname AS[Ad Soyad], 
tc AS TC, 
tbUnit.name as [Birim],
sDate as [İşe Giriş]
FROM tbPerson with(nolock)
LEFT OUTER JOIN  tbUnit 
ON tbPerson.unit = tbUnit.Ref
where tbperson.Unit = @unit
ORDER BY [Ad Soyad] asc");
            }
            else
            {
                dt = db.GetDataTable(@"		SELECT        
tbPerson.Ref, 
tbPerson.name + ' ' + surname AS[Ad Soyad], 
tc AS TC, 
tbUnit.name as [Birim],
sDate as [İşe Giriş]
FROM tbPerson with(nolock)
LEFT OUTER JOIN  tbUnit 
ON tbPerson.unit = tbUnit.Ref
ORDER BY [Ad Soyad] asc");
            }


            dgwPerson.DataSource = dt;
            grdPerson.Columns[0].Visible = false;
            grdPerson.BestFitColumns();
        }


        private void FrmPersonalReport_Load(object sender, EventArgs e)
        {
            lblKalan.Text = "0";
            lblKazanilan.Text = "0";
            lblKullanilan.Text = "0";
            fillData();


        }

        private void grdPerson_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                int Kullanilan = 0, Kullanilabilir = 0, Kazanilan = 0;
                if (!string.IsNullOrEmpty(grdPerson.GetFocusedRowCellValue("Ref").ToString()))
                {
                    int Ref = int.Parse(grdPerson.GetFocusedRowCellValue("Ref").ToString());

                    db.AddParameterValue("@pRef", Ref);
                    DataTable dt = db.GetDataTable(@"SELECT        
              Ref, 
              pRef,
              tbPermission.pType AS[İzin Tipi],
              tbPermission.pSDate AS[Başlangıç Tarihi],
              tbPermission.pFDate AS[Bitiş Tarihi],
              tbPermission.pWSDate AS[İşe Başlama Tarihi],
              tbPermission.pRequest AS[Kullanılan İzin],
              (tbPermission.Weekend + tbPermission.pNational + tbPermission.religion) as [Resmi Tatil],
              (tbPermission.Weekend + tbPermission.pNational + tbPermission.religion + tbPermission.pRequest) as [Toplam]
              FROM tbPermission with(nolock)
               WHERE
               pRef=@pRef");

                    gridControl2.DataSource = dt;
                    gridView2.Columns[0].Visible = false;
                    gridView2.Columns[1].Visible = false;
                    if (dt.Rows.Count > 0)
                    {

                        gridView2.BestFitColumns();
                    }



                    db.AddParameterValue("@ref", Ref);
                    Kazanilan = int.Parse(db.GetScalarValue("Select gain from tbPerson where Ref=@ref").ToString());


                    db.parameterDelete();

                    db.AddParameterValue("@pRef", Ref);
                    Kullanilan = int.Parse(db.GetScalarValue("select  dbo.IK_GetUsedDays(@pRef)").ToString());



                    Kullanilabilir = Kazanilan - Kullanilan;

                    lblKalan.Text = Kullanilabilir.ToString() + " Gün";
                    lblKazanilan.Text = Kazanilan.ToString() + " Gün";
                    lblKullanilan.Text = Kullanilan.ToString() + " Gün";

                }
            }
            catch (Exception ex)
            {

            }

        }

        private void btnEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
