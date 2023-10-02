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
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Task1();
            Task4();
            Task6();

            Console.ReadKey();
        }
    }
}