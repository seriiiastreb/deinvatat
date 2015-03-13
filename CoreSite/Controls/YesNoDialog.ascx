<%@ Control Language="C#" AutoEventWireup="true" CodeFile="YesNoDialog.ascx.cs" Inherits="YesNoDialog" %>

<input id="btnShowModalDiv" runat="server" CausesValidation="false"/>

<div id="divDialogPopup" class="divFilterPopup" runat="server">       
          
    <div class="filterWindowHeader">            
        <div id="titleDIV" runat="server" style="text-align:center; text-transform:uppercase;"><b><asp:Label ID="WindowTitleLabel" runat="server" Text="Are you sure?"></asp:Label></b></div>
        <a id="btnClosePopup" class="FilterModalClose" onclick="$('#<%= divDialogPopup.ClientID %>').hideModal(); return false;" ></a>
    </div>
    <div id="dialogWindowBodyDiv" runat="server" class="filterWindowBodyDiv">

    </div>
    <div class="filterWindowFooter" style="height: 20px; padding-top: 8px; padding-bottom: 0px;" >
        <div style="text-align:center; margin:auto;">
            <asp:Button ID="yesButton" runat="server" Text="YES" CausesValidation="false" Width="90px" Height="22px" onclick="yesButton_Click"/>
             &nbsp;&nbsp; 
            <asp:Button ID="noButton" runat="server" Text="No" CausesValidation="false" Width="90px" Height="22px" onclick="noButton_Click"/>
             &nbsp;&nbsp;
            <asp:Button ID="closeButton" runat="server" Text="Cancel" CausesValidation="false"  Width="90px" Height="22px" />
        </div>    
    </div>
</div>

