﻿using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Web;
using System;
using System.Data;

namespace Adding_a_Custom_Function_to_the_Designer
{
    public partial class Default : System.Web.UI.Page
    {
        public static string MyFunc(string value)
        {
            return value.ToUpper();
        }

        static Default()
        {
            // How to Activate
            //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
            //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
            //Stimulsoft.Base.StiLicense.LoadFromStream(stream);

            var ParamNames = new string[1];
            var ParamTypes = new Type[1];
            var ParamDescriptions = new string[1];

            ParamNames[0] = "value";
            ParamDescriptions[0] = "Descriptions";
            ParamTypes[0] = typeof(string);

            // How to add my function
            StiFunctions.AddFunction(
                "MyCategory",
                "MyFunc",
                "MyFunc",
                "Description",
                typeof(Default),
                typeof(string),
                "Return Description",
                ParamTypes,
                ParamNames,
                ParamDescriptions);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void StiWebDesigner1_GetReport(object sender, StiReportDataEventArgs e)
        {
            var report = new StiReport();
            report.Load(Server.MapPath(@"Reports\MyInvoice.mrt"));

            // Add System.Web.dll library to the report references
            var assemblies = new string[report.ReferencedAssemblies.Length + 1];
            Array.Copy(report.ReferencedAssemblies, assemblies, report.ReferencedAssemblies.Length);
            assemblies[assemblies.Length - 1] = "System.Web.dll";
            report.ReferencedAssemblies = assemblies;

            e.Report = report;
        }

        protected void StiWebDesigner1_SaveReport(object sender, StiSaveReportEventArgs e)
        {
            var report = e.Report;
            report.Save(Server.MapPath(@"Reports\" + report.ReportName + ".mrt"));
        }
    }
}