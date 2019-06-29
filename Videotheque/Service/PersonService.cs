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
            return context.Persons
                .OrderBy(p => p.LastName + p.FirstName)
                .Include(p => p.PersonMedias)
                    .ThenInclude(pm => pm.Media)
                .ToList();
        }
        public List<Person> GetPersonsNotFriends()
        {
            return context.Persons
                .Where(p => p.Type != TypePerson.Friend)
                .OrderBy(p => p.LastName + p.FirstName)
                .Include(p => p.PersonMedias)
                    .ThenInclude(pm => pm.Media)
                .ToList();
        }
        public Person findByPersonId(int PersonId)
        {
            return context.Persons.Find(PersonId);
        }
        public Person findPersonByName(string firstName, string lastName)
        {
            List<Person> Persons = context.Persons
                .Where(p => p.Type != TypePerson.Friend)
                .Where((p) => p.FirstName.Equals(firstName) && p.LastName.Equals(lastName))
                .Include(p => p.PersonMedias)
                    .ThenInclude(pm => pm.Media)
                    .ToList();
            if (Persons == null || Persons.Count == 0)
                return null;
            return Persons.First();
        }

        public List<Person> findPersonWithName(string WithNameLike)
        {
            if (WithNameLike == null || "".Equals(WithNameLike))
                return this.GetPersons();
            return context.Persons
                .Where(p => p.Type != TypePerson.Friend)
                .Where(p => p.FirstName.Contains(WithNameLike) || p.LastName.Contains(WithNameLike))
                .Include(p => p.PersonMedias)
                    .ThenInclude(pm => pm.Media)
                .OrderBy(p => p.LastName + p.FirstName)
                .ToList();
        }
        public List<Person> findPersonByFunction(PersonMediaFunction? WithFunction)
        {
            if (WithFunction == null || WithFunction == PersonMediaFunction.Unknown)
                return this.GetPersons();
            return context.Persons
                .Where(p => p.Type != TypePerson.Friend)
                .Where(p => p.PersonMedias.Any(pm => pm.Function == WithFunction))
                .Include(p => p.PersonMedias)
                    .ThenInclude(pm => pm.Media)
                .OrderBy(p => p.LastName + p.FirstName)
                .ToList();
        }
        public List<Person> findPersonByNameAndFunction(string WithNameLike, PersonMediaFunction? WithFunction)
        {
            if (WithFunction == null || WithFunction == PersonMediaFunction.Unknown)
                return this.findPersonWithName(WithNameLike);
            if (WithNameLike == null || "".Equals(WithNameLike))
                return this.findPersonByFunction(WithFunction);
            return context.Persons
                .Where(p => p.Type != TypePerson.Friend)
                .Where(p => p.FirstName.Contains(WithNameLike) || p.LastName.Contains(WithNameLike))
                .Where(p => p.PersonMedias.Any(pm => pm.Function == WithFunction))
                .Include(p => p.PersonMedias)
                    .ThenInclude(pm => pm.Media)
                .OrderBy(p => p.LastName + p.FirstName)
                .ToList();
        }

        public List<Person> GetFriends()
        {
            return context.Persons
                .Where(p => p.Type == TypePerson.Friend)
                .OrderBy(p => p.LastName + p.FirstName)
                .Include(p => p.PersonMedias)
                    .ThenInclude(pm => pm.Media)
                .ToList();
        }
        public List<Person> findFriendWithName(string WithNameLike)
        {
            if (WithNameLike == null || "".Equals(WithNameLike))
                return this.GetPersons();
            return context.Persons
                .Where(p => p.Type == TypePerson.Friend)
                .Where(p => p.FirstName.Contains(WithNameLike) || p.LastName.Contains(WithNameLike))
                .Include(p => p.PersonMedias)
                    .ThenInclude(pm => pm.Media)
                .OrderBy(p => p.LastName + p.FirstName)
                .ToList();
        }

        public Task Save(Person p)
        {
            Task t = Task.Run(() =>
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
                context.SaveChanges();
            });
            return t;
        }
        public Task Save(Person p, Action loading)
        {
            Task t = this.Save(p);
            if (loading != null)
                loading();
            return t;
        }
        public Task Delete(Person p)
        {
            Task t = Task.Run(() => {
                context.Remove(p);
                context.SaveChanges();
            });
            return t;
        }
        public Task Delete(Person p, Action loading)
        {
            Task t = this.Delete(p);
            if (loading != null)
                loading();
            return t;
        }
    }
}
