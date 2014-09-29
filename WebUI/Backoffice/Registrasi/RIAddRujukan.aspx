<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="RIAddRujukan.aspx.cs" Inherits="Backoffice_Registrasi_RIAddRujukan" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1"  EnableScriptGlobalization="true" EnableScriptLocalization="true" />
        <table class="adminheading" width="100%" id="Table3">
            <tr>
	            <th class="menudottedline">
                    <%= Resources.GetString("RS","TitleRawatInapAddRegistrasi") %>
	            </th>
	            <td class="menudottedline" align="right">&nbsp;
	            </td>
            </tr>
        </table>
        <asp:Panel ID="pnlPasienHeader" runat="server" CssClass="collapsePanelHeader" Width="100%"> 
            <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                <div style="float: left; vertical-align: middle;">
                </div>
                <div style="float: left; margin-left:5px;">Data Pasien<asp:TextBox ID="txtPasienId" runat="server" Visible="False" Width="9px"></asp:TextBox></div>
                <div style="float: right; margin-left: 20px;">
                    <asp:Label ID="lblPasien" runat="server"></asp:Label>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlPasien" runat="server" CssClass="collapsePanel" Height="0"  Width="100%">
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
                        <asp:Button ID="btnCek" runat="server" CausesValidation="False" OnClick="btnCek_Click"
                            Text="Cek" UseSubmitBehavior="False" /><asp:RequiredFieldValidator ID="RVNoRM" runat="server" ControlToValidate="txtNoRM" ValidationGroup="MENoRM">*</asp:RequiredFieldValidator>
                        <asp:Label ID="lblCek" runat="server"></asp:Label>
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
                        <asp:TextBox ID="txtJabatanPasien" runat="server" MaxLength="50" Width="350px"></asp:TextBox></td>
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
                        <asp:TextBox ID="txtAlamatKesatuanPasien" runat="server" MaxLength="250" TextMode="MultiLine" Width="350px"></asp:TextBox></td>
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
        </asp:Panel>
        <ajaxToolkit:CollapsiblePanelExtender ID="cpDataPasienDetil" runat="Server" AutoExpand="true" 
                    TargetControlID="pnlPasien"
                    SuppressPostBack="true"/>            
        <asp:Panel ID="pnlRIHeader" runat="server" CssClass="collapsePanelHeader" Width="100%"> 
            <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                <div style="float: left; vertical-align: middle;">
                </div>
                <div style="float: left; margin-left:5px;">Data Kunjungan Rawat Inap</div>
                <div style="float: right; margin-left: 20px;">
                    <asp:Label ID="lblRIHeader" runat="server"></asp:Label>
                </div>
            </div>
        </asp:Panel>                
        <asp:Panel ID="pnlRI" runat="server" CssClass="collapsePanelHeader" Width="100%"> 
            <table class="adminform" id="Table4" border="0" width="100%">
                <tr>
                    <td class="text">
                        Nomor Registrasi</td>
                    <td class="separator">
                        :</td>
                    <td class="value">
                        <asp:UpdatePanel ID="UPNoRegistrasi" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtNoRegistrasi" runat="server" MaxLength="50" Width="181px" ReadOnly="True"></asp:TextBox>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="txtTanggalMasuk" EventName="TextChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="text">
                        Tanggal Masuk</td>
                    <td class="separator">
                        :</td>
                    <td class="value">
                        <asp:TextBox ID="txtTanggalMasuk" runat="server" Width="60px" MaxLength="1" style="text-align:justify" ValidationGroup="MKETanggalMasuk" AutoPostBack="True" OnTextChanged="txtTanggalMasuk_TextChanged" />
                        <asp:ImageButton ID="ImgTanggalMasuk" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" CausesValidation="False" />
                        <asp:RequiredFieldValidator ID="RVTanggalMasuk" runat="server" ControlToValidate="txtTanggalMasuk" >*</asp:RequiredFieldValidator>
                        <ajaxToolkit:MaskedEditExtender ID="MEETanggalMasuk" runat="server"
                            TargetControlID="txtTanggalMasuk"
                            Mask="99/99/9999"
                            MessageValidatorTip="true"
                            OnFocusCssClass="MaskedEditFocus"
                            OnInvalidCssClass="MaskedEditError"
                            MaskType="Date"
                            DisplayMoney="Left"
                            AcceptNegative="Left"
                            ErrorTooltipEnabled="True" ClearTextOnInvalid="True" />
                        <ajaxToolkit:MaskedEditValidator ID="MEVTanggalMasuk" runat="server"
                            ControlExtender="MEETanggalMasuk"
                            ControlToValidate="txtTanggalMasuk"
                            IsValidEmpty="False"
                            EmptyValueMessage="Tanggal Masuk Harus Diisi"
                            InvalidValueMessage="Format Tanggal Salah"
                            Display="Dynamic"
                            TooltipMessage="(Tanggal/Bulan/Tahun)"
                            EmptyValueBlurredText="*"
                            InvalidValueBlurredMessage="Format Tanggal Salah"
                            ValidationGroup="MKETanggalMasuk" />
                        <ajaxToolkit:CalendarExtender ID="CETanggalMasuk" CssClass="MyCalendar" runat="server" TargetControlID="txtTanggalMasuk" PopupButtonID="ImgTanggalMasuk" />
                    </td>
                </tr>
                <tr>
                   <td class="text">
                       Jam Masuk</td>
                   <td class="separator">
                       :</td>
                   <td class="value">
                        <asp:TextBox ID="txtJamMasuk" runat="server" Width="34px" Height="16px" ValidationGroup="MKEJamMasuk" />
                        <asp:RequiredFieldValidator ID="RVJamMasuk" runat="server" ControlToValidate="txtJamMasuk">*</asp:RequiredFieldValidator>
                        <ajaxToolkit:MaskedEditExtender ID="MEEJamMasuk" runat="server"
                            TargetControlID="txtJamMasuk" 
                            Mask="99:99"
                            MessageValidatorTip="true"
                            OnFocusCssClass="MaskedEditFocus"
                            OnInvalidCssClass="MaskedEditError"
                            MaskType="Time"
                            AcceptAMPM="True"
                            ErrorTooltipEnabled="True" ClearTextOnInvalid="True" />
                        <ajaxToolkit:MaskedEditValidator ID="MEVJamMasuk" runat="server"
                            ControlExtender="MEEJamMasuk"
                            ControlToValidate="txtJamMasuk"
                            IsValidEmpty="False"
                            EmptyValueMessage="Jam Masuk Harus diisi"
                            InvalidValueMessage="Format Jam Masuk Salah"
                            Display="Dynamic"
                            TooltipMessage="(Jam:Menit)"
                            EmptyValueBlurredText="*"
                            InvalidValueBlurredMessage="*"
                            ValidationGroup="MKEJamMasuk"/>
                   </td>
               </tr>
               <tr>
                   <td class="text">
                       Kelas</td>
                   <td class="separator">
                       :</td>
                   <td class="value">
                       <asp:DropDownList ID="cmbKelas" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbKelas_SelectedIndexChanged">
                       </asp:DropDownList>
                       <asp:RequiredFieldValidator ID="RVKelas" runat="server" ControlToValidate="cmbKelas">*</asp:RequiredFieldValidator></td>
               </tr>
               <tr>
                   <td class="text">
                       Ruang</td>
                   <td class="separator">
                       :</td>
                   <td class="value">
                        <asp:UpdatePanel ID="UPRuang" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="cmbRuang" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbRuang_SelectedIndexChanged"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RVRuang" runat="server" ControlToValidate="cmbRuang">*</asp:RequiredFieldValidator>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="cmbKelas" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
               </tr>
               <tr>
                   <td class="text">
                       Nomor Kamar/Ruang</td>
                   <td class="separator">
                       :</td>
                   <td class="value">
                       <asp:UpdatePanel ID="UPNomorRuang" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="cmbNomorRuang" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbNomorRuang_SelectedIndexChanged"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RVNomorRuang" runat="server" ControlToValidate="cmbNomorRuang">*</asp:RequiredFieldValidator>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="cmbKelas" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="cmbRuang" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
               </tr>
               <tr>
                   <td class="text">
                       No.Tempat Tidur</td>
                   <td class="separator">
                       :</td>
                   <td class="value">
                       <asp:UpdatePanel ID="UPNomorTempat" runat="server">
                           <ContentTemplate>
                                <asp:DropDownList ID="cmbNomorTempat" runat="server"></asp:DropDownList>
                           </ContentTemplate>
                           <Triggers>
                               <asp:AsyncPostBackTrigger ControlID="cmbKelas" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="cmbRuang" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="cmbNomorRuang" EventName="SelectedIndexChanged" />
                           </Triggers>
                       </asp:UpdatePanel>
                   </td>
               </tr>
               <tr>
                    <td class="text">
                        Rujukan Dari</td>
                    <td class="separator">
                        :</td>
                    <td class="value">
                        <asp:TextBox ID="txtDariRujukan" runat="server" MaxLength="255" TextMode="MultiLine" Width="350px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="text">
                        Dokter Yang Menangani</td>
                    <td class="separator">
                        :</td>
                    <td class="value">
                        <asp:DropDownList ID="cmbDokter" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RVDokter" runat="server" ControlToValidate="cmbDokter">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                
                <tr>
                    <td class="text">
                        Diagnosa Masuk</td>
                    <td class="separator">
                        :</td>
                    <td class="value">
                        <asp:TextBox ID="txtDiagnosaMasuk" runat="server" MaxLength="255" TextMode="MultiLine" Width="350px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="text">Deposit</td>
                    <td class="separator">:</td>
                    <td class="value">
                        <asp:UpdatePanel ID="UPDeposit" runat="server">
                           <ContentTemplate>
                                <asp:TextBox CssClass="money" ID="txtDeposit" runat="server" MaxLength="20" AutoPostBack="True" OnTextChanged="txtDeposit_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDeposit">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="REVDeposit" runat="server" ControlToValidate="txtDeposit" ValidationExpression="^\$?(?:\d+|\d{1,3}(?:.\d{3})*)(?:\,\d{1,2}){0,1}$">Isi dengan bilangan yang benar</asp:RegularExpressionValidator>
                           </ContentTemplate>
                           <Triggers>
                               <asp:AsyncPostBackTrigger ControlID="txtDeposit" EventName="TextChanged" />
                           </Triggers>
                       </asp:UpdatePanel>
                   </td>
                </tr>
                <tr>
                    <td class="text">
                        Penanggung</td>
                    <td class="separator">
                        :</td>
                    <td class="value">
                    <asp:DropDownList ID="cmbJenisPenjamin" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbJenisPenjamin_SelectedIndexChanged">
                    </asp:DropDownList></td>
                </tr>
            </table>
        </asp:Panel>
        <ajaxToolkit:CollapsiblePanelExtender ID="cpRI" runat="Server" AutoExpand="true" TargetControlID="pnlRI" SuppressPostBack="true"/>    
	    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
