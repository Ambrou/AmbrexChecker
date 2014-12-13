using System;
using TechTalk.SpecFlow;

namespace AmbrexCheckerBDD
{
    [Binding]
    public class ConfigurationDeLApplicationSteps
    {
        [Given(@"l'application lancé avec une ligne de commande")]
        public void SoitLApplicationLanceAvecUneLigneDeCommande()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"la ligne de commande contient '-amont=""(.*)""")]
        public void SoitLaLigneDeCommandeContient_Amont(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"la ligne de commande contient '-aval=""(.*)""")]
        public void SoitLaLigneDeCommandeContient_Aval(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"la ligne de commande ne contient pas de commutateur -amont")]
        public void SoitLaLigneDeCommandeNeContientPasDeCommutateur_Amont()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"la ligne de commande ne contient pas de commutateur -aval")]
        public void SoitLaLigneDeCommandeNeContientPasDeCommutateur_Aval()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"j'analyse la ligne de commande")]
        public void QuandJAnalyseLaLigneDeCommande()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"le fichier contenant les exigences amonts est fichier amont\.txt")]
        public void AlorsLeFichierContenantLesExigencesAmontsEstFichierAmont_Txt()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"le fichier contenant les exigences avals est fichier aval\.doc")]
        public void AlorsLeFichierContenantLesExigencesAvalsEstFichierAval_Doc()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"un message d'(.*)'est pas renseigné""")]
        public void AlorsUnMessageDEstPasRenseigne(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"l'application arrête son traitement")]
        public void AlorsLApplicationArreteSonTraitement()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
