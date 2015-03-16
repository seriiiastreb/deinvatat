<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RecoveryPWD.aspx.cs" Inherits="RecoveryPWD" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">

<asp:UpdatePanel runat="server">
<ContentTemplate>

    <asp:Panel ID="emptyPanel" runat="server" visible="false">
        <div align="center">
            <h1 >Bine ati venit la DINAR-CAPITAL</h1>
        </div>        
    </asp:Panel>

    <asp:Panel ID="resetPasswordStep1Panel" runat="server" visible="false">
    <div class="centred_box" >
            <div class="form"> 
                <fieldset class="login">
			        <legend>Resetarea parolei</legend>
			        <p class="notice">Introduceti va rog datele indicate la inregistrare</p>
			        <p>
				        <label>Login: </label>
				        <asp:TextBox ID="loginTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="*" ControlToValidate="loginTextBox"></asp:RequiredFieldValidator>
			        </p>
			        <p>
				        <label>Email: </label>
				        <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="emailTextBox"></asp:RequiredFieldValidator>
			        </p>
                    <p>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ErrorMessage="Email incorect!" ControlToValidate="emailTextBox" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            <br />
                        <asp:CustomValidator
                            ID="resetPasswordStep1CustomValidator" runat="server" 
                            ErrorMessage="Acesta combinatie login-email nu a fost găsita în baza de date! Verificați va rog!" 
                            OnServerValidate="ServerValidation" 
                            ControlToValidate="emailTextBox"></asp:CustomValidator> 
                    </p>                    
                        <asp:Button ID="resetPasswordStep1_OkButton" runat="server" CssClass="centred_box_Button" Text="OK" onclick="resetPasswordStep1_OkButton_Click" />
                    
		        </fieldset>
            </div>
        </div>
    </asp:Panel>

    <asp:Panel ID="resetPasswordStep2Panel" runat="server" visible="false">
        <div class="centred_box">            
			<h2>PAROLA ESTE SHIMBATA</h2>
			<div class="block">
				<p>
                    Pe Email-ul indicat a fost transmisă parola nouă. Verificați emailul dvs și logați-vă folosind parola primită.
                </p>
                <p> 
                    IMPORTANT: După logare este recomandat sa schimbați parola!
                </p>
			</div>			
        </div>
    </asp:Panel>


</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>

