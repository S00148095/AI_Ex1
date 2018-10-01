using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            Female female = new Female("Female");
            Male male = new Male("Male");
            Person paul = new Person(null, null, male, new List<Person>() , new List<Person>());
            Person bill = new Person(null, null, male, new List<Person>(), new List<Person>());
            Person mary = new Person(null, null, female, new List<Person>(), new List<Person>());
            Person fred = new Person(mary, paul, male, new List<Person>(), new List<Person>());
            Person victoria = new Person(null, null, female, new List<Person>(), new List<Person>());
            Person jemima = new Person(mary, paul, female, new List<Person>(), new List<Person>());
            paul.Brothers.Add(fred);
            fred.Brothers.Add(paul);
            mary.Sisters.Add(victoria);
            victoria.Sisters.Add(mary);
            List<Person> people = new List<Person>();
            people.Add(paul);
            people.Add(bill);
            people.Add(mary);
            people.Add(fred);
            people.Add(victoria);
            people.Add(jemima);

            bool isParent = IsParent(people, paul, fred);
            Console.WriteLine(isParent);
            bool isSibling = IsSibling(people, paul, jemima);
            Console.WriteLine(isSibling);
            bool isBrother = IsBrother(people, fred, jemima);
            Console.WriteLine(isBrother);
            Console.ReadKey();
        }

        private static bool IsBrother(List<Person> people, Person p1, Person p2)
        {
            if (IsSibling(people, p1, p2) && p2.Gender.Name == "Male") return true;
            else return false;
        }

        private static bool IsSibling(List<Person> people, Person p1, Person p2)
        {
            var p1Father = (from p in people
                            where p == p1
                            select p.Father).ToList()[0];
            var p1Mother = (from p in people
                            where p == p1
                            select p.Mother).ToList()[0];
            var p2Father = (from p in people
                            where p == p2
                            select p.Father).ToList()[0];
            var p2Mother = (from p in people
                            where p == p2
                            select p.Mother).ToList()[0];
            if (p2Father == p1Father && p2Father!=null && p1Father!=null || p2Mother == p1Mother && p2Mother != null && p1Mother != null) return true;
            else return false;
        }

        private static bool IsParent(List<Person> people, Person p1, Person p2)
        {
            var p2Father = (from p in people
                           where p == p2
                           select p.Father).ToList()[0];
            var p2Mother = (from p in people
                           where p == p2
                           select p.Mother).ToList()[0];
            if (p2Father == p1 || p2Mother == p1) return true;
            else return false;
        }
    }

    class Person
    {
        public Person(Person mother, Person father, Gender gender, List<Person> brothers, List<Person> sisters)
        {
            Mother = mother;
            Father = father;
            Gender = gender;
            Brothers = brothers;
            Sisters = sisters;
        }

        public Person Mother { get; set; }
        public Person Father { get; set; }
        public Gender Gender { get; set; }
        public List<Person> Brothers { get; set; }
        public List<Person> Sisters { get; set; }
    }

    class Gender {
        public Gender(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
    class Male : Gender
    {
        public Male(string name) : base(name)
        {
        }
    }
    class Female : Gender
    {
        public Female(string name) : base(name)
        {
        }
    }
}
