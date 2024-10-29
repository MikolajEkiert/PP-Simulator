namespace Simulator;

public static class DirectionParser
{
    public static Directions.Direction[] Parse(string input)
    {
        var directions = new List<Directions.Direction>();

        foreach (char c in input.ToUpper())
        {
            switch (c)
            {
                case 'U':
                    directions.Add(Directions.Direction.Up);
                    break;
                case 'R':
                    directions.Add(Directions.Direction.Right);
                    break;
                case 'D':
                    directions.Add(Directions.Direction.Down);
                    break;
                case 'L':
                    directions.Add(Directions.Direction.Left);
                    break;
            }
        }

        return directions.ToArray();
    }
}