using DgBooksDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DgBooksDetails.DgBServices
{
    public class personaServices
    {
        public bool Insert(Persona persona)
        {
            bool resp = false;

            try
            {
                using (var context = new DgBooksEntities()) 
                {
                    context.Persona.Add(persona);
                    context.SaveChanges();
                }
                resp = true;
            }
            catch(Exception e)
            {
                string err = e.Message;
            }

            return resp;
        }

        public int GetUltimaPersona()
        {
            int id = 0;
            List<Persona> personas = new List<Persona>();
            try
            {
                using(var context = new DgBooksEntities())
                {
                    
                    Persona[] arrPersona = context.Persona.ToArray();
                    id = arrPersona[(arrPersona.Length)-1].intIdPersona;
                }

            }
            catch(Exception ex)
            {
                string err = ex.Message;
            }

            return id;
        }

        public bool Delete(int id)
        {
            try
            {
                using(var context = new DgBooksEntities())
                {
                    var persona = context.Persona.FirstOrDefault(x => x.intIdPersona == id);
                    context.Persona.Remove(persona);
                    context.SaveChanges();
                }
                return true;
            }
            catch(Exception ex)
            {
                string errMsg = ex.Message;
            }

            return false;
        }

        public Persona GetPersona(int id)
        {
            Persona persona = new Persona();
            try
            {
                using(var context = new DgBooksEntities())
                {
                    persona= context.Persona.FirstOrDefault(p=>p.intIdPersona==id);
                }
            }
            catch
            {

            }
            return persona;
        }
    }
}
