using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;

namespace myApp
{
    public class MyExternalApplication : IExternalApplication
    {
        public RibbonBar ribbonBar = new RibbonBar();
        public API api = new API();
        public DataParser dataParser = new DataParser();

        public Result OnStartup(UIControlledApplication application)
        {
            this.ribbonBar.Init(application);
            TaskDialog.Show("Revit", "my plug-in successfully loaded");

            try
            {   
                application.ControlledApplication.DocumentSynchronizingWithCentral += new EventHandler<Autodesk.Revit.DB.Events.DocumentSynchronizingWithCentralEventArgs>(application_DocumentSynchronizingWithCentral);
                return Result.Succeeded;
            }
            catch (Exception) { return Result.Failed; }
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            // remove the event.
            application.ControlledApplication.DocumentSynchronizingWithCentral -= application_DocumentSynchronizingWithCentral;
            return Result.Succeeded;
        }

        public void application_DocumentSynchronizingWithCentral(object sender, Autodesk.Revit.DB.Events.DocumentSynchronizingWithCentralEventArgs args)
        {
            // get document from event args.
            Document doc = args.Document;
            Command4 command = new Command4();
            command.Run(doc);
        }
    }
}
