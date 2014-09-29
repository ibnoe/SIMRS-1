<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="FISView.aspx.cs" Inherits="Backoffice_Kasir_FISView" Title="Untitled Page" %>
<%@ Register Src="../Controls/HeaderRJ.ascx" TagName="HeaderRJ" TagPrefix="uc5" %>
<%@ Register Src="../Controls/EditKuitansiFIS.ascx" TagName="EditKuitansiFIS" TagPrefix="uc6" %>
<%@ Register Src="../Controls/EditKasirFIS.ascx" TagName="EditKasirFIS" TagPrefix="uc4" %>
<%@ Register Src="../Controls/ViewRekamMedisFIS.ascx" TagName="ViewRekamMedisFIS" TagPrefix="uc3" %>
<%@ Register Src="../Controls/ViewRegistrasiFIS.ascx" TagName="ViewRegistrasiFIS" TagPrefix="uc2" %>
<%@ Register Src="../Controls/ViewDataUmum.ascx" TagName="ViewDataUmum" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../../js/Popup.js"></script>
    <asp:HiddenField ID="HFStatusRawatJalan" runat="server" />
    <asp:HiddenField ID="HFRegistrasiId" runat="server" />
    <asp:HiddenField ID="HFRawatJalanId" runat="server" />
    <asp:HiddenField ID="HFPasienId" runat="server" />
    <table class="adminheading"  style="width:100%">
	    <tr>
		    <th class="menudottedline">
		        Data Pasien Fisioterapi 
		    </th>
		    <th style="width:50px;text-align:center" class="menudottedline">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="Middle" ImageUrl="~/images/icons/find.gif" OnClick="ImageButton1_Click" CausesValidation="False" />
		    </th>
	    </tr>
    </table>
    <uc5:HeaderRJ ID="HeaderRJ1" runat="server" />
    <ajaxToolkit:TabContainer ID="TabPasien" runat="server" ActiveTabIndex="3">
        <ajaxToolkit:TabPanel ID="TabUmum" runat="server" HeaderText="">
            <HeaderTemplate>
                <%= Resources.GetString("RS", "TabUmunFIS")%> 
            </HeaderTemplate>
            <ContentTemplate>
                <uc1:ViewDataUmum ID="UCViewDataUmum" runat="server" />
                <hr />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabRegistrasi" runat="server" HeaderText="">
            <HeaderTemplate>
                <%= Resources.GetString("RS", "TabRegistrasiFIS")%>  
            </HeaderTemplate>
            <ContentTemplate>
                <uc2:ViewRegistrasiFIS ID="UCViewRegistrasiFIS" runat="server" />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabRM" runat="server" HeaderText="">
            <HeaderTemplate>
                <%= Resources.GetString("RS", "TabRekamMedisFIS")%> 
            </HeaderTemplate>
            <ContentTemplate>
                <uc3:ViewRekamMedisFIS id="UCViewRekamMedisFIS" runat="server">
                </uc3:ViewRekamMedisFIS>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabKasir" runat="server" HeaderText="">
            <HeaderTemplate>
                <%= Resources.GetString("RS", "TabLayananFIS")%> 
            </HeaderTemplate>
            <ContentTemplate>
                <uc4:EditKasirFIS ID="UCEditKasirFIS" runat="server" />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabKuitansi" runat="server" HeaderText="">
            <HeaderTemplate>
                <%= Resources.GetString("RS", "TabKuitansiFIS")%> 
            </HeaderTemplate>
            <ContentTemplate>
                <uc6:EditKuitansiFIS ID="UCEditKuitansiFIS" runat="server" />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
</asp:Content>

