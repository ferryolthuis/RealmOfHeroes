using RealmOfHeroes.Combat;
using RealmOfHeroes.WorldMap;

namespace RealmOfHeroes.Character;

public class Player : Character
{
    public Location CurrentLocation { get; private set; }

    private readonly Map _map;

    private Player(string name, Map map, Location initialLocation) : base(name, 100)
    {
        CurrentLocation = initialLocation;
        _map = map;
    }

    public static Player Create(Map map, Location initialLocation)
    {
        Console.Write("Enter your character's name: ");
        string playerName = Console.ReadLine() ?? "Hero";
        Console.WriteLine();
        return new Player(playerName, map, initialLocation);
    }

    public void Heal()
    {
        // Simulate healing
        int healing = new Random().Next(5, 15);
        Console.WriteLine($"{Name} healed for {healing} HP.");
        Health += healing;
    }

    private void UpdateLocation(Location newLocation)
    {
        CurrentLocation = newLocation;
        newLocation.ExecuteLocationEvents(this);
    }

    public void PerformAction(PlayerAction action)
    {
        switch (action)
        {
            case PlayerAction.MoveNorth:
                UpdateLocation(_map.Locations[CurrentLocation.Coordinates.X, CurrentLocation.Coordinates.Y + 1]);
                break;

            case PlayerAction.MoveSouth:
                UpdateLocation(_map.Locations[CurrentLocation.Coordinates.X, CurrentLocation.Coordinates.Y - 1]);
                break;

            case PlayerAction.MoveEast:
                UpdateLocation(_map.Locations[CurrentLocation.Coordinates.X + 1, CurrentLocation.Coordinates.Y]);
                break;

            case PlayerAction.MoveWest:
                UpdateLocation(_map.Locations[CurrentLocation.Coordinates.X - 1 , CurrentLocation.Coordinates.Y]);
                break;

            case PlayerAction.DisplayStats:
                DisplayStats();
                break;

            case PlayerAction.Quit:
                Console.WriteLine("Thanks for playing! See you next time.");
                Environment.Exit(0);
                break;
        }

        Console.WriteLine();
    }

    public override Dictionary<CombatAction, string> GetCombatActions() => new() {
            { CombatAction.Heal, "Heal Yourself" },
            { CombatAction.Attack, "Attack the monster" },
        };

    public override void PerformCombatAction(CombatAction action, Character opponent)
    {
        switch (action)
        {
            case CombatAction.Heal:
                Heal();
                break;

            case CombatAction.Attack:
                Attack(opponent);
                break;
        }
    }
}