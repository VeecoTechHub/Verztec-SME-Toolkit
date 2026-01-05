<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DownloadReport.aspx.cs" Inherits="FinancialModeling_DownloadReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <script type="text/javascript" language="javascript">


      function formatCellsWithComma(strLblClientIds) {

          var lblSplitIds = strLblClientIds.split(',');

          for (i = 0; i <= lblSplitIds.length - 1; i++) {

              var lblObj = document.getElementById(lblSplitIds[i]);

              var val = document.getElementById(lblSplitIds[i]).innerText;

              lblObj.innerText = includeComma(val, 3);
          }
      }
      


    </script>
       <title>ABS : The Association of Banks in Singapore</title>   
   <link href="<%= Page.ResolveUrl("~/css/mainstyles.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl("~/css/SlideShow.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl("~/css/RatingStyles.css") %>" rel="stylesheet" type="text/css" />   
    <script src="../scripts/Common.js" type="text/javascript"></script>
 
</head>
 
   
<body>
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
  <table width="874px" border="0" align="center" cellpadding="0" cellspacing="0" style="padding-left: 25px;">
  
  <tr><td>
  <table  Width="680" border="0" align="center" cellpadding="0" cellspacing="0" style="padding-left: 25px;">
     
    <tr>
        <td width="750" valign="bottom" >
            <table Width="680" border="0" align="center" cellpadding="0" cellspacing="0" style="padding-left: 25px;" >
      <tr><td style="height:50px">&nbsp;</td></tr>
                    <tr>
                        <td height="100px">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="blue_36_font"  Height="60px">
                           <asp:Label ID="lblCompanyName" runat="server"/>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="black_22_font">
                            Financial Diagnostic and Key Analysis Report<br>
                            For the 3 Years ending  <asp:Label ID="lblFinancialYr" runat="server" /><br />
                            Dated : <asp:Label ID="lblTodayDate" runat="server" /> <%--1 Jan 2011 to 31 Dec 2013--%><br>
                        </td>
                    </tr>
                    <tr>
                        <td height="250">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong style="color:Red;">Disclaimer</strong><br/>
                            The report is generated based on information entered and for indicative purpose
                            only.Please seek professional advices prior to making any business decission.
                        </td>
                    </tr>
                    <tr>
                        <td height="420">
                            &nbsp;
                        </td>
                    </tr>
             
            </table>
        </td>
        <td valign="top">
            <table border="0" cellpadding="0" cellspacing="0" width="29">
                <tr>
                    <td height="1">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:ImageButton ID="imgBtnHightlight" runat="server" border="0" Height="117" ImageUrl="~/images/highlights.jpg"
                            Width="29" />
                        <%--<a href="highlights.aspx"><img src="images/highlights.jpg" alt="" width="29" height="117" border="0" /></a>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%-- <a href="breakeven.aspx">
                                                                                            <img src="images/breaken.jpg" alt="" width="29" height="117" border="0" /></a>--%>
                        <asp:ImageButton ID="imgBtnBreakeven" runat="server" border="0" Height="117" ImageUrl="~/images/breaken.jpg"
                            Width="29" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%-- <a href="workingcapital.aspx">
                                                                                            <img src="images/WorkingCapital.jpg" alt="" width="29" height="138" border="0" /></a>--%>
                        <asp:ImageButton ID="imgBtnWorkingCapital" runat="server" border="0" Height="117"
                            ImageUrl="~/images/WorkingCapital.jpg" Width="29" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%-- <a href="cashflow.aspx">
                                                                                            <img src="images/CashFlow.jpg" alt="" width="29" height="116" border="0" /></a>--%>
                        <asp:ImageButton ID="imgBtnCashFlow" runat="server" border="0" Height="117" ImageUrl="~/images/CashFlow.jpg"
                            Width="29" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--  <a href="funding.aspx">
                                                                                            <img src="images/Funding.jpg" alt="" width="29" height="115" border="0" /></a>--%>
                        <asp:ImageButton ID="imgBtnFunding" runat="server" border="0" Height="117" ImageUrl="~/images/Funding.jpg"
                            Width="29" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%-- <a href="appendix.aspx">
                                                                                            <img src="images/Appendix.jpg" alt="" width="29" height="115" border="0" /></a>--%>
                        <asp:ImageButton ID="imgBtnAppendix" runat="server" border="0" Height="117" ImageUrl="~/images/Appendix1.jpg"
                            Width="29" />
                    </td>
                </tr>
                <tr>
                    <td>

                        <asp:ImageButton ID="imgBtnAppendix2" runat="server" border="0" Height="117" ImageUrl="~/images/Appendix2.jpg"
                            Width="29"  />
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
  </td></tr>
  <tr>
  <td>
  <table width="680px" border="0" align="center" cellpadding="0" cellspacing="0" style="padding-left: 25px;">
     <tr>
        <td  class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            <asp:Image ID="imgHeader" runat="server" Width="680" ImageUrl="~/images/highlightsbar.png" />
        </td>
    </tr>
     <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
        <tr><td class="FontStyle" width="680">The following graph shows the three primary financial indicators of your business: Sales, Gross Profit and Earnings (specifically EBITDA) projections for the next three years.								
    
    </td></tr>
    
        <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td align="left" valign="top">
            <h4>
                A) Financial Highlights</h4>
        </td>
    </tr>
    <tr>
        <td valign="top" align="center">
            <asp:Chart ID="FinancialChart" runat="server" BackColor="#D3DFF0" Width="600px" Height="400px"
                BorderColor="26, 59, 105" Palette="SeaGreen" BorderDashStyle="Solid" BackGradientStyle="TopBottom"
                BackSecondaryColor="White" BorderWidth="2" ImageType="Png" ImageLocation="~\TempImages\ChartPic_#SEQ(300,3)"
                SkinID="100" BorderlineColor="Wheat" BorderlineDashStyle="DashDot" BackImageTransparentColor="Transparent">
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
                        Text="Financial Highlights" ForeColor="26, 59, 105">
                    </asp:Title>
                </Titles>
                <Series>
                    <asp:Series ChartArea="FinArea" Color="#37ACCB" Name="Sales" IsValueShownAsLabel="true"
                        CustomProperties="DrawingStyle=Cylinder" Legend="Legend1">
                    </asp:Series>
                    <asp:Series ChartArea="FinArea" Color="#7756A0" Name="GrossProfit" IsValueShownAsLabel="true"
                        CustomProperties="DrawingStyle=Cylinder" Legend="Legend1">
                    </asp:Series>
                    <asp:Series ChartArea="FinArea" IsValueShownAsLabel="true" Color="#96BC47" Name="EBITDA"
                        CustomProperties="DrawingStyle=Cylinder" Legend="Legend1">
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
                        </AxisY>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </td>
    </tr>
    <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
           <tr>
        <td align="center" >
            <table class="tblBorder" width="600px" cellpadding="0" cellspacing="0" style="font-size: 8.5pt;font-family: Verdana, Arial, haettenschweiler;  color:#000000;">
                <tr style="background-color:#0099FF; color:White; font-weight:bold">
                    <td style="width:300px" >
                    </td>
                     <td style="width:75px" align="right">
                        FY<asp:Label ID="lblYearC" runat="server"  ></asp:Label>A
                    </td>
                    <td style="width:75px" align="right" >
                        FY<asp:Label ID="lblYearP1" runat="server"  ></asp:Label>P
                    </td>
                    <td style="width:75px" align="right" >
                        FY<asp:Label ID="lblYearP2" runat="server"  ></asp:Label>P
                    </td>
                    <td style="width:75px" align="right"
                        FY<asp:Label ID="lblYearP3" runat="server"  ></asp:Label>P
                    </td>
                </tr>
                <tr class="FontStyle">
                 <td align="left" style="width:300px"><asp:Label ID="lblEBITDA" runat="server"  ></asp:Label>(%)</td>
                 <td style="width:75px" align="right"><asp:Label ID="lblEBITDAC" runat="server"  ></asp:Label>%</td>
                 <td style="width:75px" align="right"><asp:Label ID="lblEBITDAP1" runat="server"  ></asp:Label>%</td>
                 <td style="width:75px" align="right"><asp:Label ID="lblEBITDAP2" runat="server"  ></asp:Label>%</td>
                 <td style="width:75px" align="right"><asp:Label ID="lblEBITDAP3" runat="server"  ></asp:Label>%</td>
                
                
                </tr>
                <tr class="FontStyle">
                <td align="left" style="width:300px"><asp:Label ID="lblEBITDAPercentage" runat="server"  ></asp:Label>(%)</td>
                 <td style="width:75px" align="right"><asp:Label ID="lblEBITDAPercentageC" runat="server"  ></asp:Label>%</td>
                 <td style="width:75px" align="right"><asp:Label ID="lblEBITDAPercentageP1" runat="server"  ></asp:Label>%</td>
                 <td style="width:75px" align="right"><asp:Label ID="lblEBITDAPercentageP2" runat="server"  ></asp:Label>%</td>
                 <td style="width:75px" align="right"><asp:Label ID="lblEBITDAPercentageP3" runat="server"  ></asp:Label>%</td>
                </tr>
                    <tr class="FontStyle">
                <td  align="left" style="width:300px"><asp:Label ID="lblGrossProfit" runat="server"  ></asp:Label></td>
                  <td style="width:75px" align="right" ><asp:Label ID="lblGrossProfitC" runat="server"  ></asp:Label></td>
                 <td style="width:75px" align="right"><asp:Label ID="lblGrossProfitP1" runat="server"  ></asp:Label></td>
                 <td style="width:75px" align="right"><asp:Label ID="lblGrossProfitP2" runat="server"  ></asp:Label></td>
                 <td style="width:75px" align="right"><asp:Label ID="lblGrossProfitP3" runat="server"  ></asp:Label></td>
                </tr>
                 <tr class="FontStyle">
                <td align="left" style="width:300px"><asp:Label ID="lblGrossProfitPercentage" runat="server"  ></asp:Label></td>
                   <td style="width:75px" align="right"><asp:Label ID="lblGrossProfitPercentageC" runat="server"  ></asp:Label></td>
                 <td style="width:75px" align="right"><asp:Label ID="lblGrossProfitPercentageP1" runat="server"  ></asp:Label></td>
                 <td style="width:75px" align="right"><asp:Label ID="lblGrossProfitPercentageP2" runat="server"  ></asp:Label></td>
                 <td style="width:75px" align="right"><asp:Label ID="lblGrossProfitPercentageP3" runat="server"  ></asp:Label></td>
                </tr>
                   <tr class="FontStyle">
                <td align="left" style="width:300px"><asp:Label ID="lblSales" runat="server"  ></asp:Label></td>
                 <td style="width:75px" align="right"><asp:Label ID="lblSalesC" runat="server"  ></asp:Label></td>
                 <td style="width:75px" align="right"><asp:Label ID="lblSalesP1" runat="server"  ></asp:Label></td>
                 <td style="width:75px" align="right"><asp:Label ID="lblSalesP2" runat="server"  ></asp:Label></td>
                 <td style="width:75px" align="right"><asp:Label ID="lblSalesP3" runat="server"  ></asp:Label></td>
                </tr>
            </table>
         
        </td>
    </tr>
      <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
     <tr><td class="Header">1. Sales   
    
    </td></tr>
       <tr><td class="FontStyle">Sales, also commonly known as Revenue, Turnover, and sometimes incorrectly known as Income, is derived from the sale of goods and/or provision of services. Sales is recorded when it is confirmed that the business activity will lead to the receipt of payment from the customer. Sales should not ever be confused with profit; a business may make sales, but not necessarily profitable.								
    
    </td></tr>
    
       <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
       <tr><td class="Header">2. Gross Profit
    
    </td></tr>
       <tr><td class="FontStyle">Gross Profit measures the amount that is left after deducting the direct costs associated to the sales. For sale of goods, the direct costs may be cost of goods, freight charges, packing costs. For rendering of services, the direct costs may be manpower and/or subcontract costs. This represents the net contribution from the sale before deducting the operating expenses of the business. 								

    
    </td></tr>
      <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>

     <tr><td align="center">
       <asp:GridView ID="gvGrossProfit" runat="server" ShowHeader="true" CssClass="tblBorder" Width="600px" GridLines="None"
                    AutoGenerateColumns="false" >
                    <Columns>
                       <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                            <ItemTemplate>
                                <asp:Label ID="lblFsMappingName" runat="server" Text='<%#Eval("FsMappingName")%>' ></asp:Label>
                            </ItemTemplate>
                          
                            <ItemStyle HorizontalAlign="left" CssClass="gvFont" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                            <ItemTemplate>
                                <asp:Label ID="lblC_Percent" runat="server" Text='<%#Eval("C_Percent")%>'></asp:Label>%
                            </ItemTemplate>
                        
                            <ItemStyle HorizontalAlign="right"  CssClass="gvFont"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="right" >
                            <ItemTemplate>
                                <asp:Label ID="lbl_P1_Percent" runat="server" Text='<%#Eval("P1_Percent")%>'></asp:Label>%
                            </ItemTemplate>
                      
                            <ItemStyle HorizontalAlign="right" CssClass="gvFont" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                            <ItemTemplate>
                                <asp:Label ID="lbl_P2_Percent" runat="server" Text='<%#Eval("P2_Percent") %>'></asp:Label>%</ItemTemplate>
                        
                            <ItemStyle HorizontalAlign="right" CssClass="gvFont" />
                        </asp:TemplateField>
                      
                        <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                            <ItemTemplate>
                                <asp:Label ID="lbl_P3_Percent" runat="server" Text='<%#Eval("P3_Percent") %>'></asp:Label>%</ItemTemplate>
                         
                            <ItemStyle HorizontalAlign="right" CssClass="gvFont"/>
                        </asp:TemplateField>
                     
                    </Columns>
               <RowStyle VerticalAlign="NotSet" />
                    <HeaderStyle BackColor="#0099FF" ForeColor="White" Height="5"/>
                    
                </asp:GridView>
     
     
      </td></tr>
        <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
      <tr><td class="FontStyle">
      Gross profit margin is calculated by dividing gross profit by sales. It represents how much every dollar of sales is left after deducting the costs of sales. The higher the gross profit margin, the higher the incremental contribution from every dollar increase in sales. This is a key indicator that every business should be focusing on to manage the performance of the business.								
      </td></tr>
      
        <tr>
        <td Height="100px">
            &nbsp;
        </td>
    </tr>
      <tr>
        <td>
            <asp:Image ID="Image6" runat="server" Width="680" ImageUrl="~/images/highlightsbar.png" />
        </td>
    </tr>
      <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr><td class="Header">3. EBITDA (Earnings before interest, tax, depreciation and amortisation)</td></tr>
    <tr><td class="FontStyle">EBITDA is a good measure of the operaing cash flow that the business is able to generate.  Generally, if a business is unable to generate positive EBITDA, the business viability may be at stake. It means that the business is unable to generate sufficient operating cash to cover interests and tax payments. Unless the business has strong cash backing, a business cannot sustain with negative EBITDA.								
    
    
    </td></tr>
       <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    
          <tr><td class="FontStyle">The following graph shows the three primary financial indicators of your business: Sales, Gross Profit and Earnings (specifically EBITDA) projections for the next three years.								
    
    </td></tr>
     
    
    <tr>
        <td align="left" valign="top">
            <h4>
                B) Segment Analysis</h4>
        </td>
    </tr>
    <tr>
        <td valign="top" align="center">
            <asp:Chart ID="chartSegmentAnalysis" runat="server" BackColor="#D3DFF0" Width="600px" 
                Height="400px" BorderColor="26, 59, 105" Palette="SeaGreen" BorderDashStyle="Solid"
                BackGradientStyle="TopBottom" BackSecondaryColor="White" BorderWidth="2" ImageType="Png"
                ImageLocation="~\TempImages\ChartPic_#SEQ(300,3)" SkinID="100" BorderlineColor="Wheat"
                BorderlineDashStyle="DashDot" BackImageTransparentColor="Transparent">
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
                    <asp:Series ChartArea="FinArea" Color="#FF00AE" BorderWidth="3" Name="GrossProfit Margin (%)"
                        CustomProperties="DrawingStyle=Cylinder" IsValueShownAsLabel="true" Legend="Legend1">
                    </asp:Series>
                    <asp:Series ChartArea="FinArea" Color="#B75A0C" BorderWidth="3" Name="EBITDA Margin (%)"
                        CustomProperties="DrawingStyle=Cylinder" IsValueShownAsLabel="true" Legend="Legend1">
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
                            <%--Title="Thousands"--%>
                        </AxisY>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </td>
    </tr>

     <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
       <tr><td align="center">
       <asp:GridView ID="gvSalesProfitAnalysis" runat="server" ShowHeader="true" 
               CssClass="tblBorder" Width="600px" GridLines="None"
                    AutoGenerateColumns="false" 
               onrowcreated="gvSalesProfitAnalysis_RowCreated" onrowdatabound="gvSalesProfitAnalysis_RowDataBound" 
              >
                    <Columns>
                       <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblFsMappingName" runat="server" Text='<%#Eval("FsMappingName")%>'></asp:Label>
                            </ItemTemplate>
                          
                            <ItemStyle HorizontalAlign="Left" CssClass="gvFont" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                            <ItemTemplate>
                                <asp:Label ID="lbl_P1_Value" runat="server" Text='<%#Eval("P1_Value")%>'></asp:Label>
                            </ItemTemplate>
                        
                            <ItemStyle HorizontalAlign="right"  CssClass="gvFont"/>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderStyle-HorizontalAlign="right" >
                            <ItemTemplate>
                                <asp:Label ID="lbl_P1_Percent" runat="server" Text='<%#Eval("P1_Percent")%>'></asp:Label>%
                            </ItemTemplate>
                      
                            <ItemStyle HorizontalAlign="right" CssClass="gvFont" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="right" >
                            <ItemTemplate>
                                <asp:Label ID="lbl_P2_Value" runat="server" Text='<%#Eval("P2_Value")%>'></asp:Label>
                            </ItemTemplate>
                      
                            <ItemStyle HorizontalAlign="right" CssClass="gvFont" />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderStyle-HorizontalAlign="right" >
                            <ItemTemplate>
                                <asp:Label ID="lbl_P2_Percent" runat="server" Text='<%#Eval("P2_Percent")%>'></asp:Label>%
                            </ItemTemplate>
                      
                            <ItemStyle HorizontalAlign="right" CssClass="gvFont" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                            <ItemTemplate>
                                <asp:Label ID="lbl_P3_Value" runat="server" Text='<%#Eval("P3_Value") %>'></asp:Label></ItemTemplate>
                        
                            <ItemStyle HorizontalAlign="right" CssClass="gvFont" />
                        </asp:TemplateField>
                      
                        <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                            <ItemTemplate>
                                <asp:Label ID="lbl_P3_Percent" runat="server" Text='<%#Eval("P3_Percent") %>'></asp:Label>%</ItemTemplate>
                         
                            <ItemStyle HorizontalAlign="right" CssClass="gvFont"/>
                        </asp:TemplateField>
                     
                    </Columns>
               <RowStyle VerticalAlign="NotSet" />
                    <HeaderStyle BackColor="#0099FF" ForeColor="White" Height="5"/>
                    
                </asp:GridView>
     
     
      </td></tr>
      
        <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
       <tr><td align="center">
       <asp:GridView ID="gvGPAnalysis" runat="server" ShowHeader="true" 
               CssClass="tblBorder" Width="600px" GridLines="None"
                    AutoGenerateColumns="false" onrowdatabound="gvGPAnalysis_RowDataBound"  
              >
                    <Columns>
                       <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblFsMappingName" runat="server" Text='<%#Eval("FsMappingName")%>'></asp:Label>
                            </ItemTemplate>
                          
                            <ItemStyle HorizontalAlign="Left" CssClass="gvFont" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                            <ItemTemplate>
                                <asp:Label ID="lbl_P1_Value" runat="server" Text='<%#Eval("P1_Value")%>'></asp:Label>
                            </ItemTemplate>
                        
                            <ItemStyle HorizontalAlign="right"  CssClass="gvFont"/>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderStyle-HorizontalAlign="right" >
                            <ItemTemplate>
                                <asp:Label ID="lbl_P1_Percent" runat="server" Text='<%#Eval("P1_Percent")%>'></asp:Label>%
                            </ItemTemplate>
                      
                            <ItemStyle HorizontalAlign="right" CssClass="gvFont" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="right" >
                            <ItemTemplate>
                                <asp:Label ID="lbl_P2_Value" runat="server" Text='<%#Eval("P2_Value")%>'></asp:Label>
                            </ItemTemplate>
                      
                            <ItemStyle HorizontalAlign="right" CssClass="gvFont" />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderStyle-HorizontalAlign="right" >
                            <ItemTemplate>
                                <asp:Label ID="lbl_P2_Percent" runat="server" Text='<%#Eval("P2_Percent")%>'></asp:Label>%
                            </ItemTemplate>
                      
                            <ItemStyle HorizontalAlign="right" CssClass="gvFont" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                            <ItemTemplate>
                                <asp:Label ID="lbl_P3_Value" runat="server" Text='<%#Eval("P3_Value") %>'></asp:Label></ItemTemplate>
                        
                            <ItemStyle HorizontalAlign="right" CssClass="gvFont" />
                        </asp:TemplateField>
                      
                        <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                            <ItemTemplate>
                                <asp:Label ID="lbl_P3_Percent" runat="server" Text='<%#Eval("P3_Percent") %>'></asp:Label>%</ItemTemplate>
                         
                            <ItemStyle HorizontalAlign="right" CssClass="gvFont"/>
                        </asp:TemplateField>
                     
                    </Columns>
               <RowStyle VerticalAlign="NotSet" />
                    <HeaderStyle BackColor="#0099FF" ForeColor="White" Height="5"/>
                    
                </asp:GridView>
     
     
      </td></tr>
        <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
           <tr>
        <td align="center">
            <table class="tblBorder" width="600px" cellpadding="0" cellspacing="0" style="font-size: 8.5pt;font-family: Verdana, Arial, haettenschweiler;  color:#000000;">
                <tr style="background-color:#0099FF; color:White; font-weight:bold">
                    <td align="right" >
                    </td>
                  
                     
                    <td align="right" >
                        FY<asp:Label ID="lblYear1P1" runat="server"  ></asp:Label>P
                    </td>
                    <td align="right" >
                        FY<asp:Label ID="lblYear1P2" runat="server"  ></asp:Label>P
                    </td>
                    <td align="right">
                        FY<asp:Label ID="lblYear1P3" runat="server"  ></asp:Label>P
                    </td>
                </tr>
                <tr class="FontStyle">
                 <td align="left"><asp:Label ID="lblSales1Name" runat="server"  ></asp:Label></td>
                 <td align="right"><asp:Label ID="lblSales1P1" runat="server"  ></asp:Label></td>
                 <td align="right"><asp:Label ID="lblSales1P2" runat="server"  ></asp:Label></td>
                 <td align="right"><asp:Label ID="lblSales1P3" runat="server"  ></asp:Label></td>
                
                
                </tr>
                <tr class="FontStyle">
                 <td align="left"><asp:Label ID="lblgp" runat="server"  ></asp:Label></td>
                 <td align="right"><asp:Label ID="lblgpP1" runat="server"  ></asp:Label></td>
                 <td align="right"><asp:Label ID="lblgpP2" runat="server"  ></asp:Label></td>
                 <td align="right"><asp:Label ID="lblgpP3" runat="server"  ></asp:Label></td>
                </tr>
             
            </table>
         
        </td>
    </tr>
        <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    
      
         <tr><td class="FontStyle">It is important to know the different dimensions of your business. It may be painful to track but if you have information on your sales and gross profit contribution derived from different activities, type of products and even the industries of your customers, you would be able to make informed decisions and look at how to direct your limited resources to focus on what matter most to your business.								
								
    </td></tr>
     
    
