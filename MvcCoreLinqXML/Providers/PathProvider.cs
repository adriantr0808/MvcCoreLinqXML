using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreLinqXML.Providers
{
    public enum Folders
    {
        Images = 0, Documents = 1
    }


    public static class PathProvider
    {
        private static IWebHostEnvironment environment;

       public static void Initialize(IWebHostEnvironment hostEnvironment)
        {
            environment = hostEnvironment;
        }

        public static string MapPath(string filename, Folders folder)
        {
            string carpeta = "";

            if(folder == Folders.Images)
            {
                carpeta = "images";
            }else if(folder == Folders.Documents){
                carpeta = "documents";
            }

            string path = Path.Combine(environment.WebRootPath, carpeta, filename);
            return path;
        }
    }
}
