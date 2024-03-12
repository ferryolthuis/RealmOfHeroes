using RealmOfHeroes.Character;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Realm of Heroes!");

        // Character creation
        Player player = Player.CreateCharacter();

        // Initialize the map
        Map map = new Map(10, 10);             

        // Interactive battle with a random monster encounter
        while (player.IsAlive)
        {
            // Display the position
            Console.WriteLine($"You find yourself in {map.GetCurrentTileName(player)}.");
            Console.WriteLine("Choose your action:");
            Console.WriteLine("1. Move to a new tile");
            Console.WriteLine("2. Display character stats");
            Console.WriteLine("3. Quit");

            int choice = InputHelper.GetValidInput(1, 3);

            switch (choice)
            {
                case 1:
                    map.MovePlayer(player);
                    break;

                case 2:
                    player.DisplayStats();
                    break;

                case 3:
                    Console.WriteLine("Thanks for playing! See you next time.");
                    return;
            }
            Console.WriteLine();
        }

        // If the player is no longer alive
        Console.WriteLine("Game over! You have been defeated by the monsters.");
    }
}