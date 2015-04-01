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

    bool allowEdit = false;
    bool allowView = false;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Utils.GetMaster(this).PerformPreloadActions(mCurrentModule, mPageName);

        allowEdit = Utils.PermissionAllowed(mCurrentModule, Security.Domains.Administration.Name, Constants.Classifiers.Permissions_Edit);
        allowView = Utils.PermissionAllowed(mCurrentModule, Security.Domains.Administration.Name, Constants.Classifiers.Permissions_View);

        if (allowView)
        {            
            FillDDLs();
            FillUsersGridView();

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
                ClearEditForm();
                editUserPopupExtender.Show();
                break;

            case "rst":
                ClearResetPasswordForm();
                resetPassPopupExtender.Show();                
                break;

            case "delete":
                deleteUserModalPopupExtender.Show();
                break;
        }
 
    }

    protected void FillDDLs()
    {
        DataTable passwordStatus = Utils.ModuleMain().GetClassifierByTypeID((int)Constants.ClassifierTypes.PasswordStatus);
        Utils.FillSelector(userDetails_PasswordStatusDDL, passwordStatus, "Name", "Code");

        DataTable recordStatus = Utils.ModuleMain().GetClassifierByTypeID((int)Constants.ClassifierTypes.SystemUserRecordStatus);
        Utils.FillSelector(userDetails_RecordStatusDDL, recordStatus, "Name", "Code");

        Utils.FillSelector(editUserPWDStatusDDL, passwordStatus, "Name", "Code");
        Utils.FillSelector(editUserRECStatus, recordStatus, "Name", "Code");
    }

    protected void usersGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        { e.Row.TableSection = TableRowSection.TableHeader; }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
            //e.Row.Attributes["mousedown"] = "SetSelection(this.event,'" + usersGrid.ClientID + "'," + e.Row.RowIndex + ", '" + usersGrid_Selection_HiddenValue.ClientID + "');";
            //e.Row.Attributes["onrightclick"] = "javascript: SetSelection('" + usersGrid.ClientID + "'," + e.Row.RowIndex + ", '" + usersGrid_Selection_HiddenValue.ClientID + "');";

        }
    }

    protected void FillUsersGridView()
    {
        DataTable sourceDT = Utils.ModuleSecurity().GetUsersList();
        usersGrid.DataSource = sourceDT;
        usersGrid.DataBind();
    }

    #region AddUser
    
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
        if (allowEdit)
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
                addUserPopupExtender.Hide();
                   
                Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Ok, "Congratulation", "Succesifuly added user information.");
            }
            else
            {
                addUserPopupExtender.Show();
                Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Warning, "Attention", "Unable to add new user, try again later. " + (Utils.UserObject().IsSysadmin ? Utils.ModuleSecurity().LastError : string.Empty));
            }
        }
        else
        {
            Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Warning, "Access restricted.", "You do not have access to this page or options. Contact DataBase administrator to resolve this issues.");
        }            
    }

    #endregion AddUser

    #region Reset Pass

    protected void ClearResetPasswordForm()
    {
        resetPassTextBox.Text = string.Empty;
        resetPass_repeatTextBox.Text = string.Empty;
    }
    
    protected void resetPassOkButton_Click(object sender, EventArgs e)
    {        
        if (allowEdit)
        {
            if (usersGrid.SelectedRow != null)
            {
                int userID = 0;
                int.TryParse(usersGrid.SelectedRow.Cells[0].Text, out userID);

                if (userID != 0)
                {
                    string newPassword = resetPass_repeatTextBox.Text.Trim();

                    if (Utils.ModuleSecurity().ResetUserPassword(userID, newPassword))
                    {
                        //FillUsersGridView();
                        resetPassPopupExtender.Hide();
                        ClearResetPasswordForm();
                    }
                    else
                    {
                        resetPassPopupExtender.Hide();
                        Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Error, "Error updating record.", "For selected user was not changet password. Try again later! " + (Utils.UserObject().IsSysadmin ? Utils.ModuleSecurity().LastError : string.Empty));
                    }
                }
            }
        }
        else
        {
            Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Warning, "Access restricted.", "You do not have access to this page or options. Contact DataBase administrator to resolve this issues.");
        }  
    }

    #endregion Reset Pass

    #region Edit User

    protected void ClearEditForm()
    {
        editUserNumeTextBox.Text = string.Empty;
        editUserLastNameTextBox.Text = string.Empty;
        editUserLoginTextBox.Text = string.Empty;
        editUserEmailTextBox.Text = string.Empty;

        try { editUserPWDStatusDDL.SelectedIndex = 0; }
        catch { }

        try { editUserRECStatus.SelectedIndex = 0; }
        catch { }
    }

    protected void editUserOkButton_Click(object sender, EventArgs e)
    {
        if (allowEdit)
        {
            //string nume = addUser_Nume_TextBox.Text;
            //string prenume = addUser_Prenume_TextBox.Text;
            //string login = addUser_Login_TextBox.Text;
            //string password = addUser_Email_TextBox.Text;
            //string email = addUser_Password_TextBox.Text;
            //addUser_RepeatPassword_TextBox.Text = string.Empty;

            //int passwordStatusID = 0;
            //int.TryParse(userDetails_PasswordStatusDDL.SelectedValue, out passwordStatusID);

            //int recordStatusID = 0;
            //int.TryParse(userDetails_RecordStatusDDL.SelectedValue, out recordStatusID);


            //if (Utils.ModuleSecurity().NewUser(nume, prenume, login, password, email, passwordStatusID, recordStatusID))
            //{
            //    ClearAddUserPanel();
            //    FillUsersGridView();
            //    addUserPopupExtender.Hide();
                   
            //    Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Ok, "Congratulation", "Succesifuly added user information.");
            //}
            //else
            //{
            //    addUserPopupExtender.Show();
            //    Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Warning, "Attention", "Unable to add new user, try again later. " + (Utils.UserObject().IsSysadmin ? Utils.ModuleSecurity().LastError : string.Empty));
            //}
        }
        else
        {
            Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Warning, "Access restricted.", "You do not have access to this page or options. Contact DataBase administrator to resolve this issues.");
        }            
    }


    #endregion Edit User

    #region  Delete User

    protected void deleteUserOkButton_Click(object sender, EventArgs e)
    {
        if (allowEdit)
        {
            if (usersGrid.SelectedRow != null)
            {
                int userID = 0;
                int.TryParse(usersGrid.SelectedRow.Cells[0].Text, out userID);

                if (userID != 0)
                {
                    if (Utils.ModuleSecurity().DeleteUser(userID))
                    { 
                        FillUsersGridView();
                        deleteUserModalPopupExtender.Hide();
                    }
                    else
                    {
                        deleteUserModalPopupExtender.Hide();
                        Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Error, "Error deleting record.", "Selected user not deleted. Try again later! " + (Utils.UserObject().IsSysadmin ? Utils.ModuleSecurity().LastError : string.Empty ));
                    }
                }
            }
        }
        else
        {
            Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Warning, "Access restricted.", "You do not have access to this page or options. Contact DataBase administrator to resolve this issues.");
        }  
    }

    #endregion  Delete User

}