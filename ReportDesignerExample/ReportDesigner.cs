using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Stimulsoft.Report;
using Stimulsoft.Report.Design;

namespace ReportDesignerExample
{
    public class ReportDesigner
    {
        private StiReport _report;
        private string _assemblyLocation;

        [STAThread]
        static void Main(string[] args)
        {
            new ReportDesigner();
        }
        public ReportDesigner()
        {
            ConfigureDesigner();
            _report = new StiReport();


            // Change a few settings
            StiOptions.Engine.ReportCache.CachePath = Path.Combine(Path.GetTempPath(), "ReportCache");
            StiOptions.Engine.ImageCache.Enabled = true;

            this.StiReport.ReportCacheMode = StiReportCacheMode.On;



            // set place to find the assemblies
            _assemblyLocation = AssemblyUtils.GetAssemblyDirectory();
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += ResolveEventHandler;

            StiReport.Tag = this;

            StiConfig.Services.Clear();
            StiOptions.Services.DataAdapters.Clear();
            // Database access

            StiOptions.Services.DataAdapters.Add(new GReportAdapterService(this));


            _report.Design(true);
        }

        private Assembly ResolveEventHandler(object sender, ResolveEventArgs args)
        {
            if (args.Name.StartsWith("Report") || args.Name.StartsWith("Stimulsoft"))
            {
                int pos = args.Name.IndexOf(",", StringComparison.Ordinal);
                string fileName = pos > -1
                    ? Path.Combine(this._assemblyLocation, args.Name.Substring(0, pos) + ".dll")
                    : Path.Combine(this._assemblyLocation, args.Name + ".dll");

                if (!File.Exists(fileName))
                {
                    return null;
                }

                return Assembly.LoadFrom(fileName);
            }

            return sender as Assembly;
        }

        private void ConfigureDesigner()
        {
            // attach events (detached in "ClosedDesigner()")
            StiDesigner.LoadedReport += LoadedReport;
            StiOptions.Engine.GlobalEvents.OpenRecentFileInDesigner += LoadedReportFromRecent;
        }

        /// <summary>
        /// Gets the Stimul soft report. 
        /// </summary>
        public StiReport StiReport
        {
            get
            {
                return this._report;
            }

            protected set { this._report = value; }
        }

        /// <summary>
        /// Loads the sti report and renews ReferencedAssemblies.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public void LoadStiReport(string filePath)
        {
            StiReport.Load(filePath);
            UpdateAssemblies();
        }

        /// <summary>
        /// List all the assemblies which contains stimulsoft components
        /// </summary>
        protected void UpdateAssemblies()
        {
            if (!StiReport.ReferencedAssemblies.Contains("ReportDesignerExample"))
            {
                List<string> newRefAssemblies = this.StiReport.ReferencedAssemblies.ToList();
                newRefAssemblies.Add("ReportDesignerExample");
                StiReport.ReferencedAssemblies = newRefAssemblies.ToArray();
            }
        }

        /// <summary>
        /// Loadeds the report.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void LoadedReport(object sender, EventArgs e)
        {
            var stiDesignerControl = sender as StiDesignerControl;

            if (stiDesignerControl != null && GReportConverterTool.IsOldReport(stiDesignerControl.ReportFileName))
            {
                GReportConverterTool.Convert(stiDesignerControl.ReportFileName);
                LoadStiReport(stiDesignerControl.ReportFileName);
            }
        }

        /// <summary>
        /// Loads a report selected in the recent tab
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void LoadedReportFromRecent(object sender, StiOpenRecentFileObjectEventArgs e)
        {
            if (GReportConverterTool.IsOldReport(e.FileName))
            {
                GReportConverterTool.Convert(e.FileName);

            }
            e.Processed = false;
            LoadStiReport(e.FileName);
        }
    }
}
