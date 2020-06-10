using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

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
        public string StringToDNI
        {
            set
            {
                this.Dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region Metodos
        public Persona() { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) 
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
             : this(nombre, apellido, nacionalidad)

        {
            this.Dni = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.Apellido, this.Nombre);
            sb.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad);

            return sb.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            bool dniEsArgentino = dato > 1 && dato < 90000000;
            bool dniEsExtranjero = dato > 90000000 && dato < 99999999;

            if(!dniEsArgentino && !dniEsExtranjero)
            {
                throw new DniInvalidoException();
            }
            else if ((dniEsArgentino && nacionalidad == ENacionalidad.Argentino) ||
            (dniEsExtranjero && nacionalidad == ENacionalidad.Extranjero))
            {
                return dato;
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dniNumerico;
            if (!int.TryParse(dato, out dniNumerico))
            {
                throw new DniInvalidoException("El DNI Ingresado no es numérico");
            };
            return dniNumerico;
        }

        private string ValidarNombreApellido(string dato)
        {
            return string.IsNullOrEmpty(dato) || dato.Any(x => !Regex.IsMatch(dato, @"\A[\p{L}\s]+\Z")) ? string.Empty : dato;
        }
        #endregion
    }
}
