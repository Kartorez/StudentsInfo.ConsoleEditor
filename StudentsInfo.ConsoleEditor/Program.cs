using System;

namespace StudentsInfo.ConsoleEditor
{
    class Program
    {
        static DataContext dataContext;
        static Editor editor;

        static void Main(string[] args)
        {
            Console.Title = "StudentsInfo.ConsoleEditor (Матвієнко Б. В.)";
            Settings.SetConsoleParam();
            Console.WriteLine("Реалізація класів для предметної області");

            dataContext = new DataContext();
            editor = new Editor(dataContext);
            editor.Run();

            Console.ReadKey(true);
        }

    }
}
