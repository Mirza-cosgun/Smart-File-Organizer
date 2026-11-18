using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace AkilliDosyaDuzenleyici
{
    public partial class KurulumFormu : Form
    {
        public KurulumFormu()
        {
            InitializeComponent();
        }

        // 1. "Göz At" Butonuna Tıklanınca Çalışacak Kod.
        private void btnGozat_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Düzenlenecek ana klasörü seçin (Örn: İndirilenler)";

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtKlasorYolu.Text = fbd.SelectedPath;
                }
            }
        }

        // 2. "Kaydet ve Başlat" Butonuna Tıklanınca Çalışacak Kod.
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKlasorYolu.Text))
            {
                MessageBox.Show("Lütfen önce bir klasör seç!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ayarları bir obje içinde toplar.
            var ayarlar = new
            {
                HedefKlasor = txtKlasorYolu.Text,
                OtomatikBaslat = chkOtoBaslat.Checked
            };

            // Newtonsoft.Json ile objeyi JSON formatına çevirir.
            // Formatting.Indented parametresi JSON dosyasının içini alt alta, okunaklı ve düzenli yazar.
            string jsonMetni = JsonConvert.SerializeObject(ayarlar, Formatting.Indented);

            // JSON dosyasını programın çalıştığı yere (exe'nin yanına) kaydeder.
            string ayarDosyasi = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ayarlar.json");
            File.WriteAllText(ayarDosyasi, jsonMetni);

            MessageBox.Show("Ayarlar başarıyla kaydedildi! Program şimdi arka planda çalışmaya başlayacak.", "Kurulum Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Sistemi yeniden başlatarak Program.cs'deki "Ayar dosyası varsa Gizli Motoru aç" mantığını tetikler.
            Application.Restart();
            Environment.Exit(0);
        }
    }
}
