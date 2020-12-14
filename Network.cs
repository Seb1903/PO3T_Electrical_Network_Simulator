using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_Réseau
{
    public class Network
    {
        public double total_consumption = 0;
        public List<Node> network_nodes;  //mettre des new ...? 
        public List<Consumer> consumerList;
        public List<Producer> producerList = new List<Producer>();
        public Grid network_grid;
        public double wallet = 0;
        public double CO2;
        public Market network_market;

        public Network(Grid grid)
        {
            this.network_grid = grid;
            //this.total_consumption = get_total_consumption(); 
        }

        public double getCO2()
        {
            return this.CO2;
        }

        public void setCO2()
        {
            foreach (Producer producer in producerList)
            {
                this.CO2 = producer.getCO2Produced();
            }
        }
        public double getWallet()
        {
            return this.wallet;
        }

        public void set_generic_market(int variation)
        {
            network_market.set_average_prices(this, variation);
        }

        public double get_total_consumption()
        {
            double total_consumption = 0;
            foreach(distributionNode node in this.network_nodes)
            {
                foreach(Actor target in node.targets) 
                { 
                    if(target is Consumer) 
                    { 
                        total_consumption += node.power; //pour éviter d'ajouter un doublon si une target est un doublon
                    }
                }
            }
            return total_consumption;
        }

        public void get_network_nodes()
        {
           
        }
        
        public void add_Node(Node my_node, Point placement) {

            my_node.placement = placement;
            network_grid.takenLocations.Add(placement);
            this.network_nodes.Add(my_node);

        }
        public void delNode(Node node)
        {
            this.network_nodes.Remove(node);
            network_grid.takenLocations.Remove(node.placement);
        }

        public void addActor(Actor my_actor, List<Point> new_placement)       //mettre une limitation sur les points ? -> ceux-ci doivent être proches l'un de l'autre 
        {
            bool good_placement = true; // nous servira a accepter ou non le placement 
            foreach (Point point in new_placement)
            {
                if (this.network_grid.takenLocations.Contains(point))
                {
                    good_placement = false;
                }

                if (good_placement)
                {  //comme ça si le placement est faux juste avant, pas besoin de faire toute la boucle car on sait déjà que c'est faux
                    foreach (Point sidepoint in new_placement) // on va comparer les points proposés entre eux pour être sûrs qu'ils sont tous proches l'un de l'autre
                    {
                        if (!(point.xCoordinate == sidepoint.xCoordinate && point.yCoordinate == sidepoint.yCoordinate))
                        {  //on regarde déjà si c'est pas exactement le même point 
                            if (!(point.xCoordinate == sidepoint.xCoordinate + 1 || point.xCoordinate == sidepoint.xCoordinate - 1))
                            {
                                if (!(point.yCoordinate == sidepoint.yCoordinate + 1 || point.yCoordinate == sidepoint.yCoordinate - 1))
                                {      // si aucune proximité en x alors on regarde en y (pas sûr que ce soit nécessaire)

                                    good_placement = false;           //on compare chaque point avec les autres points, s'ils ne sont pas proches alors pas bon placement 

                                }
                            }
                        }
                    }
                }
            }

            if (good_placement)
            {                                                           // si toutes les conditions sont validées
                foreach (Point point in new_placement)
                {
                    this.network_grid.setTakenLocation(point);
                }
                my_actor.placement = new_placement;

                if(my_actor is Consumer)
                {
                    Consumer my_consumer = my_actor as Consumer;
                    this.consumerList.Add(my_consumer);
                }
                else if (my_actor is Producer)
                {
                    Producer my_producer = my_actor as Producer;
                    this.producerList.Add(my_producer);
                }

            }
        }
        public void delActor(Actor my_actor)
        {
            if (my_actor is Consumer)
            {
                Consumer my_consumer = my_actor as Consumer;
                this.consumerList.Remove(my_consumer);
            }
            else if (my_actor is Producer)
            {
                Producer my_producer = my_actor as Producer;
                this.producerList.Remove(my_producer);
            }

            foreach (Point point in my_actor.placement)
                network_grid.takenLocations.Remove(point);
        }

    }
}   
