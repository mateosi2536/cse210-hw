using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private List<string> _achievements;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
        _achievements = new List<string>();
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            Goal goal = _goals[index];
            goal.RecordEvent();
            int pointsEarned = goal.GetPoints() + goal.GetBonus();
            _score += pointsEarned;

            CheckLevelUp();
            CheckAchievements();
        }
    }

    public void RecordBadHabit(int index)
    {
        if (index >= 0 && index < _goals.Count && _goals[index] is BadHabitGoal)
        {
            BadHabitGoal badGoal = (BadHabitGoal)_goals[index];
            badGoal.RecordEvent();
            _score -= badGoal.GetPenalty();
            if (_score < 0) _score = 0;
        }
    }

    private void CheckLevelUp()
    {
        int newLevel = (_score / 1000) + 1;
        if (newLevel > _level)
        {
            _level = newLevel;
            _achievements.Add($"Reached Level {_level}!");
        }
    }

    private void CheckAchievements()
    {
        int completedGoals = 0;
        foreach (Goal goal in _goals)
        {
            if (goal.IsComplete()) completedGoals++;
        }

        if (completedGoals >= 5 && !_achievements.Contains("Goal Master"))
        {
            _achievements.Add("Goal Master");
        }

        if (_score >= 5000 && !_achievements.Contains("High Scorer"))
        {
            _achievements.Add("High Scorer");
        }
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public int GetScore()
    {
        return _score;
    }

    public int GetLevel()
    {
        return _level;
    }

    public List<string> GetAchievements()
    {
        return _achievements;
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            outputFile.WriteLine(_level);
            outputFile.WriteLine(string.Join(",", _achievements));
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals(string filename)
    {
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _level = int.Parse(lines[1]);
            _achievements = new List<string>(lines[2].Split(","));

            for (int i = 3; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(":");
                string type = parts[0];
                string[] data = parts[1].Split(",");

                Goal goal = null;
                if (type == "SimpleGoal")
                {
                    goal = new SimpleGoal(data[0], data[1], int.Parse(data[2]));
                    if (bool.Parse(data[3]))
                    {
                        goal.RecordEvent();
                    }
                }
                else if (type == "EternalGoal")
                {
                    goal = new EternalGoal(data[0], data[1], int.Parse(data[2]));
                }
                else if (type == "ChecklistGoal")
                {
                    goal = new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]));
                    for (int j = 0; j < int.Parse(data[5]); j++)
                    {
                        goal.RecordEvent();
                    }
                }
                else if (type == "BadHabitGoal")
                {
                    goal = new BadHabitGoal(data[0], data[1], int.Parse(data[2]));
                }

                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }
        }
    }

    public List<Goal> GetGoals()
    {
        return _goals;
    }
}
