<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewKasirHemo.ascx.cs" Inherits="Backoffice_Controls_ViewKasirHemo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <div class="title">
        <asp:TextBox ID="txtPolilinikId" runat="server" Visible="False" Width="21px"></asp:TextBox>
        <asp:TextBox ID="txtRawatJalanId" runat="server" Visible="False" Width="21px"></asp:TextBox>
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
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <asp:UpdatePanel ID="UPList" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlList" runat="server" Width="100%">
                <table style="width:100%">
                    <tr>
                        <td style="width:100%; text-align:right">
                            &nbsp;</td>
                    </tr>
                </table>
                <asp:GridView CssClass="DataGridList" ID="GV" runat="server"
                    AutoGenerateColumns="False" DataKeyNames="RJLayananId" Width="100%" OnSorting="GV_Sorting" ShowFooter="True">
                    <Columns>
                        <asp:TemplateField HeaderText="No">
                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                            <ItemTemplate>
                                <asp:Label ID="lblgNo" runat="server" Text='<%# ++NoKe %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Kode" SortExpression="Kode">
                            <ItemStyle Width="40px" />
                            <ItemTemplate>
                                <asp:Label ID="lblgKode" runat="server" Text='<%# Eval("LayananKode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Kelompok Pemeriksaan" SortExpression="KelompokPemeriksaanNama">
                            <ItemStyle Width="150px" />
                            <ItemTemplate>
                                <asp:Label ID="lblgKelompokLayananNama" runat="server" Text='<%# Eval("KelompokPemeriksaanNama") %>'></asp:Label>
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
            <asp:AsyncPostBackTrigger ControlID="GV" EventName="Sorting" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UPView" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlView" runat="server" Width="100%">
                <table class="adminform" border="0" width="100%">
                    <tr class="trvalidation">
                        <td class="tdvalidation" colspan="3">
                            <asp:Label ID="lblConfirmDelete" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                            <asp:Label ID="lblRJLayananId" runat="server" Text="" Visible="false"></asp:Label>
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
                </table>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GV" EventName="SelectedIndexChanging" />
        </Triggers>
    </asp:UpdatePanel>