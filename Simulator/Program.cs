﻿using System.Security.Cryptography.X509Certificates;

namespace Simulator
{
    internal class Program
    {

        static void Lab4b()
        {
            object[] myObjects = {
                new Animals() { Description = "dogs"},
                new Birds { Description = "  eagles ", Size = 10 },
                new Elf("e", 15, -3),
                new Orc("morgash", 6, 4)
            };
            Console.WriteLine("\nMy objects:");
            foreach (var o in myObjects) Console.WriteLine(o);
        }
        static void Lab4a()
        {
            Console.WriteLine("HUNT TEST\n");
            var o = new Orc() { Name = "Gorbag", Rage = 7 };
            o.SayHi();
            for (int i = 0; i < 10; i++)
            {
                o.Hunt();
                o.SayHi();
            }

            Console.WriteLine("\nSING TEST\n");
            var e = new Elf("Legolas", agility: 2);
            e.SayHi();
            for (int i = 0; i < 10; i++)
            {
                e.Sing();
                e.SayHi();
            }

            Console.WriteLine("\nPOWER TEST\n");
            Creature[] creatures = {
                o,
                e,
                new Orc("Morgash", 3, 8),
                new Elf("Elandor", 5, 3)
            };
            foreach (Creature creature in creatures)
            {
                Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Simulator! \n");
            Lab4b();
            Lab4a();


        }
    }
}