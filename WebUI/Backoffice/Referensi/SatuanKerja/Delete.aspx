<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="Delete.aspx.cs" Inherits="Backoffice_Referensi_SatuanKerja_Delete" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="adminheading" id="Table3">
		<tr>
			<th class="menudottedline">
				<%= Resources.GetString("Referensi","TitleDeleteSatuanKerja") %>
			</th>
			<td class="menudottedline" align="right">&nbsp;
			</td>
		</tr>
	</table>
	<table class="adminform" id="Table1" border="0">
		<tr>
			<td colspan="2"></td>
		</tr>
		<tr>
			<td class="text">Kode
				<asp:TextBox id="txtIdSatuanKerja" runat="server" MaxLength="2" Width="8px" ReadOnly="True" Visible="False"></asp:TextBox></td>
			<td>
				<asp:Label id="lblKode" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td class="text">Nama</td>
			<td>
				<asp:Label id="lblNamaSatker" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td class="text">Keterangan</td>
			<td>
				<asp:Label id="lblKeterangan" runat="server"></asp:Label></td>
		</tr>
	</table>
	<table class="adminheading">
		<tr>
			<td class="text"></td>
			<td>
                <asp:ImageButton OnClientClick="if(confirm('Apakah Anda yakin akan menghapus data ini !')) {return true}else{return false}" ID="btnDelete"  ImageUrl="~/images/delete_f2.gif" OnClick="OnDelete" runat="server" />
				<asp:ImageButton ID="btnCancel"  ImageUrl="~/images/cancel_f2.gif" OnClick="OnCancel" runat="server" CausesValidation="False" />
			</td>
		</tr>
	</table>
</asp:Content>

