namespace Simulator;

class Creature
{
    private string name;
    private int level;

    public string Name
    {
        get => name;
        set
        {
            value = value.Trim();

            if (value.Length < 3)
            {
                value = value.PadRight(3, '#');
            }

            if (value.Length > 25)
            {
                value = value.Substring(0, 25).TrimEnd();
                if (value.Length < 3)
                {
                    value = value.PadRight(3, '#');
                }
            }

            if (char.IsLower(value[0]))
            {
                value = char.ToUpper(value[0]) + value.Substring(1);
            }

            name = value;
        }
    }

    public int Level
    {
        get => level;
        set
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

    public Creature(string name = "Unknown", int level = 1)
    {
        Name = name;
        Level = level;
    }

    public string Info => $"value: {Name}, Level: {Level}";

    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name} and I'm at level {Level}.");
    }

    public void Upgrade()
    {
        if (level <= 9)
        {
            level++;
        }
    }

    public void Go(Directions.Direction direction)
    {
        Console.WriteLine($"{Name} goes {direction.ToString().ToLower()}.");
    }

    public void Go(Directions.Direction[] directions)
    {
        foreach (var direction in directions)
        {
            Go(direction);
        }
    }

    public void Go(string directions)
    {
        var parsedDirections = DirectionParser.Parse(directions);
        Go(parsedDirections);
    }
}