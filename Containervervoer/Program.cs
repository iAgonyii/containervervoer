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
            int length = 0;
            int width = 0;
            Console.WriteLine("Enter ship length");
            length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter ship width");
            width = Convert.ToInt32(Console.ReadLine());

            Ship ship = new Ship(length, width);

            List<IContainer> containers = ContainerFactory.MakeContainers(4, 8, 18);

           // try
           // {
            ship.PlaceAllContainers(containers);
            ship.HalfWeightsWithinBounds(ship.GetHalfWeights());
           // }
            //catch(Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}



            Console.ReadLine();
        }
    }
}
