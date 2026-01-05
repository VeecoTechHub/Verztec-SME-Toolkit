<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CashFlow.ascx.cs" Inherits="UserControls_CashFlow" %>

<table width="90%" border="0" align="center" cellpadding="0" cellspacing="0" style="padding-left: 25px;">


    <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="cashflow">
        
        <asp:Label ID="lblHeading" runat="server" Text="Cash flow Analysis" 
                meta:resourcekey="lblHeadingResource1"></asp:Label>
            <%--<asp:Image ID="imgHeader" runat="server" Width="680" ImageUrl="~/images/cashflowbar.png" />--%>
        </td>
    </tr>
    <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr><td class="FontStyle" style="text-align:justify">
    <asp:Localize ID="locPara1" runat="server" 
            Text="
    Cash is king and it is the most important element for survival of businesses. Understanding the cash flow requirement 
    of your business and planning ahead is important so that you can take necessary actions on a timely basis. Based on the
     data that you have entered, the cash flow of your next 3 years are projected as follows: -" 
            meta:resourcekey="locPara1Resource1"></asp:Localize>							
							

    
    </td></tr>
      <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr><td>
    <table class="FontStyle" cellpadding="0" cellspacing="0" style="font-size: 8.5pt; font-family: Verdana, Arial, haettenschweiler;  color:#000000; width:650px">
    <tr  style="background-color:#0099FF; color:White; font-weight:bold" align="center" >
      <td style="width:301px" align="right"></td>
    <td style="width:83px" align="center"><asp:Label ID="lblYearP1" runat="server" 
            Text="Label" meta:resourcekey="lblYearP1Resource1"></asp:Label></td>
    <td style="width:83px" align="center"><asp:Label ID="lblYearP2" runat="server" 
            Text="Label" meta:resourcekey="lblYearP2Resource1"></asp:Label></td>
    <td style="width:83px" align="center"><asp:Label ID="lblYearP3" runat="server" 
            Text="Label" meta:resourcekey="lblYearP3Resource1"></asp:Label></td>
    </tr>
          <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr style=" font-weight:bold; background-color:#ccecff"">
    <td class="FontStyle">
        <asp:Label ID="lblcashsurplus" runat="server" 
            Text="(A)  Net cash surplus/(shortfall) from operating activities" 
            meta:resourcekey="lblcashsurplusResource1"></asp:Label>
    </td>
    <td style="width:83px"  align="right"><asp:Label ID="lblOperatingActivitiesP1" 
            runat="server" meta:resourcekey="lblOperatingActivitiesP1Resource1"></asp:Label></td>
    <td style="width:83px"  align="right"><asp:Label ID="lblOperatingActivitiesP2" 
            runat="server" meta:resourcekey="lblOperatingActivitiesP2Resource1"></asp:Label></td>
    <td style="width:83px"  align="right"><asp:Label ID="lblOperatingActivitiesP3" 
            runat="server" meta:resourcekey="lblOperatingActivitiesP3Resource1"></asp:Label></td>
    
    </tr>
      <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
  
     <tr><td class="FontStyle" colspan="4" style="text-align:justify">
     <asp:Localize ID="locPara2" runat="server" 
             
             meta:resourcekey="locPara2Resource1"></asp:Localize>			 

   		 				

    
    </td></tr>
      <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr  style=" font-weight:bold; background-color:#ccecff"" ><td>
        <asp:Label ID="lbl2cashsurplus" runat="server" 
            Text="(B)  Net cash surplus/(shortfall) from financing & investing activities" 
            meta:resourcekey="lbl2cashsurplusResource1"></asp:Label>
    </td>
    <td style="width:83px" align="right"><asp:Label ID="lblInvestingActivitiesP1" 
            runat="server" meta:resourcekey="lblInvestingActivitiesP1Resource1"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblInvestingActivitiesP2" 
            runat="server" meta:resourcekey="lblInvestingActivitiesP2Resource1"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblInvestingActivitiesP3" 
            runat="server" meta:resourcekey="lblInvestingActivitiesP3Resource1"></asp:Label></td>
    </tr>
     <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
    <td class="FontStyle" style="width:301px"  align="left">
        <asp:Label ID="lblYouhaveplanned" runat="server" 
            Text="You have planned capital expenditure amounting to" 
            meta:resourcekey="lblYouhaveplannedResource1"></asp:Label>
    </td>
    <td style="width:83px" align="right"><asp:Label ID="lblplannedP1" runat="server" 
            meta:resourcekey="lblplannedP1Resource1"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblplannedP2" runat="server" 
            meta:resourcekey="lblplannedP2Resource1"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblplannedP3" runat="server" 
            meta:resourcekey="lblplannedP3Resource1"></asp:Label></td>
    </tr>
      <tr>
    <td class="FontStyle" style="width:301px"  align="left">
    <asp:Label ID="lblOfWhich" runat="server" 
            Text="Of which you plan secure external funding of" 
            meta:resourcekey="lblOfWhichResource1"></asp:Label>
    </td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblOfWhichP1" 
            runat="server" meta:resourcekey="lblOfWhichP1Resource1"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblOfWhichP2" 
            runat="server" meta:resourcekey="lblOfWhichP2Resource1"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblOfWhichP3" 
            runat="server" meta:resourcekey="lblOfWhichP3Resource1"></asp:Label></td>
    </tr>
     <tr>
    <td style="width:301px">
     <asp:Label ID="lblBalanceamount" runat="server" 
            Text="(I) Balance amount will be funded by internally generated resources" 
            meta:resourcekey="lblBalanceamountResource1"></asp:Label>
    </td>
    <td style="width:83px" align="right"><asp:Label ID="lblBalanceP1" runat="server" 
            meta:resourcekey="lblBalanceP1Resource1"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblBalanceP2" runat="server" 
            meta:resourcekey="lblBalanceP2Resource1"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblBalanceP3" runat="server" 
            meta:resourcekey="lblBalanceP3Resource1"></asp:Label></td>
    </tr>
    <tr><td colspan="4">
        <asp:Label ID="lblrepaymentcommitments" runat="server" 
            Text="Your loan repayment commitments (Principal + Interests)" 
            meta:resourcekey="lblrepaymentcommitmentsResource1"></asp:Label>
    
    </td></tr>
       <tr>
    <td style="width:301px">
        <asp:Label ID="lblexisting" runat="server" 
            Text="Repayment of existing loan/(s)" meta:resourcekey="lblexistingResource1"></asp:Label>
    </td>
    <td style="width:83px; vertical-align:bottom" align="right">
        <asp:Label ID="lblExistingP1" runat="server" 
            meta:resourcekey="lblExistingP1Resource1"></asp:Label></td>
    <td style="width:83px; vertical-align:bottom" align="right">
        <asp:Label ID="lblExistingP2" runat="server" 
            meta:resourcekey="lblExistingP2Resource1"></asp:Label></td>
    <td style="width:83px; vertical-align:bottom" align="right">
        <asp:Label ID="lblExistingP3" runat="server" 
            meta:resourcekey="lblExistingP3Resource1"></asp:Label></td>
    </tr>
    <tr>
    <td style="width:301px">
     <asp:Label ID="lblprojected" runat="server" 
            Text="Repayment of projected new loan/(s)" 
            meta:resourcekey="lblprojectedResource1"></asp:Label>
    </td>
    <td style="width:83px" align="right"><asp:Label ID="lblNewP1" runat="server" 
            meta:resourcekey="lblNewP1Resource1"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblNewP2" runat="server" 
            meta:resourcekey="lblNewP2Resource1"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblNewP3" runat="server" 
            meta:resourcekey="lblNewP3Resource1"></asp:Label></td>
    </tr>
     <tr>
    <td style="width:301px">
     <asp:Label ID="lblworkingcapitalloan" runat="server" 
            Text="Interests on working capital loan" 
            meta:resourcekey="lblworkingcapitalloanResource1"></asp:Label>
     <span style="color:Red">**</span></td>
    <td style="width:83px" align="right" class="tdbottom">
        <asp:Label ID="lblInterestsP1" runat="server" 
            meta:resourcekey="lblInterestsP1Resource1"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom">
        <asp:Label ID="lblInterestsP2" runat="server" 
            meta:resourcekey="lblInterestsP2Resource1"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom">
        <asp:Label ID="lblInterestsP3" runat="server" 
            meta:resourcekey="lblInterestsP3Resource1"></asp:Label></td>
    </tr>
       <tr>
    <td style="width:301px">
     <asp:Label ID="lblloancommitments" runat="server" 
            Text="(II) Total loan commitments" 
            meta:resourcekey="lblloancommitmentsResource1"></asp:Label>
    </td>
    <td style="width:83px" align="right"><asp:Label ID="lblTotalloanP1" runat="server" 
            meta:resourcekey="lblTotalloanP1Resource1"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblTotalloanP2" runat="server" 
            meta:resourcekey="lblTotalloanP2Resource1"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblTotalloanP3" runat="server" 
            meta:resourcekey="lblTotalloanP3Resource1"></asp:Label></td>
    </tr>
       <tr>
    <td style="width:301px">
     <asp:Label ID="lblplanningtoraise" runat="server" 
            Text="(III) You are planning to raise new capital of" 
            meta:resourcekey="lblplanningtoraiseResource1"></asp:Label>
    </td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblRaiseNewP1" 
            runat="server" meta:resourcekey="lblRaiseNewP1Resource1"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblRaiseNewP2" 
            runat="server" meta:resourcekey="lblRaiseNewP2Resource1"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblRaiseNewP3" 
            runat="server" meta:resourcekey="lblRaiseNewP3Resource1"></asp:Label></td>
    </tr>
         <tr style=" font-weight:bold;">
    <td style="width:301px;">
     <asp:Label ID="lbloutflow" runat="server" 
            Text="Total cash inflow/(outflow) from financing and investing activities is the aggregate of (I) + (II) + (III)" 
            meta:resourcekey="lbloutflowResource1"></asp:Label>
     </td>
    <td style="width:83px" align="right" class="tdbottom">
        <asp:Label ID="lblTotalcashP1" runat="server" 
            meta:resourcekey="lblTotalcashP1Resource1"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom">
        <asp:Label ID="lblTotalcashP2" runat="server" 
            meta:resourcekey="lblTotalcashP2Resource1"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom">
        <asp:Label ID="lblTotalcashP3" runat="server" 
            meta:resourcekey="lblTotalcashP3Resource1"></asp:Label></td>
    </tr>
        <tr>
    <td style=" color:Red; font-style:italic" colspan="4">
        <asp:Label ID="lblassumed" runat="server" 
            Text="** It is assumed that there is no change in the working capital loan during the projection period." 
            meta:resourcekey="lblassumedResource1"></asp:Label>
    </td>

    </tr>
       <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr  style=" font-weight:bold; background-color:#ccecff; width:301px"><td>
        <asp:Label ID="lblTotalnetcash" runat="server" 
            Text="(C) Total net cash surplus/(shortfall) generated in the period" 
            meta:resourcekey="lblTotalnetcashResource1"></asp:Label>
    &nbsp;       
        <asp:Label ID="lblAB" runat="server" Text="(A) + (B)" 
            meta:resourcekey="lblABResource1"></asp:Label>
    </td>
    <td style="width:83px" align="right"><asp:Label ID="lblNetCashP1" runat="server" 
            meta:resourcekey="lblNetCashP1Resource1"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblNetCashP2" runat="server" 
            meta:resourcekey="lblNetCashP2Resource1"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblNetCashP3" runat="server" 
            meta:resourcekey="lblNetCashP3Resource1"></asp:Label></td
    
    </tr>
      <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr><td colspan="4">
     <asp:Localize ID="locPara4" runat="server" 
            Text="
