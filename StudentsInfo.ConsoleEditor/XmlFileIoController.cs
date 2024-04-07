using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace StudentsInfo
{
    public class XmlFileIoController
    {

        public void Save(DataSet dataSet, string fileName)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.Unicode;
            XmlWriter writer = null;
            try
            {
                writer = XmlWriter.Create(fileName, settings);
                WriteData(dataSet, writer);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        void WriteData(DataSet dataSet, XmlWriter writer)
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("StudentsInfo");
            WritePerson(dataSet.Person, writer);
            WriteStudents(dataSet.Students, writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
        }

        void WritePerson(IEnumerable<Person> collection, XmlWriter writer)
        {
            writer.WriteStartElement("PersonData");
            foreach (var inst in collection)
            {
                writer.WriteStartElement("Person");
                writer.WriteElementString("Id", inst.Id.ToString());
                writer.WriteElementString("Surname", inst.Surname);
                writer.WriteElementString("Po_Batkovi", inst.Po_Batkovi);
                writer.WriteValue(inst.Date_birth.ToShortDateString());
                writer.WriteElementString("Index_kod", inst.Index_kod.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        private void WriteStudents(IEnumerable<Students> collection, XmlWriter writer)
        {
            writer.WriteStartElement("StudentsData");
            foreach (var inst in collection)
            {
                writer.WriteStartElement("Students");
                writer.WriteElementString("Id", inst.Id.ToString());
                writer.WriteElementString("Number_group", inst.Number_group);
                writer.WriteValue( inst.Date_enrollment.ToShortDateString());
                writer.WriteValue( inst.Date_expulsion.ToShortDateString());
                int PersonId = inst.Person == null ? 0 : inst.Person.Id;
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }




        public void Load(DataSet dataSet, string fileName)
        {
            if (!File.Exists(fileName)) return;

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            using (XmlReader reader = XmlReader.Create(fileName, settings))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.Name)
                        {
                            case "Person":
                                ReadPerson(reader, dataSet.Person);
                                break;
                            case "Students":
                                ReadStudents(reader, dataSet);
                                break;
                        }
                    }
                }
            }
        }

        void ReadPerson(XmlReader reader, ICollection<Person> collection)
        {
            reader.ReadStartElement("Perosn");
            int id = reader.ReadElementContentAsInt();
            string Surname = reader.ReadElementContentAsString();
            string Name = reader.ReadElementContentAsString();
            string Po_Batkovi = reader.ReadElementContentAsString();
            int Index_kod=reader.ReadElementContentAsInt();
            DateTime Date_birth = (DateTime)reader.ReadElementContentAsObject();
            Person inst = new Person(Surname, Name, Po_Batkovi, Index_kod, Date_birth) { Id = id };
            collection.Add(inst);
        }


        void ReadStudents(XmlReader reader, DataSet dataSet)
        {
            Students inst = new Students();
            reader.ReadStartElement("Students");
            inst.Id = reader.ReadElementContentAsInt();
            inst.Number_group = reader.ReadElementContentAsString();
            inst.Date_enrollment = (DateTime)reader.ReadElementContentAsObject();
            inst.Date_expulsion = (DateTime)reader.ReadElementContentAsObject();
            int PersoId = reader.ReadElementContentAsInt();
            inst.Person = dataSet.Person.FirstOrDefault(e => e.Id == PersoId);
            dataSet.Students.Add(inst);
        }

    }
}

