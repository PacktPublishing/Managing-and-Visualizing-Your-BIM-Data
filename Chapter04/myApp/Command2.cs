using Autodesk.Revit.UI;
using Autodesk.Revit.DB;

namespace myApp
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class Command2 : IExternalCommand
    {
        API api = new myApp.API();
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData revit, ref string message, ElementSet elements)
        {
            string url = "https://jsonplaceholder.typicode.com/todos/2";
            string apiResponse = this.api.GetRequest(url);

            TaskDialog.Show(url, apiResponse);
            return Autodesk.Revit.UI.Result.Succeeded;
        }
    }
}
