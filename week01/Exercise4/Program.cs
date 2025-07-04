using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int input = -1;

        Console.WriteLine("Enter a series of numbers (enter 0 to finish):");

        while (input != 0)
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());

            if (input != 0)
            {
                numbers.Add(input);
            }
        }

        int sum = numbers.Sum();
        double average = numbers.Average();
        int max = numbers.Max();

        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Average: {average}");
        Console.WriteLine($"Maximum: {max}");

        // Stretch 1 and 2
        List<int> numbers1 = new List<int>();
        int input1 = -1;

        Console.WriteLine("Enter a series of numbers (positive or negative). Enter 0 to finish:");

        while (input1 != 0)
        {
            Console.Write("Enter number: ");
            input1 = int.Parse(Console.ReadLine());

            if (input1 != 0)
            {
                numbers1.Add(input1);
            }
        }

        int sum1 = numbers1.Sum();
        double average1 = numbers1.Average();
        int max1 = numbers1.Max();

        int smallestPositive = numbers1.Where(n => n > 0).DefaultIfEmpty().Min();

        numbers1.Sort();

        Console.WriteLine($"\nSum: {sum1}");
        Console.WriteLine($"Average: {average1}");
        Console.WriteLine($"Maximum: {max1}");

        if (smallestPositive > 0)
        {
            Console.WriteLine($"Smallest positive number: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("No positive numbers were entered.");
        }

        Console.WriteLine("Sorted list:");
        foreach (int num1 in numbers1)
        {
            Console.WriteLine(num1);
        }

    }
}