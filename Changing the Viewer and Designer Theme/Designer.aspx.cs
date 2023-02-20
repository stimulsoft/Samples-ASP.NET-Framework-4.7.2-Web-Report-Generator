﻿using Stimulsoft.Report;
using Stimulsoft.Report.Web;
using System;
using System.Data;

namespace Changing_the_Viewer_and_Designer_Theme_and_viewer
{
    public partial class Designer : System.Web.UI.Page
    {
        static Designer()
        {
            // How to Activate
            //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
            //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
            //Stimulsoft.Base.StiLicense.LoadFromStream(stream);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var report = new StiReport();
            report.Load(Server.MapPath(@"Reports\Invoice.mrt"));

            StiWebDesigner1.Theme = (StiDesignerTheme)Enum.Parse(typeof(StiDesignerTheme), Session["theme"] as string);
            StiWebDesigner1.Report = report;
        }

        protected void StiWebDesigner1_CreateReport(object sender, StiReportDataEventArgs e)
        {
            var data = new DataSet();
            data.ReadXmlSchema(Server.MapPath(@"Data\Demo.xsd"));
            data.ReadXml(Server.MapPath(@"Data\Demo.xml"));

            e.Report.RegData(data);
            e.Report.Dictionary.Synchronize();
        }

        protected void StiWebDesigner1_PreviewReport(object sender, StiReportDataEventArgs e)
        {

        }
    }
}