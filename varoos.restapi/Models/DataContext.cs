using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace varoos.restapi.Models
{
    public abstract class DataContext
    {
        public void AddStation(Station station)
        {

        }
        public void AddUser(Person person)
        {
            var people = GetAllPeople();

            if (!people.Any(x => x.Name == person.Name))
            {
                person.Id = people.Count == 0 ? 0 : people.Max(x => x.Id) + 1;
                people.Add(person);
            }
            SavePeople(people);
        }

        public void DeleteUser(int id)
        {
            var people = GetAllPeople();

            if (people.Any(x => x.Id == id))
                people.Remove(people.First(x => x.Id == id));

            SavePeople(people);
        }

        public abstract List<Person> GetAllPeople();
        public abstract void SavePeople(List<Person> people);
    }
}