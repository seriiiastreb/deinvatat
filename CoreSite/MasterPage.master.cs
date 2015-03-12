using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public string navMainMenu = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void ShowMenu()
    {
        bool resulAutentification = Utils.AutentificatedUser;

        if (resulAutentification)
        {
            if (Session["NavLinks"] == null)
            {
                DataTable navLinksDT = new DataTable();
                navLinksDT.Columns.Add("linkName", typeof(string));
                navLinksDT.Columns.Add("linkURL", typeof(string));
                navLinksDT.Columns.Add("linkID", typeof(string));

                Session["NavLinks"] = navLinksDT;
            }
        }
        else
        {
            Session["NavLinks"] = null;
            Session["MenuObject"] = null;
        }

        navMainMenu = resulAutentification && Session["MenuObject"] != null ? (string)Session["MenuObject"] : string.Empty;
    }

    protected string WriteAppPath()
    {
        string appPath = Utils.GetApplicationPath(Request);
        return appPath;
    }

    protected void LogInLogOutLinkButton_Load(object sender, EventArgs e)
    {
        if (Utils.AutentificatedUser)
        {
            string firstName = Utils.UserObject().FirstName;
            string lastName = Utils.UserObject().LastName;
            LogInLogOutLinkButton.Text = firstName + " " + lastName + " | Log OUT";
            LogInLogOutLinkButton.NavigateUrl = "~/Default.aspx?action=logout";

            emailBoxButton.Visible = true;
        }
        else
        {
            LogInLogOutLinkButton.Text = "Log IN";
            LogInLogOutLinkButton.NavigateUrl = "~/Default.aspx?area=login";

            emailBoxButton.Visible = false;
        }
    }
}
