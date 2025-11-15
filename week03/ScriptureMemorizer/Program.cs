using System;

class Program
{
    /*
    EXCEEDING REQUIREMENTS - Stretch Challenge:
    The program intelligently avoids hiding words that are already hidden.
    
    The program displays real-time progress statistics showing how many
    words remain visible out of the total word count
    */

    static void Main(string[] args)
    {
        Reference reference = new Reference("John", 3, 16);
        string text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
        Scripture scripture = new Scripture(reference, text);

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine($"\nPalabras visibles: {scripture.GetVisibleWordCount()} de {scripture.GetTotalWordCount()}");
            Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");

            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are hidden. Press any key to exit.");
        Console.ReadKey();
    }
}