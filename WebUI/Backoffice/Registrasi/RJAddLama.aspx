<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="RJAddLama.aspx.cs" Inherits="Backoffice_Registrasi_RJAddLama" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
    <table class="adminheading" width="100%" id="Table3">
        <tr>
            <th class="menudottedline">
                <%= Resources.GetString("RS","TitleRawatJalanAddRegistrasi") %>
            </th>
            <td class="menudottedline" align="right">&nbsp;
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UPSeachPasien" runat="server">
        <ContentTemplate>
<asp:Panel id="pnlSearchHeader" runat="server" Width="100%" CssClass="collapsePanelHeader"> 
                <div style="padding:5px; cursor: pointer; vertical-align: middle;">
                    <div style="float: left; vertical-align: middle;">
                        <asp:ImageButton ID="imgSearch" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="(Show Details...)"/>
                    </div>
                    <div style="float: left; margin-left:5px;">Pencarian Data Pasien</div>
                    <div style="float: right; margin-left: 20px; text-align:right">
                        <asp:Label ID="lblSearch" runat="server">(Show Details...)</asp:Label>
                    </div>
                </div>
            </asp:Panel> <asp:Panel id="pnlSearch" runat="server" Width="100%" CssClass="collapsePanel" Height="0"><TABLE id="tblpnlSearchPasien" class="adminform" runat="server"><TBODY><TR><TD><TABLE><TBODY><TR><TD style="WIDTH: 70px; TEXT-ALIGN: right">Nomor RM:</TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:TextBox id="txtNoRMSearch" runat="server"></asp:TextBox></TD><TD style="WIDTH: 70px; TEXT-ALIGN: right">Nama Pasien:</TD><TD style="WIDTH: 100px; TEXT-ALIGN: left"><asp:TextBox id="txtNamaSearch" runat="server"></asp:TextBox></TD><TD style="TEXT-ALIGN: left">&nbsp;NRP:&nbsp;<asp:TextBox id="txtNRP" runat="server"></asp:TextBox></TD><TD style="TEXT-ALIGN: left"><asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" CausesValidation="False" Text="Cari"></asp:Button> </TD></TR></TBODY></TABLE></TD></TR><TR><TD><asp:GridView id="GridViewPasien" runat="server" Width="100%" CssClass="DataGridList" OnPageIndexChanging="GridViewPasien_PageIndexChanging" OnSelectedIndexChanged="GridViewPasien_SelectedIndexChanged" DataKeyNames="PasienId" AutoGenerateColumns="False" AllowPaging="True">
                                <Columns>
                                    <asp:TemplateField SortExpression="Nomor RM" HeaderText="Nomor RM" ShowHeader="False">
                                        <ItemStyle Width="100px" />
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
                                    <asp:TemplateField SortExpression="Alamat" HeaderText="Alamat" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAlamat"  Text='<%# Eval("Alamat") %>' runat="server" ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tanggal Lahir" ShowHeader="False">
                                        <ItemStyle Width="120px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblTanggalLahir"  Text='<%# Eval("TanggalLahir").ToString() != "" ? ((DateTime)Eval("TanggalLahir")).ToString("dd MMMM yyyy"): "" %>' runat="server" ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                </Columns>
                                <RowStyle CssClass="ItemStyle" />
                                <SelectedRowStyle CssClass="SelectedItemStyle" />
								<AlternatingRowStyle CssClass="AlternatingItemStyle" />
								<RowStyle CssClass="ItemStyle" />
								<HeaderStyle CssClass="HeaderStyle" /> 
								<FooterStyle CssClass="FooterSytle" />
                            </asp:GridView> </TD></TR></TBODY></TABLE></asp:Panel> <ajaxToolkit:CollapsiblePanelExtender id="cpSearch" runat="Server" SuppressPostBack="true" TargetControlID="pnlSearch" CollapsedImage="../../images/expand_blue.jpg" ExpandedImage="../../images/collapse_blue.jpg" CollapsedText="(Show Details...)" ExpandedText="(Hide Details...)" ImageControlID="imgSearch" TextLabelID="lblSearch" Collapsed="false" CollapseControlID="pnlSearchHeader" ExpandControlID="pnlSearchHeader"></ajaxToolkit:CollapsiblePanelExtender> 
</ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UPPasien" runat="server">
        <ContentTemplate>
