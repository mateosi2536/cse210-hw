using System;

class Program
{
    static void Main(string[] args)
    {
        string input;

        while (true)
        {
            Console.WriteLine("Enter your grade percentage: ");
            input = Console.ReadLine();
            if (int.TryParse(input, out int grade) && grade >= 0 && grade <= 100)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 0 and 100.");
            }
        }

        int gradePercentage = int.Parse(input);

        string letterGrade;
        string signGrade = "";

        if (gradePercentage >= 90)
        {
            letterGrade = "A";
        }
        else if (gradePercentage >= 80)
        {
            letterGrade = "B";
        }
        else if (gradePercentage >= 70)
        {
            letterGrade = "C";
        }
        else if (gradePercentage >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }


        if (gradePercentage % 10 >= 7 && letterGrade != "F" && letterGrade != "A")
        {
            signGrade = "+";
        }
        else if (gradePercentage % 10 < 3 && letterGrade != "F" && gradePercentage != 100)
        {
            signGrade = "-";
        }

        Console.WriteLine($"Your letter grade is: {signGrade}{letterGrade}");

        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You have passed the course.");
        }
        else
        {
            Console.WriteLine("Unfortunately, you have not passed the course. Better luck next time!");
        }
    }
}