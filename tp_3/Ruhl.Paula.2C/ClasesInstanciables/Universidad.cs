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

        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;


        public List<Alumno> Alumnos { get; set; }
        public List<Jornada> Jornadas { get; set; }
        public List<Profesor> Instructores { get; set; }
        public Jornada this[int i]
        {
            get
            {
                return new Jornada();
            }
            set
            {
            }

        }
        public Universidad()
        {

        }

        public bool Guardar(Universidad uni)
        {
            return true;
        }
        public Universidad Leer()
        {
            return new Universidad();
        }
        
        private static string MostrarDatos(Universidad uni)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static bool operator ==(Universidad g, Alumno a)
        {

        }
        public static bool operator ==(Universidad g, Profesor i)
        {

        }
        public static Profesor operator ==(Universidad g, EClases clase)
        {

        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            return !(g == clase);
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            return new Universidad();
        }
        public static Universidad operator +(Universidad g, Alumno a)
        {
            return new Universidad();
        }
        public static Universidad operator +(Universidad g, Profesor i)
        {
            return new Universidad();
        }

    }
}
