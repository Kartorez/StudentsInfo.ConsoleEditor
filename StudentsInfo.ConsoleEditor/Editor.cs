using System;
using System.Collections.Generic;

namespace StudentsInfo
{

    public partial class Editor
    {

        private DataContext dataContext;

        IEnumerable<Person> sortingPerson;
        IEnumerable<Students> sortingStudents;

        public Editor(DataContext dataContext)
        {
            this.dataContext = dataContext;
            sortingPerson = dataContext.Person;
            sortingStudents = dataContext.Students;
            IniCommandsInfo();
        }

        private CommandInfo[] commandsInfo;

        private void IniCommandsInfo()
        {
            commandsInfo = new CommandInfo[] {
                new CommandInfo("вийти", null),
                new CommandInfo("створити тестові дані",  dataContext.CreateTestingData),
                new CommandInfo("зберегти дані",  dataContext.Save),
                new CommandInfo("додати запис про Особу", AddPerson),
                new CommandInfo("додати запис про Студента", AddStudents),
                new CommandInfo("видалити запис про Особу", RemovePerson),
                new CommandInfo("видалити запис про Студента", RemoveStudents),
                new CommandInfo("видалити усі записи", dataContext.Clear),
                new CommandInfo("сортувати осіб за Прізвищем", SortPersonBySurname),
                new CommandInfo("сортувати осіб за Індентифікаційним номером", SortPersonByIndex_kod),
                new CommandInfo("сортувати осіб за Датою народження", SortPersonByDate_birth),
                new CommandInfo("сортувати осіб за Прізвищем", SortPersonBySurname),
                new CommandInfo("сортувати студентів за номером групи", SortPersonByNumber_group)
,
                            };
        }
       /* public void iRun()
        {
            dataContext.Load();
            while (true)
            {
                Console.Clear();
                OutData();
                Console.WriteLine();
                ShowCommandsMenu();
                Command command = EnterCommand();
                if (command == null)
                {
                    return;
                }
                command();
            }
       
        }*/
        public void Run()
        {
            
            while (true)
            {OutData();
               Console.Clear();
                OutData();
                Console.WriteLine();
                ShowCommandsMenu();
                Command command = delegate { };
                try
                {
                    command = EnterCommand();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (command == null)
                {
                    return;
                }
                try
                {
                    command();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void ShowCommandsMenu()
        {
            Console.WriteLine("  Список команд меню:");
            for (int i = 0; i < commandsInfo.Length; i++)
            {
                Console.WriteLine("\t{0,2} - {1}",
                    i, commandsInfo[i].name);
            }
        }

        private Command EnterCommand()
        {
            Console.WriteLine();
            int number = Entering.EnterInt32(
                "Введіть номер команди меню");
            return commandsInfo[number].command;
        }
    }
}
