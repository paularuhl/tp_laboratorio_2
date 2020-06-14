using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    /// <summary>
    /// Clase pública y sellada Alumno. Hereda de Universitario. 
    /// Representa a los alumnos de una universidad.
    /// </summary>
    public sealed class Alumno : Universitario
    {
        #region nestedTypes
        /// <summary>
        /// Enumerado que indica los posibles estados de cuenta del alumno.
        /// </summary>
        public enum EEstadoCuenta { AlDia, Deudor, Becado }
        #endregion

        #region atributos
        /// <summary>
        /// Atributo que indica la clase que toma el alumno
        /// </summary>
        private Universidad.EClases claseQueToma;
        /// <summary>
        /// Atributo que indica el estado de cuenta del alumno
        /// </summary>
        private EEstadoCuenta estadoCuenta;
        #endregion  

        #region constructores
        /// <summary>
        /// Constructor público y por defecto. Nos permite serializar y deserializar objetos de este tipo.
        /// </summary>
        public Alumno() { }

        /// <summary>
        /// Constructor parametrizado que llamará al constructor de la clase base Universitario pasandole los parámetros que este necesita, 
        /// e inicializará el atributo claseQueToma.
        /// </summary>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) 
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor parametrizado que llamará a otro constructor de esta clase pasandole los parámetros que este necesita, 
        /// e inicializará el atributo estadoCuenta.
        /// </summary>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Mostrará los datos del alumno.
        /// </summary>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());

            sb.AppendFormat("ESTADO DE CUENTA: {0}\n", this.estadoCuenta == EEstadoCuenta.AlDia ? "Cuota al día" : this.estadoCuenta.ToString());
            sb.AppendFormat($"{this.ParticiparEnClase()}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Retornará la cadena "TOMA CLASE DE " junto al nombre de la clase que toma.
        /// </summary>
        protected override string ParticiparEnClase()
        {
            return $"TOMA CLASES DE {this.claseQueToma} ";
        }

        /// <summary>
        /// Hará públicos los datos del alumno.
        /// </summary>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region operadores
        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>true or false</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor;
        }
        /// <summary>
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase.
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>true or false</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma != clase;
        }
        #endregion
    }
}
