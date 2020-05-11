using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase Abstracta Vehículo
    /// </summary>
    public abstract class Vehiculo
    {
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;

        /// <summary>
        /// Propiedad abstracta que en las clases derivadas retornará el tamaño correspondienete del vehículo
        /// </summary>
        protected abstract ETamanio Tamanio { get; }

        /// <summary>
        /// Constructor que asigna chasis, marca y color al vehiculo.
        /// </summary>
        /// <param name="chasis"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.color = color;
            this.marca = marca;
        }

        /// <summary>
        /// Publica todos los datos del Vehiculo en formato string
        /// </summary>
        /// <returns>devuelve los datos del vehículo</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        /// <summary>
        /// Convierte un objeto de tipo Vehículo a tipo string
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CHASIS: {0}\r\n", p.chasis);
            sb.AppendFormat("MARCA : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR : {0}\r\n", p.color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>Retorna true si los chasis son iguales.</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return v1.chasis == v2.chasis;
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>Retorna true si los chasis son distintos.</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }

        /// <summary>
        /// Enumerado de marcas disponibles para los vehículos
        /// </summary>
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda
        }

        /// <summary>
        /// Enumerado de tamaños disponibles para los vehículos
        /// </summary>
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
    }
}
