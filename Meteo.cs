using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_Réseau
{
	public class Meteo
	{
		public double temperature;
		public double sunshine;
		public double windForce;


		public Meteo(double temperature, double sunshine, double windForce, double coeffAléatoire, int variation)
		{
			Random rnd = new Random();
			this.temperature = temperature + coeffAléatoire * rnd.Next(-variation , variation) ;
			this.sunshine = sunshine + coeffAléatoire * rnd.Next(-variation , variation);
			this.windForce = windForce + coeffAléatoire * rnd.Next(-variation , variation);
		}
		public string getMeteo()
		{
			return "Température:" + temperature.ToString() + "°C Ensoleillement :" + sunshine.ToString() + "Mj/m^2 Force du vent:" + windForce.ToString();
	
	}
		public double getTemperature()
		{
			return temperature;
		}
		public double getSunshine()
		{
			return sunshine;
		}
		public double getWindForce()
		{
			return windForce;
		}
	}
}
