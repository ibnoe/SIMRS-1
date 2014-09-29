<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="RIList.aspx.cs" Inherits="Backoffice_Kasir_RIList" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="../../js/Popup.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
    </asp:ScriptManager>
    <table class="adminheading" id="Table3">
		<tr>
			<th class="menudottedline">
			    <%= Resources.GetString("RS", "TitleSeacrPasien")%> Rawat Inap
			</th>
		</tr>
	</table>
    <table class="adminform">
        <tr>
            <td style="width:100%;">
                Nomor RM:
                <asp:TextBox ID="txtNoRMSearch" runat="server"></asp:TextBox>
                Nama Pasien:
                <asp:TextBox ID="txtNamaSearch" runat="server"></asp:TextBox>
                NRP:
                <asp:TextBox ID="txtNRP" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" CausesValidation="False" Text="Cari" OnClick="btnSearch_Click" />
             </td>
        </tr>
        <tr>
            <td style="width:100%;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlGridView" runat="server" Width="100%">
                            <asp:GridView ID="GridViewPasien" CssClass="DataGridList" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="RawatInapId" OnSelectedIndexChanged="GridViewPasien_SelectedIndexChanged" Width="100%" OnPageIndexChanging="GridViewPasien_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="Tanggal Masuk" SortExpression="TanggalRegistrasi">
                                        <ItemStyle Width="150px" />
                                        <ItemTemplate>
                                            <asp:LinkButton Width="100%" ID="lbTanggalRegistrasi" Text='<%# Eval("TanggalRegistrasi", "{0:dd MMMM yyyy HH:mm}") %>' runat="server" CommandName="Select" ></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nomor RM" SortExpression="NoRM">
                                        <ItemStyle Width="60px" />
                                        <ItemTemplate>
                                            <asp:LinkButton Width="100%" ID="lbNoRM" Text='<%# Eval("NoRM") %>' runat="server" CommandName="Select" ></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nama Pasien" SortExpression="Nama">
                                        <ItemStyle Width="120px" />
                                        <ItemTemplate>
                                            <asp:LinkButton Width="100%" ID="lbNama" Text='<%# Eval("Nama") %>' runat="server" CommandName="Select" ></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="NRP" SortExpression="NRP">
                                        <ItemStyle Width="70px" />
                                        <ItemTemplate>
                                            <asp:LinkButton Width="100%" ID="lbNRP" Text='<%# Eval("NRP") %>' runat="server" CommandName="Select" ></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Alamat" SortExpression="Alamat">
                                        <ItemTemplate>
                                            <asp:Label Width="100%" ID="lblAlamat" runat="server" Text='<%# Eval("Alamat") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Umur" SortExpression="Umur">
                                        <ItemStyle Width="50px" />
                                        <ItemTemplate>
                                            <asp:Label Width="100%" ID="lblUmur" runat="server" Text='<%# Eval("Umur") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Kelas" SortExpression="KelasNama">
                                        <ItemStyle Width="60px" />
                                        <ItemTemplate>
                                            <asp:Label Width="100%" ID="lblKelasNama" runat="server" Text='<%# Eval("KelasNama") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ruangan" SortExpression="RuangNama">
                                        <ItemStyle Width="120px" />
                                        <ItemTemplate>
                                            <asp:Label Width="100%" ID="lblRuangNama" runat="server" Text='<%# Eval("RuangNama") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No Kamar" SortExpression="RuangNama">
                                        <ItemStyle Width="60px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbNomorRuang" runat="server" Text='<%# Eval("NomorRuang") %>'></asp:Label>
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
                        </asp:Panel>
                        <asp:Panel ID="pnlDataPasien" runat="server" Visible="true" Width="100%">
                            
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

