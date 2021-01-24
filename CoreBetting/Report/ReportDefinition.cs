using System.Configuration;

namespace CoreBetting.Report
{
    public class ReportDefinition
    {
        public static string ReportingFolder()
        {
             return @"C:\Users\Koochibotla.Kumar\Downloads\steps\CoreBetting";
            //return ConfigurationManager.AppSettings["ReportingFolder"];
        }
    }
}
