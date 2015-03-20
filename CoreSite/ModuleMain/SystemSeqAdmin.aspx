<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SystemSeqAdmin.aspx.cs" Inherits="SystemSeqAdmin" %>
<%@ Register TagPrefix="ajax" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" Runat="Server">   

    <script language="javascript">
        $(function () {
            $.contextMenu({
                selector: '.context-menu-one',
                callback: function (key, options) {
                    doPost("usersGridClik", key);
                },
                items: {
                    "add": { name: "Add", icon: "add", className: 'resetMarginLeft' },
                    "edit": { name: "Edit", icon: "edit", className: 'resetMarginLeft' },
                    //"cut": { name: "Cut", icon: "cut", className: 'resetMarginLeft' },
                    //"copy": { name: "Copy", icon: "copy", className: 'resetMarginLeft' },
                    //"paste": { name: "Paste", icon: "paste", className: 'resetMarginLeft' },
                    "delete": { name: "Delete", icon: "delete", className: 'resetMarginLeft' }
                    //,
                    //   "sep1": "---------",
                    //  "quit": { name: "Quit", icon: "quit", className: 'resetMarginLeft' }
                }
            });

            $('.context-menu-one').on('click', function (e) {
                console.log('clicked', this);
            })           
        });

        function SetSelection(gridID, selctedIndex, selectValHidID) {

            var hiddField = document.getElementById(selectValHidID);
            var grid = document.getElementById(gridID);
            var rows = grid.getElementsByTagName("tbody")[0].getElementsByTagName("tr");


            for (var i = 0; i < rows.length; i++) {

                if (i == selctedIndex) {
                    rows[i].setAttribute("class", "selectedRow");
                    hiddField.value = selctedIndex;
                }
                else {
                    if (i % 2 == 0) {
                        rows[i].removeAttribute("class");
                    }
                    else {
                        rows[i].setAttribute("class", "odd");                        
                    }
                }         
            }
        }

    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" Runat="Server">  

    <div class="grid_3 box">
		<h2>
			System Management
		</h2>
		<div class="block" id="list-items">
			<p>Here you can add/edit users and groups in system. And you can change permissions of them.</p>
			<h5>Users and Grousp</h5>
			<ul class="menu">
				<li>
					<a href="#">Users</a>
				</li>
				<li>
					<a href="#">Groups</a>
				</li>
				<li>
					<a href="#">Domains</a>
				</li>
			</ul>
        </div>
    </div>

     <div class="grid_8 box context-menu-one">
        <h2>
		    My Table
	    </h2>

        <asp:HiddenField ID="ExperimentGrid_Selection_HiddenValue" runat="server" />

        <asp:GridView ID="ExperimentGrid" runat="server"
            AlternatingRowStyle-CssClass="odd"
            AutoGenerateColumns="true" 
            onrowdatabound="ExperimentGrid_RowDataBound"
            AllowPaging="false"  
            SelectedRowStyle-CssClass = "selectedRow">
        </asp:GridView>
     </div>

     <div style="clear:both;"></div>

    <asp:HyperLink ID="addUserHyperLink" runat="server" Style=" display:none;"></asp:HyperLink>

    <ajax:ModalPopupExtender ID="addUserPopupExtender" runat="server"     
        TargetControlID="addUserHyperLink"
        PopupControlID = "AddUserPanel" 
        PopupDragHandleControlID="addUserHeader"
        CancelControlID="addUser_CancelButton"
        DropShadow="true" >
    </ajax:ModalPopupExtender>   

    <asp:Panel runat="server" ID="AddUserPanel" CssClass="grid_5 box" style="display:none; width: auto">
        <fieldset>
			<legend style="cursor:move;" runat="server" id="addUserHeader">New User</legend>
			<p>
				<label>First Name: </label>
                <asp:TextBox ID="addUser_Nume_TextBox" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" EnableClientScript="true" Display="None" ControlToValidate="addUser_Nume_TextBox" ErrorMessage="This field is mandatory."> </asp:RequiredFieldValidator>
                <ajax:ValidatorCalloutExtender 
                    runat="Server"
                    ID="PNReqE"                     
                    TargetControlID="RequiredFieldValidator" 
                    Width="250px"
                    PopupPosition="Right" />
			</p>
            <p>
				<label>Last Name: </label>
				<asp:TextBox ID="addUser_Prenume_TextBox" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" EnableClientScript="true" Display="None" ControlToValidate="addUser_Prenume_TextBox" ErrorMessage="This field is mandatory."> </asp:RequiredFieldValidator>
                <ajax:ValidatorCalloutExtender 
                    runat="Server"
                    ID="ValidatorCalloutExtender1"
                    TargetControlID="RequiredFieldValidator2" 
                    Width="250px"
                    PopupPosition="Right" />
			</p>

			<p>
				<label>Login: </label>
				<asp:TextBox ID="addUser_Login_TextBox" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" EnableClientScript="true" Display="None" ControlToValidate="addUser_Login_TextBox" ErrorMessage="This field is mandatory."> </asp:RequiredFieldValidator>
                <ajax:ValidatorCalloutExtender 
                    runat="Server"
                    ID="ValidatorCalloutExtender2"
                    TargetControlID="RequiredFieldValidator3" 
                    Width="250px"
                    PopupPosition="Right" />
			</p>

			<p>
				<label>Email: </label>
                <asp:TextBox ID="addUser_Email_TextBox" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" EnableClientScript="true" Display="None" ControlToValidate="addUser_Email_TextBox"  ErrorMessage="This field is mandatory."> </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ID="valEmailPattern" Display="None" ControlToValidate="addUser_Email_TextBox" ErrorMessage="The email is not well formed." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <ajax:ValidatorCalloutExtender 
                    runat="Server"
                    ID="ValidatorCalloutExtender3"
                    TargetControlID="RequiredFieldValidator4" 
                    Width="250px"
                    PopupPosition="Right" />
                <ajax:ValidatorCalloutExtender 
                    runat="Server"
                    ID="ValidatorCalloutExtender6"
                    TargetControlID="valEmailPattern" 
                    Width="250px"
                    PopupPosition="Right" />
			</p>

            <p>
				<label>Password: </label>
                <asp:TextBox ID="addUser_Password_TextBox" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="addUser_Password_RequiredFieldValidator" runat="server" EnableClientScript="true" Display="None" ControlToValidate="addUser_Password_TextBox" ErrorMessage="Acest cimp este obligatoriu"> </asp:RequiredFieldValidator>
                <ajax:ValidatorCalloutExtender 
                    runat="Server"
                    ID="ValidatorCalloutExtender4"
                    TargetControlID="addUser_Password_RequiredFieldValidator" 
                    Width="250px"
                    PopupPosition="Right" />
			</p>

			<p>
				<label>Repeat Password: </label>
                <asp:TextBox ID="addUser_RepeatPassword_TextBox" runat="server" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator id="comparePasswords" 
                    runat="server"
                    ControlToCompare="addUser_RepeatPassword_TextBox"
                    ControlToValidate="addUser_Password_TextBox"
                    ErrorMessage="Attention! Passwords do not match."
                    Display="None" />

                    <ajax:ValidatorCalloutExtender 
                    runat="Server"
                    ID="ValidatorCalloutExtender5"
                    TargetControlID="comparePasswords" 
                    Width="250px"
                    PopupPosition="Right" />
			</p>
            <p>
				<label>Password Status: </label>
                <asp:DropDownList ID="userDetails_PasswordStatusDDL" runat="server" ></asp:DropDownList>
			</p>

	        <p>
				<label>Record Status: </label>
                <asp:DropDownList ID="userDetails_RecordStatusDDL" runat="server"  ></asp:DropDownList>
			</p>

            <asp:Button ID="addUser_SaveButton" CssClass="register-button" runat="server" Text="Save" Width="100px" onclick="addUser_SaveButton_Click"  />
            <asp:Button ID="addUser_CancelButton" runat="server" Text="Cancel" Width="100px" CausesValidation="false" />                   
              
		</fieldset>    
    </asp:Panel>



</asp:Content>