</table>
  
  </td>
  </tr>
  <tr><td>
  <table  Width="680" border="0" align="center" cellpadding="0" cellspacing="0" style="padding-left: 25px;">
    <tr>
        <td class="style1">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            <asp:Image ID="Image1" runat="server" Width="680" ImageUrl="~/images/breakeven.png" />
        </td>
    </tr>
    <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
       <tr><td class="FontStyle">Is your business generating sufficient sales to pay for the operating expenses and loan commitments? The sales surplus (or shortfall) for cash flow breakeven is illustrated below based on your projection for the next three years:  								
    
    </td></tr>
  
  <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
       <tr>
        <td align="center" >
            <table class="tblBorder" width="600px" cellpadding="0" cellspacing="0" style="font-size: 8.5pt;font-family: Verdana, Arial, haettenschweiler;  color:#000000;">
                <tr style="background-color:#0099FF; color:White; font-weight:bold">
                    <td style="width:300px" align="right" >
                    </td>
                    <td  style="width:100px" align="right" >
                        FY<asp:Label ID="Label1" runat="server"  ></asp:Label>P
                    </td>
                    <td style="width:100px" align="right">
                        FY<asp:Label ID="Label2" runat="server"  ></asp:Label>P
                    </td>
                    <td  style="width:100px" align="right">
                        FY<asp:Label ID="Label3" runat="server"  ></asp:Label>P
                    </td>
                </tr>
                <tr><td colspan="4" align="left" style="font-weight:bold">
                Minimum sales that your business needs to generate in order to
                </td></tr>
                <tr>
                <td align="left"> (i)   Pay for operating expenses</td>
                 <td align="right"><asp:Label ID="lblCoverFixedExpensesP1" runat="server"  ></asp:Label></td>
                 <td align="right" ><asp:Label ID="lblCoverFixedExpensesP2" runat="server"  ></asp:Label></td>
                 <td align="right"><asp:Label ID="lblCoverFixedExpensesP3" runat="server"  ></asp:Label></td>
                
                
                </tr>
                <tr>
                <td align="left">(ii)  Pay for interests</td>
                 <td align="right"><asp:Label ID="lblCoverInterestsP1" runat="server"  ></asp:Label></td>
                 <td align="right"><asp:Label ID="lblCoverInterestsP2" runat="server"  ></asp:Label></td>
                 <td align="right"><asp:Label ID="lblCoverInterestsP3" runat="server"  ></asp:Label></td>
                </tr>
                    <tr>
                <td align="left" >(iii) Pay loan instalments</td>
                 <td align="right" ><asp:Label ID="lblPrincipalPaymentsP1" runat="server"  ></asp:Label></td>
                 <td align="right"><asp:Label ID="lblPrincipalPaymentsP2" runat="server"  ></asp:Label></td>
                 <td align="right"><asp:Label ID="lblPrincipalPaymentsP3" runat="server"  ></asp:Label></td>
                </tr>
                   <tr style="background-color:#ccecff">
                <td align="left" style="background-color:#ccecff">(A) Minimum sales that your business <br />needs to generate for cash flow breakeven</td>
                 <td align="right"><asp:Label ID="lblbreakevenP1" runat="server"  ></asp:Label></td>
                 <td align="right"><asp:Label ID="lblbreakevenP2" runat="server"  ></asp:Label></td>
                 <td align="right"><asp:Label ID="lblbreakevenP3" runat="server"  ></asp:Label></td>
                </tr>
                <tr height="15"><td colspan="4"></td></tr>
                  <tr>
                <td align="left">(B) Your projected sales</td>
                 <td align="right"><asp:Label ID="lblTotalSalesP1" runat="server"  ></asp:Label></td>
                 <td align="right"><asp:Label ID="lblTotalSalesP2" runat="server"  ></asp:Label></td>
                 <td align="right"><asp:Label ID="lblTotalSalesP3" runat="server"  ></asp:Label></td>
                </tr>
                   <tr height="15"><td colspan="4"></td></tr>
                 <tr style="background-color:#ccecff">
                <td align="left" style="font-weight:bold; background-color:#ccecff">Surplus / (Shortfall) in sales to (A) - (B)<br /> achieve cash flow breakeven</td>
                 <td align="right"><asp:Label ID="lblSaleSurplusP1" runat="server"  ></asp:Label></td>
                 <td align="right"><asp:Label ID="lblSaleSurplusP2" runat="server"  ></asp:Label></td>
                 <td align="right"><asp:Label ID="lblSaleSurplusP3" runat="server"  ></asp:Label></td>
                </tr>
                 
            </table>
         
        </td>
    </tr>
       <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
           <tr><td class="FontStyle">Breakeven is one of the most important concepts in financial management. You need to know the minimum level of sales your business needs to generate in order cover operating costs. At breakeven sales level, your business does not make any profits. 								
    </td></tr>
    
         <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
           <tr><td class="FontStyle">Do bear in mind that the analysis is done on the basis that you would be able to maintain the same level of margins as you have projected. If you cut your price to bring in the sales, your margin will be affected and it will also mean that you would have to bring in even higher sales to breakeven.								
    </td></tr>
    
             <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
           <tr style="font-weight:bold; font-style:italic"><td class="FontStyle" >What does the surplus or shortfall in sales to achieve cash flow breakeven means?
    </td></tr>
      <tr><td class="FontStyle" >If you have a surplus (a <span style="font-weight:bold">positive</span> number) sales, your business is able to generate more cash than you need to cover operating expenses and loan commitments. 								
								

    </td></tr>
     <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
      <tr><td class="FontStyle" >Conversely, if your business has shortfall (a <span style="font-weight:bold">negative</span> number) in sales for cash flow breakeven, the projected sales is insufficient to generate enough margins to cover your operating costs and loan obligations.  In this situation, a business should find ways to:								

    </td></tr>
  
    <tr>
    <td>
    <table>
    <tr><td style="width:40px">&nbsp;</td><td class="FontStyle">(a) Increase sales and/or improving gross profit margin;</td></tr>
    <tr><td style="width:40px">&nbsp;</td><td class="FontStyle">(b) Reduce operating costs;</td></tr>
    <tr><td style="width:40px">&nbsp;</td><td class="FontStyle">(c) Restructure your loan facilities; or</td></tr>
    <tr><td style="width:40px">&nbsp;</td><td class="FontStyle">(d) Any combination of the above.</td></tr></table></td>
    
    </tr>
    
  
