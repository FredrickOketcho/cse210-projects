using System;

public class Entry
{
    public string Date { get; set; } = string.Empty;
    public string PromptText { get; set; } = string.Empty;
    public string EntryText { get; set; } = string.Empty;
    public string Mood { get; set; } = string.Empty;

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {PromptText}");
        Console.WriteLine($"Mood: {Mood}");
        Console.WriteLine($"Entry: {EntryText}");
        Console.WriteLine();
    }
}
