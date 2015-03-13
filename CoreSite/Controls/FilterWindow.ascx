<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FilterWindow.ascx.cs" Inherits="FilterWindow" %>

<input id="btnShowModalDiv" runat="server" CausesValidation="false"/>

<div id="divFilterPopup" class="divFilterPopup" runat="server">   
    
    <% Response.Write(this.AllowSorting ? 
        @"<script type=""text/javascript"">
        function initSort" + this.ClientID + @"() {
            var Table" + this.ClientID + @"Sorter = new TSorter; 
            Table" + this.ClientID + @"Sorter.init('" + filterGridView.ClientID + @"');
            }

        $(document).ready(function () {
           initSort" + this.ClientID + @"(); ;
        });
            
    </script>" : String.Empty);
    %>
           
    <div class="filterWindowHeader">            
        <div id="titleDIV" runat="server" style="text-align:center; text-transform:uppercase;"><b><asp:Label ID="WindowTitleLabel" runat="server" Text="Select"></asp:Label></b></div>
        <a id="btnClosePopup" class="FilterModalClose" onclick="$('#<%= divFilterPopup.ClientID %>').hideModal(); return false;" ></a>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Search:"></asp:Label>
            <asp:TextBox runat="server" ID="txtSearch" ></asp:TextBox>              
        </div>
    </div>
    <div id="filterWindowBodyDiv" runat="server" class="filterWindowBodyDiv">
        <asp:GridView ID="filterGridView" runat="server" 
            AutoGenerateColumns="False"  
            GridLines="None"  
            AllowPaging="false"  
            CssClass="mGrid"  
            AlternatingRowStyle-CssClass="alt" 
            SelectedRowStyle-CssClass = "selectedRow" 
            Width="100%" > 
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10px" >
                    <ItemTemplate>
                        <asp:CheckBox ID="checkBoxID" runat="server" onclick="<%# this.AllowMultiSelection ? string.Empty : this.AllowMultiSelJSLink %>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField  HtmlEncode="False" ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Size="Medium"   />
                <asp:BoundField  HtmlEncode="False" ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Size="Medium"   />
                <asp:BoundField  HtmlEncode="False" ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Size="Medium"   />
            </Columns>       
                                                       
        </asp:GridView>
    </div>
    <div class="filterWindowFooter">
        <div style="float:left; margin-top:2px;">
            &nbsp;<asp:CheckBox ID="selectAllCheckBox" runat="server" Text="Select ALL" /> 
        </div>
        <div style="text-align:right; float:right;">
            <asp:HiddenField ID="filterControlSelectedValuesHiddenF" runat="server" />
            <asp:HiddenField ID="filterControlSelectedNamesValuesHiddenF" runat="server" />
            <asp:ImageButton ID="okButton" runat="server"  AlternateText="OK" OnClick="okButton_Click" CssClass="roundedButton" BorderWidth="1px" BorderStyle="Solid" ImageAlign="Bottom" Width="24px" ToolTip="OK" ImageUrl="../Images/ok.png"  CausesValidation="false" />
            <asp:ImageButton ID="closeButton" runat="server"  AlternateText="Close" CssClass="roundedButton" BorderWidth="1px" BorderStyle="Solid" ImageAlign="Bottom" Width="24px" ToolTip="Close" ImageUrl="../Images/cancel.png"  CausesValidation="false"  />                    
        </div>    
    </div>
</div>

