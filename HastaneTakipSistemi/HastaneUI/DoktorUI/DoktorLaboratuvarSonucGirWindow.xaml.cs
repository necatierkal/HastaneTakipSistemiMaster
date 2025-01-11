﻿using HastaneTakipSistemi.HastaneBLL;
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
    /// Interaction logic for DoktorLaboratuvarSonucGirWindow.xaml
    /// </summary>
    public partial class DoktorLaboratuvarSonucGirWindow : MetroWindow
    {
        public string drIdent { get; set; }
        public string sonucTarih { get; set; }

        public string hastaTC { get; set; }

        public string sonuc { get; set; }
        public DoktorLaboratuvarSonucGirWindow(int drId)
        {
            InitializeComponent();
            drIdent = Convert.ToString(drId);
            DataContext = this; 
        }

        private void btnAnaMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private async void btnKaydet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sonucTarih = Convert.ToString(dtpTarih.SelectedDate);
                hastaTC = Convert.ToString(tbxHastaTC.Text);
                sonuc = Convert.ToString(tbxLaboratuvar.Text);

                DoktorBLL.DoktorLaboratuvarSonucGirBLL(sonucTarih,hastaTC,sonuc,drIdent);
                await this.ShowMessageAsync("Kayıt İşlemi Tamamlandı", "");
            }
            catch (Exception)
            {
                await this.ShowMessageAsync("İşlemde Hata", "Kayıt Esnasında Hata Meydana Geldi");
            }
        }
    }
}
