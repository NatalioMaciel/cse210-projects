using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assigment1 = new Assignment();
        assigment1.SetStudentName("Samuel Bennet");
        assigment1.SetTopic("Multiplication");

        Console.WriteLine($"{assigment1.GetSummary()}\n");

        MathAssignment assigment2 = new MathAssignment();
        assigment2.SetStudentName("Roberto Rodriguez");
        assigment2.SetTopic("Fractions");
        assigment2.SetBookSection("7.3");
        assigment2.SetProblems("8-9");

        Console.WriteLine($"\n{assigment2.GetSummary()}");
        Console.WriteLine(assigment2.GetHomeWorkList());

        WritingAssignment assignment3 = new WritingAssignment();
        assignment3.SetStudentName("Mary Waters");
        assignment3.SetTopic("European History");
        assignment3.SetTitle("The Causes of Wrold War II");

        Console.WriteLine(assignment3.GetSummary());
        Console.WriteLine(assignment3.GetWritingInformation());

    }
}