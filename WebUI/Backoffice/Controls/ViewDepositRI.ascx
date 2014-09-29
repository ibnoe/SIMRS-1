<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewDepositRI.ascx.cs" Inherits="Backoffice_Controls_ViewDepositRI" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
    <div class="title">
        <asp:TextBox ID="txtKelasId" runat="server" Visible="False" Width="21px"></asp:TextBox>
        <asp:TextBox ID="txtNamaPasien" runat="server" Visible="False" Width="21px"></asp:TextBox>
        <asp:TextBox ID="txtRawatInapId" runat="server" Visible="False" Width="21px"></asp:TextBox>
        <asp:TextBox ID="txtPasienId" runat="server" Visible="False" Width="21px"></asp:TextBox>
    </div>
    <asp:UpdatePanel ID="UPList" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlList" runat="server" Width="100%">
                <asp:GridView CssClass="DataGridList" ID="GV" runat="server"
                    AutoGenerateColumns="False" DataKeyNames="KuitansiId" Width="100%" ShowFooter="True" AllowSorting="True" AllowPaging="False">
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
                        <asp:TemplateField HeaderText="Diterima Dari" >
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
                    </Columns>
                    <RowStyle VerticalAlign="Top" Width="100%" CssClass="ItemStyle" />
                    <EmptyDataTemplate>
                        Belum Terdapat Deposit. 
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
            <asp:AsyncPostBackTrigger ControlID="GV" EventName="SelectedIndexChanging" />
            <asp:AsyncPostBackTrigger ControlID="GV" EventName="RowDeleting" />
            <asp:AsyncPostBackTrigger ControlID="GV" EventName="Sorting" />
        </Triggers>
    </asp:UpdatePanel>
