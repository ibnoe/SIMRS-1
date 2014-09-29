<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DetilLayananRI.aspx.cs" Inherits="Backoffice_Pasien_DetilLayananRI" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="CRVPasien" runat="server" AutoDataBind="True"
            Height="50px" Width="350px" DisplayGroupTree="False" HasCrystalLogo="False" HasDrillUpButton="False" HasGotoPageButton="True" HasPageNavigationButtons="True" HasSearchButton="False" HasToggleGroupTreeButton="False" HasZoomFactorList="False" HasViewList="False" />
    </div>
    </form>
</body>
</html>
