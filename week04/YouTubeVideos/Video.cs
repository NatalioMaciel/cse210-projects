

using System.Transactions;

public class Video
{
    private string _title;
    private string _author;
    private int _lenghtSeconds;

    private List<Comment> _comments = new();

    public Video(string title, string author, int lenghtSeconds)
    {
        _title = title;
        _author = author;
        _lenghtSeconds = lenghtSeconds;
    }

    public string GetTitle()
    {
        string title = _title;
        return title;
    }

    public string GetAuthor()
    {
        string author = _author;
        return author;
    }
    public int GetLenghtSecond()
    {
        int lenghtSeconds = _lenghtSeconds;
        return lenghtSeconds;
    }

    public void AddComment(Comment comment)
    {
        if (comment != null)
        {
            _comments.Add(comment);
        }
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public List<Comment> GetComments()
    {
        return new List<Comment>(_comments);
    }
}