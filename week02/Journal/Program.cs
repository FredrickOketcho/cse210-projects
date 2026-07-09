using System;

class Program
{
    static void Main(string[] args)
    {
        // -------------------------------------------------------------------
        // CREATIVITY & EXCEEDING REQUIREMENTS NOTE:
        // This program exceeds the core requirements by recording a mood
        // for every journal entry and supporting JSON storage when the
        // filename ends with .json. This lets the user save and load journal
        // entries in a structured format that can be reused or opened by
        // other tools.
        // -------------------------------------------------------------------

        Journal theJournal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();
        
        string choice = "";

        Console.WriteLine("Welcome to the Journal Program!");

        // Main program loop
        while (choice != "5")
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            
            choice = Console.ReadLine()?.Trim() ?? string.Empty;

            if (choice == "1")
            {
                // Fetch a random prompt
                string prompt = promptGen.GetRandomPrompt();
                Console.WriteLine($"\nPrompt: {prompt}");
                Console.Write("> ");
                string response = Console.ReadLine() ?? string.Empty;
                Console.Write("Mood for this entry (optional): ");
                string mood = Console.ReadLine() ?? string.Empty;

                // Create a new entry object and populate its fields
                Entry newEntry = new Entry();
                newEntry.Date = DateTime.Now.ToShortDateString();
                newEntry.PromptText = prompt;
                newEntry.Mood = mood;
                newEntry.EntryText = response;

                // Add the entry to the journal list
                theJournal.AddEntry(newEntry);
            }
            else if (choice == "2")
            {
                Console.WriteLine("\n--- Journal Entries ---");
                theJournal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("\nWhat is the filename? ");
                string filename = Console.ReadLine()?.Trim() ?? string.Empty;
                if (string.IsNullOrEmpty(filename))
                {
                    Console.WriteLine("Filename cannot be empty.");
                }
                else
                {
                    theJournal.LoadFromFile(filename);
                }
            }
            else if (choice == "4")
            {
                Console.Write("\nWhat is the filename? ");
                string filename = Console.ReadLine()?.Trim() ?? string.Empty;
                if (string.IsNullOrEmpty(filename))
                {
                    Console.WriteLine("Filename cannot be empty.");
                }
                else
                {
                    theJournal.SaveToFile(filename);
                }
            }
            else if (choice == "5")
            {
                Console.WriteLine("\nGoodbye!");
            }
            else
            {
                Console.WriteLine("\nInvalid option. Please choose a number from 1 to 5.");
            }
        }
    }
}