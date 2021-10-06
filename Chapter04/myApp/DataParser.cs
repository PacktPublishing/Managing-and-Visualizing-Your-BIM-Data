using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.IO;
using System.Diagnostics;

namespace myApp
{

    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class DataParser : IExternalCommand
    {
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData revit, ref string message, ElementSet elements)
        {
            return Autodesk.Revit.UI.Result.Succeeded;
        }
        public Autodesk.Revit.UI.Result Display(Document doc)
        {
            Data data = GetData(doc);
            TaskDialog.Show("Parsed Data", data.Print());
            return Autodesk.Revit.UI.Result.Succeeded;
        }
        public Data GetData(Document doc)
        {
            Data data = new Data()
            {
                user = doc.Application.Username,
                software = doc.Application.VersionName,
                project = doc.ProjectInformation.Name,
                size = FileLengthToKBs(new FileInfo(doc.PathName).Length),
                dateTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                date = DateTime.UtcNow.ToString("yyyy-MM-dd") + "T00:00:00Z"
            };

            return data;
        }
        private float FileLengthToKBs(long length)
        {
            return (length / 1024);
        }

        public class Data
        {
            public string user;
            public string software;
            public string project;
            public float size;
            public string dateTime;
            public string date;

            public string ToJSON()
            {
                return "[{\"user\":\"" + user + "\","+
                    "\"software\":\"" + software + "\","+
                    "\"project\":\"" + project + "\","+
                    "\"size\":\"" + size + "\"," +
                    "\"dateTime\":\"" + dateTime + "\"," +
                    "\"date\":\"" + date + "\"}\r\n]";
            }
            public string Print()
            {
                return
                    "user:" + user +
                    "\nsoftware:" + software +
                    "\nproject:" + project +
                    "\nsize:" + size + " KB" +
                    "\ndateTime:" + dateTime +
                    "\ndate:" + date;
            }
        }
    }
}
