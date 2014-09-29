<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="JadwalDokter.aspx.cs" Inherits="Backoffice_Informasi_JadwalDokter" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
    <table class="adminheading" id="Table3">
		<tr>
			<th class="menudottedline">
				Jadwal Praktek Dokter
			</th>
			<td class="menudottedline" align="right">
            </td>
		</tr>
	</table>
    <table class="adminform" id="Table1" border="0">
		<tr>
			<td>
				<table id="Table2" width="100%" border="0">
					<tr>
						<td>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
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
                                </ContentTemplate>
                            </asp:UpdatePanel>
						</td>
						<td><asp:panel id="pnlSearch" runat="server">
								<table id="TableSearch" cellspacing="0" cellpadding="0" align="right" border="0">
									<tr>
										<td align="right"></td>
										<td align="right">
											<asp:DropDownList id="cmbFilterBy" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbFilterBy_SelectedIndexChanged">
                                                <asp:ListItem>Poliklinik</asp:ListItem>
                                                <asp:ListItem>Dokter</asp:ListItem>
											</asp:DropDownList></td>
										<td align="right">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
							                        <asp:DropDownList id="cmbPoliklinik" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbPoliklinik_SelectedIndexChanged"></asp:DropDownList>
                                                    <asp:DropDownList id="cmbDokter" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbDokter_SelectedIndexChanged" Visible="False">
                                                    </asp:DropDownList>&nbsp;
											    <asp:TextBox id="txtSearch" runat="server" AutoPostBack="True" Width="150px" OnTextChanged="OnSearch" Visible="False"></asp:TextBox>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="cmbFilterBy" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
										<td align="right">
											<asp:Button id="btnSearch" onclick="OnSearch" runat="server" Text="Seacrh" CssClass="button" Visible="False"></asp:Button></td>
									</tr>
								</table>
							</asp:panel>
						</td>
					</tr>
					<tr>
						<td colspan="2">
						    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                            <asp:datagrid id="DataGridList" runat="server" CssClass="DataGridList" OnItemCreated="PageItemCreated"
								OnSortCommand="SortByColumn" OnPageIndexChanged="PageChanged" AutoGenerateColumns="False" DataKeyField="JadwalDokterId"
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
											<asp:label ID="Label1" runat="server" Text="<%#++NoKe%>">
											</asp:label>.
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="PoliklinikNama" HeaderText="Poliklinik">
										<ItemStyle Width="200px"></ItemStyle>
										<ItemTemplate>
											<asp:label ID="Label2" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PoliklinikNama") %>' >
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="DokterNama" HeaderText="Dokter">
										<ItemTemplate>
											<asp:label ID="Label3" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DokterNama") %>' >
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="Senin" HeaderText="Senin">
										<ItemTemplate>
											<asp:label ID="lblSenin" Width="100%" runat="server" Text='<%# GetJamPraktek(DataBinder.Eval(Container, "DataItem.DokterId").ToString(), DataBinder.Eval(Container, "DataItem.PoliklinikId").ToString(),DataBinder.Eval(Container, "DataItem.Senin").ToString(), DataGridList.CurrentPageIndex.ToString()) %>' >
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="Selasa" HeaderText="Selasa">
										<ItemTemplate>
											<asp:label ID="lblSenin" Width="100%" runat="server" Text='<%# GetJamPraktek(DataBinder.Eval(Container, "DataItem.DokterId").ToString(), DataBinder.Eval(Container, "DataItem.PoliklinikId").ToString(),DataBinder.Eval(Container, "DataItem.Selasa").ToString(), DataGridList.CurrentPageIndex.ToString()) %>' >
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="Rabu" HeaderText="Rabu">
										<ItemTemplate>
											<asp:label ID="lblSenin" Width="100%" runat="server" Text='<%# GetJamPraktek(DataBinder.Eval(Container, "DataItem.DokterId").ToString(), DataBinder.Eval(Container, "DataItem.PoliklinikId").ToString(),DataBinder.Eval(Container, "DataItem.Rabu").ToString(), DataGridList.CurrentPageIndex.ToString()) %>' >
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="Kamis" HeaderText="Kamis">
										<ItemTemplate>
											<asp:label ID="lblSenin" Width="100%" runat="server" Text='<%# GetJamPraktek(DataBinder.Eval(Container, "DataItem.DokterId").ToString(), DataBinder.Eval(Container, "DataItem.PoliklinikId").ToString(),DataBinder.Eval(Container, "DataItem.Kamis").ToString(), DataGridList.CurrentPageIndex.ToString()) %>' >
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="Jumat" HeaderText="Jumat">
										<ItemTemplate>
											<asp:label ID="lblSenin" Width="100%" runat="server" Text='<%# GetJamPraktek(DataBinder.Eval(Container, "DataItem.DokterId").ToString(), DataBinder.Eval(Container, "DataItem.PoliklinikId").ToString(),DataBinder.Eval(Container, "DataItem.Jumat").ToString(), DataGridList.CurrentPageIndex.ToString()) %>' >
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="Sabtu" HeaderText="Sabtu">
										<ItemTemplate>
											<asp:label ID="lblSenin" Width="100%" runat="server" Text='<%# GetJamPraktek(DataBinder.Eval(Container, "DataItem.DokterId").ToString(), DataBinder.Eval(Container, "DataItem.PoliklinikId").ToString(),DataBinder.Eval(Container, "DataItem.Sabtu").ToString(), DataGridList.CurrentPageIndex.ToString()) %>' >
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="Minggu" HeaderText="Minggu">
										<ItemTemplate>
											<asp:label ID="lblSenin" Width="100%" runat="server" Text='<%# GetJamPraktek(DataBinder.Eval(Container, "DataItem.DokterId").ToString(), DataBinder.Eval(Container, "DataItem.PoliklinikId").ToString(),DataBinder.Eval(Container, "DataItem.Minggu").ToString(), DataGridList.CurrentPageIndex.ToString()) %>' >
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn SortExpression="Keterangan" HeaderText="Keterangan">
										<ItemTemplate>
											<asp:label ID="Label5" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Keterangan") %>' >
											</asp:label>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Right" CssClass="PageStyle" Mode="NumericPages"></PagerStyle>
							</asp:datagrid>
							</ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="cmbPoliklinik" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="cmbDokter" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
						</td>
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

