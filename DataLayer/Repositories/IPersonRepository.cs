using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{

    // this interface specify the some Rules
    // about Opreation that we should do in Person table
    public interface IPersonRepository
    {
        List<Person> GetAllPersons();
        Person GetPersonById(int perosnid);
        void InsertPerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(Person perosnid);
        void DeletePerson(int personid);
        void DbSave();
    }
}
