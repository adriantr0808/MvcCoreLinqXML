using Microsoft.AspNetCore.Mvc;
using MvcCoreLinqXML.Models;
using MvcCoreLinqXML.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreLinqXML.Controllers
{
    public class JoyeriasController : Controller
    {
        private RepositoryJoyerias repo;
        

        public JoyeriasController(RepositoryJoyerias repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<Joyeria> joyerias = this.repo.GetJoyerias();
            return View(joyerias);
        }
    }
}
