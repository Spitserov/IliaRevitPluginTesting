using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;

namespace IliasRevitPluginTest_01
{
    [TransactionAttribute(TransactionMode.ReadOnly)]
    public class IliasTest_ShowDocInfo : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;

            TaskDialog.Show("task dialog shows:", "THIS");

            return Result.Succeeded;          
        }

    }
}
