using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        static Profesor()
        {
            random = new Random();
        }
        public Profesor()
        {

        }
        public Profesor(int id, string nombre, string apellido, string dni, EntidadesAbstractas.Persona.ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        private void _randomClases()
        {
            int i = 0;
            do
            {
                this.clasesDelDia
                    .Enqueue((Universidad.EClases)random
                    .Next((int)Universidad.EClases.Programacion, (int)Universidad.EClases.SPD));
                Thread.Sleep(300);
                i++;
            } while (i < 2);
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append(base.MostrarDatos());
            sb.AppendFormat($"{this.ParticiparEnClase()}\n");

            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }
            return $"CLASES DEL DÍA: \n{sb.ToString()}";
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return i.clasesDelDia.Contains(clase);
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }
}
