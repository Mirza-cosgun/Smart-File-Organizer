using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkilliDosyaDuzenleyici
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Ayar dosyamızın yolu (Programın çalıştığı klasördeki ayarlar.json).
            string ayarDosyasi = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ayarlar.json");

            // EĞER AYAR DOSYASI YOKSA (İLK AÇILIŞ)
            if (!File.Exists(ayarDosyasi))
            {
                // Kullanıcının Ayarları Yapacağı İlk Formu Ekrana Getirir.
                Application.Run(new KurulumFormu());
            }
            // EĞER AYAR DOSYASI VARSA (DAHA ÖNCE KURULMUŞ)
            else
            {
                // Form Göstermeyip, Sadece Sağ Alt Köşe (Tray) Kodlarını Çalıştıran Arka Plan Yapısını Başlatır.
                Application.Run(new GizliArkaPlanMotoru());
            }
        }
    }
}
