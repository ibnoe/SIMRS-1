<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Backoffice_Referensi_Dokter_Edit" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true" ></asp:ScriptManager>
<table class="adminheading" id="Table3">
	<tr>
		<th class="menudottedline">
			<%= Resources.GetString("Referensi","TitleEditDokter") %>
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
            NRP</td>
        <td>
            <asp:TextBox ID="txtNRP" runat="server" MaxLength="50" Width="106px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNRP">*</asp:RequiredFieldValidator></td>
    </tr>
	<tr>
		<td class="text">Nama<asp:TextBox id="txtDokterId" runat="server" MaxLength="2" Width="8px" ReadOnly="True" Visible="False"></asp:TextBox></td>
		<td>
			<asp:TextBox id="txtNama" runat="server" MaxLength="50" Width="350px"></asp:TextBox>&nbsp;
			<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtNama">*</asp:RequiredFieldValidator></td>
	</tr>
	<tr>
        <td class="text">
            Tempat Lahir</td>
        <td>
            <asp:TextBox ID="txtTempatLahir" runat="server" MaxLength="50" Width="350px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="text">
            Tanggal Lahir</td>
        <td>
            <asp:TextBox ID="txtTanggalLahir" runat="server" Width="82px" MaxLength="1" style="text-align:justify" ValidationGroup="MKE" />
            <font style="font-size:smaller">(Tanggal/Bulan/Tahun)</font>
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server"
                        TargetControlID="txtTanggalLahir"
                        Mask="99/99/9999"
                        MessageValidatorTip="true"
                        OnFocusCssClass="MaskedEditFocus"
                        OnInvalidCssClass="MaskedEditError"
                        MaskType="Date"
                        ErrorTooltipEnabled="True" CultureName="id-ID" />
                    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator5" runat="server"
                        ControlExtender="MaskedEditExtender5"
                        ControlToValidate="txtTanggalLahir"
                        EmptyValueMessage="Harus diisi!"
                        InvalidValueMessage="Format tangal salah"
                        Display="Dynamic"
                        EmptyValueBlurredText="Harus diisi!"
                        InvalidValueBlurredMessage="Format tangal salah"
                        ValidationGroup="MKE" />
        </td>
    </tr>
    <tr>
        <td class="text">
            Jenis Kelamin</td>
        <td>
            <asp:DropDownList ID="cmbJenisKelamin" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem Value="L">Laki-laki</asp:ListItem>
                <asp:ListItem Value="P">Perempuan</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cmbJenisKelamin">*</asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td class="text">
            Alamat</td>
        <td>
            <asp:TextBox ID="txtAlamat" runat="server" MaxLength="50"
                TextMode="MultiLine" Width="350px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="text">
            Telepon</td>
        <td>
            <asp:TextBox ID="txtTelepon" runat="server" MaxLength="50" Width="350px"></asp:TextBox></td>
    </tr>
	<tr>
        <td class="text">
            Spesialis</td>
        <td>
            <asp:DropDownList ID="cmbSpesialis" runat="server">
            </asp:DropDownList></td>
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

