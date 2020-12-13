using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_Réseau
{
	public class Node
	{
		public Point placement; //ne reconnait pas encore la classe podouble !!
		public List<Line> incomingLine = new List<Line>();
		public List<Line> outgoingLine = new List<Line>();
		public double power = 0;
		public double powerNeeded = 0;

		public void delOutgoingLine(Line line)
		{
			outgoingLine.Remove(line);
		}
		public void delIncomingLine(Line line)
		{
			incomingLine.Remove(line);
		}
		public void UpdatePower()
		{
			foreach (Line line in incomingLine)
			{
				this.power += line.getPowerIn();
			}
			foreach (Line line in outgoingLine)
			{
				this.powerNeeded += line.getPowerNeeded();
			}
			if (this.powerNeeded <= this.power)
			{
				foreach (Line line in outgoingLine)
				{
					line.setPowerIn(line.getPowerNeeded());
				}
				if (this.powerNeeded < this.power)
                {
					double surplus = this.power - this.powerNeeded;
					//soit retourner un message soit envoyer vers un centre de stockage
                }
			}
            else
            {
				double coefficient = 1;
				while (coefficient > 0)
				{
					if (coefficient* this.powerNeeded < this.power)
                    {
						foreach (Line line in outgoingLine)
						{
							line.setPowerIn(coefficient*line.getPowerNeeded());
						}
						//ajouter un message d'erreur pour dire que seulement coefficient*100 % d'énergie a pu etre envoyer.  
						coefficient = 0; 
					}
					else
                    {
						coefficient -= 0.01; //peut etre à modifier après. 
                    }
                }
            }
		}
	}
	public class distributionNode : Node
	{
		public distributionNode(Point placement)
		{
			this.placement = placement;
		}
		public void addIncomingLine(Line line)
		{
			if (this.incomingLine.Count == 0)
			{
				this.incomingLine.Add(line);
			}
			else
				throw new ArgumentException("Parameter cannot be null");
		}
		public void addOutgoingLine(Line line)
		{
			this.outgoingLine.Add(line);
		}
	}
	public class concentrationNode : Node
	{
		public concentrationNode(Point placement)
		{
			this.placement = placement;
		}
		public void addIncomingLine(Line line)
		{
			this.incomingLine.Add(line);
		}
		public void addOutgoingLine(Line line)
		{
			if (this.outgoingLine.Count == 0)
			{
				this.outgoingLine.Add(line);
			}
			else
				throw new ArgumentException("Parameter cannot be null");
		}
	}
}
