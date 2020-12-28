using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_Réseau
{
	public class Node : Actor
	{
		public new Point placement; 

		public List<Line> incomingLine = new List<Line>();
		public List<Line> outgoingLine = new List<Line>();
		public Dictionary<Line, Actor> Links= new Dictionary<Line, Actor>();

		public double powerNeeded = 0;
		public double stockage = 0; 

		public void delOutgoingLine(Line line)
		{
			outgoingLine.Remove(line);
		}
		public void delIncomingLine(Line line)
		{
			incomingLine.Remove(line);
		}
		public void UpdateIncomingLines()
        {
			foreach (Line line in incomingLine)
            {
				if (this.Links[line] is concentrationNode)
				{
					((concentrationNode)this.Links[line]).setPower();
				}
				line.setPowerIn(this.Links[line].power);
			}
		}
		public void UpdateOutgoingLines()
		{
			foreach (Line line in outgoingLine)
			{
				if (this.Links[line] is distributionNode)
				{
					((distributionNode)this.Links[line]).setPower();
				}
				line.setPowerNeeded(this.Links[line].power);
			}
		}

		public void setPower()
        {
			this.power = 0;
			foreach (Line line in incomingLine)
			{
				this.power += line.getPowerIn();
			}
		}
		public void setPowerNeeded()
        {
			this.powerNeeded = 0; 
			foreach (Line line in outgoingLine)
			{
				this.powerNeeded += line.getPowerNeeded();
			}
		}

		public void UpdatePower()
		{
			
			UpdateIncomingLines();
			UpdateOutgoingLines();
			setPowerNeeded();
			setPower();

			if (this.powerNeeded <= this.power)
			{
				foreach (Line line in outgoingLine)
				{
					line.setPowerIn(line.getPowerNeeded());
					this.Links[line].real_power = line.getPowerNeeded();
				}
				if (this.powerNeeded < this.power)
                {
					double surplus = this.power - this.powerNeeded;
					this.stockage = surplus;
					this.power -= this.powerNeeded;
                }
			}
            else
            {
				//double coefficient = 1;
				//while (coefficient > 0)
				//{
					//if (coefficient* this.powerNeeded < this.power)
                   // {
						foreach (Line line in outgoingLine)
						{
							line.setPowerIn(this.power * (1.0/(outgoingLine.Count))); //toutes les lignes reçoivent la même part de l'énergie
							this.Links[line].real_power = line.getPowerIn();

						}
						//ajouter un message d'erreur pour dire que seulement coefficient*100 % d'énergie a pu etre envoyer.  
						//coefficient = 0; 
					//}
					//else
                   // {
						//coefficient -= 0.01; //peut etre à modifier après. 
                   // }
               // }
            }
		}
	}
	public class distributionNode : Node
	{
		public Actor origin;
		public List<Actor> targets = new List<Actor>();

		public distributionNode()
		{

		}
		public void addIncomingLine(Line line, Actor origin)
		{
			if (this.incomingLine.Count == 0)
			{
				line.setPowerIn(origin.power);
				this.incomingLine.Add(line);
				this.origin = origin;
				this.Links.Add(line, origin);
				UpdatePower();
			}
			else
				throw new ArgumentException("Parameter cannot be null");
		}
		
		public void addOutgoingLine(Line line, Actor target)
		{
			this.outgoingLine.Add(line);
			this.targets.Add(target);
			line.setPowerNeeded(target.power);
			this.Links.Add(line, target);

			UpdatePower();
		}
	}
	public class concentrationNode : Node
	{
		public List<Actor> origins = new List<Actor>();
		public  Actor target;

		public concentrationNode()
		{

		}
		public void addIncomingLine(Line line, Actor origin)
		{
			this.incomingLine.Add(line);
			this.origins.Add(origin);
			line.setPowerIn(origin.power);
			this.Links.Add(line, origin);

			UpdatePower();

		}
		public void addOutgoingLine(Line line, Actor target)
		{
			if (this.outgoingLine.Count == 0)
			{
				this.outgoingLine.Add(line);
				this.target = target;
				this.Links.Add(line, target);

				UpdatePower();
			}
			else
				throw new ArgumentException("Parameter cannot be null");
		}
	}
}
