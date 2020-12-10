using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_Réseau
{
    class Grid
    {
        public List<Point> listOfLocations = new List<Point>();
        public List<Point> takenLocations = new List<Point>();
        public List<int> size = new List<int>();
        public Grid(int length, int width) //creation de la grille  // changé void Grid en Grid pour pouvoir appeler un constructeur 
        {
            this.size.Add(length);
            this.size.Add(width);
            setlistOfLocation(length, width);   //appelle de la fonction afin d'ajouter tous les points 
        }
        private void setlistOfLocation(int length, int width)
        {
            for (int column = 0; column <= length; column++)
            {
                for (int line = 0; line <= width; line++)    
                {
                    Point createdPoint = new Point(column, line);
                    this.listOfLocations.Add(createdPoint);
                }
            }
            this.availableLocations = this.listOfLocations; 
        }
        public void setTakenLocation(Point usedPoint)
        {
            this.takenLocations.Add(usedPoint);
        }
    }
    public class Point
    {
        public int xCoordinate;
        public int yCoordinate;
        public string name;
        public List<int> meteo = new List<int> { 1 , 2 , 3}; //pour l'exemple pour l'instant à modifier avec un objet météo;
        public string type; 

        public  Point(int Xcoord, int Ycoord)  //idem que pour grid, supprimé le void  //initialiser avec le type ? 
        {
            this.xCoordinate = Xcoord;
            this.yCoordinate = Ycoord;
            this.name = setName();
        }
        private string setName()
        {
            return xCoordinate.ToString() + "/" + yCoordinate.ToString(); // on mettra le type dedans aussi 
        }
        
    }
}
