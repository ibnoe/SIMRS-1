<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="FISList.aspx.cs" Inherits="Backoffice_Registrasi_FISList" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
    </asp:ScriptManager>
    <table class="adminheading" id="Table3">
		<tr>
			<th class="menudottedline">
				<%= Resources.GetString("RS", "TitleRegistrasiListFIS")%>
			</th>
			<td class="menudottedline" align="right">
				<asp:linkbutton id="btnNew" onclick="OnNewRecord" runat="server"></asp:linkbutton>
				<asp:linkbutton id="btnAddRJ" onclick="OnAddRJ" runat="server"></asp:linkbutton>
				<asp:linkbutton id="btnAddRI" onclick="OnAddRI" runat="server"></asp:linkbutton>
			</td>
		</tr>
	</table>

	<table class="adminform" id="Table1" border="0">
		<tr>
            <td colspan="2" class="asetselector">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            Tanggal:
                        </td>
                        <td>
                            <asp:TextBox ID="txtTanggalRegistrasi" runat="server" Width="75px" MaxLength="1" style="text-align:justify" ValidationGroup="MKE" OnTextChanged="txtTanggalRegistrasi_TextChanged" AutoPostBack="True" />
                            <asp:ImageButton ID="ImgTanggalRegistrasi" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" CausesValidation="False" />
                            <ajaxToolkit:MaskedEditExtender ID="MEETanggalRegistrasi" runat="server"
                                TargetControlID="txtTanggalRegistrasi"
                                Mask="99/99/9999"
                                MessageValidatorTip="true"
                                OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError"
                                MaskType="Date"
                                DisplayMoney="Left"
                                AcceptNegative="Left"
                                ErrorTooltipEnabled="True" ClearTextOnInvalid="True" />
                            <ajaxToolkit:MaskedEditValidator ID="MEVTanggalRegistrasi" runat="server"
                                ControlExtender="MEETanggalRegistrasi"
                                ControlToValidate="txtTanggalRegistrasi"
                                EmptyValueMessage="Tanggal Harus Diisi"
                                InvalidValueMessage="Format Tanggal Salah"
                                Display="Dynamic"
                                TooltipMessage="(Tanggal/Bulan/Tahun)"
                                InvalidValueBlurredMessage="Format Tanggal Salah"
                                ValidationGroup="MKE" />
                            <ajaxToolkit:CalendarExtender ID="CETanggalRegistrasi" CssClass="MyCalendar" runat="server" TargetControlID="txtTanggalRegistrasi" PopupButtonID="ImgTanggalRegistrasi" />
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
								    OnSortCommand="SortByColumn" OnPageIndexChanged="PageChanged" AutoGenerateColumns="False" DataKeyField="RawatJalanId"
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
											    <asp:label id="Label4" runat="server" Text="<%#++NoKe%>">
											    </asp:label>.
										    </ItemTemplate>
									    </asp:TemplateColumn>
									    <asp:TemplateColumn SortExpression="TanggalRegistrasi" HeaderText="Tanggal">
										    <ItemStyle Width="60px"></ItemStyle>
										    <ItemTemplate>
											    <asp:label ID="Label1" Width="100%" runat="server" Text='<%# ((DateTime)DataBinder.Eval(Container, "DataItem.TanggalRegistrasi")).ToString("dd/MM/yyyy") %>' >
											    </asp:label>
										    </ItemTemplate>
									    </asp:TemplateColumn>
									    <asp:TemplateColumn SortExpression="NoRegistrasi" HeaderText="No Kunjungan">
										    <ItemStyle Width="100px"></ItemStyle>
										    <ItemTemplate>
											    <asp:label ID="Label2" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NoRegistrasi") %>' >
											    </asp:label>
										    </ItemTemplate>
									    </asp:TemplateColumn>
									    <asp:TemplateColumn SortExpression="NoRM" HeaderText="Nomor RM">
										    <ItemStyle Width="75px"></ItemStyle>
										    <ItemTemplate>
											    <asp:label ID="Label3" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NoRM") %>' >
											    </asp:label>
										    </ItemTemplate>
									    </asp:TemplateColumn>
									    <asp:TemplateColumn SortExpression="Nama" HeaderText="Nama Pasien">
										    <ItemStyle Width="150px"></ItemStyle>
										    <ItemTemplate>
											    <asp:label ID="Label5" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Nama") %>' >
											    </asp:label>
										    </ItemTemplate>
									    </asp:TemplateColumn>
									    <asp:TemplateColumn SortExpression="Umur" HeaderText="Umur">
										    <ItemStyle Width="40px"></ItemStyle>
										    <ItemTemplate>
											    <asp:label Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Umur") %>' >
											    </asp:label>
										    </ItemTemplate>
									    </asp:TemplateColumn>
									    <asp:TemplateColumn SortExpression="Keterangan" HeaderText="Keterangan">
										    <ItemTemplate>
											    <asp:label ID="lblKeterangan" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Keterangan") %>' >
											    </asp:label>
										    </ItemTemplate>
									    </asp:TemplateColumn>
									    <asp:TemplateColumn HeaderText="&lt;div align=center&gt;Action&lt;/div&gt;">
										    <ItemStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Top"></ItemStyle>
										    <ItemTemplate>
											    <%# GetLinkButton(DataBinder.Eval(Container, "DataItem.RawatJalanId").ToString(), DataBinder.Eval(Container, "DataItem.StatusRawatJalan").ToString(),DataBinder.Eval(Container, "DataItem.NoRegistrasi").ToString(), DataGridList.CurrentPageIndex.ToString())%>
											    <asp:LinkButton ID="btnDelete" OnClientClick="return confirm('Apakah anda yakin akan menghapus data ini ?');" Visible='<%# GetLinkDelete(DataBinder.Eval(Container, "DataItem.StatusRawatJalan").ToString())%>' CssClass="toolbar" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
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
                        <asp:AsyncPostBackTrigger ControlID="txtTanggalRegistrasi" EventName="TextChanged" />
                    </Triggers>
				</asp:UpdatePanel>
			</td>
		</tr>
	</table>
</asp:Content>

