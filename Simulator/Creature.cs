

namespace Simulator
{
    public abstract class Creature
    {
        private string name="Unknown";
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

        private int level=1;
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
        public abstract void SayHi();
       
        public void Upgrade()
        {
            if (Level < 10)
            {
                level++;
            }
        }
        public void Go(Directions directions)
        {
            switch (directions)
            {
                case Directions.Up:
                    Console.WriteLine($"{Name} goes up");
                    break;
                case Directions.Right:
                    Console.WriteLine($"{Name} goes right");
                    break;
                case Directions.Down:
                    Console.WriteLine($"{Name} goes down");
                    break;
                case Directions.Left:
                    Console.WriteLine($"{Name} goes left");
                    break;


            }
        }
        public void Go(Directions[] directions)
        {
            foreach (Directions direction in directions)
            {
                Go(direction);
            }
        }

        public void Go(string directionsString)
        {
            Directions[] directions = DirectionParser.Parse(directionsString);
            Go(directions);
        }


        public string Info
        {
            get { return $"{Name} [{Level}]"; }
        }
        public abstract int Power { get; }
    }
}