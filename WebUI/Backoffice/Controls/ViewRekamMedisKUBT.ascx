<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewRekamMedisKUBT.ascx.cs" Inherits="Backoffice_Controls_ViewRekamMedisKUBT" %>
<table class="adminform" width="100%">
    <tr>
        <td class="text">
            Tanggal Periksa</td>
        <td class="separator">:</td>
        <td class="value">
            <asp:Label ID="lblTanggalPeriksa" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="text">
            Jam Periksa</td>
        <td class="separator">:</td>
        <td class="value">
            <asp:Label ID="lblJamPeriksa" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="text">
            Hasil Pemeriksaan</td>
        <td class="separator">:</td>
        <td class="value">
            <asp:Label ID="lblDiagnosa" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="text">
            Keterangan Lain</td>
        <td class="separator">:</td>
        <td class="value">
            <asp:Label ID="lblKeteranganLain" runat="server"></asp:Label></td>
    </tr>
</table>