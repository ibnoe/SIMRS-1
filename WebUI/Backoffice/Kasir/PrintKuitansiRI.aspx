<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintKuitansiRI.aspx.cs" Inherits="Backoffice_Kasir_PrintKuitansiRI"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body onunload="window.opener.location.reload()">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>
        <asp:Panel ID="pnlEdit" runat="server" Width="100%">
                <table class="adminheading" border="0" width="100%">
                    <tr>
                        <th class="menudottedline">
                            <asp:Label ID="lblTitleEditForm" runat="server" Text="Pembayaran Rawat Inap"></asp:Label>
                        </th>
                    </tr>
                </table>
                <div>
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                      <asp:ValidationSummary ID="VSEdit" runat="server" DisplayMode="SingleParagraph" HeaderText="Tanda * harus diisi atau dipilih!" />
                      <asp:TextBox ID="txtRawatInapId" Visible="false" runat="server" Width="27px"></asp:TextBox>
                      <asp:TextBox ID="txtNoRM" Visible="false" runat="server" Width="27px"></asp:TextBox>
                      <asp:TextBox ID="txtNoRegistrasi" Visible="false" runat="server" Width="27px"></asp:TextBox>
                      <asp:TextBox ID="txtRuangRawatId" Visible="false" runat="server" Width="27px"></asp:TextBox>
                </div>
                <table class="adminform" border="0" width="100%">
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
                            <asp:TextBox ID="txtJumlahBiaya" runat="server" Width="200px"></asp:TextBox></td>
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
                            </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="width:100%">
                            <asp:GridView CssClass="DataGridList" ID="GV" runat="server"
                                AutoGenerateColumns="False" DataKeyNames="RILayananId" Width="100%" ShowFooter="True">
                                <Columns>
                                    <asp:TemplateField SortExpression="RILayananId">
                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="cbxAll" Checked="true" OnCheckedChanged="cbxAll_CheckedChanged" AutoPostBack="true" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbxRILayananId" Checked="true" OnCheckedChanged="cbxRILayananId_CheckedChanged" AutoPostBack="true" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No">
                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblgNo" runat="server" Text='<%# ++NoKe %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Kelompok Layanan" SortExpression="Kelompok">
                                        <ItemStyle Width="150px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblgKelompokLayananNama" runat="server" Text='<%# Eval("KelompokLayananNama") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Layanan" SortExpression="NamaLayanan">
                                        <FooterTemplate>
                                            Total
                                        </FooterTemplate>
                                        <ItemStyle Width="150px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblgNamaLayanan" runat="server" Text='<%# Eval("NamaLayanan") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tarif (Rp)" SortExpression="Tarif">
                                        <ItemStyle Width="100px" HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblgTarif" runat="server" Text='<%# ((Decimal)Eval("Tarif")).ToString("#,###.###.###.###") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jumlah Satuan" SortExpression="JumlahSatuan">
                                        <ItemStyle Width="60px" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblgJumlahSatuan" runat="server" Text='<%# ((double)Eval("JumlahSatuan")).ToString("N") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Discount (%)" SortExpression="Discount">
                                        <ItemStyle Width="60px" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblgDiscount" runat="server" Text='<%# ((double)Eval("Discount")).ToString("N") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Biaya Tambahan (%)" SortExpression="BiayaTambahan">
                                        <ItemStyle Width="60px" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblgBiayaTambahan" runat="server" Text='<%# ((double)Eval("BiayaTambahan")).ToString("N") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jumlah Tagihan (Rp)" SortExpression="JumlahTagihan">
                                        <FooterTemplate>
                                            <%# TotalTagihan.ToString("#,###.###.###.###")%>
                                        </FooterTemplate>
                                        <ItemStyle Width="100px" HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblgJumlahTagihan" runat="server" Text='<%# ((Decimal)Eval("JumlahTagihan")).ToString("#,###.###.###.###") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
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
                        </td>
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
                            <asp:Button ID="btnSave" runat="server" Text="Simpan" OnClick="btnSave_Click"  />
                            <asp:Button ID="btnCancel" OnClientClick="window.close()" runat="server" Text="Batal" CausesValidation="False"  />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="width:100%">
                            <hr />
                            Tanda <span style="color: #ff0000">*</span> harus diisi atau dipilih
                        </td>
                    </tr>
                </table>
            </asp:Panel>  
    </form>
</body>
</html>
