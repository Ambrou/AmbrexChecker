using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmbrexChecker
{
    public class AmbrexCheckerExceptionFileMissing : Exception
    {
         public AmbrexCheckerExceptionFileMissing(string strTypeFile)
            : base(String.Format("le fichier {0} n'est pas renseigné", strTypeFile))
        {
        }
    }
}
