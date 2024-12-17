using Simulator;

public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = new List<SimulationTurnLog>();

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ?? throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
    }

    public void RecordTurn()
    {
        var symbols = new Dictionary<Point, List<char>>();
        foreach (var mappable in _simulation.IMappables)
        {
            if (!symbols.ContainsKey(mappable.Position))
            {
                symbols[mappable.Position] = new List<char>();
            }
            symbols[mappable.Position].Add(mappable.Symbol);
        }

        var log = new SimulationTurnLog
        {
            Mappable = _simulation.CurrentMappable.ToString(),
            Move = _simulation.CurrentMoveName,
            Symbols = symbols
        };

        TurnLogs.Add(log);
    }

    public void ReplayTurn(int turnNumber)
    {
        if (turnNumber < 1 || turnNumber > TurnLogs.Count)
        {
            Console.WriteLine("Invalid turn number.");
            return;
        }

        var log = TurnLogs[turnNumber - 1];
        Console.WriteLine($"Turn {turnNumber}:");
        Console.WriteLine($"Mappable: {log.Mappable}");
        Console.WriteLine($"Move: {log.Move}");
        foreach (var symbol in log.Symbols)
        {
            Console.WriteLine($"Position: {symbol.Key}, Symbols: {string.Join(", ", symbol.Value)}");
        }
    }
}