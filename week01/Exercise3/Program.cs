using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;
        while (playAgain)
        {
            Random random = new Random();
            int magicNumber = random.Next(1, 101);

            int userGuess = 0;
            int attempts = 0;

            Console.WriteLine("Welcome to the Magic Number Guessing Game!");
            while (userGuess != magicNumber)
            {
                Console.Write("Enter your guess (1-100): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out userGuess) && userGuess >= 1 && userGuess <= 100)
                {
                    attempts++;
                    if (userGuess < magicNumber)
                    {
                        Console.WriteLine("Too low! Try again.");
                    }
                    else if (userGuess > magicNumber)
                    {
                        Console.WriteLine("Too high! Try again.");
                    }
                    else
                    {
                        Console.WriteLine($"Congratulations! You've guessed the magic number {magicNumber} in {attempts} attempts.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 100.");
                }
            }
            Console.Write("Do you want to play again? (yes/no): ");
            string playAgainInput = Console.ReadLine().ToLower();
            if (playAgainInput != "yes" && playAgainInput != "y")
            {
                playAgain = false;
                Console.WriteLine("Thank you for playing! Goodbye.");
            }
        }
    }
}