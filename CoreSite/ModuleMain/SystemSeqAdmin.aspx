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

    <div style="width:92%; padding:20px; float: left;">
        <div style="float:left; width:200px; border:1px solid black; ">
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

        </div>
        <%--<div style="float:left; width: 700px; padding-left: 15px;">
           <div class="context-menu-one" style="border:1px solid black; ">                
                <div class="box">
	                <h2>
		                <a href="#" id="toggle-tables" style="cursor: pointer;" class="hidden">Tables</a>
	                </h2>
	                <div style="margin: 0px; position: static; overflow: hidden;">
		                <div class="block" id="tables" style="margin: 0px;">
			                <table>
				                <tbody>
					                <tr>
						                <th>Lorem ipsum</th>
						                <td>Dolor sit</td>
						                <td class="currency">$125.00</td>
					                </tr>
					                <tr>
						                <th>Dolor sit</th>
						                <td>Nostrud exerci</td>
						                <td class="currency">$75.00</td>
					                </tr>
					                <tr>
						                <th>Nostrud exerci</th>
						                <td>Lorem ipsum</td>
						                <td class="currency">$200.00</td>
					                </tr>
					                <tr>
						                <th>Lorem ipsum</th>
						                <td>Dolor sit</td>
						                <td class="currency">$64.00</td>
					                </tr>
					                <tr>
						                <th>Dolor sit</th>
						                <td>Nostrud exerci</td>
						                <td class="currency">$36.00</td>
					                </tr>
				                </tbody>
			                </table>		
		                </div>
	                </div>
                </div>


            </div>
        </div>--%>

        <div style="clear:both;"></div>
                <br />        
        <div class="box">
	        <h2>
		        <a href="#" id="A1" style="cursor: pointer;" class="hidden">My Table</a>
	        </h2>
           <%-- <asp:GridView ID="ExperimentGrid" runat="server"
                AutoGenerateColumns="true">
            </asp:GridView>--%>
        </div>
                <div style="clear:both;"></div>
    </div>
</asp:Content>

