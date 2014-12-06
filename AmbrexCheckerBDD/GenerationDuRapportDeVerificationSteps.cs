using AmbrexChecker;
using System;
using TechTalk.SpecFlow;

namespace AmbrexCheckerBDD
{
    [Binding]
    public class GenerationDuRapportDeVerificationSteps
    {
        CheckerVisitor ambrexChecker = new CheckerVisitor();
        //IRapport rapport = new MockRapport();

        [Given(@"les exigences couvrant une exigence inconnue:")]
        public void SoitLesExigencesCouvrantUneExigenceInconnue(Table table)
        {
            foreach (var row in table.Rows)
            {
                ambrexChecker.getAvalRequirementsCovevedRequirementNotExist().Add(new Tuple<string, string>(row["exigence"],row["exigence_inconnu"]));
            }
        }

        [Given(@"les exigences non couvertes")]
        public void SoitLesExigencesNonCouvertes(Table table)
        {
            foreach (var row in table.Rows)
            {
                ambrexChecker.getAmontRequirementsNotCovered().Add(row["exigence"]);
            }
        }

        [When(@"je génére le rapport")]
        public void QuandJeGenereLeRapport()
        {
            ambrexChecker.generateRapport();
        }

        [Then(@"le rapport indique que la couverture des exigences est mauvaise")]
        public void AlorsLeRapportIndiqueQueLaCouvertureDesExigencesEstMauvaise()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"le rapport indique les erreurs:")]
        public void AlorsLeRapportIndiqueLesErreurs(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
