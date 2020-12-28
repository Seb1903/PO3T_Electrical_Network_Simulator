using System;
using System.Collections.Generic;
using System.Timers;
using System.Threading;




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
            Gas_plant centrale_gaz = new Gas_plant(20, 1000, market);



            network.addActor(ma_centrale,"Thiange 1", grid.listOfLocations[0][2]);
            network.addActor(centrale_gaz, "Gazoil", grid.listOfLocations[0][5]);



            Graphics graphiques = new Graphics();

            City Bruxelles = new City(15, 5);
            City Londres = new City(15, 5);

            distributionNode node = new distributionNode();

            Line line1 = new Line(15, "L1");
            Line line2 = new Line(25, "L2");
            Line line3 = new Line(25, "L3");

            node.addIncomingLine(line1, ma_centrale);
            node.addOutgoingLine(line2, Bruxelles);
            node.addOutgoingLine(line3, Londres);


            network.add_Node(node, grid.listOfLocations[0][7]);
            network.addActor(Bruxelles, "Bruxelles", grid.listOfLocations[0][8]);
            network.addActor(Londres, "Londres", grid.listOfLocations[0][9]);

            while (true)
            {
                Thread.Sleep(5000);
                network.Update();
                graphiques.show_network_interface(network);
                graphiques.show_meteo_interface(network);
            }
            
            
            
        }
        

    }
}
