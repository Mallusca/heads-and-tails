using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace HeadsAndTails
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;
            int predictedResult;
            int result;
            Random rand = new Random();
            do
            {
                result = rand.Next(1, 3);
                Console.WriteLine("Хотите сыграть в Орёл и Решку? Нажми Enter...");
                key = Console.ReadKey();
                Console.WriteLine("Угадай результат: нажми 1 если думаешь, что будет решка, 2 если будет орёл.");
                predictedResult = int.Parse(Console.ReadLine());
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("...");
                    Thread.Sleep(1000);
                }

                if(result == predictedResult)
                {
                    Console.WriteLine("Победа");
                }
                else
                {
                    Console.WriteLine("Поражение");
                }
            }
            while (key.Key == ConsoleKey.Enter);
            {

            }
        }
    }
}
