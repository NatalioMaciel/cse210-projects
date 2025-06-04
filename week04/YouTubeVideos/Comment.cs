

public class Comment
{
    private string _commenterName;
    private string _commentText;

    public Comment(string name, string text)
    {
        _commenterName = name;
        _commentText = text;
    }

    public string GetCommenterName()
    {
        string commenter = _commenterName;
        return commenter;
    }

    public string GetCommentText()
    {
        string commentText = _commentText;
        return commentText;
    }
}