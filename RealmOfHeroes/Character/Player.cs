namespace RealmOfHeroes.Character;

class Player : Character
{
    public int CurrentLocationX { get; private set; }

    public int CurrentLocationY { get; private set; }

    public Player(string name, int initialX, int initialY) : base(name, 100)
    {
        CurrentLocationX = initialX;
        CurrentLocationY = initialY;
    }

    public static Player CreateCharacter()
    {
        Console.Write("Enter your character's name: ");
        string playerName = Console.ReadLine() ?? "Hero";
        Console.WriteLine();
        return new Player(playerName, 0, 0);
    }

    public void Heal()
    {
        // Simulate healing
        int healing = new Random().Next(5, 15);
        Console.WriteLine($"{Name} healed for {healing} HP.");
        Health += healing;
    }

    public void UpdateLocation(int newX, int newY)
    {
        CurrentLocationX = newX;
        CurrentLocationY = newY;
    }
}