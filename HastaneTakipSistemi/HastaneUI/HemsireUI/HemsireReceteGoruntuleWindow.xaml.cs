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
    /// Interaction logic for HemsireReceteGoruntuleWindow.xaml
    /// </summary>
    public partial class HemsireReceteGoruntuleWindow : MetroWindow
    {
        public string hastaTCKimlikNo { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;


        private List<recete> _ReceteList;
        public int HemsireId { get; set; }

        public List<recete> ReceteList
        {
            get
            {
                return _ReceteList;
            }
            set
            {
                _ReceteList = value;
                OnPropertyChanged("ReceteList");
            }
        }
        private List<recete> _SelectedRecete;

        public List<recete> SelectedRecete
        {
            get
            {
                return _SelectedRecete;
            }
            set
            {
                _SelectedRecete = value;
                OnPropertyChanged("SelectedRecete");
            }
        }
        public HemsireReceteGoruntuleWindow(int HemsireId)
        {
            InitializeComponent();
            this.HemsireId = HemsireId;
            DataContext = this; 
        }
        
        private async void btnGoruntule_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                hastaTCKimlikNo = tbxTCkimlikNo.Text;

                if(!(string.IsNullOrEmpty(hastaTCKimlikNo)))
                {
                    ReceteList = HemsireBLL.GetReceteByTCBLL(hastaTCKimlikNo);

                    dgrRecete.ItemsSource = ReceteList;
                }
                else
                {
                    await this.ShowMessageAsync("Boş Değer", "Reçetesini görüntülemek istediğiniz hastanın TCKimlik numarasını giriniz");
                }
            }
            catch (Exception)
            {
                await this.ShowMessageAsync("İşlemde Hata", "Listeleme Esnasında Hata Meydana Geldi"); 
            }
        }

        private void btnCikis_Click(object sender, RoutedEventArgs e)
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
        private void dgrRecete_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedRecete = dgrRecete.SelectedItems.Cast<recete>().ToList();

            foreach (var item in SelectedRecete)
            {
                lblRecete.Content = item.dr_aciklama.ToString();
            }
        }
    }
}
