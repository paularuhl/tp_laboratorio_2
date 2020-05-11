using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    /// <summary>
    /// Clase Automóvil, derivada de Vehículo
    /// </summary>
    public class Automovil : Vehiculo
    {
        /// <summary>
        /// Enumerado de tipos posibles de Automovil
        /// </summary>
        public enum ETipo { Monovolumen, Sedan }
        /// <summary>
        /// Atributo que indica el tipo de automovil del objeto.
        /// </summary>
        ETipo tipo;

        /// <summary>
        /// Constructor publico de Automovil, donde no recibe un Tipo. Por defecto, TIPO será Monovolumen.
        /// Llama a una sobrecarga del constructor que sí recibe parametro Tipo.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color)
            : this(marca, chasis, color, ETipo.Monovolumen)
        {
        }

        /// <summary>
        ///  Constructor publico de Automovil, donde se asigna el tipo y se llama al constructor de la clase base
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Propiedad que retorna el tamaño de las camionetas,
        /// Los automoviles son medianos
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

         /// <summary>
        /// Publica todos los datos del automóvil en formato string
        /// </summary>
        /// <returns>Datos del automóvil</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
