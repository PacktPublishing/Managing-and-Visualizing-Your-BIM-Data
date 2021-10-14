import clr

clr.AddReference("RevitNodes")
import Revit
clr.ImportExtensions(Revit.Elements)

clr.AddReference("RevitServices")
import RevitServices
from RevitServices.Persistence import DocumentManager
doc = DocumentManager.Instance.CurrentDBDocument

clr.AddReference("RevitAPI")
import Autodesk
from Autodesk.Revit.DB import *

doc = DocumentManager.Instance.CurrentDBDocument
project_info = FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_ProjectInformation).ToElements()[0]
project_info_parameters = project_info.Parameters
output_list = []
for parameter in project_info_parameters:
output_list.append([parameter.Definition.Name, parameter.AsString()])
OUT = output_list