<asp:Panel id="pnlPasienHeader" runat="server" Width="100%" CssClass="collapsePanelHeader"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; CURSOR: pointer; PADDING-TOP: 5px"><DIV style="FLOAT: left; VERTICAL-ALIGN: middle"><asp:ImageButton id="imgPasien" runat="server" AlternateText="(Show Details...)" ImageUrl="~/images/expand_blue.jpg"></asp:ImageButton> </DIV><DIV style="FLOAT: left; MARGIN-LEFT: 5px">Data Pasien<asp:TextBox id="txtPasienId" runat="server" Width="9px" Visible="False"></asp:TextBox></DIV><DIV style="FLOAT: left; MARGIN-LEFT: 20px; WIDTH: 120px; TEXT-ALIGN: right">Nomor Rekam Medis:</DIV><DIV style="FLOAT: left; MARGIN-LEFT: 5px; WIDTH: 150px; COLOR: yellow"><asp:Label id="lblNoRMHeader" runat="server"></asp:Label></DIV><DIV style="FLOAT: left; MARGIN-LEFT: 5px; WIDTH: 75px; TEXT-ALIGN: right">Nama Pasien:</DIV><DIV style="FLOAT: left; MARGIN-LEFT: 5px; WIDTH: 150px; COLOR: yellow"><asp:Label id="lblNamaPasienHeader" runat="server"></asp:Label></DIV><DIV style="FLOAT: right; MARGIN-LEFT: 20px"><asp:Label id="lblPasien" runat="server">(Show Details...)</asp:Label> </DIV><asp:TextBox id="txtPenjaminId" runat="server" Width="9px" __designer:wfdid="w1" Visible="False"></asp:TextBox></DIV></asp:Panel> <asp:Panel id="pnlPasien" runat="server" Width="100%" CssClass="collapsePanel" Height="0"><TABLE id="Table1" class="adminform" width="100%" border=0><TBODY><TR><TD style="WIDTH: 50%"><TABLE><TBODY><TR><TD class="text">Nomor Rekam Medis</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblNoRM" runat="server"></asp:Label></TD></TR><TR><TD class="text">Nama Pasien</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblNamaPasien" runat="server"></asp:Label></TD></TR><TR><TD class="text">Status</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblStatus" runat="server"></asp:Label></TD></TR><TR><TD class="text">Pangkat</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblPangkat" runat="server"></asp:Label></TD></TR><TR><TD class="text">No ASKES</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblNoAskes" runat="server"></asp:Label></TD></TR><TR><TD class="text">No KTP</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblNoKTP" runat="server"></asp:Label></TD></TR><TR><TD class="text">Golongan Darah</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblGolDarah" runat="server"></asp:Label></TD></TR><TR><TD class="text">NRP</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblNRP" runat="server"></asp:Label></TD></TR><TR><TD class="text">Satuan Kerja</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblKesatuan" runat="server"></asp:Label></TD></TR><TR><TD class="text">Tempat/Tanggal Lahir</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblTempatLahir" runat="server"></asp:Label>/<asp:Label id="lblTanggalLahir" runat="server"></asp:Label></TD></TR></TBODY></TABLE></TD><TD style="WIDTH: 50%"><TABLE><TBODY><TR><TD class="text">Alamat</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblAlamat" runat="server"></asp:Label></TD></TR><TR><TD class="text">Telepon</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblTelepon" runat="server"></asp:Label></TD></TR><TR><TD class="text">Jenis Kelamin</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblJenisKelamin" runat="server"></asp:Label></TD></TR><TR><TD class="text">Status Perkawinan</TD><TD style="WIDTH: 1px" vAlign=top align=left>:</TD><TD class="value"><asp:Label id="lblStatusPerkawinan" runat="server"></asp:Label></TD></TR><TR><TD class="text">Agama</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblAgama" runat="server"></asp:Label></TD></TR><TR><TD class="text">Pendidikan</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblPendidikan" runat="server"></asp:Label></TD></TR><TR><TD class="text">Pekerjaan</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblPekerjaan" runat="server"></asp:Label></TD></TR><TR><TD class="text">Alamat Kantor</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblAlamatKantor" runat="server"></asp:Label></TD></TR><TR><TD class="text">No Tlp Kantor</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblTeleponKantor" runat="server"></asp:Label></TD></TR><TR><TD class="text">Keterangan</TD><TD class="separator">:</TD><TD class="value"><asp:Label id="lblKeterangan" runat="server"></asp:Label></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></asp:Panel> <ajaxToolkit:CollapsiblePanelExtender id="cpDataPasienDetil" runat="Server" SuppressPostBack="true" TargetControlID="pnlPasien" ExpandControlID="pnlPasienHeader" CollapseControlID="pnlPasienHeader" Collapsed="false" TextLabelID="lblPasien" ImageControlID="imgPasien" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)" ExpandedImage="../../images/collapse_blue.jpg" CollapsedImage="../../images/expand_blue.jpg"></ajaxToolkit:CollapsiblePanelExtender> 
</ContentTemplate>
        <Triggers>
