using Archivos;
using EntidadesAbstractas;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    /// <summary>
    /// Clase pública e instanciable Universidad.
    /// </summary>
    public class Universidad
    {
        #region nestedTypes
        /// <summary>
        /// Enumerado de materias disponibles en el tipo Universidad.
        /// </summary>
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }
        #endregion

        #region atributos
        /// <summary>
        /// Lista de inscriptos
        /// </summary>
        private List<Alumno> alumnos;
        /// <summary>
        /// Lista de jornadas de la universidad.
        /// </summary>
        private List<Jornada> jornadas;
        /// <summary>
        /// Lista de quienes pueden dar las clases.
        /// </summary>
        private List<Profesor> profesores;
        #endregion

        #region propiedades e indexadores
        /// <summary>
        /// Propiedad que asigna y retorna la lista de inscriptos
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
        /// Propiedad que asigna y retorna la lista de jornadas de la universidad. 
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornadas;
            }
            set
            {
                this.jornadas = value;
            }
        }
        /// <summary>
        /// Propiedad que asigna y retorna la lista de quienes pueden dar las clases.
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Indexador que retorna la jornada pasada por parámetro
        /// </summary>
        /// <param name="i">parámetro índice</param>
        /// <returns>Jornada en posición i</returns>
        public Jornada this[int i]
        {
            get
            {
                return this.Jornadas[i];
            }
        }
        #endregion

        #region constructor
        /// <summary>
        /// Constructor por defecto de los objetos de tipo Universidad,
        /// inicializa las colecciones de la misma. 
        /// También nos permite serializar y deserializar objetos de este tipo.
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
        }
        #endregion

        #region metodos
        /// <summary>
        /// Serializará los datos de Universidad en un XML,
        /// incluyendo todos los datos de sus profesores, alumnos y jornadas
        /// </summary>
        /// <param name="uni">Universidad a guardar</param>
        /// <returns>bool, si pudo o no guardarse la misma.</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> serializador = new Xml<Universidad>();

            return serializador.Guardar("universidad", uni);
        }

        /// <summary>
        /// Retornará un Universidad con todos los datos que se hayan serializado previamente
        /// </summary>
        /// <returns>objeto de tipo Universidad</returns>
        public static Universidad Leer()
        {
            Xml<Universidad> serializador = new Xml<Universidad>();
            Universidad uni = null;
            serializador.Leer("universidad", out uni);
            return uni;
        }

        /// <summary>
        /// Retornará los datos de la clase.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada j in uni.Jornadas)
            {
                sb.Append(j.ToString());
                sb.AppendLine("<---------------------------------------------------------->");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Hace públicos los datos de la universidad.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion

        #region operadores
        /// <summary>
        /// Un Universidad será igual a un alumno si el mismo está inscripto en él
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno</param>
        public static bool operator ==(Universidad u, Alumno a)
        {
            if (!(u.Alumnos is null))
            {
                foreach (Alumno al in u.Alumnos)
                {
                    if (al == a)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Un Universidad será igual a un profesor si el mismo está dando clases en él
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="i">Profesor</param>
        public static bool operator ==(Universidad u, Profesor i)
        {
            if (!(u.Instructores is null)) return u.Instructores.Contains(i);
            return false;
        }
        /// <summary>
        /// Retornará el primer profesor capaz de dar la clase.
        /// </summary>
        /// <param name="u">universidad</param>
        /// <param name="clase">clase a matchear con profesor</param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            if (!(u.Instructores is null))
            {
                foreach (Profesor p in u.Instructores)
                {
                    if (p == clase)
                    {
                        return p;
                    }
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Un Universidad será distinto a un alumno si el mismo no está inscripto en él
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno</param>
        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }
        /// <summary>
        /// Un Universidad será distinto a un profesor si el mismo no está dando clases en él
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="i">Profesor</param>
        public static bool operator !=(Universidad u, Profesor i)
        {
            return !(u == i);
        }
        /// <summary>
        /// Retornará el primer profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Clase a encontrar un profesor que no pueda darla</param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            return u.Instructores.FirstOrDefault(p => p != clase);
        }

        /// <summary>
        /// Agrega una clase a la universidad, generando una jornada y verificando
        /// profesores y alumnos disponibles.
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Clase a agregar</param>
        /// <returns>Universidad actualizada</returns>
        public static Universidad operator +(Universidad u, EClases clase)
        {
            //Verifica si hay un profesor disponible y lo asigna, de lo contrario retorna null
            Profesor profesorDisponible = u.Instructores?.FirstOrDefault(p => p == clase);

            if (!(profesorDisponible is null))
            {

                //Verifico los alumnos que toman la clase
                List<Alumno> alumnosQueLaToman = u.Alumnos.Where(a => a == clase && a as Universitario != profesorDisponible as Universitario).ToList();

                //Crea la jornada y le asigno clase y profesor
                Jornada j = new Jornada(clase, profesorDisponible);

                //Sumo los alumnos que la toman
                foreach (Alumno a in alumnosQueLaToman)
                {
                    j = j + a;
                }

                //Agrego la jornada a la Universidad
                u.Jornadas.Add(j);
            }
            else
            {
                throw new SinProfesorException();
            }
            //Retorno la universidad actualizada
            return u;
        }

        /// <summary>
        /// Agrega un alumno a la universidad verificando que no esté inscripto previamente
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns>Universidad actualizada</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a) u.Alumnos.Add(a);
            else throw new AlumnoRepetidoException();
            return u;
        }

        /// <summary>
        /// Agrega un profesor a la universidad verificando que no esté ingresado previamente
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="i">Instructor a agregar</param>
        /// <returns>Universidad actualizada</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i) u.Instructores.Add(i);
            return u;
        }
        #endregion
    }
}
