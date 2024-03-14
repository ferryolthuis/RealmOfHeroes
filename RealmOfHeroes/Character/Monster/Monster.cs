using RealmOfHeroes.Combat;

namespace RealmOfHeroes.Character.Monster; 

public abstract class Monster : Character
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

    public override Dictionary<CombatAction, string> GetCombatActions() => new() {
        { CombatAction.Attack, "Attack the player" },
    };

    public override void PerformCombatAction(CombatAction action, Character opponent)
    {
        switch (action)
        {
            case CombatAction.Attack:
                Attack(opponent);
                break;
            default:
                throw new NotSupportedException("Somehow the monster tried to execute an action which it cannot even do. There's a bug here");
        }
    }
}