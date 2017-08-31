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
        //contiene la direccion original de la cancion, titulo, y el archivo Taglib
        //el cual contiene la metadata mas importante la duracion
        public string Directorio = "";
        public string Titulo = "";
        public TagLib.File Archivo;

        public Cancion(TagLib.File ARCH,String Dirreccion)
        {
            Archivo = ARCH;
            Directorio = Dirreccion;

            // en caso el titulo de la cancion no este especificado se toma el nombre del arhivo como tal
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
