using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public static class ConvertController
    {
        public static bool Convert(string address)
        {
            //получаем коллекцию строк из файла
            IEnumerable<string> stringCollection = Reader.ReadStringFromfile(address);
            //создаём лист для экспорта
            //StudentList list = new StudentList();
            List<StudentSerializable> list = new List<StudentSerializable>();

            if (stringCollection.Count<string>() < 1) return false;

            //читаем строку из коллекции в объект типа студент
            foreach (string student in stringCollection)
            {
                string[] delimeted = student.Split(';');

                StudentSerializable newStudent = new StudentSerializable(
                delimeted[0], delimeted[1], delimeted[2],
                delimeted[3], delimeted[4], System.Convert.ToInt32(delimeted[5]),
                System.Convert.ToInt32(delimeted[6]), System.Convert.ToInt32(delimeted[7]),
                 delimeted[8]);

                //newStudent.firstName = delimeted[0];
                //newStudent.lastName = delimeted[1];
                //newStudent.univercity = delimeted[2];
                //newStudent.faculty = delimeted[3];
                //newStudent.profession = delimeted[4];
                //newStudent.age = System.Convert.ToInt32(delimeted[5]);
                //newStudent.cource = System.Convert.ToInt32(delimeted[6]);
                //newStudent.group = System.Convert.ToInt32(delimeted[7]);
                //newStudent.city = delimeted[8];

                Console.WriteLine(newStudent.ToString());

                list.Add(newStudent);
            }

            //Console.WriteLine(list.Count);

            if (XMLWriter.ExportToXML(address, list)) return true;
            else return false;
        }
    }
}
