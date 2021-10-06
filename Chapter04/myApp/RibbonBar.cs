using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Windows.Media.Imaging;

namespace myApp
{
  public class RibbonBar
  {
    public void Init(UIControlledApplication application)
    {
      this.addRibbonBar(application);
    }
    private void addRibbonBar(UIControlledApplication application)
    {
      // Create a custom ribbon tab
      string tabName = "My Custom Toolbar";
      application.CreateRibbonTab(tabName);
      string mypath = System.Reflection.Assembly.GetExecutingAssembly().Location;

      // Create a panel with 3 buttons
      RibbonPanel panel = application.CreateRibbonPanel(tabName, "Sample Commands");
      AddPushButtonWithImage(panel, mypath, "button1", " Text ", "myApp.Command1", @"C:[YOUR_PATH_FOLDER]\packt-my-revit-plug-in\myApp\bin\Debug\icon-dialog_32x32.png");
      AddPushButtonWithImage(panel, mypath, "button2", " Web Request ", "myApp.Command2", @"C:[YOUR_PATH_FOLDER]\packt-my-revit-plug-in\myApp\bin\Debug\icon-web_32x32.png");

      // Create a panel with 1 image button
      RibbonPanel imagePanel = application.CreateRibbonPanel(tabName, "Model Data");
      AddPushButtonWithImage(imagePanel, mypath, "button3", "collect", "myApp.Command3", @"C:[YOUR_PATH_FOLDER]\packt-my-revit-plug-in\myApp\bin\Debug\icon-get_32x32.png");
      AddPushButtonWithImage(imagePanel, mypath, "button4", "send", "myApp.Command4", @"C:[YOUR_PATH_FOLDER]\packt-my-revit-plug-in\myApp\bin\Debug\icon-send_32x32.png");
    }
    private void AddBasicPushButton(RibbonPanel panel, string dllPath, string name, string text, string className)
    {
      PushButtonData buttonData = new PushButtonData(name, text, dllPath, className);
      PushButton Cmnd1 = panel.AddItem(buttonData) as PushButton;
    }
    private void AddPushButtonWithImage(RibbonPanel panel, string dllPath, string name, string text, string className, string imagePath)
    {
      PushButtonData buttonData = new PushButtonData(name, text, dllPath, className);
      PushButton pushButton = panel.AddItem(buttonData) as PushButton;

      // Set ToolTip and contextual help
      pushButton.ToolTip = "Say Hello World";
      ContextualHelp contextHelp = new ContextualHelp(ContextualHelpType.Url, "http://www.autodesk.com");
      pushButton.SetContextualHelp(contextHelp);

      // Set the large image shown on button
      pushButton.LargeImage = new BitmapImage(new Uri(imagePath));
    }
  }
}