</table>
  </td></tr>
  <tr><td>
  <table  Width="680" border="0" align="center" cellpadding="0" cellspacing="0" style="padding-left: 25px;" class="FontStyle"  >
    <%--  <tr>
                    <td width="729" align="left" valign="top">
                        <h3 class="border_btm">
                            Working Capital
                        </h3>
                    </td>
                </tr>--%>
    <tr>
           <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            <asp:Image ID="Image2" runat="server" Width="680" ImageUrl="~/images/workingcaptialbar.png" />
        </td>
    </tr>
     
     <tr><td >Due to the different timing of activities in a business, it takes time to “turn” a sale into cash. For example, a business that sells on credit terms may need to wait a period of time until cash is finally collected. During the same period, payments need to be made to staff and creditors. So the “gap” between collecting cash and paying cash needs to be properly managed.									
    
    </td></tr>
       <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
      <tr><td  ><span style="font-weight:bold">Working Capital Days,</span> also known as <span style="font-weight:bold">Cash Conversion Cycle,</span> refers to the period of time in which resources are tied up in the business process before cash can be generated. It is an indication of the <span style="font-weight:bold">financing days</span> that you need for your trade. If your business have strong capital base or have generated sufficient past reserves, you may not need external financing.									
    
    </td></tr>
    <tr>
        <td align="center" valign="middle">
            <asp:Chart ID="CashConversion1_Chart" runat="server" BackColor="#D3DFF0" Width="600px"
                Visible="false" Height="450px" BorderColor="26, 59, 105" Palette="BrightPastel"
                BorderDashStyle="Solid" BackGradientStyle="TopBottom" BackSecondaryColor="White"
                BorderWidth="2" ImageType="Png" ImageLocation="~\TempImages\ChartPic_#SEQ(300,3)">
                <Titles>
                    <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                        Text="Cash Conversion Cycle and Working Capital Needs Analysis" ForeColor="26, 59, 105">
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
                    <asp:Series ChartArea="FinArea" Color="#9EDAEA" Name="Avg Stock Holdings Days" CustomProperties="DrawingStyle=Cylinder"
                        IsValueShownAsLabel="true" Legend="Legend1" Label="#SERIESNAME #VAL">
                    </asp:Series>
                    <asp:Series ChartArea="FinArea" CustomProperties="DrawingStyle=Cylinder" Color="#C2ECF6"
                        Name="Avg Collection Days" IsValueShownAsLabel="false" Legend="Legend1" Label="#SERIESNAME  #VAL">
                    </asp:Series>
                    <asp:Series ChartArea="FinArea" CustomProperties="DrawingStyle=Cylinder" Color="#FFEAE8"
                        Name="Avg Payment Days" Label="#SERIESNAME #VAL" IsValueShownAsLabel="false"
                        Legend="Legend1">
                    </asp:Series>
                    <asp:Series ChartArea="FinArea" CustomProperties="DrawingStyle=Cylinder" Color="#EA5656"
                        Name="Working Capital Days" Label="#SERIESNAME #VAL" IsValueShownAsLabel="true"
                        Legend="Legend1">
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
  <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td align="left" valign="top">
            <h4>
                Projection Years</h4>
        </td>
    </tr>
    <tr>
        <td align="center" valign="middle">
            <asp:Chart ID="CashConversion2_Chart" runat="server" BackColor="#D3DFF0" Width="600px"
                Height="450px" BorderColor="26, 59, 105" Palette="BrightPastel" BorderDashStyle="Solid"
                BackGradientStyle="TopBottom" BackSecondaryColor="White" BorderWidth="2" ImageType="Png"
                ImageLocation="~\TempImages\ChartPic_#SEQ(300,3)">
                <Titles>
                    <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                        Text="Cash Conversion Cycle and Working Capital Needs Analysis" ForeColor="26, 59, 105">
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
                        Name="Avg Stock Holdings Days" IsValueShownAsLabel="true" Legend="Legend1" Label="#SERIESNAME #VAL">
                    </asp:Series>
                    <asp:Series ChartArea="FinArea" CustomProperties="DrawingStyle=Cylinder" Color="#C2ECF6"
                        Name="Avg Collection Days" IsValueShownAsLabel="false" Legend="Legend1" Label="#SERIESNAME  #VAL">
                    </asp:Series>
                    <asp:Series ChartArea="FinArea" CustomProperties="DrawingStyle=Cylinder" Color="#FFEAE8"
                        Name="Avg Payment Days" Label="#SERIESNAME #VAL" IsValueShownAsLabel="false"
                        Legend="Legend1">
                    </asp:Series>
                    <asp:Series ChartArea="FinArea" CustomProperties="DrawingStyle=Cylinder" Color="#EA5656"
                        Name="Working Capital Days" Label="#SERIESNAME #VAL" IsValueShownAsLabel="true"
                        Legend="Legend1">
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
      <tr>
           <td class="spacer">
            &nbsp;
        </td>
    </tr>
 
       <tr>
        <td colspan="2" align="center">
            <table class="tblBorder" width="600px" cellpadding="0" cellspacing="0" style="font-size: 8.5pt;font-family: Verdana, Arial, haettenschweiler;  color:#000000;">
                <tr style="background-color:#0099FF; color:White; font-weight:bold">
                    <td style="width:300px"  >
                    </td>
                    <td style="width:150px" >
                     Period of financing
                    </td>
                    <td style="width:150px" >
                      Your resources tied in
                    </td>
                  
                </tr>
                <tr  >
                <td align="left"> Resources tied in Stocks</td>
                 <td align="center"><asp:Label ID="lblAvgPaymentDaysP1" runat="server"  ></asp:Label></td>
                 <td align="center"><asp:Label ID="lblAvgPaymentDaysP2" runat="server"  ></asp:Label></td>
              
                
                
                </tr>
                <tr  >
                <td align="left">Resources tied in Receivables</td>
                 <td align="center"><asp:Label ID="lblWorkingCapitalDaysP1" runat="server"  ></asp:Label></td>
                 <td align="center"><asp:Label ID="lblWorkingCapitalDaysP2" runat="server"  ></asp:Label></td>
               
                </tr>
                    <tr  >
                <td  align="left">Funding by Suppliers</td>
                 <td align="center" ><asp:Label ID="lblAvgStockHoldingDaysP1" runat="server"  ></asp:Label></td>
                 <td align="center" ><asp:Label ID="lblAvgStockHoldingDaysP2" runat="server"  ></asp:Label></td>
               
                </tr>
                 <tr  >
                <td align="left" >Funding by Suppliers</td>
                 <td align="center"><asp:Label ID="lblAvgCollectionDaysP1" runat="server"  ></asp:Label></td>
                 <td align="center"><asp:Label ID="lblAvgCollectionDaysP2" runat="server"  ></asp:Label></td>
             
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
        <td align="center">
            <table  class="tblBorder" width="600px" cellpadding="0" cellspacing="0" style="font-size: 8.5pt;font-family: Verdana, Arial, haettenschweiler;  color:#000000;">
                <tr style="background-color:#0099FF; color:White; font-weight:bold">
                    <td style="width:300px">
                    </td>
                    <td align="left" style="width:150px">
                     Period of financing
                    </td>
                    <td align="left" style="width:150px">
                      Your resources tied in
                    </td>
                  
                </tr>
                <tr   >
                <td align="left">  Avg Payment Days</td>
                 <td align="center"><asp:Label ID="lblAvgPaymentDays1P1" runat="server"  ></asp:Label></td>
                 <td align="center"><asp:Label ID="lblAvgPaymentDays1P2" runat="server"  ></asp:Label></td>
              
                
                
                </tr>
                <tr  >
                <td align="left">Working Capital Days</td>
                 <td align="center"><asp:Label ID="lblWorkingCapitalDays1P1" runat="server"  ></asp:Label></td>
                 <td align="center"><asp:Label ID="lblWorkingCapitalDays1P2" runat="server"  ></asp:Label></td>
               
                </tr>
                    <tr  >
                <td align="left" >Avg Stock Holding Days</td>
                 <td align="center" ><asp:Label ID="lblAvgStockHoldingDays1P1" runat="server"  ></asp:Label></td>
                 <td align="center" ><asp:Label ID="lblAvgStockHoldingDays1P2" runat="server"  ></asp:Label></td>
               
                </tr>
                 <tr  >
                <td align="left">Avg Collection Days</td>
                 <td align="center"><asp:Label ID="lblAvgCollectionDays1P1" runat="server"  ></asp:Label></td>
                 <td align="center"><asp:Label ID="lblAvgCollectionDays1P2" runat="server"  ></asp:Label></td>
             
                </tr>
                
            </table>
         
        </td>
    </tr>
  
   <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr><td   style="font-weight:bold;"><u>Your Most Recent Average Working Capital Days</u></td></tr>
    <tr><td  >You have an average Working Capital Days of 
        <asp:Label ID="lblCapital1Days" runat="server"></asp:Label>  Days.</td></tr>
    <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
     <tr><td   style="font-weight:bold;"><u>Your Projected Working Capital Days</u></td></tr>
    <tr><td  >You have an average Working Capital Days of  <asp:Label ID="lblCapital2Days" runat="server"></asp:Label>  
        Days.</td></tr>
    <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr><td><table width="90%">
    <tr>
    <td   colspan="2">The following assumptions are noted:-</td></tr>
    <tr><td  >(a) You have projected that your customers pay you faster by an average of <asp:Label ID="lblAverage1" runat="server"></asp:Label> Days.</td>
    <td align="center"><asp:Label ID="lbla" runat="server"></asp:Label></td>
    </tr>
        
    <tr>
    <td  width="80%">(b) Your stock holding days is projected to reduce by an average of <asp:Label ID="lblAverage2" runat="server"></asp:Label> Days.</td>
    <td align="center"><asp:Label ID="lblb" runat="server" ></asp:Label></td>
    </tr>
    <tr><td   width="80%">(c) You have assumed to pay your suppliers slower by an average of <asp:Label ID="lblAverage3" runat="server"></asp:Label> Days.</td>
    <td align="center" class="tdbottom" ><asp:Label ID="lblc" runat="server"></asp:Label></td>
    </tr>
      <tr><td   width="80%"> &nbsp;</td>
    <td align="center" class="tdbottom" ><asp:Label ID="lblABCTotal" runat="server"></asp:Label></td>
    </tr>
     </table></td> </tr>
      <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
      <tr><td   style="font-weight:bold; font-size:13px">Working Capital Requirements</td></tr>
      <tr><td   style="font-style:italic">The figures are expressed in SGD rounded to the nearest Thousand</td></tr>
     <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
          <tr><td  >The working capital requirements of your business are represented below:- </td></tr>
 
      <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
        <tr>
        <td align="center">
            <table class="tblBorder" width="600px" cellpadding="0" cellspacing="0" style="font-size: 8.5pt;font-family: Verdana, Arial, haettenschweiler;  color:#000000;">
                <tr  style="background-color:#0099FF; color:White; font-weight:bold">
                    <td style="width:300px" align="right">
                    </td>
                   
                    <td style="width:100px" align="right">
                        FY<asp:Label ID="Label4" runat="server"  ></asp:Label>P
                    </td>
                    <td style="width:100px" align="right">
                        FY<asp:Label ID="Label5" runat="server"  ></asp:Label>P
                    </td>
                    <td style="width:100px" align="right">
                        FY<asp:Label ID="Label6" runat="server"  ></asp:Label>P
                    </td>
                </tr>
                   <tr>
                <td align="left" style="width:300px">Resources tied in Stocks</td>
                 <td style="width:100px" align="right"><asp:Label ID="lblResourcesStocksP1" runat="server"  ></asp:Label></td>
                 <td style="width:100px" align="right"><asp:Label ID="lblResourcesStocksP2" runat="server"  ></asp:Label></td>
                 <td style="width:100px" align="right"><asp:Label ID="lblResourcesStocksP3" runat="server"  ></asp:Label></td>
               
                </tr>
                    <tr>
                <td align="left" style="width:300px" >Resources tied in Receivables</td>
                 <td style="width:100px" align="right" ><asp:Label ID="lblResourcesReceivablesP1" runat="server"  ></asp:Label></td>
                 <td style="width:100px" align="right"><asp:Label ID="lblResourcesReceivablesP2" runat="server"  ></asp:Label></td>
                 <td style="width:100px" align="right"><asp:Label ID="lblResourcesReceivablesP3" runat="server"  ></asp:Label></td>
               
                </tr>
                <tr >
                <td align="left" style="width:300px">Funding by Suppliers</td>
                 <td style="width:100px" align="right"><asp:Label ID="lblFundingP1" runat="server"  ></asp:Label></td>
                 <td style="width:100px" align="right"><asp:Label ID="lblFundingP2" runat="server"  ></asp:Label></td>
                 <td style="width:100px" align="right"><asp:Label ID="lblFundingP3" runat="server"  ></asp:Label></td>
                </tr>
                 <tr style="background-color:#ccecff">
                <td align="left" style="background-color:#ccecff; font-weight:bold; width:300px">Working Capital Needs of your business</td>
                 <td style="width:100px" align="right"><asp:Label ID="lblWorkingCapitalP1" runat="server"  ></asp:Label></td>
                 <td style="width:100px" align="right"><asp:Label ID="lblWorkingCapitalP2" runat="server"  ></asp:Label></td>
                 <td style="width:100px" align="right"><asp:Label ID="lblWorkingCapitalP3" runat="server"  ></asp:Label></td>
             
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
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr><td  >If your working capital needs is <b><u>negative</u></b> amount, it means that, on the average, your trade is self-financing and will be able to generate sufficient cash from the trade before payment to your suppliers. 									
									
									
</td></tr>
   <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
       <tr><td  >Conversely, if the working capital needs is <b><u>positive</u></b> amount, it means that, on the average, your business need more trade and alternative sources of financing. However, if there is sufficient capital base or you have built up strong cash reserves, you may not need external financing. 									
									
									

									
									
