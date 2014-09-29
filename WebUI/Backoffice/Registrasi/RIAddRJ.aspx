<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="RIAddRJ.aspx.cs" Inherits="Backoffice_RawatInap_RIAddRJ" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <table class="adminheading" width="100%" id="Table3">
            <tr>
	            <th class="menudottedline">
                    <%= Resources.GetString("RS", "TitleRegistrasiAddRI")%>
	            </th>
	            <td class="menudottedline" align="right">&nbsp;
	            </td>
            </tr>
        </table>
        <div id="divSearch" runat="server">
        <asp:UpdatePanel ID="UPSeach" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlSearchHeader" runat="server" CssClass="collapsePanelHeader"  Width="100%"> 
                    <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                        <div style="float: left; vertical-align: middle;">
                            <asp:ImageButton ID="imgSearch" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="(Show Details...)"/>
                        </div>
                        <div style="float: left; margin-left:5px;">Pencarian Data Pasien</div>
                        <div style="float: right; margin-left: 20px; text-align:right">
                            <asp:Label ID="lblSearch" runat="server">(Show Details...)</asp:Label>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlSearch" runat="server" CssClass="collapsePanel" Height="0"  Width="100%">
                    <table class="adminform"  runat="server" id="tblpnlSearchHeader">
                        <tr>
                            <td>
                                Tanggal Kunjungan:
                                <asp:TextBox ID="txtTanggalRegistrasi" runat="server" Width="75px" MaxLength="1" style="text-align:justify" ValidationGroup="MKE" />
                                <asp:ImageButton ID="ImgTanggalRegistrasi" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" CausesValidation="False" />
                                <ajaxToolkit:MaskedEditExtender ID="MEETanggalRegistrasi" runat="server"
                                    TargetControlID="txtTanggalRegistrasi"
                                    Mask="99/99/9999"
                                    MessageValidatorTip="true"
                                    OnFocusCssClass="MaskedEditFocus"
                                    OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date"
                                    DisplayMoney="Left"
                                    AcceptNegative="Left"
                                    ErrorTooltipEnabled="True" ClearTextOnInvalid="True" />
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
                                Nomor RM:
                                <asp:TextBox ID="txtNoRMSearch" runat="server" AutoPostBack="true" OnTextChanged="txtNoRMSearch_TextChanged"></asp:TextBox>
                                Nama Pasien:
                                <asp:TextBox ID="txtNamaSearch" runat="server" AutoPostBack="true" OnTextChanged="txtNamaSearch_TextChanged"></asp:TextBox>
                                NRP:
                                <asp:TextBox ID="txtNRPSearch" runat="server" AutoPostBack="true" OnTextChanged="txtNRPSearch_TextChanged"></asp:TextBox>
                                <asp:Button ID="btnSearch" CssClass="button" runat="server" CausesValidation="False" OnClick="btnSearch_Click" Text="Cari" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GridViewPasien" CssClass="DataGridList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    DataKeyNames="RawatJalanId" OnSelectedIndexChanged="GridViewPasien_SelectedIndexChanged" Width="100%" OnPageIndexChanging="GridViewPasien_PageIndexChanging">
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <Columns>
                                        <asp:TemplateField SortExpression="TanggalRegistrasi" HeaderText="Tanggal Kunjungan" ShowHeader="False">
                                        <ItemStyle Width="60px" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbTanggalRegistrasi" Text='<%# Eval("TanggalRegistrasi").ToString() != "" ? ((DateTime)Eval("TanggalRegistrasi")).ToString("dd/MM/yyyy"): "" %>' runat="server" CausesValidation="false" CommandName="Select" Width="100%"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="NoRegistrasi" HeaderText="Nomor Kunjungan" ShowHeader="False">
                                        <ItemStyle Width="100px" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbNoRegistrasi" Text='<%# Eval("NoRegistrasi") %>' runat="server" CausesValidation="false" CommandName="Select" Width="100%"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="NoRM" HeaderText="Nomor RM" ShowHeader="False">
                                        <ItemStyle Width="75px" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbNoRM" Text='<%# Eval("NoRM") %>' runat="server" CausesValidation="false" CommandName="Select" Width="100%"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Nama" HeaderText="Nama Pasien" ShowHeader="False">
                                        <ItemStyle Width="120px" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbNama" Text='<%# Eval("Nama") %>' runat="server" CausesValidation="false" CommandName="Select" Width="100%"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="NRP" HeaderText="NRP" ShowHeader="False">
                                        <ItemStyle Width="100px" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbNRP" Text='<%# Eval("NRP") %>' runat="server" CausesValidation="false" CommandName="Select" Width="100%"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Umur" HeaderText="Umur" ShowHeader="False">
                                        <ItemStyle Width="40px" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbUmur" Text='<%# Eval("Umur") %>' runat="server" CausesValidation="false" CommandName="Select" Width="100%"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="PoliklinikNama" HeaderText="Poliklinik Tujuan" ShowHeader="False">
                                        <ItemStyle Width="120px" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbPoliklinikNama" Text='<%# Eval("PoliklinikNama") %>' runat="server" CausesValidation="false" CommandName="Select" Width="100%"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="DokterNama" HeaderText="Dokter" ShowHeader="False">
                                        <ItemStyle Width="100px" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbDokterNama" Text='<%# Eval("DokterNama") %>' runat="server" CausesValidation="false" CommandName="Select" Width="100%"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="Alamat" HeaderText="Alamat" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAlamat"  Text='<%# Eval("Alamat") %>' runat="server" ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div style="color:Red;">
                                            <strong>Data Pasien Tidak Ditemukan</strong>
                                        </div>
                                    </EmptyDataTemplate>
                                    <RowStyle CssClass="ItemStyle" />
                                    <SelectedRowStyle CssClass="SelectedItemStyle" />
								    <AlternatingRowStyle CssClass="AlternatingItemStyle" />
								    <RowStyle CssClass="ItemStyle" />
								    <HeaderStyle CssClass="HeaderStyle" /> 
								    <FooterStyle CssClass="FooterSytle" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <ajaxToolkit:CollapsiblePanelExtender ID="cpSearch" runat="Server"
                    TargetControlID="pnlSearch"
                    ExpandControlID="pnlSearchHeader"
                    CollapseControlID="pnlSearchHeader" 
                    Collapsed="false"
                    TextLabelID="lblSearch"
                    ImageControlID="imgSearch"    
                    ExpandedText="(Hide Details...)"
                    CollapsedText="(Show Details...)"
                    ExpandedImage="../../images/collapse_blue.jpg"
                    CollapsedImage="../../images/expand_blue.jpg"
                    SuppressPostBack="true"/>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
        <div id="divDataPasien" runat="server">
        <asp:UpdatePanel ID="UPPasien" runat="server">
            <ContentTemplate>
