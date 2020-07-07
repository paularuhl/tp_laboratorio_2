using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        public Correo()
        {
            this.Paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }

        public void FinEntregas()
        {
            foreach(Thread t in this.mockPaquetes)
            {
                t.Abort();
            }
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Paquete p in ((Correo)elementos).Paquetes)
            {
                sb.AppendLine($"{p} {p.Estado}");
            }
            return sb.ToString();
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            if (c != null && p != null)
            {
                foreach (Paquete paq in c.Paquetes)
                {
                    if (p == paq)
                    {
                        throw new TrackingIdRepetidoException($"El Tracking ID {p.TrackingID} ya figura en la lista de envios.");
                    }
                }

                Thread hiloParaMock = new Thread(p.MockCicloDeVida);
                c.Paquetes.Add(p);
                c.mockPaquetes.Add(hiloParaMock);
                hiloParaMock.Start();
            }

            return c;
        }
    }

}