This refers to the total cash that your business generates in each of the projection periods. If the amount is positive,
 your business is generating positive cash and will add on to your cash reserves. If the amount is negative, it means
  your business activities is not generating positive cash flow and will deplete your cash reserves." 
            meta:resourcekey="locPara4Resource1"></asp:Localize>							
							
							

    </td></tr>
      <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr  style=" font-weight:bold;  background-color:#ccecff; width:301px"><td>
        <asp:Label ID="lblCashBalance" runat="server" 
            Text="(D) Cash Balance as at the end of period of period" 
            meta:resourcekey="lblCashBalanceResource1"></asp:Label>
    </td>
        <td style="width:83px" align="right"><asp:Label ID="lblCashBalanceP1" 
                runat="server" meta:resourcekey="lblCashBalanceP1Resource1"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblCashBalanceP2" 
            runat="server" meta:resourcekey="lblCashBalanceP2Resource1"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblCashBalanceP3" 
            runat="server" meta:resourcekey="lblCashBalanceP3Resource1"></asp:Label></td
    
    </tr>
      <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr><td colspan="4">
     <asp:Localize ID="locPara5" runat="server" 
            Text="
    This refers to the cash balance as at the end of each of the projection periods. This is computed by adding
     the beginning cash balance of the period to the net cash surplus/(shortfall) for the period." 
            meta:resourcekey="locPara5Resource1"></asp:Localize>											
							

    </td></tr>
     <tr><td>
         <asp:Label ID="lblbeginningofperiod" runat="server" 
             Text="Cash balance as at the beginning of period" 
             meta:resourcekey="lblbeginningofperiodResource1"></asp:Label>
     </td><td Style="width:83px" align="right"><asp:Label ID="lblCashBalP1" runat="server" 
                 meta:resourcekey="lblCashBalP1Resource1"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblCashBalP2" runat="server" 
            meta:resourcekey="lblCashBalP2Resource1"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblCashBalP3" runat="server" 
            meta:resourcekey="lblCashBalP3Resource1"></asp:Label></td
    
    </tr>
      <tr><td style="width:301px">
          <asp:Label ID="lblshortfall" runat="server" 
              Text="Add : (C) Total net cash surplus/(shortfall) for the period" 
              meta:resourcekey="lblshortfallResource1"></asp:Label>
      </td>
        <td style="width:83px" align="right" class="tdbottom">
            <asp:Label ID="lblTotelNetCashP1" runat="server" 
                meta:resourcekey="lblTotelNetCashP1Resource1"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom">
        <asp:Label ID="lblTotelNetCashP2" runat="server" 
            meta:resourcekey="lblTotelNetCashP2Resource1"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom">
        <asp:Label ID="lblTotelNetCashP3" runat="server" 
            meta:resourcekey="lblTotelNetCashP3Resource1"></asp:Label></td
    
    </tr>
      <tr style=" font-weight:bold;"><td style=" font-weight:bold; width:301px">
          <asp:Label ID="lblendofperiod" runat="server" 
              Text="Cash balance as at the end of period" 
              meta:resourcekey="lblendofperiodResource1"></asp:Label>
      </td>
        <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblCashBal1P1" 
                runat="server" meta:resourcekey="lblCashBal1P1Resource1"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblCashBal1P2" 
            runat="server" meta:resourcekey="lblCashBal1P2Resource1"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblCashBal1P3" 
            runat="server" meta:resourcekey="lblCashBal1P3Resource1"></asp:Label></td
    
    </tr>
           <tr>
      <td class="spacer">
            &nbsp;
        </td>
    </tr>
      <tr  style=" page-break-before: always;">
      <td class="spacer">
            &nbsp;
        </td>
    </tr>
      <tr  style=" font-weight:bold; background-color:#ccecff; width:301px;"><td>
          <asp:Label ID="lblHeadroomsurplus" runat="server" 
              Text="(E) Headroom surplus/(shortfall)" 
              meta:resourcekey="lblHeadroomsurplusResource1"></asp:Label>
      </td>
        <td style="width:83px" align="right"><asp:Label ID="lblHeadroomSurplusP1" 
                runat="server" meta:resourcekey="lblHeadroomSurplusP1Resource1"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblHeadroomSurplusP2" 
            runat="server" meta:resourcekey="lblHeadroomSurplusP2Resource1"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblHeadroomSurplusP3" 
            runat="server" meta:resourcekey="lblHeadroomSurplusP3Resource1"></asp:Label></td
    
    </tr>
      <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
      <tr><td style="width:301px">
      <asp:Label ID="lblCashBal" runat="server" 
              Text="Cash balance as at the end of period" 
              meta:resourcekey="lblCashBalResource1"></asp:Label>
      </td>
        <td style="width:83px" align="right"><asp:Label ID="lblCashBalance1P1" 
                runat="server" meta:resourcekey="lblCashBalance1P1Resource1"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblCashBalance1P2" 
            runat="server" meta:resourcekey="lblCashBalance1P2Resource1"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblCashBalance1P3" 
            runat="server" meta:resourcekey="lblCashBalance1P3Resource1"></asp:Label></td
    
    </tr>
      <tr><td style="width:301px">
      <asp:Label ID="lblUnutilised" runat="server" 
              Text="Add : Unutilised credit facilities" 
              meta:resourcekey="lblUnutilisedResource1"></asp:Label>
      </td>
        <td style="width:83px" align="right"><asp:Label ID="lblUnutilisedP1" runat="server" 
                meta:resourcekey="lblUnutilisedP1Resource1"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblUnutilisedP2" runat="server" 
            meta:resourcekey="lblUnutilisedP2Resource1"></asp:Label></td>
    <td style="width:83px" align="right"><asp:Label ID="lblUnutilisedP3" runat="server" 
            meta:resourcekey="lblUnutilisedP3Resource1"></asp:Label></td
    
    </tr>
      <tr><td style="width:301px">
      <asp:Label ID="lblRestricted" runat="server" 
              Text="Less : Restricted Cash (Cash Pledged to Bank/(s))" 
              meta:resourcekey="lblRestrictedResource1"></asp:Label>
      </td>
        <td style="width:83px" align="right" class="tdbottom">
            <asp:Label ID="lblRestrictedP1" runat="server" 
                meta:resourcekey="lblRestrictedP1Resource1"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom">
        <asp:Label ID="lblRestrictedP2" runat="server" 
            meta:resourcekey="lblRestrictedP2Resource1"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom">
        <asp:Label ID="lblRestrictedP3" runat="server" 
            meta:resourcekey="lblRestrictedP3Resource1"></asp:Label></td
    
    </tr>
      <tr  style=" font-weight:bold" style="width:301px"><td>
      <asp:Label ID="lblHeadroom" runat="server" Text="Headroom Surplus/(Shortfall)" 
              meta:resourcekey="lblHeadroomResource1"></asp:Label>
      </td>
        <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblHeadroomP1" 
                runat="server" meta:resourcekey="lblHeadroomP1Resource1"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblHeadroomP2" 
            runat="server" meta:resourcekey="lblHeadroomP2Resource1"></asp:Label></td>
    <td style="width:83px" align="right" class="tdbottom"><asp:Label ID="lblHeadroomP3" 
            runat="server" meta:resourcekey="lblHeadroomP3Resource1"></asp:Label></td
    
    </tr>
     <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr><td colspan="4" style="text-align:justify">
    <asp:Localize ID="locPara6" runat="server" 
            Text="
    This represents the free cash reserves (excluding cash that may be pledged to the banks / financial institutions as
     collateral for your credit facilities) and unutilised credit facilities that are available as at the end of each
      of the projection periods. If this is surplus (<b>positive</b> amount), it means you have sufficient cash reserves
       and credit facilities (after excluding the pledged cash) to fund your business needs." 
            meta:resourcekey="locPara6Resource1"></asp:Localize> 

        <br />
        <br />
        <asp:Localize ID="locPara7" runat="server" 
            Text="
        If it is shortfall (<b>negative</b> amount), it means even you have exhausted all the cash reserves and utilised
         the credit facilities in full, there is still insufficient cash to fund your projected activities.  You are likely
          to experience strain in your cash flow. Therefore, you may like to consider (a) raising more debt and/or equity if
           your business is viable, i.e. you are expecting to record profitability and your balance sheet is relatively
            healthy; and (b) look into areas of improving your working capital management and profitability." 
            meta:resourcekey="locPara7Resource1"></asp:Localize>						
							
							
							
							
							
							

    </td></tr>
    
      <tr>
        <td class="spacer">
            &nbsp;
            <asp:Label ID="lblfy" runat="server" Visible="False" 
                meta:resourcekey="lblfyResource1"></asp:Label>
            <asp:Label ID="lblp" runat="server" Visible="False" 
                meta:resourcekey="lblpResource1"></asp:Label>
        </td>
    </tr>
      </table>
    </td></tr>
        
 
     

</table>

