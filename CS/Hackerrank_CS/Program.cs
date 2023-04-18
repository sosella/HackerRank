using System;

namespace Hackerrank
{
    class Program
    {
        public class TestCase
        {
            public int prop { get; }
            public int expected { get; }

            public TestCase(int prop, int expected)
            {
                this.prop = prop;
                this.expected = expected;
            }

            public static int func(int prop)
            {
                return 0;
            }

            public void Execute()
            {
                Validate(func(prop));
            }

            private void Validate(int result)
            {
                Console.WriteLine(result == expected ? "Success" : $"Failed: '{prop}' '{expected}' != '{result}'");
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
