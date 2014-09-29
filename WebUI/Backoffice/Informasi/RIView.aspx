<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="RIView.aspx.cs" Inherits="Backoffice_Informasi_RIView" Title="Untitled Page" %>
<%@ Register Src="../Controls/ViewDepositRI.ascx" TagName="ViewDepositRI" TagPrefix="uc8" %>
<%@ Register Src="../Controls/HeaderRI.ascx" TagName="HeaderRI" TagPrefix="uc5" %>
<%@ Register Src="../Controls/ViewKuitansiRI.ascx" TagName="ViewKuitansiRI" TagPrefix="uc6" %>
<%@ Register Src="../Controls/ViewRuangRI.ascx" TagName="ViewRuangRI" TagPrefix="uc5" %>
<%@ Register Src="../Controls/ViewKasirRI.ascx" TagName="ViewKasirRI" TagPrefix="uc4" %>
<%@ Register Src="../Controls/ViewRekamMedisRI.ascx" TagName="ViewRekamMedisRI" TagPrefix="uc3" %>
<%@ Register Src="../Controls/ViewRegistrasiRI.ascx" TagName="ViewRegistrasiRI" TagPrefix="uc2" %>
<%@ Register Src="../Controls/ViewDataUmum.ascx" TagName="ViewDataUmum" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../../js/Popup.js"></script>
    <asp:HiddenField ID="HFStatusRawatInap" runat="server" />
    <asp:HiddenField ID="HFRegistrasiId" runat="server" />
    <asp:HiddenField ID="HFRawatInapId" runat="server" />
    <asp:HiddenField ID="HFPasienId" runat="server" />
    <table class="adminheading"  style="width:100%">
	    <tr>
		    <th class="menudottedline">
		        Data Pasien Rawat Inap 
		    </th>
		    <th style="width:50px;text-align:center" class="menudottedline">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="Middle" ImageUrl="~/images/icons/find.gif" OnClick="ImageButton1_Click" CausesValidation="False" />
		    </th>
	    </tr>
    </table>
    <uc5:HeaderRI ID="HeaderRI1" runat="server" />
    <ajaxToolkit:TabContainer ID="TabPasien" runat="server" ActiveTabIndex="0">
        <ajaxToolkit:TabPanel ID="TabUmum" runat="server" HeaderText="">
            <HeaderTemplate>
                <%= Resources.GetString("RS", "TabUmunRI")%> 
            </HeaderTemplate>
            <ContentTemplate>
                <uc1:ViewDataUmum ID="UCViewDataUmum" runat="server" />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabRegistrasi" runat="server" HeaderText="">
            <HeaderTemplate>
                <%= Resources.GetString("RS", "TabRegistrasiRI")%>  
            </HeaderTemplate>
            <ContentTemplate>
                <uc2:ViewRegistrasiRI ID="UCViewRegistrasiRI" runat="server" />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabRM" runat="server" HeaderText="">
            <HeaderTemplate>
                <%= Resources.GetString("RS", "TabRekamMedisRI")%> 
            </HeaderTemplate>
            <ContentTemplate>
                <uc3:ViewRekamMedisRI id="UCViewRekamMedisRI" runat="server">
                </uc3:ViewRekamMedisRI>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabRuangRawat" runat="server" HeaderText="">
            <HeaderTemplate>
                <%= Resources.GetString("RS", "TabRuangInapRI")%> 
            </HeaderTemplate>
            <ContentTemplate>
                <uc5:ViewRuangRI ID="UCViewRuangRI" runat="server" />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabKasir" runat="server" HeaderText="">
            <HeaderTemplate>
                <%= Resources.GetString("RS", "TabLayananRI")%> 
            </HeaderTemplate>
            <ContentTemplate>
                <uc4:ViewKasirRI ID="UCViewKasirRI" runat="server" />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabDeposit" runat="server">
            <HeaderTemplate>
                Deposit
            </HeaderTemplate>
            <ContentTemplate>
                <uc8:ViewDepositRI id="UCViewDepositRI" runat="server" />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabKuitansi" runat="server" HeaderText="">
            <HeaderTemplate>
                <%= Resources.GetString("RS", "TabKuitansiRI")%> 
            </HeaderTemplate>
            <ContentTemplate>
                <uc6:ViewKuitansiRI ID="UCViewKuitansiRI" runat="server" />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
</asp:Content>

