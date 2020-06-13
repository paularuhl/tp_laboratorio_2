using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    /// <summary>
    /// Clase Texto, encargada de guardar y leer archivos de texto.
    /// </summary>
    public class Texto : IArchivo<string>
    {

        /// <summary>
        /// Guarda como texto los datos que se envían por parámetro.
        /// </summary>
        /// <param name="archivo">Nombre del archivo a guardar</param>
        /// <param name="datos">Datos a guardar en el archivo</param>
        /// <returns>True si pudo guardar, false si no.</returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter writer = null;
            bool pudoEscribir = false;
            try
            {
                using (writer = new StreamWriter($"{archivo}.txt"))
                {
                    writer.WriteLine(datos);
                    pudoEscribir = true;
                }
            }
            catch (ArgumentNullException e)
            {
                throw new ArchivosException(e);
            }
            catch (PathTooLongException e)
            {
                throw new ArchivosException(e);
            }
            catch (IOException e)
            {
                throw new ArchivosException(e);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if (!pudoEscribir) throw new ArchivosException("No se pudo escribir el archivo de texto.");
            }

            return pudoEscribir;
        }

        /// <summary>
        /// Lee un archivo de texto y lo retorna como cadena por out parameter.
        /// </summary>
        /// <param name="archivo">Nombre del archivo a leer</param>
        /// <param name="datos">String a devolver con los datos del archivo en cuestión.</param>
        /// <returns>True si pudo leer, false si no.</returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader reader = null;
            bool pudoLeer = false; 

            try
            {

                using (reader = new StreamReader($"{archivo}.txt"))
                {
                    datos = reader.ReadToEnd();
                    pudoLeer = true;
                }
            }
            catch (FileNotFoundException e)
            {
                throw new ArchivosException("El archivo no existe", e);
            }
            catch (NotSupportedException e)
            {
                throw new ArchivosException(e);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if (!pudoLeer) throw new ArchivosException("No se pudo leer el archivo");
            }

            return pudoLeer;
        }

    }
}
