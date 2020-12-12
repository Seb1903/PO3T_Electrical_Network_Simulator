using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_Réseau
{
	public class Actor
	{
		public List<Point> placement;
		int area;  //un point est une aire, servira pour faire des moyennes pour la météo 

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
	}



	public class Consumer : Actor
	{
		public int consumption;
		public int price;

		public Consumer(int consumption, int price){
			this.consumption = consumption;
			this.price = price;
		}
		public void setConsumption(int choosen_consumption, int isRandom, int variation)
		{
			Random rnd = new Random();
			this.consumption = choosen_consumption + isRandom *rnd.Next(-variation, variation);
			//ajoutera le int à une variable consommation sûrement 
		}

		public void setPrice(int wanted_price)
        {
			this.price = wanted_price;
        }

		public int getPrice()
		{
			return this.price;
		}

		public int getConsumption()
		{
			return this.consumption;
		}

	}


	public class Producer : Actor
    {
		int production;
		int CO2;
		int cost; 
		
		public Producer(int production, int CO2, int cost)
        {
			this.production = production;
			this.CO2 = CO2;
			this.cost = cost;
        }
		public void setProduction(int produced)
		{
			this.production = produced;
		}

		public int getProduction()
		{
			return this.production;
		}
		public void setcostProduction(int choosen_cost)  // prix des combustibles à prendre en compte 
		{
			int cost = choosen_cost;
		}
		public int getcostProduction()  // prix des combustibles à prendre en compte 
		{
			return this.cost;
		}

		public void setCO2Produced(int choosen_pollution) // sûrement essayer de taper ça dans le constructeur (si constructeur possible)
		{
			this.CO2 = choosen_pollution;
		}

		public int getCO2Produced()
		{
			return this.CO2;
		}
		
	}

	

	public class City : Consumer    //https://stackoverflow.com/questions/56867/interface-vs-base-class
	{
		public City(int consumption, int price) : base(consumption, price)   //permet d'appeler le constructeur de Consumer
        {

        }


	}
	public class Business : Consumer
	{
		public Business(int consumption, int price) : base(consumption, price)
		{

		}

	}
	public class Foreign : Consumer
	{
		public Foreign(int consumption, int price) : base(consumption, price)
		{

		}

	}

	public class Dissipator : Consumer
	{
		public Dissipator(int consumption, int price) : base(consumption, price)     // pas sûr de devoir le définir de la même manière.
		{

		}

	}


	public class Nuclear_plant : Producer
    {
		public Nuclear_plant(int production, int CO2, int cost) : base(production, CO2, cost)
        {

        }
    }
	public class Gas_plant : Producer
	{
		public Gas_plant(int production, int CO2, int cost) : base(production, CO2, cost)
		{

		}
	}
	public class Wind_farm : Producer
	{
		public Wind_farm(int production, int CO2, int cost) : base(production, CO2, cost)
		{

		}
	}
	public class Solar_plant : Producer
	{
		public Solar_plant(int production, int CO2, int cost) : base(production, CO2, cost)
		{

		}
	}

	public class Buy_foreign : Producer
	{
		public Buy_foreign(int production, int CO2, int cost) : base(production, CO2, cost)
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