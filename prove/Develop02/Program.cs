using System;
using System.IO;

class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found");
        }
        else
        {
            foreach (var entry in _entries)
            {
                entry.Display();
            }
        }
    }

    public void SaveToFile(string file)
    {
        List<string> lines = new List<string>();
        foreach (var entry in _entries)
        {
            lines.Add(entry.ToString());
        }
        File.WriteAllLines(file, lines);
        Console.WriteLine($"Journal saved to {file}.");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();
        foreach (string line in File.ReadAllLines(file))
        {
            string[] parts = line.Split('|');
            if (parts.Length == 4)
            {
                Entry entry = new Entry(parts[1], parts[2], parts[3]) { _date = parts[0] };
                _entries.Add(entry);
            }
        }
    }
}

class Entry
{
    public string _date;
    private string _promptText;
    private string _entryText;
    private string _dayRating;

    public Entry(string promptText, string entryText, string dayRating)
    {
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();
        _date = dateText;
        _promptText = promptText;
        _entryText = entryText;
        _dayRating = dayRating;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} -- Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}");
        Console.WriteLine($"Day Rating: {_dayRating}/10");
    }

    public override string ToString()
    {
        return $"{_date}|{_promptText}|{_entryText}|{_dayRating}";
    }
}

class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "What made you happy today?",
        "What was the best part of your day?",
        "If you could re-do one thing throughout the day, what would it be?",
        "How have you felt the Spirit guide and help you today?",
        "Have you talked to someone interesting today? If yes, why were they interesting?",
        "What is a Scripture verse that stuck out most to you?",
        "How spiritual do you think you were for this day?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
    }
}

class Program
{
    static Journal journal = new Journal();
    static PromptGenerator promptGen = new PromptGenerator();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do?: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                AddEntry();
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                LoadJournal();
            }
            else if (choice == "4")
            {
                SaveJournal();
            }
            else if (choice == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }
        }
    }

    static void AddEntry()
    {
        string prompt = promptGen.GetRandomPrompt();
        Console.WriteLine($"{prompt}");
        string response = Console.ReadLine();

        Console.Write("How would you rate your day out of 10?: ");
        string dayRating = Console.ReadLine();

        Entry newEntry = new Entry(prompt, response, dayRating);
        journal.AddEntry(newEntry);
    }

    static void SaveJournal()
    {
        Console.Write("What is the filename you want to save?: ");
        journal.SaveToFile(Console.ReadLine());
    }

    static void LoadJournal()
    {
        Console.Write("What is the filename you want to load?: ");
        journal.LoadFromFile(Console.ReadLine());
    }
}