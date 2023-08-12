using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using System.Reflection;
using Autodesk.Revit.Attributes;

namespace IliasRevitPluginTest_01
{
    [TransactionAttribute(TransactionMode.ReadOnly)]
    class ToolbarExternalApplication : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            //Create Ribbon Tab
            application.CreateRibbonTab("Ilias Commands Tab");

            //Create Pushbutton
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            PushButtonData button01 = new PushButtonData("button01", "MyButton_01", assemblyPath, "IliasRevitPluginTest_01.IliasTest_GetElementId");
            PushButtonData button02 = new PushButtonData("button02", "MyButton_02", assemblyPath, "IliasRevitPluginTest_01.IliasTest_ShowDocInfo");


            //Create Ribbon Panel
            RibbonPanel commandsPanel = application.CreateRibbonPanel("Ilias Commands Tab", "Ilias Commands Panel");
            commandsPanel.AddItem(button01);
            commandsPanel.AddItem(button02);


            return Result.Succeeded;
        }
    }
}
