using Simulator.Maps;

namespace Simulator
{
    public abstract class Creature
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

        public Creature(string name, int level = 1)
        {
            Name = name;
            Level = level;
        }

        public Creature() { }

        public abstract string Greetings();
       
        public void Upgrade()
        {
            if (Level < 10)
            {
                level++;
            }
        }

        public void Go(Direction directions)
    {
        if (Map != null)
        {
            var nextPosition = Map.Next(Position, directions);
            if (!Map.Exist(nextPosition))
            {
                Console.WriteLine($"Invalid move. {this.Info} tried to move out of bounds.");
                return;
            }
            try
            {
                Map.Move(this, Position, directions);
                Position = nextPosition;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to move {this.Info}: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Creature's map is not set. Cannot move.");
        }
    }

        public abstract int Power { get; }

        public abstract string Info { get; }

        public override string ToString()
        {
            return $"{GetType().Name.ToUpper()}: {Info}";
        }
    }
}