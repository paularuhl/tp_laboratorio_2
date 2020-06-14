using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ClasesInstanciables
{
    /// <summary>
    /// Clase pública y sellada Profesor. Hereda de Universitario. 
    /// Representa a los instructores de una universidad.
    /// </summary>
    public sealed class Profesor : Universitario
    {
        #region atributos
        /// <summary>
        /// Atributo clases del día, tipo cola, indica las clases que dictará el profesor.
        /// </summary>
        private Queue<Universidad.EClases> clasesDelDia;
        /// <summary>
        /// Atributo de clase de tipo Random, lo usaremos para generar números aleatorios.
        /// </summary>
        private static Random random;
        #endregion

        #region propiedades
        /// <summary>
        /// Propiedad que da acceso al serializador a las clases del día, sólo se utiliza para serializar.
        /// </summary>
        public List<Universidad.EClases> ClasesDelDia
        {
            get
            {
                return this.clasesDelDia.ToList();
            }
            set
            {
                value.Reverse();
                foreach (var item in value)
                {
                    this.clasesDelDia.Enqueue(item);
                }
            }
        }
        #endregion

        #region constructores
        /// <summary>
        /// Constructor estático que instanciara el atributo estático random.
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor público y por defecto que instanciará la Queue clasesDelDia
        /// También nos permite serializar y deserializar objetos de este tipo.
        /// </summary>
        public Profesor()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
        }
        /// <summary>
        /// Constructor parametrizado que llamará al constructor de la clase base Universitario pasandole los parámetros que este necesita, 
        /// e inicializará la queue clasesDelDia
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, EntidadesAbstractas.Persona.ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion 

        #region metodos
        /// <summary>
        /// Asignará dos clases al azar al Profesor, pudiendo repetirse.
        /// </summary>
        private void _randomClases()
        {
            do
            {
                this.clasesDelDia
                    .Enqueue((Universidad.EClases)random
                    .Next((int)Universidad.EClases.Programacion, (int)Universidad.EClases.SPD));
                Thread.Sleep(100);

            } while (this.clasesDelDia.Count < 2);
        }

        /// <summary>
        /// Mostrará los datos del profesor.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.AppendFormat($"{this.ParticiparEnClase()}\n");

            return sb.ToString();
        }

        /// <summary>
        /// Retornará la cadena "CLASES DEL DÍA" junto al nombre de la clases que da.
        /// </summary>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }
            return $"CLASES DEL DÍA: \n{sb.ToString()}";
        }

        /// <summary>
        /// Hará públicos los datos del profesor.
        /// </summary>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region operadores 
        /// <summary>
        /// Un profesor será igual a una clase si dicha clase se encuentra entre sus clases del día
        /// </summary>
        /// <param name="i">Profesor a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>true or false</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return i.clasesDelDia.Contains(clase);
        }

        /// <summary>
        /// Un profesor será distinto a una clase si dicha clase no se encuentra entre sus clases del día
        /// </summary>
        /// <param name="i">Profesor a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>true or false</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
