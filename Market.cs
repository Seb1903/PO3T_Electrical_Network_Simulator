using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_Réseau
{
	public class Market
	{
		double electricityPurchasePrice;
		double electricitySalePrice;

		double nuclearPurchasePrice;
		double gasPurchasePrice;

		
		public Market(double electricityPurchasePrice, double electricitySalePrice, double nuclearPurchasePrice, double gasPurchasePrice)
		{
			this.electricityPurchasePrice = electricityPurchasePrice;
			this.electricitySalePrice = electricitySalePrice;
			this.nuclearPurchasePrice = nuclearPurchasePrice;
			this.gasPurchasePrice = gasPurchasePrice;
		}
		public void set_average_prices(Network network, int variation)
        {
			
			Random random = new Random();
			foreach(Consumer consumer in network.consumerList)
            {

				this.electricityPurchasePrice += consumer.price;
            }
			foreach (Producer producer in network.producerList)
			{
				this.electricitySalePrice += producer.cost;
			}
			this.electricityPurchasePrice = this.electricityPurchasePrice/network.consumerList.Count + random.Next(-variation, variation); //ajouter les valeurs limite 
			this.electricitySalePrice = this.electricitySalePrice / network.producerList.Count + random.Next(-variation, variation);
		}
		public string getMarket()
		{
			return electricityPurchasePrice.ToString() + " " + electricitySalePrice.ToString() + " " + nuclearPurchasePrice.ToString() + " " + gasPurchasePrice.ToString();
		}
		public double getElectricityPurchasePrice()
		{
			return electricityPurchasePrice;
		}
		public double getElectricitySalePrice()
		{
			return electricitySalePrice;
		}
		public double getNuclearPurchasePrice()
		{
			return nuclearPurchasePrice;
		}
		public double getGasPurchasePrice()
		{
			return gasPurchasePrice;
		}
	}
}
