using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_Réseau
{
    public class Network
    {
        public double needed_consumption = 0 ;
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
            foreach (Consumer consumer in this.consumerList)
            {
                total_consumption += consumer.real_power;
            }
            return total_consumption;
           
        }
        public double get_needed_consumption()
        {
            double needed_consumption = 0;
            foreach (Consumer consumer in this.consumerList)
            {
                needed_consumption += consumer.power;
            }
            return needed_consumption;

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
        
        public void add_Node(Node my_node, String name, Point placement) {

            my_node.placement = placement;
            my_node.name = name;
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

        public void Update()
        {
            foreach(Actor actor in this.consumerList)
            {
                Random rnd = new Random();
                actor.power = rnd.Next(Convert.ToInt32(actor.power*0.9), Convert.ToInt32(actor.power * 1.1));
            }
            this.needed_consumption = this.get_needed_consumption();
            this.total_consumption = this.get_total_consumption();
            this.total_production = this.get_total_production();

            if (this.needed_consumption > this.total_production)
            {
                double percentage_of_change = 1.0 / this.producerList.Count;

                foreach (Producer producer in this.producerList)
                {
                    if (producer.power==0)
                    {
                        Console.WriteLine("La centrale {0} a été démarrée", producer.name);
                    }
                    double new_power = producer.power + (this.needed_consumption - this.total_production) * percentage_of_change;       //tous les producteurs vont se répartir le nouvelle charge à produire en parts égales //pose probleme dans les cas limites car la centrale ne produit pas assez vite 
                    if (producer is Nuclear_plant)
                    {
                        ((Nuclear_plant)producer).setpower(new_power);
                    }
                    else if (producer is Wind_farm)
                    {
                        ((Wind_farm)producer).setpower(new_power);
                    }
                    else
                    {
                        producer.setpower(new_power);
                    }
                    Console.WriteLine("La production de {0} a été modifiée et vaut maintenant {1} kWh",producer.name, new_power);
                }
            }
            if (this.needed_consumption < this.total_production)
            {
                double percentage_of_change = 1.0 / this.producerList.Count;
                foreach (Producer producer in this.producerList)
                {
                    double new_power = producer.power - (this.total_production - this.needed_consumption) * percentage_of_change * (producer.power/this.total_production);       //tous les producteurs vont se répartir le nouvelle charge à produire en parts égales 
                    if (new_power == 0)
                    {
                        Console.WriteLine("La centrale {0} a été arrêtée", producer.name);
                    }
                    if (producer is Nuclear_plant)
                    {
                        ((Nuclear_plant)producer).setpower(new_power);
                    }
                    else if (producer is Wind_farm)
                    {
                        ((Wind_farm)producer).setpower(new_power);
                    }
                    else
                    {
                        producer.setpower(new_power);
                    }
                }
            }

            foreach (Node node in this.network_nodes)
            {
                node.UpdatePower();
                Console.WriteLine("La distribution de {0} a été modifiée, la puissance passant par le noeud vaut maintenant {1} kWh", node.name, node.power);
            }

            this.needed_consumption = this.get_needed_consumption();
            this.total_consumption = this.get_total_consumption();
            this.total_production = this.get_total_production();
            this.setCO2();

            //ajouter update meteo ? 
        }

    }
}   
