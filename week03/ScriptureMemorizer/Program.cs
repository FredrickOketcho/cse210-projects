using System;

/*
 * STRETCH CHALLENGE / EXCEEDING REQUIREMENTS:
 * 1. Smart Hiding: The Scripture class tracks which words are already hidden and 
 *    strictly selects random targets from only the remaining visible words.
 *    This ensures we don't waste turns trying to "re-hide" already hidden words.
 */

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        
        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding In all thy ways acknowledge him and he shall direct thy paths";

        Scripture scripture = new Scripture(reference, text);

        string userInput = "";

        while (userInput.ToLower() != "quit")
        {
            Console.Clear();
            
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words, or type 'quit' to exit.");
            
            userInput = Console.ReadLine();

            if (userInput == "")
            {
                scripture.HideRandomWords(3);

                if (scripture.IsCompletelyHidden())
                {
                    Console.Clear();
                    Console.WriteLine(scripture.GetDisplayText());
                    Console.WriteLine("\nExcellent job! All words are hidden. Goodbye!");
                    break;
                }
            }
        }
    }
}
