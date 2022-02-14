using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreLinqXML.Models
{
    public class Usuario
    {
        public string IdCurso { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Perfil { get; set; }
        public int Nota { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
