<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HeaderRI.ascx.cs" Inherits="Backoffice_Controls_HeaderRI" %>
<table class="collapsePanelHeader" style="width:100%">
<%--    <tr>
        <td style="width:34%" colspan="2"></td>
        <td style="width:33%" colspan="2"></td>
        <td style="width:33%" colspan="2"></td>
    </tr>--%>
    <tr>
        <td style="width:100px;text-align:right;color:Black">Nomor RM: </td>
        <td><asp:Label ID="lblNoRMHeader" runat="server">__________________</asp:Label></td>
        <td style="width:100px;text-align:right;color:Black">Ruang Rawat: </td>
        <td><asp:Label ID="lblRuangRawatHeader" runat="server">__________________</asp:Label></td>
        <td style="width:130px;text-align:right;color:Black">Pananggung: </td>
        <td><asp:Label ID="lblJenisPenanggungNamaHeader" runat="server">__________________</asp:Label></td>

    </tr>
    <tr>
        <td style="width:100px;text-align:right;color:Black">Nama Pasien: </td>
        <td><asp:Label ID="lblNamaPasienHeader" runat="server">__________________</asp:Label>
            <asp:Label ID="lblUmurPasienHeader" runat="server"></asp:Label></td>
        <td style="width:100px;text-align:right;color:Black">Dokter: </td>
        <td><asp:Label ID="lblDokterHeader" runat="server">__________________</asp:Label></td>
        <td style="width:130px;text-align:right;color:Black">Nama Pananggung: </td>
        <td><asp:Label ID="lblNamaPenanggungHeader" runat="server">__________________</asp:Label></td>
    </tr>
    <tr>
        <td style="width:100px;text-align:right;color:Black">Status Pasien: </td>
        <td><asp:Label ID="lblStatusPasienHeader" runat="server">__________________</asp:Label></td>
        <td style="width:100px;text-align:right;color:Black">Tanggal Masuk: </td>
        <td><asp:Label ID="lblTanggalMasukHeader" runat="server">__________________</asp:Label></td>
        <td style="width:130px;text-align:right;color:Black">Status Penanggung: </td>
        <td><asp:Label ID="lblStatusPenenaggungHeader" runat="server">__________________</asp:Label></td>
    </tr>
    <tr>
        <td style="width:100px;text-align:right;color:Black">Pangkat Pasien: </td>
        <td><asp:Label ID="lblPangkatPasienHeader" runat="server">__________________</asp:Label></td>
        <td style="width:100px;text-align:right;color:Black">Tanggal Keluar: </td>
        <td><asp:Label ID="lblTanggalKeluarHeader" runat="server">__________________</asp:Label></td>
        <td style="width:130px;text-align:right;color:Black">Pangkat Penanggung: </td>
        <td><asp:Label ID="lblPangkatPenanggungHeader" runat="server">__________________</asp:Label></td>
    </tr>
</table>