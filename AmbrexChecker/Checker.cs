using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbrexChecker
{
    public class Checker
    {
        public void setAmont(List<string> listAmont)
        {
            amontRequirements = listAmont;
        }

        public void setAval(Dictionary<string, List<string>> listAval)
        {
            avalRequirements = listAval;
        }

        public void checkCoverage()
        {
            checkCoverageDownToUp();
            checkCoverageUpToDown();
        }

        public List<string> getRequirementNotCovered()
        {
            return amontRequirementsNotCovered;
        }

        public List<Tuple<string, string>> getRequirementCoveredButNotExist()
        {
            return avalRequirementsCovevedRequirementNotExist;
        }

        public void setAmontFile(String amontFile)
        {
            this.amontFile = amontFile;
        }

        public void setAvalFile(String avalFile)
        {
            this.avalFile = avalFile;
        }

        public void setReportFile(String rapportFile)
        {
            this.rapportFile = rapportFile;
        }

        public void loadAmontRequirement()
        {
            List<string> fileList = amontFile.Split(';').ToList();
            foreach (var file in fileList)
            {
                string line;
                System.IO.StreamReader streamFile = new System.IO.StreamReader(file, System.Text.Encoding.UTF8);
                while ((line = streamFile.ReadLine()) != null)
                {
                    if(line.StartsWith("ReqID= ") == true)
                    {
                        line = line.Replace("  (T)", "");
                        line = line.Replace("  (P)", "");
                        line = line.Replace(" (T)", "");
                        line = line.Replace(" (P)", "");
                        line = line.Replace("(T)", "");
                        line = line.Replace("(P)", "");
                        line = line.Replace("\xA0", "");
                        amontRequirements.Add(line.Substring(line.IndexOf(" ") + 1));
                    }
                }

                streamFile.Close();
            }
        }

        public void loadAvalRequirement()
        {
            List<string> fileList = avalFile.Split(';').ToList();
            foreach (var file in fileList)
            {
                string line;
                string requirementAval = null;
                List<string> requirementAmont = null;
                System.IO.StreamReader streamFile = new System.IO.StreamReader(file, System.Text.Encoding.UTF8);
                while ((line = streamFile.ReadLine()) != null)
                {
                    if (line.StartsWith("ReqID= ") == true)
                    {
                        requirementAval = line.Substring(line.IndexOf(" ") + 1);
                    }
                    if (line.StartsWith("Exigence(s)-Amont= ") == true)
                    {
                        line = line.Replace("  (T)", "");
                        line = line.Replace("  (P)", "");
                        line = line.Replace(" (T)", "");
                        line = line.Replace(" (P)", "");
                        line = line.Replace("(T)", "");
                        line = line.Replace("(P)", "");
                        line = line.Replace("\xA0", "");
                        requirementAmont = line.Substring(line.IndexOf(" ") + 1).Split(' ').ToList();
                    }
                    if (requirementAmont != null && requirementAval != null)
                    {
                        avalRequirements.Add(requirementAval, requirementAmont);
                        requirementAval = null;
                        requirementAmont = null;
                    }
                }

                streamFile.Close();
            }
        }

        public void generateRapport()
        {

            string strStatus;

            if((amontRequirementsNotCovered.Count != 0) || (avalRequirementsCovevedRequirementNotExist.Count != 0))
            {
                strStatus = "INCORRECT";
            }
            else
            {
                strStatus = "CORRECT";
            }
            //StreamWriter rapportStreamWriter = new StreamWriter(rapportFile, false, System.Text.Encoding.ASCII);
            StreamWriter rapportStreamWriter = new StreamWriter(rapportFile);

            rapportStreamWriter.WriteLine("<HTML>");
            rapportStreamWriter.WriteLine(" <HEAD>");
            rapportStreamWriter.WriteLine("     <meta http-equiv=\"expires\" content=\"0\">");
            rapportStreamWriter.WriteLine("     <meta charset=\"UTF-8\">");
            rapportStreamWriter.WriteLine("     <LINK rel=\"stylesheet\" type=\"text/css\" href=\"style.css\">");
            rapportStreamWriter.WriteLine("     <TITLE>RAPPORT D'ANALYSE</TITLE>");
            rapportStreamWriter.WriteLine(" </HEAD>");
            rapportStreamWriter.WriteLine(" <BODY>");
            rapportStreamWriter.WriteLine("     <TABLE BORDER=0 WIDTH=100%>");
            rapportStreamWriter.WriteLine("         <TD WIDTH=20% VALIGN=TOP><img src=\"astek.jpg\"><br><A HREF=\"javascript:history.go(-1);\">Retour</A></TD>");
            rapportStreamWriter.WriteLine("         <TD WIDTH=60% VALIGN=TOP><CENTER><H2>PROJET X</H2></CENTER></TD>");
            rapportStreamWriter.WriteLine("         <TD WIDTH=20%>");
            rapportStreamWriter.WriteLine("         <TR>");
            rapportStreamWriter.WriteLine("             <TD COLSPAN=3 VALIGN=TOP>");
            rapportStreamWriter.WriteLine("                 <CENTER><H3>RAPPORT DE VERIFICATION</H3></CENTER>");
            rapportStreamWriter.WriteLine("             </TD>");
            rapportStreamWriter.WriteLine("         </TR>");
            rapportStreamWriter.WriteLine("         <P>");
            rapportStreamWriter.WriteLine("             <TABLE BORDER=0 WIDTH=100%>");
            rapportStreamWriter.WriteLine("                 <TD WIDTH=20%></TD>");
            rapportStreamWriter.WriteLine("                 <TD WIDTH=60% VALIGN=TOP><CENTER><H3>Résumé</H3></CENTER></TD>");
            rapportStreamWriter.WriteLine("                 <TD WIDTH=20%></TD>");
            rapportStreamWriter.WriteLine("                 <TR>");
            rapportStreamWriter.WriteLine("                     <TD WIDTH=20% VALIGN=TOP><CENTER>Couverture des exigence</CENTER></TD>");
            rapportStreamWriter.WriteLine("                     <TD WIDTH=60% VALIGN=TOP><CENTER>" + strStatus + "</CENTER></TD>");
            rapportStreamWriter.WriteLine("                 </TR>");
            rapportStreamWriter.WriteLine("                 <TR>");
            rapportStreamWriter.WriteLine("                     <TD WIDTH=20%></TD>");
            rapportStreamWriter.WriteLine("                     <TD WIDTH=60% VALIGN=TOP><CENTER><H3>Exigence non couvertes</H3></CENTER></TD>");
            rapportStreamWriter.WriteLine("                     <TD WIDTH=20%></TD>");
            rapportStreamWriter.WriteLine("                 </TR>");
            foreach(var amontRequirement in amontRequirementsNotCovered)
            {
                rapportStreamWriter.WriteLine("                 <TR>");
                rapportStreamWriter.WriteLine("                     <TD WIDTH=20% VALIGN=TOP></TD>");
                rapportStreamWriter.WriteLine("                     <TD WIDTH=60% VALIGN=TOP><CENTER>" + amontRequirement + "</CENTER></TD>");
                rapportStreamWriter.WriteLine("                 </TR>");
            }
            rapportStreamWriter.WriteLine("                 <TR>");
            rapportStreamWriter.WriteLine("                     <TD WIDTH=20%></TD>");
            rapportStreamWriter.WriteLine("                     <TD WIDTH=60% VALIGN=TOP><CENTER><H3>Exigence inconnues</H3></CENTER></TD>");
            rapportStreamWriter.WriteLine("                     <TD WIDTH=20%></TD>");
            rapportStreamWriter.WriteLine("                 </TR>");
            foreach(var amontUnknwon in avalRequirementsCovevedRequirementNotExist)
            {
                rapportStreamWriter.WriteLine("                 <TR>");
                rapportStreamWriter.WriteLine("                     <TD WIDTH=20% VALIGN=TOP>" + amontUnknwon.Item1 + "</TD>");
                rapportStreamWriter.WriteLine("                     <TD WIDTH=60% VALIGN=TOP><CENTER>Couvre l'exigence " + amontUnknwon.Item2 + " qui est inconnue</CENTER></TD>");
                rapportStreamWriter.WriteLine("                 </TR>");
            }
            rapportStreamWriter.WriteLine("             </TABLE>");
            rapportStreamWriter.WriteLine("         </P>");
            rapportStreamWriter.WriteLine("     </TABLE>");
            rapportStreamWriter.WriteLine(" </BODY>");
            rapportStreamWriter.WriteLine("</HTML>");

            rapportStreamWriter.Close(); 

        }

        private void checkCoverageDownToUp()
        {
             foreach (var avalRequirement in avalRequirements)
             {
                 List<string> amontRequirementList = avalRequirement.Value;
                 foreach(var amontRequirement in amontRequirementList)
                 {
                     if ((amontRequirements.Contains(amontRequirement) == false) && (amontRequirement != ""))
                     {
                         avalRequirementsCovevedRequirementNotExist.Add(new Tuple<string, string>(avalRequirement.Key, amontRequirement));
                     }
                 }
             }
        }

        private void checkCoverageUpToDown()
        {
            foreach (var amontRequirement in amontRequirements)
            {
                bool bFound = false;
                foreach(var avalRequirement in avalRequirements)
                {
                    if (avalRequirement.Value.Contains(amontRequirement) == true)
                    {
                        bFound = true;
                    }
                }
                if (bFound == false)
                {
                    amontRequirementsNotCovered.Add(amontRequirement);
                }
            }
        }

        protected List<string> amontRequirements = new List<string>();
        protected Dictionary<string, List<string>> avalRequirements = new Dictionary<string, List<string>>();
        protected List<Tuple<string, string>> avalRequirementsCovevedRequirementNotExist = new List<Tuple<string, string>>();
        protected List<string> amontRequirementsNotCovered = new List<string>();
        
        private string amontFile;
        private string avalFile;
        private string rapportFile;
    }
}
