

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void Run()
    {
        DisplayStartingMessage();

        AskDuration();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);

        bool breathe = true;

        while (breathe)
        {
            for (int i = 0; i < _duration / 6; i++)
            {
                Console.Write("\nBreathe in...");
                ShowCountDown(3);
                Console.Write("Now breathe out..");
                ShowCountDown(3);
            }
            ShowSpinner(1);
            Console.WriteLine("Well done!!");
            ShowSpinner(1);
            DisplayEndingMessage();
            ShowSpinner(3);
            breathe = false;
        }
    }
}