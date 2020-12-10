using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_Réseau
{
    class Graphics
    {
        public string Draw(Grid network_grid)
        {
            string graphics = "";     // utiliser char[] ?? 
            int i = 0;
            foreach(Point point in network_grid.listOfLocations){
                if (network_grid.takenLocations.Contains(point)) {
                                                                                 //graphicsAschar = graphics.ToCharArray()  ?? 
                    graphics += point.name.Substring(0, 1);                     //pour prendre le prmier caractère 
                                                                               //point.IsIn(network_grid.availableLocations    // faudra penser à rajouter les nodes dans takenLocations
                }
                else {
                    graphics += " ";
                }

                i += 1;

                if (i == network_grid.size[0])
                {
                    graphics += "\n";     //pour passer à la ligne si on est arrivé à la largeur maximale
                    i = 0;
                }
            }
            return graphics;
            
            }


        public string DrawLines(Grid network_grid, string graphics)
        {
            char[] graphicsAschar = graphics.ToCharArray(); 
            // faut voir si les lignes seront créées par l'utilisateur. 
            
        }
            
            // parcourir les éléments du grid et par position on écrit dans le string ce que c'est (style ASCII) et on relie par des traits pour faire les lignes électriques 
            // ex de ce que ça donnerait au final : 
            /*
             *   graphics = "    C -------------------V
             *                   |
             *                   |
             *                   P--------V----D-------"
             *                      
             *                      on voit que C (une centrale est reliée à une ville (V))
             *                      on peut utiliser des / et \ pour des diagonales 
             *                      faut juste paramétrer en fonction de ce qui se trouve dans le grid et sa taille 
             *                      P = panneaux solaires, D = Dissipateur, etc. 
             * 
             * 
             * 
             * 
             * 
             * */
        }
    }
}
