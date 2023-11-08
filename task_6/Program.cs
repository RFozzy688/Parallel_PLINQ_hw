﻿using System;
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
            List<int> array = new List<int>();

            pr.ReadFile(array);
            foreach(int i in array)
            {
                Console.Write(i + " ");
            }
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
