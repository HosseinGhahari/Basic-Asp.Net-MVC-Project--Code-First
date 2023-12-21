using DataLayer.Context;
using DataLayer.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services
{

    // in this section we inheritance from our interface
    // then implements the rules with some functions

    // here to avoid direct access to context and database 
    // we do constructor injection and everytime we wanna 
    // accesss to person class we have to give it the context there
    // this way we don't need to make a new context with every new Repository
    // also we do Unit of work method for that 


    // but in the end for this specific practices i use Generic Repository
    // for having control on person table
    public class PersonRepository : IPersonRepository
    {

        private OurContext db;
        public PersonRepository(OurContext context)
        {
            db = context;
        }

        public List<Person> GetAllPersons()
        {
            return db.Persons.ToList();
        }

        public Person GetPersonById(int perosnid)
        {
            return db.Persons.Find(perosnid);
        }

        public void InsertPerson(Person person)
        {
            db.Persons.Add(person);
        }

        public void UpdatePerson(Person person)
        {
            db.Entry(person).State = EntityState.Modified;
        }

        public void DeletePerson(Person person)
        {
            db.Entry(person).State = EntityState.Deleted;
        }

        public void DeletePerson(int personid)
        {
            var person = GetPersonById(personid);
            DeletePerson(person);
        }

        public void DbSave()
        {
            db.SaveChanges();
        }
    }
}
