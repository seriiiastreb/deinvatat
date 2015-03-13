using System;
using System.Web.UI.WebControls;
using System.Web.UI;

public partial class InfoWindow : System.Web.UI.UserControl
{
    string mWindowTitle = string.Empty;
    string mMessage = string.Empty;
    int mMessageType = Constants.InfoBoxMessageType.Info;
    int parameterX = 0;
    int parameterY = 0;

    public string WindowTitle
    {
        set { mWindowTitle = value; }
    }

    public string Message
    {
        set { mMessage = value; }
    }

    public int MessageType
    {
        set { mMessageType = value; }
    }

    public int ParameterX
    {
        set { parameterX = value; }
    }

    public int ParameterY
    {
        set { parameterY = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {       
    }

    public void Show()
    {
        string appPath = Utils.GetApplicationPath(Request);

        infoBoxTitleLabel.Text = mWindowTitle;
        infoBoxMessageLabel.Text = mMessage;

        #region add Icon  in Dependence of MessageType

        switch (mMessageType)
        {
            case Constants.InfoBoxMessageType.Info:
                infoBoxImage.ImageUrl = appPath + "/images/infobox/info.png";
                break;

            case Constants.InfoBoxMessageType.Error:
                infoBoxImage.ImageUrl = appPath + "/images/infobox/error.png";
                break;

            case Constants.InfoBoxMessageType.Warning:
                infoBoxImage.ImageUrl = appPath + "/images/infobox/warning.png";
                break;

            case Constants.InfoBoxMessageType.Ok:
                infoBoxImage.ImageUrl = appPath + "/images/infobox/cheked.png";
                break;

            case Constants.InfoBoxMessageType.Important:
                infoBoxImage.ImageUrl = appPath + "/images/infobox/important.png";
                break;

            case Constants.InfoBoxMessageType.Question:
                infoBoxImage.ImageUrl = appPath + "/images/infobox/question.png";
                break;
        }

        #endregion add Icon  in Dependence of MessageType

        #region set Panel style in Dependence of MessageType

        string bodyStyle = "border: 1px solid Gray; margin: 5px 0px; padding:5px 5px 10px 5px; background-repeat: no-repeat; background-position: 10px center;  position: relative; width:500px; text-align: center;";
        string dragHandelStyle = "width:497px; position:absolute; cursor: move;  border: solid 1px Gray; color: Black;";

        bodyMessageDiv.Style.Value = "margin-left: 40px; margin-top:20px; padding: 10px;";

        switch (mMessageType)
        {
            case Constants.InfoBoxMessageType.Info:
                bodyStyle += " color: #00529B; background-color: #F5F7F8; ";
                dragHandelStyle += "background-color:#DFE3F3;;";
                break;

            case Constants.InfoBoxMessageType.Error:
                bodyStyle += " color: #4F8A10; background-color: #FFE8D5; ";
                dragHandelStyle += "background-color:#F14646;";
                break;

            case Constants.InfoBoxMessageType.Warning:
                bodyStyle += " color: #9F6000; background-color: #FFFDD2; ";
                dragHandelStyle += "background-color:#E9E9B5;";
                break;

            case Constants.InfoBoxMessageType.Ok:
                bodyStyle += "  color: #D8000C; background-color: #D5FCE3;  ";
                dragHandelStyle += "background-color:#50C965;";
                break;

            case Constants.InfoBoxMessageType.Important:
                bodyStyle += " color: #9F6000; background-color: #FFFDD2; ";
                dragHandelStyle += "background-color:#E9E9B5;";
                break;

            case Constants.InfoBoxMessageType.Question:
                bodyStyle += " color: #00529B; background-color: #BDE5F8; ";
                dragHandelStyle += "background-color:#788ef1;";
                break;
        }

        programmaticPopup.Style.Value = bodyStyle;
        programmaticPopupDragHandle.Style.Value = dragHandelStyle;

        #endregion  set Panel style in Dependence of MessageType

        if (parameterX != 0) programmaticModalPopup.X = parameterX;
        if (parameterY != 0) programmaticModalPopup.Y = parameterY;

        this.programmaticModalPopup.Show();
    }
}
