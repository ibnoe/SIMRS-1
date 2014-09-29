<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="Backoffice_Users_Add" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="adminheading" id="Table3">
		<tr>
			<th class="menudottedline">
				<%= Resources.GetString("","TitleAddUser") %></th>
			<td class="menudottedline" align="right">&nbsp;
			</td>
		</tr>
	</table>
	<table class="adminform" id="Table1" border="0">
		<tr>
			<td colspan="2">
				<asp:Label id="lblError" runat="server" ForeColor="Red"></asp:Label></td>
		</tr>
		<tr>
			<td class="text">Nama Lengkap</td>
			<td>
				<asp:TextBox id="txtName" runat="server" MaxLength="50"></asp:TextBox>
				<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtName"></asp:RequiredFieldValidator>
			</td>
		</tr>
		<tr>
			<td class="text">Username</td>
			<td>
				<asp:TextBox id="txtUserName" runat="server" MaxLength="50"></asp:TextBox>
				<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtUserName"></asp:RequiredFieldValidator></td>
		</tr>
		<tr>
			<td class="text">Password</td>
			<td>
				<asp:TextBox id="txtPassword" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
				<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtPassword"></asp:RequiredFieldValidator></td>
		</tr>
		<tr>
			<td class="text">Verifikasi Password</td>
			<td>
				<asp:TextBox id="txtVerifyPassword" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
				<asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtVerifyPassword"></asp:RequiredFieldValidator>
				<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="Password harus sama" ControlToValidate="txtVerifyPassword"
					ControlToCompare="txtPassword"></asp:CompareValidator></td>
		</tr>
		<tr>
			<td class="text">Group</td>
			<td>
				<asp:DropDownList id="cmbGroup" runat="server"></asp:DropDownList>
				<asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="cmbGroup"></asp:RequiredFieldValidator></td>
		</tr>
	</table>
	<table class="adminheading" id="Table2">
		<tr>
			<td width="150px" class="menudottedline" align="left">
				&nbsp;</td>
			<td width="50" class="menudottedline" align="left">
				<div class="toolbar" onmouseover="MM_swapImage('save','','../../images/save_f2.gif',1);"
					onmouseout="MM_swapImgRestore();">
					<asp:linkbutton id="btnSave" OnClick="OnSave" runat="server"></asp:linkbutton></div>
			</td>
			<td width="50" class="menudottedline" align="left">
				<div class="toolbar" onmouseover="MM_swapImage('cancel','','../../images/cancel_f2.gif',1);"
					onmouseout="MM_swapImgRestore();"><asp:linkbutton id="btnCancel" OnClick="OnCancel" runat="server" CausesValidation="False"></asp:linkbutton></div>
			</td>
			<td class="menudottedline">&nbsp;</td>
		</tr>
	</table>
</asp:Content>

