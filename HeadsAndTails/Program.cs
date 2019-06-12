using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace HeadsAndTails
{
    class CreateResultMessageAndShow
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo newGameKeyInfo;
            int? prediction = 0;
            int predictedResult = 0;
            int calculatedResult = 0;
            Random rand = new Random();

            ShowWelcomeInTheGameMessage();

            newGameKeyInfo = ReadKey();

            while (newGameKeyInfo.Key == ConsoleKey.Enter)
            {
                prediction = GetPrediction();
                if (!prediction.HasValue)
                    break;

                predictedResult = prediction.Value;

                calculatedResult = rand.Next(1, 3);
                ShowLoading();

                Console.WriteLine();
                Console.WriteLine();

                CreateGameResultMessageAndShow(predictedResult, calculatedResult);

                ShowPlayAgainText();
                newGameKeyInfo = ReadKey();
            }

            ShowLoading();
        }

        private static void CreateGameResultMessageAndShow(int predictedResult, int calculatedResult)
        {
            string resultMessage = predictedResult == calculatedResult ? "Ура, вы угадали!" : "Вы не угадали, попробуйте ещё!";
            Console.WriteLine(resultMessage);
        }

        //Nullable type
        private static int? GetPrediction()
        {
            ConsoleKeyInfo predictedResultKeyInfo;
            int predictedResult = -1;

            do
            {
                Console.WriteLine("Угадайте результат(нажмите соответствующую клавишу):");
                Console.WriteLine("1 - Орел");
                Console.WriteLine("2 - Решка");
                Console.WriteLine();
                do
                {
                    predictedResultKeyInfo = Console.ReadKey(true);
                    if (predictedResultKeyInfo.Key != ConsoleKey.D1 && predictedResultKeyInfo.Key != ConsoleKey.D2 && predictedResultKeyInfo.Key != ConsoleKey.Escape) {
                        Console.WriteLine("Неверная клавиша. Повторите Ввод.");
                        Console.WriteLine();
                        //print key
                    }
                    else
                    {
                        break;
                    }
                }
                 while (predictedResultKeyInfo.Key != ConsoleKey.D1 && predictedResultKeyInfo.Key != ConsoleKey.D2 && predictedResultKeyInfo.Key != ConsoleKey.Escape);
                Console.WriteLine(predictedResultKeyInfo.KeyChar);              
                //break line
                Console.WriteLine();
                predictedResult = (int)predictedResultKeyInfo.Key - 48;
                if (predictedResultKeyInfo.Key == ConsoleKey.Escape)
                {
                    return null;
                }
                if (predictedResult <= 0 || predictedResult > 2)
                {
                    Console.WriteLine("Неверная клавиша. Повторите Ввод.");
                    Console.WriteLine();
                }

            } while (predictedResult != 1 && predictedResult != 2);

            return predictedResult;
        }

        private static void ShowPlayAgainText()
        {
            Console.WriteLine();
            Console.WriteLine("Нажмите Enter для начала новой игры");
            Console.WriteLine("");
            Console.WriteLine();
        }

        private static void ShowWelcomeInTheGameMessage()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Игра Орёл и Решка, от \"GOR\"! ");
            Console.WriteLine("Для начала новой игры нажмите клавишу Enter.");
            Console.WriteLine("Для выхода нажмите клавишу Esc.");
            Console.WriteLine("------------------------------------------");

            Console.WriteLine();
        }

        private static ConsoleKeyInfo ReadKey()
        {
            ConsoleKeyInfo newGameKeyInfo;
            do
            {
                newGameKeyInfo = Console.ReadKey(true);
            }
            while (newGameKeyInfo.Key != ConsoleKey.Enter && newGameKeyInfo.Key != ConsoleKey.Escape);


            return newGameKeyInfo;
        }

        private static void ShowLoading()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write(".");
                Thread.Sleep(300);
            }
        }
    }
}
