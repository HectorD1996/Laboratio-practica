using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioPracticaED2
{
    class Cancion
    {
        public string Path = "";
        public TagLib.File Archivo;

        Cancion(TagLib.File ARCH,String Dirreccion)
        {
            Archivo = ARCH;
            Path = Dirreccion;
        }
    }
}
