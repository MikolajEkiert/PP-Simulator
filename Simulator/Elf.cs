namespace Simulator;

public class Elf : Creature
{
    private int agility = 1;
    public int Agility
    {
        get => agility;
        init
        {
            if (value < 0)
            {
                value = 0;
            }
            if (value > 10)
            {
                value = 10;
            }

            agility = value;
        }
    }

    private int singCounter = 0;

    public override int Power => 8 * Level + 2 * Agility;

    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }

    public Elf() { }
    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");

    public void Sing()
    {
        Console.WriteLine($"{Name} is singing.");
        singCounter++;
        if (singCounter % 3 == 0 & agility < 10)
        {
            agility++;
        }
    }
}