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
            FIll_ExperimentGrid();

            string eventArgument = Request.Params.Get("__EVENTARGUMENT");

            switch (Request.Params.Get("__EVENTTARGET"))
            {
                case "usersGridClik":

                    if (!ExperimentGrid_Selection_HiddenValue.Value.Equals(string.Empty))
                    {
                        int selectedIndex = 0;
                        int.TryParse(ExperimentGrid_Selection_HiddenValue.Value, out selectedIndex);

                        ExperimentGrid.SelectedIndex = selectedIndex;
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

    protected void FIll_ExperimentGrid()
    {
        DataTable sourceDT = new DataTable();
        sourceDT.Columns.Add("Column1", typeof(string));
        sourceDT.Columns.Add("Column2", typeof(string));
        sourceDT.Columns.Add("Column3", typeof(string));
        sourceDT.Columns.Add("Column4", typeof(string));
        sourceDT.Columns.Add("Column5", typeof(string));

        sourceDT.Rows.Add(",jbzddhcb", "lujhdfjlijnl,", "uuhsdkjdjjnd", "ljhchuoxcv", ",kjdhckhducvn");
        sourceDT.Rows.Add(",jbzddhcb", "lujhdfjlijnl,", "uuhsdkjdjjnd", "ljhchuoxcv", ",kjdhckhducvn");
        sourceDT.Rows.Add(",jbzddhcb", "lujhdfjlijnl,", "uuhsdkjdjjnd", "ljhchuoxcv", ",kjdhckhducvn");
        sourceDT.Rows.Add(",jbzddhcb", "lujhdfjlijnl,", "uuhsdkjdjjnd", "ljhchuoxcv", ",kjdhckhducvn");
        sourceDT.Rows.Add(",jbzddhcb", "lujhdfjlijnl,", "uuhsdkjdjjnd", "ljhchuoxcv", ",kjdhckhducvn");
        sourceDT.Rows.Add(",jbzddhcb", "lujhdfjlijnl,", "uuhsdkjdjjnd", "ljhchuoxcv", ",kjdhckhducvn");
        sourceDT.Rows.Add(",jbzddhcb", "lujhdfjlijnl,", "uuhsdkjdjjnd", "ljhchuoxcv", ",kjdhckhducvn");
        sourceDT.Rows.Add(",jbzddhcb", "lujhdfjlijnl,", "uuhsdkjdjjnd", "ljhchuoxcv", ",kjdhckhducvn");

        ExperimentGrid.DataSource = sourceDT;
        ExperimentGrid.DataBind();
    }

    protected void ExperimentGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header) 
        { e.Row.TableSection = TableRowSection.TableHeader; }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
            e.Row.Attributes["onclick"] = "javascript: SetSelection('" + ExperimentGrid.ClientID + "'," + e.Row.RowIndex + ", '" + ExperimentGrid_Selection_HiddenValue.ClientID + "');";
        }
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


               if (Utils.ModuleSecurity().NewUser(nume, prenume, login, password, email, groupList, passwordStatusID, recordStatusID))
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

        //        if (!userDetailsActionHiddenField.Value.Equals(string.Empty))
        //        {
        //            int userID = 0;
        //            int.TryParse(userDetailsUserIDHiddenField.Value, out userID);

        //            string nume = userDetails_Nume_TextBox.Text.Trim();
        //            string prenume = userDetails_Prenume_TextBox.Text.Trim();
        //            string login = userDetails_Login_TextBox.Text.Trim();
        //            string password = userDetails_Password_TextBox.Text.Trim();
        //            string email = userDetails_Email_TextBox.Text.Trim();

        //            List<string> groupList = new List<string>();
        //            for (int i = 0; i < userDetails_GoupsListBox.Items.Count; i++)
        //            {
        //                if (userDetails_GoupsListBox.Items[i].Selected && !groupList.Contains(userDetails_GoupsListBox.Items[i].Value))
        //                {
        //                    groupList.Add(userDetails_GoupsListBox.Items[i].Value);
        //                }
        //            }

        //            int passwordStatusID = 0;
        //            int.TryParse(userDetails_PasswordStatusDDL.SelectedValue.ToString(), out passwordStatusID);

        //            int recordStatusID = 0;
        //            int.TryParse(userDetails_RecordStatusDDL.SelectedValue.ToString(), out recordStatusID);

        //            if (Crypt.Module.DecodeCriptedString(userDetailsActionHiddenField.Value).Equals(Constants.UserOperation.Edit))
        //            {
        //                if (userID != 0 && Utils.ModuleSecurity().UpdateUser(userID, nume, prenume, login, password, email, groupList, passwordStatusID, recordStatusID, userDetails_ResetPasswordCheckBox.Checked))
        //                {
        //                    ClearUserForm();
        //                    userDetailsPanel.Visible = false;
        //                    FillUsersGridView();
        //                    userDetailsActionHiddenField.Value = Crypt.Module.CreateEncodedString(Constants.UserOperation.Edit);
        //                    Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Ok, "Congratulation", "Succesifuly updated user information.");
        //                }
        //                else
        //                {
        //                    Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Warning, "Attention", "Unable to Update user, try again later. Error message: " + Utils.ModuleSecurity().LastError);
        //                }
        //            }
        //            else
        //            {
        //                if (Utils.ModuleSecurity().NewUser(nume, prenume, login, password, email, groupList, passwordStatusID, recordStatusID))
        //                {
        //                    userDetailsPanel.Visible = false;
        //                    ClearUserForm();
        //                    FillUsersGridView();
        //                    userDetailsActionHiddenField.Value = Crypt.Module.CreateEncodedString(Constants.UserOperation.Edit);
        //                    Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Ok, "Congratulation", "Succesifuly added user information.");
        //                }
        //                else
        //                {
        //                    Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Warning, "Attention", "Unable to add new user, try again later. Error message: " + Utils.ModuleSecurity().LastError);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Warning, "Attention", "Any parameters is not valid, please ask for help from system administrator!");
        //        }
        //    }
        //    else
        //    {
        //        Response.Redirect(Utils.GetApplicationPath(Request) + "/AccessDenied.aspx");
        //    }
    }

    #endregion AddUser
}