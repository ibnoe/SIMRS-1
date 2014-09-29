<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dlgDetilLayananRI.aspx.cs" Inherits="Backoffice_Pasien_dlgDetilLayananRI" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Print Rincian Biaya Rawat Inap</title>
    <link href="../../css/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="adminheading"  style="width:100%">
	        <tr>
		        <th class="menudottedline">
		            Print Rincian Biaya Rawat Inap
		        </th>
	        </tr>
        </table>
        <table width="100%">
            <tr>
                <td align="center">
                    <table style="width:500px;background-color:Silver;" cellspacing="1">
                        <tr>
                            <td style="width:100px;text-align:left;background-color:White;">Nomor RM</td>
                            <td style="text-align:left;background-color:White;">
                                <asp:Label ID="lblNoRM" runat="server"></asp:Label>
                                <asp:HiddenField ID="HFRawatInapId" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width:100px;text-align:left;background-color:White;">Nama Pasien</td>
                            <td style="text-align:left;background-color:White;">
                                <asp:Label ID="lblNamaPasienHeader" runat="server"></asp:Label>
                                <asp:Label ID="lblUmurPasienHeader" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:100;text-align:left;background-color:White;">Status Pasien</td>
                            <td style="text-align:left;background-color:White;">
                                <asp:Label ID="lblStatusPasienHeader" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:100;text-align:left;background-color:White;">Ruang Rawat</td>
                            <td style="text-align:left;background-color:White;">
                                <asp:DropDownList ID="cmbRuangRawat" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:100;text-align:left;background-color:White;"></td>
                            <td style="text-align:left;background-color:White;">
                                <asp:Button ID="btnPrint" CssClass="button" runat="server" Text="Print" OnClick="btnPrint_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
