<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Backoffice_Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%= ConfigurationManager.AppSettings["Main.Title"].ToString() %></title>
    <script language="javascript" type="text/javascript">
			function setFocus() {
				document.index.txtUserName.select();
				document.index.txtUserName.focus();
			}
		</script>

    <link href="../css/admin_login.css" rel="stylesheet" type="text/css" />
</head>
<body onload="setFocus();">
    <form id="index" method="post" runat="server">
			<table id="TableMain" cellspacing="0" cellpadding="0" width="100%" border="0" align="center">
				<tr>
					<td valign="top" height="400"><br />
						<div align="center">
							<div class="main">
								<table width="100%" border="0">
									<tr>
										<td valign="middle" align="center">
											<div class="login">
												<div class="login-form">
													<img src='<%= Request.ApplicationPath + "/images/blank.gif" %>' height="70" width="64">
													<div class="form-block">
														<div class="inputlabel">Username</div>
														<div><input class="inputbox" id="txtUserName" type="text" size="15" name="txtUserName" runat="server" /></div>
														<div class="inputlabel">Password</div>
														<div><input class="inputbox" id="txtPassword" type="password" size="15" name="pass" runat="server" /></div>
														<div align="left">
														    <input class="button" id="btnLogin" type="submit" value="Login" name="submit" runat="server" onserverclick="btnLogin_ServerClick" />
														    <input class="button" id="btnClose" type="submit" value="Close" onclick="javascript:window.close()" />
														</div>
														
													</div>
												</div>
												<div class="login-text">
													<img src='<%= Request.ApplicationPath + "/images/blank.gif" %>' height="80" width="64">
													<p><b> SIMRS <br />Ver:1.0</b></p>
													<p><asp:Label id="txtHeader" runat="server" ForeColor="Red"></asp:Label></p>
												</div>
												<div class="clr"></div>
											</div>
										</td>
									</tr>
								</table>
							</div>
						</div>
					</td>
				</tr>
				<tr>
					<td align="center" bgColor="#ffffff"></td>
				</tr>
			</table>
			&nbsp;
		</form>
</body>
</html>
