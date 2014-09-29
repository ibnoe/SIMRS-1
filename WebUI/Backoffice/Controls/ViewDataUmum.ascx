<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewDataUmum.ascx.cs" Inherits="Backoffice_Controls_ViewDataUmum" %>
<asp:HiddenField ID="HFPasienId" runat="server" />
<table class="adminform" id="Table1" border="0" width="100%">
    <tr>
        <td style="width:50%">
            <table>
                <tr>
                    <td class="text"> 
                        Nomor Rekam Medis</td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:Label ID="lblNoRM" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="text">
                        Nama Pasien</td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:Label ID="lblNamaPasien" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="text">
                        Jenis Kelamin</td>
                    <td class="separator">:</td>
                    <td align="left" style="vertical-align: top; text-align: left">
                        <asp:Label ID="lblJenisKelamin" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="text">
                        Tempat/Tanggal Lahir</td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:Label ID="lblTempatLahir" runat="server"></asp:Label> / <asp:Label ID="lblTanggalLahir" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="text">
                        Alamat</td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:Label ID="lblAlamat" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="text">
                        Telepon</td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:Label ID="lblTelepon" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="text">
                        Agama</td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:Label ID="lblAgama" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="text">
                        Pendidikan</td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:Label ID="lblPendidikan" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="text">
                        Status Perkawinan</td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:Label ID="lblStatusPerkawinan" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="text">
                        Status</td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:Label ID="lblStatus" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="text">
                        Pangkat</td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:Label ID="lblPangkat" runat="server"></asp:Label></td>
                </tr>
            </table>
        </td>
        <td style="width:50%">
            <table>
                <tr>
                    <td class="text">
                        NRP</td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:Label ID="lblNRP" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="text">
                        Jabatan</td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:Label ID="lblJabatan" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="text">
                        Kesatuan</td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:Label ID="lblKesatuan" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="text">
                        Alamat Kesatuan</td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:Label ID="lblAlamatKesatuan" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="text">
                        No ASKES</td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:Label ID="lblNoAskes" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="text">
                        No KTP</td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:Label ID="lblNoKTP" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="text">
                        Golongan Darah</td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:Label ID="lblGolDarah" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="text">
                        Pekerjaan</td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:Label ID="lblPekerjaan" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="text">
                        Alamat Kantor</td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:Label ID="lblAlamatKantor" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="text">
                        No Tlp Kantor</td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:Label ID="lblTeleponKantor" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="text">Keterangan</td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:Label ID="lblKeterangan" runat="server"></asp:Label></td>
                </tr>                          
            </table>
        </td>
    </tr>
</table>

