<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WorkingCapital.ascx.cs"
    Inherits="UserControls_WorkingCapital" %>
<table width="90%" border="0" align="center" cellpadding="0" cellspacing="0" style="padding-left: 25px;"
    class="FontStyle">
    <tr>
        <td align="left" style="height: 980;">
            <table border="0" cellpadding="0" style="height: 980px;" cellspacing="0">
                <tr id="HideTr15" runat="server">
                    <td class="spacer">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="workingcapital">
                        <asp:Label ID="lblHeading" runat="server" Text="Cash Conversion Cycle" meta:resourcekey="lblHeadingResource1"></asp:Label>
                        <%--<asp:Image ID="imgHeader" runat="server" Width="680" ImageUrl="~/images/workingcaptialbar.png" />--%>
                    </td>
                </tr>
                <tr>
                    <td class="spacer">
                        &nbsp;
                    </td>
                </tr>
                <tr id="HideTr1" runat="server">
                    <td>
                        <asp:Localize ID="locPara1" runat="server" Text="Due to the different timing of activities in a business, it takes time to “turn”
                        a sale into cash. For example, a business that sells on credit terms may need to
                        wait a period of time until cash is finally collected. During the same period, payments
                        need to be made to staff and creditors. So the “gap” between collecting cash and
                        paying cash needs to be properly managed." meta:resourcekey="locPara1Resource1"></asp:Localize>
                    </td>
                </tr>
                <tr id="HideTr17" runat="server">
                    <td class="style2">
                        &nbsp;
                    </td>
                </tr>
                <tr id="HideTr2" runat="server">
                    <td>
                        <asp:Localize ID="locPara2" runat="server" Text="&lt;b&gt;Working Capital Days,&lt;/b&gt; also known as &lt;b&gt;Cash Conversion Cycle,&lt;/b&gt;refers to the period
                        of time in which resources are tied up in the business process before cash can be
                        generated. It is an indication of the &lt;b&gt;financing days&lt;/b&gt; that you need for your trade. If your business have strong capital base or have
                        generated sufficient past reserves, you may not need external financing." meta:resourcekey="locPara2Resource1"></asp:Localize>
                    </td>
                </tr>
                <tr>
                    <td style="height: 5px">
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        <asp:Label ID="lblYourMost" runat="server" Text="Your Most Recent Financial Year"
                            meta:resourcekey="lblYourMostResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 5px">
                    </td>
                </tr>
                <tr id="HideTr3" runat="server">
                    <td align="center" valign="middle">
                        <asp:Chart ID="CashConversion1_Chart" runat="server" BackColor="211, 223, 240" Width="600px"
                            Visible="False" Height="350px" BorderColor="#1A3B69" BorderDashStyle="Solid"
                            BackGradientStyle="TopBottom" BackSecondaryColor="White" ImageStorageMode="UseImageLocation"
                            BorderWidth="2px" ImageLocation="~\TempImages\ChartPic_#SEQ(300,3)" meta:resourcekey="CashConversion1_ChartResource1">
                            <Titles>
                                <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                                    ForeColor="26, 59, 105">
                                </asp:Title>
                            </Titles>
                            <Legends>
                                <asp:Legend Docking="Bottom" BackColor="AliceBlue" ItemColumnSpacing="500" LegendStyle="Column"
                                    Name="Legend2" Enabled="true" BorderWidth="1" BorderColor="Black" ItemColumnSeparator="Line"
                                    ItemColumnSeparatorColor="Black" AutoFitMinFontSize="10" TableStyle="Wide">
                                </asp:Legend>
                                <asp:Legend Docking="Bottom" LegendStyle="Table" BackColor="AliceBlue" Name="Legend1"
                                    TextWrapThreshold="50">
                                </asp:Legend>
                            </Legends>
                            <Series>
                                <asp:Series ChartArea="FinArea" Color="#9EDAEA" CustomProperties="DrawingStyle=Cylinder"
                                    IsValueShownAsLabel="true" Legend="Legend1" Label="#SERIESNAME #VAL">
                                </asp:Series>
                                <asp:Series ChartArea="FinArea" CustomProperties="DrawingStyle=Cylinder" Color="#C2ECF6"
                                    IsValueShownAsLabel="false" Legend="Legend1" Label="#SERIESNAME  #VAL">
                                </asp:Series>
                                <asp:Series ChartArea="FinArea" CustomProperties="DrawingStyle=Cylinder" Color="#329CB8"
                                    IsValueShownAsLabel="false" Legend="Legend1" Label="#SERIESNAME  #VAL">
                                </asp:Series>
                                <asp:Series ChartArea="FinArea" CustomProperties="DrawingStyle=Cylinder" Color="#FFEAE8"
                                    Label="#SERIESNAME #VAL" IsValueShownAsLabel="false" Legend="Legend1">
                                </asp:Series>
                                <asp:Series ChartArea="FinArea" CustomProperties="DrawingStyle=Cylinder" Color="#EA5656"
                                    Label="#SERIESNAME #VAL" IsValueShownAsLabel="true" Legend="Legend1">
                                </asp:Series>
                            </Series>
                            <BorderSkin SkinStyle="Emboss" PageColor="Transparent"></BorderSkin>
                            <ChartAreas>
                                <asp:ChartArea Name="FinArea" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                                    BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent"
                                    BackGradientStyle="TopBottom">
                                    <AxisX ArrowStyle="Triangle" Enabled="True" Interval="Auto">
                                    </AxisX>
                                    <AxisY2 IsLabelAutoFit="False" Enabled="False" Interval="Auto">
                                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                    </AxisY2>
                                    <AxisX2 Enabled="False">
                                    </AxisX2>
                                    <AxisY Interval="Auto" IsMarginVisible="true" IsStartedFromZero="false" ArrowStyle="Triangle">
                                    </AxisY>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                        <asp:Label ID="lblChartTitle" runat="server" Visible="False" meta:resourcekey="lblChartTitleResource1"></asp:Label>
                        <asp:Label ID="lblAvgStockHoldingsDays" runat="server" Visible="False" meta:resourcekey="lblAvgStockHoldingsDaysResource1"></asp:Label>
                        <asp:Label ID="lblAvgCollectionDays" runat="server" Visible="False" meta:resourcekey="lblAvgCollectionDaysResource1"></asp:Label>
                        <asp:Label ID="lblAvgFinancingDaysfromSupplliers" runat="server" Visible="False"
                            meta:resourcekey="lblAvgFinancingDaysfromSupplliersResource1"></asp:Label>
                        <asp:Label ID="lblAvgPaymentDays" runat="server" Visible="False" meta:resourcekey="lblAvgPaymentDaysResource1"></asp:Label>
                        <asp:Label ID="lblWorkingCapitalDays" runat="server" Visible="False" meta:resourcekey="lblWorkingCapitalDaysResource1"></asp:Label>
                        <asp:Label ID="lblCycleName1" runat="server" Visible="False" meta:resourcekey="lblCycleName1Resource1"></asp:Label>
                        <asp:Label ID="lblCycleName2" runat="server" Visible="False" meta:resourcekey="lblCycleName2Resource1"></asp:Label>
                        <asp:Label ID="lblDes1" runat="server" Visible="False" meta:resourcekey="lblDes1Resource1"></asp:Label>
                        <asp:Label ID="lblDes2" runat="server" Visible="False" meta:resourcekey="lblDes2Resource1"></asp:Label>
                        <asp:Label ID="lblDes3" runat="server" Visible="False" meta:resourcekey="lblDes3Resource1"></asp:Label>
                        <asp:Label ID="lblDes4" runat="server" Visible="False" meta:resourcekey="lblDes4Resource1"></asp:Label>
                        <asp:Label ID="lblDes5" runat="server" Visible="False" meta:resourcekey="lblDes5Resource1"></asp:Label>
                        <asp:Label ID="lblDes6" runat="server" Visible="False" meta:resourcekey="lblDes6Resource1"></asp:Label>
                        <asp:Label ID="lblDes7" runat="server" Visible="False" meta:resourcekey="lblDes7Resource1"></asp:Label>
                        <asp:Label ID="lblDes8" runat="server" Visible="False" meta:resourcekey="lblDes8Resource1"></asp:Label>
                        <asp:Label ID="lblDes9" runat="server" Visible="False" meta:resourcekey="lblDes9Resource1"></asp:Label>
                        <asp:Label ID="lblDes10" runat="server" Visible="False" meta:resourcekey="lblDes10Resource1"></asp:Label>
                        <asp:Label ID="lblDes11" runat="server" Visible="False" meta:resourcekey="lblDes11Resource1"></asp:Label>
                        <asp:Label ID="lblDes12" runat="server" Visible="False" meta:resourcekey="lblDes12Resource1"></asp:Label>
                        <asp:Label ID="lblDes13" runat="server" Visible="False" meta:resourcekey="lblDes13Resource1"></asp:Label>
                        <asp:Label ID="lblDes14" runat="server" Visible="False" meta:resourcekey="lblDes14Resource1"></asp:Label>
                        <asp:Label ID="lblDes15" runat="server" Visible="False" meta:resourcekey="lblDes15Resource1"></asp:Label>
                        <asp:Label ID="lblDes16" runat="server" Visible="False" meta:resourcekey="lblDes16Resource1"></asp:Label>
                        <asp:Label ID="lblDes17" runat="server" Visible="False" meta:resourcekey="lblDes17Resource1"></asp:Label>
                        <asp:Label ID="lblDes18" runat="server" Visible="False" meta:resourcekey="lblDes18Resource1"></asp:Label>
                        <asp:Label ID="lblDes19" runat="server" Visible="False" meta:resourcekey="lblDes19Resource1"></asp:Label>
                        <asp:Label ID="lblDes20" runat="server" Visible="False" meta:resourcekey="lblDes20Resource1"></asp:Label>
                        <asp:Label ID="lblDes21" runat="server" Visible="False" meta:resourcekey="lblDes21Resource1"></asp:Label>
                        <asp:Label ID="lblDes22" runat="server" Visible="False" meta:resourcekey="lblDes22Resource1"></asp:Label>
                        <asp:Label ID="lblDes23" runat="server" Visible="False" meta:resourcekey="lblDes23Resource1"></asp:Label>
                        <asp:Label ID="lblDes24" runat="server" Visible="False" meta:resourcekey="lblDes24Resource1"></asp:Label>
                        <asp:Label ID="lblDes25" runat="server" Visible="False" meta:resourcekey="lblDes25Resource1"></asp:Label>
                        <asp:Label ID="lblDays" runat="server" Visible="False" meta:resourcekey="lblDaysResource1"></asp:Label>
                        <asp:Label ID="lblfake1" runat="server" Visible="False" meta:resourcekey="lblfake1Resource1"></asp:Label>
                        <asp:Label ID="lblfake2" runat="server" Visible="False" meta:resourcekey="lblfake2Resource1"></asp:Label>
                        <asp:Label ID="lblfake3" runat="server" Visible="False" meta:resourcekey="lblfake3Resource1"></asp:Label>
                        <asp:Label ID="lblfake4" runat="server" Visible="False" meta:resourcekey="lblfake4Resource1"></asp:Label>
                    </td>
                </tr>
                <tr id="TrImage1" runat="server" style="height: 350px">
                    <td  id="tdHide1" runat="server">
                        <table border="0" align="center" cellpadding="0" cellspacing="0" style="padding-left: 55px;
                            padding-right: 70px;">
                            <tr>
                                <td>
                                    <asp:Localize ID="locPara3" runat="server" Text="This section is not applicable to your business as you have no balance in the past
                                    on the average stock holdings days, average collection days and average payment
                                    days." meta:resourcekey="locPara3Resource1"></asp:Localize>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="HideTr16" runat="server">
                    <td class="spacer">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top">
                        <h4>
                            <asp:Label ID="lblProjectionYears" runat="server" Text="Projection Years" meta:resourcekey="lblProjectionYearsResource1"></asp:Label>
                        </h4>
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="middle">
                        <asp:Chart ID="CashConversion2_Chart" runat="server" BackColor="211, 223, 240" Width="600px"
                            Height="340px" BorderColor="#1A3B69" BorderDashStyle="Solid" BackGradientStyle="TopBottom"
                            BackSecondaryColor="White" BorderWidth="2px" ImageStorageMode="UseImageLocation"
                            ImageLocation="~\TempImages\ChartPic_#SEQ(300,3)" meta:resourcekey="CashConversion2_ChartResource1">
                            <Titles>
                                <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                                    ForeColor="26, 59, 105">
                                </asp:Title>
                            </Titles>
                            <Legends>
                                <asp:Legend Docking="Bottom" BackColor="AliceBlue" ItemColumnSpacing="500" LegendStyle="Column"
                                    Name="Legend2" Enabled="true" BorderWidth="1" BorderColor="Black" ItemColumnSeparator="Line"
                                    ItemColumnSeparatorColor="Black" AutoFitMinFontSize="10" TableStyle="Wide">
                                </asp:Legend>
                                <asp:Legend Docking="Bottom" LegendStyle="Table" BackColor="AliceBlue" Name="Legend1"
                                    TextWrapThreshold="50">
                                </asp:Legend>
                            </Legends>
                            <Series>
                                <asp:Series ChartArea="FinArea" CustomProperties="DrawingStyle=Cylinder" Color="#9EDAEA"
                                    IsValueShownAsLabel="true" Legend="Legend1" Label="#SERIESNAME #VAL">
                                </asp:Series>
                                <asp:Series ChartArea="FinArea" CustomProperties="DrawingStyle=Cylinder" Color="#C2ECF6"
                                    IsValueShownAsLabel="false" Legend="Legend1" Label="#SERIESNAME  #VAL">
                                </asp:Series>
                                <asp:Series ChartArea="FinArea" CustomProperties="DrawingStyle=Cylinder" Color="#329CB8"
                                    IsValueShownAsLabel="false" Legend="Legend1" Label="#SERIESNAME  #VAL">
                                </asp:Series>
                                <asp:Series ChartArea="FinArea" CustomProperties="DrawingStyle=Cylinder" Color="#FFEAE8"
                                    Label="#SERIESNAME #VAL" IsValueShownAsLabel="false" Legend="Legend1">
                                </asp:Series>
                                <asp:Series ChartArea="FinArea" CustomProperties="DrawingStyle=Cylinder" Color="#EA5656"
                                    Label="#SERIESNAME #VAL" IsValueShownAsLabel="true" Legend="Legend1">
                                </asp:Series>
                            </Series>
                            <BorderSkin SkinStyle="Emboss" PageColor="Transparent"></BorderSkin>
                            <ChartAreas>
                                <asp:ChartArea Name="FinArea" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                                    BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent"
                                    BackGradientStyle="TopBottom">
                                    <AxisX Enabled="True" Interval="Auto">
                                    </AxisX>
                                    <AxisY2 IsLabelAutoFit="False" Enabled="False" Interval="Auto">
                                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                    </AxisY2>
                                    <AxisX2 Enabled="False">
                                    </AxisX2>
                                    <AxisY Interval="Auto" IsStartedFromZero="false" ArrowStyle="Triangle">
                                    </AxisY>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </td>
                </tr>
                <tr id="TrImage2" runat="server" style="height: 350px">
                    <td  id="tdHide" runat="server">
                        <table border="0" cellpadding="0" cellspacing="0" style="padding-left: 55px; padding-right: 70px;">
                            <tr>
                                <td align="center">
                                    <asp:Localize ID="locPara5" runat="server" Text="This section is not applicable to your business as you have assumed that there is
                                    no balance in the projected years on the average stock holdings days, average collection
                                    days and average payment days." meta:resourcekey="locPara5Resource1"></asp:Localize>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="ConditionTR" runat="server">
                    <td style="height: 1px">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr style="page-break-after: always">
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td align="left" style="height: 980;">
            <table border="0" cellpadding="0" cellspacing="0">
                <tr id="HideTr4" runat="server">
                    <td style="font-weight: bold;">
                        <u>
                            <asp:Label ID="lbl1YourMost" runat="server" Text="Your Most Recent Average Working Capital Days"
                                meta:resourcekey="lbl1YourMostResource1"></asp:Label>
                        </u>
                    </td>
                </tr>
                <tr id="HideTr5" runat="server">
                    <td>
                        <asp:Label ID="lblCapital1Days" runat="server" meta:resourcekey="lblCapital1DaysResource1"></asp:Label>
                    </td>
                </tr>
                <tr id="HideTr6" runat="server">
                    <td class="spacer">
                        &nbsp;
                    </td>
                </tr>
                <tr id="HideTr7" runat="server">
                    <td style="font-weight: bold;">
                        <u>
                            <asp:Label ID="lblProjected" runat="server" Text="Your Projected Working Capital Days"
                                meta:resourcekey="lblProjectedResource1"></asp:Label>
                        </u>
                    </td>
                </tr>
                <tr id="HideTr8" runat="server">
                    <td>
                        <asp:Label ID="lblCapital2Days" runat="server" meta:resourcekey="lblCapital2DaysResource1"></asp:Label>
                        <asp:Label ID="lblCapital3Days" runat="server" meta:resourcekey="lblCapital3DaysResource1"></asp:Label>
                    </td>
                </tr>
                <tr id="HideTr9" runat="server">
                    <td class="spacer">
                        &nbsp;
                    </td>
                </tr>
                <tr id="HideTr10" runat="server">
                    <td>
                        <table width="90%">
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblThefollowing" runat="server" Text="The following assumptions are noted:-"
                                        meta:resourcekey="lblThefollowingResource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="90%">
                                    <asp:Label ID="lblAverage1" runat="server" meta:resourcekey="lblAverage1Resource1"></asp:Label>
                                </td>
                                <td width="10%" align="center">
                                    <asp:Label ID="lbla" runat="server" meta:resourcekey="lblaResource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="80%">
                                    <asp:Label ID="lblAverage2" runat="server" meta:resourcekey="lblAverage2Resource1"></asp:Label>
                                </td>
                                <td width="10%" align="center">
                                    <asp:Label ID="lblb" runat="server" meta:resourcekey="lblbResource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="80%">
                                    <asp:Label ID="lblAverage3" runat="server" meta:resourcekey="lblAverage3Resource1"></asp:Label>
                                </td>
                                <td width="10%" align="center" class="tdbottom">
                                    <asp:Label ID="lblc" runat="server" meta:resourcekey="lblcResource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td width="80%">
                                    &nbsp;
                                </td>
                                <td width="10%" align="center" class="tdbottom">
                                    <asp:Label ID="lblABCTotal" runat="server" meta:resourcekey="lblABCTotalResource1"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="HideTr14" runat="server">
                    <td class="spacer">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold; font-size: 13px">
                        <asp:Label ID="lblWorkingCapitalRequirements" runat="server" Text="Working Capital Requirements"
                            meta:resourcekey="lblWorkingCapitalRequirementsResource1"></asp:Label>
                    </td>
                </tr>
                <tr id="HideTr13" runat="server">
                    <td class="spacer">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTheworkingcapital" runat="server" Text="The working capital requirements of your business are represented below:-"
                            meta:resourcekey="lblTheworkingcapitalResource1"></asp:Label>
                    </td>
                </tr>
                <tr id="HideTr12" runat="server">
                    <td class="spacer">
                        &nbsp;
                    </td>
                </tr>
                <tr id="HideTr11" runat="server">
                    <td align="center">
                        <table class="tblBorder" width="600px" cellpadding="0" cellspacing="0" style="font-size: 8.5pt;
                            font-family: Verdana, Arial, haettenschweiler; color: #000000;">
                            <tr style="background-color: #0099FF; color: White; font-weight: bold">
                                <td style="width: 200px" align="right">
                                </td>
                                <td  align="center">
                                    <asp:Label ID="lbl1FY" runat="server" Text="FY" meta:resourcekey="lbl1FYResource1"></asp:Label>
                                    <asp:Label ID="lblYearP1" runat="server" meta:resourcekey="lblYearP1Resource1"></asp:Label><br />
                                    <asp:Label ID="lbl1P" runat="server" Text="P" meta:resourcekey="lbl1PResource1"></asp:Label>
                                </td>
                                <td  align="center">
                                    <asp:Label ID="lbl2FY" runat="server" Text="FY" meta:resourcekey="lbl2FYResource1"></asp:Label>
                                    <asp:Label ID="lblYearP2" runat="server" meta:resourcekey="lblYearP2Resource1"></asp:Label><br />
                                    <asp:Label ID="lbl2P" runat="server" Text="P" meta:resourcekey="lbl2PResource1"></asp:Label>
                                </td>
                                <td  align="center">
                                    <asp:Label ID="lbl3FY" runat="server" Text="FY" meta:resourcekey="lbl3FYResource1"></asp:Label>
                                    <asp:Label ID="lblYearP3" runat="server" meta:resourcekey="lblYearP3Resource1"></asp:Label><br />
                                    <asp:Label ID="lbl3P" runat="server" Text="P" meta:resourcekey="lbl3PResource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" >
                                    <asp:Label ID="lblResources" runat="server" Text="Resources tied in Stocks" meta:resourcekey="lblResourcesResource1"></asp:Label>
                                </td>
                                <td style="width: 100px" align="right">
                                    <asp:Label ID="lblResourcesStocksP1" runat="server" meta:resourcekey="lblResourcesStocksP1Resource1"></asp:Label>
                                </td>
                                <td style="width: 100px" align="right">
                                    <asp:Label ID="lblResourcesStocksP2" runat="server" meta:resourcekey="lblResourcesStocksP2Resource1"></asp:Label>
                                </td>
                                <td style="width: 100px" align="right">
                                    <asp:Label ID="lblResourcesStocksP3" runat="server" meta:resourcekey="lblResourcesStocksP3Resource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" >
                                    <asp:Label ID="lblReceivables" runat="server" Text="Resources tied in Receivables"
                                        meta:resourcekey="lblReceivablesResource1"></asp:Label>
                                </td>
                                <td style="width: 100px" align="right">
                                    <asp:Label ID="lblResourcesReceivablesP1" runat="server" meta:resourcekey="lblResourcesReceivablesP1Resource1"></asp:Label>
                                </td>
                                <td style="width: 100px" align="right">
                                    <asp:Label ID="lblResourcesReceivablesP2" runat="server" meta:resourcekey="lblResourcesReceivablesP2Resource1"></asp:Label>
                                </td>
                                <td style="width: 100px" align="right">
                                    <asp:Label ID="lblResourcesReceivablesP3" runat="server" meta:resourcekey="lblResourcesReceivablesP3Resource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" >
                                    <asp:Label ID="lblFundingbySuppliers" runat="server" Text="Funding by Suppliers"
                                        meta:resourcekey="lblFundingbySuppliersResource1"></asp:Label>
                                </td>
                                <td style="width: 100px" align="right">
                                    <asp:Label ID="lblFundingP1" runat="server" meta:resourcekey="lblFundingP1Resource1"></asp:Label>
                                </td>
                                <td style="width: 100px" align="right">
                                    <asp:Label ID="lblFundingP2" runat="server" meta:resourcekey="lblFundingP2Resource1"></asp:Label>
                                </td>
                                <td style="width: 100px" align="right">
                                    <asp:Label ID="lblFundingP3" runat="server" meta:resourcekey="lblFundingP3Resource1"></asp:Label>
                                </td>
                            </tr>
                            <tr style="background-color: #ccecff; font-weight: bold;">
                                <td align="left" style="background-color: #ccecff; width: 300px">
                                    <asp:Label ID="lblbusiness" runat="server" Text="The Working Capital Needs of your business"
                                        meta:resourcekey="lblbusinessResource1"></asp:Label>
                                </td>
                                <td style="width: 100px" align="right">
                                    <asp:Label ID="lblWorkingCapitalP1" runat="server" meta:resourcekey="lblWorkingCapitalP1Resource1"></asp:Label>
                                </td>
                                <td style="width: 100px" align="right">
                                    <asp:Label ID="lblWorkingCapitalP2" runat="server" meta:resourcekey="lblWorkingCapitalP2Resource1"></asp:Label>
                                </td>
                                <td style="width: 100px" align="right">
                                    <asp:Label ID="lblWorkingCapitalP3" runat="server" meta:resourcekey="lblWorkingCapitalP3Resource1"></asp:Label>
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
                <tr>
                    <td>
                        <asp:Localize ID="locPara6" runat="server" Text="If your working capital needs is &lt;b&gt;&lt;u&gt;negative&lt;/u&gt;&lt;/b&gt; amount, it means that, on
            the average, your trade is self-financing and will be able to generate sufficient
            cash from the trade before payment to your suppliers." meta:resourcekey="locPara6Resource1"></asp:Localize>
                    </td>
                </tr>
                <tr>
                    <td class="spacer">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Localize ID="locPara7" runat="server" Text="Conversely, if the working capital needs is &lt;b&gt;&lt;u&gt;positive&lt;/u&gt;&lt;/b&gt; amount, it means
            that, on the average, your business need more trade and alternative sources of financing.
            However, if there is sufficient capital base or you have built up strong cash reserves,
            you may not need external financing." meta:resourcekey="locPara7Resource1"></asp:Localize>
                    </td>
                </tr>
                <tr>
                    <td class="spacer">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
