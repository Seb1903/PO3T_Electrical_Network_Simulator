using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_Réseau
{
	public class Actor 
	{
		public Point placement;
		public double power;
		public double real_power;
		public string name; 


		public Point getPlacement()
		{
			return this.placement;
		}
	}



	public class Consumer : Actor
	{
		
		public double price;

		public Consumer(double power, double price){
			this.power = power;
			this.price = price;
		}
		public void setConsumption(double choosen_power, double coeffRandom, int variation)
		{
			Random rnd = new Random();
			this.power = choosen_power + coeffRandom *rnd.Next(-variation, variation);  //convertir en double 
			//ajoutera le double à une variable consommation sûrement 
		}

		public void setPrice(double wanted_price)
        {
			this.price = wanted_price;
        }

		public double getPrice()
		{
			return this.price;
		}

		public double getConsumption()
		{
			return this.power;
		}

	}


	public class Producer : Actor
    {
		
		public double CO2;
		public double cost;
		
		public Producer(double power, double CO2, double cost)
        {
			this.power = power;
			this.CO2 = CO2;
			this.cost = cost;
        }
		public void setpower(double produced)
		{
			Random rnd = new Random();
			this.power = rnd.Next(Convert.ToInt32(produced*0.9), Convert.ToInt32(produced * 1.1)) ; // permet de générer une part d'aléatoire
		}

		public double getpower()
		{
			return this.power;
		}
		public void setcostpower(double choosen_cost)  // prix des combustibles à prendre en compte 
		{
			double cost = choosen_cost;
		}
		public double getcostpower()  // prix des combustibles à prendre en compte 
		{
			return this.cost;
		}

		public void setCO2Produced(double choosen_pollution) // sûrement essayer de taper ça dans le constructeur (si constructeur possible)
		{
			this.CO2 = choosen_pollution;
		}

		public double getCO2Produced()
		{
			return this.CO2;
		}
		
	}

	

	public class City : Consumer    //https://stackoverflow.com/questions/56867/doubleerface-vs-base-class
	{
		public City(double power, double price) : base(power, price)   //permet d'appeler le constructeur de Consumer
        {

        }


	}
	public class Business : Consumer
	{
		public Business(double power, double price) : base(power, price)
		{

		}

	}
	public class Foreign : Consumer
	{
		public Foreign(double power, double price) : base(power, price)
		{

		}

	}

	public class Dissipator : Consumer
	{
		public Dissipator(double power, double price) : base(power, price)     
		{

		}

	}

	// pour arrêter une centrale : mettre le power à 0 
	public class Nuclear_plant : Producer
    {
		public double fuel_cost;
		public Nuclear_plant(double power, double CO2, Market market) : base(power, CO2, 0)
        {
			this.fuel_cost = market.getNuclearPurchasePrice() ;
			this.cost = fuel_cost * 3;
		}
	public new void setpower(double produced)
		{
			if (this.power/produced < 1)
			{		
					this.power += 0.05 * (produced - this.power);   // permet de modifier lentement la production		
					Math.Round(this.power);
			}

			if (this.power / produced > 1)
			{
				
					this.power -= 0.05 * (this.power - produced);
					Math.Round(this.power);			// laisser l'utilisateur paramétrer la vitesse peut-être
			}
		}
    }
	public class Gas_plant : Producer
	{
		public double fuel_cost;
		public Gas_plant(double power, double CO2,  Market market) : base(power, CO2, 0)
		{
			this.fuel_cost = market.getGasPurchasePrice();
			this.cost = fuel_cost * 0.5;
		}
	}
	public class Wind_farm : Producer
	{
		public Meteo plant_meteo; //mettre = new Meteo() ? 

		public Wind_farm(double power, double CO2, double cost) : base(power, CO2, cost)
		{
			this.plant_meteo.windForce += placement.meteo.windForce;    
			this.power = power * this.plant_meteo.windForce / 30; //30 km/h est la moyenne nationale pour la force du vent, nous permet ici de faaire un ratio pour ajuster la power
		}
		public new void setpower(double produced)
		{
			if (this.power / produced > 1)
			{
				this.power -= 0.6 * (this.power - produced);
				this.power = power * this.plant_meteo.windForce / 30;
				Math.Round(this.power);            // laisser l'utilisateur paramétrer la vitesse peut-être

			}
		}
	}
	public class Solar_plant : Producer
	{
		public Meteo plant_meteo;
		public Solar_plant(double power, double CO2, double cost) : base(power, CO2, cost)
		{  
			this.plant_meteo.sunshine = placement.meteo.sunshine;
			this.power = power * this.plant_meteo.sunshine / 0.6; //utilisateurs donnentl'ensolleiment en 0.6 = moyenne nationale on peut imaginer le 0.6 remplacé par la moyenne du grid
		}

	}

	public class Buy_foreign : Producer
	{
		public Buy_foreign(double power, double CO2, double cost) : base(power, CO2, cost)
		{

		}
	}

}




