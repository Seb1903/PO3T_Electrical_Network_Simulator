using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_Réseau
{
    class Grid
    {
        public List<Point> listOfLocation = new List<Point>();
        public List<Point> avaibleLocation = new List<Point>();
        public List<int> size = new List<int>();
        public void Grid(int length, int width) //creation de la grille 
        {
            this.size.Add(length);
            this.size.Add(width);
            setlistOfLocation(length, width);   //appelle de la fonction afin d'ajouter tous les points 
        }
        private void setlistOfLocation(int length, int width)
        {
            for (int column = 0; column =< length; column++)
            {
                for (int line = 0; line =<width; line++)
                {
                    Point createdPoint = new Point(column, line);
                    this.listOfLocation.Add(createdPoint);
                }
            }
            this.avaibleLocation = this.listOfLocation; 
        }
        public void removeUnavaiblepoint(Point usedPoint)
        {
            this.avaibleLocation.Remove(Point usedPoint);
        }
    }
    class Point
    {
        public int xCoordinate;
        public int yCoordinate;
        public string name;
        public List<int> meteo = new List<int> { 1 , 2 , 3}; //pour l'exemple pour l'instant à modifier avec un objet météo;

        public void Point(int Xcoord, int Ycoord)
        {
            this.xCoordinate = Xcoord;
            this.yCoordinate = Ycoord;
            this.name = setName();
        }
        private string setName()
        {
            return xCoordinate.ToString() + "/" + yCoordinate.ToString();
        }
        
    }
}
