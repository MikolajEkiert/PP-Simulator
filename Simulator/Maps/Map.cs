namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public int SizeX { get; }
    public int SizeY { get; }
    private Rectangle boundaries;
    protected abstract List<Creature>?[,] Fields { get; }
    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p)
    {
        return boundaries.Contains(p);
    }


    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);

    public void Add(Creature creature, Point point)
    {
        Fields[point.X, point.Y] ??= new List<Creature>();
        Fields[point.X, point.Y]?.Add(creature);
    }

    public void Remove(Creature creature, Point point)
    {
        if (Fields[point.X, point.Y] != null)
        {
            Fields[point.X, point.Y]?.Remove(creature);
            if (Fields[point.X, point.Y]?.Count == 0)
                Fields[point.X, point.Y] = null;
        }
    }
    public void Move(Creature creature, Point from, Point to)
    {
        Remove(creature, from);
        Add(creature, to);
    }

    public List<Creature> At(Point point)
    {
        return Fields[point.X, point.Y] ?? new List<Creature>();
    }
    public List<Creature> At(int x, int y)
    {
        return At(new Point(x, y));
    }
    public Map(int sizeX, int sizeY)
    {
        if (sizeX < 5)
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Szerokość mapy musi wynosić co najmniej 5.");
        if (sizeY < 5)
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Długość mapy musi wynosić co najmniej 5.");

        SizeX = sizeX;
        SizeY = sizeY;
        boundaries = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }
}