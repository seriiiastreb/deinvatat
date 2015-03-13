<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" Runat="Server">
<div class="grid_5 prefix_5">
    <div class="box">
	    <h2>
		    <a href="#" id="toggle-login-forms">Login Forms</a>
	    </h2>
	    <div class="block" id="login-forms">
			<fieldset class="login">
				<legend>Login</legend>
				<p class="notice">Login to complete your action.</p>
				<p>
					<label>Username: </label>
                    <asp:TextBox ID="userNameTextBox" runat="server" ></asp:TextBox>
				</p>
				<p>
					<label>Password: </label>
                    <asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password"></asp:TextBox>
				</p>
                <asp:Button ID="loginButton" runat="server" Text="Login"  class="login button" onclick="loginButton_Click" />
			</fieldset>
	    </div>
    </div>
</div>
</asp:Content>

