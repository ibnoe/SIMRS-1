<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="RJDelete.aspx.cs" Inherits="Backoffice_Registrasi_RJDelete" Title="Untitled Page" %>
<%@ Register Src="../Controls/ViewRegistrasiRJ.ascx" TagName="ViewRegistrasiRJ" TagPrefix="uc2" %>
<%@ Register Src="../Controls/ViewDataUmum.ascx" TagName="ViewDataUmum" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../../js/Popup.js"></script>
    <asp:HiddenField ID="HFStatusRawatJalan" runat="server" />
    <asp:HiddenField ID="HFRegistrasiId" runat="server" />
    <asp:HiddenField ID="HFRawatJalanId" runat="server" />
    <asp:HiddenField ID="HFPasienId" runat="server" />
    <table class="adminheading">
	    <tr>
		    <th class="menudottedline">
                <asp:Label ID="lblTitleHeader" runat="server"></asp:Label>
		    </th>
	    </tr>
    </table>
    <table class="collapsePanelHeader">
	    <tr>
		    <td>
			    <div style="float: left; margin-left: 0px; color:Black; font-size:medium; width:200px; text-align:right;">Nomor Rekam Medis:</div>
                <div style="float: left; margin-left:5px; color:White; font-size:medium; font-weight:bold; width:150px;">
                    <asp:Label ID="lblNoRMHeader" runat="server">__________________</asp:Label></div>
                <div style="float: left; margin-left:5px; color:Black; font-size:medium; width:150px; text-align:right;">Nama Pasien:</div>
                <div style="float: left; margin-left:5px; color:White; font-size:medium; font-weight:bold; width:200px;">
                    <asp:Label ID="lblNamaPasienHeader" runat="server">__________________</asp:Label></div>
                <div style="float: right; text-align:right;">
                    </div>
                </td>
	    </tr>
    </table>
    <ajaxToolkit:TabContainer ID="TabPasien" runat="server" ActiveTabIndex="1">
        <ajaxToolkit:TabPanel ID="TabUmum" runat="server" HeaderText="Data Umum">
            <HeaderTemplate>
                Data Umum
            </HeaderTemplate>
            <ContentTemplate>
                <uc1:ViewDataUmum ID="UCViewDataUmum" runat="server" />
                <hr />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabRegistrasi" runat="server" HeaderText="Data TabRegistrasi">
            <HeaderTemplate>
                Data Kunjungan 
            </HeaderTemplate>
            <ContentTemplate>
                <uc2:ViewRegistrasiRJ ID="UCViewRegistrasiRJ" runat="server" />
                <hr />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
    <asp:Button ID="btnDelete" runat="server" Text="Button" />
    <asp:Button ID="btnCancel" runat="server" Text="Button" />
</asp:Content>

