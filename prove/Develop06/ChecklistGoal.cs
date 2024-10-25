using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;
    public int bonus => _bonus;

    public ChecklistGoal(string _shortName, string _description, int _points, int target, int bonus)
    : base(_shortName, _description, _points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
            
            if (_amountCompleted == _target)
            {
                Console.WriteLine($"Congratulations! You have earned {_points + _bonus} points!");
            }
            else
            {
                Console.WriteLine($"You have earned {_points} points.");
            }
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {_shortName} - {_description} -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_amountCompleted},{_target},{_bonus}";
    }
}