<asp:Panel id="pnlPasienHeader" runat="server" Width="100%" CssClass="collapsePanelHeader"> 
                    <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                        <div style="float: left; vertical-align: middle;">
                            <asp:ImageButton ID="imgPasien" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="(Show Details...)"/>
                        </div>
                        <div style="float: left; margin-left:5px;">Data Pasien<asp:TextBox ID="txtPasienId" runat="server" Visible="False" Width="9px"></asp:TextBox></div>
                        <div style="float: left; margin-left: 20px; width:120px; text-align:right;">Nomor Rekam Medis:</div>
                        <div style="float: left; margin-left:5px; color:Yellow; width:150px;"><asp:Label ID="lblNoRMHeader" runat="server"></asp:Label></div>
                        <div style="float: left; margin-left:5px; width:75px; text-align:right;">Nama Pasien:</div>
                        <div style="float: left; margin-left:5px; color:Yellow; width:150px;"><asp:Label ID="lblNamaPasienHeader" runat="server"></asp:Label></div>
                        <div style="float: right; margin-left: 20px;">
                            <asp:Label ID="lblPasien" runat="server">(Show Details...)</asp:Label>
                        </div>
                    </div>
                </asp:Panel> <asp:Panel id="pnlPasien" runat="server" Width="100%" CssClass="collapsePanel" Height="0"><TABLE id="Table1" class="adminform" width="100%" border=0><TBODY><TR><TD style="WIDTH: 50%"><TABLE><TBODY><TR><TD class="text">Nomor Rekam Medis</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblNoRM" runat="server"></asp:Label></TD></TR><TR><TD class="text">Nama Pasien</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblNamaPasien" runat="server"></asp:Label></TD></TR><TR><TD class="text">Status</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblStatus" runat="server"></asp:Label></TD></TR><TR><TD class="text">Pangkat</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblPangkat" runat="server"></asp:Label></TD></TR><TR><TD class="text">No ASKES</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblNoAskes" runat="server"></asp:Label></TD></TR><TR><TD class="text">No KTP</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblNoKTP" runat="server"></asp:Label></TD></TR><TR><TD class="text">Golongan Darah</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblGolDarah" runat="server"></asp:Label></TD></TR><TR><TD class="text">NRP</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblNRP" runat="server"></asp:Label></TD></TR><TR><TD class="text">Satuan Kerja</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblKesatuan" runat="server"></asp:Label></TD></TR><TR><TD class="text">Tempat/Tanggal Lahir</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblTempatLahir" runat="server"></asp:Label>/<asp:Label id="lblTanggalLahir" runat="server"></asp:Label></TD></TR></TBODY></TABLE></TD><TD style="WIDTH: 50%"><TABLE><TBODY><TR><TD class="text">Alamat</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblAlamat" runat="server"></asp:Label></TD></TR><TR><TD class="text">Telepon</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblTelepon" runat="server"></asp:Label></TD></TR><TR><TD class="text">Jenis Kelamin</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblJenisKelamin" runat="server"></asp:Label></TD></TR><TR><TD class="text">Status Perkawinan</TD><TD style="WIDTH: 1px" vAlign=top align=left>:</TD><TD class="value"><asp:Label id="lblStatusPerkawinan" runat="server"></asp:Label></TD></TR><TR><TD class="text">Agama</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblAgama" runat="server"></asp:Label></TD></TR><TR><TD class="text">Pendidikan</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblPendidikan" runat="server"></asp:Label></TD></TR><TR><TD class="text">Pekerjaan</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblPekerjaan" runat="server"></asp:Label></TD></TR><TR><TD class="text">Alamat Kantor</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblAlamatKantor" runat="server"></asp:Label></TD></TR><TR><TD class="text">No Tlp Kantor</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblTeleponKantor" runat="server"></asp:Label></TD></TR><TR><TD class="text">Keterangan</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblKeterangan" runat="server"></asp:Label></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></asp:Panel> <ajaxToolkit:CollapsiblePanelExtender id="CPPasien" runat="Server" SuppressPostBack="true" CollapsedImage="../../images/expand_blue.jpg" ExpandedImage="../../images/collapse_blue.jpg" CollapsedText="(Show Details...)" ExpandedText="(Hide Details...)" ImageControlID="imgPasien" TextLabelID="lblPasien" Collapsed="false" CollapseControlID="pnlPasienHeader" ExpandControlID="pnlPasienHeader" TargetControlID="pnlPasien"></ajaxToolkit:CollapsiblePanelExtender> <asp:Panel id="pnlRJHeader" runat="server" Width="100%" CssClass="collapsePanelHeader"> 
                    <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                        <div style="float: left; vertical-align: middle;">
                            <asp:ImageButton ID="imgRJ" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="(Show Details...)"/>
                        </div>
                        <div style="float: left; margin-left:5px;">Data Kunjungan Rawat Jalan<asp:TextBox ID="txtRawatJalanId" runat="server" Visible="False" Width="9px"></asp:TextBox></div>
                        <div style="float: left; margin-left: 20px; width:120px; text-align:right;">Nomor Kunjungan:</div>
                        <div style="float: left; margin-left:5px; color:Yellow; width:150px;">
                            <asp:Label ID="lblNoRegistrasiHeader" runat="server"></asp:Label></div>
                        <div style="float: right; margin-left: 20px;">
                            <asp:Label ID="lblRJ" runat="server">(Show Details...)</asp:Label>
                        </div>
                    </div>
                </asp:Panel> <asp:Panel id="pnlRJ" runat="server" Width="100%" CssClass="collapsePanelHeader"><TABLE id="Table2" class="adminform" width="100%" border=0><TBODY><TR><TD class="text">Nomor Kunjungan</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 1px">:</TD><TD class="value"><asp:Label id="lblNoRegistrasi" runat="server"></asp:Label></TD></TR><TR><TD class="text">Tanggal Kunjungan</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 1px">:</TD><TD class="value"><asp:Label id="lblTanggalBerobat" runat="server"></asp:Label></TD></TR><TR><TD class="text">Poliklinik Tujuan</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 1px">:</TD><TD class="value"><asp:Label id="lblPoliklinik" runat="server"></asp:Label></TD></TR><TR><TD class="text">Dokter</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 1px">:</TD><TD class="value"><asp:Label id="lblDokter" runat="server"></asp:Label></TD></TR><TR><TD class="text">Nomor Tunggu</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 1px">:</TD><TD class="value"><asp:Label id="lblNoTunggu" runat="server"></asp:Label></TD></TR><TR><TD class="text">Penanggung</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 1px">:</TD><TD class="value"><asp:Label id="lblJenisPenjaminNama" runat="server"></asp:Label> <asp:Label id="lblJenisPenjaminId" runat="server" Visible="false"></asp:Label> <asp:Label id="lblPenjaminId" runat="server" Visible="false"></asp:Label> </TD></TR></TBODY></TABLE><TABLE id="tblPenjaminKeluargaView" class="adminform" width="100%" border=0 runat="server" visible="false"><TBODY><TR><TH colSpan=3>Data Keluarga Penjamin</TH></TR><TR><TD class="text">Nama </TD><TD style="VERTICAL-ALIGN: top; WIDTH: 1px">:</TD><TD style="VERTICAL-ALIGN: top; TEXT-ALIGN: left" align=left><asp:Label id="lblNamaPenjamin" runat="server"></asp:Label></TD></TR><TR><TD class="text">Hubungan dengan Pasien</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 1px">:</TD><TD style="VERTICAL-ALIGN: top; TEXT-ALIGN: left" align=left><asp:Label id="lblHubunganNama" runat="server"></asp:Label></TD></TR><TR><TD class="text">Status</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 1px">:</TD><TD style="VERTICAL-ALIGN: top; TEXT-ALIGN: left" align=left><asp:Label id="lblStatusPenjaminNama" runat="server"></asp:Label></TD></TR><TR><TD class="text">Pangkat</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 1px">:</TD><TD style="VERTICAL-ALIGN: top; TEXT-ALIGN: left" align=left><asp:Label id="lblPangkatPenjaminNama" runat="server"></asp:Label></TD></TR><TR><TD class="text">No. KTP</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 1px">:</TD><TD style="VERTICAL-ALIGN: top; TEXT-ALIGN: left" align=left><asp:Label id="lblNoKTPPenjamin" runat="server"></asp:Label></TD></TR><TR><TD class="text">Golongan Darah</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 1px">:</TD><TD style="VERTICAL-ALIGN: top; TEXT-ALIGN: left" align=left><asp:Label id="lblGolDarahPenjamin" runat="server"></asp:Label></TD></TR><TR><TD class="text">NRP/NIP</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 1px">:</TD><TD style="VERTICAL-ALIGN: top; TEXT-ALIGN: left" align=left><asp:Label id="lblNRPPenjamin" runat="server"></asp:Label></TD></TR><TR><TD class="text">Satuan Kerja</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 1px">:</TD><TD style="VERTICAL-ALIGN: top; TEXT-ALIGN: left" align=left><asp:Label id="lblKesatuanPenjamin" runat="server"></asp:Label></TD></TR><TR><TD class="text">Alamat</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 1px">:</TD><TD style="VERTICAL-ALIGN: top; TEXT-ALIGN: left" align=left><asp:Label id="lblAlamatPenjamin" runat="server"></asp:Label></TD></TR><TR><TD class="text">No Tlp yang bisa dihubungi</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 1px">:</TD><TD style="VERTICAL-ALIGN: top; TEXT-ALIGN: left" align=left><asp:Label id="lblTeleponPenjamin" runat="server"></asp:Label></TD></TR><TR><TD class="text">Keterangan</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 1px">:</TD><TD style="VERTICAL-ALIGN: top; TEXT-ALIGN: left" align=left><asp:Label id="lblKeteranganPenjamin" runat="server"></asp:Label></TD></TR></TBODY></TABLE><TABLE id="tblPenjaminPerusahaanView" class="adminform" width="100%" border=0 runat="server" visible="false"><TBODY><TR><TH colSpan=3>Data Perusahaan Penjamin</TH></TR><TR><TD class="text">Nama Perusahaan</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 1px">:</TD><TD class="value"><asp:Label id="lblNamaPerusahan" runat="server"></asp:Label></TD></TR><TR><TD class="text">Nama Kontak</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 1px">:</TD><TD class="value"><asp:Label id="lblNamaKontak" runat="server"></asp:Label></TD></TR><TR><TD class="text">Alamat Perusahaan</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 1px">:</TD><TD class="value"><asp:Label id="lblAlamatPerusahaan" runat="server"></asp:Label></TD></TR><TR><TD class="text">Telepon </TD><TD style="VERTICAL-ALIGN: top; WIDTH: 1px">:</TD><TD class="value"><asp:Label id="lblTeleponPerusahaan" runat="server"></asp:Label></TD></TR><TR><TD class="text">FAX</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 1px">:</TD><TD class="value"><asp:Label id="lblFaxPerusahaan" runat="server"></asp:Label></TD></TR><TR><TD class="text">Keterangan</TD><TD style="VERTICAL-ALIGN: top; WIDTH: 1px">:</TD><TD class="value"><asp:Label id="lblKeteranganPerusahaan" runat="server"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel> <ajaxToolkit:CollapsiblePanelExtender id="cpRJ" runat="Server" SuppressPostBack="true" CollapsedImage="../../images/expand_blue.jpg" ExpandedImage="../../images/collapse_blue.jpg" CollapsedText="(Show Details...)" ExpandedText="(Hide Details...)" ImageControlID="imgRJ" TextLabelID="lblRJ" Collapsed="true" CollapseControlID="pnlRJHeader" ExpandControlID="pnlRJHeader" TargetControlID="pnlRJ"></ajaxToolkit:CollapsiblePanelExtender> 
