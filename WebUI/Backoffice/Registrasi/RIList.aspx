<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="RIList.aspx.cs" Inherits="Backoffice_Registrasi_RIList" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
    </asp:ScriptManager>
    <table class="adminheading" id="Table3">
		<tr>
			<th class="menudottedline">
				<%= Resources.GetString("RS", "TitleRegistrasiListRI")%>
			</th>
			<td class="menudottedline" align="right">
				<asp:linkbutton id="btnOld" onclick="OnOldRecord" runat="server"></asp:linkbutton>
				<asp:linkbutton id="btnNew" onclick="OnNewRecord" runat="server"></asp:linkbutton>
			</td>
		</tr>
	</table>

	<table class="adminform" id="Table1" border="0">
		<tr>
            <td colspan="2" class="asetselector">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            Kelas:
                        </td>
                        <td>
                            <asp:DropDownList ID="cmbKelas" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbKelas_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        <td align="left">
                            Ruangan:</td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList id="cmbRuang" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbRuang_SelectedIndexChanged" ></asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="cmbKelas" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td align="left">
                            Nomor Kamar:</td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                     <asp:DropDownList id="cmbNoRuang" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbNoRuang_SelectedIndexChanged" ></asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="cmbKelas" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="cmbRuang" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
                
             </td>
		</tr>
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
												    <asp:ListItem Value="Nama">Nama Pasien</asp:ListItem>
                                                    <asp:ListItem Value="NRP">NRP</asp:ListItem>
											        <asp:ListItem Value="NoRegistrasi">Nomor Kunjungan</asp:ListItem>
                                                    <asp:ListItem Value="NoRM">Nomor RM</asp:ListItem>
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
						    <td colspan="2">
						        <asp:datagrid id="DataGridList" runat="server" CssClass="DataGridList" OnItemCreated="PageItemCreated"
								    OnSortCommand="SortByColumn" OnPageIndexChanged="PageChanged" AutoGenerateColumns="False" DataKeyField="RawatInapId"
								    AllowPaging="True" AllowSorting="True" OnDeleteCommand="DataGridList_DeleteCommand">
								    <SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
								    <AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
								    <ItemStyle CssClass="ItemStyle"></ItemStyle>
								    <HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
								    <FooterStyle CssClass="FooterSytle"></FooterStyle>
								    <Columns>
									    <asp:TemplateColumn HeaderText="No">
										    <ItemStyle HorizontalAlign="Right" Width="25px" VerticalAlign="Top"></ItemStyle>
										    <ItemTemplate>
											    <asp:label id="lblgNoKe" runat="server" Text="<%#++NoKe%>">
											    </asp:label>.
										    </ItemTemplate>
									    </asp:TemplateColumn>
									    <asp:TemplateColumn SortExpression="TanggalRegistrasi" HeaderText="Tanggal">
										    <ItemStyle Width="60px"></ItemStyle>
										    <ItemTemplate>
											    <asp:label ID="lblgTanggalRegistrasi" Width="100%" runat="server" Text='<%# ((DateTime)DataBinder.Eval(Container, "DataItem.TanggalRegistrasi")).ToString("dd/MM/yyyy") %>' >
											    </asp:label>
										    </ItemTemplate>
									    </asp:TemplateColumn>
									    <asp:TemplateColumn SortExpression="NoRegistrasi" HeaderText="No Kunjungan">
										    <ItemStyle Width="100px"></ItemStyle>
										    <ItemTemplate>
											    <asp:label ID="llblgNoRegistrasi" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NoRegistrasi") %>' >
											    </asp:label>
										    </ItemTemplate>
									    </asp:TemplateColumn>
									    <asp:TemplateColumn SortExpression="NoRM" HeaderText="Nomor RM">
										    <ItemStyle Width="75px"></ItemStyle>
										    <ItemTemplate>
											    <asp:label ID="lblgNoRM" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NoRM") %>' >
											    </asp:label>
										    </ItemTemplate>
									    </asp:TemplateColumn>
									    <asp:TemplateColumn SortExpression="Nama" HeaderText="Nama Pasien">
										    <ItemTemplate>
											    <asp:label ID="lblgNama" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Nama") %>' >
											    </asp:label>
										    </ItemTemplate>
									    </asp:TemplateColumn>
									    <asp:TemplateColumn SortExpression="Umur" HeaderText="Umur">
										    <ItemStyle Width="40px"></ItemStyle>
										    <ItemTemplate>
											    <asp:label ID="lblgUmur" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Umur") %>' >
											    </asp:label>
										    </ItemTemplate>
									    </asp:TemplateColumn>
									    <asp:TemplateColumn SortExpression="KelasNama" HeaderText="Kelas">
										    <ItemStyle Width="50px"></ItemStyle>
										    <ItemTemplate>
											    <asp:label ID="lblKelasNama" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.KelasNama") %>' >
											    </asp:label>
										    </ItemTemplate>
									    </asp:TemplateColumn>
									    <asp:TemplateColumn SortExpression="RuangNama" HeaderText="Ruangan">
										    <ItemStyle Width="75px"></ItemStyle>
										    <ItemTemplate>
											    <asp:label ID="lblgRuangNama" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RuangNama") %>' >
											    </asp:label>
										    </ItemTemplate>
									    </asp:TemplateColumn>
									    <asp:TemplateColumn SortExpression="NomorRuang" HeaderText="Nomor Kamar">
										    <ItemStyle Width="50px"></ItemStyle>
										    <ItemTemplate>
											    <asp:label ID="lblNomorRuang" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NomorRuang") %>' >
											    </asp:label>
										    </ItemTemplate>
									    </asp:TemplateColumn>
									    <asp:TemplateColumn HeaderText="<div align=center>Action</div>">
										    <ItemStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Top"></ItemStyle>
										    <ItemTemplate>
											    <%# GetLinkButton(DataBinder.Eval(Container, "DataItem.RawatInapId").ToString(), DataBinder.Eval(Container, "DataItem.NoRegistrasi").ToString(), DataGridList.CurrentPageIndex.ToString())%>
										        <asp:LinkButton ID="btnDelete" OnClientClick="return confirm('Apakah anda yakin akan menghapus data ini ?');" Visible='<%# GetLinkDelete(DataBinder.Eval(Container, "DataItem.StatusRawatInap").ToString())%>' CssClass="toolbar" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
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
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cmbKelas" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="cmbRuang" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="cmbNoRuang" EventName="SelectedIndexChanged" />
                    </Triggers>
				</asp:UpdatePanel>
			</td>
		</tr>
	</table>
</asp:Content>

