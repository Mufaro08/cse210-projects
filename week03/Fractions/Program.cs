using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Fractions Project.");

        Fraction fraction1 = new Fraction();
        Console.WriteLine($"Default Fraction: {fraction1.GetFractionString()}");
        Console.WriteLine($"Default Fraction: {fraction1.GetDecimalValue()}");

        Fraction fraction2 = new Fraction(5);
        Console.WriteLine($"Whole Number Fraction: {fraction2.GetFractionString()}");
        Console.WriteLine($"Whole Number Fraction: {fraction2.GetDecimalValue()}");

        Fraction fraction3 = new Fraction(3, 4);
        Console.WriteLine($"Fraction with Top and Bottom: {fraction3.GetFractionString()}");
        Console.WriteLine($"Fraction with Top and Bottom: {fraction3.GetDecimalValue()}");

        Fraction fraction4 = new Fraction(1, 3);
        Console.WriteLine($"Another Fraction: {fraction4.GetFractionString()}");
        Console.WriteLine($"Another Fraction: {fraction4.GetDecimalValue()}");


    }
}