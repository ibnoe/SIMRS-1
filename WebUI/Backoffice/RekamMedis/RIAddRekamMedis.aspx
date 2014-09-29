<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="RIAddRekamMedis.aspx.cs" Inherits="Backoffice_RekamMedis_RIAddRekamMedis" Title="Untitled Page" %>

<%@ Register Src="../Controls/EditRekamMedisRI.ascx" TagName="EditRekamMedisRI" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:EditRekamMedisRI ID="EditRekamMedisRI1" runat="server" />
    <table class="adminheading" width="100%">
	    <tr>
		    <td style="width: 150px" class="menudottedline">
			    &nbsp;</td>
		    <td style="width:50px" class="menudottedline">
                <asp:ImageButton ID="btnSave" ImageUrl="~/images/save_f2.gif" runat="server" OnClick="btnSave_Click" />
		    </td>
		    <td style="width:50px" class="menudottedline">
                <asp:ImageButton ID="btnCancel" ImageUrl="~/images/cancel_f2.gif" runat="server" CausesValidation="False" OnClick="btnCancel_Click" />
		    </td>
		    <td class="menudottedline">&nbsp;</td>
	    </tr>
    </table> 
</asp:Content>

