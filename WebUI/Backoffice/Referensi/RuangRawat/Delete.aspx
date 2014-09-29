<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="Delete.aspx.cs" Inherits="Backoffice_Referensi_RuangRawat_Delete" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="adminheading" id="Table3">
		<tr>
			<th class="menudottedline">
				<%= Resources.GetString("Referensi","TitleDeleteRuangRawat") %>
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
            <td class="text">
                Kelas</td>
            <td>
                <asp:Label ID="lblKelas" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="text">
                Ruang<asp:TextBox id="txtRuangRawatId" runat="server" MaxLength="2" Width="8px" ReadOnly="True" Visible="False"></asp:TextBox></td>
            <td>
                <asp:Label ID="lblRuang" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="text">
                Nomor Ruang</td>
            <td>
                <asp:Label ID="lblNomorRuang" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="text">
                Jumlah Tempat Tidur</td>
            <td>
                <asp:Label ID="lblTempatTidurTotal" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="text">
                Tempat Tidur Terisi</td>
            <td>
                <asp:Label ID="lblTempatTidurIsi" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="text">
                Tempt Tidur Kosong</td>
            <td>
                <asp:Label ID="lblTempatTidurKosong" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="text">
                Keterangan</td>
            <td>
                <asp:Label ID="lblKeterangan" runat="server"></asp:Label></td>
        </tr>
	</table>
	<table class="adminheading" id="Table2">
		<tr>
			<td width="150" class="menudottedline">
				&nbsp;</td>
			<td width="50" class="menudottedline" align="left">
				<div class="toolbar" onmouseover="MM_swapImage('save','','../../../images/save_f2.gif',1);"
					onmouseout="MM_swapImgRestore();">
					<asp:linkbutton id="btnDelete" OnClick="OnDelete" runat="server"></asp:linkbutton></div>
			</td>
			<td width="50" class="menudottedline" align="left">
				<div class="toolbar" onmouseover="MM_swapImage('cancel','','../../../images/cancel_f2.gif',1);"
					onmouseout="MM_swapImgRestore();"><asp:linkbutton id="btnCancel" OnClick="OnCancel" runat="server" CausesValidation="False"></asp:linkbutton></div>
			</td>
			<td class="menudottedline">&nbsp;</td>
		</tr>
	</table>
</asp:Content>

