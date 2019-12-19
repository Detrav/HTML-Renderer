using FastReport.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastReport.Plugins.Html
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Config.DesignerSettings.ShowInTaskbar = true;
            Config.SplashScreenEnabled = true;


            using (Report report = new Report())
            {
                RegisteredObjects.Add(typeof(HtmlObject), "ReportPage", 246, 18);
                report.Design();
            }
        }
    }
}
