using System;

class Program
{
    static void Main(string[] args)
    {
        // Welcome message
        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine("Press Enter to begin...");
        Console.ReadLine();

        // Create a reference and a scripture
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string scriptureText = "Trust in the Lord with all thine heart; and lean not unto thine own understanding.";
        Scripture scripture = new Scripture(reference, scriptureText);

        // Loop until all words are hidden or user types "quit"
        while (true)
        {
           // Console.Clear();
            scripture.Display();

            Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords();

            if (scripture.AllWordsHidden())
            {
                Console.Clear();
                scripture.Display();
                Console.WriteLine("All words are hidden. Good job!");
                break;
            }
        }

        Console.WriteLine("Thanks for using the Scripture Memorizer!");
    }
}
