using Simulator.Maps;

namespace Simulator
{
    public abstract class Creature: IMappable
    {
        public Map? Map { get; private set; }
        public Point Position { get; private set; }

        public void initMapAndPosition(Map map, Point position)
        {
            Map = map;
            Position = position;
        }
        
        private string name = "Unknown";
        public string Name
        {
            get { return name; }
            init
            {
                var trimmed = value.Trim();
                if (trimmed.Length < 3)
                {
                    trimmed = trimmed.PadRight(3, '#');
                }
                else if (trimmed.Length > 25)
                {
                    trimmed = trimmed.Substring(0, 25);
                }
                if (!char.IsUpper(trimmed[0]))
                {
                    trimmed = char.ToUpper(trimmed[0]) + trimmed.Substring(1); 
                }
                trimmed = trimmed.Trim();
                if (trimmed.Length < 3)
                {
                    trimmed = trimmed.PadRight(3, '#');
                }

                name = trimmed;
            }
        }

        private int level = 1;
        public int Level
        {
            get { return level; }
            init
            {
                if (value < 1)
                {
                    value = 1;
                }
                else if (value > 10)
                {
                    value = 10;
                }
                level = value;
            }
        }

        public Creature() { }

        public Creature(string name, int level = 1)
        {
            Name = name;
            Level = level;
        }
        
        public abstract string Greetings();
       
        public void Upgrade()
        {
            if (Level < 10)
            {
                level++;
            }
        }

        public void Go(Direction direction)
        {
            if (Map == null)
                return; 

            Point nextPosition = Map.Next(Position, direction);
            Map.Move(this, Position, nextPosition);
            Position = nextPosition;
        }

        public abstract int Power { get; }

        public abstract string Info { get; }
        
        public abstract char Symbol { get; } 

        public override string ToString()
        {
            return $"{GetType().Name.ToUpper()}: {Info}";
        }
    }
}