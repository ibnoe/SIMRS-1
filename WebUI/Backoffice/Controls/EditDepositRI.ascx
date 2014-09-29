<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditDepositRI.ascx.cs" Inherits="Backoffice_Controls_EditDepositRI" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
    <div class="title">
        <asp:TextBox ID="txtKelasId" runat="server" Visible="False" Width="21px"></asp:TextBox>
        <asp:TextBox ID="txtNamaPasien" runat="server" Visible="False" Width="21px"></asp:TextBox>
        <asp:TextBox ID="txtRawatInapId" runat="server" Visible="False" Width="21px"></asp:TextBox>
        <asp:TextBox ID="txtPasienId" runat="server" Visible="False" Width="21px"></asp:TextBox>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width:100%">
                    <tr>
                        <td style="width:100%;text-align:center">
                            <asp:Label ID="lblWarning" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="GV" EventName="SelectedIndexChanging" />
                <asp:AsyncPostBackTrigger ControlID="GV" EventName="PageIndexChanging" />
                <asp:AsyncPostBackTrigger ControlID="btnDeleteDetil" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnBack" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="GV" EventName="RowDeleting" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <asp:UpdatePanel ID="UPList" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlList" runat="server" Width="100%">
                <table style="width:100%">
                    <tr>
                        <td style="width:100%; text-align:right">
                            <asp:Button ID="btnAdd" runat="server" Text="Tambah Deposit" OnClick="btnAdd_Click" />        
                        </td>
                    </tr>
                </table>
                <asp:GridView CssClass="DataGridList" ID="GV" runat="server"
                    AutoGenerateColumns="False" DataKeyNames="KuitansiId" OnRowEditing="GV_RowEditing" OnPageIndexChanging="GV_PageIndexChanging" OnSelectedIndexChanging="GV_SelectedIndexChanging" Width="100%" OnRowDeleting="GV_RowDeleting" OnSorting="GV_Sorting" ShowFooter="True" AllowSorting="True" AllowPaging="False">
                    <Columns>
                        <asp:TemplateField HeaderText="No">
                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                            <ItemTemplate>
                                <asp:Label ID="lblgNo" runat="server" Text='<%# ++NoKe %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tanggal Pembayaran">
                            <ItemStyle Width="150px" />
                            <ItemTemplate>
                                <asp:Label ID="lblgTanggalBayar" runat="server" Text='<%# Eval("TanggalBayar").ToString() != "" ? ((DateTime)Eval("TanggalBayar")).ToString("dd MMMM yyyy"): "" %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nomor Kuitansi">
                            <ItemStyle Width="120px" />
                            <ItemTemplate>
                                <asp:Label ID="lblgNomorKuitansi" runat="server" Text='<%# Eval("NomorKuitansi") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Diterima Dari">
                            <ItemStyle Width="150px" />
                            <ItemTemplate>
                                <asp:Label ID="lblgDiterimaDari" runat="server" Text='<%# Eval("DiterimaDari") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Jumlah Deposit" >
                            <FooterTemplate>
                                <%# TotalDeposit.ToString("#,###.###.###.###")%>
                            </FooterTemplate>
                            <ItemStyle Width="100px" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblgJumlahBiaya" runat="server" Text='<%# ((Decimal)Eval("JumlahBiaya")).ToString("#,###.###.###.###") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Keterangan" >
                            <ItemTemplate>
                                <asp:Label ID="lblgKeterangan" runat="server" Text='<%# Eval("Keterangan") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemStyle  HorizontalAlign="Center" Width="150px" />
                            <ItemTemplate>
                                <asp:Button ID="btnDetil" runat="server" OnClientClick='<%# getlinkPrint(Eval("KuitansiId").ToString()) %>' CausesValidation="false" Text="Print" />
                                <asp:Button ID="btnEdit" runat="server" CausesValidation="false" CommandName="Edit" Text="Edit" />
                                <asp:Button ID="btnDelete" OnClientClick="return confirm('Apakah anda yakin akan menghapus data ini ?');"  runat="server" CausesValidation="false" CommandName="Delete" Text="Hapus" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle VerticalAlign="Top" Width="100%" CssClass="ItemStyle" />
                    <EmptyDataTemplate>
                        Belum Terdapat Biaya Deposit. 
                    </EmptyDataTemplate>
                    <EmptyDataRowStyle BackColor="White" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                        ForeColor="Red" HorizontalAlign="Center" Width="100%" />
                    <FooterStyle CssClass="FooterStyle" />
                    <SelectedRowStyle CssClass="SelectedItemStyle" />
                    <PagerStyle CssClass="PageStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <AlternatingRowStyle CssClass="AlternatingItemStyle" />
                </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GV" EventName="PageIndexChanging" />
            <asp:AsyncPostBackTrigger ControlID="GV" EventName="RowEditing" />
            <asp:AsyncPostBackTrigger ControlID="GV" EventName="SelectedIndexChanging" />
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="GV" EventName="RowDeleting" />
            <asp:AsyncPostBackTrigger ControlID="GV" EventName="Sorting" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UPEdit" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlEdit" runat="server" Width="100%">
                <table class="adminform" border="0" width="100%">
                    <tr>
                        <th style="text-align:left" colspan="3">
                            <asp:Label ID="lblTitleEditForm" runat="server" Text="Tambah data"></asp:Label>
                            <hr />
                        </th>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                            <asp:ValidationSummary ID="VSEdit" runat="server" DisplayMode="SingleParagraph" HeaderText="Tanda * harus diisi atau dipilih!" />
                            <asp:TextBox ID="txtKuitansiId" Visible="false" runat="server" Width="27px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            No Kuitansi</td>
                        <td class="separator">:</td>
                        <td class="value">
                            <asp:TextBox ID="txtNoKuitansi" runat="server" MaxLength="20" Width="100px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="text">
                            Sudah diterima dari</td>
                        <td class="separator">:</td>
                        <td class="value">
                            <asp:TextBox ID="txtDiterimaDari" runat="server" MaxLength="50" Width="350px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td class="text">
                            Tanggal Pembayaran</td>
                        <td class="separator">:</td>
                        <td class="value">
                            <asp:TextBox ID="txtTanggalBayar" runat="server" Width="75px" MaxLength="1" style="text-align:justify" ValidationGroup="MKE" />
                            <asp:ImageButton ID="ImgTanggalBayar" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" CausesValidation="False" />
                            <asp:RequiredFieldValidator ID="RVTanggalBayar" runat="server" ControlToValidate="txtTanggalBayar" Width="20px">*</asp:RequiredFieldValidator>
                            <ajaxToolkit:MaskedEditExtender ID="MEETanggalBayar" runat="server"
                                TargetControlID="txtTanggalBayar"
                                Mask="99/99/9999"
                                MessageValidatorTip="true"
                                OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError"
                                MaskType="Date"
                                DisplayMoney="Left"
                                AcceptNegative="Left"
                                ErrorTooltipEnabled="True" />
                            <ajaxToolkit:MaskedEditValidator ID="MEVTanggalBayar" runat="server"
                                ControlExtender="MEETanggalBayar"
                                ControlToValidate="txtTanggalBayar"
                                EmptyValueMessage="Tanggal Pembayaran Harus Diisi"
                                InvalidValueMessage="Format Tanggal Salah"
                                Display="Dynamic"
                                TooltipMessage="(Tanggal/Bulan/Tahun)"
                                EmptyValueBlurredText="*"
                                InvalidValueBlurredMessage="Format Tanggal Salah"
                                ValidationGroup="MKE" />
                             <ajaxToolkit:CalendarExtender ID="CETanggalBayar" CssClass="MyCalendar" runat="server" TargetControlID="txtTanggalBayar" PopupButtonID="ImgTanggalBayar" />       
                        </td>
                    </tr>
                    <tr>
                        <td class="text">Jumlah</td>
                        <td class="separator">:</td>
                        <td class="value">
                            <asp:TextBox CssClass="money" ID="txtJumlahBiaya" runat="server" MaxLength="20" AutoPostBack="True" OnTextChanged="txtJumlahBiaya_TextChanged"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="REVJumlahBiaya" runat="server" ControlToValidate="txtJumlahBiaya"
                                ValidationExpression="^\$?(?:\d+|\d{1,3}(?:.\d{3})*)(?:\,\d{1,2}){0,1}$">Isi dengan bilangan yang benar</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Jumlah Terbilang</td>
                        <td class="separator">:</td>
                        <td class="value">
                            <asp:TextBox ID="txtJumlahBiayaText" runat="server" MaxLength="255" TextMode="MultiLine" Width="350px" ReadOnly="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="text">
                            Untuk pembayaran</td>
                        <td class="separator">:</td>
                        <td class="value">
                            <asp:TextBox ID="txtUntukpembayaran" runat="server" MaxLength="255" TextMode="MultiLine"
                                Width="350px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="text">Keterangan</td>
                        <td class="separator">:</td>
                        <td class="value">
                            <asp:TextBox ID="txtKeterangan" runat="server" MaxLength="255" TextMode="MultiLine"
                                Width="350px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="text"></td>
                        <td class="separator"></td>
                        <td class="value">
                            <asp:Button ID="btnSave" runat="server" Text="Simpan" OnClick="btnSave_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Batal" CausesValidation="False" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <hr />
                            Tanda <span style="color: #ff0000">*</span> harus diisi atau dipilih
                        </td>
                    </tr>
                </table>
            </asp:Panel>    
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="GV" EventName="RowEditing" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UPView" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlView" runat="server" Width="100%">
                <table class="adminform" border="0" width="100%">
                    <tr class="trvalidation">
                        <td class="tdvalidation" colspan="3">
                            <asp:Label ID="lblConfirmDelete" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                            <asp:Label ID="lblKuitansiId" runat="server" Text="" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Tanggal</td>
                        <td class="separator">:</td>
                        <td class="value">
                            <asp:Label ID="lblTanggalTransaksi" runat="server" Text=""></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td class="text">Deposit</td>
                        <td class="separator">:</td>
                        <td class="value">
                            <asp:Label ID="lblDeposit" runat="server" Text=""></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td class="text">Keterangan</td>
                        <td class="separator">:</td>
                        <td class="value">
                            <asp:Label ID="lblKeterangan" runat="server" Text=""></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td class="text"></td>
                        <td class="separator"></td>
                        <td class="value">
                            <asp:Button ID="btnEditDetil" Visible ="false" ToolTip="Edit" runat="server" Text="Edit" OnClick="btnEditDetil_Click" />
                            <asp:Button ID="btnDeleteDetil" Visible ="false" OnClientClick="return confirm('Apakah anda yakin akan menghapus data ini ?');"  runat="server" Text="Hapus" OnClick="btnDeleteDetil_Click"/>
                            <asp:Button ID="btnBack" runat="server" Text="Kembali" CausesValidation="False" OnClick="btnBack_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GV" EventName="SelectedIndexChanging" />
        </Triggers>
    </asp:UpdatePanel>