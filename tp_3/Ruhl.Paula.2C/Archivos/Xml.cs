using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Serializa un dato de Tipo genérico a xml y lo guarda.
        /// </summary>
        /// <param name="dato">dato de tipo genérico</param>
        /// <returns></returns>
        public bool Guardar(string archivo, T dato)
        {
            XmlTextWriter writer = null;
            XmlSerializer ser = null;
            bool pudoSerializar = false; 

            try
            {
                using (writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    if (writer != null)
                    {
                        ser = new XmlSerializer(dato.GetType());
                        ser.Serialize(writer, dato);
                        pudoSerializar = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException("No se pudo serializar.", ex);
            }
            
            return pudoSerializar;
        }

        /// <summary>
        /// Deserializa un archivo de tipo XML al tipo deseado.
        /// </summary>
        /// <returns> Dato de tipo genérico </returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader reader = null;
            XmlSerializer ser = null;
            datos = default(T);
            bool pudoDeserializar = false; 

            try
            {
                using (reader = new XmlTextReader(archivo))
                {
                    if(reader != null)
                    {
                        ser = new XmlSerializer(typeof(T));
                        datos = (T)ser.Deserialize(reader);
                        pudoDeserializar = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException("No se pudo Deserializar.", ex);
            }

            return pudoDeserializar;
        }
    }
}
