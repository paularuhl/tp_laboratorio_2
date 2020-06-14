using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using ClasesInstanciables;

namespace ClasesInstanciables
{
    /// <summary>
    /// Clase pública e instanciable Jornada, que representa un día de la universidad y debe tener alumnos, instructor y una materia/clase asignada
    /// </summary>
    public class Jornada
    {
        #region atributos
        /// <summary>
        /// Lista de alumnos que participan de la jornada.
        /// </summary>
        private List<Alumno> alumnos;
        /// <summary>
        /// Clase que se dictará.
        /// </summary>
        private Universidad.EClases clase;
        /// <summary>
        /// Instructor de la clase.
        /// </summary>
        private Profesor instructor;
        #endregion

        #region propiedades
        /// <summary>
        /// Propiedad Alumnos que asigna y retorna la lista de objetos de tipo Alumno, alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Propiedad Clase que asigna y retorna el atributo de tipo Universidad.EClases clase.
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Propiedad Instructor que asigna y retorna el atributo de tipo Profesor instructor.
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion
        
        #region constructores
        /// <summary>
        /// Constructor por defecto, que inicializa la lista de alumnos de la jornada.
        /// También nos permite serializar y deserializar objetos de este tipo.
        /// </summary>
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor publico que recibe la clase a asignar y el profesor que la dará. 
        /// Llama al constructor por defecto.
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Muestra todos los datos de la jornada.
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");

            sb.Append($"CLASE DE {this.Clase.ToString()} POR ");
            sb.AppendFormat(this.Instructor.ToString());
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno a in this.Alumnos)
            {
                sb.Append(a.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Guarda los datos de la jornada en un archivo de texto.
        /// </summary>
        /// <param name="j">Jornada a guardar</param>
        /// <returns>bool, si pudo o no guardarse la misma.</returns>
        public static bool Guardar(Jornada j)
        {
            Texto archivoHandler = new Texto();

            return archivoHandler.Guardar("jornadas", j.ToString());
        }

        /// <summary>
        /// Retorna los datos de la jornada como string leyéndolos desde un archivo de texto.
        /// </summary>
        /// <returns>El resultado de la operación en tipo string</returns>
        public static string Leer()
        {
            Texto serializador = new Texto();
            string jornadaLeida = string.Empty;

            serializador.Leer("jornadas", out jornadaLeida);

            return jornadaLeida;
        }
        #endregion

        #region operadores
        /// <summary>
        /// Una jornada será igual a un alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>True si participa, false si no.</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno alumno in j.Alumnos)
            {
                if (alumno == a)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Una jornada será distinta a un alumno si el mismo no participa de la clase.
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>False si participa, true si no.</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Operador de suma. Se validará que el alumno no pertenezca
        /// previamente a la jornada correspondiente, y en ese caso
        /// se agregará el mismo a la lista de alumnos.
        /// </summary>
        /// <param name="j">Jornada a validar</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns>Jornada con o sin cambios</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a) j.Alumnos.Add(a);
            return j;
        }
        #endregion
    }
}
