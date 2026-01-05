<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RadarGraph.aspx.cs" Inherits="RadarGraph"
    MasterPageFile="~/MasterPages/MainMaster.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxcontroltoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .border_btm
        {
            border-bottom: #b2b2b2 solid 1px;
        }
        .style3
        {
            width: 690px;
        }
        .style4
        {
            font-family: "Microsoft Sans Serif";
        }
        .style5
        {
            width: 2%;
        }
    </style>
    <table width="874">
        <tr>
            <td align="left" height="33" valign="middle" class="blue_Big_title">
                <div>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Business Health Profiling
                </div>
            </td>
        </tr>
        <tr>
            <td height="5px" class="style3">
            </td>
        </tr>
        <tr>
            <td class="style3">
                <table class="timesheet_bg" width="874">
                   
                    <tr>
                        <td height="5px">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle">
                           
                            <asp:Chart ID="Chart1" runat="server" Width="550px" Height="500px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)"
                                ImageType="Png" Palette="SeaGreen" BackColor="#D3DFF0" BorderColor="26, 59, 105"
                                BackSecondaryColor="White" BorderDashStyle="Solid" BackGradientStyle="TopBottom"
                                BorderWidth="2">
                                <Titles>
                                    <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                                        Text="Business Health Profiling" ForeColor="26, 59, 105">
                                    </asp:Title>
                                </Titles>
                                <Legends>
                                    <asp:Legend IsTextAutoFit="true" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"
                                        Alignment="Far">
                                        <Position Y="74.08253" Height="14.23021" Width="19.34047" X="74.73474"></Position>
                                    </asp:Legend>
                                </Legends>
                                <BorderSkin SkinStyle="Emboss" PageColor="Transparent"></BorderSkin>
                                <Series>
                                    <asp:Series MarkerBorderColor="64, 64, 64" MarkerSize="4" Name="Series1" ChartType="Radar"
                                        BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" ShadowOffset="1" IsVisibleInLegend="false">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                                        BackColor="OldLace" ShadowColor="Transparent" >
                                        <Area3DStyle Rotation="4" Perspective="4" Inclination="15" IsRightAngleAxes="False"
                                            WallWidth="0" IsClustered="true" />
                                        <Position Y="15" Height="78" Width="88" X="5"></Position>
                                        <AxisY IsInterlaced="false" IsMarksNextToAxis="false" LineColor="64, 64, 64, 64">
                                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                            <MajorGrid LineColor="64, 64, 64, 64" />
                                            <MajorTickMark Size="0.6" />
                                        </AxisY>
                                        <AxisX LineColor="64, 64, 64, 64">
                                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                            <MajorGrid LineColor="64, 64, 64, 64" />
                                        </AxisX>
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
                                    <asp:Series ChartArea="FinArea" Color="#715197" Name="Yours" IsValueShownAsLabel="true"
                                        Legend="Legend1" CustomProperties="DrawingStyle=Cylinder" IsVisibleInLegend="false">
                                    </asp:Series>
                                    <asp:Series ChartArea="FinArea" Color="#8CAF42" Name="High" IsValueShownAsLabel="false"
                                        Legend="Legend1" CustomProperties="DrawingStyle=Cylinder" IsVisibleInLegend="false">
                                    </asp:Series>
                                </Series>
                                <BorderSkin SkinStyle="Emboss" PageColor="Transparent"></BorderSkin>
                                <ChartAreas>
                                    <asp:ChartArea Name="FinArea" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                                        BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent"
                                        BackGradientStyle="TopBottom">
                                       <%-- <AxisX Enabled="True" Interval="Auto" >
                                        </AxisX>--%>
                                        <%-- <AxisY2 IsLabelAutoFit="False" Enabled="True" Interval="Auto" Title="Percentage">
                                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                        </AxisY2>
                                        <AxisX2 Enabled="False">
                                        </AxisX2>
                                        <AxisY IsStartedFromZero="false" Title="Thousands" ArrowStyle="Triangle">
                                        </AxisY>--%><AxisY Enabled="False">
                                        </AxisY>
                                        <AxisX Enabled="True">
                                        </AxisX>
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
                            <span class="style4">Disclaimer : The above rating is for reference only and should not be relied on
                            for management
                            </span>
                            <br class="style4" />
                            <span class="style4">decision making prior to seeking proper professional advices.
                            </span>
                        </td>
                    </tr>
                      <tr>
                        <td style="padding-left: 120px;">
                            <table width="90%" style="border-width: 2px; border-color: Black; border-style: solid;">
                                <tr>
                                    <td width="20%">
                                        Scoring Reference
                                    </td>
                                    <td class="style5">
                                        &lt;</td>
                                    <td width="6%">
                                        50%
                                    </td>
                                    <td width="72%">
                                        Weak and not in your favour.</td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td class="style5">
                                        =
                                    </td>
                                    <td>
                                        50%
                                    </td>
                                    <td>
                                        There is room for improvement.
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td class="style5">
                                        &gt;
                                    </td>
                                    <td>
                                        50%
                                    </td>
                                    <td>
                                        You are doing well.</td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td class="style5">
                                        =
                                    </td>
                                    <td>
                                        100%
                                    </td>
                                    <td>
                                        You have a strong position</td>
                                </tr>
                               
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
        <td style="padding-left: 60px;" align="left">
                           <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/images/back.png" 
                                onclick="btnBack_Click" />
                        </td>
        </tr>
    </table>
</asp:Content>
