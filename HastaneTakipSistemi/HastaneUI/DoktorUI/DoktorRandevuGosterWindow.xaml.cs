using HastaneTakipSistemi.HastaneBLL;
using HastaneTakipSistemi.HastaneDAL;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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
    /// Interaction logic for DoktorRandevuGosterWindow.xaml
    /// </summary>
    public partial class DoktorRandevuGosterWindow : MetroWindow
    {
        public string drIdent { get; set; }

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

        public DoktorRandevuGosterWindow(int drId)
        {
            InitializeComponent();

            drIdent = Convert.ToString(drId);
            this.DataContext = this;
        }

        private async void btnRandevuListeleGunluk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RandevuList = DoktorBLL.GetRandevuGunlukBLL(drIdent);
                dgrRandevu.ItemsSource = RandevuList;
            }
            catch (Exception)
            {

                await this.ShowMessageAsync("İşlemde Hata", "Listeleme Esnasında Hata Meydana Geldi"); ;
            }
        }

        private async void btnRandevuListeleToplu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RandevuList= DoktorBLL.GetRandevuTopluBLL(drIdent);
                dgrRandevu.ItemsSource = RandevuList;
            }
            catch (Exception)
            {
                await this.ShowMessageAsync("İşlemde Hata", "Listeleme Esnasında Hata Meydana Geldi");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private void btnAnaMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
