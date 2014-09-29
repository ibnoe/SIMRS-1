<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditPasien.ascx.cs" Inherits="Backoffice_Controls_EditPasien" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:HiddenField ID="HFPasienId" runat="server" />
<table class="adminform" border="0" width="50%">
    <tr>
        <td align="left" colspan="3">
                <asp:Label ID="lblError" runat="server" ForeColor="Red">
                </asp:Label><asp:ValidationSummary id="ValidationSummary1" runat="server" DisplayMode="SingleParagraph" HeaderText="Tanda * harus diisi atau dipilih!"></asp:ValidationSummary></td>
    </tr>
    <tr>
        <td class="text">
            Nomor Rekam Medis</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:TextBox ID="txtNoRM" runat="server" MaxLength="50" Width="100px" Font-Bold="True" Font-Size="Large" ValidationGroup="MENoRM"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RVNoRM" runat="server" ControlToValidate="txtNoRM" ValidationGroup="MENoRM">*</asp:RequiredFieldValidator>
            <ajaxToolkit:MaskedEditExtender ID="MENoRM" runat="server"
                Mask="99,99,99" TargetControlID="txtNoRM" ClearMaskOnLostFocus="False" CultureName="id-ID">
            </ajaxToolkit:MaskedEditExtender>
            <ajaxToolkit:MaskedEditValidator ID="MEVNoRM" runat="server" ControlExtender="MENoRM"
                ControlToValidate="txtNoRM" ValidationGroup="MENoRM" ErrorMessage="MEVNoRM" EmptyValueBlurredText="Nomor Rkam Medis Harus diisi" EmptyValueMessage="Nomor Rkam Medis Harus diisi" IsValidEmpty="False" SetFocusOnError="True" InvalidValueMessage="*" ValidationExpression="(\d{2})(\.)(\d{2})(\.)(\d{2})">*</ajaxToolkit:MaskedEditValidator>
        </td>
    </tr>
    <tr>
        <td class="text">
            Nama Pasien</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:TextBox ID="txtNama" runat="server" MaxLength="50" Width="350px"></asp:TextBox>&nbsp;
            <asp:RequiredFieldValidator ID="RVNamaPasien" runat="server" ControlToValidate="txtNama" Width="8px">*</asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td class="text">
            Jenis Kelamin</td>
        <td class="separator">
            :</td>
        <td class="value"><asp:DropDownList ID="cmbJenisKelamin" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem Value="L">Laki-laki</asp:ListItem>
            <asp:ListItem Value="P">Perempuan</asp:ListItem>
        </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RVJenisKelamin" runat="server" ControlToValidate="cmbJenisKelamin" Width="20px">*</asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td class="text">
            Tempat Lahir</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:TextBox ID="txtTempatLahir" runat="server" MaxLength="50" Width="135px"></asp:TextBox>
            </td>
    </tr>
    <tr>
        <td class="text">
            Tanggal Lahir</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:TextBox ID="txtTanggalLahir" runat="server" Width="75px" MaxLength="1" style="text-align:justify" ValidationGroup="MKE" />
            <asp:ImageButton ID="ImgTanggalLahir" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" CausesValidation="False" />
            <asp:RequiredFieldValidator ID="RVTanggalLahir" runat="server" ControlToValidate="txtTanggalLahir" Width="20px">*</asp:RequiredFieldValidator>
            <ajaxToolkit:MaskedEditExtender ID="MEETanggalLahir" runat="server"
                TargetControlID="txtTanggalLahir"
                Mask="99/99/9999"
                MessageValidatorTip="true"
                OnFocusCssClass="MaskedEditFocus"
                OnInvalidCssClass="MaskedEditError"
                MaskType="Date"
                DisplayMoney="Left"
                AcceptNegative="Left"
                ErrorTooltipEnabled="True" />
            <ajaxToolkit:MaskedEditValidator ID="MEVTanggalLahir" runat="server"
                ControlExtender="MEETanggalLahir"
                ControlToValidate="txtTanggalLahir"
                EmptyValueMessage="Tanggal Lahir Harus Diisi"
                InvalidValueMessage="Format Tanggal Salah"
                Display="Dynamic"
                TooltipMessage="(Tanggal/Bulan/Tahun)"
                EmptyValueBlurredText="*"
                InvalidValueBlurredMessage="Format Tanggal Salah"
                ValidationGroup="MKE" />
             <ajaxToolkit:CalendarExtender ID="CETanggalLahir" CssClass="MyCalendar" runat="server" TargetControlID="txtTanggalLahir" PopupButtonID="ImgTanggalLahir" />       
        </td>
    </tr>
    <tr>
        <td class="text">
            Alamat</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:TextBox ID="txtAlamatPasien" runat="server" MaxLength="250" TextMode="MultiLine" Width="350px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="text">
            Telepon</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:TextBox ID="txtTeleponPasien" runat="server" MaxLength="50" Width="350px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="text">
            Agama</td>
        <td class="separator">
            :</td>
        <td class="value"><asp:DropDownList ID="cmbAgama" runat="server">
        </asp:DropDownList></td>
    </tr>
    <tr>
        <td class="text">
            Pendidikan</td>
        <td class="separator">
            :</td>
        <td class="value"><asp:DropDownList ID="cmbPendidikan" runat="server">
        </asp:DropDownList></td>
    </tr>
    <tr>
        <td class="text">
            Status Perkawinan</td>
        <td class="separator">
            :</td>
        <td class="value"><asp:DropDownList ID="cmbStatusPerkawinan" runat="server">
        </asp:DropDownList></td>
    </tr>
    <tr>
        <td class="text">
            Status Pasien</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:DropDownList ID="cmbStatusPasien" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbStatusPasien_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RVStatusPsaien" runat="server" ControlToValidate="cmbStatusPasien" Width="18px">*</asp:RequiredFieldValidator>&nbsp;
            </td>
    </tr>
    <tr>
        <td class="text">
            Pangkat Pasien</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:UpdatePanel ID="UPPangkatPasien" runat="server">
                <ContentTemplate>
            <asp:DropDownList ID="cmbPangkatPasien" runat="server">
            </asp:DropDownList>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="cmbStatusPasien" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="text">
            NRP/NIP</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:TextBox ID="txtNrpPasien" runat="server" MaxLength="50" Width="350px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="text">
            Jabatan</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:TextBox ID="txtJabatan" runat="server" MaxLength="50" Width="350px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="text">
            Satuan Kerja</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:DropDownList ID="cmbSatuanKerja" runat="server" AutoPostBack="false">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td class="text">
            Alamat Kesatuan</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:TextBox ID="txtAlamatKesatuan" runat="server" MaxLength="250" TextMode="MultiLine" Width="350px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="text">
            No ASKES</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:TextBox ID="txtNoASKES" runat="server" MaxLength="50" Width="350px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="text">
            No KTP</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:TextBox ID="txtNoKTP" runat="server" MaxLength="50" Width="350px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="text">
            Golongan Darah</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:TextBox ID="txtGolDarah" runat="server" MaxLength="2" Width="30px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="text">
            Pekerjaan</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:TextBox ID="txtPekerjaan" runat="server" MaxLength="50" Width="350px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="text">
            Alamat Kantor</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:TextBox ID="txtAlamatKantorPasien" runat="server" MaxLength="50" TextMode="MultiLine" Width="350px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="text">
            No Tlp Kantor</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:TextBox ID="txtTeleponKantorPasien" runat="server" MaxLength="50" Width="350px"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="text">Keterangan</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:TextBox id="txtKeteranganPasien" runat="server" Width="350px" MaxLength="50" TextMode="MultiLine"></asp:TextBox></td>
    </tr>
</table>