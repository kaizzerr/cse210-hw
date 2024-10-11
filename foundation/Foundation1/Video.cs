using System;

public class Video
{
    public string _title { get; set; }
    public string _author { get; set; }
    public int _length { get; set; }
    private List<Comment> _comments;
    
    public Video(string Title, string Author, int Length)
    {
        _title = Title;
        _author = Author;
        _length = Length;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment _comment)
    {
        _comments.Add(_comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }

    public void Display()
    {
        Console.WriteLine($"{_title} by {_author}, Length: {_length} seconds");
    }
}