using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class Person
    {
        private int _personId;
        private string _firstName;
        private string _lastName;
        private string _favoriteColour;
        private int _age;
        private bool _isWorking;

        public int PersonId
        {
            get { return _personId; }
            set { _personId = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string FavoriteColour
        {
            get { return _favoriteColour; }
            set { _favoriteColour = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public bool IsWorking
        {
            get { return _isWorking; }
            set { _isWorking = value; }
        }

        public Person(int pid, string firstname, string lastname, string fcolor, int age, bool working)
        {
            this._personId = pid;
            this._firstName = firstname;
            this._lastName = lastname;
            this._favoriteColour = fcolor;
            this._age = age;
            this._isWorking = working;
        }

        public void DisplayPersonInfo()
        {
            Console.WriteLine(PersonId + ": " + FirstName + " " + LastName + "'s favoite color is " + FavoriteColour);
        }

        public void ChangeFavoriteColour()
        {
            FavoriteColour = "White";
        }
        public int GetAgeInTenYears()
        {
            int age = Age + 10;
            return age;
        }
        public override string ToString()
        {
            // display all Person Object information as a list
            //return "PersonId: "+PersonId+"\nFirstName: "+ FirstName+"\nLastName: "+LastName+"\nFavoriteColour: " + FavoriteColour + "\nAge: " + Age+"\nIsWorking: "+ IsWorking ;
            string result = $"PersonId: {PersonId}\n";
            result += $"FirstName: {FirstName}\n";
            result += $"LastName: {LastName}\n";
            result += $"FavoriteColour: {FavoriteColour}\n";
            result += $"Age: {Age}\n";
            result += $"IsWorking: {IsWorking}";

            return result;
        }
    }

    public class Relation
    {
        public enum RelationType
        {
            Sister, Brother, Mother, Father
        }
        public static void ShowRelationShip(Person p1, Person p2)
        {
            if (p1.FirstName == "Gina" && p2.FirstName == "Mary")
            {
                Console.WriteLine("Relationship between Gina and Mary is: " + RelationType.Sister);
            }
            else if (p1.FirstName == "Ian" && p2.FirstName == "Mike")
            {
                Console.WriteLine("Relationship between Ian and Mike is: " + RelationType.Brother);
            }
        }

    }

    public class MainLab
    {
        public static void Main(string[] args)
        {
            Person p1 = new Person(1, "Ian", "Brooks", "Red", 30, true);
            Person p2 = new Person(2, "Gina", "James", "Green", 18, false);
            Person p3 = new Person(3, "Mike", "Briscoe", "Blue", 45, true);
            Person p4 = new Person(4, "Mary", "Beals", "Yellow", 28, true);

            p2.DisplayPersonInfo();
            Console.WriteLine(p3.ToString());
            p1.ChangeFavoriteColour();
            p1.DisplayPersonInfo();

            Console.WriteLine(p4.FirstName + " " + p4.LastName + "'s Age in 10 year is: " + p4.GetAgeInTenYears());

            //Relation relation1 = new Relation();
            //Relation relation2 = new Relation();
            Relation.ShowRelationShip(p2, p4);
            Relation.ShowRelationShip(p1, p3);

            List<Person> list = new List<Person>();
            list.Add(p1);
            list.Add(p2);
            list.Add(p3);
            list.Add(p4);

            double averageAge = list.Average(person => person.Age);
            Console.WriteLine("Average age is: " + averageAge);

            //shows only ages
            //int youngest = list.Min(person => person.Age); 
            //int oldest = list.Max(person => person.Age);

            //dosen't work......
            //list.OrderBy(person => person.Age);
            //string youngest = list.First().FirstName;
            //string oldest = list.Last().FirstName;
            //Console.WriteLine("The younget person is: " + youngest);
            //Console.WriteLine("The oldest person is: " + oldest);

            string youngestName = list.OrderBy(person => person.Age).First().FirstName;
            string oldestName = list.OrderBy(p => p.Age).Last().FirstName;
            Console.WriteLine("The younget person is: " + youngestName);
            Console.WriteLine("The oldest person is: " + oldestName);

            //List<Person> searchPeople = new List<Person>();
            //foreach(Person person in list)
            //{
            //    if (person.FirstName.StartsWith("M"))
            //    {
            //        searchPeople.Add(person);
            //    }
            //}

            List<Person> searchPeople = list.Where(p => p.FirstName.StartsWith("M")).ToList();

            foreach (Person person in searchPeople)
            {
                Console.WriteLine(person.ToString());
            }

            List<Person> likeBlue = list.Where(person => person.FavoriteColour == "Blue").ToList();

            foreach (Person person in likeBlue)
            {
                Console.WriteLine(person.ToString());
            }

        }
    }
}
