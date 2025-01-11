using HastaneTakipSistemi.HastaneBLL;
using HastaneTakipSistemi.HastaneDAL;
using MahApps.Metro.Controls;
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

namespace HastaneTakipSistemi.HastaneUI.HemsireUI
{
    /// <summary>
    /// Interaction logic for HemsireWindow.xaml
    /// </summary>
    public partial class HemsireWindow : MetroWindow
    {
        public int HemsireIdent { get; set; }
        public string HemsireKimlik { get; set; }

        public string SistemeGiris { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private List<hemsireler> _SelectedHemsire;

        public List<hemsireler> SelectedHemsire
        {
            get
            {
                return _SelectedHemsire;
            }
            set
            {
                _SelectedHemsire = value;
                OnPropertyChanged("SelectedHemsire");
            }
        }
        public HemsireWindow(int hemsireId)
        {
            ProgressRing prg = new ProgressRing();
            prg.IsActive = true;

            InitializeComponent();
            HemsireIdent = hemsireId;
            DataContext = this;

            try
            {
                GetHemsireKimlikById(HemsireIdent);
                HemsireKimlik = "Hoşgeldiniz Sayın" + " " + SelectedHemsire.Select(x => x.hemsire_ad).FirstOrDefault() + " "
                + SelectedHemsire.Select(x => x.hemsire_soyad).FirstOrDefault() + "";
            }
            catch (Exception)
            {

                throw new Exception("Hemşire Bilgilerinde Hata Oluştu");
            }
            SistemeGiris = "Sisteme Giriş : " + DateTime.Now.ToString() + "";
            DataContext = this;
            prg.IsActive = false;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var frm = new HemsireReceteGoruntuleWindow(HemsireIdent);
            frm.ShowDialog();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            var frm = new HemsireRandevuGosterWindow(HemsireIdent);
            frm.ShowDialog();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            var frm = new HemsireLavoratuvarSonucSorgulaWindow(HemsireIdent);
            frm.ShowDialog();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            var frm = new HemsireBilgiWindow(HemsireIdent);
            frm.ShowDialog();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void GetHemsireKimlikById(int hemsireId)
        {
            SelectedHemsire = HemsireBLL.GetHemsireKimlikByIdBLL(hemsireId).ToList();
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }
        }
    }
}
