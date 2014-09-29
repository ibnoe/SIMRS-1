<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditRekamMedisRAD.ascx.cs" Inherits="Backoffice_Controls_EditRekamMedisRAD" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
</asp:ScriptManager>
<asp:HiddenField ID="txtStatusRawatJalan" runat="server" />
<asp:HiddenField ID="txtRawatJalanId" runat="server" />
<asp:HiddenField ID="txtRegistrasiId" runat="server" />
<asp:HiddenField ID="txtPasienId" runat="server" />
<asp:HiddenField ID="txtTanggalBerobat" runat="server" />
<asp:HiddenField ID="txtJamPraktek" runat="server" />
<table class="adminheading" width="100%">
    <tr>
		<th class="menudottedline">
		    Pencatatan Data Hasil Radiologi 
		</th>
	</tr>
	<tr>
		<th class="menudottedline">
			<div style="float: left; margin-left: 0px; color:Black; width:200px; text-align:right;">Nomor Rekam Medis:</div>
            <div style="float: left; margin-left:5px; color:Blue; width:150px;"><asp:Label ID="lblNoRMHeader" runat="server"></asp:Label></div>
            <div style="float: left; margin-left:5px; color:Black; width:150px; text-align:right;">Nama Pasien:</div>
            <div style="float: left; margin-left:5px; color:Blue; width:200px;"><asp:Label ID="lblNamaPasienHeader" runat="server"></asp:Label></div>
		</th>
	</tr>
</table>
<table class="adminform" id="Table2" border="0" width="100%">
    <tr>
        <td style="width:50%">
            <table>
                <tr>
                    <td class="text">Nomor Kunjungan</td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:Label ID="lblNoRegistrasi" Font-Bold="true" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="text">
                        Tanggal Kunjungan</td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:Label ID="lblTanggalBerobat" Font-Bold="true" runat="server"></asp:Label></td>
                </tr>
            </table>
        </td>
        <td style="width:50%">
            <table>
                <tr>
                    <td class="text">
                        Poliklinik </td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:Label ID="lblPoliklinik" Font-Bold="true" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="text">
                        Dokter</td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:Label ID="lblDokter" Font-Bold="true" runat="server"></asp:Label></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <table class="adminform" border="0" width="100%">
        <tr>
            <td colspan="3">
                <asp:Label ID="lblError" runat="server" ForeColor="Red">
                </asp:Label><asp:ValidationSummary id="ValidationSummary1" runat="server" DisplayMode="SingleParagraph" HeaderText="Tanda * harus diisi atau dipilih!"></asp:ValidationSummary>
                </td>
        </tr>
        <tr>
            <td class="text">
                Tanggal Periksa</td>
            <td class="separator">:</td>
            <td class="value">
                <asp:TextBox ID="txtTanggalPeriksa" runat="server" Width="60px" OnTextChanged="txtTanggalPeriksa_TextChanged" AutoPostBack="True" ></asp:TextBox>
                <asp:ImageButton ID="ImgTanggalPeriksa" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" CausesValidation="False" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTanggalPeriksa" Width="20px">*</asp:RequiredFieldValidator>
                <ajaxToolkit:MaskedEditExtender ID="MEETanggalPeriksa" runat="server"
                    TargetControlID="txtTanggalPeriksa"
                    Mask="99/99/9999"
                    MessageValidatorTip="true"
                    OnFocusCssClass="MaskedEditFocus"
                    OnInvalidCssClass="MaskedEditError"
                    MaskType="Date"
                    DisplayMoney="Left"
                    AcceptNegative="Left"
                    ErrorTooltipEnabled="True" />
                <ajaxToolkit:MaskedEditValidator ID="MEVTanggalPeriksa" runat="server"
                    ControlExtender="MEETanggalPeriksa"
                    ControlToValidate="txtTanggalPeriksa"
                    EmptyValueMessage="Tanggal Kunjungan Harus Diisi"
                    InvalidValueMessage="Format Tanggal Salah"
                    Display="Dynamic"
                    TooltipMessage="(Tanggal/Bulan/Tahun)"
                    EmptyValueBlurredText="*"
                    InvalidValueBlurredMessage="Format Tanggal Salah"
                    ValidationGroup="MKE" />
                <ajaxToolkit:CalendarExtender ID="CETanggalPeriksa" CssClass="MyCalendar" runat="server" TargetControlID="txtTanggalPeriksa" PopupButtonID="ImgTanggalPeriksa" />
                <asp:TextBox ID="txtHari" runat="server" Visible="False" Width="2px"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td class="text">
                Jam Periksa</td>
            <td class="separator">:</td>
            <td class="value">
                <asp:TextBox ID="txtJamPeriksa" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="text">
                Dokter Pemeriksa</td>
            <td class="separator">:</td>
            <td class="value">
                <asp:DropDownList ID="cmbDokter" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        
        <tr>
            <td class="text">
                <asp:RequiredFieldValidator ControlToValidate="txtDiagnosa" ID="RVDiagnosa" runat="server" ErrorMessage="" Text="*) " ForeColor="red"></asp:RequiredFieldValidator>
                Hasil Pemeriksaan
            </td>
            <td class="separator">:</td>
            <td class="value">
                <asp:TextBox ID="txtDiagnosa" TextMode="MultiLine" runat="server" Width="500px" Rows="10"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td class="text">
                Keterangan Lain</td>
            <td class="separator">:</td>
            <td class="value">
                <asp:TextBox ID="txtKeteranganLain" TextMode="MultiLine" runat="server" Width="500px" Rows="5"></asp:TextBox></td>
        </tr>
    </table>
</ContentTemplate>
</asp:UpdatePanel>
