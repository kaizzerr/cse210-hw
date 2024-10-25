using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine($"\nYou have {goalManager.score} points");
            Console.WriteLine($"You are level {goalManager.level}");
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine(" 1. Create a new goal");
            Console.WriteLine(" 2. List goals");
            Console.WriteLine(" 3. Record an event");
            Console.WriteLine(" 4. Show player info");
            Console.WriteLine(" 5. Save goals");
            Console.WriteLine(" 6. Load goals");
            Console.WriteLine(" 7. Quit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                goalManager.CreateGoal();
            }
            else if (choice == "2")
            {
                goalManager.ListGoalNames();
            }
            else if (choice == "3")
            {
                goalManager.RecordEvent();
            }
            else if (choice == "4")
            {
                goalManager.DisplayPlayerInfo();
            }
            else if (choice == "5")
            {
                goalManager.SaveGoals();
            }
            else if (choice == "6")
            {
                goalManager.LoadGoals();
            }
            else if (choice == "7")
            {
                exit = true;
            }
        }
    }
}