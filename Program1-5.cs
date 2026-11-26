using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab4Tasks1to5
{
    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Задание 1");
            var list1 = ReadIntList("Введите элементы списка (через пробел): ");
            Console.Write("Введите элемент E: ");
            int E = int.Parse(Console.ReadLine() ?? "0");
            var res1 = Lab4.Task1(list1, E);
            Console.WriteLine("Исходный список: " + string.Join(", ", list1));
            Console.WriteLine("После удаления за " + E + ": " + string.Join(", ", res1));

            Console.WriteLine("\nЗадание 2");
            var listValues = ReadIntList("Введите элементы связанного списка (через пробел): ");
            var linked1 = new LinkedList<int>(listValues);
            Console.WriteLine("Список: " + string.Join(", ", linked1));
            Console.WriteLine("Есть равные соседи? " + Lab4.Task2(linked1));

            Console.WriteLine("\nЗадание 3");
            Console.Write("Введите общий перечень стран (через запятую): ");
            var allCountries = new HashSet<string>((Console.ReadLine() ?? "").Split(',').Select(s => s.Trim()));

            var tourists = new List<HashSet<string>>();
            Console.WriteLine("Вводите страны, которые посетил каждый турист (через запятую).");
            Console.WriteLine("Чтобы закончить ввод, оставьте строку пустой и нажмите Enter.");

            int touristNum = 1;
            while (true)
            {
                Console.Write("Турист " + touristNum + ": ");
                string input = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(input)) break;
                tourists.Add(new HashSet<string>(input.Split(',').Select(s => s.Trim())));
                touristNum++;
            }

            var result3 = Lab4.Task3(allCountries, tourists);
            Console.WriteLine("Все туристы посетили: " + string.Join(", ", result3.allVisited));
            Console.WriteLine("Хотя бы один посетил: " + string.Join(", ", result3.someVisited));
            Console.WriteLine("Никто не посетил: " + string.Join(", ", result3.noneVisited));

            Console.WriteLine("\nЗадание 4");
            string file4 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input4.txt");
            File.WriteAllText(file4, "Шла Саша по шоссе и сосала сушку. Фуфайка и шапка.", System.Text.Encoding.UTF8);
            var res4 = Lab4.Task4(file4);
            Console.WriteLine("Глухие согласные, не входящие ровно в одно слово: " + string.Join(", ", res4));

            Console.WriteLine("\nЗадание 5");
            string file5 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input5.txt");
            Lab4.GenerateTask5File(file5);
            Lab4.Task5(file5);

            Console.ReadKey();
        }

        private static List<int> ReadIntList(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? "";
                try
                {
                    var parts = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    return parts.Select(int.Parse).ToList();
                }
                catch { Console.WriteLine("Ошибка ввода, попробуйте снова."); }
            }
        }
    }
}
