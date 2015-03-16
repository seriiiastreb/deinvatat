using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MasterPage : System.Web.UI.MasterPage, IMasterItems
{
    string mCurrentModule = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected string WriteAppPath()
    {
        string appPath = Utils.GetApplicationPath(Request);
        return appPath;
    }

    void IMasterItems.PerformPreloadActions(string currentModuleId, string pageName)
    {
        mCurrentModule = currentModuleId;

        string moduleDescription = Utils.ModuleSecurity().GetModuleDescriptionById(mCurrentModule);
        string pageDescription = !string.IsNullOrEmpty(moduleDescription) ? moduleDescription : "Self-service platform";

        this.Page.Title = pageName + (!string.IsNullOrEmpty(pageDescription) && !string.IsNullOrEmpty(pageName) ? " - " : string.Empty) + pageDescription;
        
        if (Utils.AutentificatedUser)
        {
            //// CREATE MODULE SELECTORS


            //// CREATE GENERAL MENU FOR MODULE


            //// LoginLOgout ButtonLink       
            string firstName = Utils.UserObject().FirstName;
            string lastName = Utils.UserObject().LastName;
            LogInLogOutLinkButton.Text = firstName + " " + lastName + " | Log OUT";
            LogInLogOutLinkButton.NavigateUrl = "~/Login.aspx?action=logout";

            emailBoxButton.Visible = true;
        }
        else
        {

            //// CREATE MODULE SELECTORS


            //// CREATE GENERAL MENU FOR MODULE
            //navMainMenuDIV.InnerHtml = resulAutentification && Session["MenuObject"] != null ? (string)Session["MenuObject"] : string.Empty;



            //// LoginLOgout ButtonLink    
            LogInLogOutLinkButton.Text = "Log IN";
            LogInLogOutLinkButton.NavigateUrl = "~/Login.aspx?action=login";

            emailBoxButton.Visible = false;
        }




        //bool resulAutentification = Utils.AutentificatedUser;

        //if (resulAutentification)
        //{
        //    if (Session["NavLinks"] == null)
        //    {
        //        DataTable navLinksDT = new DataTable();
        //        navLinksDT.Columns.Add("linkName", typeof(string));
        //        navLinksDT.Columns.Add("linkURL", typeof(string));
        //        navLinksDT.Columns.Add("linkID", typeof(string));

        //        Session["NavLinks"] = navLinksDT;
        //    }
        //}
        //else
        //{
        //    Session["NavLinks"] = null;
        //    Session["MenuObject"] = null;
        //}
    }

    void IMasterItems.ShowMessage(int messageType, string messageTitle, string message)
    {
        InfoWindow infoBox = (InfoWindow)mainDIV.FindControl("InfoBox");
        if (infoBox == null)
        {
            infoBox = (InfoWindow)LoadControl("~/Controls/InfoWindow.ascx");
        }

        infoBox.ID = "InfoBox";
        infoBox.MessageType = messageType;
        infoBox.WindowTitle = messageTitle;
        infoBox.Message = message;

        mainDIV.Controls.Add(infoBox);
        infoBox.Show();
    }

}
