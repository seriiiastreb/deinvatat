using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class YesNoDialog : System.Web.UI.UserControl
{
    Unit mWidth = 350;

    Unit mSelectButtonWidth = 16;
    Unit mSelectButtonHeight = 16;
    string mTitleWindow = "Selection Dialog Box";
    string mSelectButtonBackGroundImageURL = "Please Select";
    string mToolTip = string.Empty;
    string mConfirmQuestion = string.Empty;

    public Unit Width
    {
        get { return mWidth; }
        set { mWidth = value; }
    }

    public string SelectButtonBackGroundImageURL
    {
        get { return mSelectButtonBackGroundImageURL; }
        set { mSelectButtonBackGroundImageURL = value; }
    }

    public string ToolTip
    {
        get { return mToolTip; }
        set { mToolTip = value; }
    }

    public string ConfirmQuestion
    {
        get { return mConfirmQuestion; }
        set { mConfirmQuestion = value; }
    }

    public Unit SelectButtonWidth
    {
        get { return mSelectButtonWidth; }
        set { mSelectButtonWidth = value; }
    }

    public Unit SelectButtonHeight
    {
        get { return mSelectButtonHeight; }
        set { mSelectButtonHeight = value; }
    }

    public string TitleWindow
    {
        get { return mTitleWindow; }
        set { mTitleWindow = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        divDialogPopup.Style.Value = "width: " + (int)mWidth.Value + "px; ";
        btnShowModalDiv.Attributes["class"] = "roundedButton";
        btnShowModalDiv.Attributes["type"] = "image";
        btnShowModalDiv.Attributes["alt"] = mToolTip;
        btnShowModalDiv.Attributes["src"] = mSelectButtonBackGroundImageURL;
        btnShowModalDiv.Attributes["align"] = "absmiddle";
        string borderStyle = " border-width: 1px; border-style: Solid; ";     

        btnShowModalDiv.Style.Value = "width: " + (int)mSelectButtonWidth.Value + "px; height: " + (int)mSelectButtonHeight.Value + "px; " + borderStyle;
        btnShowModalDiv.Attributes.Add("onclick", "$('#" + divDialogPopup.ClientID + "').showModal(); return false; ");

		WindowTitleLabel.Text = mTitleWindow;
        dialogWindowBodyDiv.InnerText = mConfirmQuestion;

        closeButton.Attributes["onClick"] = "$('#" + divDialogPopup.ClientID + "').hideModal(); return false;";
    }
    
    protected void yesButton_Click(object sender, EventArgs e)
    {
        if (ResponseSelected != null)
        {
            YesNoDialogEventsArg args = new YesNoDialogEventsArg(Constants.ConfirmationDialogResponseType.Yes);
            ResponseSelected(this, args);
        }
    }

    protected void noButton_Click(object sender, EventArgs e)
    {
        if (ResponseSelected != null)
        {
            YesNoDialogEventsArg args = new YesNoDialogEventsArg(Constants.ConfirmationDialogResponseType.No);
            ResponseSelected(this, args);
        }
    }

    public class YesNoDialogEventsArg : EventArgs
    {
        private int selectedItems;
        public int SelectedItems
        {
            get { return selectedItems; }
        }

        public YesNoDialogEventsArg(int response)
        {
            selectedItems = response;
        }
    }

    public event CustomItemEventHandler ResponseSelected;

    public delegate void CustomItemEventHandler(object sender, YesNoDialog.YesNoDialogEventsArg e);
}