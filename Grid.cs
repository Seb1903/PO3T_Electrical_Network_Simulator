using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_Réseau
{
    public class Grid
    {
        // creer generateur aleatoire de meteo pour chaque point

        public List<List<Point>> listOfLocations = new List<List<Point>>();
        public List<Point> takenLocations = new List<Point>();
        //public List<int> size = new List<int>();
        public int length;
        public int width;
        public Grid(int length, int width) //creation de la grille  // changé void Grid en Grid pour pouvoir appeler un constructeur 
        {
            this.length = length; //nécessaire?
            this.width = width;
            setlistOfLocations(length, width);   //appelle de la fonction afin d'ajouter tous les points 
        }
        private void setlistOfLocations(int length, int width)
        {
            for (int line = 0; line < width; line++)  
            {
                List<Point> temp_sublist = new List<Point>();   //on crée une liste pour chaque 

                for (int column = 0; column < length; column++)    
                {
                    Point createdPoint = new Point(column, line);     // adapter le nom avec une variable dynamique // ou alors utiliser des listes imbriquées dans listOfLocations pour faire une matrice puis appeler un objet point (pour le set dans Acteur grâce à la grille).
                    temp_sublist.Add(createdPoint);
                }
                this.listOfLocations.Add(temp_sublist);   //on ajoute à la liste initiale la ligne créée puis on passe à la ligne suivante 
            }
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
        public string type = "";
        public Meteo meteo;

        public  Point(int Xcoord, int Ycoord)  //idem que pour grid, supprimé le void  //initialiser avec le type ? 
        {
            this.xCoordinate = Xcoord;
            this.yCoordinate = Ycoord;
            this.name = setName();

        }
        private string setName()
        {
            return  type + xCoordinate.ToString() + "/" + yCoordinate.ToString(); // on mettra le type dedans aussi 
        }
        
        public void setType(string type_string)
        {
            this.type = type_string;
        }
        public void setMeteo(float temperature, float sunshine, float windforce)
        {
            this.meteo.temperature = temperature;
            this.meteo.sunshine = sunshine;
            this.meteo.windForce = windforce;
        }
    }
}
