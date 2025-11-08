using System;

// Exceeded requirements by:
// 1. Adding 8 prompts instead of minimum 5
// 2. Adding proper error handling in save/load operations
// 3. Using custom separator "~|~" for file storage

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        Console.WriteLine("Welcome to the Journal Program!");
        Console.WriteLine("This program helps you record your daily thoughts and experiences.");

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Thank you for using the Journal Program!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void WriteNewEntry(Journal journal)
    {
        string prompt = journal.GetRandomPrompt();
        Console.WriteLine();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");

        string response = Console.ReadLine();
        string date = DateTime.Now.ToString("yyyy-MM-dd");

        Entry entry = new Entry(prompt, response, date);
        journal.AddEntry(entry);

        Console.WriteLine("Entry added to journal!");
    }

    static void SaveJournal(Journal journal)
    {
        Console.WriteLine();
        Console.Write("Enter filename to save journal: ");
        string filename = Console.ReadLine();

        if (!string.IsNullOrEmpty(filename))
        {
            journal.SaveToFile(filename);
        }
        else
        {
            Console.WriteLine("Invalid filename.");
        }
    }

    static void LoadJournal(Journal journal)
    {
        Console.WriteLine();
        Console.Write("Enter filename to load journal: ");
        string filename = Console.ReadLine();

        if (!string.IsNullOrEmpty(filename))
        {
            journal.LoadFromFile(filename);
        }
        else
        {
            Console.WriteLine("Invalid filename.");
        }
    }
}