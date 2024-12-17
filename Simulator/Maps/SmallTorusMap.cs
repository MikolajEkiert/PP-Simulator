namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    private List<IMappable>?[,] fields;

    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        fields = new List<IMappable>?[sizeX, sizeY];
    }


    public override bool Exist(Point p)
    {
        try
        {
            Rectangle r = new(0, 0, SizeX - 1, SizeY - 1);
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
                return new Point(p.X, (p.Y + 1) % SizeY);
            case Direction.Down:
                return new Point(p.X, (p.Y - 1 + SizeY) % SizeY);
            case Direction.Left:
                return new Point((p.X - 1 + SizeX) % SizeX, p.Y);
            case Direction.Right:
                return new Point((p.X + 1) % SizeX, p.Y);
            default:
                throw new ArgumentException("Niepoprawny kierunek");
        }
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        switch (d)
        {
            case Direction.Up:
                return new Point((p.X + 1) % SizeX, (p.Y + 1) % SizeY);
            case Direction.Down:
                return new Point((p.X - 1 + SizeX) % SizeX, (p.Y - 1 + SizeY) % SizeY);
            case Direction.Left:
                return new Point((p.X - 1 + SizeX) % SizeX, (p.Y + 1) % SizeY);
            case Direction.Right:
                return new Point((p.X + 1) % SizeX, (p.Y - 1 + SizeY) % SizeY);
            default:
                throw new ArgumentException("Niepoprawny kierunek");
        }
    }
}