</td></tr>

  
</table>
  </td></tr>
  <tr><td>
  <table  Width="680" border="0" align="center" cellpadding="0" cellspacing="0" style="padding-left: 25px;">

    <tr>
           <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            <asp:Image ID="Image3" runat="server" Width="680" ImageUrl="~/images/cashflowbar.png" />
        </td>
    </tr>
    <tr>
        <td class="spacer">
            &nbsp;<asp:Label runat="server" ID="lbl" Visible="false" ></asp:Label>
        </td>
    </tr>
    <tr><td class="FontStyle">
    Cash is king and it is the most important element for survival of businesses. Understanding the cash flow requirement of your business and planning ahead is important so that you can take necessary actions on a timely basis. Based on the data that you have entered, the cash flow of your next 3 years are projected as follows: -							
							

    
    </td></tr>
      <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr><td>
    <table class="FontStyle" cellpadding="0" cellspacing="0" style="font-size: 8.5pt;font-family: Verdana, Arial, haettenschweiler;  color:#000000;">
    <tr  style="background-color:#0099FF; color:White; font-weight:bold" align="center" >
      <td style="width:301px" align="right"></td>
    <td style="width:83px" align="right"><asp:Label ID="Label7" runat="server" Text="Label"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="Label8" runat="server" Text="Label"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="Label9" runat="server" Text="Label"></asp:Label></td>
    </tr>
          <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr style=" font-weight:bold; background-color:#ccecff"">
    <td class="FontStyle">(A)  Net cash surplus/(shortfall) from operating activities</td>
    <td style="width:83px"  align="right"><asp:Label ID="lblOperatingActivitiesP1" runat="server"></asp:Label></td>
    <td style="width:83px"  align="right"><asp:Label ID="lblOperatingActivitiesP2" runat="server"></asp:Label></td>
    <td style="width:83px"  align="right"><asp:Label ID="lblOperatingActivitiesP3" runat="server"></asp:Label></td>
    
    </tr>
      <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
  
     <tr><td class="FontStyle" colspan="4">
   The net cash generated from operations refers to the cash generated by your business after taking into account the funding of the working capital as well as payment of operating expenses and taxes (if applicable). Please refer to <span style="color:Blue; font-style:italic">Appendix A</span>  for the details. If there is shortfall (negative amount) in the cash generated from operating activities, it means your operating business is consuming cash and therefore, you will need to look at ways to improve your profiability and shorten your cash conversion cycle. Find ways to collect faster from your customers and negotiate for longer credit terms to pay your suppliers or reduce the level of inventories (if applicable).							

    
    </td></tr>
      <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr  style=" font-weight:bold; background-color:#ccecff"" ><td>
    (B)  Net cash surplus/(shortfall) from financing & investing activities
    
    </td>
    <td style="width:83px" align="right"><asp:Label ID="lblInvestingActivitiesP1" runat="server"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblInvestingActivitiesP2" runat="server"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblInvestingActivitiesP3" runat="server"></asp:Label></td>
    </tr>
     <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
    <td class="FontStyle" style="width:301px"  align="left">You have planned capital expenditure amounting to</td>
    <td style="width:83px" align="right"><asp:Label ID="lblplannedP1" runat="server"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblplannedP2" runat="server"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblplannedP3" runat="server"></asp:Label></td>
    </tr>
      <tr>
    <td class="FontStyle" style="width:301px"  align="left">Of which you plan secure external funding of</td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblOfWhichP1" runat="server"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblOfWhichP2" runat="server"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblOfWhichP3" runat="server"></asp:Label></td>
    </tr>
     <tr>
    <td style="width:301px">(I) Balance amount will be funded internally generated resources</td>
    <td style="width:83px" align="right"><asp:Label ID="lblBalanceP1" runat="server"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblBalanceP2" runat="server"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblBalanceP3" runat="server"></asp:Label></td>
    </tr>
       <tr>
    <td style="width:301px">Your loan repayment commitments (Principal + Interests) <br />Repayment of existing loan/(s)</td>
    <td style="width:83px" align="right"><asp:Label ID="lblExistingP1" runat="server"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblExistingP2" runat="server"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblExistingP3" runat="server"></asp:Label></td>
    </tr>
    <tr>
    <td style="width:301px">Repayment of projected new loan/(s)</td>
    <td style="width:83px" align="right"><asp:Label ID="lblNewP1" runat="server"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblNewP2" runat="server"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblNewP3" runat="server"></asp:Label></td>
    </tr>
     <tr>
    <td style="width:301px">Interests on working capital loan <span style="color:Red">**</span></td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblInterestsP1" runat="server"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblInterestsP2" runat="server"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblInterestsP3" runat="server"></asp:Label></td>
    </tr>
       <tr>
    <td style="width:301px">(II) Total loan commitments</td>
    <td style="width:83px" align="right"><asp:Label ID="lblTotalloanP1" runat="server"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblTotalloanP2" runat="server"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblTotalloanP3" runat="server"></asp:Label></td>
    </tr>
       <tr>
    <td style="width:301px">(III) You are planning to raise new capital of</td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblRaiseNewP1" runat="server"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblRaiseNewP2" runat="server"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblRaiseNewP3" runat="server"></asp:Label></td>
    </tr>
         <tr style=" font-weight:bold;">
    <td style="width:301px;">Total cash inflow/(outflow) from financing and investing activities is the aggregate of (I) + (II) + (III) </td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblTotalcashP1" runat="server"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblTotalcashP2" runat="server"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblTotalcashP3" runat="server"></asp:Label></td>
    </tr>
        <tr>
    <td style=" color:Red; font-style:italic" colspan="4">** It is assumed that there is no change in the working capital loan during the projection period. </td>

    </tr>
       <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr  style=" font-weight:bold; background-color:#ccecff; width:301px"><td>(C) Total net cash surplus/(shortfall) generated in the period&nbsp;       (A) + (B)</td>
    <td style="width:83px" align="right"><asp:Label ID="lblNetCashP1" runat="server"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblNetCashP2" runat="server"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblNetCashP3" runat="server"></asp:Label></td
    
    </tr>
      <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr><td colspan="4">
    
    This refers to the total cash that your business generates in each of the projection periods. If the amount is positive, your business is generating positive cash and will add on to your cash reserves. If the amount is negative, it means your business activities is not generating postive cash flow and will deplete your cash reserves.							
							
							

    </td></tr>
      <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr  style=" font-weight:bold;  background-color:#ccecff; width:301px"><td>(D) Cash Balance as at the end of period</td>
        <td style="width:83px" align="right"><asp:Label ID="lblCashBalanceP1" runat="server"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblCashBalanceP2" runat="server"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblCashBalanceP3" runat="server"></asp:Label></td
    
    </tr>
      <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr><td colspan="4">
    This refers to the cash balance as at the end of each of the projection periods. This is computed by adding the beginning cash balance of the period to the net cash surplus/(shortfall) for the period.							
							

    </td></tr>
     <tr><td style="width:301px">Cash balance as at the beginnig of period</td>
        <td style="width:83px" align="right"><asp:Label ID="lblCashBalP1" runat="server"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblCashBalP2" runat="server"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblCashBalP3" runat="server"></asp:Label></td
    
    </tr>
      <tr><td style="width:301px">Add : (C) Total net cash surplus/(shortfall) for the period</td>
        <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblTotelNetCashP1" runat="server"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblTotelNetCashP2" runat="server"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblTotelNetCashP3" runat="server"></asp:Label></td
    
    </tr>
      <tr><td style=" font-weight:bold; width:301px">Cash balance as at the end of period</td>
        <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblCashBal1P1" runat="server"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblCashBal1P2" runat="server"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblCashBal1P3" runat="server"></asp:Label></td
    
    </tr>
           <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
      <tr  style=" font-weight:bold; background-color:#ccecff; width:301px"><td>(E) Headroom surplus/(shortfall)</td>
        <td style="width:83px" align="right"><asp:Label ID="lblHeadroomSurplusP1" runat="server"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblHeadroomSurplusP2" runat="server"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblHeadroomSurplusP3" runat="server"></asp:Label></td
    
    </tr>
      <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
      <tr><td style="width:301px">Cash balance as at the end of period</td>
        <td style="width:83px" align="right"><asp:Label ID="lblCashBalance1P1" runat="server"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblCashBalance1P2" runat="server"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblCashBalance1P3" runat="server"></asp:Label></td
    
    </tr>
      <tr><td style="width:301px">Add : Unutilised credit facilities</td>
        <td style="width:83px" align="right"><asp:Label ID="lblUnutilisedP1" runat="server"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblUnutilisedP2" runat="server"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblUnutilisedP3" runat="server"></asp:Label></td
    
    </tr>
      <tr><td style="width:301px">Less : Restricted Cash (Cash Pledged to Bank/(s))</td>
        <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblRestrictedP1" runat="server"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblRestrictedP2" runat="server"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblRestrictedP3" runat="server"></asp:Label></td
    
    </tr>
      <tr  style=" font-weight:bold" style="width:301px"><td>Headroom Surplus/(Shortfall)</td>
        <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblHeadroomP1" runat="server"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblHeadroomP2" runat="server"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblHeadroomP3" runat="server"></asp:Label></td
    
    </tr>
     <tr>
           <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr><td colspan="4">
    
    This represents the free cash reserves (excluding cash that may be pledged to the banks / financial institutions as collateral for your credit facilities) and unutilised credit facilities that are available as at the end of each of the projection periods. If this is surplus (<b>positive</b> amount), it means you have sufficient cash reserves and credit facilities (after excluding the pledged cash) to fund your business needs. 

        <br />
        <br />
        If it is shortfall (<b>negative</b> amount), it means even you have exhausted all the cash reserves and utilised the credit facilities in full, there is still insufficient cash to fund your projected activities.  You are likely to experience strain in your cash flow. Therefore, you may like to consider (a) raising more debt and/or equity if your business is viable, i.e. you are expecting to record profitability and your balance sheet is relatively healthy; and (b) look into areas of improving your working capital management and profitability.						
							
							
							
							
							
							

    </td></tr>
      </table>
    </td></tr>
       <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
 
     

