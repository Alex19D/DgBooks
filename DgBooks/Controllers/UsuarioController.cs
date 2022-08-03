using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DgBooks.Comodin;
using DgBooks.Models;
using DgBooksDB;
using DgBooksDetails.DgBServices;

namespace DgBooks.Controllers
{
    public class UsuarioController : Controller
    {
        personaServices personaServices = new personaServices();
        usuarioServices services = new usuarioServices();
        validarServices validarServices = new validarServices();
        normalizarServices normalizar = new normalizarServices();
        // GET: Usuario
        public ActionResult Index()
        {
            return RedirectToAction("LogIn");
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UserLog log)
        {
            if (log.strUser_Email != null && log.strPassword != null)
            {
                var user = services.GetUsuarioByNameOrEmail(log.strUser_Email);
                if(user != null)
                {
                    if(log.strPassword == user.strContraseña)
                    {
                        int idU = user.intIdUsuario;
                        return RedirectToAction("PantallaP", "Libros", new { id = idU });
                    }
                }
                return View();
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(newUser user)
        {
            if (user!=null)
            {
                if(user.strContraseña == user.strConfirmContraseña)
                {
                    Usuario usuario = normalizar.normUsuario(user);
                    Persona persona = normalizar.normPersona(user);
                    if (validarServices.ValidPersona(persona) && validarServices.ValidUsuario(usuario)) 
                    {
                        if (personaServices.Insert(persona))
                        {
                            int id = personaServices.GetUltimaPersona();
                            usuario.intIdPersona = id;

                            if (services.Insert(usuario))
                            {
                                return RedirectToAction("Index");
                            }
                            else
                            {
                                personaServices.Delete(id);
                            }
                        }
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditarUsuario(int id)
        {
            try
            {
                var user = services.GetUsuarioById(id);
                var newU = normalizar.changePass(user);
                return View(newU);
            }
            catch
            {
                return RedirectToAction("PantallaP","Libros", new {id=id});
            }
        }

        [HttpPost]
        public ActionResult EditarUsuario(newPassword newPassword)
        {
            int id = newPassword.id;
            try
            {
                if(newPassword != null)
                {
                    if(newPassword.passI == newPassword.passII)
                    {
                        var user = services.GetUsuarioById(id);
                        var actUser=normalizar.norEditUser(newPassword, user);
                        if (services.Update(actUser))
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
            }
            catch
            {

            }
            return RedirectToAction("PantallaP", "Libros", new { id = id });
        }

    }
}