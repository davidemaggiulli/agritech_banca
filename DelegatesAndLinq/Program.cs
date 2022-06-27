using System;
using System.Collections.Generic;

namespace DelegatesAndLinq
{
    internal class Program
    {
        delegate bool SearchFunc<T>(T person);
        delegate string TransformFunc(int a);

        static bool SearchByMilano(Person p)
        {
            return p.City == "Milano";
        }
        static bool SearchByBari(Person p)
        {
            return p.City == "Bari";
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Delegates - Linq Examples");
            
            IList<Person> people = new List<Person>();

            people.Add(new Person()
            {
                FirstName = "Davide",
                LastName = "Maggiulli",
                BirthDate = new DateTime(1987, 6, 27),
                City = "Imola",
                Gender = Gender.M,
                Height = 179,
                Salary = null
            });
            people.Add(new Person()
            {
                FirstName = "Emanuela",
                LastName = "Maggiulli",
                BirthDate = new DateTime(1984, 8, 20),
                City = "Castel S.Pietro",
                Gender = Gender.F,
                Height = 155,
                Salary = null
            });
            people.Add(new Person()
            {
                FirstName = "Martina",
                LastName = "Bettoni",
                BirthDate = new DateTime(2001, 8, 20),
                City = "Bari",
                Gender = Gender.F,
                Height = 170,
                Salary = 25000
            });
            people.Add(new Person()
            {
                FirstName = "Norberto",
                LastName = "Lesi",
                BirthDate = new DateTime(2000, 8, 20),
                City = "Bari",
                Gender = Gender.M,
                Height = 165,
                Salary = 24000
            });
            people.Add(new Person()
            {
                FirstName = "Pippo",
                LastName = "Pluto",
                BirthDate = new DateTime(1995, 8, 20),
                City = "Milano",
                Gender = Gender.U,
                Height = 175,
                Salary = 34000
            });
            people.Add(new Person()
            {
                LastName = "D'Avena",
                FirstName = "Cristina",
                BirthDate = new DateTime(1964, 7, 1),
                City = "Bologna",
                Gender = Gender.F,
                Height = 160,
                Salary = 120000
            });
            people.Add(new Person
            {
                Gender = Gender.U,
                FirstName = "Mario",
                LastName = "Rossi",
                BirthDate = new DateTime(1986, 1, 1),
                City = "Firenze",
                Height = 190,
                Salary = 50000
            });



            //IList<Person> result = new List<Person>();
            //foreach (Person person in people)
            //    if(person.City == "Bari")
            //        result.Add(person);

            //result = new List<Person>();
            //foreach (Person person in people)
            //    if (person.City == "Firenze")
            //        result.Add(person);
            var result = SearchPeopleByCity(people, "Bari");
            var resultWithDel = people.Search(SearchByBari);
            
            //Stampi

            var result1 = SearchPeopleByCity(people, "Firenze");
            //Stampi

            var result2 = SearchPeopleByCity(people, "Palermo");

            var result3 = SearchPeopleByCity(people, "Bari", "Firenze");

            var result4 = SearchPeopleByMinHeight(people, 170);


            var result5WithDel = people.Search((pippo) => pippo.Height >= 170);
            var result5 = SearchPeopleByHeightRange(people, 160,170);


            var milanoPeopole = people.Search(SearchByMilano);

            var result6 = GetFirstPersonByCity(people, "Milano");
            result6 = people.GetFirstOrDefault( p => p.City == "Milano");

            var result7 = GetFirstPersonByCity(people, "Roma");
            result7 = people.GetFirstOrDefault( p => p.City == "Roma");


            var result8 = GetFirstPersonByMinHeight(people, 170);
            result8 = people.GetFirstOrDefault( p => p.Height >= 170);


            //Dammi la prima donna alta almeno 160cm
            var result9 = people.GetFirstOrDefault(p => p.Gender == Gender.F && p.Height >= 160);

            //Dammi la lista di persone con stipendio specificato (not null)
            var result10 = people.Search(p => p.Salary.HasValue);


            var stringList = new List<string>
            {
                "Io",
                "Sono",
                "Una",
                "Lista",
                "Di",
                "Stringhe"
            };
            var intList = new List<int> { 1, 2, 3, 45, 6, 7 };
            var result12 = intList.GetFirstOrDefault( i => i >= 40);

            var result11 = stringList.GetFirstOrDefault(s => s.Length >= 3);
            var result13 = stringList.Search(s => s.Length >= 3 && s.Length <= 6);

            Console.ReadLine();
        }

        static IList<Person> SearchPeopleByCity(IList<Person> source, string city)
        {
            IList<Person> result = new List<Person>();
            foreach (Person person in source)
                if (person.City == city)
                    result.Add(person);
            return result;
        }

        static IList<Person> SearchPeopleByMinHeight(IList<Person> source, int minH)
        {
            IList<Person> result = new List<Person>();
            foreach (Person person in source)
                if (person.Height >= minH)
                    result.Add(person);
            return result;
        }

        static IList<Person> SearchPeopleByHeightRange(IList<Person> source, int minH, int maxH)
        {
            IList<Person> result = new List<Person>();
            foreach (Person person in source)
                if (person.Height >= minH && person.Height <= maxH)
                    result.Add(person);
            return result;
        }

        static IList<Person> SearchPeopleByCity(IList<Person> source, string city, string city1)
        {
            IList<Person> result = new List<Person>();
            foreach (Person person in source)
                if (person.City == city || person.City == city1)
                    result.Add(person);
            return result;
        }

        

        

        

        static bool SearchByMinHeight170(Person p)
        {
            return p.Height >= 170;
        }

        static Person GetFirstPersonByCity(IEnumerable<Person> source, string city)
        {
            foreach (var person in source)
                if (person.City == city)
                    return person;
            return null;
        }
        static Person GetFirstPersonByMinHeight(IEnumerable<Person> source, int minH)
        {
            foreach (var person in source)
                if (person.Height >= minH)
                    return person;
            return null;
        }

        

    }
}
