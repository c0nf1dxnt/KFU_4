using System;
using System.Text;
using System.Threading;

namespace Part2
{
    internal class Program
    {
        static bool ValueIsInArray(int[] array, int value)
        {
            foreach (int i in array)
            {
                if (i == value)
                {
                    return true;
                }
            }
            return false;
        }
        static int CountSumInArray(ref long compositionOfNumbers, out int sumOfNumbers, out double averageNumber, params int[] array)
        {
            sumOfNumbers = 0;
            compositionOfNumbers = 1;
            foreach (int i in array)
            {
                sumOfNumbers += i;
                compositionOfNumbers *= i;
            }
            averageNumber = (double)sumOfNumbers / array.Length;
            return sumOfNumbers;
        }
        static void PrintNumber(int value)
        {
            string[] numbers =
            {
                " ####\n #  #\n #  #\n #  #\n ####\n",
                "    #\n  # #\n    #\n    #\n    #\n",
                "  ## \n #  #\n   # \n  #  \n ####\n",
                "  ## \n #  #\n   # \n #  #\n  ## \n",
                " #  #\n #  #\n ####\n    #\n    #\n",
                " ####\n #   \n ####\n    #\n ####\n",
                " ####\n #   \n ####\n #  #\n ####\n",
                " ####\n    #\n   # \n  #  \n #   \n",
                " ####\n #  #\n ####\n #  #\n ####\n",
                " ####\n #  #\n ####\n    #\n ####\n",
            };
            Console.WriteLine(numbers[value]);
        }
        enum LevelOfGrouchiness
        {
            Низкий,
            Средний,
            Высокий,
            Максимальный,
            Эпический
        }
        struct GrandFather
        {
            public string Name;
            public LevelOfGrouchiness Grouchiness;
            public string[] Phrases;
            public int Bruises;
            public GrandFather(string name, LevelOfGrouchiness grouchiness, string[] phrases)
            {
                Name = name;
                Grouchiness = grouchiness;
                Phrases = phrases;
                Bruises = 0;
            }
            public int CheckPhrases(params string[] BadWords)
            {
                foreach (string phr in Phrases)
                {
                    foreach (string word in BadWords)
                    {
                        if (phr.Contains(word))
                        {
                            Bruises++;
                        }
                    }
                }
                return Bruises;
            }
        }
        static void Task1()
        {
            Console.WriteLine("Задание №1:\nВывести на экран массив из 20 случайных чисел. Ввести два числа из этого массива,\r\nкоторые нужно поменять местами. Вывести на экран получившийся массив.\n");
            int[] array = new int[20];
            Random random = new Random();
            Console.Write("Array = { ");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(100);
                Console.Write(array[i] + " ");
            }
            Console.Write("}\nВведите первое число: ");
            string inputString1 = Console.ReadLine();
            Console.Write("Введите второе число: ");
            string inputString2 = Console.ReadLine();
            if (Int32.TryParse(inputString1, out int number1) & Int32.TryParse(inputString2, out int number2))
            {
                if (number1 == number2)
                {
                    Console.WriteLine("Предупреждение! Введённые числа равны, ничего не изменится!");
                }
                if (ValueIsInArray(array, number1) && ValueIsInArray(array, number2))
                {
                    (array[Array.IndexOf(array, number1)], array[Array.IndexOf(array, number2)]) = (number2, number1);
                    Console.Write("Array = { ");
                    foreach (int i in array)
                    {
                        Console.Write(i + " ");
                    }
                    Console.WriteLine("}\n");
                }
                else
                {
                    Console.WriteLine("Вы ввели число, не входящее в массив!\n");
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не целое число или строку!\n");
            }

        }
        static void Task2()
        {
            Console.WriteLine("Задание №2:\nНаписать метод, где в качества аргумента будет передан массив (ключевое слово\r\nparams). Вывести сумму элементов массива (вернуть). Вывести (ref) произведение\r\nмассива. Вывести (out) среднее арифметическое в массиве.\n");
            int[] array = new int[10];
            Random random = new Random();
            Console.Write("Array = { ");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 20);
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("}");
            long compositionOfValues = 0;
            Console.WriteLine($"Сумма элементов массива равна: {CountSumInArray(ref compositionOfValues, out int sumOfNumbers, out double averageNumber, array)}");
            Console.WriteLine($"Произведение всех элементов массива равно: {compositionOfValues}");
            Console.WriteLine($"Среднее арифметическое элементов массива равно: {averageNumber}\n");
        }
        static void Task3()
        {
            Console.WriteLine("Задание №3\nПользователь вводит числа. Если числа от 0 до 9, то необходимо в консоли нарисовать\r\nизображение цифры в виде символа #.Если число больше 9 или меньше 0, то консоль\r\nдолжна окраситься в красный цвет на 3 секунды и вывести сообщение об ошибке. Если\r\nпользователь ввёл не цифру, то программа должна выпасть в исключение. Программа\r\nзавершает работу, если пользователь введёт слово: exit или закрыть (оба варианта\r\nдолжны сработать) - консоль закроется.\n");
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                if (input == "exit" || input == "закрыть")
                {
                    Environment.Exit(0);
                }
                else
                {
                    try
                    {
                        if (int.TryParse(input, out int number))
                        {
                            if (0 <= number && number <= 9)
                            {
                                PrintNumber(number);
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.WriteLine("ОШИБКА 404");
                                Thread.Sleep(3000);
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Вы ввели не число или не целое число");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Неправильный формат данных!");
                    }
                }
            }
        }
        static void Task4()
        {
            Console.WriteLine("\nЗадание №4\nСоздать структуру Дед. У деда есть имя, уровень ворчливости (перечисление), массив\r\nфраз для ворчания (прим.: “Проститутки!”, “Гады!”), количество синяков от ударов\r\nбабки = 0 по умолчанию. Создать 5 дедов. У каждого деда - разное количество фраз для\r\nворчания. Напишите метод (внутри структуры), который на вход принимает деда,\r\nсписок матерных слов (params). Если дед содержит в своей лексике матерные слова из\r\nсписка, то бабка ставит фингал за каждое слово. Вернуть количество фингалов.\n");
            Console.WriteLine("Данные о дедах:");
            string[] BadWords = { "Тварь", "Мразь", "Подонок", "Блять", "Сука" };
            string[] GrandFather1Phrases = { "Попуски", "Чмошники" };
            string[] GrandFather2Phrases = { "Сука" };
            string[] GrandFather3Phrases = { "Сука", "Подонок", "Паскуда", "Котёнок", "Ишак" };
            string[] GrandFather4Phrases = { "Тварь", "Сука", "Подонок" };
            string[] GrandFather5Phrases = { "Тварь", "Мразь", "Подонок", "Блять" };
            GrandFather[] GrandFathers = new GrandFather[5];
            GrandFathers[0] = new GrandFather("Александр", LevelOfGrouchiness.Низкий, GrandFather1Phrases);
            GrandFathers[1] = new GrandFather("Григорий", LevelOfGrouchiness.Средний, GrandFather2Phrases);
            GrandFathers[2] = new GrandFather("Владимир", LevelOfGrouchiness.Высокий, GrandFather3Phrases);
            GrandFathers[3] = new GrandFather("Евгений", LevelOfGrouchiness.Максимальный, GrandFather4Phrases);
            GrandFathers[4] = new GrandFather("Алексей", LevelOfGrouchiness.Эпический, GrandFather5Phrases);
            Console.WriteLine($"Дед {GrandFathers[0].Name} получил {GrandFathers[0].CheckPhrases(BadWords)} синяков");
            Console.WriteLine($"Дед {GrandFathers[1].Name} получил {GrandFathers[1].CheckPhrases(BadWords)} синяков");
            Console.WriteLine($"Дед {GrandFathers[2].Name} получил {GrandFathers[2].CheckPhrases(BadWords)} синяков");
            Console.WriteLine($"Дед {GrandFathers[3].Name} получил {GrandFathers[3].CheckPhrases(BadWords)} синяков");
            Console.WriteLine($"Дед {GrandFathers[4].Name} получил {GrandFathers[4].CheckPhrases(BadWords)} синяков");
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

            Console.ReadKey();
        }
    }
}