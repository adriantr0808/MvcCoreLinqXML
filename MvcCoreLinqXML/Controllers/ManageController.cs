using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MvcCoreLinqXML.Models;
using MvcCoreLinqXML.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MvcCoreLinqXML.Controllers
{
    public class ManageController:Controller
    {

        private RepositoryCursos repo;

        public ManageController(RepositoryCursos repo)
        {
            this.repo = repo;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Login(string username, string password)
        {
            Usuario usu = this.repo.ExisteUsuario(username, password);

            if(usu != null)
            {
                ClaimsIdentity identity =
                    new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme,
                    ClaimTypes.Name, ClaimTypes.Role);

                Claim claimName = new Claim(ClaimTypes.Name, usu.Nombre);
                Claim claimApellido = new Claim("APELLIDO", usu.Apellido);
                Claim claimPerfil = new Claim("PERFIL", usu.Perfil);
                Claim claimNota = new Claim("NOTA", usu.Nota.ToString());
                Claim claimIdCurso = new Claim("IDCURSO", usu.IdCurso.ToString());
             
                identity.AddClaim(claimName);
                identity.AddClaim(claimApellido);
                identity.AddClaim(claimPerfil);
                identity.AddClaim(claimNota);
                identity.AddClaim(claimIdCurso);

                ClaimsPrincipal userPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync
                    (CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal);

                string controller = TempData["controller"].ToString();
                string action = TempData["action"].ToString();
                string id = claimIdCurso.Value.ToString();

                return RedirectToAction(action, controller, new { id = id});

            }
            else
            {
                ViewData["MENSAJE"] = "Usuario/Password incorrectos";
            }
            return View();

        }

        public IActionResult ErrorAcceso()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync
                (CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("PerfilGeneral", "Cursos");
        }
        
    }
}
