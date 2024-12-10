using System.Collections.Generic;

namespace Simulator.Maps
{
    public class BigMap : Map
    {
        private Dictionary<Point, List<IMappable>> fields;

        public BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 1000)
                throw new ArgumentOutOfRangeException(nameof(sizeX), "Szerokość mapy nie może przekraczać 1000.");
            if (sizeY > 1000)
                throw new ArgumentOutOfRangeException(nameof(sizeY), "Długość mapy nie może przekraczać 1000.");

            fields = new Dictionary<Point, List<IMappable>>();
        }

        protected override List<IMappable>?[,] Fields => throw new NotImplementedException();

        public override Point Next(Point p, Direction d)
        {
            Point nextPoint = p.Next(d);
            return Exist(nextPoint) ? nextPoint : p;
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            Point nextPoint = p.NextDiagonal(d);
            return Exist(nextPoint) ? nextPoint : p;
        }

        public override bool Exist(Point p)
        {
            return p.X >= 0 && p.X < SizeX && p.Y >= 0 && p.Y < SizeY;
        }

        public override void Add(IMappable mappable, Point point)
        {
            if (!fields.ContainsKey(point))
            {
                fields[point] = new List<IMappable>();
            }
            fields[point].Add(mappable);
        }

        public override void Remove(IMappable mappable, Point point)
        {
            if (fields.ContainsKey(point))
            {
                fields[point].Remove(mappable);
                if (fields[point].Count == 0)
                {
                    fields.Remove(point);
                }
            }
        }

        public override List<IMappable> At(Point point)
        {
            return fields.ContainsKey(point) ? fields[point] : new List<IMappable>();
        }
    }
}