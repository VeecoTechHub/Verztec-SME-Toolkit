<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="Sec_Sales.aspx.cs" Inherits="FinancialModeling_Sec_Sales"
    MaintainScrollPositionOnPostback="true" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LogPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- <script type="text/javascript">
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


                queryString[paramname] = unescape(paramval.replace(/\+/g, ' '));
            } else {
                //special value when there is a querystring parameter with no value
                queryString[parameters[i]] = ""
            }
        }


    </script>--%>
    <asp:UpdatePanel ID="upPanel" runat="server">
        <ContentTemplate>
            <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="33" valign="top" class="sme_title">
                        <div>
                            <asp:Label ID="lblHeading" runat="server" Text="FINANCIAL MANAGEMENT TOOLKIT" 
                                meta:resourcekey="lblHeadingResource1"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                    </td>
                </tr>
                <tr>
                    <td height="300" valign="top">
                        <table width="874" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td height="160" class="titleBar">
                                    <table border="0" cellspacing="0" cellpadding="0" width="874">
                                        <tr>
                                            <td width="100%" align="center" colspan="2">
                                                <table width="100%">
                                                    <tr>
                                                        <td class="Reportsbg">
                                                            <table align="center" align="center">
                                                                <tr>
                                                                    <td width="60px">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td width="90px" align="center">
                                                                        <asp:ImageButton ID="imgbtnStatements" ToolTip="Statements" ImageUrl="~/images/icon-statements.png"
                                                                            runat="server" OnClick="imgbtnStatements_Click" 
                                                                            OnClientClick="return SaveData();" 
                                                                            meta:resourcekey="imgbtnStatementsResource1" /><br />
                                                                        <asp:Label ID="lblStatements" runat="server" Text="Statements" 
                                                                            meta:resourcekey="lblStatementsResource1"></asp:Label>
                                                                    </td>
                                                                    <td width="90px" align="center">
                                                                        <asp:ImageButton ID="imgbtnHome" ToolTip="Home" ImageUrl="~/images/icon-home.png"
                                                                            runat="server" OnClick="imgbtnHome_Click" 
                                                                            OnClientClick="return SaveData();" meta:resourcekey="imgbtnHomeResource1" />
                                                                        <br />
                                                                        <asp:Label ID="lblHome" runat="server" Text="Home" 
                                                                            meta:resourcekey="lblHomeResource1"></asp:Label>
                                                                    </td>
                                                                    <td width="90px" align="center">
                                                                        <asp:ImageButton ID="imgBtnGenerateReport" ToolTip="Generate Report" OnClientClick="return SaveData();"
                                                                            ImageUrl="~/images/icon-report.png" runat="server" 
                                                                            OnClick="imgBtnGenerateReport_Click" 
                                                                            meta:resourcekey="imgBtnGenerateReportResource1" /><br />
                                                                        <asp:Label ID="lblReport" runat="server" Text="Report" 
                                                                            meta:resourcekey="lblReportResource1"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 90px" align="center">
                                                                        <asp:ImageButton ID="imgBtnHelp" ToolTip="Help" ImageUrl="~/images/icon-faq.png"
                                                                            runat="server" OnClientClick="return SaveData();" 
                                                                            OnClick="imgBtnHelp_Click" meta:resourcekey="imgBtnHelpResource1" /><br />
                                                                        <asp:Label ID="lblHelp" runat="server" Text="Help" 
                                                                            meta:resourcekey="lblHelpResource1"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 60px">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="90" align="center">
                                                <img src="../images/icon01.png" width="48" height="47" alt="" />
                                            </td>
                                            <td valign="top" style="padding-top: 5px;" align="left" width="784px">
                                                <asp:Label ID="lblSalesConditions" runat="server" Text="1. Sales & Collections" 
                                                    meta:resourcekey="lblSalesConditionsResource1"></asp:Label>
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
                                    <strong>
                                        <asp:Label ID="lbl1AEstimation" runat="server" Text="1A. Sales Estimation" 
                                        meta:resourcekey="lbl1AEstimationResource1"></asp:Label>
                                    </strong>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 41px">
                                    <asp:Localize ID="locPara1" runat="server" Text="
                            Let us first understand your sales estimates for the next 3 years. If your sales
                            come from various sources with different gross margin contribution, you may like
                            to break them down accordingly, otherwise enter total sales in the first row." 
                                        meta:resourcekey="locPara1Resource1"></asp:Localize>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <table width="874" border="0" align="center" cellpadding="3" cellspacing="0">
                                        <tr>
                                            <td width="214" align="left" valign="top" bgcolor="#E9E9E9" class="border">
                                                <asp:Label ID="lblSourcesofsales" runat="server" Text="Sources of sales" 
                                                    meta:resourcekey="lblSourcesofsalesResource1"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblEG" runat="server" Text="(e.g. manufacturing, trading, etc)" 
                                                    meta:resourcekey="lblEGResource1"></asp:Label>
                                            </td>
                                            <td width="3">
                                                &nbsp;
                                            </td>
                                            <td width="155" align="center" bgcolor="#E9E9E9" valign="top" class="border">
                                                <asp:Label ID="lbl1Estimates" runat="server" Text="Estimates" 
                                                    meta:resourcekey="lbl1EstimatesResource1"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblProjYear1" runat="server" 
                                                    meta:resourcekey="lblProjYear1Resource1"></asp:Label>($)
                                            </td>
                                            <td width="3">
                                                &nbsp;
                                            </td>
                                            <td width="70" align="center" valign="top" bgcolor="#E9E9E9" class="border">
                                                <asp:Label ID="lbl1Increase" runat="server" Text="% of Increase" 
                                                    meta:resourcekey="lbl1IncreaseResource1"></asp:Label>
                                            </td>
                                            <td width="3" align="center">
                                                &nbsp;
                                            </td>
                                            <td width="185" align="center" bgcolor="#E9E9E9" valign="top" class="border">
                                                <asp:Label ID="lbl2Estimates" runat="server" Text="Estimates" 
                                                    meta:resourcekey="lbl2EstimatesResource1"></asp:Label><br />
                                                <asp:Label ID="lblProjYear2" runat="server" 
                                                    meta:resourcekey="lblProjYear2Resource1"></asp:Label>($)
                                            </td>
                                            <td width="3" align="center">
                                                &nbsp;
                                            </td>
                                            <td width="70" align="center" valign="top" bgcolor="#E9E9E9" class="border">
                                                <asp:Label ID="lbl2Increase" runat="server" Text="% of Increase" 
                                                    meta:resourcekey="lbl2IncreaseResource1"></asp:Label>
                                            </td>
                                            <td width="3">
                                                &nbsp;
                                            </td>
                                            <td width="185" align="center" bgcolor="#E9E9E9" valign="top" class="border">
                                                <asp:Label ID="lbl3Estimates" runat="server" Text="Estimates" 
                                                    meta:resourcekey="lbl3EstimatesResource1"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblProjYear3" runat="server" 
                                                    meta:resourcekey="lblProjYear3Resource1"></asp:Label>($)
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="borderBLR">
                                                <asp:TextBox ID="txtTradingOfGoods" runat="server" CssClass="txtfieldNewText" MaxLength="30"
                                                    onkeypress="return runScript(event)" Style="width: 210px;" 
                                                    meta:resourcekey="txtTradingOfGoodsResource1"></asp:TextBox>
                                             <%--   <asp:FilteredTextBoxExtender ID="ftTradingOfGoods" runat="server" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz .&"
                                                    TargetControlID="txtTradingOfGoods" Enabled="True">
                                                </asp:FilteredTextBoxExtender>--%>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtTradingOfGoodsP1" runat="server" CssClass="txtfieldNew" MaxLength="20"
                                                    onkeypress="return runScript(event)" onblur="CalculateEstimate1Total(this,'1');"
                                                    Style="width: 100px;" meta:resourcekey="txtTradingOfGoodsP1Resource1"></asp:TextBox>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtTradingOfGoodsP1Per" runat="server" CssClass="txtfieldNew" MaxLength="6"
                                                    onkeypress="return runScript(event)" Style="width: 30px;" 
                                                    onblur="CalcEstmateGoodsP1Increase();" 
                                                    meta:resourcekey="txtTradingOfGoodsP1PerResource1"></asp:TextBox>
                                                %
                                                <asp:FilteredTextBoxExtender ID="ftTradingOfGoodsP1Per" runat="server"
                                                    ValidChars=".-0123456789" TargetControlID="txtTradingOfGoodsP1Per" 
                                                    Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:Label ID="lblTradingOfGoodsP2" runat="server" Width="130px" 
                                                    CssClass="alignRight" meta:resourcekey="lblTradingOfGoodsP2Resource1"></asp:Label>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtTradingOfGoodsP2Per" runat="server" CssClass="txtfieldNew" MaxLength="6"
                                                    onkeypress="return runScript(event)" Style="width: 30px;" 
                                                    onblur="CalcEstmateGoodsP2Increase();" 
                                                    meta:resourcekey="txtTradingOfGoodsP2PerResource1"></asp:TextBox>
                                                %
                                                <asp:FilteredTextBoxExtender ID="ftTradingOfGoodsP2Per" runat="server"
                                                    ValidChars=".-0123456789" TargetControlID="txtTradingOfGoodsP2Per" 
                                                    Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:Label ID="lblTradingOfGoodsP3" runat="server" Width="130px" 
                                                    CssClass="alignRight" meta:resourcekey="lblTradingOfGoodsP3Resource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="borderBLR">
                                                <asp:TextBox ID="txtManufacturingSale" runat="server" CssClass="txtfieldNewText"
                                                    onkeypress="return runScript(event)" MaxLength="30" Style="width: 210px;" 
                                                    meta:resourcekey="txtManufacturingSaleResource1"></asp:TextBox>
                                             <%--   <asp:FilteredTextBoxExtender ID="ftManufacturingSale" runat="server" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz .&"
                                                    TargetControlID="txtManufacturingSale" Enabled="True">
                                                </asp:FilteredTextBoxExtender>--%>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtManufacturingSaleP1" runat="server" CssClass="txtfieldNew" MaxLength="20"
                                                    onkeypress="return runScript(event)" onblur="CalculateEstimate1Total(this,'2');"
                                                    Style="width: 100px;" meta:resourcekey="txtManufacturingSaleP1Resource1"></asp:TextBox>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtManufacturingSaleP1Per" runat="server" CssClass="txtfieldNew"
                                                    onkeypress="return runScript(event)" MaxLength="6" Style="width: 30px;" 
                                                    onblur="CalcEstmateMfSaleP1Increase();" 
                                                    meta:resourcekey="txtManufacturingSaleP1PerResource1"></asp:TextBox>
                                                %
                                                <asp:FilteredTextBoxExtender ID="ftManufacturingSaleP1Per" runat="server"
                                                    ValidChars=".-0123456789" TargetControlID="txtManufacturingSaleP1Per" 
                                                    Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:Label ID="lblManufacturingSaleP2" runat="server" Width="130px" 
                                                    CssClass="alignRight" meta:resourcekey="lblManufacturingSaleP2Resource1"></asp:Label>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtManufacturingSaleP2Per" runat="server" CssClass="txtfieldNew"
                                                    onkeypress="return runScript(event)" MaxLength="6" Style="width: 30px;" 
                                                    onblur="CalcEstmateMfSaleP2Increase();" 
                                                    meta:resourcekey="txtManufacturingSaleP2PerResource1"></asp:TextBox>
                                                %
                                                <asp:FilteredTextBoxExtender ID="ftManufacturingSaleP2Per" runat="server"
                                                    ValidChars=".-0123456789" TargetControlID="txtManufacturingSaleP2Per" 
                                                    Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:Label ID="lblManufacturingSaleP3" runat="server" Width="130px" 
                                                    CssClass="alignRight" meta:resourcekey="lblManufacturingSaleP3Resource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="borderBLR">
                                                <asp:TextBox ID="txtServices" runat="server" CssClass="txtfieldNewText" MaxLength="30"
                                                    onkeypress="return runScript(event)" Style="width: 210px;" 
                                                    meta:resourcekey="txtServicesResource1"></asp:TextBox>
                                            <%--    <asp:FilteredTextBoxExtender ID="ftServices" runat="server"
                                                    ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz .&" 
                                                    TargetControlID="txtServices" Enabled="True">
                                                </asp:FilteredTextBoxExtender>--%>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtServicesP1" runat="server" CssClass="txtfieldNew" MaxLength="20"
                                                    onkeypress="return runScript(event)" onblur="CalculateEstimate1Total(this,'3');"
                                                    Style="width: 100px;" meta:resourcekey="txtServicesP1Resource1"></asp:TextBox>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtServicesP1Per" runat="server" CssClass="txtfieldNew" MaxLength="6"
                                                    onkeypress="return runScript(event)" Style="width: 30px;" 
                                                    onblur="CalcEstmateServicesP1Increase();" 
                                                    meta:resourcekey="txtServicesP1PerResource1"></asp:TextBox>
                                                %
                                                <asp:FilteredTextBoxExtender ID="ftServicesP1Per" runat="server"
                                                    ValidChars=".-0123456789" TargetControlID="txtServicesP1Per" 
                                                    Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:Label ID="lblServicesP2" runat="server" Width="130px" 
                                                    CssClass="alignRight" meta:resourcekey="lblServicesP2Resource1"></asp:Label>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtServicesP2Per" runat="server" CssClass="txtfieldNew" MaxLength="6"
                                                    onkeypress="return runScript(event)" Style="width: 30px;" 
                                                    onblur="CalcEstmateServicesP2Increase();" 
                                                    meta:resourcekey="txtServicesP2PerResource1"></asp:TextBox>
                                                %
                                                <asp:FilteredTextBoxExtender ID="ftServicesP2Per" runat="server"
                                                    ValidChars=".-0123456789" TargetControlID="txtServicesP2Per" 
                                                    Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:Label ID="lblServicesP3" runat="server" Width="130px" 
                                                    CssClass="alignRight" meta:resourcekey="lblServicesP3Resource1"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="borderBLR">
                                                <strong>
                                                    <asp:Label ID="lblTotal1" runat="server" Text="Total" 
                                                    meta:resourcekey="lblTotal1Resource1"></asp:Label>
                                                </strong>
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:Label ID="lblTotalP2" runat="server" Width="100px" CssClass="alignRight" 
                                                    meta:resourcekey="lblTotalP2Resource1"></asp:Label>
                                            </td>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:Label ID="lblTotalP3" runat="server" Width="130px" CssClass="alignRight" 
                                                    meta:resourcekey="lblTotalP3Resource1"></asp:Label>
                                            </td>
                                            <td align="center" colspan="3">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:Label ID="lblTotalP4" runat="server" Width="130px" CssClass="alignRight" 
                                                    meta:resourcekey="lblTotalP4Resource1"></asp:Label>
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
                                <td>
                                    <asp:Localize ID="locPara2" runat="server" Text="
                                    Note: Estimates are your judgment of your business’ expected performance or target
                                    sales that you set for your business for the next few years." 
                                        meta:resourcekey="locPara2Resource1"></asp:Localize>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>
                                    <asp:Label ID="lbl1BCollections" runat="server" Text="1B. Collections" 
                                        meta:resourcekey="lbl1BCollectionsResource1"></asp:Label>
                                    </strong>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                <asp:Localize ID="locPara4" runat="server" Text="
                                    The number of days customers take to pay you have implications on the cash and funds,
                                    which is part of your working capital, required to fund your business." 
                                        meta:resourcekey="locPara4Resource1"></asp:Localize>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="874" border="0" align="center" cellpadding="3" cellspacing="1">
                                        <tr>
                                            <td width="350">
                                                <strong>
                                                   <asp:Label ID="lblDoyoudealincashtermsonly" runat="server" 
                                                    Text="Do you deal in cash terms only?" 
                                                    meta:resourcekey="lblDoyoudealincashtermsonlyResource1"></asp:Label>
                                               </strong>
                                            </td>
                                            <td align="left" width="100">
                                                <asp:RadioButtonList ID="rbl_Q2" runat="server" RepeatDirection="Horizontal" onclick="hide1B();"
                                                    onkeypress="return runScript(event)" meta:resourcekey="rbl_Q2Resource1">
                                                    <asp:ListItem Value="1" meta:resourcekey="ListItemResource1" Text="Yes"></asp:ListItem>
                                                    <asp:ListItem Value="0" meta:resourcekey="ListItemResource2" Text="No"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td style="text-align: left; vertical-align: bottom">
                                                <asp:RequiredFieldValidator runat="server" ID="radRfv1" ControlToValidate="rbl_Q2"
                                                    ErrorMessage="Select One option" Display="Dynamic" 
                                                    meta:resourcekey="radRfv1Resource1" Text="*"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr id="tr_CashTerm1">
                                <td>
                                 <asp:Localize ID="locPara3" runat="server" Text="
                                    Enter the percentage of your total sales and the corresponding days you take to
                                    collect from your customers. For example, if 60% of your sales are collectible within
                                    30 days, and 40% of your sales are collectible within 45 days, enter 60% and 30
                                    days in first row, and 40% and 45 days in the second row, and so on. If you take
                                    on the average 35 days to collect all your sales, just enter 100% and 35 days in
                                    the first row, and leave the rest blank." meta:resourcekey="locPara3Resource1"></asp:Localize>
                                </td>
                            </tr>
                            <tr id="tr_CashTerm2">
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr id="tr_CashTerm3">
                                <td valign="middle">
                                    <table width="874" border="0" align="center" cellpadding="3" cellspacing="0">
                                        <tr>
                                            <td width="214" valign="top">
                                            </td>
                                            <td width="3">
                                            </td>
                                            <td width="115">
                                                &nbsp;
                                            </td>
                                            <td width="3">
                                            </td>
                                            <td width="60">
                                            </td>
                                            <td width="3">
                                            </td>
                                            <td width="120" align="center" bgcolor="#E9E9E9" class="border">
                                              <asp:Label ID="lblPercentageofTotalSales" runat="server" 
                                                    Text="Percentage of Total Sales" 
                                                    meta:resourcekey="lblPercentageofTotalSalesResource1"></asp:Label>
                                            </td>
                                            <td width="3">
                                            </td>
                                            <td width="60">
                                            </td>
                                            <td width="3">
                                            </td>
                                            <td width="115" align="center" bgcolor="#E9E9E9" class="border">
                                             <asp:Label ID="lblCorresponding" runat="server" 
                                                    Text="Corresponding Days to Collects" 
                                                    meta:resourcekey="lblCorrespondingResource1"></asp:Label>
                                            </td>
                                            <td width="3">
                                            </td>
                                            <td width="60">
                                            </td>
                                            <td width="3">
                                            </td>
                                            <td width="115">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" width="398">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtSales1" runat="server" CssClass="txtfieldNew" MaxLength="6" Style="width: 40px;"
                                                    onkeypress="return runScript(event)" onblur="CalcSaleTotal();" 
                                                    meta:resourcekey="txtSales1Resource1"></asp:TextBox>
                                                %
                                                <asp:FilteredTextBoxExtender ID="ftSales1" runat="server" ValidChars=".-0123456789"
                                                    TargetControlID="txtSales1" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtDays1" runat="server" CssClass="txtfieldNew" MaxLength="10" Style="width: 40px;"
                                                    onkeypress="return runScript(event)" onblur="CalcDaysTotal();" 
                                                    meta:resourcekey="txtDays1Resource1"></asp:TextBox>
                                                     <asp:Label ID="lbl1Days" runat="server" Text="day(s)" 
                                                    meta:resourcekey="lbl1DaysResource1"></asp:Label>
                                               
                                                <asp:FilteredTextBoxExtender ID="ftDays1" runat="server" ValidChars="-0123456789"
                                                    TargetControlID="txtDays1" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td colspan="4">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtSales2" runat="server" CssClass="txtfieldNew" MaxLength="6" Style="width: 40px;"
                                                    onkeypress="return runScript(event)" onblur="CalcSaleTotal();" 
                                                    meta:resourcekey="txtSales2Resource1"></asp:TextBox>
                                                %
                                                <asp:FilteredTextBoxExtender ID="ftSales2" runat="server" ValidChars=".-0123456789"
                                                    TargetControlID="txtSales2" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtDays2" runat="server" CssClass="txtfieldNew" MaxLength="10" Style="width: 40px;"
                                                    onkeypress="return runScript(event)" onblur="CalcDaysTotal();" 
                                                    Height="22px" meta:resourcekey="txtDays2Resource1"></asp:TextBox>
                                                     <asp:Label ID="lbl2Days" runat="server" Text="day(s)" 
                                                    meta:resourcekey="lbl2DaysResource1"></asp:Label>
                                                <asp:FilteredTextBoxExtender ID="ftDays2" runat="server" ValidChars="-0123456789"
                                                    TargetControlID="txtDays2" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td colspan="4">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtSales3" runat="server" CssClass="txtfieldNew" MaxLength="6" Style="width: 40px;"
                                                    onkeypress="return runScript(event)" onblur="CalcSaleTotal();" 
                                                    meta:resourcekey="txtSales3Resource1"></asp:TextBox>
                                                %
                                                <asp:FilteredTextBoxExtender ID="ftSales3" runat="server" ValidChars=".-0123456789"
                                                    TargetControlID="txtSales3" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtDays3" runat="server" CssClass="txtfieldNew" MaxLength="10" Style="width: 40px;"
                                                    onkeypress="return runScript(event)" onblur="CalcDaysTotal();" 
                                                    meta:resourcekey="txtDays3Resource1"></asp:TextBox>
                                                     <asp:Label ID="lbl3Days" runat="server" Text="day(s)" 
                                                    meta:resourcekey="lbl3DaysResource1"></asp:Label>
                                                <asp:FilteredTextBoxExtender ID="ftDays3" runat="server" ValidChars="-0123456789"
                                                    TargetControlID="txtDays3" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td colspan="4">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtSales4" runat="server" CssClass="txtfieldNew" MaxLength="6" Style="width: 40px;"
                                                    onkeypress="return runScript(event)" onblur="CalcSaleTotal();" 
                                                    meta:resourcekey="txtSales4Resource1"></asp:TextBox>
                                                %
                                                <asp:FilteredTextBoxExtender ID="ftSales4" runat="server" 
                                                    TargetControlID="txtSales4" ValidChars=".-0123456789" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:TextBox ID="txtDays4" runat="server" CssClass="txtfieldNew" MaxLength="10" Style="width: 40px;"
                                                    onkeypress="return runScript(event)" onblur="CalcDaysTotal();" 
                                                    meta:resourcekey="txtDays4Resource1"></asp:TextBox>
                                                        <asp:Label ID="lbl4Days" runat="server" Text="day(s)" 
                                                    meta:resourcekey="lbl4DaysResource1"></asp:Label>
                                           
                                                <asp:FilteredTextBoxExtender ID="ftDays4" runat="server" ValidChars="-0123456789"
                                                    TargetControlID="txtDays4" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td colspan="4">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" align="right">
                                                <strong>
                                                 <asp:Label ID="lblTot" runat="server" Text="Total" 
                                                    meta:resourcekey="lblTotResource1"></asp:Label>
                                                </strong>
                                            </td>
                                            <td align="center" class="borderBLR">
                                                &nbsp;<asp:Label ID="lblTotal" runat="server" Width="80px" 
                                                    meta:resourcekey="lblTotalResource1"></asp:Label>
                                            </td>
                                            <td colspan="3" align="right">
                                                <strong>
                                                  <asp:Label ID="lblAvg" runat="server" Text="Average" 
                                                    meta:resourcekey="lblAvgResource1"></asp:Label>
                                                </strong>
                                            </td>
                                            <td align="center" class="borderBLR">
                                                <asp:Label ID="lblAvgNumberofDays" runat="server" Width="40px" 
                                                    Style="text-align: right" meta:resourcekey="lblAvgNumberofDaysResource1"></asp:Label>
                                                &nbsp;
                                                 <asp:Label ID="lbl5Days" runat="server" Text="day(s)" 
                                                    meta:resourcekey="lbl5DaysResource1"></asp:Label>
                                                
                                            </td>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="middle" colspan="15">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="15">
                                                <strong>
                                                <asp:Label ID="lblAvaCollDays" runat="server" 
                                                    Text="Analysis of your average collection days" 
                                                    meta:resourcekey="lblAvaCollDaysResource1"></asp:Label>
                                                </strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="middle" colspan="15">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr id="tr_Days" runat="server" >
                                            <td colspan="15" runat="server">
                                            <asp:Label ID="lblLastYear" runat="server" Text="Last year, the average number of days it took for you to collect from your customers
                                                was approximately" meta:resourcekey="lblLastYearResource1"></asp:Label>
                                                
                                                <asp:Label ID="lblCollectionDays" runat="server" 
                                                    meta:resourcekey="lblCollectionDaysResource1"></asp:Label>&nbsp; 
                                                      <asp:Label ID="lblDaysLast" runat="server" Text="days" 
                                                    meta:resourcekey="lblDaysLastResource1"></asp:Label>
                                                    
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td valign="middle" colspan="15">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="15">
                                            <asp:Label ID="lblbased" runat="server" 
                                                    Text="Based on the information that you have entered above, on the average you take approximately" 
                                                    meta:resourcekey="lblbasedResource1"></asp:Label>
                                                
                                                <asp:Label ID="lblAvgDays" runat="server" 
                                                    meta:resourcekey="lblAvgDaysResource1"></asp:Label>&nbsp; 
                                                <asp:Label ID="lblDaysTo" runat="server" Text="days to collect from
                                                your customers. For subsequent projections and financial analysis, you may either
                                                use this figure, or" meta:resourcekey="lblDaysToResource1"></asp:Label> 
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="middle" colspan="15">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="15">
                                               <asp:Label ID="lblEnterThe" runat="server" 
                                                    Text="Enter the average collection days you take to collect from your customers :" 
                                                    meta:resourcekey="lblEnterTheResource1"></asp:Label>
                                                
                                                <asp:TextBox ID="txtDays" runat="server" CssClass="txtfieldNew" MaxLength="10" Style="width: 40px;"
                                                    onkeypress="return runScript(event)" BorderWidth="1px" BorderColor="#348781"
                                                    BorderStyle="Solid" onFocus="highlightBg(this);" 
                                                    meta:resourcekey="txtDaysResource1"></asp:TextBox>
                                                      <asp:Label ID="lbl6Days" runat="server" Text="day(s)" 
                                                    meta:resourcekey="lbl6DaysResource1"></asp:Label>
                                                
                                                <br />
                                                 <asp:Label ID="lblOptional" runat="server" Text="(Optional)" 
                                                    meta:resourcekey="lblOptionalResource1"></asp:Label>
                                                
                                                <asp:FilteredTextBoxExtender ID="ftDays" runat="server" ValidChars="-0123456789"
                                                    TargetControlID="txtDays" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr_CashTerm4">
                                <td valign="middle">
                                    &nbsp;
                                    <asp:HiddenField ID="hfValue1" runat="server" />
                                    <asp:HiddenField ID="hfValue" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="middle">
                                    <asp:Button ID="btnSaveNext" runat="server" Text="Save & Next" CssClass="orange_button"
                                        OnClick="btnSaveNext_Click" OnClientClick="return IsValid();" 
                                        meta:resourcekey="btnSaveNextResource1" />
                                    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="orange_button" 
                                        OnClick="btnClear_Click" meta:resourcekey="btnClearResource1" />
                                    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="orange_button" OnClick="btnBack_Click"
                                        OnClientClick="return ConfirmChoice();" 
                                        meta:resourcekey="btnBackResource1" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="middle">
                                    &nbsp;
                                </td>
                            </tr>
                               <tr style="display:none">
                                <td valign="middle">
                                       <asp:Label ID="lblGiven" runat="server" 
                                        Text="Given value is not in a correct format" 
                                        meta:resourcekey="lblGivenResource1"></asp:Label>
                                       <asp:Label ID="lblPercentage" runat="server" 
                                        Text="Percentage of Total Sales Must Be 100%." 
                                        meta:resourcekey="lblPercentageResource1"></asp:Label>
                                       <asp:Label ID="lblAreYou" runat="server" 
                                        Text="Are you sure, you want to save the data." 
                                        meta:resourcekey="lblAreYouResource1"></asp:Label>
                                       <asp:Label ID="lblDoYou" runat="server" 
                                        Text="Do you want to save the data before naviagtion? then click OK, otherwise, click Cancel." 
                                        meta:resourcekey="lblDoYouResource1"></asp:Label>
                                       <asp:Label ID="lblDoYouChanges" runat="server" 
                                        Text="Do you want to save the changes you made?" 
                                        meta:resourcekey="lblDoYouChangesResource1"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress runat="server" ID="UpdateProgress">
        <ProgressTemplate>
            <div>
                <asp:Image ID="Image1" ImageUrl="~/images/progressbar.gif" AlternateText="Processing"
                    runat="server" meta:resourcekey="Image1Resource1" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress"
        PopupControlID="UpdateProgress" BackgroundCssClass="modalPopup" 
        DynamicServicePath="" Enabled="True" />

    <script type="text/javascript">
     
        function highlightBg(txtObj) {
            document.getElementById(txtObj.id).select();
        }
        var radioSelectedValue;
        var saleTotal;
        function hide1B() {
            var radio = document.getElementById('<%=rbl_Q2.ClientID%>');
            var rdbItem = radio.getElementsByTagName("input");
            var selectedvalue;
            for (var j = 0; j < rdbItem.length; j++) {
                if (rdbItem[j].checked) {
                    selectedvalue = rdbItem[j].value;
                    radioSelectedValue = selectedvalue;
                    break;
                }
            }
            if (selectedvalue == "1") {
                for (i = 1; i <= 4; i++) {
                    document.getElementById('tr_CashTerm' + i.toString()).style.display = 'none';
                }
            }
            if (selectedvalue == "0") {
                for (i = 1; i <= 4; i++) {
                    document.getElementById('tr_CashTerm' + i.toString()).style.display = '';
                }
            }

        }


        function CalculateEstimate1Total(txtId, number) {

            //document.getElementById(txtId.id).focus();
            var flag1_n = 1;
            var flag2_n = 2;
            var flag3_n = 3;
            var flag1 = true;
            var flag2 = true;
            var flag3 = true;

            if (flag1_n == number)
                var flag1 = checkFormat(document.getElementById('<%=txtTradingOfGoodsP1.ClientID%>').value);

            if (flag2_n == number)
                var flag2 = checkFormat(document.getElementById('<%=txtManufacturingSaleP1.ClientID%>').value);

            if (flag3_n == number)
                var flag3 = checkFormat(document.getElementById('<%=txtServicesP1.ClientID%>').value);

            if (flag1 == false || flag2 == false || flag3 == false) {
                var lblGiven = document.getElementById('<%=lblGiven.ClientID%>').innerHTML
                alert(lblGiven);
            }
            else {

                formatCellsWithoutComma();
                document.getElementById(txtId.id).style.background = '#dbeaee';

                var txt1 = document.getElementById('<%=txtTradingOfGoodsP1.ClientID%>').value
                var txt2 = document.getElementById('<%=txtManufacturingSaleP1.ClientID%>').value
                var txt3 = document.getElementById('<%=txtServicesP1.ClientID%>').value
                if (txt1.trim() != "" || txt2.trim() != "" || txt3.trim() != "")
                    document.getElementById('<%=lblTotalP2.ClientID%>').innerHTML = parseFloat(checkNanCondition(txt1)) + parseFloat(checkNanCondition(txt2)) + parseFloat(checkNanCondition(txt3));
                else
                    document.getElementById('<%=lblTotalP2.ClientID%>').innerHTML = "";
                formatCellsWithComma();
                CalcEstmateGoodsP1Increase();
                CalcEstmateMfSaleP1Increase();
                CalcEstmateServicesP1Increase();

            }

        }
        function CalculateEstimate2Total() {
            formatCellsWithoutComma();
            var Val1 = document.getElementById('<%=lblTradingOfGoodsP2.ClientID%>').innerHTML
            var Val2 = document.getElementById('<%=lblManufacturingSaleP2.ClientID%>').innerHTML
            var Val3 = document.getElementById('<%=lblServicesP2.ClientID%>').innerHTML
            if (Val1.trim() != "" || Val2.trim() != "" || Val3.trim() != "")
                document.getElementById('<%=lblTotalP3.ClientID%>').innerHTML = parseFloat(checkNanCondition(Val1)) + parseFloat(checkNanCondition(Val2)) + parseFloat(checkNanCondition(Val3));
            else
                document.getElementById('<%=lblTotalP3.ClientID%>').innerHTML = "";
            formatCellsWithComma();
        }
        function CalculateEstimate3Total() {
            formatCellsWithoutComma();
            var Val1 = document.getElementById('<%=lblTradingOfGoodsP3.ClientID%>').innerHTML
            var Val2 = document.getElementById('<%=lblManufacturingSaleP3.ClientID%>').innerHTML
            var Val3 = document.getElementById('<%=lblServicesP3.ClientID%>').innerHTML
            if (Val1.trim() != "" || Val2.trim() != "" || Val3.trim() != "")
                document.getElementById('<%=lblTotalP4.ClientID%>').innerHTML = parseFloat(checkNanCondition(Val1)) + parseFloat(checkNanCondition(Val2)) + parseFloat(checkNanCondition(Val3));
            else
                document.getElementById('<%=lblTotalP4.ClientID%>').innerHTML = "";
            formatCellsWithComma();
        }

        //Trading goods % increase


        function CalcEstmateGoodsP1Increase() {
            var flag = checkFormat(document.getElementById('<%=txtTradingOfGoodsP1.ClientID%>').value);
            if (flag == true) {
                formatCellsWithoutComma();
                var txtGoods = document.getElementById('<%=txtTradingOfGoodsP1.ClientID%>').value
                var Percent = document.getElementById('<%=txtTradingOfGoodsP1Per.ClientID%>').value
                if (Percent.trim() != "" && txtGoods.trim() != "") {
                    document.getElementById('<%=lblTradingOfGoodsP2.ClientID%>').innerHTML = Math.round(parseFloat(txtGoods) + (parseFloat(txtGoods) * checkNanCondition(Percent)) / 100);
                }
                else {
                    document.getElementById('<%=lblTradingOfGoodsP2.ClientID%>').innerHTML = "";
                }
                formatCellsWithComma();
                CalculateEstimate2Total();
                CalcEstmateGoodsP2Increase()

            }

        }
        function CalcEstmateGoodsP2Increase() {

            formatCellsWithoutComma();
            var txtGoods = document.getElementById('<%=lblTradingOfGoodsP2.ClientID%>').innerHTML
            var Percent = document.getElementById('<%=txtTradingOfGoodsP2Per.ClientID%>').value
            if (Percent.trim() != "" && txtGoods.trim() != "") {
                document.getElementById('<%=lblTradingOfGoodsP3.ClientID%>').innerHTML = Math.round(parseFloat(txtGoods) + (parseFloat(txtGoods) * checkNanCondition(Percent)) / 100);
            }
            else
                document.getElementById('<%=lblTradingOfGoodsP3.ClientID%>').innerHTML = "";

            formatCellsWithComma();
            CalculateEstimate3Total();


        }
        //Manufacturing sale % increase

        function CalcEstmateMfSaleP1Increase() {
            var flag = checkFormat(document.getElementById('<%=txtManufacturingSaleP1.ClientID%>').value);
            if (flag == true) {
                formatCellsWithoutComma();
                var txtMfSale = document.getElementById('<%=txtManufacturingSaleP1.ClientID%>').value
                var Percent = document.getElementById('<%=txtManufacturingSaleP1Per.ClientID%>').value
                if (Percent.trim() != "" && txtMfSale.trim() != "") {
                    document.getElementById('<%=lblManufacturingSaleP2.ClientID%>').innerHTML = Math.round(parseFloat(txtMfSale) + (parseFloat(txtMfSale) * checkNanCondition(Percent)) / 100);
                }
                else
                    document.getElementById('<%=lblManufacturingSaleP2.ClientID%>').innerHTML = "";
                formatCellsWithComma();
                CalculateEstimate2Total();
                CalcEstmateMfSaleP2Increase();

            }

        }
        function CalcEstmateMfSaleP2Increase() {

            formatCellsWithoutComma();
            var txtMfSale = document.getElementById('<%=lblManufacturingSaleP2.ClientID%>').innerHTML
            var Percent = document.getElementById('<%=txtManufacturingSaleP2Per.ClientID%>').value
            if (Percent.trim() != "" && txtMfSale.trim() != "") {
                document.getElementById('<%=lblManufacturingSaleP3.ClientID%>').innerHTML = Math.round(parseFloat(txtMfSale) + (parseFloat(txtMfSale) * checkNanCondition(Percent)) / 100);
                formatCellsWithComma();
            }
            else
                document.getElementById('<%=lblManufacturingSaleP3.ClientID%>').innerHTML = "";
            formatCellsWithComma();
            CalculateEstimate3Total();

        }

        //services % increase        
        function CalcEstmateServicesP1Increase() {
            var flag = checkFormat(document.getElementById('<%=txtServicesP1.ClientID%>').value);
            if (flag == true) {
                formatCellsWithoutComma();
                var txtServices = document.getElementById('<%=txtServicesP1.ClientID%>').value
                var Percent = document.getElementById('<%=txtServicesP1Per.ClientID%>').value
                if (Percent.trim() != "" && txtServices.trim() != "") {
                    document.getElementById('<%=lblServicesP2.ClientID%>').innerHTML = Math.round(parseFloat(txtServices) + (parseFloat(txtServices) * checkNanCondition(Percent)) / 100);

                }
                else
                    document.getElementById('<%=lblServicesP2.ClientID%>').innerHTML = "";
                formatCellsWithComma();
                CalculateEstimate2Total();
                CalcEstmateServicesP2Increase();
            }


        }
        function CalcEstmateServicesP2Increase() {

            formatCellsWithoutComma();
            var txtServices = document.getElementById('<%=lblServicesP2.ClientID%>').innerHTML
            var Percent = document.getElementById('<%=txtServicesP2Per.ClientID%>').value
            if (Percent.trim() != "" && txtServices.trim() != "") {
                document.getElementById('<%=lblServicesP3.ClientID%>').innerHTML = Math.round(parseFloat(txtServices) + (parseFloat(txtServices) * checkNanCondition(Percent)) / 100);

            }
            else
                document.getElementById('<%=lblServicesP3.ClientID%>').innerHTML = "";
            formatCellsWithComma();
            CalculateEstimate3Total();

        }




        function CalcSaleTotal() {

            var Sales1 = document.getElementById('<%=txtSales1.ClientID%>').value
            var Sales2 = document.getElementById('<%=txtSales2.ClientID%>').value
            var Sales3 = document.getElementById('<%=txtSales3.ClientID%>').value
            var Sales4 = document.getElementById('<%=txtSales4.ClientID%>').value


            if (Sales1.trim() != "") {
                Sales1 = Sales1;
            }
            else
                Sales1 = 0;
            if (Sales2.trim() != "") {
                Sales2 = Sales2;
            }
            else
                Sales2 = 0;
            if (Sales3.trim() != "") {
                Sales3 = Sales3;
            }
            else
                Sales3 = 0;
            if (Sales4.trim() != "") {
                Sales4 = Sales4;
            }
            else
                Sales4 = 0;


            var total = (parseFloat(Sales1) + parseFloat(Sales2) + parseFloat(Sales3) + parseFloat(Sales4));
            saleTotal = total;
            document.getElementById('<%=lblTotal.ClientID%>').innerHTML = total + ' %';
            if (total != 100) {
                document.getElementById('<%=lblTotal.ClientID%>').style.backgroundColor = '#DC7171';
            }
            else {
                document.getElementById('<%=lblTotal.ClientID%>').style.backgroundColor = 'White';
            }
            CalcDaysTotal();
        }
        function CalcDaysTotal() {

            var Sales1 = document.getElementById('<%=txtSales1.ClientID%>').value
            var Sales2 = document.getElementById('<%=txtSales2.ClientID%>').value
            var Sales3 = document.getElementById('<%=txtSales3.ClientID%>').value
            var Sales4 = document.getElementById('<%=txtSales4.ClientID%>').value

            var Days1 = document.getElementById('<%=txtDays1.ClientID%>').value
            var Days2 = document.getElementById('<%=txtDays2.ClientID%>').value
            var Days3 = document.getElementById('<%=txtDays3.ClientID%>').value
            var Days4 = document.getElementById('<%=txtDays4.ClientID%>').value

            if (Sales1.trim() != "") {
                Sales1 = Sales1;
            }
            else
                Sales1 = 0;
            if (Sales2.trim() != "") {
                Sales2 = Sales2;
            }
            else
                Sales2 = 0;
            if (Sales3.trim() != "") {
                Sales3 = Sales3;
            }
            else
                Sales3 = 0;
            if (Sales4.trim() != "") {
                Sales4 = Sales4;
            }
            else
                Sales4 = 0;



            if (Days1.trim() != "") {
                Days1 = Days1;
            }
            else
                Days1 = 0;
            if (Days2.trim() != "") {
                Days2 = Days2;
            }
            else
                Days2 = 0;
            if (Days3.trim() != "") {
                Days3 = Days3;
            }
            else
                Days3 = 0;
            if (Days4.trim() != "") {
                Days4 = Days4;
            }
            else
                Days4 = 0;


            var total = (parseFloat(Sales1) * parseInt(Days1) + parseFloat(Sales2) * parseInt(Days2) + parseFloat(Sales3) * parseInt(Days3) + parseFloat(Sales4) * parseInt(Days4));
            total = Math.round(total / 100);
            document.getElementById('<%=lblAvgNumberofDays.ClientID%>').innerHTML = total;
            document.getElementById('<%=txtDays.ClientID%>').value = total;
            document.getElementById('<%=lblAvgDays.ClientID%>').innerHTML = total;
        }


        function checkNanCondition(tempValue) {
            var check = isNaN(parseInt(tempValue));
            if (check == false) {
                return tempValue;
            }
            else {
                return 0;
            }

        }

        var SplitIds = '<%=strTxtClientIds %>'.split(',');
        var lblSplitIds = '<%=strLblClientIds %>'.split(',');

        function IsValid() {

            var flg = false;
            hide1B();
            var txtvalue = document.getElementById('<%=txtDays.ClientID%>').value;
            CalcSaleTotal();
            document.getElementById('<%=txtDays.ClientID%>').value = txtvalue;
            if (radioSelectedValue == "0") {
                if (saleTotal != 100) {
                    var lblPercentage = document.getElementById('<%=lblPercentage.ClientID%>').innerHTML
                    alert(lblPercentage);
                    return false;
                }
            }
            for (i = 0; i <= SplitIds.length - 1; i++) {
                var txtObj = document.getElementById(SplitIds[i]);
                var flag = checkFormat(txtObj.value);
                if (flag == false) {
                    flg = true;
                    txtObj.style.background = '#DC7171';
                }
                else {
                    var tempVal = replaceBracketsWithNegativeSign(txtObj.value);
                    txtObj.value = removeSplCharacters(tempVal);
                }
            }
            for (i = 0; i <= lblSplitIds.length - 1; i++) {

                var lblObj = document.getElementById(lblSplitIds[i]);
                var tempVal = replaceBracketsWithNegativeSign(lblObj.innerHTML);
                lblObj.innerHTML = removeSplCharacters(tempVal);
            }

            if (flg == true) {
                var lblGiven = document.getElementById('<%=lblGiven.ClientID%>').innerHTML
                alert(lblGiven);
                formatCellsWithComma();
                return false;
            }
            //            return confirm('Are you sure, you want to save the data.');
            var lblAreYou = document.getElementById('<%=lblAreYou.ClientID%>').innerHTML 
            if (confirm(lblAreYou)) {
                return true;
            }
            else {
                formatCellsWithComma();
                return false;
            }
        }

        function formatCellsWithComma() {

            for (i = 0; i <= SplitIds.length - 1; i++) {

                var txtObj = document.getElementById(SplitIds[i]);

                var val = document.getElementById(SplitIds[i]).value;

                txtObj.value = includeComma(val, 3);
            }

            for (i = 0; i <= lblSplitIds.length - 1; i++) {

                var lblObj = document.getElementById(lblSplitIds[i]);

                var val = document.getElementById(lblSplitIds[i]).innerHTML;

                lblObj.innerHTML = includeComma(val, 3);
            }

        }


        function formatCellsWithoutComma() {

            for (i = 0; i <= SplitIds.length - 1; i++) {

                var txtObj = document.getElementById(SplitIds[i]);
                var tempVal = replaceBracketsWithNegativeSign(txtObj.value);
                //                var val = document.getElementById(SplitIds[i]).value;
                txtObj.value = removeSplCharacters(tempVal);
            }

            for (i = 0; i <= lblSplitIds.length - 1; i++) {

                var lblObj = document.getElementById(lblSplitIds[i]);
                var tempVal = replaceBracketsWithNegativeSign(lblObj.innerHTML);
                //                var val = document.getElementById(lblSplitIds[i]).innerHTML;
                lblObj.innerHTML = removeSplCharacters(tempVal);
            }

        }
        function Combine(strhide) {
            if (strhide == 'yes') {
                hide1B();
            }
            formatCellsWithComma();

        }
        function ConfirmChoice() {
            var lblDoYou = document.getElementById('<%=lblDoYou.ClientID%>').innerHTML
            answer = confirm(lblDoYou)
            if (answer == "0") {
                document.getElementById('<%= hfValue.ClientID %>').value = 0;
                return true;
            }
            else {
                document.getElementById('<%= hfValue.ClientID %>').value = 1;

                var flg = false;

                for (i = 0; i <= SplitIds.length - 1; i++) {
                    var txtObj = document.getElementById(SplitIds[i]);
                    var flag = checkFormat(txtObj.value);
                    if (flag == false) {
                        flg = true;
                        txtObj.style.background = '#DC7171';
                    }
                    else {
                        var tempVal = replaceBracketsWithNegativeSign(txtObj.value);
                        txtObj.value = removeSplCharacters(tempVal);
                    }
                }
                for (i = 0; i <= lblSplitIds.length - 1; i++) {

                    var lblObj = document.getElementById(lblSplitIds[i]);
                    var tempVal = replaceBracketsWithNegativeSign(lblObj.innerHTML);
                    lblObj.innerHTML = removeSplCharacters(tempVal);
                }

                if (flg == true) {
                    var lblGiven = document.getElementById('<%=lblGiven.ClientID%>').innerHTML
                    alert(lblGiven);
                    formatCellsWithComma();
                    return false;
                }

                hide1B();
                var txtvalue = document.getElementById('<%=txtDays.ClientID%>').value;
                CalcSaleTotal();
                document.getElementById('<%=txtDays.ClientID%>').value = txtvalue;
                if (radioSelectedValue == "0") {
                    if (saleTotal != 100) {
                        var lblPercentage = document.getElementById('<%=lblPercentage.ClientID%>').innerHTML
                        alert(lblPercentage);
                        formatCellsWithComma();
                        return false;
                    }
                }
                return true; ;
            }

        }
        function SaveData() {
            var lblDoYouChanges = document.getElementById('<%=lblDoYouChanges.ClientID%>').innerHTML
            answer = confirm(lblDoYouChanges)
            if (answer == "0") {
                document.getElementById('<%= hfValue1.ClientID %>').value = 0;
                return true;
            }
            else {
                document.getElementById('<%= hfValue1.ClientID %>').value = 1;

                var flg = false;

                for (i = 0; i <= SplitIds.length - 1; i++) {
                    var txtObj = document.getElementById(SplitIds[i]);
                    var flag = checkFormat(txtObj.value);
                    if (flag == false) {
                        flg = true;
                        txtObj.style.background = '#DC7171';
                    }
                    else {
                        var tempVal = replaceBracketsWithNegativeSign(txtObj.value);
                        txtObj.value = removeSplCharacters(tempVal);
                    }
                }
                for (i = 0; i <= lblSplitIds.length - 1; i++) {

                    var lblObj = document.getElementById(lblSplitIds[i]);
                    var tempVal = replaceBracketsWithNegativeSign(lblObj.innerHTML);
                    lblObj.innerHTML = removeSplCharacters(tempVal);
                }

                if (flg == true) {
                    var lblGiven = document.getElementById('<%=lblGiven.ClientID%>').innerHTML
                    alert(lblGiven);
                    formatCellsWithComma();
                    return false;
                }

                hide1B();
                var txtvalue = document.getElementById('<%=txtDays.ClientID%>').value;
                CalcSaleTotal();
                document.getElementById('<%=txtDays.ClientID%>').value = txtvalue;
                if (radioSelectedValue == "0") {
                    if (saleTotal != 100) {
                        var lblPercentage = document.getElementById('<%=lblPercentage.ClientID%>').innerHTML
                        alert(lblPercentage);
                        formatCellsWithComma();
                        return false;
                    }
                }
                return true; ;
            }
        }
        function runScript(e) {
            if (e.keyCode == 13) {
                return false;
            }
            else
                return true;
        }
        
    </script>

    <script type="text/javascript">

        //
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        //Raised before processing of an asynchronous postback starts and the postback request is sent to the server.
        prm.add_beginRequest(BeginRequestHandler);
        // Raised after an asynchronous postback is finished and control has been returned to the browser.
        prm.add_endRequest(EndRequestHandler);
        function BeginRequestHandler(sender, args) {
            //Shows the modal popup - the update progress
            var popup = $find('<%= modalPopup.ClientID %>');
            if (popup != null) {
                popup.show();
                              document.body.scroll = "no" 
            }
        }

        function EndRequestHandler(sender, args) {
            //Hide the modal popup - the update progress
            var popup = $find('<%= modalPopup.ClientID %>');
            if (popup != null) {
                popup.hide();
                              document.body.scroll = "yes" 
            }
        }
    </script>

</asp:Content>
