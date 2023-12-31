﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using System.Reflection;
using Autodesk.Revit.Attributes;
using System.Windows.Media.Imaging;

//TestComment

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
            application.CreateRibbonTab("Ilia's Commands Tab");

            //Create Pushbutton
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            PushButtonData button01 = new PushButtonData("button01", "MyButton_01", assemblyPath, "IliasRevitPluginTest_01.IliasTest_GetElementId");

            //Create Ribbon Panel, add buttons
            RibbonPanel commandsPanel = application.CreateRibbonPanel("Ilias Commands Tab", "Ilias Commands Panel");

            //Add image to button
            Uri buttonImage01Path = new Uri(@"C:\Users\DELL\source\repos\IliaRevitPluginTesting\IliasRevitPluginTest_01\Resources\redButtonImageSmall.png");
            BitmapImage myImage01 = new BitmapImage(buttonImage01Path);
            
            PushButton myButton01 = commandsPanel.AddItem(button01) as PushButton;
            myButton01.LargeImage = myImage01;

            return Result.Succeeded;
        }
    }
}
