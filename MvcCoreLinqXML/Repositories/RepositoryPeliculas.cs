using MvcCoreLinqXML.Models;
using MvcCoreLinqXML.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MvcCoreLinqXML.Repositories
{
    public class RepositoryPeliculas
    {
        private XDocument document;
        private string path;

        public RepositoryPeliculas(PathProvider pathProvider)
        {
            this.path = pathProvider.MapPath("peliculas.xml", Folders.Documents);
            this.document = XDocument.Load(path);
        }

        public List<Pelicula> GetPeliculas()
        {
            var consulta = from datos in this.document.Descendants("pelicula")
                           select datos;

            List<Pelicula> peliculas = new List<Pelicula>();

            foreach (XElement dato in consulta)
            {
                Pelicula peli = new Pelicula();
                peli.Id = int.Parse(dato.Attribute("idpelicula").Value);
                peli.Titulo = dato.Element("titulo").Value;
                peli.TituloOriginal = dato.Element("titulooriginal").Value;
                peli.Poster = dato.Element("poster").Value;
                peli.Descripcion = dato.Element("descripcion").Value;
                peliculas.Add(peli);
            }

            return peliculas;
        }

    }
}
