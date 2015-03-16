<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Classifiers.aspx.cs" Inherits="Classifiers" EnableEventValidation="false" %>

<asp:Content ID="ClassifiersContnet" ContentPlaceHolderID="MainContent" Runat="Server">

<asp:Panel ID="classifiersGeneraPanel" runat="server" Visible="false">
    <div class="leftColumn">
        <div class="module">
            <div class="moduleHeader">Lista Tipurilor de Classificatoare</div>                    
                
            <div class="module_content">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Button ID="refreshClassifirsTypesButton" runat="server" Text="Refresh" Width="100px"  onclick="refreshClassifirsTypesButton_Click">  </asp:Button>
                                   
                        <asp:Panel ID="classifierTypesPanel" runat="server" Visible="False">
                            <asp:Button ID="newClassifierTypeButton" runat="server" Text="Adauga un nou Tip Clasificator" Width="230px"  onclick="newClassifierTypeButton_Click"> </asp:Button>
                            <hr />
                            <asp:GridView ID="classifierTypesGridView" runat="server" 
                                    AutoGenerateColumns="False"
                                    CssClass="mGrid"
                                    PagerStyle-CssClass="pgr"
                                    AlternatingRowStyle-CssClass="alt"
                                    AllowPaging="True" 
                                    onrowediting="classifierTypesGridView_RowEditing" 
                                    onpageindexchanging="classifierTypesGridView_PageIndexChanging" 
                                    onrowdeleting="classifierTypesGridView_RowDeleting" 
                                    onselectedindexchanged="classifierTypesGridView_SelectedIndexChanged" 
                                    onrowdatabound="classifierTypesGridView_RowDataBound"  >
                                <Columns>
                                    <asp:BoundField DataField="Type ID"  HeaderText="Type ID"  HeaderStyle-CssClass="HiddenColumn" ItemStyle-CssClass="HiddenColumn" HtmlEncode="False" />
                                    <asp:BoundField DataField="Name"          HeaderText="Name"             HtmlEncode="False" />
                                    <asp:ButtonField ButtonType="Button" CommandName="Edit" Text="Edit" />
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                                <asp:Button ID="deleteButton" runat="server" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Sure you want to delete?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>                                
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>

                        <asp:Panel ID="addNewClassifierTypePanel" runat="server" Visible="False" >
                            <div class="module">
                                <div class="moduleHeader">Noul tip de clasificator</div>   
                                <div class="module_content">   
                                    <p>                         
                                        <label> Denumire: </label>
                                        <asp:TextBox ID="addNewClassifierTypeTextBox" runat="server"></asp:TextBox>
                                    </p>
                                    <asp:Button ID="addNewClassifierTypeSaveButton"  runat="server" Text="Save" onclick="addNewClassifierTypeSaveButton_Click"   />
                                    <asp:Button ID="addNewClassifierTypeCancelButton" runat="server" Text="Cancel"  onclick="addNewClassifierTypeCancelButton_Click"  />    
                                </div>                        
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="editClassifierTypePanel" runat="server" Visible="False">
                            <div class="module">  
                                <div class="moduleHeader">Editare tip clasificator</div>
                                <div class="module_content">
                                    <p class="HiddenColumn">
                                        <label> ID: </label>
                                        <asp:Label ID="typeIDLabel" runat="server" Text="Classifier type ID: "  ></asp:Label>
                                    </p>                               
                                
                                    <p>
                                        <label> Denumire: </label>
                                        <asp:TextBox ID="editClassifierTypeDenumireaTextBox" runat="server" ></asp:TextBox>
                                    </p>  
                                    
                                    <asp:Button ID="editClassifierTypeSaveButton" runat="server" Text="Save" onclick="editClassifierTypeSaveButton_Click"  />
                                    <asp:Button ID="editClassifierTypeCancelButton" runat="server" Text="Cancel" onclick="editClassifierTypeCancelButton_Click"  />                                 
                                </div>
                                                         
                            </div>
                        </asp:Panel>
                    
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="classifierTypesGridView" EventName="PageIndexChanging" />
                        <asp:AsyncPostBackTrigger ControlID="classifierTypesGridView" EventName="RowEditing" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>          

    <div class="rightColumn">        
        <div class="module">  
            <div class="moduleHeader">Lista Classificatoarelor</div> 
            <div class="module_content">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="label" runat="server" Text="Tipul curent selectat: "></asp:Label>
                        <asp:Label ID="curentClassifierTypeSelectedLabel" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Large"></asp:Label>   

                            <asp:Panel ID="classifiersPanel" runat="server" Visible="False">
                                <asp:Button ID="classifiersNewClassifierButton" runat="server" Text="Adauga Noul Classificator" Width="230px" onclick="classifiersPanelNewClassifierButton_Click"/>
                                <br />
                                <hr />
                                <asp:HiddenField ID="selectedClassifierTypeIDHiddenField" runat="server" />
                                <asp:GridView ID="classifiersPanelGridView" runat="server" 
                                    EnableModelValidation="True" 
                                    AutoGenerateColumns="False" 
                                    CssClass="mGrid"
                                    PagerStyle-CssClass="pgr"
                                    AlternatingRowStyle-CssClass="alt"
                                    AllowPaging="True"         
                                    PageSize="10" onrowediting="classifiersPanelGridView_RowEditing" 
                                    onpageindexchanging="classifiersPanelGridView_PageIndexChanging" 
                                    onrowdeleting="classifiersPanelGridView_RowDeleting"  >
                                    <Columns>
                                        <asp:BoundField DataField="Type ID"     HeaderText="Type ID"          HtmlEncode="False"  HeaderStyle-CssClass="HiddenColumn" ItemStyle-CssClass = "HiddenColumn"  />
                                        <asp:BoundField DataField="Code"        HeaderText="Code"             HtmlEncode="False"  HeaderStyle-CssClass="HiddenColumn" ItemStyle-CssClass = "HiddenColumn" />
                                        <asp:BoundField DataField="Name"        HeaderText="Name"             HtmlEncode="False" />
                                        <asp:BoundField DataField="GroupCode"   HeaderText="Group Code"       HtmlEncode="False" />
                                        <asp:ButtonField ButtonType="Button" CommandName="Edit" Text="Edit" />
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                    <asp:Button ID="deleteButton" runat="server" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Sunteti sigur ca vreti sa stergeti?');" />
                                            </ItemTemplate>
                                        </asp:TemplateField>  
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>

                            <asp:Panel ID="addNewClassifierPanel" runat="server" Visible="False">
                                <div class="module">
                                    <div class="moduleHeader">Adauga clasificator nou</div>
                                    <div class="module_content">
                                        <p>
                                            <label> Descrirerea: </label>
                                            <asp:TextBox ID="addNewClassifierNameTextBox" runat="server"></asp:TextBox>
                                        </p> 
                                
                                        <p> 
                                            <label> Group Code: </label>
                                            <asp:TextBox ID="addNewClassifierGroupCodeTextBox" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="addNewClassifierGroupCodeTextBox" ErrorMessage="Please Enter Only Numbers" ValidationExpression="^\d+$" ValidationGroup="number"></asp:RegularExpressionValidator>                                 
                                        </p>
                                        <asp:Button ID="addNewClassifierSaveButton" runat="server" Text="Save" onclick="addNewClassifierSaveButton_Click"  />
                                        <asp:Button ID="addNewClassifierCancelButton" runat="server" Text="Cancel" onclick="addNewClassifierCancelButton_Click" /> 
                                    </div>                                  
                                </div>
                            </asp:Panel>

                            <asp:Panel ID="editClassifierPanel" runat="server" Visible="False">
                                <div class="module">
                                    <div class="moduleHeader">Editare clasificator</div>
                                    <div class="module_content">                                       
                                        <p class="HiddenColumn">
                                            <label> Codul clasificatorului: </label>
                                            <asp:Label ID="editClassifierCodeLabel" runat="server" Text="Classifier type ID: " ></asp:Label>
                                        </p>
                                
                                        <p>
                                            <label>  Descrirerea: </label>
                                            <asp:TextBox ID="editClassifierNameTextBox" runat="server" ></asp:TextBox>
                                        </p>
                                
                                        <p>
                                            <label> Group Code: </label>
                                            <asp:TextBox ID="editClassifierGroupCodeTextBox" runat="server" ></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="editClassifierGroupCodeTextBox" ErrorMessage="Please Enter Only Numbers" ValidationExpression="^\d+$" ValidationGroup="number"></asp:RegularExpressionValidator>  
                                        </p>   
                                                                    
                                        <asp:Button ID="editClassifierSaveButton" runat="server" Text="Save" onclick="editClassifierSaveButton_Click"  />
                                        <asp:Button ID="editClassifierCancelButton" runat="server" Text="Cancel" onclick="editClassifierCancelButton_Click"  />     
                                    </div>                              
                                </div>
                            </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="classifierTypesGridView" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel> 
            </div>
        </div>
    </div>

    <div class="clear"></div> 
</asp:Panel>

</asp:Content>



