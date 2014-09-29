<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="Backoffice_Referensi_Spesialis_Add" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="adminheading" id="Table3">
		<tr>
			<th class="menudottedline">
				<%= Resources.GetString("Referensi","TitleAddSpesialis") %>
			</th>
			<td class="menudottedline" align="right">&nbsp;
			</td>
		</tr>
	</table>
	<table class="adminform" id="Table1" border="0">
		<tr>
			<td colspan="2">
				<asp:Label id="lblError" runat="server" ForeColor="Red"></asp:Label>
				<asp:ValidationSummary id="ValidationSummary1" runat="server" DisplayMode="SingleParagraph" HeaderText="Tanda * harus diisi atau dipilih!"></asp:ValidationSummary></td>
		</tr>
		<tr>
			<td class="text">Kode
				<asp:TextBox id="txtId" runat="server" MaxLength="50" Width="8px" ReadOnly="True" Visible="False"></asp:TextBox></td>
			<td><input id="txtKode" style="width: 349px; height: 22px; text-align: left"
					type="text" maxlength="50" name="txtKode" runat="server" />&nbsp;
				<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtKode">*</asp:RequiredFieldValidator></td>
		</tr>
		<tr>
			<td class="text">Nama</td>
			<td>
				<asp:TextBox id="txtNama" runat="server" MaxLength="50" Width="350px"></asp:TextBox>&nbsp;
				<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtNama">*</asp:RequiredFieldValidator></td>
		</tr>
		<tr>
			<td class="text">Keterangan</td>
			<td>
				<asp:TextBox id="txtKeterangan" runat="server" Width="350px" MaxLength="50" TextMode="MultiLine"></asp:TextBox></td>
		</tr>
		<tr>
			<td class="text">Aktif</td>
			<td>
				<asp:RadioButton id="rbtYes" runat="server" GroupName="Published" Text="Ya" Checked="True"></asp:RadioButton>
				<asp:RadioButton id="rbtNo" runat="server" GroupName="Published" Text="Tidak"></asp:RadioButton></td>
		</tr>
	</table>
	<table class="adminheading" id="Table2">
		<tr>
			<td width="150px" class="menudottedline" align="left">
				&nbsp;</td>
			<td width="50" class="menudottedline" align="left">
				<div class="toolbar" onmouseover="MM_swapImage('save','','../../../images/save_f2.gif',1);"
					onmouseout="MM_swapImgRestore();">
					<asp:linkbutton id="btnSave" OnClick="OnSave" runat="server"></asp:linkbutton></div>
			</td>
			<td width="50" class="menudottedline" align="left">
				<div class="toolbar" onmouseover="MM_swapImage('cancel','','../../../images/cancel_f2.gif',1);"
					onmouseout="MM_swapImgRestore();"><asp:linkbutton id="btnCancel" OnClick="OnCancel" runat="server" CausesValidation="False"></asp:linkbutton></div>
			</td>
			<td class="menudottedline">&nbsp;</td>
		</tr>
	</table>
</asp:Content>

