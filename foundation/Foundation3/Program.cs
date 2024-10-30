using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running("28 October 2024", 60, 7),
            new Cycling("29 October 2024", 60, 50.0),
            new Swimming("30 October 2024", 60, 30)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}