using System;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "5 Trust in the Lord with all your heart and lean not on your own understanding; 6 in all your ways submit to him, and he will make your paths straight."),
            new Scripture(new Reference("Moroni", 10, 4, 5), "4 And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true;and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost. 5 And by the power of the Holy Ghost ye may know the truth of all things."),
            new Scripture(new Reference("Alma", 37, 35), "O, remember, my son, and learn wisdom in thy youth; yea, learn in thy youth to keep the commandments of God."),
            new Scripture(new Reference("Isaiah", 5, 20),"Woe unto them that call evil good, and good evil; that put darkness for light, and light for darkness; that put bitter for sweet, and sweet for bitter!"),
        };

        Random random = new Random();
        Scripture displayScripture = scriptures[random.Next(scriptures.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(displayScripture.GetDisplayText());
            Console.WriteLine("Please enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit") 
            {
                break;
            }

            if (string.IsNullOrWhiteSpace(input))
            {
                displayScripture.HideRandomWords(3);
            }

            if (displayScripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(displayScripture.GetDisplayText());

                Console.WriteLine("Would you like to rate this verse from 1 to 5? (If not interested, type 'no'): ");
                string ratingInput = Console.ReadLine();
                if (ratingInput.ToLower() != "no")
                {
                    if (int.TryParse(ratingInput, out int rating))
                    {
                        displayScripture.SetRating(rating);
                        Console.WriteLine("Thank you rating this Scripture Verse!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please pick a number between 1 and 5");
                    }
                }
                break;
            }
        }
    }
}