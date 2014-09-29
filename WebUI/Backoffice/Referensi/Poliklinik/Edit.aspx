<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Backoffice_Referensi_Poliklinik_Edit" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="adminheading" id="Table3">
		<tr>
			<th class="menudottedline">
				<%= Resources.GetString("Referensi","TitleEditPoliklinik") %>
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
			<td class="text">Kode<asp:TextBox id="txtId" runat="server" MaxLength="2" Width="8px" ReadOnly="True" Visible="False"></asp:TextBox></td>
			<td>
				<asp:TextBox id="txtKode" runat="server" MaxLength="50" Width="350px"></asp:TextBox>&nbsp;
				<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtKode">*</asp:RequiredFieldValidator></td>
		</tr>
		<tr>
			<td class="text">Nama</td>
			<td>
				<asp:TextBox id="txtNama" runat="server" MaxLength="50" Width="350px"></asp:TextBox>&nbsp;
				<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtNama">*</asp:RequiredFieldValidator></td>
		</tr>
		<tr>
			<td class="text">Jenis Poliklinik</td>
			<td>
                <asp:DropDownList ID="cmbJenisPoliklinik" runat="server">
                </asp:DropDownList></td>
		</tr>
		<tr>
			<td class="text">Kelompok</td>
			<td>
                <asp:DropDownList ID="cmbKelompokPoliklinik" runat="server">
                </asp:DropDownList></td>
		</tr>
		<tr>
			<td class="text">Keterangan</td>
			<td>
				<asp:TextBox id="txtKeterangan" runat="server" Width="350px" MaxLength="50" TextMode="MultiLine"></asp:TextBox></td>
		</tr>
		<tr>
			<td class="text">Aktif</td>
			<td>
				<asp:RadioButton id="rbtYes" runat="server" GroupName="Published" Text="Ya"></asp:RadioButton>
				<asp:RadioButton id="rbtNo" runat="server" GroupName="Published" Text="Tidak"></asp:RadioButton></td>
		</tr>
		<tr>
			<td class="text">Urutan</td>
			<td>
				<asp:DropDownList id="cmbOrdering" runat="server"></asp:DropDownList></td>
		</tr>
	</table>
	<table class="adminheading" id="Table2">
		<tr>
			<td style="width:150px" class="menudottedline">&nbsp;</td>
			<td class="menudottedline" align="left">
			    <asp:ImageButton ID="btnSave" ImageUrl="~/images/save_f2.gif" OnClick="OnSave" runat="server" />
				<asp:ImageButton ID="btnCancel" ImageUrl="~/images/cancel_f2.gif" OnClick="OnCancel" runat="server" CausesValidation="False" />
			</td>
		</tr>
	</table>
</asp:Content>

