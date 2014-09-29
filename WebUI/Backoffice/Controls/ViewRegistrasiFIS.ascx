<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewRegistrasiFIS.ascx.cs" Inherits="Backoffice_Controls_ViewRegistrasiFIS" %>
<asp:HiddenField ID="HFRawatJalanId" runat="server" />
<table id="Table2" border="0" class="adminform" width="100%">
    <tr>
        <td class="text">
            Nomor Kunjungan</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblNoRegistrasi" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            Tanggal Kunjungan</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblTanggalBerobat" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            Poliklinik Tujuan</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblPoliklinik" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            Nomor Tunggu</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblNoTunggu" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            Keterangan</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblKeterangan" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            Penanggung</td>
        <td class="separator">
           :</td>
        <td class="value">
            <asp:Label ID="lblJenisPenjaminNama" runat="server"></asp:Label>
        </td>
    </tr>
</table>
<table id="tblPenjaminKeluargaView" runat="server" border="0" class="adminform" visible="False" width="100%">
    <tr>
        <th colspan="3">
            Data Keluarga Penjamin</th>
    </tr>
    <tr>
        <td class="text">
            Nama Lengkap
        </td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblNamaPenjamin" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            Hubungan dengan Pasien</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblHubunganNama" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            Umur</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblUmur" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            Alamat</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblAlamatPenjamin" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            No Tlp yang bisa dihubungi</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblTeleponPenjamin" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            Agama</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblAgamaPenjamin" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            Pendidikan</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblPendidikanPenjamin" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            Status</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblStatusPenjaminNama" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            Pangkat</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblPangkatPenjaminNama" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            NRP/NIP</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblNRPPenjamin" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            Jabatan</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblJabatan" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            Kesatuan</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblKesatuanPenjamin" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            Alamat Kesatuan</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblAlamatKesatuan" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            No. KTP</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblNoKTPPenjamin" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            Golongan Darah</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblGolDarahPenjamin" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            Keterangan</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblKeteranganPenjamin" runat="server"></asp:Label>
        </td>
    </tr>
</table>
<table id="tblPenjaminPerusahaanView" runat="server" border="0" class="adminform" visible="False" width="100%">
    <tr>
        <th colspan="3">
            Data Perusahaan Penjamin</th>
    </tr>
    <tr>
        <td class="text">
            Nama Perusahaan</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblNamaPerusahan" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            Nama Kontak</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblNamaKontak" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            Alamat Perusahaan</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblAlamatPerusahaan" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            Telepon
        </td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblTeleponPerusahaan" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            FAX</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblFaxPerusahaan" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            Keterangan</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblKeteranganPerusahaan" runat="server"></asp:Label>
        </td>
    </tr>
</table>
