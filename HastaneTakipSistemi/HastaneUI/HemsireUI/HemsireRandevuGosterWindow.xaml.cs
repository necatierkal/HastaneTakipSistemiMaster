using HastaneTakipSistemi.HastaneBLL;
using HastaneTakipSistemi.HastaneDAL;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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
    /// Interaction logic for HemsireRandevuGosterWindow.xaml
    /// </summary>
    public partial class HemsireRandevuGosterWindow : MetroWindow
    {
        public string HemsireIdent { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private List<randevular> _RandevuList;

        public List<randevular> RandevuList
        {
            get
            {
                return _RandevuList;
            }
            set
            {
                _RandevuList = value;
                OnPropertyChanged("RandevuList");
            }
        }
        public HemsireRandevuGosterWindow(int hemsireId)
        {
            InitializeComponent();
            HemsireIdent = Convert.ToString(hemsireId);
            DataContext = this; 
        }

  

        private async void btnRandevuListeleToplu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RandevuList = HemsireBLL.GetRandevuTopluBLL(HemsireIdent);
                dgrRandevu.ItemsSource = RandevuList;
            }
            catch (Exception)
            {
                await this.ShowMessageAsync("İşlemde Hata", "Listeleme Esnasında Hata Meydana Geldi");
            }
        }

        private async void btnRandevuListeleGunluk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RandevuList = HemsireBLL.GetRandevuGunlukBLL(HemsireIdent);
                dgrRandevu.ItemsSource = RandevuList;
            }
            catch (Exception)
            {
               await this.ShowMessageAsync("İşlemde Hata", "Listeleme Esnasında Hata Meydana Geldi"); 
            }
        }

        private async void btnAra_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!(string.IsNullOrEmpty(tbxTCKimlik.Text)))
                {
                    string TCKimlikNo = tbxTCKimlik.Text;
                    RandevuList = HemsireBLL.GetRandevuKisiBLL(HemsireIdent, TCKimlikNo);
                    dgrRandevu.ItemsSource = RandevuList;
                }
                else
                {
                    await this.ShowMessageAsync("Boş Değer", "Lütfen sorgulamak istediğiniz hastanın T.C. Kimlik numarası giriniz");
                }
                
            }
            catch (Exception)
            {
                await this.ShowMessageAsync("İşlemde Hata", "Listeleme Esnasında Hata Meydana Geldi"); 
            }
        }
        private void btnAnaMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
