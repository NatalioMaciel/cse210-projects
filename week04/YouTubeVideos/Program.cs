using System;

class Program
{
    static void Main(string[] args)
    {
        var video1 = new Video("Exploring the forest", "Roger", 300);
        video1.AddComment(new Comment("John", "Great Place"));
        video1.AddComment(new Comment("Mary", "Loved the background music."));
        video1.AddComment(new Comment("Alex", "Where is this place?"));

        var video2 = new Video("Cooking Pasta", "Chef Alex", 420);
        video2.AddComment(new Comment("Tom", "Looks delicious"));
        video2.AddComment(new Comment("Charles", "I'll try this recipe."));
        video2.AddComment(new Comment("Arnold", "Can you do a vegan version?"));

        var video3 = new Video("Learning C#", "DevDan", 600);
        video3.AddComment(new Comment("Mike", "Very helpful, thanks!"));
        video3.AddComment(new Comment("Laura", "Please make more like this."));
        video3.AddComment(new Comment("Zoe", "Clear and easy to follow."));

        var videos = new List<Video> { video1, video2, video3 };

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLenghtSecond()} seconds");
            Console.WriteLine($"Comments ({video.GetCommentCount()}):");

            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.GetCommenterName()}: {comment.GetCommentText()}");
            }

            Console.WriteLine(new string('-', 40));
        }
    }
}