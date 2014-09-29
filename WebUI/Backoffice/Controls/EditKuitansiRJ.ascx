<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditKuitansiRJ.ascx.cs" Inherits="Backoffice_Controls_EditKuitansiRJ" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <div class="title">
        <asp:TextBox ID="txtPolilinikId" runat="server" Visible="False" Width="21px"></asp:TextBox>
        <asp:TextBox ID="txtRawatJalanId" runat="server" Visible="False" Width="21px"></asp:TextBox>
        <asp:TextBox ID="txtPasienId" runat="server" Visible="False" Width="21px"></asp:TextBox>&nbsp;
    </div>
    <table style="width:100%">
        <tr>
            <td style="width:100%; text-align:right">
            </td>
        </tr>
    </table>
    <asp:GridView CssClass="DataGridList" ID="GV" runat="server"
        AutoGenerateColumns="False" DataKeyNames="KuitansiId" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="No">
                <ItemStyle HorizontalAlign="Center" Width="20px" />
                <ItemTemplate>
                    <asp:Label ID="lblgNo" runat="server" Text='<%# ++NoKe %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nomor Kuitansi">
                <ItemStyle Width="40px" />
                <ItemTemplate>
                    <asp:Label ID="lblgNomorKuitansi" runat="server" Text='<%# Eval("NomorKuitansi") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="TanggalBayar">
                <ItemStyle Width="150px" />
                <ItemTemplate>
                    <asp:Label ID="lblgTanggalBayar" runat="server" Text='<%# Eval("TanggalBayar").ToString() != "" ? ((DateTime)Eval("TanggalBayar")).ToString("dd MMMM yyyy"): "" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DiterimaDari" SortExpression="Dari">
                <ItemStyle Width="150px" />
                <ItemTemplate>
                    <asp:Label ID="lblgDiterimaDari" runat="server" Text='<%# Eval("DiterimaDari") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="JumlahBiaya" SortExpression="Jumlah">
                <ItemStyle Width="100px" HorizontalAlign="Right" />
                <ItemTemplate>
                    <asp:Label ID="lblgJumlahBiaya" runat="server" Text='<%# ((Decimal)Eval("JumlahBiaya")).ToString("#,###.###.###.###") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Keterangan" SortExpression="Keterangan">
                <ItemTemplate>
                    <asp:Label ID="lblgKeterangan" runat="server" Text='<%# Eval("Keterangan") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemStyle  HorizontalAlign="Center" Width="120px" />
                <ItemTemplate>
                    <asp:Label Text='<%# GetlinkDetil(Eval("KuitansiId").ToString()) %>' ID="linkDetil" runat="server"></asp:Label>
                    <asp:Label Text='<%# GetlinkEdit(Eval("KuitansiId").ToString()) %>' ID="linkEdit" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <RowStyle VerticalAlign="Top" Width="100%" CssClass="ItemStyle" />
        <EmptyDataTemplate>
            Belum Terdapat Kuitansi Pembayaran. 
        </EmptyDataTemplate>
        <EmptyDataRowStyle BackColor="White" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
            ForeColor="Red" HorizontalAlign="Center" Width="100%" />
        <FooterStyle CssClass="FooterStyle" />
        <SelectedRowStyle CssClass="SelectedItemStyle" />
        <PagerStyle CssClass="PageStyle" />
        <HeaderStyle CssClass="HeaderStyle" />
        <AlternatingRowStyle CssClass="AlternatingItemStyle" />
    </asp:GridView>