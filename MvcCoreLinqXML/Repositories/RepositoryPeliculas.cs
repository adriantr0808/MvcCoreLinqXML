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
        private XDocument documentEscenas;
        private string path;
        private string pathEscenas;

        public RepositoryPeliculas()
        {
            this.path = PathProvider.MapPath("peliculas.xml", Folders.Documents);
            this.document = XDocument.Load(path);

            this.pathEscenas = PathProvider.MapPath("escenaspeliculas.xml", Folders.Documents);
            this.documentEscenas = XDocument.Load(pathEscenas);
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

        public List<Escena> GetEscenasPelicula(int idpelicula)
        {
            var consulta = from datos in this.documentEscenas.Descendants("escena")
                           where datos.Attribute("idpelicula").Value == idpelicula.ToString()
                           select datos;


            
            List<Escena> escenas = new List<Escena>();

            foreach(XElement dato in consulta)
            {
                Escena escena = new Escena()
                {
                    IdPelicula = int.Parse(dato.Attribute("idpelicula").Value),
                    Titulo = dato.Element("tituloescena").Value,
                    Descripcion = dato.Element("descripcion").Value,
                    Imagen = dato.Element("imagen").Value

                };

                escenas.Add(escena);
            }

           

            return escenas;
           
        }
        public Escena GetEscenasPeliculaPaginate(int idpelicula, int posicion, ref int numeroescenas)
        {
            var consulta = from datos in this.documentEscenas.Descendants("escena")
                           where datos.Attribute("idpelicula").Value == idpelicula.ToString()
                           select datos;



            List<Escena> escenas = new List<Escena>();

            foreach (XElement dato in consulta)
            {
                Escena escena = new Escena()
                {
                    IdPelicula = int.Parse(dato.Attribute("idpelicula").Value),
                    Titulo = dato.Element("tituloescena").Value,
                    Descripcion = dato.Element("descripcion").Value,
                    Imagen = dato.Element("imagen").Value

                };

                escenas.Add(escena);
            }

            numeroescenas = escenas.Count();
            Escena escena1 = escenas.Skip(posicion).Take(1).FirstOrDefault();
            return escena1;

        }

        public Pelicula FindPelicula(int idpelicula)
        {
            var consulta = from datos in this.document.Descendants("pelicula")
                           where datos.Attribute("idpelicula").Value == idpelicula.ToString()
                           select datos;

            XElement dato = consulta.FirstOrDefault();
            Pelicula peli = new Pelicula
            {
                Id = int.Parse(dato.Attribute("idpelicula").Value),
                Titulo = dato.Element("titulo").Value,
                TituloOriginal = dato.Element("titulooriginal").Value,
                Descripcion = dato.Element("descripcion").Value,
                Poster = dato.Element("poster").Value
            };

            return peli;
        }

    }
}
