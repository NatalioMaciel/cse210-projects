

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity helps you reflect on the good things in your life by having you list as many things as you can in a certain area";
        _prompts = new List<string>
        {
            "Who are people you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        AskDuration();

        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($"\n---{GetRandomPrompt()}---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        List<string> responses = GetListFromUser();
        _count = responses.Count;

        Console.WriteLine($"You listed {_count} items");
        Console.WriteLine("Well done!!");
        ShowSpinner(2);
        DisplayEndingMessage();
        ShowSpinner(3);
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int i = random.Next(_prompts.Count);
        return _prompts[i];
    }

    public List<string> GetListFromUser()
    {
        List<string> list = new List<string>();

        while (true)
        {
            Console.Write(">");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) break;
            list.Add(input);
        }

        return list;
    }
}