

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity() { }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name}");
        Console.WriteLine(_description);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}");
    }

    public void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds * 2; i++)
        {
            Console.Write("|/-\\"[i % 4]);
            Thread.Sleep(1000);
            Console.Write("\b");
        }
        Console.WriteLine(" ");
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    public void AskDuration()
    {
        Console.WriteLine("\nHow long, in seconds, would you like for your session? ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int duration))
        {
            _duration = duration;
        }
        else
        {
            Console.WriteLine("invalid number. Defauling to 15 seconds.");
            _duration = 15;
        }
        Console.Clear();
    }

}