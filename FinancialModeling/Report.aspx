<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="FinancialModeling_Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ABS : The Association of Banks in Singapore</title>
    <link href="<%# Page.ResolveUrl("~/css/stylesheet.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%# Page.ResolveUrl("~/css/print.css") %>" rel="stylesheet" media="print"
        type="text/css" />
    <style type="text/css">
        .orange_button
        {
            background: #fc6d01 url(../images/butimage.jpg) repeat-x;
            border: 1px solid #f45a07;
            font-size: 14px;
            color: #fff;
            font-weight: bold;
            cursor: pointer;
            padding: 6px 10px;
        }
        .supporter{color:#394c8c; font-size:19px; font-weight:bold; 	}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="smId" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up1" runat="server">
        <contenttemplate>
            <table width="1003" border="0" cellpadding="0" cellspacing="0" class="maintable">
                <tr>
                    <td align="left" valign="top">
                        <table width="1003" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="left" valign="top">
                                    &nbsp;
                                </td>
                                <td align="right" valign="bottom">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td width="500" align="left" valign="top">
                                    <table width="500" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td align="left" valign="middle">
                                                <h1>
                                                    Welcome <span>David</span> of ABS!</h1>
                                                <h2>
                                                    Your last login was on 08/12/11 at 11:30 AM</h2>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="503" align="right" valign="bottom">
                                    <table width="180" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td>
                                                <img src="<%= Page.ResolveUrl("~/images/userIcon.jpg") %>" width="14" height="14" alt="" />
                                            </td>
                                            <td>
                                                <a href="<%= Page.ResolveUrl("~/Public/MyAccount.aspx") %>" class="topnav">My Profile</a>
                                            </td>
                                            <td>
                                                <img src="<%= Page.ResolveUrl("~/images/icon_dashboard.jpg") %>" width="16" height="15"
                                                    alt="" />
                                            </td>
                                            <td>
                                                <a href="<%= Page.ResolveUrl("~/Public/Dashboard.aspx") %>" class="topnav">Dashboard</a>
                                            </td>
                                            <td>
                                                <img src="<%= Page.ResolveUrl("~/images/logout_icon.png") %>" width="14" height="14"
                                                    alt="" />
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lBtnLogout" runat="server" CssClass="topnav" Text="Logout" OnClick="lBtnLogout_Click"
                                                    CausesValidation="false"></asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td colspan="5" align="right">
                                                <table width="215" border="0" cellpadding="0" cellspacing="0" style="margin-top: 5px;">
                                                    <tr>
                                                        <td width="155" align="center" valign="middle">
                                                            &nbsp;
                                                        </td>
                                                        <td height="3%" align="center" valign="middle">
                                                            <img src="<%= Page.ResolveUrl("~/images/printIcon.jpg") %>" width="18" height="17" alt="" />
                                                        </td>
                                                        <td width="35" align="center" valign="middle">
                                                            <a href="#" class="topnav">Print</a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top">
                        <table width="1003" border="0" cellpadding="0" cellspacing="0" class="border" style="margin: 8px 0px;">
                            <tr>
                                <td>
                                    <table width="1003" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="263" align="center" valign="top" class="leftNav">
                                                <table width="94%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td align="center" valign="top">
                                                            <table width="230" border="0" cellpadding="0" cellspacing="0" class="marTB">
                                                                <tr>
                                                                    <td width="27" height="30" align="left" valign="middle">
                                                                        <asp:Image ID="imgOne" runat="server" Width="21" Height="21" />
                                                                    </td>
                                                                    <td width="203" align="left" valign="middle">
                                                                        <asp:LinkButton ID="lbFinPerfo" runat="server" OnClick="lbFinPerfo_Click">Financial Performance</asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" align="left" valign="middle">
                                                                        <img src="<%= Page.ResolveUrl("~/images/hrline.jpg") %>" width="229" height="1" alt="" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="27" height="30" align="left" valign="middle">
                                                                        <asp:Image ID="imgTwo" runat="server" Width="21" Height="21" />
                                                                    </td>
                                                                    <td width="203" align="left" valign="middle">
                                                                        <asp:LinkButton ID="lbFinPosition" runat="server" OnClick="lbFinPosition_Click">Financial Position</asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" align="left" valign="middle">
                                                                        <img src="<%= Page.ResolveUrl("~/images/hrline.jpg") %>" width="229" height="1" alt="" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="27" height="30" align="left" valign="middle">
                                                                        <asp:Image ID="imgThree" runat="server" Width="21" Height="21" />
                                                                    </td>
                                                                    <td width="203" align="left" valign="middle">
                                                                        <asp:LinkButton ID="lbCashFlowAnalysis" runat="server" OnClick="lbCashFlowAnalysis_Click">Cash Flow Analysis</asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" align="left" valign="middle">
                                                                        <img src="<%= Page.ResolveUrl("~/images/hrline.jpg") %>" width="229" height="1" alt="" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="27" height="30" align="left" valign="middle">
                                                                        <asp:Image ID="imgFour" runat="server" Width="21" Height="21" />
                                                                    </td>
                                                                    <td width="203" align="left" valign="middle">
                                                                        <asp:LinkButton ID="lbWorkingCapitalCycle" runat="server" OnClick="lbWorkingCapitalCycle_Click">Working Capital Cycle</asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" align="left" valign="middle">
                                                                        <img src="<%= Page.ResolveUrl("~/images/hrline.jpg") %>" width="229" height="1" alt="" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="27" height="30" align="left" valign="middle">
                                                                        <asp:Image ID="imgFive" runat="server" Width="21" Height="21" />
                                                                    </td>
                                                                    <td width="203" align="left" valign="middle">
                                                                        <asp:LinkButton ID="lbFundingSalesGrowth" Text="Funding for Sales Growth" OnClick="lbFundinSalesGrowth_Click"
                                                                            runat="server"></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" align="left" valign="middle">
                                                                        <img src="<%= Page.ResolveUrl("~/images/hrline.jpg") %>" width="229" height="1" alt="" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="27" height="30" align="left" valign="middle">
                                                                        <asp:Image ID="imgSix" runat="server" Width="21" Height="21" />
                                                                    </td>
                                                                    <td width="203" align="left" valign="middle">
                                                                        <asp:LinkButton ID="lbDebtRepaymentSchedule" Text="Debt Repayment Schedule" runat="server"
                                                                            OnClick="lbDebtRepaymentSchedule_Click"></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" align="left" valign="middle">
                                                                        <img src="<%= Page.ResolveUrl("~/images/hrline.jpg") %>" width="229" height="1" alt="" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="27" height="30" align="left" valign="middle">
                                                                        <asp:Image ID="imgSeven" runat="server" Width="21" Height="21" />
                                                                    </td>
                                                                    <td width="203" align="left" valign="middle">
                                                                        <asp:LinkButton ID="lbBreakEvenPoints" Text="Break Even Points" runat="server" OnClick="lbBreakEvenPoints_Click"></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" align="left" valign="middle">
                                                                        <img src="<%= Page.ResolveUrl("~/images/hrline.jpg") %>" width="229" height="1" alt="" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="27" height="30" align="left" valign="middle">
                                                                        <asp:Image ID="imgEight" runat="server" Width="21" Height="21" />
                                                                    </td>
                                                                    <td width="203" align="left" valign="middle">
                                                                        <asp:LinkButton ID="lbKpiProfitablility1" Text="Key Performance Indicators - Profitability 1"
                                                                            runat="server" OnClick="lbKpiProfitablility1_Click"></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" align="left" valign="middle">
                                                                        <img src="<%= Page.ResolveUrl("~/images/hrline.jpg") %>" width="229" height="1" alt="" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="27" height="30" align="left" valign="middle">
                                                                        <asp:Image ID="imgNine" runat="server" Width="21" Height="21" />
                                                                    </td>
                                                                    <td width="203" align="left" valign="middle">
                                                                        <asp:LinkButton ID="lbKpiProfitablility2" Text="Key Performance Indicators - Profitability 2"
                                                                            runat="server" OnClick="lbKpiProfitablility2_Click"></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" align="left" valign="middle">
                                                                        <img src="<%= Page.ResolveUrl("~/images/hrline.jpg") %>" width="229" height="1" alt="" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="27" height="30" align="left" valign="middle">
                                                                        <asp:Image ID="imgTen" runat="server" Width="21" Height="21" />
                                                                    </td>
                                                                    <td width="203" align="left" valign="middle">
                                                                        <asp:LinkButton ID="lbKpiLiquidity" Text="Key Performance Indicators - Liquidity"
                                                                            runat="server" OnClick="lbKpiLiquidity_Click"></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" align="left" valign="middle">
                                                                        <img src="<%= Page.ResolveUrl("~/images/hrline.jpg") %>" width="229" height="1" alt="" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="30" align="left" valign="middle">
                                                                        <asp:Image ID="imgEleven" runat="server" Width="21" Height="21" />
                                                                    </td>
                                                                    <td align="left" valign="middle">
                                                                        <asp:LinkButton ID="lbKpiLeverage" Text="Key Performance Indicators - Leverage" runat="server"
                                                                            OnClick="lbKpiLeverage_Click"></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" align="left" valign="middle">
                                                                        <img src="<%= Page.ResolveUrl("~/images/hrline.jpg") %>" width="229" height="1" alt="" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="30" align="left" valign="middle">
                                                                        <asp:Image ID="imgTwelve" runat="server" Width="21" Height="21" />
                                                                    </td>
                                                                    <td align="left" valign="middle">
                                                                        <asp:LinkButton ID="lbKeySensitivityReport" Text="Key Sensitivity Report" runat="server"
                                                                            OnClick="lbKeySensitivityReport_Click"></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="bottom">
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="ABS">
                                                                <tr>
                                                                    <td align="right" valign="top">
                                                                        <table width="50%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td align="right" valign="top">
                                                                                    <img src="<%= Page.ResolveUrl("~/images/ABSLOGO.jpg") %>" width="112" height="42" alt="" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="50" align="right" valign="bottom">
                                                                                    <img src="<%= Page.ResolveUrl("~/images/RSMLOGO.jpg") %>" width="68" height="37" alt="" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="60" align="right" valign="bottom">
                                                                                    <img src="<%= Page.ResolveUrl("~/images/WebSynergies.jpg") %>" width="80" height="45"
                                                                                        alt="" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="bottom">
                                                                        <img src="<%= Page.ResolveUrl("~/images/gotop.jpg") %>" width="88" height="32" alt="" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="740" align="left" valign="top">
                                                <table width="100%">
                                                    <tr id="trFinGraphs" runat="server">
                                                        <td align="left">
                                                            <asp:PlaceHolder runat="server" ID="phFinancialGraphs"></asp:PlaceHolder>
                                                        </td>
                                                    </tr>
                                                    <tr id="trBreakEven" valign="top" runat="server" visible="false">
                                                        <td align="left">
                                                     <%--       <uc2:BreakEvenPoints ID="BreakEvenPoints1" runat="server" />--%>
                                                        </td>
                                                    </tr>
                                                    <tr id="trKeyRpt" valign="top" runat="server" visible="false">
                                                        <td align="left">
                                                      <%--      <uc1:KeySensitivityReport ID="KeySensitivityReport1" runat="server" />--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </contenttemplate>
    </asp:UpdatePanel>
    <table width="1003" border="0" cellpadding="0" cellspacing="0" class="maintable"
        style="vertical-align: bottom;">
        <tr>
            <td align="left" valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="82%" align="left" valign="middle">
                            <p>
                                © 2011 ABS. All Rights Reserved.</p>
                        </td>
                        <td align="right" valign="middle">
                            <p>
                                Email us: <a href="mailto:banks@abs.org.sg">banks@abs.org.sg</a></p>
                        </td>
                    </tr>
                    <tr>
                        <td height="85" valign="bottom">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left" style="height: 25px;" class="supporter" colspan="6">
                                        Our Supporters
                                    </td>
                                </tr>
                                <tr>
                                    <td width="150" align="center" valign="bottom">
                                        <a href="http://www.abs.org.sg/cms/index.php" target="_blank">
                                            <img src="<%= Page.ResolveUrl("~/images/ABS-small-logo.jpg") %>" alt="" border="0"
                                                align="bottom" /></a>
                                    </td>
                                    <td width="129" align="center" valign="bottom">
                                        <a href="http://www.dbs.com/home/Pages/default.aspx" target="_blank">
                                            <img src="<%= Page.ResolveUrl("~/images/DBS-smalllogo.jpg") %>" alt="" border="0"
                                                align="bottom" /></a>
                                    </td>
                                    <td width="134" align="center" valign="middle">
                                        <a href="http://www.ocbc.com/global/main/index.shtm" target="_blank">
                                            <img src="<%= Page.ResolveUrl("~/images/ocbc.jpg") %>" alt="" border="0" align="bottom" /></a>
                                    </td>
                                    <td width="123" align="center" valign="bottom">
                                        <a href="http://www.uob.com.sg/personal/index.html" target="_blank">
                                            <img src="<%= Page.ResolveUrl("~/images/uob.jpg") %>" alt="" border="0" align="bottom" /></a>
                                    </td>
                                    <td width="123" align="center" valign="bottom">
                                        <a href="http://www.spring.gov.sg/Pages/Homepage.aspx" target="_blank">
                                            <img src="<%= Page.ResolveUrl("~/images/spring.jpg") %>" alt="" width="85" height="80"
                                                border="0" align="bottom" /></a>
                                    </td>
                                    <td width="215" align="center" valign="middle">
                                        <a href="http://www.rsmchiolim.com.sg/" target="_blank">
                                            <img src="<%= Page.ResolveUrl("~/images/stoneforest.jpg") %>" alt="" width="200"
                                                height="46" border="0" align="bottom" /></a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
