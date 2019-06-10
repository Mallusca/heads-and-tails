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

            WelcomeInTheGame();
            newGameKeyInfo = Console.ReadKey(true);
            if (newGameKeyInfo.Key == ConsoleKey.Escape)
            {
                Delay();
                return;
            }
            newGameKeyInfo = KeyCheck(newGameKeyInfo);
            while (newGameKeyInfo.Key == ConsoleKey.Enter)
            {
                do
                {
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
                    else if (predictedResultKeyInfo.Key == ConsoleKey.Escape)
                    {
                        Delay();
                        return;
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

                Delay();

                Console.WriteLine();
                Console.WriteLine();

                string resultMessage = predictedResult == result ? "Ура, вы угадали!" : "Вы не угадали, попробуйте ещё!";
                Console.WriteLine(resultMessage);

                PlayAgain();
                newGameKeyInfo = Console.ReadKey(true);
                if (newGameKeyInfo.Key == ConsoleKey.Escape)
                {
                    Delay();
                    return;
                }
                newGameKeyInfo = KeyCheck(newGameKeyInfo);
            }
        }

        private static void PlayAgain()
        {
            Console.WriteLine();
            Console.WriteLine("Нажмите Enter для начала новой игры");
            Console.WriteLine("");
            Console.WriteLine();
        }

        private static void WelcomeInTheGame()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Игра Орёл и Решка, от \"GOR\"! ");
            Console.WriteLine("Для начала новой игры нажмите клавишу Enter.");
            Console.WriteLine("Для выхода нажмите клавишу Esc.");
            Console.WriteLine("------------------------------------------");

            Console.WriteLine();
        }

        private static ConsoleKeyInfo KeyCheck(ConsoleKeyInfo newGameKeyInfo)
        {
            while (newGameKeyInfo.Key != ConsoleKey.Enter && newGameKeyInfo.Key != ConsoleKey.Escape)
                newGameKeyInfo = Console.ReadKey(true);
            return newGameKeyInfo;
        }

        private static void Delay()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write(".");
                Thread.Sleep(300);
            }
        }
    }
}
