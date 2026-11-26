using System;

namespace Lab4Tasks6and7
{
    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Тестирование класса RightTriangle");

            Console.WriteLine("\nСоздание первого треугольника");
            double a1 = ReadDouble("Введите катет a: ");
            double b1 = ReadDouble("Введите катет b: ");
            var t1 = new RightTriangle(a1, b1);
            Console.WriteLine("Создан: " + t1.ToString());
            Console.WriteLine("Площадь: " + t1.GetArea());

            Console.WriteLine("\nСоздание второго треугольника");
            double a2 = ReadDouble("Введите катет a: ");
            double b2 = ReadDouble("Введите катет b: ");
            var t2 = new RightTriangle(a2, b2);
            Console.WriteLine("Создан: " + t2.ToString());
            Console.WriteLine("Площадь: " + t2.GetArea());

            Console.WriteLine("\nПриведение типов");
            Console.WriteLine("(double)t1 площадь: " + (double)t1);
            Console.WriteLine("(bool)t1 существует? " + ((bool)t1));

            Console.WriteLine("\nУнарные операции");
            var t3 = t1++;
            Console.WriteLine("После t1++ : t1 " + t1.ToString() + ", а старое t3: " + t3.ToString());

            var t4 = t2--;
            Console.WriteLine("После t2-- : t2 " + t2.ToString() + ", а старое t4: " + t4.ToString());

            Console.WriteLine("\nСравнение площадей");
            Console.WriteLine("t1 меньше либо равно t2: " + (t1 <= t2));
            Console.WriteLine("t1 больше либо равно t2: " + (t1 >= t2));

            Console.ReadKey();
        }

        private static double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? "";
                if (double.TryParse(input, out double result) && result > 0) return result;
                Console.WriteLine("Ошибка. Введите положительное число.");
            }
        }
    }
}
