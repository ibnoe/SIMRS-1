<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditRekamMedisRJ.ascx.cs" Inherits="Backoffice_Controls_EditRekamMedisRJ" %>
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
		    Pencatatan Data Rekam Medis Rawat Jalan 
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
                        <asp:Label ID="lblDokter" Font-Bold="true" runat="server"></asp:Label>
                        <asp:Label ID="lblDokterId" Visible="false" runat="server"></asp:Label></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table class="adminform" border="0" width="100%">
    <tr>
        <td colspan="3">
            <asp:Label ID="lblError" runat="server" ForeColor="Red">
            </asp:Label><asp:ValidationSummary id="ValidationSummary1" runat="server" DisplayMode="SingleParagraph" HeaderText="Tanda * harus diisi atau dipilih!"></asp:ValidationSummary>
            </td>
    </tr>
    <tr>
        <td class="text">
            Tanggal Kunjungan</td>
        <td class="separator">:</td>
        <td class="value">
            <asp:TextBox ID="txtTanggalPeriksa" runat="server" Width="127px"></asp:TextBox>
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
            </td>
    </tr>
    <tr>
        <td class="text">
            Jam Kunjungan</td>
        <td class="separator">:</td>
        <td class="value">
            <asp:TextBox ID="txtJamPeriksa" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="text">
            <asp:RequiredFieldValidator ControlToValidate="txtKeluhanUtama" ID="RVKeluhanUtama" runat="server" ErrorMessage="" Text="*) " ForeColor="red"></asp:RequiredFieldValidator>
            Keluhan</td>
        <td class="separator">:</td>
        <td class="value">
            
            <asp:TextBox ID="txtKeluhanUtama" TextMode="MultiLine" runat="server" Width="500px" Rows="5"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td class="text">
            <asp:RequiredFieldValidator ControlToValidate="txtDiagnosa" ID="RVDiagnosa" runat="server" ErrorMessage="" Text="*) " ForeColor="red"></asp:RequiredFieldValidator>
            Diagnosa
        </td>
        <td class="separator">:</td>
        <td class="value">
            <asp:TextBox ID="txtDiagnosa" TextMode="MultiLine" runat="server" Width="500px" Rows="5"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td class="text">
            Jenis Penyakit</td>
        <td class="separator">:</td>
        <td class="value">
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>Data Jenis Penyakit</td>
                    <td style="width:50px;"></td>
                    <td>Referensi Jenis Penyakit</td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:ListBox ID="lbJenisPenyakit" runat="server" Height="200px"></asp:ListBox>        
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnAddJenisPenyakit" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btnRemoveJenisPenyakit" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                    <td style="width:50px;">
                        <asp:Button ID="btnAddJenisPenyakit" runat="server" Text="<<" Width="50px" CausesValidation="false" OnClick="btnAddJenisPenyakit_Click" />
                        <asp:Button ID="btnRemoveJenisPenyakit" runat="server" Text=">>" Width="50px" CausesValidation="false" OnClick="btnRemoveJenisPenyakit_Click" />
                    </td>
                    <td valign="top">
                        <asp:ListBox ID="lbJenisPenyakitAvaliable" runat="server" Height="200px"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="text">
            <asp:RequiredFieldValidator ControlToValidate="txtTindakanMedis" ID="RVTindakanMedis" runat="server" ErrorMessage="" Text="*) " ForeColor="red"></asp:RequiredFieldValidator>
            Tindakan Medis</td>
        <td class="separator">:</td>
        <td class="value">
            <asp:TextBox ID="txtTindakanMedis" TextMode="MultiLine" runat="server" Width="500px" Rows="5"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td class="text">
            <asp:RequiredFieldValidator ControlToValidate="txtObat" ID="RVObat" runat="server" ErrorMessage="" Text="*) " ForeColor="red"></asp:RequiredFieldValidator>
            Obat Yang Diberikan</td>
        <td class="separator">:</td>
        <td class="value">
            <asp:TextBox ID="txtObat" TextMode="MultiLine" runat="server" Width="500px" Rows="5"></asp:TextBox>
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
