using System;
using System.Configuration;
using System.Data;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    #region Logger Setup
    protected static readonly log4net.ILog msLogger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    #endregion Logger Setup

    protected void Page_Load(object sender, EventArgs e)
    {
        Utils.RedirectIfSslRequired(Request, Response);

        //if (!IsPostBack && languageDropDownList.DataSource == null) FillLanguageDropDownList();

        if (Request["action"] != null)
        {
            string action = Request["action"].ToString();

            switch (action)
            {
                case "logout":
                    Session[Utils.SessionKey_UserObject] = null;
                    Session[Utils.SessionKey_ModuleSecurity] = null;
                    break;

                default:
                    break;
            }
        }

        if (!MaintenanceMode())
        {
            // If already logged in
            Security.User userObject = (Security.User)Session[Utils.SessionKey_UserObject];
            string userName = string.Empty;

            if (userObject != null)
            {
                userName = userObject.UserLogin;                

                // if user is active 
                if (userName != string.Empty)
                {
                    FormsAuthentication.RedirectFromLoginPage(userName, false);
                }
            }
        }
        else
        {
            Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Info, "Sorry.....", "This site is closed for maintenance. Please check back soon.");
        }
    }

    private bool MaintenanceMode()
    {
        bool maintenanceModeActive = true;
        bool.TryParse(ConfigurationManager.AppSettings["maintenanceMode"], out maintenanceModeActive);

        return maintenanceModeActive;
    }

    protected void loginButton_Click(object sender, EventArgs e)
    {
        string userIP = " IP:" + Request.UserHostAddress;
        try
        {
            string username = userNameTextBox.Text.Trim();
            string password = passwordTextBox.Text;

            string bypassers = ConfigurationManager.AppSettings["allowBypassMaintenanceMode"];

            if (!MaintenanceMode() || bypassers.Contains(username))
            {
                if (Authenticate(username, password))
                {
                    msLogger.Info("Login success. " + username + " from " + userIP);
                    //Session[Constants.GlobalSessionKey_CurrentLanguage] = languageDropDownList.SelectedValue;
                    FormsAuthentication.RedirectFromLoginPage(username, false);
                }
                else
                {
                    Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Error, "Error on page.", "Login failed. Incorrect user name or password.");
                    msLogger.Info("Login failed. " + username + " from " + userIP);
                }
            }
            else
            {
                Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Error, "Error on page.", "Sorry. This site is closed for maintenance. Please check back soon.");
                msLogger.Warn("Login attempt while site closed for maintenance." + username + " from " + userIP);
            }
        }
        catch (Exception ex)
        {
            Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Error, "Error on page.", ex.Message);
            msLogger.Fatal(ex.Message + userIP);
        }
    }

    private bool Authenticate(string login, string password)
    {
        bool result = false;

        if (Session[Utils.SessionKey_UserObject] != null) Session[Utils.SessionKey_UserObject] = null;

        if (login.Contains("'") || login.Contains(" ") || password.Contains("'") || password.Contains(" "))
        {
            throw new Exception("Invalid characters in login or password");
        }

        Security.User userObject = Security.User.Login(login, password);
        if (userObject == null) throw new Exception("Null user object received");

        msLogger.Info("Login attempt.  " + userObject.UserLogin + " - UserObject created. Creating modules...");

        Session[Utils.SessionKey_UserObject] = userObject;
        Session[Utils.SessionKey_ModuleSecurity] = new Security.Module();

        CreateModulesByRole(userObject);

        result = true;

        return result;
    }

    private void CreateModulesByRole(Security.User userObject)
    {
        

    }

}