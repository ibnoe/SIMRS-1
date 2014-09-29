<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="ListHemo.aspx.cs" Inherits="Backoffice_Tarif_ListHemo" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
    </asp:ScriptManager>
    <table class="adminheading" id="Table3">
		<tr>
			<th class="menudottedline">
				Daftar Layanan & Tarif HEMODIALISA
			</th>
			<td class="menudottedline" align="right">
				<div class="toolbar" onmouseover="MM_swapImage('new','','../../../images/new_f2.gif',1);"
					onmouseout="MM_swapImgRestore();"><asp:linkbutton id="btnNew" onclick="OnNewRecord" runat="server"></asp:linkbutton></div>
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
        <table id="TableSearch" class="adminform" cellspacing="0" cellpadding="0" align="right" border="0">
			<tr>
				<td>&nbsp;Kelompok Pemeriksaan:<asp:DropDownList ID="cmbKelompokPemeriksaan" OnSelectedIndexChanged="OnSearch" AutoPostBack="true" runat="server">
                    </asp:DropDownList>
                    &nbsp;<asp:Button id="btnSearch" Visible="false" onclick="OnSearch" runat="server" Text="Seacrh" CssClass="button"></asp:Button>
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
                ExpandedImage="../../images/collapse_blue.jpg"
                CollapsedImage="../../images/expand_blue.jpg"
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
								            <asp:TemplateColumn SortExpression="Kode" HeaderText="Kode Tarif">
									            <ItemStyle Width="50px"></ItemStyle>
									            <ItemTemplate>
										            <asp:label ID="lblKode" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Kode") %>' >
										            </asp:label>
									            </ItemTemplate>
								            </asp:TemplateColumn>
								            <asp:TemplateColumn SortExpression="KodePeriksa" HeaderText="Kode Pemeriksaan">
									            <ItemStyle Width="50px"></ItemStyle>
									            <ItemTemplate>
										            <asp:label ID="lblKode" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.KodePeriksa") %>' >
										            </asp:label>
									            </ItemTemplate>
								            </asp:TemplateColumn>
								            <asp:TemplateColumn SortExpression="KelompokPemeriksaanNama" HeaderText="Kelompok Pemeriksaan">
									            <ItemStyle Width="100px"></ItemStyle>
									            <ItemTemplate>
										            <asp:label ID="lblKelompokLayananNama" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.KelompokPemeriksaanNama") %>' >
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
								            <asp:TemplateColumn SortExpression="RJ" HeaderText="Rawat Jalan">
									            <ItemStyle Width="50px" HorizontalAlign="Right"></ItemStyle>
									            <ItemTemplate>
										            <asp:label ID="lblRJ" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RJ").ToString()!="" ? ((decimal)DataBinder.Eval(Container, "DataItem.RJ")).ToString("N"):"" %>' >
										            </asp:label>
									            </ItemTemplate>
								            </asp:TemplateColumn>
								            <asp:TemplateColumn SortExpression="KelasIII" HeaderText="Tarif Kelas III">
									            <ItemStyle Width="50px" HorizontalAlign="Right"></ItemStyle>
									            <ItemTemplate>
										            <asp:label ID="lblKelasIII" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.KelasIII").ToString()!="" ? ((decimal)DataBinder.Eval(Container, "DataItem.KelasIII")).ToString("N"):"" %>' >
										            </asp:label>
									            </ItemTemplate>
								            </asp:TemplateColumn>
								            <asp:TemplateColumn SortExpression="KelasII" HeaderText="Tarif Kelas II">
									            <ItemStyle Width="50px" HorizontalAlign="Right"></ItemStyle>
									            <ItemTemplate>
										            <asp:label ID="lblKelasII" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.KelasII").ToString()!="" ? ((decimal)DataBinder.Eval(Container, "DataItem.KelasII")).ToString("N"):"" %>' >
										            </asp:label>
									            </ItemTemplate>
								            </asp:TemplateColumn>
								            <asp:TemplateColumn SortExpression="KelasI" HeaderText="Tarif Kelas I">
									            <ItemStyle Width="50px" HorizontalAlign="Right"></ItemStyle>
									            <ItemTemplate>
										            <asp:label ID="lblKelasI" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.KelasI").ToString()!="" ? ((decimal)DataBinder.Eval(Container, "DataItem.KelasI")).ToString("N"):"" %>' >
										            </asp:label>
									            </ItemTemplate>
								            </asp:TemplateColumn>
								            <asp:TemplateColumn SortExpression="KelasVIP" HeaderText="Tarif VIP">
									            <ItemStyle Width="50px" HorizontalAlign="Right"></ItemStyle>
									            <ItemTemplate>
										            <asp:label ID="lblKelasVIP" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.KelasVIP").ToString()!="" ? ((decimal)DataBinder.Eval(Container, "DataItem.KelasVIP")).ToString("N"):"" %>' >
										            </asp:label>
									            </ItemTemplate>
								            </asp:TemplateColumn>
								            <asp:TemplateColumn SortExpression="KelasVVIP" HeaderText="Tarif VVIP">
									            <ItemStyle Width="50px" HorizontalAlign="Right"></ItemStyle>
									            <ItemTemplate>
										            <asp:label ID="lblKelasVVIP" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.KelasVVIP").ToString()!="" ? ((decimal)DataBinder.Eval(Container, "DataItem.KelasVVIP")).ToString("N"):"" %>' >
										            </asp:label>
									            </ItemTemplate>
								            </asp:TemplateColumn>
								            
								            <asp:TemplateColumn SortExpression="" HeaderText="Askes">
									            <ItemTemplate>
										            <asp:label ID="Label5" Width="100%" runat="server" Text='' >
										            </asp:label>
									            </ItemTemplate>
								            </asp:TemplateColumn>
								            <asp:TemplateColumn SortExpression="" HeaderText="Satuan">
									            <ItemTemplate>
										            <asp:label ID="Label6" Width="100%" runat="server" Text='' >
										            </asp:label>
									            </ItemTemplate>
								            </asp:TemplateColumn>
								            <asp:TemplateColumn SortExpression="" HeaderText="Range Nilai Normal (P)">
									            <ItemTemplate>
										            <asp:label ID="Label7" Width="100%" runat="server" Text='' >
										            </asp:label>
									            </ItemTemplate>
								            </asp:TemplateColumn>
								            <asp:TemplateColumn SortExpression="" HeaderText="Range Nilai Normal (W)">
									            <ItemTemplate>
										            <asp:label ID="Label8" Width="100%" runat="server" Text='' >
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
            <asp:AsyncPostBackTrigger ControlID="cmbKelompokPemeriksaan" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
	
</asp:Content>

