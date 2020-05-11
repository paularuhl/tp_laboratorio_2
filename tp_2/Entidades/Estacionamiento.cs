using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public class Estacionamiento
    {
        /// <summary>
        /// Atributo que contendrá a la lista de vehículos del estacionamiento.
        /// </summary>
        List<Vehiculo> vehiculos;
        /// <summary>
        /// Atributo que indicará el espacio disponible en el estacionamiento.
        /// </summary>
        int espacioDisponible;

        /// <summary>
        /// Enumerado de tipos posibles de automóvil.
        /// </summary>
        public enum ETipo
        {
            Moto, Automovil, Camioneta, Todos
        }

        #region "Constructores"
        /// <summary>
        /// Constructor privado que inicializa la lista de vehículos
        /// </summary>
        private Estacionamiento()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        /// <summary>
        /// Constructor público que inicializa espacio disponible con el pasado por parametro y luego llama al constructor 
        /// privado sin parametros.
        /// </summary>
        /// <param name="espacioDisponible"></param>
        public Estacionamiento(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Override de ToString, que devuelve los datos del estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Estacionamiento.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Estacionamiento c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c.vehiculos.Count, c.espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in c.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.Camioneta:
                        if (v is Camioneta) sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Moto:
                        if (v is Moto) sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Automovil:
                        if (v is Automovil) sb.AppendLine(v.Mostrar());
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista verificand si ya existe en ella y si hay espacio para hacerlo
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Estacionamiento operator +(Estacionamiento c, Vehiculo p)
        {
            if (c.vehiculos.Count < c.espacioDisponible)
            {
                foreach (Vehiculo v in c.vehiculos)
                {
                    if (v == p)
                        return c;
                }

                c.vehiculos.Add(p);
            }
            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista, verificando que esté en ella.
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Estacionamiento operator -(Estacionamiento c, Vehiculo p)
        {
            foreach (Vehiculo v in c.vehiculos)
            {
                if (v == p)
                {
                    c.vehiculos.Remove(v);
                    break;
                }
            }
            return c;
        }
        #endregion
    }
}
