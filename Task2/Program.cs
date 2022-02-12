using System;
namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Presenter presenter = new Presenter();
            while (true)
            {
                string input = Console.ReadLine();
                // Если ввели Run значит нужно запускать событие
                if (input == "Run")
                {
                    presenter.InvokeRun();
                }
            }
        }
    }
    public delegate void EventRun();
}
