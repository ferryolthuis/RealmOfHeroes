namespace RealmOfHeroes;

public class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Realm of Heroes!");

        // Create and run the game
        Game game = new();
        game.Run();

        Console.WriteLine("Thanks for playing! See you next time.");
    }
}