<TABLE id="tblPenjaminKeluarga" class="adminform" width="100%" border=0 runat="server" visible="false"><TBODY><TR><TH style="BORDER-BOTTOM: orangered 1px solid" align=left colSpan=3>Data Keluarga Penjamin</TH></TR><TR><TD class="text">Nama Lengkap </TD><TD class="separator">:</TD><TD class="value"><asp:TextBox id="txtNamaPenjamin" runat="server" Width="350px" MaxLength="50"></asp:TextBox>&nbsp; <asp:RequiredFieldValidator id="RVNamaPenjamin" runat="server" ControlToValidate="txtNamaPenjamin">*</asp:RequiredFieldValidator></TD></TR><TR><TD class="text">Hubungan dengan Pasien</TD><TD class="separator">:</TD><TD class="value"><asp:DropDownList id="cmbHubungan" runat="server">
                                </asp:DropDownList> <asp:RequiredFieldValidator id="RVHubungan" runat="server" ControlToValidate="cmbHubungan">*</asp:RequiredFieldValidator></TD></TR><TR><TD class="text">Umur</TD><TD class="separator">:</TD><TD class="value"><asp:TextBox id="txtUmurPenjamin" runat="server" Width="350px" MaxLength="50"></asp:TextBox></TD></TR><TR><TD class="text">Alamat</TD><TD class="separator">:</TD><TD class="value"><asp:TextBox id="txtAlamatPenjamin" runat="server" Width="350px" MaxLength="50" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD class="text">Telepon</TD><TD class="separator">:</TD><TD class="value"><asp:TextBox id="txtTeleponPenjamin" runat="server" Width="350px" MaxLength="50"></asp:TextBox></TD></TR><TR><TD class="text">Agama</TD><TD class="separator">:</TD><TD class="value"><asp:DropDownList id="cmbAgamaPenjamin" runat="server">
                            </asp:DropDownList></TD></TR><TR><TD class="text">Pendidikan</TD><TD class="separator">:</TD><TD class="value"><asp:DropDownList id="cmbPendidikanPenjamin" runat="server">
                            </asp:DropDownList></TD></TR><TR><TD class="text">Status</TD><TD class="separator">:</TD><TD class="value"><asp:DropDownList id="cmbStatusPenjamin" runat="server" OnSelectedIndexChanged="cmbStatusPenjamin_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList> <asp:RequiredFieldValidator id="RVStatusPenjamin" runat="server" ControlToValidate="cmbStatusPenjamin">*</asp:RequiredFieldValidator></TD></TR><TR><TD class="text">Pangkat</TD><TD class="separator">:</TD><TD class="value"><asp:UpdatePanel id="UPPangkatPenjamin" runat="server">
                                    <ContentTemplate>
                                <asp:DropDownList ID="cmbPangkatPenjamin" runat="server">
                                </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="cmbStatusPenjamin" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel> </TD></TR><TR><TD class="text">No. KTP</TD><TD class="separator"></TD><TD class="value"><asp:TextBox id="txtNoKTPPenjamin" runat="server" Width="350px" MaxLength="50"></asp:TextBox></TD></TR><TR><TD class="text">Golongan Darah</TD><TD class="separator"></TD><TD class="value"><asp:TextBox id="txtGolDarahPenjamin" runat="server" Width="30px" MaxLength="2"></asp:TextBox></TD></TR><TR><TD class="text">NRP/NIP</TD><TD class="separator">:</TD><TD class="value"><asp:TextBox id="txtNRPPenjamin" runat="server" Width="350px" MaxLength="50"></asp:TextBox></TD></TR><TR><TD class="text">Satuan Kerja</TD><TD class="separator">:</TD><TD class="value"><asp:DropDownList id="cmbSatuanKerjaPenjamin" runat="server" __designer:dtid="2251799813685361" AutoPostBack="false" __designer:wfdid="w5"></asp:DropDownList></TD></TR><TR><TD class="text">Alamat Kesatuan</TD><TD class="separator">:</TD><TD class="value"><asp:TextBox id="txtAlamatKesatuanPenjamin" runat="server" Width="350px" MaxLength="250" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD class="text">Keterangan</TD><TD style="WIDTH: 1px; HEIGHT: 40px" vAlign=top align=left>:</TD><TD class="value"><asp:TextBox id="txtKeteranganPenjamin" runat="server" Width="350px" MaxLength="50" TextMode="MultiLine"></asp:TextBox></TD></TR></TBODY></TABLE>
</ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="cmbJenisPenjamin" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                    <table class="adminform" runat="server" id="tblPenjaminPerusahaan" border="0" width="100%" visible="false">
                        <tr>
                            <th align="left" colspan="3" style="border-bottom: solid 1px OrangeRed">
                                Data Perusahaan/Asuransi Penjamin</th>
                        </tr>
                        <tr>
                            <td class="text">
                                Nama&nbsp; Perusahaan</td>
                            <td class="separator">
                                :</td>
                            <td class="value">
                                <asp:TextBox ID="txtNamaPerusahaan" runat="server" MaxLength="50" Width="350px"></asp:TextBox>&nbsp;
                                <asp:RequiredFieldValidator ID="RVNamaPerusahaan" runat="server" ControlToValidate="txtNamaPerusahaan">*</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td class="text">
                                Nama Kontak</td>
                            <td class="separator">
                                :</td>
                            <td class="value">
                                <asp:TextBox ID="txtNamaKontak" runat="server" MaxLength="50" Width="350px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="text">
                                Alamat Perusahaan</td>
                            <td class="separator">
                                :</td>
                            <td class="value">
                                <asp:TextBox ID="txtAlamatPerusahaan" runat="server" MaxLength="50" TextMode="MultiLine"
                                    Width="350px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="text">
                                Telepon
                            </td>
                            <td class="separator">
                                :</td>
                            <td class="value">
                                <asp:TextBox ID="txtTeleponPerusahaan" runat="server" MaxLength="50" Width="350px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="text">
                                FAX</td>
                            <td class="separator">
                            </td>
                            <td class="value">
                                <asp:TextBox ID="txtFAXPerusahaan" runat="server" MaxLength="50" Width="350px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="text">
                                Keterangan</td>
                            <td class="separator">
                               :</td>
                            <td class="value">
                                <asp:TextBox ID="txtKeteranganPerusahaan" runat="server" MaxLength="50" TextMode="MultiLine"
                                    Width="350px"></asp:TextBox></td>
                        </tr>
                    </table>
            </ContentTemplate>
	        <Triggers>
	            <asp:AsyncPostBackTrigger ControlID="cmbJenisPenjamin" EventName="SelectedIndexChanged" />
	        </Triggers>
        </asp:UpdatePanel>
        <table class="adminheading" width="100%">
		    <tr>
			    <td style="width: 150px" class="menudottedline">
				    &nbsp;</td>
			    <td style="width:50px" class="menudottedline">
				    <asp:linkbutton id="btnSave" OnClick="OnSave" runat="server"></asp:linkbutton>
			    </td>
			    <td style="width:50px" class="menudottedline">
				    <asp:linkbutton id="btnCancel" OnClick="OnCancel" runat="server" CausesValidation="False"></asp:linkbutton>
			    </td>
			    <td class="menudottedline">&nbsp;</td>
		    </tr>
	    </table>  
</asp:Content>

