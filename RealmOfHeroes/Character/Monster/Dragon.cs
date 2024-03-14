namespace RealmOfHeroes.Character.Monster;

public class Dragon : Monster
{
    public Dragon() : base("Dragon", 60)
    {
        // Additional dragon-specific attributes can be added here
    }

    public override void Attack(Character character)
    {
        // Dragon's special attack
        Console.WriteLine($"The {Name} unleashed a fiery breath!");
        int damage = new Random().Next(10, 25);
        character.TakeDamage(damage);
    }
}