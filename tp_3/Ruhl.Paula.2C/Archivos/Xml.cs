using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        private static string path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\XmlPrueba.xml";

        /// <summary>
        /// Serializa un dato de Tipo genérico a xml y lo guarda.
        /// </summary>
        /// <param name="dato">dato de tipo genérico</param>
        /// <returns></returns>
        public bool Guardar(T dato)
        {
            XmlTextWriter writer = null;
            XmlSerializer ser = null;

            using (writer = new XmlTextWriter(path, Encoding.UTF8))
            {
                if (writer != null)
                {
                    ser = new XmlSerializer(dato.GetType());
                    ser.Serialize(writer, dato);
                }
                else
                {
                    throw new Excepciones.ArchivosException();
                }
            }
            return true;
        }

        /// <summary>
        /// Deserializa un archivo de tipo XML al tipo deseado.
        /// </summary>
        /// <returns> Dato de tipo genérico </returns>
        public T Leer()
        {
            XmlTextReader reader = null;
            XmlSerializer ser = null;
            T aux;

            using (reader = new XmlTextReader(path))
            {
                ser = new XmlSerializer(typeof(T));
                aux = (T)ser.Deserialize(reader);
            }

            return aux;
        }
    }
}
