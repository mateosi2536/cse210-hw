
using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Microsoft";
        job1._title = "Software Engineer";
        job1._startDate = "2017";
        job1._endDate = "2022";

        Job job2 = new Job();
        job2._company = "Apple";
        job2._title = "Software Engineer";
        job2._startDate = "2022";
        job2._endDate = "2024";

        Resume resume = new Resume();
        resume._name = "John Doe";
        resume._jobs = new List<Job> { job1, job2 };

        resume.Display();
    }
}