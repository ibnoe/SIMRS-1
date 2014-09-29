<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="AddHemo.aspx.cs" Inherits="Backoffice_Tarif_AddHemo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" language="javascript" src="../../js/inputFormatNo.js"></script>
    <table class="adminheading" id="Table3">
		<tr>
			<th class="menudottedline">
				Tambah Layanan & Tarif HEMODIALISA
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
			<td class="text">Kelompok Pemeriksaan</td>
			<td>
                <asp:DropDownList ID="cmbKelompokPemeriksaan" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator id="RVKelompokPemeriksaan" runat="server" ControlToValidate="cmbKelompokPemeriksaan">*</asp:RequiredFieldValidator></td>
		</tr>
		<tr>
            <td class="text">
                Kode Tarif<asp:TextBox id="txtId" runat="server" MaxLength="2" Width="8px" ReadOnly="True" Visible="False"></asp:TextBox></td>
            <td>
                <asp:TextBox ID="txtKode" runat="server" MaxLength="50" Width="160px"></asp:TextBox></td>
        </tr>
		<tr>
			<td class="text">Kode Pemeriksaan</td>
			<td>
				<asp:TextBox id="txtKodePeriksa" runat="server" MaxLength="50" Width="160px"></asp:TextBox>&nbsp;
				<asp:RequiredFieldValidator id="RVKodePeriksa" runat="server" ControlToValidate="txtKodePeriksa">*</asp:RequiredFieldValidator></td>
		</tr>
        <tr>
			<td class="text">Nama Pemeriksaan</td>
			<td>
				<asp:TextBox id="txtNama" runat="server" MaxLength="50" Width="350px"></asp:TextBox>&nbsp;
				<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtNama">*</asp:RequiredFieldValidator></td>
		</tr>
        <tr>
            <td class="text">
                Rawat Jalan</td>
            <td>
                <input id="txtRJ" onkeypress="CheckInteger()" onblur="FormatAsNumber(this)" onfocus="FormatAsDecimal(this)"  runat="server" maxlength="20" name="txtRJ" style="width: 165px; text-align: right;" type="text" />&nbsp;
				</td>
        </tr>
        <tr>
            <td class="text">
                Kelas III</td>
            <td>
                <input id="txtTarifIII" onkeypress="CheckInteger()" onblur="FormatAsNumber(this)" onfocus="FormatAsDecimal(this)"  runat="server" maxlength="20" name="txtTarifIII" style="width: 165px; text-align: right;" type="text" />&nbsp;
				</td>
        </tr>
        <tr>
            <td class="text">
                Kelas II</td>
            <td>
                <input id="txtTarifII" onkeypress="CheckInteger()" onblur="FormatAsNumber(this)" onfocus="FormatAsDecimal(this)"  runat="server" maxlength="20" name="txtTarifII" style="width: 165px; text-align: right;" type="text" />&nbsp;
				</td>
        </tr>
        <tr>
            <td class="text">
                Kelas I</td>
            <td>
                <input id="txtTarifI" onkeypress="CheckInteger()" onblur="FormatAsNumber(this)" onfocus="FormatAsDecimal(this)"  runat="server" maxlength="20" name="txtTarifI" style="width: 165px; text-align: right;" type="text" />&nbsp;
				</td>
        </tr>
        <tr>
            <td class="text">
                Kelas VIP</td>
            <td>
                <input id="txtTarifVIP" onkeypress="CheckInteger()" onblur="FormatAsNumber(this)" onfocus="FormatAsDecimal(this)"  runat="server" maxlength="20" name="txtTarifVIP" style="width: 165px; text-align: right;" type="text" />&nbsp;
				</td>
        </tr>
        <tr>
            <td class="text">
                Kelas VVIP</td>
            <td>
                <input id="txtTarifVVIP" onkeypress="CheckInteger()" onblur="FormatAsNumber(this)" onfocus="FormatAsDecimal(this)"  runat="server" maxlength="20" name="txtTarifVVIP" style="width: 165px; text-align: right;" type="text" />&nbsp;
				</td>
        </tr>
        <tr>
            <td class="text">
                Askes</td>
            <td>
                <input id="txtAskes" onkeypress="CheckInteger()" onblur="FormatAsNumber(this)" onfocus="FormatAsDecimal(this)"  runat="server" maxlength="20" name="txtTarifVVIP" style="width: 165px; text-align: right;" type="text" />
				<asp:TextBox id="txtKeterangan" runat="server" Width="87px" MaxLength="50" Visible="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="text">
                Satuan</td>
            <td>
                <asp:TextBox ID="txtSatuan" runat="server" MaxLength="50" Width="350px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="text">
                Range Nilai Normal (P)</td>
            <td>
                <input id="Text1" onkeypress="CheckInteger()" onblur="FormatAsNumber(this)" onfocus="FormatAsDecimal(this)"  runat="server" maxlength="20" name="txtTarifVVIP" style="width: 52px; text-align: right;" type="text" />
                -
                <input id="Text2" onkeypress="CheckInteger()" onblur="FormatAsNumber(this)" onfocus="FormatAsDecimal(this)"  runat="server" maxlength="20" name="txtTarifVVIP" style="width: 52px; text-align: right;" type="text" /></td>
        </tr>
        <tr>
            <td class="text">
                Range Nilai Normal (W)</td>
            <td>
                <input id="Text3" onkeypress="CheckInteger()" onblur="FormatAsNumber(this)" onfocus="FormatAsDecimal(this)"  runat="server" maxlength="20" name="txtTarifVVIP" style="width: 52px; text-align: right;" type="text" />
                -
                <input id="Text4" onkeypress="CheckInteger()" onblur="FormatAsNumber(this)" onfocus="FormatAsDecimal(this)"  runat="server" maxlength="20" name="txtTarifVVIP" style="width: 52px; text-align: right;" type="text" /></td>
        </tr>
	</table>
	<table class="adminheading" id="Table2">
		<tr>
			<td width="150px" class="menudottedline">
				&nbsp;</td>
			<td width="50px" class="menudottedline" align="left">
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

