using MvcCoreLinqXML.Models;
using MvcCoreLinqXML.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MvcCoreLinqXML.Repositories
{
    public class RepositoryJoyerias
    {

        private PathProvider pathProvider;
        XDocument document;

        public RepositoryJoyerias(PathProvider provider)
        {
            string filename = "joyerias.xml";
            string path = provider.MapPath
                (filename, Folders.Documents);

            this.document = XDocument.Load(path);
            this.pathProvider = provider;
        }

        public List<Joyeria> GetJoyerias()
        {
            var consulta = from datos in this.document.Descendants("joyeria")
                           select datos;

            List<Joyeria> joyerias = new List<Joyeria>();
            foreach(var element in consulta)
            {
                Joyeria joyeria = new Joyeria();
                //Para acceder a una etiqueta utilizamos Element
                //Para acceder a un atributo utilizamos Attribute
                joyeria.Nombre = element.Element("nombrejoyeria").Value;
                joyeria.CIF = element.Attribute("cif").Value;
                joyeria.Telefono = element.Element("telf").Value;
                joyeria.Direccion = element.Element("direccion").Value;
                joyerias.Add(joyeria);
            }

            return joyerias;
        }



    }
}
