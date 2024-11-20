namespace Simulator.Maps;

public abstract class SmallMap : Map
{
   List<Creature>? [,] _field;
    
    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX >20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Mapa jest zbyt szeroka");
        if (sizeY >20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Mapa jest zbyt wysoka");

    }
    
}