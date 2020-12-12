using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_Réseau
{
	public class Line
	{
		public Node entrance;
		public Actor entrance; //peut etre ajouter noeud dans les acteur et rename la classe en lieu de deplacement elec.
		public Node exit;
		public Actor exit;
		public int powerMax;
		public int powerIn;
		public int powerNeeded;

		public Line(Actor incoming, )
		{
			this.powerMax = powerMax;
			this.entrance = //
			this.exit = //
		}

		public setPowerIn(int powerIn)
		{
			this.powerIn = powerIn;
		}

		public int getPowerIn()
		{
			return this.powerIn;
		}

		public setPowerNeeded(int powerNeeded)
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
		public int getPowerNeeded()
		{
			return this.powerNeeded;
		}
	}
}

