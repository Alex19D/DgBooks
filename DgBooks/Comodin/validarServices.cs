using DgBooksDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DgBooks.Comodin
{
    public class validarServices
    {
        public bool ValidPersona(Persona persona)
        {
            bool resp = false;
            if(persona.strNombrePersona!=null && persona.strApellidoM!=null && persona.strApellidoM!=null && persona.dtFechaNacimiento != null)
            {
                resp = true;
            }
            return resp;
        }

        public bool ValidUsuario(Usuario usuario)
        {
            bool resp=false;
            if (usuario.strNombreUsuario != null && usuario.strContraseña!=null && usuario.strCorreo!=null)
            {
                resp = true;
            }
            return resp;
        }
    }
}