using System;
using System.Web.UI.WebControls;

public interface IMasterItems
{
    void PerformPreloadActions(string currentModuleId, string pageName);
    //void AddNavlink(string linkName, string linkURL, string linkID);
    //bool IsEmptyNavLinks { get; }
    //void ClearNavLinks();
    //void ShowMainMenu();

    //void ShowMessage(System.Web.UI.WebControls.Panel panel, int messageType, string TitleWindow, string message);
    //void ShowMessage(System.Web.UI.UpdatePanel panel, int messageType, string TitleWindow, string message);
    //void ShowMessage(System.Web.UI.WebControls.Panel panel, int messageType, string TitleWindow, string message, int parameterX, int parameterY);
    //void ShowMessage(System.Web.UI.UpdatePanel panel, int messageType, string TitleWindow, string message, int parameterX, int parameterY);

    void ShowMessage(int messageType, string TitleWindow, string message);
}

