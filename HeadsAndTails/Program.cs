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
            ConsoleKeyInfo newGameKeyInfo;
            ConsoleKeyInfo predictedResultKeyInfo;
            int predictedResult = 0;
            int result = 0;
            Random rand = new Random();

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Игра Орёл и Решка, от \"GOR\"! ");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("Нажмите Enter для начала новой игры...");
            Console.WriteLine();
            newGameKeyInfo = Console.ReadKey();

            while (newGameKeyInfo.Key == ConsoleKey.Enter)
            {        
                do {
                    Console.WriteLine("Угадайте результат(нажмите соответствующую клавишу):");
                    Console.WriteLine("1 - Орел");
                    Console.WriteLine("2 - Решка");
                    Console.WriteLine();

                    predictedResultKeyInfo = Console.ReadKey();
                    //print key
                    Console.WriteLine();
                    
                    //break line
                    Console.WriteLine();

                    if (predictedResultKeyInfo.Key == ConsoleKey.D1)
                    {
                        predictedResult = 1;
                    }
                    else if (predictedResultKeyInfo.Key == ConsoleKey.D2)
                    {
                        predictedResult = 2;
                    }
                    else
                    {
                        predictedResult = -1;
                        Console.WriteLine("Неверная клавиша. Повторите Ввод.");
                        Console.WriteLine();
                    }

                } while (predictedResult == -1);

                // get result
                result = rand.Next(1, 3);

                for (int i = 0; i < 10; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(300);
                }

                Console.WriteLine();
                Console.WriteLine();

                string resultMessage = predictedResult == result ? "Ура, вы угадали!" : "Вы не угадали, попробуйте ещё!";
                Console.WriteLine(resultMessage);

                Console.WriteLine();
                Console.WriteLine("Нажмите Enter для начала новой игры...");
                Console.WriteLine();
                newGameKeyInfo = Console.ReadKey();
            }
            
        }
    }
}
