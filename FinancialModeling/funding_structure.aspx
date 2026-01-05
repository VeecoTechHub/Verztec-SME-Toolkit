<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="funding_structure.aspx.cs" Inherits="FinancialModeling_funding_structure"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LogPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function backgroundFilter() {
            var div;
            if (document.getElementById)
                div = document.getElementById('backgroundFilterNew');
            else if (document.all)
                div = document.all['backgroundFilterNew'];
            if (div.style.display == '' && div.offsetWidth != undefined && div.offsetHeight != undefined)
                div.style.display = (div.offsetWidth != 0 && div.offsetHeight != 0) ? 'block' : 'none';
            div.style.display = (div.style.display == '' || div.style.display == 'block') ? 'none' : 'block';
        }
        function showpopUp() {

            //             $('#popUpNewTopicDiv').fadeIn('slow');
            var div;
            div = document.getElementById('popUpNewTopicDiv');
            div.style.display = "block"
            backgroundFilter();

        }
        function closepopUp() {

            //             $('#popUpNewTopicDiv').fadeIn('slow');
            var div;
            div = document.getElementById('popUpNewTopicDiv');
            div.style.display = "none"
            backgroundFilter();

        }
        function delay() {
            setTimeout('showpopUp()', 500)
        }      
          
        
    </script>
    <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="33" valign="top" class="sme_title">
                <div>
                    Financial Management Self-Evaluation Questionnaire</div>
            </td>
        </tr>
        <tr>
            <td height="300" valign="top">
                <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="trNo" style="display: block;">
                        <td>
                            <table width="874" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="29">
                                        <table border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="55" align="left">
                                                    <a href="CompanyInformation.aspx">
                                                        <%--<img src="../images/info.png" alt="" width="51" height="82" border="0" /></a>--%>
                                                            <asp:ImageButton ImageUrl="~/images/info.png" Width="51" Height="82" border="0" ID="imgbtnCompanyInformation"
                                                        runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        CommandArgument="FinancialModeling/CompanyInformation.aspx">
                                                    </asp:ImageButton>
                                                </td>
                                                <td>
                                                    <img src="../images/left.png" width="31" height="82" alt="" />
                                                </td>
                                                <td class="navbg">
                                                  <%--  <a href="Sec_Sales.aspx?Id=0" class="menu_link">Sales</a>--%>
                                                     <asp:LinkButton ID="lnkSales" runat="server" class="menu_link" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        CommandArgument="FinancialModeling/Sec_Sales.aspx?Id=0">Sales</asp:LinkButton>

                                                </td>
                                                <td>
                                                    <img src="../images/middle_right.png" width="32" height="82" alt="" />
                                                </td>
                                                <td class="navbg">
                                             <%--       <a href="Sec_CostOfSales.aspx?Id=0" class="menu_link">Cost of
                                                        <br />
                                                        Sale /<br />
                                                        Stocks</a>--%>
                                                           <asp:LinkButton ID="lnkCostOFSale" runat="server" class="menu_link" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        CommandArgument="FinancialModeling/Sec_CostOfSales.aspx?Id=0">Cost of
                                                        <br />
                                                        Sale /<br />
                                                        Stocks</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src="../images/middle_right.png" width="32" height="82" alt="" />
                                                </td>
                                                <td class="navbg">
                                                 <%--   <a href="OperatingCost.aspx?Id=0" class="menu_link">Operating<br />
                                                        Cost /
                                                        <br />
                                                        Income</a>--%>
                                                         <asp:LinkButton ID="lnkOperatingCost" runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        class="menu_link" CommandArgument="FinancialModeling/OperatingCost.aspx?Id=0">Operating<br /> Cost / <br />Income</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src="../images/hover_left.png" width="41" height="82" alt="" />
                                                </td>
                                                <td class="navbg_hover">
                                                 <%--   <a href="funding_structure.aspx?Id=0" class="menu_link_select">Funding &<br />
                                                        Capital<br />
                                                        Expenditure</a>--%>
                                                         <asp:LinkButton ID="lnkFundingCapital" runat="server" class="menu_link_select" >Funding &amp;<br /> Capital<br /> Expenditure</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src="../images/hover_right.png" width="41" height="82" alt="" />
                                                </td>
                                                <td class="navbg">
                                                  <%--  <a href="Other_Assets.aspx?Id=0" class="menu_link">Other
                                                        <br />
                                                        Assets and
                                                        <br />
                                                        Liabilities</a>--%>
                                                         <asp:LinkButton ID="lnkOtherAssetsAndLiabilities" runat="server" OnClick="SaveData"
                                                        OnClientClick="ConfirmChoice();" class="menu_link" CommandArgument="FinancialModeling/Other_Assets.aspx?Id=0">Other <br />Assets and <br />Liabilities</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src="../images/middle_right.png" width="32" height="82" alt="" />
                                                </td>
                                                <td class="navbg">
                                                 <%--   <a href="Optional.aspx?Id=0" class="menu_link">Optional</a>--%>
                                                 <asp:LinkButton ID="lnkOptional" runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        class="menu_link" CommandArgument="FinancialModeling/Optional.aspx?Id=0">Optional</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src="../images/right.png" width="30" height="82" alt="" />
                                                </td>
                                                <td width="55" align="right">
                                                <%--    <a href="Report.aspx?Id=0">
                                                        <img src="../images/Reports.png" alt="" width="51" height="82" border="0" /></a>--%>
                                                                <asp:ImageButton ImageUrl="~/images/Reports.png" Width="51" Height="82" border="0"
                                                        ID="imgbtnReports" runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        class="menu_link" CommandArgument="FinancialModeling/Report.aspx?Id=0">
                                                    </asp:ImageButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="trYes" style="display: block;">
                        <td>
                            <table width="874" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="29">
                                        <table border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="55" align="left">
                                        <%--            <a href="CompanyInformation.aspx">
                                                        <img src="../images/info.png" alt="" width="51" height="82" border="0" /></a>--%>
                                                            <asp:ImageButton ImageUrl="~/images/info.png" ID="imgbtnCompanyInformation1" Width="51"
                                                        Height="82" border="0" runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        CommandArgument="FinancialModeling/CompanyInformation.aspx">
                                                    </asp:ImageButton>
                                                </td>
                                                <td>
                                                    <img src="../images/left.png" width="31" height="82" alt="" />
                                                </td>
                                                <td class="navbg">
                                                   <%-- <a href="SciStatement.aspx?Id=1" class="menu_link">Income<br />
                                                        Statement</a>--%>
                                                         <asp:LinkButton ID="lnkIncomeStmt1" runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        CommandArgument="FinancialModeling/SciStatement.aspx?Id=1" class="menu_link">Income<br /> Statement</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src="../images/middle_right.png" width="32" height="82" alt="" />
                                                </td>
                                                <td class="navbg">
                                                  <%--  <a href="SfpStatement.aspx?Id=1" class="menu_link">Balance<br />
                                                        Sheet</a>--%>
                                                         <asp:LinkButton ID="lnkBalance1" runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        class="menu_link" CommandArgument="FinancialModeling/SfpStatement.aspx?Id=1">Balance<br /> Sheet</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src="../images/middle_right.png" width="32" height="82" alt="" />
                                                </td>
                                                <td class="navbg">
                                                   <%-- <a href="Sec_Sales.aspx?Id=1" class="menu_link">Sales</a>--%>
                                                    <asp:LinkButton ID="lnkSales1" runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        class="menu_link" CommandArgument="FinancialModeling/Sec_Sales.aspx?Id=1">Sales</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src="../images/middle_right.png" width="32" height="82" alt="" />
                                                </td>
                                                <td class="navbg">
                                                 <%--   <a href="Sec_CostOfSales.aspx?Id=1" class="menu_link">Cost of
                                                        <br />
                                                        Sale /<br />
                                                        Stocks</a>--%>
                                                          <asp:LinkButton ID="lnkCostOfSale1" runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        class="menu_link" CommandArgument="FinancialModeling/Sec_CostOfSales.aspx?Id=1">Cost of
                                                        <br />
                                                        Sale /<br />
                                                        Stocks</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src="../images/middle_right.png" width="32" height="82" alt="" />
                                                </td>
                                                <td class="navbg">
                                                   <%-- <a href="OperatingCost.aspx?Id=1" class="menu_link">Operating<br />
                                                        Cost /
                                                        <br />
                                                        Income</a>--%>
                                                        <asp:LinkButton ID="lnkOperatingCost1" runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        class="menu_link" CommandArgument="FinancialModeling/OperatingCost.aspx?Id=1">Operating<br /> Cost / <br />Income</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src="../images/hover_left.png" width="41" height="82" alt="" />
                                                </td>
                                                <td class="navbg_hover">
                                                  <%--  <a href="funding_structure.aspx?Id=1" class="menu_link_select">Funding &<br />
                                                        Capital<br />
                                                        Expenditure</a>--%>
                                                        <asp:LinkButton ID="lnkFundingStructure1" runat="server" 
                                                        class="menu_link_select">Funding &amp;<br /> Capital<br /> Expenditure</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src="../images/hover_right.png" width="41" height="82" alt="" />
                                                </td>
                                                <td class="navbg">
                                                 <%--   <a href="Other_Assets.aspx?Id=1" class="menu_link">Other
                                                        <br />
                                                        Assets and
                                                        <br />
                                                        Liabilities</a>--%>
                                                         <asp:LinkButton ID="lnkOtherAssetsAndLiabilities1" runat="server" OnClick="SaveData"
                                                        OnClientClick="ConfirmChoice();"
                                                        class="menu_link" CommandArgument="FinancialModeling/Other_Assets.aspx?Id=1">Other <br />Assets and <br />Liabilities</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src="../images/middle_right.png" width="32" height="82" alt="" />
                                                </td>
                                                <td class="navbg">
                                                   <%-- <a href="Optional.aspx?Id=1" class="menu_link">Optional</a>--%>
                                                    <asp:LinkButton ID="lnkOptional1" runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        class="menu_link" CommandArgument="FinancialModeling/Optional.aspx?Id=1">Optional</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src="../images/right.png" width="30" height="82" alt="" />
                                                </td>
                                                <td width="55" align="right">
                                                    <%--<a href="Report.aspx?Id=1">
                                                        <img src="../images/Reports.png" alt="" width="51" height="82" border="0" /></a>--%>
                                                         <asp:ImageButton ImageUrl="~/images/Reports.png" Width="51" Height="82" border="0"
                                                        ID="imgbtnReports1" runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                         CommandArgument="FinancialModeling/Report.aspx?Id=1"></asp:ImageButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>SECTION 4 - FUNDING &amp; CAPITAL EXPENDITURE </strong>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="875" border="0" align="center" cellpadding="3" cellspacing="1">
                                <tr>
                                    <td width="19" align="left" valign="top">
                                        Q1
                                    </td>
                                    <td width="337">
                                        What is the paid up capital of your business?
                                    </td>
                                    <td width="5">
                                        &nbsp;
                                    </td>
                                    <td width="106" align="center" id="tdActual_3">
                                        $ 100,000
                                    </td>
                                    <td width="7" align="center">
                                        &nbsp;
                                    </td>
                                    <td width="106" align="center">
                                        &nbsp;
                                    </td>
                                    <td width="7" align="center">
                                        &nbsp;
                                    </td>
                                    <td width="106" align="center">
                                        &nbsp;
                                    </td>
                                    <td width="7" align="center">
                                        &nbsp;
                                    </td>
                                    <td width="106" align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" bgcolor="#E9E9E9" id="tdActual_1">
                                        Estimate<br />
                                        <asp:Label ID="lblEstimate" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center" bgcolor="#E9E9E9">
                                        Projection<br />
                                        <asp:Label ID="lblProjYear1" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" bgcolor="#E9E9E9">
                                        Projection<br />
                                        <asp:Label ID="lblProjYear2" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center" bgcolor="#E9E9E9">
                                        Projection<br />
                                        <asp:Label ID="lblProjYear3" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="19" align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        If you intend to increase the capital, please enter the intended incremental 
                                        amount
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:TextBox ID="txtQuestion1P1" runat="server" Style="width: 90px;" class="InputBgColor" MaxLength="15"></asp:TextBox></td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:TextBox ID="txtQuestion1P2" runat="server" Style="width: 90px;" class="InputBgColor" MaxLength="15"></asp:TextBox></td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:TextBox ID="txtQuestion1P3" runat="server" class="InputBgColor" Style="width: 90px;" MaxLength="15"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td width="19" align="left" valign="top">
                                        Q2
                                    </td>
                                    <td>
                                        Your cash balance as at the end of last financial period is
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" id="tdActual_2">
                                        $ 120,000
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        How much of the cash is pledged to the bank/(s) as collateral/(s) for credit 
                                        facilities?
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:TextBox ID="txtQuestion2" runat="server" Style="width: 90px;" class="InputBgColor" MaxLength="15"></asp:TextBox></td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        Q3
                                    </td>
                                    <td>
                                        Do you have any existing term loan/(s) or hire purchase loan/(s)?
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="left" colspan="3">
                                        <input type="radio" onclick="hideQ3();" name="group1" id="rd_Q3_Yes" value="Yes" />
                                        Yes
                                        <input type="radio" name="group1" onclick="hideQ3();" id="rd_Q3_No" value="No" />
                                        No &nbsp; &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tr_3Q_1">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center" bgcolor="#E9E9E9">
                                        Projection
                                        <br />
                                        <asp:Label ID="lblProjection1" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" bgcolor="#E9E9E9">
                                        Projection
                                        <br />
                                        <asp:Label ID="lblProjection2" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center" bgcolor="#E9E9E9">
                                        Projection
                                        <br />
                                        <asp:Label ID="lblProjection3" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr_3Q_2">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        Aggregate loan balance as at beginning of period
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" id="tdActual_4">
                                        $ 500,000
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tr_3Q_3">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        Estimated average interests rate
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;&nbsp;
                                        <asp:TextBox ID="txtQuestion3" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                        %
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tr_3Q_4">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        Please indicate your estimated total repayment (principal + interests)
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:TextBox ID="txtQuestion3P1" runat="server" Style="width: 90px;" class="InputBgColor" MaxLength="15"></asp:TextBox></td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:TextBox ID="txtQuestion3P2" runat="server" Style="width: 90px;" class="InputBgColor" MaxLength="15"></asp:TextBox></td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:TextBox ID="txtQuestion3P3" runat="server" Style="width: 90px;" class="InputBgColor" MaxLength="15"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Q4
                                    </td>
                                    <td>
                                        Do you have any working capital loan/(s)?
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="left" colspan="3">
                                        <input type="radio" onclick="hideQ4();" name="group2" id="rd_Q4_Yes" value="Yes" />
                                        Yes
                                        <input type="radio" name="group2" onclick="hideQ4();" id="rd_Q4_No" value="No" />
                                        No &nbsp; &nbsp; &nbsp; &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tr_4Q_1">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        (Working capital loan includes overdraft, short term revolving loan, invoice 
                                        discounting, trust receipts, etc)
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tr_4Q_2">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tr_4Q_3">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        How much is the aggregate credit limit of the working capital funding?
                                        <!--<img src="../images/Help.png" width="16" height="16" title="Please include Letter of Credit but exclude Banker's Guarantee & Forex lines"
                                                                    alt="Please include Letter of Credit but exclude Banker's Guarantee & Forex lines." />-->
                                        <img src="../images/Help.png" width="16" height="16" alt="" onmouseover="delay();" />
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:TextBox ID="txtQuestion4P1" runat="server" Style="width: 90px;" class="InputBgColor" MaxLength="15"></asp:TextBox></td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tr_4Q_4">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        What is the Letter of Credit Limit if it is within the aggregated credit limit?
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:TextBox ID="txtQuestion4P2" runat="server" Style="width: 90px;" class="InputBgColor" MaxLength="15"></asp:TextBox></td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tr_4Q_5">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" bgcolor="#E9E9E9" id="tdActual_5">
                                        Estimate<br />
                                        <asp:Label ID="lblEstimate1" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tr_4Q_6">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        Short term borrowing balances as at end of period
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" id="tdActual_6">
                                        $ 500,000
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tr_4Q_7">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        What is the average interest rate on the short term borrowing?
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;&nbsp;
                                        <asp:TextBox ID="txtQuestion4EstimatePercent" runat="server" Style="width: 40px;"
                                            class="InputBgColor" MaxLength="15"></asp:TextBox>%
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tr_4Q_8">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        What is the Letter of Credit utilisation, if applicable?
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:TextBox ID="txtQuestion4EstimateValue" runat="server" Style="width: 90px;"
                                            class="InputBgColor" MaxLength="15"></asp:TextBox></td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        Q5
                                    </td>
                                    <td>
                                        Do you need to incur capital expenditure needed to support the business in the 
                                        projection periods?<br />
                                        E.g. Purchase or replacement of plant and equipment, motor vehicle, renovation, 
                                        etc
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="left" colspan="3">
                                        <input type="radio" onclick="hideQ5();" name="group5" id="rd_Q5_Yes" value="Yes" />
                                        Yes
                                        <input type="radio" name="group5" onclick="hideQ5();" id="rd_Q5_No" value="No" />
                                        No &nbsp; &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tr_5Q_1">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center" bgcolor="#E9E9E9">
                                        Projection<br />
                                        <asp:Label ID="lblPro1" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" bgcolor="#E9E9E9">
                                        Projection
                                        <br />
                                        <asp:Label ID="lblPro2" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center" bgcolor="#E9E9E9">
                                        Projection
                                        <br />
                                        <asp:Label ID="lblPro3" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr_5Q_2">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtQuestion5Main1" runat="server" Style="width: 320px;" MaxLength="250"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:TextBox ID="txtQuestion5P1" runat="server" Style="width: 90px;" class="InputBgColor" MaxLength="15"></asp:TextBox></td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:TextBox ID="txtQuestion5P2" runat="server" Style="width: 90px;" class="InputBgColor" MaxLength="15"></asp:TextBox></td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:TextBox ID="txtQuestion5P3" runat="server" Style="width: 90px;" class="InputBgColor" MaxLength="15"></asp:TextBox></td>
                                </tr>
                                <tr id="tr_5Q_3">
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td>
                                        Estimated useful life of the assets (Year(s))
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtQuestion5YearsP1" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtQuestion5YearsP2" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtQuestion5YearsP3" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="tr_5Q_4">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        Is financing required?
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="left" colspan="3">
                                        <input type="radio" onclick="hideQ5Capex1();" name="group5" id="rd_Q5Capex1_Yes"
                                            value="Yes" />
                                        Yes
                                        <input type="radio" name="group5" onclick="hideQ5Capex1();" id="rd_Q5Capex1_No" value="No" />
                                        No &nbsp; &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tr_5Q_5">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tr_5Q_6">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        Loan Quantum (%)
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="txtQuantumP1" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                        %
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="txtQuantumP2" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                        %
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="txtQuantumP3" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                        %
                                    </td>
                                </tr>
                                <tr id="tr_5Q_7">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        Loan Interest Rate (%)
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="txtInterestRate" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                        %
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tr_5Q_8">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        Loan Tenure (Year(s))
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtTenureP1" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtTenureP2" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtTenureP3" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="tr_5Q_9">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        Number of Mth(s) in use of the assets in the year of addition
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtMonthsP1" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtMonthsP2" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtMonthsP3" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="tr_5Q_10">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tr_5Q_11">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtQuestion5Main2" runat="server" Style="width: 320px;" MaxLength="250"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:TextBox ID="txtQuestion5Main2P1" runat="server" Style="width: 90px;" class="InputBgColor" MaxLength="15"></asp:TextBox></td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:TextBox ID="txtQuestion5Main2P2" runat="server" Style="width: 90px;" class="InputBgColor" MaxLength="15"></asp:TextBox></td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:TextBox ID="txtQuestion5Main2P3" runat="server" Style="width: 90px;" class="InputBgColor" MaxLength="15"></asp:TextBox></td>
                                </tr>
                                <tr id="tr_5Q_12">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        Estimated useful life of the assets (Year(s))
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtQuestion5Main2YearsP1" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtQuestion5Main2YearsP2" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtQuestion5Main2YearsP3" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="tr_5Q_13">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        Is financing required?
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="left" colspan="3">
                                        <input type="radio" onclick="hideQ5Capex2();" name="group6" id="rd_Q5Capex2_Yes"
                                            value="Yes" />
                                        Yes
                                        <input type="radio" name="group6" onclick="hideQ5Capex2();" id="rd_Q5Capex2_No" value="No" />
                                        No &nbsp; &nbsp;
                                    </td>
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tr_5Q_14">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tr_5Q_15">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        Loan Quantum (%)
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="txtQuestion5Main2QuantumP1" runat="server" Style="width: 40px;"
                                            class="InputBgColor" MaxLength="15"></asp:TextBox>
                                        %
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="txtQuestion5Main2QuantumP2" runat="server" Style="width: 40px;"
                                            class="InputBgColor" MaxLength="15"></asp:TextBox>
                                        %
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="txtQuestion5Main2QuantumP3" runat="server" Style="width: 40px;"
                                            class="InputBgColor" MaxLength="15"></asp:TextBox>
                                        %
                                    </td>
                                </tr>
                                <tr id="tr_5Q_16">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        Loan Interest Rate (%)
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="txtMain2InterestRate2" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                        %
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tr_5Q_17">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        Loan Tenure (Year(s))
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtTenureMain2P1" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtTenureMain2P2" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtTenureMain2P3" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="tr_5Q_18">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        Number of Mth(s) in use of the assets in the year of addition
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtMain2MonthsP1" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtMain2MonthsP2" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtMain2MonthsP3" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="tr_5Q_19">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tr_5Q_20">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtQuestion5Main3" runat="server" Style="width: 320px;" MaxLength="250"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:TextBox ID="txtQuestion5Main3P1" runat="server" Style="width: 90px;" class="InputBgColor" MaxLength="15"></asp:TextBox></td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:TextBox ID="txtQuestion5Main3P2" runat="server" Style="width: 90px;" class="InputBgColor" MaxLength="15"></asp:TextBox></td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:TextBox ID="txtQuestion5Main3P3" runat="server" Style="width: 90px;" class="InputBgColor" MaxLength="15"></asp:TextBox></td>
                                </tr>
                                <tr id="tr_5Q_21">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        Estimated useful life of the assets (Year(s))
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtQuestion5Main3YearsP1" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtQuestion5Main3YearsP2" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtQuestion5Main3YearsP3" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="tr_5Q_22">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        Is financing required?
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="left" colspan="3">
                                        <input type="radio" onclick="hideQ5Capex3();" name="group7" id="rd_Q5Capex3_Yes"
                                            value="Yes" />
                                        Yes
                                        <input type="radio" name="group7" onclick="hideQ5Capex3();" id="rd_Q5Capex3_No" value="No" />
                                        No &nbsp; &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tr_5Q_23">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tr_5Q_24">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        Loan Quantum (%)
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="txtQuestion5Main3QuantumP1" runat="server" Style="width: 40px;"
                                            class="InputBgColor" MaxLength="15"></asp:TextBox>
                                        %
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="txtQuestion5Main3QuantumP2" runat="server" Style="width: 40px;"
                                            class="InputBgColor" MaxLength="15"></asp:TextBox>
                                        %
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="txtQuestion5Main3QuantumP3" runat="server" Style="width: 40px;"
                                            class="InputBgColor" MaxLength="15"></asp:TextBox>
                                        %
                                    </td>
                                </tr>
                                <tr id="tr_5Q_25">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        Loan Interest Rate (%)
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="txtMain3InterestRate3" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                        %
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tr_5Q_26">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        Loan Tenure (Year(s))
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtTenureMain3P1" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtTenureMain3P2" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtTenureMain3P3" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="tr_5Q_27">
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        Number of Mth(s) in use of the assets in the year of addition
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtMain3MonthsP1" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtMain3MonthsP2" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtMain3MonthsP3" runat="server" Style="width: 40px;" class="InputBgColor" MaxLength="15"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle">
                            <asp:Button ID="btnSaveNext" runat="server" Text="Save & Next" CssClass="orange_button"
                                OnClick="btnSaveNext_Click" />
                            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="orange_button" OnClientClick="Clear()"/>
                            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="orange_button" OnClick="btnBack_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle">
                         <asp:HiddenField ID="hfValue" runat="server" />
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="backgroundFilterNew">
    </div>
    <div id="popUpNewTopicDiv" class="popUpClassNew" style="display: none;">
        <table width="100%">
            <tr height="100px">
                <td valign="top">
                    Please include Letter of Credit but exclude Banker&#39;s Guarantee &amp; Forex lines.
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <input type="button" id="btn1" value="Ok" class="orange_button" onclick="closepopUp();"
                        style="width: 80px;" />
                </td>
            </tr>
        </table>
    </div>
    <script type="text/javascript">
        //querystring.js - Contains functions to extract querystring parameters from URL
        //The parameters are loaded into the associative array queryString[].

        //In open JavaScript (not inside a function), define the array
        var queryString = new Array();
        // and then pull the querystyring parameters from the URL.
        // The search property of the window location returns the query string.
        // The method substring(1) removes the first character (the question mark).
        // The split function then copies the parameters into an array called "parms"
        var parameters = window.location.search.substring(1).split('&');
        // For each element in the array, find the equal sign that separates the parameter
        // name from the parameter value.  If there is one, divide the expression into
        // the parameter name

        for (var i = 0; i < parameters.length; i++) {

            var pos = parameters[i].indexOf('=');
            // If there is an equal sign, separate the parameter into the name and value,
            // and store it into the queryString array.
            if (pos > 0) {
                var paramname = parameters[i].substring(0, pos);
                var paramval = parameters[i].substring(pos + 1);
                //Here u can write ur logic based on the value
                if (paramval == '0') {

                    document.getElementById('trYes').style.display = 'none';
                }
                else {
                    document.getElementById('trNo').style.display = 'none';

                }

                queryString[paramname] = unescape(paramval.replace(/\+/g, ' '));
            } else {
                //special value when there is a querystring parameter with no value
                queryString[parameters[i]] = ""
            }
        }

        function NavigatePage() {
            window.location = 'other_assets.htm?Id=' + paramval;
        }

        function hideQ3() {
            if (document.getElementById('rd_Q3_Yes').checked == true) {
                for (i = 1; i <= 4; i++) {
                    document.getElementById('tr_3Q_' + i.toString()).style.display = '';
                }

            }
            if (document.getElementById('rd_Q3_No').checked == true) {
                for (i = 1; i <= 4; i++) {
                    document.getElementById('tr_3Q_' + i.toString()).style.display = 'none';
                }

            }
        }

        function hideQ4() {
            if (document.getElementById('rd_Q4_Yes').checked == true) {
                for (i = 1; i <= 8; i++) {
                    document.getElementById('tr_4Q_' + i.toString()).style.display = '';
                }

            }
            if (document.getElementById('rd_Q4_No').checked == true) {
                for (i = 1; i <= 8; i++) {
                    document.getElementById('tr_4Q_' + i.toString()).style.display = 'none';
                }

            }
        }

        function hideQ5() {
            if (document.getElementById('rd_Q5_Yes').checked == true) {
                for (i = 1; i <= 27; i++) {
                    document.getElementById('tr_5Q_' + i.toString()).style.display = '';
                }

            }
            if (document.getElementById('rd_Q5_No').checked == true) {
                for (i = 1; i <= 27; i++) {
                    document.getElementById('tr_5Q_' + i.toString()).style.display = 'none';
                }

            }
        }

        function hideQ5Capex1() {
            if (document.getElementById('rd_Q5Capex1_Yes').checked == true) {
                for (i = 6; i <= 9; i++) {
                    document.getElementById('tr_5Q_' + i.toString()).style.display = '';
                }

            }
            if (document.getElementById('rd_Q5Capex1_No').checked == true) {
                for (i = 6; i <= 9; i++) {
                    document.getElementById('tr_5Q_' + i.toString()).style.display = 'none';
                }

            }
        }
        function hideQ5Capex2() {
            if (document.getElementById('rd_Q5Capex2_Yes').checked == true) {
                for (i = 15; i <= 18; i++) {
                    document.getElementById('tr_5Q_' + i.toString()).style.display = '';
                }

            }
            if (document.getElementById('rd_Q5Capex2_No').checked == true) {
                for (i = 15; i <= 18; i++) {
                    document.getElementById('tr_5Q_' + i.toString()).style.display = 'none';
                }

            }
        }
        function hideQ5Capex3() {
            if (document.getElementById('rd_Q5Capex3_Yes').checked == true) {
                for (i = 24; i <= 27; i++) {
                    document.getElementById('tr_5Q_' + i.toString()).style.display = '';
                }

            }
            if (document.getElementById('rd_Q5Capex3_No').checked == true) {
                for (i = 24; i <= 27; i++) {
                    document.getElementById('tr_5Q_' + i.toString()).style.display = 'none';
                }

            }
        }

        //Hiding the actual yr tds
        if (paramval == '0') {

            for (i = 1; i <= 6; i++) {

                var tdCell = document.getElementById('tdActual_' + i.toString());
                var inputs = tdCell.getElementsByTagName('input');
                for (var j = 0; j < inputs.length; j++) {
                    //                    document.getElementById(inputs[j].id).style.visibility = 'hidden';
                    if (i != 1) {
                        document.getElementById(inputs[j].id).disabled = true;
                        document.getElementById(inputs[j].id).style.backgroundColor = 'White';
                    }
                }
                if (i != 1) {
                    if (i != 5) {
                        document.getElementById('tdActual_' + i.toString()).innerHTML = '';
                    }
                }

                //                document.getElementById('tdActual_' + i.toString()).style.backgroundColor = 'gray';
            }

        }

        function Clear() {

            var allInputs = document.getElementsByTagName("input");
            for (var i = 0; i < allInputs.length; i++) {
                if (allInputs[i].type == "text") {
                    allInputs[i].value = "";
                }
            }
        }
        function ConfirmChoice() {
            answer = confirm("Do You Want To Save The Data")
            if (answer == "0") {
                document.getElementById('<%= hfValue.ClientID %>').value = 0;
            }
            else {
                document.getElementById('<%= hfValue.ClientID %>').value = 1;
            }
        }
        
    </script>
</asp:Content>
