using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_Réseau
{
    class Réseau
    {
        public List<Consumer> consumerList;
        public List<Producer> producerList;
        public List<Node> nodeList;
        public double consumption;
        public double production;
        public double elecPrice; //pas certain
        public double wallet; 
        public double CO2;
        public Grid grid;

        public Réseau(Grid grid, double wallet)
        {
            this.grid = grid;
        }
        public void addConsumer(Consumer consumer)
        {
            this.consumerList.Add(consumer);
        }
        public void delConsumer(Consumer consumer)
        {
            this.consumerList.Remove(consumer);
        }
        public void addProducer(Producer producer)
        {
            this.producerList.Add(producer);
        }
        public void delProducer(Producer producer)
        {
            this.producerList.Remove(producer);
        }
        public void addNode(Node node)
        {
            this.nodeList.Add(node);
        }
        public void delNode(Node node)
        {
            this.nodeList.Remove(node);
        }
        public double getProduction()
        {
            return this.production;
        }
        public void setProduction()
        {
            foreach (Producer producer in producerList)
            {
                this.production = producer.getProduction();
            }
        }
        public double getConsumption()
        {
            return this.consumption;
        }
        public void setConsumption()
        {
            foreach (Consumer consumer in consumerList)
            {
                this.consumption = consumer.getRealConsumption();
            }
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
        public void setWallet()
        {
            foreach (Consumer consumer in consumerList)
            {
                this.wallet += consumer.getPrice();
            }
            foreach (Producer producer in producerList)
            {
                this.wallet += producer.getcostProduction();
            }
        }

    }
}
