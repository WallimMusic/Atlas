using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using Obje.Companents;
using Obje.Classes;
using DevExpress.XtraGrid.Views.Grid;

namespace IK
{

    public class Helper
    {
        #region LOG
        public void WriteLogLine(string sCallerName, string sLogFolder, long lCallerInstance, string sLogLine)
        {
            lock (this)
            {
                string sFileName;
                sFileName = String.Format("{0}_{1:yyyy.MM.dd}_{2:00}.log",
                              sCallerName, DateTime.Now, lCallerInstance);
                StreamWriter swServerLog =
                       new StreamWriter(sLogFolder + sFileName, true);
                swServerLog.WriteLine(
                       String.Format("[{0:T}] {1}", DateTime.Now, sLogLine));
                swServerLog.Close();
            }
        }
        #endregion

        #region HASH
        private string password = "1";
        ErpManager db = new ErpManager();
        public byte[] Sifrele(byte[] SifresizVeri, byte[] Key, byte[] IV)

        {

            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = IV;
            CryptoStream cs = new CryptoStream(ms,
            alg.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(SifresizVeri, 0, SifresizVeri.Length);
            cs.Close();
            byte[] sifrelenmisVeri = ms.ToArray();
            return sifrelenmisVeri;

        }
        private byte[] SifreCoz(byte[] SifreliVeri, byte[] Key, byte[] IV)

        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = IV;
            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(SifreliVeri, 0, SifreliVeri.Length);
            cs.Close();
            byte[] SifresiCozulmusVeri = ms.ToArray();
            return SifresiCozulmusVeri;
        }
        public string TextSifrele(string sifrelenecekMetin)

        {
            byte[] sifrelenecekByteDizisi = System.Text.Encoding.Unicode.GetBytes(sifrelenecekMetin);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d,
            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
            byte[] SifrelenmisVeri = Sifrele(sifrelenecekByteDizisi,
                 pdb.GetBytes(32), pdb.GetBytes(16));
            return Convert.ToBase64String(SifrelenmisVeri);

        }
        public string TextSifreCoz(string text)

        {
            byte[] SifrelenmisByteDizisi = Convert.FromBase64String(text);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65,
            0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
            byte[] SifresiCozulmusVeri = SifreCoz(SifrelenmisByteDizisi,
                pdb.GetBytes(32), pdb.GetBytes(16));
            return System.Text.Encoding.Unicode.GetString(SifresiCozulmusVeri);

        }
        #endregion

