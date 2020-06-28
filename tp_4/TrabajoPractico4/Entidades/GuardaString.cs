using System;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        public static bool Guardar(this string texto, string archivo)
        {
            bool pudoGuardar = false;
            string path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\{archivo}.txt";

            using (StreamWriter file = new StreamWriter(path, true))
            {
                file.WriteLine(texto);
                pudoGuardar = true;
            }
            return pudoGuardar;
        }
    }
}
