<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reports_All.aspx.cs" Inherits="Reports_All"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="~/UserControls/ReportsHome.ascx" TagName="ReportsHome" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/Hightlights.ascx" TagName="Hightlights" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/breakeven.ascx" TagName="Breakeven" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/CashFlow.ascx" TagName="CashFlow" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/Funding.ascx" TagName="Funding" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/TradeCycle.ascx" TagName="TradeCycle" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/WorkingCapital.ascx" TagName="WorkingCapital" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/Appendix.ascx" TagName="Appendix" TagPrefix="uc1" %>
<link href="<%= Page.ResolveUrl("~/css/report.css") %>" rel="stylesheet" type="text/css" />
<link href="<%= Page.ResolveUrl("~/css/mainstyles.css") %>" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../scripts/Common.js" type="text/javascript"></script>
    <style type="text/css">
        .break
        {
            page-break-before: always;
            background-image: images/ABSLogo.jpg;
            background-position: right;
        }
        .HideTR1
        {
            height: 700px;
        }
        .HideTR2
        {
            height: 1950px;
        }
    </style>
</head>
<body>
    <script type="text/javascript" language="javascript">

        function formatCellsWithComma(strLblClientIds) {
            var lblSplitIds = strLblClientIds.split(',');

            for (i = 0; i <= lblSplitIds.length - 1; i++) {

                var lblObj = document.getElementById(lblSplitIds[i]);

                var val = document.getElementById(lblSplitIds[i]).innerHTML;

                lblObj.innerHTML = includeComma(val, 3);
            }
        }
      
      


    </script>
    <form id="form1" runat="server" class="Reportbody">
    <table width="779" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" width="779">
                    <tr>
                        <td align="left" style="height: 64px">
                            <%--       <asp:Image ID="Image9" runat="server" ImageUrl="~/images/Reports.png" />--%>
                        </td>
                        <td align="right">
                            <%--       <asp:Image ID="Image8" runat="server" ImageUrl="~/images/ABSLOGO_1.jpg" />--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="750" valign="top" class="timesheet_bg" style="height: 980px">
                <uc1:ReportsHome ID="ReportsHome1" runat="server" />
            </td>
            <td valign="top">
                <table width="29" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="3">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="imgBtnHightlight" runat="server" Width="29px" Height="117px" border="0"
                                ImageUrl="../images/highlights.jpg" meta:resourcekey="imgBtnHightlightResource1" />
                            <asp:Label ID="lblHigh" runat="server" Visible="False" 
                                meta:resourcekey="lblHighResource1"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="imgBtnBreakeven" runat="server" Width="29px" Height="117px" border="0"
                                ImageUrl="../images/breaken.jpg" meta:resourcekey="imgBtnBreakevenResource1" />
                            <asp:Label ID="lblBreakeven" runat="server" Visible="False" 
                                meta:resourcekey="lblBreakevenResource1"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="imgBtnWorkingCapital" runat="server" Width="29px" Height="117px" border="0"
                                ImageUrl="../images/WorkingCapital.jpg" meta:resourcekey="imgBtnWorkingCapitalResource1" />
                            <asp:Label ID="lblWorkingCapital" runat="server" Visible="False" 
                                meta:resourcekey="lblWorkingCapitalResource1"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="imgBtnCashFlow" runat="server" Width="29px" Height="117px" border="0"
                                ImageUrl="../images/CashFlow.jpg" meta:resourcekey="imgBtnCashFlowResource1" />
                            <asp:Label ID="lblCashFlow" runat="server" Visible="False" 
                                meta:resourcekey="lblCashFlowResource1"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="imgBtnFunding" runat="server" Width="29px" Height="117px" border="0"
                                ImageUrl="../images/Funding.jpg" meta:resourcekey="imgBtnFundingResource1" />
                            <asp:Label ID="lblFunding" runat="server" Visible="False" 
                                meta:resourcekey="lblFundingResource1"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="imgBtnAppendix1" runat="server" Width="29px" Height="117px" border="0"
                                ImageUrl="../images/AppendixA.jpg" meta:resourcekey="imgBtnAppendix1Resource1" />
                            <asp:Label ID="lblApp1" runat="server" Visible="False" 
                                meta:resourcekey="lblApp1Resource1"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="imgBtnAppendix2" runat="server" Width="29px" Height="117px" border="0"
                                ImageUrl="../images/AppendixB.jpg" meta:resourcekey="imgBtnAppendix2Resource1" />
                            <asp:Label ID="lblApp2" runat="server" Visible="False" 
                                meta:resourcekey="lblApp2Resource1"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="break">
            <td colspan="2">
                <table>
                    <tr>
                        <td align="left" colspan="2">
                            <table border="0" cellpadding="0" cellspacing="0" width="779">
                                <tr>
                                    <td align="left" style="height: 64px">
                                        <%--    <asp:Image ID="Image10" runat="server" ImageUrl="~/images/Reports.png" />--%>
                                    </td>
                                    <td align="right">
                                        <%--   <asp:Image ID="Image11" runat="server" ImageUrl="~/images/ABSLOGO_1.jpg" />--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="trCss" runat="server">
                        <td width="750" valign="top" class="timesheet_bg">
                            <uc1:Hightlights ID="Hightlights1" runat="server" />
                        </td>
                        <td valign="top">
                            <table width="29" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Image ID="ImageButton1" runat="server" Width="29px" Height="117px" border="0"
                                            ImageUrl="../images/highlights.jpg" meta:resourcekey="ImageButton1Resource1" />
                                        <asp:Label ID="lblHigh1" runat="server" Visible="False" 
                                            meta:resourcekey="lblHigh1Resource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
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
            <td>
                &nbsp;
            </td>
        </tr>
        <tr class="break">
            <td colspan="2">
                <table>
                    <tr>
                        <td align="left" colspan="2">
                            <table border="0" cellpadding="0" cellspacing="0" width="779">
                                <tr>
                                    <td align="left" style="height: 64px">
                                        <%--   <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Reports.png" />--%>
                                    </td>
                                    <td align="right">
                                        <%--  <asp:Image ID="Image12" runat="server" ImageUrl="~/images/ABSLOGO_1.jpg" />--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="750" valign="top" class="timesheet_bg" style="height: 980px">
                            <uc1:Breakeven ID="Breakeven1" runat="server" />
                        </td>
                        <td valign="top">
                            <table width="29" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Image ID="ImageButton2" runat="server" Width="29px" Height="117px" border="0"
                                            ImageUrl="../images/breaken.jpg" meta:resourcekey="ImageButton2Resource1" />
                                        <asp:Label ID="lblBreakeven1" runat="server" Visible="False" 
                                            meta:resourcekey="lblBreakeven1Resource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
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
            <td>
                &nbsp;
            </td>
        </tr>
        <tr class="break">
            <td colspan="2">
                <table>
                    <tr>
                        <td align="left" colspan="2">
                            <table border="0" cellpadding="0" cellspacing="0" width="779">
                                <tr>
                                    <td align="left" style="height: 64px">
                                        <%--    <asp:Image ID="Image3" runat="server" ImageUrl="~/images/Reports.png" />--%>
                                    </td>
                                    <td align="right">
                                        <%--    <asp:Image ID="Image13" runat="server" ImageUrl="~/images/ABSLOGO_1.jpg" />--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="750" valign="top" class="timesheet_bg" style="height: 2060px">
                            <uc1:WorkingCapital ID="WorkingCapital1" runat="server" />
                        </td>
                        <td valign="top">
                            <table width="29" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Image ID="ImageButton3" runat="server" Width="29px" Height="117px" border="0"
                                            ImageUrl="../images/WorkingCapital.jpg" meta:resourcekey="ImageButton3Resource1" />
                                        <asp:Label ID="lblWorkingCapital1" runat="server" Visible="False" 
                                            meta:resourcekey="lblWorkingCapital1Resource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
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
            <td>
                &nbsp;
            </td>
        </tr>
        <tr class="break">
            <td colspan="2">
                <table>
                    <tr>
                        <td align="left" colspan="2">
                            <table border="0" cellpadding="0" cellspacing="0" width="779">
                                <tr>
                                    <td align="left" style="height: 64px">
                                        <%--   <asp:Image ID="Image4" runat="server" ImageUrl="~/images/Reports.png" />--%>
                                    </td>
                                    <td align="right">
                                        <%--         <asp:Image ID="Image14" runat="server" ImageUrl="~/images/ABSLOGO_1.jpg" />--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="750" valign="top" class="timesheet_bg" style="height: 1900px">
                            <uc1:CashFlow ID="CashFlow1" runat="server" />
                        </td>
                        <td valign="top">
                            <table width="29" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Image ID="ImageButton4" runat="server" Width="29px" Height="117px" border="0"
                                            ImageUrl="../images/CashFlow.jpg" meta:resourcekey="ImageButton4Resource1" />
                                        <asp:Label ID="lblCashFlow1" runat="server" Visible="False" 
                                            meta:resourcekey="lblCashFlow1Resource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
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
            <td>
                &nbsp;
            </td>
        </tr>
        <tr class="break">
            <td colspan="2">
                <table>
                    <tr>
                        <td align="left" colspan="2">
                            <table border="0" cellpadding="0" cellspacing="0" width="779">
                                <tr>
                                    <td align="left" style="height: 64px">
                                        <%--<asp:Image ID="Image5" runat="server" ImageUrl="~/images/Reports.png" />--%>
                                    </td>
                                    <td align="right">
                                        <%--  <asp:Image ID="Image15" runat="server" ImageUrl="~/images/ABSLOGO_1.jpg" /--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="750" valign="top" class="timesheet_bg" style="height: 980px">
                            <uc1:Funding ID="Funding1" runat="server" />
                        </td>
                        <td valign="top">
                            <table width="29" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Image ID="ImageButton5" runat="server" Width="29px" Height="117px" border="0"
                                            ImageUrl="../images/Funding.jpg" meta:resourcekey="ImageButton5Resource1" />
                                        <asp:Label ID="lblFunding1" runat="server" Visible="False" 
                                            meta:resourcekey="lblFunding1Resource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
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
            <td>
                &nbsp;
            </td>
        </tr>
        <tr class="break">
            <td colspan="2">
                <table>
                    <tr>
                        <td align="left" colspan="2">
                            <table border="0" cellpadding="0" cellspacing="0" width="779">
                                <tr>
                                    <td align="left" style="height: 64px">
                                        <%--  <asp:Image ID="Image6" runat="server" ImageUrl="~/images/Reports.png" />--%>
                                    </td>
                                    <td align="right">
                                        <%--  <asp:Image ID="Image16" runat="server" ImageUrl="~/images/ABSLOGO_1.jpg" />--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="750" valign="top" class="timesheet_bg" style="height: 1950px">
                            <uc1:TradeCycle ID="TradeCycle" runat="server" />
                        </td>
                        <td valign="top">
                            <table width="29" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Image ID="ImageButton6" runat="server" Width="29px" Height="117px" border="0"
                                            ImageUrl="../images/AppendixA.jpg" meta:resourcekey="ImageButton6Resource1" />
                                        <asp:Label ID="lblAppA1" runat="server" Visible="False" 
                                            meta:resourcekey="lblAppA1Resource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
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
            <td>
                &nbsp;
            </td>
        </tr>
        <tr class="break">
            <td colspan="2">
                <table>
                    <tr>
                        <td align="left" colspan="2">
                            <table border="0" cellpadding="0" cellspacing="0" width="779">
                                <tr>
                                    <td align="left" style="height: 64px">
                                        <%--  <asp:Image ID="Image7" runat="server" ImageUrl="~/images/Reports.png" />--%>
                                    </td>
                                    <td align="right">
                                        <%--  <asp:Image ID="Image17" runat="server" ImageUrl="~/images/ABSLOGO_1.jpg" />--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="750" valign="top" class="timesheet_bg" style="height: 1020px">
                            <uc1:Appendix ID="Appendix1" runat="server" />
                        </td>
                        <td valign="top">
                            <table width="29" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Image ID="Image1" runat="server" Width="29px" Height="117px" border="0" ImageUrl="../images/AppendixB.jpg"
                                            meta:resourcekey="Image1Resource1" />
                                        <asp:Label ID="lblAppA2" runat="server" Visible="False" 
                                            meta:resourcekey="lblAppA2Resource1"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
    <%-- <script type="text/javascript" language="javascript">
        alert(document.getElementById('headerP1'));
        document.getElementById('headerP1').style.display = "block";
    </script>--%>
</body>
</html>
