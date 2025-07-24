using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("C# for Beginners", "TechAcademy", 600);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks."));
        video1.AddComment(new Comment("Clara", "Clear and concise."));

        Video video2 = new Video("How to Cook Pasta", "FoodieLife", 300);
        video2.AddComment(new Comment("David", "Yummy!"));
        video2.AddComment(new Comment("Eva", "I tried this and it worked perfectly."));
        video2.AddComment(new Comment("Frank", "Awesome recipe."));

        Video video3 = new Video("Workout Routine", "FitnessPro", 450);
        video3.AddComment(new Comment("Grace", "I feel stronger already."));
        video3.AddComment(new Comment("Henry", "Perfect for beginners."));
        video3.AddComment(new Comment("Isla", "Loved the energy!"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.Name}: {comment.Text}");
            }
            Console.WriteLine(new string('-', 40));
        }
    }
}
