using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using DemoLibrary.Model;

namespace DemoLibrary.DataAccess
{
    public class DemoDataAccess : IDataAccess
    {
        private List<PersonModel> people = new();

        public DemoDataAccess()
        {
            people.Add(new PersonModel { Id = 1, FirstName = "John", LastName = "Doe" });
            people.Add(new PersonModel { Id = 2, FirstName = "Jane", LastName = "Smith" });
            people.Add(new PersonModel { Id = 3, FirstName = "Sam", LastName = "Brown" });
        }

        public List<PersonModel> GetPeople()
        {
            return people;
        }

        public PersonModel GetPersonById(int id)
        {
            return people.FirstOrDefault(p => p.Id == id);
        }

        public PersonModel InsertPerson(string firstName, string lastName)
        {
            var p = new PersonModel
            {
                FirstName = firstName, LastName = lastName,
                Id = people.Max(p => p.Id) + 1
            };
            people.Add(p);
            return p;
        }
    }
}