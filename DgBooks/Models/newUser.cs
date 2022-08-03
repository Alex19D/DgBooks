using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DgBooks.Models
{
    public class newUser
    {
        public int Id { get; set; }
        public string strNombrePersona { get; set; }
        public string strApellidoP { get; set; }
        public string strApellidoM { get; set; }
        public System.DateTime dtFechaNacimiento { get; set; }
        public string strNombreUsuario { get; set; }
        public string strCorreo { get; set; }
        public string strContraseña { get; set; }
        public string strConfirmContraseña { get; set; }
    }
}