</table>
  </td></tr>
  <tr><td>
  <table  Width="680" border="0" align="center" cellpadding="0" cellspacing="0" style="padding-left: 25px;">
  <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            <asp:Image ID="Image4" runat="server" Width="680" ImageUrl="~/images/fundingbar.png" />
        </td>
    </tr>
   
    <tr>
        <td class="spacer">
            &nbsp;<asp:Label runat="server" ID="Label10" Visible="false" ></asp:Label>
        </td>
    </tr>
    <tr>
    <td  class="FontStyle">
    If your business is partially funded by borrowings from financial institution/(s), it is important that you watch your gearing ratio that measures your business' reliance on bank loans.							
							

    
    </td>
    </tr>
     <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:GridView ID="gvReport" runat="server" ShowHeader="true"  
                CssClass="gridStyle" Width="600px" GridLines="None"
                AutoGenerateColumns="false" onrowdatabound="gvReport_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="left">
                            <ItemTemplate>
                                <asp:Label ID="lblFsMappingName" runat="server" Text='<%#Eval("FsMappingName")%>'></asp:Label>
                            </ItemTemplate>
                              <ItemStyle HorizontalAlign="left"  Width="300px"/>
                        </asp:TemplateField>
                      
                       
                        <asp:TemplateField HeaderStyle-HorizontalAlign="right" >
                            <ItemTemplate>
                                <asp:Label ID="lbl_P1_Value" runat="server" Text='<%#Eval("P1_Value")%>'></asp:Label>
                            </ItemTemplate>
                        
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                            <ItemTemplate>
                                <asp:Label ID="lbl_P2_Value" runat="server" Text='<%#Eval("P2_Value") %>'></asp:Label></ItemTemplate>
                        
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:TemplateField>
                      
                        <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                            <ItemTemplate>
                                <asp:Label ID="lbl_P3_Value" runat="server" Text='<%#Eval("P3_Value") %>'></asp:Label></ItemTemplate>
                       
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:TemplateField>
                     
                    </Columns>
                    
                <HeaderStyle BackColor="#0099FF" ForeColor="White" Height="3"/>
            </asp:GridView>
        </td>
    </tr>
    
       <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
    <td  class="FontStyle">
        Net Gearing Ratio refers to<br />
