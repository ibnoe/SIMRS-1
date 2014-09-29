<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditRegistrasiRI.ascx.cs" Inherits="Backoffice_Controls_EditRegistrasiRI" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:HiddenField ID="HFRawatInapId" runat="server" />
<asp:HiddenField ID="HFTempatInapId" runat="server" />
<asp:HiddenField ID="HFPasienId" runat="server" />
<asp:HiddenField ID="HFStatusRawatInap" runat="server" />
<asp:HiddenField ID="HFPenjaminId" runat="server" />
<asp:HiddenField ID="HFRegistrasiId" runat="server" />
        <asp:Panel ID="pnlRIHeader" runat="server" CssClass="collapsePanelHeader" Width="100%"> 
            <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                <div style="float: left; vertical-align: middle;">
                </div>
                <div style="float: left; margin-left:5px;">Data Kunjungan Rawat Inap<asp:TextBox ID="TextBox1" runat="server" Visible="False" Width="9px"></asp:TextBox></div>
                <div style="float: left; margin-left: 20px; width:120px; text-align:right;">Nomor Kunjungan:</div>
                <div style="float: left; margin-left:5px; color:Yellow; width:150px;">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblNoRegistrasi" runat="server"></asp:Label>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="txtTanggalMasuk" EventName="TextChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                <div style="float: right; margin-left: 20px;">
                    <asp:Label ID="lblRIHeader" runat="server"></asp:Label>
                </div>
            </div>
        </asp:Panel>                
        <asp:Panel ID="pnlRI" runat="server" CssClass="collapsePanelHeader" Width="100%"> 
            <table class="adminform" id="Table4" border="0" width="100%">
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
                        <asp:Label ID="lblNoRM" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td class="text">
                        Nama Pasien</td>
                    <td class="separator">
                        :</td>
                    <td class="value">
                        <asp:Label ID="lblNamaPasien" runat="server" Text="Label"></asp:Label></td>
                </tr>
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
                        <asp:TextBox ID="txtTanggalMasuk" runat="server" Width="60px" MaxLength="1" style="text-align:justify" ValidationGroup="MKETanggalMasuk" OnTextChanged="txtTanggalMasuk_TextChanged" AutoPostBack="True" />
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
                        <asp:TextBox ID="txtDariRujukan" runat="server" MaxLength="255" TextMode="MultiLine" Width="350px"></asp:TextBox></td>
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
                <%--<tr>
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
                </tr>--%>
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
                                Jabatan</td>
                            <td class="separator">
                                :</td>
                            <td class="value">
                                <asp:TextBox ID="txtJabatanPenjamin" runat="server" MaxLength="50" Width="350px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="text">
                                Satuan Kerja</td>
                            <td class="separator">
                                :</td>
                            <td class="value">
                                <asp:DropDownList ID="cmbSatuanKerjaPenjamin" runat="server" AutoPostBack="false">
                                </asp:DropDownList></td>
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