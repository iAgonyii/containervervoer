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
            containers = MakeContainers();

            try
            {
                ship.PlaceAllContainers(containers);
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

            List<IContainer> containers = ContainerFactory.MakeContainers(valuable, coolable, normal);
            return containers;
        }

    }
}
