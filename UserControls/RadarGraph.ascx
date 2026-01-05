<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RadarGraph.ascx.cs" Inherits="UserControls_RadarGraph" %>
<table class="sampleTable">
    <tr>
        <td width="412" class="tdchart">
            <asp:Chart ID="Chart1" runat="server" Width="500px" Height="500px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)"
                ImageType="Png" Palette="BrightPastel" BackColor="#F3DFC1" BorderColor="181, 64, 1"
                BorderDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BackHatchStyle="BackwardDiagonal">
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
                <BorderSkin SkinStyle="Emboss"></BorderSkin>
                <Series>
                    <asp:Series MarkerBorderColor="64, 64, 64" MarkerSize="4" Name="Series1" ChartType="Radar"
                        BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" ShadowOffset="1">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                        BackColor="OldLace" ShadowColor="Transparent">
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
        <td valign="top" style="display: none;">
            <table class="controls" cellpadding="4">
                <tr>
                    <td class="label">
                        Radar Style:
                    </td>
                    <td>
                        <asp:DropDownList ID="RadarStyleList" runat="server" AutoPostBack="True" Width="100px"
                            CssClass="spaceright">
                            <asp:ListItem Value="Area" Selected="True">Area</asp:ListItem>
                            <asp:ListItem Value="Line">Line</asp:ListItem>
                            <asp:ListItem Value="Marker">Marker</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="label">
                        Area Drawing Style:
                    </td>
                    <td>
                        <asp:DropDownList ID="AreaDrawingStyleList" runat="server" AutoPostBack="True" Width="100px"
                            CssClass="spaceright">
                            <asp:ListItem Value="Circle" Selected="True">Circle</asp:ListItem>
                            <asp:ListItem Value="Polygon">Polygon</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="label">
                        Labels Style:
                    </td>
                    <td>
                        <asp:DropDownList ID="LabelStyleList" runat="server" AutoPostBack="True" Width="100px"
                            CssClass="spaceright">
                            <asp:ListItem Value="Circular">Circular</asp:ListItem>
                            <asp:ListItem Value="Radial">Radial</asp:ListItem>
                            <asp:ListItem Value="Horizontal" Selected="True">Horizontal</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="label">
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
