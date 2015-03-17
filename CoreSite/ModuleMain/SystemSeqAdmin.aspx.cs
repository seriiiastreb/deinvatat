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
    private readonly string mEfectivePermVS = "EfectivePermissions";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Utils.GetMaster(this).PerformPreloadActions(mCurrentModule, mPageName);

        bool allowHere = Utils.PermissionAllowed(mCurrentModule, Security.Domains.Administration.Name, Constants.Classifiers.Permissions_View);
        if (allowHere)
        {
            FIll_ExperimentGrid();
        }
        else
        {
           // Response.Redirect(Utils.GetApplicationPath(Request) + "/AccessDenied.aspx");
        }       
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

        //ExperimentGrid.DataSource = sourceDT;
        //ExperimentGrid.DataBind();
    }


    //#region General Functions

    //protected void usersListButton_Click(object sender, EventArgs e)
    //{
    //    groupPermissionsConfigPanel.Visible = false;
    //    usersAdminPanel.Visible = true;

    //    FillUsersGridView();
    //    FillComboBoxesInUserForm();
    //}

    //protected void groupsDomainsButton_Click(object sender, EventArgs e)
    //{
    //    groupPermissionsConfigPanel.Visible =  true;
    //    usersAdminPanel.Visible = false;

    //    FillgroupsListBox();
    //    FillModulesComboBox();
    //    FillDomainslistBox();
    //}

    //#endregion General Functions

    //#region Groups

    //protected void FillgroupsListBox()
    //{
    //    DataTable groupsList = Utils.ModuleSecurity().GetGroupsList();
    //    groupsListBox.DataSource = groupsList;
    //    groupsListBox.DataTextField = "role_id";
    //    groupsListBox.DataValueField = "role_id";
    //    groupsListBox.DataBind();
    //}

    //protected void regreshButton_Click(object sender, EventArgs e)
    //{
    //    FillgroupsListBox();
    //}

    //protected void newGroupButton_Click(object sender, EventArgs e)
    //{
    //    newGroupPanel.Visible = true;
    //    newGroupTextBox.Text = string.Empty;
    //}

    //protected void newGroupSaveButton_Click(object sender, EventArgs e)
    //{
    //    newGroupPanel.Visible = false;
    //    bool allowHere = Utils.PermissionAllowed(mCurrentModule, Security.Domains.Administration.Name, Constants.Classifiers.Permissions_Edit);
    //    if (allowHere)
    //    {
    //        string newGroupName = newGroupTextBox.Text.Trim();

    //        if (Utils.ModuleSecurity().AddGroup(newGroupName))
    //        {
    //            FillgroupsListBox();
    //        }
    //        else
    //        {
    //            Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Error, "Error!", "Unable add group. Try again later."); 
    //        }
    //    }
    //    else
    //    {
    //        Response.Redirect(Utils.GetApplicationPath(Request) + "/AccessDenied.aspx");
    //    }
    //}

    //protected void newGroupCancelButton_Click(object sender, EventArgs e)
    //{
    //    newGroupPanel.Visible = false;
    //}

    //protected void deleteGroupButton_Click(object sender, EventArgs e)
    //{
    //    bool allowHere = Utils.PermissionAllowed(mCurrentModule, Security.Domains.Administration.Name, Constants.Classifiers.Permissions_Edit);
    //    if (allowHere)
    //    {
    //        if (groupsListBox.SelectedValue != null)
    //        {
    //            string selectedRow = groupsListBox.SelectedValue;                
    //            if (Utils.ModuleSecurity().DeleteGroup(selectedRow))
    //            {
    //                FillgroupsListBox();
    //            }
    //            else
    //            {
    //                Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Error, "Error!", "Unable delete group. Try again later.");
    //            }
    //        }
    //    }
    //    else
    //    {
    //        Response.Redirect(Utils.GetApplicationPath(Request) + "/AccessDenied.aspx");
    //    }
    //}

    //#endregion Groups

    //#region Modules

    //protected void FillModulesComboBox()
    //{
    //    DataTable modulList = Utils.ModuleSecurity().GetModulesList();
    //    Utils.FillSelector(aviableModulesDDL, modulList, "description", "module_id");
    //}

    //protected void registerModulesButton_Click(object sender, EventArgs e)
    //{
    //    bool allowHere = Utils.PermissionAllowed(mCurrentModule, Security.Domains.Administration.Name, Constants.Classifiers.Permissions_Edit);
    //    if (allowHere)
    //    {
    //        try
    //        {
    //            Security.MainModule.Register();

    //            FillModulesComboBox();
    //            FillDomainslistBox();
    //        }
    //        catch (Exception ex)
    //        {
    //            Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Error, "System error!", ex.Message); 
    //        }
    //    }
    //    else
    //    {
    //        Response.Redirect(Utils.GetApplicationPath(Request) + "/AccessDenied.aspx");
    //    }
    //}

    //protected void FillDomainslistBox()
    //{
    //    bool allowHere = Utils.PermissionAllowed(mCurrentModule, Security.Domains.Administration.Name, Constants.Classifiers.Permissions_View);
    //    if (allowHere)
    //    {
    //        if (aviableModulesDDL.SelectedValue != null && !aviableModulesDDL.SelectedValue.Equals(string.Empty))
    //        {
    //            string moduleID = aviableModulesDDL.SelectedValue;
    //            DataTable domainsList = Utils.ModuleSecurity().GetDomainsListInModule(moduleID);
    //            aviableDomaninsListBox.DataSource = domainsList;
    //            aviableDomaninsListBox.DataTextField = "description";
    //            aviableDomaninsListBox.DataValueField = "domain_id";
    //            aviableDomaninsListBox.DataBind();
    //        }
    //    }
    //    else
    //    {
    //        Response.Redirect(Utils.GetApplicationPath(Request) + "/AccessDenied.aspx");
    //    }
    //}
    
    //protected void aviableModulesDDL_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    FillDomainslistBox();
    //}

    //#endregion Modules

    //#region EfectivePermissions Manipulation

    //protected void groupsListBox_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    bool allowHere = Utils.PermissionAllowed(mCurrentModule, Security.Domains.Administration.Name, Constants.Classifiers.Permissions_View);
    //    if (allowHere)
    //    {
    //        if (groupsListBox.SelectedValue != null && !groupsListBox.SelectedValue.Equals(string.Empty))
    //        {
    //            string groupID = groupsListBox.SelectedValue;
    //            DataTable efectivePermissionsDT = Utils.ModuleSecurity().GetPermissionsForGroup(groupID);
    //            ViewState[mEfectivePermVS] = efectivePermissionsDT;
    //            UpdateEfectivePermissionsGroupListBox();
    //        }
    //    } 
    //    else
    //    {
    //        Response.Redirect(Utils.GetApplicationPath(Request) + "/AccessDenied.aspx");
    //    }
    //}

    //protected void UpdateEfectivePermissionsGroupListBox()
    //{
    //    string display_key = string.Empty;
    //    if (efectivePermissionsGroupListBox.SelectedItem != null)
    //    {
    //        display_key = efectivePermissionsGroupListBox.SelectedItem.Text;
    //    }

    //    DataTable sourceTable = GetPermissionsTableFromViewState();
    //    efectivePermissionsGroupListBox.DataSource = sourceTable;
    //    efectivePermissionsGroupListBox.DataTextField = "display_key";
    //    efectivePermissionsGroupListBox.DataValueField = "key";
    //    efectivePermissionsGroupListBox.DataBind();

    //    if (!display_key.Equals(string.Empty))
    //    {
    //        for (int i = 0; i < efectivePermissionsGroupListBox.Items.Count; i++)
    //        {
    //            if (efectivePermissionsGroupListBox.Items[i].Text.Equals(display_key))
    //            {
    //                efectivePermissionsGroupListBox.Items[i].Selected = true;
    //                i = efectivePermissionsGroupListBox.Items.Count;
    //            }
    //        }
    //    }
    //}

    //protected void efectivePermissionsGroupListBox_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (efectivePermissionsGroupListBox.SelectedItem != null)
    //    {
    //        string[] keys = efectivePermissionsGroupListBox.SelectedValue.Split('~');

    //        if (keys != null && keys.Length == 4)
    //        {
    //            int permissionsCode = 0;
    //            int.TryParse(keys[3], out permissionsCode);

    //            if (!permissionsCode.Equals(string.Empty))
    //            {
    //                switch (permissionsCode)
    //                {
    //                    case (int)Constants.Classifiers.Permissions_View:
    //                        efectivePermissions_Read_RadioButton.Checked = true;
    //                        efectivePermissions_Write_RadioButton.Checked = false;
    //                        efectivePermissions_Denied_RadioButton.Checked = false;
    //                        break;

    //                    case (int)Constants.Classifiers.Permissions_Edit:
    //                        efectivePermissions_Read_RadioButton.Checked = false;
    //                        efectivePermissions_Write_RadioButton.Checked = true;
    //                        efectivePermissions_Denied_RadioButton.Checked = false;
    //                        break;

    //                    case (int)Constants.Classifiers.Permissions_Deny:
    //                        efectivePermissions_Read_RadioButton.Checked = false;
    //                        efectivePermissions_Write_RadioButton.Checked = false;
    //                        efectivePermissions_Denied_RadioButton.Checked = true;
    //                        break;

    //                    default:
    //                        efectivePermissions_Read_RadioButton.Checked = false;
    //                        efectivePermissions_Write_RadioButton.Checked = false;
    //                        efectivePermissions_Denied_RadioButton.Checked = false;
    //                        break;
    //                }
    //            }
    //        }
    //    }
    //}

    //protected void efectivePermissions_Read_RadioButton_CheckedChanged(object sender, EventArgs e)
    //{
    //    bool allowHere = Utils.PermissionAllowed(mCurrentModule, Security.Domains.Administration.Name, Constants.Classifiers.Permissions_Edit);
    //    if (allowHere)
    //    {
    //        if (efectivePermissionsGroupListBox.SelectedItem != null)
    //        {
    //            string display_key = efectivePermissionsGroupListBox.SelectedItem.Text;
    //            string[] keys = efectivePermissionsGroupListBox.SelectedValue.Split('~');

    //            if (keys != null && keys.Length == 4 && !keys[0].Equals(string.Empty) && !keys[1].Equals(string.Empty) && !keys[2].Equals(string.Empty) && !keys[3].Equals(string.Empty))
    //            {
    //                string moduleID = keys[0];
    //                string roleID = keys[1];
    //                string domainID = keys[2];

    //                if (Utils.ModuleSecurity().UpdatePermissions(moduleID, roleID, domainID, (int)Constants.Classifiers.Permissions_View))
    //                {
    //                    DataTable viewstateDT = GetPermissionsTableFromViewState();

    //                    if (viewstateDT != null)
    //                    {
    //                        for (int i = 0; i < viewstateDT.Rows.Count; i++)
    //                        {
    //                            if (viewstateDT.Rows[i]["display_key"].ToString().Equals(display_key))
    //                            {
    //                                viewstateDT.Rows[i]["key"] = moduleID + "~" + roleID + "~" + domainID + "~" + (int)Constants.Classifiers.Permissions_View;
    //                                viewstateDT.Rows[i]["permissions"] = (int)Constants.Classifiers.Permissions_View;

    //                                ViewState[mEfectivePermVS] = viewstateDT;
    //                                UpdateEfectivePermissionsGroupListBox();

    //                                i = viewstateDT.Rows.Count;
    //                            }
    //                        }
    //                    }
    //                }
    //                else
    //                {
    //                    ////  error message
    //                }

    //            }
    //        }           
    //    }
    //    else
    //    {
    //        Response.Redirect(Utils.GetApplicationPath(Request) + "/AccessDenied.aspx");
    //    }
    //}

    //protected void efectivePermissions_Write_RadioButton_CheckedChanged(object sender, EventArgs e)
    //{
    //    bool allowHere = Utils.PermissionAllowed(mCurrentModule, Security.Domains.Administration.Name, Constants.Classifiers.Permissions_Edit);
    //    if (allowHere)
    //    {
    //        if (efectivePermissionsGroupListBox.SelectedItem != null)
    //        {
    //            string display_key = efectivePermissionsGroupListBox.SelectedItem.Text;
    //            string[] keys = efectivePermissionsGroupListBox.SelectedValue.Split('~');

    //            if (keys != null && keys.Length == 4 && !keys[0].Equals(string.Empty) && !keys[1].Equals(string.Empty) && !keys[2].Equals(string.Empty) && !keys[3].Equals(string.Empty))
    //            {
    //                string moduleID = keys[0];
    //                string roleID = keys[1];
    //                string domainID = keys[2];

    //                if (Utils.ModuleSecurity().UpdatePermissions(moduleID, roleID, domainID, (int)Constants.Classifiers.Permissions_Edit))
    //                {
    //                    DataTable viewstateDT = GetPermissionsTableFromViewState();

    //                    if (viewstateDT != null)
    //                    {
    //                        for (int i = 0; i < viewstateDT.Rows.Count; i++)
    //                        {
    //                            if (viewstateDT.Rows[i]["display_key"].ToString().Equals(display_key))
    //                            {
    //                                viewstateDT.Rows[i]["key"] = moduleID + "~" + roleID + "~" + domainID + "~" + (int)Constants.Classifiers.Permissions_Edit;
    //                                viewstateDT.Rows[i]["permissions"] = (int)Constants.Classifiers.Permissions_Edit;

    //                                ViewState[mEfectivePermVS] = viewstateDT;
    //                                UpdateEfectivePermissionsGroupListBox();

    //                                i = viewstateDT.Rows.Count;
    //                            }
    //                        }
    //                    }
    //                }
    //                else
    //                {
    //                    ///  error message
    //                }
    //            }
    //        }
    //    }
    //    else
    //    {
    //        Response.Redirect(Utils.GetApplicationPath(Request) + "/AccessDenied.aspx");
    //    }
    //}

    //protected void efectivePermissions_Denied_RadioButton_CheckedChanged(object sender, EventArgs e)
    //{
    //    bool allowHere = Utils.PermissionAllowed(mCurrentModule, Security.Domains.Administration.Name, Constants.Classifiers.Permissions_Edit);
    //    if (allowHere)
    //    {
    //        if (efectivePermissionsGroupListBox.SelectedItem != null)
    //        {
    //            string display_key = efectivePermissionsGroupListBox.SelectedItem.Text;
    //            string[] keys = efectivePermissionsGroupListBox.SelectedValue.Split('~');

    //            if (keys != null && keys.Length == 4 && !keys[0].Equals(string.Empty) && !keys[1].Equals(string.Empty) && !keys[2].Equals(string.Empty) && !keys[3].Equals(string.Empty))
    //            {
    //                string moduleID = keys[0];
    //                string roleID = keys[1];
    //                string domainID = keys[2];

    //                if (Utils.ModuleSecurity().UpdatePermissions(moduleID, roleID, domainID, (int)Constants.Classifiers.Permissions_Deny))
    //                {
    //                    DataTable viewstateDT = GetPermissionsTableFromViewState();

    //                    if (viewstateDT != null)
    //                    {
    //                        for (int i = 0; i < viewstateDT.Rows.Count; i++)
    //                        {
    //                            if (viewstateDT.Rows[i]["display_key"].ToString().Equals(display_key))
    //                            {
    //                                viewstateDT.Rows[i]["key"] = moduleID + "~" + roleID + "~" + domainID + "~" + (int)Constants.Classifiers.Permissions_Deny;
    //                                viewstateDT.Rows[i]["permissions"] = (int)Constants.Classifiers.Permissions_Deny;

    //                                ViewState[mEfectivePermVS] = viewstateDT;
    //                                UpdateEfectivePermissionsGroupListBox();

    //                                i = viewstateDT.Rows.Count;
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    else
    //    {
    //        Response.Redirect(Utils.GetApplicationPath(Request) + "/AccessDenied.aspx");
    //    }
    //}

    //protected DataTable GetPermissionsTableFromViewState()
    //{
    //    DataTable result = null;

    //    if (ViewState[mEfectivePermVS] != null)
    //    {
    //        result = (DataTable)ViewState[mEfectivePermVS];
    //    }
    //    else
    //    {
    //        result = Utils.ModuleSecurity().GetPermissionsForGroup("emptyGroup");
    //    }

    //    return result;
    //}

    //protected void moveToLeftButton_Click(object sender, ImageClickEventArgs e)
    //{
    //    bool allowHere = Utils.PermissionAllowed(mCurrentModule, Security.Domains.Administration.Name, Constants.Classifiers.Permissions_Edit);
    //    if (allowHere)
    //    {
    //        if (aviableModulesDDL.SelectedValue != null && aviableDomaninsListBox.SelectedValue != null && groupsListBox.SelectedValue != null)
    //        {
    //            DataTable viewstateDT = GetPermissionsTableFromViewState();

    //            if (viewstateDT != null)
    //            {
    //                string moduleID = aviableModulesDDL.SelectedValue;
    //                string domainID = aviableDomaninsListBox.SelectedValue;
    //                string roleID = groupsListBox.SelectedValue;
    //                string key = moduleID + "~" + roleID + "~" + domainID + "~" + (int)Constants.Classifiers.Permissions_View;
    //                string display_key = moduleID + "~" + roleID + "~" + domainID;

    //                bool foundKey = false;

    //                for (int i = 0; i < viewstateDT.Rows.Count; i++)
    //                {
    //                    if (viewstateDT.Rows[i]["display_key"].ToString().Equals(display_key))
    //                    {
    //                        foundKey = true;
    //                    }
    //                }

    //                if (!foundKey)
    //                {
    //                    if (Utils.ModuleSecurity().UpdatePermissions(moduleID, roleID, domainID, (int)Constants.Classifiers.Permissions_View))
    //                    {
    //                        viewstateDT.Rows.Add();
    //                        viewstateDT.Rows[viewstateDT.Rows.Count - 1]["module_id"] = moduleID;
    //                        viewstateDT.Rows[viewstateDT.Rows.Count - 1]["role_id"] = roleID;
    //                        viewstateDT.Rows[viewstateDT.Rows.Count - 1]["domain_id"] = domainID;
    //                        viewstateDT.Rows[viewstateDT.Rows.Count - 1]["key"] = key;
    //                        viewstateDT.Rows[viewstateDT.Rows.Count - 1]["display_key"] = display_key;
    //                        viewstateDT.Rows[viewstateDT.Rows.Count - 1]["permissions"] = (int)Constants.Classifiers.Permissions_View;
    //                        viewstateDT.AcceptChanges();

    //                        ViewState[mEfectivePermVS] = viewstateDT;
    //                        UpdateEfectivePermissionsGroupListBox();
    //                    }
    //                    else
    //                    {
    //                        Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Error, "Error Updating record!", "Unable to updating permissions. Try again later."); 
    //                    }
    //                }
    //            } 
    //        }                   
    //    }
    //    else
    //    {
    //        Response.Redirect(Utils.GetApplicationPath(Request) + "/AccessDenied.aspx");
    //    }
    //}

    //protected void moveToRightButton_Click(object sender, ImageClickEventArgs e)
    //{
    //    bool allowHere = Utils.PermissionAllowed(mCurrentModule, Security.Domains.Administration.Name, Constants.Classifiers.Permissions_Edit);
    //    if (allowHere)
    //    {
    //        if (aviableModulesDDL.SelectedValue != null && aviableDomaninsListBox.SelectedValue != null && groupsListBox.SelectedValue != null)
    //        {
    //            DataTable viewstateDT = GetPermissionsTableFromViewState();

    //            if (viewstateDT != null && viewstateDT.Rows.Count > 0)
    //            {
    //                string moduleID = aviableModulesDDL.SelectedValue;
    //                string domainID = aviableDomaninsListBox.SelectedValue;
    //                string roleID = groupsListBox.SelectedValue;
    //                string display_key = moduleID + "~" + roleID + "~" + domainID;

    //                for (int i = 0; i < viewstateDT.Rows.Count; i++)
    //                {
    //                    if (viewstateDT.Rows[i]["display_key"].ToString().Equals(display_key))
    //                    {
    //                        if (Utils.ModuleSecurity().DeletePermissions(moduleID, roleID, domainID))
    //                        {
    //                            viewstateDT.Rows[i].Delete();
    //                        }
    //                        else
    //                        {
    //                            Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Error, "Error Deleting record!", "Unable to detele permissions. Try again later."); 
    //                        }
    //                    }
    //                }

    //                viewstateDT.AcceptChanges();
    //                ViewState[mEfectivePermVS] = viewstateDT;
    //                UpdateEfectivePermissionsGroupListBox();                    
    //            }
    //        }
    //    }
    //    else
    //    {
    //        Response.Redirect(Utils.GetApplicationPath(Request) + "/AccessDenied.aspx");
    //    }
    //}

    //protected void moveAllToRightButton_Click(object sender, ImageClickEventArgs e)
    //{
    //    bool allowHere = Utils.PermissionAllowed(mCurrentModule, Security.Domains.Administration.Name, Constants.Classifiers.Permissions_Edit);
    //    if (allowHere)
    //    {
    //        DataTable viewstateDT = GetPermissionsTableFromViewState();

    //        if (viewstateDT != null && viewstateDT.Rows.Count > 0)
    //        {
    //            for (int i = 0; i < viewstateDT.Rows.Count; i++)
    //            {
    //                string moduleID = viewstateDT.Rows[i]["module_id"].ToString();
    //                string roleID = viewstateDT.Rows[i]["role_id"].ToString();
    //                string domainID = viewstateDT.Rows[i]["domain_id"].ToString();

    //                if (Utils.ModuleSecurity().DeletePermissions(moduleID, roleID, domainID))
    //                {
    //                    viewstateDT.Rows[i].Delete();
    //                }
    //                else
    //                {
    //                    Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Error, "Error Deleting record!", "Unable to detele permissions. Try again later."); 
    //                }
    //            }

    //            viewstateDT.AcceptChanges();
    //            ViewState[mEfectivePermVS] = viewstateDT;
    //            UpdateEfectivePermissionsGroupListBox();
    //        }
    //    }
    //    else
    //    {
    //        Response.Redirect(Utils.GetApplicationPath(Request) + "/AccessDenied.aspx");
    //    }
    //}

    //protected void moveAllToLeftButton_Click(object sender, ImageClickEventArgs e)
    //{
    //    bool allowHere = Utils.PermissionAllowed(mCurrentModule, Security.Domains.Administration.Name, Constants.Classifiers.Permissions_Edit);
    //    if (allowHere)
    //    {
    //        if (aviableModulesDDL.SelectedValue != null && aviableDomaninsListBox.SelectedValue != null && groupsListBox.SelectedValue != null)
    //        {
    //            DataTable viewstateDT = GetPermissionsTableFromViewState();

    //            if (viewstateDT != null)
    //            {
    //                string moduleID = aviableModulesDDL.SelectedValue;
    //                string roleID = groupsListBox.SelectedValue;

    //                for (int d = 0; d < aviableDomaninsListBox.Items.Count; d++)
    //                {
    //                    string domainID = aviableDomaninsListBox.Items[d].Value;
    //                    string display_key = moduleID + "~" + roleID + "~" + domainID;
    //                    string key = moduleID + "~" + roleID + "~" + domainID + "~" + (int)Constants.Classifiers.Permissions_View;

    //                    bool foundKey = false;

    //                    for (int i = 0; i < viewstateDT.Rows.Count; i++)
    //                    {
    //                        if (viewstateDT.Rows[i]["display_key"].ToString().Equals(display_key))
    //                        {
    //                            foundKey = true;
    //                        }
    //                    }

    //                    if (!foundKey)
    //                    {
    //                        if (Utils.ModuleSecurity().UpdatePermissions(moduleID, roleID, domainID, (int)Constants.Classifiers.Permissions_View))
    //                        {
    //                            viewstateDT.Rows.Add();
    //                            viewstateDT.Rows[viewstateDT.Rows.Count - 1]["module_id"] = moduleID;
    //                            viewstateDT.Rows[viewstateDT.Rows.Count - 1]["role_id"] = roleID;
    //                            viewstateDT.Rows[viewstateDT.Rows.Count - 1]["domain_id"] = domainID;
    //                            viewstateDT.Rows[viewstateDT.Rows.Count - 1]["key"] = key;
    //                            viewstateDT.Rows[viewstateDT.Rows.Count - 1]["display_key"] = display_key;
    //                            viewstateDT.Rows[viewstateDT.Rows.Count - 1]["permissions"] = (int)Constants.Classifiers.Permissions_View;
    //                            viewstateDT.AcceptChanges();
    //                        }
    //                        else
    //                        {
    //                            Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Error, "Error Updating record!", "Unable to updating permissions. Try again later."); 
    //                        }                          
    //                    }
    //                }

    //                ViewState[mEfectivePermVS] = viewstateDT;
    //                UpdateEfectivePermissionsGroupListBox();
    //            }
    //        }
    //    }
    //    else
    //    {
    //        Response.Redirect(Utils.GetApplicationPath(Request) + "/AccessDenied.aspx");
    //    }
    //}

    //#endregion EfectivePermissions Manipulation
    
    //#region Users Region

    //protected void FillUsersGridView()
    //{
    //    DataTable usersDT = Utils.ModuleSecurity().UsersList();
    //    usersGridView.DataSource = usersDT;
    //    usersGridView.DataBind();
    //}

    //protected void refreshUsersGridButton_Click(object sender, EventArgs e)
    //{
    //    FillUsersGridView();
    //    userDetailsPanel.Visible = false;
    //}

    //protected void usersGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    usersGridView.PageIndex = e.NewPageIndex;
    //    FillUsersGridView();
    //    userDetailsPanel.Visible = false;
    //}

    //protected void usersGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    int index = e.RowIndex;

    //    try
    //    {
    //        int userID = 0;
    //        int.TryParse(usersGridView.Rows[index].Cells[0].Text, out userID);

    //        if (Utils.ModuleSecurity().DeleteUser(userID))
    //        {
    //            FillUsersGridView();
    //            userDetailsPanel.Visible = false;
    //        }
    //        else
    //        {
    //            Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Warning, "Atentie", "Utilizatorul nu a fost sters. Incercati mai tirziu."); 
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Error, "Eroare in System!", ex.Message); 
    //    }        
    //}

    //protected void usersGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
    //        e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

    //        for (int i = 0; i < e.Row.Cells.Count - 1; i++)
    //        {
    //            e.Row.Cells[i].Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.usersGridView, "Select$" + e.Row.RowIndex);
    //        }
    //    }
    //}

    //protected void usersGridView_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    userDetailsPanel.Visible = true;

    //    try
    //    {
    //        ClearUserForm();

    //        if (usersGridView.SelectedRow != null)
    //        {
    //            int userID = 0;

    //            GridViewRow row = usersGridView.SelectedRow;
    //            userDetails_ResetPasswordCheckBox.Checked = false;
    //            userDetails_Password_RequiredFieldValidator.Enabled = false;

    //            userDetailsActionHiddenField.Value = Crypt.Module.CreateEncodedString(Constants.UserOperation.Edit);
    //            userDetailsUserIDHiddenField.Value = row.Cells[0].Text;

    //            int.TryParse(userDetailsUserIDHiddenField.Value, out userID);

    //            userDetails_Nume_TextBox.Text = row.Cells[1].Text;
    //            userDetails_Prenume_TextBox.Text = row.Cells[2].Text;
    //            userDetails_Login_TextBox.Text = row.Cells[3].Text;
    //            userDetails_Email_TextBox.Text = row.Cells[4].Text;

    //            DataTable userGroups = Utils.ModuleSecurity().GetUserGroupsList(userID);

    //            if (userGroups != null)
    //            {
    //                for (int i = 0; i < userGroups.Rows.Count; i++)
    //                {
    //                    string groupID = userGroups.Rows[i]["role_id"].ToString();

    //                    for (int item = 0; item < userDetails_GoupsListBox.Items.Count; item++)
    //                    {
    //                        if (groupID.Equals(userDetails_GoupsListBox.Items[item].Value))
    //                        {
    //                            userDetails_GoupsListBox.Items[item].Selected = true;
    //                            item = userDetails_GoupsListBox.Items.Count;
    //                        }
    //                    }
    //                }
    //            }

    //            userDetails_PasswordStatusDDL.SelectedValue = row.Cells[5].Text;
    //            userDetails_RecordStatusDDL.SelectedValue = row.Cells[7].Text;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Error, "Error in System!", ex.Message); 
    //    }
    //}    

    //protected void ClearUserForm()
    //{
    //    userDetailsUserIDHiddenField.Value = string.Empty;
    //    userDetails_Nume_TextBox.Text = string.Empty;
    //    userDetails_Prenume_TextBox.Text = string.Empty;
    //    userDetails_Login_TextBox.Text = string.Empty;
    //    userDetails_Password_TextBox.Text = string.Empty;
    //    userDetails_RepeatPassword_TextBox.Text = string.Empty;
    //    userDetails_Email_TextBox.Text = string.Empty;

    //    for (int i = 0; i < userDetails_GoupsListBox.Items.Count; i++)
    //    {
    //        userDetails_GoupsListBox.Items[i].Selected = false;
    //    }

    //    userDetails_PasswordStatusDDL.SelectedIndex = 0;
    //    userDetails_RecordStatusDDL.SelectedIndex = 0;
    //}

    //protected void FillComboBoxesInUserForm()
    //{
    //    DataTable systemRoleType = Utils.ModuleSecurity().GetGroupsList();
    //    userDetails_GoupsListBox.DataSource = systemRoleType;
    //    userDetails_GoupsListBox.DataTextField = "role_id";
    //    userDetails_GoupsListBox.DataValueField = "role_id";
    //    userDetails_GoupsListBox.DataBind();

    //    DataTable passwordStatus = Utils.ModuleMain().GetClassifierByTypeID((int)Constants.ClassifierTypes.PasswordStatus);
    //    Utils.FillSelector(userDetails_PasswordStatusDDL, passwordStatus, "Name", "Code");

    //    DataTable recordStatus = Utils.ModuleMain().GetClassifierByTypeID((int)Constants.ClassifierTypes.SystemUserRecordStatus);
    //    Utils.FillSelector(userDetails_RecordStatusDDL, recordStatus, "Name", "Code");

    //}
    
    //protected void userDetails_SaveButton_Click(object sender, EventArgs e)
    //{
    //    bool allowHere = Utils.PermissionAllowed(mCurrentModule, Security.Domains.Administration.Name, Constants.Classifiers.Permissions_Edit);
    //    if (allowHere)
    //    {
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
    //}

    //protected void newUsersButton_Click(object sender, EventArgs e)
    //{
    //    ClearUserForm();
    //    userDetailsPanel.Visible = true;
    //    userDetails_ResetPasswordCheckBox.Checked = true;
    //    userDetails_Password_RequiredFieldValidator.Enabled = true;
    //    userDetailsActionHiddenField.Value = Crypt.Module.CreateEncodedString(Constants.UserOperation.New);
    //}

    //protected void userDetails_CancelButton_Click(object sender, EventArgs e)
    //{
    //    ClearUserForm();
    //    userDetailsPanel.Visible = false;
    //}

    //protected void userDetails_ResetPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
    //{
    //    userDetails_Password_RequiredFieldValidator.Enabled = userDetails_ResetPasswordCheckBox.Checked;
    //}

    //#endregion Users Region


    
}