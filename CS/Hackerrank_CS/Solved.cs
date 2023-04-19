// ---------------------------------------------------------------------------------------------------------
// Template
// ---------------------------------------------------------------------------------------------------------
#if false
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
// ---------------------------------------------------------------------------------------------------------
// Taum and B'day
// ---------------------------------------------------------------------------------------------------------
#if false
/*
    Taum is planning to celebrate the birthday of his friend, Diksha. 
    There are two types of gifts that Diksha wants from Taum: one is black and the other is white. 
    To make her happy, Taum has to buy b black gifts and w white gifts.
    The cost of each black gift is bc units.
    The cost of every white gift is wc units.
    The cost to convert a black gift into white gift or vice versa is z units.
    Determine the minimum cost of Diksha's gifts.
*/
using System;

namespace Hackerrank
{
    class Program
    {
        public class TestCase
        {
            private int b { get; }
            private int w { get; }
            private int bc { get; }
            private int wc { get; }
            private int z { get; }
            private long expected { get; }

            public TestCase(int b, int w, int bc, int wc, int z, long expected)
            {
                this.b = b;
                this.w = w;
                this.bc = bc;
                this.wc = wc;
                this.z = z;
                this.expected = expected;
            }

            // int b: the number of black gifts
            // int w: the number of white gifts
            // int bc: the cost of a black gift
            // int wc: the cost of a white gift
            // int z: the cost to convert one color gift to the other color
            // returns the minimum cost to purchase the gifts
            public static long func(int b, int w, int bc, int wc, int z)
            {
                long bcz = wc + (long)z;
                long wcz = bc + (long)z;

                return (b * ((bc <= bcz) ? bc : bcz)) + (w * ((wc <= wcz) ? wc : wcz));
            }

            public void Execute()
            {
                var result = func(b, w, bc, wc, z);
                Console.WriteLine($"{Title(result)} -> " + (Validate(result) ? "Success" : "Failed"));
            }

            private bool Validate(long result)
            {
                return result == expected;
            }

            private string Title(long result)
            {
                return $"{b} {w} {bc} {wc} {z} : {expected} : {result}";
            }
        }

        static void Main(string[] args)
        {
            TestCase[] testCases = new[]
            {
                new TestCase(3, 5, 3, 4, 1, 29),
                new TestCase(10, 10, 1, 1, 1, 20),
                new TestCase(5, 9, 2, 3, 4, 37),
                new TestCase(3, 6, 9, 1, 1, 12),
                new TestCase(7, 7, 4, 2, 1, 35),
                new TestCase(3, 3, 1, 9, 2, 12),
                new TestCase(42899452, 58539299, 832193, 584380, 655132, 69909819207856),
                new TestCase(60020263, 12506083, 825605, 399222, 7272, 29390580255348),
                new TestCase(19034680, 45658385, 284898, 669792, 173627, 26358453244765),
                new TestCase(801547, 74747239, 505041, 84296, 26457, 6389666993635),
                new TestCase(79436075, 94544581, 359505, 563489, 368187, 81832497545984),
                new TestCase(71415433, 84421474, 700577, 634364, 199434, 103585953737377),
                new TestCase(16681661, 41050167, 738732, 513853, 150899, 32182918976523),
                new TestCase(86393864, 80050468, 656981, 735820, 449689, 115661862528344),
                new TestCase(64664252, 20286852, 624425, 949149, 956643, 59633220844048),
                new TestCase(5314404, 95267047, 703881, 819444, 351342, 81806718063792),
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
// ---------------------------------------------------------------------------------------------------------
// Modified Kaprekar Numbers
// ---------------------------------------------------------------------------------------------------------
#if false
/*
    A modified Kaprekar number is a positive whole number with a special property. 
    If you square it, then split the number into two integers and sum those integers, you have the same value you started with.
    Consider a positive whole number n with d digits. 
    We square n to arrive at a number that is either 2 x d digits long or (2 x d) - 1 digits long. 
    Split the string representation of the square into two parts, l and r. 
    The right hand part, r must be d digits long. 
    The left is the remaining substring. 
    Convert those two substrings back to integers, add them and see if you get n.
*/
using System;
using System.Collections.Generic;

namespace Hackerrank
{
    class Program
    {
        public class TestCase
        {
            private int p { get; }  // the lower limit
            private int q { get; }  // the upper limit (inclusive)
            private string expected { get; }

            public TestCase(int p, int q, string expected)
            {
                this.p = p;
                this.q = q;
                this.expected = expected;
            }

            // Given two positive integers p and q where p is lower than q,
            // write a program to print the modified Kaprekar numbers in the range between p and q, inclusive.
            // If no modified Kaprekar numbers exist in the given range, print "INVALID RANGE"
            public static string func(int p, int q)
            {
                var modifiedKaprekarNumbers = new List<int>();

                while (p <= q)
                {
                    string pStr = p.ToString();
                    int d = pStr.Length;

                    long p2 = p * (long)p;
                    string p2Str = p2.ToString();
                    int d2 = p2Str.Length;

                    int lLen = d2 - d;
                    int rLen = d;

                    string l = p2Str.Substring(0, lLen);
                    string r = p2Str.Substring(lLen, rLen);

                    int lNum = l.Length == 0 ? 0 : int.Parse(l);
                    int rNum = int.Parse(r);

                    if ((lNum + rNum) == p)
                    {
                        modifiedKaprekarNumbers.Add(p);
                    }

                    p++;
                }

                var result = (modifiedKaprekarNumbers.Count == 0) ? "INVALID RANGE" : string.Join(' ', modifiedKaprekarNumbers);

                Console.WriteLine($"{result}");

                return result;
            }

            public void Execute()
            {
#if false
                func(p, q);
#else
                var result = func(p, q);
                Console.WriteLine($"{Title(result)} -> " + (Validate(result) ? "Success" : "Failed"));
#endif
            }

            private bool Validate(string result)
            {
                return result == expected;
            }

            private string Title(string result)
            {
                return $"{p} {q} : {expected} : {result}";
            }
        }

        static void Main(string[] args)
        {
            TestCase[] testCases = new[]
            {
                new TestCase(1, 100, "1 9 45 55 99"),
                new TestCase(100, 300, "297"),
                new TestCase(1, 99999, "1 9 45 55 99 297 703 999 2223 2728 4950 5050 7272 7777 9999 17344 22222 77778 82656 95121 99999"),
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
// ---------------------------------------------------------------------------------------------------------
// ACM ICPC Team
// ---------------------------------------------------------------------------------------------------------
#if false
/*
    There are a number of people who will be attending ACM-ICPC World Finals.
    Each of them may be well versed in a number of topics.
    Given a list of topics known by each attendee, presented as binary strings, determine the maximum number of topics a 2-person team can know.
    Each subject has a column in the binary string, and a '1' means the subject is known while '0' means it is not.
    Also determine the number of teams that know the maximum number of topics.
    Return an integer array with two elements:
        The first is the maximum number of topics known, and 
        the second is the number of teams that know that number of topics.
*/
using System;
using System.Collections.Generic;

namespace Hackerrank
{
    class Program
    {
        public class TestCase
        {
            private List<string> topic { get; }
            private List<int> expected { get; }

            public TestCase(List<string> topic, List<int> expected)
            {
                this.topic = topic;
                this.expected = expected;
            }

            public static List<int> func(List<string> topic)
            {
                int n = topic.Count;
                int m = topic[0].Length;

                int nbrGroupsWithMaxTopics = 0;
                int maxTopics = 0;

                for (int i = 0; i < n; i++)
                {
                    string topics1 = topic[i];

                    for (int j = i + 1; j < n; j++)
                    {
                        string topics2 = topic[j];

                        int nbrTopics = 0;
                        for (int k = 0; k < m; k++)
                        {
                            nbrTopics += ((topics1[k] == '1' || topics2[k] == '1') ? 1 : 0);
                        }

                        if (nbrTopics == maxTopics)
                        {
                            nbrGroupsWithMaxTopics++;
                        }
                        else if (nbrTopics > maxTopics)
                        {
                            maxTopics = nbrTopics;
                            nbrGroupsWithMaxTopics = 1;
                        }
                    }
                }

                return new List<int>() { maxTopics, nbrGroupsWithMaxTopics };
            }

            public void Execute()
            {
                var result = func(topic);
                Console.WriteLine($"{Title(result)} -> " + (Validate(result) ? "Success" : "Failed"));
            }

            private bool Validate(List<int> result)
            {
                return result[0] == expected[0] && result[1] == expected[1];
            }

            private string Title(List<int> result)
            {
                return $"{string.Join(',', topic)} : {string.Join(',', expected)} : {string.Join(',', result)}";
            }
        }

        static void Main(string[] args)
        {
            TestCase[] testCases = new[]
            {
                new TestCase(new List<string> { "10101", "11110", "00010" }, new List<int> { 5, 1 }),
                new TestCase(new List<string> { "10101", "11100", "11010", "00101" }, new List<int> { 5, 2 }),
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
// ---------------------------------------------------------------------------------------------------------
// Library Fine
// ---------------------------------------------------------------------------------------------------------
#if false
/*
    
    create a program that calculates the fine (if any). The fee structure is as follows:
    If the book is returned on or before the expected return date, no fine will be charged (i.e.: fine = 0).
    If the book is returned after the expected return day but still within the same calendar month and year as the expected return date, fine = 15 Hackos x (the number of days late).
    If the book is returned after the expected return month but still within the same calendar year as the expected return date, the fine = 500 Hackos x (the number of months late).
    If the book is returned after the calendar year in which it was expected, there is a fixed fine of 10000 Hackos.
    Charges are based only on the least precise measure of lateness. For example, whether a book is due January 1, 2017 or December 31, 2017, 
    if it is returned January 1, 2018, that is a year late and the fine would be 10000 Hackos.
*/
using System;

namespace Hackerrank
{
    class Program
    {
        // d1, m1, y1: returned date day, month and year, each an integer
        // d2, m2, y2: due date day, month and year, each an integer
        // return: the amount of the fine or  if there is none
        // 1 <= d <= 31
        // 1 <= m <= 12
        // 1 <= y <= 3000
        // Gregorian Calendar
        public static int libraryFine(int d1, int m1, int y1, int d2, int m2, int y2)
        {
            DateTime returnedDate = new DateTime(y1, m1, d1);
            DateTime dueDate = new DateTime(y2, m2, d2);

            if (returnedDate <= dueDate)
            {
                return 0;
            }

            if (returnedDate.Year == dueDate.Year && returnedDate.Month == dueDate.Month)
            {
                return 15 * (returnedDate.Day - dueDate.Day);
            }

            if (returnedDate.Year == dueDate.Year)
            {
                return 500 * (returnedDate.Month - dueDate.Month);
            }

            return 10000;
        }

        public class TestCase
        {
            public int d1 { get; }
            public int m1 { get; }
            public int y1 { get; }
            public int d2 { get; }
            public int m2 { get; }
            public int y2 { get; }
            public int expected { get; }

            public TestCase(int d1, int m1, int y1, int d2, int m2, int y2, int expected)
            {
                this.d1 = d1;
                this.m1 = m1;
                this.y1 = y1;
                this.d2 = d2;
                this.m2 = m2;
                this.y2 = y2;
                this.expected = expected;
            }

            public void Execute()
            {
                Validate(libraryFine(d1, m1, y1, d2, m2, y2));
            }

            private void Validate(int result)
            {
                Console.WriteLine(result == expected ? "Success" : $"Failed: '{d1}' '{m1}' '{y1}' '{d2}' '{m2}' '{y2}' '{expected}' != '{result}'");
            }
        }

        static void Main(string[] args)
        {
            TestCase[] testCases = new[]
            {
                new TestCase(9, 6, 2015, 6, 6, 2015, 45),
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
// ---------------------------------------------------------------------------------------------------------
// Append and Delete
// ---------------------------------------------------------------------------------------------------------
#if false
using System;

namespace Hackerrank
{
    class Program
    {
        // s & t are strings of lowercase English letters
        // You can perform two types of operations on the first string:
        // 1) Append a lowercase English letter to the end of the string
        // 2) Delete the last character of the string. Performing this operation on an empty string results in an empty string
        // Given an integer, k, and two strings, s and t,
        // determine whether or not you can convert s to t by performing EXACTLY k of the above operations on s.
        // If it's possible, print Yes. Otherwise, print No.
        public static string appendAndDelete(string s, string t, int k)
        {
            int sLen = s.Length;
            int tLen = t.Length;

            // Find how many of the first characters in s match those in t
            int i = 0;
            while (i < sLen && i < tLen)
            {
                if (s[i] != t[i])
                {
                    break;
                }
                i++;
            }

            // calculate how many delete ops need to be performed
            int n = sLen - i;

            // calculate how many add ops need to be performed
            int m = tLen - i;

            // calculate minimum number of operations to be performed
            int sum = n + m;

            // Calculate number of remaining ops to perform
            int l = k - sum;

            // Otherwise, can delete and add (2 ops each time) until all chars in s are deleted, or no ops left
            while (i > 0 && l >= 2)
            {
                i--;
                l -= 2;
            }

            // If not enough ops available
            if (l < 0)
            {
                return "No";
            }

            // If exactly the right number of ops are available
            if (l == 0)
            {
                return "Yes";
            }

            // l > 0 : i.e., some ops left, can only be handled if s is empty
            return (i == 0) ? "Yes" : "No";
        }

        public class TestCase
        {
            public string s { get; }
            public string t { get; }
            public int k { get; }
            public string expected { get;}

            public TestCase(string s, string t, int k, string expected)
            {
                this.s = s;
                this.t = t;
                this.k = k;
                this.expected = expected;
            }
        }

        static void Main(string[] args)
        {
            TestCase[] testCases = new[]
            {
                new TestCase("abc", "def", 6, "Yes"),
                new TestCase("abc", "abc", 0, "Yes"),
                new TestCase("abdef", "abcef", 6, "Yes"),
                new TestCase("hackerhappy", "hackerrank", 9, "Yes"),
                new TestCase("aba", "aba", 7, "Yes"),
                new TestCase("aaaaaaaaaa", "aaaaa", 7, "Yes"),
                new TestCase("ashley", "ash", 2, "No"),
                new TestCase("y", "yu", 2, "No"),
                new TestCase("abcd", "abcdert", 10, "No"),
            };

            foreach (var testCase in testCases)
            {
                string result = appendAndDelete(testCase.s, testCase.t, testCase.k);

                Console.WriteLine(result == testCase.expected ? "Success" : $"Failed: '{testCase.s}' '{testCase.t}' '{testCase.k}' '{testCase.expected}' ");
            }
            Console.ReadLine();
        }
    }
}
#endif
// ---------------------------------------------------------------------------------------------------------
// Simple Array Sum
// ---------------------------------------------------------------------------------------------------------
#if false
        static int simpleArraySum(int[] ar)
        {
            int sum = 0;
            foreach (int n in ar)
            {
                sum += n;
            }
            return sum;
        }

        static void Main(string[] args)
        {
            int[] ar = new int[] { 1, 2, 3, 4, 5 };

            Console.WriteLine(simpleArraySum(ar));
        }
#endif
// ---------------------------------------------------------------------------------------------------------
// Compare the Triplets
// ---------------------------------------------------------------------------------------------------------
#if false
        static List<int> compareTriplets(List<int> a, List<int> b)
        {
            int[] scoresAry = new int[] { 0, 0 };
            List<int> scores = new List<int>(scoresAry);
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] > b[i])
                {
                    scores[0]++;
                }
                else if (a[i] < b[i])
                {
                    scores[1]++;
                }
            }
            return scores;
        }

        static void Main(string[] args)
        {
            List<int> a = new int[] { 1, 2, 3 }.ToList();
            List<int> b = new int[] { 1, 2, 3 }.ToList();

            Console.WriteLine(string.Join(" ", compareTriplets(a, b)));
        }
#endif
// ---------------------------------------------------------------------------------------------------------
// A Very Big Sum
// ---------------------------------------------------------------------------------------------------------
#if false
        static long aVeryBigSum(long[] ar)
        {
            long sum = 0;
            foreach (long n in ar)
            {
                sum += n;
            }
            return sum;
        }

        static void Main(string[] args)
        {
            List<int> a = new int[] { 1, 2, 3 };

            Console.WriteLine(aVeryBigSum(ar));
        }
#endif
// ---------------------------------------------------------------------------------------------------------
// Diagonal Difference
// ---------------------------------------------------------------------------------------------------------
#if false
        static int diagonalDifference(int[][] arr)
        {
            int n = arr.GetLength(0);
            int suml2r = 0;
            int sumr2l = 0;
            for (int i = 0, ii = n - 1, j = 0; i < n; i++, ii--, j++)
            {
                suml2r += arr[i][j];
                sumr2l += arr[ii][j];
            }
            return Math.Abs(suml2r - sumr2l);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(diagonalDifference(arr));
        }
#endif
// ---------------------------------------------------------------------------------------------------------
// Plus Minus
// ---------------------------------------------------------------------------------------------------------
#if false
        static void plusMinus(int[] arr)
        {
            int n = arr.GetLength(0);
            int sumPos = 0;
            int sumNeg = 0;
            int sumZero = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] > 0)
                {
                    sumPos++;
                }
                else if (arr[i] < 0)
                {
                    sumNeg++;
                }
                else
                {
                    sumZero++;
                }
            }

            TextWriter textWriter = new StreamWriter(Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            textWriter.WriteLine((double)sumPos / (double)n);
            textWriter.WriteLine((double)sumNeg / (double)n);
            textWriter.WriteLine((double)sumZero / (double)n);

            textWriter.Flush();
            textWriter.Close();
        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            plusMinus(arr);
        }
#endif
// ---------------------------------------------------------------------------------------------------------
// Staircase
// ---------------------------------------------------------------------------------------------------------
#if false
        static void staircase(int n)
        {
            TextWriter textWriter = new StreamWriter(Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            for (int i = 1; i <= n; i++)
            {
                string line = "";
                int m = n - i;
                for (int j = 0; j < m; j++)
                {
                    line += ' ';
                }
                for (int j = 0; j < i; j++) {
                    line += '#';
                }
                textWriter.WriteLine(line);
            }

            textWriter.Flush();
            textWriter.Close();
        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            staircase(n);
        }
#endif
// ---------------------------------------------------------------------------------------------------------
// Mini-Max Sum
// ---------------------------------------------------------------------------------------------------------
#if false
        static void miniMaxSum(int[] arr)
        {
            int n = arr.GetLength(0);
            long min = long.MaxValue;
            long max = long.MinValue;
            for (int skip = 0; skip < n; skip++)
            {
                long sum = 0;
                for (int i = 0; i < n; i++)
                {
                    if (i == skip)
                    {
                        continue;
                    }

                    sum += arr[i];
                }

                if (sum < min)
                {
                    min = sum;
                }
                if (sum > max)
                {
                    max = sum;
                }
            }

            TextWriter textWriter = new StreamWriter(Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            textWriter.Write(min);
            textWriter.Write(' ');
            textWriter.Write(max);
            textWriter.WriteLine();
            textWriter.Flush();
            textWriter.Close();
        }

        static void Main(string[] args)
        {
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            miniMaxSum(arr);
        }
#endif
// ---------------------------------------------------------------------------------------------------------
// Birthday Cake Candles
// ---------------------------------------------------------------------------------------------------------
#if false
        static int birthdayCakeCandles(int[] ar)
        {
            int n = ar.GetLength(0);
            int max = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                if (ar[i] > max)
                {
                    max = ar[i];
                }
            }
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (ar[i] == max)
                {
                    count++;
                }
            }
            return count;
        }

        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int arCount = Convert.ToInt32(Console.ReadLine());

            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp))
            ;
            int result = birthdayCakeCandles(ar);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
#endif
// ---------------------------------------------------------------------------------------------------------
// Time Conversion
// ---------------------------------------------------------------------------------------------------------
#if false
        // From 12:00 AM (midnight) to 12:59 AM you subtract 12 hours
        // From 1:00 PM to 11:59 PM you add 12 hours
        static string timeConversion(string s)
        {
            Regex regex = new Regex(@"(?<hour>\d{2}):(?<minute>\d{2}):(?<second>\d{2})(?<antipostmeridiem>AM|PM)");
            Match match = regex.Match(s);

            if (!match.Success)
            {
                return "";
            }

            int hour = int.Parse(match.Groups["hour"].Value);
            bool antimeridiem = match.Groups["antipostmeridiem"].Value.Equals("AM");
            if (antimeridiem)
            {
                if (hour == 12)
                {
                    hour -= 12;
                }
            }
            else
            {
                if (hour != 12)
                {
                    hour += 12;
                }
            }

            return hour.ToString("00") + ":" + match.Groups["minute"].Value + ":" + match.Groups["second"].Value;
        }

        static void Main(string[] args)
        {
            //TextWriter tw = new StreamWriter(Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            //string s = Console.ReadLine();

            //string result = timeConversion(s);

            Console.WriteLine("12:00:00AM" + " = " + timeConversion("12:00:00AM")); // 00:00:00
            Console.WriteLine("12:40:22AM" + " = " + timeConversion("12:40:22AM")); // 00:40:22
            Console.WriteLine("01:02:03AM" + " = " + timeConversion("01:02:03AM")); // 01:02:03
            Console.WriteLine("06:40:03AM" + " = " + timeConversion("06:40:03AM")); // 06:40:03
            Console.WriteLine("12:45:54PM" + " = " + timeConversion("12:45:54PM")); // 12:45:54
            Console.WriteLine("01:02:03PM" + " = " + timeConversion("01:02:03PM")); // 13:02:03
            Console.WriteLine("07:05:45PM" + " = " + timeConversion("07:05:45PM")); // 19:05:45
            Console.WriteLine("11:59:59PM" + " = " + timeConversion("11:59:59PM")); // 23:59:59

            //tw.WriteLine(result);

            //tw.Flush();
            //tw.Close();
        }
#endif
// ---------------------------------------------------------------------------------------------------------
// Tree Pruning
// ---------------------------------------------------------------------------------------------------------
#if false
        private class TreeNode
        {
            public int idx { get; }
            public int weight { get; }
            public long treeWeight { get; set;  }
            public bool pruned { get; set;  }
            public List<TreeNode> children { get; }

            public TreeNode(int _idx, int _weight)
            {
                idx = _idx;
                weight = _weight;
                treeWeight = 0;
                pruned = false;
                children = new List<TreeNode>();
            }

            public void AddChild(TreeNode child)
            {
                children.Add(child);
            }
        }

#if false
        private static void PrintTree(TreeNode node, string title = null)
        {
            if (title != null)
            {
                Console.WriteLine(title);
            }
            if (node.pruned)
            {
                return;
            }
            Console.Write($"{node.idx} {node.weight}");
            foreach (TreeNode child in node.children)
            {
                if (child.pruned)
                {
                    continue;
                }
                Console.Write($" {child.idx}");
            }
            Console.WriteLine();
            foreach (TreeNode child in node.children)
            {
                PrintTree(child);
            }
        }
#endif

        private static void CaluculateTreeWeights(TreeNode node)
        {
            if (node.pruned)
            {
                return;
            }
            node.treeWeight = node.weight;
            foreach (TreeNode child in node.children)
            {
                CaluculateTreeWeights(child);
                node.treeWeight += child.treeWeight;
            }
            //Console.WriteLine($"Node {node.idx}: Weight = {node.treeWeight}");
        }

        private static void PruneNode(TreeNode node)
        {
            if (node == null)
            {
                return;
            }
            node.pruned = true;
            node.treeWeight = 0;
            foreach (TreeNode child in node.children)
            {
                PruneNode(child);
            }
        }

        private static TreeNode FindNodeToPrune(List<TreeNode> nodes)
        {
            long minTreeWeight = 0;
            TreeNode nodeToPrune = null;
            foreach (TreeNode node in nodes)
            {
                if (node.pruned)
                {
                    continue;
                }
                if (node.treeWeight < minTreeWeight)
                {
                    nodeToPrune = node;
                    minTreeWeight = node.treeWeight;
                }
            }
            return nodeToPrune;
        }

        private static TreeNode FindNode(List<TreeNode> nodes, int idx)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.idx == idx)
                {
                    return node;
                }
            }
            return null;
        }

        private static void BuildTree(int n, List<TreeNode> nodes, int[][] tree)
        {
            for (int i = 0; i < n - 1; i++)
            {
                TreeNode vertex0 = FindNode(nodes, tree[i][0]);
                TreeNode vertex1 = FindNode(nodes, tree[i][1]);
                if (vertex0.idx < vertex1.idx)
                {
                    vertex0.AddChild(vertex1);
                }
                else
                {
                    vertex1.AddChild(vertex0);
                }
            }
        }

        private static long treePrunning(int k, int[] weights, int[][] tree)
        {
            int n = weights.GetLength(0);

            List<TreeNode> nodes = new List<TreeNode>();
            for (int i = 0, idx = 1; i < n; i++, idx++)
            {
                nodes.Add(new TreeNode(idx, weights[i]));
            }

            BuildTree(n, nodes, tree);

            TreeNode root = nodes.First();

            //PrintTree(root, "Tree");
            CaluculateTreeWeights(root);

            for (int i = 0; i < k; i++)
            {
                TreeNode nodeToPrune = FindNodeToPrune(nodes);
                if (nodeToPrune == null)
                {
                    break;
                }

                //Console.WriteLine($"Node To Prune: {nodeToPrune.idx} {nodeToPrune.treeWeight}");
                PruneNode(nodeToPrune);

                //PrintTree(root, "Tree");
                CaluculateTreeWeights(root);
            }

            return root.treeWeight;
        }

        static void Main(string[] args)
        {
            /*
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] nk = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            int[] weights = Array.ConvertAll(Console.ReadLine().Split(' '), weightsTemp => Convert.ToInt32(weightsTemp));

            int[][] tree = new int[n - 1][];

            for (int treeRowItr = 0; treeRowItr < n - 1; treeRowItr++)
            {
                tree[treeRowItr] = Array.ConvertAll(Console.ReadLine().Split(' '), treeTemp => Convert.ToInt32(treeTemp));
            }

            int result = treePrunning(k, weights, tree);
            */

#if false
            int n = 5;
            int k = 2;
            int[] weights = { 1, 1, -1, -1, -1 };
            int[][] tree = new int[n - 1][];
            tree[0] = new int[] { 1, 2 };
            tree[1] = new int[] { 2, 3 };
            tree[2] = new int[] { 4, 1 };
            tree[3] = new int[] { 4, 5 };
#elif true
            int n = 20;
            int k = 5;
            int[] weights = { 773581246, -348306003, -788117784, 629111611, -142726426, 241605607, 418519531, -291199082, -453706450, -850635818, -641575760, 453047217, -874946563, -257858612, 927125122, 860575225, -162713554, 61368550, -262466871, 361084678 };
            int[][] tree = new int[n - 1][];
            tree[0] = new int[] { 2, 1 };
            tree[1] = new int[] { 3, 2 };
            tree[2] = new int[] { 4, 2 };
            tree[3] = new int[] { 5, 1 };
            tree[4] = new int[] { 6, 3 };
            tree[5] = new int[] { 7, 2 };
            tree[6] = new int[] { 8, 1 };
            tree[7] = new int[] { 9, 6 };
            tree[8] = new int[] { 10, 7 };
            tree[9] = new int[] { 11, 8 };
            tree[10] = new int[] { 12, 1 };
            tree[11] = new int[] { 13, 7 };
            tree[12] = new int[] { 14, 10 };
            tree[13] = new int[] { 15, 3 };
            tree[14] = new int[] { 16, 14 };
            tree[15] = new int[] { 17, 14 };
            tree[16] = new int[] { 18, 15 };
            tree[17] = new int[] { 19, 17 };
            tree[18] = new int[] { 20, 3 };
#endif

            long result = treePrunning(k, weights, tree);
            Console.WriteLine(result);

            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
#endif
// ---------------------------------------------------------------------------------------------------------
// Grading Students
// ---------------------------------------------------------------------------------------------------------
#if false
        public static List<int> gradingStudents(List<int> grades)
        {
            List<int> newGrades = new List<int>(grades.Count);
            foreach (int grade in grades)
            {
                int newGrade;
                if (grade < 38)
                {
                    newGrade = grade;
                }
                else
                {
                    int roundedGrade = ((grade / 5) * 5) + 5;
                    newGrade = ((roundedGrade - grade) < 3) ? roundedGrade : grade;
                }
                newGrades.Add(newGrade);
            }
            return newGrades;
        }

        public static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            //int gradesCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> grades = new List<int> { 73, 67, 38, 33 };

            /*for (int i = 0; i < gradesCount; i++)
            {
                int gradesItem = Convert.ToInt32(Console.ReadLine().Trim());
                grades.Add(gradesItem);
            }*/

            List<int> result = gradingStudents(grades);

            //textWriter.WriteLine(String.Join("\n", result));

            //textWriter.Flush();
            //textWriter.Close();
        }
#endif
// ---------------------------------------------------------------------------------------------------------
// Apple and Orange
// ---------------------------------------------------------------------------------------------------------
#if false
        static void countApplesAndOranges(int s, int t, int a, int b, int[] apples, int[] oranges)
        {
            int nbrApplesInHouse = 0;
            foreach (int d in apples)
            {
                if (d > 0)
                {
                    int loc = a + d;
                    if ((loc >= s) && (loc <= t))
                    {
                        nbrApplesInHouse++;
                    }
                }
            }
            Console.WriteLine(nbrApplesInHouse);

            int nbrOrangesInHouse = 0;
            foreach (int d in oranges)
            {
                if (d < 0)
                {
                    int loc = b + d;
                    if ((loc >= s) && (loc <= t))
                    {
                        nbrOrangesInHouse++;
                    }
                }
            }
            Console.WriteLine(nbrOrangesInHouse);
        }

        static void Main(string[] args)
        {
            /*
            string[] st = Console.ReadLine().Split(' ');

            int s = Convert.ToInt32(st[0]);

            int t = Convert.ToInt32(st[1]);

            string[] ab = Console.ReadLine().Split(' ');

            int a = Convert.ToInt32(ab[0]);

            int b = Convert.ToInt32(ab[1]);

            string[] mn = Console.ReadLine().Split(' ');

            int m = Convert.ToInt32(mn[0]);

            int n = Convert.ToInt32(mn[1]);

            int[] apples = Array.ConvertAll(Console.ReadLine().Split(' '), applesTemp => Convert.ToInt32(applesTemp));

            int[] oranges = Array.ConvertAll(Console.ReadLine().Split(' '), orangesTemp => Convert.ToInt32(orangesTemp));
            */

            //countApplesAndOranges(s, t, a, b, apples, oranges);

            int[] apples = new int[] { -2, 2, 1 };
            int[] oranges = new int[] { 5, -6 };
            countApplesAndOranges(7, 11, 5, 15, apples, oranges);
        }
#endif
// ---------------------------------------------------------------------------------------------------------
// Kangaroo
// ---------------------------------------------------------------------------------------------------------
#if false
        static string kangaroo(int x1, int v1, int x2, int v2)
        {
            if (x1 == x2)
            {
                return "YES";
            }
            if (((x2 > x1) && (v2 >= v1)) || ((x1 > x2) && (v1 >= v2)))
            {
                return "NO";
            }
            int num = x2 - x1;
            int denom = v1 - v2;
            return ((num % denom) == 0) ? "YES" : "NO";
        }
        static void Main(string[] args)
        {
            Console.WriteLine(kangaroo(0, 3, 4, 2));
            Console.WriteLine(kangaroo(0, 2, 5, 3));
        }
#endif
// ---------------------------------------------------------------------------------------------------------
// Between Two Sets
// ---------------------------------------------------------------------------------------------------------
#if false
        public static void PrintNumbers(List<int> nbrs)
        {
            foreach (int n in nbrs)
            {
                Console.Write($"{n}, ");
            }
            Console.WriteLine();
        }
        public static int getTotalX(List<int> a, List<int> b)
        {
            int minb = b.Min();

            List<int> factorsofa = new List<int>();
            for (int i = 1; i <= minb; i++)
            {
                bool isfactor = true;
                foreach (int an in a)
                {
                    if ((i % an) != 0)
                    {
                        isfactor = false;
                        break;
                    }
                }
                if (isfactor)
                {
                    factorsofa.Add(i);
                }
            }

            //PrintNumbers(a);
            //PrintNumbers(factorsofa);

            List<int> factorsofb = new List<int>();
            foreach (int an in factorsofa)
            {
                bool isfactor = true;
                foreach (int bn in b)
                {
                    if ((bn % an) != 0)
                    {
                        isfactor = false;
                        break;
                    }
                }
                if (isfactor)
                {
                    factorsofb.Add(an);
                }
            }

            //PrintNumbers(b);
            //PrintNumbers(factorsofb);

            return factorsofb.Count;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(getTotalX(new List<int> { 2, 4 }, new List<int> { 16, 32, 96 }));
        }
#endif
// ---------------------------------------------------------------------------------------------------------
// Breaking the Records
// ---------------------------------------------------------------------------------------------------------
#if false
        static int[] breakingRecords(int[] scores)
        {
            int n = scores.Count();

            int[] recordsbroken = new int[] { 0, 0 };
            if (n == 0)
            {
                return recordsbroken;
            }

            int min = scores[0];
            int max = scores[0];
            for (int i = 1; i < n; i++)
            {
                if (scores[i] < min)
                {
                    min = scores[i];
                    recordsbroken[1]++;
                }
                if (scores[i] > max)
                {
                    max = scores[i];
                    recordsbroken[0]++;
                }
            }
            return recordsbroken;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(breakingRecords(new int[] { 10, 5, 20, 20, 4, 5, 2, 25, 1 }));
        }
#endif
// ---------------------------------------------------------------------------------------------------------
// Birthday Chocolate
// ---------------------------------------------------------------------------------------------------------
#if false
        static int birthday(List<int> s, int d, int m)
        {
            int n = s.Count;
            int[] sa = s.ToArray();
            int maxi = n - m;

            if (maxi < 0)
            {
                return 0;
            }

            int nbrSegments = 0;

            for (int i = 0; i <= maxi; i++)
            {
                int segmentSum = 0;
                for (int j = 0; j < m; j++)
                {
                    segmentSum += sa[i+j];
                }
                if (segmentSum == d)
                {
                    nbrSegments++;
                }
            }

            return nbrSegments;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(birthday(new List<int> { 1, 2, 1, 3, 2 }, 3, 2));
            Console.WriteLine(birthday(new List<int> { 1, 1, 1, 1, 1 }, 3, 2));
            Console.WriteLine(birthday(new List<int> { 4 }, 4, 1));
        }
#endif
// ---------------------------------------------------------------------------------------------------------
// Divisible Sum Pairs
// ---------------------------------------------------------------------------------------------------------
#if false
        static int divisibleSumPairs(int n, int k, int[] ar)
        {
            int numdivisible = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (((ar[i] + ar[j]) % k) == 0)
                    {
                        numdivisible++;
                    }
                }
            }
            return numdivisible;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(divisibleSumPairs(6, 3, new List<int> { 1, 3, 2, 6, 1, 2 }.ToArray()));
        }
#endif
// ---------------------------------------------------------------------------------------------------------
// Migratory Birds
// ---------------------------------------------------------------------------------------------------------
#if false
        static int migratoryBirds(List<int> arr)
        {
            List<int> birdIdSums = new List<int>(arr.Count);
            foreach (int id in arr)
            {
                birdIdSums.Add(0);
            }
            foreach (int id in arr)
            {
                birdIdSums[id]++;
            }
            return birdIdSums.IndexOf(birdIdSums.Max());
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(migratoryBirds(new List<int> { 1, 4, 4, 4, 5, 3 }));
        }
#endif
// ---------------------------------------------------------------------------------------------------------
// Day of the Programmer
// ---------------------------------------------------------------------------------------------------------
#if false
        static string dayOfProgrammer(int year)
        {
            bool isLeapYearJulian = ((year % 4) == 0);
            bool isLeapYearGregorian = ((year % 400) == 0) || (((year % 4) == 0) && ((year % 100) != 0));
            int[] daysInMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            if (year == 1918)   // Switch
            {
                daysInMonth[1] = 15;
            }
            else if (year < 1918) // Julian Calendar
            {
                if (isLeapYearJulian)
                {
                    daysInMonth[1] = 29;
                }
            }
            else /* (year > 1918) */ // Gregorian Calendar
            {
                if (isLeapYearGregorian)
                {
                    daysInMonth[1] = 29;
                }
            }

            int mm = 0;
            int days = 0;
            do
            {
                days += daysInMonth[++mm];
            }
            while (days < 256);
            days -= daysInMonth[mm];

            int dd = 256 - days - 1;

            return dd.ToString("00") + "." + mm.ToString("00") + "." + year.ToString("0000");
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(dayOfProgrammer(2017));   // 13.09.2017
            Console.WriteLine(dayOfProgrammer(2016));   // 12.09.2016
            Console.WriteLine(dayOfProgrammer(1800));   // 12.09.2016
            Console.WriteLine(dayOfProgrammer(1918));   // 26.09.1918
        }
#endif
// ---------------------------------------------------------------------------------------------------------
// Bon Appétit
// ---------------------------------------------------------------------------------------------------------
#if false
        static void bonAppetit(List<int> bill, int k, int b)
        {
            long billSum = 0;
            for (int i = 0; i < bill.Count; i++)
            {
                if (i != k)
                {
                    billSum += bill[i];
                } 
            }

            long chargediff = b - (billSum / 2);

            Console.WriteLine((chargediff == 0) ? "Bon Appetit" : $"{chargediff}");
        }

        public static void Main(string[] args)
        {
            bonAppetit(new List<int>() { 3, 10, 2, 9 }, 1, 12); // 5
            bonAppetit(new List<int>() { 3, 10, 2, 9 }, 1, 7);  // Bon Appetit
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        private static String ConvertOnesNumberToString(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = "";
            switch (_Number)
            {
                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }

        private static String ConvertTensNumberToString(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = null;
            switch (_Number)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (_Number > 0)
                    {
                        name = ConvertTensNumberToString(Number.Substring(0, 1) + "0") + ConvertOnesNumberToString(Number.Substring(1));
                    }
                    break;
            }
            return name;
        }

        private static String ConvertNumberToStringRepresentation(String Number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;
                bool isDone = false;
                double dblAmt = (Convert.ToDouble(Number));
                if (dblAmt > 0)
                {
                    beginsZero = Number.StartsWith("0");

                    int numDigits = Number.Length;
                    int pos = 0; 
                    String place = "";
                    switch (numDigits)
                    {
                        case 1:

                            word = ConvertOnesNumberToString(Number);
                            isDone = true;
                            break;
                        case 2:
                            word = ConvertTensNumberToString(Number);
                            isDone = true;
                            break;
                        case 3: 
                            pos = (numDigits % 3) + 1;
                            place = "Hundred";
                            break;
                        case 4:
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = "Thousand";
                            break;
                        case 7:
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = "Million";
                            break;
                        case 10:
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = "Billion";
                            break;
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {
                        if (Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertNumberToStringRepresentation(Number.Substring(0, pos)) + place + ConvertNumberToStringRepresentation(Number.Substring(pos));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertNumberToStringRepresentation(Number.Substring(0, pos)) + ConvertNumberToStringRepresentation(Number.Substring(pos));
                        }

                    }
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }
            return word.Trim();
        }

        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    int nbr;
                    bool parsed = int.TryParse(line, out nbr);
                    if (parsed)
                    {
                        string dollars = (nbr == 1) ? "Dollar" : "Dollars";
                        string nbrStr = ConvertNumberToStringRepresentation(line);
                        Console.WriteLine(nbrStr + dollars);
                    }
                }
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
    static void Main()
    {
        using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                var characterCount = new Dictionary<char, int>();
                foreach (var c in line)
                {
                    if (characterCount.ContainsKey(c))
                        characterCount[c]++;
                    else
                        characterCount[c] = 1;
                }

                String sortedDistinctLetters = String.Concat(line.Distinct().OrderBy(c => c));
                String output = "";
                foreach (var c in sortedDistinctLetters)
                {
                    output += (c + $"{characterCount[c]}");
                }

                Console.WriteLine(output);
            }
    }
#endif
// ---------------------------------------------------------------------------------------------------------
// IsUserNameValid
// ---------------------------------------------------------------------------------------------------------
#if false
    private static string ReverseString(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }

    private static bool IsUserNameValid(string userName)
    {
        if (string.IsNullOrEmpty(userName))
        {
            return false;
        }

        string[] userNameParts = userName.Split('$');
        if (userNameParts.Length != 2)
        {
            return false;
        }

        string part0 = userNameParts[0];
        if (!char.IsUpper(part0[0]))
        {
            return false;
        }

        string part1 = userNameParts[1];
        if (!char.IsUpper(part1[0]))
        {
            return false;
        }

        string part1Reversed = ReverseString(part1);
        int nbrDigits = 0;
        bool letterSeen = false;
        foreach (char c in part1Reversed)
        {
            if (char.IsNumber(c))
            {
                if (letterSeen)
                {
                    return false;
                }
                if (++nbrDigits > 3)
                {
                    return false;
                }
            }
            else if (char.IsLetter(c))
            {
                letterSeen = true;
            }
            else
            {
                return false;
            }
        }

        return true;
    }

    static void Main()
    {
        using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                bool valid = IsUserNameValid(line);
                Console.WriteLine(valid ? "true" : "false");
            }
    }
#endif
// ---------------------------------------------------------------------------------------------------------
// Sock Merchant
// ---------------------------------------------------------------------------------------------------------
#if false
        static int sockMerchant(int n, int[] ar)
        {
            // color and count
            var colorCount = new Dictionary<int, int>();
            foreach (var c in ar)
            {
                if (colorCount.ContainsKey(c))
                    colorCount[c]++;
                else
                    colorCount[c] = 1;
            }

            int nbrPairs = 0;
            foreach (int count in colorCount.Values)
            {
                nbrPairs += (count / 2);
            }
            return nbrPairs;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(sockMerchant(9, new List<int>() { 10, 20, 20, 10, 10, 30, 50, 10, 20 }.ToArray())); // 3
        }
#endif
// ---------------------------------------------------------------------------------------------------------
// Longest Palindrome
// ---------------------------------------------------------------------------------------------------------
#if false
        public static string LongestPalindrome(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return string.Empty;
            }

            int startIndex = 0, length = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if ((str.Length - i) <= length)
                {
                    break;
                }

                for (int j = str.Length - 1; j >= i; j--)
                {
                    int curLength = j - i + 1;
                    if (curLength <= length)
                    {
                        break;
                    }

                    bool isPalindrome = true;
                    for (int k = i, l = j; k < l; k++, l--)
                    {
                        if (str[k] != str[l])
                        {
                            isPalindrome = false;
                            break;
                        }
                    }

                    if (isPalindrome)
                    {
                        startIndex = i;
                        length = curLength;
                    }
                }
            }

            return str.Substring(startIndex, length);
        }

        public static void RunTest(string str, string answer)
        {
            string longestPalindrome = LongestPalindrome(str);
            string notCorrect = longestPalindrome.Equals(answer) ? "" : " IS NOT CORRECT!";
            Console.WriteLine($"input='{str}', Longest Palindrome = '{longestPalindrome}', Answer = '{answer}'{notCorrect}");
        }

        static void Main(string[] args)
        {
            RunTest(null, "");
            RunTest("", "");
            RunTest("a", "a");
            RunTest("ab", "a");
            RunTest("aba", "aba");
            RunTest("abb", "bb");
            RunTest("xaba", "aba");
            RunTest("abax", "aba");
            RunTest("xaay", "aa");
            RunTest("xabay", "aba");
            RunTest("abcxy", "a");
            RunTest("abcxyz", "a");
            RunTest("abaxyx", "aba");
            RunTest("abbaxyx", "abba");
            RunTest("xanbay", "x");
            RunTest("xanbayy", "yy");
            RunTest("abaxyz", "aba");
            RunTest("xyabbajk", "abba");
            RunTest("xyabzbajk", "abzba");
            RunTest("xyabzybajk", "x");
            RunTest("xyaabzybajk", "aa");
            RunTest("xnabaynabaabzn", "baab");
            RunTest("xnbaabynabaabzn", "baab");
            RunTest("racecar", "racecar");
            RunTest("xracecar", "racecar");
            RunTest("xracecary", "racecar");
            RunTest("xreracecargul", "racecar");
            RunTest("tattarrattat", "tattarrattat");
            RunTest("tattarxyrattat", "atta");
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        public class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;
        }

        public static SinglyLinkedListNode removeNodes(SinglyLinkedListNode listHead, int x)
        {
            SinglyLinkedListNode newList = null;
            SinglyLinkedListNode curNode = null;

            for (SinglyLinkedListNode node = listHead; node != null; node = node.next)
            {
                if (node.data <= x)
                {
                    SinglyLinkedListNode newNode = new SinglyLinkedListNode();
                    newNode.data = node.data;
                    newNode.next = null;

                    if (newList == null)
                    {
                        newList = newNode;
                    }
                    else
                    {
                        curNode.next = newNode;
                    }
                    curNode = newNode;
                }
            }
            return newList;
        }

        static void Main(string[] args)
        {
            SinglyLinkedList listHead = new SinglyLinkedList();
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        public static List<int> getMinimumDifference(List<string> a, List<string> b)
        {
            int n = a.Count;

            List<int> result = new List<int>();
            for (int i = 0; i < n; i++)
            {
                string aa = a[i];
                string bb = b[i];
                if (aa.Length != bb.Length)
                {
                    result.Add(-1);
                }
                else
                {
                    int len = aa.Length;

                    char[] aaIntobb = new char[len];
                    for (int j = 0; j < len; j++)
                    {
                        aaIntobb[j] = ' ';
                    }

                    int count = 0;
                    for (int j = 0; j < len; j++)
                    {
                        char ach = aa[j];
                        bool placed = false;
                        for (int k = 0; k < len; k++)
                        {
                            char bch = bb[k];
                            if (ach == bch)
                            {
                                if (aaIntobb[k] == ' ')
                                {
                                    aaIntobb[k] = ach;
                                    placed = true;
                                    break;
                                }
                            }
                        }
                        if (!placed)
                        {
                            count++;
                        }
                    }
                    result.Add(count);
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
        }
#endif
// ---------------------------------------------------------------------------------------------------------
// Forming a Magic Square
// ---------------------------------------------------------------------------------------------------------
#if false
        static int[,] ms = new int[3, 3] { { 4, 9, 2 }, { 3, 5, 7 }, { 8, 1, 6 } };

        static int diffMagicSquare(int[][] s)
        {
            int diff = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    diff += Math.Abs(s[i][j] - ms[i,j]);
                }
            }
            return diff;
        }

        private static void flipSquare(int[][] s, int[][] sf)
        {
            sf[0][0] = s[0][2];
            sf[0][1] = s[0][1];
            sf[0][2] = s[0][0];
            sf[1][0] = s[1][2];
            sf[1][1] = s[1][1];
            sf[1][2] = s[1][0];
            sf[2][0] = s[2][2];
            sf[2][1] = s[2][1];
            sf[2][2] = s[2][0];
        }

        static void rotateSquare(int[][] s, int[][] sr)
        {
            sr[0][0] = s[2][0];
            sr[0][1] = s[1][0];
            sr[0][2] = s[0][0];
            sr[1][0] = s[2][1];
            sr[1][1] = s[1][1];
            sr[1][2] = s[0][1];
            sr[2][0] = s[2][2];
            sr[2][1] = s[1][2];
            sr[2][2] = s[0][2];
        }

        static void initializeSquare(int[][] s)
        {
            s[0] = new int[3] { 0, 0, 0 };
            s[1] = new int[3] { 0, 0, 0 };
            s[2] = new int[3] { 0, 0, 0 };
        }

        static int formingMagicSquare(int[][] s)
        {
            List<int> diffs = new List<int>();

            diffs.Add(diffMagicSquare(s));
            int[][] sf = new int[3][];
            initializeSquare(sf);
            flipSquare(s, sf);
            diffs.Add(diffMagicSquare(sf));

            int[][] s1r = new int[3][];
            initializeSquare(s1r);
            rotateSquare(s, s1r);
            diffs.Add(diffMagicSquare(s1r));
            int[][] s1f = new int[3][];
            initializeSquare(s1f);
            flipSquare(s1r, s1f);
            diffs.Add(diffMagicSquare(s1f));

            int[][] s2r = new int[3][];
            initializeSquare(s2r);
            rotateSquare(s1r, s2r);
            diffs.Add(diffMagicSquare(s2r));
            int[][] s2f = new int[3][];
            initializeSquare(s2f);
            flipSquare(s2r, s2f);
            diffs.Add(diffMagicSquare(s2f));

            int[][] s3r = new int[3][];
            initializeSquare(s3r);
            rotateSquare(s2r, s3r);
            diffs.Add(diffMagicSquare(s3r));
            int[][] s3f = new int[3][];
            initializeSquare(s3f);
            flipSquare(s3r, s3f);
            diffs.Add(diffMagicSquare(s3f));

            return diffs.Min();
        }

        static void Main(string[] args)
        {
            int[][] s = new int[3][];

            // 1
            s[0] = new int[3] { 4, 9, 2 };
            s[1] = new int[3] { 3, 5, 7 };
            s[2] = new int[3] { 8, 1, 5 };
            Console.WriteLine(formingMagicSquare(s));

            // 4
            s[0] = new int[] { 4, 8, 2 };
            s[1] = new int[] { 4, 5, 7 };
            s[2] = new int[] { 6, 1, 6 };
            Console.WriteLine(formingMagicSquare(s));

            // 18
            s[0] = new int[] { 9, 3, 3 };
            s[1] = new int[] { 3, 3, 2 };
            s[2] = new int[] { 1, 8, 1 };
            Console.WriteLine(formingMagicSquare(s));
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        // The Power Sum
        // Natural numbers are a set of positive integers from 1 to infinity
        static int powerSum(int X, int N)
        {
            int max = (int)Math.Pow(X, (1.0 / N));
            int[] powers = new int[max];
            for (int i = 0; i < max; i++)
            {
                powers[i] = (int)Math.Pow(i + 1, N);
            }

            int nbrCombinationsThatAddUpToX = 0;

            int nbrCombinations = (int)Math.Pow(2, max);

            for (int i = nbrCombinations - 1; i >= 1; i--)
            {
                int powerSum = 0;
                for (int j = max - 1; j >= 0; j--)
                {
                    if (((i >> j) % 2) != 0)
                    {
                        powerSum += powers[j];
                        if (powerSum > X)
                        {
                            break;
                        }
                    }
                }
                if (powerSum == X)
                {
                    nbrCombinationsThatAddUpToX++;
                }
            }

            return nbrCombinationsThatAddUpToX;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(powerSum(10, 1));     // 10
            Console.WriteLine(powerSum(10, 2));     // 1
            Console.WriteLine(powerSum(100, 2));    // 3
            Console.WriteLine(powerSum(100, 3));    // 1
            Console.WriteLine(powerSum(800, 2));    // 561
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
    class Spot
    {
        public Spot(int _row, int _col, int _len, bool _isHorizontal)
        {
            row = _row;
            col = _col;
            len = _len;
            isHorizontal = _isHorizontal;
        }

        public int row { get; }
        public int col { get; }
        public int len { get; }
        public bool isHorizontal { get; }
    }

    class WordSpotCombination
    {
        public WordSpotCombination(string _word, Spot _spot)
        {
            word = _word;
            spot = _spot;
        }

        public string word { get; }
        public Spot spot { get; }
    }

    class Program
    {
        static void copyCrossword(char[,] cwIn, string[] cwOut)
        {
            for (int i = 0; i < 10; i++)
            {
                StringBuilder sb = new StringBuilder("          ");
                for (int j = 0; j < 10; j++)
                {
                    sb[j] = cwIn[i, j];
                }
                 cwOut[i]= sb.ToString();
            }
        }

        static void copyCrossword(char[,] cwIn, char[,] cwOut)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    cwOut[i,j] = cwIn[i,j];
                }
            }
        }

        static void copyCrossword(string[] cwIn, char[,] cwOut)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    cwOut[i, j] = cwIn[i][j];
                }
            }
        }

        static List<Spot> getSpots(char[,] cw)
        {
            List<Spot> spots = new List<Spot>();

            for (int i = 0; i < 10; i++)
            {
                int startCol = 0;
                int endCol = 0;

                int j = 0;
                while (j < 10)
                {
                    if ((cw[i,j] == '-') && ((j + 1) < 10) && (cw[i,j+1] == '-'))
                    {
                        startCol = j;
                        while ((j < 10) && (cw[i,j] == '-'))
                        {
                            j++;
                        }
                        endCol = j - 1;
                        spots.Add(new Spot(i, startCol, (endCol - startCol + 1), true));
                    }
                    else
                    {
                        j++;
                    }
                }
            }

            for (int j = 0; j < 10; j++)
            {
                int startRow = 0;
                int endRow = 0;

                int i = 0;
                while (i < 10)
                {
                    if ((cw[i,j] == '-') && ((i + 1) < 10) && (cw[i + 1,j] == '-'))
                    {
                        startRow = i;
                        while ((i < 10) && (cw[i,j] == '-'))
                        {
                            i++;
                        }
                        endRow = i - 1;
                        spots.Add(new Spot(startRow, j, (endRow - startRow + 1), false));
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            return spots;
        }

        static void copyWordToSpot(string word, Spot spot, char[,] cw)
        {
            if (spot.isHorizontal)
            {
                int j = spot.col;
                for (int n = 0; n < spot.len; n++, j++)
                {
                    cw[spot.row,j] = word[n];
                }
            }
            else
            {
                int i = spot.row;
                for (int n = 0; n < spot.len; n++, i++)
                {
                    cw[i, spot.col] = word[n];
                }
            }
        }

        static List<List<WordSpotCombination>> getCombinationSets(List<string> wordsList, List<Spot> spotsList)
        {
            List<List<WordSpotCombination>> combinationSets = new List<List<WordSpotCombination>>();

            for (int wordIdx = 0; wordIdx < wordsList.Count; wordIdx++)
            {
                int idx = wordIdx;
                List<WordSpotCombination> combinations = new List<WordSpotCombination>();
                foreach (Spot spot in spotsList)
                {
                    string word = wordsList[idx];
                    combinations.Add(new WordSpotCombination(word, spot));
                    Console.Write($"[{word} {spot.row} {spot.col} {spot.len}], ");
                    if (++idx == wordsList.Count)
                    {
                        idx = 0;
                    }
                }
                Console.WriteLine();
                combinationSets.Add(combinations);
            }

            for (int i = combinationSets.Count - 1; i >= 0; i--)
            {
                List<WordSpotCombination> combinations = combinationSets[i];

                bool remove = false;
                foreach (WordSpotCombination combination in combinations)
                {
                    if (combination.word.Length != combination.spot.len)
                    {
                        remove = true;
                        break;
                    }
                }
                if (remove)
                {
                    combinationSets.RemoveAt(i);
                }
            }

            return combinationSets;
        }

        static string[] crosswordPuzzle(string[] crossword, string words)
        {
            char[,] cwIn = new char[10, 10];
            copyCrossword(crossword, cwIn);

            List<string> wordsList = words.Split(';').ToList();
            List<Spot> spotsList = getSpots(cwIn);
            List<List<WordSpotCombination>> combinationSets = getCombinationSets(wordsList, spotsList);

            char[,] cwOut = new char[10,10];
            copyCrossword(cwIn, cwOut);
            printCrossword(cwOut);

            string[] cwRet = new string[10];
            copyCrossword(cwOut, cwRet);

            return cwRet;
        }

        static void printCrossword(char[,] cw)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(cw[i,j]);
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            string[] crossword = new string[10];
            string[] result;

#if false
            crossword[0] = "+-++++++++";
            crossword[1] = "+-++++++++";
            crossword[2] = "+-++++++++";
            crossword[3] = "+-----++++";
            crossword[4] = "+-+++-++++";
            crossword[5] = "+-+++-++++";
            crossword[6] = "+++++-++++";
            crossword[7] = "++------++";
            crossword[8] = "+++++-++++";
            crossword[9] = "+++++-++++";
            result = crosswordPuzzle(crossword, "LONDON;DELHI;ICELAND;ANKARA");
#endif

            crossword[0] = "+-++++++++";
            crossword[1] = "+-++++++++";
            crossword[2] = "+-------++";
            crossword[3] = "+-++++++++";
            crossword[4] = "+-++++++++";
            crossword[5] = "+------+++";
            crossword[6] = "+-+++-++++";
            crossword[7] = "+++++-++++";
            crossword[8] = "+++++-++++";
            crossword[9] = "++++++++++";
            result = crosswordPuzzle(crossword, "AGRA;NORWAY;ENGLAND;GWALIOR");
        }
    }
#endif
// ---------------------------------------------------------------------------------------------------------
// Drawing Book
// ---------------------------------------------------------------------------------------------------------
#if false
        static int pageCount(int n, int p)
        {
            bool evenPage = ((p % 2) == 0);
            int fromFront = p / 2;
            int fromBack = (n - p + (evenPage ? 0 : 1)) / 2;
            return (fromFront < fromBack) ? fromFront : fromBack;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(pageCount(6, 2)); // 1
            Console.WriteLine(pageCount(5, 4)); // 0
            Console.WriteLine(pageCount(6, 6)); // 0
            Console.WriteLine(pageCount(6, 5)); // 1
            Console.WriteLine(pageCount(6, 4)); // 1
            Console.WriteLine(pageCount(6, 3)); // 1
            Console.WriteLine(pageCount(6, 2)); // 1
            Console.WriteLine(pageCount(6, 1)); // 0
        }
#endif
// ---------------------------------------------------------------------------------------------------------
// Counting Valleys
// ---------------------------------------------------------------------------------------------------------
#if false
        static int countingValleys(int n, string s)
        {
            int direction = 0;  // -1 = down, 0 = sea level, +1 = up
            int count = 0;
            int valleys = 0;
            foreach (char ch in s)
            {
                if (ch == 'U')
                {
                    switch (direction)
                    {
                        case -1:    // down
                            if (--count == 0)
                            {
                                direction = 0;
                            }
                            break;
                        case 0:     // sea-level
                            direction = 1;
                            count = 1;
                            break;
                        case 1:     // up
                            count++;
                            break;
                    }
                }
                else // (ch == 'D')
                {
                    switch (direction)
                    {
                        case -1:    // down
                            count++;
                            break;
                        case 0:     // sea-level
                            direction = -1;
                            count = 1;
                            valleys++;
                            break;
                        case 1:     // up
                            if (--count == 0)
                            {
                                direction = 0;
                            }
                            break;
                    }
                }
            }
            return valleys;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(countingValleys(8, "UDDDUDUU")); // 1
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        public static int Minimum(int x = 1, int y = 4, int z = 3)
        {
            return Min(x, Min(y, z));
        }
        public static void Main(string[] args)
        {
            Console.WriteLine(Minimum());
            Console.WriteLine(Minimum(8, z:10));
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        public static int countHoles(int num)
        {
            if (num == 0)
            {
                return 1;
            }
            int holes = 0;
            while (num > 0)
            {
                int digit = (num % 10);
                switch (digit) {
                    case 1:
                    case 2:
                    case 3:
                    case 5:
                    case 7:
                        break;
                    case 0:
                    case 4:
                    case 6:
                    case 9:
                        holes += 1;
                        break;
                    case 8:
                        holes += 2;
                        break;
                }
                num = num / 10;
            }
            return holes;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(countHoles(630)); // 2
            Console.WriteLine(countHoles(1288)); // 4
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
    internal class Comparator
    {
        internal bool compare(int num1, int num2)
        {
            return (num1 == num2);
        }
        internal bool compare(int[] ary1, int[] ary2)
        {
            if (ary1.Count() != ary2.Count())
            {
                return false;
            }
            for (int i = 0; i < ary1.Count(); i++)
            {
                if (ary1[i] != ary2[i])
                {
                    return false;
                }
            }
            return true;
        }
        internal bool compare(string s1, string s2)
        {
            return s1.CompareTo(s2) == 0;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Comparator comp = new Comparator();
            int testCases = Convert.ToInt32(Console.ReadLine());
            while (testCases-- > 0)
            {
                int condition = Convert.ToInt32(Console.ReadLine());
                if (condition == 1)
                {
                    string s1 = Console.ReadLine();
                    string s2 = Console.ReadLine();
                    if (comp.compare(s1, s2))
                    {
                        Console.WriteLine("Same");
                    }
                    else
                    {
                        Console.WriteLine("Different");
                    }
                }
                else if (condition == 2)
                {
                    int num1 = Convert.ToInt32(Console.ReadLine());
                    int num2 = Convert.ToInt32(Console.ReadLine());
                    if (comp.compare(num1, num2))
                    {
                        Console.WriteLine("Same");
                    }
                    else
                    {
                        Console.WriteLine("Different");
                    }
                }
                else if (condition == 3)
                {
                    Console.ReadLine();
                    int[] arr1 = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
                    int[] arr2 = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
                    if (comp.compare(arr1, arr2))
                    {
                        Console.WriteLine("Same");
                    }
                    else
                    {
                        Console.WriteLine("Different");
                    }
                }
            }
        }
    }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
    class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode()
        {
            this.data = /*nodeData*/0;
            this.next = null;
        }
    }

    class SinglyLinkedList
    {
        public SinglyLinkedListNode head;
        public SinglyLinkedListNode tail;

        public SinglyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
            }

            this.tail = node;
        }
    }

    class Result
    {
        public static SinglyLinkedListNode deleteOdd(SinglyLinkedListNode listHead)
        {
            SinglyLinkedList newList = null;
            SinglyLinkedListNode curNode = null;

            for (SinglyLinkedListNode node = listHead; node != null; node = node.next)
            {
                if ((node.data % 2) == 0)
                {
                    SinglyLinkedListNode newNode = new SinglyLinkedListNode();
                    newNode.data = node.data;

                    if (newList == null)
                    {
                        newList.head = newList.tail = newNode;
                    }
                    else
                    {
                        curNode.next = newNode;
                    }
                    curNode = newNode;
                }
            }
            return newList.head;
        }

    }

    class Program
    {
        public static void Main(string[] args)
        {
            SinglyLinkedList listHead = new SinglyLinkedList();
            SinglyLinkedListNode result = Result.deleteOdd(listHead.head);
        }
    }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
    class Result
    {
        public static void customSort(List<int> arr)
        {
            var integerCount = new Dictionary<int, int>();
            foreach (int n in arr)
            {
                if (integerCount.ContainsKey(n))
                    integerCount[n]++;
                else
                    integerCount[n] = 1;
            }

            var sortedIntegerCount = from entry in integerCount orderby entry.Value ascending select entry;
            foreach (var entry in sortedIntegerCount)
            {
                for (int n = 0; n < entry.Value; n++)
                {
                    Console.WriteLine(entry.Key);
                }
            }
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Result.customSort(new int[] { 2, 5, 6, 3, 2, 6 }.ToList());
        }
    }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        static public string removeChars(string s, char[] chars)
        {
            StringBuilder sb = new StringBuilder(s);
            for (int i = 0; i < s.Length; i++)
            {
                if (chars.Contains(sb[i]))
                {
                    sb[i] = ' ';
                }
            }
            return sb.ToString();
        }
        // Return a list of strings representing the most frequently used word in the text or, 
        // in case of a tie, all the most frequently used words in the text
        // Order of words does not matter
        // Treat punction as white space
        // Case does not matter
        // exclude the words in wordsToExclude
        static public List<string> retrieveMostFrequentlyUsedWords(string literatureText, List<string> wordsToExclude)
        {
            // Remove Punctuation
            char[] punctuation = new char[] { '.', ';', '\'' };
            string literatureTextWOPunctuation = Regex.Replace(removeChars(literatureText, punctuation), @"\s+", " ");

            // Get Words
            List<string> wordsUpperCase = (from word in literatureTextWOPunctuation.Split(' ') select word.ToUpper()).ToList();

            // Count words excluding those in wordsToExclude
            List<string> wordsToExcludeUpperCase = (from word in wordsToExclude select word.ToUpper()).ToList();
            var wordCount = new Dictionary<string, int>();
            foreach (string wordUpperCase in wordsUpperCase)
            {
                if (wordsToExcludeUpperCase.Contains(wordUpperCase))
                {
                    continue;
                }
                string upcaseWord = wordUpperCase.ToUpper();
                if (wordCount.ContainsKey(wordUpperCase))
                    wordCount[wordUpperCase]++;
                else
                    wordCount[wordUpperCase] = 1;
            }

            // Get words that appear the most
            var sortedWordCount = from entry in wordCount orderby entry.Value descending select entry;

            // Build the output list
            List<string> mostFrequentlyUsedWords = new List<string>();
            int max = -1;
            foreach (var entry in sortedWordCount)
            {
                if ((max != -1) && (entry.Value < max))
                {
                    break;
                }
                max = entry.Value;
                mostFrequentlyUsedWords.Add(entry.Key);
            }

            return mostFrequentlyUsedWords;
        }

        static void Main(string[] args)
        {
            string literatureText = "Jack and Jill went to the market to buy bread and cheese. Cheese is Jack's and Jill's favorite food.";
            List<string> wordsToExclude = new string[] { "and", "he", "the", "to", "is", "Jack", "Jill" }.ToList();

            List<string> mostFrequentlyUsedWords = retrieveMostFrequentlyUsedWords(literatureText, wordsToExclude);

            foreach (string word in mostFrequentlyUsedWords)
            {
                Console.WriteLine(word);
            }
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        // Cats and a Mouse
        // x: position of Cat A
        // y: position of Cat B
        // z: position of Mouse C
        // If cat A catches the mouse first, print Cat A.
        // If cat B catches the mouse first, print Cat B.
        // If both cats reach the mouse at the same time, print Mouse C as the two cats fight and mouse escapes.
        static string catAndMouse(int x, int y, int z)
        {
            int distA = Math.Abs(x - z);
            int distB = Math.Abs(y - z);

            if (distA == distB)
            {
                return "Mouse C";
            }
            else if (distA < distB)
            {
                return "Cat A";
            }
            else // if (distA > distB)
            {
                return "Cat B";
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(catAndMouse(1, 2, 3));    // Cat B
            Console.WriteLine(catAndMouse(1, 3, 2));    // Mouse C
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        // Picking Numbers
        // Given an array of integers, find and print the maximum number of integers you can select from the array such that the 
        // absolute difference between any two of the chosen integers is less than or equal to 1
        public static int pickingNumbers(List<int> a)
        {
            //printList("input list", a);

            List<List<int>> lists = new List<List<int>>();

            for (int i = 0; i < a.Count; i++)
            {
                List<int> listAbove = new List<int>();
                List<int> listBelow = new List<int>();

                for (int j = 0; j < a.Count; j++)
                {
                    if (a[j] == a[i])
                    {
                        listAbove.Add(a[j]);
                        listBelow.Add(a[j]);
                    }
                    else if (a[j] == (a[i] + 1))
                    {
                        listAbove.Add(a[j]);
                    }
                    else if (a[j] == (a[i] - 1))
                    {
                        listBelow.Add(a[j]);
                    }
                }

                lists.Add(listAbove);
                lists.Add(listBelow);
            }

            List<int> maxList = null;
            int maxLength = int.MinValue;
            for (int k = 0; k < a.Count; k++)
            {
                List<int> list = lists[k];
                if (list.Count > maxLength)
                {
                    maxLength = list.Count;
                    maxList = list;
                }
            }

            //printList("max list", maxList);

            return maxLength;
        }

        private static void printList(string str, List<int> list)
        {
            Console.Write($"{str} ({list.Count}): ");
            foreach (int n in list)
            {
                Console.Write($"{n}, ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine(pickingNumbers(new List<int> { 4, 6, 5, 3, 3, 1 }));  // 3
            Console.WriteLine(pickingNumbers(new List<int> { 1, 2, 2, 3, 1, 2 }));  // 5
            Console.WriteLine(pickingNumbers(new List<int> { 14, 18, 17, 10, 9, 20, 4, 13, 19, 19, 8, 15, 15, 17, 6, 5, 15, 12, 18, 2, 18, 7, 20, 8, 2, 8, 11, 2, 16, 2, 12, 9, 3, 6, 9, 9, 13, 7, 4, 6, 19, 7, 2, 4, 3, 4, 14, 3, 4, 9, 17, 9, 4, 20, 10, 16, 12, 1, 16, 4, 15, 15, 9, 13, 6, 3, 8, 4, 7, 14, 16, 18, 20, 11, 20, 14, 20, 12, 15, 4, 5, 10, 10, 20, 11, 18, 5, 20, 13, 4, 18, 1, 14, 3, 20, 19, 14, 2, 5, 13 }));  // 15
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        // Electronics Shop
        // Monica wants to buy a keyboard and a USB drive from her favorite electronics store. 
        // The store has several models of each. 
        // Monica wants to spend as much as possible for the  items, given her budget.
        // Given the price lists for the store's keyboards and USB drives, and Monica's budget, 
        // find and print the amount of money Monica will spend. 
        // If she doesn't have enough money to both a keyboard and a USB drive, print -1 instead. 
        // She will buy only the two required items.
        static int getMoneySpent(int[] keyboards, int[] drives, int b)
        {
            int maxMoneySpent = int.MinValue;

            foreach (int k in keyboards)
            {
                foreach (int d in drives)
                {
                    int moneySpent = k + d;
                    if (moneySpent <= b)
                    {
                        if (moneySpent > maxMoneySpent)
                        {
                            maxMoneySpent = moneySpent;
                        }
                    }
                }
            }

            return (maxMoneySpent < 0) ? -1 : maxMoneySpent;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(getMoneySpent(new int[] { 3, 1 }, new int[] { 5, 2, 8 }, 10));    // 9
            Console.WriteLine(getMoneySpent(new int[] { 4 }, new int[] { 5 }, 5));              // -1
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        // The Hurdle Race
        // Dan is playing a video game in which his character competes in a hurdle race. 
        // Hurdles are of varying heights, and Dan has a maximum height he can jump. 
        // There is a magic potion he can take that will increase his maximum height by unit for each dose. 
        // How many doses of the potion must he take to be able to jump all of the hurdles.
        // k: maximum height Dan can jump naturally
        // height: hurdle heights
        static int hurdleRace(int k, int[] height)
        {
            int maxK = k;
            int potionsTaken = 0;
            foreach (int h in height)
            {
                if (h > maxK)
                {
                    potionsTaken += (h - maxK);
                    maxK = h;
                }
            }
            return potionsTaken;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(hurdleRace(4, new int[] { 1, 6, 3, 5, 2 }));    // 2
            Console.WriteLine(hurdleRace(7, new int[] { 2, 5, 4, 5, 2 }));    // 0
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        // Designer PDF Viewer
        // Using the letter heights given, determine the area of the rectangle highlight in mm^2 assuming all letters are 1mm wide.
        // h: an array of integers representing the heights of each letter (consecutive lowercase English letter, ascii[a-z])
        // word: a string
        static int designerPdfViewer(int[] h, string word)
        {
            List<char> letters = new char[] {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
            }.ToList();

            int maxHeight = int.MinValue;
            foreach (char ch in word)
            {
                int height = h[letters.IndexOf(ch)];
                if (height > maxHeight)
                {
                    maxHeight = height;
                }
            }

            return (word.Length * maxHeight);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(designerPdfViewer(new int[] { 1, 3, 1, 3, 1, 4, 1, 3, 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }, "abc"));    // 9
            Console.WriteLine(designerPdfViewer(new int[] { 1, 3, 1, 3, 1, 4, 1, 3, 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 7 }, "zaba"));   // 28
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        // Utopian Tree
        // The Utopian Tree goes through 2 cycles of growth every year. 
        // Each spring, it doubles in height. 
        // Each summer, its height increases by 1 meter.
        // Laura plants a Utopian Tree sapling with a height of 1 meter at the onset of spring.
        // How tall will her tree be after n growth cycles?
        static int utopianTree(int n)
        {
            bool isSpring = true;
            int height = 1;

            for (int i = 0; i < n; i++)
            {
                height = isSpring ? (height * 2) : (height + 1);
                isSpring = !isSpring;
            }

            return height;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(utopianTree(0));    // 1
            Console.WriteLine(utopianTree(1));    // 2
            Console.WriteLine(utopianTree(4));    // 7
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        // Angry Professor
        // Given the arrival time of each student and a threshhold number of attendees, determine if the class is canceled.
        // k: the threshold number of students (cancellation threshold)
        // a: an array of integers representing arrival times
        static string angryProfessor(int k, int[] a)
        {
            int nbrOnTime = 0;
            foreach (int n in a)
            {
                if (n <= 0)
                {
                    nbrOnTime++;
                }
            }

            return (nbrOnTime < k) ? "YES" : "NO";
        }

        static void Main(string[] args)
        {
            Console.WriteLine(angryProfessor(3, new int[] { -1, -3, 4, 2 }));    // YES
            Console.WriteLine(angryProfessor(2, new int[] { 0, -1, 2, 1 }));    // NO
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        // Beautiful Days at the Movies
        // Given a range of numbered days, [i..j] and a number k, determine the number of days in the range that are beautiful. 
        // Beautiful numbers are defined as numbers where |i - reverse(i)| is evenly divisible by k. 
        // If a day's value is a beautiful number, it is a beautiful day. 
        // Print the number of beautiful days in the range.
        // i: the starting day number
        // j: the ending day number
        // k: the divisor
        static int beautifulDays(int i, int j, int k)
        {
            int nbrBeautifulDays = 0;

            for (int n = i; n <= j; n++)
            {
                int absDiff = Math.Abs(n - int.Parse(new string(n.ToString().Reverse().ToArray())));
                if ((absDiff % k) == 0)
                {
                    nbrBeautifulDays++;
                }
            }

            return nbrBeautifulDays;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(beautifulDays(20, 23, 6));    // 2
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        // Viral Advertising
        // Each day, floor(recipients/2) of the recipients like the advertisement and will share it with 3 friends on the following day. 
        // n: number of days
        static int viralAdvertising(int n)
        {
            int cumulative = 0;

            int shared = 5;
            for (int i = 1; i <= n; i++)
            {
                int liked = (int)Math.Floor(shared / (decimal)2);
                cumulative += liked;
                shared = liked * 3;
            }

            return cumulative;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(viralAdvertising(5));    // 24
            Console.WriteLine(viralAdvertising(3));    // 9
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        // Save the Prisoner!
        // Beginning with the prisoner in selected chair, one candy will be handed to each prisoner 
        // sequentially around the table until all have been distributed.
        // Determine the chair number occupied by the prisoner who will receive the last candy.
        // n: an integer, the number of prisoners
        // m: an integer, the number of sweets
        // s: an integer, the chair number to begin passing out sweets from
        static int saveThePrisoner(int n, int m, int s)
        {
            int mr = n - s + 1;
            if (m <= mr)
            {
                return s + m - 1;
            }

            m -= mr;

            m -= ((m / n) * n);
            return (m == 0) ? n : m;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(saveThePrisoner(4, 6, 2));    // 3
            Console.WriteLine(saveThePrisoner(5, 2, 1));    // 2
            Console.WriteLine(saveThePrisoner(5, 2, 2));    // 3
            Console.WriteLine(saveThePrisoner(4, 13, 2));   // 2
            Console.WriteLine(saveThePrisoner(4, 2, 2));    // 3
            Console.WriteLine(saveThePrisoner(4, 1, 2));    // 2
            Console.WriteLine(saveThePrisoner(4, 3, 2));    // 4

            int[,] inputs = {
                {3, 394274638, 3},
                {7, 615562705, 2},
                {2, 739424390, 2},
                {654809340, 204894365, 472730208},
                {12, 430895283, 10},
                {820162082, 641616307, 588599124},
                {11, 872829055, 1},
                {8, 863472675, 5},
                {6, 737005495, 6},
                {13, 140874526, 1},
            };
            int[] outputs = {3, 3, 1, 22815232, 12, 410053348, 10, 7, 6, 13};

            int nbrInputs = inputs.Length / 3;
            for (int n = 0; n < nbrInputs; n++)
            {
                int output = saveThePrisoner(inputs[n, 0], inputs[n, 1], inputs[n, 2]);
                string pf = (output == outputs[n]) ? "PASSED" : "FAILED";
                Console.WriteLine($"Test Case {n}: {pf}");
            }
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        // Circular Array Rotation
        // operation called a right circular rotation on an array of integers. 
        // One rotation operation moves the last array element to the first position and shifts all remaining elements right one.
        // For each array, perform a number of right circular rotations and return the value of the element at a given index.
        // a: an array of integers to rotate
        // k: an integer, the rotation count
        // queries: an array of integers, the indices to report
        static int[] circularArrayRotation(int[] a, int k, int[] queries)
        {
            int aLenMinus1 = a.Length - 1;
            int idx = 0;
            for (int kk = 0; kk < k; kk++)
            {
                if (--idx < 0)
                {
                    idx = aLenMinus1;
                }
            }

            int[] output = new int[queries.Length];
            for (int n = 0; n < queries.Length; n++)
            {
                int i = queries[n] + idx;
                if (i >= a.Length)
                {
                    i -= a.Length;
                }
                output[n] = a[i];
            }

            return output;
        }

        static void Main(string[] args)
        {
            testOutput(circularArrayRotation(new int[] { 3, 4, 5 }, 2, new int[] { 1, 2 }), new int[] { 5, 3 });
            testOutput(circularArrayRotation(new int[] { 1, 2, 3 }, 2, new int[] { 0, 1, 2 }), new int[] { 2, 3, 1 });
        }

        private static void testOutput(int[] output, int[] answer)
        {
            for (int n = 0; n < output.Length; n++)
            {
                if (output[n] != answer[n])
                {
                    Console.WriteLine($"FAILED");
                    return;
                }
            }
            Console.WriteLine($"PASSED");
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        // Sequence Equation
        // p: an array of integers
        // Given a sequence of p(1), p(2), ..., p(n) integers, where each element is distinct and satisfies 1 <= p(i) <= n. 
        // For each i where 1 <= i <= n, find any integer j such that p(p(j)) = i and print the value of j on a new line.
        static int[] permutationEquation(int[] p)
        {
            for (int i = 0; i < p.Length; i++)
            {
                p[i]--;
            }

            int[] y = new int[p.Length];

            for (int i = 0; i < p.Length; i++)
            {
                for (int j = 0; j < p.Length; j++)
                {
                    if (p[p[j]] == i)
                    {
                        y[i] = j + 1;
                        break;
                    }
                }
            }

            return y;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(" ", permutationEquation(new int[] { 5, 2, 1, 3, 4 })));    // 4, 2, 5, 1, 3
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        private static int computeSquare(int n, bool isLower)
        {
            int sr = (int)Math.Sqrt(n);
            return sr + (((sr * sr) == n) ? 0 : (isLower ? 1 : 0));
        }

        // return an integer representing the number of square integers in the inclusive range from a to b
        // squares has the following parameter(s): 
        // a: an integer, the lower range boundary
        // b: an integer, the uppere range boundary
        static int squares(int a, int b)
        {
            int lb = computeSquare(a, true);
            int ub = computeSquare(b, false);
            return ub - lb + 1;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(" ", squares(3, 9))); // 2
            Console.WriteLine(string.Join(" ", squares(17, 24))); // 0
            Console.WriteLine(string.Join(" ", squares(35, 70))); // 3
            Console.WriteLine(string.Join(" ", squares(100, 1000))); // 22
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        // given a number of sticks of varying lengths. You will iteratively cut the sticks into smaller sticks, 
        // discarding the shortest pieces until there are none left. At each iteration you will determine the 
        // length of the shortest stick remaining, cut that length from each of the longer sticks and then discard 
        // all the pieces of that shortest length. When all the remaining sticks are the same length, they cannot 
        // be shortened so discard them.
        // return an array of integers representing the number of sticks before each cut operation is performed.
        // cutTheSticks has the following parameter(s):
        // arr: an array of integers representing the length of each stick
        static int[] cutTheSticks(int[] arr)
        {
            List<int> list = new List<int>();
            foreach (int n in arr)
            {
                list.Add(n);
            }
            List<int> list2 = new List<int>();
            while (true)
            {
                if (list.Count == 0)
                {
                    break;
                }
                list2.Add(list.Count);
                int minNbr = int.MaxValue;
                foreach (int n in list)
                {
                    if (n < minNbr)
                    {
                        minNbr = n;
                    }
                }
                int i = 0;
                while (i < list.Count)
                {
                    list[i] -= minNbr;
                    if (list[i] == 0)
                    {
                        list.RemoveAt(i);
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            foreach (int n in list2)
            {
                Console.WriteLine(n);
            }
            return list2.ToArray();
        }

        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(" ", cutTheSticks(new int[] { 5, 4, 4, 2, 2, 8 }))); // 6, 4, 2, 1
            Console.WriteLine(string.Join(" ", cutTheSticks(new int[] { 1, 2, 3, 4, 3, 3, 2, 1 }))); // 8, 6, 4, 1
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        // Jump on any safe cloud having a number that is equal to the number of the current cloud plus 1 or 2. 
        // Must avoid the unsafe clouds
        // return the minimum number of jumps required as an integer.
        // jumpingOnClouds has the following parameter(s):
        // c: an array of binary integers, c[i] = {0, 1}, c[0] = c[n-1] = 0
        // 0 = safe, 1 = unsafe
        static int jumpingOnClouds(int[] c)
        {
            int maxIdx = c.Length - 1;
            int jumps = 0;
            int idx = 0;
            while (idx < maxIdx)
            {
                int idx2 = idx + 2;
                if ((idx2 <= maxIdx) && (c[idx2] == 0))
                {
                    idx = idx2;
                }
                else
                {
                    int idx1 = idx + 1;
                    if ((idx1 <= maxIdx) && (c[idx1] == 0))
                    {
                        idx = idx1;
                    }
                    else
                    {
                        // shouldn't ever be the case
                        break;
                    }
                }
                jumps++;
            }
            return jumps;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(" ", jumpingOnClouds(new int[] { 0, 0, 1, 0, 0, 1, 0 }))); // 4
            Console.WriteLine(string.Join(" ", jumpingOnClouds(new int[] { 0, 0, 0, 0, 1, 0 }))); // 3
            Console.WriteLine(string.Join(" ", jumpingOnClouds(new int[] { 0, 0, 0, 1, 0, 0 }))); // 3
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        // reduce the array until all remaining elements are equal. Determine the minimum 
        // number of elements to delete to reach the goal.
        // return an integer that denotes the minimum number of deletions required.
        // equalizeArray has the following parameter(s):
        // arr: an array of integers
        static int equalizeArray(int[] arr)
        {
            List<int> list = new List<int>();
            foreach (int n in arr)
            {
                list.Add(n);
            }
            var countDict = new Dictionary<int, int>();
            foreach (int n in list)
            {
                if (countDict.ContainsKey(n))
                    countDict[n]++;
                else
                    countDict[n] = 1;
            }
            int maxNum = -1;
            int maxCount = int.MinValue;
            foreach (int n in countDict.Keys)
            {
                if (countDict[n] > maxCount)
                {
                    maxNum = n;
                    maxCount = countDict[n];
                }
            }
            int nbrDeletions = 0;
            foreach (int n in list)
            {
                if (n != maxNum)
                {
                    nbrDeletions++;
                }
            }
            return nbrDeletions;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(" ", equalizeArray(new int[] { 3, 3, 2, 1, 3 }))); // 2
            Console.WriteLine(string.Join(" ", equalizeArray(new int[] { 1, 2, 3, 1, 2, 3, 3, 3 }))); // 5
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        // call a cell of the map a cavity if and only if this cell is not on the border 
        // of the map and each cell adjacent to it has strictly smaller depth. 
        // Two cells are adjacent if they have a common side, or edge.
        // return an array of strings, each representing a line of the completed map.
        // cavityMap has the following parameter(s):
        // grid: an array of strings, each representing a row of the grid
        static string[] cavityMap(string[] grid)
        {
            int N = grid.Length;
            int[][] gridInt = new int[N][];
            int[][] markedGridInt = new int[N][];
            for (int i = 0; i < N; i++)
            {
                gridInt[i] = new int[N];
                markedGridInt[i] = new int[N];
                for (int j = 0; j < N; j++)
                {
                    gridInt[i][j] = markedGridInt[i][j] = int.Parse(grid[i][j].ToString());
                }
            }
            for (int i = 1; i < N - 1; i++)
            {
                for (int j = 1; j < N - 1; j++)
                {
                    int n = gridInt[i][j];
                    int n_im1_j = gridInt[i - 1][j];
                    int n_i_jm1 = gridInt[i][j - 1];
                    int n_i_jp1 = gridInt[i][j + 1];
                    int n_ip1_j = gridInt[i + 1][j];
                    if (
                        (n > n_im1_j)
                        && (n > n_i_jm1) 
                        && (n > n_i_jp1)
                        && (n > n_ip1_j)
                       )
                    {
                        markedGridInt[i][j] = -1;
                    }
                }
            }
            char[] nums = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            string[] markedGrid = new string[N];
            for (int i = 0; i < N; i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < N; j++)
                {
                    sb.Append(markedGridInt[i][j] == -1 ? 'X' : nums[markedGridInt[i][j]]);
                }
                markedGrid[i] = sb.ToString();
            }
            return markedGrid;
        }

        static void Main(string[] args)
        {
            //Console.WriteLine(string.Join(", ", cavityMap(new string[] { "1112", "1912", "1892", "1234" }))); // 1112, 1X12, 18X2, 1234
            printGrid(cavityMap(new string[] {
                "884179362992919143428887745218617594484248579735335683155622684818584863837361995843138587668725",
                "877935637998356834563953298823581234638468352948583671742984367929193951737839286593316118548915",
                "958485147934716746152527692875528343974751298294723783494844152444653553259494475842956576368312",
                "467933229391924864792567672734265974159213732287177953334569595897365642686149363878875226922937",
                "898852889214169242346746379713679739929563439387279442432273774833964226588914794693189322331119",
                "363534972369956512768251566878978529884648231991115833339366833595984163825482891237458541867481",
                "484469686835449986615957512323859669323598879233796257415349756114642436786749815111237469764392",
                "934389329655599477799746877464664279355195589863512133567669946446252345667838114285264939674786",
                "799667913388253312973545941216652253316843422715722219552225697953723282799625996262819648533714",
                "427671527738853375176315915691327131482768721376251596542827873928474788292269861984653313229958",
                "675265486734298157791823676755251776945111341386747357417272852446428521797147272163866373557868",
                "951985255313274222877657852683944934158589181546422569773187932211153786769347492457771885471719",
                "694575266214919923455644388138312138391342494644826144553145234151452285243369189992566399222354",
                "781691578563357775124686796389571179472183338894421348372185742431419667174252951442182521835413",
                "275943781188515122917474912482155767631392416622955712256161597772552599681517326846685363749757",
                "872454845292953661239994165293769981599667596471694664528355739196588816425641778961399798792242",
                "599736162299537443183681976576744441699932844711958193241492245322676767821265661592517675517529",
                "249319798196714886712793666292924335482831852329419466817176711864793345481214645325277642239349",
                "633195194755981692841681539357757391381592741526892331536929968462822751625753417557127872539858",
                "635844672734291531623659887826167793393725565752863722997289427253845413356966334435824725173642",
                "111295549494962499188957816262431838336795439578181147379919391739758119759349543965769267896511",
                "568983815938671119914963512758998632984494668224333592918629587415311539253572839395516531215498",
                "384961885229186356251639996898353859361547736574777978932122895671555567141977713599328775535982",
                "968188786726255134566252331593784381115143284524511432676963783765132985594987523783583326258226",
                "876142695133757893782784257228611695197227591564447699696493745349368327261289538767347167861248",
                "414115515535574537175266191299764655548183399934496947516215879736566268865585285266736886634284",
                "945762631428146186623798894868819955694749239447979633466479848224899768548984954648762966763111",
                "816336812475975723984222847918344463138186455172119187397599185757333875723514367768783411715843",
                "912244984824283228176356497351526989631819477472779944942126429611688272443164348753657287331388",
                "588487389677661958232599791254136598847893619162669387672723616237921485563832945171992874456974",
                "571775863849625184751116623241525853733258165573198539922711835528141699165859696892968439528124",
                "295162878325664944944721684887789665488549948976188546133829331524951718492219484287699847738379",
                "355335396677635579394774954492387719414192997718591832621825668391318858175579844468657825849832",
                "186787268829631123753322637519137365433773274647293499879284165912227466351524435471185623241985",
                "235248937194951171795751719729829422732171543951977758285779566635465391981868233243218392967617",
                "674828941232452733585384169469732387192215517263338264447858274361183965335623728199699253777327",
                "414834684676338869648289736223741726253448957844995496576572778698156292511887857425247261821567",
                "418515411421917778519291792473856221985941363972935683977925176332782889535861398622985968329383",
                "256529138897884785725949879285221276773436341864236592175244562536191635523243383117393211598721",
                "918127626646335318424611877173345565622871527666969375798272311445477486414549773321869517152666",
                "989914779321756126675363385154121997271137693687936997579899237934157398977654583725777392395915",
                "698143438293842995933517866921392318239572956834592654345783279444688277345664347991183617844812",
                "771849339388964255664697742474847477275268351734641318591268238391121253276795961241492691616197",
                "197677247996287235928238218864583476331535191659758831932643246391497474495359573282994733594562",
                "647588717488525639323428499257122613999569989625359356223927146439439648286485764664558621462867",
                "912637725846725426385426923447118449834554329342881677852611996375314766535759433336572121224715",
                "358713957818522326913668699655379179576186467593939241867115497746548449915625265918536812756215",
                "169127125698473952676734696976573448578892583136832277893789871857392946843898345774655436158126",
                "413869384786315175359953867841418474879296595785355198199295246345745657527454564891455918444369",
                "413137832573336848587735682479871775732871687238875915478869122268264948398827392543825593835111",
                "877818456527795354879655133695162925654498838971198837672645478486937419469478637714773412485913",
                "185885225614344865577846385464785449886314479413934636561935749277189137972925699168444673343237",
                "595981676983842277865395639382877878561238592534694682356125726399627268245282932852494278459733",
                "197471756747598819277664111194274646749669185543576361274285282389967647734819683176866854896164",
                "376336825481741295962976112243821467718875188873349892879916419811557537536546497365513512534666",
                "862947279815185897171182581382378898499799458745967253174365577481297233386448598454199769158966",
                "731544946469558658745938263584357361528819252482555333732479916535753147332733297638474772218824",
                "275364317274299618279887737423966647363219269182498775412986348211442458187449223799423239791375",
                "286926781515136935683323713718267192766282968396162598343211574573715788985299655522117381383518",
                "558563441472692417923161359391941216347796639564837767564696452624836424382885559542427872344197",
                "454917326142436371531797488532974691283217711666934739343842887954194438639283449295291536961288",
                "616446778215733753273766752696823582295933415242265648784827942435551443334694756916516554917512",
                "433536829745713946429196619365454854319576397974483777318735315121554485912388598968297823861587",
                "522576129342349915287786697161794997938545439572972912416719713224167549565219632677161557361139",
                "753119934499325823937167544558775266456543693273682489259324257848934415848294167377858392298293",
                "187342467687284671526586539895561363263113415716997374553372368233283821244356643844717791253959",
                "749682289995524894375932242561978733217258985762639371674669731297935817486483961797736424689195",
                "484562315342638212782429857438279154255673289674128332386691312928298118822731726826796652419942",
                "759447819942356356698445348864571749413166653522294964528796892916756439695633291186688451196287",
                "349238562175476925148839371745898167344264277166598522876895732565175322732511617112224882713963",
                "291411345171596844171658334773852187849368718164217747298164343427697241774233375677446414629415",
                "976766291994565861854199759824514331886257412996724753856153399736914918897952532961413294253844",
                "343638622447854516234174219939387273638644453546985924187137199252698769671878173876217531186658",
                "629512716496593322973981494532555166863969842472186781755958329455826158421995474723715714196394",
                "242243282837249565324727875644533154688254172762158473256194669748984691168967728548634493394596",
                "327549494343513482622379376942853361514483575441776687729774431214628937148782267945748122311444",
                "695792774381619793236243659679632991452457821275338538162937511269152275191923677177717854653892",
                "325897826462358852335234474725799437891117332722379922187218744234218829214718446339623243565371",
                "267514481369838977279285166951946494976731936124524671466588873515468481792519763424847721376491",
                "196417889966736414914652593331439473238712466954842221993858165452955971352652317285518255257539",
                "817999139696117642384721197537577992916219741341868381726315148211417963731474597135174367834615",
                "938526229929295183324234237262592644264659891167647417659617418155314211539923716736974146536116",
                "291166446956569863988567389576388826785272861612342233695331679598477589315978453282313221551851",
                "699339843495589423652338266268467976171522357666795767566482277416373448222842351267981217227896",
                "223422465353267759137759699713432475915971514519657924242694615614734215125664416445387217431677",
                "348289763626986427289668331898329199797582794226155132431637914127394645713912582118815725545173",
                "151758238175316292899845174576233419365457641344968544861312788176447768554944173476735633938113",
                "146498243516766242576766496979524583297283924427821512725444636871757468423329149229524276354613",
                "511119159468266611714969957245648178755986777674996767772383969897338995726987298697178736636287",
                "293412168625466237523771462388647567386227551876398632428272268387593499217898735926745927771483",
                "125377277162695261835767344578137787432871259133162729834551755659725312126412343743697214621943",
                "283576571112411549855666268773539196696418221296775978579324455669219947141547632566294911132926",
                "822912189721589543186583881794398787865655595118251161746946798334314239354881782216572436433568",
                "992162836816433881813159449849555624432942462129357356761575226367376168476775879559536612489299",
                "114431999569221885519338746158254268178962712465187446959196265596589235176188827787337436835213",
                "998787613642788774985946992252719969295636577521482779957251589295799276312749676454299993263688"
            }));
        }

        private static void printGrid(string[] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                Console.WriteLine(grid[i]);
            }
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        // construct and print out the sorted strings.
        // countSort has the following parameter(s):
        // arr: a 2D array where each arr[i] is comprised of two strings: x and s.
        static void countSort(List<List<string>> arr)
        {
            int N = arr.Count / 2;
            Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
            int n = 0;
            foreach (List<string> pairs in arr)
            {
                int key = int.Parse(pairs[0]);
                string value = pairs[1];
                if (!dict.ContainsKey(key))
                {
                    dict[key] = new List<string>();
                }
                dict[key].Add((n < N) ? "-" : value);
                n++;
            }
            var sortedPairs = from pair in dict orderby pair.Key select pair;
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<int, List<string>> pair in sortedPairs)
            {
                List<string> values = pair.Value;
                foreach (string str in values)
                {
                    sb.Append(str + ' ');
                }
            }
            Console.WriteLine(sb.ToString().Trim());
        }

        static void Main(string[] args)
        {
            List<List<string>> arr = new List<List<string>>();
            arr.Add(new List<string>() { "0", "ab" });
            arr.Add(new List<string>() { "6", "cd" });
            arr.Add(new List<string>() { "0", "ef" });
            arr.Add(new List<string>() { "6", "gh" });
            arr.Add(new List<string>() { "4", "ij" });
            arr.Add(new List<string>() { "0", "ab" });
            arr.Add(new List<string>() { "6", "cd" });
            arr.Add(new List<string>() { "0", "ef" });
            arr.Add(new List<string>() { "6", "gh" });
            arr.Add(new List<string>() { "0", "ij" });
            arr.Add(new List<string>() { "4", "that" });
            arr.Add(new List<string>() { "3", "be" });
            arr.Add(new List<string>() { "0", "to" });
            arr.Add(new List<string>() { "1", "be" });
            arr.Add(new List<string>() { "5", "question" });
            arr.Add(new List<string>() { "1", "or" });
            arr.Add(new List<string>() { "2", "not" });
            arr.Add(new List<string>() { "4", "is" });
            arr.Add(new List<string>() { "2", "to" });
            arr.Add(new List<string>() { "4", "the" });
            countSort(arr);
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        class Pair
        {
            public int n { get; }
            public int m { get; }
            public Pair(int _n, int _m)
            {
                n = _n;
                m = _m;
            }
        }

        // return an array of integers as described.
        // closestNumbers has the following parameter(s):
        // arr: an array of integers
        static int[] closestNumbers(int[] arr)
        {
            var sortedArrEnum = from n in arr orderby n ascending select n;
            var sortedArr = sortedArrEnum.ToArray<int>();
            int minDifference = int.MaxValue;
            List<Pair> pairs = new List<Pair>();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int n = sortedArr[i];
                int m = sortedArr[i + 1];
                int difference = Math.Abs(n - m);
                if (difference <= minDifference)
                {
                    if (difference < minDifference)
                    {
                        pairs = new List<Pair>();
                        minDifference = difference;
                    }
                    pairs.Add(new Pair(n, m));
                }
            }
            List<int> smallestDifferences = new List<int>();
            foreach (Pair pair in pairs)
            {
                smallestDifferences.Add(pair.n);
                smallestDifferences.Add(pair.m);
            }
            return smallestDifferences.ToArray();
        }

        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(" ", closestNumbers(new int[] { -20, -3916237, -357920, -3620601, 7374819, -7330761, 30, 6246457, -6461594, 266854 }))); // -20 30
            Console.WriteLine(string.Join(" ", closestNumbers(new int[] { -20, -3916237, -357920, -3620601, 7374819, -7330761, 30, 6246457, -6461594, 266854, -520, -470 }))); // -520 -470 -20 30
            Console.WriteLine(string.Join(" ", closestNumbers(new int[] {
            9310848, -7174654, -2392933, -2854787, -1822654, 6755990, 507339, -3123167, 62378, 9053276, 3064616, -811366, 9164016, -6896092, 9239176, 7973785, 6237840, 9674468, 3386376, 9306447, 2831783, -273491, 6637866, 769010, 6731901, 7078390, 6449896, 3848846, -4798058, -3846069, -7727377, -7273563, 2268719, -9110636, 1291983, 4499655, -409391, -9183031, -1287452, 110292, -9571078, -2480182, 1070458, -8105699, 7566747, -1148856, -4874143, 4598284, 838569, -9362279, -3891425, 9697386, 7503037, -6230258, -2708971, -567440, -8578343, -9838825, -1571730, 3034881, 224473, -2749297, 2794913, 1504412, 2293399, -7572495, -647865, -8406237, 4555841, -3679301, -262845, 5139197, -9523435, -6787576, -5800133, 2195996, 5740789, -8033444, -6270162, -1616385, -1060285, -9790528, 7356317, 991232, -2048912, -4250025, 6461050, 8392654, -7592716, -6842122, -2045966, -3396068, -1824800, 9380062, 8745793, -6924934, 57769, -7394676, -1075902, -9974391, -1473124, -7511196, -5872084, -1793289, 4037455, -1435612, 337644, 9656484, 322163, 2292595, 200853, 9511501, -5250046, 9363420, 2262718, -5083384, -8943714, 1243297, 1059036, 583933, -8186288, 1177642, -6828478, -4052089, 2387532, 6513064, 6348598, -1765515, -1934219, -8343955, 8154064, 2300718, 4262376, 1698420, -9416681, 8389520, -5267906, 2463266, 7078647, 6413751, -1528562, -7733432, -7927974, -3704534, 1652732, 5158876, -9124272, 9546521, 3078925, -8098123, 7030600, -9781404, 6973665, -5496598, 3939069, 8369826, -5803476, -247295, 4425900, 8220502, 9576155, -7606861, -1857465, 439708, 1270378, -94295, -4806764, 3482005, -5306147, -9933585, -6525711, 772676, 2000477, 3899809, -2078096, -420261, 5237827, -7012551, -3705221, -6702798, -5080051, -2729598, -6619448, -7781575, 6423238, -453727, -146677, -3433891, 3448177, 4659598, 4038580, -6766503, -6891017, -3502632, -2389723, -1420987, -1965212, -1538575, -9924651, 560012, 7760310, -3116438, 6818372, -7493998, 1291867, -2870042, -45786, 3205166, -7565759, 1471046, -765427, -1293443, 1382864, -7134047, 6965910, -3828658, 8257500, -3208379, -5783194, -1103830, -7357631, -8293332, 1853416, 1589061, -926278, 5728039, -7523332, 7871700, 5285148, 54349, 4724253, 2937353, -383279, 5858665, -2976096, 3448256, 4344153, -6247564, -4280375, 6332272, 9087202, -5208482, -3315128, -5507535, -8486140, 1562293, -1621981, 3355279, -5012950, 4297680, 7301428, 1323620, 4860140, 1931020, -9398974, 6194780, 454191, -3621664, 3124901, 4691910, -723327, 7286267, 3507896, 8842932, -3394195, 5553806, -9579152, 1397676, -7699050, 123549, 1472313, 8149084, 7541452, 964838, 8355585, -5074402, -9767478, 8883985, -8584850, 5244617, 9978307, -4433145, 4287772, 1975172, 2343324, -581239, 798655, -8823706, -393548, 1201006, -639895, -192246, 4682611, -2160058, -6397133, 5567450, 8518637, -7255694, 4921922, 3710149, -1901416, 2845876, -734023, -7560218, -9970581, -6135798, 4969622, 7161169, 628940, -8549899, 939146, -299144, -6814507, -4786235, 3417076, -2942128, -4432869, -5409113, 7573655, 6833688, 2322253, 4310037, -7971211, -7631639, -6788197, -510338, -2040127, -8383520, 1788520, 8284443, -5738643, -5167782, -6563092, -9629953, 9142929, -3720670, -2130171, 8082979, -1644322, -7733597, -1812616, -2728411, 1623873, 3585069, 5382030, 6124255, 891757, 1582239, 4288726, 946352, 7086224, 4432761, 3397049, 105251, 1083078, -272965, 8399903, -952499, -2002594, -3477117, 3961613, -2667834, 246837, -3350038, -2363642, 9779639, -9911183, 6398298, 2771121, 8046797, -2395934, 7450646, 1416622, 9753801, -2424717, 7812449, 3913554, -1682513, -1321680, -4751711, -7042458, -47117, -1470067, 4170972, 654710, -9533319, -5217105, -5313226, -8932616, 438730, -227744, -6920011, 4043046, 2152767, 5230107, -1965036, 9358702, 6043303, -5401250, 673750, -578055, -5916704, -7699628, 7456348, 3101039, 1032718, 1450155, 4632655, 2821566, 3070037, 7167916, 4154521, -472353, 6345760, 1146460, -9935679, -1166, -7768507, 6870541, 5372388, -2223764, 2997602, -9924670, 8615647, -1073620, -8988122, 6560023, 2608895, 1101612, -3518201, 2360309, -6298052, 7325120, 6457169, -7986294, -4224155, 1926329, -5797372, 768777, 1250959, -6912427, 7874435, -7222381, 2301322, -5384212, -965460, -8326746, -1864829, 2107909, -6768926, 7076932, 8919026, 3791449, -148856, -6318296, 9858794, -7674305, -6322380, -6129671, -9011496, -6666879, -693126, 6253242, 778082, 3388519, -4067535, 5576265, 5625742, 2502532, 6056004, 2714644, -2278455, 8085115, -9304520, 5045504, 2523518, -4982441, 9995336, 9419472, 4485084, -3711872, -6899221, 3280080, 734865, -4144217, -4404960, -8411884, -2647740, -2029151, 5988788, -3941537, 2196198, 4677401, -7561726, 8676055, 8800996, -7586475, -8305525, 9124380, -6370257, 1867628, -2312053, -936842, -2581017, 8383698, 3541996, 5289541, -7924421, -5272150, 4973694, -5829600, -6480575, -7078059, 4698310, 9005517, -2548595, -6599028, -2785323, 8457612, 236137, 3232867, -6108465, 5237884, -6200360, 6375860, -6521635, -8655823, -1618901, 9275562, -8019989, -6364925, -9178778, 8776876, 358609, -801361, -7723724, -9936955, 5798599, 8899791, 3231551, -3771069, 2131939, -8478432, -1175992, -7455417, -3888024, 1349597, 9349894, 5379038, -6845550, 6841636, -344951, -4917723, -6101093, 6424948, -4187497, -9539620, -8018694, -9644011, 1886514, -5919835, 2890308, 9276038, 1999266, -6955019, 5378188, 337221, 7970982, -7410833, -8981627, -5649759, -4631204, 9144088, -1031085, 6655404, 6403265, 8341388, -8601846, -1247852, 8564347, 8091384, -5598934, -3321722, -8699471, -1250894, -6461186, -8502791, 2521920, -3788431, -4747643, -5618203, -9800780, -6588151, 1853943, -6219240, -2512494, -330106, 3282463, 4841115, 6958037, 1730595, -8935179, -1806375, 2073653, 9028587, 1677316, 7661789, -8610127, -927960, 4736766, 2043928, -2045003, -282271, 802520, 7754160, -4426688, -3239699, -9577905, 3922317, -5206222, -4640700, -2864113, 3874415, -114622, -9173484, 7891656, -6214536, -632323, -9517676, -6845551, 5720290, -6236846, 6981277, 7246422, 3182631, 5273192, 5613691, -8964312, -1999271, -7234121, -3936455, -7975485, 701252, -9485808, 5264374, -9651962, -4457694, -5436839, -6576383, -3441181, 2406422, -8021609, 9090835, -223752, -3267539, -5071962, -721620, 8964466, -2454735, -6294123, -4814615, -2478061, -85103, 8097724, -7994858, -6308681, 7613506, -2375121, 6058567, 6664897, -3627310, -1123952, 8405738, 9774908, 652510, -3239670, -7743619, 2879390, -9252225, 1454009, 6919230, -6120829, 9506377, 1166727, -9291313, 4049027, 1730839, 9957089, -7046577, -9362774, 3930379, -5204550, -2502701, 557030, 4443700, -5490941, -2747537, -2317827, 5663017, -2998767, -9362321, -2903947, -9601476, 5055388, -8813467, -2690866, -5514134, 9869646, 8047829, -1973412, 4934059, -6699058, -5362123, -9683464, -8856672, 5020417, 3388240, -5705692, -4375289, 2819601, 1883644, 1413327, -9463802, -6197337, -5823787, -9080046, -5336779, -2661771, 2128435, -3513870, 3922014, 4411183, 4500001, 822405, -692598, -3592541, -3691786, 9497417, -2050957, 3522397, -6111144, 6886838, -497605, 5825200, 2079473, -8348340, 3140679, -8201020, 7397069, 2439315, 4374736, -3120604, -2990507, 3448891, -7315953, -2714769, 7346886, -6169590, 1243462, 2162497, 7539995, 4650878, -4208012, -5556304, -3103266, -7435526, -5727728, 8591898, 2638953, -7392471, -7025912, 4538185, -4238884, 9017663, 2220392, -4084118, -8416212, -9428211, 3682551, -3137462, -2362050, 2879162, -2023738, 1250196, 1688864, -9293807, 3634403, -3817724, -2476136, -701426, -2709565, 8902204, 6458786, 3300565, 7414616, 9934631, -116065, -5203390, 2711759, 5169947, -5822021, 3051428, -4109607, -802341, 3682348, 1144497, -3574010, 8673742, 3865676, 1136336, 1555779, -1271822, 2487011, 2694744, -2221179, -4527663, 1803496, -6295314, 9208537, 7870775, 1118433, 5454183, 1135566, 4959696, -2526430, 258984, -9603056, -9059273, 8512855, 1192760, 4245568, 8456651, -2646104, 3672968, -6365681, -9639963, -4065607, 2053643, 9447645, -6673765, -84320, 571070, 8990109, -4523154, 859925, 6759928, 4719679, -2526651, 3591989, 4323051, -3170406, 8375071, 9546211, -32641, -6649884, 5315037, 4383790, -247134, -653863, -5833694, 5306830, 1566975, -6625676, 7317399, -5004820, 4503539, -6585302, 9222569, 9269056, -9898018, -6385341, -3491318, 132428, 7082282, 9137526, 5401591, 9624080, -6276657, -4687481, 1267567, -8620025, -9429475, -1847799, -9574259, 7837557, 263809, 6622014, 6503064, 9703159, 5282185, -5479955, 5762561, -5845123, -9536607, -4621870, 2107019, -3387488, 2946617, 1843981, -3637980, 8741253, 1653996, 9081507, 7128311, 5152782, -3438909, 8157518, 8896940, 4814447, 8449169, -9134660, 4317905, -8966027, 8077066, -2281659, -4178423, 4171080, 1617641, 1204336, 9558143, 8204645, 477840, 8787613, 4797994, 4330278, 4177069, -7962788, -1544884, 4684579, -9433542, 582291, 3339894, -693679, -986488, -4484190, -8201667, -1695479, -1559120, -5531436, -968396, 7180268, -4099631, -8314227, -1652570, -4567962, 1417700, -1245334, 2420759, -5335363, -7410592, 5713527, -3420260, -5870452, 3279398, 9981308, -6670636, -327045, -6498726, -8025342, 7019050, 6096686, 2064282, -1274736, 5218643, -6149763, 5129330, -7933560, -6352315, -6727336, -3261312, 5990670, 6180782, 7130349, -3947390, -6977051, 1961259, -3368627, -9489147, -1576045, -4219771, 9836278, -4970847, 2064362, 4210741, 3624883, 1268028, 8664710, 9549704, 5428829, 3534438, -711095, -1274376, 6379882, -8507918, -1361979, -1701741, -6742970, -9395605, 5457225, -8960421, 3635619, 9820273, -4093905, -9864893, -6439860, 9588680, -750623, 4151548, 6875894, 6604075, -2950592, 1262135, 959920, -7017974, -8700870, -7004687, -9796440, 4941744, -7435583, -2870580, 2129540, 3919554, 131022, -5213328, -9484393, 1538713, 5353643, -9951829, 5381027, -108473, -7327609, 8245175, -3867575, 9999177, -326978, 5533019, -9399175, -2879861, 9012682, 3039591, -8736889, 3914284, -8769978, -2550355, 571127, -2318446, -9307942, 5487476, 7689615, 4176344, 608443, -8170363, 4025294, 6427455, -2507756, 3601694, -2407441, 5625471, 134253, -5989345, 6771592, 3071114, -4620947, 2996089, 5941351, -8349437, -2800453, 2057066, 1758198, -2772196, 5777326, -2057344, -2980972, -3624949, -5932278, -4882354, -6158571, -858160, -9869745, 6640985, 4538269, 2438055, -6734351, -3454254, 3698791, -4920220, -1044190, -7835707, 7145276, -6228404, 9362531, 855351, 5525627, 8776688, 3607462, 1768999, -6544775, -1441668, -4648318, 5038544, -4952322, -5752035, -2801974, 3311782, 3580896, 9627584, 4922357, -1386685, -4834988, -5322909, -4925684, -7604098, -1069627, -7079486, -2643330, 8870407, 7117805, 4471391, -309098, 4240474, -1878538, -2662074, -6258504, 5075505, -8946677, 4798047, 9871891, -9073087, 8051976, -8141887, 4206488, 3913212, 5431443, 9831952, 3713593, 1676988, 1032928, -6638779, 7623337, 5726446, 7183470, -7527041, -7385553, 3293224, 9278277, 2251029, -2503321, -4093075, 4732574, -2733263, -5960403, 6282241, 7923621, -303622, 619074, 2352409, 8536246, -4398370, -9447496, -2446502, -1103698, -1360731, 2013560, -5886153, 6889123, 9575411, -923043, -363396, -5905814, 2761962, 7492100, 222711, 9063194, 8455370, 5283819, -8493782, -2894753, -2516680, 224766, -357556, 9928457, 2574869, -6015417, -5179180, -5166568, -3912159, 4623351, 5351434, -1859653, 8108304, 549223, -3040362, 1666405, 8762873, 9277277, 7313075, 153222, 9140513, 3480726, 4925552, -281899, -830985, -991625, 7036452, 8772436, 8881515, -1606451, 8493011, -1169886, -71007, 130510, 7612227, 9050526, -4529380, -7880275, 6415496, 5473292, -5912005, -6235561, 9422095, -6044105, 4963106, 1541190, 2421768, -9418893, -6899501, 1162389, -5064972, -6265165, 3701810, -6885135, -2129612, -4998377, 3316444, 8800037, -9345145, 1219863, -7454501, 232772, -5004877, 1723051, 6364169, 5265369, -1351134, 177528, 6230424, 4620368, -2899253, 9292428, -4693972, -9395828, 8457207, -317892, -4325785, 54447, -5520872, -6321942, -4757687, 7818801, -5112251, -9913913, -2934458, -1699568, 9303908, 6346450, -184665, -4899244, 9262525, 455319, 1878640, 3548409, -7066033, 1295278, 811827, -9529117, -313407, -3893927, -2205888, 8429290, 9462842, 1992773, 5699670, -2480459, -9334294, 9568635, 2960201, 9173232, 7762149, 9574208, 251831, 1220430, -8179908, 5452344, 8645485, -7445216, 4635516, 1001219, -9317639, -7063991, -6790849, -4743396, -1571021, 5646436, 3257955, -2567309, -670341, 2957493, 5253167, -2740955, 3949527, 9715764, -6456957, -575763, -1215243, 70434, -271704, 2110525, 1415011, -8547313, -9895776, 4213986, -4804683, 7312682, 2054853, -3076392, 8921012, 4439390, 5583619, 31763, 3658499, 2423949, -3492062, -9676256, -731972, -1821595, -9466321, 4500809, -2064772, -3439713, -274287, 8925648, -8825403, 7745080, -8781595, 5079370, 235446, -3720631, -3699717, 214730, -6027532, 8718159, 5120937, 9546691, 6175103, 6476822, 8153132, -5566659, 5820548, -5567518, 6672624, 8179153, -7973214, 185765, -9953677, 5754038, -1140118, -9958768, -2796845, 8496476, -9198750, 6565483, 3275757, -4746003, -8204312, -4715173, -6628339, -8877848, 3163094, -7226215, -4920653, -1436320, 4853569, -3482994, -840071, 7872602, 1503565, 8354069, 7097048, -8127219, -6681262, -2118888, 3812427, 504087, -9219332, -9990087, 9974362, -7684368, 2211615, -9030824, 2276904, 9060993, -9649845, -2427775, 8842435, -9275543, 4810549, -794368, -988595, -6306684, -9682244, -8862815, -4330699, -1248326, 2600792, -551840, -1162149, 9744730, 3270601, 6678172, 9195346, -7190436, 421537, -2988317, -722132, -2858617, -7849240, -857939, 4432527, 6354454, -4210837, 9180712, -8961893, 519906, -614897, -1256036, -1327016, 9620924, 5004118, -1548143, -9324246, -9931237, -4843080, -4703513, 3784545, 3136036, -1010168, -1483033, 8853112, 2988232, -454425, -5472095, 5266091, -4003267, 6784165, 3054939, -4150547, 6124317, 4590386, 5239959, -742215, -2528055, -4324285, -819000, 1861429, -285837, -2156561, 5993024, 3972422, -7952424, -8534461, -8739218, 177347, -3896907, -959413, -5778450, 3250727, 3741591, 7481058, -5994964, -4197752, 6063047, -4392445, -2627704, 1939848, 4531130, -7900401, -2701087, -1359074, -6955649, -9009439, -7658437, -6748115, 167889, 2811978, -5149868, 6324069, -6010047, -6157517, 2101851, 7124106, -4721497, 8433242, -7988840, -2137838, 184392, -97016, -5914725, -3541641, 2911129, -1334053, 8129471, 4504384, 969652, 3830405, -6483065, -6742637, -252472, 3959325, -4159664, 6940770, 2971124, -8359220, 6817003, 3027011, 9450903, 9308251, 563678, 1714215, -5457469, 1580962, -8308254, 9479061, -1652981, 8372871, 8039364, 5432567, -559600, -3636951, -2630568, -5545172, -8583796, -6040215, 8938837, -7838578, 7789817, 4954338, -4094482, 2705918, -6607597, -77218, -6964482, -3561121, -9643058, 2610632, -4648349, -7839703, -6706051, -2080639, 3418981, -3548123, -9231163, 4008871, 9588184, 2532556, -6589875, -8976168, -7451156, -9310642, 6712953, 4813368, -215974, 5518959, -9296230, 7431226, 7302741, 1503655, -4971282, -2533571, 9243824, -2922898, -2315562, 5288430, 2579601, 1582033, 6214231, -844902, 4927372, -5621649, -5266102, 5335696, 4574891, 7659540, -8866871, -5486728, -777910, 7956807, -6155790, 8282407, -5011376, 8281806, 2318053, -7045204, -9332155, 5544826, -9618171, 2346153, -3234502, 6452337, 1204788, -9980901, 8581650, -2695537, 8914718, 4612729, 7480503, -7039225, -7172939, 9055620, -782743, -4218459, -6074781, 9741263, -402167, 4279381, -2980796, -5610794, 1836337, -1892158, 1522660, -4962546, -5573659, -7119376, 1687989, -832376, 578083, 7464200, -6254052, 1606745, -1268371, -1277345, 9248933, -9637966, -4525088, 9021199, -7199264, 1042173, 8075720, -3761714, -9481396, 973965, 1632547, 4556837, -5959424, -7839384, 4811010, -1710748, -863614, -6079250, 6608913, 7826500, -9877396, -5742053, -2356255, 5477005, -402763, 390615, -6816128, 9987530, -6580731, -4738813, 712386, -2486725, 7115580, 7262369, -8984086, -2895574, -2817449, 5988068, 9533571, -2173201, -1268558, -1082214, 8924823, 4916033, 5372062, 4860298, 8324180, 9019203, -1842074, -5763877, -7213693, -8802520, 5573670, 8277518, 2176133, 8139032, 5872399, -6754692, 9146272, 811353, 9903346, 8478966, 9039714, -2071706, -5532005, 8827766, -9779062, -280371, -1871668, 6608654, -6953695, 6304655, 6092409, 7483742, -8347864, 1236187, -8773873, -5462943, -6610870, -5620943, 7421760, 6962290, 4740638, 1715310, -2544183, 2089306, -7903735, 4765913, -1877264, -3466326, 5572846, 9748000, 620489, -3730326, -752745, -2444253, -3855842, 1467806, 455967, -4744815, 2287340, 6068551, 7665254, 4785656, 754838, 7275362, 4855559, 6730263, 3124000, 8962246, -5591044, 3412831, -8367887, -3687327, -6998963, -5777512, 8690319, -3267080, -284148, 5584737, 3758376, -2611884, -1588079, 919689, -1739434, -6891532, 8292045, 1938349, 6779542, -1613228, -4361801, 1882712, -5396434, 6230260, 3100166, -1931952, 288801, -3468014, -5042122, 3859661, -5687541, 9407019, 851147, 5582945, -7536706, -8560595, -8656436, 4566754, 7979016, -923607, 1744395, 8917092, 5254189, -3517603, -7635113, -5970342, 7365369, -3489587, -3132675, -2839802, -4535374, 2092688, -2179492, 9826248, -2279277, -4165450, 2691277, -6301442, -4590068, 6821040, 7550286, -7786135, -6096599, -7259730, 7137148, -3639080, 82306, 2881015, -8991913, -7149777, 4268138, -9573528, 7646028, -8012874, -5517406, -7982038, 4235828, 1267587, 4183321, 5946166, -8653589, -313396, 8318042, -3907221, -1030610, 3594039, 8697702, -8366998, -1185930, -6990442, 3149169, 6227332, 5955864, 5182193, -3496052, 6384466, -9254855, 2124378, 4331728, -5255211, 4023894, 778702, -2621354, 644497, -1372136, 2566355, -6835081, 1210787, -3678900, 8175186, 65405, -3108910, -8690537, 1635171, 7332408, 9843266, 948976, 1044916, -7058858, -6090525, -9603069, -8389496, 6452429, -1848446, -4296559, -2478394, -926222, -4168651, -6590272, -5655393, 2216897, 2394275, 653117, -8747874, 561129, -1277007, 2310498, 1409535, -5890636, -6142751, -9312671, -600100, 3230668, -4436246, -9669021, 3513186, -868392, -7178615, -3413798, -2169037, -1001425, -3422518, -1394668, -1888339, 3773085, -4560461, -8535158, 9983283, 3767757, 8267356, -668785, 9180166, -4164992, -9227072, -4273644, -7434513, 4034322, -1177019, -4278347, -6555269, -307519, 991895, -8963518, 9819732, -842387, -9972825, 2798486, -216767, 8671883, -3833539, 401250, 1855899, 5178320, -8402440, 9175864, 3840255, -3953956, -7418333, -4367981, -7633561, 9758288, 4407254, -4239540, 1256667, -1821305, -5918048, -8187402, -3897925, -2126361, -6558268, -7380322, 637700, 3995073, -1438153, 6631923, -6725710, -9517926, 6345508, -9595764, -4537131, -5811733, 1381446, -7087968, -5279887, 4760315, -2628784, 3815726, -4171845, 8706135, 8430442, -9927467, 5655299, -5423708, 6050035, 5877415, -9047047, -9474262, 5294257, -6930525, 5932141, 2478930, -5160787, -146109, 4060817, -7945708, -360898, 9999952, 6264417, 778891, 201196, 4159142, 6676190, 1983851, -1535123, -2487526, -9367241, -7511166, 1604971, -8922506, -7967887, 4820415, -5122145, 7291114, -3623085, -4627972, 8456945, 5209347, -8035895, -643200, -9248511, -8078396, 5497356, -7153259, 7099314, 279585, -9373571, -6737813, -5917745, -3946629, -7907854, 4488236, 1938316, -6547883, 6555730, 434378, 2296979, -5230598, -1905211, -342244, 5359537, 1325276, -9383341, 1881311, -8170702, -5164985, -1796435, -2934824, -940643, 631335, 6717324, -9495094, 9241575, -6857005, -6181749, 8205643, -2025935, -1881366, 3610338, -9401993, 4430554, -2486809, -9461720, -9402612, -7688658, 3887503, -9323673, 6877775, -3120878, 8541525, -9809994, -7059168, -8700367, -9632880, -5141639, 4775168, 3493568, -8801520, 4031605, -4153710, -4415813, -6600080, 6461618, -3268632, 842622, 9132305, -4414085, -2398119, 1310737, -324328, -7767129, 3471000, 3573589, 9708981, -8065538, -1308668, -4735312, 6888110, -918249, 6593055, 697349, -7027776, 481324, -6563130, 9253742, -3822556, 3177520, -9630374, -4366098, 7450713, 7302575, -8715836, -1751493, -6901377, -9374055, -7924853, 8165071, -3580316, 4285929, 8530881, -2450050, 704230, 903238, 6490, -4024905, -5657834, -7144380, 1171722, 8761074, 2227008, 4283912, 4375128, 7774242, 3555309, -5412195, -7782527, -1323265, -5238809, -2287215, 9522799, 9168003, 737919, -6756485, -4072616, -9906849, -7690965, -2893563, -8353809, 1342434, -9500719, -1466829, 5119539, -907635, -8271701, 6366733, 6423997, 7549694, -4734271, 6685701, -9336878, 3102997, 7789990, -9419418, -9700995, -9997673, -9945253, 4202037, -8379578, -2553170, -5398150, -5639849, 3782290, -8097005, 6699052, -6524468, 3083053, -5812397, 24531, -7397990, -1905274, -3528049, 6957802, -1419214, -1427465, 2307157, 7925049, -3564475, 9619089, 6112145, -2140914, 5892778, -8580749, -653263, 2412170, -7673194, -2022794, 916341, 9886908, 490250, 5986676, -6470776, 3399679, -9597089, -5306839, -1734364, -160870, 8906418, -4090073, 3439278, -3365714, -3280266, 9722566, -1320901, 1025427, 1578798, 4901714, -6656611, -765883, -964669, 2856192, -3041647, -2666703, 8158607, 3799302, -3780592, -9706510, 4322569, 3314888, 9179255, -4097351, 5650843, -1861512, -4442624, -4381327, 8609054, -6890561, -9658479, 9594076, -4269152, -4263682, 7239561, -409644, -1889880, -2238342, -2691426, 6109627, -2988458, 8341122, -8105, 1362678, 7967890, -7050439, -3080661, -9976254, 5938545, -3640938, 820110, 4387314, 2827384, 7053536, -4002297, -4613809, 4720140, -1465510, 1613628, 1905107, 499545, -6231361, -7633825, -8047376, -4790392, -4995238, -9859392, 5143146, -5142612, -201692, 5302186, 8928063, -3766411, -2328444, 6373996, 3717273, 3127434, 885234, 3907479, -7537010, 2561441, 4272327, 5407005, 3823610, 5253637, -4413555, -797947, -8824048, 8051673, -9593772, 3581597, -3065355, -5779003, 1616693, 5887282, 6845365, -5491203, -6319452, -7393140, 242563, -2015448, 9055867, -4720686, 4734073, -3951072, -839489, 9543154, 8774516, 7397149, -1224908, -8751436, 8050941, 8020601, 7793648, -8863623, -132063, -4165676, 8961958, -8277498, -6376337, 4617159, -4823267, 3856368, 4547017, -346085, 4867264, 2081315, 392743, -1824663, 8530497, -7323578, 798939, 6811979, -9121175, 1485378, -1959339, 3106642, 3661547, -1323926, -357118, 7763614, 4411141, -1736238, 2333131, -6072105, 773331, 6376199, 2350652, -4413772, 3667976, -5238730, -8025418, -2127618, -4120104, 1600919, 7746243, 1228693, 4059704, 6789135, 2020531, -7838474, -1124916, 1948910, -7089467, 5115132, -6125031, 2113957, -5693865, 3655525, -900355, 6642133, 2585786, -5439786, -3307010, 4768962, 4854525, -6232517, 4158528, -1405026, 5271139, -3466328, 5367544, 7398752, -8293621, 9427783, 8404485, 2613173, -5293646, -8515511, 4407994, -111214, -6991788, -1514167, 1753391, -9056532, -2140105, -5808618, -6208596, -2480036, 4728591, 2307359, -1848258, -1016275, 1965611, 7418944, 5409483, 3501604, -1216486, -8430754, 9699193, 7329956, -8821079, -4407890, -9239989, -5291474, 7397867, -3703485, 5634624, -2788886, 312527, -7764856, 4191745, -9012635, 9602074, 6380041, 2731646, -7986025, -4073586, 9791857, 4245088, 5915089, 4274293, -6340130, -5988140, 5514370, -5707833, 8330464, -6126061, -8389888, -6331279, 9543022, 6105593, 6609832, -3671978, 5640313, -5982748, 7842841, 3357302, -3577687, -5978768, 3815672, 5984984, -9503124, -3814781, 2131902, 1869647, -5416319, -221947, -9379631, -3537773, 2624937, -3314550, 2404099, -4124250, 4723010, -2997425, 6232013, 1424897, -2754125, -6906406, 6035580, 2767167, -4179016, 331458, -5140070, -7390612, 6694382, 4860879, -971671, -1331194, 9547977, -2313418, -3592665, -4624758, 6944978, 1950639, -534967, 5256771, 9857519, 9663104, 1729863, -2718213, 1709436, 8390675, 7497397, 461541, -9508563, 7897109, 4072346, -594358, 5295986, 191544, 1645018, 8425460, 972311, -3258293, 6457138, 4398780, -333100, 7420382, -1808562, -4939466, -3524129, 1118146, -5998742, 6606520, -3402940, 1232588, -4453076, -4893692, -5667686, 9629629, -7606810, -5545610, -9235693, 604750, 1439079, 5984643, 5497459, 5875601, 9289780, -517847, 4429172, -260818, -82637, 3029808, -8186510, -1280752, 6462237, -624513, 1442870, -3860211, -4984385, 691135, 8717091, -3264837, -7240965, -7864727, 2391993, -5983302, -7962124, 2835910, -7105682, 5805556, 4013577, 7704684, -5536795, 2671819, 7859581, 7555956, 1734157, 52038, -2054880, 8971035, -3184592, -5356278, 3061844, 477763, 8087541, 2357096, -2697155, -1775641, -4939558, -9045955, -345331, -9513963, 3487532, -2732471, 55799, -2845864, 1436100, 386597, -6862112, -2988745, 6304356, -4998921, 721209, -7798152, -1796269, 4392028, -5884177, 5977082, -676374, 1110932, -6901352, -9487499, 2721084, 332134, 7348850, 5425972, 7495933, -8032935, 1905218, 1958955, -4460452, 815644, 4388254, -3167259, -6829019, -1338745, 6352647, 4095873, -1429180, 1919660, 5497676, -6163729, 6939761, 6977653, 4270857, 8273964, -7241498, 4259689, -4000697, 8162926, 4064812, 2027661, -7429559, -3438045, -224575, -8942141, 3630505, 7015968, -2371642, 5446141, 8625219, 9497894, 4362662, 122109, -1185513, 7464314, 8217082, -3900519, -7068785, 6416880, -1789680, -1177722, 2172981, 8226057, -776472, -3645751, 8889181, 1256693, -5733672, -2372728, 6652814, 6359593, -4687881, -7161225, 7144539, -6973177, 706743, 9514091, -4679562, -2966840, -3743564, 6566792, -8664535, 5707311, -3678977, 5400334, -5131254, 8805619, 3980899, 2352809, -2311246, 8366987, 6606299, -7402041, -3335341, -342449, 5167431, 213776, -8147320, 8816444, -8674523, -4920719, -2127328, 6197288, -5225799, -3826948, 9094078, 3807811, -1826310, 4789775, -2134391, -4259924, -4434360, -6704130, -6472818, 2307529, -3051583, -7111877, 257325, 8379099, -7761719, -6151860, -8461182, -9639092, 2076216, -66081, 6856025, -3796965, 640060, -7121664, -3494067, -2682601, -4097832, 1756489, -9117434, 7568265, -2319020, 386999, 7747489, -521799, -823193, 5930015, -1419003, 2967235, -7270681, 6711249, 6379511, 5562200, 176641, -6867848, -4492624, 7305972, -5564411, 2034687, -1824998, -1142884, -9887650, -3486315, 9015791, -6491498, 9743290, -1757956, -6736961, 5948884, -8888720, 8558916, -8151108, 6524977, -9845880, 2235681, 5224865, -4517567, 430646, -4560878, -3175166, 8847031, 8777340, 464259, 4127628, -3240310, 7831849, 8507613, 694195, -4927783, -865823, 7142274, -3045369, 7948743, -3144541, -4988106, 1797008, -3267172, -9794400, 9803349, 838434, 6501487, 3127938, 2388170, 1460008, 4766493, 7534614, 8984437, 3966739, 2902181, 9191723, -3125974, 1271436, 7012738, -8150632, 734142, -7342125, 3488241, -5577923, -5998266, -8207706, 4248643, 6788118, 1747266, -4418024, 1226120, -5519203, -4174776, 1993807, -3912557, -8402429, -6164519, 585690, 5094515, -5400100, -2699370, -3265966, -9908385, 9140111, 9624108, 5187035, -5848416, 7470388, 3032453, 8409374, -3623980, 1038873, -5824511, 1926039, -4030737, 4731532, -4865256, -7421924, 6082505, 5573464, -1056265, 1339265, 6078957, 7378040, -2937495, 5307559, 7189408, 9321702, -858573, -2327617, 8713834, 4425214, 6632129, -6905896, 3527797, -6205646, -9104187, -613489, 6458841, 4219506, 7131978, 7288392, 9849799, 3183286, 5047201, 3841460, 8115897, 6840882, 2371667, 1336642, -3591245, 311615, -4732413, -2562155, 6731561, -3358664, 3300759, -7074155, 739088, 6727628, 4506110, -8956632, -5630570, 8592240, 8577364, 1005675, 6906233, -646279, -9142631, 7556071, 9180245, -5715722, -4082635, -2674337, 9218643, 6873609, -144022, -5560483, -3813481, 6604559, -9684221, 4093727, -7441923, -8504398, 1879185, 4480572, 2166197, -7091530, -8529135, 1178321, 9488501, 4174908, 1005175, 9790846, -3496157, -7339752, -7595709, 6921337, -7651200, -8031033, -5010586, 5644194, -2202457, 4041072, -837763, 6410467, 9693803, -4964915, 3702664, -4881233, -6174938, 9018106, -9897105, 1400623, -6554342, 8154231, -5575685, 7177661, -874759, -4674878, 6345786, -9798288, -6748259, 774548, -1004305, 2418658, -2734804, 8035789, -6050800, -2235517, 8445857, -2047025, 2304283, -4594360, -8884301, -217471, 5975231, 9775447, -105865, -2855481, 347592, 6740306, 7179988, 9842662, -4651170, 4414819, -5025630, -9271976, 7108949, 8016120, -5443279, 346492, -6392750, -5573207, -5833724, 7730710, -1443058, -2897496, -8296430, -565251, -8468439, 6633994, -1801320, -5752052, 866156, -9111162, -5899693, 7834360, 4800894, 519866, -4682089, 4295270, -6797874, 5368320, -1783106, -7758240, -1345435, -5687934, -8555861, 6717921, 497435, 6839045, -9786239, 6384525, 4394566, 4871879, 8615089, -63165, 7367798, -2060312, 1813610, -990813, 666083, 6609139, -5436121, 6335407, -2174641, -5967981, 2305460, -62485, 5974683, -864538, -4138108, 894126, -719241, -8930517, -9922135, -5545424, -6116963, -4267154, -2231737, 4405197, -5491400, -7163492, -1901404, 1406696, 2204621, -4974659, 6448991, 2338936, -1507493, 9004900, -7551659, 8781257, -90487, -2876047, -3311016, -7647358, 6767128, -5028726, -3096633, -8790381, 6151970, -9416549, 3211345, -1695162, -6584506, -9722855, 1052052, -1366701, -9788349, 6963398, -5006087, -628109, 3757655, -6048231, 7627462, -5840938, -7428805, 2503495, -8133290, -2668468, -7789523, 9161432, -8328149, 9083396, -8714431, -6335483, 1324383, -2174657, -8193517, 144659, 651714, -2486493, -9961495, -4089288, -9511161, 8415127, 5252678, -1507943, -1229129, -2813093, -5315578, -8694689, -330509, -1993320, -202153, 265182, 6254575, -1175454, -8381377, 6507381, 4651648, 7371991, -7191278, -6136813, -1290582, 7288842, 4708961, 9838664, 1867891, 7655539, 6445264, 2496614, -3700903, -7235325, 5085, 9640187, -3692577, 6942059, 5294230, -6164470, -8881993, 4055286, -6768884, -8455394, -6752171, -965520, -160328, -7610843, -1428494, 1030880, -5339228, -2257021, -1454689, -176499, 1706520, -4533941, 9567442, -7097768, 5990213, -4167054, -2215834, 2829393, -5472606, -4472430, -6848177, 2827863, -5288896, 87260, 6994416, -9362719, -2488281, -9583068, 3902129, 4338773, -4042468, -9367264, -8049806, 6492228, -1030422, -8268513, 1551632, 7987084, -1332369, -9862549, 1357109, 3643888, -935254, 1197879, -9325270, 4573435, 3696624, 4401964, -6783583, 9499711, -3434381, -5263992, 7247286, -2075770, 6674210, 8676761, 7818184, -48510, -7066957, 8775645, 408570, 3147268, -5488320, 9580852, 4010966, 5164732, -6773114, -1403655, 3798042, 3368960, 5603179, 6237555, 6875584, 2760499, 5278362, 4861191, -3979276, -7571012, 8883986, 2945680, -2211310, -3815177, 3401399, 9827245, 6138973, 7517228, 3996013, -5236272, -659962, 9039684, -4210044, -4609407, -6174045, 3991560, 6519491, -1005633, -389804, 1785783, 2336517, -4109941, -6222429, 1035869, -9558340, 8475620, 8711806, -364986, -9481769, -8695364, -5091023, -1233494, -4278002, -3490448, 2987933, 7374510, 2863551, -5561090, -5188870, 9297156, -3519897, -2454143, 2877075, -4337981, -1716226, -1058086, -789133, -8118095, 6303799, -1734757, -6379111, -7526512, -6473817, -7158458, 5409579, 3849, 4192305, -5045595, 7182715, -7706796, 9591495, -6634911, -8071540, 7918166, -8011336, -4245827, 1325009, 8063481, -4317405, 1147384, -8885130, 452038, 6853149, -6648813, -2496850, -2056570, -5396671, 4180824, 3016754, -1064749, -8933733, 6915452, -5216353, -9946282, 5829100, 3324278, 6800527, 3262772, 8474376, 6191360, 9630725, -6295503, -437806, -6634137, 3131034, 8990612, -4317481, 1915921, 1643343, 7784332, 4906735, -4945707, 1166897, -2846369, 5382541, 4296357, -809671, 1004261, -4976324, 7340906, 8287959, 7850439, 4655704, 3654571, 6823630, -1623591, 7209339, 2324865, 1735161, 500719, 9505193, 7880190, 6938157, -1494974, 6450227, 7069807, -4481759, -9031461, -4402112, -206003, 5259820, 2092475, 7715804, -645327, 6567607, 8927606, -6957044, 3136513, 7013709, 2512735, -7637414, 1675289, -1513934, 9488817, -7690007, -7888957, -6067076, 5439251, 3269455, 3526366, -8125629, -4721006, 3920507, -7813231, -172017, 8629129, -5916668, 1022816, 1869639, 3938458, 3879414, 994303, 3738207, -9314042, 4446748, 3297571, -2646210, 8143991, 3181450, 6471520, -9402220, 4505804, 2512055, -7334263, 2822810, 4275067, 2545305, -3119447, -3510005, -2118467, -5442294, 6558004, -839443, 8878545, -5348867, 2913647, -3765822, 4861600, -3755993, 7605848, -7284007, -3535222, -6186047, 8816725, 8317296, 5964184, 1476100, 5406632, -934047, 6750399, 379942, -3812487, -5571154, -6091401, 1168389, 2386905, -3863891, 4672520, -7071459, -714990, -6554675, -4903790, 819242, -5154880, -8629370, 9230390, 4891289, -6627887, -9709810, -9328544, 8852656, 7726055, 2174310, -6329271, 2692927, -9249723, 1199925, -1955228, -247480, 5037935, -3497287, -581976, -8505314, -542333, 235378, 7111824, -5543353, 5262979, -5926528, 8727422, -8570195, 5188234, 4126628, -7182558, 7227104, -3475285, 9535864, -8242025, -6054536, -5670977, 3032019, 1362657, -3397744, 6743271, -5937836, -2003037, -8352260, -6795467, 6758718, 6395778, -3790235, -3274420, -42247, -4171202, 1420767, -1669650, 8143466, 3791835, 6732617, 8631104, 3183642, -2030913, -8086843, -5979694, -2950023, -4282780, -9926049, 7927901, -4282731, 9953087, -1398033, -4098109, 5530738, -8049862, -5389962, -9250785, 718718, 3397436, 5296934, 1278743, 9259223, -3845546, 9904270, -1386051, -3880190, 1658872, 4535716, -3490998, -1981026, -5797685, 4715287, -9244250, 5517653, -3752652, -406785, -7081641, 6699455, 3631685, -209088, 316020, 6765359, 7115347, 6320904, -4589053, -4227024, 1034366, -2218834, -2441649, 8395011, -180038, 6290133, 5831701, 3628295, 935825, 4379316, -6601726, -3166281, -7446660, 8611883, -5173286, -2335842, -5669011, -1989570, 263821, 169556, -1716769, -551462, 5119625, 2760516, 9963597, -9069594, 7622875, 2231845, 6115866, 827678, 314888, -3028622, 8943630, 452854, 6666090, 7995977, -2178519, -4556770, -2172935, 9669042, -4812274, 2273056, 7544073, -8785984, -5091877, -2084832, -3530987, -6625714, 3669849, -9428272, -2514028, 2555281, -8001470, 1089367, -3081466, 9950406, 796610, -7947841, -1498058, -7287518, 8792682, -6325250, 270013, -2845863, -9901718, -1295474, -2035235, 389359, -3832931, 9624215, -9929053, 9999938, -6505479, 2873333, 7837586, 7414419, -5310097, 3722073, 5531387, -3426357, 4575984, 829062, -9521475, -1273402, -5621412, 6929287, -9652832, -6629905, 1892354, -8415198, -1910967, -6755557, 1408178, -7453608, -5980445, -8685409, 2148953, -1426025, 1591643, 8697774, -7802494, -1852094, -3737241, 6397283, -3378458, 1984106, 9900364, -6018253, 2495818, 5592314, -3565224, 1130128, 4019306, 7626811, -3181457, -6787529, -2843198, -3850146, 325284, -8740689, 1655760, -5524392, 2397841, -3643795, 2919366, 759037, -8320997, -9028881, -3194182, -8607007, 2036240, 4490628, 3397593, 7594357, -5865345, -5625115, -3511461, -2173942, 4926116, 222442, 515336, -1589282, 1750073, -525909, 9197947, -5953796, -9099437, 5347969, 9991407, 7417125, -2198977, 1526361, 4328207, 3216431, -1485813, -531492, 208349, -9293247, 8890871, -6153224, 1852850, 2940819, 568612, 9543000, 2358265, 4735785, -1193727, -6650659, -815063, -5192326, 4393730, 3101590, -4546014, -3792565, -5707658, -7541010, -2486895, 9624991, 4967775, -1154826, 9449308, 9655621, -1609498, 6823300, 3622574, 996380, 9082188, -7880829, -4939017, -3545136, 5296746, -4658336, -2643607, -5848433, -6367135, -1784222, 4383262, -2215483, -8352500, 260287, -6600513, 4677992, -1021918, -7527008, -2564372, 1077160, 3841870, 4950287, -7065560, -6208674, 4064200, -4266323, 1451497, -4544076, 5412539, -6720598, -7776902, -2149083, 970294, 1899301, 7332386, 3093872, -1749747, -9089833, -6152378, 8046274, -2085517, 8021941, -1529511, 7987041, 1068010, 2901007, -4246806, 4776544, 1223268, 3482631, -2313951, -3343371, 7026443, 9878494, 1382995, 5510512, -6935275, 2202445, 2038712, 357450, 6795235, -4432644, -4822509, 9864345, 4019549, 6424351, 9975372, -6889489, 6463171, 4896674, 3664044, -1420479, 8677679, -9653796, 6591223, -6822546, -2479597, -7341622, -5919791, 8053679, 9814981, -4146649, -1766926, 6876700, 2388283, 2909181, 101880, -933344, 1976368, -1017798, 8954902, 4028032, 9807365, -5483246, 9452909, 6286765, 125364, -8227330, 5862874, 2005138, -4365337, -2462469, 4975633, 4316830, -6667314, 1271838, 4460901, -2506763, 9592471, -7378788, -4391046, -2247774, 355804, 5066995, 4223514, 9140883, -9244980, -3116458, 9104956, -6299591, 6579041, -7670739, 8817496, 874534, -3375047, 978158, 3928842, 3386000, 7900485, 903664, -2825190, 9312692, 1243362, 1635336, 1228460, 658719, -4514029, 9295405, 7972793, -3471357, 6435454, -9747817, 8979911, 5254295, 5765070, 6469211, -6667718, -4249748, 2006135, 1689528, -3857874, 5389021, -1549641, -5033941, -6400272, 4458086, 6341501, -5908280, -1001848, -3781579, -7920995, 2614528, 9717753, 3530743, 8404535, -9824680, -3147893, 5443744, 5221545, 4092709, -3715181, -8498174, -2096916, 4137997, -4331019, -6302788, 2478649, -6086248, -9918571, 4495101, -2105596, -3317568, -8073649, 4841541, -5754543, 501073, 1425676, -8130470, -7723321, 9731679, 5842085, 8444120, 1075670, 2655103, -2086929, 7231140, 8321263, -1943792, -6817652, 6586897, 4549738, -5970339, -8221313, -3663846, -317742, 8673305, -2677065, 6440358, 3828626, -8336749, 8410035, -946001, 7140462, -4769069, -3903730, -3003377, -3267610, -2364637, 9083120, -2731682, -8362642, 8217445, 7704677, -4188318, -1241795, 3314253, -7162179, 6740633, -4116232, -6715736, -5349672, 9912873, 2159270, -8411718, -2162265, -1663311, 2213137, -6762233, 142678, 6591082, -5079446, -6024444, -3816644, -750294, -9328499, 2469186, 6436064, 4909765, -827701, -681179, 3776762, -5709372, 2109529, 3449483, -3572106, -8235326, -7821050, 7371890, -9327067, 1103999, 6831222, -5967050, -6875222, -8411685, 8392876, 7335333, -3832150, -4357432, -5472099, -118102, 9454317, -9416874, 1674349, 351031, -218973, 4833213, -2202206, 3102995, -5115899, -4136005, -9265956, -1838152, 7368246, -890153, -1383012, -847624, -7246569, -3539933, -7511801, 3291289, -5914823, 8527064, 8514905, 8528694, 1004212, -8778305, 8910926, 9090457, 1842902, 6383469, 9847799, -6049336, -9892029, 3905536, 2931148, -4500403, -677898, -3237898, 654264, 1346258, 7594700, 2739980, -2892663, 9127507, -2306663, -8190337, -4045555, 5006128, 1058147, 1251894, -5333829, -5295865, 137830, -3355449, -5606836, 8273860, -3809676, 836614, -6706371, -8473995, -6111796, 5582365, 7897215, 3432901, 2574994, -1111614, -3653154, -3851745, 9747888, 3812026, -692008, 2769029, 5293640, -1988273, 9384900, -9423474, 6172014, 6344865, 8177844, 9610379, 7008879, 5387864, 2821539, 9409245, 9648058, -8154839, -5156320, -7125444, 7327512, -8415096, 3855556, 5595859, -6306043, 420766, 6193773, -4389472, -7941619, -7717335, -6095973, 2517163, -5032900, -9894655, -5198561, 4408457, 9584360, -9607667, 2552011, -7508495, 1622943, -566335, 4763452, 5553203, -3677268, -3754565, 4658057, -8850033, -1465628, 7459782, 7423682, 9871869, -851372, 7304503, 6838768, -7894724, 5983347, 9112274, -5691957, 8423519, -4595303, -4922501, -6027351, -7547948, 8531869, 5901335, 7249382, -4321082, -297079, 8684120, 1319956, -683664, -7028941, 1436410, -5608288, -1558243, -2573338, -5287369, -1181747, 8433355, 4081667, 2314697, 7158215, -1609770, 1163376, 4732010, -1112665, 5931441, 628148, 4625191, 5702871, -9451982, 3662020, 707218, -7774043, -372103, 1981530, 5493688, -254841, -4159206, -2074084, -7173607, -6100450, -9998385, -9507583, 7624762, 1428256, -9353491, 2625530, -7606920, -9239932, -3033078, -6555953, -9691244, -9293550, 7499847, -1695132, -525011, -9967071, -9501499, -1808410, 159, 8858422, 6839104, 1237516, 4183525, 1069840, 4671876, -3529840, -3853612, 3036342, 4338732, 7182708, 6118947, -3089861, -9015001, 5547364, 5901720, 1953194, 6432755, -9186642, -1582303, 9050272, -5049025, -2698572, -1562681, 8407769, -4438718, -7437185, -399552, -1764524, -2704388, -2438920, 1155611, -2692891, -1090495, -6796599, -995592, -5483908, -4276798, -5365368, 1207875, 4483826, -7151314, 2969626, 4043622, -5563382, 1935184, 4522322, -2309588, -6736517, 431476, -1678561, -8519708, -1335821, 7883899, -6363392, 9938576, -8523890, 8730781, -4138209, 1573848, -3949620, -2811003, -305572, 6328127, -5120918, 9369893, 627245, -1145594, -6587473, 3985032, -9767940, -2721663, 673430, -9673838, 7200401, -8518026, 7860066, -5224860, -4987263, 2640882, -2590293, 8800304, -4094943, 5650459, -1194602, -2089659, -2285972, -8631021, -3464497, -2344184, 1755516, -3126864, 3803819, 9481989, -7369937, 6871883, -5040548, -7425769, 5196825, -1891070, 3491503, 2569710, -8473185, -2995582, -5837448, -7848320, -2761056, -8750280, 7981197, -6680450, -1534184, -8003579, -5257347, -7686321, -5955197, -6257589, 5290466, 2637166, 5562288, 7456971, -3197753, 7004579, 8731920, -4477408, 6522701, 1443439, -3986165, 477650, -9638486, 4732004, -3518565, 2428666, -1246959, 6714301, -1652261, -112108, 5040928, -601149, 5007596, -4507924, 4904313, -8586323, -9247277, -5975498, -7098362, 1914243, 4530114, 2519316, 8971841, 5144588, 9678651, -1224226, -5820041, 3258157, 7073729, -7770910, 1602790, -4549545, -3214764, 9409257, -6725588, -7399983, -3281353, -5049832, 5854917, 3848525, 3805209, 4419670, 7347988, 2012360, 217508, -860320, 4172892, -1009640, -9326945, 3250082, -6325109, 6917286, -4322652, -9132514, 6884190, 8757216, 4422632, 6496013, -7242820, 5528540, -6847173, 7875210, 5893004, 878256, -5883179, -180902, 5170491, 9985613, -1911757, 266556, -8807395, -4631588, 3933624, 7947259, -7318378, -1420697, -2443332, -4486999, 12584, -7119184, -5824009, 5861648, 309160, -5770975, 4608617, 9217513, 1289129, 6435089, -8286910, 2824738, -2041483, 5850027, 1317216, -5539572, -4578540, 8501656, -909892, -9589105, -6801130, 5199886, -7226735, -668626, -2365340, 9404462, 266636, 7156718, 2062412, 5368864, -3489275, 2563976, 5232343, -7658817, -9335298, 7579906, 6222591, 1347396, 4107184, -6856875, -4379999, -5276539, -812814, -5482555, -8206001, 4074997, 9563228, 2786905, 4712754, -5963366, 3417387, 4245643, 3855086, -7313217, 5517471, 3123804, 3999513, -1840293, -8004380, -3134256, -8885417, 6432517, -3685034, 1847883, -9848244, -8536964, -9727451, 7592, 4992408, 2066046, 3154360, 7356436, 4984935, -955435, 6786911, -7236466, -8798029, 9398250, 9243130, -2543865, 8471325, -3473451, 256938, -7894264, -6575846, -1766241, -4365228, -7557975, -1083431, -4724164, -588179, -3480609, -661903, -1552467, -1832197, 5723856, 6115266, 3239926, -8718652, -6930657, 425668, 58138, 1292544, 7451655, 344173, -3089759, -8700415, -1130238, 5013033, 345691, 3005257, 7356646, 1797401, -1934885, -3569444, 1375002, -4757167, 8309897, -4015282, 4235561, 6556103, 207905, -4048010, -2671560, -1278827, 8431007, 5792262, 4817090, -8208489, -9839171, 8134419, -1410695, -411920, 4608178, 8243142, 8516714, 4926953, 7907897, -5728707, -3639146, 827488, -2907764, 8633355, -8185420, -8952978, -881975, 336741, -9312598, -6576811, 6853160, 1483586, -257788, -6239431, -2024617, -1278285, 8071529, 8903385, 6586276, 8781045, 8533830, -8059818, 8963648, 4106201, 5303447, -5820937, 7607421, 9382825, -1863859, -1255557, 6128951, 6066413, -4566091, 5333391, 3747414, 9712528, 9079860, -3016729, -3491092, -7474607, -1482971, 8911877, 8561583, 5656865, -1349785, -6213232, -5225834, 4478679, 4485817, 5882539, -3107273, -4609149, 2230259, 512363, -393829, 8356806, -7547576, -7440919, 530952, -8762587, -1622385, 4817964, -5640393, -7962109, -5583299, 6368627, -7102205, 6016876, 9152378, -7290059, -1820753, -7997764, 7954873, -5036895, -7814803, -9112824, 7546955, -4705139, 2821758, -1336355, 9663939, 9857674, -957823, -167181, -4848126, 1216308, -2194906, 2977576, -191098, 506646, 5020166, 4300764, 2794162, 7387902, 5558114, 5158531, 4577664, -734563, 7535599, 3638615, -5776365, -9424563, -6156819, 4231354, 1519365, 2901192, 3795574, 8669641, 1764126, -242448, 9139023, 2449212, -4317739, 7618077, 48660, -2972036, -5547212, 2037074, -7517196, 7091692, -7178524, 5257844, 9012998, 3561453, 5397815, 874169, 3642954, 67805, -4614184, 8677012, 7516792, -709253, -1140293, -7107677, -390377, 7014081, -1578811, 705814, -9286875, -6258857, 4890095, 3411052, 7425179, 936594, 4573522, 1514424, 5442217, 9740067, -3204986, -3032877, -2731209, -6607635, 9802321, 1646034, 9653135, -191971, -5657592, 5804330, 6164171, -9721120, 6863559, 7221104, 2504121, -2508065, -1651263, 9653175, 7887885, -4013565, 5624431, -9698417, -3551178, 3773407, 1711889, 8064814, 4842461, 4650056, 7841738, -3759342, -7460216, -1472780, 866774, 5923978, 7734098, 9254614, -9483769, 4808951, -4335119, 8484298, -740572, -1520438, -991367, -6697341, -3644541, 6386718, 9232663, -630827, -2222342, -1684272, 8830454, -8071761, -7712986, 3415791, 2975955, -9399359, -1352201, 839775, -8500479, -1309106, 3837959, -9088667, -4610070, -8687762, 2997478, -8302332, -9483957, -7472152, -4684528, -1821945, 672646, -149974, 2435030, 4274295, -8396198, 3961983, 9169283, 8416978, 4767030, 4157337, -9026917, 6673703, -1788799, 9664449, -7545461, -8097681, -7646661, -8893464, 4456085, -9722307, -2104934, 8626847, -3618845, 5313670, 4688589, -1001171, -4293799, -3419987, -7353398, 2159388, -5851839, -9827880, -894849, -3553039, 6752147, -9081028, 3593088, -429693, 6991656, -2753480, 137258, 7316125, -9262067, -6448792, 9218756, 1794390, 9089345, 5043425, -7661703, -8825459, -9477030, -3688082, -6227607, 6704776, 866565, -8199057, -9944150, 5146732, 8786673, 1604031, 647746, 1352991, 6813520, -5046261, -2134451, 1776882, -3029037, 8284314, 175607, -7947763, 1703094, -1947342, -1409243, 4696527, 7476681, -8280157, -9224588, 9384079, -469817, -9933514, -3352485, 2652675, -4359241, -5832112, 8981502, -2726248, -8742858, 5224799, -9812644, 5450656, -7375514, 3832472, 5780706, -2878811, 8678471, -6624141, 6353158, 8304848, 4427035, 9058770, -1676719, 669504, -7287342, -6453533, -8631110, -6225224, -4584728, 4569170, 51039, 2873560, 8442628, 3394055, -8212038, 2206269, 6772239, -4800901, -6260625, -6471933, -4511852, -4350244, 9276020, -486114, 7231124, -4623505, 2696145, 2985771, 3807548, 7338634, -4067472, 263777, 319536, 7941643, -6501625, 7068394, -7523465, -313231, 8122379, -6215420, 2894170, -1940204, 8791202, -6884863, 7189420, -2799954, -3501296, 8598278, -4916565, -1734114, -9061388, -7100104, -5078484, -7980355, 9251959, 6879243, -9577302, -3711297, 2721093, -4852076, -9606468, -3615582, 9535047, -305366, -1616006, -9755821, 8130618, -9826924, 4686918, -7372925, -2113339, -2107945, -8245999, 5623584, 2802791, -9436226, 8294533, -8446062, 1226456, 8567151, 768302, 6393785, -6292475, 8898091, 5868738, 1637774, 5708263, -5149049, -7785411, -4341203, -4823060, 1498600, 4963374, -2239194, 9735804, 1122245, 2068768, 9204864, 3343409, -9741149, 6458842, 44625, 4425211, 735514, -4838201, -3278697, 8503192, 6142881, 5957193, -8477121, 7559222, 4106959, 48124, 4260679, 5975686, 1339286, 9683093, -8575015, -6632395, -6241144, 7221741, 2847708, 8439550, -8973418, 6427371, -5030142, 2007322, 3753393, 1751249, 1096164, 2579018, -361721, -908871, -5367052, -7355017, -965741, -2297254, 9810850, -4547105, 5704189, 7090148, -6454706, -3976742, -7836797, 5905427, -6462591, -9735554, 3800590, 1181631, 8679369, -2438290, 6589728, -5841628, 8462403, 1298502, 1539368, -2152929, -610477, 4454860, 6288468, -9889332, -6741847, -8908008, 2629363, -2824960, -3186210, 6627712, -7987920, -2941487, -9373114, 4825187, 4670794, -7294052, 3767452, 330083, 5843329, -5107873, 5119916, 7717047, -1015280, 726723, -3675965, -2430899, 2501191, -6953241, 3898764, -9248347, -3921807, -3838417, -2788079, 3676696, -4637499, 8587992, 4838751, -8097264, 1006017, 2108207, 3818875, -9917120, -7416848, -3847685, -3885118, 1181894, 9254854, -5360689, -476040, 4414002, 2223529, 6189692, 280935, 4043481, 6435612, -5525928, -5553137, 8582772, 9305027, 7261053, -2373512, 4898928, -3217138, 8220565, -953646, 9907893, 2303336, 1047274, 4824228, 4338772, 8645848, 9283118, -3644142, -9680373, 4510039, -8827487, -4118955, -8208318, 9954435, 4640290, -7564216, -8540344, 6399787, -5237444, -2124344, 5429159, -6523384, -252682, -4515437, 1952958, 4735461, -7741613, 8688501, 397935, 8548876, 866226, -991967, -6327084, 5787048, 3062082, -5012327, 6612321, 8583902, 2698533, -2576269, 3900383, 5748271, -733008, -4187079, -3817716, 1062564, 2220325, 6469033, -6377348, 2554615, 8236820, 1288184, -1267375, -2038146, -80793, 8987349, -4719614, 5583295, -2933533, 1108510, -7058379, -292082, -4073237, 6972542, 7434699, -2879794, 8790186, 9046015, -3071960, -1197248, -641414, 512171, -6139171, -9293535, -2571023, -4664254, 4974159, 3656226, -8647611, -3554165, 766629, -7033454, -3887136, 6198127, 4544130, -7568240, 795263, -6583025, -5923048, -7450626, -591944, 5049989, 4908844, 625426, 164512, 2484353, 7551519, 4190881, 1147180, -9923547, 9623665, 6570812, -4041524, 4114065, 3668119, 3362139, -6366188, -7815747, 4238091, 7427008, -5646925, 6568834, -2017647, -1454282, -928635, 5013083, -5749428, 1055988, -774351, -5146437, -4952099, -2160427, 6323383, 2508687, -1361731, 4042500, 2785997, 9856938, -5144224, 7935056, -2676843, -693773, -8003732, -9936308, 8303899, -9186809, -2293669, 4804761, -3134282, -882079, -7690552, -749894, -2645679, 3189571, 1557782, 9748456, 7786201, 9536006, -936225, -7111285, -3007938, -1045877, -7226277, -9695850, 7785161, 7253902, -5925466, -1168636, 6211088, 8713140, 4982151, -5284873, -9301355, -900812, 838908, 9327132, -337627, -6558446, -8078880, -4834571, -3242558, 5312518, -2522477, 470523, -3303207, -4166808, -7394338, -2291915, 6386566, -266276, 8003900, 1434032, 5366248, -3522391, -7104707, 9765964, 9827232, -1074994, -5307112, -4471772, 9289970, 205146, -8988046, -3537749, -4954574, -8448855, 9726075, -4756104, -8539542, -8409836, -8775607, -5722109, -8254902, -2169737, 8877982, -9695877, 6678600, 7368613, -5192354, 6444742, -9476139, -3512526, 6285617, -4401603, -446425, -6388535, -7402433, 9698120, 3971009, -8826301, -8430792, 5863606, 5558193, 6664330, -594867, 5211828, -3443710, 2262098, -9562044, -3152311, -6965980, -1551459, 9844772, -7467254, -6262571, 2334252, 2514733, 3210420, 5194209, -5943113, -4643513, -1306670, -6641703, 6860417, -6028938, -2481323, 1677394, -9252874, -7608876, 3846861, 5165856, 9264770, 3370882, -2254047, -4616575, 7673826, -1110306, -7344881, 1447442, -5902870, 996585, -177200, 5628511, -7644744, -9105325, -5739827, 469036, -6934233, 1504708, 6135651, 5249517, -7842381, -2145549, -3901958, -5246692, -1920625, 81857, 291980, 1578047, 4286790, 7423379, -302154, 8704258, -352483, 9022493, -3790169, 9921025, -1970853, -7239241, 3089339, 1090493, 207340, -9458247, -7891864, 308489, 239387, 7227687, 2418209, -4929406, 7551758, -4070379, -4374629, 1401086, 7975737, 4552211, 4649505, 4801800, -6794868, 836949, 5705821, 5222922, -4746519, -6976334, -1845841, 9866018, 2223420, -664641, -7169828, -4521791, -3288514, 7868749, -5421462, -7639969, -4962219, -3930463, -537669, -3451897, -7232385, 7838300, 2850000, -4022751, -5594092, -7525061, -8123291, -1507810, -2707344, -1553132, -2450100, -5198312, 1389438, 1696579, 1086299, -5990559, 8623335, 2087494, -2462982, -8865809, -6586585, 7720884, -2518224, 1490805, 3489435, -940415, 1236894, -9725965, -4625975, -524794, -8141316, -5288287, 479544, 5387391, -3940580, -2673017, 4715113, 7057963, 1413150, 7150026, 4810948, 1447161, -8285849, -949862, -9429398, 5786141, 8129726, -6448293, -5541791, -1622973, 1816121, 1172249, 3354122, 1950940, -6564365, 492676, 8788648, -4978630, -892411, 6428325, -4374927, 2635528, -7261649, -5022645, -8143532, -7696982, -8344208, -1893291, 3015672, 7432061, -1656247, -490729, -6107688, 7472828, 4807400, 4259323, -7944911, 9153702, 2082384, 1089698, -8867242, -664130, -1403657, 8691328, 4766845, -1867257, 4409890, -7010856, -2118909, -5236660, 7359440, 407097, -7026860, 5789318, -7832623, 5818126, 202304, -6802349, 3967704, -1546721, -1424616, -676091, -4289108, -2755777, -4582644, 5061748, 8617311, -1676707, -4293228, -331754, -8098619, -2086251, 9316661, -6521140, -6027439, 1183478, -158820, 6221039, 4203171, -2695903, -9934202, 2795838, 6077486, 4443335, -5729952, 9835027, 2743231, 7741667, 2058475, 8515797, 5561927, 762957, 7177955, 1114062, -8015299, -6051692, 8388481, 8272764, 190869, -1439210, -4925899, 4423799, 2003603, -6160919, -6212389, 1136353, 8319898, 7292277, -3642673, 8192982, 9260424, -9529285, -5159261, -7185858, -8856916, 8905451, 6756949, 6293377, -2980570, -3780964, -9767974, -1318734, 6860155, -1321377, 7567832, -804479, -1194041, -976751, -425826, -8174905, -8718108, -2948105, -3113759, -8294511, 8023941, -6487723, -9404547, -591016, -7540740, -9022622, 8485510, -6395259, 3386229, 1649662, 1044755, -7225542, -6032460, 8094570, -1732509, -4192396, 6711875, 2783889, 129513, -3418774, 1433416, -7365260, 3385386, -1098813, 8978840, -2056398, -5703747, -8354231, 7079066, -3969539, 5839863, 9248250, -8993582, -6870077, 7832786, 5448046, 8284828, -9735577, -1920833, -1630252, -9294225, 4753151, 2222880, 5228368, 8614894, -4678393, -523441, 842818, -5720502, 4874829, -5064142, 5776560, -6250673, 1612093, 4748592, 8314429, -2433260, -1116168, 2428128, -8965149, -4561662, 739476, 804259, -1735997, -9216613, 625942, 6583933, -9221091, -262377, 967047, -7291649, 6644943, 2670940, -2594590, -1638261, -4914949, 471678, 7503647, 9761168, -1546390, 5974896, 9203180, -2668866, -7325872, -8334092, 3485045, 245957, -6333120, 203852, -3606576, 3685472, -125016, -782553, 6072546, -4394564, 1300895, -7740744, -5131509, 3823501, -9969497, 6093694, 4684791, -6767754, -819848, -6443486, -9551322, -5426926, -8243514, -387118, 3602533, 3772337, 414080, -8974392, -4421724, -7245923, 8205308, 5366108, 4125123, -177671, -6720679, -2934366, 4663199, 4783088, -9012009, -3061579, -9079682, 6587904, -5379123, -4251240, -9717931, 2571117, -7794283, -4590278, 5346579, 315862, 75341, -4675331, 3277875, 2989346, -6041025, 3998328, 4919561, -6065726, -2610314, -1059737, -8263809, -4923537, 8449991, -8636558, 1637060, -3534177, -4285356, -4528851, 9253833, -199251, 1070294, -3825845, -2518679, -343225, -8126994, -9172513, -9381599, 3880337, -3829091, -3819615, -9760072, -5416003, -1372311, -5862227, 3875975, 2949373, 2742301, 7630899, -6437435, -474743, 5251748, 3776800, 7653338, 1596005, 3177513, 8234869, -2717893, -5166934, 9975842, 5065133, 4864117, -1287024, -9186974, -4667521, 4943999, 2840587, 8643105, 3264723, 3122651, -5728714, -3624164, 9483822, -9964331, 5793953, 258807, -9040580, 9512864, 9848353, 9178315, -9436712, 8558083, 3886088, -10354, 3922018, 3808476, -7962838, -9582194, -4282138, -3547074, 7847393, -480201, -2917037, 637476, 4585476, 5023993, 7422926, 5008391, 4967320, 1465165, -4184894, -4344330, 7112368, -1342650, 4979004, -7448323, -9374619, 4259047, -8570326, 9888842, -8667489, 1027839, 7281665, -2467702, -532681, 2391185, -9437388, 5216906, -1479553, 3474221, 2214399, 5158801, -281777, -3636926, -6470398, -1423251, -146559, -4248375, -9224267, -4765423, 3486142, 562249, -5004578, 2307454, -1573442, 9288563, -4251547, -977937, -698443, -1309229, -8982635, 4544890, -7921929, -1597136, -6800861, -4115878, -7035376, 894963, 8636811, -6614378, 4001618, -9349859, 7892531, 7486616, 5117538, 2258682, -5741730, -7067923, 8413764, 6887743, 227964, -2343848, -3208382, -9662131, -2707914, -1584066, -9977503, -3437966, -5170370, 8647618, -6289363, 3025426, 3722270, 3357489, -9566176, -2669839, -8633910, -4806489, 5881497, 1158081, -3420100, 6863698, 5959775, -6663945, -150543, -7301129, -770242, 7099918, 3782945, 4140867, 2260412, -2586741, -8793375, 7564249, -4759175, -8609182, -1768146, 6235562, -5519745, 1721671, -9980979, 9594681, -1351355, -930398, -5852008, 5421684, -4378529, 9886844, 7339546, 1207690, 2668868, 4622617, -6559955, -2421282, 6159552, -9428250, -4389115, 7141688, 4349316, 3578984, 7795486, -1217918, -4129263, -4954363, 3574206, -3119553, 2718297, -5917542, 3770404, -7505302, -4519578, -9056753, 4616335, -4573202, -7678916, 168117, 5736590, 6503158, -2869445, -5231800, -7726082, -4139619, 8434077, -3559213, 1109536, -8679506, 6598289, -219697, 263544, -6078997, 3531712, -3714825, 9635493, 371431, -5853634, -9801018, -5861871, -6610128, -1304467, 707652, 5592059, 1316132, -7112952, -6408426, -3050889, -3296172, -6125711, -9022057, -2386110, 6158263, -7283891, 7935112, -8682781, 2053726, 5299511, -3058999, 5325063, -7527434, -5152520, -3156831, -5402212, 6033226, -9496802, -1405079, 6696692, 5168293, 714284, 9878779, 3521257, -804536, 408326, 8984600, 5629525, -9376921, -3683372, 642989, 7439591, -6699206, 6498723, -7544449, -6055490, -4279385, -5074358, 2482916, -1851073, 4950984, -5982119, 5662033, 8998050, -8042522, -6396759, 7899634, -142652, 423196, 9646315, 7677228, 3807737, 7763908, 6206279, -3017386, 4510399, -4834979, 1382759, -5975204, -8837302, 2335815, -9791996, 6699533, 661726, -1652190, -3251877, -5784353, -2897509, -8250008, -2979954, 9715201, 4617274, -5313292, -2804881, 2736606, -1304215, -8043215, 4911568, 3341863, 3395814, 3539311, 9567369, 3185411, -6296690, 9387351, 5975399, -2007553, -2983640, 1277006, 9870666, 3936154, -1625481, -7319485, 6412010, -3514140, -5379295, -366644, 2747635, 5917671, 1189960, -8510654, 2457035, -7179600, -1510962, -8446054, 8514910, 174175, 610065, -1350082, -3234469, 3523454, 4601831, -9757016, 9603778, 2152942, -1067009, -8925844, 6477991, 9570671, -4421650, 9287003, -504341, 7511505, 2316641, 4685816, -1330709, -9065397, -1736152, 4145770, 1598434, 6127108, 6424267, -1097878, 4423540, -5236844, -1054502, 1648619, -8592113, 1122795, -255061, 4182874, 7406937, 6826725, -1504031, -8863502, -889729, 9458286, -4411913, 6589708, 1046761, -1959813, 6795282, 4128035, 2636036, -8574323, -8220834, -9931339, -7225418, -930815, 8701327, 873290, 7265958, 247034, -5347636, -8032652, 8381965, -7019185, -7913302, -953648, -6179723, 5316237, 881185, -3423070, 287629, -564433, -7864059, -1456477, 7258308, 8715595, -6161054, 24451, 8828751, -3072477, 3511217, -627508, 2992407, -1807144, -5992461, -2341811, -510878, 4260599, 1376792, -9329589, 3845030, 6821422, -6838957, 7137392, -5433660, 6514307, 2832444, 41263, -5321739, -667690, -1362899, 4312574, -101292, 2926322, -7292670, 2829073, -7187040, 2966694, 3740727, -5673302, 7804755, -4403933, -266334, -5662406, -4153454, 8484656, 3646679, 3610003, -4123566, 7422605, 2471230, -8452307, -4519744, 9201130, 879565, 9718406, -159243, -4925420, 6110716, -2644698, 3565678, -5509596, 4768836, -7862191, 28682, -2527881, 8609338, 818831, 136005, 7652170, 6555571, -6128849, -3022069, -5963668, -3139219, -3516465, 2909402, -42399, -9092907, 4706252, -8370680, 8983937, -8519937, -7875342, 4910129, -8793948, -1596399, -2005692, -2817457, -4809810, 1451665, -3505757, -2752278, 7244342, 5668910, 4540513, 1077818, 5609165, -7315207, -4582347, 573465, 6145962, 1987889, -1591756, -6533410, 8304701, -4854787, 3783424, -9208899, 3631299, 2497175, -8871327, -293184, 1892572, -7523066, -7988899, -774716, -1261415, -4469702, 2064504, -7624540, -4382837, 2941272, -6568235, -7471010, -1562512, -8781635, -132335, 7405137, -5947009, 6993797, 5949240, 3708157, -1047068, -7296473, 1247426, -1999754, 1055179, 2649247, 9335535, -1494330, 3663908, -7833974, 1384155, -9855761, 510162, -6325985, -5026396, -2787065, -2192018, -575054, -5147516, -8889634, -24017, 8697594, -7489696, 5324185, 3256577, -1819618, 6404347, -5027805, 5565624, -8833739, 8324224, -6574194, 524625, 5517526, 8178484, 4154445, 4059672, -7563070, 5972484, 8227029, -2465181, 8760738, 9756529, -3201080, -2840252, -16762, 2481545, 4090901, -4292038, 4424242, 3350912, -6054717, -2423424, -1391752, -4785571, 3312505, -5665980, 1650751, -5434894, -7217375, -5024409, -625792, 813394, 8517926, 5951521, -4810288, 3538215, -487453, 9548765, 9133386, -3780381, 4793062, -2135030, -9043780, -1752463, 9384547, 9159882, 2336917, -9859279, 6404029, 6001385, -5229096, -1546449, -2942453, -1106099, 8898832, -4700101, -7855483, -8790183, -264773, 3062445, -1148917, 9510283, 5654283, -1631123, -7562883, 8654754, 2052357, 4026056, -5401649, 6001768, 4292379, 4052159, -6963245, -4201906, -9529945, 3376132, -988713, -1107700, 6573033, 6259917, 8551769, -1407793, -2877208, 4175677, 8277262, -4362606, -4767365, -5065814, -9438801, 5291134, -4671957, -192164, -5638922, -2429463, 3668156, 2496396, 2953155, 1039803, 6109200, 3759759, 8852150, -953304, 6614334, 3934098, -5272847, 9788500, -8910285, 8131444, 215750, -2042879, -1673643, 2752689, 9437705, 3916771, 587887, 6750092, -7937371, -9412056, 2647567, 5428541, 8494365, -3362101, -9587009, 7529498, 1346252, 57059, 3520485, -4873990, 2366294, 7273828, -3558395, 4081948, -8383205, 1081794, -456650, -5927954, 4257186, -7067172, 7826126, 4999288, 7141146, -4459934, 4903929, 9592867, -1396660, 4978641, 9203849, -5195712, -7437658, -239348, -205751, 6396222, 1922954, 7073684, 6218650, -8657369, -9344284, -6342170, 6494228, -5389194, -2341890, -9072524, -6141766, 5651201, -6037828, -9226396, 6887162, 7604785, 2374650, -8335435, 391077, 8177316, -6558435, 6035077, 3844024, 7283995, 2492680, -801630, 6748734, 4709044, 5689167, 7980194, 6778753, -2176743, 1655259, 985850, 3583499, 1774019, -4882910, 7575218, 9206258, 8752169, 7876485, 1797489, -7053328, 8091216, 3417349, -403978, -557125, -1208811, -6511476, 6308480, 7851221, 2811355, 3464177, 6264976, -2434167, 8264310, 4660347, 7038280, 3415975, 4589008, 8186035, 9607938, -9132275, 2809893, 9467901, -5192377, -146106, 9490233, 6327918, 5641940, 2420448, 5284048, -2611219, -4882062, -5517821, 3475028, -9837329, -4871960, -7266144, 5216571, 7762058, -3470606, 8466290, -6335415, 6512774, 6784420, 7664813, -2627389, 6219617, -7952237, -2197206, 5813934, -3165443, 8521332, 3563191, 9106128, -5543944, -4358656, 6010883, -3242080, 1771911, -6917278, 2965524, -6829994, 2644353, 4335001, -389314, -4712627, -9713744, -9704051, 7971363, -165118, 1580143, 757555, 4680260, -3851062, -8529470, 8320455, 9554575, 537704, 626477, 4021024, 8120717, 9459252, -1433640, 3556068, -6120007, 4794427, 4801355, 5927078, 5375834, -5612075, -2758982, -2452659, 3874966, -8291657, -8831681, -3075891, 366915, 2575944, -7821937, 4526676, 1345253, 2091916, 6955821, 2671846, 5554954, 2648043, -6196369, -7919071, 8449762, 3319113, 7886258, -8903887, -8369275, 8408792, 6718667, 6333328, -9365688, 8672952, 6775605, -1910975, 1532684, -4722249, 1334171, -6440602, 9428204, -967201, 4824412, -9466565, 8507297, -428028, -4130736, -6772220, -7943195, 680192, -4642469, -2355050, -3343599, -7045065, -7674127, 3785432, -4558462, 3353231, 7430079, 7492941, -7045016, -7413134, -1618999, 3819402, -4251438, -635275, 7268544, -7921591, -4634500, -8241455, -4397702, -5412209, 4789013, 1444961, 2373749, 2821284, 9757631, 6734279, 9594839, 3193742, -3318670, -6160418, -7614039, 8305173, -218684, -1651597, -6017761, -6554653, -4271178, -9871308, 2686677, 7864930, 9884317, -1350473, -3721823, -1678239, -3240158, 2381671, -6451815, 6249751, 6047677, -5001149, 4003025, 9612676, 3071909, -6037553, 8352725, 9940803, -9414136, -5142755, -7228384, -1974684, -6437541, -954028, -9611022, 8386241, -9731501, -2607088, -9560862, -9048500, -297534, 3934818, -5451342, -309406, -9404137, -1399565, -2315741, 7473412, -9762156, -4508130, 5430448, 3486942, -854668, -6008022, -7148687, -6202354, 3077642, -5952108, 694254, -2447957, 8577203, 3749499, 6574051, 1989160, -6032426, 5913803, 5215066, -715440, 6760418, -4733039, -1805823, -3189075, 8369411, -6849903, -7308311, 4330889, 9294736, -2080838, -4219906, -3241720, 8346325, 9992740, 7362319, 4467870, 1069821, 1374020, 9212085, -9107753, -499359, 2239494, 2102779, 2565239, -7723283, -2177520, 9367005, 5510605, 6246128, -8122998, -3849604, 6738016, 9675508, 3136154, 903471, 6165100, 8692514, -2365369, 9341234, 5401068, 4013343, -4188370, 8829713, 2665992, -7707163, 3688990, 8881702, 5777696, 8830106, 1676067, -8919889, -8006940, -7281489, -5115712, 4684653, -3174943, 6451189, -3932423, -5368829, 2061232, 2888276, -5366583, 577933, 9283199, -2889437, -5241938, 8087144, 1252122, -5150873, 6279141, -6010032, -2885276, -7100098, 9732801, 4550423, 9455412, 55230, -6254732, -5567010, -1774776, -9612982, 7726284, 9798039, -5624810, -583869, -7132304, -4566427, 8310157, -5311856, 6434274, 7505920, -6245425, 7481152, -1587751, 470182, 7124776, -9160534, -1333275, 4647823, 454346, -8669480, -9129707, 8542600, -6125640, 7741140, -6315272, 8842802, -1848720, -2230427, -6846630, -411511, -3923620, 6373321, -8776934, -9279914, -7569242, 1319691, 1454668, -9732315, -9707027, -3796832, 1909193, 2661260, -6935120, 633211, -2541880, -2042411, -4960283, 7876210, 6043125, 9130603, 6087325, -1253715, -9037070, 4809667, -6808434, 8191664, 6464338, -4156922, 598689, 6334412, -2234953, -6153145, 128563, 5886250, 2766647, 3880163, 1313428, -2679164, 7503539, -6334612, 5811420, -7192595, -9553046, 9412552, 3922606, -5104690, 4094058, -682273, -9977548, -7962007, 9372068, -5586747, 5017147, -3118160, -5828210, -5287533, 2170686, 424465, -3739516, 543865, -5823802, -1074121, -8980519, 1305983, -5716243, 1889754, 6359213, 853214, 9839383, -2167312, -2353949, 8631483, 6163621, -2099852, 505229, 1419149, -4668090, 6703092, 349017, -8096657, -4827121, -7645561, 3904347, -6301878, -9160586, 6509219, -8288863, 6788040, 1091769, 8118026, 5798976, 8911504, -9913534, 9976182, -4125216, 7529801, -6408407, -3506357, -4463523, 8343113, 6023555, -4033758, 1962009, 2953011, 2758690, -7255790, -9569074, -4753211, 6351661, 2120140, 1820185, -4876355, -7978178, 6586206, -8168851, 9388768, 2859593, -272652, 8538241, -4390045, 5933942, 8360491, -1309619, -645208, -1563352, 2555682, -169556, 99078, 2186063, 8610331, 8484935, 8099873, 4818683, 2617764, 9080386, 1103589, -1449683, -495954, -7214768, -435136, -3381770, -6919737, 822322, -7027377, 8243625, 8050994, -3197589, 7163290, -8433733, 8150997, 632216, 3734114, 3479586, 4329428, 6111603, 9291869, -6965191, -3069895, 8619800, -4808587, 3540965, 1291915, 5743138, -9956359, -872552, -5888170, 6948619, -5618379, 8165085, -9916885, -9524981, -1051021, -709567, -6296114, 8763960, 8851546, -29009, 3642449, -8517047, -823157, -7285463, 3739166, -9888724, -3027939, 7267891, 8707212, 9576153, -6875864, 416988, -6862560, -2444928, -5811873, -9811480, 8116407, 1126238, -5490045, -7635782, -7416320, 9200072, -7062565, -736256, -8741979, -4832041, 9212811, -8065389, 765798, 9929089, 4969191, 785521, 4303536, 947289, 1274737, -7131757, -8196687, 7912395, -3265609, -5014429, -4472711, 470059, -4990002, -2245900, 7812680, -3747320, -5487939, -5118007, 4166417, 5097858, -9440567, 1832039, -5545949, 1459318, -268225, -3570231, 5654707, 867892, 2016473, -1468197, 1609856, 6662154, 5722289, 9826027, -6368666, -6578084, 2094098, -5301039, 3642648, -5353770, -9472553, 3811004, 4204552, 8330143, -7658390, -5685788, 142909, -9694883, -55237, 8827463, 7186715, -3449309, -4338290, 4747128, -4389427, 1626912, -7943545, -4778063, 7481829, 8981430, -136009, 2879194, -7923111, -3896510, 8188749, -6068963, -9853221, -55631, -1679533, 4452281, -9244196, -6705958, -8287207, -2782980, -7178653, 6524739, 1836330, -5916010, 4386048, -8313269, -154694, -9784730, -6598385, -6892245, 1508501, 7643476, -358586, 523673, -3311970, -2515290, 3904615, -5247505, 8236375, 5543032, -5049672, -3403662, 2427932, 6431032, 8861786, 1203142, 2774546, 2394901, -3960003, -2899088, -5436783, -9483125, -8284227, 763298, 9095983, 1145398, -8860358, -908484, -1402119, -6253031, -7170891, -315018, -5491009, -6926397, -2820088, 8878702, 9289539, 7633181, -983657, -7268695, 90790, 502860, 1483938, 5042960, -5849170, 7901637, 5683196, -4659577, 4792176, 2967244, -9710659, -6765769, -1685899, -7457940, 3117132, -1870328, 7123404, 9246130, 9769913, -9612298, 2809375, -7490008, -2807272, 1733104, 8546865, -9394952, -4891523, 5793813, 9331559, -2466319, 6528892, 752753, 4338822, 8288417, -5279976, -3801662, -1331295, 821053, -8712769, 4676068, 911937, -1014763, 9546892, -9447663, 8494108, -3918789, -7700940, 4772379, 818482, 6149397, -3038036, 1516341, 5310018, 6806909, 3777266, -6921740, -2204198, 6307633, -370325, 6244634, -5743402, -7949962, 1508931, -6363652, 3065258, 5836235, 9022518, 7824031, 9512736, -2001650, 2447085, -3493401, -5581572, 184785, 8911104, -3171604, -2293058, -7880107, -8190589, 8808415, 8920579, -9523254, -4135772, 6692359, 8807885, 5622593, -4243022, 9078190, 2220208, 383028, 9336233, 505715, -5929367, -3417835, -6300962, -8195167, -1983099, -1435003, -6010907, -5241434, 4286764, -9132895, 6989100, 1861574, -6591178, -6160279, 4484106, -9203946, -3904425, -1554412, -7522411, -1981109, -3765372, -805235, 5003357, 3617872, 6453125, -1826513, -1568122, -8041297, 1921467, -7654616, -5853843, -7175524, 1253542, 6171567, -2422923, -2565281, 4587585, 5068855, -1153415, -9850217, 7865157, -3249094, -9530633, -5142489, -882373, -7124670, -9513695, -4440138, 4684912, 8182463, -1514183, 799028, -217040, -7943192, -9601609, -3539658, 6276289, -4901496, 791730, 2622009, 4394998, 6957961, -6605118, 881188, 2648381, 9796498, 9604880, -1880584, -267947, -3009448, 3315228, -5874671, 2182076, 5237854, 42022, 5294189, -7148288, -3617458, 2213824, -275772, -329054, 5335564, -3221929, -2392164, 5212552, -4033616, -8469970, -7664637, -5427273, 2252938, 5846867, 1073304, -2648055, -5417403, -8967150, -607476, 6171651, -8975244, 8045483, -1857039, 6750231, 874509, 1061260, -173827, -1984845, 6401031, 6125641, 3315554, -6388789, -4928079, 1871705, -1258511, 1280275, 8277644, 8637010, -3609557, 4277442, 6694069, -9451074, 70928, -4569839, 9228726, 5694139, 9542726, -4686547, -5401470, -8437300, -1576363, 6821499, -4011605, -4025245, 2351388, -3492044, 8185257, 2789463, 9207359, -6491722, -182538, -4083723, -2145103, 6915431, -6755428, -9190918, 8964239, -1418661, -787563, -2013720, 2692330, -5234152, 708719, -2216402, 1037228, -1647980, 3180684, -3178202, -8398833, -2418028, -942233, 3099450, -9686043, -9096132, -2903354, -8633296, -3003305, -8746832, 8182901, 5211615, 5086036, -5270881, 2263402, -4428421, -712326, -4736131, -5949456, 9046919, -8237813, 3474653, 753382, -3532114, -6012172, 9589806, -4901197, 9441898, 3185606, 9813746, -4861846, 3528045, -4575814, 1230698, -682117, -8869949, -9005509, -5368433, -1467752, -4414591, 4731850, 264496, -7406440, 5890207, 1215458, 4715131, -6292058, -913250, 1157764, -4696199, -3950017, 9960272, 5051871, -2932916, 4072226, 26632, -4920592, -4439782, 4798701, -1051662, -6190440, 13017, 4001046, 4549245, -1457706, 3592893, 9300188, -1651509, 1751415, 6235896, 1120451, 6376272, 9021909, 6082804, 60871, 814401, -6222961, 6542478, 3407404, 3316820, 5536762, 3741885, 6604680, 2366829, -8884355, -5600181, -369495, -2797107, -8184654, 4725873, 3312730, 3106164, 5307784, 4681116, 9044469, -664245, -1292336, -2333019, 8162232, -1032483, 7029989, -5309407, 6683125, -5287170, -6753001, 3330421, 8806592, -527114, 8174681, -1760141, 2301766, 2142511, 59027, -3715183, 6497366, 8574048, -4072315, -3755176, 8990742, 5095000, 9666999, -9530201, -596054, 1299444, -4671688, 8508645, -8191987, -2762274, 6366140, -242078, 6847179, -9772059, -1818012, -6776791, 5750483, -9287684, 8909055, 805112, 9412006, 5432736, -2089241, -8288995, -2750692, 9408572, 7513392, -2122806, 4809261, -5723883, -2652752, 6019945, 7221177, 9218279, -5206991, -7350166, 2427193, 3177460, 939390, 2939865, 8667374, 9660780, 5098396, -3255513, -8877416, -1462602, 5256783, 1002565, -1781871, 8024799, -3735070, -4752912, -2557476, 9341718, 4342787, -1534178, -4790588, 1995269, -5232596, -2328373, -5148731, 2564646, 3029025, 4379020, -8591989, 4514647, -9816522, 507103, 118221, 6955002, 6229677, 5036425, 5191588, 5660680, 7915741, 1026770, -3853058, -5041129, 9387867, 3739486, 9343519, 5116833, -7595242, 8653947, -3453247, 5900479, -4041235, 3711020, -4454533, -6177928, -4795557, -4917773, -3753049, 1128945, -2730629, 9830356, 5846763, 6248434, 2971999, 6395291, 4596816, -8942788, 6559867, -5236628, 8223127, -2195981, 8899744, 2570318, 6704411, 4515586, -9270636, -2035856, 2695444, 4006223, -2094098, -9002313, -6390848, 5737152, -5639881, -2631526, -5774438, 6400754, 1307528, 3691279, -9835754, 5507299, -3862719, -8641752, 295300, 2204862, 3533724, 3257187, 8500735, 9052282, 4862957, -7603457, -1571331, 7589338, -8720457, 8401338, 1823417, 9108274, -1516662, 4809811, 1669780, 5935197, 9234810, -1782558, 4498220, -6133530, -7081792, 6001715, 9494440, -9174770, -7068317, -4914344, 9094591, -6896023, 147060, 2481944, -980822, -9051032, -7141047, -4969483, -2457029, -1419136, 4445862, 982360, -7510938, 1795777, -371577, 6889899, 5215336, 2101344, -5582657, -5687097, 5869479, 2590130, 9508798, 412200, -2844394, 1330438, 1250396, -2889979, 9646066, -7546515, -4414155, 5262765, 8744273, 6413334, -3698706, 1975333, -2329176, -3956259, 4100938, 7645803, 939300, 9315940, 7694829, 4270276, -8537842, -1854594, -386243, -8437467, 7018229, 4420651, 2834145, 9874588, -8687255, 6879861, -3502457, 2631654, -8698674, -1157088, 729978, 9342430, 735790, -5620239, -7818605, -7550364, 2027294, -2692406, 7781259, 6334856, 7905695, -1692676, -8901031, -7668562, -2774023, -5100563, 3939304, 5179436, -7470277, 7055695, 3434657, 8436320, -2130648, 3643463, -4887163, 5780138, 364694, -4759355, 3573924, 4191796, 7128164, -8668978, 2105125, -3066453, -8015969, -1646696, -5426458, 8770396, 3454850, 4635508, -8627112, 8754639, 7095120, -9794502, -2748706, 3992814, -9181050, -4823693, -2087471, 2545512, -9900639, -1061123, 9302422, 2750457, -2812801, -3640569, 6892116, -4601480, 4563657, 6973445, 5759227, -4886855, -832655, -5417550, -7619445, 1683687, -2688773, 5347591, 3874139, -9961091, -5915536, -2757539, -3599526, -8388132, -7324556, 3734609, 9789341, -9909934, 9867779, -9040101, -4744407, 9564725, -8949769, -1681714, -2171128, 952487, 7857297, -3572191, 4576092, 745054, -5445160, 1239867, 7189395, -169263, 5364128, 3141837, -5722387, 8562659, -9840266, -4447009, -5362518, 6681059, 1324297, 3367265, 8099661, -5967440, 5153285, 6543779, 1336766, 6524284, -7409274, -882067, 6579869, -4959232, 7180000, 1717479, -6292918, -4643736, 2298037, 5082943, -1273465, -5670996, 4522138, -4413077, 683281, 3069168, -2586493, 4820090, 6970447, -6029971, -6742966, 1170050, 8831550, 9673475, -9795224, -8527344, 7872421, -8765672, -3769091, 8637232, -5436604, 519956, -2078821, 2946466, -2382248, -6387924, -5900506, -5151353, -4689385, -8015721, 8660783, 8822922, 192141, 3635269, -4620811, 5394893, 456496, -6140900, -7313188, -6000395, -4616923, -1215759, 1242469, 6054836, 9977211, -6441746, -5679525, 6127724, 2599864, 1720832, -6085817, -1471692, -1822754, -4231120, -7348233, 1361696, -2777406, -4170513, 4907306, 2070143, 6397632, 5456891, -9187775, 4947547, 6466208, 522378, -2932593, 7677893, 2568965, 6433478, -5792712, 4220079, -688831, -3657885, 450347, -7331791, 8608508, -7766567, 3986081, -9105759, 840701, 3128443, -2393315, 8915187, -4648861, 8403777, -7281092, -5573136, -9277918, -2244680, 7073027, -8044083, -3711284, 8575969, 8905338, -2462738, -7755260, -2326805, -6795952, 9432776, 1901459, 944762, 5454493, -1284775, 1416864, 7771285, -1330770, 4686808, 1323806, 2635007, -5995446, -2055432, 7690849, -7554478, -181304, -507648, 9216752, -390684, -8728921, 5154858, -5402277, 4178605, 8035012, 5240939, -4388305, -9580869, -5060400, -3202084, 5902944, 5409056, 282030, 7923272, -4493027, 4304290, 8452523, 4390341, 9622047, -6309581, 2532627, 8967639, -3164948, -1175418, -2911656, 7130308, -7496722, 8530917, 6314053, -55350, 1078569, 9204557, 4554925, -4343898, -5070247, 7852916, -1882724, 5064769, 9446715, 8960897, 2819302, 6484455, -6571266, -7638497, 7275963, -9480064, 3663087, 5549683, -3289811, 9411497, 6940890, 4419943, -6661071, 7145677, 6802212, 6841415, 6181849, 1599365, -889835, 3506098, -1287157, 8822412, 8664045, -841437, 9691399, 2601602, -7320268, -1105001, 7307677, -9416083, 2350537, 3310707, -7654332, -3894058, -426564, -7141079, 655169, 9828300, 823333, 3646443, 1882898, 3213852, -6680606, -443725, -688031, -520330, 5327493, -1245007, -4411144, 2060642, -1485916, 631033, -6205264, -2459405, -532109, 479128, 7174885, -2019427, 7752520, 5699529, 1563080, 8688061, -2906716, 3180384, 7610992, 5886598, 6003089, 1282898, 3887911, 6372089, 6841740, -4701158, -5171713, 4613448, -8887967, -2566457, -4166321, -2323113, -1942771, 1035322, -1200463, 5617108, 5815162, 1105869, 4124080, 7469589, 312155, -7591503, 1250423, 8270479, 1772478, -9986439, 2331041, 6793805, -9488024, 8734620, -4348839, 7082056, -4132561, -3521227, -6778790, 5180645, 1111119, -2746517, -8883795, -1178728, -3441994, 9447198, 6797932, 6849338, 1020748, -9541853, 7868588, -8604753, 4222453, 5478407, 2519697, -783137, 1086994, -9973834, 4736847, -9340546, -2240075, 7747987, 8331794, -2371777, -8616920, -9692666, 4397527, 4371153, -2846723, 6706218, -3027793, 8999026, 6089075, 6066513, -2294555, -2033333, -5568438, 3563264, -7434793, 5626876, 8864700, 1932845, -3201742, 6017031, 4969661, 1215860, 1167369, 818988, 4057923, 8652625, -4810419, 5088969, 6883850, 2765698, 8118316, 5660323, 4724575, 9692176, -5885101, -5616449, -9754913, -2204798, 7121796, -3461615, 7534851, -6403432, -3092089, -1267175, 3180764, 4601098, -1139118, 7168671, -8556725, 5214165, -4236337, 6044554, -7852519, 392566, 8052818, 109267, 7219296, 3358323, 3415203, -8831178, 4153949, 8245204, 9925699, 9712167, -226169, -948615, -986992, 9869304, 2786467, -9359969, -5200767, -1073775, -9146357, -1336883, 7472012, 3490704, 2596996, 7393025, 8093348, -4139989, 4513939, -9535740, 3026152, -8867824, 5548878, -680121, -254757, -7860302, 9270219, -3399825, 5245126, -7412309, 2584843, 9083618, -6504956, 9909550, 618954, -3184982, -4400776, -6645738, 4624016, -9202740, 6146508, 673845, 7937389, -6434693, -6189509, -4217555, -4759515, 8211153, 9150441, 1105325, 3058571, 1718254, 9447713, -4631291, 4358908, -4866963, -3292747, -3168634, 1746701, -1393734, -6282257, -7958850, -4589528, -6198257, 7439060, 9387698, 2083066, 9458828, 130632, 7958223, -4164768, -8146418, -6488603, -8925165, -8372138, 5039788, -8058817, -3982117, 219356, 7151984, 3930681, 2888188, 6491897, 3995902, 7471511, -7423344, 58856, -4620527, -6633295, -3394961, 8069439, 5862621, -2096793, 86155, -1598374, -5099314, -2616225, -3600896, 9219855, -9901488, 4639060, -5093897, -7094817, 520553, 4809858, 9139736, -1317060, -7307412, 4358710, 2404943, 1113121, 3499484, 4431868, 1743549, 7388891, -6061189, 9963012, 1750970, 2892548, 5934423, 6925307, -8483983, 4693911, -6061212, -551286, -6420724, 4332822, 1524638, 1195630, -4433667, 7125858, -1541852, 387610, -2152122, -5827708, 4085380, 7482961, -9481772, 5384928, -6145777, 7715616, -1688746, -2695307, -8659462, 3279718, 9290462, -7190181, -201378, -962560, -5772991, 9205572, -3609881, 4271563, -578432, 7863898, 5717159, -545808, 7477401, 2675174, -8415876, 5814784, -9980013, 5400129, 3636949, -669970, -3034653, -1412382, -7524715, 6346110, -2588792, 4801597, -3246150, -9857787, 9388738, 6463235, -2932078, 3453962, -6834808, -5682036, -9064624, -934708, -4156302, 4090537, 8677786, 3896332, -3502888, -6092688, 818690, 8327849, -453218, -8722170, 3830920, 5893260, 9017107, -8156804, -80955, 881190, 5260975, -7805360, 8510938, -5789318, 2684664, -54683, -3054658, 6528206, -9808875, 6509562, 3351078, -5864640, -8604571, 3839704, -2205246, -9815809, -4010165, 9662015, 4445758, -5485150, 3084278, 7562771, -1141429, -7429668, 632140, 476453, 8132122, -5933408, -5955381, -2345713, -2584906, -4217548, 1339886, -6850094, -9453936, 8107590, 8586903, -2733135, -9086024, 6712739, 7391002, -3456048, -6680057, 2193642, -8165305, -4850092, -3296482, -708692, -4823963, 4489329, -1817452, 1916946, -301200, -6354064, 3413003, -3407746, -996222, -3893196, -8091900, 2754043, 9729633, -425245, 3049658, 7407228, -669251, -3654750, -9984625, 3261601, 1525805, -1500933, -4073935, -2219449, -9289407, -4636476, 6559726, -78584, -6785915, -3413181, -792162, 177731, -4971190, -9926298, -2076257, -8710870, -9892532, 2847601, -649036, 2345448, -9905978, 9411475, -9114650, 2533908, -9566563, 4136288, 7869945, 2481223, -9234625, -2925682, 3819664, 5171128, -6751215, -3318980, 5851298, 9883373, -1530904, -4099661, -4268899, 2591117, 8343983, -6234309, 4640522, -7625295, -8975531, 8916584, -8931387, 4262883, -2627865, -5237636, -8491671, -4466705, 275012, -1397598, -1334564, 1378494, -9858354, 9467805, 8713429, -5375673, 328591, 4685968, -6728834, -574558, -8352394, -3933943, 4083470, -1626785, 2277301, 5877782, -293027, 1279820, 8704917, -3612037, -1169232, -2625415, 8289958, -1869487, 3972169, 6943928, -1455046, -5468684, 6642544, 4667919, 7829955, -2125805, -7853892, -5862822, 3081220, -8690759, -8720547, 8572299, 5674272, 3990031, 3763933, -6336936, 6879109, -5248342, -6398441, -7878416, -526271, -2530986, 6028515, 8226490, -917227, -4937230, -9270746, 1106160, 2649808, 5441809, -2406159, 2855944, 2471198, 3556802, 3572147, 3868337, -1336432, 4509337, -958939, 6962968, -7762312, 6724866, 4657172, -3787232, -6720314, 8604568, -648059, 2791736, 4546800, -2929016, -9643510, -78490, 923912, -7071601, 9460856, 3769386, -6635074, -2564850, 1814968, -2970597, 4538660, -4634937, -1469948, 7864912, -4498353, -2618795, 6927467, 9231723, 1702012, -9517358, 396651, -2161969, -7990454, 8461486, -6422620, 7088653, -3033668, 292428, 6956341, 8479030, -5517657, 2187494, -8065435, 399447, -7660841, -4025852, -2426773, -5874444, 7371133, -6691644, 7772622, -6732401, 5294130, -2035244, 6840003, -4021287, -623143, -9418009, 6287806, 3709198, -6745865, 7740684, 9888075, -6677070, -6479628, -7949315, -9901835, -2258323, 366944, 4430194, -7671538, -878250, 6510591, 7710470, -6214372, -9521163, 9346152, -4868100, -9892562, 9653809, 3069908, -3895803, -9222360, 1416906, 5918270, 191908, 2919532, -5323447, -6290066, -6667589, -5757524, 3011800, 9083862, 164041, 4692236, -4453968, -5455272, 9439030, -1449978, -161675, 4041299, 6112420, 9697368, 9977102, -3742079, 4471416, 7236113, 7316613, -2382752, 8861586, 5908162, -9868227, 8131431, 336976, 8651508, 2020760, 1349237, 5728121, 3719796, 5146279, -5716116, -156592, -7313637, 5034423, -7422166, 9723800, 3820640, -2065838, -3390662, -6720862, 5898436, -8580860, -4442910, -2733774, -9792054, 1251891, -598790, 4234842, -4077749, 8568651, 5251230, -5869595, -3030988, 2360276, 2949706, -2384129, 8692165, -8466184, 4779446, 7877789, 3933431, -9097928, 8573249, 497587, 9429431, -2815201, -1643859, 1160946, 7696306, -6689595, 3544245, 3106245, 5580351, -7118814, 3908443, 3022558, -7461524, 9070258, 9262088, 8522729, -7795622, 9493231, 649853, 1325227, -3851749, -7788985, -8876451, -8096155, -1004737, -7312468, 9353083, -3567418, 4360571, 7368970, 2182942, 3920044, 553773, 2985534, 9814880, 1802202, 7250660, 5725184, 3390524, 7874788, -2570987, -1153514, 8739638, -1005871, -4139644, -2759814, -8143193, 7621827, 6186598, 3838063, -9276848, -6982670, 1082847, -396967, -5856530, -1808552, -9146284, 7680997, 8840715, -5483047, -8193504, 64608, 3436511, -8610321, 2133714, -2990329, -5727489, 5316551, 4863833, -3510711, -5337319, -2544231, 7009735, 5723001, 4278706, -2036974, -9335623, 3500305, -4648114, 3311312, -3451347, 4075392, -3774186, 9698061, 5399363, 8204536, 2977733, -4330521, 3861831, -7374580, -270854, -3727723, 9882454, -306399, -7417015, -7655970, -6471239, -7072141, -2962468, 9421953, 6535667, -2939526, 6393871, -4271840, 1420974, 3165493, 1916771, 4132007, -8991318, 8582720, -1019086, 2655182, 7620922, -2525706, 7123118, 2331023, -1999961, 9126839, 3318000, 2215293, 7809186, 6340792, -2239857, -8351966, 4643923, 685366, -5293872, 9575380, -2682671, 777701, 5988158, 6919618, 5816966, -2172072, -5030171, -6112457, 1633871, -2321434, 7150064, 761305, 9725282, 2121778, -6951887, 2689551, 1434459, 8359225, -5138319, 8191980, -8356145, -6883222, -3808684, 7577344, 1180506, -2125774, 7927264, 9939888, 1311844, 5665115, -8624172, -6974391, 2285136, 605905, 1808480, -4301660, -8934243, -7992311, -4564829, -2398207, 5715930, 4643383, 9276530, -1612226, 4773270, 1893633, -2148845, 9831254, 4180911, -885472, 9223615, -9153681, -9959159, -3678541, -5090596, 2192587, 1688602, -3732601, -75638, 8125672, -6156937, -1324059, 6394307, -6312230, -5151437, -4256585, 8514571, 7261133, -1159000, 4355514, -2574208, 7402422, 7974901, 2660155, 1278331, -9903214, 4762197, -3179796, -348662, 4287072, 1188717, -8992537, -3653636, -7464660, -3247343, 6353901, -3439679, 2787945, -5141222, -5422180, -3155925, 6052755, 6817883, 4865975, -8099636, -1063544, 7467193, 4372114, -1687418, 6641969, 5025556, -3524196, 9069420, -2152601, 9021073, 4799046, -444596, 9826705, 1429960, -4552441, 1768110, 3058006, -860194, -9063378, 7356592, 4931131, 8830248, 6869595, -2717077, -7793801, 7289278, 7568343, 7175345, -3774115, 4008241, -2236407, 6389987, 9340677, -3015542, -1416978, 9164885, -8927860, 8828678, -7379318, -8114216, 9772954, 7974030, 5087319, 6652480, -4713946, 4038572, -4302827, -2783205, 6172698, -3300004, -6193525, 1157718, -4406590, 2395038, -2948625, -97589, -6052143, -6765915, 1758869, 8615008, 233094, -2381904, -3628691, -108392, -2285868, -7012642, -5793765, 7206251, 4400988, 986403, -4812048, 3359409, 4157042, -9997519, 2436325, -6708522, -6644073, -8513604, 3192202, -9724274, -770132, -7729757, 7672683, 6400217, -4201215, -25774, -2232448, -4677672, -3255928, 5464380, 5938789, 4439368, -4463349, -3997093, 3549940, -9495550, 6454604, 9716185, -440377, 4529010, 205822, -6111291, 9279012, 1150833, 7899778, 2037631, -6799595, -4282684, -2578020, -161245, 2179593, -7380945, -4591014, 3365886, 4074565, 9612150, 5840241, -2111611, -3891266, 2194086, 6495300, 170449, 2305678, -7059211, 5179869, 5980944, 3599145, -1447016, 7710434, 7144310, -9986598, 4051124, -167302, 7115920, 8379280, -6139639, -8465577, -9448585, -643201, -200569, 8596373, -839134, -9500993, 19960, -9546718, -1252204, -7363130, -2575256, 4403181, -2767295, -4022779, -4735881, 6396258, -8878212, 9682221, 5608801, 183258, -5546202, 9117318, 3589490, 5717553, -7070616, 1068376, -6525457, -5947256, -1750098, -3026859, -3543828, -6540009, -8952860, -8317763, 7599404, -1720172, -3060747, 1931383, -4209717, -4631638, 9277966, -6995866, -5346035, -9676453, -6881446, -8554600, 3414261, -1238280, -262342, -643663, -4136405, 2313259, 5849997, 7073785, 9431666, -127730, 1348656, 2373587, -7421969, -8319637, 5536747, -1684793, 7242225, 9498317, -3387169, 2794133, -9439429, -6334481, -1565068, -1666375, 9679300, -5659436, 6107047, -23007, 9554281, 1282215, -5446995, -3862704, -2702703, 8313188, -4233847, 9880587, -461524, 7245172, 7728889, -7962656, -1852302, 3895454, 6594438, -2303157, 8708005, 8947554, -4078974, -8016619, -2413493, -6605529, -4698368, -3415280, 636893, 2964171, -1366316, 7531049, -5048659, 6439238, 7821103, 468794, 3590865, 5781290, 9541449, -2352024, -4106523, 4913284, -1283978, -8335463, -17162, 4342039, 4158016, 1877626, -9547799, -4378550, -1395838, -8871158, -5662749, -3739973, -8984162, -1198585, -6159258, -4187005, 1911804, -6070376, 872117, -6775288, -49228, -5553539, -7056778, 1391446, -3955079, 8343401, 5586554, 750229, 5565584, -9458100, -2395101, 1510324, 4807969, -5834916, -1003543, 4569719, 2320972, 3187802, -1287788, 3412039, -8766466, 6353586, -9879912, -203866, 5299227, 2936208, 1313581, -8286631, 9599900, 5266321, -890900, -8045946, 7240458, -4239809, -4202004, 7175013, -9347725, 2866662, -585051, -9728732, 9614904, -5359575, 8719913, -612555, -3163111, 2172623, 5067886, -9155051, 3882947, 1583734, -514214, -2558253, 1219904, 9255940, -1387832, -3820384, -8487034, -8322182, 5297384, 8698296, 2773113, 4080592, -7114194, 1366862, 5474548, -68088, 8623094, 2909811, 4884195, 4882672, -6404206, -9255184, -1374199, 837514, 2578215, -5570719, -4666126, -4629355, 863426, -8749624, 256042, -3176549, -4341369, 9898827, 1953042, -6820730, -94655, 7847820, 6331080, 2656983, -4953437, -7029409, -7362240, 6890908, -8825759, 682385, -4607063, 3047543, 6948586, -7224160, -9207803, -4238324, -6176543, 4187524, 3109140, 1141146, -6819385, 636033, 7600632, 5732658, 647481, -229811, 487529, 8727514, 646898, 2026339, 2912393, -1811638, 8859747, -4315109, -7225612, -4489557, 3232882, -5474443, -2131860, 746000, 3863684, 5182595, -3204764, -4744494, 237344, -9589127, -521650, 9836914, -4946699, 8725014, -9842464, -6586844, -2562783, 8600582, -813651, 7959744, -7364871, -3107278, 1164742, -8178261, 9053024, 4768812, -7757583, -4099700, 2249649, -3212733, 3668492, -8986537, 1759315, 2433838, -1178214, 1723800, 5395987, -1429569, 6164782, -1836983, -149729, 8748882, 7865513, -3933355, 8207607, -6756410, -2772201, 7020226, -4477157, 9566343, -1439777, 6357101, 224928, -5501099, 9600781, 2086077, 7963417, 7870230, -2287153, -2908233, 2998059, 252539, -8029590, 745275, 9268197, 3433024, -8004088, -1664959, -4558643, 3762595, -2202101, -2675919, 7981587, -3464844, 9190796, 6940675, 7369755, -3173943, -4694854, 5824340, -1402730, -9903410, -6582358, 1677678, 2086762, 1917976, 8433562, 6430455, 6822929, -9712256, -4615478, -6728991, -934990, -3658073, -4355285, -182179, -9973336, 1983956, 6038185, -6184215, -1295363, 3814305, -6746982, -4419983, -3981214, -6002286, -5582995, -8055379, 9259165, -485200, 1058925, -2306810, 3057041, 103548, 7447631, -8979686, 2141454, 124354, 7284055, 1914955, -5892962, -9656639, 7391702, -9785463, 3152839, 7492894, 6452602, -2083583, 9375453, -1557789, -1019209, -6817984, 3597805, -9285561, -5131624, 2632659, 9287981, 2741974, -1585119, 1982, 4612321, -3700383, 1155012, 6085206, 5179326, 1540119, -3833108, -8748445, -3425844, -5516749, 4856792, -6542662, -628276, -2887504, 7555631, -9397745, -2414568, 3806920, -6026546, -8211811, 6980622, 6922149, 1982992, -3458423, -2054378, 7110988, 6804686, 8942050, -9984564, 9173485, -4643861, 3282199, 1805332, 9176745, 9472259, -4010680, -7993819, -810652, -927616, 593664, -6139926, 9482209, 5857881, 9655918, 3223143, -8730465, -1543106, -5684196, 4394925, 8806977, -1315860, 6768731, -7714500, -3534677, 6392136, 8924123, -9982369, 2468703, 1373441, -9418548, -7529953, 5613585, 2490306, -2826845, -2091527, -6442070, 5774324, -2246555, -7853040, 9629308, -26565, -9341683, 1189454, 2216521, -9981803, 1285212, -8833951, 2384487, -6595463, 4716388, -634957, -1554384, -5708726, 3680480, 5632932, -4098265, 4827736, 6936778, 4612269, -9454502, -7929155, -5506940, -1023973, 3279381, 7472910, -7035145, -7366905, 3181415, 9400354, 4047069, -562644, -2598830, 2639046, 7622361, -8589964, -4690788, -2294656, 4628981, -7443327, -1503284, 7555070, 2013926, 5406533, -5499021, 2906466, -7048947, 6248063, -9576604, -826784, -4682418, 5413096, 1710980, 1955906, 2419977, 9517873, -2784605, 9148810, 6399996, 5796284, 3893083, 8175795, -1032376, -9366288, 7220586, -3867135, 5805843, -537632, 3410928, -1852303, -743152, -2086311, 9991820, 493801, -9503103, -4609023, -8834807, 1911965, 12331, -1417577, 9800939, 2777326, -1938120, -9175066, 4665777, 8002560, -6548347, -1214209, 8987119, 2693822, 5316969, -5544117, 6376775, 4798387, -9501662, 1439842, -1974607, 2479610, 1645564, -5897583, 5335313, 8975920, 3535988, 5328306, -8732409, -467510, 8862300, 2107230, -2774455, -4148137, -9269555, -6726834, -4516743, -116946, 3192445, 2096769, -5993801, -9977683, -8695581, -5990945, -9707742, 8953280, 7365754, 6764724, 4641099, -3170856, -4929604, 2033143, 6672753, 317174, 3551418, -1654869, -4305842, -2265178, -5681601, -3067147, -1131379, 661192, 6377414, -3234801, -7031937, 5963310, -4600533, 4738290, 3023655, 4770429, 8962550, 273625, 264336, -7319569, 2483548, 9399272, 2267260, -8992739, -9105716, -6298269, 5203869, 79215, 2544577, 5623241, -1595223, -2313710, 3385698, 5169774, -3394666, 6827718, 2856381, -4746778, 644679, -6989314, 2226341, -1857079, 9991839, -3710396, 9857095, -7676688, -8185044, 3053995, -9216915, -2156718, -1683879, 8195020, 3437002, 6872439, -323158, -5856347, -5108234, -8121588, -5580060, -5115507, -9239481, -7075588, 9042056, -4796214, -2869379, 5850795, -5153090, -2694767, 4007952, -5177694, 7834886, -3171488, -9687915, 3397539, 1392301, -143382, -5035756, -8704548, -9747736, 1985019, 6084241, 5810042, -1297529, 5382327, 5085001, -8127616, -4374544, -2759543, 5699417, -6482595, 642890, 3468770, -8722546, 7678917, -3556626, -7506981, -7587514, -4938205, -6285416, 5754206, -6419822, -5846088, -9973594, 1873168, 7447824, -6393069, -2357407, -7872236, -4815155, 4288497, -9487520, 9372481, 8048084, -8871993, 1785900, -5831917, -8208405, 3886757, -9347984, 9819113, 7751747, -733065, 8988867, -2628218, 3278891, 7036978, 7838007, 9966188, -4256719, -4162838, 1908979, 9218867, 9296146, 4398076, 1400412, 9231948, -8642551, -2679997, 6226211, -4987215, -4928343, -5517204, -8620488, -2438362, -6015702, 9319411, -9578524, -1474470, -4686264, -4034120, -8067503, 4331191, 3236147, 733440, 9274682, 3788885, -9288846, -7283929, 5117474, -1824492, 7150621, -3561385, 4518442, -3689849, -8534369, -9209955, 9259666, 1802806, 6758311, -9303110, -9144421, 8869984, 8775779, 3757973, 520294, 2714632, -4858960, -8293797, 8817624, 8019284, 7114553, -6007141, 4639306, 9583970, 9573261, -6750284, -305197, 143808, 7384302, 9462960, 2058894, -8723478, -8083708, -7991325, 9396668, 6085175, -1113764, 6311964, 6456276, 7022124, 1879503, 4097196, -5666028, -7549078, 1234433, 9856306, -1532608, -6344637, -7288888, 7156254, -4962257, 5870454, 2478371, 2417658, -3623132, -3272919, 9997931, -3427807, 5661052, 6109979, 7481095, -3366256, 2064867, 3604234, -1968551, -7689875, 8928951, 7187720, 9801460, 5820974, -7964198, 5205610, -5740203, 6312287, 1320402, 7193697, -551090, 4135266, 1346482, -7223884, -4895311, -2520765, -6953839, 6614402, -8749783, -3151628, -2675769, 3235024, -9804568, -4859150, 2732978, -9334719, -3027472, -6488021, -5612231, 9050353, -9733729, 6635867, 4795315, -3305250, 5374081, 4979300, 5856613, -5572075, 2951566, 8812696, -2855673, 7993582, -8626677, 1723448, 1879206, 7185256, -9655080, -5395913, -6362540, -5136344, -7747550, 9735362, 3444139, 2297964, -7667194, 4070837, -2824305, 7073170, -2827524, 4476442, -4563844, 2432401, -4176547, -7399733, 7026265, 4162043, 3418997, 9352798, 5500861, 234400, 6073478, -5118371, 8795356, -4417851, 8331578, 6322925, 8742331, 4299102, 9300192, 4519147, 696122, -5766065, -3886862, -46950, -8064143, 8900806, -2984143, -888063, 919499, -4167615, 7199027, -5683724, 565343, -3685353, 8710563, -3997917, -7199832, 36255, 5658582, 6092836, 1278937, -6095046, -1773346, 263203, -6606618, 8008488, 3708374, -2566937
            }))); // -6845551 -6845550 -2845864 -2845863 -1852303 -1852302 -643201 -643200 4338772 4338773 6458841 6458842 8883985 8883986
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        // return an integer that represents the median of the array.
        // findMedian has the following parameter(s):
        // arr: an unsorted array of integers
        static int findMedian(int[] arr)
        {
            var sortedArrEnum = from n in arr orderby n ascending select n;
            var sortedArr = sortedArrEnum.ToArray<int>();
            return sortedArr[arr.Length / 2];
        }

        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(" ", findMedian(new int[] { 0, 1, 2, 4, 6, 5, 3 }))); // 3
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        // print the interim and final arrays, each on a new line.
        // insertionSort1 has the following parameter(s):
        // n: an integer, the size of arr
        // arr: an array of integers to sort
        static void insertionSort1(int n, int[] arr)
        {
            int pos = n - 1;
            int e = arr[pos];
            while ((pos > 0) && (e <= arr[pos - 1]))
            {
                arr[pos] = arr[pos - 1];
                pos--;
            }
            arr[pos] = e;
        }

        static void Main(string[] args)
        {
            //insertionSort1(5, new int[] { 2, 4, 6, 8, 3 }); // 2 4 6 8 8 ; 2 4 6 6 8 ; 2 4 4 6 8 ; 2 3 4 6 8
            insertionSort1(10, new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 1 }); // 2 3 4 5 6 7 8 9 10 10 ; 2 3 4 5 6 7 8 9 9 10 ; 2 3 4 5 6 7 8 8 9 10 ; 2 3 4 5 6 7 7 8 9 10 ; 2 3 4 5 6 6 7 8 9 10; 2 3 4 5 5 6 7 8 9 10; 2 3 4 4 5 6 7 8 9 10 ; 2 3 3 4 5 6 7 8 9 10 ; 2 2 3 4 5 6 7 8 9 10 ; 1 2 3 4 5 6 7 8 9 10
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        static void insertionSort1(int n, int[] arr, int pos)
        {
            int e = arr[pos];
            while ((pos > 0) && (e <= arr[pos - 1]))
            {
                arr[pos] = arr[pos - 1];
                pos--;
            }
            arr[pos] = e;
        }

        // print the array as space-separated integers on a separate line.
        // insertionSort2 has the following parameter(s):
        // n: an integer representing the length of the array
        // arr: an array of integers
        static void insertionSort2(int n, int[] arr)
        {
            for (int i = 1; i < n; i++)
            {
                insertionSort1(n, arr, i);
                Console.WriteLine(string.Join(" ", arr));
            }
        }

        static void Main(string[] args)
        {
            insertionSort2(7, new int[] { 3, 4, 7, 5, 6, 2, 1 }); // 3 4 7 5 6 2 1 ; 3 4 7 5 6 2 1 ; 3 4 5 7 6 2 1 ; 3 4 5 6 7 2 1 ; 2 3 4 5 6 7 1 ; 1 2 3 4 5 6 7
            insertionSort2(6, new int[] { 1, 4, 3, 5, 6, 2 }); // 1 4 3 5 6 2 ; 1 3 4 5 6 2 ; 1 3 4 5 6 2 ; 1 3 4 5 6 2 ; 1 2 3 4 5 6
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        public static void insertionSort(int[] A)
        {
            for (var i = 1; i < A.Length; i++)
            {
                var value = A[i];
                var j = i;
                while (j > 0 && value <= A[j - 1])
                {
                    A[j] = A[j - 1];
                    j--;
                }
                A[j] = value;
            }
            Console.WriteLine(string.Join(" ", A));
        }

        static void Main(string[] args)
        {
            insertionSort(new int[] { 7, 4, 3, 5, 6, 2 }); // 2 3 4 5 6 7
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        // The encoded message is obtained by displaying the characters in a column, inserting a space, 
        // and then displaying the next column and inserting a space, and so on.
        static string encryption(string s)
        {
            string cs = Regex.Replace(s, @"\s+", ""); // remove whitespace
            int len = cs.Length;
            int rows = (int)Math.Floor(Math.Sqrt(len));
            int columns = (int)Math.Ceiling(Math.Sqrt(len));
            if ((rows * columns) < len)
            {
                rows++;
            }
            string[] rowstrs = new string[rows];
            for (int j = 0, idx = 0; j < rows; j++, idx += columns)
            {
                int maxLength = cs.Length - idx;
                int length = (maxLength < columns) ? maxLength : columns;
                rowstrs[j] = cs.Substring(idx, length);
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (i < rowstrs[j].Length)
                    {
                        sb.Append(rowstrs[j][i]);
                    }
                }
                sb.Append(' ');
            }
            return sb.ToString().Trim();
        }

        static void Main(string[] args)
        {
            Console.WriteLine(encryption("have a nice day")); // hae and via ecy
            Console.WriteLine(encryption("feed the dog")); // fto ehg ee dd
            Console.WriteLine(encryption("chill out")); // clu hlt io
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        public static void testNumber(int n)
        {
            if (((n % 3) == 0) && ((n % 5) == 0))
            {
                Console.WriteLine("FizzBuzz");
            }
            else if ((n % 3) == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if ((n % 5) == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine($"{n}");
            }

        }

        public static void fizzBuzz(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                testNumber(i);
            }
        }

        static void Main(string[] args)
        {
            fizzBuzz(15);
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        public static void customSort(List<int> arr)
        {
            var counts = new Dictionary<int, int>();
            foreach (int n in arr)
            {
                if (counts.ContainsKey(n))
                    counts[n]++;
                else
                    counts[n] = 1;
            }
            var sortedCounts = from count in counts orderby count.Value, count.Key ascending select count;
            foreach (var count in sortedCounts)
            {
                for (int n = 0; n < count.Value; n++)
                {
                    Console.WriteLine(count.Key);
                }
            }
        }

        static void Main(string[] args)
        {
            customSort(new int[] { 3, 1, 2, 2, 4 }.ToList());
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        public static int nbrClosedPaths(int n)
        {
            switch (n)
            {
                case 0:
                case 4:
                case 6:
                case 9:
                    return 1;
                case 8:
                    return 2;
                default:
                    return 0;
            }
        }

        public static int closedPaths(int number)
        {
            int totalNbrClosedPaths = 0;
            do
            {
                int n = number % 10;
                totalNbrClosedPaths += nbrClosedPaths(n);
                number /= 10;
                if (number == 0)
                {
                    break;
                }
            }
            while (true);
            return totalNbrClosedPaths;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(closedPaths(630));
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        public class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;

            public SinglyLinkedListNode(int nodeData)
            {
                this.data = nodeData;
                this.next = null;
            }
        }

        public class SinglyLinkedList
        {
            public SinglyLinkedListNode head;
            public SinglyLinkedListNode tail;

            public SinglyLinkedList()
            {
                this.head = null;
                this.tail = null;
            }

            public void InsertNode(int nodeData)
            {
                SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

                if (this.head == null)
                {
                    this.head = node;
                }
                else
                {
                    this.tail.next = node;
                }

                this.tail = node;
            }
        }

        public static SinglyLinkedListNode deleteOdd(SinglyLinkedListNode listHead)
        {
            SinglyLinkedListNode newList = null;
            SinglyLinkedListNode curNode = null;

            for (SinglyLinkedListNode node = listHead; node != null; node = node.next)
            {
                if ((node.data % 2) == 0)
                {
                    SinglyLinkedListNode newNode = new SinglyLinkedListNode(node.data);

                    if (newList == null)
                    {
                        newList = newNode;
                    }
                    else
                    {
                        curNode.next = newNode;
                    }
                    curNode = newNode;
                }
            }
            return newList;
        }

        static void Main(string[] args)
        {
            SinglyLinkedList listHead = new SinglyLinkedList();

            listHead.InsertNode(2);
            listHead.InsertNode(1);
            listHead.InsertNode(3);
            listHead.InsertNode(4);
            listHead.InsertNode(6);

            SinglyLinkedListNode result = deleteOdd(listHead.head);
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        private static int calculateHourGlassSum(int[][] arr, int i, int j)
        {
            int sum = 0;
            int jMax = j + 3;
            for (int n = j; n < jMax; n++)
            {
                sum += arr[i][n];
            }
            i++;
            sum += arr[i][j + 1];
            i++;
            for (int n = j; n < jMax; n++)
            {
                sum += arr[i][n];
            }
            return sum;
        }

        static int hourglassSum(int[][] arr)
        {
            int maxSum = int.MinValue;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int sum = calculateHourGlassSum(arr, i, j);
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                    }
                }
            }
            return maxSum;
        }

        static void Main(string[] args)
        {
            int[][] arr = new int[6][];
            arr[0] = new int[] { 1, 1, 1, 0, 0, 0 };
            arr[1] = new int[] { 0, 1, 0, 0, 0, 0 };
            arr[2] = new int[] { 1, 1, 1, 0, 0, 0 };
            arr[3] = new int[] { 0, 0, 2, 4, 4, 0 };
            arr[4] = new int[] { 0, 0, 0, 2, 0, 0 };
            arr[5] = new int[] { 0, 0, 1, 2, 4, 0 };
            int maxSum = hourglassSum(arr);
            Console.WriteLine(maxSum);
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        static int[] matchingStrings(string[] strings, string[] queries)
        {
            int[] occurances = new int[queries.Length];
            for (int n = 0; n < queries.Length; n++)
            {
                int occurance = 0;
                for (int m = 0; m < strings.Length; m++)
                {
                    if (queries[n].Equals(strings[m]))
                    {
                        occurance++;
                    }
                }
                occurances[n] = occurance;
            }
            return occurances;
        }

        static void Main(string[] args)
        {
            string[] strings = new string[] { "aba", "baba", "aba", "xzxb" };
            string[] queries = new string[] { "aba", "xzxb", "ab" };
            int[] occurances = matchingStrings(strings, queries);
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        private class Node
        {
            public Node(int _index)
            {
                Index = _index;
                Left = null;
                Right = null;
            }

            public int Index { get;  }
            public int Depth { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        private static void traverseTree(Node node, List<int> indexes)
        {
            if (node.Left != null)
            {
                traverseTree(node.Left, indexes);
            }
            indexes.Add(node.Index);
            if (node.Right != null)
            {
                traverseTree(node.Right, indexes);
            }
        }

        private static int[] traverseTree(Node root)
        {
            List<int> indexes = new List<int>();
            traverseTree(root, indexes);
            return indexes.ToArray();
        }

        private static void swapNodes(Node node, int h)
        {
            if (node == null)
            {
                return;
            }
            if (node.Depth == h)
            {
                Node temp = node.Left;
                node.Left = node.Right;
                node.Right = temp;
                return;
            }
            swapNodes(node.Left, h);
            swapNodes(node.Right, h);
        }

        private static int[] swapNodes(Node root, int k, int maxDepth)
        {
            int m = 1;
            int h = k;
            while (h <= maxDepth)
            {
                swapNodes(root, h);
                h = (++m * k);
            }

            return traverseTree(root);
        }

        private static void setDepth(Node node, int depth, ref int maxDepth)
        {
            if (node == null)
            {
                return;
            }
            if (depth > maxDepth)
            {
                maxDepth = depth;
            }
            node.Depth = depth;
            setDepth(node.Left, depth + 1, ref maxDepth);
            setDepth(node.Right, depth + 1, ref maxDepth);
        }

        static Node buildTree(int[][] indexes)
        {
            Node[] nodes = new Node[indexes.Length];
            for (int i = 0, index = 1; i < indexes.Length; i++, index++)
            {
                nodes[i] = new Node(index);
            }

            for (int i = 0; i < indexes.Length; i++)
            {
                nodes[i].Left = (indexes[i][0] == -1) ? null : nodes[indexes[i][0] - 1];
                nodes[i].Right = (indexes[i][1] == -1) ? null : nodes[indexes[i][1] - 1];
            }

            return (nodes.Length == 0) ? null : nodes[0];
        }

        static int[][] swapNodes(int[][] indexes, int[] queries)
        {
            int[][] traversals = new int[queries.Length][];

            Node root = buildTree(indexes);
            int maxDepth = 0;
            setDepth(root, 1, ref maxDepth);

            for (int i = 0; i < queries.Length; i++)
            {
                traversals[i] = swapNodes(root, queries[i], maxDepth);
            }

            return traversals;
        }

        static void Main(string[] args)
        {
            /*
            int[][] indexes = new int[3][];
            indexes[0] = new int[] { 2, 3 };
            indexes[1] = new int[] { -1, -1 };
            indexes[2] = new int[] { -1, -1 };
            int[] queries = new int[2] { 1, 1 };
            */
            /*
            int[][] indexes = new int[5][];
            indexes[0] = new int[] { 2, 3 };
            indexes[1] = new int[] { -1, 4 };
            indexes[2] = new int[] { -1, 5 };
            indexes[3] = new int[] { -1, -1 };
            indexes[4] = new int[] { -1, -1 };
            int[] queries = new int[1] { 2 };
            */
            int[][] indexes = new int[11][];
            indexes[0] = new int[] { 2, 3 };
            indexes[1] = new int[] { 4, -1 };
            indexes[2] = new int[] { 5, -1 };
            indexes[3] = new int[] { 6, -1 };
            indexes[4] = new int[] { 7, 8 };
            indexes[5] = new int[] { -1, 9 };
            indexes[6] = new int[] { -1, -1 };
            indexes[7] = new int[] { 10, 11 };
            indexes[8] = new int[] { -1, -1 };
            indexes[9] = new int[] { -1, -1 };
            indexes[10] = new int[] { -1, -1 };
            int[] queries = new int[2] { 2, 4 };

            int[][] traversals = swapNodes(indexes, queries);
            for (int i = 0; i < traversals.Length; i++)
            {
                printTraversal(traversals[i]);
            }
        }

        private static void printTraversal(int[] traversal)
        {
            foreach (int n in traversal)
            {
                Console.Write($"{n}, ");
            }
            Console.WriteLine();
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
    class Program
    {
        static char endChar(char ch0)
        {
            switch(ch0)
            {
                case '(':
                    return ')';
                case '[':
                    return ']';
                case '{':
                    return '}';
                default:
                    return ' ';
            }
        }

        static bool isEnd(char ch0, char ch1)
        {
            return (ch1 == endChar(ch0));
        }

        static bool isStart(char ch)
        {
            return ((ch == '(') || (ch == '{') || (ch == '['));
        }

        static List<string> findSubstrings(string s)
        {
            List<string> strs = new List<string>();
            int i = 0;
            while (i < s.Length)
            {
                int iStart = i;
                char s0 = s[i];
                char s1 = endChar(s0);
                int count = 1;
                while ((++i < s.Length) && (count > 0))
                {
                    if (s[i] == s0)
                    {
                        count++;
                    }
                    else if (s[i] == s1)
                    {
                        count--;
                    }
                }
                int len = i - iStart;
                string str = s.Substring(iStart, len);
                strs.Add(str);
            }
            return strs;
        }

        static bool isStrBalanced(string s)
        {
            if (s.Length == 0)
            {
                return true;
            }

            bool isBalanced = true;
            List<string> strs = findSubstrings(s);
            foreach (string str in strs)
            {
                if ((str.Length == 1) || !isStart(str[0]) || (!isEnd(str[0], str[str.Length - 1])) || !isStrBalanced(str.Substring(1, str.Length - 2)))
                {
                    isBalanced = false;
                    break;
                }
            }

            return isBalanced;
        }

        static string isBalanced(string s)
        {
            return isStrBalanced(s) ? "YES" : "NO";
        }

        static void Main(string[] args)
        {
            Console.WriteLine(isBalanced("{}()[]"));
            Console.WriteLine(isBalanced("{}))[]"));
            Console.WriteLine(isBalanced("{(([])]])[]}"));
            Console.WriteLine(isBalanced("{(([])[])[]}"));
            Console.WriteLine(isBalanced("{(([])[])[]]}"));
            Console.WriteLine(isBalanced("{(([])[])[]}[]"));
            Console.WriteLine(isBalanced("()[{}()]([[][]()[[]]]{()})([]()){[]{}}{{}}{}(){([[{}([]{})]])}"));
            Console.WriteLine(isBalanced("{][({(}]][[[{}]][[[())}[)(]([[[)][[))[}[]][()}))](]){}}})}[{]{}{((}]}{{)[{[){{)[]]}))]()]})))["));
            Console.WriteLine(isBalanced("[)](][[([]))[)"));
            Console.WriteLine(isBalanced("]}]){[{{){"));
            Console.WriteLine(isBalanced("{[(}{)]]){(}}(][{{)]{[(((}{}{)}[({[}[}((}{()}[]})]}]]))((]][[{{}[(}})[){()}}{(}{{({{}[[]})]{((]{[){["));
            Console.WriteLine(isBalanced("()}}[(}])][{]{()([}[}{}[{[]{]](]][[))(()[}(}{[{}[[]([{](]{}{[){()[{[{}}{[{()(()({}([[}[}[{(]})"));
            Console.WriteLine(isBalanced("){[])[](){[)}[)]}]]){](]()]({{)(]])(]{(}(}{)}])){[{}((){[({(()[[}](]})]}({)}{)]{{{"));
            Console.WriteLine(isBalanced("[(})])}{}}]{({[]]]))]})]"));
            Console.WriteLine(isBalanced("[{"));
            Console.WriteLine(isBalanced("{}([{()[]{{}}}])({})"));
            Console.WriteLine(isBalanced("{({}{[({({})([[]])}({}))({})]})}"));
            Console.WriteLine(isBalanced("()[]"));
            Console.WriteLine(isBalanced("{)[])}]){){]}[(({[)[{{[((]{()[]}][([(]}{](])()(}{(]}{})[)))[](){({)][}()(("));
            Console.WriteLine(isBalanced("[][(([{}])){}]{}[()]{([[{[()]({}[])()()}[{}][]]])}"));
            Console.WriteLine(isBalanced("(}]}"));
            Console.WriteLine(isBalanced("(([{()}]))[({[{}{}[]]{}})]{((){}{()}){{}}}{}{{[{[][]([])}[()({}())()({[]}{{[[]]([])}})()]]}}"));
            Console.WriteLine(isBalanced("[(([){[](}){){]]}{}([](([[)}[)})[(()[]){})}}]][({[}])}{(({}}{{{{])({]]}[[{{(}}][{)([)]}}"));
            Console.WriteLine(isBalanced("()()[()([{[()][]{}(){()({[]}[(((){(())}))]()){}}}])]"));
            Console.WriteLine(isBalanced("({)}]}[}]{({))}{)]()(](])})][(]{}{({{}[]{][)){}{}))]()}((][{]{]{][{}[)}}{)()][{[{{[["));
            Console.WriteLine(isBalanced(")}(()[])(}]{{{}[)([})]()}()]}(][}{){}}})}({](){([()({{(){{"));
            Console.WriteLine(isBalanced("}([]]][[){}}[[)}[(}(}]{(}[{}][{}](}]}))]{][[}(({(]}[]{[{){{(}}[){[][{[]{[}}[)]}}]{}}(}"));
        }
    }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        static bool isPrime(int n)
        {
            if (n == 1) return false;
            if (n == 2) return true;

            if (n % 2 == 0) return false;

            for (int i = 2; i < n; i++)
            {
                if (n % i == 0) return false;
            }

            return true;
        }

        static int[] firstNPrimeNumbers(int N)
        {
            int[] primes = new int[N];

            int i = 2;
            int n = 0;
            while (true)
            {
                if (isPrime(i))
                {
                    primes[n++] = i;
                    if (n == N)
                    {
                        break;
                    }
                }
                i++;
            }

            return primes;
        }

        static int[] waiter(int[] number, int Q)
        {
            int[] primes = firstNPrimeNumbers(Q);
            int[][] A = new int[Q + 1][];
            int[] Acount = new int[Q + 1];
            int[][] B = new int[Q + 1][];
            int[] Bcount = new int[Q + 1];
            int[] result = new int[number.Length];

            for (int i = 0; i <= Q; i++)
            {
                A[i] = new int[number.Length];
                Acount[i] = 0;
                B[i] = new int[number.Length];
                Bcount[i] = 0;
            }
            for (int n = 0; n < number.Length; n++)
            {
                A[0][n] = number[n];
            }
            Acount[0] = number.Length;

            for (int i = 1; i <= Q; i++)
            {
                for (int n = Acount[i - 1] - 1; n >= 0; n--)
                {
                    if ((A[i - 1][n] % primes[i - 1]) == 0)
                    {
                        B[i][Bcount[i]++] = A[i - 1][n];
                    }
                    else
                    {
                        A[i][Acount[i]++] = A[i - 1][n];
                    }
                    A[i - 1][n] = 0;
                    Acount[i - 1]--;
                }
            }

            int j = 0;
            for (int i = 1; i <= Q; i++)
            {
                for (int n = Bcount[i] - 1; n >= 0; n--)
                {
                    result[j++] = B[i][n];
                }
            }
            for (int n = Acount[Q] - 1; n >= 0; n--)
            {
                result[j++] = A[Q][n];
            }

            return result;
        }

        static void Main(string[] args)
        {
            //Console.WriteLine(string.Join(" ", waiter(new int[] { 3, 4, 7, 6, 5 }, 1))); // 4, 6, 3, 7, 5
            //Console.WriteLine(string.Join(" ", waiter(new int[] { 3, 3, 4, 4, 9 }, 2))); // 4, 4, 9, 3, 3
            Console.WriteLine(string.Join(" ", waiter(new int[] { 7834, 1901, 9623, 9866, 4875, 5783, 9201, 6440, 1664, 2270, 9492, 4424, 9118, 913, 5695, 9321, 6104, 2387, 3526, 6697, 7564, 7281, 6924, 2503, 1562, 6328, 8693, 8268, 5561, 7158, 6551, 9378, 9794, 9946, 8540, 8961, 6801, 9272, 6081, 3977, 3950, 5160, 9792, 8037, 6414, 6773, 9210, 7737, 872, 1199, 3576, 1882, 522, 2341, 7777, 178, 2086, 6318, 6948, 2765, 4742, 6302, 1880, 7368, 5409, 3864, 2931, 7321, 3898, 443, 2695, 2965, 1105, 907, 5036, 7084, 1159, 9395, 6750, 3257, 4312, 9712, 2635, 1241, 1402, 1522, 8720, 8663, 1917, 4508, 9268, 3482, 5276, 9533, 1563, 5669, 8570, 3628, 9579, 3357, 8243, 2523, 7621, 5218, 1581, 2216, 1396, 1732, 3180, 2490, 4719, 8925, 3251, 8540, 6790, 263, 137, 4387, 4781, 5141, 2618, 8660, 6608, 5851, 6567, 6613, 5346, 6357, 377, 8473, 8023, 7908, 2745, 4168, 6264, 2950, 1969, 35, 9022, 2234, 8666, 5038, 8873, 4417, 8465, 930, 6551, 9255, 4744, 7822, 7085, 3817, 8239, 7720, 6850, 7492, 1898, 4399, 2700, 5757, 2005, 7286, 6316, 1035, 6323, 2935, 8923, 8720, 5939, 3583, 6126, 3513, 9568, 1702, 1181, 5421, 5912, 8114, 2027, 3800, 6751, 3049, 8297, 9438, 8517, 725, 7822, 8832, 7204, 349, 7100, 2769, 8388, 2809, 3933, 9000, 3077, 6298, 7817, 2659, 5470, 2796, 2056, 3846, 3511, 2576, 2207, 224, 8376, 7148, 1120, 8398, 9425, 1657, 9141, 8281, 8323, 1245, 893, 4291, 4725, 1218, 2023, 6575, 1300, 52, 9073, 4687, 4952, 7778, 8319, 2777, 2594, 4584, 1363, 8125, 9209, 4229, 8029, 5982, 2654, 857, 3195, 8733, 5091, 954, 176, 3444, 127, 4771, 6322, 6246, 4886, 3047, 9696, 7362, 9617, 7206, 1012, 7853, 1049, 2095, 8413, 2773, 534, 8478, 5660, 1846, 7760, 489, 8668, 8806, 1603, 7768, 4265, 4500, 3758, 5227, 7317, 7832, 7003, 4758, 4213, 9350, 2372, 6059, 8613, 737, 5462, 6768, 4142, 8341, 354, 9991, 4047, 744, 9744, 4735, 9193, 8413, 1875, 8267, 635, 5484, 5459, 5652, 8197, 8870, 9484, 1788, 65, 1916, 5205, 5106, 9436, 9717, 9271, 4200, 8615, 6762, 3090, 483, 6812, 2811, 3772, 4928, 7202, 1089, 9542, 6592, 4171, 4034, 9276, 7269, 8885, 7207, 1244, 6061, 9725, 1674, 5010, 8008, 4320, 6555, 3442, 5010, 5899, 51, 1991, 6910, 6036, 7094, 4672, 1416, 2473, 6551, 465, 456, 2043, 4319, 2446, 3615, 3143, 863, 2321, 4610, 4260, 9066, 8708, 7988, 1850, 3838, 5226, 8595, 2900, 2029, 7599, 768, 7710, 4298, 6886, 2457, 5161, 2292, 6581, 4255, 2677, 6301, 51, 771, 7043, 2331, 1184, 7608, 9299, 166, 5187, 5627, 824, 2189, 5124, 8948, 8902, 6199, 6654, 2508, 4155, 1608, 7096, 7546, 205, 5739, 7561, 228, 7352, 6804, 3724, 3307, 7256, 5298, 4983, 4734, 2574, 8171, 4944, 4725, 1992, 1012, 8947, 6720, 5631, 1943, 6979, 7090, 5360, 5182, 1534, 2773, 3252, 2271, 9844, 1222, 8641, 8185, 8784, 2257, 9594, 7140, 1084, 4181, 4642, 6250, 7699, 9714, 6155, 5869, 5912, 8220, 3596, 1057, 9135, 9491, 1155, 2170, 2507, 1191, 627, 9497, 385, 4783, 4960, 628, 3315, 2796, 2000, 6268, 7582, 3618, 5457, 2919, 7273, 3218, 6515, 4720, 5518, 2248, 1456, 2420, 4072, 2354, 1340, 7882, 7727, 3599, 3735, 3204, 2213, 5087, 851, 3812, 868, 2948, 7417, 123, 2785, 8029, 6739, 71, 7882, 4174, 8100, 1924, 3446, 7940, 8835, 4164, 1993, 933, 7546, 9004, 229, 9798, 6261, 4336, 5907, 5640, 9964, 4259, 1055, 5995, 3912, 4086, 1763, 1821, 6630, 1912, 9225, 4369, 5180, 5119, 1648, 245, 2569, 4032, 6733, 8753, 4089, 1821, 5199, 8356, 4913, 1725, 3142, 6622, 4247, 6353, 2235, 5311, 6821, 4776, 5315, 438, 5653, 3604, 2893, 7017, 2131, 9576, 4169, 4034, 8679, 2054, 3199, 2866, 1442, 732, 9696, 6856, 8546, 1357, 9009, 6791, 2087, 3654, 7395, 4765, 1987, 3671, 160, 9388, 4824, 4075, 1100, 1427, 7070, 6772, 392, 2504, 5985, 3283, 6783, 5686, 7928, 3698, 8560, 4436, 2431, 3628, 451, 1356, 97, 4410, 1031, 4997, 5553, 2254, 8518, 9826, 5114, 6674, 6164, 7722, 5316, 8357, 2975, 5749, 4641, 6547, 1646, 5979, 2230, 7676, 52, 7072, 2847, 5223, 4689, 6425, 6502, 8415, 357, 7181, 1659, 7840, 6320, 7270, 3924, 1629, 4149, 625, 2649, 4366, 4026, 9335, 7743, 477, 3330, 2968, 4973, 1511, 6079, 3222, 5953, 9003, 5554, 5272, 7118, 845, 8606, 2546, 6783, 4055, 7563, 6119, 3269, 7158, 6160, 6682, 1471, 2799, 1076, 9291, 9518, 7123, 6166, 2874, 1709, 8463, 853, 8997, 9799, 6665, 3025, 5299, 7743, 6118, 6948, 7802, 7828, 4279, 6455, 2417, 3416, 5255, 4764, 4752, 4789, 9479, 9003, 2322, 1671, 2696, 7800, 5951, 5396, 6026, 7652, 2963, 1298, 3298, 3123, 8418, 2351, 6740, 4733, 9500, 5925, 6589, 8135, 7322, 1442, 817, 5120, 8391, 4878, 3557, 5456, 1614, 7911, 5296, 1471, 6882, 8073, 3471, 9657, 3360, 7684, 2035, 6190, 7723, 2521, 2116, 5902, 4169, 6534, 4907, 8222, 7795, 3887, 7296, 4295, 3208, 6158, 7052, 5303, 51, 8078, 4365, 1883, 5943, 6415, 5010, 332, 5038, 4287, 252, 6610, 5930, 9899, 4474, 3194, 3947, 8811, 4183, 230, 8260, 7035, 185, 2191, 5476, 3381, 7595, 1183, 4934, 8496, 6104, 8074, 6293, 1525, 8659, 2522, 7949, 2056, 3858, 4651, 2037, 2041, 2982, 1583, 1968, 8078, 4163, 4157, 4112, 3521, 7495, 4509, 5026, 1784, 7606, 1591, 3138, 8291, 6171, 9004, 1419, 9344, 9116, 7082, 8458, 4479, 1237, 810, 5442, 2764, 8618, 2386, 4188, 1043, 3605, 1639, 6507, 6102, 6164, 6619, 3001, 6131, 3095, 3308, 8008, 8905, 5022, 5546, 2520, 6269, 3696, 6145, 8173, 8872, 4304, 6546, 1814, 8275, 4335, 8841, 6986, 2092, 336, 4516, 5142, 9819, 8542, 8390, 7599, 2149, 8223, 1388, 2193, 8308, 5691, 135, 5696, 7005, 5219, 6287, 9103, 6173, 4408, 2547, 5226, 9539, 9449, 27, 3264, 9108, 5097, 4237, 8848, 5151, 5356, 9062, 4448, 729, 4633, 8489, 2360, 446, 4048, 5056, 4851, 262, 3595, 789, 1049, 2121, 1763, 839, 4424, 6176, 1672, 4735, 6567, 9277, 2262, 3205, 9884, 7327, 6770, 9454, 6841, 9452, 2096, 985, 4764, 537, 2601, 3198, 4863, 6206, 8485, 9792, 5551, 7751, 8066, 1837, 5013, 5455, 852, 5927, 4176, 4979, 4834, 3115, 7469, 4199, 290, 8146, 9807, 5074, 5579, 5359, 830, 2875, 7099, 2938, 8238, 6741, 1568, 9836, 7296, 4977, 1996, 4206, 2897, 6231, 5261, 7325, 6273, 6547, 8469, 2370, 9269, 1891, 8786, 3530, 2132, 6767, 8727, 9659, 3585, 1905, 9288, 7057, 8266, 8863, 5830, 9123, 4072, 7478, 4733, 9450, 4735, 5311, 8855, 2211, 41, 93, 2619, 4249, 3671, 1875, 8582, 1069, 1000, 9197, 7025, 1371, 2280, 1506, 7963, 3244, 690, 2092, 5018, 9915, 8156, 6007, 1106, 1205, 305, 46, 2819, 1262, 6788, 5211, 6652, 6173, 4000, 9444, 1767, 6115, 6607, 3100, 1146, 1015, 9553, 7703, 8151, 9090, 6641, 3064, 8278, 5530, 6629, 2115, 2062, 6464, 2962, 2468, 6619, 9045, 7711, 8833, 6814, 9328, 4598, 3161, 8802, 1328, 9753, 4943, 6021, 3007, 1295, 7739, 8793, 2563, 1585, 2123, 6631, 4511, 918, 2056, 2426, 8956, 5101, 6203, 1504, 7851, 5481, 5142, 1694, 190, 850, 9079, 4832, 9285, 2648, 8120, 7261, 1212, 8026, 80, 650, 7728, 2471, 7789, 3718, 466, 7627, 1662, 5598, 7599, 9327, 7809, 6055, 8706, 9251, 3297, 6036, 2666, 8830, 6524, 981, 3153, 6894, 833, 5134, 1250, 1025, 8611, 6951, 1942, 6996, 6219, 5913, 8041, 7220, 1988, 652, 7627, 6638, 5075, 9793, 9424, 2954, 7435, 710, 4937, 8475, 2727, 8810, 6553, 9951, 6074, 4222, 630, 532, 8068, 3900, 2739, 7587, 1016, 4296, 2061, 8678, 7120, 9105, 3844, 7119, 9684, 8877, 6518, 2387, 5668, 4493, 1845, 7012, 2567, 4689, 8581, 2113, 7220, 130, 6701, 2911, 2929, 9062, 8018, 659, 8646, 178, 5611, 6446, 1626, 7399, 9082, 1088, 8934, 3443, 1717, 4877, 72, 4754, 3728, 3968, 5629, 6898, 5524, 9700, 1947, 2761, 7847, 7813, 1928, 1489, 4636, 3978, 924, 6573, 9150, 2039, 8796, 5440, 3867, 1618, 630, 8765, 3032, 7152, 7558, 1951, 70, 3076, 4221, 8261, 7564, 6846, 7845, 8696, 1250, 3282, 9758, 9928, 5037, 3035, 4236, 8675, 5785, 788, 1004, 6120, 7657, 7817, 664, 8443, 7585, 9842, 722, 2683, 7986, 8871, 721, 5488, 6571, 4385, 2912, 1652, 2653, 9192, 7579, 9405, 156, 2959, 31, 3536, 9674, 5921, 8490, 6823, 2062, 8918, 6752, 8297, 6406, 2952, 9813, 8621, 127, 2942, 1059, 6039, 3340, 5944, 7899, 7159, 2065, 2463, 6703, 8422, 3979, 1900, 4402, 9586, 884, 6203, 5812, 5940, 5839, 3120, 2283, 2168, 7422, 4172, 4615, 9834, 2547, 5741, 2660, 8341, 5973, 4778, 845, 7978, 7890, 6370, 6960, 5495, 9122, 8646, 9181, 2872, 7691, 6001, 5280, 4577, 248, 9273, 2363, 2467, 4451, 4447, 302, 6820, 5022, 2122, 1840, 8908, 4896, 9096, 6439, 5171, 310, 951, 3711, 965, 3713, 8118, 7822, 5950, 3345, 8920, 1375, 7180, 2713, 8469, 4842, 6772, 8918, 2979, 3089, 5504, 8670, 8687, 828, 1347, 6439, 3088, 6161, 3812, 5221, 2693, 2419, 3821, 9592, 6059, 860, 475, 8017, 9683, 1459, 5394, 5136, 9342, 1464, 5940, 7305, 1119, 1008, 5639, 4639, 2369, 9085, 9887, 379, 8193, 1684, 7277, 3583, 5041, 49, 8062, 7625, 6880, 9727, 6178, 9008, 6206, 1816, 2021, 1071, 2336, 1616, 9857, 3677, 9754, 2757, 5390, 2411, 3276, 3996, 6530, 4969, 9196, 2983, 1969, 795, 9707, 424, 7782, 445, 1914, 7625, 2299, 1864, 1598, 6647, 5443, 885, 1917, 7615, 8865, 1592, 6285, 2663, 5105, 3695, 4255, 6795, 8693, 5975, 4595, 5195, 4364, 9483, 3535, 1107, 2053, 7788, 1994, 6999, 9015, 8666, 3314, 1870, 6042, 7024, 3760, 2098, 2773, 3708, 9401, 2763, 4835, 8644, 4930, 9093, 8274, 4155, 4432, 1569, 7820, 3057, 7204, 8673, 2924, 1643, 6359, 4272, 4521, 4142, 3980, 6165, 1862, 7910, 6018, 1478, 861, 2868, 2274, 1774, 6949, 975, 7764, 6350, 4, 2410, 2112, 6467, 6172, 7047, 6243, 7279, 4153, 3866, 334, 4395, 410, 7815, 1648, 7949, 4055, 5733, 6378, 7737, 5167, 8481, 7362, 4063, 2887, 5627, 8000, 23, 4914, 4577, 7116, 9648, 2206, 3972, 5069, 1206, 369, 6684, 1022, 8292, 969, 5503, 363, 4117, 8773, 8790, 7475, 7848, 8604, 8741, 4961, 6427, 2572, 1179, 7456, 6111, 1133, 9771, 8338, 6442, 7773, 8884, 7631, 1005, 324, 8520, 7151, 6785, 132, 5159, 226, 4634, 7493, 4137, 2152, 3644, 6094, 6639, 9990, 7447, 3901, 5931, 8747, 8621, 4575, 4366, 5310, 3344, 644, 9416, 8866, 3720, 134, 6435, 5352, 8411, 8142, 7885, 2826, 6066, 6670, 7388, 5888, 6249, 2907, 4769, 2070, 2334, 2600, 3272, 3929, 778, 2954, 1692, 3539, 3196, 2774, 9097, 5647, 671, 1899, 1747, 2384, 3189, 2756, 4164, 4672, 5544, 5365, 6284, 8982, 1063, 3531, 55, 2887, 8663, 7401, 7816, 6643, 9124, 2364, 7950, 7843, 8524, 8105, 8201, 5562, 3862, 8291, 4746, 2110, 2078, 4105, 7683, 518, 2789, 220, 4277, 7054, 6994, 3167, 9766, 6523, 7744, 7963, 9633, 8508, 7470, 3512, 764, 583, 5060, 2041, 3543, 2895, 4795, 7875, 5402, 2417, 8589, 3190, 526, 7150, 5054, 7591, 6040, 4756, 7102, 3530, 183, 7719, 709, 142, 2321, 4676, 8362, 132, 1747, 5766, 9449, 3357, 922, 189, 3595, 1334, 3478, 4820, 4065, 2479, 4018, 2876, 2724, 4741, 6663, 7170, 8268, 5127, 5572, 4865, 4815, 6230, 8839, 9471, 7959, 4397, 2900, 2982, 7096, 4286, 8369, 1195, 4527, 5410, 6753, 7134, 1887, 3984, 5269, 1648, 5487, 7663, 4636, 6530, 4746, 1354, 2890, 6557, 7384, 9815, 1675, 1134, 4938, 5905, 7574, 7917, 6041, 9427, 4894, 1442, 6285, 9481, 6569, 4925, 393, 8793, 6465, 3249, 6675, 2003, 6381, 3329, 7949, 6190, 5411, 2978, 2614, 1539, 3019, 5705, 8248, 3796, 1134, 8933, 510, 7164, 7471, 8348, 1933, 4390, 6252, 5020, 9665, 913, 9208, 7142, 1110, 9021, 1043, 6267, 4837, 4739, 4447, 1391, 9936, 9946, 8486, 9008, 6501, 6611, 730, 3348, 1395, 6510, 3466, 4219, 9530, 5338, 758, 1013, 6150, 2634, 7463, 4608, 7142, 9310, 2305, 1804, 1186, 7907, 7207, 3726, 7079, 7357, 6173, 9159, 7911, 9264, 8193, 5326, 873, 5865, 7024, 7534, 2734, 9873, 4522, 7841, 8894, 2889, 9557, 8653, 5672, 4700, 8864, 7640, 9262, 9214, 9733, 2799, 650, 8237, 7818, 9254, 6514, 5718, 3486, 6305, 6560, 6586, 3283, 6395, 17, 3644, 9992, 4463, 8937, 8758, 692, 7589, 5708, 7502, 1162, 8066, 2062, 9802, 4164, 7426, 2965, 9496, 8327, 6454, 4762, 2886, 3682, 2413, 6145, 6477, 7030, 1811, 3833, 9489, 5362, 6241, 4251, 7641, 7928, 7734, 4216, 5014, 1948, 3084, 8021, 9385, 8871, 1603, 2043, 3941, 7266, 1826, 5220, 207, 5009, 3490, 8762, 8947, 5213, 8701, 5595, 1950, 3304, 3191, 4171, 1224, 311, 490, 5572, 4339, 850, 6506, 9723, 6033, 4997, 6870, 2595, 3135, 4416, 1141, 1188, 7021, 5720, 1912, 655, 5550, 1449, 67, 9514, 1745, 6095, 8540, 5173, 8136, 7671, 840, 566, 9056, 7875, 9084, 9566, 7150, 5237, 5903, 792, 4835, 9677, 8675, 5722, 4194, 1375, 1259, 306, 8612, 9078, 9460, 2730, 4733, 8979, 1072, 5502, 8256, 6597, 7748, 523, 3098, 5569, 6715, 4511, 4579, 6072, 5929, 9643, 5678, 5469, 7251, 5399, 1011, 6161, 760, 6812, 9533, 7912, 8142, 4664, 1180, 2340, 1621, 6079, 8871, 4913, 2678, 8666, 4060, 8442, 1598, 8985, 4207, 9201, 2352, 8360, 8225, 9335, 6065, 8709, 8573, 7253, 6271, 1420, 4275, 3171, 4941, 4644, 9485, 5848, 432, 5535, 2910, 5357, 7162, 3173, 3909, 8828, 4434, 2628, 7580, 8247, 2838, 3106, 3323, 6786, 4637, 2084, 9481, 511, 8331, 179, 6162, 2620, 9100, 1373, 2574, 302, 2888, 9128, 9705, 8171, 4757, 4421, 8218, 781, 6132, 9116, 5030, 9319, 4129, 6591, 8944, 9912, 9678, 3630, 417, 9183, 9714, 5257, 9417, 2012, 3655, 7692, 1594, 4854, 876, 2040, 9053, 3629, 8379, 6548, 540, 1397, 510, 7969, 2829, 1207, 5613, 4921, 5648, 4612, 5974, 6443, 4634, 5530, 2878, 9706, 5917, 117, 8335, 9573, 5135, 5368, 3795, 6639, 6373, 1992, 9590, 3383, 5744, 2819, 2067, 4266, 8204, 8737, 7282, 4490, 7801, 5012, 2244, 9320, 5184, 233, 4988, 6942, 3658, 1085, 6854, 4879, 1361, 421, 6017, 7447, 1103, 6, 2868, 860, 4710, 2038, 4713, 4095, 4095, 3569, 618, 527, 2371, 6322, 7047, 8470, 2350, 2684, 7986, 6020, 9592, 1086, 1700, 1717, 5315, 8785, 5623, 8921, 7256, 7363, 5089, 6775, 9131, 409, 2296, 8597, 7, 47, 6184, 7495, 7586, 1290, 5149, 759, 7535, 7827, 8175, 188, 7, 2117, 6294, 8701, 9669, 5103, 2712, 3745, 3750, 5007, 1424, 8657, 50, 2591, 154, 946, 4454, 4869, 3791, 1646, 4402, 7570, 1405, 9079, 1523, 5248, 6922, 6636, 5028, 3451, 5216, 6947, 6238, 1642, 6820, 7546, 4537, 7483, 5076, 5663, 5839, 360, 6140, 6504, 6140, 6931, 7763, 3714, 946, 9401, 7606, 7651, 1814, 513, 7215, 2733, 2395, 80, 7617, 7375, 7784, 3966, 8000, 1616, 6448, 5404, 6167, 4044, 8853, 243, 8451, 6818, 8176, 4860, 8152, 8364, 3014, 8946, 2113, 1981, 3225, 677, 3802, 8135, 6480, 564, 9860, 7477, 4718, 4603, 5530, 7792, 4052, 4093, 6952, 7797, 8966, 692, 807, 4118, 9473, 3306, 1565, 598, 7064, 2655, 9626, 4786, 8676, 8664, 7295, 7630, 9809, 7615, 6195, 4845, 8042, 5549, 291, 6120, 1167, 8432, 7192, 3091, 1873, 1543, 8051, 2729, 6556, 6259, 9459, 5339, 9122, 9815, 3480, 6026, 2205, 5642, 5189, 9742, 5628, 703, 5479, 9481, 2596, 6138, 5585, 6016, 3105, 5950, 83, 7179, 5945, 6557, 7001, 3741, 6962, 1398, 7381, 672, 2230, 4304, 3117, 4887, 7856, 5317, 4315, 3006, 5400, 4516, 8746, 5476, 1062, 7191, 4297, 8138, 4908, 120, 2024, 4847, 2684, 889, 7228, 5410, 6871, 59, 8578, 7358, 8794, 635, 971, 1449, 6621, 5106, 330, 464, 1667, 1601, 3656, 9837, 5901, 4748, 6588, 7313, 1803, 4782, 7053, 3669, 2551, 1807, 9113, 6303, 3569, 5437, 9683, 9021, 3525, 4267, 3083, 3015, 6686, 2719, 1085, 7653, 3910, 5735, 8373, 2560, 9083, 2235, 248, 4083, 1903, 1435, 602, 1457, 7068, 9723, 2935, 465, 5057, 835, 2905, 723, 9621, 5302, 843, 8827, 8931, 7310, 9180, 2766, 2995, 8217, 1421, 7058, 2784, 274, 8740, 2955, 1871, 1465, 4176, 3955, 8275, 9049, 126, 9919, 9134, 9642, 9290, 2395, 9468, 1655, 1924, 988, 7354, 7082, 5424, 4979, 9144, 5137, 2550, 8647, 1835, 6748, 3876, 1513, 3016, 9763, 9637, 5596, 5660, 9959, 7094, 8704, 8988, 3943, 5199, 3684, 5085, 7150, 7565, 5346, 9414, 5034, 4052, 6898, 4070, 4960, 229, 148, 4193, 5647, 9308, 5334, 7408, 3368, 4266, 299, 4956, 2540, 5864, 1622, 4719, 9804, 2293, 8343, 7345, 8975, 270, 9044, 347, 5328, 2983, 9333, 8788, 3867, 1724, 5214, 9276, 4260, 2502, 721, 6747, 4451, 7786, 5983, 3235, 9192, 9382, 8247, 8694, 1971, 2345, 9142, 4734, 8909, 6582, 3897, 2781, 2193, 1635, 4918, 8949, 7469, 2163, 95, 7632, 3379, 7227, 6859, 5202, 6590, 3304, 2731, 1079, 2564, 1003, 4828, 6980, 3102, 6239, 8251, 7738, 5422, 3693, 6750, 143, 4587, 5448, 3205, 5082, 5553, 3278, 8153, 6854, 5253, 7507, 8996, 213, 8359, 4657, 6133, 7553, 4867, 6506, 7440, 368, 1153, 7567, 8247, 8827, 2380, 6164, 3283, 6841, 8987, 1587, 3235, 9691, 3556, 4713, 9045, 4, 9000, 7365, 7639, 1506, 7579, 7552, 4361, 823, 1168, 7490, 9814, 2396, 3648, 6796, 4951, 6895, 2206, 3590, 3196, 8904, 2430, 7731, 2242, 7069, 7972, 8152, 6903, 7350, 6907, 9575, 1469, 7758, 287, 8494, 5814, 4962, 4838, 8845, 7094, 8950, 1096, 7633, 3374, 5264, 326, 8332, 2235, 1366, 1132, 9929, 5280, 6213, 3635, 1863, 2634, 3232, 9506, 4304, 4642, 3524, 2420, 9487, 2465, 8328, 3679, 5267, 5713, 5158, 9271, 1689, 7631, 6617, 6041, 6762, 215, 8922, 6531, 2179, 7196, 9215, 8571, 5646, 8967, 5142, 1676, 9223, 1945, 9942, 2122, 7021, 9437, 433, 26, 9780, 8454, 3228, 572, 7464, 8365, 6367, 3833, 5426, 1830, 3878, 8899, 4507, 3489, 6114, 5676, 5913, 5719, 472, 977, 2925, 1446, 5997, 1093, 9753, 4652, 356, 3873, 7530, 9919, 4373, 4734, 7500, 6666, 3884, 1938, 7108, 4146, 1468, 5974, 4449, 4883, 6333, 1107, 1966, 1723, 5444, 8147, 3508, 3741, 2917, 6831, 9661, 725, 6524, 3781, 9779, 1366, 916, 2951, 1932, 4155, 5668, 2167, 8238, 7140, 1937, 7750, 6882, 3589, 5133, 1244, 7738, 2152, 7725, 7527, 2389, 8287, 5216, 8464, 3390, 9522, 4057, 8811, 6823, 4656, 1393, 482, 8435, 1371, 9372, 4259, 342, 6864, 9936, 9367, 7996, 4153, 7524, 9852, 7127, 7613, 640, 4553, 6098, 8514, 9783, 4135, 2992, 166, 4612, 5064, 5839, 609, 6437, 8314, 5003, 9710, 7685, 1740, 2946, 51, 5537, 8259, 118, 1081, 5091, 2637, 6348, 2757, 1063, 5125, 5173, 5280, 8330, 280, 4276, 8236, 1720, 791, 7708, 9259, 9013, 3847, 6357, 3921, 9918, 3811, 1687, 5274, 2759, 6891, 2386, 9338, 1021, 5190, 7297, 5156, 3774, 4753, 21, 1540, 5076, 5501, 2779, 4670, 4905, 3074, 1424, 9227, 9226, 4994, 6886, 2895, 6402, 6757, 816, 154, 3953, 9082, 7117, 6790, 4292, 687, 1179, 4136, 7997, 4575, 5119, 4181, 685, 319, 5872, 7665, 4046, 4896, 1156, 1227, 6680, 5549, 2264, 2524, 5331, 918, 2269, 9985, 4578, 4355, 1257, 3135, 5290, 7220, 8917, 9777, 5365, 4632, 4320, 1118, 9633, 145, 8501, 913, 5764, 1350, 3688, 9916, 6003, 2721, 2498, 8872, 8205, 3731, 4911, 2592, 9394, 5461, 716, 6729, 7098, 5232, 4471, 5367, 3228, 2476, 5757, 6812, 5365, 6444, 9123, 5203, 2485, 6689, 4668, 1053, 8775, 2294, 8059, 7901, 9221, 1348, 8370, 1491, 3802, 6450, 7488, 1885, 5580, 1599, 4689, 6002, 569, 3824, 1913, 1414, 7275, 5938, 5733, 5191, 7491, 3525, 4789, 2203, 5582, 6464, 5930, 875, 2180, 2223, 9263, 5885, 6224, 6127, 9588, 912, 54, 7387, 5726, 5768, 4793, 6980, 7772, 4257, 1142, 2629, 6095, 4495, 7530, 7454, 1701, 1810, 1594, 1735, 5057, 8523, 3382, 6667, 1837, 8099, 5621, 5794, 5234, 1423, 508, 6494, 5579, 3642, 9766, 4599, 2919, 6051, 5506, 1715, 9824, 266, 3993, 2745, 5860, 460, 8236, 4427, 779, 1384, 3194, 3709, 6345, 9949, 5691, 8499, 8035, 7966, 9677, 2909, 7362, 2457, 1553, 9778, 8431, 9320, 5223, 9252, 5595, 3532, 6329, 2658, 6994, 1601, 8019, 7003, 9156, 9735, 9522, 4850, 1181, 3636, 1055, 1096, 5146, 6106, 5213, 8226, 6929, 8585, 5240, 901, 8885, 7677, 4555, 6894, 3860, 8578, 2220, 447, 8167, 1409, 1855, 6148, 9122, 8464, 5344, 855, 367, 998, 6157, 1281, 9362, 326, 8051, 7532, 9846, 6037, 8011, 8635, 8603, 1540, 6029, 1980, 3682, 9104, 6661, 2140, 7349, 6888, 839, 7933, 5292, 1232, 4559, 8487, 9493, 7890, 6649, 2382, 8286, 6721, 2036, 9607, 2724, 1502, 6111, 1738, 8535, 4037, 2783, 395, 8471, 7343, 1829, 9143, 4864, 3352, 8378, 9472, 7422, 4946, 4340, 9566, 2900, 506, 9877, 4770, 3787, 1654, 9611, 7874, 5365, 2977, 8389, 3631, 2255, 5710, 987, 2332, 1040, 6633, 700, 3668, 8017, 8165, 2791, 4457, 650, 1539, 356, 5173, 428, 8439, 9109, 9108, 229, 6297, 7732, 8977, 8427, 9271, 8534, 7932, 5050, 6553, 8190, 3708, 280, 3963, 9673, 7596, 1689, 1358, 1491, 1294, 4830, 856, 1992, 3135, 8230, 2531, 1288, 213, 4240, 9632, 5337, 3352, 7974, 6976, 848, 4050, 569, 6854, 9792, 6987, 6229, 5599, 5177, 785, 4368, 8531, 2514, 2755, 1511, 4198, 360, 7774, 936, 5179, 2473, 4372, 5455, 4662, 2258, 7144, 7675, 2033, 4739, 4759, 402, 4742, 8846, 9196, 2460, 8105, 1303, 61, 6906, 671, 515, 9806, 5223, 5663, 3236, 2413, 6523, 5561, 13, 715, 2484, 6548, 5469, 2051, 7518, 1724, 7792, 1643, 844, 7179, 606, 2620, 9194, 638, 9518, 2067, 8740, 5040, 7614, 313, 5425, 8505, 3905, 5953, 9617, 5355, 6969, 3825, 6301, 8778, 2710, 9597, 1196, 2593, 258, 1244, 8124, 5684, 5788, 7170, 4965, 5353, 5000, 504, 637, 5009, 9452, 7293, 4426, 6856, 1993, 5378, 5910, 6576, 9020, 2919, 9911, 5828, 2471, 5948, 7157, 4399, 8120, 2121, 775, 4832, 574, 8704, 659, 1135, 6546, 6412, 726, 4926, 339, 3405, 1095, 7344, 9197, 9288, 1451, 4173, 7615, 8630, 9377, 9960, 648, 8936, 7367, 7457, 9956, 4194, 5236, 8858, 6435, 9327, 1130, 4770, 2984, 909, 8488, 5797, 6789, 8220, 3470, 5749, 9741, 4593, 5871, 2666, 7343, 6287, 7087, 8759, 3205, 7471, 6702, 114, 9733, 7882, 6972, 2915, 8578, 2233, 2150, 3989, 5024, 1411, 9090, 7276, 7165, 4933, 1763, 7723, 1901, 7992, 5475, 6999, 8378, 1863, 7676, 8662, 5481, 2268, 5408, 9069, 2775, 3143, 5906, 7144, 7372, 6918, 9559, 3713, 1754, 8819, 2327, 2648, 327, 2604, 1816, 9628, 6045, 4355, 3364, 9287, 5208, 7041, 3964, 2875, 6218, 5040, 299, 394, 9966, 7835, 9016, 6801, 8608, 1550, 1002, 7963, 4591, 8219, 380, 4328, 5490, 6204, 8687, 2794, 9686, 7139, 9906, 377, 7891, 4476, 2504, 9406, 9459, 1111, 9471, 7984, 2533, 1512, 8265, 1805, 1655, 3149, 1968, 3319, 115, 6716, 2982, 8571, 994, 4934, 3773, 8916, 9941, 5211, 9399, 6429, 377, 3643, 9708, 4480, 7544, 7179, 7089, 8805, 9039, 6306, 4887, 6152, 3899, 4662, 7986, 1911, 5005, 1799, 861, 6626, 8826, 9516, 4919, 9677, 7418, 5684, 9296, 9905, 1631, 8404, 9864, 3297, 9960, 1993, 8619, 5199, 6862, 797, 7832, 6552, 1814, 7155, 8271, 6917, 8610, 7678, 4968, 6623, 8611, 5199, 7443, 1991, 3870, 8770, 9527, 7380, 4730, 9018, 8221, 8901, 6352, 1472, 9747, 2857, 9199, 794, 5436, 7480, 6010, 4982, 5573, 7464, 3488, 4531, 3091, 1400, 2839, 6558, 4673, 3570, 6708, 9350, 4948, 2374, 6470, 7918, 3588, 6422, 1129, 2907, 1396, 4627, 4774, 3018, 4978, 8651, 9249, 1937, 2139, 3799, 6349, 3369, 4081, 335, 5156, 7913, 711, 314, 3188, 6451, 2799, 5940, 4347, 7855, 398, 3991, 5725, 3909, 5194, 361, 60, 5483, 289, 9929, 4485, 3880, 2362, 1306, 4163, 1334, 210, 1559, 3186, 5850, 191, 9113, 5365, 605, 8809, 2781, 966, 4661, 3804, 4993, 9061, 7815, 6327, 8855, 2119, 5818, 4192, 5690, 8773, 60, 9465, 4081, 7456, 6711, 8724, 2865, 7758, 3420, 8369, 4519, 5369, 8348, 9719, 3946, 1223, 7406, 106, 3092, 3733, 2661, 7088, 1844, 1645, 4204, 7484, 4280, 127, 7692, 2164, 7319, 3626, 5343, 2418, 5451, 7226, 2168, 9434, 8859, 8797, 3977, 4651, 3090, 1370, 2201, 6543, 9861, 1579, 704, 7830, 5133, 1870, 1968, 6886, 7606, 388, 8869, 230, 356, 1758, 7832, 6122, 9933, 9873, 8416, 7861, 4237, 2589, 5089, 6708, 7753, 6560, 2047, 8666, 5772, 7380, 7342, 2467, 8937, 3859, 6270, 8195, 2286, 9339, 6905, 2669, 4675, 482, 4165, 7089, 169, 4264, 6204, 7816, 5393, 2964, 8104, 4528, 3101, 2086, 4047, 6602, 2486, 4902, 8221, 8052, 5450, 2675, 3, 429, 9875, 29, 2074, 1001, 6360, 5197, 4098, 7261, 1031, 631, 3894, 4047, 4199, 2144, 2717, 4658, 4221, 1231, 8033, 5736, 2857, 9412, 6291, 4498, 4900, 5129, 5393, 7975, 862, 7054, 11, 1347, 1388, 5672, 9443, 5, 7885, 4016, 4503, 9661, 8539, 2248, 9411, 6172, 5027, 7054, 6390, 1004, 2431, 9642, 5742, 5263, 853, 520, 5708, 4847, 2112, 796, 9488, 8429, 5876, 62, 6223, 2920, 5865, 3134, 5101, 4890, 9707, 6151, 8966, 8797, 8443, 8268, 5854, 9926, 700, 5663, 7381, 9617, 8714, 2259, 3766, 4246, 3773, 6785, 5052, 8961, 7291, 5641, 9137, 1343, 2151, 2731, 5754, 5721, 6447, 5721, 1945, 2285, 195, 4635, 7838, 4042, 1012, 4028, 5393, 7037, 9955, 7625, 7560, 9448, 5474, 5284, 2929, 504, 1444, 7529, 263, 7445, 5913, 2876, 5849, 6262, 9094, 5857, 3089, 3018, 3760, 596, 3999, 6711, 2449, 8942, 4581, 9644, 7313, 3863, 3500, 3924, 7999, 1816, 2203, 6014, 8085, 6385, 8049, 207, 9325, 9934, 4755, 6026, 7497, 1934, 5793, 3581, 5971, 5907, 7194, 3649, 511, 9061, 4789, 9265, 142, 3620, 6322, 5427, 7042, 6081, 2702, 146, 1309, 1501, 1118, 1640, 684, 4954, 9281, 787, 3668, 2817, 1392, 7236, 304, 7949, 9434, 1046, 7389, 8549, 9045, 4315, 6392, 8297, 5281, 5720, 1416, 707, 3075, 3624, 820, 6420, 6229, 8075, 4510, 1715, 5824, 2642, 1984, 5592, 3070, 7438, 4331, 1024, 9653, 6229, 389, 2889, 7136, 9402, 5960, 2303, 2248, 2608, 3297, 5296, 1747, 9926, 3460, 5991, 5871, 5290, 8701, 6464, 8648, 1437, 3135, 1599, 146, 3583, 6340, 9576, 7581, 284, 6871, 7068, 9839, 6791, 5175, 8862, 6924, 2139, 9610, 1499, 550, 9491, 1283, 6210, 623, 7210, 9957, 4583, 5330, 8029, 2949, 7477, 3822, 3992, 2972, 177, 5359, 9422, 4226, 4628, 5577, 909, 8842, 2176, 9948, 5754, 961, 2047, 6075, 809, 1858, 5380, 4698, 913, 4119, 8033, 1424, 876, 8593, 5985, 3424, 8833, 2586, 360, 5910, 1497, 8291, 3675, 4825, 5257, 550, 6745, 5289, 5183, 8942, 5520, 6191, 2917, 4002, 7034, 1100, 8824, 5578, 6752, 3428, 3932, 6164, 3396, 6473, 9708, 9635, 540, 8593, 2967, 4933, 5728, 1115, 6882, 1324, 1178, 1746, 8186, 1943, 8071, 7719, 7851, 3874, 5362, 3801, 4633, 4154, 2477, 6436, 6192, 776, 9948, 7726, 4894, 3231, 1071, 9602, 847, 691, 4898, 8679, 8870, 3861, 3323, 9550, 3508, 4128, 5848, 405, 5531, 2267, 9586, 3667, 5441, 1633, 8590, 7184, 81, 2644, 3672, 4484, 769, 3841, 1408, 2712, 166, 4842, 2193, 3824, 2270, 3184, 7865, 624, 6075, 3830, 4726, 9512, 5901, 9849, 3819, 3845, 330, 1309, 1967, 2874, 8253, 9429, 2511, 1463, 5372, 7656, 7496, 9494, 2686, 9488, 6286, 1695, 7394, 8188, 984, 6487, 9886, 6089, 1831, 7980, 6695, 6189, 3778, 7564, 7621, 9245, 7243, 4360, 7269, 3890, 9428, 4423, 8894, 2070, 6792, 1503, 9354, 2323, 5621, 5807, 8104, 685, 2289, 117, 532, 6759, 126, 750, 1222, 6488, 2615, 1144, 3850, 6114, 2096, 6711, 7505, 9435, 525, 852, 9775, 6159, 9553, 2041, 8600, 2051, 5659, 7146, 4417, 9589, 611, 9253, 1624, 900, 6209, 1096, 8548, 3243, 1735, 5860, 2285, 7759, 7588, 6088, 9930, 2608, 4069, 8450, 1499, 9929, 7838, 607, 6530, 5518, 5302, 6807, 8062, 2362, 8654, 3428, 2402, 1221, 2837, 4904, 9661, 3923, 4122, 656, 3223, 8827, 5508, 3017, 208, 5499, 9010, 3675, 3945, 9831, 1721, 2038, 6515, 9357, 3020, 6725, 459, 6091, 2029, 407, 300, 409, 630, 985, 2146, 8858, 6142, 2646, 4477, 1823, 1619, 6681, 7674, 8653, 2946, 2442, 615, 4325, 6637, 7055, 6894, 5616, 6969, 917, 5124, 2566, 4010, 4124, 3348, 3038, 9915, 1945, 8291, 9811, 9673, 6660, 7515, 3799, 9048, 8699, 4651, 675, 841, 7249, 3385, 9783, 3238, 8273, 8655, 2604, 9798, 3163, 9585, 4758, 5343, 5636, 5830, 3412, 3735, 2991, 2746, 9304, 4348, 9274, 7836, 1449, 4807, 8274, 5223, 1620, 3649, 211, 3312, 6351, 5375, 2768, 7698, 1532, 1404, 7302, 1002, 2808, 4609, 7469, 9194, 4102, 838, 5272, 318, 9339, 7960, 3808, 5578, 9357, 9432, 4619, 4018, 5578, 5295, 2556, 4833, 547, 8241, 9345, 323, 7724, 3135, 4198, 503, 9569, 3599, 5540, 9889, 1848, 3083, 4895, 2329, 2330, 4361, 7514, 1681, 563, 5983, 4469, 9153, 3509, 1343, 6128, 2337, 651, 2184, 6743, 3699, 2254, 1292, 8279, 3040, 3337, 3234, 4829, 2952, 5344, 3856, 6334, 4652, 7098, 5036, 329, 5545, 4943, 9011, 6958, 8085, 3196, 3555, 5251, 9004, 708, 238, 9949, 6323, 8104, 3919, 717, 6248, 3105, 2465, 1610, 4112, 5657, 9862, 9555, 6849, 4769, 9513, 5184, 3080, 8366, 1957, 9337, 904, 2452, 1323, 3196, 8687, 8171, 2239, 5591, 3945, 3374, 5650, 898, 587, 5453, 6675, 9495, 2875, 8751, 7386, 1439, 9481, 7153, 4527, 7114, 7007, 2708, 6120, 9641, 1041, 5363, 5214, 4524, 2243, 2017, 4338, 8077, 3384, 760, 176, 8094, 5148, 1605, 1932, 9731, 3471, 2223, 5307, 5441, 3534, 4562, 9211, 6419, 6489, 168, 7479, 1822, 5380, 101, 9920, 3007, 7217, 3671, 4050, 1762, 9729, 3520, 5051, 8927, 2019, 9083, 5535, 444, 1169, 7952, 16, 5667, 1181, 3885, 8338, 2242, 9315, 6214, 3100, 9146, 5305, 3976, 7618, 7756, 4548, 9231, 1053, 7504, 6078, 7837, 3294, 2467, 7251, 9225, 8187, 2996, 7998, 4508, 1098, 7229, 2428, 601, 2126, 8644, 8408, 620, 6463, 5134, 8925, 1644, 5959, 8847, 3789, 8858, 404, 5482, 1262, 9025, 2572, 1999, 2637, 8797, 9289, 6791, 4655, 445, 2948, 4681, 7580, 63, 8556, 5757, 6420, 2378, 8851, 2691, 9907, 5876, 4194, 8978, 3456, 7219, 1160, 6684, 5579, 5514, 5827, 8328, 5899, 5507, 3370, 995, 7102, 2341, 3048, 1039, 2422, 5997, 8284, 3842, 9059, 4022, 5949, 420, 9917, 832, 2111, 4225, 3236, 6696, 8379, 4878, 9032, 3075, 6993, 7442, 7120, 2127, 6204, 9107, 6296, 2658, 1316, 91, 7888, 5732, 7086, 5530, 1819, 7687, 8446, 6833, 8483, 9991, 9190, 4507, 4450, 5407, 8591, 1566, 4115, 944, 641, 7685, 1878, 6588, 6264, 5202, 5174, 7176, 8427, 2629, 4463, 494, 6760, 3278, 536, 2394, 2289, 8484, 1273, 9683, 5818, 9888, 2358, 5817, 3159, 3003, 905, 285, 3918, 3232, 4441, 1876, 221, 7361, 5788, 9125, 615, 7997, 2124, 7728, 3463, 7477, 646, 31, 7806, 1155, 1847, 7568, 6378, 500, 2560, 5600, 6470, 8113, 2301, 685, 5499, 2823, 3587, 9118, 5764, 4397, 1974, 4167, 1234, 4529, 2739, 9301, 7797, 1137, 1296, 8369, 4687, 6198, 2104, 9954, 4174, 6776, 8386, 4565, 4589, 5469, 6935, 8584, 9370, 2421, 5560, 2988, 9820, 9430, 5407, 1661, 4891, 6812, 8011, 3504, 6930, 401, 8049, 8847, 7780, 3753, 6227, 6176, 2826, 6527, 6357, 8917, 3125, 6830, 8615, 7014, 5977, 9672, 5450, 7089, 8654, 6492, 4960, 5143, 1260, 3008, 1563, 5766, 3228, 1234, 5267, 8831, 9725, 8102, 6305, 1013, 7368, 5554, 2554, 2585, 579, 2768, 3242, 1427, 3111, 8131, 860, 5178, 8399, 7569, 2914, 4368, 7079, 6723, 2635, 2096, 1921, 1739, 1375, 2730, 374, 5652, 4061, 424, 7397, 8314, 2344, 3014, 9977, 8911, 9992, 7979, 1039, 1970, 5502, 2302, 445, 9479, 2102, 5555, 6534, 5742, 2050, 8787, 2674, 4495, 3943, 5002, 8235, 9591, 5391, 2112, 2381, 6525, 1912, 3300, 8129, 7799, 4208, 1500, 1341, 273, 5344, 6163, 8399, 5356, 4977, 7218, 489, 911, 6986, 579, 4687, 5998, 8253, 2499, 7950, 8803, 9313, 1860, 1297, 91, 4318, 7925, 2570, 6398, 8919, 1051, 7824, 4966, 3836, 3091, 1334, 1749, 9387, 6328, 8463, 1144, 6937, 2878, 6039, 1328, 9135, 3581, 4613, 9381, 4020, 5999, 857, 9581, 6297, 9970, 6003, 7654, 4927, 5568, 3264, 8376, 6610, 6758, 4656, 1091, 6886, 8902, 1726, 7039, 5428, 9146, 4416, 1422, 6573, 1045, 7477, 839, 1855, 7029, 4161, 9548, 976, 6458, 1884, 8185, 1412, 2560, 2649, 3599, 5898, 1118, 1525, 7334, 5617, 69, 9853, 6107, 8805, 6200, 4413, 9783, 637, 7734, 5331, 2650, 7739, 5656, 6729, 3269, 3402, 468, 3289, 8098, 7960, 4636, 5198, 5813, 2648, 3321, 8761, 4374, 6393, 5370, 5966, 3779, 88, 3524, 9362, 264, 1808, 7518, 4070, 7928, 8848, 2453, 5296, 1524, 6055, 2678, 3814, 4114, 3058, 782, 2568, 7180, 918, 5024, 2898, 7207, 4263, 9923, 4815, 7258, 7390, 9328, 5456, 8915, 3282, 3317, 222, 9149, 7091, 101, 7994, 5206, 9540, 4842, 2051, 6346, 5941, 991, 8339, 9349, 2946, 1716, 7775, 4776, 3040, 9213, 8167, 6738, 3233, 6178, 3079, 7293, 2270, 5215, 9907, 7917, 8578, 4714, 9799, 2620, 7444, 1177, 3607, 3023, 5967, 5516, 124, 7156, 2876, 8853, 581, 9857, 2994, 3958, 3526, 5300, 9057, 4461, 3032, 2911, 5037, 858, 4111, 1399, 5330, 1307, 3672, 4102, 5882, 7646, 8775, 1088, 9349, 9742, 5572, 7985, 30, 2666, 3358, 9164, 5460, 1217, 4672, 2618, 4384, 2656, 1011, 4475, 2430, 5561, 2978, 3946, 3490, 1111, 1499, 4725, 2152, 8353, 2400, 8907, 690, 4613, 197, 7676, 3875, 2088, 2251, 8540, 9532, 5647, 8147, 9386, 4396, 6424, 3541, 1874, 6722, 3702, 2577, 7088, 28, 4851, 458, 5403, 3729, 3002, 683, 6542, 3178, 3279, 2714, 7214, 8003, 2705, 544, 7008, 7967, 6917, 1850, 4652, 787, 7271, 7228, 1177, 9742, 9428, 4687, 3876, 4187, 5503, 8281, 9757, 5736, 5618, 2892, 906, 173, 1943, 9986, 6580, 4857, 6782, 1692, 9387, 4608, 4133, 1705, 1391, 6722, 330, 5584, 1327, 8466, 302, 6979, 1796, 7261, 8713, 4390, 1291, 2287, 4977, 8346, 995, 5964, 4570, 2908, 3522, 3646, 7476, 3125, 3641, 9934, 6003, 1267, 7698, 349, 9021, 5432, 2871, 9784, 7875, 1076, 5422, 6525, 530, 156, 2629, 2117, 6385, 3473, 8434, 767, 3816, 4795, 5790, 829, 9599, 2887, 5709, 1946, 3402, 3987, 7704, 5777, 670, 8874, 3827, 1477, 835, 2316, 1120, 9865, 5714, 2798, 4015, 1813, 6841, 1042, 8275, 2511, 9884, 9545, 7943, 8359, 3109, 6307, 2995, 6576, 3736, 179, 1910, 8139, 7950, 3270, 3316, 3008, 8320, 5524, 6246, 9218, 612, 3107, 6710, 4597, 9945, 8128, 2540, 8112, 4011, 4363, 9675, 5527, 8500, 4046, 9446, 7237, 2888, 1047, 6900, 5930, 6453, 2007, 709, 8174, 2654, 4776, 4641, 2396, 797, 8840, 202, 5453, 4893, 6119, 143, 3281, 1771, 2726, 6652, 8479, 908, 4911, 3458, 3718, 6188, 5581, 212, 3984, 9669, 943, 1721, 3726, 1795, 8585, 4891, 555, 8809, 9205, 3449, 3149, 2583, 1352, 652, 5024, 6568, 5961, 3066, 6484, 7372, 1971, 3068, 9876, 430, 8385, 2987, 3386, 4175, 1522, 8404, 6713, 3346, 3519, 4586, 8257, 1503, 3722, 3985, 3189, 4278, 8792, 4581, 2496, 8827, 6010, 7448, 6532, 6674, 6645, 2773, 740, 1949, 3898, 1898, 3605, 6963, 6714, 3527, 3200, 3035, 936, 6414, 2780, 8751, 255, 1565, 1167, 5890, 2853, 3125, 8027, 2314, 6961, 8646, 5541, 4048, 2903, 1129, 9203, 2637, 2148, 4299, 1622, 3823, 3316, 263, 3786, 3976, 5247, 9423, 5792, 1618, 580, 7844, 2715, 8218, 5180, 5078, 5735, 2008, 7234, 9371, 1336, 9240, 994, 422, 7254, 2006, 2599, 2922, 4976, 2350, 1435, 333, 3514, 6108, 3215, 317, 2649, 652, 840, 3819, 7634, 1678, 2636, 2625, 432, 3978, 5273, 5438, 1126, 1332, 7791, 1418, 5892, 5704, 3740, 7782, 1278, 7779, 7139, 8960, 4814, 5358, 1663, 8365, 7101, 8153, 2296, 1441, 9139, 5623, 9529, 8121, 785, 1401, 1370, 9686, 5872, 7529, 6399, 3193, 6566, 7661, 4235, 733, 4415, 1790, 878, 9513, 5719, 146, 650, 44, 4777, 2442, 9006, 8730, 4801, 5889, 2946, 9596, 566, 3412, 3045, 925, 5648, 5038, 3335, 4336, 2068, 8506, 1712, 5145, 7372, 4798, 7795, 4191, 9954, 3219, 8270, 9692, 4137, 8130, 1180, 7575, 3679, 8177, 8642, 9478, 8857, 9891, 2865, 3294, 1888, 6972, 1755, 6216, 7556, 5822, 1747, 3181, 5270, 5924, 6802, 1353, 3482, 167, 1558, 5070, 6061, 7037, 5068, 8365, 9202, 9981, 4123, 189, 8482, 7577, 1811, 5443, 6510, 7269, 6397, 8637, 4882, 7868, 6107, 8897, 9682, 6822, 4400, 7463, 1957, 1873, 4708, 3071, 7861, 5507, 4327, 6446, 7641, 3933, 3134, 758, 9610, 5874, 8848, 258, 1344, 5894, 4825, 8255, 2235, 9603, 3904, 5509, 3243, 7844, 2832, 5443, 8891, 964, 6209, 3088, 5322, 7314, 4654, 5392, 7210, 3699, 5249, 7523, 771, 3782, 3163, 3819, 4333, 916, 9828, 2183, 2049, 7675, 7253, 3342, 6158, 2441, 253, 1159, 5147, 7058, 2457, 8976, 2809, 8639, 2716, 1195, 7221, 3484, 3993, 3677, 8935, 2115, 7735, 1879, 7710, 3346, 1653, 1058, 251, 8106, 3539, 7342, 607, 3178, 7457, 8644, 4810, 6480, 3264, 1729, 7340, 6416, 3793, 2110, 7746, 4226, 2840, 8186, 86, 5528, 7626, 6553, 4352, 5970, 8174, 466, 1954, 4127, 3943, 8316, 3717, 1475, 1523, 5726, 1931, 4765, 3102, 5330, 118, 3464, 3819, 2182, 9952, 1332, 7998, 4289, 9000, 6133, 1555, 1755, 1157, 9660, 745, 3053, 4108, 5976, 659, 8857, 7830, 3578, 8111, 5784, 4901, 8311, 6059, 3726, 4437, 2914, 6955, 58, 1947, 2747, 5633, 7257, 6339, 541, 5291, 5985, 8768, 8803, 6705, 2525, 6508, 150, 5218, 1524, 7087, 9770, 7225, 2305, 7483, 7386, 109, 3310, 7466, 8502, 201, 5301, 1894, 5968, 824, 5988, 4574, 1675, 3363, 3887, 8171, 2518, 6151, 6258, 2372, 1528, 7762, 9459, 6902, 615, 8836, 1854, 887, 8143, 5690, 9036, 2565, 3111, 7000, 1946, 9438, 8050, 6712, 8202, 6982, 921, 6726, 6282, 5774, 7567, 93, 8039, 5534, 5856, 8741, 7999, 3673, 4691, 1892, 6964, 7497, 2608, 3835, 1668, 3964, 1829, 8758, 887, 3968, 3089, 2313, 6175, 6239, 167, 7478, 9190, 2863, 2321, 9069, 2504, 7083, 300, 3925, 4056, 3395, 630, 322, 979, 5523, 8084, 227, 3251, 8401, 5600, 7712, 5533, 2811, 5060, 6525, 3732, 485, 5245, 1254, 6276, 3143, 6199, 864, 5625, 6061, 655, 4199, 3997, 7398, 4340, 7337, 4849, 719, 9524, 4639, 1051, 7283, 6432, 959, 7267, 3183, 1283, 3620, 1987, 9726, 6499, 1695, 8162, 7557, 2575, 4850, 7595, 4785, 8782, 1922, 1600, 3633, 3294, 2631, 3290, 41, 1505, 4636, 1985, 7714, 2162, 7039, 7041, 1615, 7969, 1149, 2222, 5460, 3546, 4351, 3064, 1449, 6449, 4567, 2809, 8138, 696, 4273, 3736, 7486, 2928, 4090, 4067, 4986, 5617, 4149, 5643, 9550, 5262, 9326, 2675, 5074, 7395, 5904, 5190, 8731, 8969, 1488, 1452, 8430, 2478, 1049, 8602, 9153, 2254, 5021, 3077, 2033, 4650, 5712, 2596, 9657, 2125, 3192, 1599, 7001, 1305, 3028, 4608, 5136, 3284, 6715, 2950, 1202, 9107, 116, 2478, 3948, 4985, 3262, 8509, 331, 2375, 8240, 6625, 5179, 2525, 8114, 4499, 4321, 3166, 3465, 9766, 1387, 4219, 7845, 2222, 8959, 3063, 5173, 3394, 2021, 2961, 9525, 8730, 9013, 7766, 4513, 7874, 1674, 821, 340, 2135, 8621, 8864, 8115, 5811, 1804, 8128, 746, 3110, 4750, 6634, 8009, 1116, 1568, 605, 8164, 3538, 5181, 4281, 9845, 4885, 5803, 5073, 3375, 8081, 807, 1053, 2225, 544, 8310, 824, 1177, 5673, 5326, 4208, 8607, 9672, 2846, 9251, 4509, 5368, 7024, 667, 6670, 875, 6423, 5876, 5029, 628, 736, 1032, 9905, 5364, 1962, 8518, 612, 6445, 718, 2197, 1360, 9395, 2036, 4827, 9512, 1856, 85, 3640, 5318, 4487, 2973, 7688, 6349, 8108, 2550, 4545, 1396, 5192, 8808, 276, 1558, 3306, 1319, 5689, 3324, 3563, 3465, 8935, 3362, 6439, 2787, 7996, 3069, 9489, 3907, 196, 6861, 1554, 9053, 8171, 4205, 1137, 88, 808, 1293, 907, 5630, 4785, 9917, 7260, 119, 3652, 6484, 4281, 7617, 2265, 1577, 8633, 3562, 1953, 672, 9051, 49, 2553, 9199, 281, 5025, 9522, 8568, 8943, 2119, 6925, 7387, 7713, 6289, 315, 8150, 3817, 398, 940, 4928, 9383, 6957, 6456, 7434, 1982, 5248, 9328, 1262, 8009, 2571, 5707, 7832, 3775, 6158, 116, 232, 9622, 1904, 1833, 569, 9316, 9932, 9337, 5702, 3676, 2147, 4388, 4473, 6221, 3042, 1599, 4774, 6234, 4497, 488, 6219, 4856, 2810, 9065, 1133, 1743, 5384, 2588, 1405, 5466, 7835, 1903, 918, 7305, 720, 9956, 4582, 2541, 2983, 9661, 3942, 8457, 1152, 8589, 8926, 7888, 387, 731, 9793, 1350, 796, 2603, 3681, 638, 3197, 4810, 2745, 1866, 1341, 5193, 7976, 7198, 7090, 9929, 1904, 523, 1150, 5022, 8496, 170, 949, 591, 73, 6116, 3085, 2714, 2083, 2362, 1616, 3481, 8458, 2677, 5698, 2202, 409, 4180, 1986, 6415, 5134, 5890, 5766, 335, 555, 76, 8819, 2276, 153, 3377, 9848, 1484, 4061, 1159, 4130, 1359, 6414, 6683, 4734, 1143, 1874, 929, 7733, 16, 5008, 833, 7408, 3966, 9986, 8768, 9738, 1266, 7827, 4797, 9452, 9704, 7209, 5009, 111, 8840, 3751, 1086, 6540, 2432, 3991, 1168, 8541, 2412, 9743, 8600, 2158, 2717, 6769, 7285, 996, 3178, 6407, 5386, 35, 574, 5990, 1817, 2420, 2826, 34, 9456, 8519, 8064, 4683, 5380, 6488, 9003, 3533, 440, 695, 2625, 2530, 5553, 9191, 8122, 3335, 614, 1423, 9834, 3551, 2754, 6135, 5863, 169, 6408, 5599, 9936, 2035, 7889, 2896, 5885, 147, 5143, 4663, 494, 7698, 9254, 7826, 3990, 3017, 6154, 8840, 1399, 8258, 4312, 5730, 688, 938, 5702, 8511, 1474, 1123, 7856, 6168, 3117, 7113, 6549, 315, 5814, 7871, 1446, 3849, 9707, 7972, 8779, 8193, 8123, 9302, 266, 4888, 4913, 8964, 9468, 711, 455, 2165, 9748, 9814, 7832, 3874, 2687, 9112, 556, 121, 8788, 9870, 2256, 2556, 6971, 1437, 8166, 5285, 2808, 3788, 7079, 9644, 1489, 3833, 8582, 9935, 2901, 1154, 1607, 5871, 1267, 1952, 7788, 5981, 3189, 9394, 2550, 9281, 3247, 4955, 3161, 9221, 2202, 445, 2893, 469, 4522, 5803, 9956, 8799, 9554, 7744, 6562, 3107, 5977, 6659, 5332, 2671, 7337, 312, 254, 6189, 553, 6263, 4345, 1297, 3601, 3945, 8990, 4366, 6481, 5538, 9747, 7952, 8872, 3103, 1969, 2070, 7970, 3883, 8191, 9078, 72, 600, 347, 3026, 3937, 7819, 8508, 2168, 8849, 7799, 2597, 5083, 6513, 1271, 4996, 7965, 3319, 130, 6261, 3767, 3791, 2505, 5746, 3369, 6044, 2550, 428, 31, 9434, 5971, 5596, 7582, 1125, 4607, 859, 566, 7763, 9072, 4080, 8182, 8218, 2706, 627, 731, 2501, 7813, 9070, 3101, 7541, 4698, 6615, 9501, 4657, 2231, 4942, 5570, 2428, 1838, 5410, 8149, 5289, 5731, 4641, 9382, 9859, 597, 9802, 7679, 8218, 1144, 6682, 4815, 5524, 846, 2564, 4321, 5042, 8226, 9580, 7027, 6266, 3564, 8183, 3482, 1178, 5520, 9555, 273, 9666, 2339, 6834, 4332, 5182, 1062, 6480, 7932, 1905, 5266, 9702, 5740, 5042, 315, 3112, 165, 3470, 5201, 79, 3371, 7270, 2573, 423, 4736, 4293, 3918, 3425, 5040, 4081, 8490, 2814, 7311, 4054, 4976, 3445, 2317, 3962, 1499, 301, 146, 3577, 6665, 1351, 8103, 4002, 7864, 6501, 9815, 9171, 1251, 9860, 4095, 7344, 1548, 3027, 9849, 5596, 8387, 6698, 6800, 9845, 8424, 5124, 8329, 9992, 5226, 8091, 572, 9752, 2402, 2768, 9138, 835, 4517, 5859, 2947, 2169, 5927, 1777, 3397, 9079, 5552, 7643, 938, 2519, 9719, 5434, 3816, 3258, 9767, 6779, 3522, 6302, 6875, 12, 2069, 3782, 4333, 804, 6574, 4995, 6620, 4422, 7504, 8503, 8860, 3331, 5558, 3776, 483, 8129, 6378, 9026, 2137, 225, 4102, 5439, 1052, 5009, 2924, 8066, 7161, 5223, 9010, 5267, 2118, 381, 6993, 1288, 4316, 3122, 644, 9010, 7578, 8075, 4775, 3971, 3955, 8563, 7686, 2629, 2860, 583, 1623, 8547, 7267, 8883, 8768, 4293, 8770, 3429, 4002, 8237, 6323, 2944, 5784, 6746, 4368, 9145, 4166, 398, 3046, 730, 327, 3543, 6024, 8989, 2473, 6753, 8250, 5224, 8887, 9481, 9640, 8775, 7779, 2882, 5430, 7964, 1970, 7339, 3176, 3681, 1630, 4727, 2830, 4686, 876, 9359, 5392, 3145, 7188, 7760, 3321, 9425, 74, 6039, 9521, 602, 4132, 5939, 498, 7207, 665, 3937, 1802, 9944, 7735, 5806, 9416, 6671, 9555, 7119, 1430, 2841, 2178, 661, 2664, 786, 9106, 8657, 330, 6726, 5950, 4877, 6570, 3507, 3105, 5231, 7423, 8640, 9036, 7150, 3915, 5347, 6396, 7715, 756, 5756, 2779, 1929, 9865, 8545, 8127, 9081, 6486, 4511, 9039, 1864, 7051, 9401, 9505, 3878, 1307, 2151, 9085, 1459, 4848, 5373, 7053, 2150, 7502, 7974, 7854, 1444, 5038, 8365, 6344, 9783, 8573, 223, 6801, 3247, 8, 1536, 4586, 1010, 6760, 424, 2107, 1039, 5636, 477, 1666, 126, 4606, 664, 678, 1103, 223, 8973, 6166, 2039, 3, 7607, 471, 5607, 8016, 96, 4655, 3357, 4944, 7753, 6735, 8930, 314, 2258, 946, 2556, 319, 3113, 2765, 1756, 5757, 5252, 5358, 7841, 2770, 5425, 871, 366, 284, 1222, 9003, 9284, 7347, 1486, 6749, 6243, 8444, 1598, 751, 6093, 3055, 760, 6942, 1750, 4252, 7443, 9337, 5076, 8768, 3629, 9374, 615, 8493, 7152, 9378, 6116, 4569, 3535, 7608, 1331, 8625, 277, 4895, 6229, 2181, 7868, 4819, 6402, 7444, 6377, 596, 8551, 4818, 2540, 5151, 4400, 3496, 9715, 1016, 7115, 7261, 4557, 2000, 1944, 826, 3107, 7911, 7054, 9553, 30, 2414, 7668, 6694, 2676, 5585, 2409, 6920, 5840, 6881, 1377, 6214, 8140, 7625, 3942, 2474, 5518, 8104, 382, 4379, 3609, 100, 9538, 133, 3248, 4193, 3839, 9237, 7382, 4906, 3996, 6564, 974, 6745, 9353, 7161, 122, 6858, 8549, 4269, 8693, 377, 5955, 4119, 6411, 8810, 5080, 8018, 6364, 6134, 3884, 3770, 8720, 1070, 1326, 8674, 2402, 4749, 9248, 770, 1278, 3209, 2190, 494, 5757, 4922, 6488, 4635, 2178, 5192, 2562, 5366, 7427, 5070, 3320, 6184, 3367, 2690, 1804, 7825, 5631, 1161, 475, 4757, 2088, 4595, 1789, 8470, 2663, 4051, 4750, 3420, 3531, 7734, 8513, 5058, 1524, 8809, 1269, 3977, 1704, 830, 7989, 5077, 2464, 9220, 78, 2069, 5204, 2882, 2397, 9769, 5549, 1913, 5503, 192, 9007, 44, 381, 6822, 7128, 9689, 800, 6727, 9105, 734, 5415, 8360, 6366, 8947, 4877, 8427, 4092, 4952, 4242, 2057, 70, 3566, 5389, 8858, 6350, 4910, 1145, 3717, 5930, 112, 964, 7080, 1598, 1910, 1175, 6225, 8343, 1023, 421, 7323, 3927, 1632, 2582, 1294, 3840, 8855, 2991, 4738, 3332, 9355, 3697, 4426, 599, 5070, 6975, 6340, 2588, 9508, 3353, 7500, 2051, 3095, 2132, 5321, 7748, 7927, 897, 2163, 4304, 5285, 957, 9748, 9181, 9048, 1178, 6398, 7139, 7366, 2772, 9156, 8019, 8812, 5550, 7005, 2228, 6633, 3201, 9076, 3591, 453, 5449, 8344, 1421, 5526, 7935, 1421, 3734, 5018, 3527, 8568, 9467, 4213, 5257, 1867, 6130, 3849, 5382, 2223, 9448, 5057, 2096, 805, 2801, 9271, 4063, 9449, 2643, 7099, 7373, 4046, 2668, 8592, 577, 42, 7150, 9237, 2577, 8695, 5899, 5731, 7651, 4329, 9085, 7449, 3466, 9508, 7356, 8450, 8799, 8183, 5605, 4423, 9328, 2764, 4721, 9777, 4056, 5718, 2809, 6892, 2619, 2024, 8562, 5214, 7699, 4685, 1536, 1959, 5276, 4917, 3281, 3744, 4265, 7748, 8212, 2238, 3206, 225, 632, 7464, 2235, 180, 4253, 519, 6896, 5437, 3771, 1410, 5773, 4177, 5936, 8604, 5328, 6975, 6483, 7618, 895, 2016, 4157, 9294, 7414, 5901, 3366, 6517, 5414, 4763, 7279, 9205, 9787, 8802, 8140, 1388, 4778, 7783, 9043, 239, 6700, 6608, 3154, 90, 8049, 190, 3785, 7868, 1231, 7624, 5301, 9806, 8976, 9880, 1065, 9446, 8522, 2485, 5265, 5262, 4470, 1904, 4108, 7822, 3312, 946, 3580, 3922, 3631, 1987, 8006, 1210, 6838, 846, 2422, 8010, 5384, 4199, 892, 7763, 8100, 6336, 1025, 2910, 8165, 4319, 8268, 6536, 7553, 799, 4873, 3483, 2589, 9689, 6046, 6613, 9420, 679, 9994, 7193, 8438, 473, 8821, 7223, 533, 8595, 7581, 3908, 4576, 7669, 2444, 3403, 4378, 6813, 8844, 1713, 2285, 9707, 257, 4443, 2678, 47, 646, 3073, 1964, 3121, 7882, 9471, 428, 4972, 497, 4443, 1633, 9125, 5145, 5481, 1170, 4209, 8462, 4166, 7934, 6660, 8353, 8779, 6560, 1980, 3320, 1975, 8048, 1994, 5613, 406, 2574, 9730, 695, 6700, 4129, 547, 2504, 3696, 802, 4798, 4393, 68, 4098, 3508, 8816, 5784, 8893, 3338, 5392, 4968, 7916, 2493, 19, 2736, 5762, 4697, 1151, 8324, 4169, 1389, 3082, 3087, 6062, 8970, 3271, 2757, 5732, 5864, 2689, 2349, 3846, 2949, 6948, 2405, 9638, 2251, 957, 335, 4150, 9032, 5203, 5535, 206, 7687, 7316, 4517, 1746, 8492, 9487, 1643, 6263, 2085, 9895, 2715, 1557, 5819, 3677, 1840, 2121, 8113, 3658, 772, 2203, 3900, 4771, 8072, 7763, 5406, 9163, 2396, 8337, 2224, 5168, 5796, 3298, 3722, 3600, 9268, 8470, 74, 2065, 4352, 310, 7201, 5748, 4277, 2579, 2612, 7954, 1800, 7696, 839, 4573, 4576, 5091, 82, 6180, 3851, 9932, 1243, 1930, 6202, 1930, 4831, 1911, 2828, 6537, 193, 5693, 9861, 787, 8839, 3802, 9175, 4320, 3936, 9132, 6910, 1741, 7693, 111, 4980, 2534, 7210, 9977, 442, 7603, 2179, 5596, 8448, 1479, 8613, 9870, 5399, 2030, 7643, 1338, 3026, 3405, 330, 353, 5012, 6004, 7687, 744, 6268, 841, 8895, 8491, 8016, 1408, 966, 5281, 5125, 2141, 8543, 1390, 5532, 8498, 466, 2505, 1304, 9501, 9243, 7239, 5061, 5969, 8771, 2496, 3537, 3653, 4796, 9165, 7287, 8063, 8551, 7918, 4917, 8059, 8373, 5456, 3090, 2167, 8195, 2217, 9163, 5267, 3197, 3272, 4253, 8065, 1003, 5557, 8006, 7868, 3145, 1059, 2878, 6182, 7992, 361, 4995, 1786, 5227, 4279, 5668, 830, 2104, 2550, 4530, 9729, 7500, 1956, 8185, 9650, 1716, 484, 2485, 820, 9235, 6370, 53, 8894, 6460, 6708, 4465, 5381, 1696, 6665, 6367, 6156, 5482, 2134, 9732, 8587, 2392, 1522, 88, 2376, 1154, 5712, 6777, 707, 7467, 3713, 3037, 6230, 6225, 6279, 1480, 7968, 7776, 8487, 4017, 8813, 1791, 5400, 7796, 348, 9306, 3377, 2426, 3884, 9412, 8447, 8476, 3227, 9530, 632, 8896, 8200, 667, 7816, 965, 3426, 46, 4909, 23, 8694, 6678, 5452, 4049, 7122, 7532, 605, 2284, 2237, 7298, 901, 1323, 8596, 1320, 297, 5571, 7017, 4737, 1969, 6472, 192, 7156, 8066, 2272, 8060, 5981, 247, 4392, 9270, 9185, 4572, 5519, 1868, 3057, 7401, 4333, 9030, 408, 9902, 1893, 3613, 104, 1501, 2569, 6808, 867, 788, 3348, 6566, 6545, 3916, 5214, 6426, 5706, 6163, 6425, 1406, 4477, 9795, 751, 4583, 3013, 6417, 5132, 1604, 5696, 6691, 7202, 2439, 4586, 2447, 5807, 6267, 3990, 9615, 4055, 1414, 301, 4043, 4128, 8959, 9600, 8974, 7296, 6639, 5774, 1953, 1556, 433, 5897, 8193, 4393, 8183, 1955, 6602, 24, 3650, 6646, 2834, 1718, 8529, 3432, 7262, 7026, 6611, 9910, 9247, 1755, 5638, 646, 7351, 8624, 8895, 8480, 2362, 4952, 7464, 1251, 132, 6783, 1361, 5307, 2185, 6487, 3597, 8944, 416, 9188, 6539, 2270, 8428, 7108, 5924, 271, 5102, 8308, 9239, 8212, 2287, 6848, 5167, 4973, 4685, 975, 9634, 5406, 8310, 886, 6525, 5798, 665, 3989, 1790, 9013, 6238, 5620, 6042, 830, 9302, 845, 246, 8968, 4844, 2978, 1183, 7088, 5587, 9391, 1113, 6088, 6890, 1588, 6527, 6773, 3719, 12, 1576, 6207, 6672, 3906, 8268, 5667, 1750, 5784, 5368, 4383, 2878, 3260, 3651, 6256, 7848, 1856, 3990, 4662, 4661, 8711, 109, 3562, 4051, 4092, 3424, 6030, 3368, 8507, 2823, 5410, 5878, 3776, 8781, 6635, 467, 4024, 3714, 5411, 4027, 8321, 619, 3378, 8852, 7229, 9257, 9836, 587, 2537, 2012, 2980, 9356, 8107, 3426, 4120, 5267, 4872, 9862, 7684, 5165, 952, 8041, 5034, 982, 544, 1393, 772, 3750, 1529, 9900, 9829, 3221, 4331, 8347, 7767, 5431, 7271, 7012, 1182, 6369, 8526, 7814, 3875, 956, 9018, 3237, 1017, 3669, 4005, 7503, 6888, 3307, 9969, 4958, 7523, 766, 546, 1408, 4143, 9750, 2435, 5754, 7214, 8146, 1488, 2543, 9446, 2714, 5587, 2372, 1261, 5599, 3675, 163, 788, 901, 3854, 976, 1868, 1076, 7444, 1436, 6246, 6503, 2212, 9581, 1257, 6567, 4590, 5684, 5633, 5246, 3113, 5197, 2751, 8780, 8637, 5232, 1583, 5184, 9448, 5173, 9184, 4876, 758, 1597, 1567, 71, 1288, 1334, 9429, 3516, 5753, 993, 9769, 80, 6028, 5548, 1363, 9623, 8114, 8470, 7386, 6374, 3044, 1751, 5139, 1365, 4720, 3466, 1942, 4435, 9608, 8141, 4815, 3291, 8006, 5967, 1201, 9327, 5421, 2399, 7220, 3420, 8520, 8914, 3300, 2001, 6223, 6362, 1425, 5133, 6471, 1658, 4722, 3703, 4497, 8509, 2013, 7086, 8713, 2731, 634, 4158, 8780, 5978, 1554, 6490, 8580, 8406, 1678, 1714, 2518, 9373, 5183, 1473, 1170, 4230, 4609, 6346, 3988, 4133, 4764, 6688, 7953, 7573, 8818, 523, 1912, 6628, 3974, 1064, 7868, 8217, 3670, 7670, 3185, 9292, 4632, 5520, 2056, 6825, 3873, 8831, 148, 3122, 2332, 9208, 862, 1889, 760, 5757, 8235, 4480, 3759, 6711, 5559, 5783, 6066, 2635, 4368, 9541, 8030, 8425, 9733, 834, 718, 9941, 4492, 4624, 7115, 9213, 9891, 3798, 9052, 40, 1888, 6581, 3980, 8077, 6500, 288, 552, 2026, 1156, 8325, 906, 4653, 4542, 718, 6575, 8069, 6977, 5472, 6043, 4632, 7599, 6065, 249, 7960, 943, 279, 9382, 227, 2573, 5572, 7163, 6952, 4029, 7947, 5010, 6440, 3775, 9244, 5631, 2081, 565, 2958, 8454, 7452, 8718, 9931, 2195, 3709, 9306, 8448, 564, 2714, 122, 2177, 3496, 1509, 4211, 7282, 1685, 1855, 652, 6528, 6935, 2077, 8627, 3579, 3692, 5385, 8408, 1666, 3917, 567, 3725, 9708, 616, 587, 6259, 7520, 4720, 7039, 4245, 6493, 2224, 8793, 4583, 4742, 2962, 2094, 1365, 998, 9804, 16, 4201, 8311, 6599, 3814, 5270, 2750, 5882, 3611, 4643, 5516, 5385, 9605, 3362, 243, 8581, 4848, 8459, 6541, 81, 1678, 7451, 5366, 2386, 7192, 2403, 4690, 9730, 3115, 9408, 5826, 3284, 6376, 8175, 2796, 4477, 7065, 6713, 4056, 4242, 7875, 211, 3511, 1973, 3353, 1541, 7005, 4886, 3932, 8627, 8907, 808, 3296, 6616, 1013, 6244, 8885, 3745, 1681, 7094, 6416, 6337, 320, 6595, 6440, 2372, 6257, 1552, 8987, 5589, 8699, 6665, 2312, 6229, 6706, 5351, 832, 8278, 3872, 4354, 3732, 3751, 9436, 791, 5955, 6530, 5168, 6666, 7544, 8189, 1712, 4588, 6824, 7843, 9263, 4707, 771, 460, 4189, 6141, 1853, 2892, 7626, 9486, 3448, 4689, 3622, 3319, 9204, 5566, 8681, 4895, 3806, 7831, 6125, 1936, 7767, 2049, 2914, 7211, 7521, 4103, 377, 4176, 4014, 974, 2087, 8507, 3783, 5982, 297, 1564, 9210, 9126, 3976, 2243, 3261, 7805, 7953, 1105, 7310, 9032, 1019, 6021, 601, 4601, 2707, 6308, 6898, 2940, 2858, 3465, 9803, 5584, 2478, 9055, 4848, 4468, 8787, 7399, 6725, 9890, 922, 739, 4122, 3037, 4057, 1784, 2471, 4231, 9168, 2955, 9353, 2325, 8220, 2060, 1360, 6995, 997, 9985, 9153, 1650, 7721, 5579, 4674, 9933, 1613, 9752, 7567, 2291, 8279, 1713, 1448, 1114, 1132, 9466, 7073, 5937, 9662, 8326, 1039, 2367, 6862, 1811, 262, 2071, 8589, 2957, 1293, 5312, 6041, 2638, 7251, 1653, 2790, 2648, 6945, 277, 9165, 2573, 4715, 9697, 4890, 3441, 7024, 1125, 3926, 783, 6162, 873, 3868, 2041, 3437, 2548, 1966, 6076, 1435, 3174, 6050, 9454, 1252, 9787, 460, 8333, 994, 4676, 1700, 4387, 4860, 948, 6273, 5314, 3942, 6394, 4240, 1010, 6527, 1191, 7038, 5255, 683, 1688, 8561, 2583, 3724, 7426, 3234, 2790, 9423, 1369, 1189, 1796, 3312, 6115, 5828, 84, 8671, 8565, 5339, 401, 5651, 7712, 4463, 6831, 3911, 6444, 8013, 5882, 5032, 7700, 5382, 3946, 2194, 3903, 5169, 4726, 927, 1446, 2346, 8678, 1201, 5493, 2417, 6428, 4071, 9642, 6745, 8754, 5060, 8755, 2074, 9538, 1654, 9213, 5951, 9495, 6148, 2232, 7405, 1519, 9210, 822, 8932, 9057, 8760, 921, 3582, 9746, 9063, 1612, 7403, 9751, 6029, 2523, 3128, 7957, 5351, 6331, 4365, 1393, 2597, 5335, 1250, 7045, 7541, 3855, 6497, 8795, 2755, 5505, 3531, 149, 2152, 5609, 9166, 3670, 5784, 7033, 4504, 8618, 1929, 7440, 3279, 1688, 1801, 5801, 2797, 149, 7526, 5842, 561, 9199, 6250, 2630, 5508, 5916, 7481, 136, 8325, 1078, 4184, 1152, 384, 9394, 1479, 7869, 7176, 6809, 891, 6513, 6022, 5714, 1502, 7757, 9587, 9700, 3324, 5412, 4526, 1709, 5106, 5311, 4182, 3937, 9880, 1759, 5348, 2505, 9279, 2120, 4415, 9250, 6192, 9097, 1545, 3250, 9727, 2904, 3057, 306, 96, 3006, 7996, 5573, 292, 3681, 6403, 9141, 1013, 7496, 8702, 6911, 2317, 1047, 142, 9846, 4756, 6438, 9947, 1312, 4592, 3647, 2613, 3502, 7871, 2129, 6841, 6298, 9764, 7775, 8128, 9993, 5368, 2721, 1904, 4924, 61, 9641, 2863, 3622, 196, 3732, 2501, 6569, 5600, 3864, 2441, 5142, 6258, 4847, 3475, 4248, 8865, 8809, 7012, 8073, 9842, 7887, 1299, 8061, 6092, 8286, 9771, 6724, 1561, 8684, 7317, 4112, 287, 5316, 993, 8676, 7988, 4697, 2026, 2634, 1379, 1596, 4622, 1526, 9904, 9734, 8928, 683, 6691, 2687, 6562, 9654, 6249, 1483, 8381, 8102, 8455, 6324, 1610, 3137, 6432, 8417, 9607, 233, 2407, 1520, 6525, 8815, 9019, 7454, 2103, 4341, 3708, 8471, 3291, 7232, 8090, 8052, 2883, 2268, 3476, 4665, 4342, 9328, 4941, 7861, 311, 3355, 876, 446, 978, 4787, 9668, 9408, 109, 1155, 6116, 2457, 8794, 9028, 200, 1961, 835, 1203, 376, 1704, 1887, 9307, 3957, 3426, 1122, 4535, 5479, 1488, 7100, 9949, 5657, 6681, 6543, 5985, 7231, 937, 5433, 3149, 8088, 8059, 4372, 1453, 4956, 5012, 1580, 1774, 8953, 2173, 5513, 8293, 3933, 8604, 8096, 9683, 4773, 3894, 9633, 8468, 6988, 4065, 9342, 6240, 9498, 6762, 1627, 3006, 6957, 2208, 9651, 3933, 4542, 8142, 6935, 8506, 3233, 2007, 2250, 4124, 9803, 8250, 9296, 4197, 4565, 1212, 3395, 2195, 7591, 8403, 3666, 5736, 2815, 2935, 2334, 8001, 439, 1725, 815, 9599, 9879, 9525, 1742, 9929, 7334, 8332, 8470, 2740, 8941, 3070, 9825, 1819, 230, 2490, 2040, 1513, 2153, 3574, 6683, 1619, 5193, 1113, 6082, 4200, 3336, 8205, 4816, 4407, 608, 4388, 1114, 7018, 597, 6990, 2772, 1144, 5173, 2104, 1412, 8665, 2981, 7232, 2664, 1065, 8551, 2386, 9429, 3943, 7370, 9052, 1421, 3299, 2921, 7105, 5262, 4511, 9932, 3120, 4181, 8774, 5938, 127, 3957, 9869, 3813, 4269, 1806, 9841, 3590, 5954, 2968, 5447, 4752, 9374, 2133, 7164, 7450, 8016, 6925, 3947, 6033, 1256, 9765, 3930, 3822, 5113, 8158, 1469, 1625, 830, 7751, 2770, 761, 3420, 6230, 1160, 5693, 8149, 954, 6746, 9881, 9346, 3682, 3175, 2613, 2433, 3296, 6242, 1792, 837, 6047, 2513, 7946, 5171, 5972, 4467, 8110, 6878, 2044, 6330, 7898, 7644, 8728, 8034, 8078, 7687, 8793, 292, 7061, 3870, 1314, 5927, 4545, 3029, 4407, 9032, 3059, 8941, 8134, 1964, 6972, 7106, 1292, 5463, 8149, 8943, 7447, 3769, 4976, 1425, 3128, 9842, 8348, 8864, 9454, 4924, 1520, 4387, 6975, 1761, 8656, 2880, 4233, 7693, 7742, 486, 24, 9504, 1581, 36, 4983, 676, 8363, 5059, 5835, 2394, 8246, 9595, 1530, 1413, 4785, 2107, 5213, 8841, 1052, 9208, 1036, 484, 6759, 842, 5486, 9371, 9513, 327, 4077, 8560, 4323, 1846, 6211, 2162, 4309, 2110, 1199, 8759, 4279, 8088, 3755, 9906, 595, 5731, 2175, 9159, 8009, 2371, 746, 1152, 8575, 2530, 3867, 4559, 3270, 1365, 3097, 6590, 798, 8111, 507, 6254, 3824, 4953, 1420, 5184, 3426, 9351, 4652, 1576, 3740, 1237, 5831, 1437, 6849, 6578, 8030, 1951, 1570, 3733, 6570, 1735, 687, 1393, 9090, 2917, 4791, 4618, 3693, 6606, 5932, 9617, 18, 7915, 8074, 5757, 9028, 818, 522, 2193, 681, 3068, 2834, 5691, 1503, 7524, 7659, 9903, 4494, 5266, 9659, 1984, 8939, 5996, 263, 1857, 784, 6910, 6673, 942, 3861, 2349, 8771, 878, 6937, 8454, 4954, 609, 5180, 4308, 3386, 9159, 2640, 7219, 8330, 1825, 7756, 5440, 9078, 4197, 7085, 3016, 3433, 7531, 3279, 4393, 8651, 8591, 9141, 3949, 5895, 7995, 8792, 8795, 156, 4931, 8207, 7582, 8859, 2107, 4708, 1084, 3216, 98, 2718, 2075, 2291, 4063, 4149, 7050, 5478, 6337, 4509, 5163, 7875, 8124, 8936, 5926, 7649, 4060, 8425, 7907, 2865, 8740, 8644, 3491, 8297, 6913, 5536, 9358, 494, 1494, 2456, 8132, 4081, 6991, 386, 7670, 8031, 521, 7846, 1249, 1710, 2200, 3582, 4954, 4554, 9974, 6035, 2982, 1516, 5447, 5348, 5134, 8732, 1940, 6872, 4246, 6664, 6546, 2318, 7805, 9461, 504, 3409, 1553, 7856, 6097, 9006, 7523, 607, 4725, 2963, 7507, 4012, 8354, 9594, 3957, 2237, 3926, 4916, 6471, 6465, 4921, 3967, 4221, 1198, 2657, 77, 1599, 8440, 6344, 793, 7416, 7599, 4817, 1993, 7734, 455, 8143, 7226, 4490, 8301, 7416, 779, 4503, 8116, 4106, 8348, 1814, 6253, 107, 6268, 9920, 3283, 2386, 8553, 9125, 1558, 4254, 4722, 9956, 7740, 6426, 411, 1685, 3833, 4260, 5939, 8178, 7152, 3394, 6226, 687, 4002, 3856, 3265, 8645, 4036, 6702, 6323, 3739, 2823, 2100, 8939, 2219, 6574, 9697, 681, 9759, 8757, 5066, 27, 4595, 5633, 3760, 3497, 1242, 5169, 3303, 4888, 7093, 7552, 4877, 6350, 6872, 6976, 6732, 7123, 8775, 930, 4994, 6269, 7918, 3381, 1437, 6605, 5604, 2242, 9329, 6363, 7735, 8749, 4085, 3831, 8843, 8029, 9891, 2436, 9859, 3421, 9874, 1923, 5525, 5538, 7515, 817, 1389, 1623, 2311, 8669, 9914, 3457, 2999, 3097, 3954, 2057, 1040, 4418, 4918, 5423, 8901, 7392, 4233, 6536, 1451, 3793, 2750, 7883, 3325, 5514, 8669, 7462, 1477, 5623, 3996, 4192, 7213, 1791, 1977, 9374, 2124, 4221, 1291, 403, 4605, 1963, 4750, 5164, 6604, 8996, 4650, 6194, 8373, 5922, 9764, 2836, 8883, 1929, 4779, 7789, 4911, 1282, 4156, 5271, 2138, 4298, 3160, 987, 7678, 8914, 4786, 2570, 6874, 4183, 6644, 7967, 1641, 7737, 5835, 9924, 3415, 5372, 5851, 9862, 1887, 5982, 1712, 5224, 3124, 7467, 2030, 3115, 5664, 5664, 841, 2703, 924, 5032, 245, 8439, 6278, 6522, 4864, 2741, 2, 8485, 8784, 3693, 7119, 1208, 7414, 211, 4470, 6900, 2236, 4258, 9562, 7845, 5273, 2831, 4419, 8823, 848, 1284, 8716, 325, 3965, 5879, 4721, 6276, 2457, 2890, 4066, 3209, 6049, 8403, 340, 127, 1744, 7008, 7116, 4205, 4598, 4220, 985, 689, 5924, 3714, 5193, 3389, 6704, 7195, 3198, 6831, 8422, 3561, 6513, 6078, 2122, 4628, 4399, 2497, 3497, 4502, 918, 3582, 4586, 8918, 5937, 5187, 2035, 6304, 9769, 5547, 5235, 7848, 9372, 8113, 5913, 2171, 3285, 4914, 9369, 6820, 5023, 623, 1641, 4086, 2530, 844, 7967, 8569, 7465, 1293, 1693, 3694, 699, 5958, 3431, 9931, 767, 3701, 8430, 3199, 2771, 9761, 8250, 2862, 9590, 3104, 1280, 2854, 8857, 6853, 1593, 878, 2292, 7402, 7874, 5456, 8914, 3825, 7459, 7424, 5540, 7990, 9809, 5777, 5027, 9438, 2458, 8859, 7807, 1025, 8954, 7683, 6728, 9940, 1923, 2026, 3901, 9786, 8851, 239, 4017, 5357, 5810, 8442, 9096, 9061, 4869, 3249, 1651, 2685, 6916, 1584, 4626, 617, 8940, 4956, 3968, 4027, 5274, 3442, 8991, 5218, 8072, 4693, 4184, 7286, 1305, 8338, 6734, 9975, 4082, 9523, 8788, 1988, 400, 1939, 4168, 5520, 4163, 7161, 7256, 8891, 4935, 5303, 216, 1668, 876, 7517, 8479, 8102, 4446, 9511, 6955, 6296, 5645, 3108, 5582, 3574, 647, 5703, 241, 629, 1925, 5589, 8372, 1126, 3206, 955, 162, 4623, 1698, 6853, 9407, 7767, 8133, 1961, 2373, 3605, 4089, 4554, 5526, 5564, 2196, 1221, 1116, 961, 7967, 4223, 7906, 9252, 9443, 4559, 4848, 5474, 6504, 8826, 7488, 8271, 9174, 2988, 657, 8063, 2662, 3399, 7961, 5187, 2328, 6115, 4240, 9557, 5330, 319, 899, 6382, 5791, 9637, 216, 2798, 3253, 7193, 701, 5454, 8683, 2848, 9181, 4367, 9355, 6228, 38, 508, 6770, 1854, 9027, 2288, 813, 4849, 7068, 9935, 4173, 6767, 4109, 3476, 6987, 2045, 7035, 2907, 3786, 3266, 4368, 2966, 2484, 9928, 8966, 7501, 3351, 3354, 9498, 42, 8345, 912, 7323, 2753, 71, 7374, 4992, 9554, 7972, 7694, 6580, 9332, 3286, 7039, 8989, 4013, 2134, 320, 6926, 738, 5007, 3383, 9097, 2405, 9861, 9195, 8569, 7925, 6227, 1445, 2149, 1961, 3077, 8618, 9740, 1961, 3667, 2699, 8361, 5223, 2288, 5034, 2686, 8050, 7901, 6507, 6465, 1524, 7940, 598, 9762, 5296, 1750, 1409, 977, 7400, 7948, 1346, 695, 5929, 2653, 5740, 2639, 4775, 4598, 2172, 5735, 1439, 6227, 6100, 5482, 4543, 4889, 1752, 63, 7352, 2983, 6605, 9852, 7961, 820, 8464, 9757, 1856, 8551, 4826, 9105, 7777, 2623, 4995, 9317, 7725, 285, 2851, 9842, 7442, 8028, 6001, 4491, 9113, 4560, 3127, 5816, 696, 9855, 4171, 2218, 1748, 2934, 5102, 4243, 2999, 4915, 8429, 8237, 5987, 4240, 1822, 1170, 5169, 6969, 5893, 9736, 4921, 1356, 5522, 2898, 2331, 9701, 1966, 4459, 7191, 6704, 1479, 896, 5572, 8012, 3944, 9681, 8410, 3435, 9477, 5631, 8758, 990, 4331, 8970, 8394, 5743, 7338, 447, 3743, 4324, 7263, 9735, 6725, 4354, 861, 9786, 1508, 5374, 8783, 8036, 176, 5715, 2593, 5186, 4567, 4905, 9806, 6959, 6139, 1822, 2639, 8348, 5740, 9510, 8485, 4034, 526, 9279, 9086, 8851, 4472, 1143, 3396, 2322, 5691, 5435, 9231, 790, 9181, 5899, 5157, 8546, 2054, 8185, 7428, 1780, 5786, 6065, 6954, 5879, 8946, 1703, 7068, 1311, 6565, 6815, 7179, 7052, 1599, 6248, 4554, 5823, 109, 6029, 5579, 8383, 1895, 7078, 523, 2314, 9159, 6088, 7800, 6102, 3697, 8378, 2286, 4231, 3461, 2487, 4391, 7933, 4732, 8306, 200, 4878, 2835, 3440, 8284, 2150, 3854, 1693, 6681, 8518, 5369, 2653, 6423, 8493, 4353, 1259, 3398, 4424, 9360, 5212, 3191, 8504, 192, 8982, 4868, 7577, 1193, 2917, 7792, 9629, 1292, 3158, 6941, 9998, 3246, 9217, 6531, 6338, 9903, 5540, 658, 8532, 4948, 1072, 2662, 195, 2755, 6006, 8621, 4540, 6900, 8921, 2142, 551, 9642, 9807, 3628, 3647, 6931, 1132, 3391, 3030, 4135, 8877, 3591, 1796, 2375, 9747, 8201, 5259, 1770, 5089, 4075, 8376, 3000, 6343, 1835, 603, 3059, 5841, 680, 9240, 2321, 307, 6392, 440, 1564, 6305, 1277, 9272, 1480, 5240, 2810, 9302, 2196, 713, 4891, 2093, 6290, 2734, 6977, 1629, 365, 6692, 7181, 2702, 7787, 2908, 8044, 7798, 2618, 2914, 3151, 3561, 6504, 5035, 631, 2731, 9093, 2143, 9581, 8974, 7853, 1313, 9076, 4153, 9366, 8827, 8728, 8960, 4822, 8908, 1035, 4515, 2925, 3910, 170, 4216, 7254, 8720, 7435, 5758, 7858, 243, 3662, 4627, 370, 8769, 3914, 2784, 4585, 1953, 6552, 6653, 2172, 7196, 5039, 8477, 6802, 61, 2019, 244, 8715, 2175, 3036, 1788, 3826, 4600, 7099, 6080, 3181, 1104, 5374, 5710, 9518, 68, 7604, 3263, 997, 2604, 9314, 1823, 4253, 9425, 237, 6436, 4162, 6228, 4135, 1893, 6496, 4254, 2196, 7579, 227, 252, 340, 9207, 6476, 1157, 6128, 1393, 193, 404, 5947, 7587, 81, 7404, 9236, 8209, 5919, 2100, 9960, 2652, 1981, 2340, 5928, 5722, 416, 134, 4043, 3733, 4332, 1963, 2396, 7239, 5885, 1810, 2559, 5601, 4807, 9016, 3037, 7513, 9608, 6651, 9457, 9059, 7418, 8393, 5067, 8116, 2714, 8895, 7282, 5027, 1814, 5910, 1495, 1618, 5381, 1388, 7367, 4689, 268, 5290, 1956, 2030, 8556, 295, 3521, 6073, 5010, 9327, 2500, 3545, 2254, 6757, 3553, 7388, 4876, 768, 6004, 9156, 9895, 4742, 8804, 813, 5111, 1132, 7356, 5256, 5037, 8193, 1462, 2802, 5720, 1710, 1023, 3558, 8075, 3068, 5523, 7671, 2721, 7824, 3906, 7339, 3526, 4376, 8090, 2284, 6409, 8473, 4324, 5492, 1801, 3703, 4457, 4951, 6373, 2872, 1048, 5491, 1370, 2945, 5272, 4322, 7785, 6190, 2026, 8308, 1328, 2016, 8974, 1779, 2543, 6436, 5925, 5269, 6371, 8766, 2014, 7356, 7655, 5730, 9550, 117, 6768, 9539, 2560, 6300, 9027, 7706, 2350, 5139, 5084, 1144, 7508, 1727, 1046, 8783, 2560, 4325, 1496, 8230, 1692, 6693, 446, 38, 905, 5115, 8107, 6771, 9201, 6995, 3414, 4663, 2032, 9205, 3080, 239, 2532, 63, 7550, 3180, 4515, 3014, 2960, 4106, 3451, 212, 6225, 29, 3631, 6843, 682, 9745, 2739, 9916, 3026, 2263, 4535, 1141, 3197, 2407, 9328, 2849, 5903, 1042, 3578, 3533, 297, 7725, 7798, 2472, 4831, 9937, 5609, 7907, 2778, 8488, 9268, 250, 6813, 4633, 3148, 5502, 1091, 8662, 818, 2585, 6305, 7571, 8700, 1185, 6698, 1036, 2619, 4589, 857, 6454, 904, 2526, 4796, 9526, 1787, 5035, 8320, 7684, 3904, 1262, 6185, 1277, 2025, 6743, 664, 2463, 3162, 3323, 2318, 2283, 4466, 8881, 8187, 5361, 7603, 3011, 7941, 1925, 8855, 3735, 3464, 8430, 8182, 6179, 352, 8812, 4530, 8036, 5022, 2974, 9086, 1832, 8802, 4119, 420, 3868, 2266, 3363, 1418, 9018, 2598, 1385, 584, 1772, 9173, 6144, 506, 8349, 4493, 9177, 4107, 9929, 8405, 5617, 5291, 6295, 9879, 8297, 7431, 3095, 8985, 124, 6117, 678, 4885, 8997, 8832, 4004, 4845, 6193, 6391, 8317, 704, 5544, 168, 6811, 382, 8688, 2942, 9960, 271, 8292, 1250, 3010, 4521, 7508, 8278, 4315, 950, 4269, 1915, 721, 3372, 6304, 5505, 9929, 3985, 7292, 362, 5884, 1489, 5145, 9817, 4637, 6554, 3705, 160, 9417, 4518, 6266, 9150, 8487, 7737, 7593, 7791, 456, 4405, 2721, 5705, 8307, 738, 574, 1507, 1763, 7699, 305, 4805, 8929, 5261, 6523, 9323, 4375, 785, 3596, 2521, 2037, 9414, 7369, 7368, 3570, 8163, 4444, 5642, 4993, 8832, 5167, 6568, 8249, 8952, 2060, 7507, 8452, 2321, 693, 9979, 2718, 3626, 7291, 9945, 4284, 5344, 7117, 9571, 7689, 8393, 110, 5041, 6935, 152, 4406, 5517, 3948, 5859, 3036, 3278, 293, 8694, 9282, 6305, 8219, 321, 4374, 5386, 8938, 4763, 3453, 2979, 7058, 7651, 3953, 3869, 7530, 5551, 8156, 9008, 3997, 8666, 8450, 477, 2106, 9265, 1154, 3071, 9944, 3352, 4634, 3063, 5593, 5048, 8406, 3229, 4869, 7947, 2982, 4871, 9855, 5492, 5443, 5913, 3963, 3462, 5695, 7568, 2208, 5100, 8179, 3819, 3054, 4110, 2815, 1080, 6736, 9753, 7074, 9059, 82, 5344, 684, 238, 6029, 3639, 7201, 222, 4496, 6738, 8773, 2415, 6517, 3529, 3144, 2031, 2517, 8411, 3315, 7025, 3387, 6622, 8467, 1776, 7681, 4977, 4514, 8171, 562, 4116, 1998, 6944, 8007, 7744, 3995, 5712, 3345, 5589, 2470, 4007, 7310, 798, 2691, 9898, 7851, 2089, 3306, 62, 8669, 1043, 8318, 2518, 5610, 1642, 4589, 6518, 9624, 8278, 6735, 3658, 5966, 1423, 4593, 4622, 5069, 5184, 9372, 632, 481, 4325, 4943, 9143, 2992, 5223, 2598, 3127, 9563, 2553, 3332, 411, 2642, 5261, 3863, 6029, 4437, 5877, 6259, 5063, 1569, 7058, 1454, 4318, 5160, 2238, 5514, 7722, 9485, 3408, 970, 8445, 8813, 3739, 5730, 6679, 6152, 8838, 895, 2159, 1037, 7264, 6755, 7397, 8905, 7939, 4690, 492, 843, 1151, 5898, 4428, 2215, 6276, 1601, 5095, 7835, 3344, 9829, 3314, 6048, 8957, 4595, 3393, 6980, 424, 1974, 688, 5393, 6136, 4202, 3151, 6560, 6690, 925, 4422, 691, 5140, 5995, 9620, 1888, 6315, 3223, 6916, 5401, 6950, 4998, 3937, 7842, 649, 6268, 5828, 9157, 5351, 562, 828, 8969, 10, 5328, 3500, 1246, 6749, 7505, 8700, 5634, 5670, 1623, 4861, 6554, 3761, 1920, 8811, 6944, 5987, 5540, 6621, 3719, 3004, 4594, 1751, 1698, 6102, 711, 9681, 2243, 6128, 3963, 9687, 759, 6988, 5653, 2942, 3184, 3161, 1524, 5823, 1891, 791, 1089, 7327, 8904, 5765, 4440, 9019, 4083, 6904, 3908, 8655, 2209, 1203, 8803, 3924, 9282, 5199, 2575, 3993, 9176, 6027, 7955, 1257, 8628, 859, 1481, 5512, 5407, 1211, 8326, 2650, 6934, 5105, 135, 2540, 1973, 9797, 2678, 2325, 3970, 1511, 8799, 7983, 9689, 1047, 7120, 2623, 6158, 306, 2423, 1144, 4179, 5527, 9444, 4507, 7358, 5414, 2004, 4719, 2519, 1742, 271, 9600, 8857, 8849, 2042, 9303, 9002, 92, 8923, 4471, 6912, 2801, 5896, 4755, 9219, 9954, 6252, 3233, 6752, 2184, 2799, 6399, 2007, 4824, 1641, 3100, 6210, 5950, 8626, 8117, 8530, 1626, 2451, 3873, 4885, 7126, 8046, 2666, 1193, 7375, 1774, 5527, 364, 2842, 8090, 3515, 9126, 5994, 8667, 2230, 31, 2274, 5450, 8393, 1259, 2647, 7635, 4027, 721, 9846, 6534, 5296, 63, 4361, 589, 361, 9019, 6981, 9487, 9703, 3140, 1482, 4224, 8214, 3851, 182, 2138, 5328, 1459, 5968, 7256, 4873, 4437, 8407, 2527, 3678, 2692, 1381, 9747, 5913, 1438, 5344, 940, 9760, 5384, 8951, 1904, 6698, 9204, 9858, 9671, 2641, 6865, 3009, 1321, 953, 4077, 1360, 4215, 5085, 8905, 4440, 988, 6842, 6122, 7831, 8802, 7477, 7473, 2379, 1229, 453, 3236, 4374, 1631, 3867, 1307, 123, 6352, 3460, 7080, 4124, 3606, 5545, 3118, 7640, 7212, 8867, 6578, 2616, 1019, 8163, 1476, 1205, 9382, 4739, 9032, 8906, 7936, 4598, 5349, 1840, 8586, 9362, 8516, 841, 6437, 4832, 2662, 4024, 403, 3315, 462, 9926, 2331, 3013, 1706, 6066, 317, 8223, 5415, 2833, 8084, 78, 5862, 5254, 294, 9255, 3149, 9127, 4438, 5675, 5893, 2719, 8046, 2762, 4388, 2912, 2630, 6102, 7857, 3284, 4809, 2850, 3661, 3575, 6364, 9789, 4996, 9046, 3160, 5365, 8354, 7085, 9924, 6199, 6343, 4063, 5071, 3870, 2959, 5332, 3666, 6328, 7812, 6252, 3224, 1903, 5862, 4706, 4595, 8622, 9479, 1449, 8636, 5030, 8773, 7170, 6942, 4699, 2292, 5998, 9459, 5177, 6059, 1537, 8093, 9590, 5988, 2978, 9883, 2037, 8162, 410, 1698, 6270, 434, 2934, 8262, 9938, 8880, 854, 5694, 1300, 8084, 4699, 1347, 3065, 9206, 5360, 888, 8457, 6889, 4399, 7747, 6322, 1813, 9721, 8904, 8421, 3161, 5353, 7378, 9751, 7761, 4245, 7544, 3714, 2410, 5321, 3686, 6861, 8922, 151, 1217, 483, 5000, 7053, 2991, 1839, 916, 2608, 2373, 1531, 2421, 9767, 676, 6167, 4564, 2192, 8273, 1081, 4234, 3048, 4789, 9612, 6556, 1876, 2474, 1812, 5664, 4825, 5351, 9816, 3052, 1206, 4041, 6353, 8389, 5100, 9341, 8263, 9735, 8849, 1399, 9750, 1538, 8762, 1762, 529, 8968, 451, 3646, 9852, 5638, 9534, 1783, 1787, 3683, 515, 6680, 1343, 5142, 5128, 1361, 3935, 433, 2093, 5666, 5671, 9554, 2370, 1466, 1875, 7695, 2448, 7905, 8956, 4141, 9599, 577, 9146, 3700, 2041, 4051, 1185, 9582, 5538, 9059, 2836, 2982, 4151, 818, 4059, 8532, 2681, 3454, 8763, 8667, 558, 5757, 2671, 6858, 7746, 7706, 4266, 8537, 7121, 1678, 5292, 2980, 3374, 26, 1867, 1123, 5883, 5796, 5461, 5546, 9284, 800, 7241, 5845, 6730, 4590, 2820, 3909, 5525, 8839, 9389, 2848, 7576, 2432, 5788, 6426, 5072, 6813, 4778, 3955, 2702, 8600, 5106, 6441, 8349, 3391, 6209, 9305, 4778, 9524, 1648, 7485, 8236, 54, 6137, 5657, 4497, 6238, 4468, 88, 3021, 9231, 7416, 3143, 6832, 3836, 3739, 891, 8378, 3012, 8297, 2618, 8200, 7487, 44, 3723, 2605, 7643, 9177, 1749, 7486, 1528, 9237, 351, 6932, 6661, 2969, 5470, 6374, 2460, 4269, 8552, 1556, 9055, 1689, 970, 9104, 1225, 3545, 5167, 8097, 4690, 351, 1072, 6916, 7379, 5478, 8463, 352, 5074, 8848, 83, 549, 1105, 5827, 3917, 736, 2844, 5880, 5481, 359, 8904, 7056, 6510, 5384, 5459, 3303, 7475, 7266, 136, 9920, 2302, 6559, 5713, 1574, 8978, 3064, 5185, 263, 491, 6796, 1221, 3592, 1461, 2339, 7074, 2853, 7502, 476, 7775, 4650, 3611, 6062, 3751, 6132, 2788, 5904, 1489, 9093, 6497, 4751, 815, 3935, 9199, 7174, 9355, 644, 2500, 7532, 5430, 6472, 2743, 7455, 7447, 2575, 8515, 6131, 4448, 8661, 5348, 9634, 2263, 6035, 6933, 5707, 6357, 1935, 5564, 4439, 9361, 1962, 1117, 2235, 6940, 85, 7340, 1317, 4407, 6673, 4974, 2660, 4066, 5385, 9576, 6680, 8714, 5223, 459, 9827, 2826, 6304, 2214, 4584, 3221, 9334, 3585, 973, 7108, 8520, 2437, 6510, 4879, 4004, 9068, 7007, 9268, 5135, 1248, 1282, 3085, 3804, 1852, 3733, 5709, 6673, 6272, 5588, 1994, 8582, 2180, 7134, 8216, 6630, 2369, 2738, 3411, 8795, 8947, 5814, 6857, 5048, 8380, 3849, 3524, 6369, 3932, 8249, 2834, 9128, 4934, 7632, 7719, 8281, 6703, 6748, 9743, 7196, 2573, 9635, 1598, 1157, 1351, 5419, 5200, 4825, 2537, 9966, 7113, 6105, 355, 2408, 1780, 2013, 4150, 8350, 9699, 1704, 3551, 5169, 3710, 3727, 8433, 5229, 8237, 5449, 2950, 5549, 7326, 7714, 1870, 6630, 4213, 4751, 6615, 6175, 8988, 7582, 2446, 5709, 8756, 9038, 9310, 1162, 1695, 4999, 5305, 1953, 4205, 9647, 5642, 5781, 6800, 9373, 6046, 2310, 4627, 5652, 1494, 5830, 8044, 8161, 4063, 1731, 4084, 6954, 4150, 9606, 3413, 4692, 667, 9380, 3022, 1398, 6351, 9570, 7197, 7038, 5806, 4626, 7885, 2109, 3101, 9040, 6912, 9510, 4368, 4789, 8133, 8076, 4986, 5971, 7514, 8138, 2392, 82, 3589, 1903, 7664, 8123, 6296, 5252, 7485, 6987, 9382, 377, 3329, 7720, 7779, 6563, 5030, 830, 1699, 8591, 9114, 4003, 5599, 5255, 9940, 4168, 8066, 3288, 1347, 6488, 700, 7824, 467, 7859, 4052, 7741, 4188, 5666, 2131, 6872, 5604, 1070, 9584, 1563, 6881, 7847, 3771, 8995, 5093, 3304, 3796, 4777, 8013, 5797, 8710, 6915, 1232, 3643, 8266, 4048, 9119, 7219, 1775, 4931, 6091, 4978, 509, 5413, 9134, 9893, 6265, 5089, 2691, 8557, 5975, 453, 2893, 9944, 3675, 9565, 9152, 4189, 9517, 6651, 1620, 8178, 8300, 8798, 1367, 649, 9997, 4808, 4846, 6903, 9551, 7678, 2707, 5610, 5470, 8657, 4212, 5609, 1193, 8893, 2348, 6625, 5328, 6900, 599, 5113, 6876, 3515, 6812, 6764, 6978, 9734, 5089, 3549, 8437, 3573, 2881, 8457, 134, 1588, 6574, 9500, 97, 4106, 6520, 6898, 5661, 7644, 1640, 4936, 8480, 3737, 1880, 3184, 7795, 5698, 8790, 2957, 550, 2964, 7705, 3203, 5590, 4880, 2689, 2881, 6686, 1242, 2509, 9057, 846, 9327, 3479, 3375, 3813, 9233, 6011, 736, 1883, 774, 5392, 9095, 6485, 7168, 5608, 6212, 8049, 6012, 6706, 2280, 1167, 178, 4174, 8135, 6370, 7218, 2919, 7018, 5363, 7253, 3863, 4031, 6143, 3126, 565, 7414, 4380, 1641, 5031, 3337, 9008, 7848, 7154, 2911, 581, 2870, 3364, 23, 2762, 3272, 7725, 1142, 1212, 1795, 1700, 4050, 5868, 7077, 8791, 1291, 6326, 7869, 3579, 961, 108, 4509, 752, 809, 4661, 8349, 7163, 7775, 1525, 5102, 4295, 9756, 3984, 6932, 4822, 9382, 5168, 1569, 4894, 3985, 6327, 8559, 2055, 211, 889, 5232, 3632, 3114, 9063, 6135, 7939, 7148, 9970, 2093, 2446, 6494, 5579, 1580, 3208, 2765, 3755, 4831, 3700, 3372, 9615, 7659, 303, 2180, 3454, 3830, 3220, 1247, 4475, 2885, 6584, 9781, 8513, 2176, 2, 3625, 9253, 6295, 8315, 1380, 8981, 8187, 43, 5846, 6795, 9188, 6310, 4815, 5637, 3551, 6886, 7784, 2667, 538, 8016, 9775, 7581, 8316, 380, 2953, 3699, 647, 9390, 3481, 9078, 2834, 8765, 4439, 6150, 2875, 8395, 3103, 4246, 2244, 285, 3947, 9228, 235, 8570, 832, 1438, 5634, 2285, 9968, 6829, 5875, 5393, 8297, 5172, 9977, 5024, 835, 22, 3770, 5647, 9373, 2843, 5603, 8476, 3894, 7551, 238, 5707, 8371, 1452, 4047, 5491, 7520, 1915, 4163, 4125, 2042, 3924, 7595, 273, 2323, 5357, 827, 5987, 1974, 8738, 9712, 7117, 6762, 3041, 7948, 1734, 65, 5973, 1865, 5752, 6227, 1154, 5315, 9385, 1148, 6733, 6540, 9167, 7925, 682, 8219, 9569, 9043, 9530, 5127, 86, 3660, 8260, 6564, 1388, 1582, 5009, 1289, 2175, 9282, 8080, 733, 6308, 3263, 5559, 4226, 3239, 8338, 8662, 9806, 8909, 8496, 8494, 7666, 9352, 8481, 2678, 2884, 4697, 9670, 5876, 7329, 5803, 3367, 2942, 4532, 1258, 8761, 9524, 7266, 6844, 8834, 7525, 3740, 2185, 6219, 5679, 9192, 3766, 4671, 2633, 1648, 539, 7534, 7608, 9550, 425, 8867, 1269, 6136, 7844, 6586, 6313, 3167, 5726, 1003, 233, 5001, 6525, 9342, 6295, 2603, 9956, 4290, 2184, 5009, 1068, 7992, 6819, 1415, 2541, 242, 3887, 2055, 231, 8591, 4729, 4308, 4367, 62, 2704, 1300, 2745, 9810, 6205, 7102, 5026, 5214, 6947, 7544, 7225, 7460, 6454, 7864, 1254, 2380, 9930, 2217, 1156, 7560, 9042, 5136, 6974, 430, 4776, 4091, 2981, 8317, 4008, 5664, 994, 2878, 4029, 8452, 2769, 4276, 2887, 7562, 811, 9778, 7342, 1066, 777, 1489, 2708, 6270, 5592, 157, 3028, 5723, 6798, 9372, 8170, 4949, 7577, 2923, 6788, 2393, 8100, 7380, 9468, 9936, 9965, 2823, 9504, 1869, 3481, 3110, 3947, 1918, 806, 2575, 1340, 8188, 9186, 9673, 2172, 4445, 2791, 6309, 9222, 1878, 1197, 705, 8487, 4046, 9402, 7100, 3891, 9955, 226, 6970, 7462, 4025, 745, 2692, 1730, 5911, 9293, 9669, 9937, 5600, 4008, 562, 6484, 4202, 7680, 6768, 9722, 6963, 7268, 746, 9282, 6249, 6731, 1249, 2904, 4633, 5348, 4751, 5673, 7252, 5980, 2366, 1736, 3268, 2327, 9125, 3880, 1004, 5733, 7683, 3923, 298, 4393, 1725, 1836, 89, 9501, 4587, 5399, 7496, 4219, 1997, 3889, 9923, 632, 8988, 520, 5766, 8417, 9959, 3908, 3354, 2079, 4549, 6912, 2933, 2883, 5358, 5631, 6039, 2880, 3811, 1428, 9621, 5384, 5954, 5648, 9399, 4504, 9850, 1980, 1322, 4634, 1993, 6537, 7706, 5531, 4186, 5359, 3749, 6902, 358, 6840, 3387, 3933, 616, 9806, 1972, 64, 7788, 7713, 1676, 8319, 6774, 7101, 2468, 4354, 8322, 7574, 204, 9609, 7944, 9750, 5392, 3376, 1651, 2106, 8763, 9739, 9360, 4994, 4398, 4111, 3296, 7408, 2873, 913, 7462, 8289, 1443, 9886, 345, 5997, 8088, 9698, 6008, 5737, 2486, 1621, 1192, 8661, 9220, 7122, 3808, 8148, 1928, 3390, 4304, 2404, 1849, 100, 2238, 6009, 4092, 2347, 2148, 4513, 4728, 2158, 2854, 4921, 5002, 2796, 8895, 5486, 3350, 1030, 4744, 5168, 1346, 5199, 1177, 2858, 4076, 2368, 2628, 8734, 3056, 2653, 1590, 9861, 718, 5434, 2164, 9703, 9686, 4478, 6263, 824, 3900, 4666, 5004, 309, 8198, 355, 8055, 3906, 1634, 5088, 3335, 7073, 3272, 6150, 9248, 9449, 9128, 9498, 1066, 99, 8713, 8486, 1160, 5727, 128, 8204, 7464, 5013, 6180, 8317, 3493, 431, 3917, 58, 1176, 2163, 4585, 3681, 9511, 2049, 7775, 4015, 4801, 5967, 9352, 973, 4222, 5009, 7590, 8494, 3192, 6428, 2749, 2161, 9181, 3509, 6457, 6015, 8154, 3032, 8007, 144, 8087, 8707, 2540, 8937, 6173, 7467, 2984, 9208, 1414, 8402, 8890, 5730, 3076, 2691, 6388, 1247, 9769, 5114, 4893, 8895, 4333, 2121, 830, 2116, 7872, 7456, 6573, 2, 7475, 36, 8660, 1516, 1568, 5557, 9851, 4145, 1699, 4186, 2401, 2549, 2852, 7313, 7090, 2918, 1848, 9429, 6156, 5096, 5588, 1007, 4252, 7143, 5650, 3198, 6712, 5419, 4674, 7629, 9582, 7621, 6904, 3143, 9597, 2103, 1933, 6102, 1005, 7938, 5527, 2897, 3282, 9069, 2126, 60, 4516, 9474, 8334, 6057, 598, 6086, 8932, 641, 1356, 4306, 9941, 8471, 9113, 4068, 5006, 7881, 9213, 8925, 5674, 5905, 8558, 1990, 4447, 89, 312, 5688, 4663, 8334, 3080, 2046, 8284, 1679, 5115, 1431, 2785, 1071, 3052, 942, 8164, 1118, 9239, 3223, 2958, 8007, 6283, 8117, 6927, 9651, 754, 7308, 5683, 2397, 2721, 132, 8481, 5285, 3037, 3311, 1923, 3339, 5699, 4078, 9516, 9586, 2307, 2239, 804, 3353, 3407, 9699, 2713, 840, 1362, 4483, 8466, 9843, 450, 3368, 7421, 2975, 8418, 7649, 2646, 7396, 5636, 4901, 9427, 5269, 6150, 831, 2805, 2764, 8369, 9967, 9011, 7004, 248, 623, 6487, 395, 1690, 1401, 8695, 3739, 6008, 2919, 2770, 8747, 2646, 1323, 3681, 598, 8586, 6113, 3505, 6191, 5069, 8111, 9065, 4675, 7405, 6635, 9215, 4908, 5908, 7095, 1257, 9720, 9641, 6748, 7676, 7400, 2213, 797, 5795, 870, 8932, 243, 8692, 1717, 4031, 3666, 3499, 4235, 9292, 9435, 6962, 2020, 1470, 2330, 6787, 7997, 6935, 3831, 5892, 3096, 4347, 9417, 1537, 4036, 864, 3291, 2822, 3276, 8233, 1249, 9227, 3544, 3401, 7255, 2871, 9809, 2993, 302, 4482, 6093, 9322, 1137, 9469, 7676, 8723, 2113, 3256, 263, 7118, 6245, 1291, 2755, 1615, 887, 1691, 8209, 5919, 2097, 601, 5271, 8975, 4070, 968, 8953, 1429, 6726, 258, 1156, 8473, 799, 6320, 3180, 3458, 2863, 7520, 1310, 5616, 4533, 1009, 8631, 5973, 3455, 7873, 8048, 8930, 6035, 7738, 7153, 6071, 3103, 5321, 4319, 6815, 4421, 8754, 7030, 3950, 2274, 5111, 391, 2853, 8015, 7815, 1493, 829, 2334, 4378, 227, 6472, 3959, 2471, 5275, 7616, 9342, 5305, 3833, 7726, 9122, 7284, 5064, 3477, 2207, 3178, 3622, 7408, 9999, 8499, 4587, 2736, 2043, 6211, 7318, 9934, 8394, 4223, 6857, 8463, 1190, 6141, 3856, 6698, 2209, 4619, 9165, 8043, 6084, 2659, 53, 1553, 395, 9265, 3138, 4448, 4192, 3595, 9736, 8665, 4747, 7965, 9800, 6353, 4236, 6198, 9854, 7626, 7467, 857, 2801, 2552, 6267, 7131, 6112, 9601, 9232, 6949, 9352, 2917, 2997, 9672, 8008, 5448, 8909, 8309, 3272, 3069, 7180, 6740, 4869, 4346, 4349, 262, 349, 9157, 2126, 1109, 4135, 4928, 1207, 3209, 9093, 7227, 1486, 3415, 4012, 532, 8258, 2395, 7860, 8506, 8259, 3352, 9504, 1863, 7829, 5819, 5971, 9463, 6022, 9560, 5585, 7021, 8620, 8587, 162, 5242, 7591, 4572, 9126, 4028, 2231, 2330, 6308, 4538, 4500, 8238, 8779, 4743, 4837, 9957, 7267, 5024, 4827, 6431, 2650, 3592, 4248, 2396, 9753, 9187, 9012, 8114, 5082, 339, 1552, 4292, 7526, 7676, 5092, 4442, 8389, 2126, 6396, 1098, 7559, 501, 6739, 7064, 2046, 995, 9562, 4740, 2617, 7844, 3043, 85, 6194, 7935, 7696, 8553, 7445, 1892, 958, 7604, 7885, 9905, 2992, 3338, 3725, 3712, 8142, 4119, 6849, 8200, 372, 4194, 4418, 846, 1062, 8562, 1301, 118, 1438, 3849, 9332, 3111, 428, 7665, 5254, 7536, 7904, 7196, 7993, 9014, 393, 776, 1284, 6624, 1602, 189, 4404, 6617, 9436, 5897, 9437, 4842, 5444, 6680, 1244, 3536, 9545, 359, 8597, 5251, 182, 5243, 7978, 953, 5813, 6757, 2987, 7862, 5891, 6323, 3384, 9107, 9988, 245, 8155, 5500, 5069, 9184, 4192, 3230, 2565, 6299, 9083, 3956, 8840, 5641, 3198, 7071, 910, 3241, 7629, 9786, 3189, 471, 7640, 9067, 2565, 3387, 7032, 6667, 7266, 8362, 6607, 5344, 7787, 4891, 4887, 9603, 9385, 2797, 8127, 5322, 1699, 8566, 2089, 5255, 5140, 9968, 1479, 4165, 357, 670, 6124, 6058, 764, 1081, 7713, 6089, 9262, 4613, 4360, 4002, 978, 8164, 6879, 4311, 8349, 4835, 6270, 6341, 3069, 3987, 315, 3830, 4594, 2530, 4659, 7589, 740, 5487, 4712, 6631, 3515, 466, 5714, 1596, 7022, 6533, 1467, 9176, 4553, 2435, 3849, 5774, 9395, 9867, 9109, 3367, 7996, 4058, 3780, 1453, 4307, 8179, 8935, 7708, 8060, 1386, 5309, 1368, 3331, 6197, 5464, 1406, 667, 1404, 7992, 53, 6650, 6802, 2807, 7058, 7804, 157, 894, 4488, 6423, 3104, 4789, 9054, 7345, 6770, 5877, 5775, 1603, 6099, 3322, 2539, 7253, 8267, 8116, 2088, 6106, 9539, 4268, 5528, 1008, 5868, 6337, 1564, 6833, 3087, 93, 9578, 3639, 8681, 3233, 7695, 9334, 5286, 9066, 1383, 2984, 8247, 8209, 9113, 727, 6560, 6317, 4118, 4549, 2922, 8549, 8563, 6636, 5459, 1711, 5392, 3575, 9119, 6667, 8214, 3887, 1012, 1396, 1230, 2931, 2860, 3783, 1034, 3238, 8776, 6724, 8890, 6629, 7914, 1830, 7141, 4959, 6271, 2280, 9716, 9836, 5061, 2443, 8358, 7272, 4378, 722, 2842, 6819, 1211, 2049, 3899, 2687, 4420, 9793, 9278, 5766, 7341, 6426, 4668, 5429, 658, 8804, 1357, 3064, 1737, 2755, 6320, 339, 919, 156, 5333, 8832, 9535, 5119, 4086, 2018, 1732, 3730, 3072, 639, 1925, 8623, 1781, 6999, 4010, 8386, 2294, 5355, 4415, 6071, 2931, 2720, 240, 5886, 7515, 208, 2075, 3256, 5861, 8617, 949, 6730, 9423, 554, 5065, 3530, 1972, 3400, 3948, 8086, 9953, 8392, 1862, 2452, 6006, 4084, 840, 4843, 6533, 8115, 7842, 7814, 2144, 5561, 2642, 9213, 5608, 8766, 723, 3438, 7936, 3676, 8312, 5023, 1056, 2878, 6157, 1239, 1935, 9032, 5467, 9562, 5627, 6159, 4354, 2606, 8128, 6439, 2537, 1320, 5134, 3855, 4072, 2851, 2532, 3092, 1847, 7187, 6082, 4192, 5822, 836, 1116, 2405, 5230, 7339, 9430, 2138, 8999, 1732, 418, 5218, 3745, 9469, 9410, 7175, 2269, 4869, 3620, 3573, 7271, 5355, 481, 1390, 4037, 8740, 3629, 4996, 4857, 4378, 3955, 4675, 83, 5855, 9603, 8265, 1812, 2788, 855, 8895, 1496, 8068, 7460, 8202, 3664, 9535, 2679, 7486, 1146, 9273, 4342, 3623, 198, 3858, 6498, 1019, 8937, 465, 3577, 4804, 7089, 1902, 1200, 76, 2180, 5441, 597, 5536, 1261, 9424, 2560, 8448, 2475, 6047, 6826, 3235, 2054, 4407, 2277, 1421, 6701, 1011, 323, 9904, 9607, 4962, 2499, 4649, 3856, 7221, 7027, 168, 6433, 4307, 7010, 4580, 978, 6977, 331, 2297, 6013, 9354, 7610, 7664, 7613, 2228, 2060, 6824, 539, 5544, 9577, 5824, 1079, 2399, 6732, 5174, 2063, 9790, 5036, 9906, 1480, 2383, 1055, 3208, 837, 2021, 9202, 8399, 417, 808, 6376, 3197, 4585, 6790, 9076, 751, 325, 8915, 3847, 7351, 7478, 2500, 1746, 2169, 8517, 6391, 9304, 1958, 7617, 8856, 5276, 8620, 1653, 1709, 8892, 9204, 1520, 8838, 8652, 3921, 5254, 547, 3608, 541, 9976, 6621, 2816, 7556, 9209, 4318, 9138, 348, 9571, 6742, 421, 1402, 4538, 4390, 3043, 2663, 6225, 7637, 6043, 3537, 2529, 249, 494, 8017, 8387, 3295, 3009, 748, 2142, 3971, 3895, 8257, 8606, 5357, 228, 2930, 7781, 9563, 1186, 3918, 5291, 9796, 8466, 7232, 1482, 4107, 6749, 9866, 7486, 7277, 2060, 6152, 7380, 2744, 916, 827, 6952, 7954, 9902, 7079, 8111, 2164, 6115, 9900, 1424, 7034, 1054, 4540, 8654, 1265, 1473, 1884, 1746, 4461, 3101, 6099, 7339, 5022, 1416, 9661, 8534, 1019, 9999, 2682, 4740, 4960, 8894, 5781, 567, 4784, 4961, 7446, 8019, 9115, 8601, 2396, 1440, 9346, 1133, 3791, 1798, 9146, 5116, 912, 8056, 3981, 7621, 3554, 7842, 8729, 6879, 1232, 5079, 6686, 8003, 5890, 1577, 7583, 2424, 7312, 6398, 5586, 1231, 2856, 9316, 7117, 2891, 764, 6496, 4076, 5055, 8663, 298, 3319, 4184, 7745, 9858, 5196, 5187, 4183, 3778, 8407, 8906, 3393, 7311, 1922, 691, 4276, 1363, 7212, 9302, 9628, 2503, 7793, 2863, 8069, 373, 9118, 6130, 68, 4780, 857, 6642, 5736, 3248, 6970, 8323, 248, 3107, 5130, 3654, 2486, 6947, 5274, 7231, 6157, 9849, 8491, 5738, 824, 2870, 2182, 3966, 9569, 2724, 120, 227, 2665, 9115, 9280, 5519, 8504, 314, 3471, 633, 5251, 9539, 1742, 9239, 350, 7180, 2263, 9570, 569, 6134, 2389, 5393, 5300, 2883, 40, 2026, 3240, 3449, 6586, 9090, 7651, 6735, 6726, 457, 1430, 2447, 5317, 8053, 3710, 5723, 4019, 3817, 2198, 7621, 5398, 8624, 9424, 4762, 6553, 5195, 7200, 8105, 1344, 1106, 5943, 9101, 1654, 5105, 3836, 6091, 6949, 3198, 7093, 4606, 1118, 6001, 8155, 7300, 4608, 3921, 6769, 8688, 3085, 4778, 1681, 9028, 6811, 560, 7677, 8441, 3798, 2043, 2744, 6584, 5133, 8164, 3244, 9945, 9742, 3453, 482, 6495, 9234, 1005, 1438, 6815, 1011, 6161, 7746, 2919, 4841, 5241, 6107, 7558, 7554, 7081, 6068, 5557, 3001, 2670, 8069, 9372, 2325, 1795, 9226, 3257, 9131, 2165, 8354, 6544, 2504, 5776, 6266, 8338, 5010, 7838, 1678, 4985, 5140, 4404, 4816, 3570, 9891, 8356, 7732, 7606, 2164, 4014, 1089, 9620, 3901, 7386, 2891, 5211, 4336, 9990, 1744, 4255, 3959, 2193, 8302, 3001, 1883, 7374, 1819, 5907, 3654, 1917, 1080, 4754, 9236, 3948, 3415, 8843, 6185, 9998, 6137, 886, 3958, 2431, 8328, 8571, 8988, 2844, 5496, 686, 7148, 1305, 1534, 3296, 3885, 1763, 9492, 4738, 8983, 8115, 4121, 4659, 3001, 5768, 3498, 4305, 7753, 7122, 8901, 4847, 8472, 1992, 6917, 3365, 6977, 6958, 1749, 5444, 2669, 7539, 4482, 7190, 1124, 9462, 1853, 7148, 8742, 802, 4996, 4370, 2510, 7800, 4943, 2640, 6144, 6203, 7208, 9013, 510, 5718, 5322, 586, 6927, 808, 989, 3323, 3930, 6249, 4989, 203, 6202, 1261, 8913, 6354, 8764, 6001, 9932, 2794, 5082, 2272, 1387, 8284, 5254, 2190, 983, 5739, 3133, 2321, 9770, 2557, 8156, 248, 867, 6508, 2718, 4071, 3635, 5608, 4529, 4837, 5738, 2195, 9191, 1017, 7982, 9295, 3747, 2704, 4121, 1550, 6512, 30, 3744, 2729, 7156, 2954, 74, 6939, 7997, 9701, 541, 3540, 6914, 9961, 2988, 6876, 2349, 2713, 7302, 9338, 2048, 6248, 5035, 6904, 8810, 538, 4314, 1913, 4991, 8280, 4081, 7778, 5205, 5114, 4888, 3759, 1139, 269, 6002, 2005, 9658, 1925, 2574, 1150, 2332, 5217, 5231, 8704, 5133, 5009, 6384, 9787, 1165, 6929, 5621, 5318, 5318, 9832, 8158, 7393, 4502, 7930, 8114, 7772, 817, 3210, 2389, 8401, 5359, 692, 183, 8219, 6131, 8061, 498, 9518, 812, 520, 550, 1594, 838, 4094, 6989, 9299, 2497, 8854, 8240, 6778, 5348, 6908, 5, 7784, 3618, 3082, 969, 7739, 8381, 760, 2041, 9266, 4427, 9729, 2117, 9945, 4073, 4672, 6535, 1683, 1621, 2318, 3853, 2908, 8912, 22, 8655, 9182, 6772, 4960, 5802, 8527, 3931, 8989, 1692, 3827, 8761, 7806, 775, 9778, 741, 7091, 4400, 2923, 69, 4597, 5782, 851, 1972, 1797, 2870, 6278, 3829, 4289, 6342, 739, 158, 5021, 420, 9946, 8676, 4488, 8368, 5457, 9067, 5328, 6772, 9300, 9929, 5203, 4121, 9233, 8992, 5923, 9847, 1474, 1341, 616, 7921, 8173, 7871, 9664, 1116, 5219, 5022, 6471, 4731, 4410, 9841, 8153, 4910, 6481, 2205, 2730, 6263, 4141, 7736, 2379, 5632, 276, 7060, 1607, 1125, 6122, 3184, 9966, 2241, 7288, 8801, 5979, 43, 5209, 1104, 2777, 2080, 6680, 1286, 4936, 6919, 6176, 8219, 7130, 888, 8112, 1277, 3687, 2854, 9159, 6531, 9259, 9707, 4612, 179, 3468, 7289, 8334, 9176, 5462, 9676, 4366, 1090, 8813, 8953, 2810, 3268, 8035, 9997, 2674, 3669, 3335, 3083, 8940, 9915, 8795, 4683, 8134, 9047, 2658, 206, 3629, 7292, 4231, 7026, 2138, 6327, 2219, 7663, 3029, 5580, 7281, 252, 2354, 9674, 9063, 8296, 1025, 5390, 5308, 7575, 6097, 1145, 3937, 1667, 3760, 4872, 6048, 753, 1444, 9876, 1237, 3925, 6411, 6532, 7572, 6115, 6059, 1530, 2992, 5165, 9976, 9382, 2540, 2196, 3728, 7036, 1073, 3601, 3617, 6908, 4016, 8316, 6248, 5237, 1618, 9977, 8738, 5927, 5699, 7897, 3930, 1468, 7246, 4246, 4081, 4177, 6569, 4373, 7999, 4420, 2781, 503, 6176, 4484, 1764, 3779, 6882, 7418, 7702, 8737, 2130, 2699, 1631, 4516, 3217, 9349, 1096, 2423, 6163, 1431, 6038, 3831, 7089, 4731, 7734, 6712, 5011, 1414, 1641, 652, 5324, 5117, 8317, 494, 5435, 2405, 5933, 1110, 9119, 3250, 6339, 2843, 1111, 3631, 3200, 6737, 7848, 1671, 9956, 8312, 4613, 7988, 8186, 8573, 2858, 4234, 8516, 8469, 4647, 4091, 4707, 6295, 4525, 3923, 5082, 8483, 1168, 2269, 2770, 4772, 3002, 1527, 7226, 2835, 9572, 9240, 9861, 8491, 8260, 9582, 2836, 4365, 5524, 9026, 7192, 8250, 9654, 6536, 3467, 4439, 3314, 340, 8082, 6440, 3347, 6374, 6754, 5224, 4300, 2004, 9770, 888, 8383, 4317, 9907, 6619, 3796, 8250, 4393, 5938, 8925, 1110, 6386, 8684, 1451, 2902, 234, 4968, 6604, 9139, 4542, 4828, 5637, 3320, 7340, 8133, 5014, 6144, 665, 7026, 3663, 9149, 2838, 6224, 696, 8257, 4322, 9820, 9112, 5887, 1678, 26, 9141, 947, 6409, 894, 5947, 216, 3751, 2689, 4545, 7408, 1473, 4951, 3882, 1871, 3065, 9800, 2166, 6528, 5883, 1930, 5583, 6307, 7434, 9917, 2306, 8468, 1175, 9958, 1843, 6099, 1165, 2394, 2778, 8249, 3377, 3439, 3626, 9073, 5657, 3898, 7146, 7635, 5844, 3677, 383, 82, 5574, 9873, 4781, 6295, 9548, 7972, 878, 9202, 3092, 7595, 2673, 6163, 249, 2103, 7545, 4946, 7702, 1144, 161, 6040, 2822, 3628, 3755, 2649, 6314, 3403, 4753, 3310, 267, 1763, 5670, 76, 8555, 1264, 4755, 6978, 8487, 3700, 6514, 376, 5326, 641, 5081, 3362, 1890, 6778, 6267, 9450, 8639, 5984, 8583, 7350, 7931, 9152, 4919, 8097, 6475, 8223, 8115, 2641, 750, 7321, 5352, 8882, 173, 1086, 7443, 7933, 3591, 4249, 9509, 3001, 6109, 3367, 5381, 8719, 5955, 301, 506, 8682, 6848, 9653, 1373, 6760, 7656, 4227, 3819, 6271, 1021, 7816, 1631, 7867, 37, 5864, 7719, 9437, 7507, 1075, 3304, 3856, 4347, 9733, 1367, 5700, 3448, 4166, 6951, 5055, 7108, 1459, 1191, 7369, 7376, 8965, 7988, 3891, 72, 776, 5618, 9909, 6609, 5964, 7530, 2903, 6002, 8531, 5694, 7318, 4199, 1598, 6708, 2344, 2834, 7116, 8397, 3636, 2900, 1338, 4289, 4166, 7149, 8942, 2695, 4444, 9858, 709, 6645, 125, 9751, 4912, 6990, 1386, 1363, 6278, 2975, 3166, 9044, 161, 5593, 7521, 4416, 2010, 5769, 4379, 1411, 1766, 6751, 1790, 361, 9230, 8875, 7726, 8178, 1685, 4401, 672, 603, 9835, 8981, 729, 5584, 8021, 1418, 6945, 2177, 5463, 9406, 2951, 5835, 4320, 23, 2715, 7742, 8068, 6129, 1685, 494, 1808, 9524, 4008, 9890, 216, 6440, 3612, 755, 1153, 6931, 6815, 8403, 6516, 4507, 5259, 2537, 5004, 5940, 1324, 3333, 4208, 3458, 9093, 6770, 9818, 1597, 6923, 5308, 4118, 7922, 7348, 2855, 9301, 6024, 432, 4401, 6016, 5653, 9900, 5976, 9170, 803, 3782, 1541, 2649, 4891, 384, 9786, 4741, 5145, 5487, 4077, 8566, 2092, 6681, 5211, 2189, 1917, 8615, 3892, 4767, 1957, 9085, 4047, 6540, 373, 6728, 4415, 4281, 8807, 27, 6916, 2034, 5156, 5368, 4950, 8997, 1885, 6023, 7026, 5015, 6000, 7785, 7625, 4068, 8730, 5476, 2322, 5631, 7927, 4071, 7054, 8126, 588, 7258, 3581, 8703, 7730, 5240, 8373, 2598, 3790, 5867, 6049, 1868, 2314, 5267, 2743, 753, 9839, 6055, 2955, 3453, 9139, 3507, 8373, 4845, 8894, 4645, 9796, 706, 1029, 3938, 9761, 3783, 1969, 4043, 7334, 3857, 7100, 8191, 5667, 145, 1726, 2304, 2026, 4330, 203, 4703, 1112, 1939, 4244, 802, 9587, 6795, 8488, 3964, 5836, 2594, 416, 8726, 5666, 1584, 4698, 371, 4066, 2740, 970, 6410, 1037, 4891, 1752, 9708, 5234, 2582, 7439, 8839, 1223, 5566, 5003, 9733, 1677, 1786, 7982, 9252, 4857, 2572, 6705, 5450, 5075, 5013, 8120, 3469, 1887, 2096, 3119, 2987, 7017, 948, 3908, 8721, 9332, 1014, 2217, 6616, 499, 3477, 8969, 7803, 8873, 3671, 668, 8356, 6624, 100, 2527, 9861, 5410, 8043, 2819, 6634, 7056, 8602, 8023, 1102, 5592, 8821, 162, 2296, 759, 7391, 1767, 4032, 9926, 103, 8543, 895, 2179, 5663, 3799, 1408, 5326, 8224, 523, 5523, 2468, 3634, 7163, 6005, 8117, 5799, 3112, 3059, 1428, 2538, 4682, 5979, 3354, 380, 1501, 9814, 688, 455, 7457, 1858, 495, 1432, 4475, 5577, 3798, 2672, 3999, 8588, 1688, 7621, 3897, 5498, 7324, 7029, 381, 9512, 8559, 8043, 9134, 4115, 5873, 3363, 9975, 2227, 6725, 4460, 2161, 6082, 3546, 9083, 342, 7606, 5960, 9024, 3079, 7168, 8478, 5647, 9029, 2715, 7896, 6686, 8688, 3712, 6007, 6286, 7473, 9851, 5835, 9682, 4987, 8626, 8848, 4444, 1040, 6066, 608, 8961, 2412, 5743, 4735, 6254, 872, 1308, 5459, 3214, 9378, 6795, 7909, 6706, 7111, 998, 6661, 6624, 1664, 7596, 1728, 6409, 5377, 8799, 2084, 9808, 6264, 7412, 6609, 7031, 6272, 9397, 5634, 9562, 7928, 7718, 9240, 8668, 2815, 1255, 603, 8784, 7335, 715, 3490, 9397, 7696, 9140, 9148, 3107, 9141, 2280, 4955, 8624, 9668, 8070, 2454, 4147, 4079, 8121, 9091, 5299, 9150, 9979, 8873, 6999, 1379, 4050, 7187, 339, 1727, 8160, 9147, 5318, 9750, 9349, 7404, 2678, 1058, 7623, 814, 5018, 4656, 5458, 6777, 5949, 7646, 6393, 5043, 6301, 8324, 1144, 1881, 9423, 4287, 468, 9406, 5813, 1720, 2699, 576, 8081, 9622, 7717, 3659, 5403, 5546, 5005, 4522, 9849, 3714, 777, 6103, 4101, 3157, 8533, 3822, 8839, 5660, 2231, 5918, 7206, 48, 9474, 3665, 8544, 3721, 1638, 7183, 9700, 3722, 141, 3036, 3605, 8850, 417, 4012, 1532, 7522, 3252, 2961, 9851, 1121, 8454, 6269, 4003, 7950, 7732, 5784, 5014, 8896, 3476, 8784, 1484, 901, 168, 2328, 2665, 6981, 4132, 5869, 8801, 3153, 9790, 9759, 5252, 1750, 4318, 4348, 3682, 9030, 1129, 8609, 9796, 3866, 1806, 5765, 530, 8891, 4825, 4974, 69, 53, 7196, 474, 5649, 1505, 4012, 734, 8104, 4362, 9159, 6599, 5176, 8587, 2487, 8333, 3368, 2309, 1669, 1056, 5954, 4195, 1257, 1787, 9316, 9478, 1002, 1215, 1905, 3841, 4598, 2637, 3910, 9076, 1739, 8178, 9350, 8766, 3205, 2605, 9622, 3347, 1389, 1591, 7166, 5471, 1372, 8899, 6886, 4416, 1416, 1821, 6233, 552, 9716, 4552, 2590, 8630, 4246, 5486, 6228, 41, 9653, 4176, 3702, 2974, 7553, 6417, 4229, 7949, 5910, 4288, 1075, 3375, 2094, 6416, 3497, 5058, 6032, 5615, 5053, 5080, 7015, 1981, 8168, 9358, 5311, 6317, 6416, 2990, 4322, 6301, 4422, 8525, 3862, 3814, 9444, 8970, 9711, 9997, 4459, 8468, 6777, 3393, 1991, 8350, 3430, 7456, 8599, 873, 8934, 8847, 7131, 7598, 7366, 7243, 9701, 6986, 102, 2302, 4658, 1646, 347, 5737, 2468, 1820, 6366, 3540, 4342, 5368, 602, 5349, 5495, 2718, 7255, 5950, 7046, 5271, 271, 7346, 8705, 9861, 7931, 5281, 7777, 6806, 6066, 9468, 2206, 5134, 2417, 3350, 8191, 4661, 5290, 6515, 6408, 5875, 8059, 4005, 1089, 3949, 9340, 8265, 5079, 4805, 8999, 6000, 7751, 2578, 2576, 6749, 3030, 350, 473, 8619, 608, 8564, 4067, 9488, 6991, 9339, 4688, 5972, 1095, 1119, 1117, 484, 1781, 7650, 4037, 5491, 518, 1787, 9205, 7902, 1990, 2695, 7649, 9273, 7792, 3680, 2772, 86, 9591, 1105, 4701, 7283, 696, 7780, 6858, 1897, 1827, 8894, 7938, 3046, 6141, 7769, 7088, 688, 4754, 5612, 7358, 1400, 9366, 8234, 6241, 2885, 5564, 1761, 9281, 454, 3161, 8924, 4804, 8475, 2578, 3213, 9642, 5523, 1044, 260, 3861, 51, 4514, 6172, 9424, 9108, 5379, 9235, 5127, 1062, 1114, 2415, 3963, 9899, 9661, 6410, 5144, 682, 6477, 4555, 5622, 7075, 3275, 9068, 885, 4566, 2237, 9732, 4, 7680, 9780, 9647, 4936, 858, 4133, 6998, 4007, 2776, 8519, 1344, 9119, 1260, 5562, 53, 6496, 4219, 2888, 100, 9876, 4557, 8808, 2969, 1186, 1731, 1874, 3515, 4542, 9727, 2124, 5404, 6748, 5235, 5530, 8309, 9931, 8773, 9673, 194, 8776, 6181, 613, 7987, 7390, 8473, 2136, 5419, 2941, 4669, 1155, 3873, 1514, 4669, 7955, 1351, 1863, 4524, 2329, 6783, 3938, 8215, 9680, 1599, 9871, 5716, 1640, 9821, 9895, 1000, 2363, 9574, 6752, 3741, 6521, 585, 8150, 9656, 9971, 6641, 7364, 2765, 8431, 3419, 4705, 8178, 4898, 3450, 8491, 2972, 5064, 5786, 1222, 5088, 6815, 9452, 319, 3426, 8369, 6200, 5815, 7341, 5926, 6913, 6758, 7070, 5294, 6388, 7708, 3158, 9561, 6780, 7227, 1788, 4944, 7624, 4191, 8423, 1736, 9057, 5844, 4350, 6904, 5751, 8935, 6251, 9253, 8206, 5676, 8381, 5693, 3578, 5434, 3197, 5512, 2875, 2232, 9416, 5640, 7672, 3801, 4465, 8399, 9174, 2729, 7799, 5247, 7880, 2005, 2094, 2882, 7467, 4543, 4739, 4692, 1083, 8092, 3052, 5425, 7946, 5515, 4035, 9482, 3916, 3145, 9622, 564, 2209, 9346, 1087, 5540, 7514, 8726, 748, 4513, 9501, 9370, 4955, 1269, 4407, 2688, 1763, 4176, 9034, 857, 4239, 3271, 8335, 7621, 7679, 3434, 8280, 3618, 6498, 1328, 5728, 1033, 1985, 1249, 1866, 8875, 3982, 3892, 9351, 7058, 8320, 6857, 8760, 3671, 3416, 6380, 4803, 5152, 1924, 7122, 2242, 3386, 2383, 9498, 401, 1988, 6123, 3416, 8116, 7341, 7067, 3984, 8111, 3641, 4691, 8496, 4488, 213, 2719, 3725, 7155, 4265, 2479, 5231, 8535, 5122, 8309, 8459, 1153, 7577, 5512, 3914, 5542, 2611, 2969, 1125, 9965, 86, 5563, 3244, 6357, 4876, 1224, 6423, 5651, 3310, 6159, 5423, 8079, 6494, 9308, 6101, 2518, 2201, 4261, 1530, 7323, 5182, 3822, 3793, 6397, 5503, 9576, 3604, 1787, 5069, 2202, 5736, 7719, 9641, 6148, 8241, 6445, 3646, 8217, 3443, 8054, 5996, 9957, 1316, 9404, 6101, 713, 3452, 8066, 4929, 4115, 8674, 554, 4037, 6091, 8109, 4879, 1856, 1651, 9355, 1559, 5387, 6618, 7189, 9104, 6842, 707, 9565, 9036, 8208, 5310, 291, 8716, 6351, 2457, 3217, 6535, 1304, 62, 7633, 9157, 5196, 7408, 2597, 6697, 9274, 224, 8158, 7677, 6172, 3142, 83, 8414, 5299, 4242, 4791, 7671, 3557, 9882, 509, 958, 2395, 1242, 5023, 3097, 2179, 9815, 5373, 3256, 484, 6164, 8547, 7478, 1463, 6282, 9430, 4324, 905, 4319, 4472, 2418, 9320, 9538, 2389, 2934, 8330, 8873, 7146, 4952, 2531, 9773, 6901, 1965, 6456, 5922, 5048, 6506, 8773, 5897, 8858, 2446, 7197, 456, 5001, 8534, 9750, 5502, 1799, 1637, 6472, 2959, 5385, 4901, 7491, 9989, 6642, 4142, 36, 7967, 9134, 3624, 8046, 4057, 5160, 2131, 3437, 5092, 9279, 1807, 9979, 7607, 1681, 4079, 1256, 4103, 4165, 6806, 2975, 7917, 4682, 7750, 5203, 9135, 1291, 2733, 1887, 2960, 2402, 5259, 1198, 3826, 3534, 5850, 4934, 9296, 9553, 7737, 1352, 3999, 7944, 671, 1956, 3587, 7201, 7894, 8986, 6066, 5046, 8996, 4918, 2676, 495, 831, 7483, 205, 1382, 9957, 7405, 9622, 7097, 487, 9080, 1236, 358, 5522, 1374, 9862, 7419, 792, 5275, 7865, 1758, 1121, 3720, 8079, 1870, 2344, 4004, 8964, 7248, 468, 3437, 2178, 2455, 7663, 686, 2685, 7319, 6471, 8698, 2624, 7172, 6863, 658, 7292, 3198, 7304, 6445, 1911, 2057, 5061, 5386, 5828, 942, 1354, 6213, 1915, 7317, 6449, 6528, 9027, 8898, 7735, 6107, 4780, 7364, 7599, 1324, 3043, 8896, 2661, 5946, 7433, 1980, 9090, 2052, 5895, 91, 8589, 3668, 615, 1225, 7956, 7315, 7506, 107, 6957, 741, 8285, 2978, 5761, 9771, 3352, 1608, 7113, 6103, 2296, 1338, 4869, 5958, 8315, 4014, 1669, 7172, 8024, 2419, 7478, 5751, 8512, 4286, 1383, 2076, 5326, 3389, 6117, 2205, 8405, 8846, 2334, 6617, 7606, 4036, 7000, 1217, 7187, 6266, 1842, 9915, 6730, 1779, 2175, 8952, 2074, 3743, 585, 5260, 9233, 2050, 74, 3282, 5756, 9113, 7927, 5874, 8911, 9920, 8442, 5249, 9492, 2600, 1113, 807, 4406, 855, 5512, 5621, 5212, 9779, 2627, 6691, 5532, 9025, 6103, 1683, 9025, 5930, 850, 6106, 171, 5814, 342, 6846, 3155, 3929, 2329, 1185, 4345, 445, 1490, 4413, 2333, 8827, 3901, 4132, 8662, 383, 7413, 6282, 5621, 3424, 267, 5536, 7591, 7400, 3037, 4516, 9445, 5570, 9624, 1283, 1710, 3127, 5755, 4965, 709, 4517, 8505, 4027, 1551, 5246, 1395, 4739, 1556, 2525, 5790, 4772, 1415, 3358, 9072, 3087, 1901, 1652, 5212, 9067, 4120, 5244, 8546, 9705, 6316, 1061, 7612, 3802, 5131, 260, 2230, 9626, 3359, 1081, 734, 2965, 8245, 4891, 6182, 4128, 9218, 7379, 5207, 1400, 3194, 6576, 386, 910, 1092, 3834, 1832, 9626, 9900, 630, 404, 8891, 5623, 9469, 8771, 4531, 5289, 4713, 2619, 794, 7364, 111, 4757, 7491, 3627, 5484, 1614, 5092, 4333, 6503, 1433, 3388, 409, 9157, 9009, 4945, 3399, 8925, 6578, 6834, 4358, 1605, 2729, 5785, 2721, 8094, 411, 4268, 9162, 9046, 5796, 138, 1937, 862, 5843, 5210, 3298, 8875, 7741, 8676, 5935, 9858, 1925, 500, 3233, 8159, 4142, 3924, 2499, 2307, 8235, 3273, 3689, 8665, 6015, 8791, 8723, 4420, 4374, 6222, 3060, 7924, 8904, 1012, 5144, 6390, 3109, 3077, 4708, 292, 6485, 6868, 9857, 7774, 4159, 1869, 4015, 7488, 7142, 438, 5864, 8241, 7604, 6609, 614, 6773, 1332, 1843, 5996, 860, 89, 6495, 3326, 5381, 6576, 2727, 1100, 2710, 6488, 9784, 3438, 4411, 4507, 9052, 5388, 5695, 6946, 6054, 7521, 7636, 7956, 6515, 5169, 9667, 876, 693, 9405, 4566, 4816, 3401, 9666, 1683, 8651, 4647, 8881, 4663, 9773, 4090, 3382, 8059, 1076, 5885, 5691, 2993, 5897, 1916, 2566, 974, 1705, 9707, 5084, 3458, 4893, 6192, 243, 1890, 1259, 2426, 7578, 4682, 4493, 6753, 9677, 2763, 3243, 7242, 4382, 592, 9024, 9583, 669, 3945, 5535, 5936, 5220, 9156, 2589, 7986, 4974, 7214, 6106, 3428, 2257, 686, 5959, 5120, 8956, 1098, 3249, 8541, 729, 718, 7923, 5265, 2376, 3974, 313, 4936, 1812, 9270, 6691, 9125, 8079, 964, 1505, 1190, 4381, 1839, 2371, 4627, 9464, 8735, 1234, 3608, 1402, 2237, 7755, 7702, 3302, 2934, 2797, 5836, 7333, 1631, 5231, 404, 5034, 8572, 6008, 1396, 9911, 9359, 8243, 9193, 5007, 1955, 7919, 5497, 9065, 4333, 2110, 6130, 1717, 1992, 6172, 2164, 6635, 2341, 6975, 1844, 7136, 1931, 6780, 9270, 7029, 5668, 4416, 3993, 9653, 9735, 9134, 7386, 1298, 1673, 527, 8905, 6058, 9489, 6070, 9061, 9638, 811, 3563, 6742, 223, 6346, 5511, 10, 3538, 7314, 1993, 1593, 4489, 8350, 5759, 3433, 3926, 5049, 3810, 9273, 4568, 8758, 9159, 2138, 3005, 1342, 2727, 7450, 4307, 5179, 5226, 6420, 7603, 2592, 4055, 571, 6213, 6616, 3143, 3587, 5570, 7685, 7806, 2131, 7448, 2548, 8947, 7937, 7304, 4938, 8051, 9949, 1295, 8914, 8797, 3994, 3263, 9396, 9386, 7917, 3879, 6052, 7384, 6819, 9742, 8891, 9935, 3028, 5853, 7788, 5465, 9505, 4143, 9590, 4200, 8544, 8738, 996, 1106, 4215, 2174, 9537, 3648, 1600, 6939, 364, 1434, 7900, 321, 8196, 4024, 8038, 5459, 7475, 9817, 7360, 2471, 7190, 6694, 5684, 3521, 721, 4508, 5222, 410, 9033, 9648, 8984, 6860, 244, 6400, 4279, 3835, 3848, 2558, 2729, 9159, 6543, 8548, 9993, 6387, 5092, 109, 3275, 3020, 1501, 5222, 7118, 3924, 3937, 7892, 9503, 7435, 8776, 9367, 2734, 8127, 6784, 6760, 2887, 7621, 4733, 6603, 462, 409, 9506, 7293, 5232, 37, 4098, 2334, 3076, 6472, 9733, 5545, 3694, 4373, 4477, 3445, 1002, 2477, 8249, 1505, 236, 7391, 6200, 5963, 1479, 7226, 6511, 6889, 7045, 6924, 4904, 8033, 2861, 7117, 1798, 2801, 4415, 8372, 4429, 7898, 2352, 9693, 958, 3124, 7406, 9311, 4631, 704, 4624, 5155, 8424, 4692, 672, 7536, 5602, 6244, 6318, 8256, 9208, 6502, 3038, 5843, 4353, 7952, 6949, 5558, 1562, 3144, 9338, 2640, 1244, 8991, 415, 9706, 7691, 9104, 2155, 5027, 4474, 2218, 2097, 1218, 5389, 881, 8170, 671, 4671, 7122, 4117, 3827, 6500, 2822, 8321, 5, 5856, 9820, 895, 7063, 5620, 1583, 4440, 9821, 1464, 5158, 8056, 9081, 6617, 1885, 7387, 7351, 6305, 338, 2049, 2094, 9968, 1506, 4111, 653, 6639, 4976, 7456, 2852, 5953, 7804, 3954, 654, 8894, 8601, 7225, 3371, 521, 5409, 720, 5280, 2026, 4815, 9092, 8961, 8761, 1172, 1146, 8698, 4888, 8502, 213, 4593, 1541, 5124, 8741, 899, 2291, 3128, 1444, 7053, 9398, 4653, 8086, 3272, 2227, 214, 8928, 9738, 1447, 361, 1144, 6533, 9488, 8935, 4143, 3271, 9926, 6395, 5947, 8939, 1795, 2192, 161, 5328, 4993, 5963, 5131, 1099, 7773, 6728, 3650, 3317, 1771, 279, 4731, 7714, 2981, 1596, 431, 8809, 544, 9583, 7739, 9988, 9371, 3263, 3428, 287, 4324, 2319, 1383, 9383, 8678, 6220, 1795, 8822, 4726, 3146, 6200, 6996, 4952, 304, 4704, 8370, 7843, 7539, 7494, 1143, 9392, 8704, 8531, 7357, 2556, 4654, 937, 2805, 1928, 7108, 434, 4277, 4968, 5875, 2975, 254, 3294, 7112, 5282, 7558, 2965, 7575, 8407, 1676, 2133, 8880, 9113, 4012, 1340, 5097, 9538, 2951, 7885, 482, 1707, 8507, 1398, 7558, 482, 4146, 4602, 9485, 9574, 946, 3732, 1897, 1177, 1494, 6983, 439, 2442, 7476, 6857, 1713, 5583, 215, 5793, 8211, 7692, 2177, 5054, 2727, 9875, 6555, 2234, 6283, 8424, 744, 7685, 1231, 8547, 2690, 5599, 6514, 5074, 1736, 2641, 8698, 2111, 1003, 9177, 26, 5640, 5161, 3984, 4531, 6287, 3062, 8139, 8875, 9663, 4922, 9392, 72, 1346, 886, 5940, 831, 681, 9962, 5882, 9177, 9146, 1076, 7452, 7103, 9622, 6906, 5608, 4933, 6163, 6282, 7544, 9122, 3450, 1165, 4388, 8617, 4303, 2636, 407, 8304, 1608, 8766, 2072, 7911, 5479, 9998, 7739, 3460, 3375, 5998, 5024, 7304, 4213, 1756, 5186, 587, 7047, 625, 9087, 6995, 7788, 3567, 9876, 3651, 33, 6713, 8435, 5484, 1768, 9740, 6942, 6218, 1529, 5247, 9259, 5788, 3444, 5560, 3791, 7608, 877, 5211, 5974, 2446, 3084, 866, 2160, 3772, 4754, 2791, 8553, 4698, 2314, 1594, 8538, 7712, 9557, 9231, 9567, 9915, 9912, 6249, 2518, 3941, 2547, 2442, 693, 736, 7373, 4863, 1497, 8431, 6271, 5228, 5501, 8615, 8849, 587, 4208, 8947, 92, 3557, 8952, 8970, 7434, 9084, 2196, 9321, 323, 9617, 7623, 8904, 4058, 5995, 2098, 2391, 48, 226, 8096, 1921, 9712, 4983, 9495, 9385, 3992, 3770, 3560, 4838, 8155, 3122, 1693, 9579, 7136, 7035, 5434, 6512, 396, 9627, 5510, 5002, 2687, 976, 2153, 5273, 5983, 7462, 4584, 5226, 828, 6732, 9580, 1873, 9923, 5366, 36, 149, 4710, 5138, 2224, 7803, 7936, 2009, 351, 778, 784, 363, 4495, 2728, 334, 7432, 6254, 804, 4710, 3436, 2827, 7219, 7379, 7211, 9523, 7340, 9875, 3995, 3696, 8051, 1293, 5799, 6061, 8977, 3076, 4255, 4205, 2176, 9266, 5390, 6650, 22, 6045, 6870, 90, 2938, 5263, 9315, 2946, 9834, 2137, 4526, 7143, 5587, 8666, 414, 9161, 3256, 6415, 3035, 6981, 2258, 639, 4777, 1057, 1855, 2117, 1899, 3380, 2552, 6878, 2549, 1291, 1816, 3220, 8698, 874, 9834, 449, 7398, 8101, 3038, 6768, 3766, 2175, 6329, 9218, 5957, 1581, 3222, 6090, 1183, 6797, 2726, 2899, 2417, 5855, 1350, 9622, 6768, 2024, 9065, 6298, 7241, 3589, 1964, 4507, 6496, 4926, 1391, 2382, 8107, 9069, 8384, 4477, 4399, 8943, 1581, 1667, 4395, 4788, 6646, 2595, 9790, 9078, 5176, 4117, 7426, 9142, 8412, 4285, 5457, 7869, 5247, 4570, 9248, 4002, 914, 273, 7071, 736, 1787, 1544, 7215, 9941, 5094, 4024, 9301, 5169, 8008, 155, 266, 5108, 1545, 5732, 7046, 4776, 8819, 8540, 5137, 5244, 1855, 3104, 6388, 4175, 9542, 4582, 7327, 947, 4119, 126, 7676, 4901, 2580, 4267, 9126, 7997, 196, 4146, 1251, 4729, 9619, 2926, 2651, 8542, 6568, 9340, 7167, 9015, 1130, 7639, 7046, 9904, 7847, 8083, 7692, 8466, 1191, 6460, 9238, 8559, 2235, 9374, 5004, 7003, 2262, 2994, 2229, 3230, 955, 2292, 1071, 8492, 7125, 7206, 364, 2324, 4715, 7353, 6506, 1113, 2761, 5737, 3934, 7697, 8184, 8606, 7750, 2471, 6307, 1695, 9499, 4652, 9352, 4027, 4597, 3021, 4139, 7996, 1972, 2823, 6380, 7680, 640, 1435, 2695, 3764, 9181, 8585, 2751, 656, 3710, 3498, 4942, 437, 2232, 5820, 3315, 2289, 5232, 29, 8701, 2509, 3629, 8813, 7181, 5530, 8950, 7561, 6762, 8096, 159, 3982, 8170, 8130, 3609, 3173, 7320, 2881, 6426, 1110, 3679, 7065, 7297, 3597, 8026, 2139, 2034, 8238, 9789, 258, 1148, 4031, 7668, 7112, 5263, 3220, 3108, 4828, 5304, 1026, 9801, 4819, 5832, 8266, 7203, 3862, 6602, 6099, 652, 8126, 5892, 716, 4974, 8531, 9404, 4492, 9118, 974, 4444, 7855, 1983, 8008, 9820, 5108, 1353, 3362, 7549, 7185, 5263, 2736, 3616, 6079, 651, 759, 2128, 254, 4155, 6350, 7669, 8840, 566, 4455, 8127, 7672, 6900, 8396, 2494, 7161, 8694, 7490, 98, 7388, 1205, 4405, 4699, 479, 1799, 5995, 3481, 13, 7642, 9582, 6495, 4240, 9822, 3618, 1729, 7737, 9896, 3438, 332, 4145, 1809, 5465, 6652, 7022, 39, 5173, 1991, 4798, 561, 1156, 1839, 2337, 8680, 5493, 8934, 685, 7384, 7668, 2705, 1658, 4136, 8385, 4898, 8628, 3632, 7208, 6221, 9280, 434, 5296, 3432, 7067, 6193, 5443, 3906, 5524, 8468, 9151, 5947, 5375, 7570, 9683, 2409, 9709, 8608, 9855, 369, 9434, 8789, 9005, 7492, 6875, 5392, 7949, 3105, 459, 7488, 8683, 7281, 6133, 2156, 589, 7621, 4454, 9058, 1403, 255, 2536, 734, 8424, 5750, 4404, 1952, 1635, 2787, 7078, 3836, 6278, 7986, 4969, 8105, 6830, 8341, 5777, 9684, 3688, 3606, 920, 9985, 9393, 4814, 1185, 5057, 6152, 9017, 4632, 3305, 6274, 5351, 1528, 8058, 1590, 5201, 3133, 4693, 3256, 4599, 428, 6061, 7795, 6063, 5007, 6037, 1823, 998, 8081, 5153, 7809, 4214, 5104, 2864, 2834, 7527, 1814, 7941, 9567, 2192, 2032, 6853, 3052, 8698, 9366, 8335, 9660, 6282, 4633, 7475, 9991, 7864, 1223, 3674, 3204, 7015, 8297, 1975, 6854, 7653, 3686, 3360, 5200, 1055, 6688, 3216, 5837, 6478, 7520, 7166, 4264, 7448, 8057, 1401, 8064, 7660, 4885, 986, 3268, 8799, 2679, 9245, 3547, 1986, 6849, 5712, 6665, 7671, 5747, 7742, 117, 5945, 6013, 2126, 6098, 1130, 3658, 3759, 5162, 6062, 8621, 7052, 5160, 8309, 9630, 6423, 2875, 73, 7244, 6603, 8431, 4359, 7362, 2486, 1464, 1307, 8560, 3711, 3855, 2969, 9370, 2996, 5967, 1574, 46, 8437, 9449, 4585, 7137, 415, 2422, 5797, 461, 944, 2223, 1393, 4488, 8694, 646, 2428, 598, 7839, 1718, 1932, 4185, 4758, 7277, 1907, 6933, 332, 3713, 1138, 2345, 2336, 5733, 3750, 6571, 8402, 46, 5677, 2413, 9032, 5416, 8075, 9588, 2834, 2174, 957, 5499, 92, 5968, 2846, 6987, 7147, 8739, 2172, 1837, 7363, 8533, 4414, 548, 6040, 5940, 2171, 1258, 7879, 1123, 3313, 56, 5081, 5661, 2314, 863, 2626, 1529, 9171, 2498, 5491, 1402, 8986, 951, 7455, 446, 9782, 9279, 1072, 4198, 8668, 469, 3917, 7314, 3942, 7566, 8906, 9225, 6703, 7252, 9056, 6217, 8926, 8729, 9863, 5783, 6556, 7771, 8455, 641, 1513, 4344, 3851, 7957, 5827, 3229, 6568, 4287, 3017, 7837, 9932, 4766, 1137, 3592, 4786, 7657, 2108, 9493, 4890, 4104, 5173, 1845, 5759, 1292, 8813, 496, 2725, 7777, 6442, 7067, 8824, 4803, 1381, 8799, 7587, 3754, 1606, 2916, 1112, 9737, 7216, 8536, 8339, 3481, 1560, 3047, 6263, 3531, 4844, 1168, 3328, 980, 1282, 2709, 8644, 5509, 2389, 5771, 8199, 8776, 4050, 2649, 8136, 6638, 7365, 7488, 4094, 9623, 8286, 8951, 1331, 2129, 9370, 9203, 8100, 8350, 536, 9440, 7686, 6468, 1683, 2891, 5907, 1156, 8669, 6166, 6389, 9429, 2402, 3545, 1400, 3731, 5455, 484, 293, 139, 902, 658, 7903, 8562, 7627, 391, 493, 472, 6315, 7246, 866, 7567, 5471, 1894, 7066, 5988, 3955, 4885, 9295, 3729, 6813, 2440, 8939, 5637, 7790, 2676, 7007, 1847, 2911, 1174, 3295, 6110, 676, 747, 264, 9980, 2563, 2758, 1325, 520, 4932, 2200, 1471, 4010, 4925, 7, 9171, 1547, 2889, 4873, 4453, 5506, 5139, 8595, 8103, 8163, 7304, 7925, 1910, 4592, 2965, 5997, 3675, 8700, 7183, 6059, 5771, 3393, 6122, 761, 3712, 337, 7156, 3913, 9183, 2518, 955, 5231, 5814, 1912, 6397, 6279, 7357, 5045, 1670, 6112, 3755, 4770, 6796, 2062, 7035, 3873, 4033, 5910, 8403, 6446, 753, 4006, 7209, 7897, 9669, 9822, 5111, 8297, 2065, 1549, 356, 7990, 7728, 9006, 5815, 8576, 9465, 655, 8937, 6977, 2473, 96, 9653, 3237, 9486, 8120, 9594, 4780, 9572, 5321, 8693, 3874, 1814, 6672, 2148, 400, 9265, 8565, 5910, 1257, 3001, 4584, 5411, 3962, 3832, 1810, 4493, 1136, 8550, 1005, 602, 4540, 5072, 7236, 1550, 8088, 5014, 4823, 8825, 4998, 258, 1960, 9628, 4474, 8203, 1878, 9628, 8332, 9669, 1267, 9958, 5879, 1749, 9790, 380, 6224, 9281, 4715, 8677, 6074, 3273, 3800, 457, 1773, 5238, 7302, 5452, 2343, 4786, 9952, 7957, 3514, 6407, 1693, 2102, 3479, 8875, 5167, 425, 5280, 6967, 2858, 4949, 8773, 5165, 3388, 4992, 5078, 2071, 6836, 7211, 4192, 6058, 1553, 6601, 6977, 2037, 454, 6258, 5913, 9642, 9448, 7920, 2515, 4854, 3599, 9858, 3340, 3262, 7895, 8680, 4093, 4086, 3099, 6711, 1718, 9793, 9674, 7727, 1341, 3247, 1523, 2691, 7956, 9939, 7905, 4866, 9977, 7665, 2592, 3382, 6846, 4462, 6791, 5113, 1455, 2831, 2347, 6900, 8595, 7903, 4525, 463, 5478, 2027, 3715, 6461, 5543, 5064, 3718, 1972, 5002, 2560, 6275, 5970, 5679, 7743, 5271, 6011, 238, 2242, 619, 1136, 50, 5726, 8147, 3658, 5722, 5312, 5413, 4753, 6838, 4558, 722, 8880, 5553, 5529, 5877, 3582, 9245, 2180, 1622, 4396, 10, 6363, 6996, 2360, 8900, 5939, 9835, 4835, 8987, 4492, 1080, 5673, 2788, 3495, 7502, 8731, 4373, 9219, 8197, 9629, 8925, 7243, 2886, 2980, 2222, 2842, 7679, 8934, 742, 5311, 9981, 748, 4110, 8252, 4890, 7733, 8072, 9216, 3556, 604, 4461, 78, 2313, 8509, 6191, 7197, 3644, 7295, 7929, 2929, 4412, 9708, 3478, 6467, 5277, 3923, 7082, 651, 5703, 485, 6955, 7210, 766, 7161, 9715, 4752, 9079, 6600, 7866, 242, 6544, 4140, 6203, 9815, 8955, 8508, 7423, 4695, 7529, 8999, 4119, 7635, 3463, 3005, 2547, 6006, 50, 7272, 4993, 3731, 1011, 6868, 5137, 2747, 7325, 7327, 8507, 9329, 7707, 5905, 9656, 391, 4365, 1931, 3942, 5823, 7511, 2910, 7475, 8344, 619, 7137, 8770, 7842, 5156, 6690, 588, 9337, 3833, 2791, 9740, 23, 541, 2735, 8538, 4489, 3083, 7664, 4378, 9322, 3833, 577, 4257, 6537, 9010, 9029, 3459, 1704, 7730, 2345, 4039, 1728, 6564, 2438, 7583, 9487, 8312, 9385, 6701, 488, 9743, 4629, 2380, 3085, 3761, 9945, 347, 6220, 1669, 4530, 1736, 5977, 5078, 7950, 8738, 2814, 4576, 8845, 1844, 984, 4902, 6819, 9327, 3490, 5330, 4509, 3998, 7357, 7638, 4533, 6946, 7120, 2679, 2566, 203, 9063, 823, 7974, 6705, 4950, 3563, 237, 9226, 2630, 5724, 617, 8164, 5052, 3030, 8358, 649, 2525, 3003, 5665, 6069, 3111, 1071, 3033, 9892, 1246, 2321, 3785, 3946, 5776, 2850, 9146, 463, 3354, 1289, 7786, 7505, 1613, 7125, 5959, 3566, 1577, 1678, 3885, 69, 5553, 3687, 1825, 5396, 3991, 3157, 8969, 2358, 8502, 5539, 5657, 3954, 5836, 9558, 3778, 6082, 4862, 922, 2566, 9637, 1349, 3522, 7446, 8228, 8930, 4195, 6608, 9876, 479, 3880, 3875, 2557, 2470, 57, 6694, 142, 7808, 5708, 3918, 5106, 354, 9043, 1600, 2532, 9717, 1389, 2833, 7656, 223, 241, 7241, 9704, 8606, 6531, 2956, 1578, 9018, 7914, 4078, 7407, 8335, 358, 1932, 3740, 6352, 5056, 3057, 1507, 3720, 6054, 1293, 6283, 8626, 4558, 6373, 4842, 2059, 8995, 6702, 1940, 9825, 6126, 4055, 7498, 7498, 2620, 6303, 4106, 2254, 6452, 3341, 179, 3344, 103, 9718, 1910, 3882, 4151, 5459, 6351, 5951, 1832, 5713, 8288, 7723, 9682, 3200, 2695, 735, 1810, 8385, 8388, 9381, 2399, 6012, 7980, 7852, 9407, 410, 6194, 8922, 7322, 2740, 4915, 5849, 7135, 4551, 4290, 4883, 8216, 2141, 9006, 5691, 8156, 1490, 9235, 1124, 9951, 8604, 8588, 7804, 2708, 5375, 565, 196, 3301, 4024, 288, 3666, 3654, 9449, 854, 3543, 3631, 5115, 8616, 4240, 804, 8196, 2475, 1616, 1900, 3876, 2664, 1482, 4814, 1342, 5776, 6434, 1017, 5349, 1982, 6745, 8834, 3223, 4370, 7226, 6870, 8624, 8866, 5768, 785, 677, 8492, 2009, 2283, 2222, 3407, 7751, 8193, 6539, 557, 9199, 2096, 6388, 7709, 6736, 9176, 2636, 9700, 1830, 346, 6529, 9030, 3560, 7404, 4031, 3338, 1362, 2899, 8708, 1737, 7617, 458, 3978, 9793, 2700, 1867, 2376, 2084, 1219, 7020, 6328, 8701, 8803, 4908, 1235, 6698, 4830, 8831, 5559, 2411, 6330, 7169, 8460, 5054, 277, 874, 1076, 5214, 7960, 6391, 6997, 1002, 6777, 2574, 9285, 4137, 1064, 5957, 6729, 4188, 9909, 9691, 6420, 5478, 3350, 5735, 9056, 1645, 1892, 8894, 8243, 6001, 3055, 420, 7691, 1250, 2717, 3818, 9280, 1210, 8896, 769, 4092, 500, 2952, 7640, 9318, 5839, 323, 4747, 7656, 3228, 1892, 4365, 7082, 6273, 6776, 1061, 8551, 77, 7182, 2672, 6796, 4004, 6062, 6641, 2370, 4654, 8082, 9594, 5518, 3824, 4653, 9851, 3442, 9773, 1721, 7815, 3815, 1767, 5532, 646, 2160, 5967, 1665, 4868, 2058, 153, 4324, 4752, 2721, 3301, 6388, 9328, 5808, 3487, 7347, 7544, 3343, 6457, 1077, 5443, 4898, 8166, 5713, 6839, 7383, 571, 7506, 4683, 789, 3269, 2089, 5867, 8947, 6516, 4030, 5736, 4184, 3264, 6018, 7863, 6278, 9632, 5829, 575, 3430, 639, 3675, 5066, 8306, 6589, 4873, 2566, 2758, 1350, 504, 3358, 8161, 7788, 9673, 3577, 9514, 8876, 7814, 7309, 2964, 1647, 1688, 1961, 2927, 6912, 259, 8485, 7318, 883, 3411, 3253, 5087, 6747, 4326, 2777, 8119, 5922, 7748, 3357, 1761, 869, 858, 8872, 8427, 7256, 5439, 3065, 4913, 5921, 8195, 5260, 9483, 4022, 3928, 1673, 7759, 5948, 9024, 9446, 8544, 148, 7271, 8565, 5252, 7135, 2382, 9777, 3537, 5745, 7646, 2193, 6582, 7499, 9641, 6281, 8592, 9917, 7985, 5681, 418, 2871, 6739, 9710, 1226, 8936, 9934, 884, 5869, 6181, 9450, 8132, 7365, 6398, 412, 8977, 7529, 1981, 5731, 5347, 2459, 2714, 2294, 7002, 8917, 454, 9945, 8142, 7821, 3549, 6711, 6392, 2661, 5852, 6106, 8474, 5491, 265, 8763, 376, 8106, 9560, 695, 8617, 2219, 1424, 7868, 6379, 2502, 2265, 830, 2604, 2150, 425, 6614, 2847, 180, 8911, 198, 3605, 8180, 6267, 6386, 5867, 2087, 9004, 4923, 6336, 9375, 2977, 4994, 6619, 2528, 5576, 5656, 424, 7177, 9559, 6079, 2881, 9099, 1183, 6661, 2116, 6025, 7252, 8789, 1934, 6235, 3585, 9458, 3523, 3333, 4153, 8352, 5507, 6223, 9125, 6927, 8176, 759, 7167, 3305, 3363, 5085, 1486, 4081, 355, 1962, 8160, 338, 3464, 6704, 1217, 2705, 8901, 9109, 4342, 8116, 8621, 4167, 3168, 5880, 3017, 1051, 5620, 9077, 2958, 3675, 2743, 8873, 9081, 1731, 2238, 1286, 8807, 5014, 4163, 8867, 5627, 5882, 2650, 1660, 1695, 9907, 3999, 6067, 6295, 9885, 7022, 5094, 6484, 1760, 8314, 1386, 2190, 7455, 3206, 1004, 4757, 3032, 6278, 587, 463, 1025, 1338, 3789, 9484, 5310, 4000, 9503, 9654, 300, 7887, 8085, 4226, 956, 7753, 764, 5333, 9177, 7214, 8521, 8194, 8118, 6502, 4189, 7379, 6873, 920, 1216, 8241, 6681, 7158, 8261, 7401, 205, 3181, 997, 2341, 7023, 4923, 2490, 9260, 434, 8273, 9920, 8309, 1614, 1805, 5840, 5239, 8997, 4363, 8284, 7587, 7664, 5919, 8229, 662, 3095, 3175, 5540, 4658, 6428, 510, 5950, 1191, 2784, 4782, 4382, 2660, 2189, 8944, 4817, 902, 4439, 4323, 6463, 6965, 3199, 256, 7274, 8741, 5465, 8697, 8040, 6576, 813, 1580, 4408, 6776, 4548, 3974, 4350, 6015, 9227, 1171, 7226, 6765, 424, 612, 5463, 5495, 6436, 4961, 4086, 6347, 6919, 9733, 7341, 8441, 9397, 137, 317, 3183, 9951, 7450, 1661, 7853, 5819, 5028, 2310, 4174, 9512, 3205, 593, 7052, 6709, 1501, 7059, 2643, 3795, 4452, 9939, 5684, 3593, 203, 6081, 5279, 4902, 8618, 7289, 5462, 6706, 9009, 7552, 323, 4310, 8829, 4297, 2728, 9878, 2109, 2431, 3725, 9075, 2452, 8095, 8532, 1903, 9673, 3451, 6328, 6389, 1321, 9374, 1325, 5248, 493, 9018, 2707, 201, 3806, 3517, 2548, 2637, 4702, 7924, 2513, 2063, 1225, 6493, 8891, 2908, 796, 5564, 7199, 8516, 1519, 7091, 2147, 2598, 3311, 9336, 6143, 5012, 7885, 5005, 5939, 9072, 9924, 6808, 9619, 429, 9071, 102, 4776, 1234, 6147, 2409, 1971, 2133, 7009, 8541, 9418, 8842, 604, 4616, 8093, 383, 3534, 672, 7673, 1695, 6762, 3665, 1046, 1797, 4391, 2459, 5562, 1103, 7576, 8511, 591, 2151, 5591, 4066, 6556, 8972, 1867, 3714, 3652, 731, 2492, 902, 6190, 6403, 6573, 3324, 9464, 4197, 3215, 5215, 846, 320, 8845, 4606, 1060, 8516, 4573, 7524, 3735, 5716, 7456, 1221, 9495, 4009, 3794, 1146, 642, 8833, 5326, 3720, 5492, 1425, 9438, 1234, 7275, 4763, 3609, 395, 7408, 5672, 4169, 3572, 8912, 1871, 3683, 9314, 220, 6245, 8317, 5374, 9647, 553, 1809, 7275, 8475, 3082, 6656, 505, 3848, 4474, 4276, 2023, 2249, 5258, 4682, 6652, 4059, 9514, 5101, 5934, 4245, 9395, 5635, 9531, 1664, 6423, 4701, 6873, 2551, 6505, 8596, 8675, 5830, 4506, 2206, 447, 3041, 5089, 17, 2099, 1377, 3869, 1101, 9097, 9914, 9772, 419, 5746, 4763, 6360, 792, 3632, 8422, 1278, 4599, 9617, 6594, 5141, 4747, 9891, 4589, 3366, 8371, 5526, 3235, 4310, 6372, 9079, 3597, 1103, 7764, 5877, 402, 1667, 6236, 5378, 9140, 5135, 2399, 7895, 8959, 7448, 958, 4712, 4702, 9423, 2879, 5144, 8641, 1786, 6499, 8939, 4705, 1425, 8082, 3558, 6746, 1376, 4062, 2703, 2617, 8680, 2028, 6314, 1169, 6484, 4383, 3232, 5730, 3028, 8657, 4340, 6906, 9604, 3797, 1742, 7433, 3100, 7955, 7255, 1959, 2315, 1338, 2464, 4701, 4335, 6973, 5561, 8133, 9686, 3968, 2256, 569, 420, 5865, 9308, 4659, 6057, 9856, 3994, 4637, 7878, 6291, 1706, 6681, 1148, 2680, 490, 4767, 7814, 1322, 1431, 8356, 7857, 442, 5675, 503, 3545, 2949, 9936, 9678, 8775, 6888, 4823, 8892, 3361, 4080, 3365, 655, 8402, 2033, 327, 7183, 4793, 2793, 4926, 1191, 8586, 4867, 5266, 2052, 7008, 6920, 4248, 833, 7095, 3497, 2474, 2419, 7133, 5326, 6046, 4909, 5879, 1529, 9190, 122, 9563, 6568, 3730, 3205, 8242, 6333, 4466, 6301, 4968, 3150, 3400, 8498, 5394, 1863, 725, 1923, 8001, 5088, 7781, 7579, 2827, 9056, 1273, 6604, 4668, 1877, 5725, 5944, 2761, 8593, 3492, 4364, 3011, 9984, 5101, 3660, 4541, 4327, 172, 6186, 1146, 2698, 9747, 8591, 6439, 269, 8216, 8230, 9224, 6687, 7930, 7118, 9174, 6551, 4589, 4533, 7898, 1188, 7407, 9310, 3551, 98, 2771, 8387, 6808, 149, 9378, 6264, 714, 3949, 6621, 8985, 4987, 1716, 3157, 8591, 6442, 9353, 2685, 9357, 5522, 581, 1617, 1136, 682, 4436, 4142, 5968, 7194, 9526, 3673, 451, 5750, 1996, 8311, 4756, 2367, 7786, 9761, 5643, 9848, 7350, 136, 7820, 4000, 9491, 4552, 6069, 503, 2689, 4940, 6961, 1888, 8232, 2104, 9368, 4888, 458, 9422, 767, 5321, 3880, 1043, 6874, 8426, 2147, 318, 7060, 7088, 2265, 7344, 6603, 8193, 8546, 9205, 1578, 5644, 6099, 5967, 7238, 3741, 815, 680, 2778, 2278, 52, 2626, 6309, 2389, 866, 3050, 8737, 1974, 7192, 803, 1125, 8718, 9315, 8734, 6972, 4466, 779, 4836, 1368, 7700, 6053, 3742, 1486, 8787, 8251, 6774, 6093, 8974, 7112, 8711, 2637, 6799, 5915, 8094, 4131, 4951, 9193, 430, 5654, 5640, 7434, 3125, 3240, 7969, 9609, 8920, 9266, 2876, 2609, 9326, 1407, 5201, 1939, 1307, 4794, 7792, 2796, 6469, 821, 1400, 752, 5093, 4227, 2352, 4010, 6946, 1827, 8161, 1844, 6294, 3060, 8168, 1044, 881, 8549, 6198, 6075, 901, 7246, 7950, 9791, 7223, 9739, 8635, 7582, 1049, 7046, 2768, 7019, 3269, 4816, 8477, 6174, 3068, 5363, 9436, 8740, 6119, 3525, 3728, 8427, 3873, 4915, 345, 5637, 4153, 2318, 3251, 9538, 7, 4983, 5121, 3437, 6463, 7447, 7864, 7294, 9168, 5959, 5575, 3888, 1685, 6178, 8226, 7635, 6791, 9532, 8314, 6330, 547, 4158, 6261, 8647, 1020, 678, 466, 8440, 5705, 1219, 7907, 1937, 1132, 4352, 5121, 4199, 8066, 335, 4608, 1211, 8526, 1367, 362, 5001, 4857, 1713, 5578, 8987, 5742, 2102, 411, 1582, 2520, 4273, 6998, 5103, 5238, 4274, 4680, 505, 6654, 6068, 3533, 189, 2281, 6167, 187, 8845, 333, 5572, 7937, 5046, 3283, 2930, 2263, 3328, 5995, 4698, 6335, 503, 2251, 8776, 2310, 8331, 7174, 2353, 461, 3327, 8890, 6968, 3639, 4340, 7860, 1517, 9620, 7470, 5742, 7042, 3078, 2864, 838, 1998, 7441, 3172, 9034, 1348, 954, 6581, 7405, 2062, 3793, 3065, 8100, 2734, 7175, 2715, 2671, 1991, 1269, 5430, 2924, 6509, 1319, 903, 4462, 9855, 2692, 1615, 5361, 647, 3993, 7353, 381, 9168, 2618, 6393, 4964, 1657, 9387, 4354, 9373, 1122, 4886, 652, 44, 8331, 7335, 6967, 7334, 1805, 3098, 8002, 8270, 4534, 826, 6509, 7907, 433, 1446, 1381, 8841, 1109, 8033, 5828, 6345, 7314, 2439, 565, 5661, 1593, 989, 8050, 9879, 3404, 9452, 9336, 7660, 8466, 2599, 886, 755, 1539, 9351, 5653, 2301, 6666, 4397, 2077, 1515, 7090, 8537, 6630, 97, 6011, 7007, 2184, 7041, 1336, 8634, 5852, 7959, 8292, 8563, 630, 8636, 4459, 5956, 5444, 404, 5857, 2158, 20, 8167, 9224, 3283, 7022, 4536, 1188, 9158, 8381, 2358, 5913, 9369, 8563, 605, 9764, 8487, 5740, 1553, 1915, 6942, 2480, 8703, 4788, 8122, 6910, 5628, 3776, 5106, 2684, 2302, 1661, 5451, 5985, 4987, 3338, 5500, 197, 3442, 9470, 8674, 1148, 2905, 8291, 4140, 9082, 4260, 2017, 8810, 3103, 577, 9872, 508, 1540, 6731, 1215, 930, 6742, 2011, 2625, 7109, 7577, 2431, 3535, 3658, 3522, 9970, 7842, 4525, 9444, 2794, 6009, 266, 4063, 1581, 3059, 616, 9957, 493, 7882, 8649, 2545, 74, 5364, 1187, 7115, 2704, 9183, 3725, 3026, 6898, 3242, 419, 358, 4381, 332, 2429, 4386, 9741, 2278, 259, 5491, 697, 1287, 9440, 483, 1925, 3548, 6053, 8080, 2847, 7722, 3366, 129, 5551, 8540, 1740, 1287, 283, 1806, 4201, 3608, 1082, 5767, 9795, 7521, 5769, 2170, 9370, 8059, 4523, 7751, 3687, 8531, 4562, 4090, 1486, 7231, 965, 9699, 9140, 6377, 1038, 6701, 9769, 7945, 7210, 70, 7543, 3889, 23, 8597, 2019, 1716, 982, 5413, 7780, 64, 62, 686, 8103, 3776, 7586, 8655, 2757, 3943, 2989, 2090, 2701, 3799, 8111, 6084, 7638, 2856, 5257, 8427, 5093, 600, 7354, 4539, 1475, 2119, 8527, 8852, 4037, 1492, 4358, 4748, 4265, 3017, 4456, 2118, 2980, 367, 7299, 419, 7990, 3257, 9411, 4183, 3377, 6222, 7046, 1590, 8546, 4985, 6421, 5027, 9398, 4774, 103, 9923, 5030, 2505, 8347, 8829, 2785, 8595, 4417, 2471, 8418, 1955, 9853, 7957, 9207, 7676, 9353, 2978, 4925, 3589, 402, 7550, 3147, 28, 1751, 3839, 5452, 2946, 6655, 1891, 1403, 7911, 3900, 301, 3013, 8572, 3681, 4370, 6184, 8381, 1517, 5543, 3789, 8742, 5318, 4393, 8568, 7991, 9954, 2997, 3740, 7614, 8385, 7465, 5070, 9568, 1270, 9341, 8859, 3430, 2760, 6958, 7004, 1507, 1735, 9249, 7616, 6277, 9439, 618, 7945, 4284, 8140, 5941, 439, 2932, 1722, 7187, 3293, 202, 5191, 8028, 5419, 8141, 430, 306, 3837, 53, 6314, 5086, 4950, 6788, 2705, 9173, 5515, 204, 3041, 8177, 9462, 2539, 1409, 2875, 6076, 8515, 666, 8438, 6953, 5647, 2918, 9966, 5694, 9935, 5527, 5211, 1406, 257, 406, 8582, 2605, 6672, 3632, 4019, 8710, 1072, 1269, 7162, 8608, 8924, 4626, 7369, 6302, 8351, 298, 8247, 5445, 1197, 5377, 7203, 6165, 9232, 2721, 1548, 1539, 5347, 6993, 4096, 523, 4113, 413, 999, 3128, 8251, 5395, 3263, 1091, 7902, 8900, 8655, 7692, 7446, 4009, 2902, 5536, 8407, 8681, 6540, 2044, 6741, 4489, 7734, 6207, 7249, 4217, 5148, 9328, 8645, 5687, 4771, 3399, 9706, 4583, 6137, 2454, 7787, 728, 1789, 3141, 5928, 5163, 859, 4774, 5742, 1458, 1728, 2797, 5000, 879, 8357, 3448, 7468, 6159, 6676, 3538, 5835, 4405, 8460, 4275, 6147, 5945, 2881, 8572, 6711, 925, 2559, 434, 4427, 4887, 1712, 2952, 6180, 4958, 111, 3880, 3221, 1318, 5269, 7539, 7689, 3824, 376, 5388, 3866, 5709, 2915, 4858, 597, 8652, 5597, 5424, 3593, 6562, 2963, 5733, 9049, 4833, 3025, 4680, 4651, 1680, 8146, 2895, 4342, 8042, 77, 9972, 923, 187, 5178, 1777, 7232, 8250, 4442, 9638, 7445, 2022, 5021, 529, 7864, 9419, 8413, 3640, 1240, 1462, 4679, 2158, 339, 9420, 1600, 707, 5331, 1618, 1542, 5363, 8977, 7170, 9236, 2999, 3845, 8426, 2923, 4404, 1465, 9765, 6632, 577, 6393, 6567, 4586, 3912, 5308, 4552, 6435, 2204, 8774, 2547, 6952, 476, 9644, 559, 1615, 8686, 4114, 3081, 5936, 9922, 6232, 1182, 8083, 443, 1915, 6207, 3896, 9714, 2659, 6608, 5589, 4564, 9620, 5487, 7787, 6012, 7333, 3784, 8684, 7269, 9186, 4480, 1459, 8733, 9647, 2956, 89, 6131, 3435, 7749, 9655, 110, 9770, 1837, 8903, 8838, 6029, 8951, 9283, 1440, 7000, 2842, 3808, 9944, 9635, 4224, 9616, 6541, 9500, 4414, 3235, 9008, 2623, 5321, 1708, 7166, 2017, 2341, 3149, 3502, 2993, 677, 1254, 7197, 4480, 3265, 906, 9058, 4055, 6090, 6089, 4359, 2169, 2665, 6280, 1223, 7300, 5517, 3220, 5124, 4307, 2428, 5315, 495, 3736, 2316, 5521, 5920, 6068, 3827, 1247, 8844, 3853, 4087, 8837, 5832, 6199, 8519, 2727, 3509, 9493, 7539, 8675, 547, 9367, 4754, 3345, 4822, 6676, 2670, 653, 9327, 5767, 158, 6047, 3038, 7591, 9198, 2770, 7009, 3372, 8175, 4232, 4070, 3184, 3181, 8487, 1830, 255, 6625, 9465, 4799, 9820, 9850, 8967, 8207, 5637, 1640, 8627, 1533, 8135, 3815, 5144, 623, 5411, 1997, 2611, 725, 6758, 2624, 4513, 7150, 9694, 2392, 1340, 8158, 9879, 5227, 3197, 7323, 6431, 7452, 5363, 8379, 9545, 6736, 5118, 8639, 3334, 648, 9107, 2480, 8778, 5748, 7851, 4226, 2735, 1147, 6548, 1858, 395, 1325, 9091, 9397, 828, 5744, 560, 7996, 3609, 8676, 6129, 8060, 1452, 6127, 4986, 3949, 5565, 8230, 2468, 7764, 4824, 3871, 6366, 8041, 9060, 7981, 7766, 5972, 9606, 5122, 4266, 2900, 9246, 3249, 9593, 8540, 3651, 8863, 6620, 7053, 150, 6964, 1327, 860, 4994, 4661, 6619, 6301, 4479, 367, 1910, 1750, 8905, 874, 6856, 6680, 783, 8089, 8288, 3161, 5943, 1731, 1925, 8750, 8603, 2679, 9388, 3439, 3849, 884, 9879, 4241, 2970, 8647, 1959, 9230, 8411, 4765, 6764, 4780, 5312, 5445, 7718, 6324, 8126, 6826, 4025, 2052, 5765, 5128, 3187, 5869, 9767, 8321, 5851, 6347, 7122, 1723, 1293, 7084, 6394, 557, 6369, 5208, 776, 8412, 2057, 9820, 3618, 9963, 9080, 6044, 5030, 8519, 622, 123, 7316, 6024, 521, 5293, 1046, 7264, 8458, 5237, 8943, 3874, 5706, 9959, 5619, 6861, 2264, 887, 1326, 7752, 2567, 4014, 8180, 2707, 9806, 1206, 3669, 1962, 4052, 9171, 7393, 365, 8919, 6437, 4059, 3069, 4571, 3827, 467, 5320, 2776, 7046, 9464, 3626, 2362, 7226, 1355, 2376, 9984, 9645, 2463, 1025, 2727, 7791, 6238, 2815, 8026, 1188, 223, 3286, 2608, 5636, 1556, 1545, 262, 6691, 1449, 7847, 4590, 5455, 6052, 3597, 9618, 6342, 5861, 4429, 3622, 8667, 9043, 9210, 1674, 2151, 2323, 9633, 2876, 6798, 969, 9672, 6368, 8167, 5860, 5710, 2022, 3925, 8123, 5687, 2654, 1674, 8118, 922, 6575, 1376, 5549, 3835, 9627, 3513, 816, 8885, 9671, 4306, 6091, 5631, 9549, 6414, 1889, 8355, 7474, 20, 5370, 2857, 5442, 7763, 6321, 2947, 4600, 537, 3184, 8478, 2660, 2102, 3832, 4963, 2289, 8672, 4941, 3097, 3978, 855, 309, 657, 8308, 8167, 5498, 6676, 9378, 682, 3138, 6074, 5289, 6138, 4436, 3550, 1927, 6703, 6256, 2519, 2381, 4760, 3804, 9081, 1687, 4847, 8122, 6215, 4511, 4209, 5553, 6605, 9465, 7037, 9589, 2011, 8969, 5179, 8474, 8910, 877, 1432, 2319, 9694, 1442, 5172, 8740, 4538, 5248, 9906, 7005, 3040, 4297, 5926, 9382, 9143, 6351, 7441, 5068, 6578, 473, 4719, 4722, 9186, 1695, 411, 1230, 3082, 4237, 9097, 8460, 1061, 2619, 9898, 2686, 6534, 4115, 8265, 7157, 5178, 9230, 4433, 2745, 9562, 3248, 375, 7935, 5241, 3302, 2776, 7273, 2152, 8284, 2960, 4629, 9378, 2394, 5088, 5713, 3463, 3541, 7898, 1345, 5386, 6021, 8582, 3881, 2211, 3105, 1640, 6269, 5862, 7388, 1587, 3208, 2759, 7153, 3436, 2866, 7410, 789, 9346, 6036, 5963, 9940, 9141, 9132, 2207, 1298, 101, 7933, 8357, 2447, 7910, 6673, 4911, 8128, 7766, 2358, 1389, 5466, 2167, 4583, 9040, 554, 8004, 5258, 5365, 599, 4115, 1547, 610, 8183, 6375, 742, 2127, 9670, 2292, 5402, 570, 8168, 6070, 381, 5352, 640, 2266, 1673, 8238, 1251, 2553, 957, 4488, 7026, 3962, 6454, 2461, 7357, 2075, 7266, 6041, 2273, 9867, 1902, 3351, 549, 7789, 3362, 2060, 6677, 8134, 6635, 9307, 9560, 1120, 7257, 5154, 4222, 6108, 7232, 8555, 408, 7855, 638, 2292, 2579, 636, 6156, 844, 7139, 3136, 3837, 2468, 8966, 2764, 3894, 450, 3639, 8558, 5166, 2317, 9035, 4465, 201, 7763, 3360, 7518, 3969, 816, 8413, 6178, 6135, 2492, 2630, 7142, 9454, 2763, 9387, 2841, 1878, 2790, 7319, 8489, 7925, 1643, 315, 8994, 5613, 9278, 2980, 3882, 5977, 413, 5073, 8404, 3927, 1735, 9653, 1009, 5971, 776, 2717, 9868, 7462, 8343, 3238, 8049, 5382, 6950, 475, 9434, 3087, 1775, 4285, 5390, 6485, 2678, 2790, 3309, 3229, 8325, 7893, 7298, 8502, 3555, 4280, 6477, 2364, 7685, 1405, 6928, 1945, 9526, 9440, 7041, 6327, 3419, 4691, 3847, 3567, 3608, 9969, 803, 3579, 3463, 1842, 8760, 7390, 5653, 7596, 199, 9015, 515, 9548, 2933, 1798, 2847, 7590, 5432, 1552, 433, 8723, 9336, 3600, 7093, 8304, 2076, 4237, 1171, 443, 6888, 9338, 8734, 5651, 5209, 3333, 2890, 8425, 5638, 581, 8892, 3096, 929, 5345, 4293, 7601, 5785, 3694, 7354, 3854, 6827, 243, 7405, 5393, 6663, 6827, 8434, 9589, 448, 495, 6183, 2175, 9726, 2013, 3450, 8863, 4348, 6147, 9640, 724, 2683, 5565, 1473, 184, 1150, 7798, 2688, 5779, 8, 6750, 4522, 1864, 1981, 7803, 6100, 8678, 7317, 9414, 9814, 4250, 5880, 5404, 387, 4640, 2592, 379, 3095, 2650, 4047, 4046, 8952, 6356, 2394, 6020, 5089, 9358, 7532, 2666, 3416, 4642, 6699, 4807, 8020, 7665, 7117, 3608, 5791, 686, 3157, 597, 8535, 222, 8296, 1616, 929, 3408, 1519, 6613, 9197, 1668, 9690, 3617, 4193, 8570, 1880, 5687, 5235, 5193, 4451, 93, 1161, 8899, 2478, 2582, 2853, 9647, 4408, 4928, 8916, 9990, 9748, 4232, 4440, 2695, 1594, 6007, 2319, 8984, 9608, 2019, 5193, 3108, 1322, 2534, 5591, 910, 5492, 273, 7339, 2353, 4068, 3700, 1189, 1940, 8422, 2925, 9999, 6479, 1430, 1897, 6580, 9357, 7238, 2186, 4035, 5749, 418, 8067, 8878, 8722, 6587, 2729, 292, 3395, 7728, 8508, 1311, 8582, 2458, 1092, 9577, 2018, 4623, 4447, 3164, 643, 6841, 841, 8042, 2799, 9508, 1514, 9948, 4389, 3357, 5382, 7146, 1388, 9256, 1372, 5238, 9853, 888, 1885, 5567, 9891, 2737, 5006, 4778, 2612, 2028, 9173, 8699, 1624, 1361, 1711, 6568, 8165, 1078, 90, 6114, 7373, 5306, 7138, 5503, 4196, 6769, 5768, 8704, 5774, 4542, 1633, 1309, 4379, 2035, 9939, 170, 6794, 1686, 1225, 8098, 7811, 3221, 8523, 8393, 7358, 8442, 9023, 5943, 6874, 767, 3270, 9953, 6916, 837, 9551, 5260, 8572, 6875, 5117, 6149, 453, 4232, 8846, 2777, 5278, 7293, 8184, 453, 59, 4304, 7122, 5799, 6476, 415, 323, 7841, 3647, 1487, 2958, 4688, 4553, 3816, 6427, 5554, 688, 1119, 9129, 7976, 8992, 6004, 5564, 5374, 2963, 5077, 865, 5787, 2574, 2048, 9674, 2876, 6085, 6701, 5537, 1173, 8147, 6793, 2544, 5862, 6984, 5121, 9911, 2780, 7963, 1334, 663, 1450, 2089, 8093, 2502, 1992, 901, 1344, 3790, 3575, 9339, 3302, 4343, 2386, 1312, 8030, 2567, 5087, 7275, 1212, 4049, 9516, 2927, 6876, 9427, 9227, 1418, 2640, 6519, 9955, 5697, 7946, 3957, 8578, 2907, 5214, 4444, 1276, 533, 7346, 3160, 7532, 5242, 2804, 9329, 9295, 6482, 7853, 3677, 4211, 9282, 4068, 5726, 4174, 4813, 7338, 5964, 639, 7580, 58, 4370, 9896, 657, 1059, 9555, 6546, 9657, 6925, 8288, 7436, 715, 398, 6327, 7756, 357, 5621, 8571, 6914, 9790, 7933, 2362, 6357, 3699, 1417, 5651, 2702, 6186, 5760, 8056, 765, 6465, 5748, 7200, 2290, 9337, 5064, 7628, 7397, 9540, 4626, 2059, 2334, 2420, 7122, 9837, 7849, 3230, 8886, 2441, 6494, 4004, 2914, 2086, 2719, 8549, 3577, 2969, 8239, 325, 4122, 2688, 1860, 5762, 9169, 2051, 5628, 9613, 6622, 7315, 7827, 8986, 4321, 8610, 7455, 5004, 9623, 4796, 1212, 6457, 8017, 284, 2668, 6231, 3633, 6260, 3138, 310, 1814, 9686, 3944, 9763, 7491, 6975, 9028, 8242, 2049, 6070, 8330, 439, 1050, 3377, 8593, 6271, 874, 2450, 7551, 7022, 273, 8934, 779, 5754, 1496, 802, 2413, 4066, 9451, 354, 5649, 6046, 2284, 7034, 7953, 6642, 3972, 8345, 3093, 1073, 2760, 9277, 4607, 5112, 4383, 8256, 6221, 4655, 101, 969, 7799, 7731, 7012, 4922, 5923, 1496, 4809, 2282, 6235, 9278, 3747, 571, 7203, 740, 1641, 4539, 7281, 6994, 2353, 8392, 675, 1036, 4792, 4845, 1839, 9312, 6956, 9992, 5168, 2401, 9356, 8235, 4729, 1255, 8471, 276, 7210, 8607, 6527, 5582, 1701, 8043, 3959, 4370, 8427, 279, 2338, 6855, 9149, 7925, 8658, 2088, 2967, 8880, 7472, 4048, 1794, 312, 4143, 6205, 3500, 7208, 8298, 2370, 6568, 7605, 7257, 9380, 2066, 5616, 4874, 8701, 8585, 6115, 71, 6573, 3256, 3607, 8893, 1911, 1704, 820, 8717, 878, 3116, 5250, 4005, 7976, 7709, 2346, 2280, 2289, 9898, 1138, 7875, 2997, 8140, 5223, 9924, 5737, 6307, 2919, 1980, 816, 7207, 7685, 854, 920, 6596, 9994, 6754, 8693, 6844, 5260, 688, 9239, 9324, 348, 8514, 3579, 4317, 3912, 803, 9905, 721, 7641, 3310, 5467, 9483, 9197, 9706, 1759, 5912, 1174, 3276, 2887, 9403, 4355, 2591, 4776, 4930, 8524, 2190, 4299, 1131, 2031, 3421, 515, 4506, 9566, 1744, 869, 8992, 6146, 7963, 1889, 4478, 9762, 613, 5044, 2723, 1315, 2848, 4509, 4478, 5074, 6701, 1113, 4302, 303, 1538, 4470, 4676, 435, 3661, 6808, 8197, 3053, 2871, 6602, 4297, 4490, 6722, 4916, 2772, 1929, 3841, 1868, 8605, 2105, 5067, 9205, 9795, 4410, 5350, 7839, 527, 1762, 8801, 1050, 281, 1958, 409, 3136, 2585, 3332, 8943, 4640, 3946, 6240, 5808, 7970, 3216, 9437, 1475, 5709, 4249, 6710, 7620, 3733, 189, 1371, 2331, 30, 5602, 2765, 9368, 9999, 9076, 930, 2895, 3392, 7689, 4602, 242, 8196, 9541, 2869, 2796, 4284, 2284, 1043, 8775, 2278, 4038, 1482, 329, 9259, 37, 4690, 4316, 6368, 5289, 7958, 665, 1380, 991, 6025, 4086, 5386, 4153, 5248, 7171, 6933, 69, 9083, 7995, 6869, 4264, 3642, 7468, 5477, 5145, 5787, 5644, 3539, 5743, 4313, 8817, 9948, 3890, 4320, 9077, 4044, 2839, 4000, 7209, 3204, 8559, 9366, 6233, 3295, 9422, 8259, 6678, 9141, 3231, 2639, 4328, 2262, 1360, 4565, 4830, 1263, 5908, 1060, 9814, 7501, 8681, 163, 8318, 7910, 723, 7673, 5919, 6703, 8500, 3133, 2339, 6556, 4127, 1206, 9449, 2316, 7648, 5124, 6258, 5348, 8348, 2534, 8307, 4794, 2023, 2060, 7326, 5920, 5974, 3612, 197, 4221, 4492, 4131, 5630, 1640, 483, 4718, 210, 6259, 9400, 3323, 2460, 717, 3621, 5465, 461, 3989, 9494, 715, 4685, 3192, 9349, 1603, 7127, 2615, 1707, 7983, 4439, 9387, 6480, 5213, 1672, 8478, 6374, 3385, 8548, 8744, 7837, 6237, 2955, 307, 5655, 8819, 3873, 5524, 3679, 8808, 4724, 9962, 8171, 5628, 7852, 8221, 733, 2864, 3773, 4969, 536, 8519, 8200, 5348, 9698, 7301, 4479, 4553, 2284, 2475, 6590, 9348, 8279, 6767, 5153, 971, 9909, 987, 8801, 99, 3819, 3911, 8400, 9092, 4087, 6069, 5244, 8045, 650, 4565, 8149, 1887, 9706, 4115, 726, 6931, 1828, 7191, 2323, 9103, 9101, 488, 8206, 456, 4915, 7684, 2017, 9407, 2285, 3623, 9146, 2723, 7989, 897, 8476, 9915, 8840, 8459, 2914, 3174, 9454, 581, 3170, 6312, 5180, 2506, 6063, 3037, 5029, 7678, 9814, 2092, 2099, 7736, 4713, 2783, 798, 5538, 8358, 8810, 2598, 970, 5453, 718, 8381, 3257, 9642, 8644, 7721, 4895, 7360, 7647, 7501, 9860, 9930, 962, 4098, 7149, 3807, 6722, 9382, 2146, 8289, 8208, 2976, 7267, 7444, 8922, 7036, 3011, 1864, 6971, 7209, 4234, 8920, 7678, 4416, 5187, 7064, 5904, 674, 2076, 8342, 2972, 3001, 2844, 362, 5001, 8764, 5495, 711, 6757, 6988, 6049, 721, 488, 9741, 8635, 7229, 2160, 9874, 3602, 2777, 3300, 9562, 8245, 2921, 2889, 8596, 2594, 8887, 3199, 6703, 8667, 1331, 1223, 9643, 5614, 9262, 5367, 6384, 369, 8034, 7909, 1371, 9131, 6342, 1872, 8604, 5910, 1694, 7919, 6502, 9442, 7448, 7559, 1705, 465, 985, 7428, 8621, 2250, 8252, 788, 5232, 9956, 2316, 6384, 7924, 2967, 3415, 2197, 339, 2874, 9772, 4698, 5039, 5409, 7335, 2422, 9193, 5978, 2423, 9064, 3595, 4682, 4007, 8194, 8947, 8539, 5540, 3045, 9991, 236, 7140, 125, 5748, 2847, 1656, 3170, 2458, 1732, 6696, 8500, 1074, 3020, 1967, 2793, 7676, 8280, 8746, 9488, 2099, 5835, 3664, 942, 3780, 3623, 3568, 1943, 6038, 1747, 1967, 9049, 3297, 3603, 8992, 1263, 9253, 6199, 5120, 5843, 4896, 4383, 2548, 5404, 78, 9853, 1777, 7234, 1171, 5990, 1921, 4241, 8186, 337, 7690, 5337, 5292, 6144, 4756, 8736, 5162, 2073, 9723, 2510, 2772, 6865, 6743, 5168, 5644, 677, 5673, 9877, 3875, 8605, 4655, 2680, 9499, 533, 1256, 6399, 1752, 5808, 4430, 2379, 9895, 7605, 2026, 8141, 57, 6300, 7243, 3201, 1077, 1495, 6098, 7916, 3049, 6031, 7248, 820, 8960, 9708, 6921, 528, 308, 3700, 8253, 4181, 4783, 6183, 3824, 1122, 4024, 5980, 9504, 5755, 3183, 5211, 1649, 7859, 7832, 1744, 7192, 9012, 7292, 2064, 5278, 2712, 1552, 1611, 7193, 5030, 7843, 770, 3581, 8637, 2730, 1697, 747, 3488, 1939, 4545, 6900, 7640, 6541, 8335, 6697, 6028, 5522, 4995, 2173, 1230, 2093, 2801, 6457, 7075, 9728, 9180, 5643, 5411, 3488, 2500, 8035, 3441, 2413, 3003, 7563, 3358, 4770, 9536, 9607, 9443, 1421, 4697, 824, 2846, 4771, 6834, 4185, 3732, 8847, 6449, 8181, 1031, 7155, 176, 5594, 5441, 5143, 1286, 6359, 8988, 3808, 3930, 5514, 3118, 4407, 7502, 5102, 4489, 1873, 9244, 9223, 3584, 2958, 462, 6492, 8201, 3479, 8079, 4544, 6734, 3322, 2183, 3868, 3555, 5468, 3321, 3007, 3458, 7718, 797, 796, 5290, 7868, 2386, 2782, 4731, 7375, 7989, 7083, 7262, 8431, 6814, 6797, 3851, 3091, 6624, 196, 5667, 1183, 3847, 210, 2250, 1850, 5178, 6536, 4511, 8920, 5572, 1359, 7177, 1597, 6274, 3395, 5529, 5799, 5381, 5502, 7034, 6823, 6388, 3793, 1911, 9323, 6198, 6379, 7527, 6120, 2097, 1975, 3698, 1665, 2209, 2131, 2445, 1497, 8569, 3880, 8801, 99, 4714, 7029, 2070, 4191, 3298, 2912, 1930, 1694, 9089, 8405, 2510, 6699, 6506, 4149, 7086, 6308, 2366, 3640, 3406, 4767, 1422, 5097, 7956, 8018, 8257, 3639, 1846, 9398, 823, 9872, 243, 5995, 8253, 8721, 583, 6602, 5262, 4116, 9429, 5370, 8040, 587, 4395, 3004, 1249, 794, 9857, 7999, 1009, 4546, 5044, 7455, 5414, 3861, 2289, 4341, 8678, 9226, 725, 8090, 6695, 2741, 1349, 9978, 5071, 3784, 2103, 2106, 9269, 806, 6489, 2235, 9450, 6533, 5044, 8119, 6136, 2646, 4699, 5406, 5723, 3725, 4607, 5447, 615, 6337, 159, 7797, 2871, 6884, 2309, 1433, 7325, 6574, 4929, 8548, 6637, 5384, 2079, 1871, 7944, 650, 674, 4475, 3900, 4168, 1178, 4097, 9551, 8560, 3172, 6123, 865, 4805, 4067, 2072, 858, 5926, 2334, 6796, 7161, 8486, 5229, 2791, 9644, 9896, 9244, 6371, 2050, 5363, 9933, 9935, 690, 5024, 3551, 9044, 6592, 2064, 1850, 9308, 6531, 9257, 6730, 9486, 8096, 2029, 1251, 2832, 6649, 7601, 2352, 3089, 6449, 435, 6139, 5098, 9447, 9238, 1138, 6157, 6504, 4305, 3899, 2721, 6397, 7045, 6767, 898, 7404, 4292, 1757, 18, 2142, 5566, 6289, 3435, 5485, 389, 3320, 4440, 3523, 8197, 2438, 6689, 8780, 4048, 1978, 5898, 1678, 3496, 8228, 8987, 6985, 1991, 672, 218, 6597, 6318, 4521, 3842, 9393, 1808, 1986, 8368, 3837, 6689, 1726, 3932, 7951, 1174, 1812, 8870, 896, 8242, 8730, 8267, 30, 4878, 1899, 3395, 9975, 7527, 2593, 8993, 1534, 7591, 2119, 9653, 4533, 612, 6315, 3638, 9247, 2537, 977, 9537, 2459, 8375, 6631, 7818, 1294, 3381, 8394, 5972, 5807, 9640, 8260, 7522, 208, 1122, 8680, 8987, 511, 2442, 795, 2598, 226, 2539, 3431, 7784, 1794, 8093, 3478, 2675, 1825, 8741, 9072, 4885, 742, 7157, 2850, 9579, 7785, 2921, 3334, 1870, 786, 7869, 5376, 186, 3997, 3843, 8198, 7282, 9340, 9908, 4794, 5607, 19, 5840, 2036, 7427, 8373, 7004, 9899, 3471, 7642, 9310, 6121, 1659, 5816, 8643, 7042, 9269, 1926, 5299, 3223, 3095, 7118, 6187, 1689, 1627, 7584, 2440, 662, 8633, 1512, 3668, 2720, 704, 9580, 3699, 4663, 7342, 1333, 1150, 1037, 5340, 5901, 8336, 4471, 9567, 7933, 1303, 3284, 581, 8957, 4787, 2589, 694, 434, 3940, 8096, 2142, 3898, 6807, 3543, 3812, 8328, 1337, 3833, 4591, 6209, 518, 8624, 4108, 7149, 5674, 6689, 7091, 2114, 6942, 5377, 2051, 3424, 5727, 9365, 5783, 7522, 5959, 3902, 223, 2064, 2892, 7852, 4626, 1772, 350, 6362, 1912, 7954, 9320, 8398, 8676, 5728, 4928, 1618, 5616, 5718, 4467, 959, 7238, 4442, 5786, 5807, 4667, 8144, 5938, 3115, 4247, 2262, 525, 3812, 670, 7889, 9029, 1591, 276, 4412, 7545, 487, 7341, 2352, 4316, 9300, 1021, 3808, 1413, 6083, 1125, 9996, 2757, 2880, 148, 1629, 1583, 7547, 6351, 1464, 9054, 105, 8984, 2311, 2118, 3896, 9636, 8640, 6330, 684, 6278, 699, 9530, 5385, 2376, 7525, 8649, 8156, 2479, 5591, 7818, 3279, 2092, 2232, 3227, 7707, 1752, 750, 2182, 2197, 424, 6179, 534, 6775, 9665, 9030, 5124, 1308, 2456, 6171, 4629, 6870, 9193, 2832, 8717, 5681, 6406, 1799, 2557, 4503, 3961, 7298, 4829, 1472, 1377, 7829, 9347, 5393, 9861, 8179, 5284, 7418, 9003, 8011, 4183, 3287, 6826, 9625, 7420, 6121, 8937, 160, 1789, 4561, 2606, 5364, 9416, 7076, 5631, 81, 8180, 9085, 4932, 9167, 8315, 6044, 185, 9706, 2942, 9463, 5845, 3723, 2980, 3187, 675, 4789, 1131, 2810, 508, 1891, 4974, 7240, 3424, 8213, 5230, 572, 4590, 7106, 208, 1398, 8923, 1095, 2114, 4073, 5344, 2712, 7098, 3278, 9225, 6553, 4379, 2904, 4577, 1743, 4904, 9948, 8925, 9564, 5320, 3787, 9160, 4137, 7158, 3381, 6201, 5950, 1999, 7501, 5020, 4297, 1461, 6545, 2076, 113, 3069, 3650, 8517, 7319, 8814, 920, 8163, 3201, 5753, 7961, 6967, 1090, 4523, 728, 3444, 7903, 9973, 1148, 4456, 281, 6129, 1296, 9881, 1621, 4940, 2659, 5319, 6554, 6901, 6896, 1943, 3363, 3093, 530, 3314, 426, 2688, 921, 7367, 6982, 1234, 7253, 7372, 1925, 4817, 2365, 10, 4017, 9817, 1602, 2795, 8854, 6119, 3278, 7303, 8401, 761, 5443, 5672, 3187, 1366, 3178, 4316, 4049, 703, 4378, 6859, 1279, 2691, 2944, 3819, 5739, 3258, 9337, 6748, 6054, 7125, 2660, 3933, 852, 2639, 2102, 1510, 9163, 8611, 3805, 2267, 3271, 5294, 6096, 7354, 4545, 8347, 7065, 7088, 3782, 5663, 7925, 3596, 3878, 7042, 6943, 389, 709, 2729, 1330, 3179, 9391, 8250, 7693, 1271, 9401, 4408, 1222, 8379, 5235, 3819, 6919, 523, 3461, 2835, 8197, 9355, 7694, 2903, 8431, 7144, 2591, 4095, 7658, 3533, 3596, 6680, 4741, 6378, 2075, 7250, 8050, 5902, 8661, 4396, 5626, 7880, 5860, 8228, 7777, 4597, 6886, 2620, 695, 7092, 9456, 3742, 30, 3132, 7967, 7143, 164, 8759, 798, 8372, 988, 1470, 4901, 7744, 7192, 6037, 3567, 5971, 784, 237, 9190, 2695, 9584, 5154, 5020, 7371, 6575, 8883, 5495, 3826, 2646, 4812, 6944, 6605, 9022, 1396, 2519, 857, 7428, 4912, 5156, 8756, 6920, 7236, 9957, 5407, 6193, 4185, 7542, 5178, 2648, 879, 8228, 5550, 695, 1797, 9893, 5843, 675, 3745, 1516, 9750, 3161, 9545, 3459, 1984, 5841, 3584, 8584, 5271, 1132, 7540, 7149, 8763, 8278, 2745, 9488, 1623, 3857, 5515, 9987, 5515, 4555, 2821, 1948, 5773, 3809, 5434, 5367, 7577, 9277, 4402, 1042, 8425, 1202, 6113, 4177, 5386, 9870, 5993, 7884, 5950, 2675, 4558, 7003, 3590, 6182, 1299, 5641, 421, 1420, 6459, 9350, 3340, 8119, 2304, 2839, 9320, 3796, 490, 4223, 7805, 2879, 5729, 7367, 1106, 2603, 2176, 2506, 1411, 9002, 3660, 4920, 534, 5358, 8325, 5274, 8067, 6987, 3304, 9992, 6122, 4306, 9688, 2434, 7028, 5428, 6901, 5576, 1346, 1478, 1831, 7905, 7858, 5957, 9017, 4041, 2845, 4759, 5316, 5851, 8300, 7731, 2683, 960, 6936, 5191, 2486, 6691, 9874, 996, 1284, 3476, 1226, 7871, 1159, 8848, 3626, 689, 1221, 6130, 1227, 8699, 9307, 7592, 4989, 6448, 5000, 6686, 724, 32, 2147, 6044, 5778, 5052, 8685, 7940, 7292, 594, 1805, 8541, 4498, 2028, 9642, 8915, 3778, 1142, 3200, 7959, 9525, 7060, 6554, 2750, 759, 7605, 3651, 4710, 5650, 2286, 6146, 9522, 5573, 534, 5915, 7978, 2340, 2931, 4603, 3278, 2681, 3519, 7439, 304, 3832, 6221, 8703, 7103, 5801, 6775, 8260, 946, 9012, 7728, 5463, 4780, 5342, 8723, 8246, 1763, 3671, 4075, 6939, 1894, 3301, 2268, 9094, 4919, 8058, 471, 872, 371, 8874, 9480, 9247, 5794, 6468, 9317, 8712, 6833, 845, 4518, 8075, 2529, 5732, 8368, 472, 2737, 7059, 6548, 7832, 7049, 3009, 1726, 9770, 6740, 2458, 399, 5346, 8128, 9053, 7577, 4384, 5470, 3818, 6861, 9802, 3510, 4125, 9204, 8375, 3389, 8916, 8751, 7452, 192, 411, 1787, 1727, 392, 4532, 4695, 7115, 3049, 6648, 383, 5978, 1906, 5088, 9713, 8287, 4861, 1515, 2558, 9295, 756, 7968, 2273, 9623, 4621, 1370, 5133, 9258, 5686, 254, 6501, 7659, 7038, 148, 1987, 3922, 6449, 9578, 4612, 3970, 7365, 7021, 1992, 2756, 7835, 1927, 7377, 333, 3246, 5441, 8267, 4248, 2184, 2699, 9579, 6970, 1986, 85, 6046, 2959, 724, 937, 627, 7539, 7711, 4230, 5314, 9808, 4586, 1678, 5133, 2235, 2153, 6687, 7962, 7068, 8635, 1277, 5018, 9371, 2331, 4260, 2414, 3187, 2637, 2467, 1370, 7300, 1008, 1883, 5029, 7109, 8129, 1808, 7883, 8498, 7362, 166, 6524, 8749, 1521, 4902, 474, 9524, 202, 9521, 6529, 6208, 2072, 978, 1562, 9320, 2828, 2398, 484, 4786, 4438, 1322, 118, 4438, 3431, 1372, 5748, 1119, 1440, 4248, 1201, 4851, 7670, 4956, 3944, 3439, 2998, 6325, 5405, 7281, 4562, 2039, 8512, 9800, 1936, 7337, 1340, 1664, 2903, 5536, 6778, 8440, 5952, 9646, 7686, 314, 5123, 7140, 2420, 6734, 258, 422, 7012, 786, 7426, 3914, 449, 8930, 9038, 8746, 9262, 7698, 4232, 317, 6848, 7806, 3970, 2257, 507, 4339, 4749, 7972, 585, 4531, 8143, 8213, 5066, 6592, 975, 1474, 4726, 7132, 5792, 8374, 6755, 1888, 695, 8084, 7913, 4930, 3327, 1822, 5808, 5088, 6343, 4117, 7825, 7449, 9766, 5266, 1676, 3017, 7248, 4299, 4960, 3861, 4195, 2593, 6405, 853, 9634, 2483, 1775, 9942, 3767, 1560, 2589, 60, 9909, 131, 950, 292, 4154, 6277, 3437, 4614, 7553, 8532, 6945, 1134, 3344, 7828, 5503, 5977, 8901, 8996, 4652, 3819, 4002, 2219, 4392, 9510, 7431, 7209, 3056, 4420, 8705, 9254, 160, 1179, 1669, 4624, 9829, 122, 1298, 3504, 7600, 7567, 5061, 737, 5127, 9803, 1293, 6853, 7801, 4371, 5726, 558, 5737, 5923, 189, 4690, 9199, 3853, 3961, 9350, 9103, 5212, 6499, 9177, 3047, 2539, 8951, 8220, 6535, 6750, 9888, 1623, 6964, 9978, 7297, 3427, 4434, 6463, 7643, 896, 7891, 1708, 3767, 7198, 9647, 794, 679, 9210, 6974, 6850, 3416, 7611, 320, 6591, 9803, 2208, 2812, 1129, 7393, 5674, 6566, 3052, 7031, 2297, 4618, 5677, 5860, 683, 7305, 8307, 926, 274, 8198, 840, 3247, 2406, 548, 8406, 2146, 2265, 7561, 6733, 4437, 608, 999, 8695, 6343, 8651, 98, 76, 5785, 2620, 1663, 6348, 7276, 777, 6301, 1280, 8450, 5470, 140, 3552, 6848, 5522, 7056, 6317, 7528, 6186, 9378, 1962, 3250, 9151, 7750, 8185, 2831, 7778, 142, 4707, 2765, 2059, 9969, 8590, 7663, 5382, 2942, 5181, 428, 7647, 7301, 9295, 6690, 7157, 4535, 9680, 6328, 2027, 5405, 7574, 7391, 9123, 8747, 1807, 2980, 2661, 6769, 4773, 2736, 7019, 5688, 9512, 33, 3539, 5603, 8859, 920, 6368, 2832, 2, 4421, 5636, 9712, 3465, 5008, 5783, 2364, 2703, 6496, 9369, 6559, 5492, 9511, 6651, 4802, 7571, 2060, 9878, 6999, 1052, 6233, 1548, 2073, 4923, 6517, 3815, 2714, 2553, 5887, 2424, 8770, 9687, 9580, 6069, 5656, 7786, 3634, 5586, 4420, 5447, 3472, 1112, 5639, 5381, 244, 7917, 6569, 4468, 5713, 6311, 1455, 5354, 500, 426, 2245, 9188, 3440, 8340, 3696, 6502, 2963, 8848, 5213, 5569, 9026, 9307, 4255, 6415, 3770, 1652, 1972, 6104, 2513, 7821, 9048, 8883, 1409, 4240, 3677, 5819, 5443, 1626, 1285, 4695, 8838, 8808, 5519, 2300, 5576, 337, 9327, 8389, 1762, 5607, 4216, 6049, 6550, 4701, 4388, 4237, 644, 3848, 1655, 7226, 9559, 3462, 7580, 9404, 23, 327, 6884, 502, 3834, 8485, 5712, 1614, 254, 9668, 6554, 6546, 8998, 6366, 1199, 9287, 7140, 8424, 3650, 3084, 2269, 4249, 5372, 28, 6433, 2102, 1455, 4001, 8218, 6687, 160, 5498, 6359, 6181, 17, 8473, 816, 5772, 8389, 9494, 5268, 2463, 9114, 6281, 6125, 6544, 6470, 684, 7533, 8919, 4022, 1407, 8620, 5627, 167, 2762, 5935, 6354, 4933, 3470, 569, 1625, 5231, 9402, 7731, 2093, 577, 4714, 3285, 3545, 4177, 3297, 2410, 4266, 8360, 6361, 5656, 2136, 3103, 7870, 4867, 4940, 1722, 4766, 2872, 7687, 7247, 4341, 108, 2251, 8084, 2185, 165, 5997, 2056, 9686, 3221, 1148, 2572, 4983, 199, 1579, 7687, 3681, 3171, 5754, 6564, 5609, 372, 9456, 6263, 4251, 8065, 9295, 7247, 3954, 4105, 4437, 953, 6556, 5192, 8817, 7404, 3774, 5310, 9614, 8257, 6598, 5243, 9648, 400, 6936, 5819, 7354, 3850, 8125, 7387, 7974, 2802, 8808, 6915, 1191, 6780, 2696, 5855, 7722, 1007, 193, 6553, 6413, 7316, 556, 1023, 6954, 521, 946, 3722, 9553, 2736, 7652, 5697, 9226, 1057, 993, 676, 1361, 804, 8398, 5122, 6862, 4116, 6550, 191, 7620, 8581, 6302, 6002, 4769, 3611, 9913, 6998, 8887, 6096, 2910, 931, 6422, 9673, 284, 453, 6267, 8692, 3676, 2623, 9436, 6862, 8437, 5392, 5805, 9584, 5219, 409, 8659, 51, 4704, 1655, 3883, 5335, 6722, 9485, 2237, 621, 6564, 3576, 5568, 6373, 6985, 9255, 4917, 6810, 2782, 6279, 1440, 231, 8032, 8184, 9612, 7529, 7227, 8904, 9238, 5744, 1938, 4230, 9262, 5807, 1557, 3425, 1360, 1760, 1001, 7676, 1218, 3018, 9531, 6160, 4212, 8521, 7157, 1917, 3815, 913, 6474, 9267, 4337, 3572, 426, 2092, 6001, 9669, 228, 8499, 8630, 9248, 7413, 780, 6208, 1164, 4087, 21, 7241, 8887, 4853, 3916, 3788, 4996, 3924, 7448, 9771, 4214, 1415, 7812, 9157, 5932, 4493, 4616, 4004, 1653, 3291, 752, 5231, 2948, 5150, 7582, 5471, 7181, 6152, 8116, 5804, 1999, 6630, 2273, 6798, 8171, 3593, 5205, 4043, 2471, 6138, 7714, 6080, 7644, 5299, 1051, 4083, 8869, 2853, 6436, 183, 9455, 5156, 4808, 9009, 8153, 9430, 459, 5500, 4584, 2146, 9107, 3638, 1177, 2423, 21, 931, 575, 8888, 813, 2959, 7974, 2021, 8689, 6198, 6221, 9257, 3372, 7779, 7131, 550, 1735, 3838, 8327, 5508, 1480, 6247, 8009, 4767, 3025, 3102, 9703, 8729, 2042, 5749, 1305, 9489, 5252, 9880, 825, 5109, 2898, 3310, 483, 7629, 9793, 3158, 4096, 555, 6183, 10, 899, 7364, 956, 5051, 44, 6693, 9066, 1684, 5114, 9579, 8872, 314, 4070, 886, 6802, 418, 5912, 331, 5956, 6099, 1039, 5977, 291, 8525, 5442, 1800, 458, 7878, 2716, 3678, 435, 1184, 876, 8905, 2137, 1373, 247, 7299, 97, 6423, 37, 8744, 4633, 2250, 5299, 9804, 322, 6824, 8466, 5821, 2887, 9587, 7204, 9143, 2481, 5730, 9336, 84, 2036, 8645, 8220, 5263, 9232, 6586, 921, 7993, 6756, 8950, 2399, 4752, 9751, 1607, 482, 9581, 9611, 6561, 7749, 5381, 7963, 4024, 6279, 5859, 8043, 8227, 6623, 6612, 4280, 5002, 680, 3490, 7084, 5739, 875, 9714, 4085, 8780, 3453, 6512, 4697, 3568, 4908, 7207, 9422, 4694, 9144, 7980, 3200, 7280, 2431, 3914, 9124, 1989, 3028, 6553, 7275, 818, 5062, 8052, 4037, 5227, 6706, 2471, 6041, 8193, 1866, 9205, 6078, 968, 2564, 4287, 5130, 6895, 4848, 836, 5693, 5695, 2977, 4860, 5705, 2695, 996, 1396, 3712, 5797, 7075, 8960, 6793, 4666, 825, 7098, 8458, 7285, 2339, 1048, 3194, 6724, 7265, 1913, 5036, 3903, 6083, 5202, 609, 5515, 3341, 4746, 4014, 365, 601, 5150, 661, 9946, 6900, 2577, 6870, 343, 9928, 4044, 4965, 793, 1226, 7035, 7254, 1794, 3481, 9983, 4329, 287, 8445, 4234, 6578, 2331, 790, 9574, 4531, 8284, 51, 1991, 1097, 2093, 1485, 7418, 8769, 1235, 5370, 3487, 6985, 6445, 4780, 7228, 3922, 6340, 7536, 7520, 9604, 227, 8798, 9525, 6719, 8802, 2449, 4046, 6346, 1848, 9314, 5609, 9038, 522, 1427, 7301, 7265, 1246, 2094, 882, 9950, 9870, 8118, 3158, 7549, 5105, 3709, 2339, 5511, 2312, 2587, 8189, 9652, 9525, 5632, 7496, 5978, 1597, 3321, 1515, 8138, 4847, 201, 7458, 3423, 3221, 7543, 8892, 3197, 5243, 1862, 3801, 8414, 5706, 1178, 2102, 2251, 3668, 5852, 4256, 8967, 3904, 8991, 669, 2068, 2325, 7946, 2671, 4881, 8458, 3992, 5341, 4358, 58, 5259, 6414, 9699, 5322, 9575, 7790, 8030, 6307, 3743, 995, 387, 1124, 7316, 1384, 3933, 6347, 916, 7295, 6609, 270, 5967, 9841, 1691, 3022, 5773, 1911, 6764, 293, 9788, 773, 3147, 4739, 4785, 1847, 2008, 9639, 416, 5341, 5125, 2777, 9764, 4429, 7619, 2067, 7063, 608, 2449, 1610, 292, 4922, 5435, 4414, 9200, 3943, 5803, 926, 9005, 4709, 7637, 9571, 2070, 1760, 3498, 358, 7179, 6990, 9536, 9699, 5786, 7456, 31, 6876, 7551, 2404, 5044, 8393, 5308, 3018, 4699, 5082, 2404, 2397, 9823, 3168, 5331, 1834, 642, 8847, 9440, 5715, 6797, 2618, 415, 6594, 9993, 2631, 8717, 342, 621, 7407, 8774, 2220, 6334, 1556, 463, 9172, 9360, 5680, 724, 934, 4556, 3097, 5428, 3609, 1727, 8189, 7732, 4416, 6207, 6989, 9165, 5493, 2166, 6172, 6521, 8152, 7666, 1369, 8558, 8159, 6796, 3419, 1092, 7296, 4193, 2513, 6747, 7542, 7434, 9476, 7520, 3157, 3697, 6049, 3291, 6289, 3060, 5701, 8619, 3470, 9639, 53, 9709, 253, 7453, 396, 9428, 1057, 466, 5309, 5734, 808, 939, 6315, 6117, 3979, 9618, 1116, 2509, 810, 8806, 8270, 7699, 3782, 5083, 8253, 9335, 442, 1877, 5309, 4217, 2706, 5722, 6220, 8114, 4107, 7147, 9516, 9411, 8495, 4194, 2962, 3338, 4832, 874, 7525, 3337, 6288, 8005, 4243, 2810, 7939, 5724, 8719, 8286, 2276, 9702, 5316, 4848, 9733, 3071, 1149, 2759, 5448, 3508, 2100, 8302, 652, 3281, 5906, 874, 4619, 6985, 8554, 2066, 1819, 9296, 991, 6646, 4965, 574, 2139, 473, 3694, 9384, 6277, 3145, 3521, 2221, 8235, 1813, 8374, 9470, 9333, 7523, 3300, 9430, 7971, 8740, 6677, 4639, 2863, 8121, 3159, 8876, 8169, 8228, 7286, 957, 408, 2194, 6574, 4388, 2081, 9679, 5546, 6096, 895, 8943, 1419, 4362, 9072, 9362, 5825, 4190, 9907, 6358, 3046, 8844, 9739, 7183, 1854, 3866, 4812, 4909, 9771, 8787, 8743, 3047, 4214, 6548, 3203, 8912, 5076, 1253, 9175, 3956, 7057, 5395, 7912, 1795, 5171, 6342, 4250, 76, 5354, 8270, 7859, 2234, 8398, 2037, 7045, 8787, 3099, 2188, 2135, 9092, 2743, 7899, 4337, 1741, 116, 1479, 2238, 5955, 4631, 1066, 6670, 8461, 3132, 5579, 9089, 2007, 4762, 8414, 2472, 6657, 9751, 8038, 5732, 2385, 4841, 1613, 5894, 9272, 9324, 8149, 9521, 6265, 2401, 2117, 1964, 8086, 7466, 1071, 7594, 7933, 2964, 8830, 9486, 6015, 4088, 9236, 6423, 6587, 2347, 3557, 7386, 1190, 5274, 2200, 6381, 332, 800, 5773, 7041, 7871, 5710, 3377, 4102, 7811, 1796, 9938, 8227, 6947, 4854, 5794, 5877, 4889, 478, 4486, 9749, 5370, 8350, 797, 5278, 1760, 4252, 7520, 6297, 8676, 8540, 7089, 9628, 6318, 4125, 2095, 2141, 6143, 9454, 803, 7700, 5161, 932, 3171, 5402, 1044, 7438, 3285, 9597, 8140, 8196, 671, 7343, 4570, 951, 32, 9266, 5520, 3944, 2945, 6024, 6384, 5511, 3240, 6007, 7065, 9481, 7873, 5625, 5746, 8371, 8869, 9579, 1186, 2872, 6826, 4093, 89, 4781, 1408, 5150, 6863, 6781, 5363, 8326, 4128, 2108, 2702, 8507, 3331, 2255, 8181, 4015, 6626, 5707, 8620, 4819, 3328, 5617, 7615, 6975, 9481, 5115, 8335, 2090, 5502, 4741, 2787, 6954, 343, 4700, 7924, 6834, 902, 709, 1078, 9294, 5514, 8491, 7306, 9305, 3621, 1388, 962, 3685, 4780, 8541, 9474, 7376, 9357, 1194, 820, 5041, 3399, 192, 5300, 1904, 5073, 3535, 286, 1507, 1841, 8023, 3545, 2506, 541, 5862, 9694, 4253, 1632, 7640, 3600, 7598, 8128, 5831, 2564, 1657, 5111, 1355, 1229, 9267, 7214, 9950, 3694, 723, 6387, 3178, 1542, 1669, 6776, 6005, 4843, 4088, 4253, 8147, 6798, 4882, 5138, 2071, 1601, 913, 5051, 9477, 2601, 5003, 8533, 5816, 4408, 8161, 3763, 7147, 9086, 4459, 7612, 5695, 3586, 2326, 7487, 8465, 2978, 2067, 3336, 637, 1936, 9825, 4092, 4720, 1335, 8896, 8638, 4028, 9188, 3603, 9901, 2416, 2915, 798, 8541, 1216, 7504, 8132, 6938, 8743, 7119, 4879, 490, 7938, 3349, 355, 7878, 9393, 4998, 8155, 5368, 146, 1912, 6385, 3080, 3928, 758, 2752, 9955, 8860, 3007, 3351, 4902, 1446, 1507, 8270, 7489, 2451, 6434, 6790, 7588, 7258, 8763, 1434, 8826, 83, 2034, 2489, 944, 9896, 1314, 2606, 8880, 776, 4206, 750, 6369, 5257, 236, 9889, 6159, 7299, 44, 2390, 8183, 9800, 5895, 2221, 4765, 6911, 3160, 3285, 984, 155, 2060, 2174, 7364, 5295, 4647, 409, 790, 7095, 9857, 4779, 9710, 3664, 2620, 8619, 5210, 4696, 7734, 6308, 5805, 1006, 4695, 4528, 3985, 7159, 6933, 9448, 4354, 4357, 1166, 2606, 3285, 3562, 6430, 1787, 9363, 8023, 684, 5070, 7107, 2218, 3327, 7554, 3245, 5222, 7852, 8247, 168, 8424, 1001, 5658, 8760, 770, 6390, 7258, 9255, 6535, 7375, 5339, 1054, 2411, 3458, 5924, 9025, 7665, 1713, 9206, 9472, 810, 8057, 5080, 7696, 9932, 3075, 466, 6933, 8992, 978, 8184, 5478, 6926, 6235, 1187, 3249, 9751, 3114, 3231, 8594, 8553, 3611, 5874, 4323, 2992, 1438, 6095, 8955, 1474, 1993, 4010, 798, 1707, 8686, 6302, 8915, 7114, 6298, 8153, 5111, 687, 7997, 9568, 5948, 9794, 2536, 8112, 3825, 4842, 961, 1766, 2816, 5643, 37, 6270, 1132, 1350, 8650, 3892, 4065, 660, 5279, 7804, 2028, 8666, 5162, 5383, 9249, 602, 4740, 4061, 4215, 2402, 8549, 6985, 6550, 2988, 4206, 5758, 7638, 1546, 975, 1065, 4135, 915, 4000, 2285, 6730, 8688, 6616, 6579, 5615, 416, 2715, 2699, 227, 3981, 2802, 1320, 8228, 8732, 3106, 4941, 429, 3387, 9651, 3778, 5416, 210, 317, 7834, 3851, 9179, 6490, 8985, 2206, 1334, 8703, 8504, 1214, 722, 5945, 3694, 1661, 6275, 3613, 2421, 6400, 3962, 2483, 407, 1192, 9304, 6439, 7706, 5575, 410, 5081, 8175, 6569, 1532, 5191, 7521, 3788, 2063, 8796, 5450, 3408, 9, 324, 5470, 3633, 7634, 6486, 6413, 2504, 6010, 9138, 2730, 3829, 2915, 1882, 8638, 3721, 6271, 8048, 4015, 9278, 3389, 9397, 4972, 8906, 9327, 1634, 4984, 3845, 9232, 1920, 9813, 4951, 420, 7443, 4259, 6969, 6313, 8, 8530, 8150, 2701, 5370, 5210, 5544, 9234, 3464, 8403, 1464, 9751, 7000, 6956, 1633, 988, 3381, 7125, 4586, 6655, 1944, 7559, 9260, 8628, 5850, 2406, 6062, 7050, 1116, 420, 3348, 7079, 8746, 8110, 6763, 9430, 4353, 3617, 5896, 5518, 1390, 1793, 4158, 6950, 4117, 9115, 2865, 7094, 4763, 2276, 8093, 9701, 795, 1990, 5174, 6291, 2730, 7214, 655, 7408, 9424, 5080, 2108, 7818, 365, 3363, 7288, 835, 9534, 4261, 813, 2293, 1633, 591, 2018, 8255, 619, 1061, 7185, 5197, 7734, 3302, 8451, 4770, 8906, 806, 1105, 6698, 7348, 739, 6025, 5841, 138, 7067, 121, 1448, 1350, 1788, 5245, 926, 8324, 4633, 3235, 2681, 6864, 6490, 8751, 1457, 6439, 2441, 242, 374, 7252, 7840, 8180, 9122, 3313, 4122, 9764, 8412, 4777, 2463, 7218, 3602, 70, 2301, 8845, 4273, 3840, 8201, 7785, 179, 9112, 1168, 3030, 6086, 7832, 2495, 8902, 7762, 1107, 568, 5723, 3734, 1737, 4434, 2619, 4634, 2727, 7842, 4551, 3069, 543, 5007, 6705, 1143, 7552, 3606, 1306, 9451, 7914, 3818, 3307, 2786, 9281, 2966, 5389, 1804, 4606, 9766, 5199, 9343, 2474, 6760, 4626, 1642, 936, 3303, 3528, 7862, 2805, 6102, 4225, 4152, 1104, 9881, 8038, 1210, 7495, 2341, 6891, 3971, 4527, 7917, 8705, 527, 5207, 7959, 4881, 544, 5146, 1073, 9712, 7748, 1888, 699, 9642, 1494, 7697, 8909, 5120, 1851, 1716, 5503, 7832, 531, 525, 5703, 4295, 2116, 608, 1146, 7289, 1062, 5346, 6856, 5505, 996, 2765, 1918, 9984, 7611, 7988, 2109, 9495, 1323, 1065, 5646, 8506, 809, 6413, 1003, 4946, 6827, 3602, 3590, 8452, 5047, 6919, 4951, 5116, 1670, 2071, 9, 3910, 7304, 6521, 422, 7481, 4695, 6618, 901, 8612, 8643, 6413, 2204, 5338, 516, 2747, 1296, 8518, 964, 122, 1665, 2756, 9382, 7492, 9177, 256, 9538, 3146, 2416, 1278, 5838, 8681, 1275, 1791, 9420, 1490, 5244, 4384, 6904, 4613, 5189, 7047, 3240, 6488, 1380, 7545, 6532, 7364, 7544, 6429, 6840, 2126, 58, 9472, 1660, 3498, 5679, 5068, 587, 1295, 3584, 4788, 2323, 8929, 8597, 1736, 8493, 3946, 355, 6137, 763, 7061, 9852, 3576, 4821, 402, 9149, 4298, 5504, 480, 9870, 8003, 9594, 8237, 7964, 8452, 5083, 3567, 7513, 4008, 3400, 6647, 9503, 8019, 5299, 3767, 4002, 8040, 9707, 781, 2630, 7226, 9392, 1293, 2616, 3084, 113, 1380, 6909, 7220, 3847, 87, 2121, 9910, 9814, 9780, 4424, 267, 7605, 421, 7101, 6377, 168, 607, 8717, 9155, 282, 3420, 5900, 1184, 1984, 3343, 4303, 1032, 1839, 6967, 7114, 8185, 225, 5118, 3647, 4974, 1555, 1517, 7736, 1963, 5967, 3550, 6023, 3499, 6095, 9024, 8688, 7821, 3828, 8163, 2464, 1177, 594, 3913, 2460, 6857, 2094, 3139, 6179, 8793, 6043, 7040, 2132, 6701, 3727, 9345, 2728, 6024, 7437, 5735, 2348, 4637, 59, 8962, 8026, 2755, 416, 8390, 7182, 3088, 8578, 8274, 1354, 2323, 3453, 8784, 9516, 6580, 1043, 2860, 2503, 8855, 4240, 331, 2509, 4236, 2404, 4589, 4630, 1392, 1484, 2310, 6954, 4523, 2445, 3336, 3378, 1839, 4193, 6909, 5382, 2676, 5319, 2385, 6987, 9062, 9723, 5444, 7300, 506, 3485, 4574, 1003, 8081, 1590, 6953, 7477, 2662, 1630, 5066, 620, 3117, 7579, 8085, 1462, 1874, 5095, 7391, 7349, 3783, 2154, 9028, 380, 4144, 7565, 9197, 7685, 159, 5619, 335, 204, 935, 3544, 1962, 7348, 2677, 100, 550, 8667, 8304, 8640, 9154, 8170, 6577, 2395, 6672, 6802, 7138, 2209, 2450, 7663, 1231, 926, 4602, 7003, 1359, 3364, 150, 2329, 8653, 4222, 2902, 274, 4497, 9355, 3551, 2372, 1305, 3885, 9955, 3194, 9617, 66, 4011, 6682, 5161, 8357, 126, 5479, 1998, 5352, 9837, 6557, 9642, 9466, 3814, 3557, 1615, 709, 3597, 2599, 5751, 5422, 2131, 6778, 309, 845, 6902, 4357, 7130, 9035, 4074, 6608, 3091, 2543, 1726, 5088, 6690, 9578, 2616, 3362, 3180, 1574, 3389, 3616, 2885, 2919, 4048, 8900, 3214, 7926, 6199, 1528, 4340, 2503, 6879, 4510, 4655, 2088, 1707, 9426, 4209, 7155, 2257, 8615, 3400, 9609, 9191, 1410, 6617, 1785, 2631, 8874, 5301, 7944, 6215, 3878, 3085, 4024, 2455, 3352, 3291, 2392, 5527, 2793, 6593, 4509, 4920, 5075, 7598, 4577, 4206, 5766, 4419, 4147, 7123, 6887, 6661, 8787, 6775, 3629, 3058, 6594, 4253, 3654, 7686, 2708, 4425, 7195, 1467, 1496, 5622, 9337, 2520, 4280, 9026, 5927, 2606, 7548, 1846, 8090, 5331, 4808, 517, 1774, 355, 9978, 9546, 1241, 4146, 8716, 5187, 1121, 8904, 3051, 7501, 4335, 3460, 3775, 5769, 1350, 7267, 1566, 9159, 7286, 5819, 1746, 1915, 1914, 5355, 6273, 7280, 7305, 9462, 9317, 5195, 7298, 9090, 3759, 8525, 3069, 4672, 3272, 8421, 3775, 7063, 1828, 1088, 8936, 4086, 6730, 7397, 6608, 5, 6073, 3181, 7137, 5894, 643, 8700, 5139, 2375, 5593, 7994, 102, 888, 7600, 5455, 5616, 8076, 9980, 5307, 8110, 6698, 7058, 6319, 8985, 5752, 9663, 170, 6266, 9721, 3368, 6023, 5967, 5797, 1810, 5420, 9125, 1867, 6919, 5401, 4696, 9086, 5221, 7312, 1012, 7231, 2992, 3716, 4773, 3661, 4095, 3668, 5181, 2557, 8875, 5921, 9429, 2261, 7800, 7462, 4095, 6567, 9225, 423, 8190, 3324, 9668, 6809, 6463, 4820, 9057, 1850, 3383, 7276, 8622, 3746, 3663, 8887, 896, 2170, 8016, 567, 4561, 7059, 7006, 6038, 4292, 5606, 3459, 9424, 3453, 3671, 6963, 7122, 5672, 604, 2070, 7801, 2757, 2907, 8027, 6004, 1568, 4231, 4719, 6784, 8816, 7769, 838, 6535, 28, 6643, 8296, 9941, 8215, 483, 8470, 5981, 5273, 3678, 9327, 2471, 9667, 6596, 1697, 6749, 4407, 7024, 1317, 7246, 7613, 9840, 1167, 7258, 5631, 7883, 8800, 4028, 3939, 7432, 5169, 5490, 3390, 8681, 3687, 3231, 3773, 9369, 2791, 563, 688, 3003, 456, 1057, 5476, 6546, 2615, 3086, 3885, 6564, 3091, 3607, 7873, 4842, 5937, 6106, 1620, 5262, 5696, 6251, 2303, 2934, 8987, 7564, 8975, 5844, 7316, 4613, 8851, 403, 2857, 6221, 45, 1436, 464, 3172, 6719, 4778, 4182, 2315, 9657, 7060, 3524, 6195, 4384, 5554, 741, 5366, 958, 8076, 2055, 5728, 803, 7874, 2650, 9657, 811, 3006, 5299, 6919, 7375, 7699, 1614, 3936, 6547, 1564, 868, 5409, 439, 2858, 3173, 3633, 3667, 1503, 5853, 3794, 3493, 8327, 1737, 9253, 5962, 4112, 4319, 1039, 6517, 2496, 3364, 9531, 8299, 3606, 839, 2425, 8269, 9893, 8116, 8858, 6397, 5578, 3553, 3358, 7945, 1082, 9876, 9244, 7286, 1980, 4771, 6190, 8306, 7587, 3167, 3871, 8420, 2010, 482, 9536, 8914, 4106, 7028, 4913, 767, 3430, 3325, 4287, 9789, 6187, 7041, 962, 8249, 6364, 4336, 9228, 1091, 5473, 3304, 5014, 9759, 6433, 2379, 8080, 8362, 3975, 8378, 402, 6877, 6462, 2467, 2272, 8542, 4619, 3367, 2750, 8140, 186, 3820, 5145, 8736, 5960, 8627, 2397, 4672, 7023, 827, 559, 9260, 3449, 2482, 8689, 4225, 1661, 6185, 35, 1535, 1993, 5024, 4121, 344, 5902, 7201, 1148, 9121, 7184, 9989, 9064, 9555, 3306, 1831, 5479, 1345, 7422, 8061, 9549, 3608, 8662, 8620, 7167, 2476, 7359, 6374, 889, 5319, 9917, 1901, 604, 1977, 9099, 2172, 8152, 8971, 6600, 6993, 3832, 4646, 2107, 1263, 9120, 6743, 4766, 1943, 2531, 6619, 4574, 8116, 3972, 1615, 6085, 7760, 2583, 373, 3840, 6080, 317, 5413, 8293, 6505, 1299, 9043, 5494, 4611, 2259, 5542, 1294, 8661, 9148, 3675, 1646, 3160, 8250, 9454, 5757, 3481, 9478, 2657, 9945, 9440, 8907, 3614, 763, 3394, 1359, 8173, 9084, 7445, 3650, 3963, 7396, 1548, 9263, 1733, 8780, 6119, 6402, 7308, 7777, 2197, 3724, 1512, 7779, 3304, 7730, 8725, 8908, 8994, 5912, 1726, 1486, 3795, 2850, 7359, 776, 5264, 7497, 810, 134, 2454, 956, 3805, 4762, 9001, 3280, 4754, 7497, 4386, 3591, 4261, 4833, 5927, 2953, 5867, 902, 7339, 4965, 3330, 1590, 1756, 9110, 7792, 3471, 895, 1163, 3545, 6732, 2350, 2730, 9038, 6812, 931, 37, 8707, 4404, 712, 3172, 5826, 7432, 197, 8683, 7229, 329, 6552, 2325, 7549, 144, 1932, 477, 7335, 6843, 1993, 3642, 9127, 5028, 2771, 4539, 4825, 2344, 2173, 779, 6132, 2489, 6534, 5945, 1976, 6179, 9481, 2328, 6372, 9248, 1919, 6976, 3748, 5587, 554, 1918, 3448, 5054, 6819, 7013, 4254, 4919, 484, 3048, 2094, 705, 6175, 596, 2889, 4375, 1742, 7880, 9618, 5463, 8664, 5079, 6364, 1790, 2167, 3465, 4846, 661, 116, 9632, 7131, 3433, 7049, 8612, 7353, 6757, 1375, 5802, 5529, 5481, 1624, 4608, 2740, 1002, 2175, 7670, 1997, 9433, 3964, 7674, 6835, 9422, 2956, 5905, 7474, 8818, 8339, 2678, 76, 5203, 5103, 9536, 699, 7150, 6232, 6956, 4852, 2669, 5876, 8016, 358, 9667, 4882, 2116, 2761, 1636, 8985, 4639, 983, 5336, 4273, 2167, 4530, 2673, 8589, 2730, 1619, 1318, 137, 7906, 1263, 8739, 1312, 5068, 4727, 1512, 6635, 4804, 6945, 2556, 6069, 7395, 637, 7034, 6739, 417, 5852, 3615, 1495, 9083, 1926, 384, 6683, 8080, 4670, 2417, 5457, 8527, 1275, 5350, 4533, 5360, 530, 519, 790, 6717, 1670, 1687, 4476, 112, 8001, 8584, 6086, 5076, 2094, 3515, 6257, 5961, 9328, 5904, 811, 5363, 6220, 5250, 8202, 3322, 2386, 6867, 7777, 921, 1474, 8844, 6729, 7159, 2814, 9563, 3080, 4784, 6761, 5974, 5713, 4884, 2905, 3957, 2700, 1299, 5011, 726, 2552, 8678, 9908, 2314, 9417, 3457, 8250, 7169, 130, 7765, 169, 2547, 3135, 7197, 8567, 5323, 8985, 2922, 4842, 477, 6184, 7210, 3502, 544, 8111, 5474, 6750, 4627, 4987, 423, 7430, 6549, 7852, 6976, 1832, 1297, 4758, 5095, 3571, 9629, 2610, 5855, 287, 9857, 9269, 3700, 9368, 2987, 3377, 4302, 2832, 2054, 8478, 3271, 9528, 7484, 743, 6804, 5078, 8001, 3300, 2454, 3316, 1347, 6901, 5867, 239, 1251, 1444, 5950, 4010, 8824, 9562, 511, 2186, 3547, 6547, 7902, 1325, 7868, 6045, 9851, 3160, 6898, 4939, 7690, 1641, 1009, 2973, 5179, 3485, 8741, 3133, 4528, 2005, 7560, 8503, 1432, 5167, 1517, 5909, 9458, 1550, 8777, 9801, 6546, 8500, 7623, 294, 9620, 9425, 8375, 9661, 1358, 4413, 6588, 2400, 8240, 4893, 3457, 8107, 2359, 7440, 5331, 3845, 4766, 6670, 6571, 4252, 4409, 7992, 5761, 6569, 2131, 5233, 4918, 4119, 8143, 8461, 8084, 6258, 2016, 9094, 6515, 7050, 7877, 9828, 9784, 7354, 191, 1056, 5729, 5222, 9081, 8201, 2538, 1844, 623, 4314, 2992, 2072, 7727, 2630, 217, 36, 9429, 9332, 8104, 4058, 9788, 8022, 6683, 6467, 5276, 2465, 4374, 3200, 7037, 1537, 3549, 2014, 6522, 9313, 7743, 7097, 4875, 5332, 7207, 3488, 6672, 324, 6089, 2329, 8632, 7122, 7255, 3981, 7282, 3861, 8611, 8927, 1675, 2033, 792, 1448, 9287, 5791, 3001, 8772, 3902, 9333, 8226, 984, 1625, 5747, 6318, 5574, 2432, 1893, 7685, 4462, 2479, 1281, 7919, 4466, 3428, 4269, 7218, 596, 5789, 2897, 8471, 4100, 4368, 9994, 7188, 9329, 1197, 3736, 745, 9531, 6324, 6067, 2641, 236, 586, 8715, 7088, 8717, 5042, 5827, 3969, 1616, 5670, 672, 4159, 1466, 4944, 6720, 8125, 2464, 4872, 4522, 5518, 4650, 398, 1933, 9984, 8933, 9714, 2535, 8931, 4086, 4263, 1745, 9197, 7864, 9926, 46, 6489, 2872, 6316, 5108, 2202, 6329, 9036, 6146, 9859, 1550, 1149, 7782, 6326, 2880, 2619, 4871, 5852, 3372, 2663, 5278, 6648, 4081, 4190, 4307, 2835, 9912, 1563, 4603, 4520, 9201, 1550, 3996, 9996, 7260, 4545, 1377, 6728, 5833, 319, 3356, 3445, 2146, 4942, 6394, 9376, 8717, 3341, 5612, 6329, 8747, 9280, 7877, 1160, 7805, 6855, 6892, 2810, 8960, 9908, 4740, 4704, 5613, 7090, 3176, 5983, 520, 9842, 8523, 6705, 3928, 5799, 7830, 6954, 6818, 1525, 586, 8124, 9426, 1122, 8543, 1729, 3322, 6929, 7169, 1231, 4143, 1461, 7150, 6870, 9089, 7096, 853, 5485, 4394, 7195, 1460, 2425, 4476, 1015, 3507, 4316, 3319, 9048, 953, 1612, 7791, 8171, 8738, 8875, 6402, 732, 9659, 1767, 6530, 7087, 4290, 3572, 4480, 1511, 9402, 1861, 3971, 677, 9042, 6501, 4575, 7732, 9553, 7277, 4082, 4136, 9928, 7735, 4048, 5241, 4078, 3578, 692, 2410, 4243, 1358, 2422, 9155, 7031, 1748, 6453, 4654, 2083, 2956, 8637, 8457, 7961, 5045, 8076, 427, 7895, 7027, 9016, 2228, 5245, 3675, 7647, 9760, 7001, 8058, 4982, 4022, 1511, 4139, 7386, 5055, 676, 9343, 4557, 637, 8212, 9174, 3469, 5028, 9703, 7890, 9781, 6093, 3433, 5663, 5819, 7794, 6165, 458, 7375, 8832, 218, 7993, 2408, 9215, 8513, 1340, 3760, 328, 5397, 7684, 9135, 647, 2889, 8382, 5576, 7409, 4378, 8040, 4706, 3602, 496, 2460, 7427, 8472, 8393, 9375, 9165, 8880, 6527, 5138, 5706, 1997, 2799, 7350, 6619, 3057, 9739, 9072, 6412, 9339, 3591, 259, 264, 8842, 7865, 9448, 2452, 2064, 9819, 6064, 7027, 9517, 7318, 9636, 8423, 961, 2736, 3882, 1918, 7756, 3146, 3309, 2372, 1078, 5167, 2018, 4908, 7633, 1431, 3090, 4023, 7374, 9439, 2534, 6639, 2242, 4660, 5893, 1182, 2028, 8073, 5690, 9331, 2066, 9128, 3293, 8835, 4844, 1662, 2144, 8782, 323, 5581, 8955, 7662, 9847, 639, 5720, 7254, 7646, 7774, 1533, 2455, 2129, 3168, 1417, 2943, 2362, 3536, 8590, 7883, 9953, 2511, 5075, 1564, 9521, 3603, 3110, 898, 1981, 631, 5395, 8071, 5549, 926, 6992, 7820, 4665, 1517, 9646, 7803, 554, 2090, 1870, 1800, 4890, 412, 1987, 7805, 5895, 1182, 5640, 6544, 222, 2580, 2173, 3296, 486, 7897, 267, 2622, 5902, 6648, 4220, 9076, 3255, 2024, 1170, 7874, 965, 4418, 2746, 2501, 7509, 1546, 4977, 5576, 4413, 2661, 5774, 861, 1819, 8468, 3494, 6458, 1077, 8683, 9987, 8631, 9841, 6154, 9068, 7394, 8341, 7189, 2873, 4225, 3196, 8276, 5492, 5292, 3855, 5504, 6751, 7098, 7440, 125, 7456, 3923, 220, 2010, 1286, 9680, 2319, 9179, 1341, 8895, 5788, 4934, 8857, 824, 3743, 5520, 1624, 7110, 3579, 8904, 8374, 7417, 5721, 4440, 9130, 6765, 6419, 3413, 6098, 4182, 1053, 7284, 5478, 4350, 9862, 9752, 9495, 6982, 357, 9285, 8664, 7123, 4293, 8370, 1755, 3647, 8406, 5721, 9179, 4584, 952, 586, 5015, 7121, 2078, 9028, 9893, 5039, 6561, 392, 7358, 6791, 9787, 5427, 2741, 8169, 7222, 1477, 2920, 6892, 3297, 9719, 6199, 9646, 2725, 6418, 2486, 4711, 9377, 3316, 8675, 6186, 905, 813, 7787, 4479, 6994, 3204, 9042, 1367, 2863, 5430, 209, 8106, 5203, 1298, 3428, 6230, 8515, 7939, 3508, 9570, 1042, 7850, 4546, 8141, 7728, 4469, 7253, 6041, 8476, 9116, 5899, 4171, 2448, 5857, 8302, 540, 9078, 3975, 6737, 7632, 7920, 6608, 6254, 6646, 8292, 7021, 2483, 5287, 4451, 3987, 5305, 4131, 2617, 3211, 3348, 8571, 2954, 1758, 1614, 342, 9044, 8527, 908, 4247, 6805, 607, 1798, 4434, 7543, 1102, 3876, 9061, 4966, 980, 2858, 7015, 5941, 3245, 9230, 5058, 9367, 4386, 1621, 3928, 5111, 5726, 1728, 2560, 3045, 1381, 5792, 1850, 1642, 3781, 848, 5921, 1355, 8192, 217, 5805, 4077, 1620, 2288, 3487, 6444, 1829, 3768, 2220, 5784, 5159, 7369, 3794, 6734, 9794, 5735, 6004, 6098, 4950, 2487, 4796, 9825, 4227, 4819, 6702, 5318, 4312, 7041, 9507, 104, 4286, 9650, 3724, 2501, 7092, 6447, 3331, 3245, 2983, 6295, 2711, 5188, 9175, 6542, 6670, 979, 97, 7182, 3391, 6705, 4118, 7092, 6871, 1411, 9180, 2921, 3972, 2097, 2869, 5575, 8730, 5163, 6774, 1534, 7669, 3396, 9589, 9242, 1964, 6001, 3840, 6227, 3829, 4186, 160, 2191, 6933, 2191, 136, 4966, 7694, 4404, 3685, 4873, 3489, 86, 4204, 7319, 7672, 4230, 5833, 947, 7057, 393, 9000, 7268, 1077, 3739, 1415, 2594, 1480, 1182, 1613, 6854, 7779, 1053, 9951, 7782, 2497, 9142, 8453, 2315, 1240, 7457, 711, 2793, 9024, 4037, 7152, 2099, 3334, 1332, 1561, 4288, 7518, 8128, 5157, 4577, 7785, 9537, 3843, 1269, 7257, 2354, 7325, 7446, 6803, 8005, 5196, 8334, 5377, 9919, 3964, 5038, 1172, 5313, 2892, 7893, 753, 9982, 3610, 5346, 7004, 5401, 2024, 5553, 7662, 7771, 2024, 9088, 1240, 4622, 1485, 7903, 4642, 2878, 6796, 810, 2083, 546, 6148, 5704, 3280, 5646, 5444, 2862, 7454, 954, 5568, 9566, 3201, 2911, 894, 7310, 6958, 6065, 3790, 3330, 3565, 242, 2053, 8689, 1659, 4618, 9298, 2200, 4150, 1641, 2130, 281, 6607, 1385, 3956, 7752, 4664, 896, 670, 6409, 4112, 5000, 7200, 1646, 9493, 1561, 7015, 9175, 8659, 4699, 2939, 9171, 3835, 7877, 7968, 9997, 3886, 6911, 838, 7430, 3091, 6096, 4205, 7513, 225, 1941, 3522, 6250, 1068, 8276, 6424, 706, 1753, 8714, 2110, 6319, 7521, 8665, 6914, 2794, 8320, 1305, 4403, 3387, 6800, 4658, 3357, 4752, 8401, 9853, 4335, 8666, 5027, 3222, 7322, 2346, 3133, 9826, 8859, 7558, 728, 7144, 8820, 720, 3249, 3897, 26, 3253, 1857, 8243, 1935, 3449, 4252, 5906, 4489, 6419, 5617, 7119, 9089, 3566, 2355, 8252, 3756, 1794, 5064, 2195, 9330, 4950, 236, 8245, 5261, 6701, 3452, 9396, 6020, 7856, 6640, 9622, 9177, 8071, 5987, 7027, 1937, 4196, 8074, 3124, 6636, 4002, 5974, 6454, 8434, 3450, 4169, 2889, 2847, 1679, 3247, 3229, 6875, 2121, 3265, 1516, 8990, 6227, 1971, 8118, 4667, 4227, 6577, 821, 4335, 3720, 8825, 5424, 8512, 9740, 732, 5778, 6248, 929, 7769, 9891, 7570, 9723, 9138, 8542, 6253, 6108, 7733, 8510, 4638, 5356, 7695, 3867, 2169, 3623, 860, 491, 4163, 8830, 9366, 1065, 2835, 9868, 8195, 2377, 3430, 2527, 5819, 5005, 5245, 7296, 9061, 453, 7863, 3716, 4363, 2498, 3434, 5952, 3280, 4756, 7459, 6256, 3599, 6794, 568, 9363, 8316, 9482, 2498, 4309, 1157, 3608, 8631, 4098, 3906, 7513, 1015, 9872, 5730, 9886, 666, 7954, 8414, 3594, 8502, 6212, 335, 9170, 2671, 7330, 8224, 5852, 9021, 5863, 5994, 6570, 7254, 7702, 2279, 630, 5998, 1788, 7063, 266, 1116, 9102, 3573, 8184, 8549, 8656, 3487, 6869, 1636, 3374, 3184, 4860, 4792, 1618, 3594, 3552, 5223, 8956, 7593, 7712, 1631, 8133, 9842, 6461, 9189, 9266, 2246, 3864, 4564, 6484, 9266, 4957, 1445, 1230, 8253, 362, 6404, 6943, 3952, 3471, 9625, 4250, 3897, 8558, 9219, 492, 9703, 7131, 6372, 3917, 1529, 9180, 2643, 7732, 5479, 2960, 3824, 9566, 2519, 3442, 9701, 8953, 2027, 1339, 8863, 4343, 1008, 7085, 4720, 1622, 7184, 8297, 7882, 8162, 8769, 3758, 5154, 7489, 2776, 5242, 4026, 6085, 1271, 3758, 7130, 8117, 931, 254, 7887, 3313, 3454, 1457, 8899, 6062, 7466, 7764, 7119, 8770, 6281, 6700, 9911, 866, 7331, 3807, 8433, 3786, 5449, 5066, 7719, 7006, 3794, 2786, 1891, 5374, 7008, 389, 797, 9577, 2936, 1730, 8800, 9147, 6051, 7963, 6876, 4740, 9851, 9926, 4464, 3957, 6042, 3051, 5868, 7179, 435, 5445, 1315, 6241, 6697, 1857, 9828, 1987, 6955, 520, 2881, 6370, 6544, 1645, 9570, 3220, 8327, 4029, 1833, 2688, 113, 9633, 3490, 5704, 2777, 2711, 9956, 9128, 9181, 1840, 5514, 7283, 1651, 9301, 8806, 4398, 7190, 261, 9364, 5115, 8038, 507, 708, 37, 2785, 1492, 4841, 198, 6361, 4610, 8803, 1429, 9359, 5665, 7995, 1865, 5442, 2101, 8404, 5745, 3140, 8364, 4693, 5248, 2540, 1170, 7146, 1394, 2999, 9139, 5355, 9818, 6001, 9105, 3682, 4001, 420, 7842, 1674, 1337, 1007, 7361, 9506, 8270, 2513, 3191, 3576, 2001, 9772, 3843, 9655, 5353, 5160, 7839, 5366, 8894, 8501, 196, 7720, 3906, 5763, 5470, 5826, 731, 357, 3967, 9293, 5874, 141, 6293, 1838, 2203, 3637, 6173, 8210, 3206, 1917, 7682, 248, 4800, 3915, 5598, 7608, 1322, 6635, 812, 7519, 422, 9280, 6845, 779, 4047, 8864, 1053, 6330, 1233, 8414, 7802, 6542, 1535, 8702, 1434, 826, 653, 8089, 7944, 8849, 4771, 9700, 6977, 5826, 574, 1208, 4455, 8715, 5020, 422, 1652, 8580, 534, 9581, 4954, 2096, 7265, 8014, 8456, 7689, 4296, 2754, 8202, 7568, 3280, 9876, 7119, 3123, 245, 3936, 6461, 1878, 443, 3330, 8755, 8583, 2310, 8285, 7075, 8255, 9361, 7347, 4197, 1312, 3523, 3990, 782, 3623, 4565, 1846, 2745, 3842, 5042, 6949, 1632, 1381, 7726, 4368, 5360, 6924, 9505, 2643, 4751, 8384, 8062, 5875, 7364, 9599, 7944, 4596, 1849, 9096, 269, 350, 4637, 5300, 6046, 5258, 7178, 5070, 7901, 970, 5624, 4876, 3008, 8808, 6788, 8549, 4567, 7555, 3775, 8481, 2509, 3548, 2420, 9497, 8775, 3490, 3373, 5201, 6314, 5640, 8199, 6151, 67, 9551, 960, 1231, 6478, 4991, 568, 2121, 9667, 2206, 3632, 9731, 6439, 8725, 6837, 5520, 1837, 1714, 9521, 5885, 2396, 1848, 1282, 1152, 5820, 575, 4064, 9040, 7348, 7038, 6349, 5239, 3409, 8963, 8128, 4836, 9609, 6156, 8330, 4911, 7027, 7264, 7946, 6345, 3403, 1064, 9211, 6826, 7176, 4862, 9063, 23, 9544, 51, 4000, 1285, 2603, 7992, 8764, 1489, 7383, 2603, 6821, 8629, 9581, 3302, 5526, 7159, 6869, 2293, 1906, 2484, 7015, 3664, 8365, 2838, 980, 500, 9490, 9887, 8806, 6445, 9129, 7315, 6782, 6218, 9006, 7111, 1822, 7796, 3102, 3984, 7805, 3352, 1418, 5606, 318, 9912, 4651, 3778, 4638, 1508, 4817, 6173, 4523, 3039, 7067, 5417, 7390, 2143, 7914, 1688, 4800, 2022, 1327, 9007, 3073, 769, 278, 3564, 9868, 2416, 6279, 3231, 792, 7197, 8079, 1936, 416, 1789, 1086, 445, 7457, 2053, 7086, 5557, 3671, 4915, 1666, 1940, 1282, 9370, 8164, 2670, 1792, 1573, 5411, 7197, 2395, 812, 4995, 4990, 383, 8604, 4335, 6999, 2879, 2920, 2661, 7083, 7656, 2555, 8439, 2936, 4984, 3982, 7442, 6442, 1415, 5313, 2602, 2366, 620, 8298, 6944, 9541, 8374, 7383, 4639, 7077, 2082, 6732, 5567, 5619, 2466, 13, 1239, 7593, 4905, 8791, 9372, 5383, 8857, 2258, 1520, 4462, 5873, 4930, 4138, 4052, 3613, 7329, 1804, 1910, 3852, 2996, 4428, 3469, 3990, 3947, 9753, 8922, 6542, 3239, 8003, 312, 4820, 6568, 4776, 4630, 9755, 4366, 4184, 1847, 765, 1603, 9328, 1535, 8891, 7296, 1077, 1195, 3364, 9503, 8001, 7563, 1633, 8094, 5330, 7443, 7570, 4941, 9989, 7962, 1721, 2535, 9775, 9847, 505, 8716, 566, 8807, 7517, 4337, 9982, 6722, 3942, 5958, 6657, 4812, 6887, 7505, 1318, 3656, 3221, 8190, 9267, 6882, 1178, 2194, 9921, 8264, 2239, 65, 2044, 7397, 3408, 1550, 4210, 6061, 2044, 6356, 298, 8375, 9760, 8994, 3275, 8507, 2319, 4032, 938, 1437, 7519, 8878, 9071, 6936, 2166, 2914, 736, 9743, 4747, 2077, 5908, 1287, 9705, 7602, 9893, 2222, 5502, 3718, 5346, 6765, 2586, 8175, 5160, 8657, 5500, 4405, 4442, 603, 3468, 677, 6530, 5223, 5801, 790, 1771, 5471, 21, 6587, 3741, 3870, 6267, 244, 7432, 2543, 49, 815, 825, 6383, 3396, 1099, 647, 1045, 7325, 5198, 4420, 7083, 6856, 1110, 1760, 3142, 7029, 2814, 4142, 2185, 9703, 9891, 9501, 5686, 8117, 3750, 4229, 6748, 3456, 4041, 3325, 9734, 4037, 5464, 1953, 4906, 2558, 4211, 9065, 3504, 4041, 1500, 5134, 1062, 6246, 5335, 7196, 1555, 3370, 6604, 7700, 3474, 9914, 6062, 6049, 3467, 3685, 6211, 4159, 348, 1856, 7330, 7680, 27, 7274, 7171, 7976, 2133, 6446, 3024, 8317, 4848, 9439, 6934, 7999, 1166, 6707, 5220, 2727, 8939, 2386, 807, 1223, 8835, 8833, 5695, 6847, 1650, 8020, 9867, 4272, 8993, 4086, 8456, 7220, 4349, 4790, 8767, 8812, 6417, 1678, 2570, 585, 5926, 2775, 3430, 9057, 6642, 3979, 6408, 3328, 3508, 3621, 5323, 8057, 8113, 3829, 9793, 6667, 2204, 9202, 6578, 549, 7195, 7506, 3753, 5340, 6602, 6266, 6047, 3731, 8062, 4391, 5651, 3546, 2688, 8721, 4112, 7549, 6798, 9205, 707, 4064, 2042, 845, 8351, 5650, 2939, 4968, 1828, 5639, 8661, 891, 8282, 1876, 9959, 2986, 556, 6173, 9675, 8578, 7721, 2309, 1503, 5269, 3245, 8796, 1407, 1762, 608, 2658, 3331, 6045, 9612, 3357, 6944, 6009, 1358, 4634, 496, 5180, 9799, 1113, 1686, 4401, 4123, 6306, 4077, 4430, 1469, 243, 915, 9020, 7086, 2938, 5393, 3325, 1654, 7394, 12, 5114, 2219, 4505, 5015, 8902, 7439, 9027, 5841, 6313, 6021, 4207, 443, 1924, 5185, 2697, 2398, 5795, 7472, 9506, 4980, 3489, 1745, 2591, 7635, 2410, 5579, 4128, 4143, 8633, 6902, 783, 620, 9073, 1361, 8113, 330, 7047, 9074, 8643, 8630, 6837, 5589, 8043, 6631, 6681, 5100, 9233, 8849, 8154, 7481, 9994, 756, 2404, 9578, 2520, 6469, 4475, 6131, 3134, 9529, 4697, 1959, 9345, 8008, 6717, 2203, 7622, 8217, 25, 6841, 2380, 1012, 5463, 3522, 4955, 4212, 924, 9660, 1729, 3156, 9022, 4324, 7427, 3715, 342, 3217, 6341, 4052, 4639, 4864, 4142, 223, 8054, 3572, 8547, 3534, 467, 9636, 8377, 4775, 1144, 9446, 9716, 849, 8128, 3810, 8900, 8033, 2438, 2348, 1286, 8371, 6478, 4500, 8988, 2201, 1077, 4020, 8917, 7391, 7490, 7681, 5637, 5367, 7431, 5375, 8523, 9177, 6566, 2989, 9270, 5997, 1591, 4259, 4646, 4134, 3436, 6890, 1651, 2223, 7152, 762, 9260, 3300, 5988, 5431, 6127, 1532, 9781, 6423, 4368, 4790, 5626, 197, 7504, 5453, 5342, 4180, 5143, 5030, 9530, 2736, 8023, 7619, 3814, 9494, 9888, 7438, 4781, 604, 7071, 9379, 7692, 9989, 7063, 5873, 2485, 6364, 7983, 85, 6064, 1865, 2430, 2390, 408, 84, 847, 345, 8098, 2041, 1024, 3771, 1893, 7033, 4086, 8988, 3972, 5785, 9632, 6195, 6305, 9173, 1279, 6732, 7646, 7505, 6391, 1545, 6536, 5131, 4211, 9439, 9922, 6169, 3421, 1785, 4185, 497, 4993, 4118, 5845, 8011, 4104, 7538, 3518, 9542, 1502, 8681, 1454, 4358, 7765, 1182, 9489, 8876, 7640, 5641, 133, 7918, 7346, 6889, 1377, 7539, 7107, 2067, 7977, 2929, 2584, 8976, 6351, 1016, 391, 1253, 6081, 4052, 3065, 7665, 582, 6538, 3759, 9303, 9646, 3904, 9147, 4167, 553, 6301, 8149, 6318, 7432, 7392, 3652, 8204, 1631, 6442, 4036, 9641, 2919, 3103, 6923, 9016, 5729, 3774, 9032, 5127, 6129, 1662, 4385, 987, 235, 7231, 7746, 5640, 2913, 7631, 3659, 8864, 3648, 1903, 3001, 287, 4417, 7051, 2018, 5055, 2317, 3005, 7271, 6778, 6518, 5741, 8829, 2543, 8478, 3617, 298, 4074, 7672, 5542, 5898, 9615, 5165, 5873, 505, 891, 5902, 2506, 5205, 8234, 4016, 2699, 2320, 6969, 8058, 9463, 2049, 8439, 668, 7912, 3588, 501, 3640, 7104, 804, 9470, 2020, 5938, 8594, 7548, 1111, 3262, 3088, 606, 97, 148, 7223, 5431, 5683, 7385, 320, 5941, 2189, 4507, 9047, 3105, 636, 4280, 7984, 1356, 593, 8268, 6649, 2105, 5574, 4864, 2943, 1696, 7037, 763, 6625, 2332, 317, 9131, 4365, 1573, 7847, 177, 6357, 8666, 2866, 3150, 2975, 1702, 7091, 8210, 1316, 2826, 9127, 2145, 466, 4297, 6341, 762, 2814, 3368, 2240, 4505, 82, 1176, 2234, 3834, 2793, 6854, 127, 297, 3401, 9873, 8519, 9119, 9, 9109, 9754, 7018, 1647, 6280, 828, 4738, 3799, 2626, 4006, 3043, 8459, 7802, 3736, 4123, 6141, 3507, 7305, 2058, 9615, 4572, 6612, 1838, 4252, 2520, 9253, 6182, 1703, 3274, 7156, 9563, 9714, 3463, 508, 5738, 7564, 8256, 9164, 3973, 354, 8621, 1362, 8329, 1384, 8896, 8086, 1419, 5479, 4611, 9826, 3952, 2502, 9803, 7479, 5700, 9254, 6295, 1713, 2868, 804, 1997, 5948, 5277, 7861, 5391, 8404, 5815, 7850, 2445, 4410, 5101, 9393, 1432, 958, 3867, 7692, 1089, 2232, 3201, 177, 221, 9848, 4742, 3871, 7273, 5322, 7707, 3289, 4651, 6094, 6640, 6429, 3919, 474, 4401, 9273, 5114, 9630, 1314, 3047, 7634, 9577, 3996, 3307, 4311, 935, 7553, 4863, 5629, 7004, 113, 9572, 3785, 1115, 9278, 7571, 3078, 1957, 6575, 2737, 8358, 8197, 7487, 8111, 3578, 6930, 2198, 1461, 2024, 4734, 3947, 3286, 9617, 3204, 7180, 720, 5044, 4324, 9353, 6593, 4602, 2724, 3181, 4533, 2301, 6129, 8536, 1365, 1586, 9953, 6815, 8372, 8980, 582, 5604, 3520, 9696, 6906, 2267, 5592, 4710, 7517, 8069, 7159, 9251, 4484, 5387, 7959, 2085, 3357, 251, 2733, 9905, 4311, 4536, 101, 8747, 5030, 348, 7985, 8247, 7459, 6527, 7803, 3866, 1578, 8601, 3776, 4619, 3617, 9426, 6075, 5820, 3655, 2490, 3067, 4422, 5835, 3381, 2795, 3968, 5091, 3760, 9437, 1951, 2882, 6135, 4712, 6783, 7303, 1955, 832, 7825, 8896, 146, 9278, 7360, 8494, 1461, 6173, 5893, 2767, 6262, 8275, 2197, 2819, 3032, 6284, 1371, 5323, 2098, 7040, 1702, 8057, 8396, 1023, 2911, 4960, 2270, 9392, 407, 7362, 8990, 1951, 2879, 3756, 7945, 7554, 7123, 8418, 7035, 4907, 9028, 3994, 5378, 7246, 3371, 1679, 3899, 3611, 2317, 961, 1409, 6117, 2916, 7727, 4759, 4249, 1296, 7861, 2490, 4398, 6079, 8527, 5738, 8436, 7115, 5367, 3688, 4398, 1616, 7344, 3956, 4757, 437, 1388, 5191, 1104, 8413, 345, 2215, 212, 2320, 5990, 1034, 3775, 4640, 3568, 6200, 3541, 4677, 1819, 5025, 9375, 1082, 4729, 2869, 3354, 9363, 8777, 8897, 476, 590, 9228, 6518, 5985, 9803, 8331, 7869, 5593, 9523, 8664, 8551, 2398, 8446, 678, 1420, 8228, 5262, 1163, 9403, 6515, 9297, 2714, 4416, 3187, 6688, 4376, 6565, 1316, 4326, 8892, 737, 7649, 5325, 9945, 126, 7116, 9018, 8541, 8383, 8205, 6345, 9951, 5656, 9730, 2195, 3505, 6911, 1307, 6265, 1830, 6555, 535, 7200, 8686, 3430, 7670, 4450, 8909, 2820, 3445, 5854, 364, 6436, 4637, 3724, 4697, 7639, 1717, 9259, 5816, 1680, 5043, 4392, 6004, 2596, 5855, 8177, 2925, 3656, 1561, 198, 5418, 9523, 9006, 4746, 2153, 3766, 8155, 8635, 4964, 3337, 1178, 3918, 9046, 6775, 2085, 1042, 7591, 5875, 1382, 568, 5821, 8739, 5727, 9205, 568, 2929, 3708, 5431, 5185, 764, 9549, 7908, 5052, 5552, 7054, 8315, 3377, 3908, 8708, 429, 9110, 2138, 5408, 9895, 4495, 4287, 4177, 9246, 1144, 4084, 6866, 6350, 3896, 2004, 8545, 8953, 5724, 1047, 8873, 9531, 7338, 345, 7972, 7689, 4456, 33, 9355, 4884, 7684, 2905, 227, 4807, 3627, 9344, 2831, 8966, 896, 8493, 1050, 2377, 3354, 3121, 7275, 4932, 8914, 3014, 1319, 6476, 4016, 1757, 2502, 4072, 2403, 6885, 3626, 5167, 4069, 5604, 1760, 699, 1965, 910, 9118, 9624, 4505, 2755, 9133, 3802, 2011, 6951, 5955, 5587, 9919, 4979, 7974, 2064, 6681, 7080, 5817, 4025, 7328, 993, 2531, 7174, 8386, 7069, 8344, 5560, 1267, 2123, 7761, 7780, 1122, 565, 1871, 4136, 319, 8346, 4235, 9825, 8656, 8149, 4352, 5178, 4188, 170, 212, 9764, 3318, 6837, 2545, 3244, 6421, 8124, 6659, 9934, 2032, 1006, 7130, 5837, 4625, 560, 1590, 7235, 7337, 9417, 2911, 1565, 1073, 3610, 5882, 9285, 6498, 2868, 217, 9342, 7398, 1005, 9678, 7506, 7616, 3856, 8068, 3999, 7143, 7088, 8783, 7980, 9581, 9761, 1562, 9530, 6957, 4965, 5483, 8110, 6731, 377, 4781, 2561, 566, 3120, 3800, 5405, 6029, 4745, 8871, 1107, 9078, 8210, 3828, 6902, 1821, 9394, 9825, 5214, 6345, 9097, 1735, 8514, 4850, 594, 7071, 9360, 4310, 6189, 1936, 5516, 2419, 6025, 2741, 6595, 80, 5361, 1656, 1007, 634, 9275, 5166, 2960, 5301, 8353, 1729, 283, 4199, 5274, 4184, 2678, 8632, 6213, 3032, 2850, 8191, 3124, 1331, 9025, 2165, 5225, 7216, 3877, 8097, 7182, 8574, 6982, 4779, 103, 8422, 734, 833, 5069, 5586, 54, 31, 5929, 4714, 3857, 1790, 2103, 9598, 8564, 2738, 6843, 2065, 4132, 4842, 7743, 2186, 8042, 4723, 9467, 7455, 3945, 4433, 903, 4499, 8019, 8309, 7756, 402, 7274, 3854, 5255, 3006, 5715, 1718, 4901, 5064, 6200, 5324, 2745, 3391, 2098, 9891, 3782, 5926, 3508, 3433, 9591, 8085, 1350, 3700, 7082, 23, 1941, 3829, 2920, 7235, 7939, 7650, 1657, 6124, 8352, 1187, 8900, 2698, 6364, 7853, 6973, 9835, 2125, 2658, 6052, 7135, 1390, 7132, 162, 678, 3206, 8727, 8455, 5732, 5505, 6086, 1328, 8099, 3548, 4206, 9101, 2081, 7620, 4376, 5561, 1502, 7570, 455, 8729, 8638, 9666, 7201, 4262, 7679, 8008, 1255, 4387, 6624, 6585, 741, 7497, 3843, 8113, 2129, 5226, 7153, 8556, 461, 8356, 1449, 4320, 2441, 1710, 6955, 3793, 9378, 5775, 2849, 3284, 1814, 1424, 7432, 9013, 2411, 4702, 1244, 4847, 3445, 6108, 7859, 8000, 728, 495, 5950, 5685, 7591, 7346, 8433, 4352, 1960, 4026, 91, 3951, 3538, 627, 9224, 8548, 3362, 6122, 7523, 4641, 9189, 2063, 4900, 2450, 6809, 4076, 349, 9876, 1088, 3249, 9686, 1426, 7701, 628, 5418, 5542, 1754, 2644, 5435, 1891, 3166, 1194, 6408, 7213, 2916, 7093, 6359, 9935, 6703, 2824, 5339, 824, 6449, 2144, 5658, 3116, 125, 1057, 7729, 3120, 1988, 4570, 5434, 978, 975, 4330, 8035, 4413, 4394, 7842, 5531, 9278, 4996, 4256, 6219, 5141, 864, 6532, 7252, 2445, 2019, 4885, 3807, 3512, 5723, 5624, 5691, 2828, 244, 9484, 946, 6268, 528, 3505, 793, 2345, 413, 93, 7372, 744, 6250, 1932, 7828, 9657, 5231, 7364, 9639, 2399, 3354, 9731, 5091, 6718, 9684, 2536, 5686, 6143, 2867, 1839, 6438, 4799, 1354, 1684, 7795, 1142, 7897, 2908, 9456, 5847, 404, 7874, 8019, 9397, 3381, 3207, 7891, 4771, 5020, 5450, 7825, 6906, 5182, 3662, 8356, 6336, 565, 774, 2333, 2631, 8583, 1759, 8307, 5007, 6411, 8027, 3151, 8846, 710, 1239, 7300, 8384, 7259, 9312, 9706, 7761, 5881, 2155, 3959, 3266, 8561, 2356, 140, 3518, 4816, 4055, 3919, 9546, 5861, 3094, 465, 5972, 490, 9399, 5101, 6020, 1133, 9131, 4178, 6407, 3597, 1345, 6030, 3962, 1287, 8166, 3953, 857, 5696, 8056, 9938, 9902, 6612, 5117, 1538, 9375, 783, 6529, 128, 5011, 6116, 559, 337, 4568, 6186, 1545, 1005, 7872, 9572, 5887, 5415, 219, 7959, 1707, 6546, 1213, 9438, 8508, 9897, 2438, 5472, 2458, 1189, 6080, 6846, 6837, 4987, 4672, 8363, 7492, 5331, 5218, 6809, 7103, 3787, 2126, 8977, 6795, 4375, 4646, 3317, 5557, 1157, 2044, 3773, 2847, 3453, 1500, 6458, 627, 9045, 8993, 8910, 1124, 5949, 8953, 5559, 4659, 8444, 7130, 3225, 9545, 9364, 4491, 9805, 283, 5902, 4067, 918, 2081, 9390, 4767, 1610, 612, 8592, 2706, 1059, 8385, 5596, 58, 7913, 5854, 4077, 1123, 7123, 2197, 5862, 6587, 3761, 404, 6192, 2144, 4845, 3261, 6691, 5748, 873, 5422, 644, 3743, 2497, 2915, 4865, 8655, 9526, 3882, 52, 8138, 5052, 2426, 6192, 3951, 1494, 4766, 4695, 2327, 8352, 322, 4191, 4226, 5651, 7661, 9009, 3434, 8882, 5080, 5244, 5887, 9778, 8608, 8232, 4660, 4961, 633, 3969, 4385, 849, 8711, 7923, 6486, 2534, 6947, 5508, 3059, 7635, 3562, 1596, 4874, 8164, 9709, 5378, 8067, 3761, 4458, 6512, 7385, 9005, 8111, 7847, 2925, 5117, 4205, 9620, 1731, 1356, 5898, 8108, 299, 6085, 7308, 3038, 4953, 6530, 3238, 5981, 7088, 2921, 7378, 9003, 9322, 6019, 2478, 7483, 6441, 9975, 9565, 8566, 4683, 7731, 8229, 7487, 9446, 2086, 9761, 9156, 1850, 6460, 9628, 8844, 7614, 8833, 7291, 8640, 9106, 1126, 3865, 3362, 3836, 3450, 112, 3892, 5958, 7946, 3905, 4897, 6800, 9505, 1185, 6328, 3590, 6896, 9824, 2536, 3984, 7916, 5084, 6827, 5482, 4252, 1072, 9201, 6976, 1144, 6857, 2650, 1276, 190, 9635, 7119, 4963, 4454, 3536, 2230, 660, 8606, 4039, 5626, 5555, 4825, 7060, 345, 1981, 1311, 4010, 3635, 7609, 1231, 5044, 4199, 8370, 9026, 6172, 1342, 9647, 561, 2283, 3685, 1831, 2351, 7504, 1163, 4097, 2199, 3555, 5058, 2106, 7490, 704, 413, 9660, 9112, 568, 6393, 9049, 2803, 1494, 8890, 891, 8957, 6245, 6086, 2712, 4897, 8595, 9721, 9898, 5893, 8245, 9950, 8098, 782, 5264, 7275, 7225, 6028, 5410, 794, 7011, 7093, 5106, 507, 1282, 1265, 4557, 1407, 8444, 1248, 7039, 6377, 9883, 8273, 6079, 6234, 7726, 3561, 9820, 3500, 3130, 9244, 3387, 7500, 18, 6229, 2489, 4209, 6819, 6788, 3375, 9353, 6420, 6784, 9828, 6264, 8403, 6840, 4872, 6270, 9196, 6026, 2292, 8909, 7819, 5058, 2789, 3288, 6704, 503, 6243, 4698, 1532, 14, 8981, 7912, 366, 9460, 6354, 7359, 2997, 9766, 7273, 2394, 676, 934, 9182, 978, 9320, 7408, 8953, 33, 9521, 3747, 3357, 7867, 6630, 3281, 9551, 8692, 892, 4725, 8056, 299, 6774, 1825, 4439, 3672, 3418, 476, 5521, 1914, 680, 3113, 2475, 2262, 1495, 1866, 6279, 918, 5, 1733, 4192, 3214, 334, 2887, 1069, 2065, 8927, 5755, 7082, 7514, 8820, 6996, 1434, 9193, 6318, 3791, 341, 6154, 5881, 6888, 5554, 5759, 6240, 7934, 9840, 3816, 3948, 1780, 9660, 5369, 5676, 211, 554, 3184, 5476, 6186, 5663, 2450, 9053, 4690, 3536, 1674, 1411, 5372, 7450, 2124, 7227, 9535, 7165, 6681, 4549, 5342, 7506, 2877, 2369, 1243, 4765, 1185, 416, 5024, 5679, 9495, 8876, 7259, 9527, 7290, 8190, 9093, 7389, 2698, 2520, 4569, 5892, 7909, 6225, 892, 9542, 7524, 5401, 8465, 5478, 2886, 5792, 259, 965, 4713, 2244, 9157, 6421, 5431, 2113, 7455, 6305, 1025, 5707, 8505, 8240, 762, 6403, 6683, 9414, 8700, 3154, 5512, 8340, 8188, 6270, 7072, 2215, 9531, 1311, 3569, 6940, 2776, 9123, 8645, 5978, 2769, 54, 5651, 4300, 3078, 8478, 8417, 3549, 2689, 8087, 2800, 9171, 3853, 1648, 9513, 974, 4183, 8055, 9910, 9443, 7803, 5621, 9407, 7069, 8822, 8453, 7980, 94, 8301, 4897, 2336, 7973, 9786, 3564, 1208, 6104, 5927, 337, 5942, 2551, 7673, 539, 3102, 1844, 920, 8915, 403, 3001, 6410, 3438, 9514, 1700, 7454, 3923, 1526, 824, 8695, 8588, 5646, 2950, 8643, 3164, 2166, 5730, 3508, 3362, 9508, 8792, 4289, 8172, 3495, 2484, 9085, 3774, 9571, 4921, 4793, 8061, 2478, 6102, 5986, 6463, 831, 4129, 7256, 78, 4480, 5125, 1588, 5646, 1003, 1407, 3599, 6562, 8609, 310, 9744, 3453, 7112, 4352, 9989, 6162, 120, 8009, 5364, 5225, 5534, 5202, 9625, 297, 6941, 2499, 1709, 9715, 7653, 2140, 8362, 1712, 6444, 9971, 1788, 1717, 1498, 9204, 945, 8272, 4308, 8189, 3563, 8412, 4747, 7283, 5251, 9216, 1051, 3422, 8562, 3867, 2977, 8398, 4674, 6975, 4378, 3062, 2686, 4954, 8930, 3763, 5937, 6756, 6161, 9360, 817, 3955, 5652, 5303, 1812, 4628, 5003, 8787, 3313, 9201, 4252, 3763, 5171, 363, 7104, 5699, 8312, 6258, 9241, 7121, 2552, 4333, 9748, 2555, 6936, 6828, 1628, 6787, 6825, 3222, 9079, 5955, 6775, 4643, 5486, 5342, 7799, 9454, 708, 7872, 1856, 2155, 3750, 6524, 9799, 6786, 2022, 2566, 4323, 6499, 7792, 9865, 2006, 9282, 4134, 3801, 8089, 1085, 3539, 1225, 4215, 9257, 2147, 3784, 1143, 5444, 4766, 5530, 65, 9258, 4850, 2164, 3390, 3125, 3588, 2672, 4151, 2323, 8960, 320, 1718, 2539, 5709, 6245, 393, 5408, 4595, 5881, 690, 6306, 4795, 6794, 4608, 3715, 6257, 6899, 5306, 3196, 2407, 2862, 3890, 2819, 9916, 2533, 6808, 241, 2648, 8698, 4173, 9681, 7918, 4364, 4209, 1292, 4321, 1678, 2720, 501, 2402, 5371, 6352, 5682, 7908, 2579, 6313, 8273, 7415, 6945, 2250, 8584, 6762, 6043, 451, 2091, 4983, 231, 1804, 62, 284, 5572, 8431, 4079, 423, 7277, 9233, 1604, 4273, 8532, 5944, 9240, 207, 9731, 8421, 7119, 3697, 5380, 9490, 1509, 3251, 2739, 7955, 834, 1800, 3148, 9367, 4646, 1814, 2466, 1055, 3693, 8831, 3161, 6414, 2535, 4877, 8632, 8220, 4486, 7867, 6808, 422, 8467, 8621, 7823, 881, 9518, 6915, 2735, 2766, 1649, 87, 5413, 7515, 9715, 1453, 6162, 1660, 6408, 6818, 6381, 9293, 9301, 396, 7779, 4798, 1845, 28, 1348, 800, 4734, 4846, 3264, 8278, 8585, 3382, 3660, 1232, 18, 4124, 6975, 3174, 2139, 8815, 7258, 9114, 8456, 6557, 6142, 7263, 365, 3660, 663, 1867, 8347, 4459, 1468, 1479, 9505, 9448, 7582, 8034, 1848, 2404, 874, 6013, 315, 691, 9962, 9652, 9944, 6723, 4293, 9234, 143, 2801, 8917, 3502, 9594, 4870, 3097, 5221, 683, 4402, 5341, 1509, 8839, 7871, 3282, 4160, 3355, 9880, 1068, 5731, 9710, 2695, 211, 8544, 7252, 8363, 3895, 4560, 1020, 5483, 6672, 7176, 2388, 8305, 8824, 7243, 4075, 2021, 9063, 8376, 8077, 1141, 5636, 8714, 4163, 2792, 7461, 3552, 8805, 4830, 4740, 4805, 6967, 4568, 6259, 2760, 4969, 488, 1475, 5488, 3086, 3633, 3949, 4222, 9465, 2563, 5987, 2495, 3321, 479, 9269, 1750, 3935, 3351, 5554, 9972, 8411, 4901, 1555, 8987, 6564, 6018, 7949, 5011, 3363, 7669, 9284, 8618, 7700, 6971, 852, 5200, 8922, 6665, 6166, 3861, 9210, 3153, 2537, 9372, 6614, 3427, 8952, 693, 9043, 669, 5564, 636, 4165, 3469, 5348, 3213, 3271, 3539, 3130, 8725, 5479, 5029, 1303, 9131, 7454, 5285, 9767, 108, 7849, 6510, 3286, 191, 2347, 816, 1612, 9301, 277, 6410, 2521, 5712, 7277, 5448, 2245, 9376, 7105, 2393, 7704, 1234, 9413, 1957, 366, 1748, 215, 1915, 7138, 4777, 1303, 9774, 9750, 2454, 2214, 7207, 9298, 8398, 1058, 7001, 484, 9465, 5405, 9092, 924, 9899, 2757, 128, 2689, 9366, 9546, 9379, 8385, 5545, 7561, 965, 3100, 3745, 2325, 9006, 5201, 3857, 3714, 2007, 1326, 3371, 4372, 9554, 5954, 6408, 364, 1738, 8224, 2363, 3699, 2657, 4334, 5129, 5290, 9732, 5115, 2607, 4250, 4571, 9560, 6345, 4908, 2892, 4167, 7219, 5941, 1629, 7616, 4099, 7792, 1563, 8708, 2255, 2219, 3636, 4564, 157, 491, 3511, 5494, 6838, 7331, 3434, 9564, 584, 5846, 9311, 2298, 2216, 9022, 7971, 8224, 5112, 163, 929, 614, 4511, 2924, 6173, 1723, 3182, 2597, 5334, 2804, 1461, 4784, 7860, 9584, 5724, 1183, 6520, 1236, 1928, 7138, 419, 2507, 2305, 767, 3810, 6287, 4234, 2746, 4155, 5889, 3336, 6808, 9113, 7456, 1783, 2383, 3469, 7411, 339, 827, 3865, 4152, 1769, 8887, 3748, 6719, 5636, 9936, 6793, 1648, 7527, 7730, 4036, 4707, 9024, 8206, 2884, 3237, 8542, 9507, 5038, 7281, 5297, 9943, 6948, 6798, 8909, 643, 8455, 8737, 387, 3210, 8704, 2537, 3793, 2311, 6076, 3138, 119, 2970, 8179, 7169, 3276, 8393, 590, 6940, 9463, 6969, 1504, 1014, 9836, 6584, 8315, 7771, 3748, 2183, 9699, 3551, 7879, 6071, 2217, 66, 4095, 4503, 2916, 7331, 2795, 890, 325, 8002, 6958, 2138, 8175, 2992, 530, 6409, 2857, 9, 2710, 2395, 3249, 3459, 8728, 4571, 5203, 3936, 5824, 2211, 8587, 8484, 9193, 5073, 7905, 5568, 9212, 4913, 230, 8730, 562, 993, 7480, 6705, 7055, 1197, 4637, 2313, 7950, 2935, 6079, 6606, 9105, 7234, 1057, 6006, 2224, 2956, 2175, 6352, 1148, 2674, 4783, 6490, 650, 459, 5043, 6886, 278, 1103, 7062, 9654, 3818, 8721, 3559, 3699, 9715, 8070, 9293, 7846, 4346, 1030, 4559, 9964, 2195, 9604, 3383, 3887, 9162, 2749, 7221, 6256, 5400, 8689, 492, 7211, 3774, 6431, 2957, 2327, 6336, 8043, 3149, 6399, 3382, 9633, 3355, 5391, 7433, 5133, 9959, 6420, 7699, 5732, 5375, 9006, 8378, 9276, 8357, 1709, 6733, 944, 2397, 8880, 3215, 9563, 1479, 6683, 79, 8700, 9818, 5404, 9923, 636, 4727, 8203, 1393, 7508, 4074, 2020, 5263, 3058, 7981, 3219, 8083, 8655, 2366, 349, 2185, 7121, 3903, 6648, 2256, 482, 5089, 9904, 5389, 1565, 5481, 3596, 4631, 781, 3484, 196, 3914, 8397, 2556, 610, 5027, 1285, 1744, 8716, 8247, 215, 9086, 1458, 3768, 4767, 5200, 5382, 9115, 202, 6562, 172, 6919, 6070, 6647, 514, 1123, 5435, 6920, 5995, 2097, 2937, 322, 4809, 722, 1090, 4384, 9533, 8303, 5920, 2164, 6386, 880, 7855, 2196, 6525, 8268, 8751, 9151, 5577, 6979, 7743, 2062, 581, 3195, 324, 3903, 7350, 2444, 4424, 2966, 4996, 8188, 5125, 8220, 9223, 3356, 9762, 429, 1303, 2412, 552, 9953, 9525, 1474, 7420, 1296, 9887, 2405, 3031, 503, 1023, 1238, 2245, 9982, 2195, 6769, 8397, 9269, 4819, 2746, 9053, 8955, 1565, 9097, 9655, 6021, 7712, 3756, 8270, 1282, 1644, 8856, 3203, 107, 5892, 1011, 9555, 496, 527, 2457, 1090, 3418, 5379, 1877, 3523, 914, 6871, 2855, 2533, 9663, 2984, 4207, 2909, 3839, 7221, 7014, 3386, 4028, 14, 2615, 113, 8950, 9540, 3058, 3365, 4198, 9437, 5267, 1069, 9590, 1969, 2870, 95, 4346, 6347, 4803, 2486, 1078, 1685, 3642, 3351, 5282, 5419, 8495, 8035, 9842, 3487, 6027, 2765, 4762, 8185, 8710, 7673, 3400, 2447, 4798, 5963, 4543, 9998, 410, 9697, 6243, 8519, 4681, 9975, 5964, 6973, 7493, 8569, 1400, 8698, 7802, 462, 5155, 6985, 9712, 2615, 8678, 788, 2855, 2961, 8834, 9330, 5556, 6488, 9931, 9968, 2570, 9366, 6648, 2828, 2640, 8748, 2871, 8552, 7821, 4604, 9915, 9985, 4293, 3289, 3126, 2322, 1917, 1781, 9514, 3751, 2062, 1193, 77, 473, 5098, 9241, 9679, 6043, 5388, 1435, 4116, 4762, 1850, 2693, 2409, 8245, 1792, 8067, 3339, 994, 1672, 6431, 9518, 4865, 3341, 4950, 1705, 3427, 884, 8202, 3716, 8356, 8306, 7823, 6893, 3890, 3536, 1713, 591, 1739, 9546, 4250, 3662, 2383, 8126, 7694, 4127, 7953, 3630, 8171, 3492, 9942, 9552, 4255, 1593, 2019, 1489, 4384, 4381, 4670, 8656, 2521, 1759, 9151, 6586, 9186, 4761, 4776, 7475, 8039, 3480, 6758, 2653, 7497, 2280, 1698, 7101, 3380, 900, 9413, 9323, 6476, 554, 8224, 45, 1680, 1649, 9574, 3116, 4844, 1605, 6337, 3376, 685, 3707, 5933, 6382, 7490, 1792, 7423, 4604, 584, 5883, 7631, 4314, 6484, 3743, 1192, 5831, 7255, 4925, 3833, 8628, 4276, 4040, 9060, 1972, 2754, 4142, 9482, 2563, 868, 5246, 2629, 1523, 537, 3888, 8628, 8472, 9985, 1457, 3497, 2516, 6776, 956, 3418, 9929, 3990, 8463, 6196, 2805, 7131, 7365, 3896, 4494, 1261, 652, 4164, 3711, 6468, 8555, 5939, 7915, 8554, 3532, 1669, 3967, 2521, 1708, 9726, 7107, 7695, 1745, 1118, 6652, 35, 351, 891, 1427, 1356, 9353, 4418, 1424, 4062, 3890, 1910, 3628, 5481, 8502, 7334, 9105, 2030, 9551, 450, 5102, 6087, 9875, 1189, 5331, 8794, 6356, 2538, 5152, 3474, 883, 4752, 8147, 9338, 3385, 6352, 6346, 3394, 2250, 2539, 1815, 8073, 4864, 9615, 3904, 6122, 2481, 3182, 9296, 7332, 2557, 4563, 7282, 9632, 4174, 6550, 9333, 3737, 5495, 8949, 3787, 5965, 4999, 5824, 973, 5901, 7338, 1937, 1221, 5461, 6256, 1118, 3953, 7559, 7275, 658, 8733, 4234, 2810, 4330, 4494, 1434, 2869, 9859, 6173, 9667, 1066, 7121, 8607, 9499, 9891, 6196, 7114, 9754, 166, 5348, 304, 636, 4617, 6979, 1357, 5454, 8526, 5764, 5590, 9773, 671, 2770, 2163, 9131, 4297, 3811, 8514, 5774, 6366, 5511, 8934, 7848, 2400, 3052, 5131, 4884, 5968, 4315, 1063, 9036, 2797, 6018, 161, 3376, 5747, 1022, 8738, 7880, 9476, 9149, 9645, 6900, 4670, 4256, 9039, 9468, 8699, 6681, 3318, 5854, 6756, 8532, 8860, 3013, 2965, 6961, 6972, 140, 5904, 2908, 342, 7908, 2626, 6028, 3987, 6817, 9218, 4135, 469, 6876, 927, 4167, 8299, 295, 4498, 9225, 5685, 4216, 4064, 2762, 1051, 6455, 727, 7007, 7486, 1490, 7553, 5464, 1506, 3792, 9401, 3626, 4933, 5382, 7269, 561, 8368, 9114, 9246, 9356, 7550, 1033, 6712, 209, 3553, 653, 6013, 9115, 5473, 7599, 2353, 7762, 1035, 3154, 6201, 7042, 5646, 2609, 9935, 6806, 1064, 1725, 1121, 5975, 650, 2524, 8903, 5673, 4762, 4433, 4109, 4691, 1440, 3512, 5066, 167, 3223, 9315, 1692, 6145, 727, 4599, 9883, 6612, 9581, 9992, 7810, 753, 2358, 2471, 1694, 9018, 8209, 5424, 650, 7925, 9082, 7362, 9491, 3751, 4333, 7783, 3610, 9155, 8854, 3374, 3665, 5941, 3495, 6125, 9098, 7080, 8319, 6929, 1153, 3178, 4446, 7159, 6930, 7347, 6631, 4386, 5962, 1638, 7532, 5922, 680, 8172, 2274, 1370, 3286, 4188, 8702, 8512, 5281, 4339, 6936, 9486, 2837, 5358, 9168, 4442, 1440, 6031, 3292, 590, 6245, 9299, 869, 8959, 4677, 2857, 5762, 4505, 7832, 855, 7870, 7328, 4731, 1228, 8383, 1705, 4615, 8679, 2312, 9726, 4413, 4489, 476, 4707, 6353, 2004, 8783, 3327, 119, 2833, 4889, 9930, 3617, 6957, 8611, 9954, 830, 8969, 2672, 3235, 1943, 7755, 6041, 9602, 612, 6417, 4605, 8980, 6543, 7812, 9679, 1139, 7785, 7730, 208, 428, 3947, 8446, 1881, 9652, 3651, 6010, 7593, 4110, 3874, 4156, 9215, 6363, 944, 4213, 536, 7439, 3787, 9540, 4139, 8066, 6682, 6902, 6097, 7533, 7493, 4926, 6505, 9466, 3876, 3764, 9626, 7266, 7884, 4612, 1110, 4407, 5683, 5251, 6963, 5430, 7514, 7317, 2060, 879, 7545, 2772, 850, 1161, 5222, 5603, 6737, 4057, 4815, 3777, 5612, 3, 5184, 7288, 535, 6528, 5526, 1269, 4857, 3218, 6514, 186, 9846, 8772, 6235, 5023, 9908, 4630, 3477, 6216, 7655, 8164, 4688, 9114, 3021, 5455, 2850, 7450, 3698, 7444, 2483, 304, 2888, 622, 8040, 4298, 4197, 3434, 392, 4265, 1368, 7250, 5523, 8989, 8705, 4746, 336, 8007, 4341, 7401, 105, 6144, 9853, 7424, 1369, 9904, 6343, 7658, 8000, 6334, 2682, 7037, 5636, 7853, 59, 1205, 9276, 9200, 1827, 7439, 2846, 9121, 3522, 5407, 9839, 7706, 2927, 4558, 8205, 8516, 5541, 689, 8566, 7882, 1499, 7384, 3927, 2646, 2676, 9929, 1056, 2985, 5222, 9974, 7447, 7962, 4421, 3296, 5906, 7331, 6506, 4660, 7474, 9457, 5848, 6266, 6523, 9949, 3254, 2154, 5072, 4802, 654, 6132, 8800, 3294, 7494, 1067, 6232, 3416, 7302, 6703, 8577, 8976, 7353, 3202, 2157, 6014, 457, 1348, 8443, 8360, 9180, 5938, 3959, 6040, 1783, 8413, 6531, 8992, 6383, 4108, 6803, 8813, 7112, 5293, 4375, 4139, 7710, 7265, 8909, 2532, 4185, 7013, 4711, 5629, 6245, 5746, 1341, 7490, 1886, 5518, 8747, 6802, 4666, 6493, 2298, 200, 5633, 4475, 4652, 417, 1730, 5536, 9509, 4672, 89, 7570, 538, 5303, 4299, 1737, 9294, 2150, 2032, 1531, 7670, 2984, 5091, 8199, 6061, 5375, 6211, 806, 9865, 942, 1962, 2218, 4857, 8257, 3532, 9981, 3514, 1773, 9365, 8947, 3091, 3957, 4817, 3919, 6488, 4826, 3982, 5738, 8989, 9120, 1997, 1526, 7204, 7806, 6128, 5033, 6623, 4734, 1460, 4118, 8127, 2159, 5532, 5440, 1551, 300, 8211, 6327, 5740, 5060, 1964, 4521, 5964, 3189, 8480, 7157, 1677, 4616, 4809, 1929, 204, 9602, 4688, 2549, 5908, 1617, 7561, 4406, 6296, 5064, 6893, 6537, 4018, 2736, 7056, 98, 5156, 5018, 4255, 9306, 7557, 9213, 3239, 8336, 6638, 1378, 7067, 30, 1541, 9193, 8875, 4657, 8475, 2224, 4711, 6986, 2205, 9969, 4598, 7342, 130, 5714, 9532, 1359, 7817, 2742, 3055, 8727, 935, 7095, 3587, 4146, 3144, 1064, 4780, 3009, 912, 7067, 5560, 8235, 7471, 5417, 5597, 1461, 4350, 6277, 7259, 5311, 623, 3683, 3898, 7693, 3721, 7451, 3193, 8001, 6960, 4954, 535, 4783, 4169, 3082, 5621, 5006, 9111, 7668, 4327, 4270, 9930, 8960, 7748, 5918, 8581, 6024, 7859, 4122, 605, 4913, 7934, 7143, 5431, 1994, 9373, 7604, 4692, 7601, 5710, 9873, 3999, 5821, 496, 2388, 1643, 69, 2923, 4563, 9401, 2216, 7521, 660, 3298, 9759, 8012, 7891, 9980, 5630, 923, 2653, 4020, 212, 6136, 8918, 2496, 9924, 4795, 2521, 72, 7240, 9588, 9394, 5316, 5041, 3560, 5915, 2039, 1977, 8701, 3475, 2923, 4763, 4208, 2499, 8134, 1379, 2955, 4457, 125, 3064, 9128, 3922, 8184, 3458, 7737, 5346, 8036, 1814, 9061, 4461, 1315, 1632, 7425, 8139, 6666, 7471, 7408, 3189, 2588, 6350, 7401, 4153, 4043, 1036, 6839, 3766, 3049, 7276, 6149, 5616, 7975, 9582, 3886, 9416, 5898, 3193, 7666, 4854, 9991, 7036, 6738, 610, 7237, 1028, 4953, 7239, 9856, 9680, 2030, 1362, 5892, 8266, 5933, 4922, 2394, 8702, 6049, 665, 9893, 3789, 7604, 1575, 4550, 6705, 9277, 3928, 3892, 1348, 389, 7132, 7713, 8975, 7907, 260, 5473, 8938, 8452, 6814, 5829, 6712, 2817, 3844, 8266, 3574, 963, 9229, 5073, 4569, 2480, 6310, 7897, 4242, 5553, 9274, 9672, 6626, 4424, 316, 1032, 6027, 6136, 6269, 943, 7167, 3496, 2207, 9821, 8259, 570, 9451, 1578, 250, 9115, 8542, 4501, 8533, 6535, 3367, 4171, 5164, 641, 7312, 6916, 7168, 5023, 7217, 7768, 6333, 738, 9949, 4790, 7823, 146, 7644, 1760, 6654, 374, 8953, 3873, 9124, 1752, 3190, 4601, 5734, 23, 2060, 5937, 5147, 2451, 6107, 6169, 9307, 3925, 4374, 4140, 860, 3153, 4129, 4472, 332, 3286, 4653, 5084, 3783, 2534, 9986, 7343, 1836, 4243, 9928, 5212, 8968, 8547, 2303, 2613, 1956, 6785, 1784, 4744, 3586, 4623, 9333, 6996, 2801, 9774, 4878, 4801, 7970, 4794, 5393, 2106, 1244, 9545, 3667, 8430, 9203, 5717, 2639, 1016, 4680, 4788, 9836, 4585, 9455, 9298, 6890, 7961, 4505, 9836, 6177, 5508, 9710, 3759, 3404, 1212, 1607, 94, 3967, 9542, 5276, 2062, 1488, 9518, 2914, 4820, 1489, 5211, 2696, 8683, 1627, 6002, 5876, 3785, 3191, 4139, 4228, 7936, 3887, 3171, 8431, 3335, 1694, 2818, 6256, 2887, 6848, 5357, 6486, 9192, 8117, 5560, 6266, 9552, 8000, 467, 4877, 7344, 7359, 5316, 3404, 3520, 111, 7268, 8417, 3425, 5962, 3919, 8586, 8032, 8378, 3794, 8710, 8733, 9834, 9073, 7804, 1973, 3504, 4769, 8265, 7142, 9598, 5805, 4146, 6876, 3101, 1018, 8921, 7851, 8700, 3811, 296, 6387, 3949, 58, 666, 218, 890, 5575, 6645, 7573, 3933, 6986, 4513, 7740, 3775, 1013, 7831, 6779, 2216, 9550, 2795, 2938, 7904, 8002, 8835, 1649, 407, 35, 2121, 2449, 4145, 1861, 1213, 8678, 8715, 5466, 6380, 8929, 7129, 3091, 2165, 3803, 6825, 4421, 5755, 1028, 1527, 8720, 6893, 6658, 9259, 28, 5709, 6154, 6305, 9147, 8824, 1786, 7424, 8135, 9590, 5497, 4415, 9988, 2289, 8882, 6000, 8193, 7714, 6863, 7462, 2418, 3983, 645, 2398, 1127, 1266, 5072, 777, 6959, 8201, 2350, 1194, 6595, 2379, 3937, 2696, 6686, 4641, 8282, 7806, 4361, 4898, 7844, 2298, 7034, 6038, 9409, 8083, 6657, 8040, 7546, 5572, 4891, 9333, 7097, 8276, 1011, 4250, 442, 133, 7319, 8260, 5549, 8664, 7434, 4797, 1424, 3946, 3944, 343, 2335, 166, 5555, 7354, 7848, 7904, 8301, 6143, 633, 5690, 4418, 9398, 5899, 3365, 1603, 634, 4138, 5046, 9971, 3190, 656, 204, 7705, 762, 4398, 7989, 187, 3629, 6737, 6449, 1354, 8681, 3734, 878, 4205, 5406, 9890, 7917, 7612, 4467, 7155, 5354, 735, 9677, 9529, 4780, 5571, 5967, 3654, 1545, 4619, 5135, 3173, 3597, 7755, 6299, 1894, 4477, 6806, 6197, 73, 3783, 7392, 1671, 4285, 735, 6106, 7182, 5870, 1434, 1840, 3081, 6837, 1492, 7880, 7791, 8095, 4408, 786, 9626, 6236, 8632, 6164, 4522, 1937, 6947, 2383, 2491, 1900, 8343, 6517, 6068, 238, 6030, 7000, 711, 3999, 9640, 5586, 1281, 4944, 9844, 4217, 6105, 6415, 9023, 6801, 8602, 4948, 9605, 360, 8629, 2622, 2067, 63, 9273, 2692, 4000, 1937, 3877, 3962, 3893, 1726, 9696, 8408, 5009, 6079, 747, 9984, 944, 2027, 9311, 1226, 2245, 6345, 4849, 6906, 784, 2267, 665, 1678, 6775, 3232, 3818, 7221, 2841, 1642, 2293, 7300, 3375, 1453, 4763, 1343, 5133, 2240, 9415, 8739, 6521, 4942, 9609, 1407, 7794, 8712, 5284, 673, 9704, 8080, 290, 9926, 9470, 5322, 4037, 353, 9152, 9294, 7570, 9402, 1212, 7874, 5392, 6680, 4792, 4908, 8434, 8302, 9198, 3580, 2643, 8945, 5108, 2079, 6475, 12, 5890, 1848, 5760, 5576, 1557, 7288, 1935, 425, 6416, 1703, 4296, 3814, 4696, 7772, 2857, 7300, 5954, 8080, 3466, 1769, 4500, 5939, 202, 1113, 5006, 9715, 6761, 7422, 6657, 7847, 9751, 9236, 4918, 4698, 4454, 9212, 974, 6279, 4802, 2760, 1989, 730, 2299, 8701, 7455, 1951, 6747, 7625, 8712, 2447, 3605, 3082, 2095, 405, 1702, 3510, 5644, 233, 3862, 527, 9723, 1329, 5161, 2489, 8952, 6785, 1642, 8430, 4567, 6444, 7639, 9462, 2904, 5779, 8731, 823, 7943, 1016, 8247, 436, 3055, 3946, 9277, 8634, 4802, 6824, 3014, 8441, 169, 1319, 9722, 9611, 8038, 8445, 4113, 9432, 1010, 9038, 7038, 253, 5055, 8147, 3657, 8388, 8951, 8401, 1186, 7101, 1224, 8979, 8285, 9375, 7397, 9352, 4190, 8006, 8324, 4459, 672, 9959, 2698, 7051, 4470, 9833, 382, 5642, 2152, 3962, 4939, 2201, 3876, 3583, 1220, 810, 4473, 3156, 1824, 2116, 9207, 4583, 5989, 7638, 2705, 5997, 659, 5149, 351, 9566, 8397, 7848, 3824, 9438, 9097, 5532, 2244, 5977, 1855, 3382, 7332, 4872, 3467, 4165, 232, 6823, 5570, 9530, 7150, 5564, 4459, 3152, 8953, 1900, 9708, 6922, 6012, 84, 34, 212, 5622, 4245, 9188, 6735, 2505, 7697, 262, 8388, 7822, 6651, 3398, 9993, 1323, 4122, 8394, 4563, 8283, 87, 3549, 1985, 9840, 1017, 7614, 2708, 6243, 1617, 3432, 4024, 3805, 1408, 3039, 8720, 7202, 9540, 6045, 3303, 4384, 2914, 9331, 1621, 507, 1736, 4679, 8858, 3856, 1591, 2563, 2749, 7424, 8302, 2928, 3903, 8901, 736, 16, 3822, 939, 7971, 3509, 306, 8599, 450, 7241, 4528, 5497, 6216, 1943, 2560, 6530, 6101, 8245, 8361, 247, 9800, 1537, 5276, 3240, 2756, 2361, 3924, 6843, 9104, 7715, 1977, 1943, 6441, 3891, 9565, 6710, 1591, 4774, 4967, 9106, 5846, 6827, 4275, 9161, 6788, 5550, 6559, 5379, 4958, 5744, 661, 5107, 4683, 7570, 5515, 2053, 9915, 8123, 3588, 1894, 5449, 3594, 7299, 992, 5576, 6345, 8910, 1431, 7971, 4619, 7777, 9467, 8759, 1688, 3339, 8206, 9100, 7149, 4171, 3598, 3760, 6992, 2002, 5691, 1783, 4459, 4146, 7372, 4958, 3015, 8145, 9586, 4694, 1578, 5954, 4247, 7061, 4160, 811, 9550, 2083, 5112, 9600, 3530, 3520, 1378, 8692, 5699, 7884, 7359, 6446, 6728, 7939, 1039, 5123, 5201, 3869, 9931, 8051, 8607, 970, 9102, 8246, 1650, 3086, 9887, 8650, 4847, 5314, 9055, 6824, 4201, 3824, 1972, 2260, 1138, 9491, 1752, 2244, 9310, 6752, 4935, 3660, 9659, 1963, 8607, 990, 9818, 1638, 3789, 241, 9690, 2325, 1832, 9397, 1219, 1460, 4729, 1370, 2985, 6921, 7209, 7371, 4598, 9595, 1781, 1672, 8465, 7747, 527, 7727, 5743, 3344, 5299, 6780, 4337, 8565, 6332, 7519, 1761, 9074, 6475, 9548, 1052, 3802, 3868, 6424, 8577, 5622, 5356, 9231, 9536, 7241, 3236, 1966, 4242, 5735, 4491, 5745, 9122, 1584, 9642, 8723, 1408, 1645, 5609, 4403, 6950, 5539, 7389, 1546, 1643, 3345, 6499, 6092, 7418, 2628, 7270, 5969, 9902, 4214, 1917, 2300, 6469, 9526, 538, 8547, 6025, 2366, 100, 1888, 2082, 8269, 640, 2334, 2456, 3089, 9256, 7458, 957, 7177, 3028, 6755, 877, 9529, 7517, 470, 649, 8396, 2525, 4697, 2621, 3916, 9113, 2696, 239, 233, 2440, 9975, 7738, 250, 3092, 7349, 4755, 1120, 3844, 6273, 1160, 7486, 1851, 7133, 1611, 9332, 4632, 8183, 5661, 5019, 4643, 1176, 3381, 5657, 8956, 3581, 645, 2937, 7849, 2459, 210, 1554, 167, 3431, 5821, 8630, 4849, 9423, 218, 3621, 9224, 9427, 7267, 2535, 831, 642, 7923, 2660, 6364, 4565, 928, 3515, 3221, 6502, 7957, 4375, 8388, 3783, 7730, 1018, 3262, 5602, 1843, 1380, 9717, 1307, 4702, 1451, 3530, 1137, 4767, 6693, 3119, 6883, 19, 7545, 9839, 8696, 1697, 3559, 6602, 3416, 5486, 8278, 4353, 1525, 9290, 5746, 4168, 8032, 3373, 655, 7604, 1503, 8981, 7636, 5884, 9672, 2093, 7576, 4528, 7395, 9752, 6217, 7250, 1787, 4227, 5448, 7899, 3746, 1067, 1855, 288, 5467, 6502, 2840, 8939, 8741, 2894, 2605, 8684, 3456, 1593, 102, 2660, 6786, 9932, 6568, 7566, 9186, 6108, 8334, 9681, 4116, 632, 3917, 4505, 3204, 3495, 3044, 5023, 2028, 7874, 4252, 8049, 3532, 9563, 9022, 6567, 5569, 4561, 498, 7483, 9058, 6229, 2727, 9965, 3990, 2048, 785, 9726, 3787, 1431, 1772, 7142, 7334, 2572, 6767, 6613, 2374, 5961, 8384, 6066, 9235, 9898, 6464, 7989, 8075, 5994, 2533, 5219, 4230, 2760, 4118, 7774, 4223, 1827, 6513, 280, 5874, 9988, 4916, 6522, 8004, 5814, 2332, 1807, 9410, 8781, 1483, 582, 8013, 467, 2639, 5455, 8293, 6909, 2625, 9587, 845, 1313, 4692, 8723, 6385, 3533, 749, 2190, 503, 4952, 9828, 4478, 5100, 1007, 5234, 9352, 747, 4903, 9350, 9071, 2247, 3784, 5609, 6941, 7394, 5683, 4755, 7284, 7145, 6495, 4034, 265, 8523, 960, 5897, 9707, 4301, 2690, 441, 7171, 174, 7546, 916, 9084, 4410, 3645, 9087, 1284, 6501, 1745, 1802, 9996, 5600, 5378, 5364, 9672, 3588, 1093, 701, 6981, 3528, 2536, 8663, 727, 719, 6780, 6545, 5334, 7007, 1342, 4935, 4002, 8875, 465, 4302, 154, 7109, 7131, 2564, 2474, 9976, 9964, 6142, 5046, 9484, 155, 1061, 2306, 9426, 9040, 2804, 5275, 828, 7185, 8521, 6670, 2850, 941, 2098, 3614, 168, 5069, 3301, 9346, 4501, 5940, 9763, 8749, 5673, 6256, 3625, 1995, 7807, 8083, 3859, 2060, 4221, 5390, 6616, 2172, 1274, 7201, 3061, 356, 2431, 9221, 7762, 199, 3002, 9759, 674, 3032, 7142, 7064, 95, 137, 9858, 4535, 3979, 6586, 8347, 2288, 5145, 8447, 3119, 7581, 3509, 8386, 321, 5716, 1529, 5285, 1846, 9284, 842, 9536, 3108, 6217, 9309, 3910, 1458, 5080, 9014, 3795, 3729, 4339, 790, 7214, 7047, 9721, 2985, 9675, 7703, 8334, 5285, 618, 8888, 6510, 7851, 5136, 1650, 1118, 471, 7494, 4893, 6364, 3797, 9434, 5656, 9072, 5211, 9897, 7237, 7201, 6065, 9591, 4019, 1530, 788, 4141, 8937, 2719, 4465, 1152, 9360, 8337, 6774, 4266, 7482, 9736, 3979, 802, 2036, 5539, 4109, 160, 4557, 2186, 5589, 9429, 7307, 8694, 4668, 5807, 7681, 7817, 5806, 8784, 9073, 6016, 556, 2384, 5801, 6884, 8023, 2142, 6236, 1606, 4501, 9314, 6660, 9575, 672, 8695, 9732, 2081, 1045, 5599, 7064, 7504, 4239, 3088, 8911, 3646, 5084, 8431, 5959, 5111, 194, 2272, 1723, 9728, 9558, 1504, 345, 3923, 390, 1634, 241, 1759, 4244, 1689, 4023, 3833, 4340, 873, 7022, 2306, 3955, 3198, 340, 3819, 5144, 7792, 8136, 8638, 697, 6104, 3095, 8411, 1236, 9947, 1855, 2193, 5276, 8004, 9087, 4861, 4491, 6632, 1774, 4335, 2918, 4675, 3941, 4364, 9314, 6322, 5096, 7664, 7500, 7517, 4754, 8096, 8393, 8346, 6294, 99, 6712, 9722, 4393, 5432, 4787, 7149, 7272, 6541, 5619, 8898, 6993, 7071, 7999, 820, 8682, 1564, 6913, 3370, 9071, 3137, 1549, 6747, 4880, 1221, 1221, 333, 9024, 75, 7036, 3772, 2901, 908, 9560, 8347, 7042, 8019, 3922, 9947, 654, 2751, 8922, 4948, 4890, 5610, 3874, 8712, 110, 6412, 2036, 1330, 4608, 2768, 1358, 5023, 3447, 971, 5477, 6602, 3586, 1142, 514, 7347, 8031, 9179, 9331, 9890, 5074, 7228, 665, 5984, 7917, 1745, 632, 4183, 6160, 3615, 2414, 7712, 8056, 1920, 4641, 4564, 7763, 9982, 1886, 5060, 546, 8920, 6219, 7764, 914, 1678, 1189, 127, 6282, 9887, 5987, 133, 4027, 3461, 8288, 2062, 6512, 9053, 8484, 8642, 2141, 8749, 8830, 9850, 1785, 7961, 9868, 178, 205, 8108, 7994, 3672, 6793, 679, 8869, 5040, 9853, 6464, 6610, 9430, 4166, 4483, 8154, 834, 5644, 4468, 6711, 2754, 6814, 2959, 3315, 3838, 9589, 7667, 3087, 4265, 19, 9702, 1150, 7252, 8958, 9359, 8990, 9128, 842, 7693, 6741, 4679, 1152, 1516, 7490, 3392, 9137, 9670, 6323, 8712, 9919, 4298, 9807, 7182, 4419, 1135, 3447, 1531, 9296, 4081, 7634, 2899, 946, 5784, 4949, 7260, 2802, 9085, 524, 6166, 6312, 5706, 7522, 5304, 7177, 17, 6443, 5159, 95, 961, 1676, 7385, 5582, 800, 9487, 6204, 2453, 1088, 8347, 573, 3831, 5297, 4560, 5675, 46, 5633, 1106, 4005, 2010, 4330, 3580, 3918, 5766, 5444, 2445, 9071, 5091, 818, 6497, 8460, 4620, 6624, 3267, 527, 6251, 594, 556, 885, 9400, 1163, 8767, 9262, 2979, 6479, 6266, 5978, 4453, 5674, 5968, 2351, 1569, 8391, 2859, 8905, 6369, 6089, 4701, 3502, 1942, 6228, 7959, 4186, 1275, 8933, 2198, 8474, 9978, 7907, 344, 6581, 271, 3997, 899, 1114, 5227, 4062, 1353, 8529, 8882, 4781, 6827, 7039, 6129, 8032, 2049, 3204, 9448, 4717, 1837, 2623, 8606, 7494, 6857, 97, 2124, 2032, 7690, 6782, 4755, 1592, 195, 5169, 1326, 3480, 3243, 6993, 120, 8191, 8459, 1162, 9625, 1784, 7859, 2765, 8613, 7409, 531, 2710, 3348, 895, 7802, 1330, 394, 6278, 8055, 5142, 384, 8921, 6740, 3736, 824, 6236, 2460, 541, 1307, 8258, 62, 107, 905, 8627, 2561, 9545, 529, 129, 4367, 9506, 3423, 8656, 4466, 4851, 3381, 5172, 4032, 9910, 7925, 6117, 5298, 8696, 585, 9139, 3889, 3941, 7412, 4039, 7043, 6898, 7942, 1498, 7668, 9401, 5679, 2515, 5186, 522, 5414, 9310, 3540, 2270, 1325, 1444, 6794, 7495, 8531, 3545, 1620, 2214, 8167, 2890, 2203, 5069, 6111, 1550, 4, 786, 1872, 5683, 5150, 9794, 4009, 2051, 6517, 8193, 2226, 3414, 7011, 1452, 4500, 9564, 3119, 1168, 6216, 9316, 4607, 6713, 6611, 7419, 8084, 8651, 7060, 5752, 4575, 1569, 1955, 6167, 6077, 3874, 2662, 3037, 9141, 2520, 241, 2224, 7551, 128, 2632, 9160, 1339, 7425, 2671, 2244, 6356, 3411, 8704, 7876, 9578, 9930, 6628, 5421, 7744, 8712, 9316, 9467, 2062, 544, 5984, 8170, 7999, 2053, 8129, 1594, 7114, 6406, 4766, 3413, 1138, 4819, 7954, 4179, 4652, 59, 7483, 6473, 9033, 5269, 3774, 6248, 1630, 7550, 7413, 9791, 7697, 8792, 9743, 1494, 6508, 6639, 8277, 6315, 8087, 69, 9707, 7126, 6343, 3659, 7713, 47, 6691, 4049, 623, 2244, 1935, 2892, 3707, 8312, 109, 6710, 4702, 6091, 8546, 5771, 3477, 30, 6010, 2793, 5997, 4781, 8369, 1218, 2759, 5728, 8599, 724, 6624, 5514, 9272, 7211, 3278, 664, 4586, 591, 3827, 5764, 6473, 3662, 4400, 5892, 7873, 2438, 5185, 1369, 5020, 1309, 3291, 4290, 6998, 1148, 5299, 7596, 6785, 5510, 2026, 5651, 9458, 5378, 3058, 4880, 6306, 9503, 4437, 5185, 6348, 6870, 8317, 1086, 376, 2146, 7023, 367, 4670, 2814, 4755, 1478, 9256, 2007, 9800, 956, 6944, 3420, 2176, 3647, 5682, 6437, 6693, 5969, 3531, 6195, 1363, 5698, 7271, 8855, 4691, 413, 3349, 7217, 8856, 55, 2743, 7469, 2458, 4459, 3490, 2423, 7863, 4095, 4752, 1151, 2583, 9822, 7734, 2256, 993, 617, 2577, 3501, 6679, 8267, 7800, 4103, 4895, 3483, 1999, 1425, 1370, 8960, 8053, 989, 3680, 8776, 3032, 2469, 3869, 6519, 2481, 4199, 1087, 232, 2338, 1864, 5264, 1567, 592, 4916, 5403, 4573, 5531, 7562, 6134, 1541, 5952, 5343, 7967, 2511, 9918, 7612, 2052, 3336, 7465, 3625, 1952, 9815, 432, 4263, 7292, 265, 2178, 4447, 5546, 7850, 3970, 3044, 304, 2644, 3347, 8010, 415, 4905, 2298, 8506, 7625, 8865, 4467, 7163, 9799, 6454, 6266, 452, 6517, 7057, 5428, 5416, 6312, 6365, 3902, 5060, 2468, 83, 4371, 5767, 9484, 3999, 102, 3754, 394, 7549, 7341, 2835, 6254, 2993, 5975, 175, 9885, 2689, 1147, 820, 8258, 6505, 2954, 3807, 6310, 596, 5856, 4278, 4910, 8499, 534, 2499, 4815, 1711, 5212, 2562, 5190, 4218, 4745, 2482, 7203, 5565, 3761, 9763, 533, 5139, 5845, 6583, 6836, 3775, 5234, 5454, 7786, 5795, 792, 2798, 9188, 2763, 5857, 2284, 7446, 928, 5758, 2374, 7620, 4923, 9797, 3295, 6408, 6463, 7313, 917, 4821, 9519, 4112, 3214, 6643, 1646, 8353, 816, 4341, 6958, 4679, 5179, 7236, 3212, 5836, 2711, 5794, 8444, 8253, 3452, 2523, 9545, 3271, 7361, 8962, 5185, 7877, 1466, 9261, 3570, 7948, 1047, 1270, 9399, 6344, 3783, 2536, 7831, 8438, 820, 9202, 6068, 1616, 4164, 7323, 6787, 9670, 9864, 2863, 4247, 7826, 6236, 303, 8274, 6694, 6606, 4743, 364, 6429, 4454, 124, 628, 2971, 7806, 3815, 9106, 4866, 6217, 250, 4367, 205, 4502, 3324, 7256, 3463, 1951, 9690, 2028, 4272, 2310, 8015, 8514, 3490, 193, 9521, 5040, 5114, 3190, 6137, 241, 7785, 888, 9211, 1930, 4020, 3649, 1744, 6608, 3380, 521, 2933, 4454, 2460, 4452, 5016, 6492, 5227, 9423, 7819, 773, 8962, 9756, 1491, 4854, 6383, 559, 7999, 744, 7370, 2859, 9591, 7555, 3390, 1333, 6701, 8057, 9902, 1355, 258, 7910, 1673, 2946, 2219, 1607, 3382, 7211, 5814, 3263, 3635, 2202, 4606, 8357, 3221, 2772, 9795, 2513, 2377, 3155, 2847, 74, 414, 7181, 2484, 9052, 5320, 7719, 869, 497, 6436, 4786, 6092, 4837, 2069, 6747, 6452, 2585, 2161, 8597, 2120, 6088, 1075, 4721, 3238, 3088, 4503, 7567, 6888, 5299, 6743, 9029, 7213, 3527, 5471, 7346, 8573, 7956, 3274, 3699, 6308, 6744, 4322, 299, 1438, 7519, 1106, 4529, 3212, 8903, 1771, 242, 2385, 5401, 6599, 6813, 1488, 5148, 592, 2923, 8069, 7042, 2981, 4238, 9740, 7227, 3319, 2300, 4358, 3450, 109, 8710, 5912, 7800, 9142, 3981, 5331, 5801, 2827, 2260, 4614, 9884, 8497, 7668, 4201, 815, 6482, 8890, 7080, 2980, 9022, 3396, 992, 1585, 8438, 9192, 9272, 3736, 5082, 117, 8923, 3014, 4873, 262, 2113, 8764, 3313, 2375, 9453, 9266, 8191, 9868, 8000, 6676, 9831, 9618, 5345, 4849, 7858, 9930, 2941, 2239, 2871, 4374, 4014, 6505, 7224, 6239, 5701, 9911, 5153, 5030, 5581, 6168, 2742, 7329, 4781, 465, 1015, 7630, 2958, 1664, 473, 6357, 4161, 7272, 9460, 9704, 5733, 697, 3634, 8294, 6825, 4018, 6626, 6682, 5939, 6103, 2798, 2751, 8578, 910, 4040, 4537, 4665, 5357, 201, 9912, 3245, 2331, 5018, 7380, 5909, 5934, 2730, 9132, 6022, 3660, 9381, 2922, 8710, 3393, 3486, 5093, 242, 6121, 6140, 8920, 5387, 4249, 4636, 8753, 8996, 3025, 3326, 2080, 1904, 6776, 1375, 324, 671, 2857, 7492, 5092, 8216, 6905, 9090, 8805, 5729, 2598, 6559, 3945, 6961, 8105, 3723, 6954, 4660, 4568, 7133, 1642, 5979, 4161, 5701, 5589, 885, 6756, 7083, 5447, 299, 8627, 8629, 3618, 2574, 3849, 5753, 6265, 4172, 1901, 4800, 8661, 8215, 2780, 3333, 7766, 7169, 293, 1176, 5472, 2867, 5809, 1957, 1673, 5994, 5775, 2117, 3789, 3424, 7801, 5220, 6625, 9992, 1333, 2118, 1243, 495, 5794, 1347, 3434, 2121, 4772, 6327, 7792, 234, 8183, 7463, 5415, 7597, 7429, 6471, 4352, 7714, 4997, 2981, 7714, 349, 720, 6670, 1514, 8114, 2931, 1717, 1887, 7970, 3908, 6330, 7051, 9505, 8311, 9213, 2766, 4708, 5598, 6619, 5916, 505, 344, 771, 7593, 5928, 7127, 9450, 350, 481, 4233, 6538, 3319, 9053, 3236, 6671, 459, 6241, 4905, 5920, 9319, 598, 2725, 5860, 2542, 1608, 2001, 1101, 1764, 5056, 6738, 3227, 3491, 4188, 6352, 3317, 4173, 5465, 4269, 2472, 5237, 277, 3919, 408, 8504, 5841, 3818, 5423, 252, 4882, 5030, 1704, 6553, 2535, 3906, 8167, 6436, 3769, 8485, 5404, 9296, 2419, 786, 7681, 7793, 4268, 9173, 9098, 5692, 1804, 6803, 7864, 6164, 822, 5941, 6388, 9602, 8209, 3859, 7347, 7220, 24, 5129, 6293, 3164, 9614, 6892, 2967, 7889, 3954, 2631, 5225, 5868, 3877, 3289, 384, 9948, 7798, 4703, 2572, 1274, 8243, 4834, 1680, 8173, 2841, 4638, 4013, 8927, 4601, 6240, 5059, 5269, 2871, 8622, 2533, 1914, 2863, 9838, 4377, 3551, 6936, 4795, 9839, 6958, 6391, 7132, 6236, 2307, 9472, 4443, 8549, 8672, 6558, 9184, 7670, 1954, 7473, 6361, 8995, 6650, 6076, 3876, 8062, 9338, 3314, 184, 9557, 6226, 3731, 6736, 8145, 5836, 1689, 7074, 6753, 8361, 4894, 7738, 7523, 4412, 8713, 525, 7737, 8496, 7479, 2882, 1877, 6435, 6878, 6664, 4322, 3590, 4040, 5351, 1176, 1368, 7387, 2569, 6203, 3062, 7276, 8777, 2927, 2583, 7926, 9976, 6385, 9299, 8151, 1101, 5934, 456, 4348, 1779, 138, 8191, 2609, 6151, 6165, 8533, 782, 2531, 921, 6099, 1980, 4337, 3709, 6731, 9354, 4504, 3553, 9279, 7551, 7658, 1494, 1975, 2866, 9321, 8093, 2134, 3558, 2944, 3729, 1266, 9252, 4491, 2713, 1712, 221, 3915, 8181, 7118, 214, 2581, 6277, 3119, 9957, 4180, 3189, 3021, 2669, 5418, 7690, 2979, 8665, 2571, 8137, 4054, 6714, 1824, 2345, 9741, 2928, 9721, 3006, 1909, 4150, 7724, 5749, 9241, 2928, 4057, 6566, 9828, 1804, 9593, 3103, 8889, 7302, 2214, 8173, 1609, 4373, 158, 9645, 3202, 8578, 1991, 2928, 3078, 6519, 2164, 4020, 9806, 1792, 8988, 922, 1314, 3787, 5541, 7817, 9137, 5624, 9556, 5433, 6059, 8274, 2678, 2841, 9717, 2683, 974, 5234, 653, 7259, 4397, 3165, 3387, 9281, 5379, 6228, 8435, 5483, 6279, 605, 6458, 1257, 1818, 4054, 9485, 3890, 8653, 4871, 6932, 9636, 7644, 8896, 3728, 1673, 675, 2768, 4446, 7210, 4229, 7968, 8186, 7585, 1988, 545, 1524, 3711, 9215, 8130, 5942, 2831, 5723, 5610, 3697, 969, 7342, 2100, 7834, 2902, 8286, 6234, 6201, 6094, 8059, 1646, 5280, 4201, 5033, 1946, 1829, 4119, 4373, 4954, 6936, 6074, 3300, 3590, 4354, 6386, 4410, 2110, 9794, 9743, 9509, 1460, 433, 6538, 2863, 6572, 6952, 4653, 3107, 8402, 2602, 6194, 934, 6017, 1773, 8131, 839, 8139, 5691, 5228, 3348, 7016, 4060, 5413, 2380, 1563, 3318, 6093, 1015, 8733, 2527, 8055, 5084, 5856, 5017, 9237, 7124, 9819, 5572, 6789, 809, 4813, 1134, 7102, 4385, 2608, 1328, 611, 3691, 8946, 9880, 7255, 5144, 116, 5781, 2769, 8861, 7384, 2947, 9236, 4731, 1599, 6123, 9595, 2815, 7834, 9989, 2888, 5392, 9125, 1610, 4920, 7573, 3592, 5324, 1069, 8515, 1742, 2923, 3528, 9659, 7846, 6526, 6549, 1858, 8492, 7531, 7547, 8033, 2204, 3447, 2976, 6016, 3055, 1956, 6163, 9601, 3247, 9505, 414, 6914, 5343, 8865, 6838, 4323, 6393, 4372, 6664, 1563, 4995, 4712, 2237, 1827, 7177, 5764, 2316, 2985, 5227, 7180, 2694, 9950, 7650, 1167, 9077, 1514, 8688, 2931, 7110, 6455, 3090, 4805, 6895, 5028, 7879, 2903, 9061, 7798, 6875, 3646, 6081, 3413, 9249, 7884, 8108, 8466, 3930, 9471, 5976, 2633, 7678, 6891, 5283, 7604, 482, 1507, 8678, 8745, 8686, 3332, 7797, 1260, 7235, 8120, 8279, 7202, 108, 1658, 6553, 8934, 8525, 1596, 7657, 4387, 2276, 9184, 3737, 3646, 2753, 854, 203, 6643, 3030, 972, 1759, 6998, 4248, 7676, 506, 7529, 7470, 8628, 3573, 7309, 334, 4435, 4918, 7559, 1951, 5583, 5339, 297, 2874, 6295, 6540, 5851, 6509, 7225, 964, 3484, 6253, 7139, 6381, 3108, 72, 559, 4159, 5106, 6725, 1188, 5272, 9571, 4014, 4500, 5521, 2478, 6546, 3829, 2325, 5898, 5988, 7360, 4401, 5813, 7361, 9118, 1920, 5084, 6973, 5474, 6986, 423, 288, 8902, 9076, 1189, 8552, 9487, 3388, 579, 6719, 1406, 5188, 6160, 215, 4225, 3429, 9470, 4937, 3973, 6702, 527, 9142, 4109, 4566, 7654, 5895, 5719, 4202, 9079, 1211, 4117, 1982, 6102, 511, 2136, 8387, 8548, 6310, 795, 7077, 9453, 4907, 737, 3609, 5102, 4485, 7298, 2411, 7612, 2325, 9353, 5582, 2702, 4797, 805, 7837, 3021, 2697, 1751, 9602, 483, 3812, 1161, 9681, 8924, 1339, 9554, 8820, 1050, 9041, 4141, 7822, 162, 5257, 9256, 2264, 5980, 6117, 4137, 3920, 7143, 7742, 7004, 5795, 5874, 6856, 9303, 9936, 117, 1786, 2515, 4226, 9890, 7419, 4953, 1697, 6674, 7626, 4630, 6859, 3648, 1059, 469, 4045, 7444, 8913, 1075, 7464, 8024, 9510, 6650, 9152, 5668, 1286, 348, 7921, 7119, 8929, 1421, 2002, 7264, 2601, 1896, 1058, 7842, 1804, 5611, 1315, 1117, 341, 1889, 5787, 6773, 1324, 6171, 6488, 6305, 3687, 2875, 3458, 8897, 4635, 9110, 2727, 985, 6125, 5200, 2270, 3267, 312, 3804, 326, 4591, 5133, 8831, 9198, 3632, 569, 1456, 5006, 5958, 8650, 9132, 7294, 5363, 8740, 8013, 429, 7199, 3824, 4940, 9715, 9362, 6580, 9795, 8479, 3422, 8268, 1648, 1694, 4079, 5946, 7972, 607, 1085, 287, 9921, 6426, 2919, 1243, 7136, 5548, 2451, 3556, 735, 9765, 3144, 7664, 9360, 9366, 4782, 3210, 7775, 4636, 3462, 1427, 4148, 7352, 2933, 4679, 1216, 521, 3294, 5943, 4898, 6908, 5115, 4943, 6284, 380, 4139, 7561, 6803, 2161, 8580, 8637, 1221, 2004, 6019, 7532, 1037, 9260, 1550, 4410, 8743, 6059, 1185, 7433, 8668, 4273, 631, 8862, 6960, 3128, 4628, 9365, 1477, 4474, 7285, 6610, 3777, 7344, 6857, 3631, 6142, 843, 8647, 3947, 7299, 7038, 874, 701, 3582, 9607, 9092, 4128, 9234, 4417, 4882, 2367, 958, 1987, 6022, 789, 5418, 4992, 3295, 2992, 8221, 101, 2520, 1170, 3137, 8546, 5704, 7231, 3752, 5629, 9340, 4893, 1216, 6860, 5273, 181, 2517, 6451, 3693, 8495, 8425, 5942, 6040, 1097, 9075, 9044, 3040, 8023, 9516, 7001, 926, 8724, 222, 6094, 2405, 4475, 4810, 3822, 7868, 7101, 608, 2450, 4079, 43, 2412, 8486, 5550, 9825, 6555, 4470, 3350, 5142, 3771, 8419, 9096, 3399, 4151, 2768, 2503, 2702, 1046, 7449, 3720, 7964, 4338, 6311, 7780, 5061, 604, 2656, 6195, 5318, 5582, 9732, 4331, 1276, 208, 8538, 2695, 2266, 1231, 1040, 3633, 6, 2405, 9633, 5048, 1842, 2497, 3925, 9431, 6992, 4892, 3780, 9593, 1467, 3327, 3592, 1119, 5191, 625, 7294, 3512, 7714, 4010, 4525, 9559, 8424, 603, 772, 4492, 3366, 6731, 7292, 6719, 4701, 5380, 852, 740, 7998, 1514, 3311, 3554, 7672, 9997, 8452, 2213, 5247, 5119, 433, 7640, 7685, 6679, 4314, 7612, 1912, 4, 9702, 1679, 1472, 6591, 7768, 9562, 4764, 248, 3673, 7885, 2639, 6929, 9567, 5323, 7138, 656, 500, 3804, 5780, 2770, 6034, 4208, 9667, 8234, 5101, 2195, 7105, 1963, 3711, 5767, 2686, 8331, 8206, 4585, 165, 9375, 2576, 14, 6971, 1339, 8238, 4649, 1944, 7449, 3851, 2537, 9405, 883, 2453, 5386, 9012, 3315, 6368, 6755, 8761, 2030, 3149, 5793, 3102, 7650, 2994, 9460, 9024, 5056, 8573, 2969, 8825, 784, 2604, 4578, 5733, 3579, 5645, 3138, 1874, 4766, 778, 3919, 9523, 649, 5391, 1613, 4294, 7555, 4897, 8258, 3688, 5707, 7455, 5254, 9536, 1453, 5148, 2302, 5131, 4535, 4666, 1413, 8200, 1955, 8466, 2750, 4114, 2015, 3795, 5019, 6060, 4309, 2736, 973, 6477, 9423, 8697, 8352, 6696, 5481, 2075, 7769, 5903, 4158, 4957, 9853, 9055, 1578, 4315, 280, 5256, 4450, 2305, 7419, 228, 1529, 7285, 313, 1292, 321, 7808, 7455, 1275, 3935, 2046, 3610, 1886, 9309, 1696, 5970, 2235, 106, 3856, 380, 6592, 8668, 6137, 3302, 5111, 9908, 5679, 3096, 8439, 528, 5316, 3185, 3486, 5573, 5000, 5506, 447, 2015, 1368, 1230, 1513, 6141, 6091, 5102, 7234, 9581, 6577, 1034, 1740, 2943, 6723, 798, 324, 9433, 4999, 7416, 7974, 419, 296, 4116, 8741, 9299, 5454, 4625, 3502, 2679, 4780, 7540, 7854, 4561, 5758, 6620, 1531, 7957, 7983, 1174, 5484, 3621, 7438, 9878, 8178, 824, 8236, 1886, 7963, 9325, 2282, 3263, 2116, 7886, 5543, 4650, 7769, 7091, 1900, 8079, 3446, 6702, 6155, 1740, 9495, 6318, 4871, 9614, 5669, 6812, 3635, 3682, 4388, 1558, 9046, 9283, 6448, 7377, 8601, 1489, 9025, 6670, 2728, 428, 1776, 9783, 3247, 2174, 873, 4608, 4866, 5731, 2861, 9667, 1528, 3870, 6175, 2792, 1533, 8843, 7802, 7202, 8415, 1882, 3014, 6810, 6943, 6883, 3714, 6338, 1285, 3639, 8981, 1999, 9387, 2070, 8335, 5293, 8239, 4171, 2233, 5478, 6545, 7940, 8500, 1166, 6502, 4376, 7408, 7733, 9272, 2059, 1548, 4200, 8040, 9211, 2000, 3595, 798, 4212, 6977, 8834, 6721, 2643, 2086, 907, 1626, 9354, 1714, 1117, 3064, 1988, 5968, 319, 4102, 4259, 4743, 3713, 1228, 1900, 5515, 5409, 8859, 710, 4142, 4294, 8098, 4346, 6472, 9757, 2904, 5970, 1490, 8063, 4611, 4512, 5131, 692, 8989, 9603, 5163, 1596, 4276, 2658, 7984, 8521, 437, 1493, 9215, 1386, 3241, 1901, 7138, 6634, 4958, 9092, 26, 7631, 5551, 5800, 3298, 8988, 2296, 2814, 78, 2324, 9300, 6037, 7946, 7158, 460, 7347, 984, 5336, 2534, 265, 5873, 228, 3097, 8099, 8583, 9447, 5983, 7672, 939, 6243, 550, 4910, 6225, 3631, 710, 7038, 6176, 5304, 2969, 1024, 4426, 9780, 8089, 3721, 1324, 5470, 2684, 7847, 9962, 7843, 9579, 3373, 8354, 9028, 7232, 6531, 400, 6877, 7032, 692, 7979, 5037, 6826, 6230, 4378, 3115, 7886, 3477, 6040, 6566, 7975, 9024, 713, 6313, 8520, 7747, 755, 3724, 5826, 9450, 2442, 319, 3366, 1141, 84, 8108, 1264, 9951, 7058, 302, 1379, 7376, 1011, 7762, 926, 6186, 2793, 5975, 7112, 7641, 9611, 2738, 728, 405, 8460, 1656, 3901, 7634, 557, 5380, 2822, 801, 7398, 3988, 5568, 4063, 7407, 986, 4712, 7968, 5956, 8018, 5915, 2941, 8082, 2153, 4481, 1160, 7624, 2203, 411, 7324, 5369, 319, 383, 7835, 701, 3928, 4617, 2725, 1098, 9128, 7425, 3715, 1648, 8800, 6981, 2960, 7966, 1864, 1446, 7719, 4432, 4368, 9967, 9301, 6232, 2910, 1044, 5837, 4289, 3026, 429, 7204, 1980, 7520, 4563, 6100, 8495, 5037, 7943, 654, 6256, 8114, 768, 4698, 2464, 9391, 4239, 6055, 8136, 3032, 572, 1577, 4978, 7313, 6514, 8983, 8501, 8389, 82, 7575, 7528, 1684, 8224, 5467, 6892, 3064, 1383, 4250, 4303, 2869, 3611, 6224, 3854, 5373, 1750, 5073, 9003, 4919, 3236, 9613, 598, 9680, 2250, 850, 6925, 5951, 2991, 8731, 4900, 3474, 4599, 3880, 3960, 8874, 665, 6826, 764, 5798, 9472, 4989, 2438, 852, 6311, 2721, 6212, 2060, 3723, 611, 3710, 3286, 9737, 6773, 8247, 7535, 8111, 6830, 2144, 3130, 7082, 3702, 7667, 8449, 3358, 5180, 8628, 8856, 9642, 5144, 6468, 5550, 7092, 3433, 9474, 6681, 7073, 4956, 9870, 8126, 8553, 7374, 4552, 1368, 4891, 2297, 7054, 2628, 2675, 5001, 3599, 7356, 4346, 9351, 8222, 7539, 395, 1222, 9898, 6317, 292, 3247, 9738, 872, 5770, 9091, 9299, 741, 2579, 959, 8973, 5519, 8861, 3037, 757, 5556, 2106, 7263, 6006, 4049, 5497, 7951, 7886, 4835, 663, 8940, 2528, 5429, 7062, 2476, 484, 6030, 650, 7670, 8954, 928, 3025, 5010, 8812, 1446, 574, 2292, 642, 8077, 1275, 9562, 2442, 208, 9723, 6208, 8807, 4915, 3666, 3150, 2991, 9966, 6374, 4524, 794, 8388, 4878, 5814, 729, 7709, 1447, 6432, 5468, 6487, 2503, 7455, 3574, 2670, 2075, 4797, 1808, 6407, 7042, 8381, 2956, 2591, 3897, 7736, 5306, 2313, 426, 9292, 1246, 3362, 8010, 5705, 3352, 8576, 3361, 3009, 1162, 3009, 2906, 8938, 4893, 1642, 5791, 7476, 2264, 5356, 1014, 4960, 179, 3134, 889, 1846, 4700, 9707, 7022, 2610, 9414, 5401, 3090, 1936, 2839, 4753, 53, 6625, 7927, 7474, 2692, 909, 169, 7017, 1272, 9350, 6317, 6671, 6875, 94, 8075, 3721, 2011, 3095, 6455, 1052, 4862, 1257, 9746, 1824, 8143, 3402, 1033, 9443, 8721, 2945, 9867, 8360, 1561, 7540, 3682, 3166, 6867, 2993, 4764, 9339, 9196, 1880, 2400, 4402, 8325, 4154, 157, 8478, 4250, 7510, 9229, 2541, 4423, 130, 1136, 7799, 4158, 1691, 3478, 7084, 5392, 6466, 3803, 7348, 3151, 1218, 7577, 1794, 5933, 7723, 1433, 9347, 593, 6888, 1839, 4127, 1909, 5068, 1819, 6209, 7303, 5665, 3144, 5497, 9671, 370, 4460, 5531, 257, 9941, 7299, 9365, 9905, 6771, 3975, 3860, 5900, 5155, 8962, 9055, 546, 24, 3377, 4753, 7835, 6309, 4012, 1655, 6698, 1725, 8084, 96, 5663, 80, 2186, 4135, 4903, 2335, 7237, 2108, 3336, 2997, 4500, 4334, 9215, 4879, 1293, 1489, 7112, 7499, 7270, 9799, 9011, 363, 8586, 2587, 5887, 5526, 2067, 524, 4723, 6539, 5348, 4366, 5667, 3950, 7153, 6857, 1378, 8618, 4135, 4305, 5660, 2072, 7085, 4868, 8718, 4294, 7549, 5280, 3609, 4010, 841, 1553, 4875, 4878, 7761, 5906, 77, 2596, 7393, 5716, 30, 6984, 4684, 1083, 7717, 1420, 3843, 7418, 5875, 2269, 7122, 6224, 2996, 6443, 1487, 2274, 177, 5546, 623, 1118, 5298, 3491, 4493, 3057, 8253, 6447, 7923, 1217, 1676, 2743, 9979, 4727, 8057, 4205, 7414, 9790, 8520, 8986, 989, 1206, 8021, 1196, 4318, 899, 6039, 5221, 9970, 159, 6013, 3501, 9001, 5912, 8700, 5498, 6175, 3335, 2824, 8149, 3020, 9999, 5457, 8526, 6739, 9678, 1059, 141, 3133, 3126, 6295, 8854, 4, 1615, 9041, 1065, 684, 9392, 3225, 7075, 5732, 3116, 3984, 1027, 9509, 2778, 3402, 6664, 449, 1565, 7462, 5612, 4727, 8018, 7087, 7607, 6299, 2329, 544, 9947, 1817, 448, 683, 8626, 8569, 9920, 7497, 3058, 8550, 9245, 4363, 5387, 7259, 1645, 4539, 7684, 5851, 3146, 6253, 4324, 2333, 7348, 7324, 8042, 5258, 9334, 3018, 2949, 4454, 3051, 5187, 6214, 1635, 9645, 251, 1531, 5031, 3037, 186, 2580, 4620, 5217, 4480, 5824, 3582, 8878, 811, 9063, 3447, 8318, 7249, 2322, 8848, 2938, 4404, 1889, 9012, 6009, 8679, 4906, 7962, 461, 1969, 7287, 7209, 8540, 9845, 86, 9151, 4820, 2420, 8212, 4419, 4205, 8576, 7190, 5520, 5079, 4370, 2039, 2970, 1694, 7104, 6465, 8672, 9444, 7835, 2039, 4598, 4879, 377, 4338, 5907, 3222, 5156, 1103, 9719, 5492, 7175, 3722, 9104, 2555, 5745, 8772, 889, 9951, 4397, 7827, 7856, 8930, 8270, 7312, 4981, 3351, 4355, 5360, 9898, 8754, 6640, 5571, 7054, 2901, 817, 2615, 5231, 3785, 4698, 6943, 7456, 2528, 2576, 6129, 2601, 6959, 509, 7139, 9113, 4033, 5637, 7463, 8143, 5583, 6000, 4517, 4364, 6418, 5332, 1649, 8559, 8272, 3791, 2988, 2665, 4053, 122, 5490, 3709, 2951, 9315, 9497, 988, 3527, 5211, 7159, 8757, 3545, 8086, 3134, 5629, 6911, 1142, 8026, 5455, 9324, 8575, 6607, 1246, 7956, 9579, 9728, 7212, 412, 7081, 7923, 6296, 3361, 8042, 9456, 8044, 7333, 5399, 8101, 2030, 4229, 9989, 2803, 7903, 4900, 6063, 552, 1638, 2003, 7617, 7000, 5199, 8917, 7233, 2234, 5597, 6013, 6425, 3089, 2551, 3778, 634, 5182, 3494, 9589, 9140, 8933, 9708, 4769, 3457, 2467, 471, 2407, 7652, 8709, 2907, 5774, 2508, 8386, 8770, 6494, 4050, 8148, 6343, 4295, 4013, 9669, 2687, 2457, 8745, 7448, 1816, 9452, 2778, 454, 2726, 8892, 4303, 7924, 9788, 5193, 4273, 2949, 2884, 1591, 2541, 8156, 6429, 9491, 9460, 581, 7921, 7769, 8665, 9256, 4170, 5866, 3683, 8513, 3347, 137, 8760, 3336, 143, 7977, 3140, 3042, 6354, 3085, 5990, 6771, 6345, 8607, 6319, 5383, 7723, 2135, 1816, 7200, 8676, 193, 6111, 3400, 2526, 2398, 5217, 2685, 534, 7643, 2787, 7548, 9212, 3032, 8105, 7272, 1576, 6035, 7300, 9825, 7339, 5532, 6431, 829, 4674, 7970, 6384, 3818, 759, 7664, 587, 5428, 6691, 4300, 6912, 2434, 1723, 9556, 9972, 679, 5029, 2694, 2147, 5514, 9938, 2821, 6709, 9783, 6349, 3343, 2850, 9813, 5519, 7789, 4294, 4457, 4550, 9271, 6317, 8223, 7575, 2498, 2471, 5066, 4786, 3725, 2249, 9718, 6290, 7538, 3578, 6830, 4425, 2959, 2176, 3436, 7808, 3004, 2341, 1478, 6565, 9110, 3247, 409, 1653, 1166, 9446, 353, 9599, 4647, 1638, 9416, 3496, 3145, 7650, 4726, 6994, 1255, 9041, 6651, 3105, 4424, 3895, 6920, 9455, 7511, 3977, 9232, 4865, 9093, 7074, 1311, 310, 592, 8006, 2423, 5786, 6820, 2561, 1222, 9239, 6925, 9870, 3264, 232, 909, 1287, 6076, 7773, 6762, 5688, 3506, 3210, 3058, 6167, 7499, 2203, 5558, 6774, 6133, 1578, 6695, 1767, 7556, 6684, 3188, 490, 7846, 78, 8558, 7038, 657, 5431, 4587, 6148, 1583, 7340, 9513, 996, 3694, 9875, 3893, 5066, 4561, 998, 100, 4978, 5187, 6978, 5265, 3553, 2987, 6918, 9612, 1878, 5446, 9733, 8630, 8426, 4395, 5719, 599, 1653, 8170, 9536, 7179, 9059, 7232, 8600, 6029, 9857, 8060, 7694, 9749, 9087, 3914, 3719, 7235, 7733, 213, 3469, 6989, 3861, 2092, 4988, 8763, 6486, 506, 2149, 4819, 9305, 7447, 625, 4994, 5378, 8634, 9825, 8866, 6465, 9745, 4568, 7029, 9816, 1258, 6477, 4463, 7272, 8695, 1757, 5491, 9791, 355, 4281, 3487, 639, 6351, 5453, 8905, 8112, 1613, 268, 7319, 2182, 2148, 8842, 7795, 4796, 8718, 8916, 4611, 2314, 3724, 1073, 2004, 6396, 23, 7607, 237, 8820, 1122, 4613, 5800, 5367, 651, 8555, 7988, 4892, 4704, 4255, 682, 7154, 4704, 154, 6570, 409, 1371, 7336, 9199, 9987, 914, 1575, 2048, 1901, 4015, 6025, 1732, 6502, 1247, 6290, 6099, 717, 9548, 6591, 2488, 1611, 342, 5326, 1507, 8505, 1610, 8935, 8927, 2443, 5315, 4887, 9702, 4005, 9042, 3823, 3331, 8914, 7583, 2907, 1436, 9294, 278, 8827, 5296, 4797, 6519, 9441, 5050, 8166, 6420, 6350, 7347, 1460, 3401, 8177, 4554, 7129, 4739, 9973, 4248, 1970, 6579, 7351, 5969, 4655, 6832, 122, 5685, 6173, 4597, 7462, 734, 1375, 992, 9039, 5307, 159, 7736, 9043, 8536, 2523, 4200, 2735, 4291, 2406, 4785, 1219, 6243, 6133, 1726, 3851, 2453, 3379, 5496, 1738, 9146, 295, 3634, 628, 5917, 6699, 4964, 922, 7791, 1472, 2552, 3706, 1530, 9251, 9033, 226, 118, 157, 7136, 7893, 4419, 992, 5614, 6865, 6487, 2843, 3010, 7675, 9618, 6020, 8262, 7928, 2038, 7765, 7306, 4155, 6875, 2393, 2683, 8040, 8607, 1685, 6072, 4595, 3820, 2573, 7155, 4238, 1794, 8214, 3483, 7622, 1063, 7274, 3836, 9205, 5565, 7598, 8157, 4572, 8059, 9468, 2431, 9706, 1790, 4618, 1131, 5247, 5744, 4990, 6543, 6843, 8064, 2000, 8100, 5226, 592, 3003, 202, 2607, 7216, 218, 6102, 2748, 5579, 1869, 969, 7865, 7813, 3272, 609, 2878, 3142, 4965, 476, 7132, 3252, 8921, 1437, 4753, 2164, 2703, 8356, 7311, 2805, 5473, 1125, 4924, 1252, 1820, 7359, 6745, 7946, 68, 8834, 282, 8765, 9457, 3001, 8915, 8657, 7806, 5012, 8896, 7800, 6984, 5118, 1719, 2070, 3125, 3900, 7710, 2875, 4759, 1249, 2881, 2494, 1248, 7772, 4315, 4498, 3732, 1282, 4036, 1485, 4964, 8944, 2764, 516, 1995, 6003, 794, 7143, 2910, 2908, 4601, 3525, 843, 5210, 4426, 7105, 9490, 6499, 8006, 7778, 6602, 1773, 7894, 3744, 5890, 8496, 4371, 7851, 8845, 7361, 7197, 5015, 331, 3188, 376, 9493, 859, 2645, 1768, 3774, 9865, 1055, 8580, 2275, 8213, 6120, 399, 9057, 110, 3197, 8154, 6307, 1178, 8480, 450, 5232, 9142, 1889, 8508, 6693, 299, 4401, 2635, 695, 5610, 8542, 5870, 1879, 246, 5302, 5687, 149, 4492, 5450, 7940, 7239, 4494, 803, 3613, 363, 2509, 5571, 7681, 7420, 8359, 1781, 5920, 7204, 1853, 5622, 1661, 7423, 4838, 3456, 275, 6450, 9389, 9917, 4167, 9771, 7698, 489, 5370, 6449, 6890, 5941, 1406, 2575, 516, 70, 2735, 9426, 4409, 3126, 9848, 3244, 1951, 3007, 7121, 8409, 2594, 1691, 6986, 9764, 7841, 7098, 259, 5308, 7248, 6374, 5343, 8422, 5379, 718, 5478, 9342, 5482, 8503, 6891, 4792, 1166, 84, 7543, 6211, 3701, 2139, 5252, 583, 9712, 2103, 8830, 9189, 2425, 3720, 5117, 8896, 7967, 267, 9307, 3786, 4406, 6017, 3612, 823, 1252, 9276, 4929, 6301, 8730, 3327, 7413, 5221, 8619, 1076, 6097, 9724, 3854, 4335, 9899, 7489, 6506, 6367, 1059, 5902, 2170, 5612, 9874, 9530, 4411, 702, 1777, 4250, 2436, 7817, 3826, 4047, 1123, 3370, 2110, 9873, 1524, 2869, 2460, 7703, 4588, 1251, 3160, 2695, 2721, 8067, 8557, 3811, 5944, 3941, 9768, 759, 2963, 5928, 8501, 5815, 9707, 15, 6232, 2039, 8350, 2555, 3420, 1713, 5162, 6362, 3208, 8180, 5036, 4622, 5042, 1212, 2010, 9007, 1567, 7203, 3570, 6462, 4232, 594, 9505, 5448, 644, 5300, 1359, 9850, 5638, 5977, 758, 9674, 8844, 2012, 7740, 2747, 7481, 983, 162, 7892, 4361, 9373, 3184, 337, 9391, 4382, 6900, 3466, 7304, 4481, 8236, 7306, 2265, 4766, 1223, 8355, 5025, 416, 5400, 2064, 2856, 4957, 2678, 9884, 9937, 9980, 8617, 6683, 8094, 8787, 3773, 4143, 2726, 520, 5672, 4020, 2215, 5815, 4251, 9807, 7540, 670, 3180, 5957, 5453, 3728, 252, 9519, 3702, 8982, 7872, 48, 2142, 9374, 3822, 1843, 2189, 2885, 9719, 1526, 2480, 3069, 2300, 1633, 3603, 4802, 3085, 1695, 3674, 5385, 4046, 9929, 9450, 9491, 1109, 2010, 8701, 6141, 3769, 3431, 2808, 2534, 5235, 8687, 4859, 1639, 6404, 2993, 1219, 5269, 491, 9255, 7138, 1314, 2558, 4634, 8751, 8709, 6260, 5357, 4172, 5936, 2902, 4183, 1264, 8334, 1704, 7836, 1061, 6390, 8155, 3021, 1350, 9144, 863, 4645, 3173, 3087, 4860, 5269, 4159, 1333, 1517, 286, 7761, 8445, 6219, 2491, 2249, 4507, 6668, 4301, 1602, 692, 1248, 5887, 1532, 1940, 9797, 8843, 8037, 367, 8844, 9984, 5919, 3953, 2581, 5774, 3263, 25, 623, 4475, 3855, 8331, 9199, 8746, 9824, 8464, 3556, 5529, 5463, 3668, 7006, 4145, 4728, 447, 3376, 1165, 1699, 4679, 4839, 6818, 9270, 6135, 8248, 3728, 6384, 3495, 801, 3075, 6351, 1524, 3486, 2303, 9924, 6811, 8980, 7808, 5306, 8370, 9736, 8001, 5134, 5815, 5756, 7939, 6097, 6476, 5494, 2903, 3031, 3563, 9901, 4674, 2725, 1926, 9701, 577, 7168, 92, 2630, 2808, 6108, 4817, 2891, 2066, 4219, 4305, 2552, 2859, 590, 5555, 9295, 331, 6527, 2828, 9137, 5029, 3136, 8175, 3560, 6940, 4302, 1285, 8607, 45, 1753, 585, 875, 8588, 3483, 2021, 9306, 2073, 1723, 9168, 5684, 9808, 3876, 3756, 5123, 1200, 1497, 2277, 9497, 9502, 858, 9870, 7512, 138, 8453, 4548, 4075, 4693, 3221, 2273, 3561, 9487, 192, 5958, 4970, 6814, 9164, 4377, 5651, 8476, 9944, 6683, 4706, 2907, 9160, 3557, 9337, 8295, 4364, 8628, 6929, 165, 9291, 732, 1323, 9724, 1612, 8604, 5228, 5023, 648, 4912, 6088, 5062, 8575, 6735, 7409, 2340, 8155, 5873, 4891, 9082, 805, 8725, 7071, 1351, 5905, 2806, 8859, 6520, 4698, 2227, 3465, 8659, 7026, 8115, 6315, 7364, 6535, 95, 4114, 1592, 5059, 7147, 6699, 7188, 7742, 1397, 5104, 2396, 4348, 8403, 440, 857, 9922, 9129, 9446, 7544, 6758, 3296, 9796, 8808, 8293, 437, 3099, 7748, 3954, 1893, 8019, 6219, 7825, 5693, 3491, 7983, 7100, 9957, 9201, 7331, 7931, 2570, 3219, 8887, 4672, 6519, 7602, 8393, 395, 352, 4699, 5154, 5170, 1416, 2301, 6070, 6520, 4701, 5715, 96, 9483, 6628, 558, 4887, 6575, 2577, 8956, 7547, 7616, 6894, 1187, 3639, 3267, 8493, 2690, 883, 192, 457, 4006, 2730, 9893, 4319, 484, 4767, 103, 826, 4750, 4339, 4280, 4002, 8454, 3594, 2331, 7127, 2543, 1003, 8753, 3797, 5649, 3282, 4152, 1711, 671, 2167, 9391, 8583, 8881, 8305, 5272, 7172, 8462, 8795, 8875, 7233, 3895, 6961, 1455, 3244, 2648, 6884, 2478, 4737, 9552, 5830, 4218, 1779, 4935, 5993, 217, 2845, 5927, 6362, 7158, 7104, 2277, 3412, 4073, 3441, 2865, 7466, 268, 5838, 6538, 4077, 5869, 2543, 648, 8790, 2301, 7499, 7308, 4503, 3284, 8783, 138, 4728, 4759, 4129, 5605, 9887, 7268, 753, 2479, 515, 5494, 5359, 8848, 7183, 5682, 3282, 52, 5147, 260, 7000, 4467, 646, 9729, 5967, 5860, 469, 4199, 9972, 4617, 5614, 3753, 8789, 6368, 9572, 2990, 8994, 7980, 4941, 8930, 2983, 8440, 9597, 2658, 1566, 7720, 9288, 8376, 6663, 5189, 3179, 8199, 9689, 942, 3994, 4820, 9150, 6851, 8208, 6523, 4994, 5059, 5530, 1507, 6614, 7082, 6099, 5380, 8550, 2551, 1474, 4910, 6013, 5625, 3767, 2138, 6539, 9490, 3378, 7148, 9037, 245, 7437, 4092, 4756, 103, 1596, 5935, 3107, 4860, 5093, 7719, 1008, 679, 1305, 9959, 9516, 7409, 5197, 1757, 9191, 2778, 6380, 6518, 1331, 4913, 5203, 4664, 8679, 7845, 4613, 4040, 8488, 5844, 2374, 2094, 902, 3686, 2648, 6482, 8992, 5927, 5806, 7854, 9653, 40, 8269, 4141, 2925, 4373, 2403, 1560, 110, 2319, 1525, 2679, 8311, 1405, 1579, 7781, 826, 9979, 9114, 8609, 3656, 6285, 7889, 6334, 7817, 3285, 3610, 7444, 4449, 710, 9507, 3426, 1195, 4638, 220, 5126, 9804, 2376, 6820, 7035, 4143, 5612, 63, 569, 6182, 8483, 772, 1475, 2212, 9346, 214, 3045, 8120, 3357, 9584, 1604, 7929, 6245, 9582, 3140, 8660, 3648, 993, 4248, 5435, 3383, 3563, 3879, 7682, 5390, 3079, 8843, 9936, 1509, 3032, 9413, 482, 4614, 1240, 2026, 272, 9960, 8310, 7855, 8254, 3119, 8482, 1384, 2998, 9724, 9052, 7172, 8141, 7791, 5245, 3578, 1143, 5571, 637, 7743, 5204, 1340, 4091, 3891, 6804, 7258, 504, 1213, 7986, 9971, 715, 4525, 7022, 8060, 9111, 8914, 1723, 3376, 5821, 460, 6690, 6414, 4035, 7929, 802, 1976, 159, 4576, 3131, 3319, 4507, 9606, 1709, 9298, 5571, 3748, 4875, 2728, 3614, 8974, 6508, 6548, 5300, 9918, 684, 5394, 5349, 6961, 7431, 1765, 7002, 2624, 1864, 2744, 8802, 5136, 4268, 3965, 6500, 3593, 9119, 1028, 590, 973, 9080, 2513, 7197, 1306, 8317, 9636, 4567, 9342, 7424, 4570, 3851, 6704, 9412, 1062, 7082, 9180, 676, 1900, 2660, 3622, 3357, 890, 7222, 4109, 7764, 4143, 9675, 7566, 2243, 4767, 3271, 6100, 3923, 9962, 5715, 1931, 4368, 847, 5932, 9860, 5775, 8119, 4708, 1740, 1344, 2337, 6598, 64, 4163, 2679, 846, 2856, 9599, 6431, 6143, 691, 7140, 5360, 878, 9185, 2690, 5051, 3777, 251, 4491, 8997, 1599, 8304, 2450, 9702, 6603, 2125, 3797, 3378, 2725, 6488, 1325, 4500, 6914, 1272, 3011, 8251, 4939, 9149, 7558, 7283, 4038, 487, 4411, 8589, 2681, 7975, 6374, 5794, 687, 9292, 9283, 159, 7275, 7508, 424, 7837, 5549, 8729, 4943, 2992, 6532, 345, 1198, 5623, 5502, 2673, 5385, 6682, 3535, 6362, 5102, 2961, 9010, 7462, 6067, 6648, 4073, 9474, 7625, 2671, 6258, 5296, 6726, 3626, 284, 4464, 27, 1963, 1681, 268, 3406, 5488, 68, 3294, 4259, 5302, 1150, 6450, 1796, 7212, 150, 6031, 7626, 9905, 4533, 5993, 8576, 5855, 2146, 6277, 3738, 4899, 8432, 2669, 9538, 4451, 5527, 9575, 3106, 5953, 8867, 6737, 7537, 214, 210, 5882, 7803, 3739, 7772, 5538, 4621, 4707, 637, 7696, 4542, 883, 5981, 7884, 2374, 8266, 8645, 7037, 4730, 3947, 9133, 2738, 2786, 4235, 685, 2506, 9237, 9092, 2932, 3766, 3949, 6433, 8393, 4537, 6350, 5516, 2320, 5589, 9959, 1140, 8582, 7229, 6439, 2239, 8488, 8244, 5475, 265, 9864, 3056, 6230, 9578, 7979, 3919, 9771, 9480, 9000, 1494, 9168, 1991, 2824, 1526, 5349, 2207, 8519, 4289, 7724, 5731, 5472, 1383, 3082, 6269, 5455, 2730, 7580, 8389, 6135, 2100, 2658, 2805, 1866, 9913, 3085, 2412, 3352, 2668, 4722, 4893, 8228, 7421, 9148, 5614, 1367, 5993, 6002, 8338, 2080, 5088, 7084, 470, 4880, 8578, 1309, 4195, 9245, 3095, 9644, 3643, 9016, 8479, 2496, 6441, 5120, 7243, 5776, 5248, 4138, 5937, 369, 5969, 8970, 2770, 740, 8171, 6529, 9695, 9552, 9219, 4848, 8806, 6922, 5695, 5990, 6249, 1879, 5265, 5517, 4598, 8338, 576, 6563, 8831, 7283, 6616, 787, 5074, 7282, 398, 7587, 1122, 6763, 5026, 8882, 4896, 9442, 8377, 4562, 2786, 3529, 4810, 5733, 4004, 7086, 2583, 2360, 4358, 2241, 4106, 5223, 9393, 1343, 6829, 117, 4550, 6521, 6431, 6735, 3568, 3552, 4616, 4200, 3516, 448, 5124, 2203, 2562, 5946, 5034, 3410, 4001, 9181, 8740, 8863, 4695, 5636, 1499, 5518, 9386, 4366, 2471, 5361, 5454, 3184, 6706, 7445, 3705, 6113, 3896, 3972, 1930, 7469, 611, 2410, 5253, 1058, 1559, 7618, 3409, 1191, 8880, 7031, 5563, 3952, 4097, 4319, 2793, 984, 8093, 7252, 5217, 2317, 35, 3767, 2417, 2856, 2172, 1416, 5635, 2216, 6938, 4703, 7849, 2884, 7901, 9744, 1028, 1168, 900, 7576, 4478, 389, 5170, 3947, 1881, 2700, 534, 4997, 7792, 5662, 2, 9634, 2208, 928, 757, 1010, 9429, 5766, 5086, 3121, 3425, 3937, 6574, 1888, 37, 6976, 1189, 4817, 4124, 2411, 6728, 9095, 3691, 6033, 2669, 5368, 3, 5252, 7112, 3197, 2765, 1452, 2415, 3824, 6861, 529, 7899, 8727, 5894, 3989, 164, 2992, 919, 4219, 9763, 3676, 9476, 6356, 6006, 2212, 3725, 5465, 1148, 878, 5907, 8985, 7170, 5484, 5381, 4378, 7622, 8311, 4367, 3601, 4823, 1705, 2900, 8532, 2602, 2564, 6572, 9804, 9144, 7149, 1204, 3420, 909, 1267, 2345, 4358, 2550, 2858, 3398, 7469, 8909, 7838, 6378, 31, 9810, 1128, 9347, 1547, 4828, 1582, 3393, 8564, 1352, 6112, 5835, 2145, 9858, 7307, 7295, 1122, 4532, 3103, 4082, 5252, 6004, 3621, 7846, 7163, 8333, 4487, 822, 7896, 3883, 9470, 1861, 2920, 201, 1831, 9952, 9791, 1062, 4904, 2676, 7273, 4672, 6123, 5638, 5034, 9422, 493, 5938, 2894, 7266, 5879, 7091, 4043, 2262, 9341, 4737, 8091, 1118, 2743, 2101, 7930, 1343, 5125, 2820, 8654, 4561, 5035, 8165, 8500, 5623, 8071, 870, 8790, 5780, 5619, 8366, 182, 2698, 9205, 5743, 9816, 3658, 8408, 9831, 3920, 7765, 1831, 8662, 354, 9567, 676, 8247, 1203, 1125, 8587, 8926, 363, 9410, 9535, 9537, 3457, 2759, 1564, 7739, 1180, 7072, 5665, 2877, 4232, 6366, 1449, 5965, 5075, 4060, 3485, 429, 6598, 5940, 5809, 1012, 4556, 2276, 8948, 7202, 1626, 8418, 560, 6173, 6846, 1305, 4364, 7164, 113, 1606, 2263, 5519, 4204, 3921, 409, 6594, 3177, 5253, 9246, 4651, 6253, 4581, 8239, 2189, 3561, 9574, 7427, 5309, 9367, 9392, 1141, 4699, 9114, 7175, 3817, 785, 1806, 2581, 6038, 3102, 30, 7323, 2532, 3090, 993, 4789, 9785, 9564, 9146, 2288, 5834, 4128, 5370, 3545, 1458, 6134, 9862, 5430, 92, 1778, 4610, 5851, 4822, 4361, 4041, 3453, 3837, 1861, 5435, 8932, 4594, 9422, 9590, 6429, 1674, 8339, 2027, 6076, 5247, 417, 1454, 5018, 4491, 1192, 9713, 5182, 7340, 6689, 1660, 6810, 7501, 1912, 2124, 2696, 7578, 5386, 3907, 5207, 9400, 4744, 657, 3334, 6810, 7311, 7440, 1168, 6508, 7391, 555, 787, 3064, 8373, 1390, 6444, 1809, 6064, 2723, 8337, 677, 9601, 3996, 3375, 4199, 5895, 1892, 1442, 6418, 2852, 9427, 5489, 9765, 4343, 5079, 1154, 6430, 1049, 7236, 8188, 5310, 2315, 8510, 7354, 8134, 494, 1440, 5738, 6554, 9720, 879, 9524, 1808, 9688, 2167, 7611, 1937, 8658, 8691, 5955, 9153, 4109, 8717, 9884, 6449, 7069, 1586, 2713, 5061, 8085, 6240, 7456, 2982, 9741, 7815, 2056, 8194, 20, 5821, 3000, 9219, 7925, 7193, 9784, 4632, 8747, 304, 8717, 9756, 6102, 5991, 2771, 6826, 8297, 2384, 468, 2619, 9082, 1136, 2070, 3012, 1467, 3710, 3908, 6102, 4966, 2567, 4717, 2846, 8743, 1359, 6872, 762, 9496, 9149, 5504, 3102, 9412, 7774, 8938, 7531, 7325, 5348, 7348, 4223, 4146, 9932, 7189, 8283, 9253, 1207, 4640, 6614, 8899, 9061, 4637, 3629, 2068, 7824, 2023, 8486, 9557, 9532, 6834, 1410, 7824, 6932, 7260, 9096, 363, 6812, 8302, 9377, 4088, 3789, 4184, 6424, 6850, 7136, 9464, 3152, 291, 6732, 7989, 8234, 1818, 339, 6005, 2974, 5109, 5238, 1031, 2350, 2795, 4696, 9061, 7980, 1820, 6166, 852, 1605, 9008, 7455, 8516, 1062, 7545, 3694, 3914, 8665, 6290, 3666, 8207, 6060, 3336, 2309, 7317, 2523, 4279, 1560, 3792, 5283, 4029, 337, 7713, 4461, 9367, 1050, 439, 4416, 8573, 5993, 9948, 8563, 2597, 8597, 9757, 3114, 4014, 6561, 2957, 1715, 4591, 8055, 9201, 3992, 7544, 2076, 5033, 3795, 7753, 6730, 5639, 7571, 6932, 4724, 9240, 1017, 9547, 7461, 4291, 1286, 6870, 3349, 3039, 647, 9792, 7124, 419, 5317, 9425, 324, 597, 7320, 4602, 3389, 2190, 9602, 1962, 505, 4403, 6227, 6030, 8711, 3265, 719, 8968, 258, 3786, 7597, 6450, 2731, 9648, 5955, 8534, 3348, 1800, 3264, 3439, 9331, 3546, 6109, 3213, 3745, 3545, 934, 6105, 7451, 6936, 3843, 479, 6309, 6890, 1616, 8942, 6820, 3949, 1915, 4110, 8920, 4158, 9433, 1788, 9963, 1864, 4038, 8116, 4876, 4395, 1060, 2205, 1939, 5864, 8312, 3991, 2734, 3088, 5850, 5098, 5176, 4609, 5547, 7077, 9893, 5215, 3954, 7411, 8435, 5514, 9903, 1387, 3601, 9498, 839, 7408, 4694, 509, 7522, 9432, 5148, 6333, 2411, 3836, 9877, 569, 7622, 119, 1406, 2212, 6054, 1228, 9727, 7127, 9687, 6487, 6673, 7037, 4649, 1461, 5233, 1116, 8323, 1293, 3071, 7803, 6855, 7303, 5275, 5932, 3719, 8856, 1632, 6231, 7710, 7882, 2939, 810, 799, 7490, 9943, 7002, 7484, 7208, 4085, 3217, 2218, 2117, 3996, 5339, 4854, 1260, 1694, 3381, 2450, 8409, 1825, 8055, 3915, 1504, 7646, 5535, 9073, 5077, 5179, 9581, 1209, 421, 4357, 1242, 900, 9373, 7888, 335, 8893, 4141, 8938, 9370, 912, 5650, 2155, 8558, 1201, 8928, 186, 8514, 733, 1288, 8512, 4207, 2561, 1936, 9828, 380, 5269, 5695, 6846, 192, 8541, 2418, 2377, 3276, 3909, 3260, 2978, 9730, 2818, 1114, 4608, 5149, 1019, 5816, 7482, 5339, 2661, 9171, 8734, 5256, 3811, 5694, 3081, 8368, 8113, 6615, 6269, 372, 5303, 5235, 5906, 7492, 7210, 8390, 3440, 9660, 597, 1990, 9638, 1793, 848, 9061, 8454, 821, 2420, 9722, 1660, 2038, 9469, 2755, 3466, 4928, 8948, 2957, 9234, 7800, 3775, 4609, 8091, 9472, 1570, 1820, 6232, 2837, 1894, 7792, 7659, 64, 318, 3072, 3676, 728, 1290, 3887, 3518, 9982, 1752, 8322, 5456, 3048, 5691, 3599, 9870, 7706, 133, 350, 1665, 9028, 3944, 6519, 6718, 3042, 8463, 8246, 1084, 6361, 4183, 5124, 3579, 5875, 3282, 9882, 5271, 3200, 3775, 3981, 4176, 5780, 3558, 5169, 1856, 7311, 6360, 2785, 752, 2749, 5901, 3600, 6316, 2974, 4938, 2036, 9230, 1188, 1626, 5375, 4208, 4139, 5198, 5092, 248, 8378, 1304, 5996, 3807, 1396, 3180, 211, 2949, 4903, 428, 7683, 8070, 2387, 1871, 7751, 54, 1059, 3585, 4682, 915, 1211, 6503, 3092, 5004, 725, 3895, 7129, 3240, 9824, 7272, 3089, 8615, 939, 9601, 351, 2485, 457, 6892, 8303, 1300, 4169, 1335, 334, 8228, 786, 8275, 1801, 5990, 9832, 2562, 7765, 1192, 3898, 3238, 4237, 9095, 7603, 6071, 8941, 2268, 7740, 6255, 2066, 4232, 3891, 7597, 5450, 2572, 5673, 7186, 2092, 1277, 9853, 9813, 4421, 7540, 1022, 1937, 2850, 842, 9595, 8142, 5496, 1405, 8908, 594, 623, 1371, 9490, 5123, 6605, 2556, 534, 8633, 6634, 3134, 5058, 6000, 9575, 8735, 6097, 7360, 6657, 2646, 3365, 1428, 9840, 8708, 3429, 8637, 9959, 5626, 8947, 6664, 8053, 9243, 4792, 342, 8055, 4079, 7602, 8168, 9572, 8362, 437, 3535, 6009, 3934, 9893, 2704, 3187, 3373, 3465, 5893, 4500, 7163, 2736, 8261, 5280, 1785, 7851, 549, 942, 1248, 5811, 8098, 3099, 843, 2452, 1262, 6567, 7060, 7468, 7194, 391, 759, 3294, 168, 7560, 6370, 2611, 3557, 318, 7169, 9866, 3486, 6641, 6156, 4307, 5148, 7687, 3134, 3798, 571, 7248, 3346, 389, 3119, 239, 7090, 1969, 8986, 6075, 8942, 1853, 2772, 7967, 1564, 5914, 5625, 632, 9437, 6517, 4208, 5103, 1787, 2698, 2919, 2876, 7246, 5661, 2444, 2809, 1545, 7253, 1113, 5095, 8759, 5206, 5126, 376, 8812, 5652, 6802, 9158, 8323, 2967, 2170, 2346, 1437, 1001, 6391, 6918, 4080, 1307, 2794, 6521, 8148, 8692, 4962, 1402, 9829, 6143, 8614, 8874, 8343, 3947, 5405, 6441, 3594, 8098, 9068, 3256, 4060, 5711, 3982, 2074, 2811, 8186, 7387, 8096, 5597, 1158, 2038, 4378, 3901, 8015, 2081, 1296, 4905, 7279, 6136, 9809, 9658, 6573, 8959, 5312, 4835, 2920, 4952, 5344, 1277, 3617, 9092, 9184, 9672, 6144, 3669, 6419, 1650, 2814, 2313, 9987, 4377, 8687, 6710, 7528, 248, 8417, 9373, 2499, 7537, 7329, 3938, 8280, 4388, 6513, 4064, 763, 8282, 4200, 5507, 1788, 4275, 3828, 5541, 5995, 5007, 9892, 4939, 6507, 8986, 8815, 346, 3189, 7182, 997, 4388, 4038, 5972, 3205, 8969, 4657, 7020, 6232, 1538, 6547, 1740, 5241, 9813, 5291, 9669, 4714, 5794, 596, 6370, 7103, 5173, 1012, 7983, 2256, 7522, 5056, 9294, 3741, 2651, 7021, 6474, 5103, 3691, 774, 2030, 6566, 9299, 4624, 2923, 5040, 7821, 6196, 9197, 399, 4391, 8730, 9831, 862, 5832, 240, 9346, 2039, 720, 1469, 1219, 6522, 2722, 7957, 9614, 3448, 2585, 3542, 7204, 5818, 4146, 673, 3852, 7019, 8101, 9181, 634, 8869, 1816, 3986, 8108, 9954, 2341, 8627, 5400, 6578, 8382, 274, 3020, 1737, 7781, 468, 874, 9573, 2763, 3512, 9639, 2360, 5066, 7123, 6053, 3456, 963, 1571, 4642, 3021, 1553, 9281, 8867, 5229, 2325, 6941, 5309, 1791, 5082, 4094, 3669, 4202, 5964, 6275, 9758, 1326, 9958, 4289, 7512, 6555, 5728, 936, 6374, 178, 5939, 430, 3415, 1282, 8617, 459, 9408, 2902, 2949, 353, 6874, 5750, 6895, 9878, 6015, 9832, 5962, 74, 6642, 1392, 9308, 4347, 7107, 7989, 5815, 1576, 9030, 6606, 9147, 3496, 5678, 7195, 9356, 8395, 7088, 8352, 617, 5754, 6803, 549, 3716, 5635, 2081, 2657, 5869, 4419, 7468, 5803, 2396, 5706, 2748, 541, 6150, 1351, 6142, 796, 999, 4154, 3883, 6933, 8477, 8813, 5349, 3921, 1389, 1855, 297, 8413, 2024, 7834, 7494, 8995, 5908, 2235, 4063, 8565, 4550, 4827, 1533, 3497, 7867, 1852, 8861, 5745, 7127, 8256, 193, 5248, 4197, 8906, 3727, 2079, 8571, 2416, 9513, 8645, 6259, 5078, 1114, 4614, 6672, 2600, 2743, 1834, 2642, 7100, 4702, 7267, 3975, 4041, 7537, 1613, 5604, 3742, 3061, 2315, 9851, 2192, 8809, 7330, 8821, 6204, 4870, 7453, 5280, 3300, 1345, 162, 6813, 3529, 9312, 860, 9808, 9906, 7093, 9616, 2352, 6750, 6283, 7242, 6587, 5933, 9628, 1187, 6634, 4421, 4400, 2754, 5868, 2481, 6087, 3234, 9530, 6656, 5575, 4493, 4414, 9235, 6269, 2670, 7498, 6610, 1585, 7674, 8794, 4727, 5150, 2699, 7033, 5044, 4521, 9934, 2887, 9458, 4657, 2506, 6522, 9525, 5966, 147, 5083, 2298, 986, 5973, 6922, 454, 75, 2459, 5620, 4676, 8015, 5775, 7459, 4069, 9224, 4456, 2253, 2343, 8374, 8788, 6907, 9883, 2670, 238, 6043, 1937, 5892, 4995, 5431, 29, 1166, 7183, 8420, 1762, 479, 3126, 6717, 2161, 2315, 7061, 9073, 9449, 9253, 6357, 5513, 8088, 4998, 2809, 1520, 9059, 8923, 3241, 2638, 4734, 3389, 4237, 9632, 6265, 64, 9787, 757, 6843, 5416, 3967, 1382, 3212, 8106, 9691, 3204, 7126, 4955, 6931, 204, 9752, 4818, 8998, 6431, 8862, 652, 3606, 7732, 725, 6110, 2908, 2124, 4790, 5041, 3377, 1576, 3369, 8360, 4549, 5988, 4981, 7500, 810, 6870, 8860, 9580, 5123, 7976, 7707, 6566, 7104, 2520, 7107, 7717, 1470, 2913, 1791, 6750, 6802, 4200, 1725, 1790, 9988, 5405, 3489, 6190, 2803, 8561, 1881, 3539, 6074, 2738, 704, 4894, 2769, 5217, 5154, 7993, 4148, 1462, 4834, 8108, 9257, 5230, 3911, 4922, 6614, 5973, 8080, 4238, 5656, 5480, 6723, 760, 8577, 4840, 8850, 6898, 6264, 6654, 6720, 894, 3653, 746, 9395, 7943, 4012, 7902, 6142, 1526, 6565, 3314, 2565, 4199, 783, 6888, 7679, 138, 4721, 6696, 3894, 3170, 9026, 1224, 7301, 6247, 1069, 3957, 4913, 1301, 8080, 73, 534, 588, 1424, 1429, 7583, 2590, 9187, 5964, 8471, 307, 6594, 9117, 6860, 9438, 5303, 4180, 1752, 9793, 9489, 7446, 5605, 6974, 8888, 5424, 5941, 4815, 4816, 824, 7864, 1460, 986, 1560, 2747, 6483, 5435, 1150, 728, 6643, 1943, 2681, 8542, 3393, 6898, 7648, 1396, 3931, 6106, 4525, 3107, 1678, 5483, 7854, 1391, 7716, 2937, 831, 6402, 5441, 2730, 8542, 8926, 5014, 4046, 5395, 9299, 7002, 266, 2005, 9808, 4804, 7448, 7550, 8754, 5582, 1839, 5869, 6868, 4274, 1855, 9651, 6715, 3214, 5012, 8423, 3280, 2187, 4072, 8473, 1604, 6816, 5559, 1768, 5882, 6585, 6693, 2794, 7122, 6087, 2040, 6086, 4618, 8968, 2218, 1719, 2073, 9469, 8025, 1872, 5468, 9414, 5950, 1475, 8425, 6074, 6042, 4954, 7560, 4035, 9971, 669, 1356, 8684, 5699, 2588, 2312, 8771, 1041, 6595, 3145, 1499, 5193, 1744, 1211, 7988, 9180, 4200, 720, 2305, 7401, 6243, 9, 5154, 5691, 7222, 84, 6188, 6987, 7478, 3040, 939, 6342, 7914, 221, 419, 7811, 3702, 4961, 5954, 1803, 3765, 187, 957, 2092, 2896, 2837, 7267, 8415, 9387, 8820, 6957, 1246, 5146, 8333, 284, 6757, 1051, 7502, 439, 1577, 2770, 4517, 1921, 1626, 3750, 4352, 1739, 5872, 4775, 822, 6923, 3670, 5791, 9061, 5328, 5986, 1974, 1377, 866, 365, 541, 2785, 4382, 8221, 1339, 5203, 2955, 3014, 9394, 9878, 1583, 8308, 7602, 5374, 2563, 5312, 32, 586, 1231, 1183, 7496, 7949, 6131, 5454, 3513, 1198, 4609, 2179, 4036, 8169, 2554, 1304, 1126, 987, 4354, 5057, 8592, 760, 4387, 4542, 1156, 5968, 2722, 534, 6530, 9023, 6770, 9160, 7631, 2703, 5088, 1924, 6297, 8908, 7479, 3529, 1977, 439, 936, 5024, 9374, 358, 5602, 5567, 1987, 261, 2705, 9626, 1652, 9130, 899, 6165, 2646, 141, 2541, 2100, 5829, 4428, 7754, 7079, 119, 3266, 8927, 5282, 3243, 5860, 288, 7755, 484, 5024, 1827, 5740, 748, 9358, 4135, 9715, 2755, 6002, 2664, 8158, 1817, 9497, 1794, 4583, 7819, 8329, 2341, 4077, 5074, 5284, 9826, 4761, 5665, 8856, 6922, 496, 525, 2498, 8579, 791, 9079, 4412, 5047, 2318, 2243, 7894, 2579, 6050, 1794, 5099, 6641, 3104, 9927, 1648, 9444, 523, 9631, 6706, 6535, 8917, 8621, 7793, 9666, 4911, 7462, 9358, 1778, 5501, 5355, 7073, 6388, 7743, 8774, 9365, 7304, 2481, 37, 131, 8980, 2994, 3134, 4728, 5065, 450, 2159, 467, 6021, 1662, 4679, 8017, 6501, 6034, 8355, 9908, 9127, 451, 5572, 9779, 8942, 8299, 3599, 1606, 6158, 7058, 1963, 5022, 5483, 4970, 585, 4444, 6046, 8384, 5297, 6502, 8667, 174, 2132, 2263, 1575, 9293, 4771, 2692, 38, 8859, 6511, 3875, 6202, 4255, 6917, 6136, 2057, 7161, 1571, 2121, 7848, 9283, 1866, 2027, 624, 4910, 8019, 7680, 6504, 7757, 8100, 7401, 2872, 2415, 4902, 7127, 8408, 5832, 2683, 4143, 2982, 2167, 4524, 1889, 500, 1657, 5915, 3405, 4793, 1591, 1011, 2104, 6006, 6327, 9991, 5961, 3499, 6768, 2749, 441, 7646, 8627, 297, 8432, 3286, 1500, 4218, 8774, 4880, 580, 5598, 1458, 3247, 864, 1448, 8361, 1899, 554, 8337, 3431, 9145, 7624, 1204, 1713, 2189, 1432, 5545, 5528, 1029, 9215, 1370, 4080, 2729, 387, 2059, 6954, 6500, 9669, 3721, 3698, 6854, 3267, 8291, 9146, 2517, 7535, 2684, 499, 2978, 2671, 2481, 8586, 2592, 3148, 8217, 6474, 2163, 7427, 4938, 1357, 7949, 5214, 6576, 8637, 5893, 7865, 3234, 8176, 9898, 2973, 8732, 6917, 7862, 6905, 6631, 1996, 4250, 5212, 2171, 1327, 9222, 9430, 951, 5524, 3319, 6724, 3288, 5264, 9817, 9713, 50, 4426, 2178, 8306, 2342, 3847, 9276, 2868, 4002, 9654, 5760, 2671, 9742, 4587, 3620, 6224, 8569, 3877, 6480, 6908, 2056, 1494, 1638, 3813, 2515, 6661, 7231, 1340, 2500, 935, 5071, 4743, 7247, 325, 7294, 3921, 7413, 9699, 3259, 3557, 739, 1920, 4932, 1337, 7400, 1192, 6122, 118, 1419, 2529, 2092, 9816, 6004, 8819, 9950, 7406, 7854, 3817, 5181, 5576, 4645, 4401, 5493, 896, 521, 5889, 557, 4479, 7009, 2749, 6598, 9814, 1145, 3013, 9803, 5234, 7810, 6513, 4058, 9235, 4111, 9892, 1382, 6215, 4874, 1530, 1252, 7099, 7761, 5472, 550, 8107, 7283, 5081, 8642, 4761, 5256, 3130, 544, 1455, 8179, 1074, 1321, 2612, 2733, 5866, 9297, 9167, 1730, 4027, 768, 510, 222, 3406, 6068, 8791, 9579, 2218, 9964, 239, 5513, 1285, 8156, 8947, 1280, 3413, 261, 2666, 6420, 4988, 8151, 5480, 7237, 515, 7829, 2859, 8985, 1517, 1679, 7780, 1928, 8607, 3815, 7383, 1230, 6843, 888, 8351, 4367, 7217, 5124, 138, 6641, 9960, 2866, 7149, 7233, 7300, 9544, 2852, 3989, 9263, 3234, 955, 1525, 7125, 3740, 1146, 3807, 1736, 9683, 1647, 5986, 5586, 4708, 5874, 8982, 8158, 513, 5782, 6414, 2932, 6509, 1694, 2535, 2815, 7154, 2332, 3381, 7721, 1568, 4142, 7303, 9456, 9103, 8558, 1934, 9881, 8053, 2817, 1611, 2624, 4337, 2774, 5929, 3388, 1523, 8347, 5987, 4760, 6112, 5896, 8036, 4127, 9848, 6696, 5202, 3583, 7507, 7041, 6683, 5851, 2709, 6256, 5821, 7622, 9021, 2072, 4275, 552, 1803, 9345, 874, 3792, 8829, 301, 7832, 1022, 41, 2294, 1053, 1138, 4101, 1680, 7895, 8666, 3941, 90, 9344, 4927, 364, 3608, 2634, 3397, 4730, 654, 9798, 9805, 2708, 4863, 7544, 2175, 9440, 9426, 9672, 6649, 1431, 3616, 4912, 4136, 5761, 2648, 7923, 5782, 2439, 5350, 44, 7073, 3936, 1792, 5318, 7031, 9119, 6748, 6729, 1707, 9399, 4205, 6512, 9715, 8349, 5668, 4104, 8953, 931, 4070, 6847, 4825, 3751, 2964, 8462, 837, 8722, 1167, 9383, 908, 8843, 5382, 9412, 7543, 4315, 8066, 5765, 6115, 1701, 7600, 1492, 3083, 4854, 328, 7236, 8309, 3629, 5798, 3188, 9965, 963, 1839, 5306, 8606, 3470, 6742, 1781, 1528, 2405, 6833, 267, 4594, 8940, 7943, 8775, 2774, 9802, 7261, 4684, 8764, 7275, 6404, 286, 6363, 5624, 9653, 1041, 7769, 6820, 4890, 5138, 7367, 6648, 1817, 740, 823, 495, 1858, 8541, 1172, 3130, 8224, 3190, 3917, 7470, 402, 1861, 2538, 3466, 5822, 6643, 6557, 1951, 2703, 550, 6981, 868, 1148, 8886, 3068, 2866, 723, 6908, 3849, 5933, 1309, 7759, 614, 1337, 831, 6269, 9956, 8456, 7875, 4984, 4910, 131, 7319, 463, 4252, 9743, 1441, 4106, 5265, 4705, 1860, 5160, 3742, 9174, 6136, 3150, 1156, 6931, 8740, 9826, 660, 715, 6437, 5569, 4220, 8776, 463, 35, 9551, 1534, 5474, 1506, 521, 9846, 6705, 2413, 4366, 2187, 8765, 7466, 4514, 4670, 2989, 1585, 8907, 3323, 3932, 181, 3580, 9292, 4154, 9613, 1448, 933, 662, 9679, 1828, 5317, 9156, 1000, 6220, 1490, 6823, 3869, 1657, 8343, 3789, 2211, 917, 5804, 8320, 2717, 5467, 4427, 606, 8432, 9498, 3695, 3737, 1361, 5334, 8900, 6783, 6337, 7796, 1814, 1278, 1413, 2361, 9522, 5269, 207, 4512, 8325, 7472, 8365, 6742, 8694, 3779, 2358, 3518, 667, 6867, 1181, 3034, 5626, 4990, 5654, 9641, 6516, 7842, 1073, 9425, 1579, 9773, 7867, 8242, 2381, 876, 3111, 5385, 3754, 1697, 975, 6682, 1972, 9734, 2691, 569, 4667, 125, 1959, 1930, 6409, 8974, 3323, 3667, 4911, 4785, 8677, 2550, 543, 7781, 4164, 4882, 9832, 463, 22, 1763, 8216, 5292, 5728, 5363, 5563, 8621, 9702, 4264, 6763, 3249, 7633, 826, 5282, 1152, 8653, 2796, 3531, 2460, 237, 5632, 6080, 6154, 896, 3515, 3734, 7808, 5804, 2256, 9524, 3219, 8341, 7032, 3727, 4074, 6768, 428, 7272, 5611, 4137, 9591, 2874, 9664, 7132, 3272, 4719, 773, 4951, 7162, 2301, 4094, 6570, 330, 5836, 4003, 7043, 8392, 9938, 5253, 5853, 3633, 1677, 5372, 6795, 3395, 7268, 8651, 8142, 807, 9264, 2269, 1493, 945, 1113, 9274, 125, 7722, 4897, 7486, 1646, 1951, 3199, 6531, 2098, 531, 7980, 4091, 7676, 5210, 2230, 1692, 5022, 439, 8684, 8981, 185, 654, 9392, 6394, 797, 3720, 1498, 4643, 5867, 1725, 4832, 2759, 8463, 8671, 3695, 8607, 216, 5016, 5321, 5987, 7406, 4177, 2024, 5282, 4839, 887, 336, 1782, 7484, 2384, 1630, 5102, 1389, 9436, 2760, 8679, 6979, 3251, 2352, 48, 2859, 7418, 1266, 2997, 3406, 3062, 1711, 3667, 4156, 5210, 3386, 6403, 3131, 2360, 3114, 8772, 4230, 7502, 2843, 2485, 7135, 2473, 5554, 3852, 6686, 3898, 8891, 5919, 430, 4269, 8273, 4075, 9065, 9635, 4651, 2188, 1298, 1391, 606, 9211, 827, 5343, 4244, 3420, 9202, 3465, 437, 5186, 2230, 7654, 5184, 6394, 8928, 9783, 299, 2363, 8566, 5166, 6660, 7388, 5130, 6146, 24, 994, 9092, 3171, 9816, 6518, 8357, 6637, 119, 3891, 471, 931, 328, 8339, 898, 6177, 3405, 1368, 9396, 9954, 3434, 8652, 4041, 4116, 4943, 2259, 9541, 3704, 4447, 925, 247, 6023, 5725, 3621, 582, 2023, 1852, 7863, 2533, 4997, 653, 7376, 8605, 6851, 7198, 4080, 2925, 5479, 9214, 1328, 3472, 9283, 1288, 1150, 4793, 87, 4551, 3001, 8805, 233, 1690, 6494, 8467, 3886, 6483, 5852, 7139, 6131, 5263, 8695, 6757, 3488, 5752, 4202, 7838, 8273, 4423, 2812, 8120, 3663, 5905, 8156, 8507, 4998, 493, 5340, 9393, 7884, 8437, 6984, 8160, 6828, 732, 9399, 5545, 4074, 4378, 4746, 4127, 7936, 4123, 8745, 5035, 9127, 3007, 1223, 9100, 2255, 7905, 6784, 5184, 8796, 9660, 2305, 7089, 2369, 5364, 3503, 1236, 8400, 2540, 2369, 5728, 3397, 8227, 9471, 8161, 5196, 8332, 4520, 4931, 288, 7406, 6226, 5034, 4072, 631, 7485, 9172, 3059, 256, 9932, 3025, 7637, 6455, 9580, 2345, 9912, 3854, 4987, 1178, 2820, 5785, 9608, 4871, 6669, 7125, 5278, 7675, 9999, 2406, 1427, 5383, 6028, 6834, 4107, 7376, 2328, 1062, 1990, 3049, 3081, 4460, 6618, 668, 3294, 9309, 7293, 4258, 1106, 8051, 5821, 523, 9317, 8683, 3965, 2869, 8885, 2654, 6695, 139, 9564, 7150, 5593, 7382, 5343, 7005, 2191, 377, 7743, 3413, 8034, 5223, 9648, 4544, 6866, 5227, 6840, 5450, 5024, 5530, 5065, 5407, 4226, 5333, 2108, 6386, 3500, 3626, 9134, 2286, 5525, 7849, 9449, 1046, 6863, 463, 5564, 8910, 861, 7623, 2644, 8727, 3678, 9761, 3104, 7888, 922, 8748, 8771, 9674, 5976, 6455, 497, 97, 8837, 5135, 8135, 7107, 2010, 7032, 7999, 5087, 7843, 3660, 714, 394, 5347, 8130, 6381, 7656, 5296, 7230, 8077, 8825, 5447, 1609, 9897, 2100, 3113, 9586, 8397, 7672, 7384, 9113, 8259, 6551, 4442, 7048, 3045, 6088, 71, 9556, 6346, 6244, 1919, 7462, 6006, 8846, 284, 2305, 5736, 8920, 8185, 3252, 6708, 9310, 5416, 7031, 1139, 7084, 8841, 3214, 7723, 8066, 6504, 5790, 1101, 1142, 2139, 7881, 4215, 6867, 7418, 7333, 3707, 1943, 3005, 4722, 8347, 9168, 2695, 7162, 9525, 1775, 5582, 5907, 1469, 8185, 3755, 5730, 2294, 9255, 8295, 2467, 3269, 509, 7884, 7296, 4989, 4031, 3556, 3170, 7317, 7677, 5757, 9917, 9188, 4871, 1896, 8008, 9146, 5001, 7345, 9383, 9459, 9360, 1259, 4167, 7163, 9313, 3035, 8287, 858, 1304, 2529, 61, 5929, 1487, 6559, 4002, 2307, 5836, 3536, 5158, 7630, 8024, 5556, 3095, 4731, 8696, 3122, 1411, 8769, 6275, 9665, 5428, 5244, 7832, 6043, 9260, 7018, 4861, 3778, 3594, 7245, 1256, 4612, 5761, 888, 1996, 8310, 2345, 6192, 98, 8124, 7610, 2642, 6873, 1857, 6849, 4640, 3954, 4652, 5658, 9490, 6550, 2296, 7096, 846, 8534, 155, 507, 3025, 6784, 763, 1074, 2451, 8896, 2962, 3219, 7648, 1423, 9012, 6563, 7743, 1443, 7704, 4862, 6828, 6323, 1829, 9101, 4420, 2035, 6950, 2598, 2898, 3002, 3519, 6062, 3466, 1098, 4707, 6008, 9466, 4264, 1228, 6280, 9229, 8412, 32, 3427, 1024, 4826, 4416, 7483, 3206, 9191, 1476, 724, 2210, 9818, 9656, 1172, 2425, 5449, 4457, 417, 7114, 911, 6492, 7579, 3418, 6718, 8868, 3103, 8766, 9293, 412, 4445, 2202, 8609, 3497, 5387, 9630, 9020, 469, 7679, 3578, 5451, 7625, 8353, 654, 8206, 4438, 4800, 4658, 9110, 3254, 1542, 9357, 8093, 7623, 8306, 345, 6638, 6729, 1190, 1241, 6858, 6649, 4058, 9354, 5477, 2810, 134, 2731, 2504, 8352, 9839, 5853, 5226, 2261, 2095, 2988, 4282, 3102, 9622, 3014, 1371, 4127, 6842, 6547, 4409, 8408, 8441, 6549, 5241, 2247, 253, 6823, 9801, 8081, 5456, 2921, 6802, 2000, 8506, 3716, 9086, 4824, 1089, 1664, 4663, 6655, 8626, 1433, 3004, 5826, 5923, 9335, 517, 9878, 8589, 9258, 5550, 2662, 5784, 5490, 1884, 2536, 2397, 4670, 7116, 3172, 2970, 5137, 9318, 4272, 1923, 2011, 1341, 8976, 1560, 3051, 2900, 3695, 8289, 1591, 4922, 895, 3415, 9551, 7154, 9441, 4477, 5445, 6400, 6373, 617, 5465, 944, 117, 8603, 7439, 6802, 520, 9677, 3982, 6729, 1284, 3521, 3829, 489, 5587, 5571, 2223, 2114, 8275, 5774, 5727, 1975, 1428, 4634, 9304, 2561, 3343, 9721, 5584, 2154, 3827, 3998, 5056, 4020, 2448, 3200, 9504, 8142, 7654, 1163, 2411, 4764, 5422, 8940, 3237, 2049, 763, 7416, 5694, 1315, 6682, 4281, 1088, 844, 7473, 4618, 9500, 1774, 5795, 5213, 4484, 4398, 3722, 9393, 4284, 7566, 1915, 4747, 9479, 9769, 3797, 3443, 4416, 1379, 3443, 641, 6482, 3583, 8228, 4795, 1123, 5865, 7898, 1437, 6751, 7655, 2175, 3135, 379, 9382, 6758, 6760, 4186, 6255, 1134, 8821, 5354, 8537, 3097, 1621, 554, 5413, 8390, 9041, 5538, 6326, 392, 1770, 2615, 519, 3261, 3932, 2021, 745, 9209, 4815, 6423, 1774, 5329, 2562, 4751, 5212, 7837, 8002, 6085, 6892, 358, 4973, 3420, 9453, 648, 1155, 8032, 989, 1633, 2661, 1233, 9572, 2263, 9775, 5537, 4571, 7263, 3604, 30, 9399, 1361, 6466, 8163, 2138, 5771, 1128, 3337, 4064, 6476, 7197, 7781, 4030, 3073, 3652, 8671, 663, 9069, 3224, 9351, 4962, 836, 7288, 7133, 5327, 7348, 7989, 5203, 515, 1548, 9322, 520, 5444, 1990, 9490, 4640, 9521, 621, 9417, 3770, 8722, 815, 3860, 3376, 7606, 2519, 9790, 9757, 3381, 7127, 9680, 2556, 5049, 6572, 8124, 1166, 8546, 5106, 500, 8238, 4037, 3000, 742, 822, 4711, 4179, 7456, 8457, 5509, 7250, 3528, 8944, 4110, 9538, 8529, 8604, 2725, 6905, 7369, 891, 7953, 6434, 8691, 1654, 9124, 7854, 9024, 3923, 9016, 2216, 5956, 3389, 5872, 4847, 362, 2074, 298, 1699, 1751, 9926, 7828, 2208, 4826, 8793, 6701, 1898, 6880, 6439, 1245, 1913, 3049, 1317, 7871, 8046, 2396, 6655, 3546, 7335, 1530, 5430, 969, 8797, 2115, 1945, 8072, 5809, 5187, 5309, 9185, 1431, 6004, 6934, 9012, 2072, 449, 6444, 9208, 6599, 494, 4138, 6806, 5005, 7542, 7080, 1034, 8440, 9637, 4038, 3492, 6960, 4963, 4648, 3745, 4100, 5702, 7884, 6214, 3629, 6378, 6831, 308, 4092, 5427, 7829, 8835, 7454, 1017, 2379, 8531, 3370, 7591, 8062, 1790, 2317, 2434, 6577, 4549, 2535, 483, 8059, 3519, 7662, 7248, 8215, 3813, 4011, 9514, 5976, 3201, 1133, 5106, 1438, 5172, 7384, 8985, 4216, 9074, 4271, 1483, 6460, 9410, 56, 2582, 6089, 1952, 4915, 7402, 4164, 4995, 419, 7878, 5080, 8808, 9432, 1734, 7998, 2852, 9797, 7120, 8314, 3497, 9375, 979, 4638, 539, 8227, 8763, 478, 9968, 2413, 8369, 7322, 1572, 176, 735, 4356, 6560, 5239, 5755, 7468, 8086, 1075, 216, 6743, 789, 9262, 7262, 4743, 3958, 6730, 4638, 6849, 3367, 8943, 6000, 9207, 1039, 5500, 4678, 6546, 6214, 2652, 6513, 9732, 1990, 3942, 9313, 9220, 7732, 670, 2851, 6544, 8103, 2703, 399, 3542, 8992, 5115, 5130, 1236, 4655, 1815, 3565, 5043, 2577, 728, 1905, 1025, 937, 4622, 7010, 6501, 3916, 1143, 2414, 8211, 9155, 4783, 6348, 2277, 4241, 9180, 9032, 9792, 1131, 1493, 9056, 7410, 8789, 1793, 3235, 2581, 941, 4573, 9581, 8227, 8596, 6031, 8469, 3101, 8201, 691, 8626, 8944, 4783, 9079, 3586, 8190, 1013, 6723, 6308, 4179, 4824, 3616, 4390, 5022, 1916, 1172, 3951, 5761, 7834, 575, 1259, 3146, 7842, 6362, 6139, 5466, 5300, 2613, 523, 4433, 9679, 2877, 76, 4132, 1730, 5860, 2885, 217, 7290, 8259, 7424, 1805, 5642, 2088, 4001, 3080, 2030, 2140, 2532, 7206, 5760, 8315, 545, 3090, 4505, 2041, 9708, 7657, 628, 2352, 9849, 6307, 7553, 9441, 4130, 8073, 2089, 5832, 1486, 9488, 209, 1878, 5909, 5936, 2695, 365, 182, 9197, 6615, 1320, 7613, 2766, 8488, 2619, 9009, 2258, 4347, 4109, 4242, 6397, 1127, 9540, 1087, 1788, 1743, 9712, 6470, 1738, 9490, 420, 1980, 5037, 8117, 2270, 4233, 3574, 9702, 6434, 6977, 3707, 4975, 4605, 1503, 5846, 8691, 9066, 2317, 8141, 1910, 6121, 9676, 7716, 7183, 3848, 5679, 7338, 8514, 6677, 974, 5222, 8347, 3719, 549, 9344, 6441, 1231, 302, 9659, 9716, 3734, 8272, 9654, 4837, 5337, 8166, 6239, 67, 388, 604, 2298, 8255, 9217, 1131, 3655, 9694, 3939, 597, 4406, 2858, 5191, 954, 5754, 4166, 8500, 7350, 1419, 7238, 243, 2539, 6459, 4591, 6272, 1294, 4949, 5979, 4244, 7193, 5304, 8124, 1006, 5176, 7735, 8315, 1604, 2256, 3841, 9366, 9573, 3295, 2173, 599, 5061, 4982, 4285, 1062, 697, 2184, 1517, 1242, 1753, 146, 2981, 907, 4750, 3329, 4580, 1636, 9991, 7216, 9657, 4700, 166, 752, 7757, 8337, 6558, 8450, 8213, 1694, 3844, 1616, 874, 4337, 7342, 1135, 6091, 2649, 6808, 3392, 4719, 5277, 9983, 7392, 2710, 9498, 7957, 6532, 3884, 8394, 9382, 9564, 6234, 3307, 6016, 3817, 5407, 8863, 7023, 2003, 7159, 2923, 7206, 4140, 3603, 61, 689, 8253, 2495, 3160, 5863, 9165, 3272, 9727, 2317, 4152, 9778, 5447, 9907, 3268, 6026, 7631, 1681, 2186, 6766, 6166, 610, 382, 4476, 1068, 7754, 6143, 190, 2111, 3906, 80, 3522, 7858, 3320, 2052, 3621, 3457, 4532, 9466, 4584, 2616, 1525, 1353, 4871, 4230, 8018, 6525, 7736, 95, 7554, 257, 69, 5622, 2015, 6878, 4190, 3784, 1090, 1197, 2939, 8659, 7002, 9534, 6382, 6433, 474, 8543, 413, 5453, 1426, 4221, 1261, 2266, 2960, 5304, 4699, 5854, 4443, 6792, 9929, 8885, 1272, 7794, 1041, 8071, 3489, 1255, 3427, 22, 8887, 2036, 5716, 3971, 3701, 3124, 3960, 6841, 2785, 781, 8690, 7478, 4646, 5288, 2216, 9556, 6597, 415, 1973, 5616, 5323, 4019, 655, 3518, 7892, 9076, 3912, 556, 470, 31, 9835, 1167, 1990, 9927, 2786, 2080, 7271, 9899, 9227, 3657, 18, 7951, 8846, 1439, 8359, 4416, 4309, 8530, 4705, 1481, 1750, 6342, 6421, 7350, 1851, 4897, 9468, 2163, 5077, 8843, 7768, 1257, 4444, 5310, 9234, 7357, 3211, 4122, 7615, 9541, 9597, 5603, 4814, 6564, 9262, 9889, 2386, 5323, 8501, 2260, 3292, 277, 8846, 2487, 5781, 441, 648, 8368, 4864, 6577, 6661, 3364, 5918, 6678, 6180, 819, 5262, 222, 3168, 9363, 6877, 2384, 4305, 7046, 5763, 9123, 3280, 7738, 202, 9278, 3998, 9872, 1288, 1991, 978, 2841, 9981, 5540, 3594, 8159, 620, 5069, 856, 2686, 888, 1388, 4155, 5986, 5930, 7854, 6196, 6997, 5274, 2927, 3810, 9766, 292, 7244, 1229, 9368, 2538, 7378, 9089, 2917, 228, 9688, 3706, 8731, 8016, 1994, 7293, 5152, 1816, 1678, 611, 1101, 6397, 3123, 7133, 2018, 5162, 1440, 8547, 9354, 353, 8575, 9661, 4474, 4103, 2085, 9217, 9936, 4745, 3328, 7577, 3541, 9106, 3087, 6115, 4172, 1794, 9865, 8535, 7902, 8186, 130, 799, 654, 742, 7506, 8059, 9494, 5779, 7772, 5680, 9085, 7141, 1367, 4551, 3780, 6906, 1242, 6347, 4788, 3836, 3411, 6904, 459, 1750, 5758, 4977, 2766, 1261, 9823, 4841, 2016, 841, 6922, 7902, 1026, 4533, 3143, 7801, 429, 510, 9086, 7682, 9165, 7076, 9453, 7758, 1864, 8011, 9973, 7153, 1666, 8505, 4642, 2596, 9676, 4395, 7767, 981, 4932, 4195, 3630, 21, 236, 6380, 3130, 5235, 3556, 3461, 183, 3532, 1834, 6385, 3000, 1797, 5193, 1746, 7206, 2500, 7486, 4320, 5333, 4835, 7090, 7335, 9698, 7754, 4587, 2792, 6604, 2115, 663, 1009, 5394, 3260, 396, 5593, 5909, 2512, 4816, 3054, 2299, 6731, 2262, 1751, 1176, 8888, 5074, 383, 8514, 7737, 3498, 5476, 2072, 5724, 9992, 8435, 450, 783, 6257, 5567, 6373, 7719, 9607, 5066, 4109, 9395, 3613, 7365, 5649, 1193, 1827, 145, 8394, 8831, 3773, 223, 9081, 659, 205, 2049, 7080, 7761, 1844, 9165, 3791, 6737, 2309, 5047, 8773, 6230, 7028, 6865, 74, 1310, 3668, 5153, 6230, 5685, 3179, 6752, 211, 6178, 6128, 7444, 5649, 3551, 7499, 7022, 8003, 7002, 9905, 3441, 1182, 9389, 6924, 1805, 2935, 5326, 966, 1766, 4330, 1372, 7207, 8667, 8192, 7454, 7248, 2879, 5267, 3635, 3563, 8154, 9440, 164, 2789, 1949, 9653, 7345, 8589, 7631, 4101, 7912, 7849, 5128, 6392, 3436, 269, 7907, 430, 5155, 1471, 331, 155, 8211, 6353, 6348, 9553, 8887, 5285, 2739, 325, 8634, 3603, 2212, 4501, 2296, 8483, 7901, 214, 9723, 906, 9278, 2752, 5548, 6422, 594, 25, 5808, 6779, 9076, 565, 5453, 3294, 1681, 1089, 7981, 1095, 7070, 9814, 1533, 4445, 3178, 6280, 3757, 8092, 5472, 5066, 1535, 1141, 3597, 7093, 349, 7372, 2407, 3611, 1884, 9722, 9336, 7408, 8594, 3433, 7861, 5381, 6960, 6624, 5059, 2491, 680, 5519, 3134, 7883, 5682, 6713, 6044, 4318, 8845, 5733, 8200, 3931, 4228, 1705, 2223, 9125, 7381, 9531, 1092, 5163, 292, 1728, 720, 7728, 8047, 5809, 9879, 2841, 3257, 4453, 8533, 9533, 6900, 3614, 4457, 5806, 9907, 6343, 9314, 8462, 132, 6155, 3687, 5508, 8865, 5738, 8025, 3755, 5277, 9438, 5183, 5477, 9883, 6650, 3173, 1811, 487, 9875, 7323, 8375, 7235, 939, 1457, 4651, 6373, 9256, 6580, 6449, 3046, 2718, 3262, 1370, 9034, 9675, 8144, 1950, 7795, 2549, 5728, 1554, 7736, 4815, 9563, 7703, 5155, 9218, 1599, 2516, 1561, 6759, 9804, 6342, 6591, 8141, 4246, 5140, 2231, 3451, 2724, 5438, 2882, 1360, 2459, 2998, 7040, 8405, 3680, 7649, 6107, 6390, 9520, 9667, 1958, 3684, 7536, 6661, 5190, 6957, 2896, 1971, 5905, 6727, 947, 5835, 8772, 418, 7241, 8053, 7467, 1986, 5724, 5731, 9841, 7107, 9518, 7608, 9239, 599, 9597, 4209, 6838, 3926, 7150, 5638, 1102, 6545, 1332, 4344, 4418, 7096, 7067, 1826, 9248, 29, 960, 8794, 6128, 6538, 5708, 3216, 736, 2945, 4158, 9995, 7417, 9126, 9827, 9938, 5808, 623, 5412, 440, 2065, 9330, 9747, 8036, 5853, 1955, 9692, 1281, 5774, 595, 5983, 3953, 8486, 8281, 7227, 6722, 7939, 3271, 412, 2872, 1442, 1521, 3156, 9560, 5889, 6612, 2665, 6538, 2615, 8686, 8086, 6709, 8734, 6513, 5013, 1442, 8563, 5828, 525, 5366, 171, 7445, 6798, 643, 6544, 208, 7352, 953, 3015, 96, 6517, 5168, 6842, 2875, 8650, 4184, 4147, 5720, 8766, 1782, 2598, 8550, 9470, 2169, 7350, 2679, 7587, 3395, 9869, 1095, 2268, 3858, 1345, 2905, 3449, 9765, 2139, 7284, 6884, 9765, 6203, 2963, 3822, 6611, 8016, 2406, 1221, 964, 457, 695, 4755, 87, 2213, 1060, 5343, 4836, 9578, 470, 990, 9163, 6080, 254, 9555, 6024, 6575, 3130, 960, 8045, 8073, 6696, 9107, 692, 4346, 4603, 6810, 3939, 6540, 1623, 6586, 5072, 9059, 3231, 6286, 1951, 7874, 3600, 687, 707, 6948, 2790, 541, 8671, 3452, 941, 3719, 525, 6850, 4004, 6865, 461, 325, 2146, 6978, 7759, 2693, 7463, 5028, 4611, 9640, 1413, 4400, 3048, 9883, 8722, 6046, 1397, 3495, 806, 1231, 2162, 6370, 224, 989, 5166, 6275, 6212, 9025, 1774, 7444, 357, 4519, 6553, 9447, 728, 2561, 9206, 622, 923, 6638, 3208, 7758, 9664, 9619, 3610, 9010, 4134, 3670, 9490, 5719, 3315, 6490, 1397, 1564, 3679, 4942, 2940, 564, 5843, 5263, 1518, 6784, 1076, 3391, 3319, 9154, 3637, 684, 6532, 47, 271, 6304, 221, 5344, 8758, 6306, 4006, 3180, 5505, 5016, 1322, 6653, 4584, 8425, 8776, 2583, 6259, 4813, 2829, 2565, 3984, 5319, 6595, 2872, 5480, 7076, 2667, 8364, 231, 1775, 2213, 5315, 4048, 3206, 3438, 1743, 8614, 3209, 1342, 9047, 6047, 4743, 4440, 4412, 1703, 818, 9489, 9358, 3257, 16, 4885, 8643, 8271, 4149, 7072, 2191, 1010, 4954, 2438, 5522, 4329, 5610, 1103, 2733, 4525, 4620, 1023, 400, 9328, 8391, 4900, 270, 3358, 2059, 1957, 9712, 7674, 327, 3250, 8553, 124, 9553, 7569, 6339, 6778, 7470, 701, 7316, 5576, 692, 2362, 4127, 1175, 5666, 5774, 1770, 4197, 2377, 9286, 5360, 1562, 6444, 761, 6742, 5259, 3053, 594, 4583, 4760, 4669, 7079, 3735, 5360, 2959, 4053, 1102, 2816, 3519, 5326, 4261, 8941, 8995, 3053, 5305, 6447, 9965, 8907, 6703, 446, 8885, 8255, 6599, 6165, 6849, 9342, 8908, 3109, 7350, 1152, 6926, 403, 3857, 4477, 3220, 7106, 6886, 2114, 9564, 896, 886, 8035, 7963, 4503, 1585, 8747, 6933, 7175, 5002, 5034, 8936, 7967, 1079, 6968, 381, 562, 1796, 1242, 1084, 1207, 5448, 6468, 9298, 6225, 2922, 6155, 9258, 7220, 9031, 3945, 1758, 2927, 75, 7415, 3208, 8087, 3047, 3690, 489, 7511, 9501, 4246, 2573, 9971, 4209, 2132, 2060, 5617, 5393, 7045, 3507, 228, 3710, 5272, 8000, 3158, 5704, 1848, 7770, 5435, 7898, 4520, 4755, 1939, 7559, 760, 336, 6601, 2680, 1037, 8050, 2913, 9919, 7697, 4626, 3105, 3545, 3958, 7228, 5232, 3700, 7862, 4503, 5844, 5259, 5039, 6796, 540, 7762, 2822, 7017, 2265, 9540, 9896, 2527, 6203, 4720, 9279, 69, 3511, 3872, 530, 5138, 1503, 265, 3473, 3151, 9483, 5292, 7786, 9935, 7097, 5935, 6692, 3382, 3197, 847, 6028, 1948, 1448, 7380, 9090, 7098, 7009, 2763, 9759, 5115, 5440, 4464, 1695, 3565, 8478, 346, 2814, 8565, 2669, 5933, 75, 4511, 2911, 8441, 1983, 2800, 4693, 52, 5478, 8741, 2463, 9211, 939, 3731, 2232, 1946, 2166, 3114, 4374, 9815, 7194, 1960, 6785, 1020, 161, 6213, 4877, 4204, 3330, 6929, 2464, 6917, 7666, 915, 226, 9802, 9175, 1348, 9570, 422, 8649, 7534, 295, 4733, 6358, 2835, 8172, 2388, 2524, 5784, 7789, 8555, 2776, 1750, 8657, 2994, 6712, 7038, 5649, 5969, 7392, 8714, 1548, 8354, 1478, 4370, 6111, 4313, 9416, 6972, 8670, 5197, 20, 8363, 8445, 2919, 5985, 9609, 8281, 1759, 9286, 2931, 4580, 3256, 9354, 795, 3655, 374, 8616, 8846, 5844, 9201, 8349, 8105, 1346, 5036, 4534, 8192, 9604, 3459, 6369, 670, 5616, 6876, 8987, 7129, 5192, 7958, 2990, 506, 9406, 8829, 7443, 1294, 3741, 1439, 2826, 5506, 3746, 9798, 5508, 9589, 1686, 3175, 8607, 4671, 7570, 7917, 2840, 6652, 7334, 2004, 296, 9012, 6765, 9712, 9676, 4789, 9766, 3109, 8514, 8515, 5157, 654, 6006, 9313, 3336, 6507, 9045, 2684, 2954, 7117, 8115, 8122, 4966, 4736, 8336, 435, 8156, 6988, 2746, 1219, 3467, 9876, 3425, 8806, 895, 2669, 2982, 961, 4861, 7034, 6610, 1783, 8488, 7549, 2299, 3499, 5858, 4048, 445, 1652, 545, 5492, 1327, 1418, 3988, 3660, 7908, 5009, 577, 9426, 7563, 4286, 257, 4333, 5422, 6730, 7673, 2944, 8327, 2545, 7042, 442, 5290, 7205, 7304, 6941, 6780, 7947, 8977, 9792, 628, 2584, 3867, 2561, 580, 5172, 9235, 8105, 4829, 7729, 2427, 8711, 3508, 7484, 6854, 9548, 7919, 3831, 3457, 9454, 2957, 609, 1754, 3730, 6453, 8453, 3711, 9393, 8072, 8137, 3677, 7237, 2376, 6062, 5142, 5022, 959, 120, 6213, 9714, 1590, 7904, 7223, 1695, 6056, 7518, 722, 5606, 9875, 6081, 6034, 6539, 7240, 5270, 2038, 120, 1867, 2005, 6134, 6334, 9698, 7369, 9444, 9327, 7299, 7122, 5675, 9068, 3102, 368, 5928, 8656, 4724, 8305, 1327, 9575, 3456, 1513, 5168, 3816, 4863, 2602, 9596, 1144, 9369, 4820, 3807, 192, 9512, 9866, 4136, 1920, 7614, 4359, 5265, 5387, 6409, 2297, 158, 1952, 7428, 6909, 2417, 9388, 6867, 5403, 9318, 4784, 9863, 218, 4522, 1964, 649, 9423, 9616, 5075, 2667, 9768, 549, 2854, 4936, 854, 6543, 140, 323, 2611, 4611, 4398, 8165, 3610, 3929, 5502, 9753, 8849, 5544, 5380, 697, 2509, 3184, 8562, 7736, 154, 8458, 7694, 193, 6284, 5400, 8885, 9552, 1089, 7229, 8820, 1961, 8989, 6231, 4263, 2051, 7583, 339, 6490, 967, 6888, 5069, 8930, 8540, 8888, 9771, 8134, 7856, 4822, 4933, 6251, 1968, 5071, 430, 8256, 8321, 2743, 423, 974, 2210, 6513, 6224, 5560, 3469, 9056, 7680, 6617, 8559, 1624, 998, 7246, 8365, 1009, 5773, 3869, 7744, 7429, 114, 3201, 172, 2960, 7157, 3564, 2232, 7798, 154, 1700, 9704, 5104, 3468, 5156, 624, 7430, 5858, 360, 3680, 1032, 2970, 1482, 53, 6218, 4011, 9549, 1108, 2708, 6003, 298, 7192, 1074, 933, 2350, 2161, 7136, 423, 4638, 241, 3393, 8891, 6833, 4871, 4540, 7275, 714, 6253, 6585, 5197, 9664, 8694, 2349, 8204, 4076, 5169, 6799, 181, 3926, 2127, 3434, 2530, 2354, 8012, 2273, 6656, 7672, 8517, 2637, 9601, 4353, 4250, 4900, 6911, 7135, 870, 3581, 2155, 6892, 1467, 4162, 7363, 4665, 4788, 6183, 5338, 6849, 1196, 8377, 6566, 1861, 1781, 969, 2851, 7605, 6116, 5323, 4606, 510, 8148, 8628, 5682, 2686, 2172, 8410, 7079, 3771, 7143, 5682, 3423, 9085, 8791, 7075, 3537, 7097, 2435, 3811, 2920, 4938, 2125, 9169, 2751, 2998, 4191, 1155, 6881, 9448, 2981, 2314, 733, 5390, 2182, 5763, 7627, 3173, 1288, 6837, 360, 5602, 9182, 6588, 2172, 8956, 8003, 780, 6321, 8946, 8223, 7391, 9705, 6264, 7161, 5400, 2787, 4543, 7347, 9162, 6031, 8511, 8405, 9996, 7489, 3014, 3801, 4476, 2262, 33, 4741, 5400, 3550, 4592, 9048, 8663, 5941, 4782, 115, 9584, 7587, 8481, 786, 6840, 5575, 8872, 8674, 5743, 2025, 8011, 3549, 8583, 5682, 6390, 2063, 5562, 6338, 4771, 7541, 7609, 6200, 6400, 9351, 9461, 8665, 1634, 9704, 3737, 5905, 5982, 2608, 1711, 5793, 4645, 2395, 8573, 1549, 2149, 583, 4045, 9045, 5844, 4956, 5962, 6848, 1942, 9705, 4049, 1323, 3579, 3871, 9125, 5686, 1055, 8237, 3608, 9346, 9160, 6863, 2436, 1018, 5741, 7256, 2733, 8723, 6134, 1209, 1148, 564, 3021, 9805, 8369, 5232, 1641, 5467, 6950, 8485, 8405, 5421, 9241, 3083, 1118, 8579, 7233, 308, 2716, 2392, 2768, 3245, 571, 1156, 5829, 1801, 8944, 2274, 182, 1579, 3706, 180, 8452, 2813, 9548, 5274, 5901, 6969, 6908, 395, 9917, 5582, 3219, 4866, 7672, 2330, 4397, 1361, 964, 1767, 3132, 1666, 4517, 63, 7617, 5456, 843, 1083, 994, 5820, 1150, 9276, 3889, 525, 1918, 5889, 7144, 6189, 7335, 1609, 2349, 7078, 4427, 1875, 9662, 5482, 37, 4758, 6260, 9166, 9929, 7691, 2905, 2341, 5112, 637, 2319, 7963, 5363, 6290, 4825, 2122, 5790, 2755, 5552, 3979, 3860, 9104, 7291, 3903, 4728, 8034, 5453, 6719, 8951, 1958, 7329, 3288, 883, 2794, 1287, 3369, 1969, 9782, 8763, 8552, 3026, 9724, 3218, 2955, 1102, 9894, 7024, 1679, 250, 6976, 8937, 1571, 9490, 2093, 5862, 765, 6711, 6742, 8436, 1489, 8491, 3129, 5844, 5776, 7170, 3454, 6865, 5073, 2706, 1267, 2771, 2400, 3586, 2804, 379, 2590, 28, 6372, 2183, 120, 2577, 8755, 3343, 1824, 3285, 4731, 7984, 5238, 9529, 7726, 6315, 6291, 3527, 2315, 3209, 6271, 4786, 1593, 707, 254, 9682, 728, 2119, 105, 8973, 8506, 1608, 8453, 6680, 213, 9806, 9003, 6866, 2322, 8992, 109, 8411, 3744, 8338, 1718, 2086, 7721, 8142, 4476, 9575, 4847, 9445, 7282, 412, 6841, 2639, 2698, 5478, 2757, 9278, 3031, 3304, 9324, 7752, 5085, 3794, 9788, 6201, 7026, 3470, 183, 1111, 6554, 5984, 7065, 3602, 7819, 9836, 9269, 425, 105, 9070, 1997, 5772, 5975, 1320, 9684, 7193, 6030, 2870, 3945, 9251, 1832, 1672, 4542, 6863, 3421, 7659, 6080, 4343, 2472, 9093, 7655, 1549, 291, 8419, 2975, 2064, 254, 3333, 9148, 9143, 6221, 1313, 6224, 615, 8789, 3037, 4423, 6561, 1520, 4632, 2485, 3221, 1523, 77, 4086, 9676, 3116, 1974, 4238, 7408, 40, 4667, 7059, 3369, 4727, 3840, 6289, 4042, 921, 5019, 5717, 8715, 7470, 2657, 3263, 2981, 1861, 6655, 3661, 8777, 706, 4166, 5646, 4959, 8834, 3035, 2825, 82, 4496, 1243, 3510, 1115, 6110, 5095, 4594, 3099, 3488, 7148, 8387, 1734, 6618, 9888, 1635, 4133, 3359, 669, 7762, 9979, 7224, 8620, 2622, 364, 2223, 9235, 6757, 2984, 2468, 9099, 8250, 7527, 5267, 7356, 6932, 4043, 7160, 3631, 623, 7736, 906, 4921, 8221, 9557, 7336, 1207, 6965, 3837, 6516, 8768, 1516, 6406, 9325, 9911, 8591, 990, 9016, 3518, 8814, 3779, 3847, 8525, 2053, 8370, 9509, 2355, 1437, 8792, 1088, 4444, 2470, 6036, 3354, 4220, 5967, 7658, 43, 7703, 8391, 1309, 2131, 3834, 2484, 2069, 9310, 7152, 1477, 3215, 6393, 9314, 6012, 3090, 5052, 6335, 5079, 3066, 8050, 4039, 5545, 6826, 7030, 3975, 3211, 7002, 6591, 8912, 5994, 3498, 3052, 1340, 4955, 6186, 9740, 6131, 6053, 9643, 2221, 9197, 4256, 7414, 1896, 1556, 5418, 9267, 654, 8192, 2386, 9363, 1958, 7081, 270, 1217, 1753, 3665, 1580, 2051, 7697, 7309, 5523, 7558, 6999, 248, 8368, 810, 4140, 3874, 4949, 3494, 2698, 8740, 6404, 4869, 4132, 8498, 2224, 9692, 4561, 3403, 8343, 5065, 7534, 415, 5498, 1556, 7812, 3654, 9243, 9448, 1226, 9563, 1440, 1632, 6191, 1195, 5795, 6450, 5651, 3128, 6348, 3703, 9636, 1553, 2680, 8859, 9441, 8690, 6715, 1527, 6116, 1452, 2332, 8417, 1413, 3395, 6642, 2850, 9735, 2125, 309, 5330, 5531, 2040, 2037, 9168, 5321, 485, 5195, 1228, 9077, 4648, 8918, 3202, 8133, 8448, 7315, 3750, 1609, 924, 2301, 5861, 889, 5803, 8511, 1400, 7437, 912, 9293, 8163, 9605, 8253, 1058, 1159, 2932, 2390, 3437, 5607, 4462, 7257, 7761, 5056, 4636, 1997, 23, 5063, 1810, 3866, 6829, 7752, 9764, 7776, 7585, 9080, 8164, 3101, 4234, 5214, 2278, 9820, 9734, 9235, 3386, 5500, 7417, 5375, 9485, 9714, 5445, 4935, 2009, 2493, 3498, 4610, 6795, 1532, 4888, 8441, 4479, 6084, 4506, 8407, 2752, 4554, 8895, 1293, 9776, 6678, 917, 6347, 5707, 4371, 9702, 5689, 4670, 2862, 2913, 6644, 7265, 7269, 330, 950, 5092, 8300, 4781, 1062, 200, 6808, 9611, 114, 8421, 5483, 8191, 5246, 8195, 3170, 8599, 2619, 9904, 9289, 521, 9099, 462, 1026, 8451, 7035, 9635, 6434, 1267, 3142, 5272, 2278, 4101, 6012, 3398, 5517, 1455, 5904, 4094, 239, 6706, 7233, 8714, 2426, 1069, 12, 6421, 3175, 7128, 1267, 7904, 4713, 379, 9152, 3813, 5471, 2764, 9250, 3897, 233, 1041, 9658, 6463, 5670, 9355, 3566, 1975, 2437, 8903, 2882, 7109, 9401, 2558, 3777, 3352, 2568, 1658, 9831, 6546, 190, 5020, 297, 5746, 829, 9551, 3040, 9716, 1996, 5983, 3254, 6544, 3134, 2459, 4470, 1427, 1781, 6829, 6503, 208, 1241, 1004, 4731, 3652, 4933, 9007, 1413, 7632, 4315, 7425, 2206, 3800, 4527, 4324, 3893, 9478, 2195, 183, 1849, 3543, 6297, 7809, 3869, 6747, 5678, 3593, 428, 9025, 3535, 4950, 3821, 5814, 9898, 9588, 1961, 4811, 9132, 3227, 2179, 2959, 374, 1195, 861, 223, 645, 2757, 5666, 5727, 2214, 4243, 8481, 9697, 1566, 2385, 7340, 232, 2791, 1752, 4806, 6429, 6668, 9523, 5977, 8543, 4754, 4950, 724, 7603, 7403, 4801, 4142, 8665, 3731, 1668, 5400, 4437, 8131, 6197, 4076, 7751, 6757, 2984, 6439, 5181, 1485, 5950, 6156, 1415, 2915, 1311, 5879, 2342, 6302, 622, 3755, 259, 692, 3834, 3649, 7939, 9293, 4112, 499, 6337, 7959, 2422, 6531, 816, 454, 6901, 4241, 92, 2812, 9602, 4574, 7645, 2157, 8389, 9393, 6987, 8586, 4675, 3055, 5084, 8154, 9277, 6533, 2018, 2171, 6646, 3123, 7629, 7046, 6812, 864, 5639, 2245, 7930, 8869, 364, 6133, 1430, 1936, 900, 5246, 7193, 31, 139, 848, 9017, 2910, 8110, 3125, 7825, 8501, 7634, 2416, 5035, 6011, 3531, 2472, 3439, 1653, 4519, 8076, 5321, 141, 9035, 242, 9599, 1632, 4469, 8068, 7926, 5831, 1029, 464, 2133, 2187, 699, 3039, 9616, 6649, 8019, 2877, 935, 5314, 2408, 7612, 7435, 9530, 7634, 6223, 9877, 9200, 3287, 1584, 2469, 3487, 7719, 3782, 4904, 5683, 4860, 3369, 4626, 2547, 8519, 4909, 5022, 1943, 223, 7898, 8062, 1589, 5991, 9733, 1334, 4286, 2557, 3689, 5388, 4729, 5807, 9651, 7197, 2063, 8746, 558, 7009, 4611, 6292, 939, 2012, 7354, 2233, 8804, 4334, 9494, 9401, 1605, 1268, 9168, 7215, 5319, 157, 6487, 4972, 4919, 9438, 5495, 5594, 5192, 2995, 301, 2668, 5135, 7320, 7070, 1240, 5799, 1506, 8650, 1978, 4325, 6890, 6109, 2235, 3100, 751, 298, 5059, 408, 8868, 7852, 1586, 7518, 3447, 535, 7897, 9765, 8096, 462, 3062, 710, 4109, 4670, 3445, 7976, 8334, 7853, 5287, 7534, 4792, 2868, 3663, 4823, 3778, 8239, 5279, 5719, 3540, 3346, 2796, 4124, 6114, 2983, 6285, 7294, 9915, 9920, 4936, 5280, 7338, 7853, 6367, 2627, 7611, 3560, 7437, 637, 5376, 4736, 2356, 2039, 2326, 8891, 3923, 6808, 9418, 1363, 6030, 1121, 7579, 2019, 371, 4314, 7606, 450, 8129, 3498, 8205, 5542, 7300, 4372, 406, 7364, 580, 4701, 9323, 5681, 1236, 207, 8330, 2115, 56, 2344, 7533, 863, 2890, 1646, 1451, 1687, 1755, 3204, 9690, 5048, 2612, 2723, 7275, 1472, 2333, 8532, 4241, 5584, 3634, 808, 3918, 6735, 5950, 1720, 7161, 8173, 1528, 5916, 5914, 1058, 1807, 6399, 2164, 2803, 8350, 8131, 9993, 5390, 3344, 2949, 4652, 8108, 3575, 4746, 4144, 6493, 6214, 1115, 2343, 1630, 3970, 5202, 7045, 6120, 8673, 7134, 7679, 6584, 5600, 8418, 3528, 9718, 1929, 9109, 8404, 7114, 5314, 9272, 1083, 2924, 475, 5096, 6858, 3640, 5498, 8515, 6927, 2212, 5495, 9818, 8423, 7538, 6338, 4088, 8673, 4138, 4847, 5732, 8627, 1205, 6056, 6055, 4360, 7566, 9169, 623, 485, 8576, 4124, 40, 248, 6285, 4135, 6634, 9573, 4068, 2658, 580, 7924, 6694, 368, 6864, 5897, 393, 4630, 5001, 6624, 2740, 8114, 7712, 5490, 7892, 1010, 5573, 9284, 9935, 1058, 1613, 4284, 133, 7281, 9588, 4557, 7930, 7236, 3266, 6684, 6129, 2125, 8894, 4864, 2850, 7857, 9520, 8759, 1316, 4758, 1682, 4632, 6220, 7417, 5829, 5760, 874, 8611, 7306, 3808, 9292, 7466, 5136, 821, 1207, 7976, 1766, 8361, 7911, 9787, 4797, 1931, 7486, 6315, 6603, 6448, 264, 4621, 986, 4523, 2106, 2476, 7476, 3871, 8151, 8930, 9359, 5779, 43, 8120, 5332, 4047, 3609, 4095, 7375, 9082, 183, 9504, 4613, 3695, 8961, 2628, 7586, 7922, 7834, 9353, 9603, 5793, 5204, 8877, 7101, 4435, 7333, 3008, 957, 684, 7572, 8841, 6469, 3196, 2400, 2951, 7070, 9704, 4216, 8191, 6255, 8502, 8747, 5597, 9268, 9889, 8307, 2812, 4304, 2852, 8447, 6260, 5926, 8869, 6884, 8579, 9321, 7419, 8057, 2831, 9882, 222, 822, 6151, 3479, 7979, 9633, 4450, 5112, 3115, 6483, 9324, 1111, 9458, 8398, 7486, 8919, 6283, 8456, 3764, 4617, 7218, 6292, 9437, 7324, 8576, 5726, 2617, 9024, 7233, 606, 3637, 9758, 6518, 1335, 658, 1610, 1822, 7009, 8498, 2647, 6256, 7441, 6090, 9480, 5629, 4850, 3022, 6285, 748, 8089, 3913, 4644, 9071, 3133, 4912, 6583, 4664, 798, 9625, 418, 6891, 6460, 8526, 9838, 813, 4463, 4590, 752, 477, 1974, 4345, 6470, 2645, 2800, 2985, 4053, 3499, 581, 8474, 2788, 9188, 8557, 9647, 4093, 9571, 9985, 6930, 3216, 9354, 4904, 9409, 6330, 7621, 8002, 4342, 3435, 712, 7140, 5348, 9794, 6531, 2656, 3707, 446, 5619, 6126, 393, 8320, 2626, 1595, 8141, 2762, 5431, 5929, 3458, 1370, 5818, 6182, 868, 4366, 220, 5948, 4672, 4020, 3109, 4616, 8354, 9967, 5630, 8079, 8596, 8256, 774, 351, 4017, 9486, 9210, 321, 8977, 4827, 1261, 7091, 2007, 6927, 6076, 3679, 7756, 2729, 335, 223, 1302, 7319, 8245, 8799, 5667, 8371, 8628, 4682, 8560, 837, 4710, 8222, 3809, 1063, 9786, 5111, 8618, 5128, 2378, 8464, 3673, 8839, 6670, 2890, 473, 4210, 2176, 1002, 9814, 6509, 5981, 9340, 832, 1831, 9193, 7549, 2326, 1166, 260, 2877, 2804, 325, 7931, 5647, 6466, 8998, 8979, 6788, 1988, 6211, 4017, 7107, 6438, 7795, 6306, 2672, 6402, 8933, 6463, 8565, 734, 7987, 6926, 4834, 6938, 3383, 6082, 8196, 4323, 3281, 8522, 6774, 8803, 5149, 9153, 1300, 4011, 5863, 1504, 7448, 7519, 4238, 1043, 1638, 8762, 137, 5808, 6729, 5143, 9582, 1827, 5014, 6002, 6419, 3289, 5620, 2629, 9833, 8055, 8578, 295, 2992, 746, 4284, 9323, 2506, 5774, 8071, 4486, 3006, 9946, 2795, 6803, 8230, 1154, 485, 119, 1024, 1295, 6580, 7678, 6751, 5702, 457, 2311, 2346, 6879, 2286, 6825, 802, 2186, 1432, 9647, 8023, 3652, 1357, 2532, 6989, 7530, 3512, 7430, 8312, 9016, 8709, 4491, 3626, 3684, 741, 2198, 8538, 3170, 9766, 7284, 5088, 8091, 4780, 5947, 7270, 7838, 2796, 8962, 5697, 3757, 3113, 610, 7392, 9046, 9153, 6414, 4112, 1657, 5041, 7596, 7384, 6560, 7103, 5411, 463, 8961, 4720, 8377, 3751, 2676, 5860, 974, 4081, 7305, 6284, 7514, 1526, 3444, 3623, 7264, 9235, 514, 1866, 6885, 6006, 7610, 2426, 2229, 8618, 4352, 1576, 8276, 3415, 6111, 8272, 8326, 696, 2802, 5516, 7031, 8623, 7967, 7694, 5277, 990, 9889, 5961, 3354, 4110, 9603, 8100, 3359, 6438, 2468, 5843, 1208, 2694, 9150, 4357, 4672, 5376, 8718, 9224, 5757, 577, 7061, 2875, 478, 7972, 8788, 4159, 3031, 7292, 731, 6946, 4955, 5756, 8078, 8185, 1506, 7916, 5811, 7002, 3982, 9011, 5485, 9164, 4150, 6930, 1178, 4279, 8464, 7801, 7024, 2963, 14, 244, 6918, 9716, 6555, 8302, 3374, 9855, 689, 7752, 6563, 3095, 9864, 9164, 2691, 1233, 370, 5901, 3491, 9568, 5032, 6558, 7064, 499, 8718, 701, 5538, 743, 1514, 815, 5188, 8684, 6812, 3335, 9834, 9979, 765, 4923, 6492, 758, 687, 7946, 6019, 3351, 7864, 4421, 5243, 6159, 152, 4183, 7456, 7748, 5141, 2298, 2192, 5419, 2441, 2265, 5849, 8690, 8580, 796, 4595, 6479, 9266, 5502, 2915, 1742, 2016, 3021, 375, 9919, 9416, 4697, 6555, 725, 6865, 6610, 9894, 8755, 7014, 3050, 1200, 2932, 3369, 2586, 794, 4426, 5712, 1593, 3154, 4023, 263, 2562, 275, 1428, 985, 9657, 8517, 2490, 1904, 2754, 7994, 3239, 693, 1998, 7409, 204, 6958, 3628, 8613, 3168, 9175, 5057, 5555, 6823, 7691, 9337, 1388, 96, 258, 7171, 4115, 4321, 2932, 8532, 8177, 8113, 6213, 7920, 1723, 8804, 6743, 9511, 3044, 4646, 1381, 2396, 2424, 6379, 8576, 876, 4481, 2095, 334, 1561, 641, 8783, 3291, 7170, 2800, 4734, 4115, 7130, 3398, 5512, 6314, 3349, 8090, 5947, 8325, 4059, 6414, 2669, 8809, 1082, 5796, 7427, 3154, 1987, 68, 8817, 7074, 6810, 2265, 6271, 4279, 9688, 7534, 895, 2320, 7499, 724, 5911, 6444, 8235, 3215, 7160, 1140, 630, 666, 1104, 3869, 5724, 2427, 8820, 7670, 1483, 9623, 497, 7236, 5061, 3201, 9084, 2953, 7636, 9827, 5187, 5093, 6447, 8353, 3985, 125, 1506, 4895, 5002, 69, 7232, 6233, 5506, 3429, 3589, 950, 7003, 526, 1623, 3754, 9334, 802, 2902, 4729, 4036, 1928, 1560, 2712, 4157, 8568, 4576, 3123, 9767, 1906, 3458, 5885, 6772, 7697, 7742, 3531, 9629, 5708, 1339, 9433, 7706, 6237, 8208, 6186, 4154, 7834, 4141, 9412, 7473, 4685, 9931, 878, 7336, 4641, 6172, 9954, 821, 5131, 3393, 5181, 4524, 6560, 7915, 57, 3802, 3044, 1593, 5702, 1946, 2238, 7786, 3554, 9540, 6351, 7777, 3714, 195, 6249, 2504, 3795, 7271, 6989, 8146, 9149, 1110, 1359, 1910, 8634, 1250, 1890, 7562, 2466, 2694, 1575, 6371, 9533, 8698, 2452, 603, 6063, 7415, 1740, 5260, 3252, 3308, 7217, 3481, 695, 6161, 3440, 8763, 5664, 506, 6474, 2204, 8475, 107, 3939, 2094, 2012, 151, 5834, 5364, 5287, 820, 3029, 6862, 9423, 7250, 4959, 9428, 953, 921, 3253, 1963, 2832, 1807, 2058, 2606, 568, 4247, 4340, 6085, 9058, 7848, 7771, 3979, 9818, 9828, 9803, 9783, 526, 5944, 6344, 6203, 2391, 1395, 1991, 4705, 6508, 3664, 8679, 2703, 8182, 8924, 4828, 15, 2189, 3188, 6737, 4275, 6623, 8195, 4581, 7252, 715, 6020, 1428, 8629, 836, 8548, 7482, 8479, 7909, 2625, 2880, 8099, 1599, 7278, 7988, 967, 6934, 8241, 6629, 8282, 8417, 4645, 6046, 6960, 9804, 5654, 8458, 8995, 6450, 8312, 3915, 5176, 4358, 3226, 3608, 2419, 3968, 7077, 914, 2729, 7811, 4542, 6888, 5311, 6246, 9290, 146, 9534, 1807, 1266, 2866, 6035, 4075, 374, 648, 1491, 7628, 8708, 3498, 7182, 1121, 9726, 6069, 2562, 3175, 6200, 6461, 6252, 1412, 3866, 9185, 7704, 5045, 4187, 4379, 1669, 1936, 482, 3774, 8144, 9227, 7661, 3599, 9571, 4313, 3653, 4958, 4289, 9535, 1134, 7916, 3856, 7656, 4939, 533, 5350, 6517, 3936, 4726, 9843, 1311, 1711, 9919, 3818, 4151, 8547, 5523, 6708, 6756, 2747, 8966, 4059, 8692, 9964, 100, 7610, 2312, 125, 8785, 4662, 4985, 9968, 1648, 6510, 7166, 8154, 2892, 435, 2109, 6102, 7071, 7126, 2287, 7287, 6974, 5160, 82, 6674, 8917, 9712, 3888, 9716, 129, 6071, 2991, 8995, 2891, 125, 3852, 7096, 4899, 7662, 7517, 3412, 5709, 2023, 9190, 4786, 1931, 2168, 645, 7883, 1033, 871, 6024, 2248, 3993, 3682, 1272, 2030, 5441, 5353, 442, 657, 9627, 6567, 1185, 8175, 4689, 7798, 8331, 2104, 9644, 3961, 9761, 5480, 5327, 9591, 4069, 9489, 2066, 6650, 4050, 891, 5189, 3653, 3504, 9544, 8456, 4369, 1258, 3420, 6847, 5246, 7547, 1334, 6074, 1854, 4673, 9180, 5532, 603, 5115, 3059, 777, 605, 647, 7277, 7438, 4189, 5608, 9884, 5870, 6796, 2836, 9042, 8860, 2449, 172, 3077, 5766, 53, 1590, 6437, 7977, 876, 5680, 9725, 8231, 3931, 7464, 776, 3369, 4220, 6394, 6266, 6799, 2042, 5174, 7664, 1544, 7647, 7869, 8511, 3994, 3883, 722, 2666, 1551, 3687, 3527, 1989, 5164, 5416, 9409, 7533, 6075, 2122, 4548, 200, 4881, 9124, 3350, 6796, 3104, 3676, 1168, 3449, 3050, 2150, 1162, 9345, 9761, 6706, 5706, 7836, 3327, 6518, 9294, 6179, 3529, 3066, 5733, 6343, 9593, 1767, 2148, 9499, 6272, 9879, 8454, 9378, 6525, 6330, 2555, 4947, 1262, 8929, 6629, 7398, 3283, 2051, 9248, 7443, 8976, 7561, 1773, 1787, 704, 1323, 3226, 8947, 6084, 1453, 2455, 2619, 9260, 1561, 5201, 8589, 6808, 4699, 598, 8086, 2328, 4784, 1688, 6976, 2534, 6348, 8539, 2494, 9177, 1031, 2110, 4494, 1073, 2336, 7018, 1337, 9085, 3199, 8055, 6471, 2974, 9632, 2759, 5172, 7447, 6688, 6938, 5532, 1046, 2823, 6050, 7915, 4314, 404, 7363, 9473, 4111, 9044, 2952, 6530, 6768, 8386, 8103, 5461, 3780, 3416, 3501, 1475, 678, 4748, 6874, 5035, 5740, 7474, 6225, 7599, 1341, 9264, 4107, 8697, 8351, 9145, 9784, 9755, 3644, 8201, 7928, 71, 7746, 8430, 7197, 3662, 3131, 5395, 3119, 3648, 344, 9318, 3592, 2416, 2690, 2992, 6578, 5796, 1562, 9276, 1524, 6730, 1228, 7274, 6698, 4137, 479, 7912, 3783, 7367, 679, 8177, 2114, 8406, 4370, 4961, 1278, 3157, 9182, 2039, 4260, 3198, 4518, 6679, 5269, 5006, 1381, 4685, 3735, 8792, 4324, 1667, 3802, 453, 757, 2659, 7802, 5801, 4012, 8846, 4758, 2214, 8214, 595, 6211, 906, 7855, 8778, 7116, 845, 8959, 4664, 7184, 3221, 8576, 2859, 8521, 621, 9413, 6861, 8236, 9641, 7698, 8982, 9569, 2184, 35, 5524, 6979, 3194, 7226, 7783, 2504, 9547, 4529, 626, 8126, 2108, 814, 2395, 6671, 6233, 2057, 3666, 9642, 1388, 7973, 8876, 6033, 4013, 5655, 1685, 5811, 1991, 9107, 8939, 4322, 9100, 3985, 7597, 7279, 797, 4919, 5157, 3231, 1775, 6896, 5934, 2009, 9530, 4999, 2968, 2582, 9445, 679, 4624, 2650, 9235, 9679, 8275, 677, 2335, 4918, 9579, 184, 3646, 4099, 8984, 2980, 2957, 2868, 3022, 4337, 8293, 9709, 2323, 1530, 2191, 6444, 7283, 9147, 2432, 4394, 7280, 9631, 9154, 6685, 2392, 7228, 3005, 1643, 9995, 8304, 9598, 8866, 8238, 6537, 8957, 5949, 5072, 2999, 8734, 4630, 3765, 7654, 3439, 2022, 718, 1705, 3181, 7884, 3984, 9252, 7912, 2126, 1531, 5537, 3210, 3556, 6761, 7579, 6698, 1118, 6618, 2185, 2349, 1222, 7627, 8772, 3292, 7553, 9469, 4425, 4755, 3914, 7157, 6155, 209, 3986, 6808, 8909, 9765, 8719, 2100, 417, 7585, 8698, 9419, 8617, 4129, 8220, 8510, 9308, 4324, 7919, 1616, 9578, 2011, 6938, 3085, 6325, 4909, 1358, 3023, 8945, 6323, 7700, 745, 359, 221, 1564, 8505, 4555, 285, 3103, 3470, 6583, 8978, 2469, 8763, 3005, 4761, 5462, 9614, 2036, 351, 9699, 7853, 8202, 7724, 1805, 92, 6735, 9530, 8852, 95, 9072, 6806, 3460, 5855, 2246, 5162, 1465, 3723, 8927, 5982, 2788, 1560, 5643, 6309, 8032, 6239, 5353, 3090, 477, 9993, 5309, 7630, 1639, 411, 9880, 8901, 8863, 9439, 3098, 1062, 7243, 7086, 488, 4328, 4515, 2800, 9907, 9986, 9561, 3962, 6613, 6435, 8578, 2183, 1171, 96, 6290, 4388, 2345, 9524, 7502, 7558, 8189, 7947, 772, 259, 8085, 5916, 4079, 8076, 8388, 4122, 3669, 3503, 5137, 6483, 8116, 4504, 2121, 7496, 3760, 4334, 790, 7759, 5288, 235, 3517, 5565, 1674, 1312, 751, 8613, 9047, 2985, 821, 3188, 9094, 9381, 7780, 3413, 9719, 5379, 5637, 2840, 578, 5766, 5444, 5301, 6567, 8427, 3809, 8711, 4591, 4003, 9744, 2461, 5362, 866, 8590, 6819, 2636, 9954, 283, 7965, 240, 1778, 2168, 7441, 5495, 1218, 7279, 9973, 6086, 2924, 2011, 5010, 8334, 7442, 3995, 2726, 3909, 8825, 2055, 5861, 8351, 8067, 9301, 2540, 405, 149, 8485, 4953, 9367, 5386, 1780, 7903, 3880, 2170, 3799, 4505, 6494, 7168, 4354, 7603, 5814, 4144, 522, 9869, 916, 8801, 6263, 3833, 557, 1476, 7226, 887, 2937, 4166, 8032, 5635, 9064, 2635, 3157, 2894, 3398, 2007, 6963, 5000, 9545, 6409, 4717, 5826, 9457, 6590, 8048, 2368, 4993, 8342, 920, 6877, 9288, 4560, 5583, 3541, 4477, 6114, 9032, 944, 9029, 7591, 6368, 7788, 1558, 4553, 2980, 6275, 5883, 7547, 8503, 435, 8334, 9050, 5077, 470, 5559, 7736, 7784, 6688, 2401, 2046, 5733, 8360, 6348, 4903, 3649, 2346, 1823, 9509, 8855, 8302, 227, 1681, 3932, 1651, 9112, 662, 8890, 5356, 8718, 352, 6301, 3760, 4637, 5900, 349, 2184, 5877, 1170, 7124, 4684, 4458, 2846, 4315, 3672, 4758, 5971, 7492, 2325, 6969, 7455, 7646, 4966, 3264, 4904, 3755, 5246, 7876, 961, 170, 806, 8849, 4854, 8174, 4077, 6842, 2912, 3955, 2946, 2802, 1535, 1682, 7321, 4348, 9068, 3417, 2647, 8666, 8922, 4703, 1505, 3647, 3564, 8328, 6079, 1385, 7138, 6195, 1089, 2347, 2795, 2768, 8277, 9686, 2608, 6718, 2858, 5620, 416, 4910, 4800, 9909, 7152, 9378, 3104, 3905, 8841, 4937, 9294, 1521, 6651, 9636, 678, 8428, 5227, 5805, 1795, 8150, 7871, 3947, 6181, 9088, 4235, 4884, 3633, 1680, 765, 4226, 7316, 121, 994, 5814, 7349, 1162, 3972, 9144, 3700, 8479, 3665, 1693, 4970, 1996, 5159, 7471, 6334, 3369, 5832, 2210, 6603, 8797, 4896, 9368, 6077, 394, 9383, 6740, 4047, 5296, 6009, 3734, 3026, 2632, 740, 3490, 2588, 9389, 4046, 8552, 7752, 6279, 4223, 8572, 735, 397, 5860, 8508, 747, 3724, 2653, 3900, 7322, 1443, 1386, 203, 6934, 7684, 9832, 8712, 3662, 3251, 8286, 7173, 8561, 5641, 3809, 2434, 1872, 3035, 9976, 6702, 9481, 5562, 3691, 2288, 2897, 3260, 6326, 4174, 9733 }, 1200)));
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        static long repeatedString(string s, long n)
        {
            long len = s.Length;
            long Q = (n / len);
            long R = (n % len);
            long cnt = 0;
            foreach (char c in s)
            {
                if (c == 'a')
                {
                    cnt++;
                }
            }
            long rcnt = 0;
            if (R != 0)
            {
                for (int i = 0; i < R; i++)
                {
                    if (s[i] == 'a')
                    {
                        rcnt++;
                    }
                }
            }
            return (cnt * Q) + rcnt;
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"{ repeatedString("abcac", 10)}"); // 4
            Console.WriteLine($"{ repeatedString("aba", 10)}"); // 7
            Console.WriteLine($"{ repeatedString("a", 1000000000000)}"); // 1000000000000
            Console.WriteLine($"{ repeatedString("babbaabbabaababaaabbbbbbbababbbabbbababaabbbbaaaaabbaababaaabaabbabababaabaabbbababaabbabbbababbaabb", 860622337747)}"); // 395886275361
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ManagerId { get; set; }
        public Employee Manager { get; set; }

        public Employee(string id, string name, string managerId)
        {
            Id = id;
            Name = name;
            ManagerId = managerId;
            Manager = null;
        }
    }

    public class OrgChart
    {
        public static List<Employee> s_employees = new List<Employee>();

        private Employee Find(string id)
        {
            foreach (Employee employee in s_employees)
            {
                if (employee.Id.Equals(id))
                {
                    return employee;
                }
            }
            return null;
        }

        public void Add(string id, string name, string managerId)
        {
            Employee employee = Find(id);
            if (employee != null)
            {
                return;
            }
            employee = new Employee(id, name, managerId);
            s_employees.Add(employee);
            employee.Manager = Find(managerId);
        }

        private List<Employee> SubOrdinates(Employee employee)
        {
            return (from subOrdinate in s_employees where subOrdinate.ManagerId.Equals(employee.Id) select subOrdinate).ToList();
        }

        private void Print(Employee employee, string indent)
        {
            Console.WriteLine($"{indent}{employee.Name} [{employee.Id}]");
        }

        private void Print(List<Employee> employees, Employee manager, string indent)
        {
            foreach (Employee employee in employees)
            {
                if (employee.Manager == manager)
                {
                    Print(employee, indent);
                    List<Employee> subOrdinates = SubOrdinates(employee);
                    Print(subOrdinates, employee, indent + "  ");
                }
            }
        }

        public void Print()
        {
            Print(s_employees, null, "");
        }

        public void Remove(string employeeId)
        {
            Employee employee = Find(employeeId);
            if (employee == null)
            {
                return;
            }
            List<Employee> subOrdinates = SubOrdinates(employee);
            foreach (Employee subOrdinate in subOrdinates)
            {
                subOrdinate.ManagerId = "-1";
                subOrdinate.Manager = null;
            }
            s_employees.Remove(employee);
        }

        public void Move(string employeeId, string newManagerId)
        {
            Employee employee = Find(employeeId);
            if (employee == null)
            {
                return;
            }
            employee.ManagerId = newManagerId;
            employee.Manager = Find(newManagerId);
        }

        public int Count(string employeeId)
        {
            return s_employees.Count;
        }
    }

    class Program
    {
        /*
            16
            add,1,Johnson Drye,-1
            add,2,Cristy Sprow,1
            add,3,Natacha Seligman,2
            add,4,Brittny Wicks,2
            add,5,Crissy Carden,2
            add,6,Maribel Lettieri,2
            add,7,Patrice Seawood,3
            add,8,Audrea Deshazo,3
            add,9,Emely Skoglund,3
            add,10,Krista Dugan,4
            add,11,Marilu Foos,4
            add,12,Cherilyn Brinegar,4
            add,13,Linn Caroll,1
            add,14,Sang Coffer,1
            add,15,Hilma Mehan,1
            print
        */

        static void Main(string[] args)
        {
            OrgChart orgChart = new OrgChart();
            orgChart.Add("1", "Johnson Drye", "-1");
            orgChart.Add("2", "Cristy Sprow", "1");
            orgChart.Add("3", "Natacha Seligman", "2");
            orgChart.Add("4", "Brittny Wicks", "2");
            orgChart.Add("5", "Crissy Carden", "2");
            orgChart.Add("6", "Maribel Lettieri", "2");
            orgChart.Add("7", "Patrice Seawood", "3");
            orgChart.Add("8", "Audrea Deshazo", "3");
            orgChart.Add("9", "Emely Skoglund", "3");
            orgChart.Add("10", "Krista Dugan", "4");
            orgChart.Add("11", "Marilu Foos", "4");
            orgChart.Add("12", "Cherilyn Brinegar", "4");
            orgChart.Add("13", "Linn Caroll", "1");
            orgChart.Add("14", "Sang Coffer", "1");
            orgChart.Add("15", "Hilma Mehan", "1");
            orgChart.Print();
            orgChart.Move("10", "3");
            orgChart.Print();
            orgChart.Remove("7");
            orgChart.Print();
        }
    }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        /*
         * Complete the 'rotateLeft' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts following parameters:
         *  1. INTEGER d
         *  2. INTEGER_ARRAY arr
         */
        public static List<int> rotateLeft(int d, List<int> arr)
        {
            int N = arr.Count;
            int[] rotatedArr = new int[arr.Count];

            int i = 0;
            foreach (int n in arr)
            {
                int j = i - d;
                if (j < 0)
                {
                    j += N;
                }
                rotatedArr[j] = n;
                i++;
            }

            return rotatedArr.ToList<int>();
        }

        static void Main(string[] args)
        {
            List<int> result = rotateLeft(4, new int[] { 1, 2, 3, 4, 5 }.ToList());

            Console.WriteLine(string.Join(" ", result));
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
    class Program
    {
        private static readonly SinglyLinkedListNode visitedNode = new SinglyLinkedListNode(0);

        private class SinglyLinkedListNode
        {
            public int data { get; private set; }
            public SinglyLinkedListNode next { get; set; }

            public SinglyLinkedListNode(int nodeData)
            {
                this.data = nodeData;
                this.next = null;
            }
        }

        private class SinglyLinkedList
        {
            public SinglyLinkedListNode head { get; private set; }
            public SinglyLinkedListNode tail { get; private set; }

            public SinglyLinkedList()
            {
                head = null;
                tail = null;
            }

            public SinglyLinkedListNode InsertNode(int nodeData)
            {
                SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

                if (head == null)
                {
                    head = node;
                }
                else
                {
                    tail.next = node;
                }

                tail = node;

                return node;
            }
        }

        static private bool hasCycle(SinglyLinkedListNode head)
        {
            if (head == null)
            {
                return false;
            }
            SinglyLinkedListNode node = head;
            for(; ; )
            {
                if (node.next == visitedNode)
                {
                    return true;
                }
                if (node.next == null)
                {
                    return false;
                }
                SinglyLinkedListNode next = node.next;
                node.next = visitedNode;
                node = next;
            }
        }

        static void Main(string[] args)
        {
            SinglyLinkedList ex1 = new SinglyLinkedList();
            SinglyLinkedListNode node1_1 = ex1.InsertNode(1);
            Console.WriteLine(hasCycle(ex1.head) ? 1 : 0);

            SinglyLinkedList ex2 = new SinglyLinkedList();
            SinglyLinkedListNode node2_1 = ex2.InsertNode(1);
            SinglyLinkedListNode node2_2 = ex2.InsertNode(2);
            SinglyLinkedListNode node2_3 = ex2.InsertNode(3);
            node2_3.next = node2_2;
            Console.WriteLine(hasCycle(ex2.head) ? 1 : 0);
        }
    }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        public static string findNumber(List<int> arr, int k)
        {
            foreach (int n in arr)
            {
                if (n == k)
                {
                    return "YES";
                }
            }
            return "NO";
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        public static List<int> oddNumbers(int l, int r)
        {
            List<int> oddNbrs = new List<int>();
            for (int n = l; n <= r; n++)
            {
                if ((n % 2) == 1)
                {
                    oddNbrs.Add(n);
                }
            }
            return oddNbrs;
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        public static string compressedString(string message)
        {
            int msgLen = message.Length;

            StringBuilder sb = new StringBuilder();
            int i = 0;
            while (i < msgLen)
            {
                int count = 1;
                char ch = message[i];
                sb.Append(ch);
                i++;

                while ((i < msgLen) && (message[i] == ch))
                {
                    count++;
                    i++;
                }

                if (count > 1)
                {
                    sb.Append(count);
                }
            }

            return sb.ToString();
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
        public static int maxTrailing(List<int> levels)
        {
            int nbrLevels = levels.Count;

            int maxLevel = levels[0];
            int maxLevelIdx = 0;
            for (int n = 1; n < nbrLevels; n++)
            {
                int leveln = levels[n];
                if (leveln > maxLevel)
                {
                    maxLevel = leveln;
                    maxLevelIdx = n;
                }
            }

            if (maxLevelIdx == 0)
            {
                return -1;
            }

            int minLevel = levels[maxLevelIdx - 1];
            for (int n = maxLevelIdx - 2; n >= 0; n--)
            {
                int leveln = levels[n];
                if (leveln < minLevel)
                {
                    minLevel = leveln;
                }
            }

            return maxLevel - minLevel;
        }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
    class Program
    {
        private static string nbrToString(int h)
        {
            switch (h)
            {
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                case 10:
                    return "ten";
                case 11:
                    return "eleven";
                case 12:
                    return "twelve";
                case 13:
                    return "thirteen";
                case 14:
                    return "fourteen";
                case 15:
                    return "fifteen";
                case 16:
                    return "sixteen";
                case 17:
                    return "seventeen";
                case 18:
                    return "eighteen";
                case 19:
                    return "nineteen";
                case 20:
                    return "twenty";
                case 21:
                    return "twenty one";
                case 22:
                    return "twenty two";
                case 23:
                    return "twenty three";
                case 24:
                    return "twenty four";
                case 25:
                    return "twenty five";
                case 26:
                    return "twenty six";
                case 27:
                    return "twenty seven";
                case 28:
                    return "twenty eight";
                case 29:
                    return "twenty nine";
                case 30:
                    return "thirty";
                default:
                    throw new Exception();
            }
        }

        static string timeInWords(int h, int m)
        {
            StringBuilder sb = new StringBuilder();

            if (m == 0)
            {
                sb.Append(nbrToString(h));
                sb.Append(" o' clock");
            }
            else if (m == 1)
            {
                sb.Append(nbrToString(m));
                sb.Append(" minute past ");
                sb.Append(nbrToString(h));
            }
            else if (m == 15)
            {
                sb.Append("quarter past ");
                sb.Append(nbrToString(h));
            }
            else if (m <= 29)
            {
                sb.Append(nbrToString(m));
                sb.Append(" minutes past ");
                sb.Append(nbrToString(h));
            }
            else if (m == 30)
            {
                sb.Append("half past ");
                sb.Append(nbrToString(h));
            }
            else if (m == 45)
            {
                sb.Append("quarter to ");
                sb.Append(nbrToString(h + 1));
            }
            else if (m <= 59)
            {
                sb.Append(nbrToString(60 - m));
                sb.Append(" minutes to ");
                sb.Append(nbrToString(h + 1));
            }
            else
            {
                throw new Exception();
            }

            return sb.ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine(timeInWords(5, 47));  // thirteen minutes to six
            Console.WriteLine(timeInWords(3, 0));   // three o' clock
            Console.WriteLine(timeInWords(7, 15));   // quarter past seven
        }
    }
#endif
// ---------------------------------------------------------------------------------------------------------
#if false
    class Program
    {
        static void Drop(char[][] matrix)
        {
            int N = matrix.Length;
            int Nm1 = N - 1;

            for (int j = 0; j < N; )
            {
                bool dropped = false;
                for (int i = Nm1; i > 0; i--)
                {
                    if ((matrix[i][j] == ' ') && (matrix[i - 1][j] != ' '))
                    {
                        matrix[i][j] = matrix[i - 1][j];
                        matrix[i - 1][j] = ' ';
                        dropped = true;
                    }
                }
                if (!dropped)
                {
                    j++;
                }
            }
        }

        static void WriteMatrix(char[][] matrix)
        {
            int N = matrix.Length;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write($"{matrix[i][j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------");
        }

        static void Pop(int i, int j, char[][] matrix, bool topLevel = false)
        {
            int N = matrix.Length;
            if ((i < 0) || (i >= N) || (j < 0) || (j >= N))
            {
                return;
            }

            char ch = matrix[i][j];
            matrix[i][j] = ' ';

            int Nm1 = N - 1;
            if ((i > 0) && (matrix[i - 1][j] == ch))
            {
                Pop(i - 1, j, matrix);
            }
            if ((i < Nm1) && (matrix[i + 1][j] == ch))
            {
                Pop(i + 1, j, matrix);
            }
            if ((j > 0) && (matrix[i][j - 1] == ch))
            {
                Pop(i, j - 1, matrix);
            }
            if ((j < Nm1) && (matrix[i][j + 1] == ch))
            {
                Pop(i, j + 1, matrix);
            }

            if (topLevel)
            {
                Drop(matrix);
            }
        }

        static void Main(string[] args)
        {
            char[][] matrix = new char[3][];
            matrix[0] = new char[] { 'B', 'R', 'R' };
            matrix[1] = new char[] { 'B', 'G', 'B' };
            matrix[2] = new char[] { 'B', 'B', 'B' };

            WriteMatrix(matrix);
            Pop(0, 0, matrix, true);
            WriteMatrix(matrix);
        }
    }
#endif
