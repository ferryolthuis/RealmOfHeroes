using RealmOfHeroes.Character;
using RealmOfHeroes.Character.Monster;

class Map
{
    private Location[,] _locations;

    public Map(int width, int height)
    {
        _locations = new Location[width, height];
        InitializeMap();
    }

    private void InitializeMap()
    {
        for (int i = 0; i < _locations.GetLength(0); i++)
        {
            for (int j = 0; j < _locations.GetLength(1); j++)
            {
                _locations[i, j] = new Location($"Tile ({i}, {j})");
            }
        }
    }

    public string GetCurrentTileName(Player player)
    {
        return _locations[player.CurrentLocationX, player.CurrentLocationY].Name;
    }

    public void MovePlayer(Player player)
    {
        Console.WriteLine("Choose the direction to move:");
        Console.WriteLine("1. North");
        Console.WriteLine("2. South");
        Console.WriteLine("3. East");
        Console.WriteLine("4. West");

        int directionChoice = InputHelper.GetValidInput(1, 4);

        int newX = player.CurrentLocationX;
        int newY = player.CurrentLocationY;

        switch (directionChoice)
        {
            case 1: // North
                newY--;
                break;

            case 2: // South
                newY++;
                break;

            case 3: // East
                newX++;
                break;

            case 4: // West
                newX--;
                break;
        }

        // Check if the new position is within bounds
        if (newX >= 0 && newX < _locations.GetLength(0) &&
            newY >= 0 && newY < _locations.GetLength(1))
        {
            player.UpdateLocation(newX, newY);

            // Access the location and perform any actions related to the tile
            Location currentLocation = _locations[newX, newY];

            // Check if there's a monster on the tile
            if (currentLocation.Monster != null)
            {
                Monster monster = currentLocation.Monster;

                // Battle with the monster
                BattleSystem.Battle(player, monster);
            }
        }
        else
        {
            Console.WriteLine("You cannot move in that direction. Try again.");
        }
    }
}