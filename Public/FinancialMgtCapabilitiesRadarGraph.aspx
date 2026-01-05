<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FinancialMgtCapabilitiesRadarGraph.aspx.cs"
    Inherits="FinancialMgtCapabilitiesRadarGraph" MasterPageFile="~/MasterPages/MainMaster.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxcontroltoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .border_btm
        {
            border-bottom: #b2b2b2 solid 1px;
        }
        .style3
        {
            width: 9px;
        }
    </style>
    <table width="874">
        <tr>
            <td align="left" height="33" valign="middle" class="blue_Big_title">
                <div>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Financial Management Capabilities
                </div>
            </td>
        </tr>
        <tr>
            <td height="5px">
            </td>
        </tr>
        <tr>
            <td align="left">
                <table class="timesheet_bg" width="874">
                   
                    <tr>
                        <td height="5px">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle">
                     
                        </td>
                    </tr>
                   
                    <tr>
                        <td align="center" valign="middle">
                            <asp:Chart ID="FinancialChart" runat="server" BackColor="#D3DFF0" Width="550px" Height="400px"
                                BorderColor="26, 59, 105" Palette="SeaGreen" BorderDashStyle="Solid" BackGradientStyle="TopBottom"
                                BackSecondaryColor="White" BorderWidth="2" ImageType="Png" ImageLocation="~\TempImages\ChartPic_#SEQ(300,3)"
                                SkinID="100">
                                <Titles>
                                    <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                                        Text="Your Score" ForeColor="26, 59, 105">
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
                                    <asp:Series IsVisibleInLegend="false" ChartArea="FinArea" Color="#715197" Name="Yours"
                                        IsValueShownAsLabel="true" Legend="Legend1" CustomProperties="DrawingStyle=Cylinder">
                                    </asp:Series>
                                    <asp:Series ChartArea="FinArea" IsVisibleInLegend="false" Color="#8CAF42" Name="High"
                                        IsValueShownAsLabel="false" Legend="Legend1" CustomProperties="DrawingStyle=Cylinder">
                                    </asp:Series>
                                </Series>
                                <BorderSkin SkinStyle="Emboss" PageColor="Transparent"></BorderSkin>
                                <ChartAreas>
                                    <asp:ChartArea Name="FinArea" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                                        BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent"
                                        BackGradientStyle="TopBottom">
                                        <AxisY Enabled="False">
                                        </AxisY>
                                        <AxisX Enabled="True" Interval="Auto">
                                        </AxisX>
                                        <%--<AxisY2 IsLabelAutoFit="False" Enabled="True" Interval="Auto" Title="Percentage">
                                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                        </AxisY2>
                                        <AxisX2 Enabled="False">
                                        </AxisX2>--%>
                                        <%-- <AxisY IsStartedFromZero="false" Title="Thousands" ArrowStyle="Triangle">
                                        </AxisY>--%>
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 120px;">
                            Disclaimer : The above rating is for reference only and should not be relied on
                            for management
                            <br />
                            decision making prior to seeking proper professional advices.
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 110px;">
                            <table width="90%" style="border-width: 2px; border-color: Black; border-style: solid;">
                                <tr>
                                    <td width="20%">
                                        Scoring Reference
                                    </td>
                                    <td width="2%">
                                        =
                                    </td>
                                    <td width="6%">
                                        0%
                                    </td>
                                    <td width="72%">
                                        Not Applicable to your Business
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td class="style3">
                                        <
                                    </td>
                                    <td>
                                        50%
                                    </td>
                                    <td>
                                        Improvement needed
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td class="style3">
                                        =
                                    </td>
                                    <td>
                                        50%
                                    </td>
                                    <td>
                                        Average
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td class="style3">
                                        >
                                    </td>
                                    <td>
                                        50%
                                    </td>
                                    <td>
                                        Good</td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td class="style3">
                                        =
                                    </td>
                                    <td>
                                        100%
                                    </td>
                                    <td>
                                        Excellent
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 60px;" align="left">
                <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/images/back.png" OnClick="btnBack_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
