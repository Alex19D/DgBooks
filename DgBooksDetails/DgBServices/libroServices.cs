using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DgBooksDB;

namespace DgBooksDetails.DgBServices
{
    public class libroServices
    {
        public List<Libro> GetLibros() 
        { 
            List<Libro> libros = new List<Libro>();

            try
            {
                using(var context=new DgBooksEntities())
                {
                    libros = context.Libro.ToList();
                }
            }
            catch(Exception ex)
            {
                string err = ex.Message;
            }

            return libros;
        }

        public Libro GetLibroById(int id)
        {
            Libro libro = new Libro();
            try
            {
                using(var context= new DgBooksEntities())
                {
                    libro = context.Libro.FirstOrDefault(p => p.intIdLibor == id);
                }
                if(libro == null)
                {
                    libro.intIdLibor = 0;
                }
            }
            catch(Exception ex)
            {
                string err = ex.Message;
            }
            return libro;
        }
    }
}
