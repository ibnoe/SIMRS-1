<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintRekapKasirRJ.aspx.cs" Inherits="Backoffice_Pasien_PrintRekapKasirRJ" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="CRVPasien" runat="server" AutoDataBind="True"
            Height="50px" Width="350px" DisplayGroupTree="False" HasCrystalLogo="False" HasDrillUpButton="False" HasSearchButton="False" HasToggleGroupTreeButton="False" HasZoomFactorList="False" HasViewList="False" />
    
    </div>
        <asp:TextBox ID="txtTanggalMulai" Visible="False" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtTanggalSelesai" Visible="False" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtModeRekap" Visible="false" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtPoliklinikId" Visible="False" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtUserId" runat="server" Visible="False"></asp:TextBox>
    </form>
</body>
</html>
