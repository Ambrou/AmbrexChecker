using AmbrexChecker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbrexCheckerBDD
{
    class CheckerVisitor : Checker
    {
        public List<string> getAmontRequirement()
        {
            return amontRequirements;
        }

        public Dictionary<string, List<string>> getAvalRequirement()
        {
            return avalRequirements;
        }

        public List<Tuple<string, string>> getAvalRequirementsCovevedRequirementNotExist()
        {
            return avalRequirementsCovevedRequirementNotExist;
        }

        public List<string> getAmontRequirementsNotCovered()
        {
            return amontRequirementsNotCovered;
        }

        public string getAmontFile()
        {
            return amontFile;
        }

        public string getAvalFile()
        {
            return avalFile;
        }

        public void setAmontFile(string s)
        {
            amontFile = s;
        }

    }
}
