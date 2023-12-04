namespace AOC_01
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            //var p1 = new PartOne();
            //var result = p1.Handle();

            var p2 = new PartTwo();
            var result = p2.Handle();

            Console.WriteLine($"Result: {result}");

            Console.ReadKey();
        }           
    }
}
