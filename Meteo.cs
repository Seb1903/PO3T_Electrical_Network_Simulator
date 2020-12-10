using System;

public class Meteo
{
	int temperature;
	int sunshine;
	int windForce;
	
	
	public Meteo(int temperature, int sunshine, int windForce, float coeffAléatoire, int variation)
    {
		
		this.temperature = temperature + coeffAléatoire*aleatoire.Next(-variation ; variation) ;
		this.sunshine = sunshine + coeffAléatoire*aleatoire.Next(-variation ; variation);
		this.windForce = windForce + coeffAléatoire*aleatoire.Next(-variation ; variation);
    }
	public string getMeteo()
    {
		return "Température:"+temperature.ToString()+"°C Ensoleillement :"+sunshine.ToString()+"Mj/m^2 Force du vent:"+windForce.ToString()
    }
	public int getTemperature()
    {
		return temperature;
    }
	public int getSunshine()
	{
		return sunshine;
	}
	public int getWindForce()
    {
		return windForce;
    }
}
