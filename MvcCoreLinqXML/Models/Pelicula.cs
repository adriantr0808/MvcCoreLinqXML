using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreLinqXML.Models
{
    public class Pelicula
    {
            public int Id { get; set; }
           public string Titulo { get; set; }
           public string TituloOriginal { get; set; }
           public string Descripcion { get; set; }
           public string Poster { get; set; }
    }
}
