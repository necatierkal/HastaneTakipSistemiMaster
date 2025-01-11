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
using HastaneTakipSistemi.HastaneBLL;
using HastaneTakipSistemi.HastaneDAL;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace HastaneTakipSistemi.HastaneUI
{
    /// <summary>
    /// HastaBilgileriGuncelleWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class HastaBilgileriGuncelleWindow : MetroWindow
    {
        public int hastaIdent { get; set; }
        public string hastaTC { get; set; }
        public string hastaAd { get; set; }
        public string hastaSoyad { get; set; }
        public string hastaDogum { get; set; }
        public string hastaIl { get; set; }
        public string hastaIlce { get; set; }
        public string hastaTel { get; set; }
        public string hastaCinsiyet { get; set; }
        public string hastaSifre { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private List<hastalar> _SelectedHasta;

        public List<hastalar> SelectedHasta
        {
            get
            {
                return _SelectedHasta;
            }
            set
            {
                _SelectedHasta = value;
                OnPropertyChanged();
            }
        }


        public HastaBilgileriGuncelleWindow(int hastaId)
        {
            InitializeComponent();
            hastaIdent = hastaId;
            ComboBoxDoldur();
            GetHastaBilgi(hastaIdent);
            BilgiDoldur();
            DataContext = this;
        }

        private async void btnGuncelle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                hastalar hasta = new hastalar()
                {
                    hasta_ad = tbxAd.Text,
                    hasta_cins = cbxCinsiyet.SelectedValue.ToString(),
                    hasta_dogum = dtpDogumTarih.SelectedDate.ToString(),
                    hasta_il = tbxIl.Text,
                    hasta_ilce = tbxIlce.Text,
                    hasta_sifre = tbxSifre.Text,
                    hasta_soyad = tbxSoyad.Text,
                    hasta_tel = tbxTel.Text,
                    hasta_id = hastaIdent
                };
                HastaBLL.UpdateHastaBilgiBLL(hasta);
                await this.ShowMessageAsync("Kayıt İşlemi Tamamlandı", "");
            }
            catch (Exception)
            {
                await this.ShowMessageAsync("İşlemde Hata", "Bilgi Güncelleme Esnasında Hata Meydana Geldi");
            }
        }

        public void ComboBoxDoldur()
        {
            cbxCinsiyet.Items.Add("Erkek");
            cbxCinsiyet.Items.Add("Kız");
        }
        public async void GetHastaBilgi(int hastaIdent)
        {
            try
            {
                SelectedHasta = HastaBLL.GetHastaBilgiBLL(hastaIdent);

            }
            catch (Exception)
            {
                await this.ShowMessageAsync("İşlemde Hata", "Bilgi Getirme Esnasında Hata Meydana Geldi");
            }

        }
        public void BilgiDoldur()
        {
            foreach (var Item in SelectedHasta)
            {
                tbxAd.Text = Item.hasta_ad;
                tbxIl.Text = Item.hasta_il;
                tbxIlce.Text = Item.hasta_ilce;
                tbxSifre.Text = Item.hasta_sifre;
                tbxSoyad.Text = Item.hasta_soyad;
                tbxTCKimlikNo.Text = Item.hasta_tc;
                tbxTel.Text = Item.hasta_tel;
                dtpDogumTarih.SelectedDate = Convert.ToDateTime(Item.hasta_dogum);
                cbxCinsiyet.SelectedItem = Item.hasta_cins;
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void btnAnaMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void btnGuncelle_Click_1(object sender, RoutedEventArgs e)
        {
             try
                {
                    hastalar hasta = new hastalar()
                    {
                        hasta_ad = tbxAd.Text,
                        hasta_cins = cbxCinsiyet.SelectedValue.ToString(),
                        hasta_dogum = dtpDogumTarih.SelectedDate.ToString(),
                        hasta_il = tbxIl.Text,
                        hasta_ilce = tbxIlce.Text,
                        hasta_sifre = tbxSifre.Text,
                        hasta_soyad = tbxSoyad.Text,
                        hasta_tel = tbxTel.Text,
                        hasta_id = hastaIdent
                    };
                    HastaBLL.UpdateHastaBilgiBLL(hasta);
                    await this.ShowMessageAsync("Kayıt İşlemi Tamamlandı", "");
                }
                catch (Exception)
                {
                    await this.ShowMessageAsync("İşlemde Hata", "Bilgi Güncelleme Esnasında Hata Meydana Geldi");
                }
            
        }
    }
}
