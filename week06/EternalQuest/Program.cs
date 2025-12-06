using System;

class Program
{
    // Creativity Exceeded Requirements:
    // 1. Leveling System: Players gain levels based on total score (1000 points per level)
    // 2. Achievement System: Players earn badges like "Goal Master" (5+ completed goals) and "High Scorer" (5000+ points)
    // 3. Bad Habit Goals: Negative goals that deduct points when recorded, helping track bad habits
    // 4. Enhanced UI: Shows current level and achievements in the main menu

    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            DisplayStatus(manager);
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Record Bad Habit");
            Console.WriteLine("  7. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(manager);
                    break;
                case "2":
                    manager.DisplayGoals();
                    break;
                case "3":
                    Console.Write("What is the filename for the goal file? ");
                    string saveFile = Console.ReadLine();
                    manager.SaveGoals(saveFile);
                    break;
                case "4":
                    Console.Write("What is the filename for the goal file? ");
                    string loadFile = Console.ReadLine();
                    manager.LoadGoals(loadFile);
                    break;
                case "5":
                    RecordEvent(manager);
                    break;
                case "6":
                    RecordBadHabit(manager);
                    break;
                case "7":
                    running = false;
                    break;
            }
        }
    }

    static void DisplayStatus(GoalManager manager)
    {
        Console.WriteLine($"\nYou have {manager.GetScore()} points.");
        Console.WriteLine($"Current Level: {manager.GetLevel()}");

        List<string> achievements = manager.GetAchievements();
        if (achievements.Count > 0)
        {
            Console.WriteLine("Achievements: " + string.Join(", ", achievements));
        }
        Console.WriteLine();
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Bad Habit Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Goal goal = null;

        if (type == "1")
        {
            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());
            goal = new SimpleGoal(name, description, points);
        }
        else if (type == "2")
        {
            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());
            goal = new EternalGoal(name, description, points);
        }
        else if (type == "3")
        {
            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int targetCount = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonusPoints = int.Parse(Console.ReadLine());
            goal = new ChecklistGoal(name, description, points, targetCount, bonusPoints);
        }
        else if (type == "4")
        {
            Console.Write("What is the penalty for this bad habit? ");
            int penalty = int.Parse(Console.ReadLine());
            goal = new BadHabitGoal(name, description, penalty);
        }

        if (goal != null)
        {
            manager.AddGoal(goal);
        }
    }

    static void RecordEvent(GoalManager manager)
    {
        manager.DisplayGoals();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;
        manager.RecordEvent(index);
    }

    static void RecordBadHabit(GoalManager manager)
    {
        List<Goal> goals = manager.GetGoals();
        Console.WriteLine("Bad Habit Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            if (goals[i] is BadHabitGoal)
            {
                Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
            }
        }
        Console.Write("Which bad habit did you commit? ");
        int index = int.Parse(Console.ReadLine()) - 1;
        manager.RecordBadHabit(index);
    }
}