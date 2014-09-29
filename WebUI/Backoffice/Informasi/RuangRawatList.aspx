<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="RuangRawatList.aspx.cs" Inherits="Backoffice_Informasi_RuangRawatList" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table class="adminheading" id="Table3">
		<tr>
			<th class="menudottedline">
				<%= Resources.GetString("Referensi","TitleListRuangRawat") %>
			</th>
		</tr>
	</table>
	<table class="adminform" id="Table1" border="0">
		<tr>
			<td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
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
								OnSortCommand="SortByColumn" OnPageIndexChanged="PageChanged" AutoGenerateColumns="False" DataKeyField="RuangRawatId"
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
									<asp:TemplateColumn SortExpression="KelasNama" HeaderText="Kelas">
										<ItemStyle Width="50px"></ItemStyle>
										<ItemTemplate>
											<asp:label ID="Label1" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.KelasNama") %>' >
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="RuangNama" HeaderText="Nama Ruangan">
										<ItemStyle Width="100px"></ItemStyle>
										<ItemTemplate>
											<asp:label ID="Label2" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RuangNama") %>' >
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="NomorRuang" HeaderText="Nomor Ruang">
										<ItemStyle Width="50px"></ItemStyle>
										<ItemTemplate>
											<asp:label ID="Label3" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NomorRuang") %>' >
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="TempatTidurTotal" HeaderText="Jumlah Tempat Tidur">
										<ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:label ID="Label1" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TempatTidurTotal") %>' >
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="TempatTidurIsi" HeaderText="Tempat Tidur Isi">
										<ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:label ID="Label5" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TempatTidurIsi") %>' >
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="TempatTidurKosong" HeaderText="Tempat Tidur Kosong">
										<ItemStyle Width="50px" HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:label ID="Label6" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TempatTidurKosong") %>' >
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="JumlahKelaminPasien" HeaderText="Keterangan">
										<ItemTemplate>
											<asp:label ID="Label7" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.JumlahKelaminPasien") %>' >
											</asp:label>
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
				</ContentTemplate>
			    </asp:UpdatePanel>
			</td>
		</tr>
	</table>
</asp:Content>

