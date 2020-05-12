using ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private Random random;

        static Profesor()
        {

        }
        public Profesor()
        {

        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {

        }

        private void _randomClases()
        {

        }

        protected override string MostrarDatos()
        {
            return "";
        }

        protected override string ParticiparEnClase()
        {
            return "";
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {

        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }
}
