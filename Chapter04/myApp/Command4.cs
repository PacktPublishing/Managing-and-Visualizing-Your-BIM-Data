using Autodesk.Revit.UI;
using Autodesk.Revit.DB;

namespace myApp
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class Command4 : IExternalCommand
    {
        private string url = "https://api.powerbi.com...";  // replace url value with your POWER BI Push URL
        public DataParser dataParser = new DataParser();
        public API api = new API();
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData revit, ref string message, ElementSet elements)
        {
            Document doc = revit.Application.ActiveUIDocument.Document;
            DataParser.Data data = this.dataParser.GetData(doc);

            string apiResponse = api.PostRequest(data, url);

            TaskDialog.Show("Data Parsed", url + "\n\n" + apiResponse.ToString());
            return Autodesk.Revit.UI.Result.Succeeded;
        }
        public void Run(Document doc)
        {
            DataParser.Data data = this.dataParser.GetData(doc);
            api.PostRequest(data, url);
        }
    }
}