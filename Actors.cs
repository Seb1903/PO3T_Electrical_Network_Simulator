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

	interface IConsumer
	{
		// peut-être créer un int consommation ? 
		public void Consume(int)
		{
			//ajoutera le int à une variable consommation sûrement 
		}

		public void getPrice()
		{
			// retourne le prix de l'électricité utilisée
		}

		public void getConsumption() {
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

	public class City : Actor, IConsumer    //https://stackoverflow.com/questions/56867/interface-vs-base-class
	{


	}

	public class Business : Actor, IConsumer
	{

	}

	public class Foreign : Actor, IConsumer
	{

	}


	public class Dissipator : Actor, IConsumer
	{

	}
}
