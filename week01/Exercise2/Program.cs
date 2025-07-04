using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        int gradePercentage = int.Parse(Console.ReadLine());

        if (gradePercentage >= 90)
        {
            Console.WriteLine("A");
        }

        else if (gradePercentage >= 80)
        {
            Console.WriteLine("B");
        }
        else if (gradePercentage >= 70)
        {
            Console.WriteLine("C");
        }
        else if (gradePercentage >= 60)
        {
            Console.WriteLine("D");
        }
        else
        {
            Console.WriteLine("F");
        }

        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations, you passed!");
        }
        else
        {
            Console.WriteLine("Unfortunately, you did not pass. Better luck next time!");
        }




        //Number 3 and stretch 1
        string Letter = " ";

        if (gradePercentage >= 90)
        {
            Letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            Letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            Letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            Letter = "D";
        }
        else
        {
            Letter = "F";
        }

        if (gradePercentage >= 60 && gradePercentage <94)
{
    int lastDigit = gradePercentage % 10;

    if (lastDigit >= 7)
    {
        Letter += "+";
    }
    else if (lastDigit < 3)
    {
        Letter += "-";
    }
}

        Console.WriteLine($"Your letter grade is: {Letter}");


    }
}