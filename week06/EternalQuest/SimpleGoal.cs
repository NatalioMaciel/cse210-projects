public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
        }
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString() =>
        $"[{(_isComplete ? "X" : " ")}] {_shortName} ({_description})";

    public override string GetStringRepresentation() =>
        $"SimpleGoal|{_shortName}|{_description}|{_points}|{_isComplete}";
}