Fonctionnalité: Configuration de l'application
  En tant qu' utilisateur d'Agex
  Je veux configurer mon système
  Afin de définir les fichiers à analyser

Scénario: Configuration réussi du plugin
  Soit l'application lancé avec une ligne de commande
    Et la ligne de commande contient '-amont="fichier amont.txt"
    Et la ligne de commande contient '-aval="fichier aval.doc"
  Quand j'analyse la ligne de commande
  Alors le fichier contenant les exigences amonts est fichier amont.txt
    Et le fichier contenant les exigences avals est fichier aval.doc

Scénario: Configuration du plugin sans fichier amont
  Soit l'application lancé avec une ligne de commande
    Et la ligne de commande contient '-aval="fichier aval.doc"
    Et la ligne de commande ne contient pas de commutateur -amont
  Quand j'analyse la ligne de commande
  Alors un message d'erreur apparait "le fichier amont n'est pas renseigné"
    Et l'application arrête son traitement

Scénario: Configuration du plugin sans fichier aval
  Soit l'application lancé avec une ligne de commande
    Et la ligne de commande contient '-amont="fichier amont.doc"
    Et la ligne de commande ne contient pas de commutateur -aval
  Quand j'analyse la ligne de commande
  Alors un message d'erreur apparait "le fichier aval n'est pas renseigné"
    Et l'application arrête son traitement