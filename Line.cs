using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_Réseau
{
	public class Line
	{
		public double powerMax;
		public double powerIn;
		public double powerNeeded;

		public Line(double powerMax)
		{
			this.powerMax = powerMax;
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
				return; //message d'erreur cette ligne ne peut pas fournir cette énergie.
			}
		}
		public double getPowerNeeded()
		{
			return this.powerNeeded;
		}
	}
}

