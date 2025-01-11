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

namespace HastaneTakipSistemi.HastaneUI
{
    /// <summary>
    /// HastaRandevuGecmisiWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class HastaRandevuGecmisiWindow : MetroWindow
    {
        public string hastaIdent { get; set; }

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

        public HastaRandevuGecmisiWindow(int hastaId)
        {
            InitializeComponent();  
            hastaIdent = Convert.ToString(hastaId);
            this.DataContext = this;
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void btnRandevuListele_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RandevuList = HastaBLL.GetRandevuListBLL(hastaIdent);
                dgrRandevuGecmisi.ItemsSource = RandevuList;
            }
            catch (Exception)
            {
                await this.ShowMessageAsync("İşlemde Hata", "Listeleme Esnasında Hata Meydana Geldi");
            }
        }
    }
}
