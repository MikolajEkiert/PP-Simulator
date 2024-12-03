namespace Simulator.Maps;

public interface IMappable
{
    // int SizeX { get; }
    // int SizeY { get; }
    // List<Creature> At(Point point);
    // void Move(Point from, Point to);
    // void Remove(Point point, Creature creature);
    // void Add(Point point, Creature creature);
    void initMapAndPosition(Map map, Point position);
    void Go(Direction direction);

}