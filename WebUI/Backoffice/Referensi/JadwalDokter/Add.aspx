<%@ Page Language="C#" MasterPageFile="~/Backoffice/Backoffice.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="Backoffice_Referensi_JadwalDokter_Add" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true" ></asp:ScriptManager>
<table class="adminheading" id="Table3">
	<tr>
		<th class="menudottedline">
			<%= Resources.GetString("Referensi","TitleAddJadwalDokter") %>
		</th>
		<td class="menudottedline" align="right">&nbsp;
		</td>
	</tr>
</table>
<table class="adminform" id="Table1" border="0">
	<tr>
		<td colspan="2">
			<asp:Label id="lblError" runat="server" ForeColor="Red"></asp:Label>
			<asp:ValidationSummary id="ValidationSummary1" runat="server" DisplayMode="SingleParagraph" HeaderText="Tanda * harus diisi atau dipilih!"></asp:ValidationSummary></td>
	</tr>
	<tr>
		<td class="text">
            Poliklinik<asp:TextBox id="txtJadwalDokterId" runat="server" MaxLength="50" Width="8px" ReadOnly="True" Visible="False"></asp:TextBox></td>
		<td>
            <asp:DropDownList ID="cmbPoliklinik" runat="server">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cmbPoliklinik">*</asp:RequiredFieldValidator></td>
	</tr>
	<tr>
        <td class="text">
            Dokter</td>
        <td>
            <asp:DropDownList ID="cmbDokter" runat="server">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cmbDokter">*</asp:RequiredFieldValidator></td>
    </tr>
    <tr>
		<td class="text">
            Hari</td>
		<td>
            <asp:DropDownList ID="cmbHari" runat="server">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cmbHari">*</asp:RequiredFieldValidator></td>
	</tr>
    <tr>
        <td class="text">
            Jam Praktek<asp:TextBox ID="txtJamMulai" runat="server" MaxLength="50" ReadOnly="True"
                Visible="False" Width="8px"></asp:TextBox>
            <asp:TextBox ID="txtJamSelesai" runat="server" MaxLength="50" ReadOnly="True" Visible="False"
                Width="8px"></asp:TextBox>
            <asp:TextBox ID="txtJamPraktek" runat="server" MaxLength="50" ReadOnly="True" Visible="False"
                Width="8px"></asp:TextBox></td>
        <td>
            <asp:DropDownList ID="cmbJamMulai" runat="server">
                <asp:ListItem>00</asp:ListItem>
                <asp:ListItem>01</asp:ListItem>
                <asp:ListItem>02</asp:ListItem>
                <asp:ListItem>03</asp:ListItem>
                <asp:ListItem>04</asp:ListItem>
                <asp:ListItem>05</asp:ListItem>
                <asp:ListItem>06</asp:ListItem>
                <asp:ListItem>07</asp:ListItem>
                <asp:ListItem>08</asp:ListItem>
                <asp:ListItem>09</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>13</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
                <asp:ListItem>17</asp:ListItem>
                <asp:ListItem>18</asp:ListItem>
                <asp:ListItem>19</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>21</asp:ListItem>
                <asp:ListItem>22</asp:ListItem>
                <asp:ListItem>23</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="cmbMenitMulai" runat="server">
                <asp:ListItem>00</asp:ListItem>
                <asp:ListItem>01</asp:ListItem>
                <asp:ListItem>02</asp:ListItem>
                <asp:ListItem>03</asp:ListItem>
                <asp:ListItem>04</asp:ListItem>
                <asp:ListItem>05</asp:ListItem>
                <asp:ListItem>06</asp:ListItem>
                <asp:ListItem>07</asp:ListItem>
                <asp:ListItem>08</asp:ListItem>
                <asp:ListItem>09</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>13</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
                <asp:ListItem>17</asp:ListItem>
                <asp:ListItem>18</asp:ListItem>
                <asp:ListItem>19</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>21</asp:ListItem>
                <asp:ListItem>22</asp:ListItem>
                <asp:ListItem>23</asp:ListItem>
                <asp:ListItem>24</asp:ListItem>
                <asp:ListItem>25</asp:ListItem>
                <asp:ListItem>26</asp:ListItem>
                <asp:ListItem>27</asp:ListItem>
                <asp:ListItem>28</asp:ListItem>
                <asp:ListItem>29</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
                <asp:ListItem>31</asp:ListItem>
                <asp:ListItem>32</asp:ListItem>
                <asp:ListItem>33</asp:ListItem>
                <asp:ListItem>34</asp:ListItem>
                <asp:ListItem>35</asp:ListItem>
                <asp:ListItem>36</asp:ListItem>
                <asp:ListItem>37</asp:ListItem>
                <asp:ListItem>38</asp:ListItem>
                <asp:ListItem>39</asp:ListItem>
                <asp:ListItem>40</asp:ListItem>
                <asp:ListItem>41</asp:ListItem>
                <asp:ListItem>42</asp:ListItem>
                <asp:ListItem>43</asp:ListItem>
                <asp:ListItem>44</asp:ListItem>
                <asp:ListItem>45</asp:ListItem>
                <asp:ListItem>46</asp:ListItem>
                <asp:ListItem>47</asp:ListItem>
                <asp:ListItem>48</asp:ListItem>
                <asp:ListItem>49</asp:ListItem>
                <asp:ListItem>50</asp:ListItem>
                <asp:ListItem>51</asp:ListItem>
                <asp:ListItem>52</asp:ListItem>
                <asp:ListItem>53</asp:ListItem>
                <asp:ListItem>54</asp:ListItem>
                <asp:ListItem>55</asp:ListItem>
                <asp:ListItem>56</asp:ListItem>
                <asp:ListItem>57</asp:ListItem>
                <asp:ListItem>58</asp:ListItem>
                <asp:ListItem>59</asp:ListItem>
            </asp:DropDownList>
            Sampai
            <asp:DropDownList ID="cmbJamSelesai" runat="server">
                <asp:ListItem>00</asp:ListItem>
                <asp:ListItem>01</asp:ListItem>
                <asp:ListItem>02</asp:ListItem>
                <asp:ListItem>03</asp:ListItem>
                <asp:ListItem>04</asp:ListItem>
                <asp:ListItem>05</asp:ListItem>
                <asp:ListItem>06</asp:ListItem>
                <asp:ListItem>07</asp:ListItem>
                <asp:ListItem>08</asp:ListItem>
                <asp:ListItem>09</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>13</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
                <asp:ListItem>17</asp:ListItem>
                <asp:ListItem>18</asp:ListItem>
                <asp:ListItem>19</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>21</asp:ListItem>
                <asp:ListItem>22</asp:ListItem>
                <asp:ListItem>23</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="cmbMenitSelesai" runat="server">
                <asp:ListItem>00</asp:ListItem>
                <asp:ListItem>01</asp:ListItem>
                <asp:ListItem>02</asp:ListItem>
                <asp:ListItem>03</asp:ListItem>
                <asp:ListItem>04</asp:ListItem>
                <asp:ListItem>05</asp:ListItem>
                <asp:ListItem>06</asp:ListItem>
                <asp:ListItem>07</asp:ListItem>
                <asp:ListItem>08</asp:ListItem>
                <asp:ListItem>09</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>13</asp:ListItem>
                <asp:ListItem>14</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
                <asp:ListItem>17</asp:ListItem>
                <asp:ListItem>18</asp:ListItem>
                <asp:ListItem>19</asp:ListItem>
                <asp:ListItem>20</asp:ListItem>
                <asp:ListItem>21</asp:ListItem>
                <asp:ListItem>22</asp:ListItem>
                <asp:ListItem>23</asp:ListItem>
                <asp:ListItem>24</asp:ListItem>
                <asp:ListItem>25</asp:ListItem>
                <asp:ListItem>26</asp:ListItem>
                <asp:ListItem>27</asp:ListItem>
                <asp:ListItem>28</asp:ListItem>
                <asp:ListItem>29</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
                <asp:ListItem>31</asp:ListItem>
                <asp:ListItem>32</asp:ListItem>
                <asp:ListItem>33</asp:ListItem>
                <asp:ListItem>34</asp:ListItem>
                <asp:ListItem>35</asp:ListItem>
                <asp:ListItem>36</asp:ListItem>
                <asp:ListItem>37</asp:ListItem>
                <asp:ListItem>38</asp:ListItem>
                <asp:ListItem>39</asp:ListItem>
                <asp:ListItem>40</asp:ListItem>
                <asp:ListItem>41</asp:ListItem>
                <asp:ListItem>42</asp:ListItem>
                <asp:ListItem>43</asp:ListItem>
                <asp:ListItem>44</asp:ListItem>
                <asp:ListItem>45</asp:ListItem>
                <asp:ListItem>46</asp:ListItem>
                <asp:ListItem>47</asp:ListItem>
                <asp:ListItem>48</asp:ListItem>
                <asp:ListItem>49</asp:ListItem>
                <asp:ListItem>50</asp:ListItem>
                <asp:ListItem>51</asp:ListItem>
                <asp:ListItem>52</asp:ListItem>
                <asp:ListItem>53</asp:ListItem>
                <asp:ListItem>54</asp:ListItem>
                <asp:ListItem>55</asp:ListItem>
                <asp:ListItem>56</asp:ListItem>
                <asp:ListItem>57</asp:ListItem>
                <asp:ListItem>58</asp:ListItem>
                <asp:ListItem>59</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td class="text">
            </td>
        <td>
        </td>
    </tr>
	<tr>
		<td class="text">Keterangan</td>
		<td>
			<asp:TextBox id="txtKeterangan" runat="server" Width="350px" MaxLength="50" TextMode="MultiLine"></asp:TextBox></td>
	</tr>
</table>
<table class="adminheading" id="Table2">
	<tr>
		<td width="150px" class="menudottedline" align="left">
			&nbsp;</td>
		<td width="50" class="menudottedline" align="left">
			<div class="toolbar" onmouseover="MM_swapImage('save','','../../../images/save_f2.gif',1);"
				onmouseout="MM_swapImgRestore();">
				<asp:linkbutton id="btnSave" OnClick="OnSave" runat="server"></asp:linkbutton></div>
		</td>
		<td width="150px" class="menudottedline" align="left">
			<div class="toolbar" onmouseover="MM_swapImage('cancel','','../../../images/cancel_f2.gif',1);"
				onmouseout="MM_swapImgRestore();"><asp:linkbutton id="btnCancel" OnClick="OnCancel" runat="server" CausesValidation="False"></asp:linkbutton></div>
		</td>
		<td class="menudottedline">&nbsp;</td>
	</tr>
</table>
</asp:Content>

