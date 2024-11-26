

namespace Simulator.Maps;
/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    //add(creature,point)
    //remove(creature,point)
    //move()
    //at(point) lub at(x,y)
    
    private readonly Rectangle r;
    protected abstract List<Creature>?[,] Fields { get; }

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5 || sizeY < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Mapa jest zbyt mała");
        }
        SizeX = sizeX;
        SizeY = sizeY;
        r = new Rectangle(0, 0, sizeX-1, sizeY-1);
    }
    public int SizeX { get; }
    public int SizeY { get; }

    /// <summary>
    /// Check if given point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p) => r.Contains(p);

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
    public void Add(Creature c, Point p)
    {
        int x = p.X;
        int y = p.Y;
        if (Fields[x, y] == null)
        {
            Fields[x, y] = new List<Creature>();
            Fields[x, y]?.Add(c);
        }
    }
    
    public void Remove(Creature c, Point p)
    {
        int x = p.X;
        int y = p.Y;
        if (Fields[x, y] != null)
        {
            Fields[x, y]?.Remove(c);
            if (Fields[x,y]?.Count == 0)
            {
                Fields[x, y] = null;
            }
        }
    }
    
    public void Move(Creature c, Point point1, Point point2)
    {
        Remove(c, point1);
        Add(c, point2);
    }
    
    public List<Creature> At(Point p)
    {
        int x = p.X;
        int y = p.Y;
        var creatures = new List<Creature>();
        if (Fields[x, y] != null)
        {
            creatures.AddRange(Fields[x, y]);
        }
        return creatures;
    }
    
    public List<Creature> At(int x, int y) 
    {
        return At(new Point(x, y));
    }


}