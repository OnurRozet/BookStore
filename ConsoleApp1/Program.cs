using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DateTime date1 = new DateTime();
            date1 =DateTime.Parse(DateTime.Today.ToString("d"));
            Console.WriteLine(date1);
        }
    }
}
