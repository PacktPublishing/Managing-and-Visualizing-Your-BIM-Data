using Autodesk.Revit.UI;
using Autodesk.Revit.DB;

namespace myApp
{

    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class Command1 : IExternalCommand
    {
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData revit, ref string message, ElementSet elements)
        {
            TaskDialog.Show("Revit", "Simple text command!");
            return Autodesk.Revit.UI.Result.Succeeded;
        }
    }
}
