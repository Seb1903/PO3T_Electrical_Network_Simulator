using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_Réseau
{
	public class Actor
	{
		public List<Point> placement;
		int area;  //un point est une aire, servira pour faire des moyennes pour la météo 

		public void setPlacement(List<Point> new_placement)       //mettre une limitation sur les points ? -> ceux-ci doivent être proches l'un de l'autre 
		{
			this.placement = new_placement;
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
