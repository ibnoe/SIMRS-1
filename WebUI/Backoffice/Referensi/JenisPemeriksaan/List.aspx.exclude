<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="Backoffice_Referensi_JenisPemeriksaan_List" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="adminheading" id="Table3">
		<tr>
			<th class="menudottedline">
				<%= Resources.GetString("Referensi","TitleListJenisPemeriksaan") %>
			</th>
			<td class="menudottedline" align="right">
				<div class="toolbar" onmouseover="MM_swapImage('new','','../../../images/new_f2.gif',1);"
					onmouseout="MM_swapImgRestore();"><asp:linkbutton id="btnNew" onclick="OnNewRecord" runat="server"></asp:linkbutton></div>
			</td>
		</tr>
	</table>
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
											<asp:imagebutton id="ImageButtonFirst" onclick="GoToFirst" runat="server" ToolTip="Halaman Pertama"></asp:imagebutton>
											<asp:imagebutton id="ImageButtonPrev" onclick="GoToPrev" runat="server" ToolTip="Halaman Sebelumnya"></asp:imagebutton>
											<asp:label id="lblPage" runat="server">Hal </asp:label>
											<asp:label id="lblCurrentPage" runat="server" Font-Bold="true"></asp:label>
											<asp:label id="lblFrom" runat="server"> dari </asp:label>
											<asp:label id="lblTotalPage" runat="server" Font-Bold="true"></asp:label>
											<asp:imagebutton id="ImageButtonNext" onclick="GoToNext" runat="server" ToolTip="Halamn Selanjutnya"></asp:imagebutton>
											<asp:imagebutton id="ImageButtonLast" onclick="GoToLast" runat="server" ToolTip="Halaman Terakhir"></asp:imagebutton>
											<asp:label id="txtTotalRecord" runat="server">Total item: </asp:label>
											<asp:label id="lblTotalRecord" runat="server" Font-Bold="true"></asp:label>
										</asp:panel></td>
									<td align="left"></td>
									<td id="td_btnFilter" align="left"></td>
								</tr>
							</table>
						</td>
						<td><asp:panel id="pnlSearch" runat="server">
								<table id="TableSearch" cellspacing="0" cellpadding="0" align="right" border="0">
									<tr>
										<td align="right"></td>
										<td align="right">
											<asp:DropDownList id="cmbFilterBy" runat="server">
												<asp:ListItem Value="Nama">Nama</asp:ListItem>
												<asp:ListItem Value="Keterangan">Keterangan</asp:ListItem>
											</asp:DropDownList></td>
										<td align="right">
											<asp:DropDownList id="cmbSearch" runat="server" Visible="False"></asp:DropDownList>
											<asp:TextBox id="txtSearch" runat="server" AutoPostBack="True" Width="150px" OnTextChanged="OnSearch"></asp:TextBox></td>
										<td align="right">
											<asp:Button id="btnSearch" onclick="OnSearch" runat="server" Text="Seacrh" CssClass="button"></asp:Button></td>
									</tr>
								</table>
							</asp:panel></td>
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
									<asp:TemplateColumn SortExpression="Kode" HeaderText="Kode">
										<ItemStyle Width="100px"></ItemStyle>
										<ItemTemplate>
											<asp:label ID="Label1" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Kode") %>' >
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="Nama" HeaderText="Nama">
										<ItemStyle Width="220px"></ItemStyle>
										<ItemTemplate>
											<asp:label ID="Label2" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Nama") %>' >
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									
									
									<asp:TemplateColumn SortExpression="Keterangan" HeaderText="Keterangan">
										<ItemTemplate>
											<asp:label ID="Label5" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Keterangan") %>' >
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
</asp:Content>

