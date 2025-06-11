

using System.Security.Cryptography.X509Certificates;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity()
    {
        _name = "Reflecting Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        AskDuration();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        DisplayPrompt();
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();
        DisplayQuestions();
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int i = random.Next(_prompts.Count);
        return _prompts[i];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"\n---{GetRandomPrompt()}---");
        Console.WriteLine("\nWhen you have something in mind, press enter to continue");
        Console.ReadLine();
    }

    public string GetRandomQuestion()
    {
        Random rand = new Random();
        int i = rand.Next(_questions.Count);
        return _questions[i];
    }

    public void DisplayQuestions()
    {
        Console.WriteLine("Now ponder each of the following questions as they related to this experience.");

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            Console.Write($"> {question}");
            ShowSpinner(3);
        }
        Console.WriteLine("Well done!!");
        ShowSpinner(2);
        DisplayEndingMessage();
        ShowSpinner(3);
    }
}