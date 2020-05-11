using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase Moto, derivada de Vehículo
    /// </summary>
    public class Moto : Vehiculo
    {
        /// <summary>
        /// Constructor publico de Moto, que llama al constructor de la clase base Vehiculo.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Moto(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }

        /// <summary>
        /// Propiedad que retorna el tamaño de las motos,
        /// Las motos son chicas
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        /// <summary>
        /// Publica todos los datos de la moto en formato string
        /// </summary>
        /// <returns>datos de la moto</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
