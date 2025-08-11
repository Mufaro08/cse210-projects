public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        if (!_completed)
        {
            _completed = true;
            return _points;
        }
        return 0;
    }

    public override string GetStatus()
    {
        return $"{_name} ({_description}) - Completed: {_completed}";
    }

    public override string Serialize()
    {
        return $"SimpleGoal|{_name}|{_description}|{_points}|{_completed}";
    }

    public static SimpleGoal Deserialize(string[] parts)
    {
        string name = parts[1];
        string desc = parts[2];
        int points = int.Parse(parts[3]);
        bool completed = bool.Parse(parts[4]);

        var goal = new SimpleGoal(name, desc, points);
        goal._completed = completed;
        return goal;
    }
}
