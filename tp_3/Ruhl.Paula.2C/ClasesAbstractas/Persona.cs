using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Enumerados
        public enum ENacionalidad { Argentino, Extranjero }
        #endregion

        #region Atributos
        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        #endregion

        #region Propiedades
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
        public int Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                //try
                //{
                    this.dni = this.ValidarDni(nacionalidad, value);
                //}
                //catch (Excepciones.DniInvalidoException ex)
                //{

                //}
                //catch (Excepciones.NacionalidadInvalidaException ex)
                //{

                //}
            }
        }
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

        public string StringToDNI
        {
            set
            {
                try
                {
                    this.Dni = this.ValidarDni(this.Nacionalidad, value);
                }
                catch (Excepciones.DniInvalidoException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Excepciones.NacionalidadInvalidaException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        #endregion

        #region Metodos
        public Persona()
        {

        }

        public Persona(string nombre, string apellido, EntidadesAbstractas.Persona.ENacionalidad nacionalidad) 
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, EntidadesAbstractas.Persona.ENacionalidad nacionalidad)
             : this(nombre, apellido, nacionalidad)

        {
            this.Dni = dni;
        }

        public Persona(string nombre, string apellido, string dni, EntidadesAbstractas.Persona.ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.Apellido, this.Nombre);
           // sb.AppendFormat("DNI: {0} ", this.Dni);
            sb.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad);

            return sb.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            bool dniEsArgentino = dato > 1 && dato < 90000000;
            bool dniEsExtranjero = dato > 90000000 && dato < 99999999;

            if(!dniEsArgentino && !dniEsExtranjero)
            {
                throw new Excepciones.DniInvalidoException();
            }
            else if ((dniEsArgentino && nacionalidad == ENacionalidad.Argentino) ||
            (dniEsExtranjero && nacionalidad == ENacionalidad.Extranjero))
            {
                return dato;
            } else
            {
                throw new Excepciones.NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
            }
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dniNumerico;
            if (!int.TryParse(dato, out dniNumerico))
            {
                throw new Excepciones.DniInvalidoException();
            };
            return dniNumerico;
        }

        private string ValidarNombreApellido(string dato)
        {
            return string.IsNullOrEmpty(dato) || dato.Any(x => !Regex.IsMatch(dato, @"\A[\p{L}\s]+\Z")) ? string.Empty : dato;
            //return !string.IsNullOrEmpty(dato) || dato.Any(x => !Regex.IsMatch(dato, @"\A[\p{L}\s]+\Z")) ? string.Empty : dato;
        }
        #endregion
    }
}
