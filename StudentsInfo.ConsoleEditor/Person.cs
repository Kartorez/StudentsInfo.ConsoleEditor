using System;
namespace StudentsInfo
{
    public class Person : Entity
    {
        public string Name;
        public int Index_kod;
        public string Surname;
        public string Po_Batkovi;
        public DateTime Date_birth;



        public Person(string Surname, string Name, string Po_Batkovi, int Index_kod, DateTime Date_birth)
        {
            this.Surname = Surname;
            this.Name = Name;
            this.Po_Batkovi = Po_Batkovi;
            this.Date_birth = Date_birth;
            this.Index_kod = Index_kod;
        }
        public Person() { }

        public Person(string surname, string name, string po_Batkovi, DateTime date_birth)
        {
            Surname = surname;
            Name = name;
            Po_Batkovi = po_Batkovi;
            Date_birth = date_birth;
        }

        public override string ToString()
        {
            return $"Прізвище:{Surname}  Ім'я:{Name} По батькові:{Po_Batkovi} Дата народження:{Date_birth} Ідентифікаційний номер:{Index_kod}";
        }
    }
}
