using System;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void SetDuration(int duration)
    {
        _duration = duration;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name}");
        Console.WriteLine(_description);
        Console.Write("How long, in seconds, would you like for your session? ");
        SetDuration(int.Parse(Console.ReadLine()));

        Console.Clear();
        Console.WriteLine("Get ready...");
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!!!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed {_duration} seconds of the {_name} activity.");
        ShowSpinner(10);
    }

    public void ShowSpinner(int seconds)
    {
        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");

        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(animationStrings[i % animationStrings.Count]);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            i++;

            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
            {
                break;
            }
        }
        Console.WriteLine();
    }

    public void ShowCountDown(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int remainingSeconds = seconds;

        while (remainingSeconds > 0 && DateTime.Now < endTime)
        {
            Console.Write($"{remainingSeconds}");
            Thread.Sleep(1000);
            Console.Write("\b \b");

            remainingSeconds--;

            if (DateTime.Now >= endTime)
            {
                break;
            }
        }
    }
}