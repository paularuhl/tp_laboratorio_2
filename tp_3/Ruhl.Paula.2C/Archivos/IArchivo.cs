using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    /// <summary>
    /// Interfaz que engloba las firmas necesarias para el manejo de archivos.
    /// </summary>
    /// <typeparam name="T">Tipo a inferir en la clase que la implemente</typeparam>
    public interface IArchivo<T>
    {
        /// <summary>
        /// Operación guardar
        /// </summary>
        /// <param name="archivo">Nombre del archivo a guardar</param>
        /// <param name="datos">Datos a guardar en el archivo</param>
        /// <returns>Resultado de la operación (True: Éxito, False: Falló</returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Operación leer
        /// </summary>
        /// <param name="archivo">Nombre del archivo a leer</param>
        /// <param name="datos">Datos leídos en el archivo</param>
        /// <returns>Resultado de la operación (True: Éxito, False: Falló</returns>
        bool Leer(string archivo, out T datos);
    }
}
