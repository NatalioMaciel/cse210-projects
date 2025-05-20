using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts;

    public PromptGenerator()
    {
        _prompts = new List<string>
        {
            "What was the best part of my day?",
            "What new things did I learn today?",
            "With whom did I have the most fascinating conversation today?",
            "If I could do one thing over again today, what would it be?",
            "What am I thankful for today?"
        };
    }

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }
}