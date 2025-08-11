public class EternalGoal : Goal
{
    private int _streakCount;

    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _streakCount = 0;
    }

    public override int RecordEvent()
    {
        _streakCount++;
        return _points + (_streakCount % 7 == 0 ? 50 : 0); 
    }

    public override string GetStatus()
    {
        return $"[∞] {_name} - {_description} | Streak: {_streakCount}";
    }

    public override string Serialize()
    {
        return $"EternalGoal|{_name}|{_description}|{_points}|{_completed}|{_streakCount}";
    }

    public static EternalGoal Deserialize(string[] parts)
    {
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);
        bool completed = bool.Parse(parts[4]);
        int streakCount = int.Parse(parts[5]);

        var goal = new EternalGoal(name, description, points);
        goal._completed = completed;
        goal._streakCount = streakCount;

        return goal;
    }
}
