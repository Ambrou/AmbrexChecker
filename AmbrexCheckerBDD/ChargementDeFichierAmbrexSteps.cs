using AmbrexChecker;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TechTalk.SpecFlow;

namespace AmbrexCheckerBDD
{
    [Binding]
    public class ChargementDeFichierAmbrexSteps
    {
        CheckerVisitor ambrexChecker = new CheckerVisitor();

        [Given(@"le fichier ESD\.agex bien formé, contenant les exigences avales")]
        public void SoitLeFichierESD_AgexBienFormeContenantLesExigencesAvales()
        {
            string pathFile = Directory.GetCurrentDirectory() + "\\..\\..\\Resources\\ESD.agex";
            ambrexChecker.setAvalFile(pathFile);
        }

        [Given(@"il contient les informations suivantes, chacune étant une ligne présente une fois seulement au sein d'un bloc ""(.*)"":")]
        public void SoitIlContientLesInformationsSuivantesChacuneEtantUneLignePresenteUneFoisSeulementAuSeinDUnBloc(string p0, Table table)
        {
            
        }

        [Given(@"il ne contient pas d'autre informations d'exigence")]
        public void SoitIlNeContientPasDExigence()
        {
            
        }  

        [Given(@"le fichier ESG\.agex bien formé, contenant les exigences amonts")]
        public void SoitLeFichierESG_AgexBienFormeContenantLesExigencesAmonts()
        {
            string pathFile = Directory.GetCurrentDirectory() + "\\..\\..\\Resources\\ESG.agex";
            ambrexChecker.setAmontFile(pathFile);
        }

        [Given(@"il contient les lignes suivantes, chacune une fois seulement")]
        public void SoitIlContientLesLignesSuivantesChacuneUneFoisSeulement(Table table)
        {
            
        }

        [Given(@"il ne contient pas d'autre ligne commençant par ""ReqID=""")]
        public void SoitIlNeContientPasDAutreLigneCommencantPar()
        {
        }

        [When(@"je charge le fichier d'exigence aval en mémoire")]
        public void QuandJeChargeLeFichierDExigenceAvalEnMemoire()
        {
            ambrexChecker.loadAvalRequirement();
        }

        [When(@"je charge le fichier d'exigence amont en mémoire")]
        public void QuandJeChargeLeFichierDExigenceAmontEnMemoire()
        {
            ambrexChecker.loadAmontRequirement();
        }

        [Then(@"la liste des exigences avales est:")]
        public void AlorsLaListeDesExigencesAvalesEst(Table table)
        {
            foreach (var requirement in table.Rows)
            {
                Assert.AreEqual(true, ambrexChecker.getAvalRequirement().ContainsKey(requirement["ReqID"]));
                List<string> listTemp = requirement["Parent"].Split(' ').ToList();
                foreach(var str in listTemp)
                {
                    Assert.AreEqual(true, ambrexChecker.getAvalRequirement()[requirement["ReqID"]].Contains(str));
                }
                
            }
        }

        [Then(@"la liste des exigences amonts est:")]
        public void AlorsLaListeDesExigencesAmontsEst(Table table)
        {
            foreach (var requirement in table.Rows)
            {
                Assert.AreEqual(true, ambrexChecker.getAmontRequirement().Contains(requirement["ReqID"]));
            }
        }
    }
}
