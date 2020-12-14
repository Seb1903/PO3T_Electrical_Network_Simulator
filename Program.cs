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
            Market market = new Market(6, 6, 6, 6);
            Nuclear_plant ma_centrale = new Nuclear_plant(10, 20, market);


            network.addActor(ma_centrale,"Thiange 1", grid.listOfLocations[0][2]);

            Graphics graphiques = new Graphics();
            graphiques.show_network_interface(network);


        }
    }
}
