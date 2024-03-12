using RealmOfHeroes.Character.Monster;

class Location
{
    public string Name { get; set; }

    public Monster Monster { get; set; }

    public Location(string name)
    {
        Name = name;
        // 30% chance to spawn a random monster
        if (new Random().Next(1, 101) <= 30)
        {
            Monster = GetRandomMonster();
        }
    }

    public void PlaceMonster(Monster monster)
    {
        Monster = monster;
    }

    public void RemoveMonster()
    {
        Monster = null;
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
}