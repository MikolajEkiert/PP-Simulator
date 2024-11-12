namespace Simulator
{
    public static class DirectionParser
    {
        public static Directions[] Parse(string input)
        {
            List<Directions> directions = new List<Directions>();
            foreach (char c in input.ToUpper())
            {
                switch (c)
                {
                    case 'U':
                        directions.Add(Directions.Up);
                        break;
                    case 'R':
                        directions.Add(Directions.Right);
                        break;
                    case 'D':
                        directions.Add(Directions.Down);
                        break;
                    case 'L':
                        directions.Add(Directions.Left);
                        break;
                    default:

                        break;

                }

            }
            return directions.ToArray();
        }
    }

}