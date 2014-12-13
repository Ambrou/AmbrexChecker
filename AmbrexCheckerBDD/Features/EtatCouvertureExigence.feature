Fonctionnalité: Etat de la couverture d'exigences
	En tant qu’utilisateur d’AGEX
	Afin de vérifier la traçabilité entre mes exigences
	Je veux savoir si toutes les exigences Amonts sont couvertes par au moins une exigence Aval



  Scénario: Couverture des exigences Amont par Aval avec une exigence Amont non couverte
	Soit les exigences amonts:
		| ReqID |
		| ESG01 |
		| ESG02 |
		| ESG03 |
		| ESG04 |
		| ESG05 |
		| ESG06 |
	Et les exigences avals:
		| ReqID | ReqID-Amont |
		| ESD01 | ESG01 ESG04 |
		| ESD02 | ESG03 ESG02 |
		| ESD04 | ESG04       |
		| ESD05 | ESG03       |
	Quand je compare ces deux listes
	Alors les exigences amonts ne sont pas correctement couvertes
#	Alors l'exigence ESG05 n'est pas couverte
#	Et l'exigence ESG06 n'est pas couverte

  Scénario: Couverture des exigences Amont par Aval avec une exigence Amont oublié
	Soit les exigences amonts:
		| ReqID |
		| ESG01 |
		| ESG02 |
		| ESG03 |
		| ESG04 |
	Et les exigences avals:
		| ReqID | ReqID-Amont |
		| ESD01 | ESG01 ESG04 |
		| ESD02 | ESG03 ESG02 |
		| ESD04 | ESG04 ESG05 |
		| ESD05 | ESG03       |
	Quand je compare ces deux listes
	Alors les exigences amonts ne sont pas correctement couvertes
#	Alors l'exigence ESD04 couvre une exigence inconnu : ESG05

  Scénario: Traçabailité correct entre les exigences amonts et les exigences avales
	Etant donné les exigences amonts:
		| ReqID |
		| ESG01 |
		| ESG02 |
		| ESG03 |
		| ESG04 |
		| ESG05 |
	Et les exigences avals:
		| ReqID | ReqID-Amont |
		| ESD01 | ESG01 ESG04 |
		| ESD02 | ESG03 ESG02 |
		| ESD03 | ESG05       |
		| ESD04 | ESG04       |
		| ESD05 | ESG03       |
	Quand je compare ces deux listes
	Alors les exigences amont sont correctement couvertes