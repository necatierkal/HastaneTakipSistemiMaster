using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HastaneTakipSistemi
{
    /// <summary>
    /// App.xaml etkileşim mantığı
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Bilinmeyen hata oluştu: " 
                + e.Exception.Message, "Exception Sample", 
                MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;

        }
    }

}
