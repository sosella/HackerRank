// ---------------------------------------------------------------------------------------------------------
// Template
// ---------------------------------------------------------------------------------------------------------
#if true
/*
    Description
*/
using System;

namespace Hackerrank
{
    class Program
    {
        public class TestCase
        {
            private int prop { get; }
            private int expected { get; }

            public TestCase(int prop, int expected)
            {
                this.prop = prop;
                this.expected = expected;
            }

            public static int func(int param)
            {
                return 0;
            }

            public void Execute()
            {
                var result = func(prop);
                Console.WriteLine($"{Title(result)} -> " + (Validate(result) ? "Success" : "Failed"));
            }

            private bool Validate(int result)
            {
                return result == expected;
            }

            private string Title(int result)
            {
                return "";
            }
        }

        static void Main(string[] args)
        {
            TestCase[] testCases = new[]
            {
                new TestCase(0, 0),
            };

            foreach (var testCase in testCases)
            {
                testCase.Execute();
            }

            Console.ReadLine();
        }
    }
}
#endif
