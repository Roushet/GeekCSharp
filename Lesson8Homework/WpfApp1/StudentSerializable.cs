using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    [Serializable]
    public class StudentSerializable
    {
        public string firstName;
        public string lastName;
        public string univercity;
        public string faculty;
        public string profession;
        public int age;
        public int cource;
        public int group;
        public string city;

        public StudentSerializable() { }

        public StudentSerializable
            (
             string firstName, string lastName, string univercity,
             string faculty, string profession,
             int age, int cource, int group,
             string city
            )
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.univercity = univercity;
            this.faculty = faculty;
            this.profession = profession;
            this.age = age;
            this.cource = cource;
            this.group = group;
            this.city = city;
        }

        public override string ToString()
        {
            return String.Format($"{firstName} {lastName} из \"{univercity}\", " +
                $"{faculty}, кафедра \"{profession}\", {age} лет, курс {cource}, " +
                $"группа {group}, из города {city}");
        }
    }
}
