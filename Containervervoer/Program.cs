using Containervervoer.Logic;
using Containervervoer.Logic.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containervervoer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IContainer> containers;
            int length = 0;
            int width = 0;

            Console.WriteLine("Enter ship length");
            length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter ship width");
            width = Convert.ToInt32(Console.ReadLine());

            Ship ship = new Ship(length, width);
            Console.WriteLine("Min full containers: " + ship.minWeight / 30);
            Console.WriteLine("Max full containers: " + ship.maxWeight / 30);
            Console.WriteLine(Environment.NewLine + Environment.NewLine);
            Console.WriteLine("Min empty containers: " + ship.minWeight / 4);
            Console.WriteLine("Max empty containers: " + ship.maxWeight / 4);
            Console.WriteLine(Environment.NewLine + Environment.NewLine);
            containers = MakeContainers();

            try
            {
                ship.PlaceAllContainers(containers);
                Console.WriteLine(Environment.NewLine + "Visualizer URL:" + Environment.NewLine + VisualizerURLBuilder.BuildURL(ship));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key to restart");
                Console.ReadKey();
                System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                Environment.Exit(0);
            }
            Console.ReadLine();
        }

        private static List<IContainer> MakeContainers()
        {
            Console.WriteLine("Enter amount of valuable containers: ");
            int valuable = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter amount of coolable containers: ");
            int coolable = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter amount of normal containers: ");
            int normal = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Press X for full containers, Y for empty containers, Z for random weights");
            var key = Console.ReadKey();
            Console.WriteLine(Environment.NewLine);
            List<IContainer> containers = new List<IContainer>();
            if (key.Key == ConsoleKey.X)
            {
                containers = ContainerFactory.MakeContainers(valuable, coolable, normal);
            }
            if (key.Key == ConsoleKey.Y)
            {
                containers = ContainerFactory.MakeContainersEmpty(valuable, coolable, normal);
            }
            if (key.Key == ConsoleKey.Z)
            {
                containers = ContainerFactory.MakeContainersRandomWeights(valuable, coolable, normal);
            }
            
            return containers;
        }

    }
}
