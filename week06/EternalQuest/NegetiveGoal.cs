public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent()
    {
        return -_points;
    }

    public override string GetStatus()
    {
        return $"[!] {_name} - {_description} (Lose {_points} pts)";
    }

    public override string Serialize()
    {
        return $"NegativeGoal|{_name}|{_description}|{_points}|{_completed}";
    }

    public static NegativeGoal Deserialize(string[] parts)
    {
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);
        bool completed = bool.Parse(parts[4]);

        var goal = new NegativeGoal(name, description, points);
        goal._completed = completed;
        return goal;
    }
}
