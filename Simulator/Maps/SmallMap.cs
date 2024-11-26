namespace Simulator.Maps;
public abstract class SmallMap : Map
{
   private readonly List<Creature>?[,] _fields;

    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX >20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Mapa jest zbyt szeroka");
        if (sizeY >20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Mapa jest zbyt wysoka");
        _fields = new List<Creature>[sizeX, sizeY];
    }
    protected override List<Creature>?[,] Fields => _fields;

    
}