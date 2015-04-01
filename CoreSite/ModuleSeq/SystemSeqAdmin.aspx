<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SystemSeqAdmin.aspx.cs" Inherits="SystemSeqAdmin" %>
<%@ Register TagPrefix="ajax" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>


<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" Runat="Server">   

    <script language="javascript">

        $(function () {
            $.contextMenu({
                selector: '.context-menu-one',
                trigger: 'none',
                callback: function (key, options) {
                    doPost("usersGridClik", key);
                },
                items: {
                    "add": { name: "Add", icon: "add", className: 'resetMarginLeft' },
                    "edit": { name: "Edit", icon: "edit", className: 'resetMarginLeft' },
                    "reset": { name: "Reset PWD", icon: "reset", className: 'resetMarginLeft' },
                    //"cut": { name: "Cut", icon: "cut", className: 'resetMarginLeft' },
                    //"copy": { name: "Copy", icon: "copy", className: 'resetMarginLeft' },
                    //"paste": { name: "Paste", icon: "paste", className: 'resetMarginLeft' },
                    "delete": { name: "Delete", icon: "delete", className: 'resetMarginLeft' }
                    //,
                    //   "sep1": "---------",
                    //  "quit": { name: "Quit", icon: "quit", className: 'resetMarginLeft' }
                }
            });
        });


        $(function () {
            $("[id*=<%= usersGrid.ClientID %>] td").mousedown(function (e) {

                var selectedRowIndex = $(this).parent().index();
                var hiddField = document.getElementById('<%= usersGrid_Selection_HiddenValue.ClientID %>');
                hiddField.value = selectedRowIndex;

                var gridID = '<%= usersGrid.ClientID %>';
                ResetGridSelection(gridID);

                $(this).closest("tr").removeClass('odd');
                $(this).closest("tr").toggleClass("selectedRow");

                if (e.which == 3) //1: left, 2: middle, 3: right
                {
                    $(".context-menu-one").contextMenu({ x: e.pageX, y: e.pageY });
                }
            });
        });


        function ResetGridSelection(gridID) {
            var grid = document.getElementById(gridID);
            var rows = grid.getElementsByTagName("tbody")[0].getElementsByTagName("tr");

            for (var i = 0; i < rows.length; i++) {
                if (i % 2 == 0) {
                    rows[i].removeAttribute("class");   
                }
                else {
                    rows[i].setAttribute("class", "odd");
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

     <div class="grid_8 box context-menu-one" style=" min-height:300px;">
        <h2>
		    My Table
	    </h2>

        <asp:HiddenField ID="usersGrid_Selection_HiddenValue" runat="server" />

        <asp:GridView ID="usersGrid" runat="server"
            AutoGenerateColumns="false"
            AlternatingRowStyle-CssClass="odd"
            onrowdatabound="usersGrid_RowDataBound"
            AllowPaging="false"  
            SelectedRowStyle-CssClass = "selectedRow">
            <Columns>
                <asp:BoundField DataField="userid" HeaderText="User ID"  HeaderStyle-CssClass="hidden"  ItemStyle-CssClass="hidden" />
                <asp:BoundField DataField="nume" HeaderText="First Name" />
                <asp:BoundField DataField="prenume" HeaderText="Last Name" />
                <asp:BoundField DataField="login" HeaderText="Login" />
                <asp:BoundField DataField="passwordstatus" HeaderText="passwordstatus" HeaderStyle-CssClass="hidden"  ItemStyle-CssClass="hidden"  />
                <asp:BoundField DataField="passwordstatus_string" HeaderText="Password Status" />
                <asp:BoundField DataField="recordstatus" HeaderText="recordstatus" HeaderStyle-CssClass="hidden"  ItemStyle-CssClass="hidden" />
                <asp:BoundField DataField="recordstatus_string" HeaderText="Record Status" />
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:BoundField DataField="sysadmin" HeaderText="Sys Admin" />
            </Columns>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ValidationGroup="addUser" EnableClientScript="true" Display="None" ControlToValidate="addUser_Nume_TextBox" ErrorMessage="This field is mandatory."> </asp:RequiredFieldValidator>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ValidationGroup="addUser" EnableClientScript="true" Display="None" ControlToValidate="addUser_Prenume_TextBox" ErrorMessage="This field is mandatory."> </asp:RequiredFieldValidator>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  ValidationGroup="addUser" EnableClientScript="true" Display="None" ControlToValidate="addUser_Login_TextBox" ErrorMessage="This field is mandatory."> </asp:RequiredFieldValidator>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  ValidationGroup="addUser"  EnableClientScript="true" Display="None" ControlToValidate="addUser_Email_TextBox"  ErrorMessage="This field is mandatory."> </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ID="valEmailPattern" Display="None"  ValidationGroup="addUser" ControlToValidate="addUser_Email_TextBox" ErrorMessage="The email is not well formed." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
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
                <asp:RequiredFieldValidator ID="addUser_Password_RequiredFieldValidator" runat="server"  ValidationGroup="addUser" EnableClientScript="true" Display="None" ControlToValidate="addUser_Password_TextBox" ErrorMessage="Acest cimp este obligatoriu"> </asp:RequiredFieldValidator>
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
                    ValidationGroup="addUser" 
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

            <asp:Button ID="addUser_SaveButton" CssClass="register-button" runat="server" Text="Save" Width="100px"  ValidationGroup="addUser" onclick="addUser_SaveButton_Click"  />
            <asp:Button ID="addUser_CancelButton" runat="server" Text="Cancel" Width="100px" CausesValidation="false" />                   
              
		</fieldset>    
    </asp:Panel>

    <asp:HyperLink ID="resetPassHyperLink" runat="server" Style=" display:none;"></asp:HyperLink>

    <ajax:ModalPopupExtender ID="resetPassPopupExtender" runat="server"     
        TargetControlID="resetPassHyperLink"
        PopupControlID = "resetPassPanel" 
        PopupDragHandleControlID="resetPassLegend"
        CancelControlID="resetPassCancelButton"
        DropShadow="true" >
    </ajax:ModalPopupExtender>   

     <asp:Panel runat="server" ID="resetPassPanel" CssClass="grid_5 box" style="display:none; width: auto">
        <fieldset>
			<legend style="cursor:move;" runat="server" id="resetPassLegend">Reset Password</legend>			
            <p>
				<label>Password: </label>
                <asp:TextBox ID="resetPassTextBox" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="resetPassRequereValiator" runat="server" EnableClientScript="true" Display="None" ControlToValidate="resetPassTextBox" ErrorMessage="This field is mandatory."> </asp:RequiredFieldValidator>
                <ajax:ValidatorCalloutExtender 
                    runat="Server"
                    ID="ValidatorCalloutExtender12"
                    TargetControlID="resetPassRequereValiator" 
                    Width="250px"
                    PopupPosition="Right" />
			</p>

			<p>
				<label>Repeat Password: </label>
                <asp:TextBox ID="resetPass_repeatTextBox" runat="server" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator id="resetPass_CompareValidator" 
                    runat="server"
                    ControlToCompare="resetPass_repeatTextBox"
                    ControlToValidate="resetPassTextBox"
                    ErrorMessage="Attention! Passwords do not match."
                    Display="None" />

                    <ajax:ValidatorCalloutExtender 
                    runat="Server"
                    ID="ValidatorCalloutExtender13"
                    TargetControlID="resetPass_CompareValidator" 
                    Width="250px"
                    PopupPosition="Right" />
			</p>       

            <asp:Button ID="resetPassOkButton" CssClass="register-button" runat="server" Text="Save" Width="100px" onclick="resetPassOkButton_Click"  />
            <asp:Button ID="resetPassCancelButton" runat="server" Text="Cancel" Width="100px" CausesValidation="false" />                   
              
		</fieldset>    
    </asp:Panel>




    <asp:HyperLink ID="editUserHyperLink" runat="server" Style=" display:none;"></asp:HyperLink>

    <ajax:ModalPopupExtender ID="editUserPopupExtender" runat="server"     
        TargetControlID="editUserHyperLink"
        PopupControlID = "editUserPanel" 
        PopupDragHandleControlID="editUserLegend"
        CancelControlID="editUserCancelButton"
        DropShadow="true" >
    </ajax:ModalPopupExtender>   

    <asp:Panel runat="server" ID="editUserPanel" CssClass="grid_5 box" style="display:none; width: auto">
        <fieldset>
			<legend style="cursor:move;" runat="server" id="editUserLegend">Edit User</legend>
			<p>
				<label>First Name: </label>
                <asp:TextBox ID="editUserNumeTextBox" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="editUserNameRequiredFieldValidator" runat="server" EnableClientScript="true" Display="None" ControlToValidate="editUserNumeTextBox" ErrorMessage="This field is mandatory."> </asp:RequiredFieldValidator>
                <ajax:ValidatorCalloutExtender 
                    runat="Server"
                    ID="ValidatorCalloutExtender7"                     
                    TargetControlID="editUserNameRequiredFieldValidator" 
                    Width="250px"
                    PopupPosition="Right" />
			</p>

            <p>
				<label>Last Name: </label>
				<asp:TextBox ID="editUserLastNameTextBox" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="ediuUserlastNameRequiredFieldValidator" runat="server" EnableClientScript="true" Display="None" ControlToValidate="editUserLastNameTextBox" ErrorMessage="This field is mandatory."> </asp:RequiredFieldValidator>
                <ajax:ValidatorCalloutExtender 
                    runat="Server"
                    ID="ValidatorCalloutExtender8"
                    TargetControlID="ediuUserlastNameRequiredFieldValidator" 
                    Width="250px"
                    PopupPosition="Right" />
			</p>

			<p>
				<label>Login: </label>
				<asp:TextBox ID="editUserLoginTextBox" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="editUserLoginRequiredFieldValidator" runat="server" EnableClientScript="true" Display="None" ControlToValidate="editUserLoginTextBox" ErrorMessage="This field is mandatory."> </asp:RequiredFieldValidator>
                <ajax:ValidatorCalloutExtender 
                    runat="Server"
                    ID="ValidatorCalloutExtender9"
                    TargetControlID="editUserLoginRequiredFieldValidator" 
                    Width="250px"
                    PopupPosition="Right" />
			</p>

			<p>
				<label>Email: </label>
                <asp:TextBox ID="editUserEmailTextBox" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="editUserEmailRequiredFieldValidator" runat="server" EnableClientScript="true" Display="None" ControlToValidate="editUserEmailTextBox"  ErrorMessage="This field is mandatory."> </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ID="emailRegularExpressionValidator" Display="None" ControlToValidate="editUserEmailTextBox" ErrorMessage="The email is not well formed." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <ajax:ValidatorCalloutExtender 
                    runat="Server"
                    ID="ValidatorCalloutExtender10"
                    TargetControlID="editUserEmailRequiredFieldValidator" 
                    Width="250px"
                    PopupPosition="Right" />
                <ajax:ValidatorCalloutExtender 
                    runat="Server"
                    ID="ValidatorCalloutExtender11"
                    TargetControlID="emailRegularExpressionValidator" 
                    Width="250px"
                    PopupPosition="Right" />
			</p>           

            <p>
				<label>Password Status: </label>
                <asp:DropDownList ID="editUserPWDStatusDDL" runat="server" ></asp:DropDownList>
			</p>

	        <p>
				<label>Record Status: </label>
                <asp:DropDownList ID="editUserRECStatus" runat="server"  ></asp:DropDownList>
			</p>

            <asp:Button ID="editUserOkButton" CssClass="register-button" runat="server" Text="Save" Width="100px" onclick="editUserOkButton_Click"  />
            <asp:Button ID="editUserCancelButton" runat="server" Text="Cancel" Width="100px" CausesValidation="false" />                   
              
		</fieldset>    
    </asp:Panel>


    <asp:HyperLink ID="deleteUserHyperLink" runat="server" Style=" display:none;"></asp:HyperLink>

    <ajax:ModalPopupExtender ID="deleteUserModalPopupExtender" runat="server"     
        TargetControlID="deleteUserHyperLink"
        PopupControlID = "deleteUserPanel" 
        PopupDragHandleControlID="deleteUserLegend"
        CancelControlID="deleteUserCancelButton"
        DropShadow="true" >
    </ajax:ModalPopupExtender>   

    <asp:Panel runat="server" ID="deleteUserPanel" CssClass="grid_5 box" style="display:none; width: auto">
        <fieldset>
			<legend style="cursor:move;" runat="server" id="deleteUserLegend">Delete User confirmation</legend>			
            <p>
                <h3>Sure you want to delete this user from the system? After this operation he will not have access to the system.</h3>
            </p>

            <asp:Button ID="deleteUserOkButton" CssClass="register-button" runat="server" Text="Ok" Width="100px" onclick="deleteUserOkButton_Click"  />
            <asp:Button ID="deleteUserCancelButton" runat="server" Text="Cancel" Width="100px" CausesValidation="false" />                   
              
		</fieldset>    
    </asp:Panel>

</asp:Content>

