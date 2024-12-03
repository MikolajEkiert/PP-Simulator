namespace Simulator.Maps;

public interface IMappable
{
    public char Symbol { get; }

    void initMapAndPosition(Map map, Point position);
    void Go(Direction direction);

}