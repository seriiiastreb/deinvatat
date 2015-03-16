using System;
using System.Web.UI.WebControls;

public interface IMasterItems
{
    void PerformPreloadActions(string currentModuleId, string pageName);
    void ShowMessage(int messageType, string TitleWindow, string message);


}

