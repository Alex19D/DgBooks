using DgBooks.Models;
using DgBooksDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DgBooks.Comodin
{
    public class normalizarServices
    {
        public Persona normPersona(newUser user)
        {
            Persona persona = new Persona();

            try
            {
                persona.strApellidoM = user.strApellidoM;
                persona.strNombrePersona=user.strNombrePersona;
                persona.strApellidoP=user.strApellidoP;
                persona.dtFechaNacimiento=DateTime.Now;
            }
            catch(Exception ex)
            {
                string err = ex.Message;
            }

            return persona;
        }

        public Usuario normUsuario(newUser user)
        {
            Usuario usuario = new Usuario();
            try
            {
                usuario.strNombreUsuario = user.strNombreUsuario;
                usuario.strContraseña = user.strContraseña;
                usuario.strCorreo = user.strCorreo;
            }
            catch(Exception ex)
            {
                string err = ex.Message;
            }
            return usuario;
        }

        public newPassword changePass(Usuario usuario)
        {
            newPassword newPass = new newPassword();
            try
            {
                newPass.id = usuario.intIdUsuario;
                newPass.UserName = usuario.strNombreUsuario;
                newPass.Email = usuario.strCorreo;
                newPass.passI = usuario.strContraseña;
                newPass.passII = usuario.strContraseña;
            }
            catch(Exception ex)
            {
                newPass = null;
                string err = ex.Message;
            }
            return newPass;
        }

        public Usuario norEditUser(newPassword password, Usuario usuario)
        {
            try
            {
                usuario.strNombreUsuario = password.UserName;
                usuario.strCorreo = password.Email;
                usuario.strContraseña = password.passI;
            }
            catch(Exception ex)
            {
                string err = ex.Message;
            }
            return usuario;
        }
    }
}