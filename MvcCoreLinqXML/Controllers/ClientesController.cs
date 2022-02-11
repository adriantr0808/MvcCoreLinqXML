using Microsoft.AspNetCore.Mvc;
using MvcCoreLinqXML.Models;
using MvcCoreLinqXML.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreLinqXML.Controllers
{
    public class ClientesController : Controller
    {
        private RepositoryClientes repo;
        public ClientesController(RepositoryClientes repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<Cliente> clientes = this.repo.GetClientes();
            return View(clientes);
        }

        public IActionResult Details(int id)
        {
            Cliente cliente = this.repo.FindCliente(id);
            return View(cliente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            this.repo.AddClient(cliente.IdCliente, cliente.Nombre, cliente.Direccion
                ,cliente.Email, cliente.Imagen);

            return RedirectToAction("Index");
        }

        public IActionResult Edit (int id)
        {
            Cliente cliente = this.repo.FindCliente(id);
            return View(cliente);

        }

        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {
            this.repo.UpdateCliente(cliente.IdCliente, cliente.Nombre, cliente.Direccion
                , cliente.Email, cliente.Imagen);
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            this.repo.DeleteCliente(id);
            return RedirectToAction("Index");
        }
    }
}
