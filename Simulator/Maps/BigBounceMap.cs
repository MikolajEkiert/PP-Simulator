using System.Collections.Generic;

namespace Simulator.Maps
{
    public class BigBounceMap : BigMap
    {
        public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

        public override Point Next(Point p, Direction d)
        {
            Point nextPoint = p.Next(d);
            if (!Exist(nextPoint))
            {
                nextPoint = p.Next(Opposite(d));
                if (!Exist(nextPoint))
                {
                    return p;
                }
            }
            return nextPoint;
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            Point nextPoint = p.NextDiagonal(d);
            if (!Exist(nextPoint))
            {
                nextPoint = p.NextDiagonal(Opposite(d));
                if (!Exist(nextPoint))
                {
                    return p;
                }
            }
            return nextPoint;
        }

        private Direction Opposite(Direction direction)
        {
            return direction switch
            {
                Direction.Up => Direction.Down,
                Direction.Right => Direction.Left,
                Direction.Down => Direction.Up,
                Direction.Left => Direction.Right,
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }
    }
}