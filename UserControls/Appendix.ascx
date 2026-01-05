<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Appendix.ascx.cs" Inherits="UserControls_Appendix" %>
<table width="90%" border="0" align="center" cellpadding="0" cellspacing="0" style="padding-left: 25px;">
    <tr>
        <td class="spacer">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="0" cellspacing="0" border="0" width="680">
                <tr>
                    <td class="appendix">
                        <asp:Label ID="lblHeading" runat="server" 
                            Text="Appendix B - Trade Cycle Report" meta:resourcekey="lblHeadingResource1"></asp:Label>
                        <%--<asp:Image ID="imgHeader" runat="server" Width="680" ImageUrl="~/images/appendixbar.png" />--%>
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
    <tr id="trTradeCycle" runat="server">
        <td>
            <table>
                <tr>
                    <td align="left" valign="top">
                        <h3>
                            <asp:Label ID="lblTradecycle" runat="server" 
                                Text="Trade Cycle Report based on Current Year Estimate" 
                                meta:resourcekey="lblTradecycleResource1"></asp:Label>
                        </h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="680" border="0" align="center" cellpadding="3" cellspacing="0" class="FontStyle">
                            <tr style="background-color: #376091; color: White; font-weight: bold">
                                <td width="141" height="35">
                                    <asp:Label ID="lblDays" runat="server" Text="Days" 
                                        meta:resourcekey="lblDaysResource1"></asp:Label>
                                </td>
                                <td width="201">
                                    <asp:Label ID="lblCumulativeDays" runat="server" Text="Cumulative Days" 
                                        meta:resourcekey="lblCumulativeDaysResource1"></asp:Label>
                                </td>
                                <td width="237">
                                    <asp:Label ID="lbl1TradeCycle" runat="server" Text="Trade Cycle" 
                                        meta:resourcekey="lbl1TradeCycleResource1"></asp:Label>
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
                                    <asp:Label ID="lblDay1" runat="server" Text="0" 
                                        meta:resourcekey="lblDay1Resource1" />
                                    &nbsp;
                                    <asp:Label ID="lbl2days" runat="server" Text="days" 
                                        meta:resourcekey="lbl2daysResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCDay1" runat="server" meta:resourcekey="lblCDay1Resource1" />
                                    &nbsp;
                                    <asp:Label ID="lbl3days" runat="server" Text="days" 
                                        meta:resourcekey="lbl3daysResource1"></asp:Label>
                                </td>
                                <td height="30" align="center" class="blue-border">
                                    <asp:Label ID="lblPlaceOrderwithSupplier" runat="server" 
                                        Text="Place Order with Supplier" 
                                        meta:resourcekey="lblPlaceOrderwithSupplierResource1"></asp:Label>
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
                                    <asp:Label ID="lblCDay7" runat="server" meta:resourcekey="lblCDay7Resource1" />
                                    &nbsp;
                                    
                                    <asp:Label ID="lbl4Days" runat="server" Text="days" 
                                        meta:resourcekey="lbl4DaysResource1"></asp:Label>
                                </td>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDay2" runat="server" meta:resourcekey="lblDay2Resource1" />
                                    &nbsp;<asp:Label ID="lbl5Days" runat="server" Text="days" 
                                        meta:resourcekey="lbl5DaysResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCDay2" runat="server" meta:resourcekey="lblCDay2Resource1" />
                                    &nbsp;<asp:Label ID="lbl6Days" runat="server" Text="days" 
                                        meta:resourcekey="lbl6DaysResource1"></asp:Label>
                                </td>
                                <td height="30" align="center" class="blue-border">
                                <asp:Label ID="lblGoodsshippedbySupplier" runat="server" 
                                        Text="Goods shipped by Supplier" 
                                        meta:resourcekey="lblGoodsshippedbySupplierResource1"></asp:Label>
                                    
                                </td>
                                <td align="center">
                                    <img src="../images/arrow_right_new.png" height="17" alt="" />
                                </td>
                                <td height="30" align="center" class="blue-border">
                                <asp:Label ID="lblPaymenttoSupplier" runat="server" Text="Payment to Supplier" 
                                        meta:resourcekey="lblPaymenttoSupplierResource1"></asp:Label>
                                    
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
                                    <asp:Label ID="lblDay3" runat="server" meta:resourcekey="lblDay3Resource1" />
                                    &nbsp;<asp:Label ID="lbl8Days" runat="server" Text="days" 
                                        meta:resourcekey="lbl8DaysResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCDay3" runat="server" meta:resourcekey="lblCDay3Resource1" />
                                    &nbsp;<asp:Label ID="lbl9Days" runat="server" Text="days" 
                                        meta:resourcekey="lbl9DaysResource1"></asp:Label>
                                </td>
                                <td height="30" align="center" class="blue-border">
                                <asp:Label ID="lblReceiptofGoodsbyyou" runat="server" 
                                        Text="Receipt of Goods by you" 
                                        meta:resourcekey="lblReceiptofGoodsbyyouResource1"></asp:Label>
                                    
                                </td>
                                <td colspan="3" rowspan="7">
                                    <table width="150" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="26" style="border-top: 1px solid #376091;">
                                                &nbsp;
                                                <%--    <img src="../images/line.jpg" width="26" height="1" alt=""  />--%>
                                            </td>
                                            <td width="0" rowspan="3" style="border-left: 1px solid #376091;">
                                                &nbsp;
                                            </td>
                                            <td width="109" rowspan="3">
                                                <table border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td align="left">
                                                            <img src="../images/arrow_right.png" width="26" height="17" alt="" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCDay8" runat="server" meta:resourcekey="lblCDay8Resource1" />
                                                            &nbsp;<asp:Label ID="lbl10Days" runat="server" Text="days" 
                                                                meta:resourcekey="lbl10DaysResource1"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="14">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="225" colspan="4">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border-bottom: 1px solid #376091;">
                                                &nbsp;
                                                <%--   <img src="../images/line.jpg" width="26" height="1" alt="" />--%>
                                            </td>
                                            <td colspan="3">
                                                &nbsp;
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
                                    <asp:Label ID="lblDay4" runat="server" meta:resourcekey="lblDay4Resource1" />
                                    &nbsp;<asp:Label ID="lbl11Days" runat="server" Text="days" 
                                        meta:resourcekey="lbl11DaysResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCDay4" runat="server" meta:resourcekey="lblCDay4Resource1" />
                                    &nbsp;<asp:Label ID="lbl12Days" runat="server" Text="days" 
                                        meta:resourcekey="lbl12DaysResource1"></asp:Label>
                                </td>
                                <td align="center" class="blue-border">
                                <asp:Label ID="lblProcessing" runat="server" Text="Processing" 
                                        meta:resourcekey="lblProcessingResource1"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblManufacturing" runat="server" 
                                        Text="(Manufacturing / Assembly / Packing)" 
                                        meta:resourcekey="lblManufacturingResource1"></asp:Label>
                                    
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
                                    <asp:Label ID="lblDay5" runat="server" meta:resourcekey="lblDay5Resource1" />
                                    &nbsp;<asp:Label ID="lbl13Days" runat="server" Text="days" 
                                        meta:resourcekey="lbl13DaysResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCDay5" runat="server" meta:resourcekey="lblCDay5Resource1" />
                                    &nbsp;<asp:Label ID="lbl14Days" runat="server" Text="days" 
                                        meta:resourcekey="lbl14DaysResource1"></asp:Label>
                                </td>
                                <td align="center" class="blue-border">
                                <asp:Label ID="lblDelivery" runat="server" Text="Delivery of goods to" 
                                        meta:resourcekey="lblDeliveryResource1"></asp:Label>
                                    
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
                                    <asp:Label ID="lblDay6" runat="server" meta:resourcekey="lblDay6Resource1" />
                                    &nbsp;<asp:Label ID="lbl15Days" runat="server" Text="days" 
                                        meta:resourcekey="lbl15DaysResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCDay6" runat="server" meta:resourcekey="lblCDay6Resource1" />
                                    &nbsp;<asp:Label ID="lbl16Days" runat="server" Text="days" 
                                        meta:resourcekey="lbl16DaysResource1"></asp:Label>
                                </td>
                                <td height="30" align="center" class="blue-border">
                                <asp:Label ID="lblReceiptsfromCustomer" runat="server" 
                                        Text="Receipts from Customer" 
                                        meta:resourcekey="lblReceiptsfromCustomerResource1"></asp:Label>
                                    
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
                     <asp:Label ID="lbl2Tradecycle" runat="server" 
                            Text="Trade cycle is the time that it takes to process a trade from start to end." 
                            meta:resourcekey="lbl2TradecycleResource1"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="lblThetrade" runat="server" Text="The trade starts when you place an order and ends when you receive payment from
                        your customers and when you pay your supplier, whichever is later." 
                            meta:resourcekey="lblThetradeResource1"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="lblAvg" runat="server" 
                            Text="Your average trade cycle days is approximately" 
                            meta:resourcekey="lblAvgResource1"></asp:Label>
                        
                        <asp:Label ID="lblCycleDays" runat="server" 
                            meta:resourcekey="lblCycleDaysResource1"></asp:Label>
                        <asp:Label ID="lbl17Days" runat="server" Text="days." 
                            meta:resourcekey="lbl17DaysResource1"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="lblFinancingPeriod" runat="server" 
                            meta:resourcekey="lblFinancingPeriodResource1"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="lblFinancingPeriodIncrease" runat="server" 
                            meta:resourcekey="lblFinancingPeriodIncreaseResource1"></asp:Label>
                        <br />
                        <br />
                        <span style="color: #FF0000"><b><u>
                         <asp:Label ID="lblImportantToNote" runat="server" Text="Important To Note" 
                            meta:resourcekey="lblImportantToNoteResource1"></asp:Label>
                        </u></b> </span>:<br />
                        <br />
                         <asp:Label ID="lblcalculation" runat="server" Text="The calculation is made based on information provided by you and is for indicative
                        purposes only." meta:resourcekey="lblcalculationResource1"></asp:Label>
                        
                    </td>
                </tr>
                <tr>
                    <td class="spacer">
                        &nbsp;
                        <asp:Label ID="lblDes1" runat="server" Visible="False" 
                            meta:resourcekey="lblDes1Resource1"></asp:Label>
                        <asp:Label ID="lblDes2" runat="server" Visible="False" 
                            meta:resourcekey="lblDes2Resource1"></asp:Label>
                        <asp:Label ID="lblDes3" runat="server" Visible="False" 
                            meta:resourcekey="lblDes3Resource1"></asp:Label>
                        <asp:Label ID="lblDes4" runat="server" Visible="False" 
                            meta:resourcekey="lblDes4Resource1"></asp:Label>
                        <asp:Label ID="lblDes5" runat="server" Visible="False" 
                            meta:resourcekey="lblDes5Resource1"></asp:Label>
                        <asp:Label ID="lblDes6" runat="server" Visible="False" 
                            meta:resourcekey="lblDes6Resource1"></asp:Label>

                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
