using HastaneTakipSistemi.HastaneDAL;
using HastaneTakipSistemi.HastaneBLL;
using MahApps.Metro.Controls;
using Microsoft.TeamFoundation.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HastaneTakipSistemi.HastaneUI.DoktorUI
{
    /// <summary>
    /// DoktorWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class DoktorWindow : MetroWindow
    {
        public int drId { get; set; }
        public string drKimlik { get; set; }

        public string sistemeGiris { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private List<doktorlar> _SelectedDoktor;

        public List<doktorlar> SelectedDoktor
        {
            get 
            { 
                return _SelectedDoktor; 
            }
            set 
            { 
                _SelectedDoktor = value;
                OnPropertyChanged("SelectedDoktor");
            }
        }

        public DoktorWindow(int doktorId)
        {
            ProgressRing prg = new ProgressRing(); 
            prg.IsActive = true;

            InitializeComponent();
            drId = doktorId;
            try
            {
                GetDoktorKimlikById(doktorId);
                drKimlik = "Hoşgeldiniz Dr." + " " + SelectedDoktor.Select(x => x.dr_ad).FirstOrDefault() + " "
                + SelectedDoktor.Select(x => x.dr_soyad).FirstOrDefault() + "";
            }
            catch (Exception)
            {

                throw new Exception("Doktor Bilgilerinde Hata Oluştu");
            }
            sistemeGiris = "Sisteme Giriş : " + DateTime.Now.ToString() + "";
            DataContext = this;
            prg.IsActive = false;
        }
        public void GetDoktorKimlikById(int doktorId)
        {
            SelectedDoktor = DoktorBLL.GetDoktorKimlikByIdBLL(doktorId).ToList();
        }
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var frm = new DoktorReceteGoruntuleWindow(drId);
            frm.ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var frm = new DoktorReceteYazWindow(drId);
            frm.ShowDialog();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            var frm = new DoktorRandevuGosterWindow(drId);
            frm.ShowDialog();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            var frm = new DoktorLaboratuvarSonucGirWindow(drId);
            frm.ShowDialog();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            var frm = new DoktorLaboratuvarSonucSorgulaWindow(drId);
            frm.ShowDialog();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            var frm = new DoktorBilgiWindow(drId);
            frm.ShowDialog();
        }
    }
}
