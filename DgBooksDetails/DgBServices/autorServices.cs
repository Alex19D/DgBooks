using DgBooksDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DgBooksDetails.DgBServices
{
    public class autorServices
    {
        public Autor GetAutor(int id)
        {
            Autor autor = new Autor();

            try
            {
                using(var context=new DgBooksEntities())
                {
                    autor = context.Autor.FirstOrDefault(p=>p.intIdAutor==id);
                }
            }
            catch
            {

            }

            return autor;
        }
    }
}
