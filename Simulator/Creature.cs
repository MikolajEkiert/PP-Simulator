

using System.Runtime.InteropServices.JavaScript;

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
        public abstract string Greetings();
       
        public void Upgrade()
        {
            if (Level < 10)
            {
                level++;
            }
        }

        public string Go(Direction direction) => $"{direction.ToString().ToLower()}";
        public string[] Go(Direction[] directions)
        {
            var result = new string[directions.Length];
            for (int i = 0; i < directions.Length; i++)
            {
                result[i] = Go(directions[i]);
            }

            return result;
        }

        public string[] Go(string directionsString) => Go(DirectionParser.Parse(directionsString));


        public string Info
        {
            get { return $"{Name} [{Level}]"; }
        }
        public abstract int Power { get; }
    }
}