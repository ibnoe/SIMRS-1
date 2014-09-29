<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="dlgRekapKasirRJ.aspx.cs" Inherits="Backoffice_Kasir_dlgRekapKasirRJ" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"  EnableScriptGlobalization="true" EnableScriptLocalization="true">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../../js/Popup.js"></script>
    <table class="adminheading" border="0" width="100%">
        <tr>
            <th class="menudottedline">
                <asp:Label ID="lblTitleHeader" runat="server" Text="Cetak Rekapitulasi Kuitansi Rawat Jalan"></asp:Label>
            </th>
        </tr>
    </table>
    <table class="adminform" border="0" width="100%">
        <tr>
            <td class="text">Tanggal Proses :</td>
            <td class="value">
                <asp:TextBox ID="txtTanggalMulai" runat="server" Width="75px" MaxLength="1" style="text-align:justify" ValidationGroup="MKE" AutoPostBack="True" OnTextChanged="txtTanggalMulai_TextChanged" />
                    <asp:ImageButton ID="ImgTanggalMulai" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" CausesValidation="False" />
                    <asp:RequiredFieldValidator ID="RVTanggalMulai" runat="server" ControlToValidate="txtTanggalMulai" Width="20px">*</asp:RequiredFieldValidator>
                    <ajaxToolkit:MaskedEditExtender ID="MEETanggalMulai" runat="server"
                        TargetControlID="txtTanggalMulai"
                        Mask="99/99/9999"
                        MessageValidatorTip="true"
                        OnFocusCssClass="MaskedEditFocus"
                        OnInvalidCssClass="MaskedEditError"
                        MaskType="Date"
                        DisplayMoney="Left"
                        AcceptNegative="Left"
                        ErrorTooltipEnabled="True" />
                    <ajaxToolkit:MaskedEditValidator ID="MEVTanggalMulai" runat="server"
                        ControlExtender="MEETanggalMulai"
                        ControlToValidate="txtTanggalMulai"
                        EmptyValueMessage="Tanggal Pembayaran Harus Diisi"
                        InvalidValueMessage="Format Tanggal Salah"
                        Display="Dynamic"
                        TooltipMessage="(Tanggal/Bulan/Tahun)"
                        EmptyValueBlurredText="*"
                        InvalidValueBlurredMessage="Format Tanggal Salah"
                        ValidationGroup="MKE" />
                    <ajaxToolkit:CalendarExtender ID="CETanggalMulai" CssClass="MyCalendar" runat="server" TargetControlID="txtTanggalMulai" PopupButtonID="ImgTanggalMulai" />
                    S/D
                    <asp:TextBox ID="txtTanggalSelesai" runat="server" Width="75px" MaxLength="1" style="text-align:justify" ValidationGroup="MKE" AutoPostBack="True" OnTextChanged="txtTanggalSelesai_TextChanged" />
                        <asp:ImageButton ID="ImgTanggalSelesai" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" CausesValidation="False" />
                        <asp:RequiredFieldValidator ID="RVTanggalSelesai" runat="server" ControlToValidate="txtTanggalSelesai" Width="20px">*</asp:RequiredFieldValidator>
                        <ajaxToolkit:MaskedEditExtender ID="MEETanggalSelesai" runat="server"
                            TargetControlID="txtTanggalSelesai"
                            Mask="99/99/9999"
                            MessageValidatorTip="true"
                            OnFocusCssClass="MaskedEditFocus"
                            OnInvalidCssClass="MaskedEditError"
                            MaskType="Date"
                            DisplayMoney="Left"
                            AcceptNegative="Left"
                            ErrorTooltipEnabled="True" />
                        <ajaxToolkit:MaskedEditValidator ID="MEVTanggalSelesai" runat="server"
                            ControlExtender="MEETanggalSelesai"
                            ControlToValidate="txtTanggalSelesai"
                            EmptyValueMessage="Tanggal Pembayaran Harus Diisi"
                            InvalidValueMessage="Format Tanggal Salah"
                            Display="Dynamic"
                            TooltipMessage="(Tanggal/Bulan/Tahun)"
                            EmptyValueBlurredText="*"
                            InvalidValueBlurredMessage="Format Tanggal Salah"
                            ValidationGroup="MKE" />
                         <ajaxToolkit:CalendarExtender ID="CETanggalSelesai" CssClass="MyCalendar" runat="server" TargetControlID="txtTanggalSelesai" PopupButtonID="ImgTanggalSelesai" />       
                      
            </td>
        </tr>
        <tr>
            <td class="text">Model Rekap :</td>
            <td class="value">
                <asp:DropDownList ID="cmbModelRekap" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbModelRekap_SelectedIndexChanged">
                    <asp:ListItem Value="1">Urutkan Berdasarkan Tanggal dan Nomor Kuitansi</asp:ListItem>
                    <asp:ListItem Value="2">Berdasarkan Poliklinik</asp:ListItem>
                </asp:DropDownList>&nbsp;
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                <asp:DropDownList ID="cmbPoliklinik" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbPoliklinik_SelectedIndexChanged" Visible="False"></asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cmbModelRekap" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                </td>
        </tr>
        <tr>
            <td class="text">
                Filter By:</td>
            <td class="value">
                <asp:DropDownList ID="cmbUser" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbUser_SelectedIndexChanged">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="User Aktif" Selected="True">User Aktif</asp:ListItem>
                    <asp:ListItem Value="Semua User">Semua User</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
<A id="btnPrint" class="button" onclick="" href="javascript:void(0)" runat="server">Cetak</A> 
</ContentTemplate>
                    <Triggers>
<asp:AsyncPostBackTrigger ControlID="txtTanggalMulai" EventName="TextChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="txtTanggalSelesai" EventName="TextChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="cmbPoliklinik" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="cmbModelRekap" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

