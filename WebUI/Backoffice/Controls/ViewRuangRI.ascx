<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewRuangRI.ascx.cs" Inherits="Backoffice_Controls_ViewRuangRI" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
    <div class="title">
        <asp:TextBox ID="txtKelasId" runat="server" Visible="False" Width="21px"></asp:TextBox>
        <asp:TextBox ID="txtRawatInapId" runat="server" Visible="False" Width="21px"></asp:TextBox>
        <asp:TextBox ID="txtPasienId" runat="server" Visible="False" Width="21px"></asp:TextBox>
        <table style="width:100%">
            <tr>
                <td style="width:100%;text-align:center">
                    <asp:Label ID="lblWarning" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="pnlList" runat="server" Width="100%">
        <asp:GridView CssClass="DataGridList" ID="GV" runat="server"
            AutoGenerateColumns="False" DataKeyNames="TempatInapId" OnPageIndexChanging="GV_PageIndexChanging" Width="100%" OnSorting="GV_Sorting">
            <Columns>
                <asp:TemplateField HeaderText="No">
                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                    <ItemTemplate>
                        <asp:Label ID="lblgNo" runat="server" Text='<%# ++NoKe %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tanggal Masuk" SortExpression="TanggalMasuk">
                    <ItemStyle Width="120px" />
                    <ItemTemplate>
                        <asp:Label ID="lblgTanggalMasuk" runat="server" Text='<%# ((DateTime)Eval("TanggalMasuk")).ToString("dd/MM/yyyy HH:mm") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tanggal Keluar" SortExpression="TanggalKeluar">
                    <ItemStyle Width="120px" />
                    <ItemTemplate>
                        <asp:Label ID="lblgTanggalKeluar" runat="server" Text='<%# Eval("TanggalKeluar").ToString() != "" ? ((DateTime)Eval("TanggalKeluar")).ToString("dd/MM/yyyy HH:mm"):"" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Jam Inap" SortExpression="JamInap">
                    <ItemStyle Width="80px" />
                    <ItemTemplate>
                        <asp:Label ID="lblgJamInap" runat="server" Text='<%# Eval("JamInap") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Kelas" SortExpression="KelasNama">
                    <ItemStyle Width="50px" />
                    <ItemTemplate>
                        <asp:Label ID="lblgKelasNama" runat="server" Text='<%# Eval("KelasNama") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ruangan" SortExpression="RuangNama">
                    <ItemStyle Width="100px" />
                    <ItemTemplate>
                        <asp:Label ID="lblgRuangNama" runat="server" Text='<%# Eval("RuangNama") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nomor Kamar" SortExpression="NomorRuang">
                    <ItemStyle Width="100px" />
                    <ItemTemplate>
                        <asp:Label ID="lblgNomorRuang" runat="server" Text='<%# Eval("NomorRuang") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nomor Tempat Tidur" SortExpression="NomorTempat">
                    <ItemStyle Width="100px" />
                    <ItemTemplate>
                        <asp:Label ID="lblgNomorTempat" runat="server" Text='<%# Eval("NomorTempat") %>'></asp:Label>
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
                Belum Terdapat Ruangan Inap. 
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
    