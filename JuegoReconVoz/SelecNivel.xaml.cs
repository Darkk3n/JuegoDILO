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
    /// Lógica de interacción para SelecNivel.xaml
    /// </summary>
    public partial class SelecNivel : Window
    {
        
        public SelecNivel()
        {
            InitializeComponent();
        }
        //Minimiza la ventana
        private void btnMini_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }
        //Regresa al menú principal
        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Publicas.princ.Visibility=System.Windows.Visibility.Visible;
            this.Close();
            //Publicas.princ.Visibility = System.Windows.Visibility.Visible; 
        }
        //Muestra la ventana de selección de categoría en dificultad principiante
        private void btnPrincip_Click(object sender, RoutedEventArgs e)
        {
            Publicas.Nivel = "Princ";
            Categoria Cat = new Categoria();
            Cat.Show();
            this.Close();
        }
        //Muestra la ventana de selección de categoría en dificultad avanzado
        private void btnAvanz_Click(object sender, RoutedEventArgs e)
        {
            Publicas.Nivel = "Avanz";
            Categoria Cat = new Categoria();
            Cat.Show();
            this.Close();
        }

        
     

    }
}
