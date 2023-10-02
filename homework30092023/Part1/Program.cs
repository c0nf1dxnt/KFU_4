using System;
using System.Text;

namespace Part1
{
    internal class Program
    {
        static int FindMax(int a, int b)
        {
            return a > b ? a : b;
        }
        static long Factorial(int a)
        {
            if (a == 0)
            {
                return 1;
            }
            return a * Factorial(a - 1);
        }
        static int Fibonacchi(int a)
        {
            if (a == 0 || a == 1)
            {
                return 1;
            }
            return Fibonacchi(a - 1) + Fibonacchi(a - 2);
        }
        static int GCD(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }
            return a;
        }
        static int GCD(int a, int b, int c)
        {
            return GCD(GCD(a, b), c);
        }
        static void Task1()
        {
            Console.WriteLine("Задание №1:\n");
            Console.Write("Введите первое число: ");
            string InputString1 = Console.ReadLine();
            Console.Write("Введите второе число: ");
            string InputString2 = Console.ReadLine();
            if (Int32.TryParse(InputString1, out int number1) & Int32.TryParse(InputString2, out int number2))
            {
                Console.WriteLine($"Наибольшее число равно: {FindMax(number1, number2)}\n");
            }
            else
            {
                Console.WriteLine("Вы ввели не целое число или строку!\n");
            }
        }
        static void Task4()
        {
            Console.WriteLine("Задание №4:\n");
            Console.Write("Введите число: ");
            string InputString1 = Console.ReadLine();
            if (Int32.TryParse(InputString1, out int number))
            {
                Console.WriteLine($"Ответ: {number}! = {Factorial(number)}\n");
            }
            else
            {
                Console.WriteLine("Вы ввели не целое число или строку!\n");
            }
        }
        static void Task5()
        {
            Console.WriteLine("Задание №5:\n");
            Random random = new Random();
            int number1 = random.Next(50);
            int number2 = random.Next(50);
            int number3 = random.Next(50);
            Console.WriteLine(number1);
            Console.WriteLine(number2);
            Console.WriteLine(number3);
            Console.WriteLine(GCD(number1,number2,number3) + "\n");
        }
        static void Task6()
        {
            Console.WriteLine("Задание №6:\n");
            Console.Write("Введите число: ");
            string InputString1 = Console.ReadLine();
            if (Int32.TryParse(InputString1, out int number))
            {
                Console.WriteLine($"Элемент ряда Фибоначчи под номером {number} = {Fibonacchi(number)}\n");
            }
            else
            {
                Console.WriteLine("Вы ввели не целое число или строку!\n");
            }
        }
        static void Main(string[] args)
        {
            Console.Title = "Skynet";
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Task1();
            Task4();
            Task5();
            Task6();

            Console.ReadKey();
        }
    }
}