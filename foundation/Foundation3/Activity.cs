using System;

public abstract class Activity
{
    private string _date;
    private double _minutes;

    public Activity(string date, double minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public abstract double GetDistance();

    public string GetDate()
    {
        return _date;
    }

    public virtual double GetMinutes()
    {
        return _minutes;
    }

    public virtual double GetSpeed()
    {
        return GetDistance() / GetMinutes() * 60;
    }

    public virtual double GetPace()
    {
        return GetMinutes() / GetDistance();
    }

    public string GetSummary()
    {
        return $"{_date} {GetType().Name} ({_minutes} min) - " +
               $"Distance: {GetDistance():0.0} km, " +
               $"Speed: {GetSpeed():0.0} kph, " +
               $"Pace: {GetPace():0.0} min per km";
    }
}