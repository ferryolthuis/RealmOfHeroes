using RealmOfHeroes.Character;
using RealmOfHeroes.Helpers;
using RealmOfHeroes.WorldMap;

namespace RealmOfHeroes;

public class Game
{
    private readonly Player player;
    private readonly Map map;

    public Game()
    {
        map = new Map(10, 10);
        player = Player.Create(map, map.Locations[0,0]);
    }

    public void Run()
    {
        while (player.IsAlive)
        {
            // Display the position
            Console.WriteLine($"You find yourself in location {player.CurrentLocation}.");

            // Get possible actions
            Dictionary<PlayerAction, string> possibleActions = map.GetPossibleActions(player.CurrentLocation);

            // Display possible actions
            PlayerAction choice = AskUserForAction(possibleActions);

            // Perform the selected action
            player.PerformAction(choice);
        }

        // If the player is no longer alive
        Console.WriteLine("Game over! You have been defeated by the monsters.");
    }

    private static PlayerAction AskUserForAction(Dictionary<PlayerAction, string> possibleActions)
    {
        Console.WriteLine("Choose your action:");
        foreach (var action in possibleActions)
        {
            Console.WriteLine($"{(int) action.Key}. {action.Value}");
        }

        int choice = InputHelper.GetValidInput(possibleActions.Keys.Select(k => (int)k));
        return (PlayerAction) choice;
    }
}
