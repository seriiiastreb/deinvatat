<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SystemSeqAdmin.aspx.cs" Inherits="SystemSeqAdmin" EnableEventValidation="false" %>
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

        function ExperimentGrid(gridID, selctedIndex) {

            var grid = document.getElementById(gridID);
            var rows = grid.getElementsByTagName("tr");

            for (i = 1; i < rows.length; i++) {

                if (i = selctedIndex) {
                    rows[i].setAttribute("class", "selectedRow");
                }
                else {
                    if (2 % 2 == 0) {
                        rows[i].setAttribute("class", "odd");
                    }
                    else {
                        rows[i].removeAttribute("class");
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
        <asp:GridView ID="ExperimentGrid" runat="server"
            AlternatingRowStyle-CssClass="odd"
            AutoGenerateColumns="true" 
            onrowdatabound="ExperimentGrid_RowDataBound"
            AllowPaging="false"  
            SelectedRowStyle-CssClass = "selectedRow"
            onselectedindexchanged = "ExperimentGrid_Select">
        </asp:GridView>

     </div>


</asp:Content>

