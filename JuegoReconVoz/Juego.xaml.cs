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
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;
using System.Collections;


namespace JuegoReconVoz
{
    /// <summary>
    /// Lógica de interacción para Juego.xaml
    /// </summary>
    public partial class Juego : Window
    {

        private void btnMini_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void bntRegresar_Click(object sender, RoutedEventArgs e)
        {
            Publicas.princ.Visibility = System.Windows.Visibility.Visible;
            this.Close();
        }

        // Variables Globales
        ArrayList arrayList;
        string[] imagenes;
        int totalImg = 0, intento = 0, Aleatorio;
        string rutaN, rutaC;

        // Escuchar 
        private SpeechRecognitionEngine recVoz = new SpeechRecognitionEngine();
        // Objeto que permitira la reproducción del nombre de la imagen seleccionada
        private SpeechSynthesizer leerNom = new SpeechSynthesizer();
        List<VoiceInfo> vozInfo = new List<VoiceInfo>();

        //Constructor y llenado de arreglos que contienen las imagenes
        public Juego()
        {
            InitializeComponent();
            //Agrega las voces disponibles en el Narrador de Windows
            //Para Windows 7 los disponibles son "Microsoft Anna" (Ingles) y Ximena(Español)
            //Para Windows 8 los disponibles son "Microsoft Helena Desktop" (Español) y "Microsoft Xira Desktop" (Ingles)
            foreach (InstalledVoice voice in leerNom.GetInstalledVoices())
            {
                vozInfo.Add(voice.VoiceInfo);
                cbVoz.Items.Add(voice.VoiceInfo.Name);
            }
            //Llenado de arreglo con las imagenes disponibles en carpetas
            if (Publicas.Leer == "n")
                lblNombImg.Visibility = System.Windows.Visibility.Hidden;
            else
                lblNombImg.Visibility = System.Windows.Visibility.Visible;
            lblNombImg.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;

            if (Publicas.Nivel == "Princ")
                rutaN = "FPrincipiante";
            else
                rutaN = "Avanzado";

            switch (Publicas.Categoria)
            {
                case "numeros":
                    rutaC = rutaN + "/Numeros";
                    break;

                case "Animales":
                    rutaC = rutaN + "/Animales";
                    break;

                case "Objetos":
                    rutaC = rutaN + "/Objetos";
                    break;

                case "FyV":
                    rutaC = rutaN + "/FyV";
                    break;

                case "Colores":
                    rutaC = rutaN + "/Colores";
                    break;
            }

            imagenes = Directory.GetFiles(("../../Images/" + rutaC + ""), "*.png");

            totalImg = imagenes.Length;

            arrayList = new ArrayList(totalImg);
            //Llenado de arreglo con imagenes 
            for (int z = 0; z < totalImg; z++)
            {
                arrayList.Add(imagenes[z]);
            }
            //Muestra una imagen al azar basandose en el número total de imagenes en carpeta
            Aleatorio = new Random().Next(0, arrayList.Count);
            BitmapImage bitImg = new BitmapImage();
            bitImg.BeginInit();
            bitImg.UriSource = new Uri((arrayList[Aleatorio].ToString()), UriKind.Relative);
            bitImg.EndInit();
            imgMuest.Source = bitImg;
            lblNombImg.Content = System.IO.Path.GetFileNameWithoutExtension(arrayList[Aleatorio].ToString());
        }

