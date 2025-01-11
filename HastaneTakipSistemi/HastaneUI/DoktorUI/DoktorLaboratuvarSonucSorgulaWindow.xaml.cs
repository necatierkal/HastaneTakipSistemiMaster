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

namespace HastaneTakipSistemi.HastaneUI.DoktorUI
{
    /// <summary>
    /// Interaction logic for LaboratuvarSonucSorgulaWindow.xaml
    /// </summary>
    public partial class DoktorLaboratuvarSonucSorgulaWindow : MetroWindow
    {
        public string hastaTCKimlikNo { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private List<lab> _LabList;
        public int drId { get; set; }

        public List<lab> LabList
        {
            get
            {
                return _LabList;
            }
            set
            {
                _LabList = value;
                OnPropertyChanged("LabList");
            }
        }
        private List<lab> _SelectedLab;

        public List<lab> SelectedLab
        {
            get
            {
                return _SelectedLab;
            }
            set
            {
                _SelectedLab = value;
                OnPropertyChanged("SelectedLab");
            }
        }
        public DoktorLaboratuvarSonucSorgulaWindow(int drId)
        {
            InitializeComponent();

            this.drId = drId;
            DataContext = this; 
        }

        private async void btnGoruntule_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                hastaTCKimlikNo = tbxTCkimlikNo.Text;

                if(!(string.IsNullOrEmpty(hastaTCKimlikNo)))
                {
                    LabList = DoktorBLL.GetLabSonucByTCBLL(hastaTCKimlikNo);

                    dgrLabSonuc.ItemsSource = LabList;
                }
                else
                {
                    await this.ShowMessageAsync("Boş Değer", "Sonuçlarını sorgulamak istediğiniz hastanın T.C. Kimlik numarasını giriniz.");
                }
                
            }
            catch (Exception)
            {
                await this.ShowMessageAsync("İşlemde Hata", "Listeleme Esnasında Hata Meydana Geldi"); 
            }
        }
        private void dgrLabSonuc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedLab = dgrLabSonuc.SelectedItems.Cast<lab>().ToList();

            foreach (var item in SelectedLab)
            {
                lblRecete.Content =  item.lab_sonuc.ToString();
            }
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
    }
}
