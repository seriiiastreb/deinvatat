using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SystemSeqAdmin : System.Web.UI.Page
{
    private readonly string mCurrentModule = Security.Module.ID;
    private readonly string mPageName = "System Sequrity Administration";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Utils.GetMaster(this).PerformPreloadActions(mCurrentModule, mPageName);

        bool allowHere = Utils.PermissionAllowed(mCurrentModule, Security.Domains.Administration.Name, Constants.Classifiers.Permissions_View);
        if (allowHere)
        {            
            FillDDLs();

            string eventArgument = Request.Params.Get("__EVENTARGUMENT");

            switch (Request.Params.Get("__EVENTTARGET"))
            {
                case "usersGridClik":

                    if (!usersGrid_Selection_HiddenValue.Value.Equals(string.Empty))
                    {
                        int selectedIndex = 0;
                        int.TryParse(usersGrid_Selection_HiddenValue.Value, out selectedIndex);

                        usersGrid.SelectedIndex = selectedIndex;
                    }

                    GridAction(eventArgument);
                    break;

                default:
                    break;
            }
        }
        else
        {
            Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Warning, "Access restricted.", "You do not have access to this page or options. Contact DataBase administrator to resolve this issues.");
        }       
    }

    protected void GridAction(string action)
    {
        switch (action.ToLower())
        {
            case "add":
                ClearAddUserPanel();
                addUserPopupExtender.Show();
                break;

            case "edit":

                break;

            case "delete":

                break;
        }
 
    }

    protected void FillDDLs()
    {
        DataTable passwordStatus = Utils.ModuleMain().GetClassifierByTypeID((int)Constants.ClassifierTypes.PasswordStatus);
        Utils.FillSelector(userDetails_PasswordStatusDDL, passwordStatus, "Name", "Code");

        DataTable recordStatus = Utils.ModuleMain().GetClassifierByTypeID((int)Constants.ClassifierTypes.SystemUserRecordStatus);
        Utils.FillSelector(userDetails_RecordStatusDDL, recordStatus, "Name", "Code");

    }

    protected void usersGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header) 
        { e.Row.TableSection = TableRowSection.TableHeader; }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
            e.Row.Attributes["onclick"] = "javascript: SetSelection('" + usersGrid.ClientID + "'," + e.Row.RowIndex + ", '" + usersGrid_Selection_HiddenValue.ClientID + "');";
        }
    }

    #region AddUser

    protected void FillUsersGridView()
    {
        DataTable sourceDT = Utils.ModuleSecurity().GetUsersList();
        usersGrid.DataSource = sourceDT;
        usersGrid.DataBind();
    }

    protected void ClearAddUserPanel()
    {
        addUser_Nume_TextBox.Text = string.Empty;
        addUser_Prenume_TextBox.Text = string.Empty;
        addUser_Login_TextBox.Text = string.Empty;
        addUser_Email_TextBox.Text = string.Empty;
        addUser_Password_TextBox.Text = string.Empty;
        addUser_RepeatPassword_TextBox.Text = string.Empty;

        try
        { userDetails_PasswordStatusDDL.SelectedIndex = 0; }
        catch { }
        try
        { userDetails_RecordStatusDDL.SelectedIndex = 0; }
        catch { }
    }

    protected void addUser_SaveButton_Click(object sender, EventArgs e)
    {
        bool allowHere = Utils.PermissionAllowed(mCurrentModule, Security.Domains.Administration.Name, Constants.Classifiers.Permissions_Edit);
        if (allowHere)
        {
            string nume = addUser_Nume_TextBox.Text;
            string prenume = addUser_Prenume_TextBox.Text;
            string login = addUser_Login_TextBox.Text;
            string password = addUser_Email_TextBox.Text;
            string email = addUser_Password_TextBox.Text;
            addUser_RepeatPassword_TextBox.Text = string.Empty;

            int passwordStatusID = 0;
            int.TryParse(userDetails_PasswordStatusDDL.SelectedValue, out passwordStatusID);

            int recordStatusID = 0;
            int.TryParse(userDetails_RecordStatusDDL.SelectedValue, out recordStatusID);


               if (Utils.ModuleSecurity().NewUser(nume, prenume, login, password, email, passwordStatusID, recordStatusID))
               {
                   ClearAddUserPanel();
                   FillUsersGridView();
                   
                   Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Ok, "Congratulation", "Succesifuly added user information.");
               }
               else
               {
                   Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Warning, "Attention", "Unable to add new user, try again later. Error message: " + Utils.ModuleSecurity().LastError);
               }

        }
        else
        {
            Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Warning, "Access restricted.", "You do not have access to this page or options. Contact DataBase administrator to resolve this issues.");
        }            
    }

    #endregion AddUser

    #region Reset Pass

    protected void ShowResetPassFrom()
    {
        if (usersGrid.SelectedIndex != 0)
        {

        }
    }

    protected void ClearResetPassForm()
    {
        resetPassTextBox.Text = string.Empty;
        resetPass_repeatTextBox.Text = string.Empty;
    }

    protected void resetPassOkButton_Click(object sender, EventArgs e)
    {
        bool allowHere = Utils.PermissionAllowed(mCurrentModule, Security.Domains.Administration.Name, Constants.Classifiers.Permissions_Edit);
        if (allowHere)
        {
           
        }
    }


    #endregion Reset Pass

}