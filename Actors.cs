using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_Réseau
{
	public class Actor
	{
		public List<Point> placement;
		public int area;  //un point est une aire, servira pour faire des moyennes pour la météo 
		public Line line;
		public void setPlacement(List<Point> new_placement, Grid current_grid)       //mettre une limitation sur les points ? -> ceux-ci doivent être proches l'un de l'autre 
		{
			bool good_placement = true; // nous servira a accepter ou non le placement 
			foreach (Point point in new_placement) {
                if (current_grid.takenLocations.Contains(point))
                {
					good_placement = false;
                }

				if (good_placement) {  //comme ça si le placement est faux juste avant, pas besoin de faire toute la boucle car on sait déjà que c'est faux
					foreach (Point sidepoint in new_placement) // on va comparer les points proposés entre eux pour être sûrs qu'ils sont tous proches l'un de l'autre
					{	if (!(point.xCoordinate == sidepoint.xCoordinate && point.yCoordinate == sidepoint.yCoordinate)) {  //on regarde déjà si c'est pas exactement le même point 
							if (!( point.xCoordinate == sidepoint.xCoordinate + 1 || point.xCoordinate == sidepoint.xCoordinate - 1)) 
							{
								if (!(point.yCoordinate == sidepoint.yCoordinate + 1 || point.yCoordinate == sidepoint.yCoordinate - 1)) {      // si aucune proximité en x alors on regarde en y (pas sûr que ce soit nécessaire)

									good_placement = false;           //on compare chaque point avec les autres points, s'ils ne sont pas proches alors pas bon placement 

								}
							}
						}
					}
				}
			}

            if (good_placement) {															// si toutes les conditions sont validées
				foreach (Point point in new_placement){
					current_grid.setTakenLocation(point);
				}
				this.placement = new_placement;
			}
		}

		public List<Point> getPlacement()
		{
			return this.placement;
		}
		public void setLine(Line line)
        {
			this.line = line;
        }
		public Line getLine()
        {
			return this.line;
        }
	}



	public class Consumer : Actor
	{
		public double consumption;
		public double price;
		public double realComsumption;

		public Consumer(double consumption, double price){
			this.consumption = consumption;
			this.price = price;
		}
		public void setConsumption(double choosen_consumption, double coeffRandom, int variation)
		{
			Random rnd = new Random();
			this.consumption = choosen_consumption + coeffRandom *rnd.Next(-variation, variation);  //convertir en double 
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
			return this.consumption;
		}
		public void UppdatePowerNeeded()
		{
			this.line.setPowerNeeded(this.consumption);
		}
		public void setRealComsumpton()
        {
			this.realComsumption = this.line.getPowerIn();
		}
		public double getRealConsumption()
        {
			return this.realComsumption;
        }

	}


	public class Producer : Actor
    {
		public double production;
		public double CO2;
		public double cost;
		
		public Producer(double production, double CO2, double cost)
        {
			this.production = production;
			this.CO2 = CO2;
			this.cost = cost;
        }
		public void setProduction(double produced, int coeffRandom, int variation)
		{
			Random rnd = new Random();
			this.production = produced + coeffRandom * rnd.Next(-variation, variation);
		}

		public double getProduction()
		{
			return this.production;
		}
		public void setcostProduction(double choosen_cost)  // prix des combustibles à prendre en compte 
		{
			double cost = choosen_cost;
		}
		public double getcostProduction()  // prix des combustibles à prendre en compte 
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
		public void UppdatePowerIn()
        {
			this.line.setPowerIn(this.production);
		}
	}

	

	public class City : Consumer    //https://stackoverflow.com/questions/56867/doubleerface-vs-base-class
	{
		public City(double consumption, double price) : base(consumption, price)   //permet d'appeler le constructeur de Consumer
        {

        }


	}
	public class Business : Consumer
	{
		public Business(double consumption, double price) : base(consumption, price)
		{

		}

	}
	public class Foreign : Consumer
	{
		public Foreign(double consumption, double price) : base(consumption, price)
		{

		}

	}

	public class Dissipator : Consumer
	{
		public Dissipator(double consumption, double price) : base(consumption, price)     // pas sûr de devoir le définir de la même manière.
		{

		}

	}

	// pour arrêter une centrale : mettre la production à 0 
	public class Nuclear_plant : Producer
    {
		public Nuclear_plant(double production, double CO2, double cost) : base(production, CO2, cost)
        {
			
        }
		public void setProduction(double produced)
		{
			if (this.production/produced < 1)
			{
				while (1 - this.production / produced > 0.0001)  // tant qu'il n'y a pas 0,001% de différence max
				{
					this.production += 0.01 * (this.production-produced);	  // laisser l'utilisateur paramétrer la vitesse peut-être
				}
			}

			if (this.production / produced > 1)
			{
				while ( (this.production -1)/ produced > 0.0001)  // tant qu'il n'y a pas 0,001% de différence max
				{
					this.production -= 0.01 * (this.production - produced);
					Math.Round(this.production);			// laisser l'utilisateur paramétrer la vitesse peut-être
				}
			}
		}
    }
	public class Gas_plant : Producer
	{
		public Gas_plant(double production, double CO2, double cost) : base(production, CO2, cost)
		{

		}
	}
	public class Wind_farm : Producer
	{
		public Meteo plant_meteo; //mettre = new Meteo() ? 

		public Wind_farm(double production, double CO2, double cost) : base(production, CO2, cost)
		{
			foreach(Point point in placement)                    //on va automatiqument initialiser des données meteos pour la centrale à travers le constructeur, en prenant la moyenne des meteos des points ou elle se trouve 
            {
				this.plant_meteo.windForce += point.meteo.windForce;    //gérer le cas défaut peut être ? 

			}
			this.plant_meteo.windForce /= this.area ;     //nous permet de faire la moyenne puisque l'aire équivaut aux nombres de points dans placement 

			this.production = production * this.plant_meteo.windForce / 30; //30 km/h est la moyenne nationale pour la force du vent, nous permet ici de faaire un ratio pour ajuster la production


		}
		public void setProduction(double produced)
		{
			if (this.production / produced > 1)
			{
				while ((this.production - 1) / produced > 0.0001)  // tant qu'il n'y a pas 0,001% de différence max
				{
					this.production -= 0.6 * (this.production - produced);
					Math.Round(this.production);            // laisser l'utilisateur paramétrer la vitesse peut-être
				}
			}
		}
	}
	public class Solar_plant : Producer
	{
		public Meteo plant_meteo;
		public Solar_plant(double production, double CO2, double cost) : base(production, CO2, cost)
		{
			foreach (Point point in placement)         
			{
				this.plant_meteo.sunshine += point.meteo.sunshine;
			}

			this.production = production * this.plant_meteo.sunshine / 0.6; //utilisateurs donnentl'ensolleiment en 0.6 = moyenne nationale on peut imaginer le 0.6 remplacé par la moyenne du grid
		}

	}

	public class Buy_foreign : Producer
	{
		public Buy_foreign(double production, double CO2, double cost) : base(production, CO2, cost)
		{

		}
	}

}




/*  interface IConsumer
{

	// peut-être créer un int consommation ? 
	public void Consume(int consumed, int coefficientAleatoire, int variation)
	{

		//ajoutera le int à une variable consommation sûrement 
	}

	public void getPrice()
	{
		// retourne le prix de l'électricité utilisée
	}

	public void getConsumption()
	{
		// retourne la consommation, à la seconde près, probablement que Consume sera variable
	}
}  

interface IProducer
{
	// peut-être créer un int production  ? 
	public void Produce(int Produced)
	{
		//ajoutera le int à une variable production sûrement 
		//surement prendre un deuxième paramètre qui servira de coefficient de variation. 
	}

	public void getProduce()
	{
		// retourne le prix de l'électricité utilisée
	}
	public void setcostProduce()  // prix des combustibles à prendre en compte 
	{
		// retourne la consommation, à la seconde près, probablement que Consume sera variable
	}
	public void getcostProduce()  // prix des combustibles à prendre en compte 
	{
		// retourne la consommation, à la seconde près, probablement que Consume sera variable
	}

	public void getCO2Produced()
	{

	}
	public void setCO2Produced() // sûrement essayer de taper ça dans le constructeur (si constructeur possible)
	{

	}
}



 */