using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab4Tasks1to5
{
    public static class Lab4
    {
        public static List<int> Task1(List<int> L, int E)
        {
            var result = new List<int>(L);
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i] == E && i + 1 < result.Count && result[i + 1] != E)
                    result.RemoveAt(i + 1);
            }
            return result;
        }

        public static bool Task2(LinkedList<int> L)
        {
            if (L == null || L.Count < 2) return false;
            var current = L.First;
            while (current != null)
            {
                var next = current.Next ?? L.First;
                if (current.Value == next.Value) return true;
                current = current.Next;
            }
            return false;
        }

        public static (HashSet<string> allVisited, HashSet<string> someVisited, HashSet<string> noneVisited) Task3(
            HashSet<string> allCountries, List<HashSet<string>> tourists)
        {
            if (tourists.Count == 0)
                return (new HashSet<string>(), new HashSet<string>(), new HashSet<string>(allCountries));

            var allVisited = new HashSet<string>(tourists[0]);
            foreach (var t in tourists) allVisited.IntersectWith(t);

            var someVisited = new HashSet<string>();
            foreach (var t in tourists) someVisited.UnionWith(t);

            var noneVisited = new HashSet<string>(allCountries);
            noneVisited.ExceptWith(someVisited);

            return (allVisited, someVisited, noneVisited);
        }

        public static List<char> Task4(string filename)
        {
            string text = File.ReadAllText(filename, Encoding.UTF8);
            var words = new List<string>();
            var sb = new StringBuilder();
            foreach (char c in text)
            {
                if (char.IsLetter(c) && (c >= 'А' && c <= 'я' || c == 'ё' || c == 'Ё')) sb.Append(c);
                else if (sb.Length > 0) { words.Add(sb.ToString().ToLower()); sb.Clear(); }
            }
            if (sb.Length > 0) words.Add(sb.ToString().ToLower());

            var voiceless = new HashSet<char> { 'п', 'ф', 'к', 'т', 'ш', 'с', 'х', 'ц', 'ч', 'щ' };
            var counts = new Dictionary<char, int>();
            foreach (char c in voiceless) counts[c] = 0;

            foreach (var word in words)
            {
                var charsInWord = new HashSet<char>(word);
                foreach (char c in charsInWord)
                    if (voiceless.Contains(c)) counts[c]++;
            }

            return counts.Where(kv => kv.Value != 1).Select(kv => kv.Key).OrderBy(c => c).ToList();
        }

        public static void GenerateTask5File(string filename)
        {
            var lines = new[] { "5", "Иванов Иван 40 50", "Петров Петр 20 60", "Сидоров Сидор 30 30", "Смирнова Анна 100 100", "Кузнецов Алексей 25 35" };
            File.WriteAllLines(filename, lines, Encoding.UTF8);
        }

        public static void Task5(string filename)
        {
            var lines = File.ReadAllLines(filename, Encoding.UTF8);
            if (lines.Length == 0) return;
            int n = int.Parse(lines[0]);
            var failed = new List<(string surname, string name)>();
            for (int i = 1; i <= n; i++)
            {
                var parts = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 4) continue;
                if (int.Parse(parts[2]) < 30 || int.Parse(parts[3]) < 30)
                    failed.Add((parts[0], parts[1]));
            }
            var sorted = failed.OrderBy(x => x.surname).ThenBy(x => x.name).ToList();
            Console.WriteLine("Абитуриенты, не допущенные к экзаменам:");
            if (sorted.Count == 0) Console.WriteLine("Таких нет.");
            foreach (var (surname, name) in sorted)
                Console.WriteLine($"{surname} {name}");
        }
    }
}
