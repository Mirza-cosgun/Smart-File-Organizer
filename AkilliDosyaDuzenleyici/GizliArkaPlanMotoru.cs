using Newtonsoft.Json;
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

namespace AkilliDosyaDuzenleyici
{
    public partial class GizliArkaPlanMotoru : Form
    {
        private FileSystemWatcher watcher;
        public GizliArkaPlanMotoru()
        {
            InitializeComponent();

            // nIconMotor, Toolbox'tan eklenen NotifyIcon'un adıdır.
            nIconMotor.Visible = true;

            AyarlariYukleVeMotoruBaslat();
        }

        // 1. Bu Kod Formun Görünmemesini Sağlar.
        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(false); // Formun görünürlüğünü kalıcı olarak iptal eder.
        }

        // 2. Ayarları Okuyan ve Dinlemeyi Başlatan Fonksiyon.
        private void AyarlariYukleVeMotoruBaslat()
        {
            string ayarDosyasi = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ayarlar.json");

            if (File.Exists(ayarDosyasi))
            {
                // JSON Dosyasını Okur.
                string jsonMetni = File.ReadAllText(ayarDosyasi);

                // Dynamic Tipiyle Class Oluşturmadan İçindeki Veriyi Çeker.
                dynamic ayarlar = JsonConvert.DeserializeObject(jsonMetni);
                string hedefKlasor = ayarlar.HedefKlasor;

                // Motoru (Watcher) o Klasör İçin Çalıştırır.
                KlasoruDinle(hedefKlasor);
            }
        }

        // 3. Klasör Kontrolu (Döngü Engelleyici)
        private void KlasoruDinle(string klasorYolu)
        {
            watcher = new FileSystemWatcher(klasorYolu);
            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.LastWrite;

            watcher.IncludeSubdirectories = false;
            watcher.Created += YeniDosyaGeldi;
            watcher.EnableRaisingEvents = true;
        }

        // Çoğu Dosya Türü ve Onlara Ait Dosyalar
        private static readonly Dictionary<string, string> UzantiHaritasi = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            // 1. RESİMLER & TASARIM DOSYALARI
            { ".jpg", "Resimler" }, { ".jpeg", "Resimler" }, { ".png", "Resimler" },
            { ".gif", "Resimler" }, { ".bmp", "Resimler" }, { ".webp", "Resimler" },
            { ".svg", "Resimler" }, { ".ico", "Resimler" }, { ".tiff", "Resimler" },
            { ".tif", "Resimler" }, { ".heic", "Resimler" }, { ".raw", "Resimler" },
            { ".jfif", "Resimler" }, { ".psd", "Tasarım Dosyaları" }, { ".ai", "Tasarım Dosyaları" },
            { ".eps", "Tasarım Dosyaları" }, { ".fig", "Tasarım Dosyaları" }, { ".xd", "Tasarım Dosyaları" },
            { ".sketch", "Tasarım Dosyaları" },{ ".cdr", "Tasarım Dosyaları" },

            // 2. VİDEOLAR
            { ".mp4", "Videolar" }, { ".mkv", "Videolar" }, { ".avi", "Videolar" },
            { ".mov", "Videolar" }, { ".wmv", "Videolar" }, { ".flv", "Videolar" },
            { ".webm", "Videolar" }, { ".m4v", "Videolar" }, { ".mpeg", "Videolar" },
            { ".mpg", "Videolar" }, { ".3gp", "Videolar" }, { ".vob", "Videolar" },

            // 3. SES & MÜZİK
            { ".mp3", "Müzikler" }, { ".wav", "Müzikler" }, { ".flac", "Müzikler" },
            { ".aac", "Müzikler" }, { ".ogg", "Müzikler" }, { ".wma", "Müzikler" },
            { ".m4a", "Müzikler" }, { ".opus", "Müzikler" }, { ".mid", "Müzikler" },
            { ".midi", "Müzikler" }, { ".aiff", "Müzikler" },

            // 4. BELGELER, OFİS & E-KİTAP
            { ".pdf", "Belgeler" }, { ".doc", "Belgeler" }, { ".docx", "Belgeler" },
            { ".txt", "Belgeler" }, { ".rtf", "Belgeler" }, { ".odt", "Belgeler" },
            { ".xls", "Belgeler" }, { ".xlsx", "Belgeler" }, { ".csv", "Belgeler" },
            { ".ods", "Belgeler" }, { ".ppt", "Belgeler" }, { ".pptx", "Belgeler" },
            { ".odp", "Belgeler" }, { ".md", "Belgeler" }, { ".epub", "Belgeler" },
            { ".mobi", "Belgeler" }, { ".tex", "Belgeler" }, { ".log", "Belgeler" },

