using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClasesAbstractas
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
                this.dni = this.ValidarDni(nacionalidad, value);
            }
        }
        public ENacionalidad Nacionalidad { 
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
                this.Dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region Metodos
        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) { }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
             : this(nombre, apellido, nacionalidad)

        { }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Nombre: {0}", this.Nombre);
            sb.AppendFormat("Apellido: {0}", this.Apellido);
            sb.AppendFormat("DNI: {0}", this.Dni);
            sb.AppendFormat("Nacionalidad: {0}", this.Nacionalidad);

            return sb.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            bool flag = false;
            if ((dni > 1 && dni < 90000000) && (nacionalidad == ENacionalidad.Argentino))
            {
                flag = true;
            }
            else if ((dni > 90000000 && dni < 99999999) && (nacionalidad == ENacionalidad.Extranjero))
            {
                flag = true;
            }
            else
            {
                //DniInvalidoException
            }
            return 0;
        }
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            if (!int.TryParse(dato, out dni))
            {
                //DniInvalidoException
            };
            return this.ValidarDni(nacionalidad, dni);
        }

        private string ValidarNombreApellido(string dato)
        {
            return !string.IsNullOrEmpty(dato) || dato.Any(x => !Regex.IsMatch(dato, @"\A[\p{L}\s]+\Z")) ? string.Empty : dato;
        }
        #endregion
    }
}
