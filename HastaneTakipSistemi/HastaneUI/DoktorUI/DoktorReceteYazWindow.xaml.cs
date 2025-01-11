using HastaneTakipSistemi.HastaneBLL;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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
using System.Windows.Shapes;

namespace HastaneTakipSistemi.HastaneUI.DoktorUI
{
    /// <summary>
    /// Interaction logic for ReceteYazWindow.xaml
    /// </summary>
    public partial class DoktorReceteYazWindow : MetroWindow
    {
        public string drIdent { get; set; }

        public string receteTarih { get; set; }

        public string hastaTC { get; set; }

        public string recete { get; set; }
        public DoktorReceteYazWindow(int drId)
        {
            InitializeComponent();
            drIdent = Convert.ToString(drId);   
            DataContext = this; 
        }

        private async void btnYaz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                receteTarih = Convert.ToString(dtpTarih.SelectedDate);    
                hastaTC = Convert.ToString(tbxHastaTC.Text);
                recete = Convert.ToString(tbxRecete.Text); 
                
                DoktorBLL.DoktorReceteYazBLL(receteTarih, hastaTC, recete,drIdent);
                await this.ShowMessageAsync("Kayıt İşlemi Tamamlandı", "");
            }
            catch (Exception)
            {
                await this.ShowMessageAsync("İşlemde Hata", "Kayıt Esnasında Hata Meydana Geldi");
            } 
        }
        private void btnAnaMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
