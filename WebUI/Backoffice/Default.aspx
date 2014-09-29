<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Backoffice_Default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" src="../js/Popup.js" type="text/javascript"></script>
    <table id="Table1" cellspacing="5" cellpadding="5" border="0" style="height:450px; text-align:left; width:100%">
		<tr>
           	<td align="left" colspan="2" >
			<div id="cpanel">
			<% if (Session["UserManagement"] != null) {%>
				<div style="float:left;"><div class="icon">
				<a href="Users/List.aspx"><img alt="" border="0" src="../images/ico_front/ico_mng_user.png" />
				<br />Manajemen User</a></div></div>
            <% } if (Session["GroupManagement"] != null){%>
				<div style="float:left;"><div class="icon">
				<a href="Groups/List.aspx"><img alt="" border="0" src="../images/ico_front/ico_mng_grup.png" />
				<br />Manajemen Grup  </a></div></div>
			<% } if (Session["StatusManagement"] != null){%>
				<div style="float:left;"><div class="icon">
				<a href="Referensi/Status/List.aspx"><img alt="" border="0" src="../images/ico_front/ico_statuspasien.png" />
				<br />Ref. Status Pasien  </a></div></div>
			<% } if (Session["PangkatManagement"] != null){%>
				<div style="float:left;"><div class="icon">
				<a href="Referensi/Pangkat/List.aspx"><img alt="" border="0" src="../images/ico_front/ico_pangkat.png" />
				<br />Ref. Pangkat Pasien  </a></div></div>
			<% } if (Session["PoliklinikManagement"] != null){%>
				<div style="float:left;"><div class="icon">
				<a href="Referensi/Poliklinik/List.aspx"><img alt="" border="0" src="../images/ico_front/ico_poliklinik.png" />
				<br />Ref. Poliklinik  </a></div></div>
			<% } if (Session["SpesialisManagement"] != null){%>
				<div style="float:left;"><div class="icon">
				<a href="Referensi/Spesialis/List.aspx"><img alt="" border="0" src="../images/ico_front/ico_spesialisasidokter.png" />
				<br />Ref. Spesialisasi Dokter  </a></div></div>
			<% } if (Session["DokterManagement"] != null){%>
				<div style="float:left;"><div class="icon">
				<a href="Referensi/Dokter/List.aspx"><img alt="" border="0" src="../images/ico_front/ico_daftardokter.png" />
				<br />Ref. Dokter  </a></div></div>
			<% } if (Session["JadwalDokterManagement"] != null) {%>
				<div style="float:left;"><div class="icon">
				<a href="Referensi/JadwalDokter/List.aspx"><img alt="" border="0" src="../images/ico_front/ico_jadwaldokter.png" />
				<br />Ref. Jadwal Dokter  </a></div></div>
			<% } if (Session["RuangManagement"] != null){%>
				<div style="float:left;"><div class="icon">
				<a href="Referensi/Ruang/List.aspx"><img alt="" border="0" src="../images/ico_front/ico_ruangan.png" />
				<br />Ref. Ruangan  </a></div></div>
			<% } if (Session["KelasManagement"] != null){%>
				<div style="float:left;"><div class="icon">
				<a href="Referensi/Kelas/List.aspx"><img alt="" border="0" src="../images/ico_front/ico_kelas.png" />
				<br />Ref. Kelas  </a></div></div>
			<% } if (Session["RuangRawatManagement"] != null){%>
				<div style="float:left;"><div class="icon">
				<a href="Referensi/RuangRawat/List.aspx"><img alt="" border="0" src="../images/ico_front/ico_ruangrawat.png" />
				<br />Ref. Ruang Rawat  </a></div></div>
			<% } if (Session["TempatTidurManagement"] != null){%>
				<div style="float:left;"><div class="icon">
				<a href="Referensi/TempatTidur/List.aspx"><img alt="" border="0" src="../images/ico_front/ico_tempattidur.png" />
				<br />Ref. Tempat Tidur  </a></div></div>
			<% } if (Session["JenisPenyakitManagement"] != null){%>
				<div style="float:left;"><div class="icon">
				<a href="Referensi/JenisPenyakit/List.aspx"><img alt="" border="0" src="../images/ico_front/ico_penyakit.png" />
				<br />Ref. Jenis Penyakit  </a></div></div>
			<% } if (Session["TarifManagement"] != null){%>
				<div style="float:left;"><div class="icon">
				<a href="Tarif/ListRawatInap.aspx"><img alt="" border="0" src="../images/ico_front/ico_tarif_inap.png" />
				<br />Tarif Rawat Inap  </a></div></div>
			<% } if (Session["TarifManagement"] != null){%>
				<div style="float:left;"><div class="icon">
				<a href="Tarif/ListRawatJalan.aspx"><img alt="" border="0" src="../images/ico_front/ico_tarif_jalan.png" />
				<br />Tarif Rawat Jalan  </a></div></div>
			<% } if (Session["RegistrasiRJ"] != null){%>
				<div style="float:left;"><div class="icon">
				<a href="Registrasi/RJList.aspx"><img alt="" border="0" src="../images/ico_front/ico_reg_jalan.png" />
				<br />Registrasi Rawat Jalan  </a></div></div>
			<% } if (Session["RegistrasiRI"] != null){%>
				<div style="float:left;"><div class="icon">
				<a href="Registrasi/RIList.aspx"><img alt="" border="0" src="../images/ico_front/ico_reg_inap.png" />
				<br />Registrasi Rawat Inap  </a></div></div>
			<% } if (Session["RekamMedisRJ"] != null){%>
				<div style="float:left;"><div class="icon">
				<a href="RekamMedis/RJList.aspx"><img alt="" border="0" src="../images/ico_front/ico_rekam_jalan.png" />
				<br />Rekam Medis Rawat Jalan  </a></div></div>
            <% } if (Session["RekamMedisRI"] != null){%>
			    <div style="float:left;"><div class="icon">
			    <a href="RekamMedis/RIList.aspx"><img alt="" border="0" src="../images/ico_front/ico_rekam_inap.png" />
			    <br />Rekam Medis Rawat Inap  </a></div></div>
            <% } if (Session["KasirRJ"] != null){%>
			    <div style="float:left;"><div class="icon">
			    <a href="Kasir/RJList.aspx"><img alt="" border="0" src="../images/ico_front/ico_cashier_jalan.png" />
			    <br />Kasir Rawat Jalan  </a></div></div>
           <% } if (Session["KasirRI"] != null){%>
			    <div style="float:left;"><div class="icon">
			    <a href="Kasir/RIList.aspx"><img alt="" border="0" src="../images/ico_front/ico_cashier_inap.png" />
			    <br />Kasir Rawat Inap  </a></div></div>
            <% } if (Session["InformasiJadwalDokter"] != null){%>
			    <div style="float:left;"><div class="icon">
			    <a href="Informasi/JadwalDokter.aspx"><img alt="" border="0" src="../images/ico_front/ico_jadwaldokter2.png" />
			    <br />Informasi Jadwal Dokter  </a></div></div>
            <% } %>
			</div>
			</td>
		</tr>
		<tr>
			<td valign="top">
				</td>
			<td align="right" valign="top">
				<table id="Table2" cellspacing="5" cellpadding="1" width="200" border="0" class="usercontrol">
					<tr>
						<td align="right">
						    <a onclick="javascript:displayPopup_scroll(2,'../Data/SIMRS-Manual1.0.pdf','UserManual',600,800,(version4 ? event : null));" href="javascript:void(0)">
						    <br />
								User Manual</a>
								</td>
					</tr>
					<tr>
						<td align="right"><a onclick="javascript:displayPopup_scroll(2,'../Data/AdbeRdr70_enu_full.exe','DownloadAcReader',600,630,(version4 ? event : null));" href="javascript:void(0)"><img src="../Images/get_adobe_reader.jpg" border="0">
						<br />Download Acrobat Reader</a></td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td vAlign="bottom"></td>
			<td align="right" vAlign="top"></td>
		</tr>
	</table>
</asp:Content>

