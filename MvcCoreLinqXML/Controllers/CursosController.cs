using Microsoft.AspNetCore.Mvc;
using MvcCoreLinqXML.Filters;
using MvcCoreLinqXML.Models;
using MvcCoreLinqXML.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreLinqXML.Controllers
{
    public class CursosController : Controller
    {
        private RepositoryCursos repo;
        public CursosController(RepositoryCursos repo)
        {
            this.repo = repo;
        }
        [AuthorizeCursos]
        public IActionResult ListaAlumnos(string id)
        {

            List<Usuario> usus = this.repo.GetUsuariosCurso(id);
            return View(usus);
        }

        [AuthorizeCursos]
        public IActionResult PerfilAlumno()
        {
          
            return View();
        }

        public IActionResult PerfilGeneral()
        {
            return View();
        }
    }
}
