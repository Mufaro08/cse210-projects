using System;

class Program
{
    static void Main(string[] args)
    {

        //Number 1
        Console.Write("Enter the magic number: ");
        int magicNumber = int.Parse(Console.ReadLine());

        Console.Write("What is your guess? ");
        int guess = int.Parse(Console.ReadLine());

        if (guess < magicNumber)
        {
            Console.WriteLine("Higher");
        }
        else if (guess > magicNumber)
        {
            Console.WriteLine("Lower");
        }
        else
        {
            Console.WriteLine("You guessed it!");
        }



        //Number 2

        Console.Write("Enter the magic number: ");
        int magicNumber2 = int.Parse(Console.ReadLine());

        int guess2 = -1; // Initialize with a value that won't match the magic number

        // Step 2: Keep asking for guesses until correct
        while (guess2 != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess2 = int.Parse(Console.ReadLine());

            if (guess2 < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess2 > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }

        //Number 3
        Random randomGenerator = new Random();
        int magicNumber3 = randomGenerator.Next(1, 101);

        int guess3 = -1000000000;

        Console.WriteLine("Guess the magic number between 1 and 100!");

        while (guess3 != magicNumber3)
        {
            Console.Write("What is your guess? ");
            guess3 = int.Parse(Console.ReadLine());

            if (guess3 < magicNumber3)
            {
                Console.WriteLine("Higher");
            }
            else if (guess3 > magicNumber3)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }

        // Stretch 1
        Random randomGenerator1 = new Random();
        int magicNumber4 = randomGenerator.Next(1, 101);

        int guess4 = -1000000000;
        int attempts = 0;

        Console.WriteLine("Guess the magic number between 1 and 100!");

        while (guess4 != magicNumber4)
        {
            Console.Write("What is your guess? ");
            guess4 = int.Parse(Console.ReadLine());
            attempts++;

            if (guess4 < magicNumber4)
            {
                Console.WriteLine("Higher");
            }
            else if (guess4 > magicNumber4)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }

        //Stretch 2
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            Random randomGenerator5 = new Random();
            int magicNumber5 = randomGenerator.Next(1, 101);
            int guess5 = -1;
            int guessCount = 0;

            Console.WriteLine("Guess the magic number between 1 and 100!");

            while (guess5 != magicNumber5)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess5< magicNumber5)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess5 > magicNumber5)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {guessCount} guess(es).");
                }
            }

            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        }

        Console.WriteLine("Thanks for playing!");



    }
}