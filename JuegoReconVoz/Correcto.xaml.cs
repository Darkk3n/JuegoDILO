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
using System.Windows.Threading;

namespace JuegoReconVoz
{
    /// <summary>
    /// Lógica de interacción para Correcto.xaml
    /// </summary>
    public partial class Correcto : Window
    {
        MediaElement player = new MediaElement();
        public Correcto()
        {
            //Inicializa un objeto timer
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Start();
            timer.Tick += new EventHandler(timer_Tick);

        }

        //Tras pasar 2 segundos el formulario se cierra
        void timer_Tick(object sender, EventArgs e)
        {           
            this.Close();
        }
       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            if (Publicas.volsonido == true)
            {
                player.UnloadedBehavior = MediaState.Manual;
                player.LoadedBehavior = MediaState.Manual;
                player.Source = new Uri("correcto.wav", UriKind.Relative);
                player.Play();
            }
        }
    }
}
