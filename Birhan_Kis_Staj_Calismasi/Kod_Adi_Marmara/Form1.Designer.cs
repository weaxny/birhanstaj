namespace Kod_Adi_Marmara
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnKlasorSec = new System.Windows.Forms.Button();
            this.btnKoplaya = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnTasi = new System.Windows.Forms.Button();
            this.btnYenidenAdlandir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxYeniAd = new System.Windows.Forms.TextBox();
            this.btnAc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Menu;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(13, 13);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(561, 425);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // btnKlasorSec
            // 
            this.btnKlasorSec.BackColor = System.Drawing.Color.White;
            this.btnKlasorSec.Location = new System.Drawing.Point(580, 13);
            this.btnKlasorSec.Name = "btnKlasorSec";
            this.btnKlasorSec.Size = new System.Drawing.Size(124, 58);
            this.btnKlasorSec.TabIndex = 1;
            this.btnKlasorSec.Text = "Klasör Seç";
            this.btnKlasorSec.UseVisualStyleBackColor = false;
            this.btnKlasorSec.Click += new System.EventHandler(this.btnKlasorSec_Click);
            // 
            // btnKoplaya
            // 
            this.btnKoplaya.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnKoplaya.Location = new System.Drawing.Point(580, 77);
            this.btnKoplaya.Name = "btnKoplaya";
            this.btnKoplaya.Size = new System.Drawing.Size(124, 58);
            this.btnKoplaya.TabIndex = 2;
            this.btnKoplaya.Text = "Kopyala ve Yapıştır";
            this.btnKoplaya.UseVisualStyleBackColor = false;
            this.btnKoplaya.Click += new System.EventHandler(this.btnKopyala_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.LightCoral;
            this.btnSil.Location = new System.Drawing.Point(580, 141);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(124, 58);
            this.btnSil.TabIndex = 3;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnTasi
            // 
            this.btnTasi.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnTasi.Location = new System.Drawing.Point(580, 205);
            this.btnTasi.Name = "btnTasi";
            this.btnTasi.Size = new System.Drawing.Size(124, 58);
            this.btnTasi.TabIndex = 4;
            this.btnTasi.Text = "Taşı";
            this.btnTasi.UseVisualStyleBackColor = false;
            this.btnTasi.Click += new System.EventHandler(this.btnTasi_Click);
            // 
            // btnYenidenAdlandir
            // 
            this.btnYenidenAdlandir.BackColor = System.Drawing.SystemColors.Info;
            this.btnYenidenAdlandir.Location = new System.Drawing.Point(580, 380);
            this.btnYenidenAdlandir.Name = "btnYenidenAdlandir";
            this.btnYenidenAdlandir.Size = new System.Drawing.Size(124, 58);
            this.btnYenidenAdlandir.TabIndex = 5;
            this.btnYenidenAdlandir.Text = "Yeniden Adlandır";
            this.btnYenidenAdlandir.UseVisualStyleBackColor = false;
            this.btnYenidenAdlandir.Click += new System.EventHandler(this.btnYenidenAdlandir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(590, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Yeni Dosya Adı";
            // 
            // textBoxYeniAd
            // 
            this.textBoxYeniAd.Location = new System.Drawing.Point(580, 351);
            this.textBoxYeniAd.Name = "textBoxYeniAd";
            this.textBoxYeniAd.Size = new System.Drawing.Size(124, 20);
            this.textBoxYeniAd.TabIndex = 7;
            // 
            // btnAc
            // 
            this.btnAc.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAc.Location = new System.Drawing.Point(580, 269);
            this.btnAc.Name = "btnAc";
            this.btnAc.Size = new System.Drawing.Size(124, 58);
            this.btnAc.TabIndex = 8;
            this.btnAc.Text = "Aç";
            this.btnAc.UseVisualStyleBackColor = false;
            this.btnAc.Click += new System.EventHandler(this.btnAc_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(714, 450);
            this.Controls.Add(this.btnAc);
            this.Controls.Add(this.textBoxYeniAd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnYenidenAdlandir);
            this.Controls.Add(this.btnTasi);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnKoplaya);
            this.Controls.Add(this.btnKlasorSec);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Dosya Yöneticisi";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnKlasorSec;
        private System.Windows.Forms.Button btnKoplaya;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnTasi;
        private System.Windows.Forms.Button btnYenidenAdlandir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxYeniAd;
        private System.Windows.Forms.Button btnAc;
    }
}

