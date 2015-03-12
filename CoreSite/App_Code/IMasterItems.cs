using System;

public interface IMasterItems
{
    void PerformPreloadActions(string currentModuleId, string pageName);
    //void AddNavlink(string linkName, string linkURL, string linkID);
    //bool IsEmptyNavLinks { get; }
    //void ClearNavLinks();
    void ShowMainMenu();
}

