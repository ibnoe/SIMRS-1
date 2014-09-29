<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="ListRawatJalan.aspx.cs" Inherits="Backoffice_Referensi_Layanan_ListRawatJalan" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
    </asp:ScriptManager>
    <table class="adminheading" id="Table3">
		<tr>
			<th class="menudottedline">
				<%= Resources.GetString("Referensi","TitleListLayanan") %>
			</th>
			<td class="menudottedline" align="right">
			    <div class="toolbar" onmouseover="MM_swapImage('new','','../../../images/new_f2.gif',1);"
					onmouseout="MM_swapImgRestore();"><asp:linkbutton Text="" id="btnNew" onclick="OnNewRecord" runat="server"></asp:linkbutton></div>
			</td>
		</tr>
	</table>
	<asp:Panel ID="pnlSearchHeader" runat="server" CssClass="collapsePanelHeader"  Width="100%"> 
        <div style="padding:5px; cursor: pointer; vertical-align: middle;">
            <div style="float: left; vertical-align: middle;">
                <asp:ImageButton ID="imgSearch" runat="server" ImageUrl="~/images/expand_blue.jpg" AlternateText="(Show Details...)"/>
            </div>
            <div style="float: left; margin-left:5px;">Filter Data</div>
            <div style="float: right; margin-left: 20px; text-align:right">
                <asp:Label ID="lblSearch" runat="server">(Show Details...)</asp:Label>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlSearch" runat="server" CssClass="collapsePanel" Height="0"  Width="100%">
        <table id="TableSearch" class="adminform" cellspacing="0" cellpadding="0" border="0">
			<tr>
				<td>&nbsp;Poliklinik:<asp:DropDownList ID="cmbPoliklinik" OnSelectedIndexChanged="OnSearch" AutoPostBack="true" runat="server">
                    </asp:DropDownList>
                    &nbsp;Kelompok Layanan:<asp:DropDownList ID="cmbKelompokLayanan" OnSelectedIndexChanged="OnSearch" AutoPostBack="true" runat="server">
                    </asp:DropDownList>
                    &nbsp;<asp:Button id="btnSearch" onclick="OnSearch" runat="server" Text="Seacrh" CssClass="button"></asp:Button>
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
                ExpandedImage="../../../images/collapse_blue.jpg"
                CollapsedImage="../../../images/expand_blue.jpg"
                SuppressPostBack="true"/>
                
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="adminform" id="Table1" border="0">
	            <tr>
		            <td>
			            <table id="Table2" width="100%" border="0">
				            <tr>
					            <td>
						            <table id="Table4" cellspacing="0" cellpadding="0" border="0">
							            <tr>
								            <td>
									            <asp:panel id="pnlNavigation" runat="server">
										            <asp:imagebutton id="ImageButtonFirst" onclick="GoToFirst" runat="server" ToolTip="Halaman Pertama" ImageUrl="~/images/navigator/nbPrevpage.gif"></asp:imagebutton>
										            <asp:imagebutton id="ImageButtonPrev" onclick="GoToPrev" runat="server" ToolTip="Halaman Sebelumnya" ImageUrl="~/images/navigator/nbPrev.gif"></asp:imagebutton>
										            <asp:label id="lblPage" runat="server">Hal </asp:label>
										            <asp:label id="lblCurrentPage" runat="server" Font-Bold="true"></asp:label>
										            <asp:label id="lblFrom" runat="server"> dari </asp:label>
										            <asp:label id="lblTotalPage" runat="server" Font-Bold="true"></asp:label>
										            <asp:imagebutton id="ImageButtonNext" onclick="GoToNext" runat="server" ToolTip="Halamn Selanjutnya" ImageUrl="~/images/navigator/nbNext.gif"></asp:imagebutton>
										            <asp:imagebutton id="ImageButtonLast" onclick="GoToLast" runat="server" ToolTip="Halaman Terakhir" ImageUrl="~/images/navigator/nbNextpage.gif"></asp:imagebutton>
										            <asp:label id="txtTotalRecord" runat="server">Total item: </asp:label>
										            <asp:label id="lblTotalRecord" runat="server" Font-Bold="true"></asp:label>
									            </asp:panel></td>
								            <td align="left"></td>
							            </tr>
						            </table>
					            </td>
				            </tr>
				            <tr>
					            <td colspan="2"><asp:datagrid id="DataGridList" runat="server" CssClass="DataGridList" OnItemCreated="PageItemCreated"
							            OnSortCommand="SortByColumn" OnPageIndexChanged="PageChanged" AutoGenerateColumns="False" DataKeyField="Id"
							            AllowPaging="True" AllowSorting="True">
							            <SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
							            <AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
							            <ItemStyle CssClass="ItemStyle"></ItemStyle>
							            <HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
							            <FooterStyle CssClass="FooterSytle"></FooterStyle>
							            <Columns>
								            <asp:TemplateColumn HeaderText="No">
									            <ItemStyle HorizontalAlign="Right" Width="25px" VerticalAlign="Top"></ItemStyle>
									            <ItemTemplate>
										            <asp:label id="Label4" runat="server" Text="<%#++NoKe%>">
										            </asp:label>.
									            </ItemTemplate>
								            </asp:TemplateColumn>
								            <asp:TemplateColumn SortExpression="JenisLayananNama" HeaderText="Jenis Layanan">
									            <ItemStyle Width="100px"></ItemStyle>
									            <ItemTemplate>
										            <asp:label ID="lblJenisLayananNama" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.JenisLayananNama") %>' >
										            </asp:label>
									            </ItemTemplate>
								            </asp:TemplateColumn>
								            <asp:TemplateColumn SortExpression="PoliklinikNama" HeaderText="Poliklinik">
									            <ItemStyle Width="100px"></ItemStyle>
									            <ItemTemplate>
										            <asp:label ID="lblPoliklinikNama" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PoliklinikNama") %>' >
										            </asp:label>
									            </ItemTemplate>
								            </asp:TemplateColumn>
								            <asp:TemplateColumn SortExpression="KelompokLayananNama" HeaderText="Kelompok">
									            <ItemStyle Width="100px"></ItemStyle>
									            <ItemTemplate>
										            <asp:label ID="lblKelompokLayananNama" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.KelompokLayananNama") %>' >
										            </asp:label>
									            </ItemTemplate>
								            </asp:TemplateColumn>
								            <asp:TemplateColumn SortExpression="Kode" HeaderText="Kode">
									            <ItemStyle Width="50px"></ItemStyle>
									            <ItemTemplate>
										            <asp:label ID="lblKode" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Kode") %>' >
										            </asp:label>
									            </ItemTemplate>
								            </asp:TemplateColumn>
								            <asp:TemplateColumn SortExpression="Nama" HeaderText="Nama">
									            <ItemStyle Width="250px"></ItemStyle>
									            <ItemTemplate>
										            <asp:label ID="lblNama" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Nama") %>' >
										            </asp:label>
									            </ItemTemplate>
								            </asp:TemplateColumn>
								            <asp:TemplateColumn SortExpression="Satuan" HeaderText="Satuan">
									            <ItemStyle Width="50px"></ItemStyle>
									            <ItemTemplate>
										            <asp:label ID="lblSatuan" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Satuan") %>' >
										            </asp:label>
									            </ItemTemplate>
								            </asp:TemplateColumn>
								            <asp:TemplateColumn SortExpression="Tarif" HeaderText="Tarif (Rp)">
									            <ItemStyle Width="50px" HorizontalAlign="Right"></ItemStyle>
									            <ItemTemplate>
										            <asp:label ID="lblTarif" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Tarif").ToString()!="" ? ((decimal)DataBinder.Eval(Container, "DataItem.Tarif")).ToString("N"):"" %>' >
										            </asp:label>
									            </ItemTemplate>
								            </asp:TemplateColumn>
								            <asp:TemplateColumn SortExpression="Keterangan" HeaderText="Keterangan">
									            <ItemTemplate>
										            <asp:label ID="lblKeterangan" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Keterangan") %>' >
										            </asp:label>
									            </ItemTemplate>
								            </asp:TemplateColumn>
								            <asp:TemplateColumn SortExpression="Published" HeaderText="Aktif">
										        <ItemStyle HorizontalAlign="Center" Width="35px"></ItemStyle>
										        <ItemTemplate>
											        <asp:label Width="100%" runat="server" Text='<%# (bool)DataBinder.Eval(Container, "DataItem.Published") ? "Ya":"Tidak" %>' ID="lblPublished">
											        </asp:label>
										        </ItemTemplate>
									        </asp:TemplateColumn>
									        <asp:TemplateColumn HeaderText="<div align=center>Action</div>">
									            <ItemStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Top"></ItemStyle>
									            <ItemTemplate>
										            <%# GetLinkButton(DataBinder.Eval(Container, "DataItem.Id").ToString(),DataBinder.Eval(Container, "DataItem.Nama").ToString(),DataGridList.CurrentPageIndex.ToString())%>
									            </ItemTemplate>
								            </asp:TemplateColumn>
							            </Columns>
							            <PagerStyle HorizontalAlign="Right" CssClass="PageStyle" Mode="NumericPages"></PagerStyle>
						            </asp:datagrid></td>
				            </tr>
				            <tr>
					            <td></td>
					            <td></td>
				            </tr>
			            </table>
		            </td>
	            </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="cmbPoliklinik" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmbKelompokLayanan" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
	
</asp:Content>

