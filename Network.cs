using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_Réseau
{
    class Network
    {
        public double total_consumption = 0;
        public List<Node> network_nodes;
        public List<Actor> network_actors;
        public Grid network_grid;

        public Network()
        {
            this.total_consumption = get_total_consumption(); 
        }





        public double get_total_consumption()
        {
            double total_consumption = 0;
            foreach(distributionNode node in this.network_nodes)
            {
                total_consumption += node.power; //if type == consommateur alors ajouter, ici on aura doublon
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
                this.network_actors.Add(my_actor);

            }
        }
    }
}   
