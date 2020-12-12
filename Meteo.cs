using System;

public class Meteo
{
	public float temperature;
	public float sunshine;
	public float windForce;
	
	
	public Meteo(float temperature, float sunshine, float windForce, float coeffAléatoire, int variation)
    {
		Random rnd = new Random();
		this.temperature = temperature + coeffAléatoire*rnd.Next(-variation , variation) ;
		this.sunshine = sunshine + coeffAléatoire*rnd.Next(-variation , variation);
		this.windForce = windForce + coeffAléatoire*rnd.Next(-variation , variation);
    }
	public string getMeteo()
    {
		return "Température:" + temperature.ToString() + "°C Ensoleillement :" + sunshine.ToString() + "Mj/m^2 Force du vent:" + windForce.ToString();
    }
	public float getTemperature()
    {
		return temperature;
    }
	public float getSunshine()
	{
		return sunshine;
	}
	public float getWindForce()
    {
		return windForce;
    }

}
