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
    /// Interaction logic for HemsireBilgiWindow.xaml
    /// </summary>
    public partial class HemsireBilgiWindow : MetroWindow
    {
        public int HemsireIdent { get; set; }
        public string hemsireAd { get; set; }
        public string hemsireSoyad { get; set; }
        public string hemsireEmail { get; set; }
        public string hemsireDogum { get; set; }
        public string hemsireAlan { get; set; }
        public string hemsireIl { get; set; }
        public string hemsireIlce { get; set; }
        public string hemsireTel { get; set; }
        public string hemsireCinsiyet { get; set; }
        public string hemsireSifre { get; set; }

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


        public List<KeyValuePair<string, int>> klinikList { get; set; }
        public HemsireBilgiWindow(int hemsireId)
        {
            InitializeComponent();
            HemsireIdent = hemsireId;
            ComboBoxDoldur();
            GetHemsireBilgi(HemsireIdent);
            BilgiDoldur();
            DataContext = this; 
        }

        public void ComboBoxDoldur()
        {
            cbxCinsiyet.Items.Add("Erkek");
            cbxCinsiyet.Items.Add("Kız");

            //klinikList = new List<KeyValuePair<string, int>>() {
            //                                                    new KeyValuePair<string, int>("Üroloji", 1),
            //                                                    new KeyValuePair<string, int>("Göz", 2),
            //                                                    new KeyValuePair<string, int>("Dahiliye", 3),
            //                                                    new KeyValuePair<string, int>("Cildiye", 4),
            //                                                    new KeyValuePair<string, int>("KBB", 5),
            //                                                    new KeyValuePair<string, int>("İntaniye", 6),
            //                                                    new KeyValuePair<string, int>("Radtoloji", 7),
            //                                                    };

            //tbKlinik.ItemsSource = klinikList;
        }
        public async void GetHemsireBilgi(int HemsireId)
        {
            try
            {
                SelectedHemsire = HemsireBLL.GetHemsireBilgiBLL(HemsireId);
            }
            catch (Exception)
            {
                await this.ShowMessageAsync("İşlemde Hata", "Bilgi Getirme Esnasında Hata Meydana Geldi");
            }

        }

        private async void btnGuncelle_Click(object sender, RoutedEventArgs e)
        {
             try
            {
                hemsireler hemsire = new hemsireler()
                {
                    hemsire_ad = tbxAd.Text,
                    hemsire_cins = cbxCinsiyet.SelectedValue.ToString(),
                    hemsire_alan = tbxAlan.Text,
                    hemsire_dogum = dtpDogumTarih.SelectedDate.ToString(),
                    hemsire_il = tbxIl.Text,
                    hemsire_ilçe = tbxIlce.Text,
                    //dr_klinik = (Int32)cbxKlinik.SelectedValue,
                    hemsire_sifre = tbxSifre.Text,
                    hemsire_soyad = tbxSoyad.Text,
                    hemsire_tel = tbxTel.Text,
                    hemsire_id = HemsireIdent
                };
                HemsireBLL.UpdateHemsireBilgiBLL(hemsire);
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

        public void BilgiDoldur()
        {
            foreach (var Item in SelectedHemsire)
            {
                tbxAd.Text = Item.hemsire_ad;
                tbxIl.Text = Item.hemsire_il;
                tbxIlce.Text = Item.hemsire_ilçe;
                tbxSifre.Text = Item.hemsire_sifre;
                tbxSoyad.Text = Item.hemsire_soyad;
                tbxTCKimlikNo.Text = Item.hemsire_tc;
                tbxTel.Text = Item.hemsire_tel;
                dtpDogumTarih.SelectedDate = Convert.ToDateTime(Item.hemsire_dogum);
                cbxCinsiyet.SelectedItem = Item.hemsire_cins;
                tbxAlan.Text = Item.hemsire_alan;
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
