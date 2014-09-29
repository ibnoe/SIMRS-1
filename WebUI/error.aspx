<%@ Page Language="C#" AutoEventWireup="true" CodeFile="error.aspx.cs" Inherits="error" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Error</h1>
			<p>Sistem tidak dapat memenuhi request Anda. Silakan hubungi Administrator.
				<asp:Button id="btnHome" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 144px" runat="server"
					Text="OK" onclick="btnHome_Click"></asp:Button></p>
    </div>
    </form>
</body>
</html>
