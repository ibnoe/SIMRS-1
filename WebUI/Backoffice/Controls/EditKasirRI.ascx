<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditKasirRI.ascx.cs" Inherits="Backoffice_Controls_EditKasirRI" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
    <div class="title">
        <asp:TextBox ID="txtKelasId" runat="server" Visible="False" Width="21px"></asp:TextBox>
        <asp:TextBox ID="txtTempatInapId" runat="server" Visible="False" Width="21px"></asp:TextBox>
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
                            <a href="javascript:void(0)" class="button" visible="False" onclick="" id="btnKuitansi" runat="server">
                                Proses Pembayaran</a>
                            <a href="javascript:void(0)" class="button" visible="False" onclick="" id="btnRincian" runat="server">
                                Print Rincian</a>
                            <a href="javascript:void(0)" class="button" visible="False" onclick="" id="btnPenagihan" runat="server">
                                Print Penagihan</a>
                            <asp:Button ID="btnAdd" runat="server" Text="Tambah Layanan Baru" OnClick="btnAdd_Click" />        
                        </td>
                    </tr>
                </table>
                <asp:GridView CssClass="DataGridList" ID="GV" runat="server"
                    AutoGenerateColumns="False" DataKeyNames="RILayananId" OnRowEditing="GV_RowEditing" OnPageIndexChanging="GV_PageIndexChanging" OnSelectedIndexChanging="GV_SelectedIndexChanging" Width="100%" OnRowDeleting="GV_RowDeleting" OnSorting="GV_Sorting" ShowFooter="True" AllowSorting="True" AllowPaging="False">
                    <Columns>
                        <asp:TemplateField HeaderText="No">
                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                            <ItemTemplate>
                                <asp:Label ID="lblgNo" runat="server" Text='<%# ++NoKe %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tanggal" SortExpression="TanggalTransaksi">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label ID="lblgTanggalTransaksi" runat="server" Text='<%# Eval("TanggalTransaksi").ToString() != "" ?  ((DateTime)Eval("TanggalTransaksi")).ToString("dd/MM/yyyy") : "" %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Kode" SortExpression="LayananKode">
                            <ItemStyle Width="40px" />
                            <ItemTemplate>
                                <asp:Label ID="lblgKode" runat="server" Text='<%# Eval("LayananKode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Kelompok Layanan" SortExpression="KelompokLayananNama">
                            <ItemStyle Width="150px" />
                            <ItemTemplate>
                                <asp:Label ID="lblgKelompokLayananNama" runat="server" Text='<%# Eval("KelompokLayananNama") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Layanan" SortExpression="NamaLayanan">
                            <ItemStyle Width="150px" />
                            <ItemTemplate>
                                <asp:Label ID="lblgNamaLayanan" runat="server" Text='<%# Eval("NamaLayanan") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tarif" SortExpression="Tarif">
                            <ItemStyle Width="100px" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblgTarif" runat="server" Text='<%# ((Decimal)Eval("Tarif")).ToString("#,###.###.###.###") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Jumlah Satuan" SortExpression="JumlahSatuan">
                            <ItemStyle Width="60px" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblgJumlahSatuan" runat="server" Text='<%# ((double)Eval("JumlahSatuan")).ToString("N") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Discount (%)" SortExpression="Discount">
                            <ItemStyle Width="60px" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblgDiscount" runat="server" Text='<%# ((double)Eval("Discount")).ToString("N") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Biaya Tambahan (%)" SortExpression="BiayaTambahan">
                            <ItemStyle Width="60px" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblgBiayaTambahan" runat="server" Text='<%# ((double)Eval("BiayaTambahan")).ToString("N") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Jumlah Tagihan" SortExpression="JumlahTagihan" >
                            <FooterTemplate>
                                <%# TotalTagihan.ToString("#,###.###.###.###")%>
                            </FooterTemplate>
                            <ItemStyle Width="100px" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblgJumlahTagihan" runat="server" Text='<%# ((Decimal)Eval("JumlahTagihan")).ToString("#,###.###.###.###") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status Bayar" SortExpression="StatusBayar" >
                            <ItemStyle Width="50px" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:CheckBox ID="cbgStatusBayar" Enabled="false" runat="server" Checked='<%# Eval("StatusBayar").ToString() == "0" ? false:true  %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Keterangan" SortExpression="Keterangan">
                            <ItemTemplate>
                                <asp:Label ID="lblgKeterangan" runat="server" Text='<%# Eval("Keterangan") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemStyle  HorizontalAlign="Center" Width="150px" />
                            <ItemTemplate>
                                <asp:Button ID="btnDetil" runat="server" CausesValidation="false" CommandName="Select" Text="Detil" />
                                <asp:Button ID="btnEdit" Visible='<%# Eval("StatusBayar").ToString() == "0" ? true:false  %>' runat="server" CausesValidation="false" CommandName="Edit" Text="Edit" />
                                <asp:Button ID="btnDelete" Visible='<%# Eval("StatusBayar").ToString() == "0" ? true:false  %>' OnClientClick="return confirm('Apakah anda yakin akan menghapus data ini ?');"  runat="server" CausesValidation="false" CommandName="Delete" Text="Hapus" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle VerticalAlign="Top" Width="100%" CssClass="ItemStyle" />
                    <EmptyDataTemplate>
                        Belum Terdapat Biaya Tagihan. 
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
                            <asp:TextBox ID="txtRILayananId" Visible="false" runat="server" Width="27px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Tanggal</td>
                        <td class="separator">
                            :</td>
                        <td class="value">
                            <asp:TextBox ID="txtTanggalTransaksi" runat="server" Width="60px" MaxLength="1" style="text-align:justify" ValidationGroup="MKETanggalTransaksi" />
                            <asp:ImageButton ID="ImgTanggalTransaksi" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" CausesValidation="False" />
                            <asp:RequiredFieldValidator ID="RVTanggalTransaksi" runat="server" ControlToValidate="txtTanggalTransaksi" >*</asp:RequiredFieldValidator>
                            <ajaxToolkit:MaskedEditExtender ID="MEETanggalTransaksi" runat="server"
                                TargetControlID="txtTanggalTransaksi"
                                Mask="99/99/9999"
                                MessageValidatorTip="true"
                                OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError"
                                MaskType="Date"
                                DisplayMoney="Left"
                                AcceptNegative="Left"
                                ErrorTooltipEnabled="True" ClearTextOnInvalid="True" />
                            <ajaxToolkit:MaskedEditValidator ID="MEVTanggalTransaksi" runat="server"
                                ControlExtender="MEETanggalTransaksi"
                                ControlToValidate="txtTanggalTransaksi"
                                IsValidEmpty="False"
                                EmptyValueMessage="Tanggal Transaksi Harus Diisi"
                                InvalidValueMessage="Format Tanggal Salah"
                                Display="Dynamic"
                                TooltipMessage="(Tanggal/Bulan/Tahun)"
                                EmptyValueBlurredText="*"
                                InvalidValueBlurredMessage="Format Tanggal Salah"
                                ValidationGroup="MKETanggalTransaksi" />
                            <ajaxToolkit:CalendarExtender ID="CETanggalTransaksi" CssClass="MyCalendar" runat="server" TargetControlID="txtTanggalTransaksi" PopupButtonID="ImgTanggalTransaksi" />
                        </td>
                    </tr>
                    <tr>
                       <td class="text">
                           Jam Transaksi</td>
                       <td class="separator">
                           :</td>
                       <td class="value">
                            <asp:TextBox ID="txtJamTransaksi" runat="server" Width="34px" Height="16px" ValidationGroup="MKEJamTransaksi" />
                            <ajaxToolkit:MaskedEditExtender ID="MEEJamTransaksi" runat="server"
                                TargetControlID="txtJamTransaksi" 
                                Mask="99:99"
                                MessageValidatorTip="true"
                                OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError"
                                MaskType="Time"
                                ErrorTooltipEnabled="True" ClearTextOnInvalid="True" />
                            <ajaxToolkit:MaskedEditValidator ID="MEVJamTransaksi" runat="server"
                                ControlExtender="MEEJamTransaksi"
                                ControlToValidate="txtJamTransaksi"
                                EmptyValueMessage="Jam Transaksi Harus diisi"
                                InvalidValueMessage="Format Jam Transaksi Salah"
                                Display="Dynamic"
                                TooltipMessage="(Jam:Menit)"
                                EmptyValueBlurredText="*"
                                InvalidValueBlurredMessage="*"
                                ValidationGroup="MKEJamTransaksi"/>
                       </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Ruang Rawat</td>
                        <td class="separator">
                            :</td>
                        <td class="value">
                            <asp:DropDownList ID="cmbRuangRawat" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbRuangRawat_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RVRuangRawat" runat="server" ControlToValidate="cmbRuangRawat">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="text">
                            Jenis Layanan</td>
                        <td class="separator">
                            :</td>
                        <td class="value">
                            <asp:DropDownList ID="cmbJenisLayanan" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbJenisLayanan_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cmbJenisLayanan">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="text">
                            Kelompok Layanan</td>
                        <td class="separator">
                            :</td>
                        <td class="value">
                            <asp:DropDownList ID="cmbKelompokLayanan" runat="server" OnSelectedIndexChanged="cmbKelompokLayanan_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cmbLayanan">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="text">
                            Layanan</td>
                        <td class="separator">:</td>
                        <td class="value">
                                    <asp:DropDownList ID="cmbLayanan" runat="server" OnSelectedIndexChanged="cmbLayanan_SelectedIndexChanged" AutoPostBack="True">
                                    </asp:DropDownList><asp:Panel ID="pnlLayananLain" Visible="false" runat="server">
                                        <asp:TextBox ID="txtNamaLayanan" runat="server" MaxLength="50" Width="350px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RVNamaLayanan" runat="server" ControlToValidate="txtNamaLayanan" >*</asp:RequiredFieldValidator>
                                    </asp:Panel>
                                    <asp:RequiredFieldValidator ID="RVLayanan" runat="server" ControlToValidate="cmbLayanan">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="text">Tarif</td>
                        <td class="separator">:</td>
                        <td class="value">
                            <asp:TextBox CssClass="money" ID="txtTarif" runat="server" MaxLength="20" AutoPostBack="True" OnTextChanged="txtTarif_TextChanged"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="REVTarif" runat="server" ControlToValidate="txtTarif"
                                ValidationExpression="^\$?(?:\d+|\d{1,3}(?:.\d{3})*)(?:\,\d{1,2}){0,1}$">Isi dengan bilangan yang benar</asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td class="text">
                            Jumlah Satuan</td>
                        <td class="separator">
                        </td>
                        <td class="value">
                            <asp:TextBox CssClass="money" ID="txtJumlahSatuan" runat="server" MaxLength="20" OnTextChanged="txtJumlahSatuan_TextChanged" AutoPostBack="True" Width="43px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="REVJumlahSatuan" runat="server" ControlToValidate="txtJumlahSatuan"
                                ValidationExpression="^[0-9][0-9]*(\,[0-9]*)?$">Isi dengan bilangan yang benar</asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td class="text">
                            Discount</td>
                        <td class="separator">
                            :</td>
                        <td class="value">
                            <asp:TextBox CssClass="money" ID="txtDiscount" runat="server" MaxLength="5" Width="40px" AutoPostBack="True" OnTextChanged="txtDiscount_TextChanged"></asp:TextBox>%<asp:RegularExpressionValidator
                                ID="REVDiscount" runat="server" ControlToValidate="txtDiscount" ValidationExpression="^[0-9][0-9]*(\,[0-9]*)?$">Isi dengan bilangan</asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td class="text">
                            Biaya Tambahan</td>
                        <td class="separator">
                            :</td>
                        <td class="value">
                            <asp:TextBox CssClass="money" ID="txtBiayaTambahan" runat="server" MaxLength="5" Width="40px" AutoPostBack="True" OnTextChanged="txtBiayaTambahan_TextChanged"></asp:TextBox>%<asp:RegularExpressionValidator
                                ID="REVBiayaTambahan" runat="server" ControlToValidate="txtBiayaTambahan" ValidationExpression="^[0-9][0-9]*(\,[0-9]*)?$">Isi dengan bilangan</asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td class="text">
                            Jumlah Tagihan</td>
                        <td class="separator">
                            :</td>
                        <td class="value">
                            <asp:TextBox CssClass="money" ID="txtJumlahTagihan" runat="server" MaxLength="20" ReadOnly="True"></asp:TextBox>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="text">Keterangan</td>
                        <td class="separator">:</td>
                        <td class="value">
                            <asp:TextBox ID="txtKeterangan" TextMode="MultiLine" Rows="3" runat="server" MaxLength="255" Width="350px"></asp:TextBox></td>
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
                            <asp:Label ID="lblRILayananId" runat="server" Text="" Visible="false"></asp:Label>
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
                        <td class="text">
                            Ruang Rawat</td>
                        <td class="separator">:</td>
                        <td class="value">
                            <asp:Label ID="lblRuangRawat" runat="server" Text=""></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Jenis Layanan</td>
                        <td class="separator">:</td>
                        <td class="value">
                            <asp:Label ID="lblJenisLayananNama" runat="server" Text=""></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Kelompok Layanan</td>
                        <td class="separator">:</td>
                        <td class="value">
                            <asp:Label ID="lblKelompokLayanan" runat="server" Text=""></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Layanan</td>
                        <td class="separator">:</td>
                        <td class="value">
                            <asp:Label ID="lblNamaLayanan" runat="server" Text=""></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td class="text">Tarif</td>
                        <td class="separator">:</td>
                        <td class="value">
                            <asp:Label ID="lblTarif" runat="server" Text=""></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Jumlah Satuan</td>
                        <td class="separator">
                        </td>
                        <td class="value">
                            <asp:Label ID="lblJumlahSatuan" runat="server" Text=""></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Discount</td>
                        <td class="separator">
                            :</td>
                        <td class="value">
                            <asp:Label ID="lblDiscount" runat="server" Text=""></asp:Label>%
                            </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Biaya Tambahan</td>
                        <td class="separator">
                            :</td>
                        <td class="value">
                            <asp:Label ID="lblBiayaTambahan" runat="server" Text=""></asp:Label>%
                            </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Jumlah Tagihan</td>
                        <td class="separator">
                            :</td>
                        <td class="value">
                            <asp:Label ID="lblJumlahTagihan" runat="server" Text=""></asp:Label>
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