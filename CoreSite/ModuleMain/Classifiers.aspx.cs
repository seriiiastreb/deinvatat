using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;

public partial class Classifiers : System.Web.UI.Page
{
    private readonly string mCurrentModule = Security.MainModule.ID;
    private readonly string mPageName = "System Sequrity Administration";
    private readonly string mEfectivePermVS = "EfectivePermissions";

    private string appPath = string.Empty;

    private void ShowClassifierTypesPanels(string panelName)
    {
        #region Hide panels
        classifiersGeneraPanel.Visible = false;

        classifierTypesPanel.Visible = false;
        editClassifierTypePanel.Visible = false;
        addNewClassifierTypePanel.Visible = false;

        #endregion Hide panels

        try
        {
            #region Get Panel Name

            switch (panelName)
            {
                case "classifierTypesPanel":
                    classifiersGeneraPanel.Visible = true;
                    classifierTypesPanel.Visible = true;
                    FillClasifiersTypesGridView();
                    break;

                case "addNewClassifierTypePanel":
                    classifiersGeneraPanel.Visible = true;
                    addNewClassifierTypePanel.Visible = true;                    
                    break;

                case "editClassifierTypePanel":
                    classifiersGeneraPanel.Visible = true;
                    editClassifierTypePanel.Visible = true;
                    break;

                default:
                    break;
            }

            #endregion Get Panel Name
        }
        catch (Exception ex)
        {
            Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Error, "Attention! Error in system!", ex.Message);
        }
    }

    private void ShowClassifierPanels(string panelName)
    {
        #region Hide panels

        classifiersPanel.Visible = false;
        addNewClassifierPanel.Visible = false;
        editClassifierPanel.Visible = false;

        #endregion Hide panels

        try
        {
            #region Get Panel Name

            switch (panelName)
            {
                case "classifiersPanel":
                    classifiersPanel.Visible = true;

                    FillClassifiersGrid();
                    break;

                case "addNewClassifierPanel":
                    addNewClassifierPanel.Visible = true;

                    break;

                case "editClassifierPanel":
                    editClassifierPanel.Visible = true;

                    break;
               
                default:
                    
                    break;
            }

            #endregion Get Panel Name
        }
        catch (Exception ex)
        {
            Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Error, "Attention! Error in system!", ex.Message);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        appPath = Utils.GetApplicationPath(Request);
        Utils.GetMaster(this).PerformPreloadActions(mCurrentModule, mPageName);

        bool allowHere = Utils.PermissionAllowed(mCurrentModule, Security.Domains.BasicProgramAdministration.Name, Constants.Classifiers.Permissions_View);
        if (allowHere)
        {
            /////////  aply security policy
            bool allowEdit = Utils.PermissionAllowed(mCurrentModule, Security.Domains.BasicProgramAdministration.Name, Constants.Classifiers.Permissions_Edit);

            newClassifierTypeButton.Visible = allowEdit;
            addNewClassifierTypeSaveButton.Visible = allowEdit;
            editClassifierTypeSaveButton.Visible = allowEdit;
            classifiersNewClassifierButton.Visible = allowEdit;
            addNewClassifierSaveButton.Visible = allowEdit;
            editClassifierSaveButton.Visible = allowEdit;

            if (allowEdit)
            {
                classifierTypesGridView.Columns[2].Visible = true;
                classifierTypesGridView.Columns[3].Visible = true;
                classifiersPanelGridView.Columns[4].Visible = true;
                classifiersPanelGridView.Columns[5].Visible = true;
            }
            else
            {
                classifierTypesGridView.Columns[2].Visible = false;
                classifierTypesGridView.Columns[3].Visible = false;
                classifiersPanelGridView.Columns[4].Visible = false;
                classifiersPanelGridView.Columns[5].Visible = false;
            }
            ///////////////////////////

            if (!IsPostBack)
            {
                ShowClassifierTypesPanels(classifierTypesPanel.ID);
                ShowClassifierPanels(classifiersPanel.ID);
            }    
        }
        else
        {
            Response.Redirect(Utils.GetApplicationPath(Request) + "/AccessDenied.aspx");
        }  
    }
    
    #region Classifier Types

    protected void classifierTypesGridView_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

            for (int i = 0; i < e.Row.Cells.Count - 2; i++)
            {
                e.Row.Cells[i].Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.classifierTypesGridView, "Select$" + e.Row.RowIndex);
            }
        }
    }

    protected void classifierTypesGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (classifierTypesGridView.SelectedRow != null)
        {
            GridViewRow row = classifierTypesGridView.SelectedRow;
            selectedClassifierTypeIDHiddenField.Value = row.Cells[0].Text;
            curentClassifierTypeSelectedLabel.Text = row.Cells[1].Text;
        }

        ShowClassifierPanels(classifiersPanel.ID);
        FillClassifiersGrid();
    }
    
    private void FillClasifiersTypesGridView()
    {
        DataTable classifiersTypesDT = Utils.ModuleMain().GetClassifierTypesList();
        classifierTypesGridView.DataSource = classifiersTypesDT;
        classifierTypesGridView.DataBind();
    }

    protected void refreshClassifirsTypesButton_Click(object sender, EventArgs e)
    {
        FillClasifiersTypesGridView();
    }

    protected void newClassifierTypeButton_Click(object sender, EventArgs e)
    {
        addNewClassifierTypeTextBox.Text = string.Empty;
        ShowClassifierTypesPanels(addNewClassifierTypePanel.ID);
    }

    protected void addNewClassifierTypeCancelButton_Click(object sender, EventArgs e)
    {
        addNewClassifierTypeTextBox.Text = string.Empty;
        ShowClassifierTypesPanels(classifierTypesPanel.ID);
    }

    protected void addNewClassifierTypeSaveButton_Click(object sender, EventArgs e)
    {
        bool allowHere = Utils.PermissionAllowed(mCurrentModule, Security.Domains.BasicProgramAdministration.Name, Constants.Classifiers.Permissions_Edit);
        if (allowHere)
        {
            try
            {
                string denumirea = addNewClassifierTypeTextBox.Text;

                if (Utils.ModuleMain().NewClassifierTypes(denumirea))
                {
                    addNewClassifierTypeTextBox.Text = string.Empty;
                    ShowClassifierTypesPanels(classifierTypesPanel.ID);
                }
                else
                {
                    Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Warning, "Attention!", "The type { " + denumirea + " } was not saved. Try again later.");
                }
            }
            catch (Exception ex)
            {
                Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Error, "Attention! Error in system!", ex.Message);
            }
        }
        else
        {
            Response.Redirect(Utils.GetApplicationPath(Request) + "/AccessDenied.aspx");
        }        
    }

    protected void classifierTypesGridView_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        int index = e.NewEditIndex;

        typeIDLabel.Text = classifierTypesGridView.Rows[index].Cells[0].Text;
        editClassifierTypeDenumireaTextBox.Text = classifierTypesGridView.Rows[index].Cells[1].Text;

        ShowClassifierTypesPanels(editClassifierTypePanel.ID);
    }

    protected void editClassifierTypeSaveButton_Click(object sender, EventArgs e)
    {
        bool allowHere = Utils.PermissionAllowed(mCurrentModule, Security.Domains.BasicProgramAdministration.Name, Constants.Classifiers.Permissions_Edit);
        if (allowHere)
        {
            try
            {
                string strTypeID = typeIDLabel.Text;
                int typeID = 0;
                int.TryParse(strTypeID, out typeID);

                string denumirea = editClassifierTypeDenumireaTextBox.Text;

                if (Utils.ModuleMain().UpdateClassifierTypes(typeID, denumirea))
                {
                    addNewClassifierTypeTextBox.Text = string.Empty;
                    ShowClassifierTypesPanels(classifierTypesPanel.ID);
                }
                else
                {
                    Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Warning, "Attention!", "The type { " + denumirea + " } was not saved. Try again later.");
                }
            }
            catch (Exception ex)
            { Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Error, "Attention! Error in system!", ex.Message); }
        }
        else
        {
            Response.Redirect(Utils.GetApplicationPath(Request) + "/AccessDenied.aspx");
        }         
    }

    protected void classifierTypesGridView_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        bool allowHere = Utils.PermissionAllowed(mCurrentModule, Security.Domains.BasicProgramAdministration.Name, Constants.Classifiers.Permissions_Edit);
        if (allowHere)
        {
            int index = e.RowIndex;

            try
            {
                string strTypeID = classifierTypesGridView.Rows[index].Cells[0].Text;
                int typeID = 0;
                int.TryParse(strTypeID, out typeID);

                if (Utils.ModuleMain().DeleteClassifierType(typeID))
                {
                    ShowClassifierTypesPanels(classifierTypesPanel.ID);
                }
                else
                {
                    Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Warning, "Attention!", "The classifier type was not deleted. Try again later.");
                }
            }
            catch (Exception ex)
            { Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Error, "Attention! Error in system!", ex.Message); }
        }
        else
        {
            Response.Redirect(Utils.GetApplicationPath(Request) + "/AccessDenied.aspx");
        }         
    }

    protected void editClassifierTypeCancelButton_Click(object sender, EventArgs e)
    {
        addNewClassifierTypeTextBox.Text = string.Empty;
        ShowClassifierTypesPanels(classifierTypesPanel.ID);
    }

    protected void classifierTypesGridView_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        classifierTypesGridView.PageIndex = e.NewPageIndex;
        ShowClassifierTypesPanels(classifierTypesPanel.ID);
    }

    #endregion Classifier Types
    
    #region Classifiers

    private void FillClassifiersGrid()
    {
        int clTypeID = 0;
        int.TryParse(selectedClassifierTypeIDHiddenField.Value, out clTypeID);

        DataTable classifiers = Utils.ModuleMain().GetAllClassifiers(clTypeID);
        classifiersPanelGridView.DataSource = classifiers;
        classifiersPanelGridView.DataBind();
      
    }

    protected void classifiersPanelNewClassifierButton_Click(object sender, EventArgs e)
    {
        addNewClassifierNameTextBox.Text = string.Empty;
        ShowClassifierPanels(addNewClassifierPanel.ID);
    }   

    protected void addNewClassifierSaveButton_Click(object sender, EventArgs e)
    {
        bool allowHere = Utils.PermissionAllowed(mCurrentModule, Security.Domains.BasicProgramAdministration.Name, Constants.Classifiers.Permissions_Edit);
        if (allowHere)
        {
            try
            {
                int clTypeID = 0;
                int.TryParse(selectedClassifierTypeIDHiddenField.Value, out clTypeID);

                string denumirea = addNewClassifierNameTextBox.Text;
                int groupCode = 0;
                int.TryParse(addNewClassifierGroupCodeTextBox.Text, out groupCode);

                if (Utils.ModuleMain().NewClassifier(clTypeID, denumirea, groupCode))
                {
                    addNewClassifierTypeTextBox.Text = string.Empty;
                    ShowClassifierPanels(classifiersPanel.ID);
                }
                else
                {
                    Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Warning, "Attention!", "The classifier  { " + denumirea + " }  was not saved. Try again later.");
                }
            }
            catch (Exception ex)
            {
                Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Error, "Attention! Error in system!", ex.Message);
            }        
        }
        else
        {
            Response.Redirect(Utils.GetApplicationPath(Request) + "/AccessDenied.aspx");
        }         
    }

    protected void addNewClassifierCancelButton_Click(object sender, EventArgs e)
    {
        addNewClassifierNameTextBox.Text = string.Empty;
        ShowClassifierPanels(classifiersPanel.ID);
    }

    protected void classifiersPanelGridView_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        int index = e.NewEditIndex;
        ShowClassifierPanels(editClassifierPanel.ID);

        try
        {
            editClassifierCodeLabel.Text = classifiersPanelGridView.Rows[index].Cells[1].Text;
            editClassifierNameTextBox.Text = classifiersPanelGridView.Rows[index].Cells[2].Text;
            editClassifierGroupCodeTextBox.Text = (classifiersPanelGridView.Rows[index].Cells[3].Text.Equals("&nbsp;") ? string.Empty : classifiersPanelGridView.Rows[index].Cells[3].Text);           
        }
        catch (Exception ex)
        {
            Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Error, "Attention! Error in system!", ex.Message);
        }
    }

    protected void editClassifierSaveButton_Click(object sender, EventArgs e)
    {
        bool allowHere = Utils.PermissionAllowed(mCurrentModule, Security.Domains.BasicProgramAdministration.Name, Constants.Classifiers.Permissions_Edit);
        if (allowHere)
        {
            try
            {
                int clCode = 0;
                int.TryParse(editClassifierCodeLabel.Text, out clCode);

                string denumirea = editClassifierNameTextBox.Text;
                int groupCode = 0;
                int.TryParse(editClassifierGroupCodeTextBox.Text, out groupCode);

                if (Utils.ModuleMain().UpdateClassifier(clCode, denumirea, groupCode))
                {
                    editClassifierCodeLabel.Text = string.Empty;
                    ShowClassifierPanels(classifiersPanel.ID);
                }
                else
                {
                    Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Warning, "Attention!", "The classifier { " + denumirea + " }  was not saved. Try again later.");
                }
            }
            catch (Exception ex)
            {
                Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Error, "Attention! Error in system!", ex.Message);
            }        
        }
        else
        {
            Response.Redirect(Utils.GetApplicationPath(Request) + "/AccessDenied.aspx");
        } 
    }

    protected void editClassifierCancelButton_Click(object sender, EventArgs e)
    {
        editClassifierNameTextBox.Text = string.Empty;
        ShowClassifierPanels(classifiersPanel.ID);
    }
     
    protected void classifiersPanelGridView_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        bool allowHere = Utils.PermissionAllowed(mCurrentModule, Security.Domains.BasicProgramAdministration.Name, Constants.Classifiers.Permissions_Edit);
        if (allowHere)
        {
            int index = e.RowIndex;

            try
            {
                int clCode = 0;
                int.TryParse(classifiersPanelGridView.Rows[index].Cells[1].Text, out clCode);

                if (Utils.ModuleMain().DeleteClassifier(clCode))
                {
                    editClassifierCodeLabel.Text = string.Empty;
                    ShowClassifierPanels(classifiersPanel.ID);
                }
                else
                {
                    Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Warning, "Attention!", "The classifier  was not deleted. Try again later.");
                }
            }
            catch (Exception ex)
            {
                Utils.GetMaster(this).ShowMessage((int)Constants.InfoBoxMessageType.Error, "Attention! Error in system!", ex.Message);
            }        
        }
        else
        {
            Response.Redirect(Utils.GetApplicationPath(Request) + "/AccessDenied.aspx");
        }        
    }

    protected void classifiersPanelGridView_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        classifiersPanelGridView.PageIndex = e.NewPageIndex;
        ShowClassifierPanels(classifiersPanel.ID);
    }   

    #endregion Classifiers
}