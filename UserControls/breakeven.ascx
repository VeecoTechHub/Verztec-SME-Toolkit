<%@ Control Language="C#" AutoEventWireup="true" CodeFile="breakeven.ascx.cs" Inherits="UserControls_breakeven" %>
<table width="90%" border="0" align="center" cellpadding="0" cellspacing="0" style="padding-left: 25px;
    height: 900px">
    <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="breakeven">
            <asp:Label ID="lblCashflowBreakevenAnalysis" runat="server" Text="Cash flow Breakeven Analysis"
                meta:resourcekey="lblCashflowBreakevenAnalysisResource1"></asp:Label>
            <%--<asp:Image ID="imgHeader" runat="server" Width="680" ImageUrl="~/images/breakeven.png" />--%>
        </td>
    </tr>
    <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="FontStyle">
            <asp:Localize ID="locPara1" runat="server" Text="
       Is your business generating sufficient sales to pay for the operating expenses and loan commitments? The sales surplus
        (or shortfall) for cash flow breakeven is illustrated below based on your projection for the next three years:"
                meta:resourcekey="locPara1Resource1"></asp:Localize>
        </td>
    </tr>
    <tr>
        <td align="center">
            <table class="tblBorder" width="600px" cellpadding="0" cellspacing="0" style="font-size: 8.5pt;
                font-family: Verdana, Arial, haettenschweiler; color: #000000;">
                <tr style="background-color: #0099FF; color: White; font-weight: bold">
                    <td style="width: 300px" align="right">
                    </td>
                    <td style="" align="center">
                        <asp:Label ID="lbl1Fy" runat="server" Text="FY" meta:resourcekey="lbl1FyResource1"></asp:Label>
                        <asp:Label ID="lblYearP1" runat="server" meta:resourcekey="lblYearP1Resource1"></asp:Label><br />
                        <asp:Label ID="lbl1P" runat="server" Text="P" meta:resourcekey="lbl1PResource1"></asp:Label>
                    </td>
                    <td style="" align="center">
                        <asp:Label ID="lbl2Fy" runat="server" Text="FY" meta:resourcekey="lbl2FyResource1"></asp:Label>
                        <asp:Label ID="lblYearP2" runat="server" meta:resourcekey="lblYearP2Resource1"></asp:Label><br />
                        <asp:Label ID="lbl2P" runat="server" Text="P" meta:resourcekey="lbl2PResource1"></asp:Label>
                    </td>
                    <td style="" align="center">
                        <asp:Label ID="lbl3Fy" runat="server" Text="FY" meta:resourcekey="lbl3FyResource1"></asp:Label>
                        <asp:Label ID="lblYearP3" runat="server" meta:resourcekey="lblYearP3Resource1"></asp:Label><br />
                        <asp:Label ID="lbl3P" runat="server" Text="P" meta:resourcekey="lbl3PResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="left" style="font-weight: bold">
                        <asp:Label ID="lblMindimum" runat="server" Text="Minimum sales that your business needs to generate in order to"
                            meta:resourcekey="lblMindimumResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lbloperatingexpenses" runat="server" Text="(i)   Pay for operating expenses"
                            meta:resourcekey="lbloperatingexpensesResource1"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblCoverFixedExpensesP1" runat="server" meta:resourcekey="lblCoverFixedExpensesP1Resource1"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblCoverFixedExpensesP2" runat="server" meta:resourcekey="lblCoverFixedExpensesP2Resource1"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblCoverFixedExpensesP3" runat="server" meta:resourcekey="lblCoverFixedExpensesP3Resource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblinterests" runat="server" Text="(ii)  Pay for interests" meta:resourcekey="lblinterestsResource1"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblCoverInterestsP1" runat="server" meta:resourcekey="lblCoverInterestsP1Resource1"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblCoverInterestsP2" runat="server" meta:resourcekey="lblCoverInterestsP2Resource1"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblCoverInterestsP3" runat="server" meta:resourcekey="lblCoverInterestsP3Resource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblinstalments" runat="server" Text="(iii) Pay loan instalments" meta:resourcekey="lblinstalmentsResource1"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblPrincipalPaymentsP1" runat="server" meta:resourcekey="lblPrincipalPaymentsP1Resource1"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblPrincipalPaymentsP2" runat="server" meta:resourcekey="lblPrincipalPaymentsP2Resource1"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblPrincipalPaymentsP3" runat="server" meta:resourcekey="lblPrincipalPaymentsP3Resource1"></asp:Label>
                    </td>
                </tr>
                <tr style="font-weight: bold; background-color: #ccecff">
                    <td align="left" style="background-color: #ccecff">
                        <asp:Label ID="lblMinimumSalesThat" runat="server" Text="(A) Minimum sales that your business"
                            meta:resourcekey="lblMinimumSalesThatResource1"></asp:Label>
                    
                    </td>
                    <td align="right">
                        <asp:Label ID="lblbreakevenP1" runat="server" meta:resourcekey="lblbreakevenP1Resource1"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblbreakevenP2" runat="server" meta:resourcekey="lblbreakevenP2Resource1"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblbreakevenP3" runat="server" meta:resourcekey="lblbreakevenP3Resource1"></asp:Label>
                    </td>
                </tr>
                <tr height="15">
                    <td colspan="4">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblprojectedsales" runat="server" Text="(B) Your projected sales"
                            meta:resourcekey="lblprojectedsalesResource1"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblTotalSalesP1" runat="server" meta:resourcekey="lblTotalSalesP1Resource1"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblTotalSalesP2" runat="server" meta:resourcekey="lblTotalSalesP2Resource1"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblTotalSalesP3" runat="server" meta:resourcekey="lblTotalSalesP3Resource1"></asp:Label>
                    </td>
                </tr>
                <tr height="15">
                    <td colspan="4">
                    </td>
                </tr>
                <tr style="font-weight: bold; background-color: #ccecff">
                    <td align="left" style="background-color: #ccecff">
                        <asp:Label ID="lblSurplus" runat="server" Text="Surplus / (Shortfall) in sales to (A) - (B)"
                            meta:resourcekey="lblSurplusResource1"></asp:Label>
                       
                    </td>
                    <td align="right">
                        <asp:Label ID="lblSaleSurplusP1" runat="server" meta:resourcekey="lblSaleSurplusP1Resource1"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblSaleSurplusP2" runat="server" meta:resourcekey="lblSaleSurplusP2Resource1"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblSaleSurplusP3" runat="server" meta:resourcekey="lblSaleSurplusP3Resource1"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="FontStyle">
            <asp:Localize ID="locPara2" runat="server" Text="
           Breakeven is one of the most important concepts in financial management. You need to know the minimum level of
            sales your business needs to generate in order 
               to cover operating costs. At breakeven sales level, your business does not make any profits. "
                meta:resourcekey="locPara2Resource1"></asp:Localize>
        </td>
    </tr>
    <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="FontStyle">
            <asp:Localize ID="locPara3" runat="server" Text="
            Do bear in mind that the analysis is done on the basis that you would be able to
            maintain the same level of margins as you have projected. If you cut your price
            to bring in the sales, your margin will be affected and it will also mean that you
            would have to bring in even higher sales to breakeven." meta:resourcekey="locPara3Resource1"></asp:Localize>
        </td>
    </tr>
    <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr style="font-weight: bold; font-style: italic">
        <td class="FontStyle">
            <asp:Label ID="lblWhat" runat="server" Text="What does the surplus or shortfall in sales to achieve cash flow breakeven means?"
                meta:resourcekey="lblWhatResource1"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="FontStyle">
            <asp:Label ID="lblIfYouHave" runat="server"  meta:resourcekey="lblIfYouHaveResource1"></asp:Label>
           
        </td>
    </tr>
    <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="FontStyle">
            <asp:Label ID="lblConversely" runat="server" 
                meta:resourcekey="lblConverselyResource1"></asp:Label>
           
        </td>
    </tr>
    <tr>
        <td>
            <table>
                <tr>
                    <td style="width: 40px">
                        &nbsp;
                    </td>
                    <td class="FontStyle">
                        <asp:Label ID="lblIncrease" runat="server" Text="(a) Increase sales and/or improving gross profit margin;"
                            meta:resourcekey="lblIncreaseResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 40px">
                        &nbsp;
                    </td>
                    <td class="FontStyle">
                        <asp:Label ID="lblReduce" runat="server" Text="(b) Reduce operating costs;" meta:resourcekey="lblReduceResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 40px">
                        &nbsp;
                    </td>
                    <td class="FontStyle">
                        <asp:Label ID="lblRestructure" runat="server" Text="(c) Restructure your loan facilities; or"
                            meta:resourcekey="lblRestructureResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 40px">
                        &nbsp;
                    </td>
                    <td class="FontStyle">
                        <asp:Label ID="lblcombination" runat="server" Text="(d) Any combination of the above."
                            meta:resourcekey="lblcombinationResource1"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
</table>
