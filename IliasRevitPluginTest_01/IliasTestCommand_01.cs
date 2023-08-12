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
    public class IliasTest_GetElementId : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;

            try
            {
                Reference pickedObj = uidoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element);

                if (pickedObj != null)
                {
                    TaskDialog.Show("Picked Element ID", pickedObj.ElementId.ToString());
                }

                return Result.Succeeded;
            }
            catch (Exception myException)
            {
                message = myException.Message;           
                return Result.Failed;
            }
        }
    }
}
