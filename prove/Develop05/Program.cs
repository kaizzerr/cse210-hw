using System;

class Program
{
    static void Main(string[] args)
    {
        int breathingLog = 0;
        int reflectingLog = 0;
        int listingLog = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Start Breathing Activity");
            Console.WriteLine(" 2. Start Reflecting Activity");
            Console.WriteLine(" 3. Start Listing Activity");
            Console.WriteLine(" 4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            Console.Clear();

            if (choice == "1")
            {
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.Run();
                breathingLog++;
            }
            else if (choice == "2")
            {
                ReflectingActivity reflectingActivity = new ReflectingActivity();
                reflectingActivity.Run();
                reflectingLog++;
            }
            else if (choice == "3")
            {
                ListingActivity listingActivity = new ListingActivity();
                listingActivity.Run();
                listingLog++;
            }
            else if (choice == "4")
            {
                break;
            }
            Console.WriteLine("Activity Log - Current Session");
            Console.WriteLine($"Breathing Activity: {breathingLog}");
            Console.WriteLine($"Reflecting Activity: {reflectingLog}");
            Console.WriteLine($"Listing Activity: {listingLog}");
            Console.WriteLine("Press Enter to continue");
            Console.ReadKey();
        }

        Console.WriteLine("Activity Log - Final Session");
        Console.WriteLine($"Breathing Activity: {breathingLog}");
        Console.WriteLine($"Reflecting Activity: {reflectingLog}");
        Console.WriteLine($"Listing Activity: {listingLog}");
        Console.WriteLine();
    }
}