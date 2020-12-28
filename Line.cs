using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_Réseau
{
	public class Line
	{
		//public entrance; //peut etre ajoutée au noeud dans les acteur et rename la classe en lieu de deplacement elec.
		//public exit;
		public string name;
		public double powerMax;
		public double powerIn;
		public double powerNeeded;

		public Line(double powerMax, string name)
		{
			this.powerMax = powerMax;
			this.name = name;
			//this.entrance = //  // pas nécessaire puisque déré par les noeuds, on pourra chercher l'info direct dans les noeuds. Géré par utilisateur
			//this.exit = //
		}
		public void setPowerIn(double powerIn)
		{
			this.powerIn = powerIn;
		}

		public double getPowerIn()
		{
			return this.powerIn;
		}

		public void setPowerNeeded(double powerNeeded)
		{
			if (powerNeeded < powerMax)
			{
				this.powerNeeded = powerNeeded;
			}
			else
			{
				this.powerNeeded = powerNeeded;
				Console.WriteLine("Surcharge de la ligne {0}", this.name);
			}
		}
		public double getPowerNeeded()
		{
			return this.powerNeeded;
		}
	}
}

