<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RadarGraph.aspx.cs" Inherits="RadarGraph"
    MasterPageFile="~/MasterPages/MainMaster.master" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxcontroltoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="874">
        <tr>
            <td align="left" height="33" valign="middle" class="blue_Big_title">
                <div>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblBusinessProfiling" runat="server" Text="Business Profiling" 
                        meta:resourcekey="lblBusinessProfilingResource1"></asp:Label>
                    
                </div>
            </td>
        </tr>
        <tr>
            <td height="5px" class="style3">
            </td>
        </tr>
        <tr>
            <td class="timesheet_bg_new">
                <table width="854" cellpadding="0" cellspacing="0" border="0" style="padding-left: 50px;">
                    <tr>
                        <td height="5px">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle">
                            <asp:Chart ID="Chart1" runat="server" Width="550px" Height="500px" 
                                ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Palette="SeaGreen" 
                                BackColor="211, 223, 240" BorderColor="#1A3B69" ImageStorageMode="UseImageLocation"
                                BackSecondaryColor="White" BorderDashStyle="Solid" BackGradientStyle="TopBottom"
                                BorderWidth="2px" meta:resourcekey="Chart1Resource1">
                                <Titles>
                                    <%-- <asp:Title ShadowColor="32, 0, 0, 0" Font="Microsoft Sans Serif , 14.25pt, style=Bold" ShadowOffset="3"
                                        Text="Business Health Profiling" ForeColor="26, 59, 105">
                                    </asp:Title>--%>
                                    <asp:Title ShadowColor="32, 0, 0, 0" Font="Arial, 14.25pt, style=Bold" ShadowOffset="3"
                                        Text="Business Profiling" ForeColor="26, 59, 105">
                                    </asp:Title>
                                </Titles>
                                <Legends>
                                    <asp:Legend IsTextAutoFit="true" Name="Default" BackColor="Transparent" Font="Microsoft Sans Serif , 8.25pt, style=Bold"
                                        Alignment="Far">
                                        <Position Y="74.08253" Height="14.23021" Width="19.34047" X="74.73474" 
                                            Auto="False"></Position>
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
                                        BackColor="OldLace" ShadowColor="Transparent">
                                        <Area3DStyle Rotation="4" Perspective="4" Inclination="15" IsRightAngleAxes="False"
                                            WallWidth="0" IsClustered="true" />
                                        <Position Y="15" Height="78" Width="88" X="5" Auto="False"></Position>
                                        <AxisY IsInterlaced="false" IsMarksNextToAxis="false" LineColor="64, 64, 64, 64">
                                            <%--   <LabelStyle Font="Microsoft Sans Serif , 8.25pt, style=Bold" />--%>
                                            <MajorGrid LineColor="64, 64, 64, 64" />
                                            <MajorTickMark Size="0.6" />
                                        </AxisY>
                                        <AxisX LineColor="64, 64, 64, 64">
                                            <%--    <LabelStyle Font="Microsoft Sans Serif , 8.25pt, style=Bold" />--%>
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
                        <td align="center">
                            <asp:Chart ID="FinancialChart" runat="server" BackColor="211, 223, 240" 
                                Width="550px" Height="400px"
                                BorderColor="#1A3B69" Palette="SeaGreen" BorderDashStyle="Solid" 
                                BackGradientStyle="TopBottom" ImageStorageMode="UseImageLocation"
                                BackSecondaryColor="White" BorderWidth="2px" ImageLocation="~\TempImages\ChartPic_#SEQ(300,3)"
                                SkinID="100" meta:resourcekey="FinancialChartResource1">
                                <Titles>
                                    <asp:Title ShadowColor="32, 0, 0, 0" Font="Arial, 14.25pt, style=Bold" ShadowOffset="3"
                                        Text="Your Score" ForeColor="26, 59, 105">
                                    </asp:Title>
                                </Titles>
                                <Legends>
                                    <asp:Legend Docking="Bottom" BackColor="AliceBlue" ItemColumnSpacing="500" LegendStyle="Column"
                                        Name="Legend2" Enabled="true" BorderWidth="1" BorderColor="Black" ItemColumnSeparator="Line"
                                        ItemColumnSeparatorColor="Black" AutoFitMinFontSize="10" TableStyle="Wide" Font="Microsoft Sans Serif , 14.25pt">
                                    </asp:Legend>
                                    <asp:Legend Docking="Bottom" LegendStyle="Table" Font="Microsoft Sans Serif , 14.25pt"
                                        BackColor="AliceBlue" Name="Legend1" TextWrapThreshold="50">
                                    </asp:Legend>
                                </Legends>
                                <Series>
                                    <asp:Series ChartArea="FinArea" Color="#715197" Name="Yours" IsValueShownAsLabel="false"
                                        Legend="Legend1" CustomProperties="DrawingStyle=Cylinder" IsVisibleInLegend="false">
                                    </asp:Series>
                                    <asp:Series ChartArea="FinArea" Color="#8CAF42" Name="High" IsValueShownAsLabel="false"
                                        Legend="Legend1" CustomProperties="DrawingStyle=Cylinder" IsVisibleInLegend="false"
                                        Font="Microsoft Sans Serif , 14.25pt">
                                    </asp:Series>
                                </Series>
                                <BorderSkin SkinStyle="Emboss" PageColor="Transparent"></BorderSkin>
                                <ChartAreas>
                                    <asp:ChartArea Name="FinArea" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                                        BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent"
                                        BackGradientStyle="TopBottom" IsSameFontSizeForAllAxes="true" AlignmentOrientation="Horizontal">
                                        <AxisY Enabled="True" Maximum="100">
                                          <%--  <CustomLabels>
                                                <asp:CustomLabel Text="Weak" FromPosition="-20" ToPosition="20" />
                                                <asp:CustomLabel Text="Average" FromPosition="100" />
                                                <asp:CustomLabel Text="Strong" FromPosition="200" />
                                            </CustomLabels>--%>
                                            <%--    <LabelStyle Font="Microsoft Sans Serif ,18.25pt" />--%>
                                        </AxisY>
                                        <AxisX Enabled="True">
                                            <CustomLabels>
                                            </CustomLabels>
                                            <%--<CustomLabels >
                                                <asp:CustomLabel Text="Weak"  FromPosition="2"  />
                                                <asp:CustomLabel Text="Strong" FromPosition="4" />
                                            </CustomLabels>--%>
                                            <%--    <LabelStyle Font="Microsoft Sans Serif , 18.25pt" />--%>
                                        </AxisX>
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                        </td>
                    </tr>
                    <tr>
                        <td>
                    
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td height="30" align="center" valign="center">
                                        <img src="../images/arrow.png" alt="" width="10" height="9" vspace="5" />
                                    </td>
                                    <td>
                                        <a href="../Public/ResourceLibDtls.aspx?RL_ID=A5LcxPFeFR4%3d" class="blueLinks">
                                            <asp:Label ID="lblIntro" runat="server" 
                                            Text="Introduction to Business Health Profiling" 
                                            meta:resourcekey="lblIntroResource1"></asp:Label>
                                         </a>
                                    </td>
                                </tr>
                                  <tr>
                                    <td colspan="2" style="font: Arial, Helvetica, sans-serif; color: #000; font-size: 13px;">
                                      <asp:Label ID="lblDes1" runat="server" 
                                            Text=" Understand your business profile and find out what are the strategies that you can adopt to further the growth of your business." 
                                            meta:resourcekey="lblDes1Resource1"></asp:Label>
                                     

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
                        <td style="font: Arial, Helvetica, sans-serif; color: #000; font-size: 13px" align="left">
                            <asp:Label ID="lblDes2" runat="server" Text=" Disclaimer: The above rating is for reference only and should
                            not be relied on for management decision making prior to seeking proper professional
                            advices." meta:resourcekey="lblDes2Resource1"></asp:Label>

                          
                        </td>
                    </tr>
                 
                    <tr>
                        <td align="left" style="display:none">
                            <asp:Label ID="lblBusinessProfi" runat="server" Visible="False" 
                                meta:resourcekey="lblBusinessProfiResource1"></asp:Label>
                            <asp:Label ID="lblGroandGlo" runat="server" Visible="False" 
                                meta:resourcekey="lblGroandGloResource1"></asp:Label>
                            <asp:Label ID="lblSurvival" runat="server" Visible="False" 
                                meta:resourcekey="lblSurvivalResource1"></asp:Label>
                            <asp:Label ID="lblRej" runat="server" Visible="False" 
                                meta:resourcekey="lblRejResource1"></asp:Label>
                            <asp:Label ID="lblGrowingPlan" runat="server" Visible="False" 
                                meta:resourcekey="lblGrowingPlanResource1"></asp:Label>
                            <asp:Label ID="lblYourScore" runat="server" Visible="False" 
                                meta:resourcekey="lblYourScoreResource1"></asp:Label>
                            <asp:Label ID="lblYourCashFLow" runat="server" Visible="False" 
                                meta:resourcekey="lblYourCashFLowResource1"></asp:Label>
                            <asp:Label ID="lblProfi" runat="server" Visible="False" 
                                meta:resourcekey="lblProfiResource1"></asp:Label>
                            <asp:Label ID="lblYourComp" runat="server" Visible="False" 
                                meta:resourcekey="lblYourCompResource1"></asp:Label>
                            <asp:Label ID="lblYourRating" runat="server" Visible="False" 
                                meta:resourcekey="lblYourRatingResource1"></asp:Label>
                            <asp:Label ID="lblWeak" runat="server" Visible="False" 
                                meta:resourcekey="lblWeakResource1"></asp:Label>
                            <asp:Label ID="lblAvarage" runat="server" Visible="False" 
                                meta:resourcekey="lblAvarageResource1"></asp:Label>
                            <asp:Label ID="lblStrong" runat="server" Visible="False" 
                                meta:resourcekey="lblStrongResource1"></asp:Label>
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
            <td style="padding-left: 50px;" align="left">
              <%--  <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/images/back.png" 
                    OnClick="btnBack_Click" meta:resourcekey="btnBackResource1" />
--%>
                    <asp:Button ID="btnBack" runat="server" Text="Back" 
                    CssClass="orange_button"  meta:resourcekey="btnBackResource1" onclick="btnBack_Click"
                                      />
            </td>
        </tr>
    </table>
</asp:Content>
