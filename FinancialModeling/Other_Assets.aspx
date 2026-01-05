<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="Other_Assets.aspx.cs" Inherits="FinancialModeling_Other_Assets"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LogPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                                                    <asp:ImageButton ImageUrl="~/images/info.png" ID="imgbtnCompanyInformation0" Width="51"
                                                        Height="82" border="0" runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        CommandArgument="FinancialModeling/CompanyInformation.aspx" class="menu_link">
                                                    </asp:ImageButton>
                                                </td>
                                                <td>
                                                    <img src="../images/left.png" width="31" height="82" alt="" />
                                                </td>
                                                <td class="navbg">
                                                    <asp:LinkButton ID="lnkSales0" runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        class="menu_link" CommandArgument="FinancialModeling/Sec_Sales.aspx?Id=0">Sales</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src="../images/middle_right.png" width="32" height="82" alt="" />
                                                </td>
                                                <td class="navbg">
                                                    <asp:LinkButton ID="lnkCostOfSale0" runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        class="menu_link" CommandArgument="FinancialModeling/Sec_CostOfSales.aspx?Id=0">Cost of <br />Sale /<br /> Stocks</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src="../images/middle_right.png" width="32" height="82" alt="" />
                                                </td>
                                                <td class="navbg">
                                                    <asp:LinkButton ID="lnkOperatingCost0" runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        class="menu_link" CommandArgument="FinancialModeling/OperatingCost.aspx?Id=0">Operating<br /> Cost / <br />Income</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src="../images/middle_right.png" width="32" height="82" alt="" />
                                                </td>
                                                <td class="navbg">
                                                    <asp:LinkButton ID="lnkFundingStructure0" runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        class="menu_link" CommandArgument="FinancialModeling/funding_structure.aspx?Id=0">Funding &<br /> Capital<br /> Expenditure</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src="../images/hover_left.png" width="41" height="82" alt="" />
                                                </td>
                                                <td class="navbg_hover">
                                                    <asp:LinkButton ID="lnkOtherAssetsAndLiabilities0" runat="server" class="menu_link_select">Other <br />Assets and <br />Liabilities</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src="../images/hover_right.png" width="41" height="82" alt="" />
                                                </td>
                                                <td class="navbg">
                                                    <asp:LinkButton ID="lnkOptional0" runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        class="menu_link" CommandArgument="FinancialModeling/Optional.aspx?Id=0">Optional</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src="../images/right.png" width="30" height="82" alt="" />
                                                </td>
                                                <td width="55" align="right">
                                                    <asp:ImageButton ImageUrl="~/images/Reports.png" Width="51" Height="82" border="0"
                                                        ID="imgbtnReports0" runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        class="menu_link" CommandArgument="FinancialModeling/Report.aspx?Id=0"></asp:ImageButton>
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
                                                    <asp:ImageButton ImageUrl="~/images/info.png" ID="imgbtnCompanyInformation1" Width="51"
                                                        Height="82" border="0" runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        CommandArgument="FinancialModeling/CompanyInformation.aspx" class="menu_link">
                                                    </asp:ImageButton>
                                                </td>
                                                <td>
                                                    <img src="../images/left.png" width="31" height="82" alt="" />
                                                </td>
                                                <td class="navbg">
                                                    <asp:LinkButton ID="lnkIncomeStmt1" runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        CommandArgument="FinancialModeling/SciStatement.aspx?Id=1" class="menu_link">Income<br /> Statement</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src="../images/middle_right.png" width="32" height="82" alt="" />
                                                </td>
                                                <td class="navbg">
                                                    <asp:LinkButton ID="lnkBalance1" runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        class="menu_link" CommandArgument="FinancialModeling/SfpStatement.aspx?Id=1">Balance<br /> Sheet</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src="../images/middle_right.png" width="32" height="82" alt="" />
                                                </td>
                                                <td class="navbg">
                                                    <asp:LinkButton ID="lnkSales1" runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        class="menu_link" CommandArgument="FinancialModeling/Sec_Sales.aspx?Id=1">Sales</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src="../images/middle_right.png" width="32" height="82" alt="" />
                                                </td>
                                                <td class="navbg">
                                                    <asp:LinkButton ID="lnkCostOfSale1" runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        class="menu_link" CommandArgument="FinancialModeling/Sec_CostOfSales.aspx?Id=1">Cost of <br />Sale /<br /> Stocks</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src="../images/middle_right.png" width="32" height="82" alt="" />
                                                </td>
                                                <td class="navbg">
                                                    <asp:LinkButton ID="lnkOperatingCost1" runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        class="menu_link" CommandArgument="FinancialModeling/OperatingCost.aspx?Id=1">Operating<br /> Cost / <br />Income</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src="../images/middle_right.png" width="32" height="82" alt="" />
                                                </td>
                                                <td class="navbg">
                                                    <asp:LinkButton ID="lnkFundingStructure1" runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        class="menu_link" CommandArgument="FinancialModeling/funding_structure.aspx?Id=1">Funding &<br /> Capital<br /> Expenditure</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src="../images/hover_left.png" width="41" height="82" alt="" />
                                                </td>
                                                <td class="navbg_hover">
                                                    <asp:LinkButton ID="lnkOtherAssetsAndLiabilities1" runat="server" class="menu_link_select">Other <br />Assets and <br />Liabilities</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src="../images/hover_right.png" width="41" height="82" alt="" />
                                                </td>
                                                <td class="navbg">
                                                  <asp:LinkButton ID="lnkOptional1" runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        class="menu_link" CommandArgument="FinancialModeling/Optional.aspx?Id=1">Optional</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <img src="../images/right.png" width="30" height="82" alt="" />
                                                </td>
                                                <td width="55" align="right">
                                                   <asp:ImageButton ImageUrl="~/images/Reports.png" Width="51" Height="82" border="0"
                                                        ID="imgbtnReports1" runat="server" OnClick="SaveData" OnClientClick="ConfirmChoice();"
                                                        class="menu_link" CommandArgument="FinancialModeling/Report.aspx?Id=1"></asp:ImageButton>
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
                            <strong>SECTION 5 - OTHER ASSETS AND LIABILITIES</strong>
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
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td width="337">
                                        &nbsp;
                                    </td>
                                    <td width="13">
                                        &nbsp;
                                    </td>
                                    <td width="75" align="center" bgcolor="#E9E9E9" id="tdActual_1">
                                        Estimate<br />
                                        <asp:Label ID="lblEstimate" runat="server"></asp:Label>
                                    </td>
                                    <td width="10" align="center">
                                        &nbsp;
                                    </td>
                                    <td width="110" align="center" bgcolor="#E9E9E9">
                                        Projection<br />
                                        <asp:Label ID="lblProjYear1" runat="server"></asp:Label>
                                    </td>
                                    <td width="10">
                                        &nbsp;
                                    </td>
                                    <td width="110" align="center" bgcolor="#E9E9E9">
                                        Projection<br />
                                        <asp:Label ID="lblProjYear2" runat="server"></asp:Label>
                                    </td>
                                    <td width="10" align="center">
                                        &nbsp;
                                    </td>
                                    <td width="110" align="center" bgcolor="#E9E9E9">
                                        Projection<br />
                                        <asp:Label ID="lblProjYear3" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="19" align="left" valign="top">
                                        Q1
                                    </td>
                                    <td>
                                        The other assets as at the end of the period<br />
                                        (It refers to rental deposits, utilities deposits, etc. blank, if not applicable)
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" id="tdActual_2">
                                        <%--$ 2,000--%>
                                        $
                                        <asp:Label ID="lblOtherAssetsEst" runat="server" Text="2000"></asp:Label>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <%-- $ 52,000--%>
                                        $
                                        <asp:Label ID="lblOtherAssetsP1" runat="server" Text="52000"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <%--  $ 102,000--%>
                                        $
                                        <asp:Label ID="lblOtherAssetsP2" runat="server" Text="102000"></asp:Label>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <%--$ 102,000--%>
                                        $
                                        <asp:Label ID="lblOtherAssetsP3" runat="server" Text="102000"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
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
                                <tr>
                                    <td width="19" align="left" valign="top">
                                        &nbsp;
                                    </td>
                                    <td>
                                        How much is the expected change? e.g. higher deposits, if applicable
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
                                        $<asp:TextBox ID="txtOtherAssetsP1" runat="server" CssClass="InputBgColor" Style="width: 90px;"
                                            MaxLength="15"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:TextBox ID="txtOtherAssetsP2" runat="server" CssClass="InputBgColor" Style="width: 90px;"
                                            MaxLength="15"></asp:TextBox>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:TextBox ID="txtOtherAssetsP3" runat="server" CssClass="InputBgColor" Style="width: 90px;"
                                            MaxLength="15"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        Q2
                                    </td>
                                    <td>
                                        The other liabilities as at the end of the period
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center" id="tdActual_3">
                                        <%-- $ 7,000--%>
                                        $
                                        <asp:Label ID="lblOtherLiabilitiesEst" runat="server" Text="7000"></asp:Label>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <%--  $ 27,000--%>
                                        $
                                        <asp:Label ID="lblOtherLiabilitiesP1" runat="server" Text="27000"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <%-- $ 27,000--%>
                                        $
                                        <asp:Label ID="lblOtherLiabilitiesP2" runat="server" Text="27000"></asp:Label>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        <%-- $ 27,000--%>
                                        $
                                        <asp:Label ID="lblOtherLiabilitiesP3" runat="server" Text="27000"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        &nbsp;
                                    </td>
                                    <td>
                                        (It refers to other creditors, accruals, etc)
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
                                <tr>
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td>
                                        How much is the expected change? e.g. higher accruals, if applicable.
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
                                        $<asp:TextBox ID="txtOtherLiabilitiesP1" runat="server" CssClass="InputBgColor" Style="width: 90px;"
                                            MaxLength="15"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:TextBox ID="txtOtherLiabilitiesP2" runat="server" CssClass="InputBgColor" Style="width: 90px;"
                                            MaxLength="15"></asp:TextBox>
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                    <td align="center">
                                        $<asp:TextBox ID="txtOtherLiabilitiesP3" runat="server" CssClass="InputBgColor" Style="width: 90px;"
                                            MaxLength="15"></asp:TextBox>
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
                            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="orange_button" OnClientClick="Clear()" />
                            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="orange_button" OnClick="btnBack_Click" />
                    </tr>
                    <tr>
                        <td valign="middle">
                            &nbsp;<asp:HiddenField ID="hfValue" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
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
            window.location = 'Optional.htm?Id=' + paramval;
        }

        //Hiding the actual yr tds
        if (paramval == '0') {

            for (i = 1; i <= 3; i++) {

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
                    document.getElementById('tdActual_' + i.toString()).innerHTML = '';
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
