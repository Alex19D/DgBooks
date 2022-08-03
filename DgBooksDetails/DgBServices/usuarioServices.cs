using DgBooksDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DgBooksDetails.DgBServices
{
    public class usuarioServices
    {
        public List<Usuario> GetUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                using(var context = new DgBooksEntities())
                {
                    usuarios = context.Usuario.ToList();
                }
            }
            catch(Exception ex)
            {
                string err = ex.Message;
            }

            return usuarios;
        }

        public Usuario GetUsuarioById(int id)
        {
            Usuario usuario = new Usuario();
            try
            {
                using(var context = new DgBooksEntities())
                {
                    usuario = context.Usuario.FirstOrDefault(p=>p.intIdUsuario==id);
                }
            }
            catch(Exception ex)
            {
                string err = ex.Message;
            }

            return usuario;
        }

        public Usuario GetUsuarioByNameOrEmail(string User_Email)
        {
            Usuario usuario = new Usuario();
            try
            {
                using(var context=new DgBooksEntities())
                {
                    usuario = context.Usuario.FirstOrDefault(p => p.strCorreo == User_Email);
                    if (usuario == null)
                    {
                        usuario = context.Usuario.FirstOrDefault(p => p.strNombreUsuario == User_Email);
                    }
                }
            }
            catch(Exception ex)
            {
                string err = ex.Message;
            }
            return usuario;
        }

        public bool Insert(Usuario usuario)
        {
            bool resp = false;

            try
            {
                using(var context = new DgBooksEntities())
                {
                    context.Usuario.Add(usuario);
                    context.SaveChanges();
                }
                resp = true;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }

            return resp;
        }

        public bool Delete(int id)
        {
            bool resp = false;

            try
            {
                using(var context = new DgBooksEntities())
                {
                    Usuario usuario = context.Usuario.FirstOrDefault(p => p.intIdUsuario == id);
                    context.Usuario.Remove(usuario);
                    context.SaveChanges();
                }
                resp = true;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }

            return resp;
        }

        public bool Update(Usuario usuario)
        {
            bool resp = false;

            try
            {
                int id = usuario.intIdUsuario;
                using(var context = new DgBooksEntities())
                {
                    Usuario us = context.Usuario.FirstOrDefault(p => p.intIdUsuario == id);
                    us.strNombreUsuario=usuario.strNombreUsuario;
                    us.strCorreo = usuario.strCorreo;
                    us.strContraseña = usuario.strContraseña;
                    context.SaveChanges();
                }
                resp = true;
            }
            catch(Exception ex)
            {
                string err = ex.Message;
            }

            return resp;
        }
    }
}
