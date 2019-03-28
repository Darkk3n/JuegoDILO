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
    /// Lógica de interacción para Personalizar.xaml
    /// </summary>
    public partial class Personalizar : Window
    {
        public Personalizar()
        {
            InitializeComponent();
        }
        //Métodos de personalización que
        //En pantalla de juego mostrara una etiqueta
        //Con el nombre de la imagen que se esta mostrando
        private void btnSi_Click(object sender, RoutedEventArgs e)
        {
            Publicas.Leer = "s";
            Configuracion opc = new Configuracion();
            opc.Show();
            this.Close();

        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            Publicas.Leer = "n";
            Configuracion opc = new Configuracion();
            opc.Show();
            this.Close();
        }
        
       

      
    }
}
