Fonctionnalité: Génération du rapport de vérification
	En tant qu’utilisateur d’AGEX
	Afin de vérifier la traçabilité entre mes exigences
	Je veux un rapport donnat l'état de la vérification




#  Scénario: Génération du rapport
#	Soit le nom du fichier de rapport "rapport"
#	Quand je génére le rapport de couverture
#	Alors le fichier rapport.html est créé
#		Et le rapport à pour titre "Rapport de vérification"
#		Et le premier titre de paragraphe est "résumé"
#		Et le deuxième titre de paragraphe est "liste des erreurs"

#  Scénario: Génération du rapport sans erreur
#	Soit les exigences sont correctement couvertes
#	Quand je génére le rapport
#	Alors le rapport indique que la couverture des exigences est bonne

  Scénario: Génération du rapport avec erreur
	Soit les exigences couvrant une exigence inconnue:
			| exigence | exigence_inconnu   |
			| ESD04    | ESG05              |
			| ESD03    | ESG09              |
		Et les exigences non couvertes
			| exigence |
			| ESG07    |
			| ESG08    |
	Quand je génére le rapport
	Alors le rapport indique que la couverture des exigences est mauvaise
		Et le rapport indique les erreurs:
			| erreur                                    |
			| l'exigence ESG07 n'est pas couverte       |
			| l'exigence ESG08 n'est pas couverte       |
			| ESD04 couvre une exigence inconnu : ESG05 |
			| ESD03 couvre une exigence inconnu : ESG09 |