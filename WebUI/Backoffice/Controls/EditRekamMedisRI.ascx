<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditRekamMedisRI.ascx.cs" Inherits="Backoffice_Controls_EditRekamMedisRI" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
</asp:ScriptManager>
<asp:HiddenField ID="txtStatusRawatInap" runat="server" />
<asp:HiddenField ID="txtRawatInapId" runat="server" />
<asp:HiddenField ID="txtRegistrasiId" runat="server" />
<asp:HiddenField ID="txtPasienId" runat="server" />
<asp:HiddenField ID="txtTanggalMasuk" runat="server" />
<asp:HiddenField ID="txtJamMasuk" runat="server" />
<table class="adminheading" width="100%">
    <tr>
		<th class="menudottedline">
		    Pencatatan Data Rekam Medis Rawat Inap 
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
                        Tanggal Masuk</td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:Label ID="lblTanggalMasuk" Font-Bold="True" runat="server"></asp:Label></td>
                </tr>
            </table>
        </td>
        <td style="width:50%">
            <table>
                <tr>
                    <td class="text">
                        Ruang Rawat</td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:Label ID="lblRuangRawat" Font-Bold="True" runat="server"></asp:Label></td>
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
<table class="adminform" border="0" width="100%">
    <tr>
        <td colspan="3">
            <asp:Label ID="lblError" runat="server" ForeColor="Red">
            </asp:Label><asp:ValidationSummary id="ValidationSummary1" runat="server" DisplayMode="SingleParagraph" HeaderText="Tanda * harus diisi atau dipilih!"></asp:ValidationSummary>
            </td>
    </tr>
    <tr>
        <td class="text">
            Tanggal Keluar</td>
        <td class="separator">:</td>
        <td class="value">
            <asp:TextBox ID="txtTanggalKeluar" runat="server" Width="85px"></asp:TextBox>
            <asp:ImageButton ID="ImgTanggalKeluar" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" CausesValidation="False" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTanggalKeluar" Width="20px">*</asp:RequiredFieldValidator>
            <ajaxToolkit:MaskedEditExtender ID="MEETanggalKeluar" runat="server"
                TargetControlID="txtTanggalKeluar"
                Mask="99/99/9999"
                MessageValidatorTip="true"
                OnFocusCssClass="MaskedEditFocus"
                OnInvalidCssClass="MaskedEditError"
                MaskType="Date"
                DisplayMoney="Left"
                AcceptNegative="Left"
                ErrorTooltipEnabled="True" />
            <ajaxToolkit:MaskedEditValidator ID="MEVTanggalKeluar" runat="server"
                ControlExtender="MEETanggalKeluar"
                ControlToValidate="txtTanggalKeluar"
                EmptyValueMessage="Tanggal Keluar Harus Diisi"
                InvalidValueMessage="Format Tanggal Salah"
                Display="Dynamic"
                TooltipMessage="(Tanggal/Bulan/Tahun)"
                EmptyValueBlurredText="*"
                InvalidValueBlurredMessage="Format Tanggal Salah"
                ValidationGroup="MKE" />
            <ajaxToolkit:CalendarExtender ID="CETanggalKeluar" CssClass="MyCalendar" runat="server" TargetControlID="txtTanggalKeluar" PopupButtonID="ImgTanggalKeluar" />
            </td>
    </tr>
    <tr>
        <td class="text">
            Jam Keluar</td>
        <td class="separator">:</td>
        <td class="value">
            <asp:TextBox ID="txtJamKeluar" runat="server" Width="34px" Height="16px" ValidationGroup="MKEJamKeluar" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RVJamKeluar" runat="server" ControlToValidate="txtJamKeluar">*</asp:RequiredFieldValidator>
            <ajaxToolkit:MaskedEditExtender ID="MEEJamKeluar" runat="server"
                TargetControlID="txtJamKeluar" 
                Mask="99:99"
                MessageValidatorTip="true"
                OnFocusCssClass="MaskedEditFocus"
                OnInvalidCssClass="MaskedEditError"
                MaskType="Time"
                AcceptAMPM="True"
                ErrorTooltipEnabled="True" />
            <ajaxToolkit:MaskedEditValidator ID="MEVJamKeluar" runat="server"
                ControlExtender="MEEJamKeluar"
                ControlToValidate="txtJamKeluar"
                IsValidEmpty="False"
                EmptyValueMessage="Jam Keluar Harus diisi"
                InvalidValueMessage="Format Jam Keluar Salah"
                Display="Dynamic"
                TooltipMessage="(Jam:Menit)"
                EmptyValueBlurredText=""
                InvalidValueBlurredMessage=""
                ValidationGroup="MKEJamKeluar"/>
                </td>
    </tr>
    <tr>
        <td class="text">
            <asp:RequiredFieldValidator ControlToValidate="txtKeluhanUtama" ID="RVKeluhanUtama" runat="server" ErrorMessage="" Text="*) " ForeColor="red"></asp:RequiredFieldValidator>
            Keluhan Utama</td>
        <td class="separator">:</td>
        <td class="value">
            
            <asp:TextBox ID="txtKeluhanUtama" TextMode="MultiLine" runat="server" Width="500px" Rows="5"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td class="text">
            Keluhan Tambahan</td>
        <td class="separator">:</td>
        <td class="value">
            
            <asp:TextBox ID="txtKeluhanTambahan" TextMode="MultiLine" runat="server" Width="500px" Rows="5"></asp:TextBox>
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
            <asp:RequiredFieldValidator ControlToValidate="cmbStatusRM" ID="RequiredFieldValidator2" runat="server" ErrorMessage="" Text="*) " ForeColor="red"></asp:RequiredFieldValidator>
            Status Pasien Saat Keluar</td>
        <td class="separator">:</td>
        <td class="value">
            <asp:DropDownList ID="cmbStatusRM" runat="server">
            </asp:DropDownList><asp:TextBox ID="txtKeteranganStatusRM" Width="350px" runat="server"></asp:TextBox>
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
