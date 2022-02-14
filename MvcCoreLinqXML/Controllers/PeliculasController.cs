using Microsoft.AspNetCore.Mvc;
using MvcCoreLinqXML.Models;
using MvcCoreLinqXML.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreLinqXML.Controllers
{
    public class PeliculasController : Controller
    {
        private RepositoryPeliculas repo;

        public PeliculasController(RepositoryPeliculas repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<Pelicula> pelis = this.repo.GetPeliculas();
            return View(pelis);
        }

        public IActionResult Escenas(int idpelicula)
        {
         
            List<Escena> escenas = this.repo.GetEscenasPelicula(idpelicula);
            
            
            return View(escenas);
        }


        public IActionResult EscenaPelicula(int idpelicula, int?posicion)
        {
            if(posicion == null)
            {
                posicion = 0;
            }
            int numeroregistros = 0;
            Escena escena = this.repo.GetEscenasPeliculaPaginate(idpelicula, posicion.Value, ref numeroregistros);
            int siguiente = posicion.Value + 1;
            if(siguiente >= numeroregistros)
            {
                siguiente = 0;
            }

            int anterior = posicion.Value - 1;

            if(anterior < 0)
            {
                anterior = posicion.Value - 1;
            }
            ViewData["REGISTROS"] = "Escena " + (posicion + 1)+ " de "+ numeroregistros;
            ViewData["SIGUIENTE"] = siguiente;
            ViewData["ANTERIOR"] = anterior;
            
            return View(escena);
        }

        public IActionResult Details(int idpelicula)
        {
            Pelicula peli = this.repo.FindPelicula(idpelicula);
            return View(peli);
        }
    }
}
