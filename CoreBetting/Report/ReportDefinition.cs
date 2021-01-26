using System;
using System.Configuration;
using System.IO;

namespace CoreBetting.Report
{
    public class ReportDefinition
    {
        public static string ReportingFolder()
        {
            string workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string parent = Directory.GetParent(workingDirectory).Parent.FullName;
            string parentDirectory = Directory.GetParent(parent).Parent.FullName;
            return parentDirectory;
            //return ConfigurationManager.AppSettings["ReportingFolder"];
        }
    }
}
