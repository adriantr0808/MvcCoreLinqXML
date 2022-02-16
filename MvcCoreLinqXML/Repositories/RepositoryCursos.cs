using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using MvcCoreLinqXML.Filters;
using MvcCoreLinqXML.Models;
using MvcCoreLinqXML.Providers;

namespace MvcCoreLinqXML.Repositories
{
    public class RepositoryCursos
    {
        private XDocument document;
        private string path;


        public RepositoryCursos()
        {
            this.path = PathProvider.MapPath("Cursos.xml", Folders.Documents);
            this.document = XDocument.Load(path);
        }

        
        public List<Usuario> GetUsuariosCurso(string idcurso)
        {
            var consulta = from datos in this.document.Descendants("usuario")
                           where datos.Parent.Attribute("idcurso").Value==idcurso
                           select datos;

            
            List<Usuario> usuarios = new List<Usuario>();

            foreach (XElement dato in consulta)
            {
                Usuario usu = new Usuario();
            
                usu.Nombre = dato.Element("nombre").Value;
                usu.Apellido = dato.Element("apellidos").Value;
                usu.Nota = int.Parse(dato.Element("nota").Value);
                usu.Perfil = dato.Element("perfil").Value;
                usu.Username = dato.Element("username").Value;
                usu.Password = dato.Element("password").Value;
                usuarios.Add(usu);
            }

            return usuarios;
        }

        public Usuario FindUsuario(int id)
        {
            var consulta = from datos in this.document.Descendants("usuario")
                           where datos.Attribute("id").Value == id.ToString()
                           select datos;

            XElement dato = consulta.FirstOrDefault();
            Usuario usu = new Usuario();
            usu.IdCurso = dato.Parent.Attribute("idcurso").Value;
            usu.IdUsuario = int.Parse(dato.Attribute("id").Value);
            usu.Nombre = dato.Element("nombre").Value;
            usu.Apellido = dato.Element("apellidos").Value;
            usu.Nota = int.Parse(dato.Element("nota").Value);
            usu.Perfil = dato.Element("perfil").Value;
            usu.Username = dato.Element("username").Value;
            usu.Password = dato.Element("password").Value;

            return usu;

        }

        public Usuario ExisteUsuario(string username, string password)
        {
            var consulta = from datos in this.document.Descendants("usuario")
                           where datos.Element("username").Value == username &&
                           datos.Element("password").Value == password
                           select datos;

            XElement dato = consulta.FirstOrDefault();
            Usuario usu = new Usuario();
            usu.IdCurso = dato.Parent.Attribute("idcurso").Value;
            usu.IdUsuario = int.Parse(dato.Attribute("id").Value);
            usu.Nombre = dato.Element("nombre").Value;
            usu.Apellido = dato.Element("apellidos").Value;
            usu.Nota = int.Parse(dato.Element("nota").Value);
            usu.Perfil = dato.Element("perfil").Value;
            usu.Username = dato.Element("username").Value;
            usu.Password = dato.Element("password").Value;

            return usu;
        }


        public XElement FindXElementCurso(string idcurso)
        {
            var consulta = from datos in this.document.Descendants("curso")
                           where datos.Attribute("idcurso").Value==idcurso
                           select datos;

            return consulta.FirstOrDefault();
        }

        public void InsertarUsuario(string idcurso,int idusuario, string nombre, string apellidos, string perfil, int nota, string username, string password)
        {
            XElement XCurso = this.FindXElementCurso(idcurso);
            XElement rootUser = new XElement("usuario");

            rootUser.SetAttributeValue("id", idusuario);
            rootUser.Add(new XElement("nombre", nombre));
            rootUser.Add(new XElement("apellidos", apellidos));
            rootUser.Add(new XElement("perfil", perfil));
            rootUser.Add(new XElement("nota", nota));
            rootUser.Add(new XElement("username", username));
            rootUser.Add(new XElement("password", password));

            XCurso.Add(rootUser);
            this.document.Save(this.path);

        }


    }
}
