public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Eternal Quest Menu ===");
            Console.WriteLine($"\nYou have {_score} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option from the menu: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateGoal();
                    ListGoalDetails();
                    break;
                case "2":
                    ListGoalDetails();
                    DisplayPlayerInfo();
                    break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": return;
                default: Console.WriteLine("Invalid choice."); break;
            }
            Console.ReadLine();
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score}");
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goal are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Choose goal type:\n1. Simple\n2. Eternal\n3. Checklist");
        Console.WriteLine("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Which goal did you accomplish?");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        Goal goal = _goals[index - 1];

        bool wasCompleteBefore = goal.IsComplete();

        goal.RecordEvent();

        int earnedPoints = goal.GetPoints();

        if (goal is ChecklistGoal checklistGoal)
        {
            if (!wasCompleteBefore && checklistGoal.IsComplete())
            {
                earnedPoints += checklistGoal.GetBonus();
                Console.WriteLine("🎉 Bonus achieved!");
            }
        }

        _score += earnedPoints;
        Console.WriteLine($"Congrats! You earned {earnedPoints} points.");
    }

    public void SaveGoals()
    {
        Console.Write("Enter a name for the save file: ");
        string fileName = Console.ReadLine();

        if (!fileName.EndsWith(".txt"))
        {
            fileName += ".txt";
        }

        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine(_score);
                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine($"Goals saved to '{fileName}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while saving the goals:");
            Console.WriteLine(ex.Message);
        }
    }

    public void LoadGoals()
    {
        Console.Write("Enter the name of the file to load: ");
        string fileName = Console.ReadLine();

        if (!fileName.EndsWith(".txt"))
        {
            fileName += ".txt";
        }

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(fileName);
            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');
                string type = parts[0];

                switch (type)
                {
                    case "SimpleGoal":
                        var sg = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                        if (bool.Parse(parts[4])) sg.RecordEvent();
                        _goals.Add(sg);
                        break;

                    case "EternalGoal":
                        _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                        break;

                    case "ChecklistGoal":
                        var cg = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));
                        for (int j = 0; j < int.Parse(parts[6]); j++) cg.RecordEvent();
                        _goals.Add(cg);
                        break;
                }
            }

            Console.WriteLine($"Goals loaded from '{fileName}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while loading the goals:");
            Console.WriteLine(ex.Message);
        }
    }
}