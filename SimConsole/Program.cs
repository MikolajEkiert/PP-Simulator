using Simulator;
using Simulator.Maps;
using System.Text;

namespace SimConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var map = InitializeMap();
            var mappables = InitializeMappables();
            var points = InitializePoints();
            string moves = "uruldrdlldldrruduldd";

            var simulation = new Simulation(map, mappables, points, moves);
            var mapVisualizer = new MapVisualizer(simulation.Map);
            var simulationHistory = new SimulationHistory(simulation);

            RunSimulation(simulation, mapVisualizer, simulationHistory);

            DisplaySimulationResults(simulationHistory);
        }

        private static BigBounceMap InitializeMap()
        {
            return new BigBounceMap(6, 8);
        }

        private static List<IMappable> InitializeMappables()
        {
            return new List<IMappable>
            {
                new Orc("Gorbag"),
                new Elf("Elandor"),
                new Animals { Description = "Rabbits", Size = 10 },
                new Birds { Description = "Eagles", Size = 5 },
                new Birds { Description = "Ostriches", Size = 5, CanFly = false }
            };
        }

        private static List<Point> InitializePoints()
        {
            return new List<Point>
            {
                new Point(5, 7),
                new Point(5, 0),
                new Point(0, 7),
                new Point(5, 4),
                new Point(0, 0)
            };
        }

        private static void RunSimulation(Simulation simulation, MapVisualizer mapVisualizer, SimulationHistory simulationHistory)
        {
            int turn = 1;

            simulationHistory.RecordTurn();
            mapVisualizer.Draw();

            while (!simulation.Finished)
            {
                Console.Clear();
                Console.WriteLine($"Turn {turn}");
                Console.WriteLine($"{simulation.CurrentMappable.Info} - current position: {simulation.CurrentMappable.Position}, move: {simulation.CurrentMoveName}");
                mapVisualizer.Draw();

                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();

                simulation.Turn();
                simulationHistory.RecordTurn();

                turn++;
            }
        }

        private static void DisplaySimulationResults(SimulationHistory simulationHistory)
        {
            Console.WriteLine("Simulation Finished. Replaying turns.");
            ReplaySpecificTurns(simulationHistory);

            while (true)
            {
                Console.WriteLine("Enter a turn number to replay: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int turn))
                {
                    Console.Clear();
                    simulationHistory.ReplayTurn(turn);
                }
                else
                {
                    break;
                }
            }
        }

        private static void ReplaySpecificTurns(SimulationHistory simulationHistory)
        {
            simulationHistory.ReplayTurn(5);
            simulationHistory.ReplayTurn(10);
            simulationHistory.ReplayTurn(15);
            simulationHistory.ReplayTurn(20);
        }
    }
}