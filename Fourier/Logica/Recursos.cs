using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Fourier.Logica
{
    class Recursos
    {
        private char letra;
        private List<int> binario;  
        private double anchodebanda;
        private double bps;
        private double T;
        private double f;
        private double t;
        private double n;
        private double F1;
        private int numbits;
        private int narmonicos;
        private double dc;
        private List<Armonico> armonicos;
        private List<double> gt;
        private int valorcaracter;

        public char Letra
        {
            get
            {
                return Letra1;
            }

            set
            {
                Letra1 = value;
            }
        }

        public List<int> Binario
        {
            get
            {
                return binario;
            }

            set
            {
                binario = value;
            }
        }

        public double Anchodebanda
        {
            get
            {
                return anchodebanda;
            }

            set
            {
                anchodebanda = value;
            }
        }

        public double Bps
        {
            get
            {
                return bps;
            }

            set
            {
                bps = value;
            }
        }

        public double T1
        {
            get
            {
                return T;
            }

            set
            {
                T = value;
            }
        }

        public double F
        {
            get
            {
                return f;
            }

            set
            {
                f = value;
            }
        }

        public double N
        {
            get
            {
                return n;
            }

            set
            {
                n = value;
            }
        }

        public double F11
        {
            get
            {
                return F1;
            }

            set
            {
                F1 = value;
            }
        }

        public int Narmonicos
        {
            get
            {
                return narmonicos;
            }

            set
            {
                narmonicos = value;
            }
        }

        public double Dc
        {
            get
            {
                return dc;
            }

            set
            {
                dc = value;
            }
        }

        public List<Armonico> Armonicos
        {
            get
            {
                return armonicos;
            }

            set
            {
                armonicos = value;
            }
        }

        public double T2
        {
            get
            {
                return t;
            }

            set
            {
                t = value;
            }
        }

        public int Numbits
        {
            get
            {
                return Numbits1;
            }

            set
            {
                Numbits1 = value;
            }
        }

        public List<double> Gt
        {
            get
            {
                return gt;
            }

            set
            {
                gt = value;
            }
        }

        public int Numbits1
        {
            get
            {
                return numbits;
            }

            set
            {
                numbits = value;
            }
        }

        public char Letra1
        {
            get
            {
                return letra;
            }

            set
            {
                letra = value;
            }
        }

        public int Valorcaracter
        {
            get
            {
                return valorcaracter;
            }

            set
            {
                valorcaracter = value;
            }
        }

        public Recursos(char caracter, double anchodebanda, double bps)
        {
            this.Numbits1 = 0;
            Binario = new List<int>();
            llenarbin(caracter);
            t = Numbits1;
            armonicos = new List<Armonico>();
            Gt = new List<double>();
            this.Anchodebanda = anchodebanda;
            this.Letra = caracter;
            this.f = 1 / (double) Numbits1;
            
            this.bps = bps;
            T = Numbits1 / bps;
            F1 = 1 / T;
            narmonicos = (int)(( anchodebanda * 1000 )/F1) ;
            
            llenarArmonicos();
            sumagt();
           /* escribirarch();*/
        }
        private void llenarbin(char caracter)
        {
            string str = Char.ToString(caracter);
            System.Text.Encoding ascii = Encoding.GetEncoding("DOS-862");

            byte[] pass_byte = ascii.GetBytes(str);
  
            
            double j = 0;
            int cartemp = (int) pass_byte[0];
            valorcaracter = cartemp;


            while (cartemp > 0)
            {
                if (cartemp % 2 == 0)
                {
                    Binario.Insert(0, 0);
                }
                else
                {
                    Binario.Insert(0, 1);
                    j++;
                }
                cartemp = (int)cartemp / 2;
            }
            if (Binario.Count <= 8)
            {
                Numbits1 = 8;
                for (int i = Binario.Count; i < 8; i++)
                {
                    Binario.Insert(0, 0);
                }
            }else
            {
                Numbits1 = 16;
                for (int i = Binario.Count; i <16 ; i++)
                {
                    Binario.Insert(0, 0);
                }
            }
            
            Dc = (double) (((Double)(j / Numbits1) )*2 );

        }
         private void llenarArmonicos()
        {
            for (int i=0; i<narmonicos;i++)
            {
                
                armonicos.Add(new Armonico(i+1, binario , t , f));
            }
        }
        private void sumagt()
        {
            double temp = 0;
            int tam = armonicos[0].Gt.Count;
            for(int j=0; j<tam; j++)
            {
                temp = 0;
                for (int k=0; k<narmonicos;k++)
                {
                    
                    temp += armonicos[k].Gt[j];
                }
               
                Gt.Add(temp);
            }
        }
        private void escribirarch()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\Users\\SANTI\\Documents\\PRUEBA\\test.txt");
            for (int w=0; w < Gt.Count; w++)
            {
                file.WriteLine(Gt[w]);
            }
            file.Close();
        }
    }   
}
