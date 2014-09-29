<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Backoffice_Referensi_TempatTidur_Edit" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
    </asp:ScriptManager>
	<table class="adminheading" id="Table3">
		<tr>
			<th class="menudottedline">
				<%= Resources.GetString("Referensi","TitleEditTempatTidur") %>
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
                <asp:DropDownList ID="cmbKelas" runat="server" OnSelectedIndexChanged="cmbKelas_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cmbKelas">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="text">
                Ruangan<asp:TextBox id="txtTempatTidurId" runat="server" MaxLength="2" Width="8px" ReadOnly="True" Visible="False"></asp:TextBox></td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbRuang" runat="server" OnSelectedIndexChanged="cmbRuang_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cmbRuang">*</asp:RequiredFieldValidator>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cmbKelas" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="text">
                Nomor Ruang</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbNoRuang" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RVNoRuang" runat="server" ControlToValidate="cmbNoRuang">*</asp:RequiredFieldValidator>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cmbRuang" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="cmbKelas" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td width="150" style="height: 26px">
                Nomor Tempat Tidur</td>
            <td style="height: 26px">
                <asp:TextBox ID="txtNomorTempat" runat="server" MaxLength="50" Width="77px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNomorTempat">*</asp:RequiredFieldValidator></td>
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

