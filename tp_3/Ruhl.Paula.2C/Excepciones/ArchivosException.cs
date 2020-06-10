using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException() : this("Error en Archivos") { }
        public ArchivosException(Exception e) : this("Error en Archivos", e) { }
        public ArchivosException(string message) : this(message, null) { }
        public ArchivosException(string message, Exception e) : base(message, e) { }
    }
}
