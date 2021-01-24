using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lab1 {
    class Program {
        private static List<string> words = new List<string>();
        private static System.IO.StreamReader file = new System.IO.StreamReader("Words.txt");
        public static void Main(string[] args) {
            char select;
            do {
                Console.WriteLine("1 - Import Words from File\n" +
                    "2 - Bubble Sort words\n" +
                    "3 - LINQ / Lambda sort words\n" +
                    "4 - Count the Distinct Words\n" +
                    "5 - Take the first 10 words\n" +
                    "6 - Get the number of words that start with 'j' and display the count\n" +
                    "7 - Get and display of words that end with 'd' and display the count\n" +
                    "8 - Get and display of words that are greater than 4 characters long, and display the count\n" +
                    "9 - Get and display of words that are less than 3 characters long and start with the letter 'a', and display the count\n" +
                    "x – Exit\n");
                Console.Write("Make a selection: ");

                select = Console.ReadLine().ToLower()[0];
                Console.Clear();

                switch (select)
                {
                    case '1':
                        readFile();
                        break;
                    case '2':
                        BubbleSort(words);
                        break;
                    case '3':
                        lambdaSort();
                        break;
                    case '4':
                        distinct();
                        break;
                    case '5':
                        firstTenWords();
                        break;
                    case '6':
                        startWithJ();
                        break;
                    case '7':
                        endWithD();
                        break;
                    case '8':
                        greaterThan4();
                        break;
                    case '9':
                        lessThan3();
                        break;
                    case 'x':
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Option!\n");
                        Console.ResetColor();
                        break;
                }
                Console.WriteLine();
            } while (select != 'x');
        }

        public static void readFile() {
            words.Clear();
            try {
                using (file) {
                    Console.WriteLine("Reading Words");

                    string text;
                    while ((text = file.ReadLine()) != null) {
                        words.Add(text);
                    }
                }
                Console.WriteLine("Reading Words complete\nNumber of words found: "+ words.Count);

            }
            catch (Exception) {
                Console.WriteLine("Error reading file!");
            }
        }

        public static void BubbleSort(List<string> words) {
            Stopwatch watch = Stopwatch.StartNew();

            for (int j = 0; j <= words.Count - 2; j++) {
                for (int i = 0; i <= words.Count - 2; i++) {
                    if (words[i].CompareTo(words[i + 1]) > 0) {
                        string temp = words[i + 1];
                        words[i + 1] = words[i];
                        words[i] = temp;
                    }
                }
            }

            watch.Stop();
            Console.WriteLine("Time elapse: {0}ms", watch.ElapsedMilliseconds);
        }

        public static void lambdaSort() {
            Stopwatch watch = Stopwatch.StartNew();
            var query = words.OrderBy(str => str).ToList();
            words = query;
            watch.Stop();
            Console.WriteLine("Time elapse: {0}ms", watch.ElapsedMilliseconds);
        }

        public static void distinct() {
            int distinctWords = (from x in words select x).Distinct().Count();
            Console.WriteLine("The number of distinct words: "+ distinctWords);
        }

        public static void firstTenWords() {
            if (words.Count == 0) { 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nothing is in file\n");
                Console.ResetColor();
                return;
            }

            for (int i = 0; i < 10; i++) {
                Console.WriteLine(words[i]);
            }
        }

        public static void startWithJ() {
            var query = from x in words where x.StartsWith("j") select x;
            int count = 0;
            foreach (var word in query) {
                Console.WriteLine(word);
                count++;
            }
            Console.WriteLine("Number of words that start with 'j': "+ count);
        }

        public static void endWithD() {
            var query = from x in words where x.EndsWith("d") select x;
            int count = 0;
            foreach (var word in query) {
                Console.WriteLine(word);
                count++;
            }
            Console.WriteLine("Number of words that end with 'd': "+ query.Count());
        }

        public static void greaterThan4() {
            var query = from x in words where x.Length > 4 select x;
            int count = 0;
            foreach (var word in query) {
                Console.WriteLine(word);
                count++;
            }
            Console.WriteLine("Number of words longer than 4 characters: {0}", query.Count());
        }

        public static void lessThan3() {
            var query = from x in words where x.Length < 3 && x.StartsWith("a") select x;
            int count = 0;
            foreach (var word in query) {
                Console.WriteLine(word);
                count++;
            }
            Console.WriteLine("Number of words longer less than 3 characters and start with 'a': "+ query.Count());
        }
    }
}