</ContentTemplate>
            <Triggers>
<asp:AsyncPostBackTrigger ControlID="GridViewPasien" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</Triggers>
        </asp:UpdatePanel>
        </div>
        
        
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
        
                <asp:Panel ID="pnlRIHeader" runat="server" CssClass="collapsePanelHeader" Width="100%">
                    <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                        <div style="float: left; vertical-align: middle;">
                        </div>
                        <div style="float: left; margin-left:5px;">Data Registrasi Rawat Inap</div>
                        <div style="float: right; margin-left: 20px; text-align:right">
                            <asp:Label ID="lblRI" runat="server"></asp:Label>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlRI" runat="server" CssClass="collapsePanel" Height="0"  Width="100%">
                   <table class="adminform" id="Table4" border="0" width="100%">
                        <tr>
                            <td align="left" colspan="3">
                                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                <asp:ValidationSummary id="ValidationSummary1" runat="server" DisplayMode="SingleParagraph" HeaderText="Tanda * harus diisi atau dipilih!"></asp:ValidationSummary></td>
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
                               <asp:DropDownList ID="cmbRuang" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbRuang_SelectedIndexChanged">
                               </asp:DropDownList>
                               <asp:RequiredFieldValidator ID="RVRuang" runat="server" ControlToValidate="cmbRuang">*</asp:RequiredFieldValidator></td>
                       </tr>
                       <tr>
                           <td class="text">
                               Nomor Kamar/Ruang</td>
                           <td class="separator">
                               :</td>
                           <td class="value">
                               <asp:DropDownList ID="cmbNomorRuang" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbNomorRuang_SelectedIndexChanged">
                               </asp:DropDownList>
                               <asp:RequiredFieldValidator ID="RVNomorRuang" runat="server" ControlToValidate="cmbNomorRuang">*</asp:RequiredFieldValidator></td>
                       </tr>
                       <tr>
                           <td class="text">
                               No.Tempat Tidur</td>
                           <td class="separator">
                               :</td>
                           <td class="value">
                               <asp:DropDownList ID="cmbNomorTempat" runat="server">
                               </asp:DropDownList>
                           </td>
                       </tr>
                       <tr>
                            <td class="text">
                                Dari Poliklinik</td>
                            <td class="separator">
                                :</td>
                            <td class="value">
                                <asp:Label ID="lblDariPoliklinik" runat="server"></asp:Label>
                                <asp:Label ID="lblDariPoliklinikId" Visible="false" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
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
                                <asp:TextBox ID="txtDiagnosaMasuk" runat="server" MaxLength="255" TextMode="MultiLine"
                                    Width="360px"></asp:TextBox></td>
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
                    </table>
                </asp:Panel> 
                <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="Server"
                            TargetControlID="pnlRI"
                            SuppressPostBack="true"/>
                                
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridViewPasien" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        
        <table class="adminheading" id="Table5" width="100%">
	        <tr>
		        <td class="menudottedline" style="width: 150px; height: 26px;">
			        &nbsp;</td>
		        <td style="width:50px; height: 26px;" class="menudottedline" align="left">
			        <div class="toolbar" onmouseover="MM_swapImage('save','','../../../images/save_f2.gif',1);"
				        onmouseout="MM_swapImgRestore();">
				        <asp:linkbutton id="btnSave" OnClick="OnSave" runat="server"></asp:linkbutton></div>
		        </td>
		        <td style="width:50px; height: 26px;" class="menudottedline" align="left">
			        <div class="toolbar" onmouseover="MM_swapImage('cancel','','../../../images/cancel_f2.gif',1);"
				        onmouseout="MM_swapImgRestore();"><asp:linkbutton id="btnCancel" OnClick="OnCancel" runat="server" CausesValidation="False"></asp:linkbutton></div>
		        </td>
		        <td class="menudottedline" style="height: 26px">&nbsp;</td>
	        </tr>
        </table>   
    
</asp:Content>
