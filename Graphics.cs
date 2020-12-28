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
        public void show_error_messages(Grid network_grid, string graphics)
        {
            
        }
            
            // parcourir les éléments du grid et par position on écrit dans le string ce que c'est (style ASCII) et on relie par des traits pour faire les lignes électriques 
            // ex de ce que ça donnerait au final : 
            /*
             *   graphics = "    C -------------------V
             *                   |
             *                   |
             *                   P--------V----D-------"
             *                      
             *                      on voit que C (une centrale est reliée à une ville (V))
             *                      on peut utiliser des / et \ pour des diagonales 
             *                      faut juste paramétrer en fonction de ce qui se trouve dans le grid et sa taille 
             *                      P = panneaux solaires, D = Dissipateur, etc. 
             * 
             * 
             * 
             * 
             * 
             * */
        }
 }


    /* string graphics = "";     // pour changer l'échelle : on peut mettre plusieurs espaces (et plusieurs \n)
            int i = 0;

            for (int current_line = 0; current_line < network_grid.width; current_line++)
            {
                foreach (Point point in network_grid.listOfLocations[current_line])
                {
                    if (network_grid.takenLocations.Contains(point))
                    {
                        //graphicsAschar = graphics.ToCharArray()  ?? 
                        graphics += point.name.Substring(0, 1);                     //pour prendre le prmier caractère 
                                                                                    //point.IsIn(network_grid.availableLocations    // faudra penser à rajouter les nodes dans takenLocations
                    }
                    else
                    {
                        graphics += " ";
                    }

                    i += 1;

                    if (i == network_grid.width)
                    {
                        graphics += "\n";     //pour passer à la ligne si on est arrivé à la largeur maximale
                        i = 0;
                    }
                }
            }
            return graphics;
            
            } */
