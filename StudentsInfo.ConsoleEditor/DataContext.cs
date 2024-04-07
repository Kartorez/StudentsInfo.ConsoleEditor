using System.Collections.Generic;
using System.Linq;
using System;

namespace StudentsInfo
{
    public class DataContext
    {

        readonly DataSet dataSet = new DataSet();

        public ICollection<Students> Students
        {
            get { return dataSet.Students; }
        }

        public ICollection<Person> Person
        {
            get { return dataSet.Person; }
        }

        XmlFileIoController xmlFileIoController = new XmlFileIoController();

        public static string fileName = "StudentsInfo.xml";

        public void Save()
        {
            xmlFileIoController.Save(dataSet, fileName);
        }

        public void Load()
        {
            xmlFileIoController.Load(dataSet, fileName);
        }

        public override string ToString()
        {
            return string.Concat("Інформація про \"Облік руху контингенту\"\n",
                Students.ToLineList("Студенти"),
                Person.ToLineList("Особи"));
        }

        public void Clear()
        {
            Students.Clear();
            Person.Clear();
        }

        public void CreateTestingData()
        {
            CreatePerson();
            CreateStudents();
        }

        private void CreatePerson()
        {
            Person.Add(new Person("Матвієнко", "Богдан", "Володимирович", 0251351315, new DateTime(2002, 08, 13)) { Id = 1 });
            Person.Add(new Person("Гула", "Максим", "Миколайович", 0551251715, new DateTime(2003, 08, 14)) { Id = 2 });
            Person.Add(new Person("Мазур", "Владислав", "Юрійович", 1612845515, new DateTime(2003, 01, 28) ) { Id = 3 });
            Person.Add(new Person("Ярошенко", "Павло", "Павлович", 1243584371, new DateTime(2003, 07, 27) ) { Id = 4 });
        }

        private void CreateStudents()
        {
            Students.Add(new Students(Person.FirstOrDefault(e => e.Id == 1), "3ОК3", new DateTime(2021,09,01), new DateTime(2023, 06, 30)) { Id = 1 });
            Students.Add(new Students(Person.FirstOrDefault(e => e.Id == 2), "3ОК3", new DateTime(2021, 09, 01), new DateTime(2023, 06, 30)) { Id = 2 });
            Students.Add(new Students(Person.FirstOrDefault(e => e.Id == 3), "3ОК3", new DateTime(2021, 09, 01), new DateTime(2023, 06, 30)) { Id = 3 });
            Students.Add(new Students(Person.FirstOrDefault(e => e.Id == 4), "3ОК3", new DateTime(2021, 09, 01), new DateTime(2023, 06, 30)) { Id = 4 });
        }
    }
}
