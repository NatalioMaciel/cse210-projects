

public class MathAssignment : Assignment
{
    private string _textBookSection;
    private string _problems;

    public string GetBookSection()
    {
        return _textBookSection;
    }

    public void SetBookSection(string bookSection)
    {
        _textBookSection = bookSection;
    }

    public string GetProblems()
    {
        return _problems;
    }

    public void SetProblems(string problems)
    {
        _problems = problems;
    }

    public string GetHomeWorkList()
    {
        return $"Section: {_textBookSection} Problems: {_problems}";
    }
}