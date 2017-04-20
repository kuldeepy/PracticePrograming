using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePrograming
{
    class Program
    {
        static void Main(string[] args)
        {
            CanYouSort();
            //StringSimilarity();
            //var test = TestDictionary();
            //int i = 10;
            //i.ToString();

            //PlusMinus();
            //CircularArrayRotation();
            //Console.WriteLine("Welcome to Program Practice");
            //int choice = Menu();
            //PerformOperation(choice);
            Console.ReadKey();
        }

        private static void CanYouSort()
        {
            int size = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            List<int[]> list = new List<int[]>();
            var duplicates = arr.GroupBy(s => s).Where(x => x.Count() > 1).Select(i=>i.Key).ToArray();

            var uinqueElement = arr.Except(duplicates).ToArray();
            list.Add(uinqueElement);
            var inter=arr.Intersect(duplicates).ToArray();
            foreach (var item in duplicates)
            {
                var slicedArray = arr.Where(i => i == item).ToArray();
                list.Add(slicedArray);
            }
            Console.WriteLine("Sorted array is here");
            foreach (var e in list)
            {
                var orderedArray = e.OrderBy(p => p).ToArray();
                foreach (var w in orderedArray)
                {
                    Console.WriteLine(w);
                }

            }

        }

        private static void StringSimilarity()
        {
            /* Tail starts here */
            int res;
            int _t_cases = Convert.ToInt32(Console.ReadLine());
            for (int _t_i = 0; _t_i < _t_cases; _t_i++)
            {
                String _a = Console.ReadLine();
                res = stringSimilarity(_a);
                Console.WriteLine(res);
            }
        }
        static int stringSimilarity(string a)
        {
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                var substring = a.Substring(i);
                count += CountSimilarChar(a, substring);
            }
            return count;
        }
        public static int CountSimilarChar(string a, string s)
        {
            int count = 0;
            if (a.Contains(s))
            {
                for (int i = 0; i < a.Length && i < s.Length; i++)
                {
                    if (a[i] == s[i])
                    {
                        ++count;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return count;

        }

        private static List<string> TestDictionary()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("key1", "value1");
            dic.Add("key2", "value2");
            dic.Add("key3", "value3");
            dic.Add("key4", "value4");
            //var list = dic.Select(e => e.Value).ToList();
            var list = (from d in dic
                        select d.Value).ToList();
            return list;
        }

        private static void CircularArrayRotation()
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            int q = Convert.ToInt32(tokens_n[2]);
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);

            for (int i = 0; i < k; i++)
            {
                RotateArray(n, ref a);
            }
            for (int a0 = 0; a0 < q; a0++)
            {
                int m = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(a[m]);
            }
        }

        private static void RotateArray(int n, ref int[] a)
        {
            int[] rotatedArray = new int[n];
            for (int j = 0; j < n; j++)
            {
                if (j == 0)
                {
                    rotatedArray[j] = a[n - 1];
                }
                else
                {
                    rotatedArray[j] = a[j - 1];
                }
            }
            a = rotatedArray;
        }

        private static void PlusMinus()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
            int positiveNumber = 0, negativeNumber = 0, zeroNumber = 0;
            double fractionPositive = 0.0, fractionNegative = 0.0, fractionZero = 0.0;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] > 0)
                {
                    positiveNumber++;
                }
                if (arr[i] < 0)
                {
                    negativeNumber++;
                }
                if (arr[i] == 0)
                {
                    zeroNumber++;
                }
            }
            if (positiveNumber > 0)
                fractionPositive = (double)positiveNumber / n;
            if (positiveNumber > 0)
                fractionNegative = (double)negativeNumber / n;
            if (positiveNumber > 0)
                fractionZero = (double)zeroNumber / n;
            Console.WriteLine(string.Format("{0:0.000000}", fractionPositive));
            Console.WriteLine(string.Format("{0:0.000000}", fractionNegative));
            Console.WriteLine(string.Format("{0:0.000000}", fractionZero));
        }

        private static void PerformOperation(int choice)
        {
            switch (choice)
            {
                case 1:
                    InsertionSort();
                    break;
                default:
                    Console.WriteLine("Please select valid option.");
                    break;
            }
        }

        private static void InsertionSort()
        {
            Console.WriteLine("Enter the size of array you want sort.");
            int _ar_size;
            _ar_size = Convert.ToInt32(Console.ReadLine());
            int[] _ar = new int[_ar_size];
            String elements = Console.ReadLine();
            String[] split_elements = elements.Split(' ');
            for (int _ar_i = 0; _ar_i < _ar_size; _ar_i++)
            {
                _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]);
            }

            InsertionSorting(_ar);
        }

        private static void InsertionSorting(int[] arr)
        {
            int item = FindSmallentItemAndPosition(arr);
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                int temp = arr[i];
                if (arr[i] >= item)
                {
                    if (i != arr.Length - 1 && i != 0)
                    {
                        arr[i + 1] = temp;
                        PrintArray(arr);
                    }
                    else
                    {
                        if (i == 0 && item < arr[i + 1])
                        {
                            arr[i + 1] = temp;
                            PrintArray(arr);
                            arr[i] = item;
                            PrintArray(arr);
                        }
                    }

                }

                if (arr[i] < item)
                {
                    if (i != arr.Length - 1)
                    {
                        if (arr[i + 1] > item && i == 0 && item < arr[i])
                        {

                            arr[i + 1] = temp;
                            PrintArray(arr);
                            arr[i] = item;

                        }
                        else
                        {
                            if (arr[i + 1] > item)
                            {
                                arr[i + 1] = item;
                                PrintArray(arr);
                            }


                        }

                    }

                }

            }

        }

        private static void PrintArray(int[] arr)
        {
            string joinArray = string.Join(" ", arr);
            Console.WriteLine(joinArray);
        }

        private static int FindSmallentItemAndPosition(int[] arr)
        {
            int result = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        result = arr[j];
                    }
                }
            }
            return result;
        }

        private static int Menu()
        {
            int choice = 0;
            Console.WriteLine("Choose the Option given below");
            Console.WriteLine("1. Insertion Sort(Press 1 for this)");
            choice = Convert.ToInt32(Console.ReadLine());
            return choice;


        }
    }
}
