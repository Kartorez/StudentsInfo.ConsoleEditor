using System;
namespace StudentsInfo
{
    public class Students : Entity
    {
        public string Number_group;
        public DateTime Date_enrollment;
        public Person Person;
        public DateTime Date_expulsion;
        public override string ToString()
        {
            return $"{Id},{Person},{Number_group},{Date_enrollment}{Date_expulsion}";
        }

        public Students(Person Person, string Number_group, DateTime Date_enrollment, DateTime Date_expulsion)
        {
            this.Person = Person;
            this.Number_group = Number_group;
            this.Date_enrollment = Date_enrollment;
            this.Date_expulsion = Date_expulsion;
        }
        public Students() { }
    }
}
