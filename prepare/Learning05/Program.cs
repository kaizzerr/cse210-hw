using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment("Kaizzer Gatan", "C++");
        Console.WriteLine(a1.GetSummary());

        MathAssignment a2 = new MathAssignment("Richard Reyes", "Chemistry", "2.1", "10-30");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Sunny Roberts", "Social Studies", "Canadian Heritage");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}