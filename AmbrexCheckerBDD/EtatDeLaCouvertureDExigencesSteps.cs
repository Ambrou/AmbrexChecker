using AmbrexChecker;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;


namespace AmbrexCheckerBDD
{
    [Binding]
    public class EtatDeLaCouvertureDExigencesSteps
    {
        Checker ambrexChecker = new Checker();

        [Given(@"les exigences amonts:")]
        public void SoitLesExigencesAmonts(Table table)
        {
            List<string> listExigenceAmont = new List<string>();
           
            foreach (var requirement in table.Rows)
            {
                listExigenceAmont.Add(requirement["ReqID"]);
            }
            ambrexChecker.setAmont(listExigenceAmont);
        }

        [Given(@"les exigences avals:")]
        public void SoitLesExigencesAvals(Table data)
        {
            Dictionary<string, List<string>> listExigenceAval = new Dictionary<string, List<string>>();
            foreach (var row in data.Rows)
            {
                var requirement = row["ReqID"];
                var listCovered = row["ReqID-Amont"].Split(' ').ToList();
                listExigenceAval.Add(requirement, listCovered);
            }
            ambrexChecker.setAval(listExigenceAval);
        }

        [When(@"je compare ces deux listes")]
        public void QuandJeCompareCesDeuxListes()
        {
            ambrexChecker.checkCoverage();
        }

        [Then(@"l'exigence (.*) n'est pas couverte")]
        public void AlorsLEstPasCouverte(string amont)
        {
            Assert.AreEqual(true, ambrexChecker.getRequirementNotCovered().Contains(amont));
        }

        [Then(@"l'exigence (.*) couvre une exigence inconnu : (.*)")]
        public void AlorsLExigenceESDCouvreUneExigenceInconnuESG(string aval, string amont)
        {
            Tuple<string, string> tuple = new Tuple<string, string>(aval, amont);
            Assert.AreEqual(true, ambrexChecker.getRequirementCoveredButNotExist().Contains(tuple));
        }

        [Then(@"les exigences amont sont correctement couvertes")]
        public void AlorsLesExigencesAmontSontCorrectementCouvertes()
        {
            Assert.AreEqual(0, ambrexChecker.getRequirementCoveredButNotExist().Count);
            Assert.AreEqual(0, ambrexChecker.getRequirementNotCovered().Count);
        }

        [Then(@"les exigences amonts ne sont pas correctement couvertes")]
        public void AlorsLesExigencesAmontsNeSontPasCorrectementCouvertes()
        {
            Assert.AreNotEqual(0, ambrexChecker.getRequirementCoveredButNotExist().Count + ambrexChecker.getRequirementNotCovered().Count);
        }

    }
}
