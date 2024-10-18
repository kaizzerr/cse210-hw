using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    : base("Breathing Activity", "This activity will help you relax by walking you through your breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        ShowSpinner(3);
        
        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        Console.Write("Breathe in... ");
        ShowCountDown(2);
        Console.WriteLine();

        Console.Write("Now Breathe out... ");
        ShowCountDown(3);
        Console.WriteLine();

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in... ");
            ShowCountDown(5);
            Console.WriteLine();
            if (DateTime.Now >= endTime) break;

            Console.Write("Now Breathe out... ");
            ShowCountDown(5);
            Console.WriteLine();
            if (DateTime.Now >= endTime) break;
        }

        DisplayEndingMessage();
        
    }
}