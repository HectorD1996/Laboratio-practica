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

        public ListasReproduccion()
        {

        }
        public ListasReproduccion(List<Cancion> Tracks,string ListName)
        {
            NombreLista = ListName;
            ListaR = Tracks;
        }

        public void Ordenar(String tipo)
        {
            switch (tipo)
            {
                case "Ordenar Ascendente Nombre":
                    ListaR= ListaR.OrderBy(o => o.Titulo).ToList();
                    break;
                case "Ordenar Descendente Nombre":
                    ListaR = ListaR.OrderByDescending(o => o.Titulo).ToList();
                    break;
                case "Ordenar Ascendente Duracion":
                    ListaR = ListaR.OrderBy(o => o.Archivo.Properties.Duration).ToList();
                    break;
                case "Ordenar Descendente Duracion":
                    ListaR = ListaR.OrderByDescending(o => o.Archivo.Properties.Duration).ToList();
                    break;
                default:
                    break;
            }
        }
    }
}
