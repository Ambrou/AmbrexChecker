using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AmbrexChecker;
using System.Collections.Generic;

namespace AmbrexCheckerTest
{
    [TestClass]
    public class CheckerUnitTest
    {
        [TestMethod]
        public void checkCoverageDownToUpFailed()
        {
            // Arrange
            Tuple<string, string> requirement = new Tuple<string, string>("ESD01", "ESG03");
            Checker ambrexChecker = new Checker();
            List<string> amont = new List<string>();
            Dictionary<string, List<string>> aval = new Dictionary<string, List<string>>();
            amont.Add("ESG01");
            amont.Add("ESG02");
            ambrexChecker.setAmont(amont);
            amont = new List<string>();
            amont.Add("ESG03");
            aval.Add("ESD01", amont);

            ambrexChecker.setAval(aval);

            // Act
            ambrexChecker.checkCoverage();

            // Assert
            Assert.AreEqual(1, ambrexChecker.getRequirementCoveredButNotExist().Count);
            Assert.AreEqual(true, ambrexChecker.getRequirementCoveredButNotExist().Contains(requirement));
        }

        [TestMethod]
        public void checkCoverageUpToDownFailed()
        {
            // Arrange
            Checker ambrexChecker = new Checker();
            List<string> amont = new List<string>();
            Dictionary<string, List<string>> aval = new Dictionary<string, List<string>>();
            string strRequirement = "ESG01";
            amont.Add("ESG01");
            amont.Add("ESG02");
            ambrexChecker.setAmont(amont);
            amont = new List<string>();
            amont.Add("ESG02");
            aval.Add("ESD01", amont);

            ambrexChecker.setAval(aval);

            // Act
            ambrexChecker.checkCoverage();

            // Assert
            Assert.AreEqual(1, ambrexChecker.getRequirementNotCovered().Count);
            Assert.AreEqual(true, ambrexChecker.getRequirementNotCovered().Contains(strRequirement));
        }

        [TestMethod]
        public void checkCoverageSucessed()
        {
            // Arrange
            Checker ambrexChecker = new Checker();
            List<string> amont = new List<string>();
            Dictionary<string, List<string>> aval = new Dictionary<string, List<string>>();
            amont.Add("ESG01");
            amont.Add("ESG02");
            ambrexChecker.setAmont(amont);
            amont = new List<string>();
            amont.Add("ESG02");
            amont.Add("ESG01");
            aval.Add("ESD01", amont);
            aval.Add("ESD02", amont);
            ambrexChecker.setAval(aval);

            // Act
            ambrexChecker.checkCoverage();

            // Assert
            Assert.AreEqual(0, ambrexChecker.getRequirementCoveredButNotExist().Count + ambrexChecker.getRequirementNotCovered().Count);
        }
    }
}
