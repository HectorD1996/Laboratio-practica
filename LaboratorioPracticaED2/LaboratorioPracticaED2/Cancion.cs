using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LaboratorioPracticaED2
{
    class Cancion
    {
        public string Directorio = "";
        public string Titulo = "";
        public TagLib.File Archivo;

        public Cancion(TagLib.File ARCH,String Dirreccion)
        {
            Archivo = ARCH;
            Directorio = Dirreccion;
            if (ARCH.Tag.Title != null)
            {
                Titulo = ARCH.Tag.Title;
            }
            else
            {
                Titulo = Path.GetFileName(ARCH.Name);
            }
            
        }
    }
}
