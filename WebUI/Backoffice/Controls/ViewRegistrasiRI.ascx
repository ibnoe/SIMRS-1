<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewRegistrasiRI.ascx.cs" Inherits="Backoffice_Controls_ViewRegistrasiRI" %>
<asp:HiddenField ID="HFRawatInapId" runat="server" />
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
            Tanggal Masuk</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblTanggalMasuk" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            Asal Pasien</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblAsalPasienNama" runat="server"></asp:Label>
            <asp:Label ID="lblAsalPasien" Visible="false" runat="server"></asp:Label>
        </td>
    </tr>
    <tr id="trRujukan" runat="server" visible="false">
        <td class="text">
            Rujukan Dari</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblDariRujukan" runat="server"></asp:Label>
            </td>
    </tr>
    <tr id="trDariPoliklinik" runat="server">
        <td class="text">
            Dari Poliklinik</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblDariPoliklinik" runat="server"></asp:Label>
            <asp:Label ID="lblDariPoliklinikId" Visible="false" runat="server"></asp:Label>
        </td>
    </tr>
    <tr id="trDariDokter" runat="server">
       <td class="text">
            Dari Dokter</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblDariDokter" runat="server"></asp:Label>
            <asp:Label ID="lblDariDokterId" Visible="false" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            Dokter Yang Menangani</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblDokterNama" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="text">
            Diagnosa Masuk</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblDiagnosaMasuk" runat="server"></asp:Label>
        </td>
    </tr>
    <%--<tr>
        <td class="text">
            Deposit</td>
        <td class="separator">
            :</td>
        <td class="value">
            <asp:Label ID="lblDeposit" runat="server"></asp:Label>
        </td>
    </tr>--%>
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
