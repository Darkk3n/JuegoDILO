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
    /// Lógica de interacción para Categoria.xaml
    /// </summary>

    public partial class Categoria : Window
    {
        public Categoria()
        {
            InitializeComponent();
        }

        private void btnMini_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }
        //Regresa a la selección de nivel
        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            SelecNivel Nivel = new SelecNivel();
            Nivel.Show();
            this.Close();
        }
        //Inicia el juego
        private void btnNumeros_Click_1(object sender, RoutedEventArgs e)
        {
            Publicas.Categoria = "numeros";
            Publicas.pantallaJuego = new Juego();
            Publicas.pantallaJuego.Show();
            //Juego pantallaJuego = new Juego();
            //pantallaJuego.Show();
            this.Close();
        }

        private void btnAnimales_Click_1(object sender, RoutedEventArgs e)
        {
            Publicas.Categoria = "Animales";
            Publicas.pantallaJuego = new Juego();
            Publicas.pantallaJuego.Show();
            //Juego pantallaJuego = new Juego();
            //pantallaJuego.Show();
            this.Close();
        }

        private void btnColores_Click(object sender, RoutedEventArgs e)
        {
            Publicas.Categoria = "Colores";
            Publicas.pantallaJuego = new Juego();
            Publicas.pantallaJuego.Show();
            //Juego pantallaJuego = new Juego();
            //pantallaJuego.Show();
            this.Close();
        }

        private void btnFyV_Click_1(object sender, RoutedEventArgs e)
        {
            Publicas.Categoria = "FyV";
            Publicas.pantallaJuego = new Juego();
            Publicas.pantallaJuego.Show();
            //Juego pantallaJuego = new Juego();
            //pantallaJuego.Show();
            this.Close();
        }

        private void btnObjetos_Click_1(object sender, RoutedEventArgs e)
        {
            Publicas.Categoria = "Objetos";
            Publicas.pantallaJuego = new Juego();
            Publicas.pantallaJuego.Show();
            //Juego pantallaJuego = new Juego();
            //pantallaJuego.Show();
            this.Close();
        }

 
    }
}
