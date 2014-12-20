using AmbrexChecker;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace AmbrexCheckerBDD
{
    [Binding]
    public class ConfigurationDeLApplicationSteps
    {
        CheckerVisitor ambrexChecker = new CheckerVisitor();
        string[] args;
        int iIndex = 0;
        AmbrexCheckerExceptionFileMissing ambrexCheckerExceptionFileMissing = null;
        

        [Given(@"une ligne de commande avec (.*) arguments")]
        public void SoitUneLigneDeCommandeAvecArguments(int p0)
        {
           args = new string[p0];
        }


        [Given(@"la ligne de commande contient '(.*)'")]
        public void SoitLaLigneDeCommandeContient(string p0)
        {
            args[iIndex++] = p0;
        }

        [Given(@"la ligne de commande ne contient pas de commutateur -amont")]
        public void SoitLaLigneDeCommandeNeContientPasDeCommutateur_Amont()
        {
            args[iIndex++] = "toto";
        }

        [Given(@"la ligne de commande ne contient pas de commutateur -aval")]
        public void SoitLaLigneDeCommandeNeContientPasDeCommutateur_Aval()
        {
            args[iIndex++] = "titi";
        }

        [When(@"j'analyse la ligne de commande")]
        public void QuandJAnalyseLaLigneDeCommande()
        {
            try
            {
                ambrexChecker.analyzeCommandLine(args);
            }
            catch (AmbrexCheckerExceptionFileMissing e)
            {
                ambrexCheckerExceptionFileMissing = e;
            }
            
        }

        [Then(@"le fichier contenant les exigences amonts est fichier '(.*)'")]
        public void AlorsLeFichierContenantLesExigencesAmontsEstFichier(string p0)
        {
            Assert.AreEqual(p0, ambrexChecker.getAmontFile());
        }

        [Then(@"le fichier contenant les exigences avals est fichier '(.*)'")]
        public void AlorsLeFichierContenantLesExigencesAvalsEstFichier(string p0)
        {
            Assert.AreEqual(p0, ambrexChecker.getAvalFile());
        }


        [Then(@"un message d erreur apparait ""(.*)""")]
        public void AlorsUnMessageDErreurApparait(string p0)
        {
            Assert.AreEqual(p0, ambrexCheckerExceptionFileMissing.Message);
        }

        [Then(@"l'application arrête son traitement")]
        public void AlorsLApplicationArreteSonTraitement()
        {
            Assert.AreNotEqual(null, ambrexCheckerExceptionFileMissing.Message);
        }
    }
}
