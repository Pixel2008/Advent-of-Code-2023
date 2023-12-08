namespace AOC_01
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new PartOne();
            var result1 = p1.Handle();

            Console.WriteLine($"Result: {result1}");


            var p2 = new PartTwo();
            var result2 = p2.Handle();

            Console.WriteLine($"Result: {result2}");
        }
    }
}
