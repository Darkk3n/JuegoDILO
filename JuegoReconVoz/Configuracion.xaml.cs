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
using System.Windows.Shapes;

namespace JuegoReconVoz
{
    /// <summary>
    /// Lógica de interacción para Configuracion.xaml
    /// </summary>
    public partial class Configuracion : Window
    {
        public Configuracion()
        {
            InitializeComponent();            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.chkCheckMel == true) 
            {
                if (Publicas.volumen == true)
                {
                    Publicas.volumen = true;
                    //MessageBox.Show(chkMelodia.Content.ToString());
                    chkOffMelodia.Visibility = System.Windows.Visibility.Collapsed;
                    chkMelodia.IsChecked = Properties.Settings.Default.chkCheckMel;
                    chkMelodia.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    chkMelodia.Visibility = System.Windows.Visibility.Collapsed;
                    chkOffMelodia.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else
            {
                Publicas.volumen = true;
                chkMelodia.Visibility = System.Windows.Visibility.Collapsed;
                chkOffMelodia.IsChecked = Properties.Settings.Default.chkCheckMel;
                chkOffMelodia.Visibility = System.Windows.Visibility.Visible;
            }

            if (Properties.Settings.Default.chkCheckSon == true)
            {
                if (Publicas.volsonido == true)
                {
                    Publicas.volsonido = true;
                    chkOffSonido.Visibility = System.Windows.Visibility.Collapsed;
                    chkSonido.IsChecked = Properties.Settings.Default.chkCheckSon;
                    chkSonido.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    chkOffSonido.Visibility = System.Windows.Visibility.Visible;
                    chkSonido.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
            else
            {
                Publicas.volsonido = false;
                chkSonido.Visibility = System.Windows.Visibility.Collapsed;
                chkOffSonido.IsChecked = Properties.Settings.Default.chkCheckSon;
                chkOffSonido.Visibility = System.Windows.Visibility.Visible;

            }
        }

        //Activa o desactiva la melodía de fondo
        private void chkMelodia_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void chkMelodia_Unchecked(object sender, RoutedEventArgs e)
        {
            Publicas.volumen = false;
            Properties.Settings.Default.chkCheckMel = false;
            chkMelodia.Visibility = System.Windows.Visibility.Collapsed;
            chkOffMelodia.Visibility = System.Windows.Visibility.Visible;
            chkOffMelodia.IsChecked = Properties.Settings.Default.chkCheckMel;
            Pagmusica.player2.Stop();         
        }

        private void chkOffMelodia_Checked(object sender, RoutedEventArgs e)
        {
            chkOffMelodia.Visibility = System.Windows.Visibility.Collapsed;
            chkMelodia.Visibility = System.Windows.Visibility.Visible;
            Properties.Settings.Default.chkCheckMel = true;
            chkMelodia.IsChecked = Properties.Settings.Default.chkCheckMel;
            Publicas.volumen = true;
            Pagmusica.player2.Play();  
            //MessageBox.Show(chkMelodia.Content.ToString());
            //Publicas.volumen = false;
        }

        //Activa o desactiva los sonidos

        private void chkSonido_Checked(object sender, RoutedEventArgs e)
        {
            //chkSonido.Visibility = System.Windows.Visibility.Collapsed;
            //chkOffSonido.Visibility = System.Windows.Visibility.Visible;
            //Publicas.volsonido = true;


        }

        private void chkSonido_Unchecked(object sender, RoutedEventArgs e)
        {
            Publicas.volsonido = false;
            Properties.Settings.Default.chkCheckSon = false;
            chkSonido.Visibility = System.Windows.Visibility.Collapsed;
            chkOffSonido.Visibility = System.Windows.Visibility.Visible;
            chkOffSonido.IsChecked = Properties.Settings.Default.chkCheckSon;
            //Correcto.player.Stop();
            //Incorrecto.player.Stop();
        }
        
        private void chkOffSonido_Checked(object sender, RoutedEventArgs e)
        {
            chkOffSonido.Visibility = System.Windows.Visibility.Collapsed;
            chkSonido.Visibility = System.Windows.Visibility.Visible;
            Properties.Settings.Default.chkCheckSon = true;
            chkSonido.IsChecked = Properties.Settings.Default.chkCheckSon;
            Publicas.volsonido = true;
            //Correcto.player.Play();
            //Incorrecto.player.Play();
        }

        private void btnMini_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow pPrincip = new MainWindow();
            pPrincip.Show();
            this.Close();
        }

        private void btnPerso_Click(object sender, RoutedEventArgs e)
        {
            Personalizar pantPerso = new Personalizar();
            pantPerso.Show();
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        

    }
}
