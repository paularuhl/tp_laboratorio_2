using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    /// <summary>
    /// Clase pública y abstracta Universitario, hereda de persona.
    /// </summary>
    public abstract class Universitario : Persona
    {
        #region atributos
        /// <summary>
        /// Atributo legajo.
        /// </summary>
        private int legajo;
        #endregion

        #region propiedades
        /// <summary>
        /// Propiedad que da acceso al serializador XML a Legajo.
        /// </summary>
        public int Legajo
        {
            get
            {
                return this.legajo;
            }
            set
            {
                this.legajo = value;
            }
        }
        #endregion

        #region constructores
        /// <summary>
        /// Constructor por defecto que nos permite serializar y deserializar objetos de este tipo.
        /// </summary>
        public Universitario() { }

        /// <summary>
        /// Constructor de clase universitario que inicializa el atributo 
        /// legajo y llama al constructor de la clase base
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad)
            : base (nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Metodo abstracto que deberá ser implementado en las clases derivadas.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Retornará todos los datos del universitario y su clase base Persona.
        /// </summary>
        /// <returns>Datos en tipo string. </returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendFormat("\nLEGAJO NÚMERO: {0}\n", this.legajo);
            return sb.ToString();
        }
        #endregion

        #region operadores
        /// <summary>
        /// Dos Universitario serán iguales si y solo si son del mismo tipo y su legajo o dni son iguales.
        /// </summary>
        /// <param name="pg1">Universitario a comparar</param>
        /// <param name="pg2">Universitario a comparar</param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.GetType() == pg2.GetType() && (pg1.legajo == pg2.legajo || pg1.Dni == pg2.Dni);
        }
        /// <summary>
        /// Dos Universitario serán distintos si no son de mismo tipo, o su legajo ni dni son iguales.
        /// </summary>
        /// <param name="pg1">Universitario a comparar</param>
        /// <param name="pg2">Universitario a comparar</param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
