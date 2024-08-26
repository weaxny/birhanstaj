using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Kod_Adi_Marmara
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listView1.Columns.Add("Dosya Adı", 200);
            listView1.Columns.Add("Boyut", 100);
            listView1.Columns.Add("Oluşturulma Tarihi", 150);
            listView1.Columns.Add("Tür", 100);
        }
        
        private string secilenKlasor = string.Empty;
        private void btnKlasorSec_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    secilenKlasor = fbd.SelectedPath;
                    ListeleDosyaVeKlasorler(secilenKlasor);
                }
            }
        }

        private void ListeleDosyaVeKlasorler(string path)
        {
            listView1.Items.Clear();

            DirectoryInfo di = new DirectoryInfo(path);

            // Önce klasörleri listeliyoruz
            DirectoryInfo[] directories = di.GetDirectories();
            foreach (DirectoryInfo dir in directories)
            {
                ListViewItem item = new ListViewItem(dir.Name);
                item.SubItems.Add("");
                item.SubItems.Add(dir.CreationTime.ToString());
                item.SubItems.Add("Klasör");
                item.Tag = dir.FullName;
                listView1.Items.Add(item);
            }

            // Sonra dosyaları listeliyoruz
            FileInfo[] files = di.GetFiles();
            foreach (FileInfo file in files)
            {
                ListViewItem item = new ListViewItem(file.Name);
                item.SubItems.Add(file.Length.ToString());
                item.SubItems.Add(file.CreationTime.ToString());
                item.SubItems.Add(file.Extension);
                item.Tag = file.FullName;
                listView1.Items.Add(item);
            }
            btnAc.Enabled = true;
            btnKoplaya.Enabled = true;
            btnSil.Enabled = true;
            btnYenidenAdlandir.Enabled = true;
            btnTasi.Enabled = true;
            btnKlasorSec.BackColor = System.Drawing.Color.White;
        }

        private void btnKopyala_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        string hedefKlasor = fbd.SelectedPath;

                        foreach (ListViewItem item in listView1.SelectedItems)
                        {
                            string kaynakYol = item.Tag.ToString();
                            string hedefYol = Path.Combine(hedefKlasor, item.Text);

                            if (Directory.Exists(kaynakYol))
                            {
                                // Klasör ise
                                DirectoryCopy(kaynakYol, hedefYol, true);
                            }
                            else if (File.Exists(kaynakYol))
                            {
                                // Dosya ise
                                File.Copy(kaynakYol, hedefYol);
                            }
                        }
                    }
                }
            }
        }
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Hedef klasörü oluştur
            Directory.CreateDirectory(destDirName);

            // Dosyaları kopyala
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }

            // Alt klasörleri kopyala
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    string yol = item.Tag.ToString();

                    if (Directory.Exists(yol))
                    {
                        if (MessageBox.Show($"{item.Text} klasörünü silmek istediğinize emin misiniz?", "Onayla", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Directory.Delete(yol, true);
                        }
                    }
                    else if (File.Exists(yol))
                    {
                        if (MessageBox.Show($"{item.Text} dosyasını silmek istediğinize emin misiniz?", "Onayla", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            File.Delete(yol);
                        }
                    }
                }
                ListeleDosyaVeKlasorler(secilenKlasor);
            }
        }

        private void btnTasi_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        string hedefKlasor = fbd.SelectedPath;

                        foreach (ListViewItem item in listView1.SelectedItems)
                        {
                            string kaynakYol = item.Tag.ToString();
                            string hedefYol = Path.Combine(hedefKlasor, item.Text);

                            if (Directory.Exists(kaynakYol))
                            {
                                // Klasör ise
                                Directory.Move(kaynakYol, hedefYol);
                            }
                            else if (File.Exists(kaynakYol))
                            {
                                // Dosya ise
                                File.Move(kaynakYol, hedefYol);
                            }
                        }
                        ListeleDosyaVeKlasorler(secilenKlasor);
                    }
                }
            }
        }

        private void btnYenidenAdlandir_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                string yeniAd = textBoxYeniAd.Text;
                if (!string.IsNullOrWhiteSpace(yeniAd))
                {
                    string eskiYol = listView1.SelectedItems[0].Tag.ToString();
                    string yeniYol = Path.Combine(Path.GetDirectoryName(eskiYol), yeniAd);

                    if (Directory.Exists(eskiYol))
                    {
                        Directory.Move(eskiYol, yeniYol);
                    }
                    else if (File.Exists(eskiYol))
                    {
                        File.Move(eskiYol, yeniYol);
                    }

                    ListeleDosyaVeKlasorler(secilenKlasor);
                }
            }
        }

        private void btnAc_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                string secilenYol = listView1.SelectedItems[0].Tag.ToString();

                if (Directory.Exists(secilenYol))
                {
                    // Eğer seçili olan bir klasörse, o klasöre geçiş yap ve içeriklerini listele
                    secilenKlasor = secilenYol;
                    ListeleDosyaVeKlasorler(secilenKlasor);
                }
                else
                {
                    string dosyaUzantisi = Path.GetExtension(secilenYol).ToLower();

                    if (dosyaUzantisi == ".png" || dosyaUzantisi == ".jpg" || dosyaUzantisi == ".jpeg")
                    {
                        // Resim dosyasını aç
                        try
                        {
                            Form resimFormu = new Form
                            {
                                Text = Path.GetFileName(secilenYol),
                                Size = new Size(800, 600)
                            };

                            PictureBox pictureBox = new PictureBox
                            {
                                Image = Image.FromFile(secilenYol),
                                SizeMode = PictureBoxSizeMode.Zoom,
                                Dock = DockStyle.Fill
                            };

                            resimFormu.Controls.Add(pictureBox);
                            resimFormu.ShowDialog();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Resim dosyası açılamadı: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (dosyaUzantisi == ".txt")
                    {
                        // Metin dosyasını aç ve düzenlemeye izin ver
                        try
                        {
                            Form metinFormu = new Form
                            {
                                Text = Path.GetFileName(secilenYol),
                                Size = new Size(800, 600)
                            };

                            TextBox textBox = new TextBox
                            {
                                Multiline = true,
                                Dock = DockStyle.Fill,
                                ScrollBars = ScrollBars.Both,
                                Text = File.ReadAllText(secilenYol)
                            };

                            metinFormu.Controls.Add(textBox);

                            // Form kapanmadan önce kaydetmek isteyip istemediğini sorma
                            metinFormu.FormClosing += (s, args) =>
                            {
                                DialogResult result = MessageBox.Show("Yapılan değişiklikleri kaydetmek istiyor musunuz?", "Kaydet", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                                if (result == DialogResult.Yes)
                                {
                                    // Değişiklikleri kaydet
                                    File.WriteAllText(secilenYol, textBox.Text);
                                }
                                else if (result == DialogResult.Cancel)
                                {
                                    // Kapatmayı iptal et
                                    args.Cancel = true;
                                }
                            };

                            metinFormu.ShowDialog();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Metin dosyası açılamadı: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (dosyaUzantisi == ".mp3" || dosyaUzantisi == ".mp4" || dosyaUzantisi == ".opus")
                    {
                        // Ses veya video dosyasını aç (mp3, mp4, opus)
                        try
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(secilenYol) { UseShellExecute = true });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Dosya açılamadı: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // Desteklenmeyen dosya formatı
                        MessageBox.Show("Desteklenmeyen dosya formatı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // Çoklu seçim yapılmış veya seçim yapılmamış
                MessageBox.Show("Lütfen sadece bir dosya veya klasör seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnAc.Enabled = false;
            btnKoplaya.Enabled = false;
            btnSil.Enabled = false;
            btnYenidenAdlandir.Enabled = false;
            btnTasi.Enabled = false;
            btnKlasorSec.BackColor = System.Drawing.Color.IndianRed;
        }
    }
}
