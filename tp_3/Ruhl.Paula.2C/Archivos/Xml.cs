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
    /// <summary>
    /// Clase Xml, encargada de serializar y deserializar datos, guardándolos o leyendolos en un archivo tipo xml.
    /// </summary>
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda un archivo xml luego de serializarlo desde su propio Tipo.
        /// </summary>
        /// <param name="archivo">Nombre del archivo a guardar</param>
        /// <param name="datos">dato de tipo genérico a serializar</param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter writer = null;
            XmlSerializer ser = null;
            bool pudoSerializar = false; 

            try
            {
                using (writer = new XmlTextWriter($"{archivo}.xml", Encoding.UTF8))
                {
                    if (writer != null)
                    {
                        ser = new XmlSerializer(datos.GetType());
                        ser.Serialize(writer, datos);
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
        /// Lee un archivo xml y lo deserializa al tipo de dato correspondiente
        /// </summary>
        /// <param name="archivo">Nombre del archivo a leer y deserializar</param>
        /// <param name="datos">Datos de tipo genérico, deserializados. </param>
        /// <returns>True si pudo realizar la operación, false si no.</returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader reader = null;
            XmlSerializer ser = null;
            datos = default(T);
            bool pudoDeserializar = false; 

            try
            {
                if (!File.Exists(archivo)) throw new ArchivosException($"El archivo {archivo} no existe");

                using (reader = new XmlTextReader($"{archivo}.xml"))
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
