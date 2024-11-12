namespace Simulator;

public class Rectangle
{
    public Rectangle(int x1, int y1, int x2, int y2)
    {
        
        if (x1 > x2)
        {
            (x1, x2) = (x2, x1);
        }
        if (y1 > y2)
        {
            (y1, y2) = (y2, y1);
        }
        if (x1 == x2 || y1 == y2)
        {
            throw new ArgumentException("Nie chcemy chudych prostokątów");
        }
        X1 = x1;
        Y1 = y1;
        X2 = x2;
        Y2 = y2;
    }
    public int X1 { get; }
    public int Y1 { get; }
    public int X2 { get; }
    public int Y2 { get; }  
    
    public override string ToString() => $"({X1}, {Y1}):({X2}, {Y2})";
    public Rectangle(Point p1, Point p2) : this(p1.X,p1.Y,p2.X,p2.Y)
    {
    }
    public bool Contains (Point point)
    {
        if (point.X >= X1 && point.X <= X2 && point.Y >= Y1 && point.Y <= Y2)
        {
            return true;
        } 
        return false;
    }

}

