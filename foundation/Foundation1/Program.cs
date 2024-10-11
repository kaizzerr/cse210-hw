using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Basics of C#", "Sir Kai", 600);
        video1.AddComment(new Comment("Rich", "Wow, This is so helpful!"));
        video1.AddComment(new Comment("Claris", "Great job simplifying the basics! Thank you"));
        video1.AddComment(new Comment("Victor", "Please make a video about the intermediate part of C#!"));
        videos.Add(video1);

        Video video2 = new Video("How Abstraction Works", "Mister Kim", 480);
        video2.AddComment(new Comment("Rica", "Ohh, so that's why coding is way simpler right now than it ever was"));
        video2.AddComment(new Comment("Winter", "I'm so grateful that Abstraction is a thing!"));
        video2.AddComment(new Comment("Dewey", "I kinda want to see what the implementation of code looks like without Abstration."));
        video2.AddComment(new Comment("Ray", "Abstraction truly is impressive because it can trim down what would have been thousands of code into one line!"));
        videos.Add(video2);

        Video video3 = new Video("Public vs. Private Classes: A Topic on Encapsulation", "Robin", 900);
        video3.AddComment(new Comment("Franky", "Man, I didn't think that knowing the difference between Public and Private is that important"));
        video3.AddComment(new Comment("Ted", "Such a nice breakdown of Encapsulation"));
        video3.AddComment(new Comment("Tony", "I wish I knew this earlier!"));
        videos.Add(video3);
        
        foreach (var video in videos)
        {
            video.Display();
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment._name}: {comment._text}");
            }
            Console.WriteLine();
        }
    }
}