        private void btnRec_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                recVoz.SetInputToDefaultAudioDevice();//Selecciona por defecto el dispositivo de entrada
                recVoz.LoadGrammar(new DictationGrammar());//Genera una instancia de datagrama que almacenara las palabras recibidas
                recVoz.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recVoz_SpeechRecognized);//Crea el manejador de eventos para el reconocimiento de voz
                recVoz.RecognizeAsync(RecognizeMode.Multiple);//Permite el reconocimiento de voz multiple
            }
            //Bloque de atrapamiento de errores y muestra de mensajes
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Método utilizado para comparación entre la voz que recibe y el nombre del archivo, se muestra un mensaje correspondiente y se cambia a hacia la siguiente imagen
        void recVoz_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            foreach (RecognizedWordUnit word in e.Result.Words)
            {                
           if (word.Confidence>08f)
           {
               try
               {
                   if (word.Text == System.IO.Path.GetFileNameWithoutExtension((arrayList[Aleatorio]).ToString()))
                   // Comparacion entre el texto recibido y el nombre de la imagen sin extension
                   {
                       //recVoz.RecognizeAsyncStop();
                       //Si ambos son iguales se despliega una pantalla con un mensaje de aprobación

                       //En cada iteración se va eliminado el indice de cada imagen para no repetir
                       arrayList.RemoveAt(Aleatorio);
                       //Si el arrayList que contiene las imagenes llega a cero el formulario se cierra
                       if (arrayList.Count == 0)
                       {

                           Window1 fin = new Window1();
                           fin.Show();
                           //Categoria cat = new Categoria();
                           //cat.Show();
                           recVoz.RecognizeAsyncStop();
                           this.Close();    
                       }
                       else
                       {
                           Correcto Bien = new Correcto();
                           Bien.Show();
                           Aleatorio = new Random().Next(0, arrayList.Count);
                           BitmapImage bitImg = new BitmapImage();
                           bitImg.BeginInit();                                                             //De lo contrario       
                           bitImg.UriSource = new Uri((arrayList[Aleatorio].ToString()), UriKind.Relative);//Se procede a la siguiente imagen
                           bitImg.EndInit();
                           imgMuest.Source = bitImg;
                           lblNombImg.Content = System.IO.Path.GetFileNameWithoutExtension(arrayList[Aleatorio].ToString());//Se asigna nombre de imagen en etiqueta
                       }
                       intento = 0;
                   }
                   else
                   {
                       //Si ambos no son iguales se despliega una pantalla con un mensaje de desaprobación y se procede a la siguiente imagen
                       //recVoz.RecognizeAsyncStop();
                       intento++;
                       //Si se cuentan 3 intentos, entonces la imagen se descarta
                       if (intento == 3)
                       {
                           arrayList.RemoveAt(Aleatorio);
                           if (arrayList.Count == 0)
                           {
                               Window1 fin = new Window1();
                               fin.Show();
                               //Categoria cat = new Categoria();
                               //cat.Show();
                               recVoz.RecognizeAsyncStop();
                               //this.Close();
                           }
                           else
                           {
                               Incorrecto Mal = new Incorrecto();
                               Mal.ShowDialog();
                               //Se procede a la siguiente imagen
                               Aleatorio = new Random().Next(0, arrayList.Count);
                               BitmapImage bitImg = new BitmapImage();
                               bitImg.BeginInit();
                               bitImg.UriSource = new Uri((arrayList[Aleatorio].ToString()), UriKind.Relative);
                               bitImg.EndInit();
                               imgMuest.Source = bitImg;
                               lblNombImg.Content = System.IO.Path.GetFileNameWithoutExtension(arrayList[Aleatorio].ToString());
                               intento = 0;
                           }
                       }
                       else
                       {
                           //Si ambos no son iguales se despliega una pantalla con un mensaje de desaprobación y se procede a la siguiente imagen
                           Incorrecto Mal = new Incorrecto();
                           Mal.ShowDialog();
                       }
                   }
               }
               //Bloque de atrapamiento de errores y muestra de mensajes
               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message);
                   return;
               }
           }
                
         }            
      }
        //Método utilizado para repetir el nombre de la imagen mostrada
        private void btnRep_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int indice;
                indice = cbVoz.SelectedIndex;
                //string nombre = vozInfo.ElementAt(indice).Name;

                leerNom.SelectVoice("Microsoft Helena Desktop");
                leerNom.Speak(System.IO.Path.GetFileNameWithoutExtension(arrayList[Aleatorio].ToString()));
            }
            //Bloque de atrapamiento de errores y mostrado de mensaje 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}