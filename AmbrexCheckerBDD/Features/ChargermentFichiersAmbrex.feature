Fonctionnalité: Chargement de fichier ambrex
	En tant qu’utilisateur d’AGEX
	Afin de comparer deux niveaux d'exigence
	Je veux charger les exigences venant d'un fichier


	
Scénario: Chargement d'exigence amont
	Soit le fichier ESG.agex bien formé, contenant les exigences amonts
	Et il contient les lignes suivantes, chacune une fois seulement
		| ligne exigence |
		| ReqID=ESG-001  |
		| ReqID=ESG-002  |
	Et il ne contient pas d'autre ligne commençant par "ReqID="
	Quand je charge le fichier d'exigence amont en mémoire
	Alors la liste des exigences amonts est:
		| ReqID   |
		| ESG-001 |
		| ESG-002 |

Scénario: Chargement d'exigence aval
	Soit le fichier ESD.agex bien formé, contenant les exigences avales
	Et il contient les informations suivantes, chacune étant une ligne présente une fois seulement au sein d'un bloc "REQUIREMENT":
		| ReqID         | Amont                                       |
		| ReqID=ESD-001 | Exigence(s)-Amont= ESG-001 (P)              |
		| ReqID=ESD-002 | Exigence(s)-Amont= ESG-001 (P)              |
		| ReqID=ESD-003 | Exigence(s)-Amont= ESG-001 (P)              |
		| ReqID=ESD-004 | Exigence(s)-Amont= ESG-001 (P)  ESG-002 (T) |
	Et il ne contient pas d'autre informations d'exigence
	Quand je charge le fichier d'exigence aval en mémoire
	Alors la liste des exigences avales est:
		| ReqID   | Parent          |
		| ESD-001 | ESG-001         |
		| ESD-002 | ESG-001         |
		| ESD-003 | ESG-001         |
		| ESD-004 | ESG-001 ESG-002 |

