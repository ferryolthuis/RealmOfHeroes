namespace RealmOfHeroes.Character.Monster; 

class Monster : Character
{
    public Monster(string name, int health) : base(name, health)
    { 
    }

    public override void Attack(Character character)
    {
        // Simulate a basic attack
        Console.WriteLine($"{Name} attacks {character.Name}!");
        int damage = new Random().Next(5, 15);
        character.TakeDamage(damage);
    }
}