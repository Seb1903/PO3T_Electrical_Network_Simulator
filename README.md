# PO3T_Electrical_Network_Simulator
par Sébastien Martinez Balbuena 18360  
  et   Logan Noël 18003 

## Introduction 
Pour pouvoir effectuer des recherches, on souhaite disposer d'une plateforme de simulation de réseau électrique à l'échelle d'un pays. Le but est de pouvoir simuler le comportement dynamique d'un ensemble de centre de production d'électricité et d'un ensemble de consommateurs d'énergie électrique. Grâce à cette plateforme les chercheurs pourront développer des systèmes de régulation automatique du réseau, faire des simulations de catastrophe, optimiser les achats et reventes d'énergie électrique à l'étranger, étudier les possibilités d'investissements et optimiser l'impact environnemental.

## Prise en main 

Le repository contient tous les fichiers nécessaires à la compilation, y compris un .csproj puisque ceci a été développé sur Visual Studio (nous conseillons de compiler le programme sur ce dernier). 

### Création des éléments du réseau 
#### Producteurs

Les différents producteurs d'énergie se trouvent dans le fichier Actors.cs  

Afin de créer ceux-ci, il faut appeler le constructeur correspondant en y précisant la puissance, la quantité de CO2 produite et le coût. Dans le cas d'une centrale au gaz ou d'une centrale nucléaire, il faut remplacer le coût par le marché d'où on achète les combustible (comme cela est fait dans notre implémentation d'une simulation). 

Exemple :
Wind_farm éoliennes = new Wind_farm(100,20,200);

Il est aisé de créer un nouveau producteur en le faisant hériter de la classe Producer.

#### Consommateurs 

Les différents consommateurs d'énergie se trouvent dans le fichier Actors.cs 

Afin de créer un consommateur, il faut appeler le constructeur correspondant en y passant la puissance consommée et le prix de l'électricité consommée.
Exemple : 
City Bruxelles = new City(15, 5);

Il est aisé de créer un nouveau producteur en le faisant hériter de la classe Consumer.

#### Météo 
Un objet Météo est défini par une température, un taux d'ensoleillement et la force du vent. Lors de la création de la zone du réseau (Grid) chaque point est créé avec une Météo qui lui est propre. De base chque point à une météo variant aux alentours de 25 C, 50% d'ensoleillement et une force du vent de 30km/h. Il est néanmoins possible de choisir une météo présice pour chaque point en accédant au point voulu dans le grid puis en accédant à son attribut météo. 

#### Marché 
Un marché est créable grâce à Market(). Il faut préciser : le prix d'achat de l'électricité, le prix de revente de l'électricité, le prix du combustible nucléaire et le prix du gaz combustible. 
Exemple : Market market = new Market(5, 5, 6000, 60);

#### Grid
Le grid désigne la zone sur laquelle on va placer nos différents acteurs. On crée le grid ainsi : Grid (longueur, largeur). Le grid crée par lui même les différents points. Le grid sera agrégé au gestionnaire de réseau qui lui pourra notamment ajouter des acteurs sur les différents points.

#### Réseau
Notre classe Network jouera le rôle de gestionnaire/contrôleur de réseau. Lors de sa création, on y précise quel grid on va utiliser. Cela permet d'avoir plusierus réseaux qui utilisent une même "zone". Il faudra ajouter les noeuds et les acteurs au réseau grâce aux méthodes addActor() et add_Node() avec en paramètre l'élément que l'on veut ajouter, le nom de l'acteur/noeud ainsi que le lieu.
La méthode Update() permet d'actualiser tout le réseau (production et consommation). Le controleur essayera toujours de fournir la production nécessaire à la consommation voulue. Les producteurs produiront alors plus mais s'ils s'adaptent trop lentement (comme la centrale nucléaire), la consommation peut alors dépasser momentanément la production mais cela est corrigé lors de l'itération d'après. 

Exemple : 
network.addActor(ma_centrale,"Thiange 1", grid.listOfLocations[0][2]);

#### Noeuds et lignes 
Une ligne est créée avec une puissance maximale et un nom :  Line line1 = new Line(15, "L1");
Un noeud ne prend pas de parmètres lors de sa création :  
concentrationNode nodec = new concentrationNode();
distributionNode node = new distributionNode();

On peut ensuite ajouter des lignes aux noeuds grâce aux méthodes : 
addIncomingLine(ligne, origine)
addOutgoingLine(ligne, destinataire)

Une ligne dépassant la puissance maximale autorisée ne sera pas coupée mais affichera un message d'alerte. 

#### Graphiques 
La classe graphiques permet de définir des méthodes afin d'afficher des éléments dans le console. La méthode qui sera la plus utilisée sera la méthode show_network_interface() en présisant le réseau en paramètre. Cette méthode permettra d'afficher les éléments de base (consommation, production, acteurs) de la simulation. 
### Mise en place 
Il faut définir la simulation dans la classe Program du fichier Program.cs
Il faut donc créer un grid pour définir le lieu sur lequel on va travailler puis créer le réseau (avec le grid en paramètre). Il faut créer les différents acteurs (consommateurs/producteurs) voulus ainsi que les noeuds nécessaires puis les ajouter au réseau grâce aux méthodes ad hoc. Il faut ensuite relier les acteurs, consommateurs et noeuds entre eux grâce aux lignes. Des noeuds peuvent être reliés entre eux. 
Il faut également créer l'objet Graphics afin de pouvoir afficher les informations dans la console. Puis dans la boucle while qui a été définie dans l'implémentation, il faut appeler la mise à jour du réseau (réseau.Update()) et l'affichage d'informations sur la console (           graphiques.show_network_interface(network);).

En changeant la valeur dans le Thread.Sleep() on modifie le nombre de millisecondes avant la nouvelle mise à jour du réseau. 

Il suffit alors de compiler. 

Il est possible aussi, si vous souhaitez pouvoir modifier manuellement la simulation, de lancer C# en mode interactif. Cela peut-être nécessaire par exemple pour arrêter une centrale (suffit de placer sa production à 0), puisque cela ne se ferait pas dans la simulation telle quelle est définie "automatiquement" (à moins de placer des consommations voulues très basses et que l'aléatoire fasse en sorte d'avoir une consommation voulue nulle). 

## Diagrammes 

Diagramme de classes https://github.com/Seb1903/PO3T_Electrical_Network_Simulator/blob/main/Diagramme_de_classes.png
Diagramme de séquence https://github.com/Seb1903/PO3T_Electrical_Network_Simulator/blob/main/Diagramme_de%20_s%C3%A9quence.png
