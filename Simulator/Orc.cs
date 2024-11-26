namespace Simulator
{
    public class Orc : Creature
    {
        private int rage = 1;
        private int counter;

        public int Rage
        {
            get { return rage; }
            init
            {
                rage = Validator.Limiter(value, 0, 10);
            }
        }

        public void Hunt()
        {
            counter++;
            if (counter % 2 == 0)
            {
                if (rage < 10) rage++;
            }
        }

        public Orc() { }

        public Orc(string name, int level = 1, int rage = 1) : base(name, level)
        {
            Rage = rage;
        }

        public override string Greetings()
        {
            return $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}";
        }

        public override int Power => 7 * Level + 3 * Rage;

        public override string Info => $"Orc {Name}, Level: {Level}, Rage: {Rage}";
    }
}