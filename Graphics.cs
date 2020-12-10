using System;
using System.Collections.Generic;
using System.Text;

namespace Simulateur_Réseau
{
    class Graphics
    {
        public string Draw(Grid network_grid)
        {
            string graphics;
            foreach(Point point in network_grid.listOfLocations){
                if (network_grid.lis.Contains(point)) {

                    //point.IsIn(network_grid.availableLocations
                }


            }
            
            
            
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
            return graphics; 
        }
    }
}
