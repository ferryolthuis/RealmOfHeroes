using RealmOfHeroes.Character.Monster;
using RealmOfHeroes.Character;
using RealmOfHeroes.Helpers;

namespace RealmOfHeroes.Combat;

public class CombatSystem
{
    public static void Battle(Player player, Monster monster)
    {
        Console.WriteLine($"\nA wild {monster.Name} appears!\n");

        while (player.IsAlive && monster.IsAlive)
        {
            player.DisplayStats();
            monster.DisplayStats();
            PlayerTurn(player, monster);
            if (!monster.IsAlive) break;  // Exit the loop if the monster is defeated
            Console.WriteLine();
            MonsterTurn(player, monster);
            Console.WriteLine();
        }

        // Display the result
        if (player.IsAlive)
        {
            Console.WriteLine($"You defeated the {monster.Name}!");
        }
        else
        {
            Console.WriteLine($"You were defeated by the {monster.Name}!");
        }
    }

    private static void PlayerTurn(Player player, Monster monster)
    {
        var possibleActions = player.GetCombatActions();

        CombatAction choice = AskUserForAction(possibleActions);

        player.PerformCombatAction(choice, monster);
    }

    private static void MonsterTurn(Player player, Monster monster)
    {
        var possibleActions = monster.GetCombatActions();

        // Let monster execute a random action from it's options
        var choice = possibleActions.OrderBy(x => Guid.NewGuid()).Single().Key;

        monster.PerformCombatAction(choice, player);
    }

    private static CombatAction AskUserForAction(Dictionary<CombatAction, string> possibleActions)
    {
        Console.WriteLine("Choose your action:");
        foreach (var action in possibleActions)
        {
            Console.WriteLine($"{(int)action.Key}. {action.Value}");
        }

        int choice = InputHelper.GetValidInput(possibleActions.Keys.Select(k => (int) k));
        return (CombatAction) choice;
    }
}