using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        while (true)
        {
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                if (number == 0)
                    break;
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }

        double average = numbers.Count > 0 ? (double)sum / numbers.Count : 0;

        int max = numbers.Count > 0 ? numbers[0] : 0;
        foreach (int num in numbers)
        {
            if (num > max)
            {
                max = num;
            }
        }

        int smallestPositive = int.MaxValue;
        bool hasPositive = false;
        foreach (int num in numbers)
        {
            if (num > 0 && num < smallestPositive)
            {
                smallestPositive = num;
                hasPositive = true;
            }
        }

        List<int> sortedNumbers = numbers.OrderBy(n => n).ToList();

        Console.WriteLine($"\nSum: {sum}");
        Console.WriteLine($"Average: {average}");
        Console.WriteLine($"Maximum: {max}");
        if (hasPositive)
        {
            Console.WriteLine($"Smallest Positive Number: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("No positive numbers were entered.");
        }
        Console.WriteLine("The sorted list is:");
        foreach (int num in sortedNumbers)
        {
            Console.WriteLine(num);
        }
    }
}