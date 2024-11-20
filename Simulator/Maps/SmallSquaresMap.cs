
namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{
    public readonly int Size;
    public SmallSquareMap(int size) : base(size, size)
    {
    }
    public override bool Exist(Point p)
    {
        var R = new Rectangle(0,0, Size, Size);
        return R.Contains(p);
    }

    public override Point Next(Point p, Direction d)
    {
        var newPoint = p.Next(d);
        if (Exist(newPoint))
        {
            return newPoint;
        }
        else
        {
            return p;
        }
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var newPoint = p.NextDiagonal(d);
        if (Exist(newPoint))
        {
            return newPoint;
        }
        else
        {
            return p;
        }
    }
}