using System;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;
    private int _level;
    private int _levelUp = 1000;
    public int score => _score;
    public int level => _level;

    public GoalManager()
    {
        _score = 0;
        _level = 1;
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You are level {_level}");
        Console.WriteLine($"You have {_score} points");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The type of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Which type of goal would you like to create? ");
        int goalTypeChoice = int.Parse(Console.ReadLine());

        Console.Write("What is the name of your goal? ");
        string shortName = Console.ReadLine();

        Console.Write("What is a short description for it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points connected to this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (goalTypeChoice == 1)
        {
            _goals.Add(new SimpleGoal(shortName, description, points));
        }
        else if (goalTypeChoice == 2)
        {
            _goals.Add(new EternalGoal(shortName, description, points));
        }
        else if (goalTypeChoice == 3)
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(shortName, description, points, target, bonus));
        }
    }

    public void RecordEvent()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.Write("What goal did you accomplish? ");
        int goalIndex = int.Parse(Console.ReadLine());

        if (goalIndex > 0 && goalIndex <= _goals.Count)
        {
            var selectedGoal = _goals[goalIndex - 1];
            int pointsEarned = selectedGoal.points;

            selectedGoal.RecordEvent();

            if (selectedGoal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                pointsEarned += checklistGoal.bonus;
            }

            _score += pointsEarned;
            LevelingUp();
            Console.WriteLine($"You now have {_score} total points.");
        }
    }

    private void LevelingUp()
    {
        if (_score >= _levelUp * _level)
        {
            _level++;
            Console.WriteLine($"Congratulations! You reached level {_level}!");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            writer.WriteLine(_level);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("There is no file with the given name.");
            return;
        }

        _goals.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            if (int.TryParse(reader.ReadLine(), out int savedScore))
            {
                _score = savedScore;
            }

            if (int.TryParse(reader.ReadLine(), out int savedLevel))
            {
                _level = savedLevel;
            }

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(new[] { ':', ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(p => p.Trim())
                            .ToArray();

                string goalType = parts[0];
                string shortName = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                Goal goal = null;

                if (goalType == "SimpleGoal")
                {
                    bool isComplete = bool.Parse(parts[4]);
                    var simpleGoal = new SimpleGoal(shortName, description, points);
                    if (isComplete) simpleGoal.RecordEvent();
                    goal = simpleGoal;
                }
                else if (goalType == "EternalGoal")
                {
                    goal = new EternalGoal(shortName, description, points);
                }
                else if (goalType == "ChecklistGoal")
                {
                    int amountCompleted = int.Parse(parts[4]);
                    int target = int.Parse(parts[5]);
                    int bonus = int.Parse(parts[6]);
                    var checklistGoal = new ChecklistGoal(shortName, description, points, target, bonus);
                    for (int i = 0; i < amountCompleted; i++) checklistGoal.RecordEvent();
                    goal = checklistGoal;
                }
                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }
        }
    }
}