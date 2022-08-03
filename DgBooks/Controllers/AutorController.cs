using DgBooksDetails.DgBServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DgBooks.Controllers
{
    public class AutorController : Controller
    {
        autorServices services = new autorServices();
        personaServices personaServices = new personaServices();
        usuarioServices usuarioServices = new usuarioServices();
        // GET: Autor
        public ActionResult Index()
        {
            return RedirectToAction("index","Home");
        }
        public ActionResult AutorDetail(int id, int idU)
        {
            try
            {
                var autor = services.GetAutor(id);
                int x = int.Parse(autor.idPersona.ToString());
                var persona = personaServices.GetPersona(x);
                var user = usuarioServices.GetUsuarioById(idU);
                ViewBag.Datos = persona;
                ViewBag.Year = persona.dtFechaNacimiento.Year.ToString();
                ViewBag.User = user;
                return View(autor);
            }
            catch
            {
                return RedirectToAction("index");
            }
        }
    }
}