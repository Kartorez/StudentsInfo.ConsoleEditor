using System.Collections.Generic;

namespace StudentsInfo
{
    public class DataSet
    {
        public List<Person> Person { get; private set; }
        public List<Students> Students { get; private set; }

        public DataSet()
        {
            Person = new List<Person>();
            Students = new List<Students>();
        }
    }
}

