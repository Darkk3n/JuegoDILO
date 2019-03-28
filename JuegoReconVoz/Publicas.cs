using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace JuegoReconVoz
{
    static class Publicas
    {
        private static string dificulti="";
        private static string niv = "";
        private static string cat = "";
        private static bool vol = true;
        private static bool son= true;

        public static MainWindow princ = new MainWindow();
        public static Pagmusica mus = new Pagmusica();        
        public static Juego pantallaJuego; //= new Juego();         

        public static string Leer
        {
            get { return dificulti; }
            set { dificulti = value; }
        }
        public static string Nivel
        {
            get { return niv; }
            set { niv = value; }
        }
        public static string Categoria
        {
            get { return cat; }
            set { cat = value; }
        }

        public static bool volumen
        {
            get { return vol; }
            set { vol = value; }
        }

        public static bool volsonido
        {
            get { return son; }
            set { son = value; }
        }

  
        }
    }


