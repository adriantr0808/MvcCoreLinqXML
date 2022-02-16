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

        [AuthorizeCursos(Policy ="Permisos")]
        public IActionResult CreateAlumno(string id)
        {
            ViewData["IDCURSO"] = id;
            TempData["IDCURSO"] = id;
            return View();
        }

        [HttpPost]
        public IActionResult CreateAlumno(int IdUsuario,string Nombre, string Apellido, string Perfil, int Nota, string Username , string Password)
        {
            string idcurso = TempData["IDCURSO"].ToString();
            this.repo.InsertarUsuario(idcurso,IdUsuario, Nombre, Apellido, Perfil, Nota, Username, Password);
            
            return RedirectToAction("ListaAlumnos", "Cursos", new { id = idcurso });
        }
    }
}
