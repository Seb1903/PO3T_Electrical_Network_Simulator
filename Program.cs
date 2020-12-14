using System;
using System.Collections.Generic;

namespace Simulateur_Réseau
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid grid = new Grid(25,20);
            Network network = new Network(grid);
            Nuclear_plant ma_centrale = new Nuclear_plant(10, 20, 20);
            List<Point> placement_nuc = new List<Point>();
            placement_nuc.Add(grid.listOfLocations[0][2]);

            network.addActor(ma_centrale, placement_nuc);

            Graphics graphiques = new Graphics();
            string interface_graphique = graphiques.Draw(grid);
            Console.WriteLine("seb");
            Console.WriteLine(interface_graphique);


        }
    }
}
