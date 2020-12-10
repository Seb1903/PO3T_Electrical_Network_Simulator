using System;

public class Market
{
	int electricityPurchasePrice;
	int electricitySalePrice;
	int nuclearPurchasePrice;
	int gasPurchasePrice;
	public Market()
    {
		Random random = new Random();
		this.electricityPurchasePrice = random.Next(,); //ajouter les valeurs limite 
		this.electricitySalePrice = random.Next(,);
		this.nuclearPurchasePrice = random.Next(,);
		this.gasPurchasePrice = random.Next(,);
	}
	public Market(int electricityPurchasePrice, int electricitySalePrice, int nuclearPurchasePrice, int gasPurchasePrice)
    {
		this.electricityPurchasePrice = electricityPurchasePrice; 
		this.electricitySalePrice = electricitySalePrice;
		this.nuclearPurchasePrice = nuclearPurchasePrice;
		this.gasPurchasePrice = gasPurchasePrice;
	}
	public string getMarket()
    {
		return electricityPurchasePrice.ToString() + " " + electricitySalePrice.ToString() + " " + nuclearPurchasePrice.ToString() + " " + gasPurchasePrice.ToString();
	}
	public int getElectricityPurchasePrice()
    {
		return electricityPurchasePrice;
	}
	public int getElectricitySalePrice()
	{
		return electricitySalePrice;
	}
	public int getNuclearPurchasePrice()
	{
		return nuclearPurchasePrice;
	}
	public int getGasPurchasePrice()
	{
		return gasPurchasePrice;
	}
}