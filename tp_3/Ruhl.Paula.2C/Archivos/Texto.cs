using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto<T> : IArchivo<T>
    {
        private static string path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\TextoPrueba.txt";
        
        /// <summary>
        /// Serializa un dato de Tipo genérico a xml y lo guarda.
        /// </summary>
        /// <param name="dato">dato de tipo genérico</param>
        /// <returns></returns>
        public bool Guardar(T dato)
        {
            StreamWriter writer = null;
            using (writer = new StreamWriter(path))
            {
                if (writer != null)
                {
                    writer.WriteLine(dato);
                }
                else return false;
            }
            return true;
        }

        public string Leer()
        {
            StreamReader reader = null;
            string aux = string.Empty;

            using (reader = new StreamReader(path))
            {
                aux = reader.ReadToEnd();
            }

            return aux;
        }

    }
}
