using Simulator.Maps;

namespace Simulator
{
    internal class Program
    {

        static void Lab5a()
        {
            Console.WriteLine("POINT CREATION AND METHODS TEST\n");
            Point p = new(15, 30);
            Console.WriteLine(p.Next(Direction.Right)); // (16, 30)
            Console.WriteLine(p.NextDiagonal(Direction.Right)); // (16, 29)

            Console.WriteLine("\nRECTANGLE CREATION TEST\n");
            var r1 = new Rectangle(2, 3, 4, 5);
            Console.WriteLine(r1); // (2, 3):(4, 5)
            var r2 = new Rectangle(new Point(6, 7), new Point(8, 9));
            Console.WriteLine(r2); // (6, 7):(8, 9)

            Console.WriteLine("\nCOORDINATE ORDER TEST\n");
            var r3 = new Rectangle(4, 5, 2, 3);
            Console.WriteLine(r3); // (2, 3):(4, 5)
            var r4 = new Rectangle(new Point(8, 9), new Point(6, 7));
            Console.WriteLine(r4); // (6, 7):(8, 9)

            Console.WriteLine("\nHANDLE EXCEPTION TEST\n");
            try
            {
                var r5 = new Rectangle(1, 2, 5, 3);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd tworzenia prostokąta r5: {ex.Message}");
            }

            try
            {
                var r6 = new Rectangle(new Point(2, 6), new Point(3, 6));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd tworzenia prostokąta r6: {ex.Message}");
            }

            var r7 = new Rectangle(1, 1, 7, 7);

            Console.WriteLine("\nCONTAINS METHOD TEST\n");
            Console.WriteLine(r7.Contains(new Point(-2, -2))); //False
            Console.WriteLine(r7.Contains(new Point(7, 7))); //True
            Console.WriteLine(r7.Contains(new Point(3, 3))); //True
        }

        static void Lab5b()
        {
            Console.WriteLine("SIZE TEST\n");
            try
            {
                var map1 = new SmallSquareMap(2);
                Console.WriteLine("Utworzono mapę map1");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd przy tworzeniu mapymap1: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Koniec testu");
            }

            try
            {
                var map2 = new SmallSquareMap(11);
                Console.WriteLine("Utworzono mapę map2");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd przy tworzeniu mapy map2: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Koniec testu");
            }

            Console.WriteLine("---EXIST TEST---");
            var map3 = new SmallSquareMap(11);
            Console.WriteLine(map3.Exist(new Point(-1, -1))); //False
            Console.WriteLine(map3.Exist(new Point(3, 3))); //True
            Console.WriteLine(map3.Exist(new Point(11, 11))); //True
            Console.WriteLine(map3.Exist(new Point(12, 12))); //False

            Console.WriteLine("---NEXT TEST---");
            Console.WriteLine(map3.Next(new Point(10, 11), Direction.Up)); //(10, 11)
            Console.WriteLine(map3.Next(new Point(-2, -2), Direction.Down)); //(-2, -2)
            Console.WriteLine(map3.Next(new Point(10, 11), Direction.Down)); //(10, 10)

            Console.WriteLine("---NEXT DIAGONAL TEST---");
            Console.WriteLine(map3.NextDiagonal(new Point(-3, -3), Direction.Down)); //(-3, -3)
            Console.WriteLine(map3.NextDiagonal(new Point(18, 19), Direction.Up)); //(18, 19)
            Console.WriteLine(map3.NextDiagonal(new Point(11, 12), Direction.Down)); //(10, 11)
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Simulator! \n");
            Point p = new(15, 30);
            Lab5a();
            Lab5b();
        }
        
    }
}