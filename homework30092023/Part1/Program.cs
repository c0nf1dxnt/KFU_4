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
        static void SwapValues(ref int a, ref int b)
        {
            (a, b) = (b, a);
        }
        static void SwapValues(ref decimal a, ref decimal b)
        {
            (a, b) = (b, a);
        }
        static bool CheckFactorial(int a, out long b)
        {
            try
            {
                b = 1;
                for (int i = 2; i < a + 1; i++)
                {
                    b = checked(b * i);
                }
                return true;
            }
            catch (OverflowException)
            {
                b = 0;
                return false;
            }
        }
        static long FindFactorial(int a)
        {
            if (a == 0)
            {
                return 1;
            }
            return a * FindFactorial(a - 1);
        }
        static long Fibonacchi(int a)
        {
            if (a == 0)
            {
                return 0;
            }
            if (a == 1)
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
            if (Int32.TryParse(InputString1, out int     number1) & Int32.TryParse(InputString2, out int number2))
            {
                Console.WriteLine($"Наибольшее число равно: {FindMax(number1, number2)}\n");
            }
            else
            {
                Console.WriteLine("Вы ввели не целое число или строку!\n");
            }
        }
        static void Task2()
        {
            Console.WriteLine("Задание №2:\n");
            Console.Write("Введите первое число: ");
            string InputString1 = Console.ReadLine();
            Console.Write("Введите второе число: ");
            string InputString2 = Console.ReadLine();
            if (Int32.TryParse(InputString1, out int number1) & Int32.TryParse(InputString2, out int number2))
            {
                SwapValues(ref number1, ref number2);
                Console.WriteLine($"Первое число теперь равно: {number1}, а второе: {number2}\n");
            }
            else
            {
                Console.WriteLine("Вы ввели не целое число или строку!\n");
            }
        }
        static void Task3()
        {
            Console.WriteLine("Задание №3:\n");
            Console.Write("Введите число: ");
            string inputString = Console.ReadLine();
            if (int.TryParse(inputString, out int number))
            {
                if (CheckFactorial(number, out long answer))
                {
                    Console.WriteLine($"Ответ: {number}! = {answer}\n");
                }
                else
                {
                    Console.WriteLine("В процессе вычисления возникло переполнение!\n");
                }
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
                Console.WriteLine($"Ответ: {number}! = {FindFactorial(number)}\n");
            }
            else
            {
                Console.WriteLine("Вы ввели не целое число или строку!\n");
            }
        }
        static void Task5()
        {
            Console.WriteLine("Задание №5:\n");
            Console.Write("Введите первое число: ");
            string InputString1 = Console.ReadLine();
            Console.Write("Введите второе число: ");
            string InputString2 = Console.ReadLine();
            Console.Write("Введите третье число: ");
            string InputString3 = Console.ReadLine();
            if (Int32.TryParse(InputString1, out int number1) & Int32.TryParse(InputString2, out int number2) & (Int32.TryParse(InputString3, out int number3)))
            {
                Console.WriteLine($"НОД трёх введённых чисел равен: {GCD(number1,number2,number3)}\n");
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
            Console.Title = "Skynet";
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();

            Console.ReadKey();
        }
    }
}