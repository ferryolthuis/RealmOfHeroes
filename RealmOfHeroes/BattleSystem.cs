using RealmOfHeroes.Character.Monster;
using RealmOfHeroes.Character;

class BattleSystem
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
        Console.WriteLine("Choose your action:");
        Console.WriteLine("1. Attack");
        Console.WriteLine("2. Heal");

        int choice = InputHelper.GetValidInput(1, 2);

        switch (choice)
        {
            case 1:
                player.Attack(monster);
                break;

            case 2:
                player.Heal();
                break;
        }
    }

    private static void MonsterTurn(Player player, Monster monster)
    {
        monster.Attack(player);
    }
}