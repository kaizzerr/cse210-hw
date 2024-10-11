using System;

public class Comment
{
    public string _name { get; set; }
    public string _text { get; set; }

    public Comment(string Name, string Text)
    {
        _name = Name;
        _text = Text;
    }
}