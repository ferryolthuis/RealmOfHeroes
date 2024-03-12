namespace RealmOfHeroes.Character;

class Character
{
    public string Name { get; }
    public int Health { get; protected set; }
    public bool IsAlive => Health > 0;

    public Character(string name, int health)
    {
        Name = name;
        Health = health;
    }

    public virtual void Attack(Character character)
    {
        // Simulate a basic attack
        int damage = new Random().Next(10, 20);
        Console.WriteLine($"{Name} attacks {character.Name}!");
        character.TakeDamage(damage);
    }

    public void DisplayStats()
    {
        Console.WriteLine($"{Name}'s HP: {Health}");
    }

    public void TakeDamage(int damage)
    {
        Console.WriteLine($"{Name} took {damage} damage!");
        Health -= damage;
    }
}