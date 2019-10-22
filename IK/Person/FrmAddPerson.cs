using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Obje.Classes;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;


namespace IK.Person
{
    public partial class FrmAddPerson : AtlasForm
    {
        public FrmAddPerson()
        {
            InitializeComponent();
            AtlasCompanent.AForm(this);

            AtlasCompanent.TemelBar(bar1);
            AtlasCompanent.TemelGrid(grdFolder);
            this.MaximizeBox = true;

            grdFolder.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            txtSicil.flaText.Leave += SetSigorta;
            txtSicil.flaText.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
        }

        ErpManager db = new ErpManager();
        Helper helper = new Helper();
        AtlasChangeState c = new AtlasChangeState();

        int register = 1000;
        int Ref = 0, gain = 0, REf = 0;
        string path = "", newName = "";
        string nowppPath = "", oldPath = "";
        string MainPath = "", goal = "", sigorta = "";
        DataTable dtFOlder = new DataTable();
        DataTable dtFillFolder = new DataTable();

        DialogResult result;

        void fillComboAndDate()
        {
            DateTime bDate = new DateTime(1990, 1, 1);
            dtpDTarihi.SetDate(bDate);

            dtpIseGiris.SetDate(DateTime.Parse(DateTime.Now.ToShortDateString().ToString()));

            ledBirim.flaLookUp.Properties.ValueMember = "Ref";
            ledBirim.flaLookUp.Properties.DisplayMember = "name";
            ledBirim.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "Ref", Caption = "dbNo", Visible = false });
            ledBirim.flaLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { FieldName = "name", Caption = "Departman" });
            ledBirim.flaLookUp.Properties.DataSource = db.GetDataTable("Select * from tbUnit  with(nolock)");


            cmbDerece.flashCombo.Properties.Items.Add("Anne");
            cmbDerece.flashCombo.Properties.Items.Add("Baba");
            cmbDerece.flashCombo.Properties.Items.Add("Eş");
            cmbDerece.flashCombo.Properties.Items.Add("Arkadaş");
            cmbDerece.flashCombo.Properties.Items.Add("Kardeş");
            cmbDerece.flashCombo.Properties.Items.Add("Çocuk");
            cmbDerece.SetString("Kardeş");

            cmbCinsiyet.flashCombo.Properties.Items.Add("Erkek");
            cmbCinsiyet.flashCombo.Properties.Items.Add("Kadın");
            cmbCinsiyet.SetString("Erkek");

            cmbAskerlik.flashCombo.Properties.Items.Add("Yapıldı");
            cmbAskerlik.flashCombo.Properties.Items.Add("Tecilli");
            cmbAskerlik.flashCombo.Properties.Items.Add("Öğrenci");
            cmbAskerlik.flashCombo.Properties.Items.Add("Muaf");
            //cmbAskerlik.SetString("Yapıldı");

            cmbCocuk.flashCombo.Properties.Items.Add("0");
            cmbCocuk.flashCombo.Properties.Items.Add("1");
            cmbCocuk.flashCombo.Properties.Items.Add("2");
            cmbCocuk.flashCombo.Properties.Items.Add("3");
            cmbCocuk.flashCombo.Properties.Items.Add("4");
            cmbCocuk.flashCombo.Properties.Items.Add("5");
            cmbCocuk.flashCombo.Properties.Items.Add("6");
            //cmbCocuk.SetString("0");

            cmbEhliyet.flashCombo.Properties.Items.Add("Yok");
            cmbEhliyet.flashCombo.Properties.Items.Add("M");
            cmbEhliyet.flashCombo.Properties.Items.Add("A");
            cmbEhliyet.flashCombo.Properties.Items.Add("B");
            cmbEhliyet.flashCombo.Properties.Items.Add("C");
            cmbEhliyet.flashCombo.Properties.Items.Add("D");
            cmbEhliyet.flashCombo.Properties.Items.Add("F");
            cmbEhliyet.flashCombo.Properties.Items.Add("G");
            //cmbEhliyet.SetString("B");

            cmbKanGrubu.flashCombo.Properties.Items.Add("AB Rh (+)");
            cmbKanGrubu.flashCombo.Properties.Items.Add("AB Rh (-)");
            cmbKanGrubu.flashCombo.Properties.Items.Add("0  Rh (-)");
            cmbKanGrubu.flashCombo.Properties.Items.Add("0  Rh (+)");
            cmbKanGrubu.flashCombo.Properties.Items.Add("A  Rh (-)");
            cmbKanGrubu.flashCombo.Properties.Items.Add("A  Rh (+)");
            cmbKanGrubu.flashCombo.Properties.Items.Add("B  Rh (-)");
            cmbKanGrubu.flashCombo.Properties.Items.Add("B  Rh (+)");
            //cmbKanGrubu.SetString("AB Rh (+)");

            cmbMedeni.flashCombo.Properties.Items.Add("Bekar");
            cmbMedeni.flashCombo.Properties.Items.Add("Evli");
            //cmbMedeni.SetString("Bekar");


            cmbOgrenim.flashCombo.Properties.Items.Add("İlkokul");
            cmbOgrenim.flashCombo.Properties.Items.Add("Ortaokul");
            cmbOgrenim.flashCombo.Properties.Items.Add("Lise");
            cmbOgrenim.flashCombo.Properties.Items.Add("Ön Lisans");
            cmbOgrenim.flashCombo.Properties.Items.Add("Lisans");
            cmbOgrenim.flashCombo.Properties.Items.Add("Yüksek Lisans");
            cmbOgrenim.flashCombo.Properties.Items.Add("Doktora");
            cmbOgrenim.flashCombo.Properties.Items.Add("Master");
            //cmbOgrenim.SetString("Lisans");

            //if (!string.IsNullOrEmpty(db.GetScalarValue("Select MAX(register) from tbPerson").ToString()))
            //    register = int.Parse(db.GetScalarValue("Select MAX(register) from tbPerson").ToString());

            //register++;
            //txtSicil.SetString(register.ToString());


            cmbFirma.flashCombo.Properties.Items.Add("Badbear");
            cmbFirma.flashCombo.Properties.Items.Add("Boyner");
            cmbFirma.flashCombo.Properties.Items.Add("Gencallar");
            //cmbFirma.SetString("Badbear");

            #region Card File
            dtFOlder.Columns.Add("Ref");
            dtFOlder.Columns.Add("cardRef");
            dtFOlder.Columns.Add("Açıklama");
            dtFOlder.Columns.Add("folderName");
            dtFOlder.Columns.Add("systemFolderName");
            dtFOlder.Columns.Add("folderPath");
            dtFOlder.Columns.Add("folderType");

            dtFOlder.Columns["Ref"].ColumnName = "Ref";
            dtFOlder.Columns["cardRef"].ColumnName = "cardRef";
            dtFOlder.Columns["folderName"].ColumnName = "Dosya Adı";
            dtFOlder.Columns["systemFolderName"].ColumnName = "Sistem Dosya Adı";
            dtFOlder.Columns["folderPath"].ColumnName = "Dosya Yolu";
            dtFOlder.Columns["folderType"].ColumnName = "Dosya Tipi";

            //db.AddParameterValue("@ref", this._Ref);


            db.AddParameterValue("@ref", this._Ref);
            dtFillFolder = db.GetDataTable("select * from tbCardFiles where cardRef=@ref");

            for (int t = 0; t < dtFillFolder.Rows.Count; t++)
            {
                DataRow row = dtFOlder.NewRow();
                row["Ref"] = dtFillFolder.Rows[t][0].ToString();
                row["cardRef"] = dtFillFolder.Rows[t][1].ToString();
                row["Açıklama"] = dtFillFolder.Rows[t][2].ToString();
                row["Dosya Adı"] = dtFillFolder.Rows[t][3].ToString();
                row["Sistem Dosya Adı"] = dtFillFolder.Rows[t][4].ToString();
                row["Dosya Yolu"] = dtFillFolder.Rows[t][5].ToString();
                row["Dosya Tipi"] = dtFillFolder.Rows[t][6].ToString();
                dtFOlder.Rows.Add(row);
                grdFolder.RefreshData();
            }

            dgwFolder.DataSource = dtFOlder;
            grdFolder.Columns[0].Visible = false;
            grdFolder.Columns[1].Visible = false;
            grdFolder.BestFitColumns();

            grdFolder.Columns[3].OptionsColumn.AllowEdit = false;
            grdFolder.Columns[4].OptionsColumn.AllowEdit = false;
            grdFolder.Columns[5].OptionsColumn.AllowEdit = false;
            grdFolder.Columns[6].OptionsColumn.AllowEdit = false;


            #endregion

        }

        void DeleteLine(GridView grd, string sql)
        {
            try
            {
                if (grd.RowCount > 0 && grd.FocusedRowHandle != -1)
                {
                    System.Data.DataRow row = grd.GetDataRow(grd.FocusedRowHandle);


                    if (!string.IsNullOrEmpty(row[0].ToString()) && row[0].ToString() != "0")
                    {
                        result = XtraMessageBox.Show("Seçili kaydı silmek istediğinize emin misiniz?\n\rKaydet işlemi yapılmadan son düzenlemeler geçerli olmayacaktır.", "Soru?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            REf = int.Parse(row[0].ToString());
                            grd.DeleteRow(grd.FocusedRowHandle);
                            db.AddParameterValue("@Ref", REf);
                            db.RunCommand(sql + " where Ref=@Ref");

                            XtraMessageBox.Show("İşlem başarıyla tamamlandı.", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        if (row[0].ToString() != "0")
                        grd.DeleteRow(grd.FocusedRowHandle);
                }
            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
            }
        }

        public int[] ikiTarihFarki(DateTime sonTarih, DateTime ilkTarih)

        {

            int ilkGun, ilkAy, ilkYil;
            int sonGun, sonAy, sonYil;
            int farkYil, farkAy, farkGun;
            farkYil = 0; farkAy = 0; farkGun = 0;

            ilkYil = ilkTarih.Year;
            ilkAy = ilkTarih.Month;
            ilkGun = ilkTarih.Day;

            sonGun = sonTarih.Day;
            sonAy = sonTarih.Month;
            sonYil = sonTarih.Year;

            if (sonGun < ilkGun)
            {
                sonGun += DateTime.DaysInMonth(sonYil, sonAy);
                farkGun = sonGun - ilkGun;
                sonAy--;
                if (sonAy < ilkAy)
                {
                    sonAy += 12;
                    sonYil--;
                    farkAy = sonAy - ilkAy;
                    farkYil = sonYil - ilkYil;
                }
                else
                {
                    farkAy = sonAy - ilkAy;
                    farkYil = sonYil - ilkYil;
                }
            }
            else
            {
                farkGun = sonGun - ilkGun;
                if (sonAy < ilkAy)
                {
                    sonAy += 12;
                    sonYil--;
                    farkAy = sonAy - ilkAy;
                    farkYil = sonYil - ilkYil;
                }
                else
                {
                    farkAy = sonAy - ilkAy;
                    farkYil = sonYil - ilkYil;
                }
            }

            int[] sonuc = new int[3];
            sonuc[0] = farkYil;
            sonuc[1] = farkAy;
            sonuc[2] = farkGun;
            return sonuc;
        }

        void calculateGain()
        {
            DateTime sonTarih = DateTime.Now;
            DateTime ilkTarih = dtpIseGiris.GetDate();

            int[] sonuc = ikiTarihFarki(sonTarih, ilkTarih);
            int yil = int.Parse(sonuc[0].ToString());


            if (yil < 1)
                gain = 0;
            if (yil <= 5 && yil > 1)
                gain = 14;
            else if (yil < 15 && yil > 5)
                gain = 20;
            else if (yil > 15)
                gain = 26;


        }

        bool Control()
        {
            int errorCount = 0;
            if (string.IsNullOrEmpty(txtAd.GetString()))
            {
                XtraMessageBox.Show("Ad alanı boş geçilemez.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorCount++;
            }
            if (string.IsNullOrEmpty(txtSoyad.GetString()))
            {
                XtraMessageBox.Show("Soyad alanı boş geçilemez.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorCount++;
            }

            if (string.IsNullOrEmpty(dtpIseGiris.GetDate().ToString()))
            {
                XtraMessageBox.Show("İşe giriş alanı boş geçilemez.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorCount++;
            }


            if (errorCount > 0)
                return false;
            else return true;
        }

        private void grdFolder_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            pmFolder.ShowPopup(Cursor.Position);
        }

        private void btnFolderAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Jpg Dosyası |*.jpg| Pdf Dosyası |*.Pdf| Png Dosyası|*.png";
            ofd.Title = "Resim Dosyası Seçiniz..";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string folderPath = ofd.FileName;
                string folderName = ofd.SafeFileName;
                string[] words = folderPath.Split('.');
                string fileType = words[1].ToString();
                string guid = Guid.NewGuid().ToString();
                string systemName = guid + "." + fileType;


                DataRow row = dtFOlder.NewRow();
                row["Ref"] = null;
                row["cardRef"] = null;
                row["Dosya Adı"] = folderName;
                row["Sistem Dosya Adı"] = systemName;
                row["Dosya Yolu"] = folderPath;
                row["Dosya Tipi"] = fileType;
                dtFOlder.Rows.Add(row);
                grdFolder.RefreshData();
                grdFolder.BestFitColumns();
            }

        }

        private void btnFolderDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string path = grdFolder.GetFocusedRowCellValue("Dosya Yolu").ToString() + grdFolder.GetFocusedRowCellValue("Sistem Dosya Adı").ToString();
                DeleteLine(grdFolder, "delete from tbCardFiles");
                File.Delete(path);
            }
            catch (Exception ex)
            {

            }

        }

        private void btnFolderOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Data.DataRow row = grdFolder.GetDataRow(grdFolder.FocusedRowHandle);
            if (!string.IsNullOrEmpty(row[6].ToString()))
            {
                if (row[6].ToString() != "pdf")
                {
                    FrmShowImage image = new FrmShowImage();
                    image.pictureEdit1.Image = Image.FromFile(row[5].ToString() + row[4].ToString());
                    image.ShowDialog();
                }
                else if (row[6].ToString() == "pdf")
                {
                    FrmPdfViewer view = new FrmPdfViewer();
                    view.MdiParent = FrmIKMain.ActiveForm;
                    view.pdfViewer1.LoadDocument(row[5].ToString() + row[4].ToString());
                    view.Show();
                }
            }
            else
            {
                XtraMessageBox.Show("Seçili bir dosya yok veya seçili dosyanın yolu belirtilmemiş.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {



            if (!string.IsNullOrEmpty(pictureEdit1.GetLoadedImageLocation().ToString()))
            {
                string goal = Application.StartupPath + @"\\Images\\Person\\" + txtAd.GetString() + txtSoyad.GetString() + "\\";

                MainPath = pictureEdit1.GetLoadedImageLocation().ToString();


                string GuidKey = Guid.NewGuid().ToString();
                string[] words = MainPath.Split('.');

                newName = GuidKey + "." + words[1].ToString();


                nowppPath = newName;
            }

        }

        private void FrmAddPerson_Load(object sender, EventArgs e)
        {
            fillComboAndDate();
            if (this._FormMod == Enums.enmFormMod.Guncelle)
            {
                db.AddParameterValue("@ref", _Ref, SqlDbType.Int);
                DataTable dt = db.GetDataTable("select * from tbPerson  with(nolock) where Ref=@ref");
                txtAd.SetString(dt.Rows[0][1].ToString());
                txtSoyad.SetString(dt.Rows[0][2].ToString());
                txtTC.SetString(dt.Rows[0][3].ToString());
                dtpDTarihi.SetDate(DateTime.Parse(dt.Rows[0][4].ToString()));
                txtDogumYeri.SetString(dt.Rows[0][5].ToString());
                txtAnneAdi.SetString(dt.Rows[0][6].ToString());
                txtBabaAdi.SetString(dt.Rows[0][7].ToString());
                cmbCinsiyet.SetString(dt.Rows[0][8].ToString());
                cmbKanGrubu.SetString(dt.Rows[0][9].ToString());
                cmbMedeni.SetString(dt.Rows[0][10].ToString());
                txtSicil.SetString(dt.Rows[0][11].ToString());
                txtGorev.SetString(dt.Rows[0][12].ToString());
                ledBirim.SetValue(int.Parse(dt.Rows[0][13].ToString()));
                dtpIseGiris.SetDate(DateTime.Parse(dt.Rows[0][14].ToString()));
                txtGSM.SetString(dt.Rows[0][15].ToString());
                txtMail.SetString(dt.Rows[0][16].ToString());
                txtAdres.SetString(dt.Rows[0][17].ToString());
                txtYAd.SetString(dt.Rows[0][18].ToString());
                txtYSoyad.SetString(dt.Rows[0][19].ToString());
                cmbDerece.SetString(dt.Rows[0][20].ToString());
                txtYgsm.SetString(dt.Rows[0][21].ToString());
                cmbEhliyet.SetString(dt.Rows[0][22].ToString());
                cmbAskerlik.SetString(dt.Rows[0][23].ToString());
                cmbOgrenim.SetString(dt.Rows[0][24].ToString());
                cmbCocuk.SetString(dt.Rows[0][25].ToString());
                path = dt.Rows[0][26].ToString();
                gain = int.Parse(dt.Rows[0][27].ToString());

                if (!string.IsNullOrEmpty(path))
                    pictureEdit1.Image = Image.FromFile(Application.StartupPath + "\\Images\\Person\\" + txtAd.GetString() + txtSoyad.GetString() + "\\" + path);

                cmbFirma.SetString(dt.Rows[0][28].ToString());

                txtIBAN.SetString(dt.Rows[0][30].ToString());
                txtYerleske.SetString(dt.Rows[0]["campus"].ToString());
                cmbKanGrubu.SetString(dt.Rows[0]["blood"].ToString());

                nowppPath = path;
                oldPath = path;



            }
            c.StateStabil(this);


        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (Control() == true)
                {
                    calculateGain();

                    if (!File.Exists(goal) && !string.IsNullOrEmpty(goal))
                    {
                        Directory.CreateDirectory(goal);

                        File.Copy(MainPath, goal + newName);
                    }


                    db.AddParameterValue("@ref", _Ref);
                    db.AddParameterValue("@name", txtAd.GetString());
                    db.AddParameterValue("@surname", txtSoyad.GetString());
                    db.AddParameterValue("@tc", txtTC.GetString());
                    db.AddParameterValue("@bdate", dtpDTarihi.GetDate(), SqlDbType.Date);
                    db.AddParameterValue("@bPlace", txtDogumYeri.GetString());
                    db.AddParameterValue("@mName", txtAnneAdi.GetString());
                    db.AddParameterValue("@dName", txtBabaAdi.GetString());
                    db.AddParameterValue("@sex", cmbCinsiyet.GetString());
                    db.AddParameterValue("@bgroup", cmbKanGrubu.GetString());
                    db.AddParameterValue("@mStatus", cmbMedeni.GetString());
                    db.AddParameterValue("@register", txtSicil.GetString());
                    db.AddParameterValue("@mission", txtGorev.GetString());
                    db.AddParameterValue("@unit", ledBirim.GetValue());
                    db.AddParameterValue("@sDate", dtpIseGiris.GetDate(), SqlDbType.Date);
                    db.AddParameterValue("@gsm", txtGSM.GetString());
                    db.AddParameterValue("@mail", txtMail.GetString());
                    db.AddParameterValue("@address", txtAdres.GetString(), SqlDbType.NVarChar);
                    db.AddParameterValue("@cname", txtYAd.GetString());
                    db.AddParameterValue("@cSurname", txtYSoyad.GetString());
                    db.AddParameterValue("@cRank", cmbDerece.GetString());
                    db.AddParameterValue("@cGsm", txtYgsm.GetString());
                    db.AddParameterValue("@dLicence", cmbEhliyet.GetString());
                    db.AddParameterValue("@solider", cmbAskerlik.GetString());
                    db.AddParameterValue("@education", cmbOgrenim.GetString());
                    db.AddParameterValue("@children", cmbCocuk.GetString());
                    db.AddParameterValue("@imagePath", nowppPath);
                    db.AddParameterValue("@gain", gain);
                    db.AddParameterValue("@firm", cmbFirma.GetString());
                    db.AddParameterValue("@insurance", sigorta);
                    db.AddParameterValue("@IBAN", txtIBAN.GetString());
                    db.AddParameterValue("@campus", txtYerleske.GetString());
                    db.AddParameterValue("@blood", cmbKanGrubu.GetString());
                    db.RunCommand("sp_Person", CommandType.StoredProcedure);

                    #region File

                    this._Ref = int.Parse(db.GetScalarValue("select MAX(Ref) from tbPerson").ToString());


                    string foldername = "", sysName = "", path = "", type = "", desc = "";
                    for (int k = 0; k < grdFolder.RowCount - 1; k++)
                    {
                        if (string.IsNullOrEmpty(grdFolder.GetRowCellValue(k, "Ref").ToString()))
                            REf = 0;
                        else
                            REf = int.Parse(grdFolder.GetRowCellValue(k, "Ref").ToString());

                        foldername = grdFolder.GetRowCellValue(k, "Dosya Adı").ToString();
                        sysName = grdFolder.GetRowCellValue(k, "Sistem Dosya Adı").ToString();
                        path = grdFolder.GetRowCellValue(k, "Dosya Yolu").ToString();
                        desc = grdFolder.GetRowCellValue(k, "Açıklama").ToString();
                        type = grdFolder.GetRowCellValue(k, "Dosya Tipi").ToString();

                        db.AddParameterValue("@ref", REf);
                        db.AddParameterValue("@cardRef", this._Ref);
                        db.AddParameterValue("@desc", desc, SqlDbType.NVarChar);
                        db.AddParameterValue("@name", foldername, SqlDbType.NVarChar);
                        db.AddParameterValue("@sysName", sysName, SqlDbType.NVarChar);
                        db.AddParameterValue("@path", path, SqlDbType.NVarChar);
                        db.AddParameterValue("@type", type, SqlDbType.NVarChar);
                        db.RunCommand("sp_CardFile", CommandType.StoredProcedure);

                        if (!string.IsNullOrEmpty(path))
                        {

                            string goal = Application.StartupPath + @"\Images\Person\" + txtAd.GetString() + txtSoyad.GetString() + "\\";
                            if (!File.Exists(goal))
                                Directory.CreateDirectory(goal);


                            if (this._FormMod == Enums.enmFormMod.Yeni)
                                File.Copy(path, goal + sysName);
                            else if (this._FormMod == Enums.enmFormMod.Guncelle)
                            {
                                string newPath = path + sysName;
                                if (!File.Exists(newPath))
                                    File.Copy(newPath, goal + sysName);
                            }


                            db.AddParameterValue("@ref", this._Ref);
                            db.AddParameterValue("@path", goal, SqlDbType.NVarChar);
                            db.RunCommand("update tbCardFiles set folderPath=@path where cardRef=@ref");
                        }




                        db.parameterDelete();
                    }


                    #endregion


                    if (nowppPath != oldPath && !string.IsNullOrEmpty(oldPath))
                    {
                        File.Open(oldPath, FileMode.Open).Close();
                        File.Delete(oldPath);
                    }

                    XtraMessageBox.Show("İşlem başarıyla tamamlandı.", "Başarılı İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    helper.ClearForm(this);
                    c.StateStabil(this);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                helper.WriteLog(ex);
                db.parameterDelete();
            }
        }

        private void btnEscape_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void SetSigorta(object sender, EventArgs e)
        {
            if (txtSicil.flaText.Text.Length > 0)
                sigorta = "Var";
            else
                sigorta = "Yok";
        }
    }
}