using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Model;

namespace Videotheque.Service
{
    class PersonService
    {
        private static PersonService _instance;
        private VideothequeDbContext context;

        private PersonService()
        {
            initialize();
        }
        private async void initialize()
        {
            context = await VideothequeDbContext.getInstance();
        }


        public static PersonService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PersonService();
            }
            return _instance;
        }

        public List<Person> GetPersons()
        {
            return context.Persons.ToList();
        }
        public Person findByPersonId(int PersonId)
        {
            return context.Persons.Find(PersonId);
        }
        public Person findByName(string firstName, string lastName)
        {
            List<Person> Persons =  context.Persons
                .Where((p) => p.FirstName.Equals(firstName) && p.LastName.Equals(lastName)).ToList();
            if (Persons == null || Persons.Count == 0)
                return null;
            return Persons.First();
        }
        public void Save(Person p)
        {
            if (p.PersonId == 0)
            {
                if (this.findByPersonId(p.PersonId) != null)
                    return;
                context.Persons.Add(p);
            }
            else
            {
                if (this.findByPersonId(p.PersonId) == null)
                    return;
                context.Persons.Update(p);
            }
            context.SaveChangesAsync();
        }
        public void Delete(Person p)
        {
            context.Remove(p);
            context.SaveChangesAsync();
        }
    }
}
