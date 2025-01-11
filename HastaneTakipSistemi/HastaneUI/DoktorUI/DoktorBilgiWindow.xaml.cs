using HastaneTakipSistemi.HastaneBLL;
using HastaneTakipSistemi.HastaneDAL;
using HastaneTakipSistemi.Helpers;
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
    /// Interaction logic for DoktorBilgiWindow.xaml
    /// </summary>
    public partial class DoktorBilgiWindow : MetroWindow
    {
        public int drIdent { get; set; }
        public string drAd { get; set; }
        public string drSoyad { get; set; }
        public string drEmail { get; set; }
        public string drDogum { get; set; }
        public string drAlan { get; set; }
        public string drIl { get; set; }
        public string drIlce { get; set; }
        public string drTel { get; set; }
        public string drCinsiyet { get; set; }
        public string drSifre { get; set; }
        public string drKlinik { get; set; }

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


        public List<KeyValuePair<string, int>> klinikList { get; set; }

        public DoktorBilgiWindow(int drId)
        {
            InitializeComponent();
            drIdent = drId;
            ComboBoxDoldur();
            GetDoktorBilgi(drIdent);
            BilgiDoldur();
            DataContext  = this;    
        }

        private async void btnGuncelle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                doktorlar dr = new doktorlar()
                {
                    dr_ad = StringHelper.FazlaBoslukSil(tbxAd.Text),
                    dr_cins = cbxCinsiyet.SelectedValue.ToString(),
                    dr_alan = cbxKlinik.SelectedValue.ToString(),
                    dr_dogum = dtpDogumTarih.SelectedDate.ToString(),
                    dr_il = StringHelper.FazlaBoslukSil(tbxIl.Text),
                    dr_ilçe = StringHelper.FazlaBoslukSil(tbxIlce.Text),
                    dr_klinik = (Int32)cbxKlinik.SelectedValue,
                    dr_sifre = tbxSifre.Text,
                    dr_soyad = StringHelper.FazlaBoslukSil(tbxSoyad.Text),
                    dr_tel = StringHelper.FazlaBoslukSil(tbxTel.Text),
                    dr_id = drIdent
                };
                DoktorBLL.UpdateDoktorBilgiBLL(dr);
                await this.ShowMessageAsync("Kayıt İşlemi Tamamlandı", "");
            }
            catch (Exception)
            {
                await this.ShowMessageAsync("İşlemde Hata", "Bilgi Güncelleme Esnasında Hata Meydana Geldi"); 
            }
        }
        private void btnAnaMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();   
        }
        public void ComboBoxDoldur()
        {
            cbxCinsiyet.Items.Add("Erkek");
            cbxCinsiyet.Items.Add("Kız");

            klinikList = new List<KeyValuePair<string, int>>() {
                                                                new KeyValuePair<string, int>("Üroloji", 1),
                                                                new KeyValuePair<string, int>("Göz", 2),
                                                                new KeyValuePair<string, int>("Dahiliye", 3),
                                                                new KeyValuePair<string, int>("Cildiye", 4),
                                                                new KeyValuePair<string, int>("KBB", 5),
                                                                new KeyValuePair<string, int>("İntaniye", 6),
                                                                new KeyValuePair<string, int>("Radyoloji", 7),
                                                                };

            cbxKlinik.ItemsSource = klinikList;
        }

        
        public async void GetDoktorBilgi(int drIdent)
        {
            try
            {
                SelectedDoktor = DoktorBLL.GetDoktorBilgiBLL(drIdent);

            }
            catch (Exception)
            {
                await this.ShowMessageAsync("İşlemde Hata", "Bilgi Getirme Esnasında Hata Meydana Geldi"); 
            }
            
        }
        public void BilgiDoldur()
        {
            foreach(var Item in SelectedDoktor)
            {
                tbxAd.Text = Item.dr_ad;
                tbxIl.Text = Item.dr_il;
                tbxIlce.Text = Item.dr_ilçe;
                tbxSifre.Text = Item.dr_sifre;  
                tbxSoyad.Text = Item.dr_soyad;
                tbxTCKimlikNo.Text = Item.dr_tc;
                tbxTel.Text = Item.dr_tel;  
                dtpDogumTarih.SelectedDate = Convert.ToDateTime(Item.dr_dogum);
                cbxCinsiyet.SelectedItem = Item.dr_cins;
                cbxKlinik.SelectedValue = Convert.ToInt32(Item.dr_klinik);    
            }
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
