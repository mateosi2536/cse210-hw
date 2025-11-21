using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new("Introduction to C#", "John Smith", 600);
        video1.AddComment(new("Maria", "Great tutorial!"));
        video1.AddComment(new("Carlos", "Very helpful, thanks"));
        video1.AddComment(new("Ana", "Perfect explanation"));

        Video video2 = new("Advanced Programming Concepts", "Sarah Johnson", 1200);
        video2.AddComment(new("Pedro", "Amazing content"));
        video2.AddComment(new("Laura", "Could you make more videos like this?"));
        video2.AddComment(new("Diego", "This helped me a lot"));
        video2.AddComment(new("Sofia", "Excellent teacher"));

        Video video3 = new("Object-Oriented Programming", "Michael Brown", 900);
        video3.AddComment(new("Luis", "Very clear explanation"));
        video3.AddComment(new("Carmen", "Best OOP tutorial"));
        video3.AddComment(new("Jorge", "Thanks for sharing"));

        Video video4 = new("Data Structures in C#", "Emily Davis", 1500);
        video4.AddComment(new("Ricardo", "Loved it!"));
        video4.AddComment(new("Patricia", "Subscribed!"));
        video4.AddComment(new("Fernando", "Can't wait for the next one"));
        video4.AddComment(new("Isabel", "Very informative"));

        List<Video> videos = [video1, video2, video3, video4];

        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}