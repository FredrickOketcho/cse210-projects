using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    // Adds a completed entry to our journal list
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    // Displays every entry currently in the journal
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is currently empty.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Saves the complete journal list to a text file or JSON file
    public void SaveToFile(string file)
    {
        if (string.IsNullOrWhiteSpace(file))
        {
            Console.WriteLine("Please provide a valid filename.");
            return;
        }

        try
        {
            if (Path.GetExtension(file).Equals(".json", StringComparison.OrdinalIgnoreCase))
            {
                string json = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(file, json);
            }
            else
            {
                using (StreamWriter outputFile = new StreamWriter(file))
                {
                    foreach (Entry entry in _entries)
                    {
                        // Using ~|~ as a custom separator so standard commas/quotes don't break our formatting
                        outputFile.WriteLine($"{entry.Date}~|~{entry.PromptText}~|~{entry.Mood}~|~{entry.EntryText}");
                    }
                }
            }

            Console.WriteLine("Journal saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unable to save file: {ex.Message}");
        }
    }

    // Loads entries from a text file or JSON file, replacing whatever is currently in memory
    public void LoadFromFile(string file)
    {
        if (string.IsNullOrWhiteSpace(file))
        {
            Console.WriteLine("Please provide a valid filename.");
            return;
        }

        if (!File.Exists(file))
        {
            Console.WriteLine("File not found. Please check the filename and try again.");
            return;
        }

        try
        {
            // Clear existing entries before loading new ones
            _entries.Clear();

            if (Path.GetExtension(file).Equals(".json", StringComparison.OrdinalIgnoreCase))
            {
                string json = File.ReadAllText(file);
                List<Entry>? loadedEntries = JsonSerializer.Deserialize<List<Entry>>(json);

                if (loadedEntries != null)
                {
                    _entries = loadedEntries;
                }
            }
            else
            {
                string[] lines = File.ReadAllLines(file);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(new string[] { "~|~" }, StringSplitOptions.None);
                    
                    // Ensure the line has exactly the 4 parts we expect (Date, Prompt, Mood, Response)
                    if (parts.Length == 4)
                    {
                        Entry loadedEntry = new Entry();
                        loadedEntry.Date = parts[0];
                        loadedEntry.PromptText = parts[1];
                        loadedEntry.Mood = parts[2];
                        loadedEntry.EntryText = parts[3];

                        _entries.Add(loadedEntry);
                    }
                }
            }
            Console.WriteLine("Journal loaded successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unable to load file: {ex.Message}");
        }
    }
}