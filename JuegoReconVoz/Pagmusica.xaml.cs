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
    /// Interaction logic for Pagmusica.xaml
    /// </summary>
    public partial class Pagmusica : Window
    {
       
        public static MediaElement player2 = new MediaElement();
        public Pagmusica()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            if (Publicas.volumen == true)
            {
                player2.UnloadedBehavior = MediaState.Manual;
                player2.LoadedBehavior = MediaState.Manual;
                player2.Source = new Uri("Doraemon1.wav", UriKind.Relative);
                player2.MediaEnded += new RoutedEventHandler(player2_MediaEnded);                
                player2.Play();
            }
            this.WindowState = System.Windows.WindowState.Minimized;
        }
     

        void player2_MediaEnded(object sender, RoutedEventArgs e)
        {
            player2.Position = TimeSpan.FromSeconds(0);
            player2.Play();
        }

        void player2_Stop(object sender, RoutedEventArgs e)
        {
            player2.Stop();
        }
        
    }
}
