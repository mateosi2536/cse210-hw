using System;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _isComplete;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = false;
    }

    public abstract void RecordEvent();

    public abstract string GetStringRepresentation();

    public virtual string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {_name} ({_description})";
    }

    public string GetName()
    {
        return _name;
    }

    public int GetPoints()
    {
        return _points;
    }

    public bool IsComplete()
    {
        return _isComplete;
    }

    public virtual int GetBonus()
    {
        return 0;
    }
}
