using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HastaneTakipSistemi.HastaneBLL;
using HastaneTakipSistemi.HastaneDAL;
using HastaneTakipSistemi.HastaneUI;
using HastaneTakipSistemi.HastaneUI.DoktorUI;
using HastaneTakipSistemi.HastaneUI.HemsireUI;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace HastaneTakipSistemi
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public int kullaniciTip { get; set; }
        public int kullaniciAdi { get; set; }
        public string kullaniciSifre { get; set; }

        public MainWindow()
        {
            InitializeComponent();
 
            DataContext = this;
        }

        private async void btnGiris_Click(object sender, RoutedEventArgs e)
        {
            //progress1.IsActive = true;
            //progress1.Visibility = Visibility.Visible;  Bunların asenkron yapılması lazım 

                if (rbDoktor.IsChecked == true)
                {
                    kullaniciTip = 0;
                }
                else if (rbHemsire.IsChecked == true)
                {
                    kullaniciTip = 1;
                }
                else if (rbHasta.IsChecked == true)
                {
                    kullaniciTip = 2;
                }

                kullaniciAdi = Convert.ToInt32(tbxKullaniciAdi.Text);
                kullaniciSifre = pbxSifre.Password.Trim().ToString();

                var res = LoginBLL.KullaniciKontrolBLL(kullaniciAdi, kullaniciSifre, kullaniciTip);

                if (res == true)
                {
                    await this.ShowMessageAsync("Kullanıcı Girişi", "Kullanıcı adı ve şifre doğru hoşgeldiniz.");
                    //MessageBox.Show("Kullanıcı adı ve şifre doğru hoşgeldiniz.");

                    switch (kullaniciTip)
                    {
                        case 0:
                            //var frm = new DoktorWindow(kullaniciAdi);
                            //frm.ShowDialog();
                            this.Hide();
                            var frm = new DoktorWindow(kullaniciAdi);
                            frm.Closed += (s, args) => this.Close();
                            frm.Show();
                            break;
                        case 1:
                            this.Hide();
                            var frm1 = new HemsireWindow(kullaniciAdi);
                            frm1.Closed += (s, args) => this.Close();
                            frm1.Show();
                            break;
                        case 2:
                            var x = new HastaRandevuWindow(kullaniciAdi);
                            x.ShowDialog();
                            //var frm = new HastaRandevuWindow(kullaniciAdi);
                            //frm.ShowDialog();
                            break;
                    }
                }
                else 
                {
                    await this.ShowMessageAsync("Kullanıcı Girişi",
                    "Kullanıcı adı veya şifre hatalı tekrar deneyiniz.");
                }
           
            
                //progress1.IsActive = false;
                //progress1.Visibility = Visibility.Collapsed; Bunların asenkron yapılması lazım
            
            
        }

    }
}
