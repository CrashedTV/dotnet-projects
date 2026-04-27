public class InputHelper
{
    public static double GetInput(string prompt)
    {
        Console.WriteLine(prompt);
        double.TryParse(Console.ReadLine(), out double result);
        return result;
    }
}