        public void ActivePassive(int id, string tabloadi, string alanadi, string kosulid)
        {
            db.AddParameterValue("@Id", id);
            string status = db.GetScalarValue("select " + alanadi + " from " + tabloadi + " where " + kosulid + "=@Id").ToString();


            db.AddParameterValue("@Id", id);
            if (status == "False")
                db.RunCommand("update " + tabloadi + " set " + alanadi + " = 1 where " + kosulid + "=@Id");
            else if (status == "True")
                db.RunCommand("update " + tabloadi + " set " + alanadi + " = 0 where " + kosulid + "=@Id");

            DevExpress.XtraEditors.XtraMessageBox.Show("İşlem başarıyla kaydedildi.", "Başarılı İşlem!"
          , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void GetCode(string tabloadi, string alan, AtlasForm form, AtlasButtonEdit btn, int start)
        {

            int code = 0;

            System.Data.DataTable dt = db.GetDataTable("select " + alan + " from " + tabloadi);
            if (dt.Rows.Count >= 1)
            {
                code = int.Parse(db.GetScalarValue("select MAX(" + alan + ") from " + tabloadi).ToString());
                code++;
            }
            else
            {
                code = start;
                code++;
            }
            btn.Enabled = false;
            btn.SetString(code.ToString());
        }

        public void WriteLog(Exception ex)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show("Beklenmedik bir hatayla karşılaşıldı.", "HATA!"
            , MessageBoxButtons.OK, MessageBoxIcon.Error);
            db.parameterDelete();
            //WriteLogLine("Hata", "Logs//", Properties.Settings.Default.errorCount, ex.Message.ToString());
            //Properties.Settings.Default.errorCount++;
            //Properties.Settings.Default.Save();
            //Properties.Settings.Default.Save();
        }

        public void ExportToGridControl(DevExpress.XtraGrid.GridControl grid)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (*.xlsx)|*.xlsx|Pdf Dosyaları (*.pdf)|*.pdf";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xlsx":
                            grid.ExportToXlsx(exportFilePath);
                            break;

                        case ".pdf":
                            grid.ExportToPdf(exportFilePath);
                            break;
                        default:
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            //Try to open the file and let windows decide how to open it.
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = "Dosya Açılamadı." + Environment.NewLine + Environment.NewLine + "Yol: " + exportFilePath;
                            DevExpress.XtraEditors.XtraMessageBox.Show(msg, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "Dosya Kaydedilemedi." + Environment.NewLine + Environment.NewLine + "Yol: " + exportFilePath;
                        DevExpress.XtraEditors.XtraMessageBox.Show(msg, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void setListView(ListView list)
        {
            list.Columns.Clear();
            list.Items.Clear();
            list.View = View.Details;
            list.FullRowSelect = true;
            list.CheckBoxes = true;
            list.GridLines = true;
            list.FullRowSelect = true;
            list.HideSelection = false;
            list.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            list.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public void FillGridForCardSettings(string tabloadi, DevExpress.XtraGrid.GridControl grid, GridView view)
        {
            System.Data.DataTable dt = db.GetDataTable("select * from " + tabloadi);
            grid.DataSource = dt;
            view.Columns[0].Visible = false;
            view.Columns[1].Caption = "Ad";
            view.Columns[2].Caption = "Kod";
            view.Columns[3].Caption = "Kısa Ad";
            view.Columns[4].Caption = "Durum";
        }

        public void ClearForm(AtlasForm form)
        {
            foreach (Control item in form.Controls)
            {
                if (item.Controls.Count > 0)
                {
                    #region inSide
                    foreach (Control y in item.Controls)
                    {
                        #region GSM
                        if (y is FlashTextBoxGsm)
                        {
                            FlashTextBoxGsm cm = (FlashTextBoxGsm)y;
                            cm.ClearData();
                        }
                        #endregion

                        #region TBOX
                        if (y is AtlasTextBox)
                        {
                            AtlasTextBox cm = (AtlasTextBox)y;
                            cm.ClearData();
                        }
                        #endregion

                        #region MEMO 

                        if (y is AtlasMemoEdit)
                        {
                            AtlasMemoEdit cm = (AtlasMemoEdit)y;
                            cm.ClearData();
                        }

                        #endregion

                        #region LOOKUP
                        if (y is AtlasLookUp)
                        {
                            AtlasLookUp cm = (AtlasLookUp)y;
                            cm.flaLookUp.Properties.Columns.Clear();
                        }
                        #endregion

                        #region DATE
                        if (y is AtlasDateEdit)
                        {
                            AtlasDateEdit cm = (AtlasDateEdit)y;
                            cm.ClearData();
                        }
                        #endregion

                        #region DATE
                        if (y is AtlasDateEdit)
                        {
                            AtlasDateEdit cm = (AtlasDateEdit)y;
                            cm.ClearData();
                        }
                        #endregion

                        #region COMBO
                        if (y is AtlasComboBox)
                        {
                            AtlasComboBox cm = (AtlasComboBox)y;
                            cm.ClearData();
                        }
                        #endregion

                        #region CHECKBOX
                        if (y is AtlasCheckEdit)
                        {
                            AtlasCheckEdit cm = (AtlasCheckEdit)y;
                            cm.SetBoolValue(false);
                        }
                        #endregion

                        #region BUTTON EDİT
                        if (y is AtlasButtonEdit)
                        {
                            AtlasButtonEdit cm = (AtlasButtonEdit)y;
                            cm.ClearData();
                        }
                        #endregion
                    }
                    #endregion
                }
            }


        }

    }
}