<asp:AsyncPostBackTrigger ControlID="GridViewPasien" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</Triggers>
    </asp:UpdatePanel>
    <asp:Panel ID="pnlRJHeader" runat="server" CssClass="collapsePanelHeader" Width="100%"> 
        <div style="padding:5px; cursor: pointer; vertical-align: middle;">
            <div style="float: left; vertical-align: middle;">
            </div>
            <div style="float: left; margin-left:5px;">Data Kunjungan Rawat Jalan<asp:TextBox ID="TextBox1" runat="server" Visible="False" Width="9px"></asp:TextBox></div>
            <div style="float: left; margin-left: 20px; width:120px; text-align:right;">Nomor Kunjungan:</div>
            <div style="float: left; margin-left:5px; color:Yellow; width:150px;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                <td align="left" colspan="3" valign="top">
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="SingleParagraph" HeaderText="Tanda * harus diisi atau dipilih!" />
                </td>
            </tr>
            <tr>
                <td class="text">Nomor Kunjungan</td>
                <td class="separator">:</td>
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
        <!--        --->
        <asp:UpdatePanel ID="UpdatePanelKeluarga" runat="server">
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
                                </asp:UpdatePanel> </TD></TR><TR><TD class="text">No. KTP</TD><TD class="separator"></TD><TD class="value"><asp:TextBox id="txtNoKTPPenjamin" runat="server" Width="350px" MaxLength="50"></asp:TextBox></TD></TR><TR><TD class="text">Golongan Darah</TD><TD class="separator"></TD><TD class="value"><asp:TextBox id="txtGolDarahPenjamin" runat="server" Width="30px" MaxLength="2"></asp:TextBox></TD></TR><TR><TD class="text">NRP/NIP</TD><TD class="separator">:</TD><TD class="value"><asp:TextBox id="txtNRPPenjamin" runat="server" Width="350px" MaxLength="50"></asp:TextBox></TD></TR><TR><TD class="text">Satuan Kerja</TD><TD class="separator">:</TD><TD class="value"><asp:DropDownList id="cmbSatuanKerjaPenjamin" runat="server" AutoPostBack="false"></asp:DropDownList></TD></TR><TR><TD class="text">Alamat Kesatuan</TD><TD class="separator">:</TD><TD class="value"><asp:TextBox id="txtAlamatKesatuanPenjamin" runat="server" Width="350px" MaxLength="250" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD class="text">Keterangan</TD><TD style="WIDTH: 1px; HEIGHT: 40px" vAlign=top align=left>:</TD><TD class="value"><asp:TextBox id="txtKeteranganPenjamin" runat="server" Width="350px" MaxLength="50" TextMode="MultiLine"></asp:TextBox></TD></TR></TBODY></TABLE>
</ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="cmbJenisPenjamin" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanelPerusahaan" runat="server">
            <ContentTemplate>
                <table class="adminform" runat="server" id="tblPenjaminPerusahaan" visible="false" border="0" width="100%">
                    <tr>
                        <th align="left" colspan="3" style="border-bottom: solid 1px OrangeRed">
                            Data Perusahaan/Asuransi Penjamin</th>
                    </tr>
                    <tr>
                        <td class="text">
                            Nama Perusahaan</td>
                        <td class="separator">
                            :</td>
                        <td class="value">
                            <asp:TextBox ID="txtNamaPerusahaan" runat="server" MaxLength="50" Width="350px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfnamaPerusahaan" runat="server" ControlToValidate="txtNamaPerusahaan" Display="None">*</asp:RequiredFieldValidator></td>
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
                        <td align="left" style="width: 1px; height: 40px;" valign="top">
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
    </asp:Panel>
    <ajaxToolkit:CollapsiblePanelExtender ID="CPRJ" runat="Server"
            TargetControlID="pnlRJ"
            SuppressPostBack="true"/>                  
    <table class="adminheading" width="100%">
        <tr>
            <td style="width: 150px" class="menudottedline">
	            &nbsp;</td>
            <td style="width: 50px" class="menudottedline">
	            <asp:linkbutton id="btnSave" OnClick="OnSave" runat="server"></asp:linkbutton>
            </td>
            <td style="width: 50px" class="menudottedline">
	            <asp:linkbutton id="btnCancel" OnClick="OnCancel" runat="server" CausesValidation="False"></asp:linkbutton>
            </td>
            <td class="menudottedline">&nbsp;</td>
        </tr>
    </table>      
</asp:Content>

