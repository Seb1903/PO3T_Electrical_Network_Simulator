using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_Réseau
{
	public class Node
	{
		public List<Point> placement; //ne reconnait pas encore la classe podouble !!
		public List<Line> incomingLine = new List<Line>();
		public List<Line> outgoingLine = new List<Line>();
		public double power = 0;
		public double powerNeeded = 0;

		public delOutgoingLine(Line line)
		{
			outgoingLine.remove(line);
		}
		public delIncomingLine(Line line)
		{
			incomingLine.Remove(line);
		}
		public UppdatePower()
		{
			foreach (line in incomingLine)
			{
				power += line.getPowerIn();
			}
			foreach (line in outgoingLine)
			{
				powerNeeded += line.getPowerNeeded();
			}
			if (powerNeeded <= powerIn)
			{
				foreach (line in outgoingLine)
				{
					line.setPowerIn(line.getPowerNeeded())
				}
				if (powerNeeded < power)
                {
					double surplus = power - powerNeeded;
					//soit retourné un message soit envoyé vers un centre de stockage
                }
			}
            else
            {
				double coefficient = 1;
				while (coefficient > 0)
				{
					if (coefficient*powerNeeded < power)
                    {
						line.setPowerIn(coefficient*line.getPowerNeeded())
						coefficient = 0; 
					}
					else
                    {
						coefficient -= 0.1; //peut etre à modifier après. 
                    }
                }
            }
		}
	}
	public class distributionNode : Node
	{
		public distributionNode(Podouble placement)
		{
			this.placement = placement;
		}
		public addIncomingLine(Line line)
		{
			if (this.incomingLine.Count == 0)
			{
				this.incomingLine.Add(line);
			}
			else
				return; //envoie qu'il y a une erreur
		}
		public addOutgoingLine(Line line)
		{
			this.outgoingLine.Add(line)
		}
	}
	public class concentrationNode : Node
	{
		public concentrationNode(Point placement)
		{
			this.placement = placement;
		}
		public addIncomingLine(Line line)
		{
			this.incomingLine.Add(line);
		}
		public addOutgoingLine(Line line)
		{
			if (this.outgoingLine.Count == 0)
			{
				this.outgoingLine.Add(line);
			}
			else
				return; //envoie qu'il y a une erreur
		}
	}
}
