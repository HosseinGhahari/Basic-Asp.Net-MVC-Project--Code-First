using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Context
{
    // in this section we bring our context and we use it only once 
    // and when wanna use our context for every section we use unitofwork class
    // also if future if we wanna add new table we have to add it here to unitofwork

    public class UnitOfWork : IDisposable
    {
        OurContext db = new OurContext();

        private GenericRepository<Person> personrepository;

        public GenericRepository<Person> PersonRepository 
        {
            get
            {
                if (personrepository == null)
                {
                    personrepository = new GenericRepository<Person> (db);
                }

                return personrepository;
            }  
        }



        public void Dispose()
        {
            db.Dispose();  
        }
    }
}
