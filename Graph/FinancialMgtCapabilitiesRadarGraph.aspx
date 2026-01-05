<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FinancialMgtCapabilitiesRadarGraph.aspx.cs"
    Inherits="FinancialMgtCapabilitiesRadarGraph" MasterPageFile="~/MasterPages/MainMaster.master" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxcontroltoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="874">
        <tr>
            <td align="left" height="33" valign="middle" class="blue_Big_title">
                <div>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblFin" runat="server" Text="Financial Management Capabilities" 
                        meta:resourcekey="lblFinResource1"></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td height="5px" class="style3">
            </td>
        </tr>
        <tr>
            <td align="left" class="timesheet_bg_new">
                <table width="854" cellpadding="0" cellspacing="0" border="0" style="padding-left: 50px;">
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
                            <asp:Chart ID="FinancialChart" runat="server" BackColor="211, 223, 240" 
                                Width="650px" Height="600px"
                                BorderColor="#1A3B69" Palette="SeaGreen" BorderDashStyle="Solid" BackGradientStyle="TopBottom"
                                ImageStorageMode="UseImageLocation" BackSecondaryColor="White" 
                                BorderWidth="2px" ImageLocation="~\TempImages\ChartPic_#SEQ(300,3)" 
                                SkinID="100" meta:resourcekey="FinancialChartResource1">
                                <Titles>
                                    <asp:Title Text="Your Score" Font="Microsoft Sans Serif , 14.25pt" ForeColor="26, 59, 105"
                                        ShadowOffset="3" ShadowColor="32, 0, 0, 0" Name="Title1">
                                    </asp:Title>
                                </Titles>
                                <Series>
                                    <asp:Series IsVisibleInLegend="false" ChartArea="FinArea" Color="#715197" Name="Yours"
                                        IsValueShownAsLabel="false" Legend="Legend1" CustomProperties="DrawingStyle=Cylinder,PixelPointWidth=50"
                                        XAxisType="Primary">
                                    </asp:Series>
                                    <asp:Series ChartArea="FinArea" IsVisibleInLegend="false" Color="#8CAF42" Name="High"
                                        IsValueShownAsLabel="false" Legend="Legend1" CustomProperties="DrawingStyle=Cylinder,PixelPointWidth=50">
                                    </asp:Series>
                                </Series>
                                <BorderSkin SkinStyle="Emboss" PageColor="Transparent"></BorderSkin>
                                <ChartAreas>
                                    <asp:ChartArea Name="FinArea" BorderDashStyle="Solid" BackSecondaryColor="White"
                                        BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom"
                                        IsSameFontSizeForAllAxes="true">
                                        <AxisY Enabled="True" ArrowStyle="None" IsLabelAutoFit="false" Maximum="100">
                                            <CustomLabels>
                                            <%--    <asp:CustomLabel Text="Improvement Needed" FromPosition="-50" ToPosition="50" />
                                                <asp:CustomLabel Text="Average" FromPosition="100" />
                                                <asp:CustomLabel Text="Excellent" FromPosition="200" />--%>
                                            </CustomLabels>
                                        </AxisY>
                                        <AxisX Enabled="True" IsLabelAutoFit="false">
                                        </AxisX>
                                        <AxisX2 Enabled="False">
                                        </AxisX2>
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                        </td>
                        <%--    <td valign="top">
                                            <table width="300" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td height="115" align="center" valign="top" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr class="grid_sub_1">
                                                    <td width="18" height="26" align="center" valign="top">
                                                        <img src="../images/arrow.png" width="10" height="9" vspace="5" />
                                                    </td>
                                                    <td width="202">
                                                        <a href="#" class="blueLinks">Click here to start working on your 3 years financial
                                                            plan</a>
                                                    </td>
                                                </tr>
                                                <tr class="grid_sub_1">
                                                    <td height="30" align="center" valign="top">
                                                        <img src="../images/arrow.png" alt="" width="10" height="9" vspace="5" />
                                                    </td>
                                                    <td>
                                                        <a href="#" class="blueLinks">Click here to learn how to draw up your business plan
                                                        </a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="25" align="center" valign="top" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr class="grid_sub">
                                                    <td height="30" align="center" valign="top">
                                                        <img src="../images/arrow.png" alt="" width="10" height="9" vspace="5" />
                                                    </td>
                                                    <td>
                                                        <a href="#" class="blueLinks">Click here to learn how to use your management report
                                                            to help you in decision making </a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="25" align="center" valign="top" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr class="grid_sub_1">
                                                    <td height="30" align="center" valign="top">
                                                        <img src="../images/arrow.png" alt="" width="10" height="9" vspace="5" />
                                                    </td>
                                                    <td>
                                                        <a href="#" class="blueLinks">Click here to learn how to organise your inventory recording
                                                            system</a>
                                                    </td>
                                                </tr>
                                                <tr class="grid_sub_1">
                                                    <td height="30" align="center" valign="top">
                                                        <img src="../images/arrow.png" alt="" width="10" height="9" vspace="5" />
                                                    </td>
                                                    <td>
                                                        <a href="#" class="blueLinks">Click here to learn how to implement basic inventory controls
                                                        </a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="15" align="center" valign="top" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr class="grid_sub">
                                                    <td height="30" align="center" valign="top">
                                                        <img src="../images/arrow.png" alt="" width="10" height="9" vspace="5" />
                                                    </td>
                                                    <td>
                                                        <a href="#" class="blueLinks">Click here to learn how to implement a simple credit control
                                                            procedure</a>
                                                    </td>
                                                </tr>
                                                <tr class="grid_sub">
                                                    <td height="30" align="center">
                                                        <img src="../images/arrow.png" alt="" width="10" height="9" />
                                                    </td>
                                                    <td>
                                                        <a href="#" class="blueLinks">Click here to download standard reminder letters</a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="17" align="center" valign="top" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr class="grid_sub_1">
                                                    <td height="30" align="center" valign="top">
                                                        <img src="../images/arrow.png" alt="" width="10" height="9" vspace="5" />
                                                    </td>
                                                    <td>
                                                        <a href="#" class="blueLinks">Click here to learn how to set up basic control on purchases
                                                        </a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>--%>
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
                                        <a href="../Public/ResourceLibDtls.aspx?RL_ID=3hoSZZAI64w%3d" class="blueLinks">
                                            <asp:Label ID="lblIntro" runat="server" 
                                            Text="Introduction to Systems and Controls" 
                                            meta:resourcekey="lblIntroResource1"></asp:Label>
                                        </a>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="font: Arial, Helvetica, sans-serif; color: #000; font-size: 13px;">
                                        <asp:Label ID="lblDes1" runat="server" Text="Effective systems and controls can help businesses improve operating efficiency,
                                        safeguard assets and enhances the quality
                                        of reporting. Learn more." meta:resourcekey="lblDes1Resource1"></asp:Label>
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
                            <asp:Label ID="lblDes2" runat="server" Text="Disclaimer : The above rating is for reference only and should
                            not be relied on for management decision making prior to seeking proper professional
                            advices." meta:resourcekey="lblDes2Resource1"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 25px">
                            &nbsp;
                        </td>
                    </tr>
                    <%--  <tr>
                        <td align="left">
                     
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="font-family: Arial;
                                color: #000; font-size: 13px;">
                                <tr>
                                    <td>
                                        <table width="100%" border="0" cellpadding="3" cellspacing="0">
                                            <tr class="grid_sub_1">
                                                <td width="16%">
                                                    Scoring Reference
                                                </td>
                                                <td width="2%">
                                                    =
                                                </td>
                                                <td width="7%">
                                                    0%
                                                </td>
                                                <td width="78%">
                                                    Not Applicable to your Business
                                                </td>
                                            </tr>
                                            <tr class="grid_sub">
                                                <td>
                                                </td>
                                                <td>
                                                    &lt;
                                                </td>
                                                <td>
                                                    50%
                                                </td>
                                                <td>
                                                    Improvement needed
                                                </td>
                                            </tr>
                                            <tr class="grid_sub_1">
                                                <td>
                                                </td>
                                                <td>
                                                    =
                                                </td>
                                                <td>
                                                    50%
                                                </td>
                                                <td>
                                                    Average
                                                </td>
                                            </tr>
                                            <tr class="grid_sub">
                                                <td>
                                                </td>
                                                <td>
                                                    &gt;
                                                </td>
                                                <td>
                                                    50%
                                                </td>
                                                <td>
                                                    Good
                                                </td>
                                            </tr>
                                            <tr class="grid_sub_1">
                                                <td>
                                                </td>
                                                <td>
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
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>--%>
                </table>
            </td>
        </tr>
        <tr>
            <td style="display:none">
                <asp:Label ID="lblYourScore" runat="server" Visible="False" 
                    meta:resourcekey="lblYourScoreResource1"></asp:Label>
                <asp:Label ID="lblHowSerious" runat="server" Visible="False" 
                    meta:resourcekey="lblHowSeriousResource1"></asp:Label>
                <asp:Label ID="lblHowMuch" runat="server" Visible="False" 
                    meta:resourcekey="lblHowMuchResource1"></asp:Label>
                <asp:Label ID="lblHow1" runat="server" Visible="False" 
                    meta:resourcekey="lblHow1Resource1"></asp:Label>
                <asp:Label ID="lblHow2" runat="server" Visible="False" 
                    meta:resourcekey="lblHow2Resource1"></asp:Label>
                <asp:Label ID="lblHow3" runat="server" Visible="False" 
                    meta:resourcekey="lblHow3Resource1"></asp:Label>
                <asp:Label ID="lblImpro" runat="server" Visible="False" 
                    meta:resourcekey="lblImproResource1"></asp:Label>
                <asp:Label ID="lblAvg" runat="server" Visible="False" 
                    meta:resourcekey="lblAvgResource1"></asp:Label>
                <asp:Label ID="lblExcellent" runat="server" Visible="False" 
                    meta:resourcekey="lblExcellentResource1"></asp:Label>
             

            </td>
        </tr>
        <tr>
            <td style="padding-left: 50px;" align="left">
          <%--      <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/images/back.png" OnClick="btnBack_Click" />--%>

                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="orange_button" 
                    onclick="btnBack_Click" meta:resourcekey="btnBackResource1" />
            </td>
        </tr>
    </table>
</asp:Content>
