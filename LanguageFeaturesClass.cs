using Microsoft.Identity.Client;
using Microsoft.VisualBasic;
using System;

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
    }
}
