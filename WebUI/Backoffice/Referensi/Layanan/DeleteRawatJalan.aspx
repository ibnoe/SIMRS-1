<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="DeleteRawatJalan.aspx.cs" Inherits="Backoffice_Referensi_Layanan_DeleteRawatJalan" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" language="javascript" src="../../../js/inputFormatNo.js"></script>
    <table class="adminheading" id="Table3">
		<tr>
			<th class="menudottedline">
				<%= Resources.GetString("Referensi","TitleDeleteLayanan") %>
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
			<td class="text">Jenis Layanan</td>
			<td>
                <asp:Label ID="lblJenisLayanan" runat="server" Text="Label"></asp:Label>
                </td>
		</tr>
		<tr>
			<td class="text">Polikinik</td>
			<td>
                <asp:Label ID="lblPolikinik" runat="server" Text="Label"></asp:Label>
                </td>
		</tr>
		<tr>
			<td class="text">Kelompok</td>
			<td>
                <asp:Label ID="lblKelompok" runat="server" Text="Label"></asp:Label>
                </td>
		</tr>
		<tr>
			<td class="text">Kode<asp:TextBox id="txtId" runat="server" MaxLength="2" Width="8px" ReadOnly="True" Visible="False"></asp:TextBox></td>
			<td>
                <asp:Label ID="lblKode" runat="server" Text="Label"></asp:Label>
                </td>
		</tr>
		<tr>
			<td class="text">Nama</td>
			<td>
                <asp:Label ID="lblNama" runat="server" Text="Label"></asp:Label>
                </td>
		</tr>
		<tr>
			<td class="text">Satuan</td>
			<td>
                <asp:Label ID="lblSatuan" runat="server" Text="Label"></asp:Label>
                </td>
		</tr>
		<tr>
			<td class="text">Tarif</td>
			<td>
                <asp:Label ID="lblTarif" runat="server" Text=""></asp:Label>
                </td>
		</tr>
		<tr>
			<td class="text">Keterangan</td>
			<td>
                <asp:Label ID="lblKeterangan" runat="server" Text=""></asp:Label>
                </td>
		</tr>
		<tr>
			<td class="text">Aktif</td>
			<td>
                <asp:Label ID="lblPublished" runat="server" Text=""></asp:Label>
                </td>
		</tr>
		<tr>
			<td class="text"></td>
			<td>
                <asp:ImageButton ID="btnDelete" OnClientClick="return confirm('Apakah anda yakin akan menghapus data ini ?');" OnClick="OnDelete" runat="server" ImageUrl="~/images/delete_f2.gif" />
			    <asp:ImageButton ID="btnCancel" OnClick="OnCancel" runat="server" CausesValidation="False" ImageUrl="~/images/cancel_f2.gif" />
			</td>
		</tr>
	</table>
</asp:Content>

