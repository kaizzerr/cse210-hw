using System;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private int _rating;

    public Scripture(Reference reference, string text)
    {
        _reference = reference ?? throw new ArgumentNullException(nameof(reference));
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
        _rating = 0;
    }

    public void SetRating(int rating)
    {
        _rating = rating;
    }

    public int GetRating()
    {
        return _rating;
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int hiddenCount = 0;

        while (hiddenCount < numberToHide)
        {
            var visibleWords = _words.Where(w => !w.IsHidden()).ToList();

            if (visibleWords.Count == 0) break;

            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            hiddenCount++;
        }
    }

    public string GetDisplayText()
    {
        return $"{_reference.GetDisplayText()}: {string.Join(" ", _words.Select(w => w.GetDisplayText()))}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}