<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="KUBTView.aspx.cs" Inherits="Backoffice_RekamMedis_KUBTView" Title="Untitled Page" %>
<%@ Register Src="../Controls/HeaderRJ.ascx" TagName="HeaderRJ" TagPrefix="uc5" %>
<%@ Register Src="../Controls/ViewKuitansiKUBT.ascx" TagName="ViewKuitansiKUBT" TagPrefix="uc6" %>
<%@ Register Src="../Controls/ViewKasirKUBT.ascx" TagName="ViewKasirKUBT" TagPrefix="uc4" %>
<%@ Register Src="../Controls/ViewRekamMedisKUBT.ascx" TagName="ViewRekamMedisKUBT" TagPrefix="uc3" %>
<%@ Register Src="../Controls/ViewRegistrasiKUBT.ascx" TagName="ViewRegistrasiKUBT" TagPrefix="uc2" %>
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
    <table class="adminheading">
	    <tr>
		    <th class="menudottedline">
		        Data Pasien KUBT 
		    </th>
		    <th style="width:50px;text-align:center" class="menudottedline">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="Middle" ImageUrl="~/images/icons/find.gif" OnClick="ImageButton1_Click" />
		    </th>
	    </tr>
    </table>
    <uc5:HeaderRJ ID="HeaderRJ1" runat="server" />
    <ajaxToolkit:TabContainer ID="TabPasien" runat="server" ActiveTabIndex="2">
        <ajaxToolkit:TabPanel ID="TabUmum" runat="server" HeaderText="">
            <HeaderTemplate>
                <%= Resources.GetString("RS", "TabUmunKUBT")%>
            </HeaderTemplate>
            <ContentTemplate>
                <uc1:ViewDataUmum ID="UCViewDataUmum" runat="server" />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabRegistrasi" runat="server" HeaderText="">
            <HeaderTemplate>
                <%= Resources.GetString("RS", "TabRegistrasiKUBT")%> 
            </HeaderTemplate>
            <ContentTemplate>
                <uc2:ViewRegistrasiKUBT ID="UCViewRegistrasiKUBT" runat="server" />
                <hr />
                <a href="javascript:void(0)" class="button" visible="False" onclick="" id="btnIkhtisarKunjungan" runat="server">Print Ikhtisar Kunjungan</a>
                <a href="javascript:void(0)" class="button" visible="False" onclick="" id="btnLembarKonsultasi" runat="server">Print Lembar Konsultasi</a>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabRM" runat="server" HeaderText="">
            <HeaderTemplate>
                <%= Resources.GetString("RS", "TabRekamMedisKUBT")%> 
            </HeaderTemplate>
            <ContentTemplate>
                <uc3:ViewRekamMedisKUBT id="UCViewRekamMedisKUBT" runat="server">
                </uc3:ViewRekamMedisKUBT>
                <hr />
                <asp:Button ID="btnEditRekamMedis" CssClass="button" Visible="False" runat="server" Text="Edit Data Rekam Medis" OnClick="btnEditRekamMedis_Click" />
                <asp:Button ID="btnAddRekamMedis" CssClass="button" Visible="False" runat="server" Text="Input Data Rekam Medis" OnClick="btnAddRekamMedis_Click" />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabKasir" runat="server" HeaderText="">
            <HeaderTemplate>
                <%= Resources.GetString("RS", "TabLayananKUBT")%> 
            </HeaderTemplate>
            <ContentTemplate>
                <uc4:ViewKasirKUBT ID="UCViewKasirKUBT" runat="server" />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabKuitansi" runat="server" HeaderText="">
            <HeaderTemplate>
                <%= Resources.GetString("RS", "TabKuitansiKUBT")%> 
            </HeaderTemplate>
            <ContentTemplate>
                <uc6:ViewKuitansiKUBT ID="UCViewKuitansiKUBT" runat="server" />
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
</asp:Content>

