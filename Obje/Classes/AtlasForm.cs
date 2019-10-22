using Obje;
namespace Obje.Classes
{
    public class AtlasForm : DevExpress.XtraEditors.XtraForm
    {
        public int _Ref { get; set; }

        public string _FormText { get; set; }

        public string _FormName { get; set; }

        public string _FormNo { get; set; }

        public string _MenuNo { get; set; }

        public Obje.Classes.Enums.enmFormMod _FormMod { get; set; }

        public string _Sql { get; set; }

        public string _ConnStr { get; set; }

        public bool _add { get; set; }

        public bool _update { get; set; }

        public bool _show { get; set; }

        public bool _delete { get; set; }


        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AtlasForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "AtlasForm";
            this.Load += new System.EventHandler(this.AtlasForm_Load);
            this.ResumeLayout(false);
    

        }

        private void AtlasForm_Load(object sender, System.EventArgs e)
        {
            this.Text = this._FormText;
        }

        public AtlasForm()
        {
            this.Text = this._FormText;
        }
    }
}
