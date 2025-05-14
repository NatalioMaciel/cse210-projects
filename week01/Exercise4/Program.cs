using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numberList = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        Console.Write("Enter a number: ");
        int numbers = int.Parse(Console.ReadLine());

        while (numbers != 0)
        {
            numberList.Add(numbers);
            Console.Write("Enter a number: ");
            numbers = int.Parse(Console.ReadLine());

        }

        int sumNumbers = numberList.Sum();
        double average = Queryable.Average(numberList.AsQueryable());
        int largest = numberList.Max();


        Console.WriteLine($"Te sum is: {sumNumbers}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
    }
}