(A) the proportion of funding that is provided by bank(s) and/or financial institution(s) net of cash (assuming the cash can be applied to pay down the loan) <br />
RELATIVE TO<br />
(B) the funding provided by business owner(s) which includes past earnings and advances by the owner(s) to the business, net of past losses and <br /> 
        advances taken out of the business by the owner(s).							
							

    </td>
    </tr>
    
     <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr><td  class="FontStyle">
    For example, if the Net Gearing Ratio is 0.8 times, it means that for every $1 that the business owner(s) have invested in the business, the bank is providing $0.80 loan to the business. As a rule of thumb, unless you have good collaterals to pledge to the bank(s) and/or financial institution(s), a gearng ratio of below 1 time is generally acceptable. 							
    
    </td></tr>
     <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr><td  class="FontStyle">
   If the net gearing ratio is 'Nil", you either do not have bank loan or you have sufficient cash to make full settlement of the loan.							

    
    </td></tr>
      <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr><td  class="FontStyle">
 If the Net Gearing Ratio is <span style=" font-weight:bold;"><u>negative</u></span> amount, it means whatever sum you have injected into the business has been depleted and the bank(s) and/or financial institution(s) is the financier of your business. Your bank(s) and/or financial institution(s) is likely to be very concerned and may take action to address the risk of default.							
							
    </td></tr>
 
