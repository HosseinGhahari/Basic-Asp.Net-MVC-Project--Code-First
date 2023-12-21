using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Context
{

    // in this class that we called it OurContext
    // indeed convert our class to table in sql server
    // and it inheritance from DbContext for converting

    // then with DbSet that is collection of all entities 
    // we can do stuff in database 

    public class OurContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

    }
}
