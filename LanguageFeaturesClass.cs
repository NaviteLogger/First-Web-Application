using Microsoft.Identity.Client;
using Microsoft.VisualBasic;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LanguageFeatures
{
    public class LanguageFeaturesClass
    {
        // $ sign - Interpolated String
        // $ sign is used to create a string that contains the value of a variable
        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        static void TestInterpolatedString()
        {
            var p1 = new Point { X = 5, Y = 10 };
            var p2 = new Point { X = 7, Y = 3 };

            Console.WriteLine("The area of interest is bounded by (" + p1.X + "," + p1.Y + ") and (" + p2.X + "," + p2.Y + ")");
            //As you can see, concatenating string like this makes the code hard to read and error-prone.You may use string.Format() to make it nicer:
            Console.WriteLine(string.Format("The area of interest is bounded by({0},{1}) and ({2},{3})", p1.X, p1.Y, p2.X, p2.Y));
            //This creates an issue: You have to maintain the number of arguments and index yourself. If the number of arguments and index are not the same, it will generate a runtime error.
            //Solution:
            Console.WriteLine($"The area of interest is bounded by ({p1.X},{p1.Y}) and ({p2.X},{p2.Y})");
            //The compiler now maintains the placeholders for you so you don’t have to worry about indexing the right argument because you simply place it right there in the string.
        }
        //nullable value
        public class NullableValues<T>
        {
            double? pi = 3.14;
            char? letter = 'a';
            int?[] arr = new int?[10]; //An arrayh of nullable value type

            static void TestNullableTypes()
            {
                //Testing for instance of a nullable value type
                int? a = 42;
                if (a is int valueOfA)
                {
                    Console.WriteLine($"a is {valueOfA}");
                }
                else
                {
                    Console.WriteLine("a does not have a value");
                }
            }
        }

        public class NullcoalescingOperators
        {
            static void TestNullcoalescingOperators()
            {
                List<int> numbers = null;
                int? a = null;

                (numbers ??= new List<int>()).Add(5);
                Console.WriteLine(string.Join(" ", numbers));  // output: 5

                numbers.Add(a ??= 0);
                Console.WriteLine(string.Join(" ", numbers));  // output: 5 0
                Console.WriteLine(a);  // output: 0


                double SumNumbers(List<double[]> setsOfNumbers, int indexOfSetToSum)
                {
                    return setsOfNumbers?[indexOfSetToSum]?.Sum() ?? double.NaN;
                }

                var sum = SumNumbers(null, 0);
                Console.WriteLine(sum);  // output: NaN
            }

        }

        public class LambdaStructures
        {
            Func<int, int> square = x => x * x;
            Func<int, int, int> add = (x, y) => x + y;
            Action<int> write = x => Console.WriteLine(x);
            
            Func<int, int, int> add2 = (x, y) =>
            {
                Console.WriteLine("Adding {0} and {1}", x, y);
                return x + y;
            };

            void TestLambdas ()
            {
                int[] numbers = { 2, 3, 4, 5 };
                foreach (var number in numbers)
                {
                    square(number);
                }
                var squaredNumbers = numbers.Select(x => x * x);
                Console.WriteLine(string.Join(" ", squaredNumbers));
            }
            // Output: 4 9 16 25
        }



        public class AwaitOperator
        {
            public static async Task Main()
            {
                Task<int> downloading = DownloadDocsMainPageAsync();
                Console.WriteLine($"{nameof(Main)}: Launched downloading.");

                int bytesLoaded = await downloading;
                Console.WriteLine($"{nameof(Main)}: Downloaded {bytesLoaded} bytes.");
            }

            private static async Task<int> DownloadDocsMainPageAsync()
            {
                Console.WriteLine($"{nameof(DownloadDocsMainPageAsync)}: About to start downloading.");

                var client = new HttpClient();
                byte[] content = await client.GetByteArrayAsync("https://docs.microsoft.com/en-us/");

                Console.WriteLine($"{nameof(DownloadDocsMainPageAsync)}: Finished downloading.");
                return content.Length;
            }
        }
            // Output similar to:
            // DownloadDocsMainPageAsync: About to start downloading.
            // Main: Launched downloading.
            // DownloadDocsMainPageAsync: Finished downloading.
            // Main: Downloaded 27700 bytes.
    }
}
