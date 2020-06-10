using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private static string path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\TextoPrueba.txt";
        
        /// <summary>
        /// Serializa un dato de Tipo genérico a xml y lo guarda.
        /// </summary>
        /// <param name="dato">dato de tipo genérico</param>
        /// <returns></returns>
        public bool Guardar(string archivo, string dato)
        {
            StreamWriter writer = null;
            bool pudoEscribir = false;
            try
            {
                using (writer = new StreamWriter(path))
                {
                    writer.WriteLine(dato);
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
                if (!pudoEscribir) throw new ArchivosException("No se pudo escribir el archivo.");
            }
            return pudoEscribir;
        }

        public bool Leer(string archivo, out string datos)
        {
            StreamReader reader = null;
            bool pudoLeer = false; 

            try
            {
                using (reader = new StreamReader(path))
                {
                    datos = reader.ReadToEnd();
                    pudoLeer = true;
                }
            }
            catch (FileNotFoundException e)
            {
                throw new ArchivosException(e);
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
