using System;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Guarda el string que lo invocó en el nombre de archivo que se le pasa por parámetro, dentro de la carpeta escritorio.
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool pudoGuardar = false;
            string path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\{archivo}";

            using (StreamWriter file = new StreamWriter(path, true))
            {
                file.WriteLine(texto);
                pudoGuardar = true;
            }
            return pudoGuardar;
        }
    }
}
