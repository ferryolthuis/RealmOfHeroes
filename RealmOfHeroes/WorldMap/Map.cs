namespace RealmOfHeroes.WorldMap;

public class Map
{
    public Location[,] Locations { get; init; }

    public Map(int width, int height)
    {
        Locations = new Location[width, height];
        InitializeMap();
    }

    private void InitializeMap()
    {
        for (int i = 0; i < Locations.GetLength(0); i++)
        {
            for (int j = 0; j < Locations.GetLength(1); j++)
            {
                Locations[i, j] = new Location(i, j);
            }
        }
    }

    public Dictionary<PlayerAction, string> GetPossibleActions(Location location)
    {
        Dictionary<PlayerAction, string> possibleActions = [];
        if (location.Coordinates.Y < Locations.GetLength(1))
        {
            possibleActions.Add(PlayerAction.MoveNorth, "Move North");
        }
        if (location.Coordinates.Y > 0)
        {
            possibleActions.Add(PlayerAction.MoveSouth, "Move South");
        }
        if (location.Coordinates.X < Locations.GetLength(0))
        {
            possibleActions.Add(PlayerAction.MoveEast, "Move East");
        }
        if (location.Coordinates.X > 0)
        {
            possibleActions.Add(PlayerAction.MoveWest, "Move West");
        }

        possibleActions.Add(PlayerAction.DisplayStats, "Display the players stats");
        possibleActions.Add(PlayerAction.Quit, "Quit");

        var locationActions = location.GetLocationActions();
        foreach(var action in locationActions)
        {
            possibleActions.Add(action.Key, action.Value);
        }

        return possibleActions;
    }
}