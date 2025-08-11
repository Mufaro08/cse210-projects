public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _completed;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _completed = false;
    }

    public abstract int RecordEvent();
    public abstract string GetStatus();

    public bool IsCompleted() => _completed;

    public abstract string Serialize();

    public static Goal? Deserialize(string line)
    {
        var parts = line.Split('|');
        if (parts.Length == 0) return null;

        string type = parts[0];

        try
        {
            return type switch
            {
                "SimpleGoal" => SimpleGoal.Deserialize(parts),
                "EternalGoal" => EternalGoal.Deserialize(parts),
                "ChecklistGoal" => ChecklistGoal.Deserialize(parts),
                "NegativeGoal" => NegativeGoal.Deserialize(parts),
                _ => null,
            };
        }
        catch
        {
            return null; 
        }
    }
}
