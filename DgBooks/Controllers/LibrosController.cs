using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DgBooksDetails.DgBServices;
using System.Web.Mvc;

namespace DgBooks.Controllers
{
    public class LibrosController : Controller
    {
        
        libroServices services = new libroServices();
        usuarioServices usuarioServices = new usuarioServices();
        autorServices autorServices = new autorServices();
        personaServices personaServices = new personaServices();
        // GET: Libros
        public ActionResult Index()
        {
            return RedirectToAction("index","Home");
        }

        [HttpGet]
        public ActionResult PantallaP(int id)
        {   
            try
            {
                var user = usuarioServices.GetUsuarioById(id);
                var List = services.GetLibros();
                ViewBag.User = user;
                return View(List);
            }
            catch(Exception ex)
            {
                string err = ex.Message;
                return RedirectToAction("LogIn", "Usuario");
            }
        }

        [HttpGet]
        public ActionResult PantallaDetalles(int id, int idU)
        {
            try
            {
                var user = usuarioServices.GetUsuarioById(idU);
                var libro = services.GetLibroById(id);
                var autor = autorServices.GetAutor(int.Parse(libro.intIdAutor.ToString()));
                var persona = personaServices.GetPersona(int.Parse(autor.idPersona.ToString()));
                ViewBag.Autor = persona;
                ViewBag.User = user;
                ViewBag.Year = int.Parse(libro.dtFechaPublicacion.Value.Year.ToString());
                return View(libro);
            }
            catch
            {
                return RedirectToAction("PantallaP", new { id=idU});
            }
        }

        [HttpGet]
        public ActionResult PantallaLectura(int id, int idU)
        {
            try
            {
                var libro=services.GetLibroById(id);
                var user = usuarioServices.GetUsuarioById(idU);
                ViewBag.User = user;
                return View(libro);
            }
            catch
            {
                return RedirectToAction("PantallaP", new { id = idU });
            }
            
        }

    }
}