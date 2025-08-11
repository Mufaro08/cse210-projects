using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== Eternal Quest ===");
            Console.WriteLine($"Score: {manager.Score} | Level: {manager.Level} {manager.Title}");
            manager.DisplayXPBar();

            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Show Goals");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Exit");

            Console.Write("\nSelect option: ");
            switch (Console.ReadLine())
            {
                case "1":
                    manager.CreateGoal();
                    break;
                case "2":
                    manager.RecordGoalEvent();
                    break;
                case "3":
                    manager.DisplayGoals();
                    Console.ReadKey();
                    break;
                case "4":
                    manager.SaveData("goals.json");
                    break;
                case "5":
                    manager.LoadData("goals.json");
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}

