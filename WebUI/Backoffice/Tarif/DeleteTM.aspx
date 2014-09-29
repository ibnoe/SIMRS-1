<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="DeleteTM.aspx.cs" Inherits="Backoffice_Tarif_DeleteTM" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" language="javascript" src="../../js/inputFormatNo.js"></script>
    <table class="adminheading" id="Table3">
		<tr>
			<th class="menudottedline">
				Hapus Data Layanan & Tarif Tindakan Medis
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
			<td class="text">Kelompok:</td>
			<td>
                <asp:Label ID="lblKelompokLayanan" runat="server" Text=""></asp:Label>
                </td>
		</tr>
		<tr>
            <td class="text">
                Kode:<asp:TextBox id="txtId" runat="server" MaxLength="2" Width="8px" ReadOnly="True" Visible="False"></asp:TextBox></td>
            <td>
                <asp:Label ID="lblKode" runat="server" Text=""></asp:Label>
                </td>
        </tr>
		<tr>
			<td class="text">Nama Layanan:</td>
			<td>
				<asp:Label ID="lblNama" runat="server" Text=""></asp:Label>
                </td>
		</tr>
        <tr>
            <td class="text">
                Kelas III:</td>
            <td>
                <asp:Label ID="lblTarifIII" runat="server" Text=""></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="text">
                Kelas II:</td>
            <td>
                <asp:Label ID="lblTarifII" runat="server" Text=""></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="text">
                Kelas I:</td>
            <td>
                <asp:Label ID="lblTarifI" runat="server" Text=""></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="text">
                Kelas VIP:</td>
            <td>
                <asp:Label ID="lblTarifV" runat="server" Text=""></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="text">
                Kelas VVIP:</td>
            <td>
                <asp:Label ID="lblTarifVV" runat="server" Text=""></asp:Label>
                </td>
        </tr>
		<tr>
			<td class="text">Keterangan:</td>
			<td>
				<asp:Label ID="lblKeterangan" runat="server" Text=""></asp:Label>
                </td>
		</tr>
	</table>
	<table class="adminheading" id="Table2">
		<tr>
			<td width="150px" class="menudottedline">
				&nbsp;</td>
			<td width="50px" class="menudottedline" align="left">
				<asp:ImageButton OnClientClick="if(confirm('Apakah Anda yakin akan menghapus data ini !')) {return true}else{return false}" ID="btnDelete"  ImageUrl="~/images/delete_f2.gif" OnClick="OnDelete" runat="server" />
			</td>
			<td width="50" class="menudottedline" align="left">
				<asp:ImageButton ID="btnCancel"  ImageUrl="~/images/cancel_f2.gif" OnClick="OnCancel" runat="server" CausesValidation="False" />
			</td>
			<td class="menudottedline">&nbsp;</td>
		</tr>
	</table>
</asp:Content>

