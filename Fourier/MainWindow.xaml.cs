using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Fourier.Logica;
using System.Windows.Media.Media3D;
using static System.Net.Mime.MediaTypeNames;

namespace Fourier
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int j = 0;
        string temp = "";
        Recursos rec;

        internal Recursos Rec
        {
            get
            {
                return rec;
            }

            set
            {
                rec = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
             
        }

        private void salida_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void bns_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

       

        private void graficar_Click(object sender, RoutedEventArgs e)
        {
            Grafica g = new Grafica();
            g.R = Rec;
            g.Activate();
            g.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            g.Visibility = Visibility.Visible;
           
        }

        private void graficarT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Form1 f = new Form1();
                f.Rec = rec;
                f.Activate();
                f.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                f.Visible = true;
            }
            catch (Exception error)
            {
                MessageBoxResult result = MessageBox.Show("Error " ,"Error" );
            }
            
        }

        private void graficardos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Form2 w = new Form2();
                w.R = rec   ;
                w.Activate();
                w.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                w.Visible = true;
            }
            catch (Exception error)
            {
                string mensaje = "Error " + error.ToString();
                MessageBoxResult result = MessageBox.Show(mensaje);
            }
        }
       
        private void escribir(object sender, KeyEventArgs e)
        {

            if (  !((carenviar.Text.Equals("") )|| (carenviar.Text.Equals(" ") ) || (carenviar.Text.Length > 1)) && !((anchodebanda.Text.Equals("") || (anchodebanda.Text.Equals(" "))) ) && !((bps.Text.Equals(""))|| (bps.Text.Equals(" "))))
            {
                graficar.IsEnabled = true;
                graficar_Todo.IsEnabled = true;
                graficardemas.IsEnabled = true;
                rec = new Recursos(carenviar.Text[0],Double.Parse(anchodebanda.Text), Double.Parse(bps.Text) );
                narmonicos.Content = rec.Narmonicos;
                dc.Content = rec.Dc;
                string mensaje = "";
                for (int i=0; i<rec.Binario.Count; i++)
                {
                    mensaje += rec.Binario[i];
                }
                binario.Content = mensaje;
                _decimal.Content = rec.Valorcaracter;
                bits.Content = rec.Numbits;
                f.Content = rec.F;
                periodo.Content = rec.F11 + " Hz";
                T.Content = rec.T1;

            }
        }

        private void anchodebanda_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ARRIBA(object sender, KeyEventArgs e)
        {
            if (!((carenviar.Text.Equals("")) || (carenviar.Text.Equals(" ")) || (carenviar.Text.Length > 1)) && !((anchodebanda.Text.Equals("") || (anchodebanda.Text.Equals(" ")))) && !((bps.Text.Equals("")) || (bps.Text.Equals(" "))))
            {
                graficar.IsEnabled = true;
                graficar_Todo.IsEnabled = true;
                graficardemas.IsEnabled = true;
                rec = new Recursos(carenviar.Text[0], Double.Parse(anchodebanda.Text), Double.Parse(bps.Text));
                narmonicos.Content = rec.Narmonicos;
                dc.Content = rec.Dc;
                string mensaje = "";
                for (int i = 0; i < rec.Binario.Count; i++)
                {
                    mensaje += rec.Binario[i];
                }
                binario.Content = mensaje;
                _decimal.Content = rec.Valorcaracter;
                bits.Content = rec.Numbits;
                f.Content = rec.F;
                periodo.Content = rec.F11 + " Hz";
                T.Content = rec.T1;

            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Este programa fue desarrollado por : \n *) Santiago Chaustre \n *) Carlos Baron \n *) Andres Cocunubo \n El principal fin de este aplicativo es ser informativo y educativo \n \n ®HellSoft S.A",
    "Mensaje importante !!!");
        }
    }
}
