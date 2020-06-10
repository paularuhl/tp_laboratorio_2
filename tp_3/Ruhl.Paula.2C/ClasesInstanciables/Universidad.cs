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
    public class Universidad
    {
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }

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
        public Jornada this[int i]
        {
            get
            {
                return this.jornadas[i];
            }
        }
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();

        }

        /// <summary>
        /// Serializará los datos de Universidad en un XML,
        /// incluyendo todos los datos de sus profesores, alumnos y jornadas
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> serializador = new Xml<Universidad>();

            return serializador.Guardar("Universidad.xml", uni);
        }
        /// <summary>
        /// Retornará un Universidad con todos los datos que se hayan serializado previamente
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Xml<Universidad> serializador = new Xml<Universidad>();
            Universidad uni = null;
            serializador.Leer("Universidad.xml", out uni);
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
        /// <param name="u"></param>
        /// <param name="clase"></param>
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
            throw new Excepciones.SinProfesorException();
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
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            return u.Instructores.FirstOrDefault(p => p != clase);
        }

        /// <summary>
        /// Agrega una clase a la universidad, generando una jornada y verificando
        /// profesores y alumnos disponibles.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
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
                throw new Excepciones.SinProfesorException();
            }
            //Retorno la universidad actualizada
            return u;
        }

        /// <summary>
        /// Agrega un alumno a la universidad verificando que no esté inscripto previamente
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
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
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns>Universidad actualizada</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i) u.Instructores.Add(i);
            return u;
        }

    }
}
