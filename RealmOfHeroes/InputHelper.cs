class InputHelper
{
    public static int GetValidInput(int minValue, int maxValue)
    {
        int choice;
        while (true)
        {
            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= minValue && choice <= maxValue)
            {
                break;
            }
            Console.WriteLine($"Invalid input. Please enter a number between {minValue} and {maxValue}.");
        }
        return choice;
    }
}