</table>
  </td></tr>
  <tr><td>
  <table  Width="680" border="0" align="center" cellpadding="0" cellspacing="0" style="padding-left: 25px;">
    <tr>
       <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Image ID="Image5" runat="server" Width="680" ImageUrl="~/images/appendixbar.png" />
        </td>
    </tr>
    <tr>
   
         <td align="left" valign="bottom" >
                        <h3>
                            Income Sheet</h3>
                    </td>
        
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvIncomeReport" runat="server" ShowHeader="true"  width="680"
                AutoGenerateColumns="false"  CssClass="gridStyle" GridLines="None" onrowdatabound="gvIncomeReport_RowDataBound"
             >
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblFsMappingName" runat="server" Text='<%#Eval("FsMappingName")%>'></asp:Label>
                        </ItemTemplate>
                         <ItemStyle HorizontalAlign="left" Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:Label ID="lbl_C_Value" runat="server" Text='<%#Eval("C_Value")%>'></asp:Label>
                        </ItemTemplate>
                           <ItemStyle HorizontalAlign="right" Width="90px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="right" HeaderText="% of Sale">
                        <ItemTemplate>
                            <asp:Label ID="lbl_C_Percent" runat="server" Text='<%#Eval("C_Percent")%>'></asp:Label>%</ItemTemplate>
                   
                        <ItemStyle HorizontalAlign="right" Width="50px"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P1_Value" runat="server" Text='<%#Eval("P1_Value")%>'></asp:Label>
                        </ItemTemplate>
                       
                        <ItemStyle HorizontalAlign="right" Width="90px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="right" HeaderText="% of Sale">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P1_Percent" runat="server" Text='<%#Eval("P1_Percent")%>'></asp:Label>%</ItemTemplate>
                    
                        <ItemStyle HorizontalAlign="right" Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P2_Value" runat="server" Text='<%#Eval("P2_Value") %>'></asp:Label></ItemTemplate>
                    
                        <ItemStyle HorizontalAlign="right" Width="90px"/>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="right" HeaderText="% of Sale">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P2_Percent" runat="server" Text='<%#Eval("P2_Percent")%>'></asp:Label>%</ItemTemplate>
                   
                        <ItemStyle HorizontalAlign="right" Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P3_Value" runat="server" Text='<%#Eval("P3_Value") %>'></asp:Label></ItemTemplate>
                   
                        <ItemStyle HorizontalAlign="right" Width="90px"/>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="right" HeaderText="% of Sale">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P3_Percent" runat="server" Text='<%#Eval("P3_Percent")%>'></asp:Label>%</ItemTemplate>
                    
                        <ItemStyle HorizontalAlign="right" Width="50px"/>
                    </asp:TemplateField>
                </Columns>
                  <HeaderStyle BackColor="#376091" ForeColor="White" Height="5"/>
            </asp:GridView>
        </td>
    </tr>
      <tr>
        <td align="left" valign="bottom">
                        <h3>
                            Balance Sheet</h3>
                    </td>
    </tr>
    <tr>
        <td class="FontStyle">
            <asp:GridView ID="gvBalanceReport" runat="server" ShowHeader="true" width="680"
                AutoGenerateColumns="false"  CssClass="gridStyle" GridLines="None" onrowdatabound="gvBalanceReport_RowDataBound"
               >
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblFsMappingName" runat="server" Text='<%#Eval("FsMappingName")%>'></asp:Label>
                        </ItemTemplate>
                           <ItemStyle HorizontalAlign="left" Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:Label ID="lbl_C_Value" runat="server" Text='<%#Eval("C_Value")%>'></asp:Label>
                        </ItemTemplate>
                           <ItemStyle HorizontalAlign="right" Width="90px" />
                    </asp:TemplateField>
               <%--     <asp:TemplateField HeaderStyle-HorizontalAlign="right" HeaderText="% of Sale">
                        <ItemTemplate>
                            <asp:Label ID="lbl_C_Percent" runat="server" Text='<%#Eval("C_Percent")%>'></asp:Label></ItemTemplate>
                        
                        <ItemStyle HorizontalAlign="right" Width="50px" />
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P1_Value" runat="server" Text='<%#Eval("P1_Value")%>'></asp:Label>
                        </ItemTemplate>
                        
                       <ItemStyle HorizontalAlign="right" Width="90px" />
                    </asp:TemplateField>
                 <%--   <asp:TemplateField HeaderStyle-HorizontalAlign="right" HeaderText="% of Sale">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P1_Percent" runat="server" Text='<%#Eval("P1_Percent")%>'></asp:Label></ItemTemplate>
                        
                        <ItemStyle HorizontalAlign="right" Width="50px" />
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P2_Value" runat="server" Text='<%#Eval("P2_Value") %>'></asp:Label></ItemTemplate>
                        
                          <ItemStyle HorizontalAlign="right" Width="90px" />
                    </asp:TemplateField>
                 <%--   <asp:TemplateField HeaderStyle-HorizontalAlign="right" HeaderText="% of Sale">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P2_Percent" runat="server" Text='<%#Eval("P2_Percent")%>'></asp:Label></ItemTemplate>
                        
                        <ItemStyle HorizontalAlign="right" Width="50px" />
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P3_Value" runat="server" Text='<%#Eval("P3_Value") %>'></asp:Label></ItemTemplate>
                        
                       <ItemStyle HorizontalAlign="right" Width="90px" />
                    </asp:TemplateField>
               <%--     <asp:TemplateField HeaderStyle-HorizontalAlign="right" HeaderText="% of Sale">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P3_Percent" runat="server" Text='<%#Eval("P3_Percent")%>'></asp:Label></ItemTemplate>
                        
                      <ItemStyle HorizontalAlign="right" Width="50px" />
                    </asp:TemplateField>--%>
                </Columns>
                <HeaderStyle BackColor="#376091" ForeColor="White" Height="5"/>
            </asp:GridView>
        </td>
    </tr>
    <tr>  <td class="spacer">
            &nbsp;
        </td></tr>
     <tr>
      
         <td align="left" valign="bottom">
                        <h3>  Cash Flow Analysis</h3>
                    </td>
    </tr>
    <tr>
        <td class="FontStyle">
            <asp:GridView ID="gvCashFlowAnalysisReport" runat="server" ShowHeader="true"  width="680"
                AutoGenerateColumns="false"  CssClass="gridStyle" GridLines="None" onrowdatabound="gvCashFlowAnalysisReport_RowDataBound"
                >
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblFsMappingName" runat="server" Text='<%#Eval("FsMappingName")%>'></asp:Label>
                        </ItemTemplate>
                           <ItemStyle HorizontalAlign="left" Width="200px" />
                    </asp:TemplateField>
                 <%--   <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:Label ID="lbl_C_Value" runat="server" Text='<%#Eval("C_Value")%>'></asp:Label>
                        </ItemTemplate>
                           <ItemStyle HorizontalAlign="right" Width="90px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="right" HeaderText="% of Sale">
                        <ItemTemplate>
                            <asp:Label ID="lbl_C_Percent" runat="server" Text='<%#Eval("C_Percent")%>'></asp:Label></ItemTemplate>
                        
                       <ItemStyle HorizontalAlign="right" Width="50px" />
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P1_Value" runat="server" Text='<%#Eval("P1_Value")%>'></asp:Label>
                        </ItemTemplate>
                        
                         <ItemStyle HorizontalAlign="right" Width="90px" />
                    </asp:TemplateField>
                 <%--   <asp:TemplateField HeaderStyle-HorizontalAlign="right" HeaderText="% of Sale">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P1_Percent" runat="server" Text='<%#Eval("P1_Percent")%>'></asp:Label></ItemTemplate>
                        
                          <ItemStyle HorizontalAlign="right" Width="50px" />
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P2_Value" runat="server" Text='<%#Eval("P2_Value") %>'></asp:Label></ItemTemplate>
                        
                       <ItemStyle HorizontalAlign="right" Width="90px" />
                    </asp:TemplateField>
                 <%--   <asp:TemplateField HeaderStyle-HorizontalAlign="right" HeaderText="% of Sale">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P2_Percent" runat="server" Text='<%#Eval("P2_Percent")%>'></asp:Label></ItemTemplate>
                        
                        <ItemStyle HorizontalAlign="right" Width="50px" />
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="right">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P3_Value" runat="server" Text='<%#Eval("P3_Value") %>'></asp:Label></ItemTemplate>
                        
                        <ItemStyle HorizontalAlign="right" Width="90px" />
                    </asp:TemplateField>
                  <%--  <asp:TemplateField HeaderStyle-HorizontalAlign="right" HeaderText="% of Sale">
                        <ItemTemplate>
                            <asp:Label ID="lbl_P3_Percent" runat="server" Text='<%#Eval("P3_Percent")%>'></asp:Label></ItemTemplate>
                        
                         <ItemStyle HorizontalAlign="right" Width="50px" />
                    </asp:TemplateField>--%>
                </Columns>
                 <HeaderStyle BackColor="#376091" ForeColor="White" Height="5"/>
            </asp:GridView>
        </td>
    </tr>
       <tr>  <td class="spacer">
            &nbsp;
        </td></tr>
    <tr id="trTradeCycle" runat="server">
        <td>
            <table>
                <tr>
                    <td align="left" valign="top">
                        <h3>
                            Trade Cycle</h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="680" border="0" align="center" cellpadding="3" cellspacing="0" class="FontStyle">
                            <tr style="background-color:#376091; color:White; font-weight:bold">
                                <td width="141" height="35">
                                    Days
                                </td>
                                <td width="201">
                                    Cumulative Days
                                </td>
                                <td width="237">
                                    Trade Cycle
                                </td>
                                <td width="68">
                                    &nbsp;
                                </td>
                                <td width="197" colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td align="center">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDay1" runat="server" Text="0" />
                                    &nbsp;days
                                </td>
                                <td>
                                    <asp:Label ID="lblCDay1" runat="server" />
                                    &nbsp;days
                                </td>
                                <td height="30" align="center" class="blue-border">
                                    Place Order with Supplier
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td align="center">
                                    <img src="../images/arrow_bottom.png" width="18" height="27" alt="" />
                                </td>
                                <td align="center" valign="bottom">
                                    <asp:Label ID="lblCDay7" runat="server" />
                                    &nbsp;days
                                </td>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDay2" runat="server" />
                                    &nbsp;days
                                </td>
                                <td>
                                    <asp:Label ID="lblCDay2" runat="server" />
                                    &nbsp;days
                                </td>
                                <td height="30" align="center" class="blue-border">
                                    Goods shipped by Supplier
                                </td>
                                <td align="center">
                                    <img src="../images/arrow_right_new.png" height="17" alt="" />
                                </td>
                                <td height="30" align="center" class="blue-border">
                                    Payment to Supplier
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td align="center">
                                    <img src="../images/arrow_bottom.png" width="18" height="27" alt="" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDay3" runat="server" />
                                    &nbsp;days
                                </td>
                                <td>
                                    <asp:Label ID="lblCDay3" runat="server" />
                                    &nbsp;days
                                </td>
                                <td height="30" align="center" class="blue-border">
                                    Receipt of Goods by you
                                </td>
                                <td colspan="3" rowspan="7">
                                    <table width="150" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="26">
                                                <img src="../images//line.jpg" width="26" height="1" alt="" />
                                            </td>
                                            <td width="15" rowspan="3" style="border-left: 1px solid #376091;">
                                                &nbsp;
                                            </td>
                                            <td width="109" rowspan="3">
                                                <table border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td>
                                                            <img src="../images/arrow_right.png" width="26" height="17" alt="" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCDay8" runat="server" />
                                                            &nbsp;days
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="225">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <img src="../images//line.jpg" width="26" height="1" alt="" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td align="center">
                                    <img src="../images/arrow_bottom.png" width="18" height="27" alt="" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDay4" runat="server" />
                                    &nbsp;days
                                </td>
                                <td>
                                    <asp:Label ID="lblCDay4" runat="server" />
                                    &nbsp;days
                                </td>
                                <td align="center" class="blue-border">
                                    Processing<br />
                                    (Manufacturing / Assembly / Packing)
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td align="center">
                                    <img src="../images/arrow_bottom.png" width="18" height="27" alt="" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDay5" runat="server" />
                                    &nbsp;days
                                </td>
                                <td>
                                    <asp:Label ID="lblCDay5" runat="server" />
                                    &nbsp;days
                                </td>
                                <td align="center" class="blue-border">
                                    Delivery of goods to
                                    <br />
                                    Customer / Billing
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td align="center">
                                    <img src="../images/arrow_bottom.png" width="18" height="27" alt="" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDay6" runat="server" />
                                    &nbsp;days
                                </td>
                                <td>
                                    <asp:Label ID="lblCDay6" runat="server" />
                                    &nbsp;days
                                </td>
                                <td height="30" align="center" class="blue-border">
                                    Receipts from Customer
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
                    <td class="FontStyle">
                        Trade cycle is the time that it takes to process a trade from start to end.<br />
                        <br />
                        The trade starts when you place an order and ends when you receive payment from
                        your customers and when you pay your supplier, whichever is later.<br />
                        <br />
                        Your average trade cycle days is approximately 23 days.<br />
                        <br />
                        The average financing period required for your business is approximately 23 days.<br />
                        <br />
                        If your customers require you to issue letter of credit at the point of payment
                        or you need to stock up to shorten lead time of purchases, your financing period
                        increase by 5 Days.<br />
                        <br />
                        <span style="color:#FF0000"><b>Important To Note</b> </span>:<br />
                        <br />
                        The calculation is made based on information provided by you and is for indicative
                        purposes only.
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
  </td></tr>
  </table>
  
    </form>
</body>
</html>
