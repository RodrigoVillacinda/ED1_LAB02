using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ED1_LAB3.Models;
using System.IO;
using Newtonsoft.Json;
using System.Text;

namespace ED1_LAB3.Controllers
{
    public class ArbolController : Controller
    {

        // Obtenemos .json
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase archivoTXT)
        {
            
            Pais pais = new Pais();
            
            //var path = @"D:\Descargas\dataPaises.json";
            var path = archivoTXT.ToString();
            // var h =System.IO.Path.GetExtension(archivoTXT.FileName);
           
            var contenido = System.IO.File.ReadAllText(path);

            //Recibe un objeto generico, agarramos la cadena de texto de Json
            // y lo convertimos en un objeto
           
            var arbol = JsonConvert.DeserializeObject<AVL<Pais>>(contenido);

            Data.DataPais.Instance.arbol = arbol;

            var cadena = JsonConvert.SerializeObject(arbol);

            TempData["Arbol"] = cadena;


            return View();
        }
        //Fin

        public ActionResult Insertar(string NombrePais1, String GrupoPais, string NoPartido, string FePartido, string NombrePais2, string EstadioPais)
        {
            Pais pais = new Pais();
            pais.Nombre1 = NombrePais1;
            pais.Grupo = GrupoPais;
            pais.NoPartido = Convert.ToInt16(NoPartido);
            pais.FechaPartido = Convert.ToDateTime(FePartido);
            pais.Nombre2 = NombrePais2;
            pais.Estadio = EstadioPais;

            var raiz = Data.DataPais.Instance.arbol;
            Data.DataPais.Instance.arbol.Insertar(pais, raiz);

            var cadena = JsonConvert.SerializeObject(Data.DataPais.Instance.arbol);


            return View("Index");
        }
            

        public ActionResult Elimminar(string NombrePais1, String GrupoPais, string NoPartido, string FePartido, string NombrePais2, string EstadioPais)
        {
            Pais pais = new Pais();
            pais.Nombre1 = NombrePais1;
            pais.Grupo = GrupoPais;
            pais.NoPartido = Convert.ToInt16(NoPartido);
            pais.FechaPartido = Convert.ToDateTime(FePartido);
            pais.Nombre2 = NombrePais2;
            pais.Estadio = EstadioPais;

            var raiz = Data.DataPais.Instance.arbol;
            Data.DataPais.Instance.arbol.Eliminar(pais, raiz);

            var cadena = JsonConvert.SerializeObject(Data.DataPais.Instance.arbol);


            return View("Index");
        }

    }
}
