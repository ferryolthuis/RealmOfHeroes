using RealmOfHeroes.WorldMap;

namespace RealmOfHeroes.Helpers;

public static class InputHelper
{
    internal static int GetValidInput(IEnumerable<int> validOptions)
    {
        int choice;
        while (true)
        {
            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out choice) && validOptions.Contains(choice))
            {
                break;
            }
            Console.WriteLine($"Invalid input. Please enter one of the following numbers: {validOptions}.");
        }
        return choice;
    }
}