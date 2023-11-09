using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program pr = new Program();
            List<int> nums = new List<int>();

            pr.ReadFile(nums);

            foreach(int i in nums)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();


            var longestSequenceLength = nums
                .AsParallel()
                .Aggregate(
                    new { Max = 0, Current = 0, Previous = nums.Min() },
                    (a, x) => x > a.Previous
                        ? new { Max = a.Max > a.Current + 1 ? a.Max : a.Current + 1, Current = a.Current + 1, Previous = x }
                        : new { Max = a.Max, Current = 0, Previous = nums.Min() })
                .Max + 1;

            Console.WriteLine($"Длина наибольшей возростающей последовательности: {longestSequenceLength}");
        }
        void ReadFile(List<int> arr)
        {
            using (FileStream fs = new FileStream(@"..\..\nums.txt", FileMode.Open))
            {
                using(StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        arr.Add(Int32.Parse(sr.ReadLine()));
                    }
                }
            }
        }
    }
}
