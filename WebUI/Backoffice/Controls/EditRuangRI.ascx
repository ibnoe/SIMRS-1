<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditRuangRI.ascx.cs" Inherits="Backoffice_Controls_EditRuangRI" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
    <div class="title">
        <asp:TextBox ID="txtKelasId" runat="server" Visible="False" Width="21px"></asp:TextBox>
        <asp:TextBox ID="txtRawatInapId" runat="server" Visible="False" Width="21px"></asp:TextBox>
        <asp:TextBox ID="txtPasienId" runat="server" Visible="False" Width="21px"></asp:TextBox>
        <asp:TextBox ID="txtStatusRawatInap" runat="server" Visible="False" Width="21px"></asp:TextBox>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width:100%">
                    <tr>
                        <td style="width:100%;text-align:center">
                            <asp:Label ID="lblWarning" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="GV" EventName="SelectedIndexChanging" />
                <asp:AsyncPostBackTrigger ControlID="GV" EventName="PageIndexChanging" />
                <asp:AsyncPostBackTrigger ControlID="GV" EventName="RowDeleting" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <asp:UpdatePanel ID="UPList" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlList" runat="server" Width="100%">
                <asp:GridView CssClass="DataGridList" ID="GV" runat="server"
                    AutoGenerateColumns="False" DataKeyNames="TempatInapId" OnRowEditing="GV_RowEditing" OnPageIndexChanging="GV_PageIndexChanging" OnSelectedIndexChanging="GV_SelectedIndexChanging" Width="100%" OnRowDeleting="GV_RowDeleting" OnSorting="GV_Sorting">
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
                            <ItemStyle Width="40px" />
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
                            <ItemStyle Width="60px" />
                            <ItemTemplate>
                                <asp:Label ID="lblgRuangNama" runat="server" Text='<%# Eval("RuangNama") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nomor Kamar" SortExpression="NomorRuang">
                            <ItemStyle Width="50px" />
                            <ItemTemplate>
                                <asp:Label ID="lblgNomorRuang" runat="server" Text='<%# Eval("NomorRuang") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nomor Tempat Tidur" SortExpression="NomorTempat">
                            <ItemStyle Width="50px" />
                            <ItemTemplate>
                                <asp:Label ID="lblgNomorTempat" runat="server" Text='<%# Eval("NomorTempat") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Keterangan" SortExpression="Keterangan">
                            <ItemTemplate>
                                <asp:Label ID="lblgKeterangan" runat="server" Text='<%# Eval("Keterangan") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemStyle  HorizontalAlign="Center" Width="150px" />
                            <ItemTemplate>
                                <asp:Button ID="btnDetil" runat="server" Visible='<%# GetLinkPindah(Eval("FlagTerakhir").ToString()) %>' CausesValidation="false" CommandName="Select" Text="Pindah" />
                                <asp:Button ID="btnEdit" runat="server" Visible='<%# GetLinkPulang(Eval("FlagTerakhir").ToString()) %>' CausesValidation="false" CommandName="Edit" Text="Pulang" />
                                <asp:Button ID="btnDelete" Visible='<%# GetLinkDelete(Eval("FlagTerakhir").ToString(),NoKe.ToString()) %>' OnClientClick="return confirm('Apakah anda yakin akan menghapus data ini ?');"  runat="server" CausesValidation="false" CommandName="Delete" Text="Hapus" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle VerticalAlign="Top" Width="100%" CssClass="ItemStyle" />
                    <EmptyDataTemplate>
                        Belum Terdapat Ruang Inap. 
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
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GV" EventName="PageIndexChanging" />
            <asp:AsyncPostBackTrigger ControlID="GV" EventName="RowEditing" />
            <asp:AsyncPostBackTrigger ControlID="GV" EventName="SelectedIndexChanging" />
            <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="GV" EventName="RowDeleting" />
            <asp:AsyncPostBackTrigger ControlID="GV" EventName="Sorting" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UPEdit" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlView" runat="server" Width="100%">
                <table class="adminform" border="0" width="100%">
                    <tr>
                        <th style="text-align:left" colspan="3">
                            <asp:Label ID="lblRuangInapSebelumnya" runat="server" Text="Ruang Inap Sebelumnya"></asp:Label>
                            <hr />
                            <asp:Label ID="lblTempatInapId" runat="server" Text="" Visible="false"></asp:Label>
                        </th>
                    </tr>
                    <tr>
                        <td class="text">
                            Tanggal Masuk</td>
                        <td class="separator">
                            :</td>
                        <td class="value">
                            <asp:Label ID="lblTanggalMasuk" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Jam Masuk</td>
                        <td class="separator">
                            :</td>
                        <td class="value">
                            <asp:Label ID="lblJamMasuk" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Tanggal Keluar</td>
                        <td class="separator">
                            :</td>
                        <td class="value">
                            <asp:Label ID="lblTanggalKeluar" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Jam Keluar</td>
                        <td class="separator">
                            :</td>
                        <td class="value">
                            <asp:Label ID="lblJamKeluar" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Jam Inap</td>
                        <td class="separator">
                            :</td>
                        <td class="value">
                            <asp:Label ID="lblJamInap" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Ruang Inap</td>
                        <td class="separator">
                            :</td>
                        <td class="value">
                            <asp:Label ID="lblRuangRawat" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Nomor Tempat Tidur</td>
                        <td class="separator">
                            :</td>
                        <td class="value">
                            <asp:Label ID="lblNomorTempat" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">Keterangan</td>
                        <td class="separator">:</td>
                        <td class="value">
                            <asp:Label ID="lblKeterangan" runat="server" Text=""></asp:Label>
                            </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlEdit" runat="server" Width="100%">
                <table class="adminform" border="0" width="100%">
                    <tr>
                        <th style="text-align:left" colspan="3">
                            <asp:Label ID="lblTitleEditForm" runat="server" Text="Tambah data"></asp:Label>
                            <hr />
                        </th>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                            <asp:ValidationSummary ID="VSEdit" runat="server" DisplayMode="SingleParagraph" HeaderText="Tanda * harus diisi atau dipilih!" />
                            <asp:TextBox ID="txtTempatInapId" Visible="false" runat="server" Width="27px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="text">
                            Tanggal Masuk</td>
                        <td class="separator">
                            :</td>
                        <td class="value">
                            <asp:TextBox ID="txtTanggalMasuk" runat="server" Width="60px" MaxLength="1" style="text-align:justify" ValidationGroup="MKETanggalMasuk" AutoPostBack="True" OnTextChanged="txtTanggalMasuk_TextChanged" />
                            <asp:ImageButton ID="ImgTanggalMasuk" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" CausesValidation="False" />
                            <asp:RequiredFieldValidator ID="RVTanggalMasuk" runat="server" ControlToValidate="txtTanggalMasuk" >*</asp:RequiredFieldValidator>
                            <ajaxToolkit:MaskedEditExtender ID="MEETanggalMasuk" runat="server"
                                TargetControlID="txtTanggalMasuk"
                                Mask="99/99/9999"
                                MessageValidatorTip="true"
                                OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError"
                                MaskType="Date"
                                DisplayMoney="Left"
                                AcceptNegative="Left"
                                ErrorTooltipEnabled="True" ClearTextOnInvalid="True" />
                            <ajaxToolkit:MaskedEditValidator ID="MEVTanggalMasuk" runat="server"
                                ControlExtender="MEETanggalMasuk"
                                ControlToValidate="txtTanggalMasuk"
                                IsValidEmpty="False"
                                EmptyValueMessage="Tanggal Masuk Harus Diisi"
                                InvalidValueMessage="Format Tanggal Salah"
                                Display="Dynamic"
                                TooltipMessage="(Tanggal/Bulan/Tahun)"
                                EmptyValueBlurredText="*"
                                InvalidValueBlurredMessage="Format Tanggal Salah"
                                ValidationGroup="MKETanggalMasuk" />
                            <ajaxToolkit:CalendarExtender ID="CETanggalMasuk" CssClass="MyCalendar" runat="server" TargetControlID="txtTanggalMasuk" PopupButtonID="ImgTanggalMasuk" />
                        </td>
                    </tr>
                    <tr>
                       <td class="text">
                           Jam Masuk</td>
                       <td class="separator">
                           :</td>
                       <td class="value">
                            <asp:TextBox ID="txtJamMasuk" runat="server" Width="34px" Height="16px" ValidationGroup="MKEJamMasuk" AutoPostBack="True" OnTextChanged="txtJamMasuk_TextChanged" />
                            <asp:RequiredFieldValidator ID="RVJamMasuk" runat="server" ControlToValidate="txtJamMasuk">*</asp:RequiredFieldValidator>
                            <ajaxToolkit:MaskedEditExtender ID="MEEJamMasuk" runat="server"
                                TargetControlID="txtJamMasuk" 
                                Mask="99:99"
                                MessageValidatorTip="true"
                                OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError"
                                MaskType="Time"
                                AcceptAMPM="True"
                                ErrorTooltipEnabled="True" ClearTextOnInvalid="True" />
                            <ajaxToolkit:MaskedEditValidator ID="MEVJamMasuk" runat="server"
                                ControlExtender="MEEJamMasuk"
                                ControlToValidate="txtJamMasuk"
                                IsValidEmpty="False"
                                EmptyValueMessage="Jam Masuk Harus diisi"
                                InvalidValueMessage="Format Jam Masuk Salah"
                                Display="Dynamic"
                                TooltipMessage="(Jam:Menit)"
                                EmptyValueBlurredText="*"
                                InvalidValueBlurredMessage="*"
                                ValidationGroup="MKEJamMasuk"/>
                       </td>
                   </tr>
                   <tr>
                        <td class="text">
                            Tanggal Keluar</td>
                        <td class="separator">
                            :</td>
                        <td class="value">
                            <asp:TextBox ID="txtTanggalKeluar" runat="server" Width="60px" MaxLength="1" style="text-align:justify" ValidationGroup="MKETanggalKeluar" />
                            <asp:ImageButton ID="ImgTanggalKeluar" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" CausesValidation="False" />
                            <ajaxToolkit:MaskedEditExtender ID="MEETanggalKeluar" runat="server"
                                TargetControlID="txtTanggalKeluar"
                                Mask="99/99/9999"
                                MessageValidatorTip="true"
                                OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError"
                                MaskType="Date"
                                DisplayMoney="Left"
                                AcceptNegative="Left"
                                ErrorTooltipEnabled="True" ClearTextOnInvalid="True" />
                            <ajaxToolkit:MaskedEditValidator ID="MEVTanggalKeluar" runat="server"
                                ControlExtender="MEETanggalKeluar"
                                ControlToValidate="txtTanggalKeluar"
                                IsValidEmpty="True"
                                EmptyValueMessage="Tanggal Keluar Harus Diisi"
                                InvalidValueMessage="Format Tanggal Salah"
                                Display="Dynamic"
                                TooltipMessage="(Tanggal/Bulan/Tahun)"
                                EmptyValueBlurredText="*"
                                InvalidValueBlurredMessage="Format Tanggal Salah"
                                ValidationGroup="MKETanggalKeluar" />
                            <ajaxToolkit:CalendarExtender ID="CETanggalKeluar" CssClass="MyCalendar" runat="server" TargetControlID="txtTanggalKeluar" PopupButtonID="ImgTanggalKeluar" />
                        </td>
                    </tr>
                    <tr>
                       <td class="text">
                           Jam Keluar</td>
                       <td class="separator">
                           :</td>
                       <td class="value">
                            <asp:TextBox ID="txtJamKeluar" runat="server" Width="34px" Height="16px" ValidationGroup="MKEJamKeluar" />
                            <ajaxToolkit:MaskedEditExtender ID="MEEJamKeluar" runat="server"
                                TargetControlID="txtJamKeluar" 
                                Mask="99:99"
                                MessageValidatorTip="true"
                                OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError"
                                MaskType="Time"
                                AcceptAMPM="True"
                                ErrorTooltipEnabled="True" ClearTextOnInvalid="True" />
                            <ajaxToolkit:MaskedEditValidator ID="MEVJamKeluar" runat="server"
                                ControlExtender="MEEJamKeluar"
                                ControlToValidate="txtJamKeluar"
                                IsValidEmpty="True"
                                EmptyValueMessage="Jam Keluar Harus diisi"
                                InvalidValueMessage="Format Jam Keluar Salah"
                                Display="Dynamic"
                                TooltipMessage="(Jam:Menit)"
                                EmptyValueBlurredText="*"
                                InvalidValueBlurredMessage="*"
                                ValidationGroup="MKEJamKeluar"/>
                       </td>
                   </tr>
                   <tr>
                        <td class="text">Jam Inap</td>
                        <td class="separator">:</td>
                        <td class="value">
                            <asp:TextBox ID="txtJamInap" runat="server" MaxLength="4" ReadOnly="true" Width="40px"></asp:TextBox></td>
                    </tr>
                    <tr>
                       <td class="text">
                           Kelas</td>
                       <td class="separator">
                           :</td>
                       <td class="value">
                           <asp:DropDownList ID="cmbKelas" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbKelas_SelectedIndexChanged">
                           </asp:DropDownList>
                           <asp:RequiredFieldValidator ID="RVKelas" runat="server" ControlToValidate="cmbKelas">*</asp:RequiredFieldValidator></td>
                   </tr>
                   <tr>
                       <td class="text">
                           Ruang</td>
                       <td class="separator">
                           :</td>
                       <td class="value">
                           <asp:DropDownList ID="cmbRuang" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbRuang_SelectedIndexChanged">
                           </asp:DropDownList>
                           <asp:RequiredFieldValidator ID="RVRuang" runat="server" ControlToValidate="cmbRuang">*</asp:RequiredFieldValidator></td>
                   </tr>
                   <tr>
                       <td class="text">
                           Nomor Kamar/Ruang</td>
                       <td class="separator">
                           :</td>
                       <td class="value">
                           <asp:DropDownList ID="cmbNomorRuang" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbNomorRuang_SelectedIndexChanged">
                           </asp:DropDownList>
                           <asp:RequiredFieldValidator ID="RVNomorRuang" runat="server" ControlToValidate="cmbNomorRuang">*</asp:RequiredFieldValidator></td>
                   </tr>
                   <tr>
                       <td class="text">
                           No.Tempat Tidur</td>
                       <td class="separator">
                           :</td>
                       <td class="value">
                           <asp:DropDownList ID="cmbNomorTempat" runat="server">
                           </asp:DropDownList>
                       </td>
                   </tr>
                    <tr>
                        <td class="text">Keterangan</td>
                        <td class="separator">:</td>
                        <td class="value">
                            <asp:TextBox ID="txtKeterangan" TextMode="MultiLine" Rows="3" runat="server" MaxLength="255" Width="350px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="text"></td>
                        <td class="separator"></td>
                        <td class="value">
                            <asp:Button ID="btnSave" OnClientClick="return confirm('Apakah anda yakin akan melakukan proses ini?');" runat="server" Text="Simpan" OnClick="btnSave_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Batal" CausesValidation="False" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <hr />
                            Tanda <span style="color: #ff0000">*</span> harus diisi atau dipilih
                        </td>
                    </tr>
                </table>
            </asp:Panel>    
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GV" EventName="SelectedIndexChanging" />
            <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="GV" EventName="RowEditing" />
        </Triggers>
    </asp:UpdatePanel>