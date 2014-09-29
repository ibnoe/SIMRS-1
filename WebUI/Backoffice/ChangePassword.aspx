<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Backoffice_ChangePassword" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="Table4" cellspacing="0" cellpadding="0" width="100%" border="0">
	    <tr>
		    <td>
			    <table class="adminheading" id="Table3">
				    <tr>
					    <th class="menudottedline">
						    <asp:label id="lblTitle" runat="server">Ganti Password</asp:label></th>
					    <td class="menudottedline" align="right">&nbsp;
					    </td>
				    </tr>
			    </table>
		    </td>
	    </tr>
	    <tr>
		    <td>
			    <asp:Panel id="pnlEdit" runat="server">
				    <table class="adminform" id="Table1" border="0">
					    <tr>
						    <td colspan="2">
							    <asp:Label id="lblError" runat="server" ForeColor="Red"></asp:Label></td>
					    </tr>
					    <tr>
						    <td class="text">Username</td>
						    <td>
							    <asp:TextBox id="txtUserName" runat="server" MaxLength="50" ReadOnly="True"></asp:TextBox>
							    <asp:TextBox id="txtUserId" runat="server" MaxLength="50" Visible="False" Width="8px"></asp:TextBox></td>
					    </tr>
					    <tr>
						    <td class="text">Password Lama</td>
						    <td>
							    <asp:TextBox id="txtOldPassword" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
							    <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="txtOldPassword" ErrorMessage="*"></asp:RequiredFieldValidator></td>
					    </tr>
					    <tr>
						    <td class="text">Password Baru</td>
						    <td>
							    <asp:TextBox id="txtNewPassword" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
							    <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPassword" ErrorMessage="*"></asp:RequiredFieldValidator></td>
					    </tr>
					    <tr>
						    <td class="text">Verifikasi Password</td>
						    <td>
							    <asp:TextBox id="txtVerifyPassword" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
							    <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ControlToValidate="txtVerifyPassword"
								    ErrorMessage="*"></asp:RequiredFieldValidator>
							    <asp:CompareValidator id="CompareValidator1" runat="server" ControlToValidate="txtVerifyPassword" ErrorMessage="Password harus sama"
								    ControlToCompare="txtNewPassword"></asp:CompareValidator></td>
					    </tr>
				    </table>
				    <table class="adminheading" id="Table2">
					    <tr>
						    <td class="menudottedline" width="150">&nbsp;</td>
						    <td class="menudottedline" align="left" width="50">
							    <div class="toolbar" onmouseover="MM_swapImage('save','','../images/save_f2.gif',1);"
								    onmouseout="MM_swapImgRestore();">
								    <asp:linkbutton id="btnSave" onclick="OnSave" runat="server"></asp:linkbutton></div>
						    </td>
						    <td class="menudottedline" align="left" width="50">
							    <div class="toolbar" onmouseover="MM_swapImage('cancel','','../images/cancel_f2.gif',1);"
								    onmouseout="MM_swapImgRestore();"><input id="Button1" onclick="javascript:window.history.go(-1);" type="image" src="../images/cancel_f2.gif"
									    value="Button" name="Button1" runat="server"><BR>
								    Batal</div>
						    </td>
						    <td class="menudottedline">&nbsp;</td>
					    </tr>
				    </table>
			    </asp:Panel>
			    <asp:Panel id="pnlOK" runat="server" HorizontalAlign="Center" Visible="False">
				    <asp:Label id="lblOK" runat="server" Font-Bold="True">Password Anda telah  behasil disimpan</asp:Label>
			    </asp:Panel></td>
	    </tr>
    </table>
</asp:Content>

