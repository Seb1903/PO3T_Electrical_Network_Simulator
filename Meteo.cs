using System;

public class Meteo
{
	int temperature;
	int sunshine;
	int windForce;
	
	public Meteo(int temperatureMax, int temperatureMin, int sunshineMax, int sunshineMin, int windForceMax, int windForceMin)
	{
		Random aleatoire = new Random();
		this.temperature = aleatoire.Next(temperatureMin, temperatureMax);
		this.sunshine = aleatoire.Next(sunshineMin, sunshineMin);
		this.windForce = aleatoire.Next(windForceMax, windForceMin);
	}
	public Meteo(int isNorth, int temperatureMax, int temperatureMin, int sunshineMax, int sunshineMin, int windForceMax, int windForceMin)
	{
		Random aleatoire = new Random();
		if (isNorth == 0)
		{
			this.temperature = aleatoire.Next(temperatureMin, temperatureMax); //ajouter la diff entre nord et sud
			this.sunshine = aleatoire.Next(sunshineMin, sunshineMin);
			this.windForce = aleatoire.Next(windForceMax, windForceMin);
		}
        else 
		{
			this.temperature = aleatoire.Next(temperatureMin, temperatureMax); //ajouter la diff entre nord et sud
			this.sunshine = aleatoire.Next(sunshineMin, sunshineMin);
			this.windForce = aleatoire.Next(windForceMax, windForceMin);
		}
	}
	public Meteo(int temperature, int sunshine, int windForce)
    {
		this.temperature = temperature;
		this.sunshine = sunshine;
		this.windForce = windForce;
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
