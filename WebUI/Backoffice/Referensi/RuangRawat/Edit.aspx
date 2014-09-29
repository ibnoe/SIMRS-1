<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Backoffice_Referensi_RuangRawat_Edit" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="adminheading" id="Table3">
		<tr>
			<th class="menudottedline">
				<%= Resources.GetString("Referensi","TitleEditRuangRawat") %>
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
                Kelas</td>
            <td>
                <asp:DropDownList ID="cmbKelas" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cmbKelas">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="text">
                Ruangan<asp:TextBox id="txtRuangRawatId" runat="server" MaxLength="2" Width="8px" ReadOnly="True" Visible="False"></asp:TextBox></td>
            <td>
                <asp:DropDownList ID="cmbRuang" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cmbRuang">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="text">
                Nomor Ruang</td>
            <td>
                <asp:TextBox ID="txtNomorRuang" runat="server" MaxLength="50" Width="350px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNomorRuang">*</asp:RequiredFieldValidator></td>
        </tr>
        
        <tr>
            <td class="text">
                Jumlah Tempat Tidur</td>
            <td>
                <input id="txtTempatTidurTotal" onkeypress="CheckInteger()" onchange="calTTkosong(Form1.txtTempatTidurTotal, Form1.txtTempatTidurIsi, Form1.txtTempatTidurKosong)" runat="server" maxlength="2" name="txtTempatTidurTotal"
                    style="width: 36px" type="text" readonly="readOnly" />&nbsp;
                </td>
        </tr>
        <tr>
            <td class="text">
                Tempat Tidur Isi</td>
            <td>
                <input id="txtTempatTidurIsi" onchange="calTTkosong(Form1.txtTempatTidurTotal, this, Form1.txtTempatTidurKosong)" onkeypress="CheckInteger()" runat="server" maxlength="2" name="txtTempatTidurIsi" style="width: 36px"
                    type="text" readonly="readOnly" /></td>
        </tr>
        <tr>
            <td class="text">
                Tempat Tidur Kosong</td>
            <td>
                <input id="txtTempatTidurKosong" readonly="readonly" runat="server" maxlength="2" name="txtTempatTidurKosong" style="width: 36px"
                    type="text" /></td>
        </tr>
        <tr>
            <td class="text">
                Keterangan</td>
            <td>
                <asp:TextBox ID="txtKeterangan" runat="server" MaxLength="50"
                    TextMode="MultiLine" Width="350px"></asp:TextBox></td>
        </tr>
		
	</table>
	<table class="adminheading" id="Table2">
		<tr>
			<td width="150" class="menudottedline">
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

