using System;
using System.Linq;

namespace StudentsInfo
{
    partial class Editor
    {

        private void OutData()
        {
            OutPersonData();
            OutStudentsData();
        }

        private void OutPersonData()
        {
            Console.WriteLine("  Список Осіб:");
            foreach (var obj in sortingPerson)
            {
                Console.WriteLine($"ID:{obj.Id}    Прізвище:{obj.Surname}\n\tІм'я:{obj.Name}\n\tПо батькові:{obj.Po_Batkovi}\n\tДата народження:{obj.Date_birth}\n");
            }
        }
        private void OutStudentsData()
        {
            Console.WriteLine("\n  Список Студентів:");
            foreach (var obj in sortingStudents)
            {

                Console.WriteLine($"ID:{obj.Id}    Прізвище:{obj.Person.Surname}\n\tім'я:{obj.Person.Name}\n\tПо батькові:{obj.Person.Po_Batkovi}\n\tНомер групи:{obj.Number_group}\n\tДата зарахування:{obj.Date_enrollment}\n\tДата відрахування:{obj.Date_expulsion}\n");
            }
        }

        public void AddPerson()
        {
            Person inst = new Person();
            inst.Surname = Entering.EnterString("Прізвище");
            inst.Name = Entering.EnterString("Ім'я");
            inst.Po_Batkovi = Entering.EnterString("По батькові");
            inst.Index_kod = Entering.EnterInt32("Індентифікаційний код");
            inst.Date_birth = Entering.EnterDate("Дата народження");
            inst.Id = dataContext.Person.Select(e => e.Id).Max() + 1;
            dataContext.Person.Add(inst);
        }

        public void AddStudents()
        {
            Students inst = new Students();
            inst.Person = SelectPersonSurname();
            inst.Person = SelectPersonName();
            inst.Person = SelectPersonPo_Batkovi();
            inst.Number_group = Entering.EnterString("Номер групи");
            inst.Date_enrollment = Entering.EnterDate("Дата зарахування");
            inst.Date_expulsion = Entering.EnterDate("Дата відрахування");
            inst.Id = dataContext.Students.Select(e => e.Id).Max() + 1;
            dataContext.Students.Add(inst);
        }
        private Person SelectPersonName()
        {
            string PersonName = Entering.EnterString("Ім'я");
            return dataContext.Person.First(e => e.Name == PersonName);
        }
        private Person SelectPersonSurname()
        {
            string PersonSurname = Entering.EnterString("Прізвище");
            return dataContext.Person.First(e => e.Surname == PersonSurname);
        }
        private Person SelectPersonPo_Batkovi()
        {
            string PersonPo_Batkovi = Entering.EnterString("По батькові");
            return dataContext.Person.First(e => e.Po_Batkovi == PersonPo_Batkovi);
        }

        public void RemovePerson()
        {
            int id = Entering.EnterInt32("Введіть числовий ідентифікатор особи");
            Person inst = dataContext.Person.FirstOrDefault(e => e.Id == id);
            dataContext.Person.Remove(inst);
        }

        public void RemoveStudents()
        {
            int id = Entering.EnterInt32("Введіть числовий ідентифікатор Студента");
            Students inst = dataContext.Students.FirstOrDefault(e => e.Id == id);
            dataContext.Students.Remove(inst);
        }
        private void SortPersonBySurname()
        {
            sortingPerson = sortingPerson.OrderBy(e => e.Surname);
        }
        private void SortPersonByIndex_kod()
        {
            sortingPerson = sortingPerson.OrderBy(e => e.Index_kod);
        }
        private void SortPersonByDate_birth()
        {
            sortingPerson = sortingPerson.OrderBy(e => e.Date_birth);
        }
        private void SortPersonByNumber_group()
        {
            sortingStudents = sortingStudents.OrderBy(e => e.Number_group);
        }

    }
}