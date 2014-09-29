<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="Backoffice_Referensi_SatuanKerja_Add" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="adminheading" id="Table3">
		<tr>
			<th class="menudottedline">
				<%= Resources.GetString("Referensi","TitleAddSatuanKerja") %>
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
				<asp:TextBox id="txtIdSatuanKerja" runat="server" MaxLength="50" Width="8px" ReadOnly="True" Visible="False"></asp:TextBox></td>
			<td><input id="txtKode" style="WIDTH: 349px; HEIGHT: 22px; TEXT-ALIGN: left"
					type="text" maxlength="50" name="txtKode" runat="server" />&nbsp;
				<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtKode">*</asp:RequiredFieldValidator></td>
		</tr>
		<tr>
			<td class="text">Nama</td>
			<td>
				<asp:TextBox id="txtNamaSatker" runat="server" MaxLength="50" Width="350px"></asp:TextBox>&nbsp;
				<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtNamaSatker">*</asp:RequiredFieldValidator></td>
		</tr>
		<tr>
			<td class="text">Keterangan</td>
			<td>
				<asp:TextBox id="txtKeterangan" runat="server" Width="350px" MaxLength="50" TextMode="MultiLine"></asp:TextBox></td>
		</tr>
	</table>
	<table class="adminheading" id="Table2">
		<tr>
			<td class="text"></td>
			<td>
                <asp:ImageButton ID="btnSave" AlternateText='<%= Resources.GetString("", "Save") %>' ImageUrl="~/images/save_f2.gif" OnClick="OnSave" runat="server" />
				<asp:ImageButton ID="btnCancel" AlternateText='<%= Resources.GetString("", "Cancel") %>' ImageUrl="~/images/cancel_f2.gif" OnClick="OnCancel" runat="server" CausesValidation="False" />
			</td>
		</tr>
	</table>
</asp:Content>

