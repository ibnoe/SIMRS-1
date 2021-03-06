<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="Backoffice_Referensi_TempatTidur_List" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="adminheading" id="Table3">
		<tr>
			<th class="menudottedline">
				<%= Resources.GetString("Referensi","TitleListTempatTidur") %>
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
												<asp:ListItem Value="RuangNama">Ruangan</asp:ListItem>
												<asp:ListItem Value="KelasNama">Kelas</asp:ListItem>
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
								OnSortCommand="SortByColumn" OnPageIndexChanged="PageChanged" AutoGenerateColumns="False" DataKeyField="TempatTidurId"
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
									<asp:TemplateColumn SortExpression="KelasId" HeaderText="Kelas">
										<ItemStyle Width="100px"></ItemStyle>
										<ItemTemplate>
											<asp:label ID="Label1" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.KelasNama") %>' >
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="RuangNama" HeaderText="Nama Ruangan">
										<ItemTemplate>
											<asp:label ID="Label2" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RuangNama") %>' >
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="NomorRuang" HeaderText="Nomor Ruang">
										<ItemTemplate>
											<asp:label ID="Label3" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NomorRuang") %>' >
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="NomorTempat" HeaderText="Nomor Tempat Tidur">
										<ItemStyle Width="100px" HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:label Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NomorTempat") %>' >
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="Status" HeaderText="Status">
										<ItemStyle Width="100px" HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:label ID="Label6" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Status").ToString() == "False" ? "Kosong":"Isi" %>' >
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="<div align=center>Action</div>">
										<ItemStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Top"></ItemStyle>
										<ItemTemplate>
											<%# GetLinkButton(DataBinder.Eval(Container, "DataItem.TempatTidurId").ToString(), DataBinder.Eval(Container, "DataItem.RuangNama").ToString(), DataBinder.Eval(Container, "DataItem.KelasNama").ToString(), DataGridList.CurrentPageIndex.ToString())%>
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

