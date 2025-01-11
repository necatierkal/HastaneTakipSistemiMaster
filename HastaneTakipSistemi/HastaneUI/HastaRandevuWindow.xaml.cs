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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HastaneTakipSistemi.HastaneBLL;
using HastaneTakipSistemi.HastaneDAL;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace HastaneTakipSistemi.HastaneUI
{
    /// <summary>
    /// HastaRandevuWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class HastaRandevuWindow : MetroWindow
    {
        public HastaRandevuWindow()
        {
            InitializeComponent();
        }

        public int hastaId { get; set; }
        public string hastaKimlik { get; set; }
        public string hastaTC { get; set; }
        public string hastaAdSoyad { get; set; }
        public string hastaDogumYerTar { get; set; }
        public string hastaCinsiyet { get; set; }
        public string hastaTel { get; set; }
        public string hastaOda { get; set; }
        public string hastaYatak { get; set; }
        public string sistemeGiris { get; set; }
        public string randevu_saati { get; set; }
        public string randevu_tarihi { get; set; }
        public string dr_id { get; set; }
        public string klinik_id { get; set; }
        
        public string hasta_id { get; set; }

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
                OnPropertyChanged("SelectedHasta");
            }
        }  

      

        public HastaRandevuWindow(int hastaId)
        {

            InitializeComponent();
            KlinikDoldur();
            DoktorDoldur();


            this.hastaId = hastaId;
            try
            {
                GetHastaKimlikById(hastaId);

                hastaKimlik = "Hoşgeldiniz Sayın" + " " + SelectedHasta.Select(x => x.hasta_ad).FirstOrDefault() + " "
                + SelectedHasta.Select(x => x.hasta_soyad).FirstOrDefault() + "";

                hastaTC= SelectedHasta.Select(x=>x.hasta_tc).FirstOrDefault();

                hastaAdSoyad= SelectedHasta.Select(x => x.hasta_ad).FirstOrDefault() + " "
                + SelectedHasta.Select(x => x.hasta_soyad).FirstOrDefault();

                hastaDogumYerTar = SelectedHasta.Select(x => x.hasta_dyeri).FirstOrDefault() + "/" +
                                    SelectedHasta.Select(x => x.hasta_dogum).FirstOrDefault();

                hastaCinsiyet = SelectedHasta.Select(x => x.hasta_cins).FirstOrDefault();

                hastaTel= SelectedHasta.Select(x => x.hasta_tel).FirstOrDefault();

                hastaOda= SelectedHasta.Select(x => x.hasta_oda).FirstOrDefault();

                hastaYatak= SelectedHasta.Select(x=>x.hasta_yatak).FirstOrDefault();

                string saatCek=" ";

                if(rbtRandevu1.IsChecked==true)
                    saatCek="09.00";
                else if(rbtRandevu2.IsChecked== true)
                    saatCek= "09.15";
                else if (rbtRandevu3.IsChecked == true)
                    saatCek = "09.30";
                else if (rbtRandevu4.IsChecked == true)
                    saatCek = "09.45";
                else if (rbtRandevu5.IsChecked == true)
                    saatCek = "10.00";
                else if (rbtRandevu6.IsChecked == true)
                    saatCek = "10.15";
                else if (rbtRandevu7.IsChecked == true)
                    saatCek = "10.30";
                else if (rbtRandevu8.IsChecked == true)
                    saatCek = "10.45";
                else if (rbtRandevu9.IsChecked == true)
                    saatCek = "11.00";
                else if (rbtRandevu10.IsChecked == true)
                    saatCek = "11.15";
                else if (rbtRandevu11.IsChecked == true)
                    saatCek = "11.30";
                else if (rbtRandevu12.IsChecked == true)
                    saatCek = "11.45";
                else if (rbtRandevu13.IsChecked == true)
                    saatCek = "12.00";
                else if (rbtRandevu14.IsChecked == true)
                    saatCek = "13.00";
                else if (rbtRandevu15.IsChecked == true)
                    saatCek = "13.30";
                else if (rbtRandevu16.IsChecked == true)
                    saatCek = "14.00";
                else if (rbtRandevu17.IsChecked == true)
                    saatCek = "14.15";
                else if (rbtRandevu18.IsChecked == true)
                    saatCek = "14.30";
                else if (rbtRandevu19.IsChecked == true)
                    saatCek = "14.45";
                else if (rbtRandevu20.IsChecked == true)
                    saatCek = "15.00";
                else if (rbtRandevu21.IsChecked == true)
                    saatCek = "15.15";
                else if (rbtRandevu22.IsChecked == true)
                    saatCek = "15.30";
                else if (rbtRandevu23.IsChecked == true)
                    saatCek = "16.00";
                else if (rbtRandevu24.IsChecked == true)
                    saatCek = "16.15";
                else 
                    saatCek = "16.30";

                tbxSaat.Text = saatCek;

                tbxTarih.Text = Convert.ToString(dtpRandevuTar.SelectedDate);

                //int selectedindexDoktor=cbxDoktor.SelectedIndex;

                tbxDoktor.Text = Convert.ToString(cbxDoktor.SelectedValuePath.ToString());              

                //int selectedindexKlinik = cbxKlinik.SelectedIndex;

                tbxKlinik.Text = Convert.ToString(cbxKlinik.SelectedValuePath.ToString());


            }
            catch (Exception)
            {

                throw new Exception("Hasta Bilgilerinde Hata Oluştu");
            }

            sistemeGiris = "Sisteme Giriş : " + DateTime.Now.ToString() + "";

            DataContext = this;
           


        }
        public void GetHastaKimlikById(int hastaId)
        {
            SelectedHasta = HastaBLL.GetHastaKimlikByIdBLL(hastaId).ToList();
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void btnRandevuGoster_Click(object sender, RoutedEventArgs e)
        {
            var frm = new HastaRandevuGecmisiWindow(hastaId);
            frm.ShowDialog();
        }

        private void btnBilgiGuncelle_Click(object sender, RoutedEventArgs e)
        {
            var frm = new HastaBilgileriGuncelleWindow(hastaId);
            frm.ShowDialog();
        }

        private void btnCikis_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void KlinikDoldur()
        {

            var klinikList = new List<KeyValuePair<string, int>>() {
                                                                new KeyValuePair<string, int>("Üroloji", 1),
                                                                new KeyValuePair<string, int>("Göz", 2),
                                                                new KeyValuePair<string, int>("Dahiliye", 3),
                                                                new KeyValuePair<string, int>("Cildiye", 4),
                                                                new KeyValuePair<string, int>("KBB", 5),
                                                                new KeyValuePair<string, int>("İntaniye", 6),
                                                                new KeyValuePair<string, int>("Radtoloji", 7),
                                                                };
            cbxKlinik.DataContext = klinikList; 
            cbxKlinik.ItemsSource = klinikList;
        }

        public void DoktorDoldur()
        {


            var doktorList = new List<KeyValuePair<string, int>>() {
                                 new KeyValuePair<string, int>("Dr.Raciye Tutlu", 1),
                                 new KeyValuePair<string, int>("Dr.Safiyet Gemici", 2),
                                 new KeyValuePair<string, int>("Dr.Sabahattin Coşanay", 3),
                                 new KeyValuePair<string, int>("Dr.Rümeysa Kızıldağ", 4),
                                 new KeyValuePair<string, int>("Dr.Pekal Karadoğan", 5),
                                 new KeyValuePair<string, int>("Dr.Ayanoğlu Çakan", 6),
                                 new KeyValuePair<string, int>("Dr.Berzali Özer ölmez", 7),
                                 new KeyValuePair<string, int>("Dr.Ünan Türkmen",8),
                                 new KeyValuePair<string, int>("Dr.Balamir Kölük", 9),
                                 new KeyValuePair<string, int>("Dr.Kutlar Çetinkaya keklikçi", 10),
                                 new KeyValuePair<string, int>("Dr.Ecer Hacıevliyagil", 11),
                                 new KeyValuePair<string, int>("Dr.Bengü Erkon", 12),
                                 new KeyValuePair<string, int>("Dr.Nemika Filiz", 13),
                                 new KeyValuePair<string, int>("Dr.Bayer Gözübüyük", 14),
                                 new KeyValuePair<string, int>("Dr.Yaltır Kaynarca", 15) };

            cbxDoktor.DataContext = doktorList;
            cbxDoktor.ItemsSource = doktorList;
                     

        }



        private async void btnOnayla_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                randevu_saati = tbxSaat.Text;
                randevu_tarihi = tbxTarih.Text;
                dr_id = tbxDoktor.Text;
                hasta_id = hastaId.ToString();
                klinik_id = tbxKlinik.Text;
             
                HastaBLL.HastaRandevuKaydetBLL(randevu_saati,randevu_tarihi,dr_id,hasta_id,klinik_id);
                await this.ShowMessageAsync("Kayıt İşlemi Tamamlandı", "");
            }
            catch (Exception)
            {
                await this.ShowMessageAsync("İşlemde Hata", "Bilgi Güncelleme Esnasında Hata Meydana Geldi");
            }
        }


        public double HastaYatisUcreti(int yatilanGun, int gunlukYatakUcreti)
        {
           return yatilanGun * gunlukYatakUcreti;
        }

        public double HastaMuayeneUcreti(double doktorUcreti, double vergi)
        {
           return doktorUcreti + vergi;
        }

        public double UcretIndirimi(double toplamUcret, double vergiIndirimi)
        {
            return toplamUcret - vergiIndirimi;
        }

        public bool UcretOdendiMi(int odendi)
        {
            if (odendi==1)
                return true;
            else 
                return false;
        }

        public bool BasarisizGiris(int validGiris)
        {
            if (validGiris == 1)
                return true;
            else
                return false;
        }

        public string BoslukDegistir(string input)
        {
            return input;
        }

        public string Doktor(string firstString)
        {
            return firstString;
            
        }

    }
}

    

