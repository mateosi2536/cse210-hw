using System;

public class BadHabitGoal : Goal
{
    private int _penalty;

    public BadHabitGoal(string name, string description, int penalty) : base(name, description, 0)
    {
        _penalty = penalty;
    }

    public override void RecordEvent()
    {
    }

    public override string GetStringRepresentation()
    {
        return $"BadHabitGoal:{_name},{_description},{_penalty}";
    }

    public override string GetDetailsString()
    {
        return $"[!] {_name} ({_description}) - Penalty: {_penalty} points";
    }

    public int GetPenalty()
    {
        return _penalty;
    }
}
