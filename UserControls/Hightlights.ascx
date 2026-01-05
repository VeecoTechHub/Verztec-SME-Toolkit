<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Hightlights.ascx.cs" Inherits="UserControls_Hightlights" %>
<style type="text/css">
    .style1
    {
        height: 19px;
    }
    .h1
    {
        font: bold 16px Arial, Helvetica, sans-serif;
        color: #FFF;
        background-color: #bd0b7d;
        padding: 5px 10px;
        margin: 0px;
    }
</style>
<table width="90%" border="0" align="center" cellpadding="0" cellspacing="0" style="padding-left: 25px;">
    <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="highlights" valign="top">
            <asp:Label ID="lblKeyFinancialHighlights" runat="server" Text="Key Financial Highlights"
                meta:resourcekey="lblKeyFinancialHighlightsResource1"></asp:Label>
            <%--<asp:Image ID="imgHeader" runat="server" Width="680" ImageUrl="~/images/highlightsbar.png" />--%>
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
            The following graph shows the three primary financial indicators of your business:
            Sales, Gross Profit and Earnings (specifically EBITDA) projections for the next
            three years." meta:resourcekey="locPara1Resource1"></asp:Localize>
        </td>
    </tr>
    <%-- <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>--%>
    <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td align="left" valign="top" class="style1">
            <h4>
                <asp:Label ID="lblAFinancialHighlights" runat="server" Text="A) Financial Highlights"
                    meta:resourcekey="lblAFinancialHighlightsResource1"></asp:Label>
            </h4>
        </td>
    </tr>
    <tr>
        <td valign="top" align="center">
            <asp:Chart ID="FinancialChart" runat="server" BackColor="211, 223, 240" Width="600px"
                Height="390px" BorderColor="#1A3B69" Palette="SeaGreen" BorderDashStyle="Solid"
                BackGradientStyle="TopBottom" BackSecondaryColor="White" BorderWidth="2px" ImageLocation="~\TempImages\ChartPic_#SEQ(300,3)"
                ImageStorageMode="UseImageLocation" SkinID="100" BorderlineColor="Wheat" BorderlineDashStyle="DashDot"
                BackImageTransparentColor="Transparent" meta:resourcekey="FinancialChartResource1">
                <Legends>
                    <asp:Legend Docking="Bottom" BackColor="AliceBlue" ItemColumnSpacing="500" LegendStyle="Column"
                        Name="Legend2" Enabled="true" BorderWidth="1" BorderColor="Black" ItemColumnSeparator="Line"
                        ItemColumnSeparatorColor="Black" AutoFitMinFontSize="10" TableStyle="Wide">
                    </asp:Legend>
                    <asp:Legend Docking="Bottom" LegendStyle="Table" BackColor="AliceBlue" Name="Legend1"
                        TextWrapThreshold="50">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                        ForeColor="26, 59, 105">
                    </asp:Title>
                </Titles>
                <Series>
                    <asp:Series ChartArea="FinArea" Color="#37ACCB" IsValueShownAsLabel="true" CustomProperties="DrawingStyle=Cylinder"
                        Legend="Legend1">
                    </asp:Series>
                    <asp:Series ChartArea="FinArea" Color="#7756A0" IsValueShownAsLabel="true" CustomProperties="DrawingStyle=Cylinder"
                        Legend="Legend1">
                    </asp:Series>
                    <asp:Series ChartArea="FinArea" IsValueShownAsLabel="true" Color="#96BC47" CustomProperties="DrawingStyle=Cylinder"
                        Legend="Legend1">
                    </asp:Series>
                </Series>
                <BorderSkin SkinStyle="Emboss" PageColor="Transparent"></BorderSkin>
                <ChartAreas>
                    <asp:ChartArea Name="FinArea" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                        BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent"
                        BackGradientStyle="TopBottom">
                        <AxisX Enabled="True" Interval="Auto" ArrowStyle="Triangle">
                        </AxisX>
                        <AxisY2 IsLabelAutoFit="False" Enabled="False" Interval="Auto" Title="Percentage">
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                        </AxisY2>
                        <AxisX2 Enabled="False">
                        </AxisX2>
                        <AxisY IsStartedFromZero="false" IsLabelAutoFit="true" ArrowStyle="Triangle">
                            <LabelStyle Format="{0,0}" />
                        </AxisY>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <asp:Label ID="lblChartTitle" runat="server" Visible="False" meta:resourcekey="lblChartTitleResource1"></asp:Label>
            <asp:Label ID="lblColumn1" runat="server" Visible="False" meta:resourcekey="lblColumn1Resource1"></asp:Label>
            <asp:Label ID="lblColumn2" runat="server" Visible="False" meta:resourcekey="lblColumn2Resource1"></asp:Label>
            <asp:Label ID="lblColumn3" runat="server" Visible="False" meta:resourcekey="lblColumn3Resource1"></asp:Label>
            <asp:Label ID="lblAxisTitle1" runat="server" Visible="False" meta:resourcekey="lblAxisTitleResource1"></asp:Label>
            <asp:Label ID="lblAxisTitle2" runat="server" Visible="False" meta:resourcekey="lblAxisTitle2Resource1"></asp:Label>
        </td>
    </tr>
    <tr style="display: none;">
        <td align="center">
            <table class="tblBorder" width="600px" cellpadding="0" cellspacing="0" style="font-size: 8.5pt;
                font-family: Verdana, Arial, haettenschweiler; color: #000000;">
                <tr style="background-color: #0099FF; color: White; font-weight: bold">
                    <td>
                    </td>
                    <td style="width: 75px" align="right">
                        FY<asp:Label ID="lblYearC" runat="server" meta:resourcekey="lblYearCResource1"></asp:Label>A
                    </td>
                    <td style="width: 75px" align="right">
                        FY<asp:Label ID="lblYearP1" runat="server" meta:resourcekey="lblYearP1Resource1"></asp:Label>P
                    </td>
                    <td style="width: 75px" align="right">
                        FY<asp:Label ID="lblYearP2" runat="server" meta:resourcekey="lblYearP2Resource1"></asp:Label>P
                    </td>
                    <td style="width: 75px" align="right">
                        FY<asp:Label ID="lblYearP3" runat="server" meta:resourcekey="lblYearP3Resource1"></asp:Label>P
                    </td>
                </tr>
                <tr class="FontStyle">
                    <td align="left" style="width: 300px">
                        <asp:Label ID="lblEBITDA" runat="server" meta:resourcekey="lblEBITDAResource1"></asp:Label>(%)
                    </td>
                    <td style="width: 75px" align="right">
                        <asp:Label ID="lblEBITDAC" runat="server" meta:resourcekey="lblEBITDACResource1"></asp:Label>%
                    </td>
                    <td style="width: 75px" align="right">
                        <asp:Label ID="lblEBITDAP1" runat="server" meta:resourcekey="lblEBITDAP1Resource1"></asp:Label>%
                    </td>
                    <td style="width: 75px" align="right">
                        <asp:Label ID="lblEBITDAP2" runat="server" meta:resourcekey="lblEBITDAP2Resource1"></asp:Label>%
                    </td>
                    <td style="width: 75px" align="right">
                        <asp:Label ID="lblEBITDAP3" runat="server" meta:resourcekey="lblEBITDAP3Resource1"></asp:Label>%
                    </td>
                </tr>
                <tr class="FontStyle">
                    <td align="left" style="width: 300px">
                        <asp:Label ID="lblEBITDAPercentage" runat="server" meta:resourcekey="lblEBITDAPercentageResource1"></asp:Label>(%)
                    </td>
                    <td style="width: 75px" align="right">
                        <asp:Label ID="lblEBITDAPercentageC" runat="server" meta:resourcekey="lblEBITDAPercentageCResource1"></asp:Label>%
                    </td>
                    <td style="width: 75px" align="right">
                        <asp:Label ID="lblEBITDAPercentageP1" runat="server" meta:resourcekey="lblEBITDAPercentageP1Resource1"></asp:Label>%
                    </td>
                    <td style="width: 75px" align="right">
                        <asp:Label ID="lblEBITDAPercentageP2" runat="server" meta:resourcekey="lblEBITDAPercentageP2Resource1"></asp:Label>%
                    </td>
                    <td style="width: 75px" align="right">
                        <asp:Label ID="lblEBITDAPercentageP3" runat="server" meta:resourcekey="lblEBITDAPercentageP3Resource1"></asp:Label>%
                    </td>
                </tr>
                <tr class="FontStyle">
                    <td align="left" style="width: 300px">
                        <asp:Label ID="lblGrossProfit" runat="server" meta:resourcekey="lblGrossProfitResource1"></asp:Label>
                    </td>
                    <td style="width: 75px" align="right">
                        <asp:Label ID="lblGrossProfitC" runat="server" meta:resourcekey="lblGrossProfitCResource1"></asp:Label>
                    </td>
                    <td style="width: 75px" align="right">
                        <asp:Label ID="lblGrossProfitP1" runat="server" meta:resourcekey="lblGrossProfitP1Resource1"></asp:Label>
                    </td>
                    <td style="width: 75px" align="right">
                        <asp:Label ID="lblGrossProfitP2" runat="server" meta:resourcekey="lblGrossProfitP2Resource1"></asp:Label>
                    </td>
                    <td style="width: 75px" align="right">
                        <asp:Label ID="lblGrossProfitP3" runat="server" meta:resourcekey="lblGrossProfitP3Resource1"></asp:Label>
                    </td>
                </tr>
                <tr class="FontStyle">
                    <td align="left" style="width: 300px">
                        <asp:Label ID="lblGrossProfitPercentage" runat="server" meta:resourcekey="lblGrossProfitPercentageResource1"></asp:Label>
                    </td>
                    <td style="width: 75px" align="right">
                        <asp:Label ID="lblGrossProfitPercentageC" runat="server" meta:resourcekey="lblGrossProfitPercentageCResource1"></asp:Label>
                    </td>
                    <td style="width: 75px" align="right">
                        <asp:Label ID="lblGrossProfitPercentageP1" runat="server" meta:resourcekey="lblGrossProfitPercentageP1Resource1"></asp:Label>
                    </td>
                    <td style="width: 75px" align="right">
                        <asp:Label ID="lblGrossProfitPercentageP2" runat="server" meta:resourcekey="lblGrossProfitPercentageP2Resource1"></asp:Label>
                    </td>
                    <td style="width: 75px" align="right">
                        <asp:Label ID="lblGrossProfitPercentageP3" runat="server" meta:resourcekey="lblGrossProfitPercentageP3Resource1"></asp:Label>
                    </td>
                </tr>
                <tr class="FontStyle">
                    <td align="left" style="width: 300px">
                        <asp:Label ID="lblSales" runat="server" meta:resourcekey="lblSalesResource1"></asp:Label>
                    </td>
                    <td style="width: 75px" align="right">
                        <asp:Label ID="lblSalesC" runat="server" meta:resourcekey="lblSalesCResource1"></asp:Label>
                    </td>
                    <td style="width: 75px" align="right">
                        <asp:Label ID="lblSalesP1" runat="server" meta:resourcekey="lblSalesP1Resource1"></asp:Label>
                    </td>
                    <td style="width: 75px" align="right">
                        <asp:Label ID="lblSalesP2" runat="server" meta:resourcekey="lblSalesP2Resource1"></asp:Label>
                    </td>
                    <td style="width: 75px" align="right">
                        <asp:Label ID="lblSalesP3" runat="server" meta:resourcekey="lblSalesP3Resource1"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <%--<tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>--%>
    <tr>
        <td class="Header">
            <asp:Label ID="lbl1Sales" runat="server" Text="1. Sales" meta:resourcekey="lbl1SalesResource1"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="FontStyle">
            <asp:Localize ID="locPara2" runat="server" Text="
            Sales, also commonly known as Revenue, Turnover, and sometimes incorrectly known
            as Income, is derived from the sale of goods and/or provision of services. Sales
            is recorded when it is confirmed that the business activity will lead to the receipt
            of payment from the customer. Sales should not ever be confused with profit; a business
            may make sales, but not necessarily profitable." meta:resourcekey="locPara2Resource1"></asp:Localize>
        </td>
    </tr>
    <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="Header">
            <asp:Label ID="lbl1GrossProfit" runat="server" Text="2. Gross Profit" meta:resourcekey="lbl1GrossProfitResource1"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="FontStyle">
            <asp:Localize ID="locPara3" runat="server" Text="
            Gross Profit measures the amount that is left after deducting the direct costs associated
            to the sales. For sale of goods, the direct costs may be cost of goods, freight
            charges, packing costs. For rendering of services, the direct costs may be manpower
            and/or subcontract costs. This represents the net contribution from the sale before
            deducting the operating expenses of the business." meta:resourcekey="locPara3Resource1"></asp:Localize>
        </td>
    </tr>
    <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:GridView ID="gvGrossProfit" runat="server" CssClass="tblBorder" Width="600px"
                GridLines="None" AutoGenerateColumns="False" OnRowDataBound="gvGrossProfit_RowDataBound"
                meta:resourcekey="gvGrossProfitResource1" EnableModelValidation="True">
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="right" meta:resourcekey="TemplateFieldResource1">
                        <ItemTemplate>
                            <asp:Label ID="lblFsMappingName" runat="server" Text='<%# Eval("FsMappingName") %>'
                                meta:resourcekey="lblFsMappingNameResource1"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                        <ItemStyle HorizontalAlign="left" CssClass="gvFont" />
                    </asp:TemplateField>
                    <asp:TemplateField meta:resourcekey="TemplateFieldResource2">
                        <ItemTemplate>
                            <asp:Label ID="lblC_Percent" runat="server" Text='<%# Eval("C_Percent") %>' meta:resourcekey="lblC_PercentResource1"></asp:Label>%
                        </ItemTemplate>                       
                        <ItemStyle HorizontalAlign="center" CssClass="gvFont" />
                    </asp:TemplateField>
                    <asp:TemplateField meta:resourcekey="TemplateFieldResource3">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P1_Percent" runat="server" Text='<%# Eval("P1_Percent") %>' meta:resourcekey="lbl_P1_PercentResource1"></asp:Label>%
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="center" CssClass="gvFont" />
                    </asp:TemplateField>
                    <asp:TemplateField meta:resourcekey="TemplateFieldResource4">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P2_Percent" runat="server" Text='<%# Eval("P2_Percent") %>' meta:resourcekey="lbl_P2_PercentResource1"></asp:Label>%</ItemTemplate>
                            <ItemStyle HorizontalAlign="center" CssClass="gvFont" />
                    </asp:TemplateField>
                    <asp:TemplateField meta:resourcekey="TemplateFieldResource5">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P3_Percent" runat="server" Text='<%# Eval("P3_Percent") %>' meta:resourcekey="lbl_P3_PercentResource1"></asp:Label>%</ItemTemplate>
                            <ItemStyle HorizontalAlign="center" CssClass="gvFont" />
                    </asp:TemplateField>
                </Columns>
                <RowStyle VerticalAlign="NotSet" />
                <HeaderStyle BackColor="#0099FF" ForeColor="White" Height="5" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="FontStyle">
            <asp:Localize ID="locPara4" runat="server" Text="
            Gross profit margin is calculated by dividing gross profit by sales. It represents
            how much every dollar of sales is left after deducting the costs of sales. The higher
            the gross profit margin, the higher the incremental contribution from every dollar
            increase in sales. This is a key indicator that every business should be focusing
            on to manage the performance of the business." meta:resourcekey="locPara4Resource1"></asp:Localize>
        </td>
    </tr>
    <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="Header">
            <asp:Label ID="lbl1EBITDA" runat="server" Text="3. EBITDA (Earnings before interest, tax, depreciation and amortisation)"
                meta:resourcekey="lbl1EBITDAResource1"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="FontStyle">
            <asp:Localize ID="locPara5" runat="server" Text="
            EBITDA is a good measure of the operating cash flow that the business is able to
            generate. Generally, if a business is unable to generate positive EBITDA, the business
            viability may be at stake. It means that the business is unable to generate sufficient
            operating cash to cover interests and tax payments. Unless the business has strong
            cash backing, a business cannot sustain with negative EBITDA." meta:resourcekey="locPara5Resource1"></asp:Localize>
        </td>
    </tr>
    <tr style="page-break-before: always;" id="idSegment" runat="server">
        <td class="spacer" id="trSpace" runat="server">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="FontStyle" id="trfollowinggraph" runat="server">
            <asp:Localize ID="locPara6" runat="server" Text="
            The following graph shows the sales and Gross Profit projections of the different
            activities of your business for the next three years." meta:resourcekey="locPara6Resource1"></asp:Localize>
        </td>
    </tr>
    <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr id="trSegmentAnalysis" runat="server">
        <td>
            <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="left" valign="top">
                        <h4>
                            <asp:Label ID="lblSegmentAnalysis" runat="server" Text="B) Segment Analysis" meta:resourcekey="lblSegmentAnalysisResource1"></asp:Label>
                        </h4>
                    </td>
                </tr>
                <tr>
                    <td class="spacer">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td valign="top" align="center">
                        <asp:Chart ID="chartSegmentAnalysis" runat="server" BackColor="211, 223, 240" Width="600px"
                            Height="400px" BorderColor="#1A3B69" Palette="SeaGreen" BorderDashStyle="Solid"
                            ImageStorageMode="UseImageLocation" BackGradientStyle="TopBottom" BackSecondaryColor="White"
                            BorderWidth="2px" ImageLocation="~\TempImages\ChartPic_#SEQ(300,3)" SkinID="100"
                            BorderlineColor="Wheat" BorderlineDashStyle="DashDot" BackImageTransparentColor="Transparent"
                            meta:resourcekey="chartSegmentAnalysisResource1">
                            <Legends>
                                <asp:Legend Docking="Bottom" BackColor="AliceBlue" ItemColumnSpacing="500" LegendStyle="Column"
                                    Name="Legend2" Enabled="true" BorderWidth="1" BorderColor="Black" ItemColumnSeparator="Line"
                                    ItemColumnSeparatorColor="Black" AutoFitMinFontSize="10" TableStyle="Wide">
                                </asp:Legend>
                                <asp:Legend Docking="Bottom" LegendStyle="Table" BackColor="AliceBlue" Name="Legend1"
                                    TextWrapThreshold="50">
                                </asp:Legend>
                            </Legends>
                            <Titles>
                                <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                                    Text="Sales & Gross Profit Analysis by Activities" ForeColor="26, 59, 105">
                                </asp:Title>
                            </Titles>
                            <Series>
                                <asp:Series ChartArea="FinArea" Color="#37ACCB" IsValueShownAsLabel="true" CustomProperties="DrawingStyle=Cylinder"
                                    Legend="Legend1">
                                </asp:Series>
                                <asp:Series ChartArea="FinArea" Color="#7756A0" IsValueShownAsLabel="true" CustomProperties="DrawingStyle=Cylinder"
                                    Legend="Legend1">
                                </asp:Series>
                            </Series>
                            <BorderSkin SkinStyle="Emboss" PageColor="Transparent"></BorderSkin>
                            <ChartAreas>
                                <asp:ChartArea Name="FinArea" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                                    BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent"
                                    BackGradientStyle="TopBottom">
                                    <AxisX Enabled="True" Interval="Auto" ArrowStyle="Triangle">
                                    </AxisX>
                                    <AxisY2 IsLabelAutoFit="False" Enabled="False" Interval="Auto" Title="Percentage">
                                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                    </AxisY2>
                                    <AxisX2 Enabled="False">
                                    </AxisX2>
                                    <AxisY IsStartedFromZero="false" IsLabelAutoFit="true" ArrowStyle="Triangle">
                                        <LabelStyle Format="{0,0}" />
                                    </AxisY>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </td>
                </tr>
                <tr>
                    <td class="spacer">
                        &nbsp;
                        <asp:Label ID="lblChartTitle1" runat="server" Visible="False" meta:resourcekey="lblChartTitle1Resource1"></asp:Label>
                        <asp:Label ID="lblColumn4" runat="server" Visible="False" meta:resourcekey="lblColumn4Resource1"></asp:Label>
                        <asp:Label ID="lblColumn5" runat="server" Visible="False" meta:resourcekey="lblColumn5Resource1"></asp:Label>
                        <asp:Label ID="lblfy" runat="server" Visible="False" meta:resourcekey="lblfyResource1"></asp:Label>
                        <asp:Label ID="lblp" runat="server" Visible="False" meta:resourcekey="lblpResource1"></asp:Label>
                        <asp:Label ID="lblA" runat="server" Visible="False" meta:resourcekey="lblpResource1"></asp:Label>
                        <asp:Label ID="lblFake1" runat="server" Visible="False" 
                            meta:resourcekey="lblChartTitle1Resource1"></asp:Label>
                        <asp:Label ID="lblFake2" runat="server" Visible="False" 
                            meta:resourcekey="lblFake2Resource1"></asp:Label>
                          

                      
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:GridView ID="gvSalesProfitAnalysis" runat="server" CssClass="tblBorder" Width="600px"
                            GridLines="None" AutoGenerateColumns="False" OnRowDataBound="gvSalesProfitAnalysis_RowDataBound"
                            OnRowCreated="gvSalesProfitAnalysis_RowCreated" meta:resourcekey="gvSalesProfitAnalysisResource1"
                            EnableModelValidation="True">
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" meta:resourcekey="TemplateFieldResource6">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFsMappingName" runat="server" Text='<%# Eval("FsMappingName") %>'
                                            meta:resourcekey="lblFsMappingNameResource2"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" CssClass="gvFont" width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="center" meta:resourcekey="TemplateFieldResource7">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_P1_Value" runat="server" Text='<%# Eval("P1_Value") %>' meta:resourcekey="lbl_P1_ValueResource1"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right" CssClass="gvFont" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="center" meta:resourcekey="TemplateFieldResource8">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_P1_Percent" runat="server" Text='<%# Eval("P1_Percent") %>' meta:resourcekey="lbl_P1_PercentResource2"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right" CssClass="gvFont" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="center" meta:resourcekey="TemplateFieldResource9">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_P2_Value" runat="server" Text='<%# Eval("P2_Value") %>' meta:resourcekey="lbl_P2_ValueResource1"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right" CssClass="gvFont" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="center" meta:resourcekey="TemplateFieldResource10">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_P2_Percent" runat="server" Text='<%# Eval("P2_Percent") %>' meta:resourcekey="lbl_P2_PercentResource2"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right" CssClass="gvFont" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="center" meta:resourcekey="TemplateFieldResource11">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_P3_Value" runat="server" Text='<%# Eval("P3_Value") %>' meta:resourcekey="lbl_P3_ValueResource1"></asp:Label></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right" CssClass="gvFont" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="center" meta:resourcekey="TemplateFieldResource12">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_P3_Percent" runat="server" Text='<%# Eval("P3_Percent") %>' meta:resourcekey="lbl_P3_PercentResource2"></asp:Label></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right" CssClass="gvFont" />
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle VerticalAlign="NotSet" />
                            <HeaderStyle BackColor="#0099FF" ForeColor="White" Height="5" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="spacer">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:GridView ID="gvGPAnalysis" runat="server" CssClass="tblBorder" Width="600px"
                            GridLines="None" AutoGenerateColumns="False" OnRowDataBound="gvGPAnalysis_RowDataBound"
                            meta:resourcekey="gvGPAnalysisResource1" EnableModelValidation="True">
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" meta:resourcekey="TemplateFieldResource13">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFsMappingName" runat="server" Text='<%# Eval("FsMappingName") %>'
                                            meta:resourcekey="lblFsMappingNameResource3"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left" CssClass="gvFont" width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="right" meta:resourcekey="TemplateFieldResource14">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_P1_Value" runat="server" Text='<%# Eval("P1_Value") %>' meta:resourcekey="lbl_P1_ValueResource2"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="right" CssClass="gvFont" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="right" meta:resourcekey="TemplateFieldResource15">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_P1_Percent" runat="server" Text='<%# Eval("P1_Percent") %>' meta:resourcekey="lbl_P1_PercentResource3"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="right" CssClass="gvFont" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="right" meta:resourcekey="TemplateFieldResource16">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_P2_Value" runat="server" Text='<%# Eval("P2_Value") %>' meta:resourcekey="lbl_P2_ValueResource2"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="right" CssClass="gvFont" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="right" meta:resourcekey="TemplateFieldResource17">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_P2_Percent" runat="server" Text='<%# Eval("P2_Percent") %>' meta:resourcekey="lbl_P2_PercentResource3"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="right" CssClass="gvFont" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="right" meta:resourcekey="TemplateFieldResource18">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_P3_Value" runat="server" Text='<%# Eval("P3_Value") %>' meta:resourcekey="lbl_P3_ValueResource2"></asp:Label></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="right" CssClass="gvFont" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="right" meta:resourcekey="TemplateFieldResource19">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_P3_Percent" runat="server" Text='<%# Eval("P3_Percent") %>' meta:resourcekey="lbl_P3_PercentResource3"></asp:Label></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="right" CssClass="gvFont" />
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle VerticalAlign="NotSet" />
                            <HeaderStyle BackColor="#0099FF" ForeColor="White" Height="5" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="spacer">
                        &nbsp;
                    </td>
                </tr>
                <tr style="display: none;">
                    <td align="center">
                        <table class="tblBorder" width="600px" cellpadding="0" cellspacing="0" style="font-size: 8.5pt;
                            font-family: Verdana, Arial, haettenschweiler; color: #000000;">
                            <tr style="background-color: #0099FF; color: White; font-weight: bold">
                                <td align="right">
                                </td>
                                <td align="right">
                                    FY<asp:Label ID="lblYear1P1" runat="server" meta:resourcekey="lblYear1P1Resource1"></asp:Label>P
                                </td>
                                <td align="right">
                                    FY<asp:Label ID="lblYear1P2" runat="server" meta:resourcekey="lblYear1P2Resource1"></asp:Label>P
                                </td>
                                <td align="right">
                                    FY<asp:Label ID="lblYear1P3" runat="server" meta:resourcekey="lblYear1P3Resource1"></asp:Label>P
                                </td>
                            </tr>
                            <tr class="FontStyle">
                                <td align="left">
                                    <asp:Label ID="lblSales1Name" runat="server" meta:resourcekey="lblSales1NameResource1"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblSales1P1" runat="server" meta:resourcekey="lblSales1P1Resource1"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblSales1P2" runat="server" meta:resourcekey="lblSales1P2Resource1"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblSales1P3" runat="server" meta:resourcekey="lblSales1P3Resource1"></asp:Label>
                                </td>
                            </tr>
                            <tr class="FontStyle">
                                <td align="left">
                                    <asp:Label ID="lblgp" runat="server" meta:resourcekey="lblgpResource1"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblgpP1" runat="server" meta:resourcekey="lblgpP1Resource1"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblgpP2" runat="server" meta:resourcekey="lblgpP2Resource1"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblgpP3" runat="server" meta:resourcekey="lblgpP3Resource1"></asp:Label>
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
                    <td class="FontStyle">
                        <asp:Localize ID="locPara7" runat="server" Text="
                        It is important to know the different dimensions of your business. It may be painful
                        to track but if you have information on your sales and gross profit contribution
                        derived from different activities, type of products and even the industries of your
                        customers, you would be able to make informed decisions and look at how to direct
                        your limited resources to focus on what matter most to your business." meta:resourcekey="locPara7Resource1"></asp:Localize>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
