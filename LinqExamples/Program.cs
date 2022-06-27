using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Linq Examples");

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

            var result = people.Where(p => p.Height >= 178);
            var resul1 = people.Where(p => p.Gender == Gender.F && p.Salary.HasValue && p.Salary.Value >= 30000);

            var result2 = people.FirstOrDefault(p => p.Gender == Gender.F);
            int maxH = people.Max(p => p.Height);
            var result3 = people.FirstOrDefault(p => p.Height == maxH);

            //Calcola la media degli stipendi
            var result4 = people
                .Where(p => p.Salary.HasValue)
                .Average(p => p.Salary);

            //Quante sono le donne?
            var result5 = people.Count(p => p.Gender == Gender.F);

            //Se mettessi in fila tutte le persone, una sopra l'altra, quale sarebbe l'altezza totale?
            var result6 = people.Sum(p => p.Height);


            //C'è almeno un uomo che guadagna almeno 50000 euro ?
            var result7 = people.Any(p => p.Gender == Gender.M && p.Salary.HasValue && p.Salary.Value >= 50000);

            //Quale è l'ultima persona della lista?
            var result8 = people.LastOrDefault();

            //Quale è l'ultima donna?
            var result9 = people.LastOrDefault(p => p.Gender == Gender.F);


            //E la prima?
            var result10 = people.FirstOrDefault();

            //Abbiamo specificato lo stipendio per tutte le persone??
            var result11 = people.All(p => p.Salary.HasValue);

            //Dammi la lista di persone, riordinate per altezza crescente
            var result12 = people.OrderBy(p => p.Height);

            //Dammi la lista di persone, riordinate per altezza decrescente
            var result13 = people.OrderByDescending(p => p.Height);
            
            //Dammi la lista di persone, ordinata per cognome-nome
            var result14 = people.OrderBy(p => p.LastName).ThenBy(p => p.FirstName);

            //Dammi la lista di persone, ordinata per cognome. A parità di cognome, ordina per nome discente
            var result15 = people.OrderBy(p => p.LastName).ThenByDescending(p => p.FirstName);

            //Dammi la lista di altezze delle persone ORDINATE dal più piccolo al più grande
            var result16 = people
                .Select(p => p.Height)
                .OrderBy(i => i);

            //Dammi la lista nome-cognome delle persone, ordinate per cognome (a parità ordina per nome)
            var result17 = people
                .Select(p => new FirstNameLastName { FirstName = p.FirstName, LastName = p.LastName })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName);

            var result18 = people
                .Select(p => new { FN = p.FirstName, LN = p.LastName })
                .OrderBy(x => x.LN)
                .ThenBy(x => x.FN);

            var p = people.FirstOrDefault(x => x.FirstName == "Davide");
            var result19 = people.Contains(p);

            //Dammi i primi due elementi della lista
            var result20 = people.Take(2);

            //Dammi i secondi due elementi della lista
            var result21 = people.Skip(2).Take(2);

            //Dammi i terzi due elementi della lista
            var result22 = people.Skip(2 * 2).Take(2);

            //Dammi la n-esima pagina di k elementi della lista
            int n = 5;  //sesta pagina 
            int pageSize = 10;
            var result23 = people.Skip(n * pageSize).Take(pageSize);

            //Dammi la lista di persone rigirata al contrario
            var result24 = people.Reverse();
            Console.ReadLine();
        }
    }
}
