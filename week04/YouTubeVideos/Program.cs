using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 1. Create Video 1 and add comments
        Video video1 = new Video("C# Classes Tutorial", "CodeAcademy", 600);
        video1.AddComment(new Comment("Alice", "Great explanation of abstraction!"));
        video1.AddComment(new Comment("Bob", "This helped me pass my quiz."));
        video1.AddComment(new Comment("Charlie", "Very clear and concise."));

        // 2. Create Video 2 and add comments
        Video video2 = new Video("Top 10 C# Features", "TechGeek", 450);
        video2.AddComment(new Comment("Dave", "Pattern matching is my favorite."));
        video2.AddComment(new Comment("Eve", "Thanks for putting this together!"));
        video2.AddComment(new Comment("Frank", "Awesome video as always."));

        // 3. Create Video 3 and add comments
        Video video3 = new Video("Object-Oriented Programming Basics", "DevTips", 900);
        video3.AddComment(new Comment("Grace", "Best explanation on YouTube."));
        video3.AddComment(new Comment("Heidi", "Looking forward to part 2!"));
        video3.AddComment(new Comment("Ivan", "Extremely informative."));

        // Store all videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Iterate through the list and display video information
        foreach (Video video in videos)
        {
            Console.WriteLine("========================================");
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._length} seconds");
            Console.WriteLine($"Comment Count: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video._comments)
            {
                Console.WriteLine($" - {comment._name}: {comment._text}");
            }
            Console.WriteLine();
        }
    }
}