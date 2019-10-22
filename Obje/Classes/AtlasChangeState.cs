using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Obje;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Obje.Classes
{
    public class AtlasChangeState
    {
        public bool ReturnState(AtlasForm form)
        {
            bool States = false;

            foreach (Control x in form.Controls)
            {
                if (x.Controls.Count > 0)
                {
                    foreach (Control y in x.Controls)
                    {
                        if (y.Tag != null)
                        {
                            if (y.Tag.ToString() == "1")
                            {
                                States = true;
                                break;
                            }
                        }

                    }
                }
                else
                {
                    if (x.Tag != null)
                    {
                        if (x.Tag.ToString() == "1")
                        {
                            States = true;
                            break;
                        }
                    }
                }
            }

            return States;
        }

        public void StateStabil(AtlasForm form)
        {
            foreach (Control x in form.Controls)
            {
                if (x.Controls.Count > 0)
                    foreach (Control y in x.Controls)
                        if (y.Tag != null)
                            y.Tag = "0";
                        else
                    if (x.Tag != null)
                            x.Tag = "0";
            }
        }

        public void DoDisable(AtlasForm form)
        {
            foreach (Control x in form.Controls)
            {
                if (x.Controls.Count > 0)
                {
                    foreach (Control y in x.Controls)
                        y.Enabled = false;


                    foreach (Label lbl in x.Controls.OfType<Label>())
                        lbl.Enabled = true;
                }
            }
        }

        public void DoActive(AtlasForm form)
        {
            foreach (Control x in form.Controls)
            {
                if (x.Controls.Count > 0)
                {
                    foreach (Control y in x.Controls)
                        y.Enabled = true;


                    foreach (Label lbl in x.Controls.OfType<Label>())
                        lbl.Enabled = true;

                    foreach (GridView view in x.Controls.OfType<GridView>())
                        view.OptionsBehavior.Editable = true;
                }
            }
        }
    }
}
