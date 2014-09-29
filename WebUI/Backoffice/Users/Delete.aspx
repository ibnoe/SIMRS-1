<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="Delete.aspx.cs" Inherits="Backoffice_Users_Delete" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="adminheading" id="Table3">
		<tr>
			<th class="menudottedline">
				<%= Resources.GetString("","TitleDeleteUser") %></th>
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
				<asp:Label id="lblNamaLengkap" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td class="text">Username</td>
			<td>
				<asp:Label id="lblUserName" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td class="text">Group</td>
			<td>
				<asp:Label id="lblGroupName" runat="server"></asp:Label></td>
		</tr>
	</table>
	<table class="adminheading" id="Table2">
		<tr>
			<td width="150" class="menudottedline">
				&nbsp;</td>
			<td width="50" class="menudottedline" align="left">
				<div class="toolbar" onmouseover="MM_swapImage('save','','../../images/save_f2.gif',1);"
					onmouseout="MM_swapImgRestore();">
					<asp:linkbutton id="btnDelete" OnClick="OnDelete" runat="server"></asp:linkbutton></div>
			</td>
			<td width="50" class="menudottedline" align="left">
				<div class="toolbar" onmouseover="MM_swapImage('cancel','','../../images/cancel_f2.gif',1);"
					onmouseout="MM_swapImgRestore();"><asp:linkbutton id="btnCancel" OnClick="OnCancel" runat="server" CausesValidation="False"></asp:linkbutton></div>
			</td>
			<td class="menudottedline">&nbsp;</td>
		</tr>
	</table>
</asp:Content>

