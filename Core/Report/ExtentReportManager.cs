﻿using System.Reflection;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;

namespace Practice.Core.Report
{
    public class ExtentReportManager
    {
        private static readonly Lazy<ExtentReports > _lazyReport = new Lazy<ExtentReports >(() => new ExtentReports ());
        public static ExtentReports  Instance { get { return _lazyReport.Value; } }

        static ExtentReportManager()
        {
            // Get report path
            string projectPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string reportPath = Path.Combine(projectPath, "TestResults");

            if (!Directory.Exists(reportPath))
            {
                Directory.CreateDirectory(reportPath);
                Console.WriteLine("Created directory: " + reportPath);
            }

            // Ensure config file exists
            string configPath = Path.Combine(projectPath, "ExtentReportConfig.xml");
            EnsureConfigFileExists(configPath);

            // Config html Reporter
            var htmlReporter = new ExtentHtmlReporter(Path.Combine(reportPath, "index.html"));
            htmlReporter.LoadConfig(configPath);
            Instance.AttachReporter(htmlReporter);
            Console.WriteLine("HtmlReporter configured successfully");
        }

        private static void EnsureConfigFileExists(string configPath)
        {
            if (!File.Exists(configPath))
            {
                var xmlContent = @"
                    <configuration>
                        <html>
                            <reportName>Test Automation Report</reportName>
                            <encoding>UTF-8</encoding>
                            <title>Test Automation Report</title>
                            <theme>standard</theme>
                            <protocol>https</protocol>
                            <autoCreateRelativePathMedia>true</autoCreateRelativePathMedia>
                        </html>
                    </configuration>";
                File.WriteAllText(configPath, xmlContent);
            }
        }

        public static void GenerateReport()
        {
            Instance.Flush();
        }
    }
}
