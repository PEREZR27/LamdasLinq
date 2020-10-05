using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdasLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string> FirstStrn = () => "Hello World";
            Func<int, int> AddOne = i => i + 1;
            Func<int, int, int> RaisePower = (a, b) => (int)Math.Pow(a, b);
            Func<int, int, int> AddInt = (a, b) => a + b;
            Func<string, string, string> ConcatStrn = (a, b) => b + a;

            var num = Enumerable.Range(1, 10).ToList();
            List<string> sl = Enumerable.Range(65, 26).ToList().ConvertAll(i => ((char)i).ToString());

            num.ForEach(i => Console.Write($"{AddOne(i)} "));
            Console.WriteLine(); 
            num.Select(x => x + 1).ToList().ForEach(i => Console.Write($"{i} "));
            Console.WriteLine();

            num.ForEach(i => Console.Write($"{RaisePower(i, 2)} "));
            Console.WriteLine(); 
            num.Select(x => RaisePower(x, 2)).ToList().ForEach(x => Console.Write($"{x} "));
            Console.WriteLine();

            int sum = 0;
            num.ForEach(i => sum = AddInt(sum, i));
            Console.WriteLine(sum);
            int sumOne = num.Aggregate((result, next) => result + next);
            Console.WriteLine(sumOne);

            Console.WriteLine(String.Join("", sl.ToArray()));
            string one = "";
            sl.ForEach(i => one = ConcatStrn(i, one));
            Console.WriteLine(one);
            Console.WriteLine(sl.Aggregate((result, next) => result + next));

            Func<int, int, int> tertrate = null;
            tertrate = (a, b) => b == 1 ? a : RaisePower(a, tertrate(a, b - 1));
            Console.WriteLine(tertrate(2, 4));
        }
    }
}