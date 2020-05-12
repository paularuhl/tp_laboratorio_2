using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        public Universitario()
        {

        }
        public Universitario(int legajo, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad)
            : base (nombre, apellido, dni, nacionalidad)
        {

        }

        protected abstract string ParticiparEnClase();

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendFormat("Legajo: {0}", this.legajo);
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            return this.legajo == obj.legajo;
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {

        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

    }
}
