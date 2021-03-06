<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="RJAddBaru.aspx.cs" Inherits="Backoffice_Registrasi_RJAddBaru" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1"  EnableScriptGlobalization="true" EnableScriptLocalization="true" />
        <table class="adminheading" width="100%" id="Table3">
            <tr>
	            <th class="menudottedline">
                    <%= Resources.GetString("RS","TitleRawatJalanAddRegistrasi") %>
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
                            Text="Cek" UseSubmitBehavior="False" />
                        <asp:RequiredFieldValidator ID="RVNoRM" runat="server" ControlToValidate="txtNoRM" ValidationGroup="MENoRM">*</asp:RequiredFieldValidator>&nbsp;
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
        <asp:Panel ID="pnlRJHeader" runat="server" CssClass="collapsePanelHeader" Width="100%"> 
            <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                <div style="float: left; vertical-align: middle;">
                </div>
                <div style="float: left; margin-left:5px;">Data Kunjungan Rawat Jalan<asp:TextBox ID="TextBox1" runat="server" Visible="False" Width="9px"></asp:TextBox></div>
                <div style="float: left; margin-left: 20px; width:120px; text-align:right;">Nomor Kunjungan:</div>
                <div style="float: left; margin-left:5px; color:Yellow; width:150px;">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblNoRegistrasi" runat="server"></asp:Label>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="cmbPoliklinik" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                <div style="float: right; margin-left: 20px;">
                    <asp:Label ID="lblRJHeader" runat="server"></asp:Label>
                </div>
            </div>
        </asp:Panel>                
        <asp:Panel ID="pnlRJ" runat="server" CssClass="collapsePanelHeader" Width="100%"> 
            <table class="adminform" id="Table4" border="0" width="100%">
                <tr>
                    <td class="text">
                    Nomor Kunjungan</td>
                    <td class="separator">
                        :</td>
                    <td class="value">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                    <asp:TextBox ID="txtNoRegistrasi" runat="server" MaxLength="50" Width="350px" ReadOnly="True"></asp:TextBox>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="cmbPoliklinik" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="text">
                        Tanggal Berobat</td>
                    <td class="separator">
                        :</td>
                    <td class="value">
                        <asp:TextBox ID="txtTanggalRegistrasi" runat="server" Width="75px" MaxLength="1" style="text-align:justify" ValidationGroup="MKE" OnTextChanged="txtTanggalRegistrasi_TextChanged" AutoPostBack="True" />
                        <asp:ImageButton ID="ImgTanggalRegistrasi" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" CausesValidation="False" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTanggalRegistrasi" Width="20px">*</asp:RequiredFieldValidator>
                        <ajaxToolkit:MaskedEditExtender ID="MEETanggalRegistrasi" runat="server"
                            TargetControlID="txtTanggalRegistrasi"
                            Mask="99/99/9999"
                            MessageValidatorTip="true"
                            OnFocusCssClass="MaskedEditFocus"
                            OnInvalidCssClass="MaskedEditError"
                            MaskType="Date"
                            DisplayMoney="Left"
                            AcceptNegative="Left"
                            ErrorTooltipEnabled="True" />
                        <ajaxToolkit:MaskedEditValidator ID="MEVTanggalRegistrasi" runat="server"
                            ControlExtender="MEETanggalRegistrasi"
                            ControlToValidate="txtTanggalRegistrasi"
                            EmptyValueMessage="Tanggal Lahir Harus Diisi"
                            InvalidValueMessage="Format Tanggal Salah"
                            Display="Dynamic"
                            TooltipMessage="(Tanggal/Bulan/Tahun)"
                            EmptyValueBlurredText="*"
                            InvalidValueBlurredMessage="Format Tanggal Salah"
                            ValidationGroup="MKE" />
                        <ajaxToolkit:CalendarExtender ID="CETanggalRegistrasi" CssClass="MyCalendar" runat="server" TargetControlID="txtTanggalRegistrasi" PopupButtonID="ImgTanggalRegistrasi" />
                    </td>
                </tr>
                <tr>
                    <td class="text">
                        Poliklinik Tujuan</td>
                    <td class="separator">
                        :</td>
                    <td class="value">
                        <asp:DropDownList ID="cmbPoliklinik" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbPoliklinik_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RVPoliklinik" runat="server" ControlToValidate="cmbPoliklinik" Width="10px">*</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="text">
                        Dokter</td>
                    <td class="separator">
                        :</td>
                    <td class="value">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="cmbDokter" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbDokter_SelectedIndexChanged"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RVDokter" runat="server" ControlToValidate="cmbDokter" Width="12px">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtJamPraktek" runat="server" Visible="False" Width="2px"></asp:TextBox>
                                <asp:TextBox ID="txtDokterId" runat="server" Visible="False" Width="2px"></asp:TextBox>
                                <asp:TextBox ID="txtHari" runat="server" Visible="False" Width="2px"></asp:TextBox>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="cmbPoliklinik" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="txtTanggalRegistrasi" EventName="TextChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="text">
                        Nomor Tunggu</td>
                    <td class="separator">
                        :</td>
                    <td class="value">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                        <asp:TextBox ID="txtNomorTunggu" runat="server" MaxLength="50" Width="46px" ReadOnly="True"></asp:TextBox>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="cmbPoliklinik" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="cmbDokter" EventName="SelectedIndexChanged" />
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
        <ajaxToolkit:CollapsiblePanelExtender ID="cpRJ" runat="Server" AutoExpand="true" TargetControlID="pnlRJ" SuppressPostBack="true"/>    
	    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                    <table class="adminform" runat="server" id="tblPenjaminKeluarga" border="0" width="100%" visible="false">
                        <tr>
                            <th align="left" colspan="3" style="border-bottom: solid 1px OrangeRed">
                                Data Keluarga Penjamin</th>
                        </tr>
                        <tr>
                            <td class="text">
                                Nama Lengkap
                            </td>
                            <td class="separator">
                                :</td>
                            <td class="value">
                                <asp:TextBox ID="txtNamaPenjamin" runat="server" MaxLength="50" Width="350px"></asp:TextBox>&nbsp;
                                <asp:RequiredFieldValidator ID="RVNamaPenjamin" runat="server" ControlToValidate="txtNamaPenjamin">*</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td class="text">
                                Hubungan dengan Pasien</td>
                            <td class="separator">
                                :</td>
                            <td class="value">
                                <asp:DropDownList ID="cmbHubungan" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RVHubungan" runat="server" ControlToValidate="cmbHubungan">*</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td class="text">
                                Umur</td>
                            <td class="separator">
                                :</td>
                            <td class="value">
                                <asp:TextBox ID="txtUmurPenjamin" runat="server" MaxLength="50" Width="350px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="text">
                                Alamat</td>
                            <td class="separator">
                                :</td>
                            <td class="value">
                                <asp:TextBox ID="txtAlamatPenjamin" runat="server" MaxLength="50" TextMode="MultiLine" Width="350px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="text">
                                Telepon</td>
                            <td class="separator">
                                :</td>
                            <td class="value">
                                <asp:TextBox ID="txtTeleponPenjamin" runat="server" MaxLength="50" Width="350px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="text">
                                Agama</td>
                            <td class="separator">
                                :</td>
                            <td class="value"><asp:DropDownList ID="cmbAgamaPenjamin" runat="server">
                            </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="text">
                                Pendidikan</td>
                            <td class="separator">
                                :</td>
                            <td class="value"><asp:DropDownList ID="cmbPendidikanPenjamin" runat="server">
                            </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="text">
                                Status</td>
                            <td class="separator">
                                :</td>
                            <td class="value">
                                <asp:DropDownList ID="cmbStatusPenjamin" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbStatusPenjamin_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RVStatusPenjamin" runat="server" ControlToValidate="cmbStatusPenjamin">*</asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td class="text">
                                Pangkat</td>
                            <td class="separator">
                                :</td>
                            <td class="value">
                                <asp:UpdatePanel ID="UPPangkatPenjamin" runat="server">
                                    <ContentTemplate>
                                <asp:DropDownList ID="cmbPangkatPenjamin" runat="server">
                                </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="cmbStatusPenjamin" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="text">
                                No. KTP</td>
                            <td class="separator">
                            </td>
                            <td class="value">
                                <asp:TextBox ID="txtNoKTPPenjamin" runat="server" MaxLength="50" Width="350px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="text">
                                Golongan Darah</td>
                            <td class="separator">
                            </td>
                            <td class="value">
                                <asp:TextBox ID="txtGolDarahPenjamin" runat="server" MaxLength="2" Width="30px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="text">
                                NRP/NIP</td>
                            <td class="separator">
                                :</td>
                            <td class="value">
                                <asp:TextBox ID="txtNRPPenjamin" runat="server" MaxLength="50" Width="350px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="text">
                                Satuan Kerja</td>
                            <td class="separator">
                                :</td>
                            <td class="value">
                                <asp:DropDownList ID="cmbSatuanKerjaPenjamin" runat="server" AutoPostBack="false">
                        </asp:DropDownList>
                                </td>
                        </tr>
                        <tr>
                            <td class="text">
                                Alamat Kesatuan</td>
                            <td class="separator">
                                :</td>
                            <td class="value">
                                <asp:TextBox ID="txtAlamatKesatuanPenjamin" runat="server" MaxLength="250" TextMode="MultiLine" Width="350px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="text">
                                Keterangan</td>
                            <td align="left" style="width: 1px; height: 40px;" valign="top">
                                :</td>
                            <td class="value">
                                <asp:TextBox ID="txtKeteranganPenjamin" runat="server" MaxLength="50" TextMode="MultiLine" Width="350px"></asp:TextBox></td>
                        </tr>
                    </table>
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

