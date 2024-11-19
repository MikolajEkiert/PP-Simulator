namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public readonly int Size;
    public SmallTorusMap(int size)
    {
        if ((size < 5) || (size > 20))
        {
            throw new ArgumentOutOfRangeException("Rozmiar nie należy do przedziału [5,20]");
        }

        Size = size;
        
    }
    public override bool Exist(Point p)
    {
        try
        {
            Rectangle r = new(0, 0, Size-1, Size-1);

            return r.Contains(p);
        }
        catch (Exception)
        {
            throw new ArgumentException("Punkt nie istnieje na mapie");
        }
    }

    public override Point Next(Point p, Direction d)
    {
        switch (d)
        {
            case Direction.Up:
                return new Point(p.X, (p.Y + 1) % Size);
            case Direction.Down:
                return new Point(p.X, (p.Y - 1 + Size) % Size);
            case Direction.Left:
                return new Point((p.X - 1 + Size) % Size, p.Y);
            case Direction.Right:
                return new Point((p.X + 1) % Size, p.Y);
            default:
                throw new ArgumentException("Niepoprawny kierunek");
        }
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        switch (d)
        {
            case Direction.Up:
                return new Point((p.X + 1) % Size, (p.Y + 1) % Size);
            case Direction.Down:
                return new Point((p.X - 1 + Size) % Size, (p.Y - 1 + Size) % Size);
            case Direction.Left:
                return new Point((p.X - 1 + Size) % Size, (p.Y + 1) % Size);
            case Direction.Right:
                return new Point((p.X + 1) % Size, (p.Y - 1 + Size) % Size);
            default:
                throw new ArgumentException("Niepoprawny kierunek");
        }
    }
}


