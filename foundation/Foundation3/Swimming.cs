using System;

public class Swimming : Activity
{
    private int _swimmingLaps;

    public Swimming(string date, double minutes, int swimmingLaps)
    : base(date, minutes)
    {
        _swimmingLaps = swimmingLaps;
    }

    public override double GetDistance()
    {
        return _swimmingLaps * 50 / 1000.0;
    }
}