using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] parts = text.Split(' ');
        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    public void Display()
    {
        Console.WriteLine();
        Console.WriteLine(_reference.ToString());
        Console.WriteLine();

        foreach (Word word in _words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }

        Console.WriteLine();
        Console.WriteLine();
    }

    public void HideRandomWords()
    {
        Random rand = new Random();
        int wordsToHide = 3; 

        for (int i = 0; i < wordsToHide; i++)
        {
            List<Word> visibleWords = new List<Word>();
            foreach (Word word in _words)
            {
                if (!word.IsHidden())
                {
                    visibleWords.Add(word);
                }
            }

            if (visibleWords.Count > 0)
            {
                int index = rand.Next(visibleWords.Count);
                visibleWords[index].Hide();
            }
        }
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
