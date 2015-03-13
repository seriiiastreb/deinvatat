<%@ Control Language="C#" AutoEventWireup="true" CodeFile="InfoWindow.ascx.cs" Inherits="InfoWindow" %>
<%@ Register TagPrefix="ajax" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>

<asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
<ajax:ModalPopupExtender 
    runat="server" 
    ID="programmaticModalPopup" 
    TargetControlID="hiddenTargetControlForModalPopup" 
    PopupControlID="programmaticPopup"
    DropShadow="True" 
    PopupDragHandleControlID="programmaticPopupDragHandle"
    OkControlID="infoBoxOkButton"
    RepositionMode="RepositionOnWindowScroll">
</ajax:ModalPopupExtender>

<asp:Panel runat="server" ID="programmaticPopup" Style="display: none;">

    <div runat="server" ID="programmaticPopupDragHandle" >
        <asp:Label ID="infoBoxTitleLabel" runat="server" Text=""></asp:Label>
    </div>        
    <div style="float:left; width:10px; height:100%; position:absolute;  " >
        <asp:Image ID="infoBoxImage" runat="server" Height="42px" Width="42px" style=" position:absolute;   top:0;   bottom:0;   margin:auto;"/> 
    </div>   
    <div runat="server" id="bodyMessageDiv">
        <asp:Label ID="infoBoxMessageLabel" runat="server" Text=""></asp:Label> 
    </div>   
    <div>
        <asp:Button ID="infoBoxOkButton" runat="server" Text="Ok" Width="150px" />
    </div>

</asp:Panel>