            // 5. YAZILIM, WEB & KAYNAK KODLARI
            { ".cs", "Yazılım & Kod" }, { ".cpp", "Yazılım & Kod" }, { ".c", "Yazılım & Kod" },
            { ".h", "Yazılım & Kod" }, { ".hpp", "Yazılım & Kod" }, { ".py", "Yazılım & Kod" },
            { ".java", "Yazılım & Kod" }, { ".class", "Yazılım & Kod" }, { ".js", "Yazılım & Kod" },
            { ".ts", "Yazılım & Kod" }, { ".jsx", "Yazılım & Kod" }, { ".tsx", "Yazılım & Kod" },
            { ".html", "Yazılım & Kod" }, { ".htm", "Yazılım & Kod" }, { ".css", "Yazılım & Kod" },
            { ".scss", "Yazılım & Kod" }, { ".sass", "Yazılım & Kod" }, { ".less", "Yazılım & Kod" },
            { ".php", "Yazılım & Kod" }, { ".sql", "Yazılım & Kod" }, { ".json", "Yazılım & Kod" },
            { ".xml", "Yazılım & Kod" }, { ".yaml", "Yazılım & Kod" }, { ".yml", "Yazılım & Kod" },
            { ".go", "Yazılım & Kod" }, { ".rs", "Yazılım & Kod" }, { ".rb", "Yazılım & Kod" },
            { ".swift", "Yazılım & Kod" }, { ".kt", "Yazılım & Kod" }, { ".kts", "Yazılım & Kod" },
            { ".dart", "Yazılım & Kod" }, { ".lua", "Yazılım & Kod" }, { ".r", "Yazılım & Kod" },
            { ".sh", "Yazılım & Kod" }, { ".bat", "Yazılım & Kod" }, { ".ps1", "Yazılım & Kod" },
            { ".ino", "Yazılım & Kod" }, { ".asm", "Yazılım & Kod" }, { ".vue", "Yazılım & Kod" },
            { ".svelte", "Yazılım & Kod" }, { ".sln", "Yazılım & Kod" }, { ".csproj", "Yazılım & Kod" },

            // 6. ARŞİVLER & DİSK KALIPLARI
            { ".zip", "Arşivler" }, { ".rar", "Arşivler" }, { ".7z", "Arşivler" },
            { ".tar", "Arşivler" }, { ".gz", "Arşivler" }, { ".bz2", "Arşivler" },
            { ".xz", "Arşivler" }, { ".iso", "Arşivler" }, { ".cab", "Arşivler" },
            { ".tgz", "Arşivler" },

            // 7. KURULUMLAR, ÇALIŞTIRILABİLİRLER & KISAYOLLAR
            { ".exe", "Kurulumlar" }, { ".msi", "Kurulumlar" }, { ".apk", "Kurulumlar" },
            { ".aab", "Kurulumlar" }, { ".jar", "Kurulumlar" }, { ".deb", "Kurulumlar" },
            { ".rpm", "Kurulumlar" }, { ".dmg", "Kurulumlar" }, { ".pkg", "Kurulumlar" },
            { ".appimage", "Kurulumlar" }, { ".msix", "Kurulumlar" }, { ".lnk", "Kısayollar" },
            { ".url", "Kısayollar" },

            // 8. 3D MODELLEME, CAD & OYUN MODLARI
            { ".obj", "3D & CAD" }, { ".fbx", "3D & CAD" }, { ".stl", "3D & CAD" },
            { ".blend", "3D & CAD" }, { ".3ds", "3D & CAD" }, { ".dae", "3D & CAD" },
            { ".step", "3D & CAD" }, { ".stp", "3D & CAD" }, { ".dwg", "3D & CAD" },
            { ".dxf", "3D & CAD" }, { ".pak", "Oyun Dosyaları" }, { ".vpk", "Oyun Dosyaları" },
            { ".mcpack", "Oyun Dosyaları" }, { ".mcworld", "Oyun Dosyaları" },

            // 9. VERİTABANLARI & YEDEKLER
            { ".db", "Veritabanları" }, { ".sqlite", "Veritabanları" }, { ".sqlite3", "Veritabanları" },
            { ".mdb", "Veritabanları" }, { ".accdb", "Veritabanları" }, { ".bak", "Veritabanları" },
            { ".dmp", "Veritabanları" },

            // 10. YAZI TİPLERİ (FONTLAR)
            { ".ttf", "Fontlar" }, { ".otf", "Fontlar" }, { ".woff", "Fontlar" },
            { ".woff2", "Fontlar" }, { ".eot", "Fontlar" },

