using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints) : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = 0;
    }

    public override void RecordEvent()
    {
        _currentCount++;
        if (_currentCount >= _targetCount)
        {
            _isComplete = true;
        }
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_name},{_description},{_points},{_targetCount},{_bonusPoints},{_currentCount}";
    }

    public override string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {_name} ({_description}) -- Currently completed: {_currentCount}/{_targetCount}";
    }

    public override int GetBonus()
    {
        if (IsComplete())
        {
            return _bonusPoints;
        }
        return 0;
    }

    public int GetCurrentCount()
    {
        return _currentCount;
    }
}
