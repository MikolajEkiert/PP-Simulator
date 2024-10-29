namespace Simulator;

class Creature
{
    public string Name { get; set; }
    public int Level { get; set; } = 1;
    
    public Creature(string name, int level)
    {
        Name = name;
        Level = level;
    }

   
    public string Info => $"Name: {Name}, Level: {Level}";
    
    public void SayHi()
    {
      Console.WriteLine($"Hi, I'm {Name} and I'm at level {Level}.");
    }


}

