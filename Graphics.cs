using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_Réseau
{
    class Graphics
    {
        public Graphics()
        {

        }
        public void show_network_interface(Network network)
        {
            Console.WriteLine(" \n \n \n Voici l'état de la simulation à {0:HH:mm:ss.fff}", DateTime.Now);

            string Producteurs = " Ceci est la liste de producteurs : \n";
            foreach(Producer producer in network.producerList) {
                Producteurs += producer.name + "\n";
            }
            Console.WriteLine(Producteurs);

            string Consumers = "Ceci est la liste de consommateurs : \n";
            foreach (Consumer consumer in network.consumerList)
            {
                Consumers += consumer.name + "\n";
            }
            Console.WriteLine(Consumers);

            string Consumption = "La consommation totale vaut " + network.get_total_consumption().ToString() + "kWh";
            string Production = "La production totale du réseau vaut " + network.get_total_production().ToString() + "kWh";
          
            Console.WriteLine(Consumption);
            Console.WriteLine(Production);
            Console.WriteLine("Les producteurs produisent {0} kg de CO2 \n", network.getCO2());
        }


        public void show_meteo_interface(Network network)
        {
            double sunshine = 0 ;
            double windForce = 0;
            double temperature = 0;
            int npoints = 0;
            foreach(List<Point> line in network.network_grid.listOfLocations)
            {
                foreach (Point point in line)
                {
                    temperature += point.meteo.temperature;
                    windForce += point.meteo.windForce;
                    sunshine += point.meteo.sunshine;
                    npoints += 1;
                }
            }
            string global_meteo = "";
            global_meteo += "La météo moyenne pour l'ensemble du réseau vaut : \n";
            global_meteo += "- Température : " + (temperature / npoints).ToString() + "°C \n";
            global_meteo += "- Ensolleillement : " + (sunshine / npoints).ToString() + "% \n";
            global_meteo += "- Force du vent : " + (windForce / npoints).ToString() + "km/h \n";
            Console.WriteLine(global_meteo);
        }

        public void show_market_interface(Network network)
        {
            double electricityPrice = (network.network_market.getElectricityPurchasePrice() + network.network_market.getElectricitySalePrice()) / 2;
            string market = "Les différents prix du marché sont : \n";
            market += "- Électricité : " + electricityPrice.ToString() + "€ \n";
            market += "- Gaz " + network.network_market.getGasPurchasePrice() + "€ \n";
            market += "- Nucleaire " + network.network_market.getNuclearPurchasePrice() + "€ \n";
            Console.WriteLine(market);

        }
        public void show_error_messages(Network network)
        {
            if (network.needed_consumption < network.total_production)
            {
                Console.WriteLine("Le réseau est en sous-production"); 
            }
            if (network.total_consumption < network.total_production*1.2)
            {
                Console.WriteLine("Le réseau est en sur-production");
            }

            if (network.total_production == 0)
            {
                Console.WriteLine("BLACKOUT");
            }
        }
            
        }
 }


   