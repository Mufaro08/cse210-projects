using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    public int Score { get; private set; }
    public int XP { get; private set; }
    public int Level { get; private set; }
    public string Title => Titles[Math.Min(Level / 5, Titles.Length - 1)];

    private List<Goal> _goals = new List<Goal>();
    private static readonly string[] Titles = {
        "Novice Adventurer", "Skilled Explorer", "Heroic Paladin",
        "Master Wizard", "Level 13 Ninja Unicorn", "Legendary Sage"
    };

    public void CreateGoal()
    {
        Console.WriteLine("\nChoose Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal");

        switch (Console.ReadLine())
        {
            case "1":
                Console.Write("Name: "); string sName = Console.ReadLine();
                Console.Write("Description: "); string sDesc = Console.ReadLine();
                Console.Write("Points: "); int sPts = int.Parse(Console.ReadLine());
                _goals.Add(new SimpleGoal(sName, sDesc, sPts));
                break;
            case "2":
                Console.Write("Name: "); string eName = Console.ReadLine();
                Console.Write("Description: "); string eDesc = Console.ReadLine();
                Console.Write("Points per record: "); int ePts = int.Parse(Console.ReadLine());
                _goals.Add(new EternalGoal(eName, eDesc, ePts));
                break;
            case "3":
                Console.Write("Name: "); string cName = Console.ReadLine();
                Console.Write("Description: "); string cDesc = Console.ReadLine();
                Console.Write("Points per step: "); int cPts = int.Parse(Console.ReadLine());
                Console.Write("Target count: "); int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus points: "); int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(cName, cDesc, cPts, target, bonus));
                break;
            case "4":
                Console.Write("Name: "); string nName = Console.ReadLine();
                Console.Write("Description: "); string nDesc = Console.ReadLine();
                Console.Write("Penalty points: "); int nPts = int.Parse(Console.ReadLine());
                _goals.Add(new NegativeGoal(nName, nDesc, nPts));
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    public void RecordGoalEvent()
    {
        DisplayGoals();
        Console.Write("\nEnter goal number: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _goals.Count)
        {
            int points = _goals[index - 1].RecordEvent();
            Score += points;
            XP += Math.Max(points, 0);

            CheckBadges();
            CheckLevelUp();

            Console.WriteLine(points >= 0
                ? $"You earned {points} points!"
                : $"You lost {-points} points!");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
        Console.ReadKey();
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\nGoals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
        }
    }

    public void DisplayXPBar()
    {
        int xpForNextLevel = 100;
        int filled = (int)((double)(XP % xpForNextLevel) / xpForNextLevel * 20);
        Console.Write("XP: [");
        Console.Write(new string('#', filled));
        Console.Write(new string('-', 20 - filled));
        Console.WriteLine($"] {XP % xpForNextLevel}/{xpForNextLevel}");
    }

    private void CheckLevelUp()
    {
        while (XP >= (Level + 1) * 100)
        {
            Level++;
            Console.WriteLine($"\n*** LEVEL UP! You are now Level {Level} {Title}! ***");
        }
    }

    private void CheckBadges()
    {
        foreach (var goal in _goals)
        {
            if (goal is EternalGoal eg && eg.GetStatus().Contains("Streak: 30"))
            {
                Console.WriteLine("*** Badge Earned: Scripture Scholar! ***");
            }
        }
    }

    public void SaveData(string filename)
    {
        using StreamWriter writer = new StreamWriter(filename);
        writer.WriteLine($"{Score}|{XP}|{Level}");
        foreach (var goal in _goals)
        {
            writer.WriteLine(goal.Serialize());
        }
        Console.WriteLine("Data saved.");
        Console.ReadKey();
    }

    public void LoadData(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("No save file found.");
            Console.ReadKey();
            return;
        }

        using StreamReader reader = new StreamReader(filename);
        var firstLine = reader.ReadLine();
        if (firstLine == null) return;

        var parts = firstLine.Split('|');
        if (parts.Length == 3)
        {
            Score = int.Parse(parts[0]);
            XP = int.Parse(parts[1]);
            Level = int.Parse(parts[2]);
        }

        _goals.Clear();
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            var goal = Goal.Deserialize(line);
            if (goal != null)
            {
                _goals.Add(goal);
            }
        }
        Console.WriteLine("Data loaded.");
        Console.ReadKey();
    }
}
