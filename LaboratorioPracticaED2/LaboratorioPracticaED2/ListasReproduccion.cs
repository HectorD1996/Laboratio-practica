using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioPracticaED2
{
    class ListasReproduccion
    {
        public String NombreLista = "";
        public List<Cancion> ListaR = new List<Cancion>();

        public ListasReproduccion(List<Cancion> Tracks,string ListName)
        {
            NombreLista = ListName;
            ListaR = Tracks;
        }

    }
}
