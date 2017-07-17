using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fourier.Logica
{
    class Armonico
    {
        private double an;
        private double bn;
        private double cn;
        private double theta;
        private int armonico;
        private List<double> gt;
        public double An
        {
            get
            {
                return an;
            }

            set
            {
                an = value;
            }
        }

        public double Bn
        {
            get
            {
                return bn;
            }

            set
            {
                bn = value;
            }
        }

        public double Cn
        {
            get
            {
                return cn;
            }

            set
            {
                cn = value;
            }
        }

        public double Theta
        {
            get
            {
                return theta;
            }

            set
            {
                theta = value;
            }
        }

        public int nArmonico
        {
            get
            {
                return armonico;
            }

            set
            {
                armonico = value;
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

        public Armonico (int armonico , List<int> numero , double nt, double f)
        {
            gt = new List<double>();
            this.armonico = armonico;
            calcularAn(numero);
            calcularBn(numero);
            calcularCn();
            calcularTetha();
            calcularGt(nt, f);

        }
        private void calcularAn(List<int> numero)
        {
            double val = 0;
            double temp1 = 0;
            int z = 4;
            if(numero.Count > 8)
            {
                z = 8;
            }
            for (int i= 0; i < numero.Count; i++)
                {
                if (numero[i] == 1)
                {
                    temp1 = (Math.Cos((Math.PI * armonico * (i + 2)) / z))*-1 + Math.Cos((Math.PI * armonico * (i + 1)) / z);
                    val += temp1;
                }
            }
            val *= 1 / (Math.PI * armonico);
            an = val ;
            
        }
        private void calcularBn(List<int> numero)
        {
            double val = 0;
            double temp1 = 0;
            int z = 4;
            if (numero.Count > 8)
            {
                z = 8;
            }
            for (int i = 0; i < numero.Count; i++)
            {
                if (numero[i] == 1)
                {
                    temp1 = Math.Sin((Math.PI * armonico * (i + 2)) / z) - Math.Sin((Math.PI * armonico * (i  + 1)) / z);
                    val += temp1;
                }
            }
            val *= (1 / (Math.PI * armonico));
            bn = val ;
        }
        private void calcularCn()
        {
           cn= Math.Sqrt((an * an) + (bn * bn));
        }
        private void calcularTetha()
        {
            theta = Math.Atan2(bn, an);
        }
        private void calcularGt(double t , double f)
        {
           
            for(double k = 0; k<=t; k += 0.01)
            {
                double b = (2 * Math.PI) * armonico * ((double)((double)1/(double)7)) * k + theta ;
                double d = (cn * (Math.Sin(b) ) );
                gt.Add(d);
            }
            }
        }
    }

