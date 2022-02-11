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
    }
}
