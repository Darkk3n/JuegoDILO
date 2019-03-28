using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Management;


namespace JuegoReconVoz
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        //Minimiza la ventana
        private void btnMini_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }
        //Cierra la aplicación
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }
        //Ingresa a la pantalla de selección de dificultad
        private void btnJugar_Click(object sender, RoutedEventArgs e)
        {
            SelecNivel ventanaNivel = new SelecNivel();
            ventanaNivel.Show();
            this.Visibility = System.Windows.Visibility.Hidden;
        }
        //Abre la ventana de opciones
        private void btnOpc_Click(object sender, RoutedEventArgs e)
        {
            Configuracion ventanaConfig = new Configuracion();
            ventanaConfig.Show();
            this.Visibility = System.Windows.Visibility.Hidden;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.chkCheckMel = true;
            Properties.Settings.Default.chkCheckSon = true;
            //Publicas.mus.Show();
            //Publicas.mus.Visibility = System.Windows.Visibility.Hidden;
            //MessageBox.Show(GetOSFriendlyName());
        }
        public static string GetOSFriendlyName()
        {
            string result = string.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
            foreach (ManagementObject os in searcher.Get())
            {
                result = os["Caption"].ToString();
                break;
            }
            return result;
        }

    }
}
