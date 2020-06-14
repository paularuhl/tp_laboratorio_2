using Excepciones;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EntidadesAbstractas
{
    /// <summary>
    /// Clase pública y abstracta Persona.
    /// </summary>
    public abstract class Persona
    {
        #region nestedTypes
        /// <summary>
        /// Nacionalidades posibles del tipo persona.
        /// </summary>
        public enum ENacionalidad { Argentino, Extranjero }
        #endregion

        #region Atributos
        /// <summary>
        /// atributo nombre
        /// </summary>
        private string nombre;
        /// <summary>
        /// atributo apellido
        /// </summary>
        private string apellido;
        /// <summary>
        /// atributo dni
        /// </summary>
        private int dni;
        /// <summary>
        /// atributo nacionalidad
        /// </summary>
        private ENacionalidad nacionalidad;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad que accede y setea el apellido validando el valor ingresado y asignandolo solo si es correcto.
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                if (this.ValidarNombreApellido(value) != string.Empty) this.apellido = value;
            }
        }
        /// <summary>
        /// Propiedad que accede y setea el nombre validando el valor ingresado y asignandolo solo si es correcto.
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if (this.ValidarNombreApellido(value) != string.Empty) this.nombre = value;
            }
        }
        /// <summary>
        /// Propiedad que accede y setea la nacionalidad de la persona.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        /// <summary>
        /// Propiedad que accede y setea el DNI validando el valor ingresado y asignandolo solo si es correcto.
        /// </summary>
        public int Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        /// <summary>
        /// Propiedad que accede y setea el DNI ingresado como cadena, validando la misma y asignandolo solo si es correcto.
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region constructores
        /// <summary>
        /// Constructor por defecto que nos permite serializar y deserializar objetos de este tipo.
        /// </summary>
        public Persona() { }

        /// <summary>
        /// Constructor parametrizado que asignará los datos Nombre, Apellido, y Nacionalidad.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor parametrizado que recibirá el dni como entero, lo asignará y pasará el resto de parámetros
        /// al constructor correspondiente de la misma clase.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
             : this(nombre, apellido, nacionalidad)

        {
            this.Dni = dni;
        }

        /// <summary>
        /// Constructor parametrizado que recibirá el dni como cadena, lo asignará y pasará el resto de parámetros
        /// al constructor correspondiente de la misma clase.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Retornará los datos de la Persona.
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.Apellido, this.Nombre);
            sb.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad);

            return sb.ToString();
        }

        /// <summary>
        /// Valida que el dni esté dentro del rango correcto y que la nacionalidad coincida con el rango correspondiente.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            bool dniEsArgentino = dato > 1 && dato < 90000000;
            bool dniEsExtranjero = dato > 90000000 && dato < 99999999;
            bool nacionalidadArgentina = nacionalidad == ENacionalidad.Argentino;

            if (!dniEsArgentino && !dniEsExtranjero) throw new DniInvalidoException("El DNI esta fuera del rango correcto");

            if ((dniEsArgentino && nacionalidadArgentina) || (dniEsExtranjero && !nacionalidadArgentina)) return dato;
            else throw new NacionalidadInvalidaException();
        }

        /// <summary>
        /// Valida que el DNI sea un dato numérico
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dniNumerico;
            try
            {
                if (!int.TryParse(dato, out dniNumerico)) throw new DniInvalidoException("El DNI Ingresado no es numérico");

                return ValidarDni(nacionalidad, dniNumerico);
            }
            catch (DniInvalidoException ex)
            {
                throw ex;
            }
            catch (NacionalidadInvalidaException ex)
            {
                throw ex;
            }
            //En este caso me pareció correcto manejarlo así, pero en lugar de hacer algo con el resultado,
            //ya que no tenemos instrucciones más allá de los resultados del main de prueba,
            //las sigo devolviendo para que la reciba el mismo.
        }

        /// <summary>
        /// Validará que los caracteres sean válidos para nombres. De lo contrario retornará un string vacío.
        /// </summary>
        /// <param name="dato">cadena a evaluar</param>
        /// <returns>cadena validada</returns>
        private string ValidarNombreApellido(string dato)
        {
            return string.IsNullOrEmpty(dato) || dato.Any(x => !Regex.IsMatch(dato, @"\A[\p{L}\s]+\Z")) ? string.Empty : dato;
        }
        #endregion
    }
}
