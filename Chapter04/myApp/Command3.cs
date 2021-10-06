using Autodesk.Revit.UI;
using Autodesk.Revit.DB;

namespace myApp
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class Command3 : IExternalCommand
    {
        public DataParser dataParser = new DataParser();
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData revit, ref string message, ElementSet elements)
        {
            Document doc = revit.Application.ActiveUIDocument.Document;
            DataParser.Data data = this.dataParser.GetData(doc);

            TaskDialog.Show("Data Parsed", data.Print());
            return Autodesk.Revit.UI.Result.Succeeded;
        }
    }
}
