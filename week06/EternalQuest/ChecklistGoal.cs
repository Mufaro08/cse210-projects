public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = 0;
    }

    public override int RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
            if (_currentCount == _targetCount)
            {
                _completed = true;
                return _points + _bonusPoints;
            }
            return _points;
        }
        return 0;
    }

    public override string GetStatus()
    {
        return $"[{(_completed ? "X" : " ")}] {_name} - {_description} ({_currentCount}/{_targetCount})";
    }

    public override string Serialize()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_completed}|{_targetCount}|{_currentCount}|{_bonusPoints}";
    }

    public static ChecklistGoal Deserialize(string[] parts)
    {
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);
        bool completed = bool.Parse(parts[4]);
        int targetCount = int.Parse(parts[5]);
        int currentCount = int.Parse(parts[6]);
        int bonusPoints = int.Parse(parts[7]);

        var goal = new ChecklistGoal(name, description, points, targetCount, bonusPoints);
        goal._completed = completed;
        goal._currentCount = currentCount;

        return goal;
    }
}