            // 11. TORRENT
            { ".torrent", "Torrentler" }, { ".nzb", "Torrentler" }
        };

        private void YeniDosyaGeldi(object sender, FileSystemEventArgs e)
        {
            string dosyaYolu = e.FullPath;
            string dosyaAdi = e.Name;
            string anaKlasor = Path.GetDirectoryName(dosyaYolu);

            // Programın Oluşturduğu Klasörlere Dokunmaz Bir Çeşit Basit Bypass.
            if (UzantiHaritasi.ContainsValue(dosyaAdi) || dosyaAdi == "Diğer" || dosyaAdi == "Klasörler")
            {
                return;
            }

            // Gelen Şey Dosya mı Klasör mü kontrol Eder.
            bool klasorMu = Directory.Exists(dosyaYolu);

            // Klasör İse
            if (klasorMu)
            {
                try
                {
                    string hedefAltKlasor = "Klasörler";
                    string tasinacakKlasorYolu = Path.Combine(anaKlasor, hedefAltKlasor);

                    if (!Directory.Exists(tasinacakKlasorYolu))
                    {
                        Directory.CreateDirectory(tasinacakKlasorYolu);
                    }

                    string yeniKlasorYolu = Path.Combine(tasinacakKlasorYolu, dosyaAdi);

                    // Aynı İsimde Klasör Varsa Sonuna (1) Ekler
                    int sayac = 1;
                    while (Directory.Exists(yeniKlasorYolu))
                    {
                        string yeniAd = $"{dosyaAdi} ({sayac})";
                        yeniKlasorYolu = Path.Combine(tasinacakKlasorYolu, yeniAd);
                        sayac++;
                    }

                    // Bir Klasör Oluşturulur Oluşturulmaz İçindeki Dosyalar Hemen Kopyalanmıyor Olabilir, Ufak Bir Süre Bekler.
                    System.Threading.Thread.Sleep(500);

                    Directory.Move(dosyaYolu, yeniKlasorYolu);
                    nIconMotor.ShowBalloonTip(3000, "Klasör Düzenlendi!", $"'{dosyaAdi}' -> {hedefAltKlasor} içine taşındı.", ToolTipIcon.Info);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Klasör taşıma hatası: " + ex.Message);
                }

                return; // Klasör İşi Bitti, Aşağıdaki Dosya Kodlarına İnmesine Gerek Yok.
            }

            // Dosya İse
            string uzanti = Path.GetExtension(dosyaYolu).ToLowerInvariant();

            if (string.IsNullOrEmpty(uzanti) || uzanti == ".crdownload" || uzanti == ".part" || uzanti == ".opdownload" || uzanti == ".download" || uzanti == ".tmp")
                return;

            if (!DosyaKullanimaHazirMi(dosyaYolu))
            {
                System.Threading.Thread.Sleep(2000);
                if (!DosyaKullanimaHazirMi(dosyaYolu)) return;
            }

            if (!UzantiHaritasi.TryGetValue(uzanti, out string altKlasorDosya))
            {
                altKlasorDosya = "Diğer";
            }

            try
            {
                string tasinacakKlasorYolu = Path.Combine(anaKlasor, altKlasorDosya);

                if (!Directory.Exists(tasinacakKlasorYolu))
                {
                    Directory.CreateDirectory(tasinacakKlasorYolu);
                }

                string yeniDosyaYolu = Path.Combine(tasinacakKlasorYolu, dosyaAdi);

                int sayac = 1;
                while (File.Exists(yeniDosyaYolu))
                {
                    string yeniAd = $"{Path.GetFileNameWithoutExtension(dosyaAdi)} ({sayac}){uzanti}";
                    yeniDosyaYolu = Path.Combine(tasinacakKlasorYolu, yeniAd);
                    sayac++;
                }

                File.Move(dosyaYolu, yeniDosyaYolu);
                nIconMotor.ShowBalloonTip(3000, "Dosya Düzenlendi!", $"{dosyaAdi} -> {altKlasorDosya} klasörüne taşındı.", ToolTipIcon.Info);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Dosya taşıma hatası: " + ex.Message);
            }
        }

        // Dosyanın İndirilmesi Bitmiş mi Diye Kontrol Eder.
        private bool DosyaKullanimaHazirMi(string yol)
        {
            try
            {
                using (FileStream stream = File.Open(yol, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                // Dosya Hala Başka Bir İşlem Tarafından Kullanılıyor (iniyor).
                return false;
            }
            return true;
        }

        // Sağ Tık Menüsünden Çıkış'a Basınca Programı Kapatır.
        private void programdanÇıkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nIconMotor.Visible = false; // Kapatırken Sağ Alttaki Simgeyi Temizler.
            Application.Exit();
        }   
    }
}
