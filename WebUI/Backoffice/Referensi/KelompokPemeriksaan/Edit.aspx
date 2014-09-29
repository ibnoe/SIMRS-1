<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Backoffice_Referensi_KelompokPemeriksaan_Edit" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true" ></asp:ScriptManager>
<table class="adminheading" id="Table3">
	<tr>
		<th class="menudottedline">
			<%= Resources.GetString("Referensi","TitleEditKelompokPemeriksaan") %>
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
        <td class="text">
            Kode<asp:TextBox ID="txtId" runat="server" MaxLength="2" ReadOnly="True" Visible="False"
                Width="8px"></asp:TextBox></td>
        <td>
            <asp:TextBox ID="txtKode" runat="server" MaxLength="50" Width="106px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtKode">*</asp:RequiredFieldValidator></td>
    </tr>
	<tr>
		<td class="text">Nama</td>
		<td>
            <asp:TextBox ID="txtNama" runat="server" MaxLength="50" Width="350px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNama">*</asp:RequiredFieldValidator></td>
	</tr>
	<tr>
        <td class="text">
            Jenis Pemeriksaan</td>
        <td>
            <asp:DropDownList ID="cmbJenisPemeriksaan" runat="server">
            </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                ControlToValidate="cmbJenisPemeriksaan">*</asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td class="text">
            Keterangan</td>
        <td>
            <asp:TextBox ID="txtKeterangan" runat="server" MaxLength="255" Width="350px"></asp:TextBox></td>
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

