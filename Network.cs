using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_Réseau
{
    public class Network
    {
        public double total_consumption = 0;
        public double total_production = 0;

        public List<Node> network_nodes = new List<Node>();
        public List<Consumer> consumerList = new List<Consumer>();
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
            foreach (Consumer consumer in consumerList)
            {
                total_consumption += consumer.real_power;
            }
            return total_consumption;
            /*double total_consumption = 0;
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
            return total_consumption; */
        }
        public double get_total_production()
        {
            double total_production = 0;
            foreach(Producer producer in producerList)
            {
                total_production += producer.power;
            }
            return total_production;
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

        public void addActor(Actor my_actor, string name, Point new_placement)       
        {
            bool good_placement = true; // nous servira a accepter ou non le placement 
            
                if (this.network_grid.takenLocations.Contains(new_placement))
                {
                    good_placement = false;
                }
            

            if (good_placement)
            {                                                          
                this.network_grid.setTakenLocation(new_placement);
                my_actor.placement = new_placement;
                my_actor.name = name;

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

                else if (my_actor is Node)
                {
                    Node my_node = my_actor as Node ; 
                    this.network_nodes.Add(my_node);
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
                
            network_grid.takenLocations.Remove(my_actor.placement);
        }

    }
}   
