<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SystemSeqAdmin.aspx.cs" Inherits="SystemSeqAdmin" EnableEventValidation="false" %>
<%@ Register TagPrefix="ajax" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" Runat="Server">   

    <script language="javascript">
        $(function () {
            $.contextMenu({
                selector: '.context-menu-one',
                callback: function (key, options) {
                    var m = "clicked: " + key;
                    window.console && console.log(m) || alert(m);
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
    
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" Runat="Server">  

    <div style="width:92%; padding:20px;">
        <div style="float:left; width:200px; border:1px solid black; height:300px;">
            <div class="box">
		        <h2>
			        <a href="#" id="toggle-list-items">System Management</a>
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


          <%--  <asp:TreeView runat="server" ID="categoryesTreeView"  Width="100%" Height="100%"   ShowLines="true" CssClass="Menu" onselectednodechanged="categoryesTreeView_SelectedNodeChanged" >
                <Nodes>
                    <asp:TreeNode Value="0" Text="Users and Grousp" Expanded="True"> 
                        <asp:TreeNode Value="01" Text="Users" Expanded="True"></asp:TreeNode>
                        <asp:TreeNode Value="02" Text="Groups" Expanded="True"></asp:TreeNode>
                        <asp:TreeNode Value="03" Text="Domains" Expanded="True"></asp:TreeNode>
                    </asp:TreeNode>

                </Nodes>
                <SelectedNodeStyle BackColor="#B7E9E7" />
            </asp:TreeView>--%>
        </div>
        <div style="float:left; width:auto; height:300px; ">
           <div class="context-menu-one box menu-1">
                <strong>right click me</strong>
            </div>
        </div>
    </div>
</asp:Content>

