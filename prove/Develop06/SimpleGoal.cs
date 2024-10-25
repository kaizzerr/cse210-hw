using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;
    public SimpleGoal(string _shortName, string _description, int _points) 
    : base (_shortName, _description, _points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"Congratulations! You have earned {_points} points!");
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {_shortName} - {_description}";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal: {_shortName},{_description},{_points},{_isComplete}";
    }
}