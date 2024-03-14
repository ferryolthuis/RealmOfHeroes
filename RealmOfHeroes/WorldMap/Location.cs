using RealmOfHeroes.Character;
using RealmOfHeroes.Character.Monster;
using RealmOfHeroes.Combat;

namespace RealmOfHeroes.WorldMap;

public class Location
{
    public (int X, int Y) Coordinates { get; init; }

    public Monster? Monster { get; set; }

    public Location(int x, int y)
    {
        Coordinates = (x, y);
        // 30% chance to spawn a random monster
        if (new Random().Next(1, 101) <= 30)
        {
            Monster = GetRandomMonster();
        }
    }

    public static Monster GetRandomMonster()
    {
        int random = new Random().Next(3);
        switch (random)
        {
            case 0:
                return new Goblin();
            case 1:
                return new Skeleton();
            case 2:
                return new Dragon();
            default:
                throw new InvalidOperationException("Invalid random monster type.");
        }
    }

    public void ExecuteLocationEvents(Player player)
    {
        // Check if there's a monster on the tile
        if (Monster != null)
        {
            // Battle with the monster
            CombatSystem.Battle(player, Monster);
        }
    }

    public override string ToString()
    {
        return $"({Coordinates.X}, {Coordinates.Y})";
    }

    internal Dictionary<PlayerAction, string> GetLocationActions()
    {
        return [];
    }
}