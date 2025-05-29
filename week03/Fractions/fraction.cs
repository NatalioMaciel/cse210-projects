

public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    public Fraction(int topNumber, int bottomNumber)
    {
        _top = topNumber;
        _bottom = bottomNumber;
    }

    public string GetFractionString()
    {
        string result = $"{_top} / {_bottom}";
        return result;
    }

    public double SetFractionValue()
    {
        double result = (double)_top / (double)_bottom;
        return result;
    }


}